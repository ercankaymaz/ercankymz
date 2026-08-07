// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.X509.X509Certificate
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Asn1.Misc;
using Org.BouncyCastle.Asn1.Utilities;
using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Operators;
using Org.BouncyCastle.Math;
using Org.BouncyCastle.Security;
using Org.BouncyCastle.Security.Certificates;
using Org.BouncyCastle.Utilities;
using Org.BouncyCastle.Utilities.Encoders;
using Org.BouncyCastle.X509.Extension;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

#nullable disable
namespace Org.BouncyCastle.X509;

public class X509Certificate : X509ExtensionBase
{
  private readonly X509CertificateStructure c;
  private readonly string sigAlgName;
  private readonly byte[] sigAlgParams;
  private readonly BasicConstraints basicConstraints;
  private readonly bool[] keyUsage;
  private AsymmetricKeyParameter publicKeyValue;
  private X509Certificate.CachedEncoding cachedEncoding;
  private volatile bool hashValueSet;
  private volatile int hashValue;

  protected X509Certificate()
  {
  }

  public X509Certificate(byte[] certData)
    : this(X509CertificateStructure.GetInstance((object) certData))
  {
  }

  public X509Certificate(X509CertificateStructure c)
  {
    this.c = c;
    try
    {
      this.sigAlgName = X509SignatureUtilities.GetSignatureName(c.SignatureAlgorithm);
      Asn1Encodable parameters = c.SignatureAlgorithm.Parameters;
      this.sigAlgParams = parameters == null ? (byte[]) null : parameters.GetEncoded("DER");
    }
    catch (Exception ex)
    {
      throw new CertificateParsingException("Certificate contents invalid: " + ex?.ToString());
    }
    try
    {
      Asn1OctetString extensionValue = this.GetExtensionValue(X509Extensions.BasicConstraints);
      if (extensionValue != null)
        this.basicConstraints = BasicConstraints.GetInstance((object) X509ExtensionUtilities.FromExtensionValue(extensionValue));
    }
    catch (Exception ex)
    {
      throw new CertificateParsingException("cannot construct BasicConstraints: " + ex?.ToString());
    }
    try
    {
      Asn1OctetString extensionValue = this.GetExtensionValue(X509Extensions.KeyUsage);
      if (extensionValue != null)
      {
        DerBitString instance = DerBitString.GetInstance((object) X509ExtensionUtilities.FromExtensionValue(extensionValue));
        byte[] bytes = instance.GetBytes();
        int num = bytes.Length * 8 - instance.PadBits;
        this.keyUsage = new bool[num < 9 ? 9 : num];
        for (int index = 0; index != num; ++index)
          this.keyUsage[index] = ((uint) bytes[index / 8] & (uint) (128 /*0x80*/ >> index % 8)) > 0U;
      }
      else
        this.keyUsage = (bool[]) null;
    }
    catch (Exception ex)
    {
      throw new CertificateParsingException("cannot construct KeyUsage: " + ex?.ToString());
    }
  }

  public virtual X509CertificateStructure CertificateStructure => this.c;

  public virtual bool IsValidNow => this.IsValid(DateTime.UtcNow);

  public virtual bool IsValid(DateTime time)
  {
    return time.CompareTo(this.NotBefore) >= 0 && time.CompareTo(this.NotAfter) <= 0;
  }

  public virtual void CheckValidity() => this.CheckValidity(DateTime.UtcNow);

  public virtual void CheckValidity(DateTime time)
  {
    if (time.CompareTo(this.NotAfter) > 0)
      throw new CertificateExpiredException("certificate expired on " + this.c.EndDate?.ToString());
    if (time.CompareTo(this.NotBefore) < 0)
      throw new CertificateNotYetValidException("certificate not valid until " + this.c.StartDate?.ToString());
  }

  public virtual int Version => this.c.Version;

  public virtual BigInteger SerialNumber => this.c.SerialNumber.Value;

  public virtual X509Name IssuerDN => this.c.Issuer;

  public virtual X509Name SubjectDN => this.c.Subject;

  public virtual DateTime NotBefore => this.c.StartDate.ToDateTime();

  public virtual DateTime NotAfter => this.c.EndDate.ToDateTime();

  public virtual byte[] GetTbsCertificate() => this.c.TbsCertificate.GetDerEncoded();

  public virtual byte[] GetSignature() => this.c.GetSignatureOctets();

  public virtual string SigAlgName => this.sigAlgName;

  public virtual string SigAlgOid => this.c.SignatureAlgorithm.Algorithm.Id;

  public virtual byte[] GetSigAlgParams() => Arrays.Clone(this.sigAlgParams);

  public virtual DerBitString IssuerUniqueID => this.c.TbsCertificate.IssuerUniqueID;

  public virtual DerBitString SubjectUniqueID => this.c.TbsCertificate.SubjectUniqueID;

  public virtual bool[] GetKeyUsage() => Arrays.Clone(this.keyUsage);

  public virtual IList<DerObjectIdentifier> GetExtendedKeyUsage()
  {
    Asn1OctetString extensionValue = this.GetExtensionValue(X509Extensions.ExtendedKeyUsage);
    if (extensionValue == null)
      return (IList<DerObjectIdentifier>) null;
    try
    {
      Asn1Sequence instance = Asn1Sequence.GetInstance((object) X509ExtensionUtilities.FromExtensionValue(extensionValue));
      List<DerObjectIdentifier> extendedKeyUsage = new List<DerObjectIdentifier>();
      foreach (DerObjectIdentifier objectIdentifier in instance)
        extendedKeyUsage.Add(objectIdentifier);
      return (IList<DerObjectIdentifier>) extendedKeyUsage;
    }
    catch (Exception ex)
    {
      throw new CertificateParsingException("error processing extended key usage extension", ex);
    }
  }

  public virtual int GetBasicConstraints()
  {
    if (this.basicConstraints == null || !this.basicConstraints.IsCA())
      return -1;
    return this.basicConstraints.PathLenConstraint == null ? int.MaxValue : this.basicConstraints.PathLenConstraint.IntValue;
  }

  public virtual GeneralNames GetIssuerAlternativeNameExtension()
  {
    return this.GetAlternativeNameExtension(X509Extensions.IssuerAlternativeName);
  }

  public virtual GeneralNames GetSubjectAlternativeNameExtension()
  {
    return this.GetAlternativeNameExtension(X509Extensions.SubjectAlternativeName);
  }

  public virtual IList<IList<object>> GetIssuerAlternativeNames()
  {
    return this.GetAlternativeNames(X509Extensions.IssuerAlternativeName);
  }

  public virtual IList<IList<object>> GetSubjectAlternativeNames()
  {
    return this.GetAlternativeNames(X509Extensions.SubjectAlternativeName);
  }

  protected virtual GeneralNames GetAlternativeNameExtension(DerObjectIdentifier oid)
  {
    Asn1OctetString extensionValue = this.GetExtensionValue(oid);
    return extensionValue == null ? (GeneralNames) null : GeneralNames.GetInstance((object) X509ExtensionUtilities.FromExtensionValue(extensionValue));
  }

  protected virtual IList<IList<object>> GetAlternativeNames(DerObjectIdentifier oid)
  {
    GeneralNames alternativeNameExtension = this.GetAlternativeNameExtension(oid);
    if (alternativeNameExtension == null)
      return (IList<IList<object>>) null;
    GeneralName[] names = alternativeNameExtension.GetNames();
    List<IList<object>> alternativeNames = new List<IList<object>>(names.Length);
    foreach (GeneralName generalName in names)
    {
      List<object> objectList = new List<object>(2);
      objectList.Add((object) generalName.TagNo);
      switch (generalName.TagNo)
      {
        case 0:
        case 3:
        case 5:
          objectList.Add((object) generalName.GetEncoded());
          break;
        case 1:
        case 2:
        case 6:
          objectList.Add((object) ((IAsn1String) generalName.Name).GetString());
          break;
        case 4:
          objectList.Add((object) X509Name.GetInstance((object) generalName.Name).ToString());
          break;
        case 7:
          IPAddress ipAddress = new IPAddress(Asn1OctetString.GetInstance((object) generalName.Name).GetOctets());
          objectList.Add((object) ipAddress.ToString());
          break;
        case 8:
          objectList.Add((object) DerObjectIdentifier.GetInstance((object) generalName.Name).Id);
          break;
        default:
          throw new IOException("Bad tag number: " + generalName.TagNo.ToString());
      }
      alternativeNames.Add((IList<object>) objectList);
    }
    return (IList<IList<object>>) alternativeNames;
  }

  protected override X509Extensions GetX509Extensions()
  {
    return this.c.Version < 3 ? (X509Extensions) null : this.c.TbsCertificate.Extensions;
  }

  public virtual AsymmetricKeyParameter GetPublicKey()
  {
    return Objects.EnsureSingletonInitialized<AsymmetricKeyParameter, X509CertificateStructure>(ref this.publicKeyValue, this.c, new Func<X509CertificateStructure, AsymmetricKeyParameter>(X509Certificate.CreatePublicKey));
  }

  public virtual byte[] GetEncoded() => Arrays.Clone(this.GetCachedEncoding().GetEncoded());

  public override bool Equals(object other)
  {
    if (this == other)
      return true;
    if (!(other is X509Certificate x509Certificate))
      return false;
    if (this.hashValueSet && x509Certificate.hashValueSet)
    {
      if (this.hashValue != x509Certificate.hashValue)
        return false;
    }
    else if (this.cachedEncoding == null || x509Certificate.cachedEncoding == null)
    {
      DerBitString signature = this.c.Signature;
      if (signature != null && !signature.Equals((Asn1Object) x509Certificate.c.Signature))
        return false;
    }
    byte[] encoding1 = this.GetCachedEncoding().Encoding;
    byte[] encoding2 = x509Certificate.GetCachedEncoding().Encoding;
    return encoding1 != null && encoding2 != null && Arrays.AreEqual(encoding1, encoding2);
  }

  public override int GetHashCode()
  {
    if (!this.hashValueSet)
    {
      this.hashValue = Arrays.GetHashCode(this.GetCachedEncoding().Encoding);
      this.hashValueSet = true;
    }
    return this.hashValue;
  }

  public override string ToString()
  {
    StringBuilder stringBuilder = new StringBuilder();
    stringBuilder.Append("  [0]         Version: ").Append(this.Version).AppendLine();
    stringBuilder.Append("         SerialNumber: ").Append((object) this.SerialNumber).AppendLine();
    stringBuilder.Append("             IssuerDN: ").Append((object) this.IssuerDN).AppendLine();
    stringBuilder.Append("           Start Date: ").Append((object) this.NotBefore).AppendLine();
    stringBuilder.Append("           Final Date: ").Append((object) this.NotAfter).AppendLine();
    stringBuilder.Append("            SubjectDN: ").Append((object) this.SubjectDN).AppendLine();
    stringBuilder.Append("           Public Key: ").Append((object) this.GetPublicKey()).AppendLine();
    stringBuilder.Append("  Signature Algorithm: ").Append(this.SigAlgName).AppendLine();
    byte[] signature = this.GetSignature();
    stringBuilder.Append("            Signature: ").AppendLine(Hex.ToHexString(signature, 0, 20));
    for (int off = 20; off < signature.Length; off += 20)
    {
      int length = System.Math.Min(20, signature.Length - off);
      stringBuilder.Append("                       ").AppendLine(Hex.ToHexString(signature, off, length));
    }
    X509Extensions extensions = this.c.TbsCertificate.Extensions;
    if (extensions != null)
    {
      IEnumerator<DerObjectIdentifier> enumerator = extensions.ExtensionOids.GetEnumerator();
      if (enumerator.MoveNext())
        stringBuilder.AppendLine("       Extensions:");
      do
      {
        DerObjectIdentifier current = enumerator.Current;
        X509Extension extension = extensions.GetExtension(current);
        if (extension.Value != null)
          goto label_7;
label_6:
        stringBuilder.AppendLine();
        continue;
label_7:
        Asn1Object asn1Object = X509ExtensionUtilities.FromExtensionValue(extension.Value);
        stringBuilder.Append("                       critical(").Append(extension.IsCritical).Append(") ");
        try
        {
          if (current.Equals((Asn1Object) X509Extensions.BasicConstraints))
          {
            stringBuilder.Append((object) BasicConstraints.GetInstance((object) asn1Object));
            goto label_6;
          }
          if (current.Equals((Asn1Object) X509Extensions.KeyUsage))
          {
            stringBuilder.Append((object) KeyUsage.GetInstance((object) asn1Object));
            goto label_6;
          }
          if (current.Equals((Asn1Object) MiscObjectIdentifiers.NetscapeCertType))
          {
            stringBuilder.Append((object) new NetscapeCertType((DerBitString) asn1Object));
            goto label_6;
          }
          if (current.Equals((Asn1Object) MiscObjectIdentifiers.NetscapeRevocationUrl))
          {
            stringBuilder.Append((object) new NetscapeRevocationUrl((DerIA5String) asn1Object));
            goto label_6;
          }
          if (current.Equals((Asn1Object) MiscObjectIdentifiers.VerisignCzagExtension))
          {
            stringBuilder.Append((object) new VerisignCzagExtension((DerIA5String) asn1Object));
            goto label_6;
          }
          stringBuilder.Append(current.Id);
          stringBuilder.Append(" value = ").Append(Asn1Dump.DumpAsString((Asn1Encodable) asn1Object));
          goto label_6;
        }
        catch (Exception ex)
        {
          stringBuilder.Append(current.Id);
          stringBuilder.Append(" value = ").Append("*****");
          goto label_6;
        }
      }
      while (enumerator.MoveNext());
    }
    return stringBuilder.ToString();
  }

  public virtual bool IsSignatureValid(AsymmetricKeyParameter key)
  {
    return this.CheckSignatureValid((IVerifierFactory) new Asn1VerifierFactory(this.c.SignatureAlgorithm, key));
  }

  public virtual bool IsSignatureValid(IVerifierFactoryProvider verifierProvider)
  {
    return this.CheckSignatureValid(verifierProvider.CreateVerifierFactory((object) this.c.SignatureAlgorithm));
  }

  public virtual bool IsAlternativeSignatureValid(IVerifierFactoryProvider verifierProvider)
  {
    TbsCertificateStructure tbsCertificate = this.c.TbsCertificate;
    X509Extensions extensions = tbsCertificate.Extensions;
    AltSignatureAlgorithm signatureAlgorithm = AltSignatureAlgorithm.FromExtensions(extensions);
    AltSignatureValue altSignatureValue = AltSignatureValue.FromExtensions(extensions);
    IVerifierFactory verifierFactory = verifierProvider.CreateVerifierFactory((object) signatureAlgorithm.Algorithm);
    Asn1Sequence instance = Asn1Sequence.GetInstance((object) tbsCertificate.ToAsn1Object());
    Asn1EncodableVector elementVector = new Asn1EncodableVector();
    for (int index = 0; index < instance.Count - 1; ++index)
    {
      if (index != 2)
        elementVector.Add(instance[index]);
    }
    elementVector.Add((Asn1Encodable) X509Utilities.TrimExtensions(3, extensions));
    return X509Utilities.VerifySignature(verifierFactory, (Asn1Encodable) new DerSequence(elementVector), altSignatureValue.Signature);
  }

  public virtual void Verify(AsymmetricKeyParameter key)
  {
    this.CheckSignature((IVerifierFactory) new Asn1VerifierFactory(this.c.SignatureAlgorithm, key));
  }

  public virtual void Verify(IVerifierFactoryProvider verifierProvider)
  {
    this.CheckSignature(verifierProvider.CreateVerifierFactory((object) this.c.SignatureAlgorithm));
  }

  public virtual void VerifyAltSignature(IVerifierFactoryProvider verifierProvider)
  {
    if (!this.IsAlternativeSignatureValid(verifierProvider))
      throw new InvalidKeyException("Public key presented not for certificate alternative signature");
  }

  protected virtual void CheckSignature(IVerifierFactory verifier)
  {
    if (!this.CheckSignatureValid(verifier))
      throw new InvalidKeyException("Public key presented not for certificate signature");
  }

  protected virtual bool CheckSignatureValid(IVerifierFactory verifier)
  {
    TbsCertificateStructure tbsCertificate = this.c.TbsCertificate;
    if (!X509Certificate.IsAlgIDEqual(this.c.SignatureAlgorithm, tbsCertificate.Signature))
      throw new CertificateException("signature algorithm in TBS cert not same as outer cert");
    return X509Utilities.VerifySignature(verifier, (Asn1Encodable) tbsCertificate, this.c.Signature);
  }

  private X509Certificate.CachedEncoding GetCachedEncoding()
  {
    return Objects.EnsureSingletonInitialized<X509Certificate.CachedEncoding, X509CertificateStructure>(ref this.cachedEncoding, this.c, new Func<X509CertificateStructure, X509Certificate.CachedEncoding>(X509Certificate.CreateCachedEncoding));
  }

  private static X509Certificate.CachedEncoding CreateCachedEncoding(X509CertificateStructure c)
  {
    byte[] encoding = (byte[]) null;
    CertificateEncodingException exception = (CertificateEncodingException) null;
    try
    {
      encoding = c.GetEncoded("DER");
    }
    catch (IOException ex)
    {
      exception = new CertificateEncodingException("Failed to DER-encode certificate", (Exception) ex);
    }
    return new X509Certificate.CachedEncoding(encoding, exception);
  }

  private static AsymmetricKeyParameter CreatePublicKey(X509CertificateStructure c)
  {
    return PublicKeyFactory.CreateKey(c.SubjectPublicKeyInfo);
  }

  private static bool IsAlgIDEqual(AlgorithmIdentifier id1, AlgorithmIdentifier id2)
  {
    if (!id1.Algorithm.Equals((Asn1Object) id2.Algorithm))
      return false;
    Asn1Encodable parameters1 = id1.Parameters;
    Asn1Encodable parameters2 = id2.Parameters;
    if (parameters1 == null == (parameters2 == null))
      return object.Equals((object) parameters1, (object) parameters2);
    return parameters1 != null ? parameters1.ToAsn1Object() is Asn1Null : parameters2.ToAsn1Object() is Asn1Null;
  }

  private class CachedEncoding
  {
    private readonly byte[] encoding;
    private readonly CertificateEncodingException exception;

    internal CachedEncoding(byte[] encoding, CertificateEncodingException exception)
    {
      this.encoding = encoding;
      this.exception = exception;
    }

    internal byte[] Encoding => this.encoding;

    internal byte[] GetEncoded()
    {
      if (this.exception != null)
        throw this.exception;
      return this.encoding != null ? this.encoding : throw new CertificateEncodingException();
    }
  }
}
