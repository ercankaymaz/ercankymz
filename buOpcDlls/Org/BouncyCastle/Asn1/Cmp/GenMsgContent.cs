// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.Cmp.GenMsgContent
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;

#nullable disable
namespace Org.BouncyCastle.Asn1.Cmp;

public class GenMsgContent : Asn1Encodable
{
  private readonly Asn1Sequence m_content;

  public static GenMsgContent GetInstance(object obj)
  {
    if (obj == null)
      return (GenMsgContent) null;
    return obj is GenMsgContent genMsgContent ? genMsgContent : new GenMsgContent(Asn1Sequence.GetInstance(obj));
  }

  public static GenMsgContent GetInstance(Asn1TaggedObject taggedObject, bool declaredExplicit)
  {
    return GenMsgContent.GetInstance((object) Asn1Sequence.GetInstance(taggedObject, declaredExplicit));
  }

  private GenMsgContent(Asn1Sequence seq) => this.m_content = seq;

  public GenMsgContent(InfoTypeAndValue itv)
  {
    this.m_content = (Asn1Sequence) new DerSequence((Asn1Encodable) itv);
  }

  public GenMsgContent(params InfoTypeAndValue[] itvs)
  {
    this.m_content = (Asn1Sequence) new DerSequence((Asn1Encodable[]) itvs);
  }

  public virtual InfoTypeAndValue[] ToInfoTypeAndValueArray()
  {
    return this.m_content.MapElements<InfoTypeAndValue>(new Func<Asn1Encodable, InfoTypeAndValue>(InfoTypeAndValue.GetInstance));
  }

  public override Asn1Object ToAsn1Object() => (Asn1Object) this.m_content;
}
