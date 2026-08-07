// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Ocsp.CertificateID
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Asn1.Ocsp;
using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.Math;
using Org.BouncyCastle.Security;
using Org.BouncyCastle.X509;
using System;

#nullable disable
namespace Org.BouncyCastle.Ocsp;

public class CertificateID
{
  public const string HashSha1 = "1.3.14.3.2.26";
  private readonly CertID id;

  public CertificateID(CertID id)
  {
    this.id = id != null ? id : throw new ArgumentNullException(nameof (id));
  }

  public CertificateID(string hashAlgorithm, X509Certificate issuerCert, BigInteger serialNumber)
  {
    this.id = CertificateID.CreateCertID(new AlgorithmIdentifier(new DerObjectIdentifier(hashAlgorithm), (Asn1Encodable) DerNull.Instance), issuerCert, new DerInteger(serialNumber));
  }

  public string HashAlgOid => this.id.HashAlgorithm.Algorithm.Id;

  public byte[] GetIssuerNameHash() => this.id.IssuerNameHash.GetOctets();

  public byte[] GetIssuerKeyHash() => this.id.IssuerKeyHash.GetOctets();

  public BigInteger SerialNumber => this.id.SerialNumber.Value;

  public bool MatchesIssuer(X509Certificate issuerCert)
  {
    return CertificateID.CreateCertID(this.id.HashAlgorithm, issuerCert, this.id.SerialNumber).Equals((object) this.id);
  }

  public CertID ToAsn1Object() => this.id;

  public override bool Equals(object obj)
  {
    if (obj == this)
      return true;
    return obj is CertificateID certificateId && this.id.ToAsn1Object().Equals(certificateId.id.ToAsn1Object());
  }

  public override int GetHashCode() => this.id.ToAsn1Object().GetHashCode();

  public static CertificateID DeriveCertificateID(
    CertificateID original,
    BigInteger newSerialNumber)
  {
    return new CertificateID(new CertID(original.id.HashAlgorithm, original.id.IssuerNameHash, original.id.IssuerKeyHash, new DerInteger(newSerialNumber)));
  }

  private static CertID CreateCertID(
    AlgorithmIdentifier hashAlg,
    X509Certificate issuerCert,
    DerInteger serialNumber)
  {
    try
    {
      string id = hashAlg.Algorithm.Id;
      byte[] digest1 = DigestUtilities.CalculateDigest(id, PrincipalUtilities.GetSubjectX509Principal(issuerCert).GetEncoded());
      byte[] digest2 = DigestUtilities.CalculateDigest(id, SubjectPublicKeyInfoFactory.CreateSubjectPublicKeyInfo(issuerCert.GetPublicKey()).PublicKeyData.GetBytes());
      return new CertID(hashAlg, (Asn1OctetString) new DerOctetString(digest1), (Asn1OctetString) new DerOctetString(digest2), serialNumber);
    }
    catch (Exception ex)
    {
      throw new OcspException("problem creating ID: " + ex?.ToString(), ex);
    }
  }
}
