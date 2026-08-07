// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Math.EC.Custom.Sec.SecP384R1FieldElement
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Math.Raw;
using Org.BouncyCastle.Utilities;
using Org.BouncyCastle.Utilities.Encoders;
using System;

#nullable disable
namespace Org.BouncyCastle.Math.EC.Custom.Sec;

internal class SecP384R1FieldElement : AbstractFpFieldElement
{
  public static readonly BigInteger Q = new BigInteger(1, Hex.DecodeStrict("FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFEFFFFFFFF0000000000000000FFFFFFFF"));
  protected internal readonly uint[] x;

  public SecP384R1FieldElement(BigInteger x)
  {
    if (x == null || x.SignValue < 0 || x.CompareTo(SecP384R1FieldElement.Q) >= 0)
      throw new ArgumentException("value invalid for SecP384R1FieldElement", nameof (x));
    this.x = SecP384R1Field.FromBigInteger(x);
  }

  public SecP384R1FieldElement() => this.x = Nat.Create(12);

  protected internal SecP384R1FieldElement(uint[] x) => this.x = x;

  public override bool IsZero => Nat.IsZero(12, this.x);

  public override bool IsOne => Nat.IsOne(12, this.x);

  public override bool TestBitZero() => Nat.GetBit(this.x, 0) == 1U;

  public override BigInteger ToBigInteger() => Nat.ToBigInteger(12, this.x);

  public override string FieldName => "SecP384R1Field";

  public override int FieldSize => SecP384R1FieldElement.Q.BitLength;

  public override ECFieldElement Add(ECFieldElement b)
  {
    uint[] numArray = Nat.Create(12);
    SecP384R1Field.Add(this.x, ((SecP384R1FieldElement) b).x, numArray);
    return (ECFieldElement) new SecP384R1FieldElement(numArray);
  }

  public override ECFieldElement AddOne()
  {
    uint[] numArray = Nat.Create(12);
    SecP384R1Field.AddOne(this.x, numArray);
    return (ECFieldElement) new SecP384R1FieldElement(numArray);
  }

  public override ECFieldElement Subtract(ECFieldElement b)
  {
    uint[] numArray = Nat.Create(12);
    SecP384R1Field.Subtract(this.x, ((SecP384R1FieldElement) b).x, numArray);
    return (ECFieldElement) new SecP384R1FieldElement(numArray);
  }

  public override ECFieldElement Multiply(ECFieldElement b)
  {
    uint[] numArray = Nat.Create(12);
    SecP384R1Field.Multiply(this.x, ((SecP384R1FieldElement) b).x, numArray);
    return (ECFieldElement) new SecP384R1FieldElement(numArray);
  }

  public override ECFieldElement Divide(ECFieldElement b)
  {
    uint[] numArray = Nat.Create(12);
    SecP384R1Field.Inv(((SecP384R1FieldElement) b).x, numArray);
    SecP384R1Field.Multiply(numArray, this.x, numArray);
    return (ECFieldElement) new SecP384R1FieldElement(numArray);
  }

  public override ECFieldElement Negate()
  {
    uint[] numArray = Nat.Create(12);
    SecP384R1Field.Negate(this.x, numArray);
    return (ECFieldElement) new SecP384R1FieldElement(numArray);
  }

  public override ECFieldElement Square()
  {
    uint[] numArray = Nat.Create(12);
    SecP384R1Field.Square(this.x, numArray);
    return (ECFieldElement) new SecP384R1FieldElement(numArray);
  }

  public override ECFieldElement Invert()
  {
    uint[] numArray = Nat.Create(12);
    SecP384R1Field.Inv(this.x, numArray);
    return (ECFieldElement) new SecP384R1FieldElement(numArray);
  }

  public override ECFieldElement Sqrt()
  {
    uint[] x = this.x;
    if (Nat.IsZero(12, x) || Nat.IsOne(12, x))
      return (ECFieldElement) this;
    uint[] tt = Nat.Create(24);
    uint[] numArray1 = Nat.Create(12);
    uint[] numArray2 = Nat.Create(12);
    uint[] numArray3 = Nat.Create(12);
    uint[] numArray4 = Nat.Create(12);
    SecP384R1Field.Square(x, numArray1, tt);
    SecP384R1Field.Multiply(numArray1, x, numArray1, tt);
    SecP384R1Field.SquareN(numArray1, 2, numArray2, tt);
    SecP384R1Field.Multiply(numArray2, numArray1, numArray2, tt);
    SecP384R1Field.Square(numArray2, numArray2, tt);
    SecP384R1Field.Multiply(numArray2, x, numArray2, tt);
    SecP384R1Field.SquareN(numArray2, 5, numArray3, tt);
    SecP384R1Field.Multiply(numArray3, numArray2, numArray3, tt);
    SecP384R1Field.SquareN(numArray3, 5, numArray4, tt);
    SecP384R1Field.Multiply(numArray4, numArray2, numArray4, tt);
    SecP384R1Field.SquareN(numArray4, 15, numArray2, tt);
    SecP384R1Field.Multiply(numArray2, numArray4, numArray2, tt);
    SecP384R1Field.SquareN(numArray2, 2, numArray3, tt);
    SecP384R1Field.Multiply(numArray1, numArray3, numArray1, tt);
    SecP384R1Field.SquareN(numArray3, 28, numArray3, tt);
    SecP384R1Field.Multiply(numArray2, numArray3, numArray2, tt);
    SecP384R1Field.SquareN(numArray2, 60, numArray3, tt);
    SecP384R1Field.Multiply(numArray3, numArray2, numArray3, tt);
    uint[] numArray5 = numArray2;
    SecP384R1Field.SquareN(numArray3, 120, numArray5, tt);
    SecP384R1Field.Multiply(numArray5, numArray3, numArray5, tt);
    SecP384R1Field.SquareN(numArray5, 15, numArray5, tt);
    SecP384R1Field.Multiply(numArray5, numArray4, numArray5, tt);
    SecP384R1Field.SquareN(numArray5, 33, numArray5, tt);
    SecP384R1Field.Multiply(numArray5, numArray1, numArray5, tt);
    SecP384R1Field.SquareN(numArray5, 64 /*0x40*/, numArray5, tt);
    SecP384R1Field.Multiply(numArray5, x, numArray5, tt);
    SecP384R1Field.SquareN(numArray5, 30, numArray1, tt);
    SecP384R1Field.Square(numArray1, numArray2, tt);
    return !Nat.Eq(12, x, numArray2) ? (ECFieldElement) null : (ECFieldElement) new SecP384R1FieldElement(numArray1);
  }

  public override bool Equals(object obj) => this.Equals(obj as SecP384R1FieldElement);

  public override bool Equals(ECFieldElement other) => this.Equals(other as SecP384R1FieldElement);

  public virtual bool Equals(SecP384R1FieldElement other)
  {
    if (this == other)
      return true;
    return other != null && Nat.Eq(12, this.x, other.x);
  }

  public override int GetHashCode()
  {
    return SecP384R1FieldElement.Q.GetHashCode() ^ Arrays.GetHashCode(this.x, 0, 12);
  }
}
