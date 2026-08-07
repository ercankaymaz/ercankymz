// Decompiled with JetBrains decompiler
// Type: Opc.Ua.Security.Certificates.CrlBuilder
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

#nullable disable
namespace Opc.Ua.Security.Certificates;

[ComVisible(true)]
public sealed class CrlBuilder : IX509CRL
{
  private List<RevokedCertificate> m_revokedCertificates;
  private X509ExtensionCollection m_crlExtensions;

  public static CrlBuilder Create(IX509CRL crl) => new CrlBuilder(crl);

  public static CrlBuilder Create(X500DistinguishedName issuerSubjectName)
  {
    return new CrlBuilder(issuerSubjectName);
  }

  public static CrlBuilder Create(
    X500DistinguishedName issuerSubjectName,
    HashAlgorithmName hashAlgorithmName)
  {
    return new CrlBuilder(issuerSubjectName, hashAlgorithmName);
  }

  private CrlBuilder(IX509CRL crl)
  {
    this.IssuerName = crl.IssuerName;
    this.HashAlgorithmName = crl.HashAlgorithmName;
    this.ThisUpdate = crl.ThisUpdate;
    this.NextUpdate = crl.NextUpdate;
    this.RawData = crl.RawData;
    this.m_revokedCertificates = new List<RevokedCertificate>((IEnumerable<RevokedCertificate>) crl.RevokedCertificates);
    this.m_crlExtensions = new X509ExtensionCollection();
    foreach (X509Extension crlExtension in crl.CrlExtensions)
      this.m_crlExtensions.Add(crlExtension);
  }

  private CrlBuilder(X500DistinguishedName issuerSubjectName)
    : this(issuerSubjectName, X509Defaults.HashAlgorithmName)
  {
  }

  private CrlBuilder(X500DistinguishedName issuerSubjectName, HashAlgorithmName hashAlgorithmName)
    : this()
  {
    this.IssuerName = issuerSubjectName;
    this.HashAlgorithmName = hashAlgorithmName;
  }

  private CrlBuilder()
  {
    this.ThisUpdate = DateTime.UtcNow;
    this.NextUpdate = DateTime.MinValue;
    this.m_revokedCertificates = new List<RevokedCertificate>();
    this.m_crlExtensions = new X509ExtensionCollection();
  }

  public X500DistinguishedName IssuerName { get; }

  public string Issuer => this.IssuerName.Name;

  public DateTime ThisUpdate { get; private set; }

  public DateTime NextUpdate { get; private set; }

  public HashAlgorithmName HashAlgorithmName { get; private set; }

  public IList<RevokedCertificate> RevokedCertificates
  {
    get => (IList<RevokedCertificate>) this.m_revokedCertificates;
  }

  public X509ExtensionCollection CrlExtensions => this.m_crlExtensions;

  public byte[] RawData { get; private set; }

  public CrlBuilder SetThisUpdate(DateTime thisUpdate)
  {
    this.ThisUpdate = thisUpdate;
    return this;
  }

  public CrlBuilder SetNextUpdate(DateTime nextUpdate)
  {
    this.NextUpdate = nextUpdate;
    return this;
  }

  public CrlBuilder SetHashAlgorithm(HashAlgorithmName hashAlgorithmName)
  {
    this.HashAlgorithmName = hashAlgorithmName;
    return this;
  }

  public CrlBuilder AddRevokedSerialNumbers(string[] serialNumbers, CRLReason crlReason = CRLReason.Unspecified)
  {
    if (serialNumbers == null)
      throw new ArgumentNullException(nameof (serialNumbers));
    this.m_revokedCertificates.AddRange((IEnumerable<RevokedCertificate>) ((IEnumerable<string>) serialNumbers).Select<string, RevokedCertificate>((Func<string, RevokedCertificate>) (s => new RevokedCertificate(s, crlReason))).ToList<RevokedCertificate>());
    return this;
  }

  public CrlBuilder AddRevokedCertificate(X509Certificate2 certificate, CRLReason crlReason = CRLReason.Unspecified)
  {
    if (certificate == null)
      throw new ArgumentNullException(nameof (certificate));
    this.m_revokedCertificates.Add(new RevokedCertificate(certificate.SerialNumber, crlReason));
    return this;
  }

  public CrlBuilder AddRevokedCertificate(RevokedCertificate revokedCertificate)
  {
    if (revokedCertificate == null)
      throw new ArgumentNullException(nameof (revokedCertificate));
    this.m_revokedCertificates.Add(revokedCertificate);
    return this;
  }

  public CrlBuilder AddRevokedCertificates(IList<RevokedCertificate> revokedCertificates)
  {
    if (revokedCertificates == null)
      throw new ArgumentNullException(nameof (revokedCertificates));
    this.m_revokedCertificates.AddRange((IEnumerable<RevokedCertificate>) revokedCertificates);
    return this;
  }

  public CrlBuilder AddCRLExtension(X509Extension extension)
  {
    this.m_crlExtensions.Add(extension);
    return this;
  }

  public IX509CRL CreateSignature(X509SignatureGenerator generator)
  {
    byte[] numArray = this.Encode();
    byte[] algorithmIdentifier = generator.GetSignatureAlgorithmIdentifier(this.HashAlgorithmName);
    byte[] signature = generator.SignData(numArray, this.HashAlgorithmName);
    this.RawData = new X509Signature(numArray, signature, algorithmIdentifier).Encode();
    return (IX509CRL) this;
  }

  public IX509CRL CreateForRSA(X509Certificate2 issuerCertificate)
  {
    using (RSA rsaPrivateKey = RSACertificateExtensions.GetRSAPrivateKey(issuerCertificate))
      return this.CreateSignature(X509SignatureGenerator.CreateForRSA(rsaPrivateKey, RSASignaturePadding.Pkcs1));
  }

  public IX509CRL CreateForECDsa(X509Certificate2 issuerCertificate)
  {
    using (ECDsa ecDsaPrivateKey = ECDsaCertificateExtensions.GetECDsaPrivateKey(issuerCertificate))
      return this.CreateSignature(X509SignatureGenerator.CreateForECDsa(ecDsaPrivateKey));
  }

  internal byte[] Encode()
  {
    AsnWriter writer = new AsnWriter(System.Formats.Asn1.AsnEncodingRules.DER);
    writer.PushSequence();
    writer.WriteInteger(1L);
    writer.PushSequence();
    string rsaOid = Oids.GetRSAOid(this.HashAlgorithmName);
    writer.WriteObjectIdentifier(rsaOid);
    writer.WriteNull();
    writer.PopSequence();
    writer.WriteEncodedValue((System.ReadOnlySpan<byte>) this.IssuerName.RawData);
    CrlBuilder.WriteTime(writer, this.ThisUpdate);
    if (this.NextUpdate != DateTime.MinValue && this.NextUpdate > this.ThisUpdate)
      CrlBuilder.WriteTime(writer, this.NextUpdate);
    writer.PushSequence();
    foreach (RevokedCertificate revokedCertificate in (IEnumerable<RevokedCertificate>) this.RevokedCertificates)
    {
      writer.PushSequence();
      BigInteger bigInteger = new BigInteger(revokedCertificate.UserCertificate);
      writer.WriteInteger(bigInteger);
      CrlBuilder.WriteTime(writer, revokedCertificate.RevocationDate);
      if (revokedCertificate.CrlEntryExtensions.Count > 0)
      {
        writer.PushSequence();
        foreach (X509Extension crlEntryExtension in revokedCertificate.CrlEntryExtensions)
          writer.WriteExtension(crlEntryExtension);
        writer.PopSequence();
      }
      writer.PopSequence();
    }
    writer.PopSequence();
    if (this.CrlExtensions.Count > 0)
    {
      System.Formats.Asn1.Asn1Tag asn1Tag = new System.Formats.Asn1.Asn1Tag(System.Formats.Asn1.TagClass.ContextSpecific, 0);
      writer.PushSequence(new System.Formats.Asn1.Asn1Tag?(asn1Tag));
      writer.PushSequence();
      foreach (X509Extension crlExtension in this.CrlExtensions)
        writer.WriteExtension(crlExtension);
      writer.PopSequence();
      writer.PopSequence(new System.Formats.Asn1.Asn1Tag?(asn1Tag));
    }
    writer.PopSequence();
    return writer.Encode();
  }

  private static void WriteTime(AsnWriter writer, DateTime dateTime)
  {
    DateTime universalTime = dateTime.ToUniversalTime();
    if (universalTime.Year < 2050)
      writer.WriteUtcTime((DateTimeOffset) universalTime);
    else
      writer.WriteGeneralizedTime((DateTimeOffset) universalTime, true);
  }
}
