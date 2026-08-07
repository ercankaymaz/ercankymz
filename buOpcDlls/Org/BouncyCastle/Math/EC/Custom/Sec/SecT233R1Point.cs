// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Math.EC.Custom.Sec.SecT233R1Point
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Math.Raw;

#nullable disable
namespace Org.BouncyCastle.Math.EC.Custom.Sec;

internal class SecT233R1Point : AbstractF2mPoint
{
  internal SecT233R1Point(ECCurve curve, ECFieldElement x, ECFieldElement y)
    : base(curve, x, y)
  {
  }

  internal SecT233R1Point(ECCurve curve, ECFieldElement x, ECFieldElement y, ECFieldElement[] zs)
    : base(curve, x, y, zs)
  {
  }

  protected override ECPoint Detach()
  {
    return (ECPoint) new SecT233R1Point((ECCurve) null, this.AffineXCoord, this.AffineYCoord);
  }

  public override ECFieldElement YCoord
  {
    get
    {
      ECFieldElement rawXcoord = this.RawXCoord;
      ECFieldElement rawYcoord = this.RawYCoord;
      if (this.IsInfinity || rawXcoord.IsZero)
        return rawYcoord;
      ECFieldElement ycoord = rawYcoord.Add(rawXcoord).Multiply(rawXcoord);
      ECFieldElement rawZcoord = this.RawZCoords[0];
      if (!rawZcoord.IsOne)
        ycoord = ycoord.Divide(rawZcoord);
      return ycoord;
    }
  }

  protected internal override bool CompressionYTilde
  {
    get
    {
      ECFieldElement rawXcoord = this.RawXCoord;
      return !rawXcoord.IsZero && this.RawYCoord.TestBitZero() != rawXcoord.TestBitZero();
    }
  }

  public override ECPoint Add(ECPoint b)
  {
    if (this.IsInfinity)
      return b;
    if (b.IsInfinity)
      return (ECPoint) this;
    ECCurve curve = this.Curve;
    ECFieldElement rawXcoord1 = this.RawXCoord;
    ECFieldElement rawXcoord2 = b.RawXCoord;
    if (rawXcoord1.IsZero)
      return rawXcoord2.IsZero ? curve.Infinity : b.Add((ECPoint) this);
    ECFieldElement rawYcoord1 = this.RawYCoord;
    ECFieldElement rawZcoord1 = this.RawZCoords[0];
    ECFieldElement rawYcoord2 = b.RawYCoord;
    ECFieldElement rawZcoord2 = b.RawZCoords[0];
    bool isOne1 = rawZcoord1.IsOne;
    ECFieldElement b1 = rawXcoord2;
    ECFieldElement b2 = rawYcoord2;
    if (!isOne1)
    {
      b1 = b1.Multiply(rawZcoord1);
      b2 = b2.Multiply(rawZcoord1);
    }
    bool isOne2 = rawZcoord2.IsOne;
    ECFieldElement b3 = rawXcoord1;
    ECFieldElement ecFieldElement1 = rawYcoord1;
    if (!isOne2)
    {
      b3 = b3.Multiply(rawZcoord2);
      ecFieldElement1 = ecFieldElement1.Multiply(rawZcoord2);
    }
    ECFieldElement ecFieldElement2 = ecFieldElement1.Add(b2);
    ECFieldElement ecFieldElement3 = b3.Add(b1);
    if (ecFieldElement3.IsZero)
      return ecFieldElement2.IsZero ? this.Twice() : curve.Infinity;
    ECFieldElement ecFieldElement4;
    ECFieldElement y;
    ECFieldElement ecFieldElement5;
    if (rawXcoord2.IsZero)
    {
      ECPoint ecPoint = this.Normalize();
      ECFieldElement xcoord = ecPoint.XCoord;
      ECFieldElement ycoord = ecPoint.YCoord;
      ECFieldElement b4 = rawYcoord2;
      ECFieldElement b5 = ycoord.Add(b4).Divide(xcoord);
      ecFieldElement4 = b5.Square().Add(b5).Add(xcoord).AddOne();
      if (ecFieldElement4.IsZero)
        return (ECPoint) new SecT233R1Point(curve, ecFieldElement4, curve.B.Sqrt());
      y = b5.Multiply(xcoord.Add(ecFieldElement4)).Add(ecFieldElement4).Add(ycoord).Divide(ecFieldElement4).Add(ecFieldElement4);
      ecFieldElement5 = curve.FromBigInteger(BigInteger.One);
    }
    else
    {
      ECFieldElement b6 = ecFieldElement3.Square();
      ECFieldElement ecFieldElement6 = ecFieldElement2.Multiply(b3);
      ECFieldElement b7 = ecFieldElement2.Multiply(b1);
      ecFieldElement4 = ecFieldElement6.Multiply(b7);
      if (ecFieldElement4.IsZero)
        return (ECPoint) new SecT233R1Point(curve, ecFieldElement4, curve.B.Sqrt());
      ECFieldElement x = ecFieldElement2.Multiply(b6);
      if (!isOne2)
        x = x.Multiply(rawZcoord2);
      y = b7.Add(b6).SquarePlusProduct(x, rawYcoord1.Add(rawZcoord1));
      ecFieldElement5 = x;
      if (!isOne1)
        ecFieldElement5 = ecFieldElement5.Multiply(rawZcoord1);
    }
    return (ECPoint) new SecT233R1Point(curve, ecFieldElement4, y, new ECFieldElement[1]
    {
      ecFieldElement5
    });
  }

  public override ECPoint Twice()
  {
    if (this.IsInfinity)
      return (ECPoint) this;
    ECCurve curve = this.Curve;
    SecT233FieldElement rawXcoord = (SecT233FieldElement) this.RawXCoord;
    if (rawXcoord.IsZero)
      return curve.Infinity;
    SecT233FieldElement rawYcoord = (SecT233FieldElement) this.RawYCoord;
    SecT233FieldElement rawZcoord = (SecT233FieldElement) this.RawZCoords[0];
    ulong[] ext64 = Nat256.CreateExt64();
    ulong[] numArray1 = Nat256.Create64();
    ulong[] numArray2 = Nat256.Create64();
    ulong[] numArray3 = Nat256.Create64();
    if (rawZcoord.IsOne)
    {
      SecT233Field.Square(rawYcoord.x, numArray3);
      SecT233Field.AddBothTo(rawYcoord.x, rawZcoord.x, numArray3);
      if (Nat256.IsZero64(numArray3))
        return (ECPoint) new SecT233R1Point(curve, (ECFieldElement) new SecT233FieldElement(numArray3), curve.B.Sqrt());
      SecT233Field.Square(numArray3, numArray1);
      SecT233Field.SquareExt(rawXcoord.x, ext64);
      SecT233Field.MultiplyAddToExt(numArray3, rawYcoord.x, ext64);
    }
    else
    {
      ulong[] numArray4 = Nat256.Create64();
      SecT233Field.Multiply(rawYcoord.x, rawZcoord.x, numArray4);
      SecT233Field.Square(rawZcoord.x, ext64);
      SecT233Field.Square(rawYcoord.x, numArray1);
      SecT233Field.AddBothTo(numArray4, ext64, numArray1);
      if (Nat256.IsZero64(numArray1))
        return (ECPoint) new SecT233R1Point(curve, (ECFieldElement) new SecT233FieldElement(numArray1), curve.B.Sqrt());
      SecT233Field.Multiply(numArray1, ext64, numArray3);
      SecT233Field.Multiply(rawXcoord.x, rawZcoord.x, ext64);
      SecT233Field.SquareExt(ext64, ext64);
      SecT233Field.MultiplyAddToExt(numArray1, numArray4, ext64);
      SecT233Field.Square(numArray1, numArray1);
    }
    SecT233Field.Reduce(ext64, numArray2);
    SecT233Field.AddBothTo(numArray1, numArray3, numArray2);
    return (ECPoint) new SecT233R1Point(curve, (ECFieldElement) new SecT233FieldElement(numArray1), (ECFieldElement) new SecT233FieldElement(numArray2), new ECFieldElement[1]
    {
      (ECFieldElement) new SecT233FieldElement(numArray3)
    });
  }

  public override ECPoint TwicePlus(ECPoint b)
  {
    if (this.IsInfinity)
      return b;
    if (b.IsInfinity)
      return this.Twice();
    ECCurve curve = this.Curve;
    SecT233FieldElement rawXcoord1 = (SecT233FieldElement) this.RawXCoord;
    if (rawXcoord1.IsZero)
      return b;
    SecT233FieldElement rawXcoord2 = (SecT233FieldElement) b.RawXCoord;
    SecT233FieldElement rawZcoord1 = (SecT233FieldElement) b.RawZCoords[0];
    if (rawXcoord2.IsZero || !rawZcoord1.IsOne)
      return this.Twice().Add(b);
    SecT233FieldElement rawYcoord1 = (SecT233FieldElement) this.RawYCoord;
    SecT233FieldElement rawZcoord2 = (SecT233FieldElement) this.RawZCoords[0];
    SecT233FieldElement rawYcoord2 = (SecT233FieldElement) b.RawYCoord;
    ulong[] ext64 = Nat256.CreateExt64();
    ulong[] numArray1 = Nat256.Create64();
    ulong[] numArray2 = Nat256.Create64();
    ulong[] numArray3 = Nat256.Create64();
    ulong[] numArray4 = Nat256.Create64();
    ulong[] numArray5 = Nat256.Create64();
    SecT233Field.Square(rawXcoord1.x, numArray1);
    SecT233Field.Square(rawYcoord1.x, numArray2);
    SecT233Field.Square(rawZcoord2.x, numArray3);
    SecT233Field.Multiply(rawYcoord1.x, rawZcoord2.x, numArray4);
    SecT233Field.AddBothTo(numArray2, numArray3, numArray4);
    SecT233Field.MultiplyExt(numArray1, numArray3, ext64);
    SecT233Field.Multiply(rawYcoord2.x, numArray3, numArray1);
    SecT233Field.AddTo(numArray2, numArray1);
    SecT233Field.MultiplyAddToExt(numArray4, numArray1, ext64);
    SecT233Field.Reduce(ext64, numArray1);
    SecT233Field.Multiply(rawXcoord2.x, numArray3, numArray2);
    SecT233Field.Add(numArray4, numArray2, numArray5);
    SecT233Field.Square(numArray5, numArray5);
    if (Nat256.IsZero64(numArray5))
      return Nat256.IsZero64(numArray1) ? b.Twice() : curve.Infinity;
    if (Nat256.IsZero64(numArray1))
      return (ECPoint) new SecT233R1Point(curve, (ECFieldElement) new SecT233FieldElement(numArray1), curve.B.Sqrt());
    ulong[] numArray6 = numArray2;
    SecT233Field.Square(numArray1, ext64);
    SecT233Field.Multiply(numArray6, ext64, numArray6);
    ulong[] numArray7 = numArray3;
    SecT233Field.Multiply(numArray7, numArray1, numArray7);
    SecT233Field.Multiply(numArray7, numArray5, numArray7);
    ulong[] numArray8 = numArray1;
    SecT233Field.AddTo(numArray5, numArray8);
    SecT233Field.Square(numArray8, numArray8);
    SecT233Field.MultiplyExt(numArray8, numArray4, ext64);
    SecT233Field.MultiplyAddToExt(rawYcoord2.x, numArray7, ext64);
    SecT233Field.Reduce(ext64, numArray8);
    SecT233Field.AddTo(numArray7, numArray8);
    return (ECPoint) new SecT233R1Point(curve, (ECFieldElement) new SecT233FieldElement(numArray6), (ECFieldElement) new SecT233FieldElement(numArray8), new ECFieldElement[1]
    {
      (ECFieldElement) new SecT233FieldElement(numArray7)
    });
  }

  public override ECPoint Negate()
  {
    if (this.IsInfinity)
      return (ECPoint) this;
    ECFieldElement rawXcoord = this.RawXCoord;
    if (rawXcoord.IsZero)
      return (ECPoint) this;
    ECFieldElement rawYcoord = this.RawYCoord;
    ECFieldElement rawZcoord = this.RawZCoords[0];
    return (ECPoint) new SecT233R1Point(this.Curve, rawXcoord, rawYcoord.Add(rawZcoord), new ECFieldElement[1]
    {
      rawZcoord
    });
  }
}
