// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.X509.X509V2CrlGenerator
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Math;
using Org.BouncyCastle.Security.Certificates;
using System;
using System.Collections.Generic;
using System.IO;

#nullable disable
namespace Org.BouncyCastle.X509;

public class X509V2CrlGenerator
{
  private readonly X509ExtensionsGenerator extGenerator = new X509ExtensionsGenerator();
  private V2TbsCertListGenerator tbsGen;

  public X509V2CrlGenerator() => this.tbsGen = new V2TbsCertListGenerator();

  public X509V2CrlGenerator(X509Crl template)
    : this(template.CertificateList)
  {
  }

  public X509V2CrlGenerator(CertificateList template)
  {
    this.tbsGen = new V2TbsCertListGenerator();
    this.tbsGen.SetIssuer(template.Issuer);
    this.tbsGen.SetThisUpdate(template.ThisUpdate);
    this.tbsGen.SetNextUpdate(template.NextUpdate);
    this.AddCrl(new X509Crl(template));
    X509Extensions extensions = template.TbsCertList.Extensions;
    if (extensions == null)
      return;
    foreach (DerObjectIdentifier extensionOid in extensions.ExtensionOids)
    {
      if (!X509Extensions.AltSignatureAlgorithm.Equals((Asn1Object) extensionOid) && !X509Extensions.AltSignatureValue.Equals((Asn1Object) extensionOid))
      {
        X509Extension extension = extensions.GetExtension(extensionOid);
        this.extGenerator.AddExtension(extensionOid, extension.critical, extension.Value.GetOctets());
      }
    }
  }

  public void Reset()
  {
    this.tbsGen = new V2TbsCertListGenerator();
    this.extGenerator.Reset();
  }

  public void SetIssuerDN(X509Name issuer) => this.tbsGen.SetIssuer(issuer);

  public void SetThisUpdate(DateTime date) => this.tbsGen.SetThisUpdate(new Time(date));

  public void SetNextUpdate(DateTime date) => this.tbsGen.SetNextUpdate(new Time(date));

  public void AddCrlEntry(BigInteger userCertificate, DateTime revocationDate, int reason)
  {
    this.tbsGen.AddCrlEntry(new DerInteger(userCertificate), new Time(revocationDate), reason);
  }

  public void AddCrlEntry(
    BigInteger userCertificate,
    DateTime revocationDate,
    int reason,
    DateTime invalidityDate)
  {
    this.tbsGen.AddCrlEntry(new DerInteger(userCertificate), new Time(revocationDate), reason, new Asn1GeneralizedTime(invalidityDate));
  }

  public void AddCrlEntry(
    BigInteger userCertificate,
    DateTime revocationDate,
    X509Extensions extensions)
  {
    this.tbsGen.AddCrlEntry(new DerInteger(userCertificate), new Time(revocationDate), extensions);
  }

  public void AddCrl(X509Crl other)
  {
    ISet<X509CrlEntry> x509CrlEntrySet = other != null ? other.GetRevokedCertificates() : throw new ArgumentNullException(nameof (other));
    if (x509CrlEntrySet == null)
      return;
    foreach (X509CrlEntry x509CrlEntry in (IEnumerable<X509CrlEntry>) x509CrlEntrySet)
    {
      try
      {
        this.tbsGen.AddCrlEntry(Asn1Sequence.GetInstance((object) Asn1Object.FromByteArray(x509CrlEntry.GetEncoded())));
      }
      catch (IOException ex)
      {
        throw new CrlException("exception processing encoding of CRL", (Exception) ex);
      }
    }
  }

  public void AddExtension(string oid, bool critical, Asn1Encodable extensionValue)
  {
    this.extGenerator.AddExtension(new DerObjectIdentifier(oid), critical, extensionValue);
  }

  public void AddExtension(DerObjectIdentifier oid, bool critical, Asn1Encodable extensionValue)
  {
    this.extGenerator.AddExtension(oid, critical, extensionValue);
  }

  public void AddExtension(string oid, bool critical, byte[] extensionValue)
  {
    this.extGenerator.AddExtension(new DerObjectIdentifier(oid), critical, (Asn1Encodable) new DerOctetString(extensionValue));
  }

  public void AddExtension(DerObjectIdentifier oid, bool critical, byte[] extensionValue)
  {
    this.extGenerator.AddExtension(oid, critical, (Asn1Encodable) new DerOctetString(extensionValue));
  }

  public X509Crl Generate(ISignatureFactory signatureFactory)
  {
    AlgorithmIdentifier algorithmDetails = (AlgorithmIdentifier) signatureFactory.AlgorithmDetails;
    this.tbsGen.SetSignature(algorithmDetails);
    if (!this.extGenerator.IsEmpty)
      this.tbsGen.SetExtensions(this.extGenerator.Generate());
    TbsCertificateList tbsCertList = this.tbsGen.GenerateTbsCertList();
    DerBitString signature = X509Utilities.GenerateSignature(signatureFactory, (Asn1Encodable) tbsCertList);
    return new X509Crl(CertificateList.GetInstance((object) new DerSequence(new Asn1Encodable[3]
    {
      (Asn1Encodable) tbsCertList,
      (Asn1Encodable) algorithmDetails,
      (Asn1Encodable) signature
    })));
  }

  public X509Crl Generate(
    ISignatureFactory signatureFactory,
    bool isCritical,
    ISignatureFactory altSignatureFactory)
  {
    this.tbsGen.SetSignature((AlgorithmIdentifier) null);
    AlgorithmIdentifier algorithmDetails = (AlgorithmIdentifier) altSignatureFactory.AlgorithmDetails;
    this.extGenerator.AddExtension(X509Extensions.AltSignatureAlgorithm, isCritical, (Asn1Encodable) algorithmDetails);
    this.tbsGen.SetExtensions(this.extGenerator.Generate());
    DerBitString signature = X509Utilities.GenerateSignature(altSignatureFactory, (Asn1Encodable) this.tbsGen.GeneratePreTbsCertList());
    this.extGenerator.AddExtension(X509Extensions.AltSignatureValue, isCritical, (Asn1Encodable) signature);
    return this.Generate(signatureFactory);
  }

  public IEnumerable<string> SignatureAlgNames => X509Utilities.GetAlgNames();
}
