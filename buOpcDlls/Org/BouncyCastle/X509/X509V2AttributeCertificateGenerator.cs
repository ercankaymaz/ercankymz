// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.X509.X509V2AttributeCertificateGenerator
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Math;
using System;
using System.Collections.Generic;

#nullable disable
namespace Org.BouncyCastle.X509;

public class X509V2AttributeCertificateGenerator
{
  private readonly X509ExtensionsGenerator extGenerator = new X509ExtensionsGenerator();
  private V2AttributeCertificateInfoGenerator acInfoGen;

  public X509V2AttributeCertificateGenerator()
  {
    this.acInfoGen = new V2AttributeCertificateInfoGenerator();
  }

  public void Reset()
  {
    this.acInfoGen = new V2AttributeCertificateInfoGenerator();
    this.extGenerator.Reset();
  }

  public void SetHolder(AttributeCertificateHolder holder)
  {
    this.acInfoGen.SetHolder(holder.holder);
  }

  public void SetIssuer(AttributeCertificateIssuer issuer)
  {
    this.acInfoGen.SetIssuer(AttCertIssuer.GetInstance((object) issuer.form));
  }

  public void SetSerialNumber(BigInteger serialNumber)
  {
    this.acInfoGen.SetSerialNumber(new DerInteger(serialNumber));
  }

  public void SetNotBefore(DateTime date)
  {
    this.acInfoGen.SetStartDate(new Asn1GeneralizedTime(date));
  }

  public void SetNotAfter(DateTime date)
  {
    this.acInfoGen.SetEndDate(new Asn1GeneralizedTime(date));
  }

  public void AddAttribute(X509Attribute attribute)
  {
    this.acInfoGen.AddAttribute(AttributeX509.GetInstance((object) attribute.ToAsn1Object()));
  }

  public void SetIssuerUniqueId(bool[] iui)
  {
    throw new NotImplementedException("SetIssuerUniqueId()");
  }

  public void AddExtension(string oid, bool critical, Asn1Encodable extensionValue)
  {
    this.extGenerator.AddExtension(new DerObjectIdentifier(oid), critical, extensionValue);
  }

  public void AddExtension(string oid, bool critical, byte[] extensionValue)
  {
    this.extGenerator.AddExtension(new DerObjectIdentifier(oid), critical, extensionValue);
  }

  public X509V2AttributeCertificate Generate(ISignatureFactory signatureFactory)
  {
    AlgorithmIdentifier algorithmDetails = (AlgorithmIdentifier) signatureFactory.AlgorithmDetails;
    this.acInfoGen.SetSignature(algorithmDetails);
    if (!this.extGenerator.IsEmpty)
      this.acInfoGen.SetExtensions(this.extGenerator.Generate());
    AttributeCertificateInfo attributeCertificateInfo = this.acInfoGen.GenerateAttributeCertificateInfo();
    DerBitString signature = X509Utilities.GenerateSignature(signatureFactory, (Asn1Encodable) attributeCertificateInfo);
    return new X509V2AttributeCertificate(new AttributeCertificate(attributeCertificateInfo, algorithmDetails, signature));
  }

  public IEnumerable<string> SignatureAlgNames => X509Utilities.GetAlgNames();
}
