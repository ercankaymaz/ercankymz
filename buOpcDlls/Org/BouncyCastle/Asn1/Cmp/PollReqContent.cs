// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.Cmp.PollReqContent
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Math;
using System;

#nullable disable
namespace Org.BouncyCastle.Asn1.Cmp;

public class PollReqContent : Asn1Encodable
{
  private readonly Asn1Sequence m_content;

  public static PollReqContent GetInstance(object obj)
  {
    if (obj == null)
      return (PollReqContent) null;
    return obj is PollReqContent pollReqContent ? pollReqContent : new PollReqContent(Asn1Sequence.GetInstance(obj));
  }

  public static PollReqContent GetInstance(Asn1TaggedObject taggedObject, bool declaredExplicit)
  {
    return PollReqContent.GetInstance((object) Asn1Sequence.GetInstance(taggedObject, declaredExplicit));
  }

  private PollReqContent(Asn1Sequence seq) => this.m_content = seq;

  public PollReqContent(DerInteger certReqId)
    : this((Asn1Sequence) new DerSequence((Asn1Encodable) new DerSequence((Asn1Encodable) certReqId)))
  {
  }

  public PollReqContent(DerInteger[] certReqIds)
    : this((Asn1Sequence) new DerSequence((Asn1Encodable[]) PollReqContent.IntsToSequence(certReqIds)))
  {
  }

  public PollReqContent(BigInteger certReqId)
    : this(new DerInteger(certReqId))
  {
  }

  public PollReqContent(BigInteger[] certReqIds)
    : this(PollReqContent.IntsToAsn1(certReqIds))
  {
  }

  public virtual DerInteger[][] GetCertReqIDs()
  {
    return this.m_content.MapElements<DerInteger[]>((Func<Asn1Encodable, DerInteger[]>) (element => Asn1Sequence.GetInstance((object) element).MapElements<DerInteger>(new Func<Asn1Encodable, DerInteger>(DerInteger.GetInstance))));
  }

  public virtual BigInteger[] GetCertReqIDValues()
  {
    return this.m_content.MapElements<BigInteger>((Func<Asn1Encodable, BigInteger>) (element => DerInteger.GetInstance((object) Asn1Sequence.GetInstance((object) element)[0]).Value));
  }

  public override Asn1Object ToAsn1Object() => (Asn1Object) this.m_content;

  private static DerSequence[] IntsToSequence(DerInteger[] ids)
  {
    DerSequence[] sequence = new DerSequence[ids.Length];
    for (int index = 0; index != sequence.Length; ++index)
      sequence[index] = new DerSequence((Asn1Encodable) ids[index]);
    return sequence;
  }

  private static DerInteger[] IntsToAsn1(BigInteger[] ids)
  {
    DerInteger[] asn1 = new DerInteger[ids.Length];
    for (int index = 0; index != asn1.Length; ++index)
      asn1[index] = new DerInteger(ids[index]);
    return asn1;
  }
}
