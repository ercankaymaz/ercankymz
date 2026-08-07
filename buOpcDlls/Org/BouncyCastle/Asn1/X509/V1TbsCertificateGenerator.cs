// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.X509.V1TbsCertificateGenerator
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;

#nullable disable
namespace Org.BouncyCastle.Asn1.X509;

public class V1TbsCertificateGenerator
{
  internal DerTaggedObject version = new DerTaggedObject(0, (Asn1Encodable) new DerInteger(0));
  internal DerInteger serialNumber;
  internal AlgorithmIdentifier signature;
  internal X509Name issuer;
  internal Time startDate;
  internal Time endDate;
  internal X509Name subject;
  internal SubjectPublicKeyInfo subjectPublicKeyInfo;

  public void SetSerialNumber(DerInteger serialNumber) => this.serialNumber = serialNumber;

  public void SetSignature(AlgorithmIdentifier signature) => this.signature = signature;

  public void SetIssuer(X509Name issuer) => this.issuer = issuer;

  public void SetStartDate(Time startDate) => this.startDate = startDate;

  public void SetStartDate(Asn1UtcTime startDate) => this.startDate = new Time(startDate);

  public void SetEndDate(Time endDate) => this.endDate = endDate;

  public void SetEndDate(Asn1UtcTime endDate) => this.endDate = new Time(endDate);

  public void SetSubject(X509Name subject) => this.subject = subject;

  public void SetSubjectPublicKeyInfo(SubjectPublicKeyInfo pubKeyInfo)
  {
    this.subjectPublicKeyInfo = pubKeyInfo;
  }

  public TbsCertificateStructure GenerateTbsCertificate()
  {
    if (this.serialNumber == null || this.signature == null || this.issuer == null || this.startDate == null || this.endDate == null || this.subject == null || this.subjectPublicKeyInfo == null)
      throw new InvalidOperationException("not all mandatory fields set in V1 TBScertificate generator");
    return TbsCertificateStructure.GetInstance((object) new DerSequence(new Asn1Encodable[6]
    {
      (Asn1Encodable) this.serialNumber,
      (Asn1Encodable) this.signature,
      (Asn1Encodable) this.issuer,
      (Asn1Encodable) new DerSequence((Asn1Encodable) this.startDate, (Asn1Encodable) this.endDate),
      (Asn1Encodable) this.subject,
      (Asn1Encodable) this.subjectPublicKeyInfo
    }));
  }
}
