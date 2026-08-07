// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.CryptoPro.Gost3410ParamSetParameters
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Math;
using Org.BouncyCastle.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Asn1.CryptoPro;

public class Gost3410ParamSetParameters : Asn1Encodable
{
  private readonly int keySize;
  private readonly DerInteger p;
  private readonly DerInteger q;
  private readonly DerInteger a;

  public static Gost3410ParamSetParameters GetInstance(Asn1TaggedObject obj, bool explicitly)
  {
    return Gost3410ParamSetParameters.GetInstance((object) Asn1Sequence.GetInstance(obj, explicitly));
  }

  public static Gost3410ParamSetParameters GetInstance(object obj)
  {
    switch (obj)
    {
      case null:
      case Gost3410ParamSetParameters _:
        return (Gost3410ParamSetParameters) obj;
      case Asn1Sequence seq:
        return new Gost3410ParamSetParameters(seq);
      default:
        throw new ArgumentException("Invalid GOST3410Parameter: " + Platform.GetTypeName(obj));
    }
  }

  public Gost3410ParamSetParameters(int keySize, BigInteger p, BigInteger q, BigInteger a)
  {
    this.keySize = keySize;
    this.p = new DerInteger(p);
    this.q = new DerInteger(q);
    this.a = new DerInteger(a);
  }

  private Gost3410ParamSetParameters(Asn1Sequence seq)
  {
    this.keySize = seq.Count == 4 ? DerInteger.GetInstance((object) seq[0]).IntValueExact : throw new ArgumentException("Wrong number of elements in sequence", nameof (seq));
    this.p = DerInteger.GetInstance((object) seq[1]);
    this.q = DerInteger.GetInstance((object) seq[2]);
    this.a = DerInteger.GetInstance((object) seq[3]);
  }

  public int KeySize => this.keySize;

  public BigInteger P => this.p.PositiveValue;

  public BigInteger Q => this.q.PositiveValue;

  public BigInteger A => this.a.PositiveValue;

  public override Asn1Object ToAsn1Object()
  {
    return (Asn1Object) new DerSequence(new Asn1Encodable[4]
    {
      (Asn1Encodable) new DerInteger(this.keySize),
      (Asn1Encodable) this.p,
      (Asn1Encodable) this.q,
      (Asn1Encodable) this.a
    });
  }
}
