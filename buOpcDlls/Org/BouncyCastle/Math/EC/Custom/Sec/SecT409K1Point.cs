// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Math.EC.Custom.Sec.SecT409K1Point
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Math.Raw;

#nullable disable
namespace Org.BouncyCastle.Math.EC.Custom.Sec;

internal class SecT409K1Point : AbstractF2mPoint
{
  internal SecT409K1Point(ECCurve curve, ECFieldElement x, ECFieldElement y)
    : base(curve, x, y)
  {
  }

  internal SecT409K1Point(ECCurve curve, ECFieldElement x, ECFieldElement y, ECFieldElement[] zs)
    : base(curve, x, y, zs)
  {
  }

  protected override ECPoint Detach()
  {
    return (ECPoint) new SecT409K1Point((ECCurve) null, this.AffineXCoord, this.AffineYCoord);
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
    SecT409FieldElement rawXcoord1 = (SecT409FieldElement) this.RawXCoord;
    SecT409FieldElement rawXcoord2 = (SecT409FieldElement) b.RawXCoord;
    if (rawXcoord1.IsZero)
      return rawXcoord2.IsZero ? curve.Infinity : b.Add((ECPoint) this);
    SecT409FieldElement rawYcoord1 = (SecT409FieldElement) this.RawYCoord;
    SecT409FieldElement rawZcoord1 = (SecT409FieldElement) this.RawZCoords[0];
    SecT409FieldElement rawYcoord2 = (SecT409FieldElement) b.RawYCoord;
    SecT409FieldElement rawZcoord2 = (SecT409FieldElement) b.RawZCoords[0];
    ulong[] numArray1 = Nat.Create64(13);
    ulong[] numArray2 = Nat448.Create64();
    ulong[] numArray3 = Nat448.Create64();
    ulong[] numArray4 = Nat448.Create64();
    bool isOne1;
    if (isOne1 = rawZcoord1.IsOne)
    {
      Nat448.Copy64(rawXcoord2.x, numArray2);
      Nat448.Copy64(rawYcoord2.x, numArray3);
    }
    else
    {
      SecT409Field.Multiply(rawXcoord2.x, rawZcoord1.x, numArray2);
      SecT409Field.Multiply(rawYcoord2.x, rawZcoord1.x, numArray3);
    }
    bool isOne2;
    if (isOne2 = rawZcoord2.IsOne)
    {
      Nat448.Copy64(rawXcoord1.x, numArray4);
      Nat448.Copy64(rawYcoord1.x, numArray1);
    }
    else
    {
      SecT409Field.Multiply(rawXcoord1.x, rawZcoord2.x, numArray4);
      SecT409Field.Multiply(rawYcoord1.x, rawZcoord2.x, numArray1);
    }
    SecT409Field.AddTo(numArray1, numArray3);
    SecT409Field.Add(numArray4, numArray2, numArray1);
    if (Nat448.IsZero64(numArray1))
      return Nat448.IsZero64(numArray3) ? this.Twice() : curve.Infinity;
    if (rawXcoord2.IsZero)
    {
      ECPoint ecPoint = this.Normalize();
      SecT409FieldElement xcoord = (SecT409FieldElement) ecPoint.XCoord;
      ECFieldElement ycoord = ecPoint.YCoord;
      ECFieldElement b1 = (ECFieldElement) rawYcoord2;
      ECFieldElement b2 = ycoord.Add(b1).Divide((ECFieldElement) xcoord);
      ECFieldElement ecFieldElement1 = b2.Square().Add(b2).Add((ECFieldElement) xcoord);
      if (ecFieldElement1.IsZero)
        return (ECPoint) new SecT409K1Point(curve, ecFieldElement1, curve.B);
      ECFieldElement y = b2.Multiply(xcoord.Add(ecFieldElement1)).Add(ecFieldElement1).Add(ycoord).Divide(ecFieldElement1).Add(ecFieldElement1);
      ECFieldElement ecFieldElement2 = curve.FromBigInteger(BigInteger.One);
      return (ECPoint) new SecT409K1Point(curve, ecFieldElement1, y, new ECFieldElement[1]
      {
        ecFieldElement2
      });
    }
    SecT409Field.Square(numArray1, numArray1);
    SecT409Field.Multiply(numArray4, numArray3, numArray4);
    SecT409Field.Multiply(numArray2, numArray3, numArray2);
    ulong[] numArray5 = numArray4;
    SecT409Field.Multiply(numArray5, numArray2, numArray5);
    if (Nat448.IsZero64(numArray5))
      return (ECPoint) new SecT409K1Point(curve, (ECFieldElement) new SecT409FieldElement(numArray5), curve.B);
    ulong[] numArray6 = numArray3;
    SecT409Field.Multiply(numArray6, numArray1, numArray6);
    if (!isOne2)
      SecT409Field.Multiply(numArray6, rawZcoord2.x, numArray6);
    ulong[] numArray7 = numArray2;
    SecT409Field.AddTo(numArray1, numArray7);
    SecT409Field.SquareExt(numArray7, numArray1);
    SecT409Field.Add(rawYcoord1.x, rawZcoord1.x, numArray7);
    SecT409Field.MultiplyAddToExt(numArray6, numArray7, numArray1);
    SecT409Field.Reduce(numArray1, numArray7);
    if (!isOne1)
      SecT409Field.Multiply(numArray6, rawZcoord1.x, numArray6);
    return (ECPoint) new SecT409K1Point(curve, (ECFieldElement) new SecT409FieldElement(numArray5), (ECFieldElement) new SecT409FieldElement(numArray7), new ECFieldElement[1]
    {
      (ECFieldElement) new SecT409FieldElement(numArray6)
    });
  }

  public override ECPoint Twice()
  {
    if (this.IsInfinity)
      return (ECPoint) this;
    ECCurve curve = this.Curve;
    ECFieldElement rawXcoord = this.RawXCoord;
    if (rawXcoord.IsZero)
      return curve.Infinity;
    ECFieldElement rawYcoord = this.RawYCoord;
    ECFieldElement rawZcoord = this.RawZCoords[0];
    bool isOne;
    ECFieldElement b1 = (isOne = rawZcoord.IsOne) ? rawZcoord : rawZcoord.Square();
    ECFieldElement ecFieldElement1 = !isOne ? rawYcoord.Add(rawZcoord).Multiply(rawYcoord) : rawYcoord.Square().Add(rawYcoord);
    if (ecFieldElement1.IsZero)
      return (ECPoint) new SecT409K1Point(curve, ecFieldElement1, curve.B);
    ECFieldElement ecFieldElement2 = ecFieldElement1.Square();
    ECFieldElement b2 = isOne ? ecFieldElement1 : ecFieldElement1.Multiply(b1);
    ECFieldElement b3 = rawYcoord.Add(rawXcoord).Square();
    ECFieldElement b4 = isOne ? rawZcoord : b1.Square();
    ECFieldElement y = b3.Add(ecFieldElement1).Add(b1).Multiply(b3).Add(b4).Add(ecFieldElement2).Add(b2);
    return (ECPoint) new SecT409K1Point(curve, ecFieldElement2, y, new ECFieldElement[1]
    {
      b2
    });
  }

  public override ECPoint TwicePlus(ECPoint b)
  {
    if (this.IsInfinity)
      return b;
    if (b.IsInfinity)
      return this.Twice();
    ECCurve curve = this.Curve;
    ECFieldElement rawXcoord1 = this.RawXCoord;
    if (rawXcoord1.IsZero)
      return b;
    ECFieldElement rawXcoord2 = b.RawXCoord;
    ECFieldElement rawZcoord1 = b.RawZCoords[0];
    if (rawXcoord2.IsZero || !rawZcoord1.IsOne)
      return this.Twice().Add(b);
    ECFieldElement rawYcoord1 = this.RawYCoord;
    ECFieldElement rawZcoord2 = this.RawZCoords[0];
    ECFieldElement rawYcoord2 = b.RawYCoord;
    ECFieldElement x1 = rawXcoord1.Square();
    ECFieldElement b1 = rawYcoord1.Square();
    ECFieldElement ecFieldElement = rawZcoord2.Square();
    ECFieldElement b2 = rawYcoord1.Multiply(rawZcoord2);
    ECFieldElement b3 = b1.Add(b2);
    ECFieldElement x2 = rawYcoord2.AddOne();
    ECFieldElement x3 = x2.Multiply(ecFieldElement).Add(b1).MultiplyPlusProduct(b3, x1, ecFieldElement);
    ECFieldElement b4 = rawXcoord2.Multiply(ecFieldElement);
    ECFieldElement b5 = b4.Add(b3).Square();
    if (b5.IsZero)
      return x3.IsZero ? b.Twice() : curve.Infinity;
    if (x3.IsZero)
      return (ECPoint) new SecT409K1Point(curve, x3, curve.B);
    ECFieldElement x4 = x3.Square().Multiply(b4);
    ECFieldElement y1 = x3.Multiply(b5).Multiply(ecFieldElement);
    ECFieldElement y2 = x3.Add(b5).Square().MultiplyPlusProduct(b3, x2, y1);
    return (ECPoint) new SecT409K1Point(curve, x4, y2, new ECFieldElement[1]
    {
      y1
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
    return (ECPoint) new SecT409K1Point(this.Curve, rawXcoord, rawYcoord.Add(rawZcoord), new ECFieldElement[1]
    {
      rawZcoord
    });
  }
}
