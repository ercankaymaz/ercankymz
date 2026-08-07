// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Math.EC.ECPoint
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Math.EC.Multiplier;
using Org.BouncyCastle.Security;
using System;
using System.Collections.Generic;
using System.Text;

#nullable disable
namespace Org.BouncyCastle.Math.EC;

public abstract class ECPoint
{
  protected static readonly ECFieldElement[] EMPTY_ZS = new ECFieldElement[0];
  protected internal readonly ECCurve m_curve;
  protected internal readonly ECFieldElement m_x;
  protected internal readonly ECFieldElement m_y;
  protected internal readonly ECFieldElement[] m_zs;
  protected internal IDictionary<string, PreCompInfo> m_preCompTable;

  protected static ECFieldElement[] GetInitialZCoords(ECCurve curve)
  {
    int coordinateSystem = curve == null ? 0 : curve.CoordinateSystem;
    switch (coordinateSystem)
    {
      case 0:
      case 5:
        return ECPoint.EMPTY_ZS;
      default:
        ECFieldElement ecFieldElement = curve.FromBigInteger(BigInteger.One);
        switch (coordinateSystem - 1)
        {
          case 0:
          case 1:
          case 5:
            return new ECFieldElement[1]{ ecFieldElement };
          case 2:
            return new ECFieldElement[3]
            {
              ecFieldElement,
              ecFieldElement,
              ecFieldElement
            };
          case 3:
            return new ECFieldElement[2]
            {
              ecFieldElement,
              curve.A
            };
          default:
            throw new ArgumentException("unknown coordinate system");
        }
    }
  }

  protected ECPoint(ECCurve curve, ECFieldElement x, ECFieldElement y)
    : this(curve, x, y, ECPoint.GetInitialZCoords(curve))
  {
  }

  internal ECPoint(ECCurve curve, ECFieldElement x, ECFieldElement y, ECFieldElement[] zs)
  {
    this.m_curve = curve;
    this.m_x = x;
    this.m_y = y;
    this.m_zs = zs;
  }

  protected abstract bool SatisfiesCurveEquation();

  protected virtual bool SatisfiesOrder()
  {
    if (BigInteger.One.Equals(this.Curve.Cofactor))
      return true;
    BigInteger order = this.Curve.Order;
    return order == null || ECAlgorithms.ReferenceMultiply(this, order).IsInfinity;
  }

  public ECPoint GetDetachedPoint() => this.Normalize().Detach();

  public virtual ECCurve Curve => this.m_curve;

  protected abstract ECPoint Detach();

  protected virtual int CurveCoordinateSystem
  {
    get => this.m_curve != null ? this.m_curve.CoordinateSystem : 0;
  }

  public virtual ECFieldElement AffineXCoord
  {
    get
    {
      this.CheckNormalized();
      return this.XCoord;
    }
  }

  public virtual ECFieldElement AffineYCoord
  {
    get
    {
      this.CheckNormalized();
      return this.YCoord;
    }
  }

  public virtual ECFieldElement XCoord => this.m_x;

  public virtual ECFieldElement YCoord => this.m_y;

  public virtual ECFieldElement GetZCoord(int index)
  {
    return index >= 0 && index < this.m_zs.Length ? this.m_zs[index] : (ECFieldElement) null;
  }

  public virtual ECFieldElement[] GetZCoords()
  {
    int length = this.m_zs.Length;
    if (length == 0)
      return this.m_zs;
    ECFieldElement[] destinationArray = new ECFieldElement[length];
    Array.Copy((Array) this.m_zs, 0, (Array) destinationArray, 0, length);
    return destinationArray;
  }

  protected internal ECFieldElement RawXCoord => this.m_x;

  protected internal ECFieldElement RawYCoord => this.m_y;

  protected internal ECFieldElement[] RawZCoords => this.m_zs;

  protected virtual void CheckNormalized()
  {
    if (!this.IsNormalized())
      throw new InvalidOperationException("point not in normal form");
  }

  public virtual bool IsNormalized()
  {
    switch (this.CurveCoordinateSystem)
    {
      case 0:
      case 5:
        return true;
      default:
        if (!this.IsInfinity)
          return this.RawZCoords[0].IsOne;
        goto case 0;
    }
  }

  public virtual ECPoint Normalize()
  {
    if (this.IsInfinity)
      return this;
    switch (this.CurveCoordinateSystem)
    {
      case 0:
      case 5:
        return this;
      default:
        ECFieldElement rawZcoord = this.RawZCoords[0];
        if (rawZcoord.IsOne)
          return this;
        ECFieldElement b = this.m_curve != null ? this.m_curve.RandomFieldElementMult(SecureRandom.ArbitraryRandom) : throw new InvalidOperationException("Detached points must be in affine coordinates");
        return this.Normalize(rawZcoord.Multiply(b).Invert().Multiply(b));
    }
  }

  internal virtual ECPoint Normalize(ECFieldElement zInv)
  {
    switch (this.CurveCoordinateSystem)
    {
      case 1:
      case 6:
        return this.CreateScaledPoint(zInv, zInv);
      case 2:
      case 3:
      case 4:
        ECFieldElement sx = zInv.Square();
        ECFieldElement sy = sx.Multiply(zInv);
        return this.CreateScaledPoint(sx, sy);
      default:
        throw new InvalidOperationException("not a projective coordinate system");
    }
  }

  protected virtual ECPoint CreateScaledPoint(ECFieldElement sx, ECFieldElement sy)
  {
    return this.Curve.CreateRawPoint(this.RawXCoord.Multiply(sx), this.RawYCoord.Multiply(sy));
  }

  public bool IsInfinity => this.m_x == null && this.m_y == null;

  public bool IsValid() => this.ImplIsValid(false, true);

  internal bool IsValidPartial() => this.ImplIsValid(false, false);

  internal bool ImplIsValid(bool decompressed, bool checkOrder)
  {
    if (this.IsInfinity)
      return true;
    ECPoint.ValidityCallback callback = new ECPoint.ValidityCallback(this, decompressed, checkOrder);
    return !((ValidityPreCompInfo) this.Curve.Precompute(this, ValidityPreCompInfo.PRECOMP_NAME, (IPreCompCallback) callback)).HasFailed();
  }

  public virtual ECPoint ScaleX(ECFieldElement scale)
  {
    return !this.IsInfinity ? this.Curve.CreateRawPoint(this.RawXCoord.Multiply(scale), this.RawYCoord, this.RawZCoords) : this;
  }

  public virtual ECPoint ScaleXNegateY(ECFieldElement scale)
  {
    return !this.IsInfinity ? this.Curve.CreateRawPoint(this.RawXCoord.Multiply(scale), this.RawYCoord.Negate(), this.RawZCoords) : this;
  }

  public virtual ECPoint ScaleY(ECFieldElement scale)
  {
    return !this.IsInfinity ? this.Curve.CreateRawPoint(this.RawXCoord, this.RawYCoord.Multiply(scale), this.RawZCoords) : this;
  }

  public virtual ECPoint ScaleYNegateX(ECFieldElement scale)
  {
    return !this.IsInfinity ? this.Curve.CreateRawPoint(this.RawXCoord.Negate(), this.RawYCoord.Multiply(scale), this.RawZCoords) : this;
  }

  public override bool Equals(object obj) => this.Equals(obj as ECPoint);

  public virtual bool Equals(ECPoint other)
  {
    if (this == other)
      return true;
    if (other == null)
      return false;
    ECCurve curve1 = this.Curve;
    ECCurve curve2 = other.Curve;
    bool flag1 = curve1 == null;
    bool flag2 = curve2 == null;
    bool isInfinity1 = this.IsInfinity;
    bool isInfinity2 = other.IsInfinity;
    if (isInfinity1 | isInfinity2)
    {
      if (!(isInfinity1 & isInfinity2))
        return false;
      return flag1 | flag2 || curve1.Equals(curve2);
    }
    ECPoint ecPoint = this;
    ECPoint p = other;
    if (!(flag1 & flag2))
    {
      if (flag1)
        p = p.Normalize();
      else if (flag2)
      {
        ecPoint = ecPoint.Normalize();
      }
      else
      {
        if (!curve1.Equals(curve2))
          return false;
        ECPoint[] points = new ECPoint[2]
        {
          this,
          curve1.ImportPoint(p)
        };
        curve1.NormalizeAll(points);
        ecPoint = points[0];
        p = points[1];
      }
    }
    return ecPoint.XCoord.Equals(p.XCoord) && ecPoint.YCoord.Equals(p.YCoord);
  }

  public override int GetHashCode()
  {
    ECCurve curve = this.Curve;
    int hashCode = curve == null ? 0 : ~curve.GetHashCode();
    if (!this.IsInfinity)
    {
      ECPoint ecPoint = this.Normalize();
      hashCode = hashCode ^ ecPoint.XCoord.GetHashCode() * 17 ^ ecPoint.YCoord.GetHashCode() * 257;
    }
    return hashCode;
  }

  public override string ToString()
  {
    if (this.IsInfinity)
      return "INF";
    StringBuilder stringBuilder = new StringBuilder();
    stringBuilder.Append('(');
    stringBuilder.Append((object) this.RawXCoord);
    stringBuilder.Append(',');
    stringBuilder.Append((object) this.RawYCoord);
    for (int index = 0; index < this.m_zs.Length; ++index)
    {
      stringBuilder.Append(',');
      stringBuilder.Append((object) this.m_zs[index]);
    }
    stringBuilder.Append(')');
    return stringBuilder.ToString();
  }

  public virtual byte[] GetEncoded() => this.GetEncoded(false);

  public abstract byte[] GetEncoded(bool compressed);

  public abstract int GetEncodedLength(bool compressed);

  public abstract void EncodeTo(bool compressed, byte[] buf, int off);

  protected internal abstract bool CompressionYTilde { get; }

  public abstract ECPoint Add(ECPoint b);

  public abstract ECPoint Subtract(ECPoint b);

  public abstract ECPoint Negate();

  public virtual ECPoint TimesPow2(int e)
  {
    if (e < 0)
      throw new ArgumentException("cannot be negative", nameof (e));
    ECPoint ecPoint = this;
    while (--e >= 0)
      ecPoint = ecPoint.Twice();
    return ecPoint;
  }

  public abstract ECPoint Twice();

  public abstract ECPoint Multiply(BigInteger b);

  public virtual ECPoint TwicePlus(ECPoint b) => this.Twice().Add(b);

  public virtual ECPoint ThreeTimes() => this.TwicePlus(this);

  private class ValidityCallback : IPreCompCallback
  {
    private readonly ECPoint m_outer;
    private readonly bool m_decompressed;
    private readonly bool m_checkOrder;

    internal ValidityCallback(ECPoint outer, bool decompressed, bool checkOrder)
    {
      this.m_outer = outer;
      this.m_decompressed = decompressed;
      this.m_checkOrder = checkOrder;
    }

    public PreCompInfo Precompute(PreCompInfo existing)
    {
      if (!(existing is ValidityPreCompInfo validityPreCompInfo1))
        validityPreCompInfo1 = new ValidityPreCompInfo();
      ValidityPreCompInfo validityPreCompInfo2 = validityPreCompInfo1;
      if (validityPreCompInfo2.HasFailed())
        return (PreCompInfo) validityPreCompInfo2;
      if (!validityPreCompInfo2.HasCurveEquationPassed())
      {
        if (!this.m_decompressed && !this.m_outer.SatisfiesCurveEquation())
        {
          validityPreCompInfo2.ReportFailed();
          return (PreCompInfo) validityPreCompInfo2;
        }
        validityPreCompInfo2.ReportCurveEquationPassed();
      }
      if (this.m_checkOrder && !validityPreCompInfo2.HasOrderPassed())
      {
        if (!this.m_outer.SatisfiesOrder())
        {
          validityPreCompInfo2.ReportFailed();
          return (PreCompInfo) validityPreCompInfo2;
        }
        validityPreCompInfo2.ReportOrderPassed();
      }
      return (PreCompInfo) validityPreCompInfo2;
    }
  }
}
