// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.Cmp.CertConfirmContent
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;

#nullable disable
namespace Org.BouncyCastle.Asn1.Cmp;

public class CertConfirmContent : Asn1Encodable
{
  private readonly Asn1Sequence m_content;

  public static CertConfirmContent GetInstance(object obj)
  {
    if (obj == null)
      return (CertConfirmContent) null;
    return obj is CertConfirmContent certConfirmContent ? certConfirmContent : new CertConfirmContent(Asn1Sequence.GetInstance(obj));
  }

  public static CertConfirmContent GetInstance(Asn1TaggedObject taggedObject, bool declaredExplicit)
  {
    return CertConfirmContent.GetInstance((object) Asn1Sequence.GetInstance(taggedObject, declaredExplicit));
  }

  private CertConfirmContent(Asn1Sequence seq) => this.m_content = seq;

  public virtual CertStatus[] ToCertStatusArray()
  {
    return this.m_content.MapElements<CertStatus>(new Func<Asn1Encodable, CertStatus>(CertStatus.GetInstance));
  }

  public override Asn1Object ToAsn1Object() => (Asn1Object) this.m_content;
}
