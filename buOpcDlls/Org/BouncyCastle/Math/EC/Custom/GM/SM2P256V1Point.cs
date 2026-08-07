// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Math.EC.Custom.GM.SM2P256V1Point
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Math.Raw;

#nullable disable
namespace Org.BouncyCastle.Math.EC.Custom.GM;

internal class SM2P256V1Point : AbstractFpPoint
{
  internal SM2P256V1Point(ECCurve curve, ECFieldElement x, ECFieldElement y)
    : base(curve, x, y)
  {
  }

  internal SM2P256V1Point(ECCurve curve, ECFieldElement x, ECFieldElement y, ECFieldElement[] zs)
    : base(curve, x, y, zs)
  {
  }

  protected override ECPoint Detach()
  {
    return (ECPoint) new SM2P256V1Point((ECCurve) null, this.AffineXCoord, this.AffineYCoord);
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
    SM2P256V1FieldElement rawXcoord1 = (SM2P256V1FieldElement) this.RawXCoord;
    SM2P256V1FieldElement rawYcoord1 = (SM2P256V1FieldElement) this.RawYCoord;
    SM2P256V1FieldElement rawXcoord2 = (SM2P256V1FieldElement) b.RawXCoord;
    SM2P256V1FieldElement rawYcoord2 = (SM2P256V1FieldElement) b.RawYCoord;
    SM2P256V1FieldElement rawZcoord1 = (SM2P256V1FieldElement) this.RawZCoords[0];
    SM2P256V1FieldElement rawZcoord2 = (SM2P256V1FieldElement) b.RawZCoords[0];
    uint[] ext = Nat256.CreateExt();
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
      SM2P256V1Field.Square(rawZcoord1.x, numArray4);
      numArray3 = numArray1;
      SM2P256V1Field.Multiply(numArray4, rawXcoord2.x, numArray3);
      SM2P256V1Field.Multiply(numArray4, rawZcoord1.x, numArray4);
      SM2P256V1Field.Multiply(numArray4, rawYcoord2.x, numArray4);
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
      SM2P256V1Field.Square(rawZcoord2.x, numArray6);
      numArray5 = ext;
      SM2P256V1Field.Multiply(numArray6, rawXcoord1.x, numArray5);
      SM2P256V1Field.Multiply(numArray6, rawZcoord2.x, numArray6);
      SM2P256V1Field.Multiply(numArray6, rawYcoord1.x, numArray6);
    }
    uint[] numArray7 = Nat256.Create();
    SM2P256V1Field.Subtract(numArray5, numArray3, numArray7);
    uint[] numArray8 = numArray1;
    SM2P256V1Field.Subtract(numArray6, numArray4, numArray8);
    if (Nat256.IsZero(numArray7))
      return Nat256.IsZero(numArray8) ? this.Twice() : curve.Infinity;
    uint[] numArray9 = numArray2;
    SM2P256V1Field.Square(numArray7, numArray9);
    uint[] numArray10 = Nat256.Create();
    SM2P256V1Field.Multiply(numArray9, numArray7, numArray10);
    uint[] numArray11 = numArray2;
    SM2P256V1Field.Multiply(numArray9, numArray5, numArray11);
    SM2P256V1Field.Negate(numArray10, numArray10);
    Nat256.Mul(numArray6, numArray10, ext);
    SM2P256V1Field.Reduce32(Nat256.AddBothTo(numArray11, numArray11, numArray10), numArray10);
    SM2P256V1FieldElement x2 = new SM2P256V1FieldElement(x1);
    SM2P256V1Field.Square(numArray8, x2.x);
    SM2P256V1Field.Subtract(x2.x, numArray10, x2.x);
    SM2P256V1FieldElement y = new SM2P256V1FieldElement(numArray10);
    SM2P256V1Field.Subtract(numArray11, x2.x, y.x);
    SM2P256V1Field.MultiplyAddToExt(y.x, numArray8, ext);
    SM2P256V1Field.Reduce(ext, y.x);
    SM2P256V1FieldElement p256V1FieldElement = new SM2P256V1FieldElement(numArray7);
    if (!isOne1)
      SM2P256V1Field.Multiply(p256V1FieldElement.x, rawZcoord1.x, p256V1FieldElement.x);
    if (!isOne2)
      SM2P256V1Field.Multiply(p256V1FieldElement.x, rawZcoord2.x, p256V1FieldElement.x);
    ECFieldElement[] zs = new ECFieldElement[1]
    {
      (ECFieldElement) p256V1FieldElement
    };
    return (ECPoint) new SM2P256V1Point(curve, (ECFieldElement) x2, (ECFieldElement) y, zs);
  }

  public override ECPoint Twice()
  {
    if (this.IsInfinity)
      return (ECPoint) this;
    ECCurve curve = this.Curve;
    SM2P256V1FieldElement rawYcoord = (SM2P256V1FieldElement) this.RawYCoord;
    if (rawYcoord.IsZero)
      return curve.Infinity;
    SM2P256V1FieldElement rawXcoord = (SM2P256V1FieldElement) this.RawXCoord;
    SM2P256V1FieldElement rawZcoord = (SM2P256V1FieldElement) this.RawZCoords[0];
    uint[] numArray1 = Nat256.Create();
    uint[] numArray2 = Nat256.Create();
    uint[] numArray3 = Nat256.Create();
    SM2P256V1Field.Square(rawYcoord.x, numArray3);
    uint[] numArray4 = Nat256.Create();
    SM2P256V1Field.Square(numArray3, numArray4);
    int num = rawZcoord.IsOne ? 1 : 0;
    uint[] numArray5 = rawZcoord.x;
    if (num == 0)
    {
      numArray5 = numArray2;
      SM2P256V1Field.Square(rawZcoord.x, numArray5);
    }
    SM2P256V1Field.Subtract(rawXcoord.x, numArray5, numArray1);
    uint[] numArray6 = numArray2;
    SM2P256V1Field.Add(rawXcoord.x, numArray5, numArray6);
    SM2P256V1Field.Multiply(numArray6, numArray1, numArray6);
    SM2P256V1Field.Reduce32(Nat256.AddBothTo(numArray6, numArray6, numArray6), numArray6);
    uint[] numArray7 = numArray3;
    SM2P256V1Field.Multiply(numArray3, rawXcoord.x, numArray7);
    SM2P256V1Field.Reduce32(Nat.ShiftUpBits(8, numArray7, 2, 0U), numArray7);
    SM2P256V1Field.Reduce32(Nat.ShiftUpBits(8, numArray4, 3, 0U, numArray1), numArray1);
    SM2P256V1FieldElement x = new SM2P256V1FieldElement(numArray4);
    SM2P256V1Field.Square(numArray6, x.x);
    SM2P256V1Field.Subtract(x.x, numArray7, x.x);
    SM2P256V1Field.Subtract(x.x, numArray7, x.x);
    SM2P256V1FieldElement y = new SM2P256V1FieldElement(numArray7);
    SM2P256V1Field.Subtract(numArray7, x.x, y.x);
    SM2P256V1Field.Multiply(y.x, numArray6, y.x);
    SM2P256V1Field.Subtract(y.x, numArray1, y.x);
    SM2P256V1FieldElement p256V1FieldElement = new SM2P256V1FieldElement(numArray6);
    SM2P256V1Field.Twice(rawYcoord.x, p256V1FieldElement.x);
    if (num == 0)
      SM2P256V1Field.Multiply(p256V1FieldElement.x, rawZcoord.x, p256V1FieldElement.x);
    return (ECPoint) new SM2P256V1Point(curve, (ECFieldElement) x, (ECFieldElement) y, new ECFieldElement[1]
    {
      (ECFieldElement) p256V1FieldElement
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
    return this.IsInfinity ? (ECPoint) this : (ECPoint) new SM2P256V1Point(this.Curve, this.RawXCoord, this.RawYCoord.Negate(), this.RawZCoords);
  }
}
