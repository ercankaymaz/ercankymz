// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.CryptoPro.ECGost3410ParamSetParameters
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Math;
using Org.BouncyCastle.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Asn1.CryptoPro;

public class ECGost3410ParamSetParameters : Asn1Encodable
{
  internal readonly DerInteger p;
  internal readonly DerInteger q;
  internal readonly DerInteger a;
  internal readonly DerInteger b;
  internal readonly DerInteger x;
  internal readonly DerInteger y;

  public static ECGost3410ParamSetParameters GetInstance(Asn1TaggedObject obj, bool explicitly)
  {
    return ECGost3410ParamSetParameters.GetInstance((object) Asn1Sequence.GetInstance(obj, explicitly));
  }

  public static ECGost3410ParamSetParameters GetInstance(object obj)
  {
    switch (obj)
    {
      case null:
      case ECGost3410ParamSetParameters _:
        return (ECGost3410ParamSetParameters) obj;
      case Asn1Sequence seq:
        return new ECGost3410ParamSetParameters(seq);
      default:
        throw new ArgumentException("Invalid GOST3410Parameter: " + Platform.GetTypeName(obj));
    }
  }

  public ECGost3410ParamSetParameters(
    BigInteger a,
    BigInteger b,
    BigInteger p,
    BigInteger q,
    int x,
    BigInteger y)
  {
    this.a = new DerInteger(a);
    this.b = new DerInteger(b);
    this.p = new DerInteger(p);
    this.q = new DerInteger(q);
    this.x = new DerInteger(x);
    this.y = new DerInteger(y);
  }

  public ECGost3410ParamSetParameters(Asn1Sequence seq)
  {
    this.a = seq.Count == 6 ? DerInteger.GetInstance((object) seq[0]) : throw new ArgumentException("Wrong number of elements in sequence", nameof (seq));
    this.b = DerInteger.GetInstance((object) seq[1]);
    this.p = DerInteger.GetInstance((object) seq[2]);
    this.q = DerInteger.GetInstance((object) seq[3]);
    this.x = DerInteger.GetInstance((object) seq[4]);
    this.y = DerInteger.GetInstance((object) seq[5]);
  }

  public BigInteger P => this.p.PositiveValue;

  public BigInteger Q => this.q.PositiveValue;

  public BigInteger A => this.a.PositiveValue;

  public override Asn1Object ToAsn1Object()
  {
    return (Asn1Object) new DerSequence(new Asn1Encodable[6]
    {
      (Asn1Encodable) this.a,
      (Asn1Encodable) this.b,
      (Asn1Encodable) this.p,
      (Asn1Encodable) this.q,
      (Asn1Encodable) this.x,
      (Asn1Encodable) this.y
    });
  }
}
