// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.Cmp.PopoDecKeyRespContent
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;

#nullable disable
namespace Org.BouncyCastle.Asn1.Cmp;

public class PopoDecKeyRespContent : Asn1Encodable
{
  private readonly Asn1Sequence m_content;

  public static PopoDecKeyRespContent GetInstance(object obj)
  {
    if (obj == null)
      return (PopoDecKeyRespContent) null;
    return obj is PopoDecKeyRespContent decKeyRespContent ? decKeyRespContent : new PopoDecKeyRespContent(Asn1Sequence.GetInstance(obj));
  }

  public static PopoDecKeyRespContent GetInstance(
    Asn1TaggedObject taggedObject,
    bool declaredExplicit)
  {
    return PopoDecKeyRespContent.GetInstance((object) Asn1Sequence.GetInstance(taggedObject, declaredExplicit));
  }

  private PopoDecKeyRespContent(Asn1Sequence seq) => this.m_content = seq;

  public virtual DerInteger[] ToIntegerArray()
  {
    return this.m_content.MapElements<DerInteger>(new Func<Asn1Encodable, DerInteger>(DerInteger.GetInstance));
  }

  public override Asn1Object ToAsn1Object() => (Asn1Object) this.m_content;
}
