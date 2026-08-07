// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Math.EC.Custom.Sec.SecP192R1Point
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Math.Raw;

#nullable disable
namespace Org.BouncyCastle.Math.EC.Custom.Sec;

internal class SecP192R1Point : AbstractFpPoint
{
  internal SecP192R1Point(ECCurve curve, ECFieldElement x, ECFieldElement y)
    : base(curve, x, y)
  {
  }

  internal SecP192R1Point(ECCurve curve, ECFieldElement x, ECFieldElement y, ECFieldElement[] zs)
    : base(curve, x, y, zs)
  {
  }

  protected override ECPoint Detach()
  {
    return (ECPoint) new SecP192R1Point((ECCurve) null, this.AffineXCoord, this.AffineYCoord);
  }

  public override ECPoint Add(ECPoint b)
  {
    if (this.IsInfinity)
      return b;
    if (b.IsInfinity)
      return (ECPoint) this;
    if (this == b)
      return this.Twice();
    ECCurve curve = this.Curve;
    SecP192R1FieldElement rawXcoord1 = (SecP192R1FieldElement) this.RawXCoord;
    SecP192R1FieldElement rawYcoord1 = (SecP192R1FieldElement) this.RawYCoord;
    SecP192R1FieldElement rawXcoord2 = (SecP192R1FieldElement) b.RawXCoord;
    SecP192R1FieldElement rawYcoord2 = (SecP192R1FieldElement) b.RawYCoord;
    SecP192R1FieldElement rawZcoord1 = (SecP192R1FieldElement) this.RawZCoords[0];
    SecP192R1FieldElement rawZcoord2 = (SecP192R1FieldElement) b.RawZCoords[0];
    uint[] ext = Nat192.CreateExt();
    uint[] numArray1 = Nat192.Create();
    uint[] numArray2 = Nat192.Create();
    uint[] x1 = Nat192.Create();
    bool isOne1;
    uint[] numArray3;
    uint[] numArray4;
    if (isOne1 = rawZcoord1.IsOne)
    {
      numArray3 = rawXcoord2.x;
      numArray4 = rawYcoord2.x;
    }
    else
    {
      numArray4 = numArray2;
      SecP192R1Field.Square(rawZcoord1.x, numArray4);
      numArray3 = numArray1;
      SecP192R1Field.Multiply(numArray4, rawXcoord2.x, numArray3);
      SecP192R1Field.Multiply(numArray4, rawZcoord1.x, numArray4);
      SecP192R1Field.Multiply(numArray4, rawYcoord2.x, numArray4);
    }
    bool isOne2;
    uint[] numArray5;
    uint[] numArray6;
    if (isOne2 = rawZcoord2.IsOne)
    {
      numArray5 = rawXcoord1.x;
      numArray6 = rawYcoord1.x;
    }
    else
    {
      numArray6 = x1;
      SecP192R1Field.Square(rawZcoord2.x, numArray6);
      numArray5 = ext;
      SecP192R1Field.Multiply(numArray6, rawXcoord1.x, numArray5);
      SecP192R1Field.Multiply(numArray6, rawZcoord2.x, numArray6);
      SecP192R1Field.Multiply(numArray6, rawYcoord1.x, numArray6);
    }
    uint[] numArray7 = Nat192.Create();
    SecP192R1Field.Subtract(numArray5, numArray3, numArray7);
    uint[] numArray8 = numArray1;
    SecP192R1Field.Subtract(numArray6, numArray4, numArray8);
    if (Nat192.IsZero(numArray7))
      return Nat192.IsZero(numArray8) ? this.Twice() : curve.Infinity;
    uint[] numArray9 = numArray2;
    SecP192R1Field.Square(numArray7, numArray9);
    uint[] numArray10 = Nat192.Create();
    SecP192R1Field.Multiply(numArray9, numArray7, numArray10);
    uint[] numArray11 = numArray2;
    SecP192R1Field.Multiply(numArray9, numArray5, numArray11);
    SecP192R1Field.Negate(numArray10, numArray10);
    Nat192.Mul(numArray6, numArray10, ext);
    SecP192R1Field.Reduce32(Nat192.AddBothTo(numArray11, numArray11, numArray10), numArray10);
    SecP192R1FieldElement x2 = new SecP192R1FieldElement(x1);
    SecP192R1Field.Square(numArray8, x2.x);
    SecP192R1Field.Subtract(x2.x, numArray10, x2.x);
    SecP192R1FieldElement y = new SecP192R1FieldElement(numArray10);
    SecP192R1Field.Subtract(numArray11, x2.x, y.x);
    SecP192R1Field.MultiplyAddToExt(y.x, numArray8, ext);
    SecP192R1Field.Reduce(ext, y.x);
    SecP192R1FieldElement p192R1FieldElement = new SecP192R1FieldElement(numArray7);
    if (!isOne1)
      SecP192R1Field.Multiply(p192R1FieldElement.x, rawZcoord1.x, p192R1FieldElement.x);
    if (!isOne2)
      SecP192R1Field.Multiply(p192R1FieldElement.x, rawZcoord2.x, p192R1FieldElement.x);
    ECFieldElement[] zs = new ECFieldElement[1]
    {
      (ECFieldElement) p192R1FieldElement
    };
    return (ECPoint) new SecP192R1Point(curve, (ECFieldElement) x2, (ECFieldElement) y, zs);
  }

  public override ECPoint Twice()
  {
    if (this.IsInfinity)
      return (ECPoint) this;
    ECCurve curve = this.Curve;
    SecP192R1FieldElement rawYcoord = (SecP192R1FieldElement) this.RawYCoord;
    if (rawYcoord.IsZero)
      return curve.Infinity;
    SecP192R1FieldElement rawXcoord = (SecP192R1FieldElement) this.RawXCoord;
    SecP192R1FieldElement rawZcoord = (SecP192R1FieldElement) this.RawZCoords[0];
    uint[] numArray1 = Nat192.Create();
    uint[] numArray2 = Nat192.Create();
    uint[] numArray3 = Nat192.Create();
    SecP192R1Field.Square(rawYcoord.x, numArray3);
    uint[] numArray4 = Nat192.Create();
    SecP192R1Field.Square(numArray3, numArray4);
    int num = rawZcoord.IsOne ? 1 : 0;
    uint[] numArray5 = rawZcoord.x;
    if (num == 0)
    {
      numArray5 = numArray2;
      SecP192R1Field.Square(rawZcoord.x, numArray5);
    }
    SecP192R1Field.Subtract(rawXcoord.x, numArray5, numArray1);
    uint[] numArray6 = numArray2;
    SecP192R1Field.Add(rawXcoord.x, numArray5, numArray6);
    SecP192R1Field.Multiply(numArray6, numArray1, numArray6);
    SecP192R1Field.Reduce32(Nat192.AddBothTo(numArray6, numArray6, numArray6), numArray6);
    uint[] numArray7 = numArray3;
    SecP192R1Field.Multiply(numArray3, rawXcoord.x, numArray7);
    SecP192R1Field.Reduce32(Nat.ShiftUpBits(6, numArray7, 2, 0U), numArray7);
    SecP192R1Field.Reduce32(Nat.ShiftUpBits(6, numArray4, 3, 0U, numArray1), numArray1);
    SecP192R1FieldElement x = new SecP192R1FieldElement(numArray4);
    SecP192R1Field.Square(numArray6, x.x);
    SecP192R1Field.Subtract(x.x, numArray7, x.x);
    SecP192R1Field.Subtract(x.x, numArray7, x.x);
    SecP192R1FieldElement y = new SecP192R1FieldElement(numArray7);
    SecP192R1Field.Subtract(numArray7, x.x, y.x);
    SecP192R1Field.Multiply(y.x, numArray6, y.x);
    SecP192R1Field.Subtract(y.x, numArray1, y.x);
    SecP192R1FieldElement p192R1FieldElement = new SecP192R1FieldElement(numArray6);
    SecP192R1Field.Twice(rawYcoord.x, p192R1FieldElement.x);
    if (num == 0)
      SecP192R1Field.Multiply(p192R1FieldElement.x, rawZcoord.x, p192R1FieldElement.x);
    return (ECPoint) new SecP192R1Point(curve, (ECFieldElement) x, (ECFieldElement) y, new ECFieldElement[1]
    {
      (ECFieldElement) p192R1FieldElement
    });
  }

  public override ECPoint TwicePlus(ECPoint b)
  {
    if (this == b)
      return this.ThreeTimes();
    if (this.IsInfinity)
      return b;
    if (b.IsInfinity)
      return this.Twice();
    return this.RawYCoord.IsZero ? b : this.Twice().Add(b);
  }

  public override ECPoint ThreeTimes()
  {
    return !this.IsInfinity && !this.RawYCoord.IsZero ? this.Twice().Add((ECPoint) this) : (ECPoint) this;
  }

  public override ECPoint Negate()
  {
    return this.IsInfinity ? (ECPoint) this : (ECPoint) new SecP192R1Point(this.Curve, this.RawXCoord, this.RawYCoord.Negate(), this.RawZCoords);
  }
}
