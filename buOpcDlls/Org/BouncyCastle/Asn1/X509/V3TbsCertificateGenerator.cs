// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.X509.V3TbsCertificateGenerator
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;

#nullable disable
namespace Org.BouncyCastle.Asn1.X509;

public class V3TbsCertificateGenerator
{
  internal DerTaggedObject version = new DerTaggedObject(0, (Asn1Encodable) new DerInteger(2));
  internal DerInteger serialNumber;
  internal AlgorithmIdentifier signature;
  internal X509Name issuer;
  internal Time startDate;
  internal Time endDate;
  internal X509Name subject;
  internal SubjectPublicKeyInfo subjectPublicKeyInfo;
  internal X509Extensions extensions;
  private bool altNamePresentAndCritical;
  private DerBitString issuerUniqueID;
  private DerBitString subjectUniqueID;

  public void SetSerialNumber(DerInteger serialNumber) => this.serialNumber = serialNumber;

  public void SetSignature(AlgorithmIdentifier signature) => this.signature = signature;

  public void SetIssuer(X509Name issuer) => this.issuer = issuer;

  public void SetStartDate(Asn1UtcTime startDate) => this.startDate = new Time(startDate);

  public void SetStartDate(Time startDate) => this.startDate = startDate;

  public void SetEndDate(Asn1UtcTime endDate) => this.endDate = new Time(endDate);

  public void SetEndDate(Time endDate) => this.endDate = endDate;

  public void SetSubject(X509Name subject) => this.subject = subject;

  public void SetIssuerUniqueID(DerBitString uniqueID) => this.issuerUniqueID = uniqueID;

  public void SetSubjectUniqueID(DerBitString uniqueID) => this.subjectUniqueID = uniqueID;

  public void SetSubjectPublicKeyInfo(SubjectPublicKeyInfo pubKeyInfo)
  {
    this.subjectPublicKeyInfo = pubKeyInfo;
  }

  public void SetExtensions(X509Extensions extensions)
  {
    this.extensions = extensions;
    if (extensions == null)
      return;
    X509Extension extension = extensions.GetExtension(X509Extensions.SubjectAlternativeName);
    if (extension == null || !extension.IsCritical)
      return;
    this.altNamePresentAndCritical = true;
  }

  public Asn1Sequence GeneratePreTbsCertificate()
  {
    if (this.signature != null)
      throw new InvalidOperationException("signature field should not be set in PreTBSCertificate");
    if (this.serialNumber == null || this.issuer == null || this.startDate == null || this.endDate == null || this.subject == null && !this.altNamePresentAndCritical || this.subjectPublicKeyInfo == null)
      throw new InvalidOperationException("not all mandatory fields set in V3 TBScertificate generator");
    return this.GenerateTbsStructure();
  }

  public TbsCertificateStructure GenerateTbsCertificate()
  {
    if (this.serialNumber == null || this.signature == null || this.issuer == null || this.startDate == null || this.endDate == null || this.subject == null && !this.altNamePresentAndCritical || this.subjectPublicKeyInfo == null)
      throw new InvalidOperationException("not all mandatory fields set in V3 TBScertificate generator");
    return TbsCertificateStructure.GetInstance((object) this.GenerateTbsStructure());
  }

  private Asn1Sequence GenerateTbsStructure()
  {
    Asn1EncodableVector elementVector = new Asn1EncodableVector(10);
    elementVector.Add((Asn1Encodable) this.version);
    elementVector.Add((Asn1Encodable) this.serialNumber);
    elementVector.AddOptional((Asn1Encodable) this.signature);
    elementVector.Add((Asn1Encodable) this.issuer);
    elementVector.Add((Asn1Encodable) new DerSequence((Asn1Encodable) this.startDate, (Asn1Encodable) this.endDate));
    if (this.subject != null)
      elementVector.Add((Asn1Encodable) this.subject);
    else
      elementVector.Add((Asn1Encodable) DerSequence.Empty);
    elementVector.Add((Asn1Encodable) this.subjectPublicKeyInfo);
    elementVector.AddOptionalTagged(false, 1, (Asn1Encodable) this.issuerUniqueID);
    elementVector.AddOptionalTagged(false, 2, (Asn1Encodable) this.subjectUniqueID);
    elementVector.AddOptionalTagged(true, 3, (Asn1Encodable) this.extensions);
    return (Asn1Sequence) new DerSequence(elementVector);
  }
}
