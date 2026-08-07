// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Math.EC.Custom.Sec.SecP256R1FieldElement
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Math.Raw;
using Org.BouncyCastle.Utilities;
using Org.BouncyCastle.Utilities.Encoders;
using System;

#nullable disable
namespace Org.BouncyCastle.Math.EC.Custom.Sec;

internal class SecP256R1FieldElement : AbstractFpFieldElement
{
  public static readonly BigInteger Q = new BigInteger(1, Hex.DecodeStrict("FFFFFFFF00000001000000000000000000000000FFFFFFFFFFFFFFFFFFFFFFFF"));
  protected internal readonly uint[] x;

  public SecP256R1FieldElement(BigInteger x)
  {
    if (x == null || x.SignValue < 0 || x.CompareTo(SecP256R1FieldElement.Q) >= 0)
      throw new ArgumentException("value invalid for SecP256R1FieldElement", nameof (x));
    this.x = SecP256R1Field.FromBigInteger(x);
  }

  public SecP256R1FieldElement() => this.x = Nat256.Create();

  protected internal SecP256R1FieldElement(uint[] x) => this.x = x;

  public override bool IsZero => Nat256.IsZero(this.x);

  public override bool IsOne => Nat256.IsOne(this.x);

  public override bool TestBitZero() => Nat256.GetBit(this.x, 0) == 1U;

  public override BigInteger ToBigInteger() => Nat256.ToBigInteger(this.x);

  public override string FieldName => "SecP256R1Field";

  public override int FieldSize => SecP256R1FieldElement.Q.BitLength;

  public override ECFieldElement Add(ECFieldElement b)
  {
    uint[] numArray = Nat256.Create();
    SecP256R1Field.Add(this.x, ((SecP256R1FieldElement) b).x, numArray);
    return (ECFieldElement) new SecP256R1FieldElement(numArray);
  }

  public override ECFieldElement AddOne()
  {
    uint[] numArray = Nat256.Create();
    SecP256R1Field.AddOne(this.x, numArray);
    return (ECFieldElement) new SecP256R1FieldElement(numArray);
  }

  public override ECFieldElement Subtract(ECFieldElement b)
  {
    uint[] numArray = Nat256.Create();
    SecP256R1Field.Subtract(this.x, ((SecP256R1FieldElement) b).x, numArray);
    return (ECFieldElement) new SecP256R1FieldElement(numArray);
  }

  public override ECFieldElement Multiply(ECFieldElement b)
  {
    uint[] numArray = Nat256.Create();
    SecP256R1Field.Multiply(this.x, ((SecP256R1FieldElement) b).x, numArray);
    return (ECFieldElement) new SecP256R1FieldElement(numArray);
  }

  public override ECFieldElement Divide(ECFieldElement b)
  {
    uint[] numArray = Nat256.Create();
    SecP256R1Field.Inv(((SecP256R1FieldElement) b).x, numArray);
    SecP256R1Field.Multiply(numArray, this.x, numArray);
    return (ECFieldElement) new SecP256R1FieldElement(numArray);
  }

  public override ECFieldElement Negate()
  {
    uint[] numArray = Nat256.Create();
    SecP256R1Field.Negate(this.x, numArray);
    return (ECFieldElement) new SecP256R1FieldElement(numArray);
  }

  public override ECFieldElement Square()
  {
    uint[] numArray = Nat256.Create();
    SecP256R1Field.Square(this.x, numArray);
    return (ECFieldElement) new SecP256R1FieldElement(numArray);
  }

  public override ECFieldElement Invert()
  {
    uint[] numArray = Nat256.Create();
    SecP256R1Field.Inv(this.x, numArray);
    return (ECFieldElement) new SecP256R1FieldElement(numArray);
  }

  public override ECFieldElement Sqrt()
  {
    uint[] x = this.x;
    if (Nat256.IsZero(x) || Nat256.IsOne(x))
      return (ECFieldElement) this;
    uint[] ext = Nat256.CreateExt();
    uint[] numArray1 = Nat256.Create();
    uint[] numArray2 = Nat256.Create();
    SecP256R1Field.Square(x, numArray1, ext);
    SecP256R1Field.Multiply(numArray1, x, numArray1, ext);
    SecP256R1Field.SquareN(numArray1, 2, numArray2, ext);
    SecP256R1Field.Multiply(numArray2, numArray1, numArray2, ext);
    SecP256R1Field.SquareN(numArray2, 4, numArray1, ext);
    SecP256R1Field.Multiply(numArray1, numArray2, numArray1, ext);
    SecP256R1Field.SquareN(numArray1, 8, numArray2, ext);
    SecP256R1Field.Multiply(numArray2, numArray1, numArray2, ext);
    SecP256R1Field.SquareN(numArray2, 16 /*0x10*/, numArray1, ext);
    SecP256R1Field.Multiply(numArray1, numArray2, numArray1, ext);
    SecP256R1Field.SquareN(numArray1, 32 /*0x20*/, numArray1, ext);
    SecP256R1Field.Multiply(numArray1, x, numArray1, ext);
    SecP256R1Field.SquareN(numArray1, 96 /*0x60*/, numArray1, ext);
    SecP256R1Field.Multiply(numArray1, x, numArray1, ext);
    SecP256R1Field.SquareN(numArray1, 94, numArray1, ext);
    SecP256R1Field.Multiply(numArray1, numArray1, numArray2, ext);
    return !Nat256.Eq(x, numArray2) ? (ECFieldElement) null : (ECFieldElement) new SecP256R1FieldElement(numArray1);
  }

  public override bool Equals(object obj) => this.Equals(obj as SecP256R1FieldElement);

  public override bool Equals(ECFieldElement other) => this.Equals(other as SecP256R1FieldElement);

  public virtual bool Equals(SecP256R1FieldElement other)
  {
    if (this == other)
      return true;
    return other != null && Nat256.Eq(this.x, other.x);
  }

  public override int GetHashCode()
  {
    return SecP256R1FieldElement.Q.GetHashCode() ^ Arrays.GetHashCode(this.x, 0, 8);
  }
}
