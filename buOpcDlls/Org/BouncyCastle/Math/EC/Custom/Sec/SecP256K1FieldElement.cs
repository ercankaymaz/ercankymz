// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Math.EC.Custom.Sec.SecP256K1FieldElement
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Math.Raw;
using Org.BouncyCastle.Utilities;
using Org.BouncyCastle.Utilities.Encoders;
using System;

#nullable disable
namespace Org.BouncyCastle.Math.EC.Custom.Sec;

internal class SecP256K1FieldElement : AbstractFpFieldElement
{
  public static readonly BigInteger Q = new BigInteger(1, Hex.DecodeStrict("FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFEFFFFFC2F"));
  protected internal readonly uint[] x;

  public SecP256K1FieldElement(BigInteger x)
  {
    if (x == null || x.SignValue < 0 || x.CompareTo(SecP256K1FieldElement.Q) >= 0)
      throw new ArgumentException("value invalid for SecP256K1FieldElement", nameof (x));
    this.x = SecP256K1Field.FromBigInteger(x);
  }

  public SecP256K1FieldElement() => this.x = Nat256.Create();

  protected internal SecP256K1FieldElement(uint[] x) => this.x = x;

  public override bool IsZero => Nat256.IsZero(this.x);

  public override bool IsOne => Nat256.IsOne(this.x);

  public override bool TestBitZero() => Nat256.GetBit(this.x, 0) == 1U;

  public override BigInteger ToBigInteger() => Nat256.ToBigInteger(this.x);

  public override string FieldName => "SecP256K1Field";

  public override int FieldSize => SecP256K1FieldElement.Q.BitLength;

  public override ECFieldElement Add(ECFieldElement b)
  {
    uint[] numArray = Nat256.Create();
    SecP256K1Field.Add(this.x, ((SecP256K1FieldElement) b).x, numArray);
    return (ECFieldElement) new SecP256K1FieldElement(numArray);
  }

  public override ECFieldElement AddOne()
  {
    uint[] numArray = Nat256.Create();
    SecP256K1Field.AddOne(this.x, numArray);
    return (ECFieldElement) new SecP256K1FieldElement(numArray);
  }

  public override ECFieldElement Subtract(ECFieldElement b)
  {
    uint[] numArray = Nat256.Create();
    SecP256K1Field.Subtract(this.x, ((SecP256K1FieldElement) b).x, numArray);
    return (ECFieldElement) new SecP256K1FieldElement(numArray);
  }

  public override ECFieldElement Multiply(ECFieldElement b)
  {
    uint[] numArray = Nat256.Create();
    SecP256K1Field.Multiply(this.x, ((SecP256K1FieldElement) b).x, numArray);
    return (ECFieldElement) new SecP256K1FieldElement(numArray);
  }

  public override ECFieldElement Divide(ECFieldElement b)
  {
    uint[] numArray = Nat256.Create();
    SecP256K1Field.Inv(((SecP256K1FieldElement) b).x, numArray);
    SecP256K1Field.Multiply(numArray, this.x, numArray);
    return (ECFieldElement) new SecP256K1FieldElement(numArray);
  }

  public override ECFieldElement Negate()
  {
    uint[] numArray = Nat256.Create();
    SecP256K1Field.Negate(this.x, numArray);
    return (ECFieldElement) new SecP256K1FieldElement(numArray);
  }

  public override ECFieldElement Square()
  {
    uint[] numArray = Nat256.Create();
    SecP256K1Field.Square(this.x, numArray);
    return (ECFieldElement) new SecP256K1FieldElement(numArray);
  }

  public override ECFieldElement Invert()
  {
    uint[] numArray = Nat256.Create();
    SecP256K1Field.Inv(this.x, numArray);
    return (ECFieldElement) new SecP256K1FieldElement(numArray);
  }

  public override ECFieldElement Sqrt()
  {
    uint[] x = this.x;
    if (Nat256.IsZero(x) || Nat256.IsOne(x))
      return (ECFieldElement) this;
    uint[] ext = Nat256.CreateExt();
    uint[] numArray1 = Nat256.Create();
    SecP256K1Field.Square(x, numArray1, ext);
    SecP256K1Field.Multiply(numArray1, x, numArray1, ext);
    uint[] numArray2 = Nat256.Create();
    SecP256K1Field.Square(numArray1, numArray2, ext);
    SecP256K1Field.Multiply(numArray2, x, numArray2, ext);
    uint[] numArray3 = Nat256.Create();
    SecP256K1Field.SquareN(numArray2, 3, numArray3, ext);
    SecP256K1Field.Multiply(numArray3, numArray2, numArray3, ext);
    uint[] numArray4 = numArray3;
    SecP256K1Field.SquareN(numArray3, 3, numArray4, ext);
    SecP256K1Field.Multiply(numArray4, numArray2, numArray4, ext);
    uint[] numArray5 = numArray4;
    SecP256K1Field.SquareN(numArray4, 2, numArray5, ext);
    SecP256K1Field.Multiply(numArray5, numArray1, numArray5, ext);
    uint[] numArray6 = Nat256.Create();
    SecP256K1Field.SquareN(numArray5, 11, numArray6, ext);
    SecP256K1Field.Multiply(numArray6, numArray5, numArray6, ext);
    uint[] numArray7 = numArray5;
    SecP256K1Field.SquareN(numArray6, 22, numArray7, ext);
    SecP256K1Field.Multiply(numArray7, numArray6, numArray7, ext);
    uint[] numArray8 = Nat256.Create();
    SecP256K1Field.SquareN(numArray7, 44, numArray8, ext);
    SecP256K1Field.Multiply(numArray8, numArray7, numArray8, ext);
    uint[] numArray9 = Nat256.Create();
    SecP256K1Field.SquareN(numArray8, 88, numArray9, ext);
    SecP256K1Field.Multiply(numArray9, numArray8, numArray9, ext);
    uint[] numArray10 = numArray8;
    SecP256K1Field.SquareN(numArray9, 44, numArray10, ext);
    SecP256K1Field.Multiply(numArray10, numArray7, numArray10, ext);
    uint[] numArray11 = numArray7;
    SecP256K1Field.SquareN(numArray10, 3, numArray11, ext);
    SecP256K1Field.Multiply(numArray11, numArray2, numArray11, ext);
    uint[] numArray12 = numArray11;
    SecP256K1Field.SquareN(numArray12, 23, numArray12, ext);
    SecP256K1Field.Multiply(numArray12, numArray6, numArray12, ext);
    SecP256K1Field.SquareN(numArray12, 6, numArray12, ext);
    SecP256K1Field.Multiply(numArray12, numArray1, numArray12, ext);
    SecP256K1Field.SquareN(numArray12, 2, numArray12, ext);
    uint[] numArray13 = numArray1;
    SecP256K1Field.Square(numArray12, numArray13, ext);
    return !Nat256.Eq(x, numArray13) ? (ECFieldElement) null : (ECFieldElement) new SecP256K1FieldElement(numArray12);
  }

  public override bool Equals(object obj) => this.Equals(obj as SecP256K1FieldElement);

  public override bool Equals(ECFieldElement other) => this.Equals(other as SecP256K1FieldElement);

  public virtual bool Equals(SecP256K1FieldElement other)
  {
    if (this == other)
      return true;
    return other != null && Nat256.Eq(this.x, other.x);
  }

  public override int GetHashCode()
  {
    return SecP256K1FieldElement.Q.GetHashCode() ^ Arrays.GetHashCode(this.x, 0, 8);
  }
}
