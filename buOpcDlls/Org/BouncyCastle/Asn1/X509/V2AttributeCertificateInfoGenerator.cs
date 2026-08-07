// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.X509.V2AttributeCertificateInfoGenerator
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;

#nullable disable
namespace Org.BouncyCastle.Asn1.X509;

public class V2AttributeCertificateInfoGenerator
{
  internal DerInteger version;
  internal Holder holder;
  internal AttCertIssuer issuer;
  internal AlgorithmIdentifier signature;
  internal DerInteger serialNumber;
  internal Asn1EncodableVector attributes;
  internal DerBitString issuerUniqueID;
  internal X509Extensions extensions;
  internal Asn1GeneralizedTime startDate;
  internal Asn1GeneralizedTime endDate;

  public V2AttributeCertificateInfoGenerator()
  {
    this.version = new DerInteger(1);
    this.attributes = new Asn1EncodableVector();
  }

  public void SetHolder(Holder holder) => this.holder = holder;

  public void AddAttribute(string oid, Asn1Encodable value)
  {
    this.attributes.Add((Asn1Encodable) new AttributeX509(new DerObjectIdentifier(oid), (Asn1Set) new DerSet(value)));
  }

  public void AddAttribute(AttributeX509 attribute)
  {
    this.attributes.Add((Asn1Encodable) attribute);
  }

  public void SetSerialNumber(DerInteger serialNumber) => this.serialNumber = serialNumber;

  public void SetSignature(AlgorithmIdentifier signature) => this.signature = signature;

  public void SetIssuer(AttCertIssuer issuer) => this.issuer = issuer;

  public void SetStartDate(Asn1GeneralizedTime startDate) => this.startDate = startDate;

  public void SetEndDate(Asn1GeneralizedTime endDate) => this.endDate = endDate;

  public void SetIssuerUniqueID(DerBitString issuerUniqueID)
  {
    this.issuerUniqueID = issuerUniqueID;
  }

  public void SetExtensions(X509Extensions extensions) => this.extensions = extensions;

  public AttributeCertificateInfo GenerateAttributeCertificateInfo()
  {
    if (this.serialNumber == null || this.signature == null || this.issuer == null || this.startDate == null || this.endDate == null || this.holder == null || this.attributes == null)
      throw new InvalidOperationException("not all mandatory fields set in V2 AttributeCertificateInfo generator");
    Asn1EncodableVector elementVector = new Asn1EncodableVector(new Asn1Encodable[5]
    {
      (Asn1Encodable) this.version,
      (Asn1Encodable) this.holder,
      (Asn1Encodable) this.issuer,
      (Asn1Encodable) this.signature,
      (Asn1Encodable) this.serialNumber
    });
    elementVector.Add((Asn1Encodable) new AttCertValidityPeriod(this.startDate, this.endDate));
    elementVector.Add((Asn1Encodable) new DerSequence(this.attributes));
    if (this.issuerUniqueID != null)
      elementVector.Add((Asn1Encodable) this.issuerUniqueID);
    if (this.extensions != null)
      elementVector.Add((Asn1Encodable) this.extensions);
    return AttributeCertificateInfo.GetInstance((object) new DerSequence(elementVector));
  }
}
