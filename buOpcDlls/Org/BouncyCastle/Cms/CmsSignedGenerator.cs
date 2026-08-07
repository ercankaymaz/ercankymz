// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Cms.CmsSignedGenerator
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Asn1.Cms;
using Org.BouncyCastle.Asn1.CryptoPro;
using Org.BouncyCastle.Asn1.Nist;
using Org.BouncyCastle.Asn1.Oiw;
using Org.BouncyCastle.Asn1.Pkcs;
using Org.BouncyCastle.Asn1.Rosstandart;
using Org.BouncyCastle.Asn1.TeleTrust;
using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.Asn1.X9;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Security;
using Org.BouncyCastle.Utilities.Collections;
using Org.BouncyCastle.X509;
using System;
using System.Collections.Generic;

#nullable disable
namespace Org.BouncyCastle.Cms;

public abstract class CmsSignedGenerator
{
  public static readonly string Data = CmsObjectIdentifiers.Data.Id;
  public static readonly string DigestSha1 = OiwObjectIdentifiers.IdSha1.Id;
  public static readonly string DigestSha224 = NistObjectIdentifiers.IdSha224.Id;
  public static readonly string DigestSha256 = NistObjectIdentifiers.IdSha256.Id;
  public static readonly string DigestSha384 = NistObjectIdentifiers.IdSha384.Id;
  public static readonly string DigestSha512 = NistObjectIdentifiers.IdSha512.Id;
  public static readonly string DigestSha512_224 = NistObjectIdentifiers.IdSha512_224.Id;
  public static readonly string DigestSha512_256 = NistObjectIdentifiers.IdSha512_256.Id;
  public static readonly string DigestMD5 = PkcsObjectIdentifiers.MD5.Id;
  public static readonly string DigestGost3411 = CryptoProObjectIdentifiers.GostR3411.Id;
  public static readonly string DigestRipeMD128 = TeleTrusTObjectIdentifiers.RipeMD128.Id;
  public static readonly string DigestRipeMD160 = TeleTrusTObjectIdentifiers.RipeMD160.Id;
  public static readonly string DigestRipeMD256 = TeleTrusTObjectIdentifiers.RipeMD256.Id;
  public static readonly string EncryptionRsa = PkcsObjectIdentifiers.RsaEncryption.Id;
  public static readonly string EncryptionDsa = X9ObjectIdentifiers.IdDsaWithSha1.Id;
  public static readonly string EncryptionECDsa = X9ObjectIdentifiers.ECDsaWithSha1.Id;
  public static readonly string EncryptionRsaPss = PkcsObjectIdentifiers.IdRsassaPss.Id;
  public static readonly string EncryptionGost3410 = CryptoProObjectIdentifiers.GostR3410x94.Id;
  public static readonly string EncryptionECGost3410 = CryptoProObjectIdentifiers.GostR3410x2001.Id;
  public static readonly string EncryptionECGost3410_2012_256 = RosstandartObjectIdentifiers.id_tc26_gost_3410_12_256.Id;
  public static readonly string EncryptionECGost3410_2012_512 = RosstandartObjectIdentifiers.id_tc26_gost_3410_12_512.Id;
  internal List<Asn1Encodable> _certs = new List<Asn1Encodable>();
  internal List<Asn1Encodable> _crls = new List<Asn1Encodable>();
  internal IList<SignerInformation> _signers = (IList<SignerInformation>) new List<SignerInformation>();
  internal IDictionary<string, byte[]> m_digests = (IDictionary<string, byte[]>) new Dictionary<string, byte[]>((IEqualityComparer<string>) StringComparer.OrdinalIgnoreCase);
  internal bool _useDerForCerts;
  internal bool _useDerForCrls;
  protected readonly SecureRandom m_random;

  protected CmsSignedGenerator()
    : this(CryptoServicesRegistrar.GetSecureRandom())
  {
  }

  protected CmsSignedGenerator(SecureRandom random)
  {
    this.m_random = random != null ? random : throw new ArgumentNullException(nameof (random));
  }

  protected internal virtual IDictionary<CmsAttributeTableParameter, object> GetBaseParameters(
    DerObjectIdentifier contentType,
    AlgorithmIdentifier digAlgId,
    byte[] hash)
  {
    Dictionary<CmsAttributeTableParameter, object> baseParameters = new Dictionary<CmsAttributeTableParameter, object>();
    if (contentType != null)
      baseParameters[CmsAttributeTableParameter.ContentType] = (object) contentType;
    baseParameters[CmsAttributeTableParameter.DigestAlgorithmIdentifier] = (object) digAlgId;
    baseParameters[CmsAttributeTableParameter.Digest] = hash.Clone();
    return (IDictionary<CmsAttributeTableParameter, object>) baseParameters;
  }

  protected internal virtual Asn1Set GetAttributeSet(Org.BouncyCastle.Asn1.Cms.AttributeTable attr)
  {
    return attr != null ? (Asn1Set) new DerSet(attr.ToAsn1EncodableVector()) : (Asn1Set) null;
  }

  public void AddAttributeCertificate(X509V2AttributeCertificate attrCert)
  {
    this._certs.Add((Asn1Encodable) new DerTaggedObject(false, 2, (Asn1Encodable) attrCert.AttributeCertificate));
  }

  public void AddAttributeCertificates(IStore<X509V2AttributeCertificate> attrCertStore)
  {
    this._certs.AddRange((IEnumerable<Asn1Encodable>) CmsUtilities.GetAttributeCertificatesFromStore(attrCertStore));
  }

  public void AddCertificate(X509Certificate cert)
  {
    this._certs.Add((Asn1Encodable) cert.CertificateStructure);
  }

  public void AddCertificates(IStore<X509Certificate> certStore)
  {
    this._certs.AddRange((IEnumerable<Asn1Encodable>) CmsUtilities.GetCertificatesFromStore(certStore));
  }

  public void AddCrl(X509Crl crl) => this._crls.Add((Asn1Encodable) crl.CertificateList);

  public void AddCrls(IStore<X509Crl> crlStore)
  {
    this._crls.AddRange((IEnumerable<Asn1Encodable>) CmsUtilities.GetCrlsFromStore(crlStore));
  }

  public void AddOtherRevocationInfo(OtherRevocationInfoFormat otherRevocationInfo)
  {
    CmsUtilities.ValidateOtherRevocationInfo(otherRevocationInfo);
    this._crls.Add((Asn1Encodable) new DerTaggedObject(false, 1, (Asn1Encodable) otherRevocationInfo));
  }

  public void AddOtherRevocationInfos(
    IStore<OtherRevocationInfoFormat> otherRevocationInfoStore)
  {
    this._crls.AddRange((IEnumerable<Asn1Encodable>) CmsUtilities.GetOtherRevocationInfosFromStore(otherRevocationInfoStore));
  }

  public void AddOtherRevocationInfos(
    DerObjectIdentifier otherRevInfoFormat,
    IStore<Asn1Encodable> otherRevInfoStore)
  {
    this._crls.AddRange((IEnumerable<Asn1Encodable>) CmsUtilities.GetOtherRevocationInfosFromStore(otherRevInfoStore, otherRevInfoFormat));
  }

  public void AddSigners(SignerInformationStore signerStore)
  {
    foreach (SignerInformation signer in (IEnumerable<SignerInformation>) signerStore.GetSigners())
    {
      this._signers.Add(signer);
      this.AddSignerCallback(signer);
    }
  }

  public IDictionary<string, byte[]> GetGeneratedDigests()
  {
    return (IDictionary<string, byte[]>) new Dictionary<string, byte[]>(this.m_digests, (IEqualityComparer<string>) StringComparer.OrdinalIgnoreCase);
  }

  public bool UseDerForCerts
  {
    get => this._useDerForCerts;
    set => this._useDerForCerts = value;
  }

  public bool UseDerForCrls
  {
    get => this._useDerForCrls;
    set => this._useDerForCrls = value;
  }

  internal virtual void AddSignerCallback(SignerInformation si)
  {
  }

  internal static SignerIdentifier GetSignerIdentifier(X509Certificate cert)
  {
    return new SignerIdentifier(CmsUtilities.GetIssuerAndSerialNumber(cert));
  }

  internal static SignerIdentifier GetSignerIdentifier(byte[] subjectKeyIdentifier)
  {
    return new SignerIdentifier((Asn1OctetString) new DerOctetString(subjectKeyIdentifier));
  }
}
