// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Math.EC.Custom.Sec.SecP256K1Point
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Math.Raw;

#nullable disable
namespace Org.BouncyCastle.Math.EC.Custom.Sec;

internal class SecP256K1Point : AbstractFpPoint
{
  internal SecP256K1Point(ECCurve curve, ECFieldElement x, ECFieldElement y)
    : base(curve, x, y)
  {
  }

  internal SecP256K1Point(ECCurve curve, ECFieldElement x, ECFieldElement y, ECFieldElement[] zs)
    : base(curve, x, y, zs)
  {
  }

  protected override ECPoint Detach()
  {
    return (ECPoint) new SecP256K1Point((ECCurve) null, this.AffineXCoord, this.AffineYCoord);
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
    SecP256K1FieldElement rawXcoord1 = (SecP256K1FieldElement) this.RawXCoord;
    SecP256K1FieldElement rawYcoord1 = (SecP256K1FieldElement) this.RawYCoord;
    SecP256K1FieldElement rawXcoord2 = (SecP256K1FieldElement) b.RawXCoord;
    SecP256K1FieldElement rawYcoord2 = (SecP256K1FieldElement) b.RawYCoord;
    SecP256K1FieldElement rawZcoord1 = (SecP256K1FieldElement) this.RawZCoords[0];
    SecP256K1FieldElement rawZcoord2 = (SecP256K1FieldElement) b.RawZCoords[0];
    uint[] ext1 = Nat256.CreateExt();
    uint[] ext2 = Nat256.CreateExt();
    uint[] numArray1 = Nat256.Create();
    uint[] numArray2 = Nat256.Create();
    uint[] x1 = Nat256.Create();
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
      SecP256K1Field.Square(rawZcoord1.x, numArray4, ext1);
      numArray3 = numArray1;
      SecP256K1Field.Multiply(numArray4, rawXcoord2.x, numArray3, ext1);
      SecP256K1Field.Multiply(numArray4, rawZcoord1.x, numArray4, ext1);
      SecP256K1Field.Multiply(numArray4, rawYcoord2.x, numArray4, ext1);
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
      SecP256K1Field.Square(rawZcoord2.x, numArray6, ext1);
      numArray5 = ext2;
      SecP256K1Field.Multiply(numArray6, rawXcoord1.x, numArray5, ext1);
      SecP256K1Field.Multiply(numArray6, rawZcoord2.x, numArray6, ext1);
      SecP256K1Field.Multiply(numArray6, rawYcoord1.x, numArray6, ext1);
    }
    uint[] numArray7 = Nat256.Create();
    SecP256K1Field.Subtract(numArray5, numArray3, numArray7);
    uint[] numArray8 = numArray1;
    SecP256K1Field.Subtract(numArray6, numArray4, numArray8);
    if (Nat256.IsZero(numArray7))
      return Nat256.IsZero(numArray8) ? this.Twice() : curve.Infinity;
    uint[] numArray9 = numArray2;
    SecP256K1Field.Square(numArray7, numArray9, ext1);
    uint[] numArray10 = Nat256.Create();
    SecP256K1Field.Multiply(numArray9, numArray7, numArray10, ext1);
    uint[] numArray11 = numArray2;
    SecP256K1Field.Multiply(numArray9, numArray5, numArray11, ext1);
    SecP256K1Field.Negate(numArray10, numArray10);
    Nat256.Mul(numArray6, numArray10, ext2);
    SecP256K1Field.Reduce32(Nat256.AddBothTo(numArray11, numArray11, numArray10), numArray10);
    SecP256K1FieldElement x2 = new SecP256K1FieldElement(x1);
    SecP256K1Field.Square(numArray8, x2.x, ext1);
    SecP256K1Field.Subtract(x2.x, numArray10, x2.x);
    SecP256K1FieldElement y = new SecP256K1FieldElement(numArray10);
    SecP256K1Field.Subtract(numArray11, x2.x, y.x);
    SecP256K1Field.MultiplyAddToExt(y.x, numArray8, ext2);
    SecP256K1Field.Reduce(ext2, y.x);
    SecP256K1FieldElement p256K1FieldElement = new SecP256K1FieldElement(numArray7);
    if (!isOne1)
      SecP256K1Field.Multiply(p256K1FieldElement.x, rawZcoord1.x, p256K1FieldElement.x, ext1);
    if (!isOne2)
      SecP256K1Field.Multiply(p256K1FieldElement.x, rawZcoord2.x, p256K1FieldElement.x, ext1);
    ECFieldElement[] zs = new ECFieldElement[1]
    {
      (ECFieldElement) p256K1FieldElement
    };
    return (ECPoint) new SecP256K1Point(curve, (ECFieldElement) x2, (ECFieldElement) y, zs);
  }

  public override ECPoint Twice()
  {
    if (this.IsInfinity)
      return (ECPoint) this;
    ECCurve curve = this.Curve;
    SecP256K1FieldElement rawYcoord = (SecP256K1FieldElement) this.RawYCoord;
    if (rawYcoord.IsZero)
      return curve.Infinity;
    SecP256K1FieldElement rawXcoord = (SecP256K1FieldElement) this.RawXCoord;
    SecP256K1FieldElement rawZcoord = (SecP256K1FieldElement) this.RawZCoords[0];
    uint[] ext = Nat256.CreateExt();
    uint[] numArray1 = Nat256.Create();
    SecP256K1Field.Square(rawYcoord.x, numArray1, ext);
    uint[] numArray2 = Nat256.Create();
    SecP256K1Field.Square(numArray1, numArray2, ext);
    uint[] numArray3 = Nat256.Create();
    SecP256K1Field.Square(rawXcoord.x, numArray3, ext);
    SecP256K1Field.Reduce32(Nat256.AddBothTo(numArray3, numArray3, numArray3), numArray3);
    uint[] numArray4 = numArray1;
    SecP256K1Field.Multiply(numArray1, rawXcoord.x, numArray4, ext);
    SecP256K1Field.Reduce32(Nat.ShiftUpBits(8, numArray4, 2, 0U), numArray4);
    uint[] numArray5 = Nat256.Create();
    SecP256K1Field.Reduce32(Nat.ShiftUpBits(8, numArray2, 3, 0U, numArray5), numArray5);
    SecP256K1FieldElement x = new SecP256K1FieldElement(numArray2);
    SecP256K1Field.Square(numArray3, x.x, ext);
    SecP256K1Field.Subtract(x.x, numArray4, x.x);
    SecP256K1Field.Subtract(x.x, numArray4, x.x);
    SecP256K1FieldElement y = new SecP256K1FieldElement(numArray4);
    SecP256K1Field.Subtract(numArray4, x.x, y.x);
    SecP256K1Field.Multiply(y.x, numArray3, y.x, ext);
    SecP256K1Field.Subtract(y.x, numArray5, y.x);
    SecP256K1FieldElement p256K1FieldElement = new SecP256K1FieldElement(numArray3);
    SecP256K1Field.Twice(rawYcoord.x, p256K1FieldElement.x);
    if (!rawZcoord.IsOne)
      SecP256K1Field.Multiply(p256K1FieldElement.x, rawZcoord.x, p256K1FieldElement.x, ext);
    return (ECPoint) new SecP256K1Point(curve, (ECFieldElement) x, (ECFieldElement) y, new ECFieldElement[1]
    {
      (ECFieldElement) p256K1FieldElement
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
    return this.IsInfinity ? (ECPoint) this : (ECPoint) new SecP256K1Point(this.Curve, this.RawXCoord, this.RawYCoord.Negate(), this.RawZCoords);
  }
}
