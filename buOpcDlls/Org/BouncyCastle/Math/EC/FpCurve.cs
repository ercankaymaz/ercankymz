// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Math.EC.FpCurve
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;

#nullable disable
namespace Org.BouncyCastle.Math.EC;

public class FpCurve : AbstractFpCurve
{
  private const int FP_DEFAULT_COORDS = 4;
  protected readonly BigInteger m_q;
  protected readonly BigInteger m_r;
  protected readonly FpPoint m_infinity;

  [Obsolete("Use constructor taking order/cofactor")]
  public FpCurve(BigInteger q, BigInteger a, BigInteger b)
    : this(q, a, b, (BigInteger) null, (BigInteger) null)
  {
  }

  public FpCurve(BigInteger q, BigInteger a, BigInteger b, BigInteger order, BigInteger cofactor)
    : this(q, a, b, order, cofactor, false)
  {
  }

  internal FpCurve(
    BigInteger q,
    BigInteger a,
    BigInteger b,
    BigInteger order,
    BigInteger cofactor,
    bool isInternal)
    : base(q, isInternal)
  {
    this.m_q = q;
    this.m_r = FpFieldElement.CalculateResidue(q);
    this.m_infinity = new FpPoint((ECCurve) this, (ECFieldElement) null, (ECFieldElement) null);
    this.m_a = this.FromBigInteger(a);
    this.m_b = this.FromBigInteger(b);
    this.m_order = order;
    this.m_cofactor = cofactor;
    this.m_coord = 4;
  }

  internal FpCurve(
    BigInteger q,
    BigInteger r,
    ECFieldElement a,
    ECFieldElement b,
    BigInteger order,
    BigInteger cofactor)
    : base(q, true)
  {
    this.m_q = q;
    this.m_r = r;
    this.m_infinity = new FpPoint((ECCurve) this, (ECFieldElement) null, (ECFieldElement) null);
    this.m_a = a;
    this.m_b = b;
    this.m_order = order;
    this.m_cofactor = cofactor;
    this.m_coord = 4;
  }

  protected override ECCurve CloneCurve()
  {
    return (ECCurve) new FpCurve(this.m_q, this.m_r, this.m_a, this.m_b, this.m_order, this.m_cofactor);
  }

  public override bool SupportsCoordinateSystem(int coord)
  {
    switch (coord)
    {
      case 0:
      case 1:
      case 2:
      case 4:
        return true;
      default:
        return false;
    }
  }

  public virtual BigInteger Q => this.m_q;

  public override ECPoint Infinity => (ECPoint) this.m_infinity;

  public override int FieldSize => this.m_q.BitLength;

  public override ECFieldElement FromBigInteger(BigInteger x)
  {
    if (x == null || x.SignValue < 0 || x.CompareTo(this.m_q) >= 0)
      throw new ArgumentException("value invalid for Fp field element", nameof (x));
    return (ECFieldElement) new FpFieldElement(this.m_q, this.m_r, x);
  }

  protected internal override ECPoint CreateRawPoint(ECFieldElement x, ECFieldElement y)
  {
    return (ECPoint) new FpPoint((ECCurve) this, x, y);
  }

  protected internal override ECPoint CreateRawPoint(
    ECFieldElement x,
    ECFieldElement y,
    ECFieldElement[] zs)
  {
    return (ECPoint) new FpPoint((ECCurve) this, x, y, zs);
  }

  public override ECPoint ImportPoint(ECPoint p)
  {
    if (this != p.Curve && this.CoordinateSystem == 2 && !p.IsInfinity)
    {
      switch (p.Curve.CoordinateSystem)
      {
        case 2:
        case 3:
        case 4:
          return (ECPoint) new FpPoint((ECCurve) this, this.FromBigInteger(p.RawXCoord.ToBigInteger()), this.FromBigInteger(p.RawYCoord.ToBigInteger()), new ECFieldElement[1]
          {
            this.FromBigInteger(p.GetZCoord(0).ToBigInteger())
          });
      }
    }
    return base.ImportPoint(p);
  }
}
