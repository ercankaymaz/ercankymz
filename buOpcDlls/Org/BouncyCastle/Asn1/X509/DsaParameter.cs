// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.X509.DsaParameter
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Math;
using Org.BouncyCastle.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Asn1.X509;

public class DsaParameter : Asn1Encodable
{
  internal readonly DerInteger p;
  internal readonly DerInteger q;
  internal readonly DerInteger g;

  public static DsaParameter GetInstance(Asn1TaggedObject obj, bool explicitly)
  {
    return DsaParameter.GetInstance((object) Asn1Sequence.GetInstance(obj, explicitly));
  }

  public static DsaParameter GetInstance(object obj)
  {
    switch (obj)
    {
      case null:
      case DsaParameter _:
        return (DsaParameter) obj;
      case Asn1Sequence _:
        return new DsaParameter((Asn1Sequence) obj);
      default:
        throw new ArgumentException("Invalid DsaParameter: " + Platform.GetTypeName(obj));
    }
  }

  public DsaParameter(BigInteger p, BigInteger q, BigInteger g)
  {
    this.p = new DerInteger(p);
    this.q = new DerInteger(q);
    this.g = new DerInteger(g);
  }

  private DsaParameter(Asn1Sequence seq)
  {
    this.p = seq.Count == 3 ? DerInteger.GetInstance((object) seq[0]) : throw new ArgumentException("Bad sequence size: " + seq.Count.ToString(), nameof (seq));
    this.q = DerInteger.GetInstance((object) seq[1]);
    this.g = DerInteger.GetInstance((object) seq[2]);
  }

  public BigInteger P => this.p.PositiveValue;

  public BigInteger Q => this.q.PositiveValue;

  public BigInteger G => this.g.PositiveValue;

  public override Asn1Object ToAsn1Object()
  {
    return (Asn1Object) new DerSequence(new Asn1Encodable[3]
    {
      (Asn1Encodable) this.p,
      (Asn1Encodable) this.q,
      (Asn1Encodable) this.g
    });
  }
}
