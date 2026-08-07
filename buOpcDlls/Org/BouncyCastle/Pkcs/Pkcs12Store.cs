// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Pkcs.Pkcs12Store
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Asn1.Misc;
using Org.BouncyCastle.Asn1.Oiw;
using Org.BouncyCastle.Asn1.Pkcs;
using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Security;
using Org.BouncyCastle.Utilities;
using Org.BouncyCastle.Utilities.Collections;
using Org.BouncyCastle.Utilities.Encoders;
using Org.BouncyCastle.X509;
using System;
using System.Collections.Generic;
using System.IO;

#nullable disable
namespace Org.BouncyCastle.Pkcs;

public class Pkcs12Store
{
  public const string IgnoreUselessPasswordProperty = "Org.BouncyCastle.Pkcs12.IgnoreUselessPassword";
  private readonly Dictionary<string, AsymmetricKeyEntry> m_keys = new Dictionary<string, AsymmetricKeyEntry>((IEqualityComparer<string>) StringComparer.OrdinalIgnoreCase);
  private readonly Dictionary<string, string> m_localIds = new Dictionary<string, string>();
  private readonly Dictionary<string, X509CertificateEntry> m_certs = new Dictionary<string, X509CertificateEntry>((IEqualityComparer<string>) StringComparer.OrdinalIgnoreCase);
  private readonly Dictionary<Pkcs12Store.CertId, X509CertificateEntry> m_chainCerts = new Dictionary<Pkcs12Store.CertId, X509CertificateEntry>();
  private readonly Dictionary<string, X509CertificateEntry> m_keyCerts = new Dictionary<string, X509CertificateEntry>();
  private readonly DerObjectIdentifier keyAlgorithm;
  private readonly DerObjectIdentifier keyPrfAlgorithm;
  private readonly DerObjectIdentifier certAlgorithm;
  private readonly bool useDerEncoding;
  private AsymmetricKeyEntry unmarkedKeyEntry;
  private const int MinIterations = 1024 /*0x0400*/;
  private const int SaltSize = 20;

  private static SubjectKeyIdentifier CreateSubjectKeyID(AsymmetricKeyParameter pubKey)
  {
    return new SubjectKeyIdentifier(SubjectPublicKeyInfoFactory.CreateSubjectPublicKeyInfo(pubKey));
  }

  internal Pkcs12Store(
    DerObjectIdentifier keyAlgorithm,
    DerObjectIdentifier keyPrfAlgorithm,
    DerObjectIdentifier certAlgorithm,
    bool useDerEncoding)
  {
    this.keyAlgorithm = keyAlgorithm;
    this.keyPrfAlgorithm = keyPrfAlgorithm;
    this.certAlgorithm = certAlgorithm;
    this.useDerEncoding = useDerEncoding;
  }

  protected virtual void LoadKeyBag(PrivateKeyInfo privKeyInfo, Asn1Set bagAttributes)
  {
    AsymmetricKeyParameter key1 = PrivateKeyFactory.CreateKey(privKeyInfo);
    Dictionary<DerObjectIdentifier, Asn1Encodable> dictionary = new Dictionary<DerObjectIdentifier, Asn1Encodable>();
    Dictionary<DerObjectIdentifier, Asn1Encodable> attributes = dictionary;
    AsymmetricKeyEntry asymmetricKeyEntry = new AsymmetricKeyEntry(key1, (IDictionary<DerObjectIdentifier, Asn1Encodable>) attributes);
    string key2 = (string) null;
    Asn1OctetString asn1OctetString = (Asn1OctetString) null;
    if (bagAttributes != null)
    {
      foreach (Asn1Sequence bagAttribute in bagAttributes)
      {
        DerObjectIdentifier instance1 = DerObjectIdentifier.GetInstance((object) bagAttribute[0]);
        Asn1Set instance2 = Asn1Set.GetInstance((object) bagAttribute[1]);
        if (instance2.Count > 0)
        {
          Asn1Encodable asn1Encodable1 = instance2[0];
          Asn1Encodable asn1Encodable2;
          if (dictionary.TryGetValue(instance1, out asn1Encodable2))
          {
            if (!asn1Encodable2.Equals((object) asn1Encodable1))
              throw new IOException("attempt to add existing attribute with different value");
          }
          else
            dictionary[instance1] = asn1Encodable1;
          if (instance1.Equals((Asn1Object) PkcsObjectIdentifiers.Pkcs9AtFriendlyName))
          {
            key2 = ((DerStringBase) asn1Encodable1).GetString();
            this.m_keys[key2] = asymmetricKeyEntry;
          }
          else if (instance1.Equals((Asn1Object) PkcsObjectIdentifiers.Pkcs9AtLocalKeyID))
            asn1OctetString = (Asn1OctetString) asn1Encodable1;
        }
      }
    }
    if (asn1OctetString != null)
    {
      string hexString = Hex.ToHexString(asn1OctetString.GetOctets());
      if (key2 == null)
        this.m_keys[hexString] = asymmetricKeyEntry;
      else
        this.m_localIds[key2] = hexString;
    }
    else
      this.unmarkedKeyEntry = asymmetricKeyEntry;
  }

  protected virtual void LoadPkcs8ShroudedKeyBag(
    EncryptedPrivateKeyInfo encPrivKeyInfo,
    Asn1Set bagAttributes,
    char[] password,
    bool wrongPkcs12Zero)
  {
    if (password == null)
      return;
    this.LoadKeyBag(PrivateKeyInfoFactory.CreatePrivateKeyInfo(password, wrongPkcs12Zero, encPrivKeyInfo), bagAttributes);
  }

  public void Load(Stream input, char[] password)
  {
    Pfx pfx = input != null ? Pfx.GetInstance((object) Asn1Object.FromStream(input)) : throw new ArgumentNullException(nameof (input));
    ContentInfo authSafe = pfx.AuthSafe;
    bool wrongPkcs12Zero = false;
    if (pfx.MacData != null)
    {
      if (password == null)
        throw new ArgumentNullException(nameof (password), "no password supplied when one expected");
      MacData macData = pfx.MacData;
      DigestInfo mac = macData.Mac;
      AlgorithmIdentifier algorithmId = mac.AlgorithmID;
      byte[] salt = macData.GetSalt();
      int intValue = macData.IterationCount.IntValue;
      byte[] octets = Asn1OctetString.GetInstance((object) authSafe.Content).GetOctets();
      byte[] pbeMac = Pkcs12Store.CalculatePbeMac(algorithmId.Algorithm, salt, intValue, password, false, octets);
      byte[] digest = mac.GetDigest();
      byte[] b = digest;
      if (!Arrays.FixedTimeEquals(pbeMac, b))
      {
        if (password.Length != 0)
          throw new IOException("PKCS12 key store MAC invalid - wrong password or corrupted file.");
        if (!Arrays.FixedTimeEquals(Pkcs12Store.CalculatePbeMac(algorithmId.Algorithm, salt, intValue, password, true, octets), digest))
          throw new IOException("PKCS12 key store MAC invalid - wrong password or corrupted file.");
        wrongPkcs12Zero = true;
      }
    }
    else if (password != null)
    {
      string environmentVariable = Platform.GetEnvironmentVariable("Org.BouncyCastle.Pkcs12.IgnoreUselessPassword");
      if ((environmentVariable == null ? 0 : (Platform.EqualsIgnoreCase("true", environmentVariable) ? 1 : 0)) == 0)
        throw new IOException("password supplied for keystore that does not require one");
    }
    this.m_keys.Clear();
    this.m_localIds.Clear();
    this.unmarkedKeyEntry = (AsymmetricKeyEntry) null;
    List<SafeBag> safeBagList = new List<SafeBag>();
    if (authSafe.ContentType.Equals((Asn1Object) PkcsObjectIdentifiers.Data))
    {
      foreach (ContentInfo contentInfo in AuthenticatedSafe.GetInstance((object) Asn1OctetString.GetInstance((object) authSafe.Content).GetOctets()).GetContentInfo())
      {
        DerObjectIdentifier contentType = contentInfo.ContentType;
        byte[] numArray = (byte[]) null;
        if (contentType.Equals((Asn1Object) PkcsObjectIdentifiers.Data))
          numArray = Asn1OctetString.GetInstance((object) contentInfo.Content).GetOctets();
        else if (contentType.Equals((Asn1Object) PkcsObjectIdentifiers.EncryptedData) && password != null)
        {
          EncryptedData instance = EncryptedData.GetInstance((object) contentInfo.Content);
          numArray = Pkcs12Store.CryptPbeData(false, instance.EncryptionAlgorithm, password, wrongPkcs12Zero, instance.Content.GetOctets());
        }
        if (numArray != null)
        {
          foreach (Asn1Sequence asn1Sequence in Asn1Sequence.GetInstance((object) numArray))
          {
            SafeBag instance = SafeBag.GetInstance((object) asn1Sequence);
            if (instance.BagID.Equals((Asn1Object) PkcsObjectIdentifiers.CertBag))
              safeBagList.Add(instance);
            else if (instance.BagID.Equals((Asn1Object) PkcsObjectIdentifiers.Pkcs8ShroudedKeyBag))
              this.LoadPkcs8ShroudedKeyBag(EncryptedPrivateKeyInfo.GetInstance((object) instance.BagValue), instance.BagAttributes, password, wrongPkcs12Zero);
            else if (instance.BagID.Equals((Asn1Object) PkcsObjectIdentifiers.KeyBag))
              this.LoadKeyBag(PrivateKeyInfo.GetInstance((object) instance.BagValue), instance.BagAttributes);
          }
        }
      }
    }
    this.m_certs.Clear();
    this.m_chainCerts.Clear();
    this.m_keyCerts.Clear();
    foreach (SafeBag safeBag in safeBagList)
    {
      X509Certificate cert = new X509CertificateParser().ReadCertificate(((Asn1OctetString) CertBag.GetInstance((object) safeBag.BagValue).CertValue).GetOctets());
      Dictionary<DerObjectIdentifier, Asn1Encodable> attributes = new Dictionary<DerObjectIdentifier, Asn1Encodable>();
      Asn1OctetString asn1OctetString = (Asn1OctetString) null;
      string key1 = (string) null;
      if (safeBag.BagAttributes != null)
      {
        foreach (Asn1Sequence bagAttribute in safeBag.BagAttributes)
        {
          DerObjectIdentifier instance1 = DerObjectIdentifier.GetInstance((object) bagAttribute[0]);
          Asn1Set instance2 = Asn1Set.GetInstance((object) bagAttribute[1]);
          if (instance2.Count > 0)
          {
            Asn1Encodable asn1Encodable1 = instance2[0];
            Asn1Encodable asn1Encodable2;
            if (attributes.TryGetValue(instance1, out asn1Encodable2))
            {
              if (PkcsObjectIdentifiers.Pkcs9AtLocalKeyID.Equals((Asn1Object) instance1))
              {
                string hexString = Hex.ToHexString(Asn1OctetString.GetInstance((object) asn1Encodable1).GetOctets());
                if (!this.m_keys.ContainsKey(hexString) && !this.m_localIds.ContainsKey(hexString))
                  continue;
              }
              if (!asn1Encodable2.Equals((object) asn1Encodable1))
                throw new IOException("attempt to add existing attribute with different value");
            }
            else
              attributes[instance1] = asn1Encodable1;
            if (instance1.Equals((Asn1Object) PkcsObjectIdentifiers.Pkcs9AtFriendlyName))
              key1 = ((DerStringBase) asn1Encodable1).GetString();
            else if (instance1.Equals((Asn1Object) PkcsObjectIdentifiers.Pkcs9AtLocalKeyID))
              asn1OctetString = (Asn1OctetString) asn1Encodable1;
          }
        }
      }
      Pkcs12Store.CertId key2 = new Pkcs12Store.CertId(cert.GetPublicKey());
      X509CertificateEntry certificateEntry = new X509CertificateEntry(cert, (IDictionary<DerObjectIdentifier, Asn1Encodable>) attributes);
      this.m_chainCerts[key2] = certificateEntry;
      if (this.unmarkedKeyEntry != null)
      {
        if (this.m_keyCerts.Count == 0)
        {
          string hexString = Hex.ToHexString(key2.Id);
          this.m_keyCerts[hexString] = certificateEntry;
          this.m_keys[hexString] = this.unmarkedKeyEntry;
        }
        else
          this.m_keys["unmarked"] = this.unmarkedKeyEntry;
      }
      else
      {
        if (asn1OctetString != null)
          this.m_keyCerts[Hex.ToHexString(asn1OctetString.GetOctets())] = certificateEntry;
        if (key1 != null)
          this.m_certs[key1] = certificateEntry;
      }
    }
  }

  public AsymmetricKeyEntry GetKey(string alias)
  {
    return alias != null ? CollectionUtilities.GetValueOrNull<string, AsymmetricKeyEntry>((IDictionary<string, AsymmetricKeyEntry>) this.m_keys, alias) : throw new ArgumentNullException(nameof (alias));
  }

  public bool IsCertificateEntry(string alias)
  {
    if (alias == null)
      throw new ArgumentNullException(nameof (alias));
    return this.m_certs.ContainsKey(alias) && !this.m_keys.ContainsKey(alias);
  }

  public bool IsKeyEntry(string alias)
  {
    return alias != null ? this.m_keys.ContainsKey(alias) : throw new ArgumentNullException(nameof (alias));
  }

  public IEnumerable<string> Aliases
  {
    get
    {
      HashSet<string> e = new HashSet<string>((IEnumerable<string>) this.m_certs.Keys);
      e.UnionWith((IEnumerable<string>) this.m_keys.Keys);
      return CollectionUtilities.Proxy<string>((IEnumerable<string>) e);
    }
  }

  public bool ContainsAlias(string alias)
  {
    if (alias == null)
      throw new ArgumentNullException(nameof (alias));
    return this.m_certs.ContainsKey(alias) || this.m_keys.ContainsKey(alias);
  }

  public X509CertificateEntry GetCertificate(string alias)
  {
    if (alias == null)
      throw new ArgumentNullException(nameof (alias));
    X509CertificateEntry certificate;
    if (this.m_certs.TryGetValue(alias, out certificate))
      return certificate;
    string k = alias;
    string str;
    if (this.m_localIds.TryGetValue(alias, out str))
      k = str;
    return CollectionUtilities.GetValueOrNull<string, X509CertificateEntry>((IDictionary<string, X509CertificateEntry>) this.m_keyCerts, k);
  }

  public string GetCertificateAlias(X509Certificate cert)
  {
    if (cert == null)
      throw new ArgumentNullException(nameof (cert));
    foreach (KeyValuePair<string, X509CertificateEntry> cert1 in this.m_certs)
    {
      if (cert1.Value.Certificate.Equals((object) cert))
        return cert1.Key;
    }
    foreach (KeyValuePair<string, X509CertificateEntry> keyCert in this.m_keyCerts)
    {
      if (keyCert.Value.Certificate.Equals((object) cert))
        return keyCert.Key;
    }
    return (string) null;
  }

  public X509CertificateEntry[] GetCertificateChain(string alias)
  {
    if (alias == null)
      throw new ArgumentNullException(nameof (alias));
    if (!this.IsKeyEntry(alias))
      return (X509CertificateEntry[]) null;
    X509CertificateEntry certificateEntry1 = this.GetCertificate(alias);
    if (certificateEntry1 == null)
      return (X509CertificateEntry[]) null;
    List<X509CertificateEntry> certificateEntryList = new List<X509CertificateEntry>();
    X509CertificateEntry certificateEntry2;
    for (; certificateEntry1 != null; certificateEntry1 = certificateEntry2 == certificateEntry1 ? (X509CertificateEntry) null : certificateEntry2)
    {
      X509Certificate certificate1 = certificateEntry1.Certificate;
      certificateEntry2 = (X509CertificateEntry) null;
      Asn1OctetString extensionValue = certificate1.GetExtensionValue(X509Extensions.AuthorityKeyIdentifier);
      if (extensionValue != null)
      {
        byte[] keyIdentifier = AuthorityKeyIdentifier.GetInstance((object) extensionValue.GetOctets()).GetKeyIdentifier();
        if (keyIdentifier != null)
          certificateEntry2 = CollectionUtilities.GetValueOrNull<Pkcs12Store.CertId, X509CertificateEntry>((IDictionary<Pkcs12Store.CertId, X509CertificateEntry>) this.m_chainCerts, new Pkcs12Store.CertId(keyIdentifier));
      }
      if (certificateEntry2 == null)
      {
        X509Name issuerDn = certificate1.IssuerDN;
        X509Name subjectDn = certificate1.SubjectDN;
        if (!issuerDn.Equivalent(subjectDn))
        {
          foreach (KeyValuePair<Pkcs12Store.CertId, X509CertificateEntry> chainCert in this.m_chainCerts)
          {
            X509Certificate certificate2 = chainCert.Value.Certificate;
            if (certificate2.SubjectDN.Equivalent(issuerDn))
            {
              try
              {
                certificate1.Verify(certificate2.GetPublicKey());
                certificateEntry2 = chainCert.Value;
                break;
              }
              catch (InvalidKeyException ex)
              {
              }
            }
          }
        }
      }
      certificateEntryList.Add(certificateEntry1);
    }
    return certificateEntryList.ToArray();
  }

  public void SetCertificateEntry(string alias, X509CertificateEntry certEntry)
  {
    if (alias == null)
      throw new ArgumentNullException(nameof (alias));
    if (certEntry == null)
      throw new ArgumentNullException(nameof (certEntry));
    if (this.m_keys.ContainsKey(alias))
      throw new ArgumentException($"There is a key entry with the name {alias}.");
    this.m_certs[alias] = certEntry;
    this.m_chainCerts[new Pkcs12Store.CertId(certEntry.Certificate.GetPublicKey())] = certEntry;
  }

  public void SetKeyEntry(string alias, AsymmetricKeyEntry keyEntry, X509CertificateEntry[] chain)
  {
    if (alias == null)
      throw new ArgumentNullException(nameof (alias));
    if (keyEntry == null)
      throw new ArgumentNullException(nameof (keyEntry));
    if (keyEntry.Key.IsPrivate && chain == null)
      throw new ArgumentException("No certificate chain for private key");
    if (this.m_keys.ContainsKey(alias))
      this.DeleteEntry(alias);
    this.m_keys[alias] = keyEntry;
    this.m_certs[alias] = chain[0];
    for (int index = 0; index != chain.Length; ++index)
      this.m_chainCerts[new Pkcs12Store.CertId(chain[index].Certificate.GetPublicKey())] = chain[index];
  }

  public void DeleteEntry(string alias)
  {
    if (alias == null)
      throw new ArgumentNullException(nameof (alias));
    X509CertificateEntry v1;
    if (CollectionUtilities.Remove<string, X509CertificateEntry>((IDictionary<string, X509CertificateEntry>) this.m_certs, alias, out v1))
      this.m_chainCerts.Remove(new Pkcs12Store.CertId(v1.Certificate.GetPublicKey()));
    string v2;
    X509CertificateEntry v3;
    if (!this.m_keys.Remove(alias) || !CollectionUtilities.Remove<string, string>((IDictionary<string, string>) this.m_localIds, alias, out v2) || !CollectionUtilities.Remove<string, X509CertificateEntry>((IDictionary<string, X509CertificateEntry>) this.m_keyCerts, v2, out v3))
      return;
    this.m_chainCerts.Remove(new Pkcs12Store.CertId(v3.Certificate.GetPublicKey()));
  }

  public bool IsEntryOfType(string alias, Type entryType)
  {
    if (entryType == typeof (X509CertificateEntry))
      return this.IsCertificateEntry(alias);
    return entryType == typeof (AsymmetricKeyEntry) && this.IsKeyEntry(alias) && this.GetCertificate(alias) != null;
  }

  public int Count
  {
    get
    {
      int count = this.m_certs.Count;
      foreach (string key in this.m_keys.Keys)
      {
        if (!this.m_certs.ContainsKey(key))
          ++count;
      }
      return count;
    }
  }

  public void Save(Stream stream, char[] password, SecureRandom random)
  {
    if (stream == null)
      throw new ArgumentNullException(nameof (stream));
    if (random == null)
      throw new ArgumentNullException(nameof (random));
    Asn1EncodableVector elementVector1 = new Asn1EncodableVector(this.m_keys.Count);
    foreach (KeyValuePair<string, AsymmetricKeyEntry> key1 in this.m_keys)
    {
      string key2 = key1.Key;
      AsymmetricKeyEntry asymmetricKeyEntry = key1.Value;
      byte[] numArray = new byte[20];
      random.NextBytes(numArray);
      DerObjectIdentifier oid;
      Asn1Encodable asn1Encodable;
      if (password == null)
      {
        oid = PkcsObjectIdentifiers.KeyBag;
        asn1Encodable = (Asn1Encodable) PrivateKeyInfoFactory.CreatePrivateKeyInfo(asymmetricKeyEntry.Key);
      }
      else
      {
        oid = PkcsObjectIdentifiers.Pkcs8ShroudedKeyBag;
        asn1Encodable = this.keyPrfAlgorithm == null ? (Asn1Encodable) EncryptedPrivateKeyInfoFactory.CreateEncryptedPrivateKeyInfo(this.keyAlgorithm, password, numArray, 1024 /*0x0400*/, asymmetricKeyEntry.Key) : (Asn1Encodable) EncryptedPrivateKeyInfoFactory.CreateEncryptedPrivateKeyInfo(this.keyAlgorithm, this.keyPrfAlgorithm, password, numArray, 1024 /*0x0400*/, random, asymmetricKeyEntry.Key);
      }
      Asn1EncodableVector elementVector2 = new Asn1EncodableVector();
      foreach (DerObjectIdentifier bagAttributeKey in asymmetricKeyEntry.BagAttributeKeys)
      {
        if (!PkcsObjectIdentifiers.Pkcs9AtFriendlyName.Equals((Asn1Object) bagAttributeKey))
          elementVector2.Add((Asn1Encodable) new DerSequence((Asn1Encodable) bagAttributeKey, (Asn1Encodable) new DerSet(asymmetricKeyEntry[bagAttributeKey])));
      }
      elementVector2.Add((Asn1Encodable) new DerSequence((Asn1Encodable) PkcsObjectIdentifiers.Pkcs9AtFriendlyName, (Asn1Encodable) new DerSet((Asn1Encodable) new DerBmpString(key2))));
      if (asymmetricKeyEntry[PkcsObjectIdentifiers.Pkcs9AtLocalKeyID] == null)
      {
        SubjectKeyIdentifier subjectKeyId = Pkcs12Store.CreateSubjectKeyID(this.GetCertificate(key2).Certificate.GetPublicKey());
        elementVector2.Add((Asn1Encodable) new DerSequence((Asn1Encodable) PkcsObjectIdentifiers.Pkcs9AtLocalKeyID, (Asn1Encodable) new DerSet((Asn1Encodable) subjectKeyId)));
      }
      elementVector1.Add((Asn1Encodable) new SafeBag(oid, asn1Encodable.ToAsn1Object(), (Asn1Set) new DerSet(elementVector2)));
    }
    byte[] derEncoded1 = new DerSequence(elementVector1).GetDerEncoded();
    ContentInfo contentInfo1 = new ContentInfo(PkcsObjectIdentifiers.Data, (Asn1Encodable) new BerOctetString(derEncoded1));
    byte[] numArray1 = new byte[20];
    random.NextBytes(numArray1);
    Asn1EncodableVector elementVector3 = new Asn1EncodableVector(this.m_keys.Count);
    AlgorithmIdentifier algorithmIdentifier = new AlgorithmIdentifier(this.certAlgorithm, (Asn1Encodable) new Pkcs12PbeParams(numArray1, 1024 /*0x0400*/).ToAsn1Object());
    HashSet<X509Certificate> x509CertificateSet = new HashSet<X509Certificate>();
    foreach (string key in this.m_keys.Keys)
    {
      X509CertificateEntry certificate = this.GetCertificate(key);
      CertBag certBag = new CertBag(PkcsObjectIdentifiers.X509Certificate, (Asn1Object) new DerOctetString(certificate.Certificate.GetEncoded()));
      Asn1EncodableVector elementVector4 = new Asn1EncodableVector();
      foreach (DerObjectIdentifier bagAttributeKey in certificate.BagAttributeKeys)
      {
        if (!PkcsObjectIdentifiers.Pkcs9AtFriendlyName.Equals((Asn1Object) bagAttributeKey))
          elementVector4.Add((Asn1Encodable) new DerSequence((Asn1Encodable) bagAttributeKey, (Asn1Encodable) new DerSet(certificate[bagAttributeKey])));
      }
      elementVector4.Add((Asn1Encodable) new DerSequence((Asn1Encodable) PkcsObjectIdentifiers.Pkcs9AtFriendlyName, (Asn1Encodable) new DerSet((Asn1Encodable) new DerBmpString(key))));
      if (certificate[PkcsObjectIdentifiers.Pkcs9AtLocalKeyID] == null)
      {
        SubjectKeyIdentifier subjectKeyId = Pkcs12Store.CreateSubjectKeyID(certificate.Certificate.GetPublicKey());
        elementVector4.Add((Asn1Encodable) new DerSequence((Asn1Encodable) PkcsObjectIdentifiers.Pkcs9AtLocalKeyID, (Asn1Encodable) new DerSet((Asn1Encodable) subjectKeyId)));
      }
      elementVector3.Add((Asn1Encodable) new SafeBag(PkcsObjectIdentifiers.CertBag, certBag.ToAsn1Object(), (Asn1Set) new DerSet(elementVector4)));
      x509CertificateSet.Add(certificate.Certificate);
    }
    foreach (KeyValuePair<string, X509CertificateEntry> cert in this.m_certs)
    {
      string key = cert.Key;
      X509CertificateEntry certificateEntry = cert.Value;
      if (!this.m_keys.ContainsKey(key))
      {
        CertBag certBag = new CertBag(PkcsObjectIdentifiers.X509Certificate, (Asn1Object) new DerOctetString(certificateEntry.Certificate.GetEncoded()));
        Asn1EncodableVector elementVector5 = new Asn1EncodableVector();
        foreach (DerObjectIdentifier bagAttributeKey in certificateEntry.BagAttributeKeys)
        {
          if (!PkcsObjectIdentifiers.Pkcs9AtLocalKeyID.Equals((Asn1Object) bagAttributeKey) && !PkcsObjectIdentifiers.Pkcs9AtFriendlyName.Equals((Asn1Object) bagAttributeKey))
            elementVector5.Add((Asn1Encodable) new DerSequence((Asn1Encodable) bagAttributeKey, (Asn1Encodable) new DerSet(certificateEntry[bagAttributeKey])));
        }
        elementVector5.Add((Asn1Encodable) new DerSequence((Asn1Encodable) PkcsObjectIdentifiers.Pkcs9AtFriendlyName, (Asn1Encodable) new DerSet((Asn1Encodable) new DerBmpString(key))));
        if (certificateEntry[MiscObjectIdentifiers.id_oracle_pkcs12_trusted_key_usage] == null)
        {
          Asn1OctetString extensionValue = certificateEntry.Certificate.GetExtensionValue(X509Extensions.ExtendedKeyUsage);
          if (extensionValue != null)
          {
            IList<DerObjectIdentifier> allUsages = ExtendedKeyUsage.GetInstance((object) extensionValue.GetOctets()).GetAllUsages();
            Asn1EncodableVector elementVector6 = new Asn1EncodableVector(allUsages.Count);
            for (int index = 0; index != allUsages.Count; ++index)
              elementVector6.Add((Asn1Encodable) allUsages[index]);
            elementVector5.Add((Asn1Encodable) new DerSequence((Asn1Encodable) MiscObjectIdentifiers.id_oracle_pkcs12_trusted_key_usage, (Asn1Encodable) new DerSet(elementVector6)));
          }
          else
            elementVector5.Add((Asn1Encodable) new DerSequence((Asn1Encodable) MiscObjectIdentifiers.id_oracle_pkcs12_trusted_key_usage, (Asn1Encodable) new DerSet((Asn1Encodable) KeyPurposeID.AnyExtendedKeyUsage)));
        }
        elementVector3.Add((Asn1Encodable) new SafeBag(PkcsObjectIdentifiers.CertBag, certBag.ToAsn1Object(), (Asn1Set) new DerSet(elementVector5)));
        x509CertificateSet.Add(certificateEntry.Certificate);
      }
    }
    foreach (KeyValuePair<Pkcs12Store.CertId, X509CertificateEntry> chainCert in this.m_chainCerts)
    {
      Pkcs12Store.CertId key = chainCert.Key;
      X509CertificateEntry certificateEntry = chainCert.Value;
      if (!x509CertificateSet.Contains(certificateEntry.Certificate))
      {
        CertBag certBag = new CertBag(PkcsObjectIdentifiers.X509Certificate, (Asn1Object) new DerOctetString(certificateEntry.Certificate.GetEncoded()));
        Asn1EncodableVector elementVector7 = new Asn1EncodableVector();
        foreach (DerObjectIdentifier bagAttributeKey in certificateEntry.BagAttributeKeys)
        {
          if (!PkcsObjectIdentifiers.Pkcs9AtLocalKeyID.Equals((Asn1Object) bagAttributeKey))
            elementVector7.Add((Asn1Encodable) new DerSequence((Asn1Encodable) bagAttributeKey, (Asn1Encodable) new DerSet(certificateEntry[bagAttributeKey])));
        }
        elementVector3.Add((Asn1Encodable) new SafeBag(PkcsObjectIdentifiers.CertBag, certBag.ToAsn1Object(), (Asn1Set) new DerSet(elementVector7)));
      }
    }
    byte[] derEncoded2 = new DerSequence(elementVector3).GetDerEncoded();
    ContentInfo contentInfo2;
    if (password != null && this.certAlgorithm != null)
    {
      byte[] contents = Pkcs12Store.CryptPbeData(true, algorithmIdentifier, password, false, derEncoded2);
      EncryptedData encryptedData = new EncryptedData(PkcsObjectIdentifiers.Data, algorithmIdentifier, (Asn1Encodable) new BerOctetString(contents));
      contentInfo2 = new ContentInfo(PkcsObjectIdentifiers.EncryptedData, (Asn1Encodable) encryptedData.ToAsn1Object());
    }
    else
      contentInfo2 = new ContentInfo(PkcsObjectIdentifiers.Data, (Asn1Encodable) new BerOctetString(derEncoded2));
    byte[] encoded = new AuthenticatedSafe(new ContentInfo[2]
    {
      contentInfo1,
      contentInfo2
    }).GetEncoded(this.useDerEncoding ? "DER" : "BER");
    ContentInfo contentInfo3 = new ContentInfo(PkcsObjectIdentifiers.Data, (Asn1Encodable) new BerOctetString(encoded));
    MacData macData1 = (MacData) null;
    if (password != null)
    {
      byte[] numArray2 = new byte[20];
      random.NextBytes(numArray2);
      byte[] pbeMac = Pkcs12Store.CalculatePbeMac(OiwObjectIdentifiers.IdSha1, numArray2, 1024 /*0x0400*/, password, false, encoded);
      macData1 = new MacData(new DigestInfo(new AlgorithmIdentifier(OiwObjectIdentifiers.IdSha1, (Asn1Encodable) DerNull.Instance), pbeMac), numArray2, 1024 /*0x0400*/);
    }
    MacData macData2 = macData1;
    new Pfx(contentInfo3, macData2).EncodeTo(stream, this.useDerEncoding ? "DER" : "BER");
  }

  internal static byte[] CalculatePbeMac(
    DerObjectIdentifier oid,
    byte[] salt,
    int itCount,
    char[] password,
    bool wrongPkcs12Zero,
    byte[] data)
  {
    Asn1Encodable algorithmParameters = PbeUtilities.GenerateAlgorithmParameters(oid, salt, itCount);
    ICipherParameters cipherParameters = PbeUtilities.GenerateCipherParameters(oid, password, wrongPkcs12Zero, algorithmParameters);
    IMac engine = (IMac) PbeUtilities.CreateEngine(oid);
    engine.Init(cipherParameters);
    return MacUtilities.DoFinal(engine, data);
  }

  private static byte[] CryptPbeData(
    bool forEncryption,
    AlgorithmIdentifier algId,
    char[] password,
    bool wrongPkcs12Zero,
    byte[] data)
  {
    if (!(PbeUtilities.CreateEngine(algId) is IBufferedCipher engine))
      throw new Exception("Unknown encryption algorithm: " + algId.Algorithm?.ToString());
    if (algId.Algorithm.Equals((Asn1Object) PkcsObjectIdentifiers.IdPbeS2))
    {
      PbeS2Parameters instance = PbeS2Parameters.GetInstance((object) algId.Parameters);
      ICipherParameters cipherParameters = PbeUtilities.GenerateCipherParameters(algId.Algorithm, password, (Asn1Encodable) instance);
      engine.Init(forEncryption, cipherParameters);
      return engine.DoFinal(data);
    }
    Pkcs12PbeParams instance1 = Pkcs12PbeParams.GetInstance((object) algId.Parameters);
    ICipherParameters cipherParameters1 = PbeUtilities.GenerateCipherParameters(algId.Algorithm, password, wrongPkcs12Zero, (Asn1Encodable) instance1);
    engine.Init(forEncryption, cipherParameters1);
    return engine.DoFinal(data);
  }

  internal class CertId
  {
    private readonly byte[] id;

    internal CertId(AsymmetricKeyParameter pubKey)
    {
      this.id = Pkcs12Store.CreateSubjectKeyID(pubKey).GetKeyIdentifier();
    }

    internal CertId(byte[] id) => this.id = id;

    internal byte[] Id => this.id;

    public override int GetHashCode() => Arrays.GetHashCode(this.id);

    public override bool Equals(object obj)
    {
      if (obj == this)
        return true;
      return obj is Pkcs12Store.CertId certId && Arrays.AreEqual(this.id, certId.id);
    }
  }
}
