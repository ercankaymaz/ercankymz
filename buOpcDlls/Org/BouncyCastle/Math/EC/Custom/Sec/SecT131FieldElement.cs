// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Math.EC.Custom.Sec.SecT131FieldElement
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Math.Raw;
using Org.BouncyCastle.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Math.EC.Custom.Sec;

internal class SecT131FieldElement : AbstractF2mFieldElement
{
  protected internal readonly ulong[] x;

  public SecT131FieldElement(BigInteger x)
  {
    if (x == null || x.SignValue < 0 || x.BitLength > 131)
      throw new ArgumentException("value invalid for SecT131FieldElement", nameof (x));
    this.x = SecT131Field.FromBigInteger(x);
  }

  public SecT131FieldElement() => this.x = Nat192.Create64();

  protected internal SecT131FieldElement(ulong[] x) => this.x = x;

  public override bool IsOne => Nat192.IsOne64(this.x);

  public override bool IsZero => Nat192.IsZero64(this.x);

  public override bool TestBitZero() => (this.x[0] & 1UL) > 0UL;

  public override BigInteger ToBigInteger() => Nat192.ToBigInteger64(this.x);

  public override string FieldName => "SecT131Field";

  public override int FieldSize => 131;

  public override ECFieldElement Add(ECFieldElement b)
  {
    ulong[] numArray = Nat192.Create64();
    SecT131Field.Add(this.x, ((SecT131FieldElement) b).x, numArray);
    return (ECFieldElement) new SecT131FieldElement(numArray);
  }

  public override ECFieldElement AddOne()
  {
    ulong[] numArray = Nat192.Create64();
    SecT131Field.AddOne(this.x, numArray);
    return (ECFieldElement) new SecT131FieldElement(numArray);
  }

  public override ECFieldElement Subtract(ECFieldElement b) => this.Add(b);

  public override ECFieldElement Multiply(ECFieldElement b)
  {
    ulong[] numArray = Nat192.Create64();
    SecT131Field.Multiply(this.x, ((SecT131FieldElement) b).x, numArray);
    return (ECFieldElement) new SecT131FieldElement(numArray);
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
    ulong[] x2 = ((SecT131FieldElement) b).x;
    ulong[] x3 = ((SecT131FieldElement) x).x;
    ulong[] x4 = ((SecT131FieldElement) y).x;
    ulong[] numArray1 = Nat.Create64(5);
    SecT131Field.MultiplyAddToExt(x1, x2, numArray1);
    ulong[] y1 = x4;
    ulong[] zz = numArray1;
    SecT131Field.MultiplyAddToExt(x3, y1, zz);
    ulong[] numArray2 = Nat192.Create64();
    SecT131Field.Reduce(numArray1, numArray2);
    return (ECFieldElement) new SecT131FieldElement(numArray2);
  }

  public override ECFieldElement Divide(ECFieldElement b) => this.Multiply(b.Invert());

  public override ECFieldElement Negate() => (ECFieldElement) this;

  public override ECFieldElement Square()
  {
    ulong[] numArray = Nat192.Create64();
    SecT131Field.Square(this.x, numArray);
    return (ECFieldElement) new SecT131FieldElement(numArray);
  }

  public override ECFieldElement SquareMinusProduct(ECFieldElement x, ECFieldElement y)
  {
    return this.SquarePlusProduct(x, y);
  }

  public override ECFieldElement SquarePlusProduct(ECFieldElement x, ECFieldElement y)
  {
    ulong[] x1 = this.x;
    ulong[] x2 = ((SecT131FieldElement) x).x;
    ulong[] x3 = ((SecT131FieldElement) y).x;
    ulong[] numArray1 = Nat.Create64(5);
    SecT131Field.SquareExt(x1, numArray1);
    ulong[] y1 = x3;
    ulong[] zz = numArray1;
    SecT131Field.MultiplyAddToExt(x2, y1, zz);
    ulong[] numArray2 = Nat192.Create64();
    SecT131Field.Reduce(numArray1, numArray2);
    return (ECFieldElement) new SecT131FieldElement(numArray2);
  }

  public override ECFieldElement SquarePow(int pow)
  {
    if (pow < 1)
      return (ECFieldElement) this;
    ulong[] numArray = Nat192.Create64();
    SecT131Field.SquareN(this.x, pow, numArray);
    return (ECFieldElement) new SecT131FieldElement(numArray);
  }

  public override ECFieldElement HalfTrace()
  {
    ulong[] numArray = Nat192.Create64();
    SecT131Field.HalfTrace(this.x, numArray);
    return (ECFieldElement) new SecT131FieldElement(numArray);
  }

  public override bool HasFastTrace => true;

  public override int Trace() => (int) SecT131Field.Trace(this.x);

  public override ECFieldElement Invert()
  {
    ulong[] numArray = Nat192.Create64();
    SecT131Field.Invert(this.x, numArray);
    return (ECFieldElement) new SecT131FieldElement(numArray);
  }

  public override ECFieldElement Sqrt()
  {
    ulong[] numArray = Nat192.Create64();
    SecT131Field.Sqrt(this.x, numArray);
    return (ECFieldElement) new SecT131FieldElement(numArray);
  }

  public virtual int Representation => 3;

  public virtual int M => 131;

  public virtual int K1 => 2;

  public virtual int K2 => 3;

  public virtual int K3 => 8;

  public override bool Equals(object obj) => this.Equals(obj as SecT131FieldElement);

  public override bool Equals(ECFieldElement other) => this.Equals(other as SecT131FieldElement);

  public virtual bool Equals(SecT131FieldElement other)
  {
    if (this == other)
      return true;
    return other != null && Nat192.Eq64(this.x, other.x);
  }

  public override int GetHashCode() => 131832 ^ Arrays.GetHashCode(this.x, 0, 3);
}
