// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Math.EC.FpPoint
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;

#nullable disable
namespace Org.BouncyCastle.Math.EC;

public class FpPoint : AbstractFpPoint
{
  internal FpPoint(ECCurve curve, ECFieldElement x, ECFieldElement y)
    : base(curve, x, y)
  {
    if (x == null != (y == null))
      throw new ArgumentException("Exactly one of the field elements is null");
  }

  internal FpPoint(ECCurve curve, ECFieldElement x, ECFieldElement y, ECFieldElement[] zs)
    : base(curve, x, y, zs)
  {
  }

  protected override ECPoint Detach()
  {
    return (ECPoint) new FpPoint((ECCurve) null, this.AffineXCoord, this.AffineYCoord);
  }

  public override ECFieldElement GetZCoord(int index)
  {
    return index == 1 && 4 == this.CurveCoordinateSystem ? this.GetJacobianModifiedW() : base.GetZCoord(index);
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
    int coordinateSystem = curve.CoordinateSystem;
    ECFieldElement rawXcoord1 = this.RawXCoord;
    ECFieldElement rawYcoord1 = this.RawYCoord;
    ECFieldElement rawXcoord2 = b.RawXCoord;
    ECFieldElement rawYcoord2 = b.RawYCoord;
    switch (coordinateSystem)
    {
      case 0:
        ECFieldElement b1 = rawXcoord2.Subtract(rawXcoord1);
        ECFieldElement ecFieldElement1 = rawYcoord2.Subtract(rawYcoord1);
        if (b1.IsZero)
          return ecFieldElement1.IsZero ? this.Twice() : this.Curve.Infinity;
        ECFieldElement ecFieldElement2 = ecFieldElement1.Divide(b1);
        ECFieldElement ecFieldElement3 = ecFieldElement2.Square().Subtract(rawXcoord1).Subtract(rawXcoord2);
        ECFieldElement y1 = ecFieldElement2.Multiply(rawXcoord1.Subtract(ecFieldElement3)).Subtract(rawYcoord1);
        return (ECPoint) new FpPoint(this.Curve, ecFieldElement3, y1);
      case 1:
        ECFieldElement rawZcoord1 = this.RawZCoords[0];
        ECFieldElement rawZcoord2 = b.RawZCoords[0];
        bool isOne1 = rawZcoord1.IsOne;
        bool isOne2 = rawZcoord2.IsOne;
        ECFieldElement ecFieldElement4 = isOne1 ? rawYcoord2 : rawYcoord2.Multiply(rawZcoord1);
        ECFieldElement x1 = isOne2 ? rawYcoord1 : rawYcoord1.Multiply(rawZcoord2);
        ECFieldElement b2 = x1;
        ECFieldElement b3 = ecFieldElement4.Subtract(b2);
        ECFieldElement ecFieldElement5 = isOne1 ? rawXcoord2 : rawXcoord2.Multiply(rawZcoord1);
        ECFieldElement b4 = isOne2 ? rawXcoord1 : rawXcoord1.Multiply(rawZcoord2);
        ECFieldElement b5 = b4;
        ECFieldElement b6 = ecFieldElement5.Subtract(b5);
        if (b6.IsZero)
          return b3.IsZero ? this.Twice() : curve.Infinity;
        ECFieldElement b7 = isOne1 ? rawZcoord2 : (isOne2 ? rawZcoord1 : rawZcoord1.Multiply(rawZcoord2));
        ECFieldElement ecFieldElement6 = b6.Square();
        ECFieldElement ecFieldElement7 = ecFieldElement6.Multiply(b6);
        ECFieldElement x2 = ecFieldElement6.Multiply(b4);
        ECFieldElement b8 = b3.Square().Multiply(b7).Subtract(ecFieldElement7).Subtract(this.Two(x2));
        ECFieldElement x3 = b6.Multiply(b8);
        ECFieldElement y2 = x2.Subtract(b8).MultiplyMinusProduct(b3, x1, ecFieldElement7);
        ECFieldElement ecFieldElement8 = ecFieldElement7.Multiply(b7);
        return (ECPoint) new FpPoint(curve, x3, y2, new ECFieldElement[1]
        {
          ecFieldElement8
        });
      case 2:
      case 4:
        ECFieldElement rawZcoord3 = this.RawZCoords[0];
        ECFieldElement rawZcoord4 = b.RawZCoords[0];
        bool isOne3 = rawZcoord3.IsOne;
        ECFieldElement ZSquared = (ECFieldElement) null;
        ECFieldElement ecFieldElement9;
        ECFieldElement y3;
        ECFieldElement Z;
        if (!isOne3 && rawZcoord3.Equals(rawZcoord4))
        {
          ECFieldElement ecFieldElement10 = rawXcoord1.Subtract(rawXcoord2);
          ECFieldElement b9 = rawYcoord1.Subtract(rawYcoord2);
          if (ecFieldElement10.IsZero)
            return b9.IsZero ? this.Twice() : curve.Infinity;
          ECFieldElement b10 = ecFieldElement10.Square();
          ECFieldElement b11 = rawXcoord1.Multiply(b10);
          ECFieldElement b12 = rawXcoord2.Multiply(b10);
          ECFieldElement b13 = b11.Subtract(b12).Multiply(rawYcoord1);
          ecFieldElement9 = b9.Square().Subtract(b11).Subtract(b12);
          y3 = b11.Subtract(ecFieldElement9).Multiply(b9).Subtract(b13);
          Z = ecFieldElement10;
          if (isOne3)
            ZSquared = b10;
          else
            Z = Z.Multiply(rawZcoord3);
        }
        else
        {
          ECFieldElement b14;
          ECFieldElement b15;
          if (isOne3)
          {
            b14 = rawXcoord2;
            b15 = rawYcoord2;
          }
          else
          {
            ECFieldElement ecFieldElement11 = rawZcoord3.Square();
            b14 = ecFieldElement11.Multiply(rawXcoord2);
            b15 = ecFieldElement11.Multiply(rawZcoord3).Multiply(rawYcoord2);
          }
          bool isOne4;
          ECFieldElement b16;
          ECFieldElement y4;
          if (isOne4 = rawZcoord4.IsOne)
          {
            b16 = rawXcoord1;
            y4 = rawYcoord1;
          }
          else
          {
            ECFieldElement ecFieldElement12 = rawZcoord4.Square();
            b16 = ecFieldElement12.Multiply(rawXcoord1);
            y4 = ecFieldElement12.Multiply(rawZcoord4).Multiply(rawYcoord1);
          }
          ECFieldElement b17 = b16.Subtract(b14);
          ECFieldElement b18 = y4.Subtract(b15);
          if (b17.IsZero)
            return b18.IsZero ? this.Twice() : curve.Infinity;
          ECFieldElement ecFieldElement13 = b17.Square();
          ECFieldElement ecFieldElement14 = ecFieldElement13.Multiply(b17);
          ECFieldElement x4 = ecFieldElement13.Multiply(b16);
          ecFieldElement9 = b18.Square().Add(ecFieldElement14).Subtract(this.Two(x4));
          y3 = x4.Subtract(ecFieldElement9).MultiplyMinusProduct(b18, ecFieldElement14, y4);
          Z = b17;
          if (!isOne3)
            Z = Z.Multiply(rawZcoord3);
          if (!isOne4)
            Z = Z.Multiply(rawZcoord4);
          if (Z == b17)
            ZSquared = ecFieldElement13;
        }
        ECFieldElement[] zs;
        if (coordinateSystem == 4)
        {
          ECFieldElement jacobianModifiedW = this.CalculateJacobianModifiedW(Z, ZSquared);
          zs = new ECFieldElement[2]{ Z, jacobianModifiedW };
        }
        else
          zs = new ECFieldElement[1]{ Z };
        return (ECPoint) new FpPoint(curve, ecFieldElement9, y3, zs);
      default:
        throw new InvalidOperationException("unsupported coordinate system");
    }
  }

  public override ECPoint Twice()
  {
    if (this.IsInfinity)
      return (ECPoint) this;
    ECCurve curve = this.Curve;
    ECFieldElement rawYcoord = this.RawYCoord;
    if (rawYcoord.IsZero)
      return curve.Infinity;
    int coordinateSystem = curve.CoordinateSystem;
    ECFieldElement rawXcoord = this.RawXCoord;
    switch (coordinateSystem)
    {
      case 0:
        ECFieldElement ecFieldElement1 = this.Three(rawXcoord.Square()).Add(this.Curve.A).Divide(this.Two(rawYcoord));
        ECFieldElement ecFieldElement2 = ecFieldElement1.Square().Subtract(this.Two(rawXcoord));
        ECFieldElement y1 = ecFieldElement1.Multiply(rawXcoord.Subtract(ecFieldElement2)).Subtract(rawYcoord);
        return (ECPoint) new FpPoint(this.Curve, ecFieldElement2, y1);
      case 1:
        ECFieldElement rawZcoord1 = this.RawZCoords[0];
        bool isOne1 = rawZcoord1.IsOne;
        ECFieldElement ecFieldElement3 = curve.A;
        if (!ecFieldElement3.IsZero && !isOne1)
          ecFieldElement3 = ecFieldElement3.Multiply(rawZcoord1.Square());
        ECFieldElement b1 = ecFieldElement3.Add(this.Three(rawXcoord.Square()));
        ECFieldElement ecFieldElement4 = isOne1 ? rawYcoord : rawYcoord.Multiply(rawZcoord1);
        ECFieldElement ecFieldElement5 = isOne1 ? rawYcoord.Square() : ecFieldElement4.Multiply(rawYcoord);
        ECFieldElement x1 = this.Four(rawXcoord.Multiply(ecFieldElement5));
        ECFieldElement b2 = b1.Square().Subtract(this.Two(x1));
        ECFieldElement b3 = this.Two(ecFieldElement4);
        ECFieldElement x2 = b2.Multiply(b3);
        ECFieldElement x3 = this.Two(ecFieldElement5);
        ECFieldElement y2 = x1.Subtract(b2).Multiply(b1).Subtract(this.Two(x3.Square()));
        ECFieldElement ecFieldElement6 = this.Two(isOne1 ? this.Two(x3) : b3.Square()).Multiply(ecFieldElement4);
        return (ECPoint) new FpPoint(curve, x2, y2, new ECFieldElement[1]
        {
          ecFieldElement6
        });
      case 2:
        ECFieldElement rawZcoord2 = this.RawZCoords[0];
        bool isOne2 = rawZcoord2.IsOne;
        ECFieldElement b4 = rawYcoord.Square();
        ECFieldElement x4 = b4.Square();
        ECFieldElement a = curve.A;
        ECFieldElement b5 = a.Negate();
        ECFieldElement b6;
        ECFieldElement x5;
        if (b5.ToBigInteger().Equals(BigInteger.ValueOf(3L)))
        {
          ECFieldElement b7 = isOne2 ? rawZcoord2 : rawZcoord2.Square();
          b6 = this.Three(rawXcoord.Add(b7).Multiply(rawXcoord.Subtract(b7)));
          x5 = this.Four(b4.Multiply(rawXcoord));
        }
        else
        {
          b6 = this.Three(rawXcoord.Square());
          if (isOne2)
            b6 = b6.Add(a);
          else if (!a.IsZero)
          {
            ECFieldElement ecFieldElement7 = (isOne2 ? rawZcoord2 : rawZcoord2.Square()).Square();
            b6 = b5.BitLength >= a.BitLength ? b6.Add(ecFieldElement7.Multiply(a)) : b6.Subtract(ecFieldElement7.Multiply(b5));
          }
          x5 = this.Four(rawXcoord.Multiply(b4));
        }
        ECFieldElement ecFieldElement8 = b6.Square().Subtract(this.Two(x5));
        ECFieldElement y3 = x5.Subtract(ecFieldElement8).Multiply(b6).Subtract(this.Eight(x4));
        ECFieldElement ecFieldElement9 = this.Two(rawYcoord);
        if (!isOne2)
          ecFieldElement9 = ecFieldElement9.Multiply(rawZcoord2);
        return (ECPoint) new FpPoint(curve, ecFieldElement8, y3, new ECFieldElement[1]
        {
          ecFieldElement9
        });
      case 4:
        return (ECPoint) this.TwiceJacobianModified(true);
      default:
        throw new InvalidOperationException("unsupported coordinate system");
    }
  }

  public override ECPoint TwicePlus(ECPoint b)
  {
    if (this == b)
      return this.ThreeTimes();
    if (this.IsInfinity)
      return b;
    if (b.IsInfinity)
      return this.Twice();
    ECFieldElement rawYcoord1 = this.RawYCoord;
    if (rawYcoord1.IsZero)
      return b;
    switch (this.Curve.CoordinateSystem)
    {
      case 0:
        ECFieldElement rawXcoord1 = this.RawXCoord;
        ECFieldElement rawXcoord2 = b.RawXCoord;
        ECFieldElement rawYcoord2 = b.RawYCoord;
        ECFieldElement b1 = rawXcoord2.Subtract(rawXcoord1);
        ECFieldElement b2 = rawYcoord1;
        ECFieldElement b3 = rawYcoord2.Subtract(b2);
        if (b1.IsZero)
          return b3.IsZero ? this.ThreeTimes() : (ECPoint) this;
        ECFieldElement b4 = b1.Square();
        ECFieldElement b5 = b3.Square();
        ECFieldElement ecFieldElement1 = b4.Multiply(this.Two(rawXcoord1).Add(rawXcoord2)).Subtract(b5);
        if (ecFieldElement1.IsZero)
          return this.Curve.Infinity;
        ECFieldElement b6 = ecFieldElement1.Multiply(b1).Invert();
        ECFieldElement b7 = ecFieldElement1.Multiply(b6).Multiply(b3);
        ECFieldElement b8 = this.Two(rawYcoord1).Multiply(b4).Multiply(b1).Multiply(b6).Subtract(b7);
        ECFieldElement ecFieldElement2 = b8.Subtract(b7).Multiply(b7.Add(b8)).Add(rawXcoord2);
        ECFieldElement y = rawXcoord1.Subtract(ecFieldElement2).Multiply(b8).Subtract(rawYcoord1);
        return (ECPoint) new FpPoint(this.Curve, ecFieldElement2, y);
      case 4:
        return this.TwiceJacobianModified(false).Add(b);
      default:
        return this.Twice().Add(b);
    }
  }

  public override ECPoint ThreeTimes()
  {
    if (this.IsInfinity)
      return (ECPoint) this;
    ECFieldElement rawYcoord = this.RawYCoord;
    if (rawYcoord.IsZero)
      return (ECPoint) this;
    switch (this.Curve.CoordinateSystem)
    {
      case 0:
        ECFieldElement rawXcoord = this.RawXCoord;
        ECFieldElement b1 = this.Two(rawYcoord);
        ECFieldElement b2 = b1.Square();
        ECFieldElement b3 = this.Three(rawXcoord.Square()).Add(this.Curve.A);
        ECFieldElement b4 = b3.Square();
        ECFieldElement ecFieldElement1 = this.Three(rawXcoord).Multiply(b2).Subtract(b4);
        if (ecFieldElement1.IsZero)
          return this.Curve.Infinity;
        ECFieldElement b5 = ecFieldElement1.Multiply(b1).Invert();
        ECFieldElement b6 = ecFieldElement1.Multiply(b5).Multiply(b3);
        ECFieldElement b7 = b2.Square().Multiply(b5).Subtract(b6);
        ECFieldElement ecFieldElement2 = b7.Subtract(b6).Multiply(b6.Add(b7)).Add(rawXcoord);
        ECFieldElement y = rawXcoord.Subtract(ecFieldElement2).Multiply(b7).Subtract(rawYcoord);
        return (ECPoint) new FpPoint(this.Curve, ecFieldElement2, y);
      case 4:
        return this.TwiceJacobianModified(false).Add((ECPoint) this);
      default:
        return this.Twice().Add((ECPoint) this);
    }
  }

  public override ECPoint TimesPow2(int e)
  {
    if (e < 0)
      throw new ArgumentException("cannot be negative", nameof (e));
    if (e == 0 || this.IsInfinity)
      return (ECPoint) this;
    if (e == 1)
      return this.Twice();
    ECCurve curve = this.Curve;
    ECFieldElement ecFieldElement1 = this.RawYCoord;
    if (ecFieldElement1.IsZero)
      return curve.Infinity;
    int coordinateSystem = curve.CoordinateSystem;
    ECFieldElement b1 = curve.A;
    ECFieldElement ecFieldElement2 = this.RawXCoord;
    ECFieldElement ecFieldElement3 = this.RawZCoords.Length < 1 ? curve.FromBigInteger(BigInteger.One) : this.RawZCoords[0];
    if (!ecFieldElement3.IsOne)
    {
      switch (coordinateSystem)
      {
        case 1:
          ECFieldElement ecFieldElement4 = ecFieldElement3.Square();
          ecFieldElement2 = ecFieldElement2.Multiply(ecFieldElement3);
          ecFieldElement1 = ecFieldElement1.Multiply(ecFieldElement4);
          b1 = this.CalculateJacobianModifiedW(ecFieldElement3, ecFieldElement4);
          break;
        case 2:
          b1 = this.CalculateJacobianModifiedW(ecFieldElement3, (ECFieldElement) null);
          break;
        case 4:
          b1 = this.GetJacobianModifiedW();
          break;
      }
    }
    for (int index = 0; index < e; ++index)
    {
      if (ecFieldElement1.IsZero)
        return curve.Infinity;
      ECFieldElement ecFieldElement5 = this.Three(ecFieldElement2.Square());
      ECFieldElement ecFieldElement6 = this.Two(ecFieldElement1);
      ECFieldElement b2 = ecFieldElement6.Multiply(ecFieldElement1);
      ECFieldElement x = this.Two(ecFieldElement2.Multiply(b2));
      ECFieldElement b3 = this.Two(b2.Square());
      if (!b1.IsZero)
      {
        ecFieldElement5 = ecFieldElement5.Add(b1);
        b1 = this.Two(b3.Multiply(b1));
      }
      ecFieldElement2 = ecFieldElement5.Square().Subtract(this.Two(x));
      ecFieldElement1 = ecFieldElement5.Multiply(x.Subtract(ecFieldElement2)).Subtract(b3);
      ecFieldElement3 = ecFieldElement3.IsOne ? ecFieldElement6 : ecFieldElement6.Multiply(ecFieldElement3);
    }
    switch (coordinateSystem)
    {
      case 0:
        ECFieldElement b4 = ecFieldElement3.Invert();
        ECFieldElement b5 = b4.Square();
        ECFieldElement b6 = b5.Multiply(b4);
        return (ECPoint) new FpPoint(curve, ecFieldElement2.Multiply(b5), ecFieldElement1.Multiply(b6));
      case 1:
        ECFieldElement x1 = ecFieldElement2.Multiply(ecFieldElement3);
        ECFieldElement ecFieldElement7 = ecFieldElement3.Multiply(ecFieldElement3.Square());
        return (ECPoint) new FpPoint(curve, x1, ecFieldElement1, new ECFieldElement[1]
        {
          ecFieldElement7
        });
      case 2:
        return (ECPoint) new FpPoint(curve, ecFieldElement2, ecFieldElement1, new ECFieldElement[1]
        {
          ecFieldElement3
        });
      case 4:
        return (ECPoint) new FpPoint(curve, ecFieldElement2, ecFieldElement1, new ECFieldElement[2]
        {
          ecFieldElement3,
          b1
        });
      default:
        throw new InvalidOperationException("unsupported coordinate system");
    }
  }

  protected virtual ECFieldElement Two(ECFieldElement x) => x.Add(x);

  protected virtual ECFieldElement Three(ECFieldElement x) => this.Two(x).Add(x);

  protected virtual ECFieldElement Four(ECFieldElement x) => this.Two(this.Two(x));

  protected virtual ECFieldElement Eight(ECFieldElement x) => this.Four(this.Two(x));

  protected virtual ECFieldElement DoubleProductFromSquares(
    ECFieldElement a,
    ECFieldElement b,
    ECFieldElement aSquared,
    ECFieldElement bSquared)
  {
    return a.Add(b).Square().Subtract(aSquared).Subtract(bSquared);
  }

  public override ECPoint Negate()
  {
    if (this.IsInfinity)
      return (ECPoint) this;
    ECCurve curve = this.Curve;
    return curve.CoordinateSystem != 0 ? (ECPoint) new FpPoint(curve, this.RawXCoord, this.RawYCoord.Negate(), this.RawZCoords) : (ECPoint) new FpPoint(curve, this.RawXCoord, this.RawYCoord.Negate());
  }

  protected virtual ECFieldElement CalculateJacobianModifiedW(
    ECFieldElement Z,
    ECFieldElement ZSquared)
  {
    ECFieldElement a = this.Curve.A;
    if (a.IsZero || Z.IsOne)
      return a;
    if (ZSquared == null)
      ZSquared = Z.Square();
    ECFieldElement ecFieldElement = ZSquared.Square();
    ECFieldElement b = a.Negate();
    return b.BitLength >= a.BitLength ? ecFieldElement.Multiply(a) : ecFieldElement.Multiply(b).Negate();
  }

  protected virtual ECFieldElement GetJacobianModifiedW()
  {
    ECFieldElement[] rawZcoords = this.RawZCoords;
    ECFieldElement jacobianModifiedW = rawZcoords[1];
    if (jacobianModifiedW == null)
      rawZcoords[1] = jacobianModifiedW = this.CalculateJacobianModifiedW(rawZcoords[0], (ECFieldElement) null);
    return jacobianModifiedW;
  }

  protected virtual FpPoint TwiceJacobianModified(bool calculateW)
  {
    ECFieldElement rawXcoord = this.RawXCoord;
    ECFieldElement rawYcoord = this.RawYCoord;
    ECFieldElement rawZcoord = this.RawZCoords[0];
    ECFieldElement jacobianModifiedW = this.GetJacobianModifiedW();
    ECFieldElement ecFieldElement1 = this.Three(rawXcoord.Square()).Add(jacobianModifiedW);
    ECFieldElement ecFieldElement2 = this.Two(rawYcoord);
    ECFieldElement b1 = ecFieldElement2.Multiply(rawYcoord);
    ECFieldElement x = this.Two(rawXcoord.Multiply(b1));
    ECFieldElement ecFieldElement3 = ecFieldElement1.Square().Subtract(this.Two(x));
    ECFieldElement b2 = this.Two(b1.Square());
    ECFieldElement y = ecFieldElement1.Multiply(x.Subtract(ecFieldElement3)).Subtract(b2);
    ECFieldElement ecFieldElement4 = calculateW ? this.Two(b2.Multiply(jacobianModifiedW)) : (ECFieldElement) null;
    ECFieldElement ecFieldElement5 = rawZcoord.IsOne ? ecFieldElement2 : ecFieldElement2.Multiply(rawZcoord);
    return new FpPoint(this.Curve, ecFieldElement3, y, new ECFieldElement[2]
    {
      ecFieldElement5,
      ecFieldElement4
    });
  }
}
