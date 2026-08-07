// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Math.EC.Custom.Sec.SecP160R2FieldElement
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Math.Raw;
using Org.BouncyCastle.Utilities;
using Org.BouncyCastle.Utilities.Encoders;
using System;

#nullable disable
namespace Org.BouncyCastle.Math.EC.Custom.Sec;

internal class SecP160R2FieldElement : AbstractFpFieldElement
{
  public static readonly BigInteger Q = new BigInteger(1, Hex.DecodeStrict("FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFEFFFFAC73"));
  protected internal readonly uint[] x;

  public SecP160R2FieldElement(BigInteger x)
  {
    if (x == null || x.SignValue < 0 || x.CompareTo(SecP160R2FieldElement.Q) >= 0)
      throw new ArgumentException("value invalid for SecP160R2FieldElement", nameof (x));
    this.x = SecP160R2Field.FromBigInteger(x);
  }

  public SecP160R2FieldElement() => this.x = Nat160.Create();

  protected internal SecP160R2FieldElement(uint[] x) => this.x = x;

  public override bool IsZero => Nat160.IsZero(this.x);

  public override bool IsOne => Nat160.IsOne(this.x);

  public override bool TestBitZero() => Nat160.GetBit(this.x, 0) == 1U;

  public override BigInteger ToBigInteger() => Nat160.ToBigInteger(this.x);

  public override string FieldName => "SecP160R2Field";

  public override int FieldSize => SecP160R2FieldElement.Q.BitLength;

  public override ECFieldElement Add(ECFieldElement b)
  {
    uint[] numArray = Nat160.Create();
    SecP160R2Field.Add(this.x, ((SecP160R2FieldElement) b).x, numArray);
    return (ECFieldElement) new SecP160R2FieldElement(numArray);
  }

  public override ECFieldElement AddOne()
  {
    uint[] numArray = Nat160.Create();
    SecP160R2Field.AddOne(this.x, numArray);
    return (ECFieldElement) new SecP160R2FieldElement(numArray);
  }

  public override ECFieldElement Subtract(ECFieldElement b)
  {
    uint[] numArray = Nat160.Create();
    SecP160R2Field.Subtract(this.x, ((SecP160R2FieldElement) b).x, numArray);
    return (ECFieldElement) new SecP160R2FieldElement(numArray);
  }

  public override ECFieldElement Multiply(ECFieldElement b)
  {
    uint[] numArray = Nat160.Create();
    SecP160R2Field.Multiply(this.x, ((SecP160R2FieldElement) b).x, numArray);
    return (ECFieldElement) new SecP160R2FieldElement(numArray);
  }

  public override ECFieldElement Divide(ECFieldElement b)
  {
    uint[] numArray = Nat160.Create();
    SecP160R2Field.Inv(((SecP160R2FieldElement) b).x, numArray);
    SecP160R2Field.Multiply(numArray, this.x, numArray);
    return (ECFieldElement) new SecP160R2FieldElement(numArray);
  }

  public override ECFieldElement Negate()
  {
    uint[] numArray = Nat160.Create();
    SecP160R2Field.Negate(this.x, numArray);
    return (ECFieldElement) new SecP160R2FieldElement(numArray);
  }

  public override ECFieldElement Square()
  {
    uint[] numArray = Nat160.Create();
    SecP160R2Field.Square(this.x, numArray);
    return (ECFieldElement) new SecP160R2FieldElement(numArray);
  }

  public override ECFieldElement Invert()
  {
    uint[] numArray = Nat160.Create();
    SecP160R2Field.Inv(this.x, numArray);
    return (ECFieldElement) new SecP160R2FieldElement(numArray);
  }

  public override ECFieldElement Sqrt()
  {
    uint[] x = this.x;
    if (Nat160.IsZero(x) || Nat160.IsOne(x))
      return (ECFieldElement) this;
    uint[] numArray1 = Nat160.Create();
    SecP160R2Field.Square(x, numArray1);
    SecP160R2Field.Multiply(numArray1, x, numArray1);
    uint[] numArray2 = Nat160.Create();
    SecP160R2Field.Square(numArray1, numArray2);
    SecP160R2Field.Multiply(numArray2, x, numArray2);
    uint[] numArray3 = Nat160.Create();
    SecP160R2Field.Square(numArray2, numArray3);
    SecP160R2Field.Multiply(numArray3, x, numArray3);
    uint[] numArray4 = Nat160.Create();
    SecP160R2Field.SquareN(numArray3, 3, numArray4);
    SecP160R2Field.Multiply(numArray4, numArray2, numArray4);
    uint[] numArray5 = numArray3;
    SecP160R2Field.SquareN(numArray4, 7, numArray5);
    SecP160R2Field.Multiply(numArray5, numArray4, numArray5);
    uint[] numArray6 = numArray4;
    SecP160R2Field.SquareN(numArray5, 3, numArray6);
    SecP160R2Field.Multiply(numArray6, numArray2, numArray6);
    uint[] numArray7 = Nat160.Create();
    SecP160R2Field.SquareN(numArray6, 14, numArray7);
    SecP160R2Field.Multiply(numArray7, numArray5, numArray7);
    uint[] numArray8 = numArray5;
    SecP160R2Field.SquareN(numArray7, 31 /*0x1F*/, numArray8);
    SecP160R2Field.Multiply(numArray8, numArray7, numArray8);
    uint[] numArray9 = numArray7;
    SecP160R2Field.SquareN(numArray8, 62, numArray9);
    SecP160R2Field.Multiply(numArray9, numArray8, numArray9);
    uint[] numArray10 = numArray8;
    SecP160R2Field.SquareN(numArray9, 3, numArray10);
    SecP160R2Field.Multiply(numArray10, numArray2, numArray10);
    uint[] numArray11 = numArray10;
    SecP160R2Field.SquareN(numArray11, 18, numArray11);
    SecP160R2Field.Multiply(numArray11, numArray6, numArray11);
    SecP160R2Field.SquareN(numArray11, 2, numArray11);
    SecP160R2Field.Multiply(numArray11, x, numArray11);
    SecP160R2Field.SquareN(numArray11, 3, numArray11);
    SecP160R2Field.Multiply(numArray11, numArray1, numArray11);
    SecP160R2Field.SquareN(numArray11, 6, numArray11);
    SecP160R2Field.Multiply(numArray11, numArray2, numArray11);
    SecP160R2Field.SquareN(numArray11, 2, numArray11);
    SecP160R2Field.Multiply(numArray11, x, numArray11);
    uint[] numArray12 = numArray1;
    SecP160R2Field.Square(numArray11, numArray12);
    return !Nat160.Eq(x, numArray12) ? (ECFieldElement) null : (ECFieldElement) new SecP160R2FieldElement(numArray11);
  }

  public override bool Equals(object obj) => this.Equals(obj as SecP160R2FieldElement);

  public override bool Equals(ECFieldElement other) => this.Equals(other as SecP160R2FieldElement);

  public virtual bool Equals(SecP160R2FieldElement other)
  {
    if (this == other)
      return true;
    return other != null && Nat160.Eq(this.x, other.x);
  }

  public override int GetHashCode()
  {
    return SecP160R2FieldElement.Q.GetHashCode() ^ Arrays.GetHashCode(this.x, 0, 5);
  }
}
