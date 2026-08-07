// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.Cmp.DhbmParameter
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1.X509;
using System;

#nullable disable
namespace Org.BouncyCastle.Asn1.Cmp;

public class DhbmParameter : Asn1Encodable
{
  private readonly AlgorithmIdentifier m_owf;
  private readonly AlgorithmIdentifier m_mac;

  public static DhbmParameter GetInstance(object obj)
  {
    if (obj == null)
      return (DhbmParameter) null;
    return obj is DhbmParameter dhbmParameter ? dhbmParameter : new DhbmParameter(Asn1Sequence.GetInstance(obj));
  }

  public static DhbmParameter GetInstance(Asn1TaggedObject taggedObject, bool declaredExplicit)
  {
    return DhbmParameter.GetInstance((object) Asn1Sequence.GetInstance(taggedObject, declaredExplicit));
  }

  private DhbmParameter(Asn1Sequence sequence)
  {
    this.m_owf = sequence.Count == 2 ? AlgorithmIdentifier.GetInstance((object) sequence[0]) : throw new ArgumentException("expecting sequence size of 2");
    this.m_mac = AlgorithmIdentifier.GetInstance((object) sequence[1]);
  }

  public DhbmParameter(AlgorithmIdentifier owf, AlgorithmIdentifier mac)
  {
    this.m_owf = owf;
    this.m_mac = mac;
  }

  public virtual AlgorithmIdentifier Owf => this.m_owf;

  public virtual AlgorithmIdentifier Mac => this.m_mac;

  public override Asn1Object ToAsn1Object()
  {
    return (Asn1Object) new DerSequence((Asn1Encodable) this.m_owf, (Asn1Encodable) this.m_mac);
  }
}
