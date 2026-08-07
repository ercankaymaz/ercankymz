// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Math.EC.Custom.Sec.SecP192R1FieldElement
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Math.Raw;
using Org.BouncyCastle.Utilities;
using Org.BouncyCastle.Utilities.Encoders;
using System;

#nullable disable
namespace Org.BouncyCastle.Math.EC.Custom.Sec;

internal class SecP192R1FieldElement : AbstractFpFieldElement
{
  public static readonly BigInteger Q = new BigInteger(1, Hex.DecodeStrict("FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFEFFFFFFFFFFFFFFFF"));
  protected internal readonly uint[] x;

  public SecP192R1FieldElement(BigInteger x)
  {
    if (x == null || x.SignValue < 0 || x.CompareTo(SecP192R1FieldElement.Q) >= 0)
      throw new ArgumentException("value invalid for SecP192R1FieldElement", nameof (x));
    this.x = SecP192R1Field.FromBigInteger(x);
  }

  public SecP192R1FieldElement() => this.x = Nat192.Create();

  protected internal SecP192R1FieldElement(uint[] x) => this.x = x;

  public override bool IsZero => Nat192.IsZero(this.x);

  public override bool IsOne => Nat192.IsOne(this.x);

  public override bool TestBitZero() => Nat192.GetBit(this.x, 0) == 1U;

  public override BigInteger ToBigInteger() => Nat192.ToBigInteger(this.x);

  public override string FieldName => "SecP192R1Field";

  public override int FieldSize => SecP192R1FieldElement.Q.BitLength;

  public override ECFieldElement Add(ECFieldElement b)
  {
    uint[] numArray = Nat192.Create();
    SecP192R1Field.Add(this.x, ((SecP192R1FieldElement) b).x, numArray);
    return (ECFieldElement) new SecP192R1FieldElement(numArray);
  }

  public override ECFieldElement AddOne()
  {
    uint[] numArray = Nat192.Create();
    SecP192R1Field.AddOne(this.x, numArray);
    return (ECFieldElement) new SecP192R1FieldElement(numArray);
  }

  public override ECFieldElement Subtract(ECFieldElement b)
  {
    uint[] numArray = Nat192.Create();
    SecP192R1Field.Subtract(this.x, ((SecP192R1FieldElement) b).x, numArray);
    return (ECFieldElement) new SecP192R1FieldElement(numArray);
  }

  public override ECFieldElement Multiply(ECFieldElement b)
  {
    uint[] numArray = Nat192.Create();
    SecP192R1Field.Multiply(this.x, ((SecP192R1FieldElement) b).x, numArray);
    return (ECFieldElement) new SecP192R1FieldElement(numArray);
  }

  public override ECFieldElement Divide(ECFieldElement b)
  {
    uint[] numArray = Nat192.Create();
    SecP192R1Field.Inv(((SecP192R1FieldElement) b).x, numArray);
    SecP192R1Field.Multiply(numArray, this.x, numArray);
    return (ECFieldElement) new SecP192R1FieldElement(numArray);
  }

  public override ECFieldElement Negate()
  {
    uint[] numArray = Nat192.Create();
    SecP192R1Field.Negate(this.x, numArray);
    return (ECFieldElement) new SecP192R1FieldElement(numArray);
  }

  public override ECFieldElement Square()
  {
    uint[] numArray = Nat192.Create();
    SecP192R1Field.Square(this.x, numArray);
    return (ECFieldElement) new SecP192R1FieldElement(numArray);
  }

  public override ECFieldElement Invert()
  {
    uint[] numArray = Nat192.Create();
    SecP192R1Field.Inv(this.x, numArray);
    return (ECFieldElement) new SecP192R1FieldElement(numArray);
  }

  public override ECFieldElement Sqrt()
  {
    uint[] x = this.x;
    if (Nat192.IsZero(x) || Nat192.IsOne(x))
      return (ECFieldElement) this;
    uint[] numArray1 = Nat192.Create();
    uint[] numArray2 = Nat192.Create();
    SecP192R1Field.Square(x, numArray1);
    SecP192R1Field.Multiply(numArray1, x, numArray1);
    SecP192R1Field.SquareN(numArray1, 2, numArray2);
    SecP192R1Field.Multiply(numArray2, numArray1, numArray2);
    SecP192R1Field.SquareN(numArray2, 4, numArray1);
    SecP192R1Field.Multiply(numArray1, numArray2, numArray1);
    SecP192R1Field.SquareN(numArray1, 8, numArray2);
    SecP192R1Field.Multiply(numArray2, numArray1, numArray2);
    SecP192R1Field.SquareN(numArray2, 16 /*0x10*/, numArray1);
    SecP192R1Field.Multiply(numArray1, numArray2, numArray1);
    SecP192R1Field.SquareN(numArray1, 32 /*0x20*/, numArray2);
    SecP192R1Field.Multiply(numArray2, numArray1, numArray2);
    SecP192R1Field.SquareN(numArray2, 64 /*0x40*/, numArray1);
    SecP192R1Field.Multiply(numArray1, numArray2, numArray1);
    SecP192R1Field.SquareN(numArray1, 62, numArray1);
    SecP192R1Field.Square(numArray1, numArray2);
    return !Nat192.Eq(x, numArray2) ? (ECFieldElement) null : (ECFieldElement) new SecP192R1FieldElement(numArray1);
  }

  public override bool Equals(object obj) => this.Equals(obj as SecP192R1FieldElement);

  public override bool Equals(ECFieldElement other) => this.Equals(other as SecP192R1FieldElement);

  public virtual bool Equals(SecP192R1FieldElement other)
  {
    if (this == other)
      return true;
    return other != null && Nat192.Eq(this.x, other.x);
  }

  public override int GetHashCode()
  {
    return SecP192R1FieldElement.Q.GetHashCode() ^ Arrays.GetHashCode(this.x, 0, 6);
  }
}
