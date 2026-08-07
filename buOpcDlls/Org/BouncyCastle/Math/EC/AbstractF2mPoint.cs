// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Math.EC.AbstractF2mPoint
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;

#nullable disable
namespace Org.BouncyCastle.Math.EC;

public abstract class AbstractF2mPoint : ECPointBase
{
  protected AbstractF2mPoint(ECCurve curve, ECFieldElement x, ECFieldElement y)
    : base(curve, x, y)
  {
  }

  protected AbstractF2mPoint(
    ECCurve curve,
    ECFieldElement x,
    ECFieldElement y,
    ECFieldElement[] zs)
    : base(curve, x, y, zs)
  {
  }

  protected override bool SatisfiesCurveEquation()
  {
    ECCurve curve = this.Curve;
    ECFieldElement rawXcoord = this.RawXCoord;
    ECFieldElement rawYcoord = this.RawYCoord;
    ECFieldElement ecFieldElement1 = curve.A;
    ECFieldElement ecFieldElement2 = curve.B;
    int coordinateSystem = curve.CoordinateSystem;
    ECFieldElement ecFieldElement3;
    ECFieldElement other;
    if (coordinateSystem == 6)
    {
      ECFieldElement rawZcoord = this.RawZCoords[0];
      bool isOne = rawZcoord.IsOne;
      if (rawXcoord.IsZero)
      {
        ecFieldElement3 = rawYcoord.Square();
        other = ecFieldElement2;
        if (!isOne)
        {
          ECFieldElement b = rawZcoord.Square();
          other = other.Multiply(b);
        }
      }
      else
      {
        ECFieldElement b1 = rawYcoord;
        ECFieldElement b2 = rawXcoord.Square();
        ECFieldElement ecFieldElement4;
        if (isOne)
        {
          ecFieldElement4 = b1.Square().Add(b1).Add(ecFieldElement1);
          other = b2.Square().Add(ecFieldElement2);
        }
        else
        {
          ECFieldElement y1 = rawZcoord.Square();
          ECFieldElement y2 = y1.Square();
          ecFieldElement4 = b1.Add(rawZcoord).MultiplyPlusProduct(b1, ecFieldElement1, y1);
          other = b2.SquarePlusProduct(ecFieldElement2, y2);
        }
        ecFieldElement3 = ecFieldElement4.Multiply(b2);
      }
    }
    else
    {
      ecFieldElement3 = rawYcoord.Add(rawXcoord).Multiply(rawYcoord);
      if (coordinateSystem != 0)
      {
        if (coordinateSystem != 1)
          throw new InvalidOperationException("unsupported coordinate system");
        ECFieldElement rawZcoord = this.RawZCoords[0];
        if (!rawZcoord.IsOne)
        {
          ECFieldElement b3 = rawZcoord.Square();
          ECFieldElement b4 = rawZcoord.Multiply(b3);
          ecFieldElement3 = ecFieldElement3.Multiply(rawZcoord);
          ecFieldElement1 = ecFieldElement1.Multiply(rawZcoord);
          ecFieldElement2 = ecFieldElement2.Multiply(b4);
        }
      }
      other = rawXcoord.Add(ecFieldElement1).Multiply(rawXcoord.Square()).Add(ecFieldElement2);
    }
    return ecFieldElement3.Equals(other);
  }

  protected override bool SatisfiesOrder()
  {
    ECCurve curve = this.Curve;
    BigInteger cofactor = curve.Cofactor;
    if (BigInteger.Two.Equals(cofactor))
      return ((AbstractF2mFieldElement) this.Normalize().AffineXCoord).Trace() != 0;
    if (!BigInteger.ValueOf(4L).Equals(cofactor))
      return base.SatisfiesOrder();
    ECPoint ecPoint = this.Normalize();
    ECFieldElement affineXcoord = ecPoint.AffineXCoord;
    ECFieldElement b = ((AbstractF2mCurve) curve).SolveQuadraticEquation(affineXcoord.Add(curve.A));
    if (b == null)
      return false;
    ECFieldElement affineYcoord = ecPoint.AffineYCoord;
    return ((AbstractF2mFieldElement) affineXcoord.Multiply(b).Add(affineYcoord)).Trace() == 0;
  }

  public override ECPoint ScaleX(ECFieldElement scale)
  {
    if (this.IsInfinity)
      return (ECPoint) this;
    switch (this.CurveCoordinateSystem)
    {
      case 5:
        ECFieldElement rawXcoord1 = this.RawXCoord;
        ECFieldElement rawYcoord1 = this.RawYCoord;
        ECFieldElement b1 = rawXcoord1.Multiply(scale);
        ECFieldElement b2 = rawXcoord1;
        ECFieldElement y1 = rawYcoord1.Add(b2).Divide(scale).Add(b1);
        return this.Curve.CreateRawPoint(rawXcoord1, y1, this.RawZCoords);
      case 6:
        ECFieldElement rawXcoord2 = this.RawXCoord;
        ECFieldElement rawYcoord2 = this.RawYCoord;
        ECFieldElement rawZcoord = this.RawZCoords[0];
        ECFieldElement b3 = rawXcoord2.Multiply(scale.Square());
        ECFieldElement b4 = rawXcoord2;
        ECFieldElement y2 = rawYcoord2.Add(b4).Add(b3);
        ECFieldElement ecFieldElement = rawZcoord.Multiply(scale);
        return this.Curve.CreateRawPoint(rawXcoord2, y2, new ECFieldElement[1]
        {
          ecFieldElement
        });
      default:
        return base.ScaleX(scale);
    }
  }

  public override ECPoint ScaleXNegateY(ECFieldElement scale) => this.ScaleX(scale);

  public override ECPoint ScaleY(ECFieldElement scale)
  {
    if (this.IsInfinity)
      return (ECPoint) this;
    switch (this.CurveCoordinateSystem)
    {
      case 5:
      case 6:
        ECFieldElement rawXcoord = this.RawXCoord;
        ECFieldElement y = this.RawYCoord.Add(rawXcoord).Multiply(scale).Add(rawXcoord);
        return this.Curve.CreateRawPoint(rawXcoord, y, this.RawZCoords);
      default:
        return base.ScaleY(scale);
    }
  }

  public override ECPoint ScaleYNegateX(ECFieldElement scale) => this.ScaleY(scale);

  public override ECPoint Subtract(ECPoint b)
  {
    return b.IsInfinity ? (ECPoint) this : this.Add(b.Negate());
  }

  public virtual AbstractF2mPoint Tau()
  {
    if (this.IsInfinity)
      return this;
    ECCurve curve = this.Curve;
    int coordinateSystem = curve.CoordinateSystem;
    ECFieldElement rawXcoord = this.RawXCoord;
    switch (coordinateSystem)
    {
      case 0:
      case 5:
        ECFieldElement rawYcoord1 = this.RawYCoord;
        return (AbstractF2mPoint) curve.CreateRawPoint(rawXcoord.Square(), rawYcoord1.Square());
      case 1:
      case 6:
        ECFieldElement rawYcoord2 = this.RawYCoord;
        ECFieldElement rawZcoord = this.RawZCoords[0];
        return (AbstractF2mPoint) curve.CreateRawPoint(rawXcoord.Square(), rawYcoord2.Square(), new ECFieldElement[1]
        {
          rawZcoord.Square()
        });
      default:
        throw new InvalidOperationException("unsupported coordinate system");
    }
  }

  public virtual AbstractF2mPoint TauPow(int pow)
  {
    if (this.IsInfinity)
      return this;
    ECCurve curve = this.Curve;
    int coordinateSystem = curve.CoordinateSystem;
    ECFieldElement rawXcoord = this.RawXCoord;
    switch (coordinateSystem)
    {
      case 0:
      case 5:
        ECFieldElement rawYcoord1 = this.RawYCoord;
        return (AbstractF2mPoint) curve.CreateRawPoint(rawXcoord.SquarePow(pow), rawYcoord1.SquarePow(pow));
      case 1:
      case 6:
        ECFieldElement rawYcoord2 = this.RawYCoord;
        ECFieldElement rawZcoord = this.RawZCoords[0];
        return (AbstractF2mPoint) curve.CreateRawPoint(rawXcoord.SquarePow(pow), rawYcoord2.SquarePow(pow), new ECFieldElement[1]
        {
          rawZcoord.SquarePow(pow)
        });
      default:
        throw new InvalidOperationException("unsupported coordinate system");
    }
  }
}
