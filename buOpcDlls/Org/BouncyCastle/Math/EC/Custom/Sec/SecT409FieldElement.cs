// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Math.EC.Custom.Sec.SecT409FieldElement
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Math.Raw;
using Org.BouncyCastle.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Math.EC.Custom.Sec;

internal class SecT409FieldElement : AbstractF2mFieldElement
{
  protected internal readonly ulong[] x;

  public SecT409FieldElement(BigInteger x)
  {
    if (x == null || x.SignValue < 0 || x.BitLength > 409)
      throw new ArgumentException("value invalid for SecT409FieldElement", nameof (x));
    this.x = SecT409Field.FromBigInteger(x);
  }

  public SecT409FieldElement() => this.x = Nat448.Create64();

  protected internal SecT409FieldElement(ulong[] x) => this.x = x;

  public override bool IsOne => Nat448.IsOne64(this.x);

  public override bool IsZero => Nat448.IsZero64(this.x);

  public override bool TestBitZero() => (this.x[0] & 1UL) > 0UL;

  public override BigInteger ToBigInteger() => Nat448.ToBigInteger64(this.x);

  public override string FieldName => "SecT409Field";

  public override int FieldSize => 409;

  public override ECFieldElement Add(ECFieldElement b)
  {
    ulong[] numArray = Nat448.Create64();
    SecT409Field.Add(this.x, ((SecT409FieldElement) b).x, numArray);
    return (ECFieldElement) new SecT409FieldElement(numArray);
  }

  public override ECFieldElement AddOne()
  {
    ulong[] numArray = Nat448.Create64();
    SecT409Field.AddOne(this.x, numArray);
    return (ECFieldElement) new SecT409FieldElement(numArray);
  }

  public override ECFieldElement Subtract(ECFieldElement b) => this.Add(b);

  public override ECFieldElement Multiply(ECFieldElement b)
  {
    ulong[] numArray = Nat448.Create64();
    SecT409Field.Multiply(this.x, ((SecT409FieldElement) b).x, numArray);
    return (ECFieldElement) new SecT409FieldElement(numArray);
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
    ulong[] x2 = ((SecT409FieldElement) b).x;
    ulong[] x3 = ((SecT409FieldElement) x).x;
    ulong[] x4 = ((SecT409FieldElement) y).x;
    ulong[] numArray1 = Nat.Create64(13);
    SecT409Field.MultiplyAddToExt(x1, x2, numArray1);
    ulong[] y1 = x4;
    ulong[] zz = numArray1;
    SecT409Field.MultiplyAddToExt(x3, y1, zz);
    ulong[] numArray2 = Nat448.Create64();
    SecT409Field.Reduce(numArray1, numArray2);
    return (ECFieldElement) new SecT409FieldElement(numArray2);
  }

  public override ECFieldElement Divide(ECFieldElement b) => this.Multiply(b.Invert());

  public override ECFieldElement Negate() => (ECFieldElement) this;

  public override ECFieldElement Square()
  {
    ulong[] numArray = Nat448.Create64();
    SecT409Field.Square(this.x, numArray);
    return (ECFieldElement) new SecT409FieldElement(numArray);
  }

  public override ECFieldElement SquareMinusProduct(ECFieldElement x, ECFieldElement y)
  {
    return this.SquarePlusProduct(x, y);
  }

  public override ECFieldElement SquarePlusProduct(ECFieldElement x, ECFieldElement y)
  {
    ulong[] x1 = this.x;
    ulong[] x2 = ((SecT409FieldElement) x).x;
    ulong[] x3 = ((SecT409FieldElement) y).x;
    ulong[] numArray1 = Nat.Create64(13);
    SecT409Field.SquareExt(x1, numArray1);
    ulong[] y1 = x3;
    ulong[] zz = numArray1;
    SecT409Field.MultiplyAddToExt(x2, y1, zz);
    ulong[] numArray2 = Nat448.Create64();
    SecT409Field.Reduce(numArray1, numArray2);
    return (ECFieldElement) new SecT409FieldElement(numArray2);
  }

  public override ECFieldElement SquarePow(int pow)
  {
    if (pow < 1)
      return (ECFieldElement) this;
    ulong[] numArray = Nat448.Create64();
    SecT409Field.SquareN(this.x, pow, numArray);
    return (ECFieldElement) new SecT409FieldElement(numArray);
  }

  public override ECFieldElement HalfTrace()
  {
    ulong[] numArray = Nat448.Create64();
    SecT409Field.HalfTrace(this.x, numArray);
    return (ECFieldElement) new SecT409FieldElement(numArray);
  }

  public override bool HasFastTrace => true;

  public override int Trace() => (int) SecT409Field.Trace(this.x);

  public override ECFieldElement Invert()
  {
    ulong[] numArray = Nat448.Create64();
    SecT409Field.Invert(this.x, numArray);
    return (ECFieldElement) new SecT409FieldElement(numArray);
  }

  public override ECFieldElement Sqrt()
  {
    ulong[] numArray = Nat448.Create64();
    SecT409Field.Sqrt(this.x, numArray);
    return (ECFieldElement) new SecT409FieldElement(numArray);
  }

  public virtual int Representation => 2;

  public virtual int M => 409;

  public virtual int K1 => 87;

  public virtual int K2 => 0;

  public virtual int K3 => 0;

  public override bool Equals(object obj) => this.Equals(obj as SecT409FieldElement);

  public override bool Equals(ECFieldElement other) => this.Equals(other as SecT409FieldElement);

  public virtual bool Equals(SecT409FieldElement other)
  {
    if (this == other)
      return true;
    return other != null && Nat448.Eq64(this.x, other.x);
  }

  public override int GetHashCode() => 4090087 ^ Arrays.GetHashCode(this.x, 0, 7);
}
