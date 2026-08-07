// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.Cmp.GenRepContent
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;

#nullable disable
namespace Org.BouncyCastle.Asn1.Cmp;

public class GenRepContent : Asn1Encodable
{
  private readonly Asn1Sequence m_content;

  public static GenRepContent GetInstance(object obj)
  {
    if (obj == null)
      return (GenRepContent) null;
    return obj is GenRepContent genRepContent ? genRepContent : new GenRepContent(Asn1Sequence.GetInstance(obj));
  }

  public static GenRepContent GetInstance(Asn1TaggedObject taggedObject, bool declaredExplicit)
  {
    return GenRepContent.GetInstance((object) Asn1Sequence.GetInstance(taggedObject, declaredExplicit));
  }

  private GenRepContent(Asn1Sequence seq) => this.m_content = seq;

  public GenRepContent(InfoTypeAndValue itv)
  {
    this.m_content = (Asn1Sequence) new DerSequence((Asn1Encodable) itv);
  }

  public GenRepContent(params InfoTypeAndValue[] itvs)
  {
    this.m_content = (Asn1Sequence) new DerSequence((Asn1Encodable[]) itvs);
  }

  public virtual InfoTypeAndValue[] ToInfoTypeAndValueArray()
  {
    return this.m_content.MapElements<InfoTypeAndValue>(new Func<Asn1Encodable, InfoTypeAndValue>(InfoTypeAndValue.GetInstance));
  }

  public override Asn1Object ToAsn1Object() => (Asn1Object) this.m_content;
}
