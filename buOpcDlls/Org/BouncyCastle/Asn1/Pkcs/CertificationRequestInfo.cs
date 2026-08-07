// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.Pkcs.CertificationRequestInfo
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1.X509;
using System;

#nullable disable
namespace Org.BouncyCastle.Asn1.Pkcs;

public class CertificationRequestInfo : Asn1Encodable
{
  internal DerInteger version = new DerInteger(0);
  internal X509Name subject;
  internal SubjectPublicKeyInfo subjectPKInfo;
  internal Asn1Set attributes;

  public static CertificationRequestInfo GetInstance(object obj)
  {
    if (obj is CertificationRequestInfo)
      return (CertificationRequestInfo) obj;
    return obj != null ? new CertificationRequestInfo(Asn1Sequence.GetInstance(obj)) : (CertificationRequestInfo) null;
  }

  public CertificationRequestInfo(
    X509Name subject,
    SubjectPublicKeyInfo pkInfo,
    Asn1Set attributes)
  {
    this.subject = subject;
    this.subjectPKInfo = pkInfo;
    this.attributes = attributes;
    CertificationRequestInfo.ValidateAttributes(attributes);
    if (subject == null || this.version == null || this.subjectPKInfo == null)
      throw new ArgumentException("Not all mandatory fields set in CertificationRequestInfo generator.");
  }

  private CertificationRequestInfo(Asn1Sequence seq)
  {
    this.version = (DerInteger) seq[0];
    this.subject = X509Name.GetInstance((object) seq[1]);
    this.subjectPKInfo = SubjectPublicKeyInfo.GetInstance((object) seq[2]);
    if (seq.Count > 3)
      this.attributes = Asn1Set.GetInstance((Asn1TaggedObject) seq[3], false);
    CertificationRequestInfo.ValidateAttributes(this.attributes);
    if (this.subject == null || this.version == null || this.subjectPKInfo == null)
      throw new ArgumentException("Not all mandatory fields set in CertificationRequestInfo generator.");
  }

  public DerInteger Version => this.version;

  public X509Name Subject => this.subject;

  public SubjectPublicKeyInfo SubjectPublicKeyInfo => this.subjectPKInfo;

  public Asn1Set Attributes => this.attributes;

  public override Asn1Object ToAsn1Object()
  {
    Asn1EncodableVector elementVector = new Asn1EncodableVector(new Asn1Encodable[3]
    {
      (Asn1Encodable) this.version,
      (Asn1Encodable) this.subject,
      (Asn1Encodable) this.subjectPKInfo
    });
    elementVector.AddOptionalTagged(false, 0, (Asn1Encodable) this.attributes);
    return (Asn1Object) new DerSequence(elementVector);
  }

  private static void ValidateAttributes(Asn1Set attributes)
  {
    if (attributes == null)
      return;
    foreach (Asn1Encodable attribute in attributes)
    {
      AttributePkcs instance = AttributePkcs.GetInstance((object) attribute.ToAsn1Object());
      if (instance.AttrType.Equals((Asn1Object) PkcsObjectIdentifiers.Pkcs9AtChallengePassword) && instance.AttrValues.Count != 1)
        throw new ArgumentException("challengePassword attribute must have one value");
    }
  }
}
