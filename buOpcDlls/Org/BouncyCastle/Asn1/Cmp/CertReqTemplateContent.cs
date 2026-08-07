// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.Cmp.CertReqTemplateContent
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1.Crmf;
using System;

#nullable disable
namespace Org.BouncyCastle.Asn1.Cmp;

public class CertReqTemplateContent : Asn1Encodable
{
  private readonly CertTemplate m_certTemplate;
  private readonly Asn1Sequence m_keySpec;

  public static CertReqTemplateContent GetInstance(object obj)
  {
    if (obj == null)
      return (CertReqTemplateContent) null;
    return obj is CertReqTemplateContent reqTemplateContent ? reqTemplateContent : new CertReqTemplateContent(Asn1Sequence.GetInstance(obj));
  }

  public static CertReqTemplateContent GetInstance(
    Asn1TaggedObject taggedObject,
    bool declaredExplicit)
  {
    return CertReqTemplateContent.GetInstance((object) Asn1Sequence.GetInstance(taggedObject, declaredExplicit));
  }

  private CertReqTemplateContent(Asn1Sequence seq)
  {
    this.m_certTemplate = seq.Count == 1 || seq.Count == 2 ? CertTemplate.GetInstance((object) seq[0]) : throw new ArgumentException("expected sequence size of 1 or 2");
    if (seq.Count <= 1)
      return;
    this.m_keySpec = Asn1Sequence.GetInstance((object) seq[1]);
  }

  public CertReqTemplateContent(CertTemplate certTemplate, Asn1Sequence keySpec)
  {
    this.m_certTemplate = certTemplate;
    this.m_keySpec = keySpec;
  }

  public virtual CertTemplate CertTemplate => this.m_certTemplate;

  public virtual Asn1Sequence KeySpec => this.m_keySpec;

  public override Asn1Object ToAsn1Object()
  {
    Asn1EncodableVector elementVector = new Asn1EncodableVector((Asn1Encodable) this.m_certTemplate);
    elementVector.AddOptional((Asn1Encodable) this.m_keySpec);
    return (Asn1Object) new DerSequence(elementVector);
  }
}
