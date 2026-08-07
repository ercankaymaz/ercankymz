// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Math.EC.Custom.Sec.SecP521R1FieldElement
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Math.Raw;
using Org.BouncyCastle.Utilities;
using Org.BouncyCastle.Utilities.Encoders;
using System;

#nullable disable
namespace Org.BouncyCastle.Math.EC.Custom.Sec;

internal class SecP521R1FieldElement : AbstractFpFieldElement
{
  public static readonly BigInteger Q = new BigInteger(1, Hex.DecodeStrict("01FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF"));
  protected internal readonly uint[] x;

  public SecP521R1FieldElement(BigInteger x)
  {
    if (x == null || x.SignValue < 0 || x.CompareTo(SecP521R1FieldElement.Q) >= 0)
      throw new ArgumentException("value invalid for SecP521R1FieldElement", nameof (x));
    this.x = SecP521R1Field.FromBigInteger(x);
  }

  public SecP521R1FieldElement() => this.x = Nat.Create(17);

  protected internal SecP521R1FieldElement(uint[] x) => this.x = x;

  public override bool IsZero => Nat.IsZero(17, this.x);

  public override bool IsOne => Nat.IsOne(17, this.x);

  public override bool TestBitZero() => Nat.GetBit(this.x, 0) == 1U;

  public override BigInteger ToBigInteger() => Nat.ToBigInteger(17, this.x);

  public override string FieldName => "SecP521R1Field";

  public override int FieldSize => SecP521R1FieldElement.Q.BitLength;

  public override ECFieldElement Add(ECFieldElement b)
  {
    uint[] numArray = Nat.Create(17);
    SecP521R1Field.Add(this.x, ((SecP521R1FieldElement) b).x, numArray);
    return (ECFieldElement) new SecP521R1FieldElement(numArray);
  }

  public override ECFieldElement AddOne()
  {
    uint[] numArray = Nat.Create(17);
    SecP521R1Field.AddOne(this.x, numArray);
    return (ECFieldElement) new SecP521R1FieldElement(numArray);
  }

  public override ECFieldElement Subtract(ECFieldElement b)
  {
    uint[] numArray = Nat.Create(17);
    SecP521R1Field.Subtract(this.x, ((SecP521R1FieldElement) b).x, numArray);
    return (ECFieldElement) new SecP521R1FieldElement(numArray);
  }

  public override ECFieldElement Multiply(ECFieldElement b)
  {
    uint[] numArray = Nat.Create(17);
    SecP521R1Field.Multiply(this.x, ((SecP521R1FieldElement) b).x, numArray);
    return (ECFieldElement) new SecP521R1FieldElement(numArray);
  }

  public override ECFieldElement Divide(ECFieldElement b)
  {
    uint[] numArray = Nat.Create(17);
    SecP521R1Field.Inv(((SecP521R1FieldElement) b).x, numArray);
    SecP521R1Field.Multiply(numArray, this.x, numArray);
    return (ECFieldElement) new SecP521R1FieldElement(numArray);
  }

  public override ECFieldElement Negate()
  {
    uint[] numArray = Nat.Create(17);
    SecP521R1Field.Negate(this.x, numArray);
    return (ECFieldElement) new SecP521R1FieldElement(numArray);
  }

  public override ECFieldElement Square()
  {
    uint[] numArray = Nat.Create(17);
    SecP521R1Field.Square(this.x, numArray);
    return (ECFieldElement) new SecP521R1FieldElement(numArray);
  }

  public override ECFieldElement Invert()
  {
    uint[] numArray = Nat.Create(17);
    SecP521R1Field.Inv(this.x, numArray);
    return (ECFieldElement) new SecP521R1FieldElement(numArray);
  }

  public override ECFieldElement Sqrt()
  {
    uint[] x = this.x;
    if (Nat.IsZero(17, x) || Nat.IsOne(17, x))
      return (ECFieldElement) this;
    uint[] tt = Nat.Create(33);
    uint[] numArray1 = Nat.Create(17);
    uint[] numArray2 = Nat.Create(17);
    SecP521R1Field.SquareN(x, 519, numArray1, tt);
    SecP521R1Field.Square(numArray1, numArray2, tt);
    return !Nat.Eq(17, x, numArray2) ? (ECFieldElement) null : (ECFieldElement) new SecP521R1FieldElement(numArray1);
  }

  public override bool Equals(object obj) => this.Equals(obj as SecP521R1FieldElement);

  public override bool Equals(ECFieldElement other) => this.Equals(other as SecP521R1FieldElement);

  public virtual bool Equals(SecP521R1FieldElement other)
  {
    if (this == other)
      return true;
    return other != null && Nat.Eq(17, this.x, other.x);
  }

  public override int GetHashCode()
  {
    return SecP521R1FieldElement.Q.GetHashCode() ^ Arrays.GetHashCode(this.x, 0, 17);
  }
}
