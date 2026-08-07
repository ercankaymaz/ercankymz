// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Math.EC.Custom.Sec.SecT193FieldElement
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Math.Raw;
using Org.BouncyCastle.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Math.EC.Custom.Sec;

internal class SecT193FieldElement : AbstractF2mFieldElement
{
  protected internal readonly ulong[] x;

  public SecT193FieldElement(BigInteger x)
  {
    if (x == null || x.SignValue < 0 || x.BitLength > 193)
      throw new ArgumentException("value invalid for SecT193FieldElement", nameof (x));
    this.x = SecT193Field.FromBigInteger(x);
  }

  public SecT193FieldElement() => this.x = Nat256.Create64();

  protected internal SecT193FieldElement(ulong[] x) => this.x = x;

  public override bool IsOne => Nat256.IsOne64(this.x);

  public override bool IsZero => Nat256.IsZero64(this.x);

  public override bool TestBitZero() => (this.x[0] & 1UL) > 0UL;

  public override BigInteger ToBigInteger() => Nat256.ToBigInteger64(this.x);

  public override string FieldName => "SecT193Field";

  public override int FieldSize => 193;

  public override ECFieldElement Add(ECFieldElement b)
  {
    ulong[] numArray = Nat256.Create64();
    SecT193Field.Add(this.x, ((SecT193FieldElement) b).x, numArray);
    return (ECFieldElement) new SecT193FieldElement(numArray);
  }

  public override ECFieldElement AddOne()
  {
    ulong[] numArray = Nat256.Create64();
    SecT193Field.AddOne(this.x, numArray);
    return (ECFieldElement) new SecT193FieldElement(numArray);
  }

  public override ECFieldElement Subtract(ECFieldElement b) => this.Add(b);

  public override ECFieldElement Multiply(ECFieldElement b)
  {
    ulong[] numArray = Nat256.Create64();
    SecT193Field.Multiply(this.x, ((SecT193FieldElement) b).x, numArray);
    return (ECFieldElement) new SecT193FieldElement(numArray);
  }

  public override ECFieldElement MultiplyMinusProduct(
    ECFieldElement b,
    ECFieldElement x,
    ECFieldElement y)
  {
    return this.MultiplyPlusProduct(b, x, y);
  }

  public override ECFieldElement MultiplyPlusProduct(
    ECFieldElement b,
    ECFieldElement x,
    ECFieldElement y)
  {
    ulong[] x1 = this.x;
    ulong[] x2 = ((SecT193FieldElement) b).x;
    ulong[] x3 = ((SecT193FieldElement) x).x;
    ulong[] x4 = ((SecT193FieldElement) y).x;
    ulong[] ext64 = Nat256.CreateExt64();
    SecT193Field.MultiplyAddToExt(x1, x2, ext64);
    ulong[] y1 = x4;
    ulong[] zz = ext64;
    SecT193Field.MultiplyAddToExt(x3, y1, zz);
    ulong[] numArray = Nat256.Create64();
    SecT193Field.Reduce(ext64, numArray);
    return (ECFieldElement) new SecT193FieldElement(numArray);
  }

  public override ECFieldElement Divide(ECFieldElement b) => this.Multiply(b.Invert());

  public override ECFieldElement Negate() => (ECFieldElement) this;

  public override ECFieldElement Square()
  {
    ulong[] numArray = Nat256.Create64();
    SecT193Field.Square(this.x, numArray);
    return (ECFieldElement) new SecT193FieldElement(numArray);
  }

  public override ECFieldElement SquareMinusProduct(ECFieldElement x, ECFieldElement y)
  {
    return this.SquarePlusProduct(x, y);
  }

  public override ECFieldElement SquarePlusProduct(ECFieldElement x, ECFieldElement y)
  {
    ulong[] x1 = this.x;
    ulong[] x2 = ((SecT193FieldElement) x).x;
    ulong[] x3 = ((SecT193FieldElement) y).x;
    ulong[] ext64 = Nat256.CreateExt64();
    SecT193Field.SquareExt(x1, ext64);
    ulong[] y1 = x3;
    ulong[] zz = ext64;
    SecT193Field.MultiplyAddToExt(x2, y1, zz);
    ulong[] numArray = Nat256.Create64();
    SecT193Field.Reduce(ext64, numArray);
    return (ECFieldElement) new SecT193FieldElement(numArray);
  }

  public override ECFieldElement SquarePow(int pow)
  {
    if (pow < 1)
      return (ECFieldElement) this;
    ulong[] numArray = Nat256.Create64();
    SecT193Field.SquareN(this.x, pow, numArray);
    return (ECFieldElement) new SecT193FieldElement(numArray);
  }

  public override ECFieldElement HalfTrace()
  {
    ulong[] numArray = Nat256.Create64();
    SecT193Field.HalfTrace(this.x, numArray);
    return (ECFieldElement) new SecT193FieldElement(numArray);
  }

  public override bool HasFastTrace => true;

  public override int Trace() => (int) SecT193Field.Trace(this.x);

  public override ECFieldElement Invert()
  {
    ulong[] numArray = Nat256.Create64();
    SecT193Field.Invert(this.x, numArray);
    return (ECFieldElement) new SecT193FieldElement(numArray);
  }

  public override ECFieldElement Sqrt()
  {
    ulong[] numArray = Nat256.Create64();
    SecT193Field.Sqrt(this.x, numArray);
    return (ECFieldElement) new SecT193FieldElement(numArray);
  }

  public virtual int Representation => 2;

  public virtual int M => 193;

  public virtual int K1 => 15;

  public virtual int K2 => 0;

  public virtual int K3 => 0;

  public override bool Equals(object obj) => this.Equals(obj as SecT193FieldElement);

  public override bool Equals(ECFieldElement other) => this.Equals(other as SecT193FieldElement);

  public virtual bool Equals(SecT193FieldElement other)
  {
    if (this == other)
      return true;
    return other != null && Nat256.Eq64(this.x, other.x);
  }

  public override int GetHashCode() => 1930015 ^ Arrays.GetHashCode(this.x, 0, 4);
}
