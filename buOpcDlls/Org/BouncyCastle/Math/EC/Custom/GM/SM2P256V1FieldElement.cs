// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Math.EC.Custom.GM.SM2P256V1FieldElement
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Math.Raw;
using Org.BouncyCastle.Utilities;
using Org.BouncyCastle.Utilities.Encoders;
using System;

#nullable disable
namespace Org.BouncyCastle.Math.EC.Custom.GM;

internal class SM2P256V1FieldElement : AbstractFpFieldElement
{
  public static readonly BigInteger Q = new BigInteger(1, Hex.DecodeStrict("FFFFFFFEFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF00000000FFFFFFFFFFFFFFFF"));
  protected internal readonly uint[] x;

  public SM2P256V1FieldElement(BigInteger x)
  {
    if (x == null || x.SignValue < 0 || x.CompareTo(SM2P256V1FieldElement.Q) >= 0)
      throw new ArgumentException("value invalid for SM2P256V1FieldElement", nameof (x));
    this.x = SM2P256V1Field.FromBigInteger(x);
  }

  public SM2P256V1FieldElement() => this.x = Nat256.Create();

  protected internal SM2P256V1FieldElement(uint[] x) => this.x = x;

  public override bool IsZero => Nat256.IsZero(this.x);

  public override bool IsOne => Nat256.IsOne(this.x);

  public override bool TestBitZero() => Nat256.GetBit(this.x, 0) == 1U;

  public override BigInteger ToBigInteger() => Nat256.ToBigInteger(this.x);

  public override string FieldName => "SM2P256V1Field";

  public override int FieldSize => SM2P256V1FieldElement.Q.BitLength;

  public override ECFieldElement Add(ECFieldElement b)
  {
    uint[] numArray = Nat256.Create();
    SM2P256V1Field.Add(this.x, ((SM2P256V1FieldElement) b).x, numArray);
    return (ECFieldElement) new SM2P256V1FieldElement(numArray);
  }

  public override ECFieldElement AddOne()
  {
    uint[] numArray = Nat256.Create();
    SM2P256V1Field.AddOne(this.x, numArray);
    return (ECFieldElement) new SM2P256V1FieldElement(numArray);
  }

  public override ECFieldElement Subtract(ECFieldElement b)
  {
    uint[] numArray = Nat256.Create();
    SM2P256V1Field.Subtract(this.x, ((SM2P256V1FieldElement) b).x, numArray);
    return (ECFieldElement) new SM2P256V1FieldElement(numArray);
  }

  public override ECFieldElement Multiply(ECFieldElement b)
  {
    uint[] numArray = Nat256.Create();
    SM2P256V1Field.Multiply(this.x, ((SM2P256V1FieldElement) b).x, numArray);
    return (ECFieldElement) new SM2P256V1FieldElement(numArray);
  }

  public override ECFieldElement Divide(ECFieldElement b)
  {
    uint[] numArray = Nat256.Create();
    SM2P256V1Field.Inv(((SM2P256V1FieldElement) b).x, numArray);
    SM2P256V1Field.Multiply(numArray, this.x, numArray);
    return (ECFieldElement) new SM2P256V1FieldElement(numArray);
  }

  public override ECFieldElement Negate()
  {
    uint[] numArray = Nat256.Create();
    SM2P256V1Field.Negate(this.x, numArray);
    return (ECFieldElement) new SM2P256V1FieldElement(numArray);
  }

  public override ECFieldElement Square()
  {
    uint[] numArray = Nat256.Create();
    SM2P256V1Field.Square(this.x, numArray);
    return (ECFieldElement) new SM2P256V1FieldElement(numArray);
  }

  public override ECFieldElement Invert()
  {
    uint[] numArray = Nat256.Create();
    SM2P256V1Field.Inv(this.x, numArray);
    return (ECFieldElement) new SM2P256V1FieldElement(numArray);
  }

  public override ECFieldElement Sqrt()
  {
    uint[] x = this.x;
    if (Nat256.IsZero(x) || Nat256.IsOne(x))
      return (ECFieldElement) this;
    uint[] numArray1 = Nat256.Create();
    SM2P256V1Field.Square(x, numArray1);
    SM2P256V1Field.Multiply(numArray1, x, numArray1);
    uint[] numArray2 = Nat256.Create();
    SM2P256V1Field.SquareN(numArray1, 2, numArray2);
    SM2P256V1Field.Multiply(numArray2, numArray1, numArray2);
    uint[] numArray3 = Nat256.Create();
    SM2P256V1Field.SquareN(numArray2, 2, numArray3);
    SM2P256V1Field.Multiply(numArray3, numArray1, numArray3);
    uint[] numArray4 = numArray1;
    SM2P256V1Field.SquareN(numArray3, 6, numArray4);
    SM2P256V1Field.Multiply(numArray4, numArray3, numArray4);
    uint[] numArray5 = Nat256.Create();
    SM2P256V1Field.SquareN(numArray4, 12, numArray5);
    SM2P256V1Field.Multiply(numArray5, numArray4, numArray5);
    uint[] numArray6 = numArray4;
    SM2P256V1Field.SquareN(numArray5, 6, numArray6);
    SM2P256V1Field.Multiply(numArray6, numArray3, numArray6);
    uint[] numArray7 = numArray3;
    SM2P256V1Field.Square(numArray6, numArray7);
    SM2P256V1Field.Multiply(numArray7, x, numArray7);
    uint[] numArray8 = numArray5;
    SM2P256V1Field.SquareN(numArray7, 31 /*0x1F*/, numArray8);
    uint[] numArray9 = numArray6;
    SM2P256V1Field.Multiply(numArray8, numArray7, numArray9);
    SM2P256V1Field.SquareN(numArray8, 32 /*0x20*/, numArray8);
    SM2P256V1Field.Multiply(numArray8, numArray9, numArray8);
    SM2P256V1Field.SquareN(numArray8, 62, numArray8);
    SM2P256V1Field.Multiply(numArray8, numArray9, numArray8);
    SM2P256V1Field.SquareN(numArray8, 4, numArray8);
    SM2P256V1Field.Multiply(numArray8, numArray2, numArray8);
    SM2P256V1Field.SquareN(numArray8, 32 /*0x20*/, numArray8);
    SM2P256V1Field.Multiply(numArray8, x, numArray8);
    SM2P256V1Field.SquareN(numArray8, 62, numArray8);
    uint[] numArray10 = numArray2;
    SM2P256V1Field.Square(numArray8, numArray10);
    return !Nat256.Eq(x, numArray10) ? (ECFieldElement) null : (ECFieldElement) new SM2P256V1FieldElement(numArray8);
  }

  public override bool Equals(object obj) => this.Equals(obj as SM2P256V1FieldElement);

  public override bool Equals(ECFieldElement other) => this.Equals(other as SM2P256V1FieldElement);

  public virtual bool Equals(SM2P256V1FieldElement other)
  {
    if (this == other)
      return true;
    return other != null && Nat256.Eq(this.x, other.x);
  }

  public override int GetHashCode()
  {
    return SM2P256V1FieldElement.Q.GetHashCode() ^ Arrays.GetHashCode(this.x, 0, 8);
  }
}
