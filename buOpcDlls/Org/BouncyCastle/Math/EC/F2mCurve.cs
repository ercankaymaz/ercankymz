// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Math.EC.F2mCurve
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Math.EC.Multiplier;
using System;

#nullable disable
namespace Org.BouncyCastle.Math.EC;

public class F2mCurve : AbstractF2mCurve
{
  private const int F2M_DEFAULT_COORDS = 6;
  private readonly int m;
  private readonly int k1;
  private readonly int k2;
  private readonly int k3;
  protected readonly F2mPoint m_infinity;

  [Obsolete("Use constructor taking order/cofactor")]
  public F2mCurve(int m, int k, BigInteger a, BigInteger b)
    : this(m, k, 0, 0, a, b, (BigInteger) null, (BigInteger) null)
  {
  }

  public F2mCurve(
    int m,
    int k,
    BigInteger a,
    BigInteger b,
    BigInteger order,
    BigInteger cofactor)
    : this(m, k, 0, 0, a, b, order, cofactor)
  {
  }

  [Obsolete("Use constructor taking order/cofactor")]
  public F2mCurve(int m, int k1, int k2, int k3, BigInteger a, BigInteger b)
    : this(m, k1, k2, k3, a, b, (BigInteger) null, (BigInteger) null)
  {
  }

  public F2mCurve(
    int m,
    int k1,
    int k2,
    int k3,
    BigInteger a,
    BigInteger b,
    BigInteger order,
    BigInteger cofactor)
    : base(m, k1, k2, k3)
  {
    this.m = m;
    this.k1 = k1;
    this.k2 = k2;
    this.k3 = k3;
    this.m_order = order;
    this.m_cofactor = cofactor;
    this.m_infinity = new F2mPoint((ECCurve) this, (ECFieldElement) null, (ECFieldElement) null);
    this.m_a = this.FromBigInteger(a);
    this.m_b = this.FromBigInteger(b);
    this.m_coord = 6;
  }

  internal F2mCurve(
    int m,
    int k1,
    int k2,
    int k3,
    ECFieldElement a,
    ECFieldElement b,
    BigInteger order,
    BigInteger cofactor)
    : base(m, k1, k2, k3)
  {
    this.m = m;
    this.k1 = k1;
    this.k2 = k2;
    this.k3 = k3;
    this.m_order = order;
    this.m_cofactor = cofactor;
    this.m_infinity = new F2mPoint((ECCurve) this, (ECFieldElement) null, (ECFieldElement) null);
    this.m_a = a;
    this.m_b = b;
    this.m_coord = 6;
  }

  protected override ECCurve CloneCurve()
  {
    return (ECCurve) new F2mCurve(this.m, this.k1, this.k2, this.k3, this.m_a, this.m_b, this.m_order, this.m_cofactor);
  }

  public override bool SupportsCoordinateSystem(int coord)
  {
    switch (coord)
    {
      case 0:
      case 1:
      case 6:
        return true;
      default:
        return false;
    }
  }

  protected override ECMultiplier CreateDefaultMultiplier()
  {
    return this.IsKoblitz ? (ECMultiplier) new WTauNafMultiplier() : base.CreateDefaultMultiplier();
  }

  public override int FieldSize => this.m;

  public override ECFieldElement FromBigInteger(BigInteger x)
  {
    if (x == null || x.SignValue < 0 || x.BitLength > this.m)
      throw new ArgumentException("value invalid for F2m field element", nameof (x));
    int[] ks;
    if ((this.k2 | this.k3) != 0)
      ks = new int[3]{ this.k1, this.k2, this.k3 };
    else
      ks = new int[1]{ this.k1 };
    return (ECFieldElement) new F2mFieldElement(this.m, ks, new LongArray(x));
  }

  protected internal override ECPoint CreateRawPoint(ECFieldElement x, ECFieldElement y)
  {
    return (ECPoint) new F2mPoint((ECCurve) this, x, y);
  }

  protected internal override ECPoint CreateRawPoint(
    ECFieldElement x,
    ECFieldElement y,
    ECFieldElement[] zs)
  {
    return (ECPoint) new F2mPoint((ECCurve) this, x, y, zs);
  }

  public override ECPoint Infinity => (ECPoint) this.m_infinity;

  public int M => this.m;

  public bool IsTrinomial() => this.k2 == 0 && this.k3 == 0;

  public int K1 => this.k1;

  public int K2 => this.k2;

  public int K3 => this.k3;

  public override ECLookupTable CreateCacheSafeLookupTable(ECPoint[] points, int off, int len)
  {
    int num = (this.m + 63 /*0x3F*/) / 64 /*0x40*/;
    ulong[] numArray = new ulong[len * num * 2];
    int zOff1 = 0;
    for (int index = 0; index < len; ++index)
    {
      ECPoint point = points[off + index];
      ((F2mFieldElement) point.RawXCoord).x.CopyTo(numArray, zOff1);
      int zOff2 = zOff1 + num;
      ((F2mFieldElement) point.RawYCoord).x.CopyTo(numArray, zOff2);
      zOff1 = zOff2 + num;
    }
    return (ECLookupTable) new F2mCurve.DefaultF2mLookupTable(this, numArray, len);
  }

  private class DefaultF2mLookupTable : AbstractECLookupTable
  {
    private readonly F2mCurve m_outer;
    private readonly ulong[] m_table;
    private readonly int m_size;

    internal DefaultF2mLookupTable(F2mCurve outer, ulong[] table, int size)
    {
      this.m_outer = outer;
      this.m_table = table;
      this.m_size = size;
    }

    public override int Size => this.m_size;

    public override ECPoint Lookup(int index)
    {
      int length = (this.m_outer.m + 63 /*0x3F*/) / 64 /*0x40*/;
      ulong[] x = new ulong[length];
      ulong[] y = new ulong[length];
      int num1 = 0;
      for (int index1 = 0; index1 < this.m_size; ++index1)
      {
        ulong num2 = (ulong) ((index1 ^ index) - 1 >> 31 /*0x1F*/);
        for (int index2 = 0; index2 < length; ++index2)
        {
          x[index2] ^= this.m_table[num1 + index2] & num2;
          y[index2] ^= this.m_table[num1 + length + index2] & num2;
        }
        num1 += length * 2;
      }
      return this.CreatePoint(x, y);
    }

    public override ECPoint LookupVar(int index)
    {
      int length = (this.m_outer.m + 63 /*0x3F*/) / 64 /*0x40*/;
      ulong[] x = new ulong[length];
      ulong[] y = new ulong[length];
      int num = index * length * 2;
      for (int index1 = 0; index1 < length; ++index1)
      {
        x[index1] = this.m_table[num + index1];
        y[index1] = this.m_table[num + length + index1];
      }
      return this.CreatePoint(x, y);
    }

    private ECPoint CreatePoint(ulong[] x, ulong[] y)
    {
      int m = this.m_outer.m;
      int[] numArray;
      if (!this.m_outer.IsTrinomial())
        numArray = new int[3]
        {
          this.m_outer.k1,
          this.m_outer.k2,
          this.m_outer.k3
        };
      else
        numArray = new int[1]{ this.m_outer.k1 };
      int[] ks = numArray;
      return this.m_outer.CreateRawPoint((ECFieldElement) new F2mFieldElement(m, ks, new LongArray(x)), (ECFieldElement) new F2mFieldElement(m, ks, new LongArray(y)));
    }
  }
}
