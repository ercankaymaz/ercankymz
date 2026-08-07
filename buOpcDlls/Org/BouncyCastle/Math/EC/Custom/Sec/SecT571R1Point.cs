// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Math.EC.Custom.Sec.SecT571R1Point
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Math.Raw;

#nullable disable
namespace Org.BouncyCastle.Math.EC.Custom.Sec;

internal class SecT571R1Point : AbstractF2mPoint
{
  internal SecT571R1Point(ECCurve curve, ECFieldElement x, ECFieldElement y)
    : base(curve, x, y)
  {
  }

  internal SecT571R1Point(ECCurve curve, ECFieldElement x, ECFieldElement y, ECFieldElement[] zs)
    : base(curve, x, y, zs)
  {
  }

  protected override ECPoint Detach()
  {
    return (ECPoint) new SecT571R1Point((ECCurve) null, this.AffineXCoord, this.AffineYCoord);
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
    SecT571FieldElement rawXcoord1 = (SecT571FieldElement) this.RawXCoord;
    SecT571FieldElement rawXcoord2 = (SecT571FieldElement) b.RawXCoord;
    if (rawXcoord1.IsZero)
      return rawXcoord2.IsZero ? curve.Infinity : b.Add((ECPoint) this);
    SecT571FieldElement rawYcoord1 = (SecT571FieldElement) this.RawYCoord;
    SecT571FieldElement rawZcoord1 = (SecT571FieldElement) this.RawZCoords[0];
    SecT571FieldElement rawYcoord2 = (SecT571FieldElement) b.RawYCoord;
    SecT571FieldElement rawZcoord2 = (SecT571FieldElement) b.RawZCoords[0];
    ulong[] x1 = Nat576.Create64();
    ulong[] numArray1 = Nat576.Create64();
    ulong[] x2 = Nat576.Create64();
    ulong[] numArray2 = Nat576.Create64();
    ulong[] precomp1 = rawZcoord1.IsOne ? (ulong[]) null : SecT571Field.PrecompMultiplicand(rawZcoord1.x);
    ulong[] numArray3;
    ulong[] y1;
    if (precomp1 == null)
    {
      numArray3 = rawXcoord2.x;
      y1 = rawYcoord2.x;
    }
    else
    {
      SecT571Field.MultiplyPrecomp(rawXcoord2.x, precomp1, numArray3 = numArray1);
      SecT571Field.MultiplyPrecomp(rawYcoord2.x, precomp1, y1 = numArray2);
    }
    ulong[] precomp2 = rawZcoord2.IsOne ? (ulong[]) null : SecT571Field.PrecompMultiplicand(rawZcoord2.x);
    ulong[] x3;
    ulong[] x4;
    if (precomp2 == null)
    {
      x3 = rawXcoord1.x;
      x4 = rawYcoord1.x;
    }
    else
    {
      SecT571Field.MultiplyPrecomp(rawXcoord1.x, precomp2, x3 = x1);
      SecT571Field.MultiplyPrecomp(rawYcoord1.x, precomp2, x4 = x2);
    }
    ulong[] numArray4 = x2;
    SecT571Field.Add(x4, y1, numArray4);
    ulong[] numArray5 = numArray2;
    SecT571Field.Add(x3, numArray3, numArray5);
    if (Nat576.IsZero64(numArray5))
      return Nat576.IsZero64(numArray4) ? this.Twice() : curve.Infinity;
    SecT571FieldElement t571FieldElement1;
    SecT571FieldElement y2;
    SecT571FieldElement t571FieldElement2;
    if (rawXcoord2.IsZero)
    {
      ECPoint ecPoint = this.Normalize();
      SecT571FieldElement xcoord = (SecT571FieldElement) ecPoint.XCoord;
      ECFieldElement ycoord = ecPoint.YCoord;
      ECFieldElement b1 = (ECFieldElement) rawYcoord2;
      ECFieldElement b2 = ycoord.Add(b1).Divide((ECFieldElement) xcoord);
      t571FieldElement1 = (SecT571FieldElement) b2.Square().Add(b2).Add((ECFieldElement) xcoord).AddOne();
      if (t571FieldElement1.IsZero)
        return (ECPoint) new SecT571R1Point(curve, (ECFieldElement) t571FieldElement1, (ECFieldElement) SecT571R1Curve.SecT571R1_B_SQRT);
      y2 = (SecT571FieldElement) b2.Multiply(xcoord.Add((ECFieldElement) t571FieldElement1)).Add((ECFieldElement) t571FieldElement1).Add(ycoord).Divide((ECFieldElement) t571FieldElement1).Add((ECFieldElement) t571FieldElement1);
      t571FieldElement2 = (SecT571FieldElement) curve.FromBigInteger(BigInteger.One);
    }
    else
    {
      SecT571Field.Square(numArray5, numArray5);
      ulong[] precomp3 = SecT571Field.PrecompMultiplicand(numArray4);
      ulong[] numArray6 = x1;
      ulong[] numArray7 = numArray1;
      SecT571Field.MultiplyPrecomp(x3, precomp3, numArray6);
      SecT571Field.MultiplyPrecomp(numArray3, precomp3, numArray7);
      t571FieldElement1 = new SecT571FieldElement(x1);
      SecT571Field.Multiply(numArray6, numArray7, t571FieldElement1.x);
      if (t571FieldElement1.IsZero)
        return (ECPoint) new SecT571R1Point(curve, (ECFieldElement) t571FieldElement1, (ECFieldElement) SecT571R1Curve.SecT571R1_B_SQRT);
      t571FieldElement2 = new SecT571FieldElement(x2);
      SecT571Field.MultiplyPrecomp(numArray5, precomp3, t571FieldElement2.x);
      if (precomp2 != null)
        SecT571Field.MultiplyPrecomp(t571FieldElement2.x, precomp2, t571FieldElement2.x);
      ulong[] ext64 = Nat576.CreateExt64();
      SecT571Field.Add(numArray7, numArray5, numArray2);
      SecT571Field.SquareExt(numArray2, ext64);
      SecT571Field.Add(rawYcoord1.x, rawZcoord1.x, numArray2);
      SecT571Field.MultiplyAddToExt(numArray2, t571FieldElement2.x, ext64);
      y2 = new SecT571FieldElement(numArray2);
      SecT571Field.Reduce(ext64, y2.x);
      if (precomp1 != null)
        SecT571Field.MultiplyPrecomp(t571FieldElement2.x, precomp1, t571FieldElement2.x);
    }
    return (ECPoint) new SecT571R1Point(curve, (ECFieldElement) t571FieldElement1, (ECFieldElement) y2, new ECFieldElement[1]
    {
      (ECFieldElement) t571FieldElement2
    });
  }

  public override ECPoint Twice()
  {
    if (this.IsInfinity)
      return (ECPoint) this;
    ECCurve curve = this.Curve;
    SecT571FieldElement rawXcoord = (SecT571FieldElement) this.RawXCoord;
    if (rawXcoord.IsZero)
      return curve.Infinity;
    SecT571FieldElement rawYcoord = (SecT571FieldElement) this.RawYCoord;
    SecT571FieldElement rawZcoord = (SecT571FieldElement) this.RawZCoords[0];
    ulong[] x1 = Nat576.Create64();
    ulong[] numArray1 = Nat576.Create64();
    ulong[] precomp = rawZcoord.IsOne ? (ulong[]) null : SecT571Field.PrecompMultiplicand(rawZcoord.x);
    ulong[] numArray2;
    ulong[] y1;
    if (precomp == null)
    {
      numArray2 = rawYcoord.x;
      y1 = rawZcoord.x;
    }
    else
    {
      SecT571Field.MultiplyPrecomp(rawYcoord.x, precomp, numArray2 = x1);
      SecT571Field.Square(rawZcoord.x, y1 = numArray1);
    }
    ulong[] numArray3 = Nat576.Create64();
    SecT571Field.Square(rawYcoord.x, numArray3);
    SecT571Field.AddBothTo(numArray2, y1, numArray3);
    if (Nat576.IsZero64(numArray3))
      return (ECPoint) new SecT571R1Point(curve, (ECFieldElement) new SecT571FieldElement(numArray3), (ECFieldElement) SecT571R1Curve.SecT571R1_B_SQRT);
    ulong[] ext64 = Nat576.CreateExt64();
    SecT571Field.MultiplyAddToExt(numArray3, numArray2, ext64);
    SecT571FieldElement x2 = new SecT571FieldElement(x1);
    SecT571Field.Square(numArray3, x2.x);
    SecT571FieldElement t571FieldElement = new SecT571FieldElement(numArray3);
    if (precomp != null)
      SecT571Field.Multiply(t571FieldElement.x, y1, t571FieldElement.x);
    ulong[] x3;
    if (precomp == null)
      x3 = rawXcoord.x;
    else
      SecT571Field.MultiplyPrecomp(rawXcoord.x, precomp, x3 = numArray1);
    SecT571Field.SquareAddToExt(x3, ext64);
    SecT571Field.Reduce(ext64, numArray1);
    SecT571Field.AddBothTo(x2.x, t571FieldElement.x, numArray1);
    SecT571FieldElement y2 = new SecT571FieldElement(numArray1);
    return (ECPoint) new SecT571R1Point(curve, (ECFieldElement) x2, (ECFieldElement) y2, new ECFieldElement[1]
    {
      (ECFieldElement) t571FieldElement
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
    ECFieldElement b3 = ecFieldElement.Add(b1).Add(b2);
    ECFieldElement x2 = rawYcoord2.Multiply(ecFieldElement).Add(b1).MultiplyPlusProduct(b3, x1, ecFieldElement);
    ECFieldElement b4 = rawXcoord2.Multiply(ecFieldElement);
    ECFieldElement b5 = b4.Add(b3).Square();
    if (b5.IsZero)
      return x2.IsZero ? b.Twice() : curve.Infinity;
    if (x2.IsZero)
      return (ECPoint) new SecT571R1Point(curve, x2, (ECFieldElement) SecT571R1Curve.SecT571R1_B_SQRT);
    ECFieldElement x3 = x2.Square().Multiply(b4);
    ECFieldElement y1 = x2.Multiply(b5).Multiply(ecFieldElement);
    ECFieldElement y2 = x2.Add(b5).Square().MultiplyPlusProduct(b3, rawYcoord2.AddOne(), y1);
    return (ECPoint) new SecT571R1Point(curve, x3, y2, new ECFieldElement[1]
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
    return (ECPoint) new SecT571R1Point(this.Curve, rawXcoord, rawYcoord.Add(rawZcoord), new ECFieldElement[1]
    {
      rawZcoord
    });
  }
}
