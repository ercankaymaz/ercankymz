// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Math.EC.Custom.Sec.SecT571R1Curve
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Math.Raw;
using Org.BouncyCastle.Utilities.Encoders;

#nullable disable
namespace Org.BouncyCastle.Math.EC.Custom.Sec;

internal class SecT571R1Curve : AbstractF2mCurve
{
  private const int SECT571R1_DEFAULT_COORDS = 6;
  private const int SECT571R1_FE_LONGS = 9;
  private static readonly ECFieldElement[] SECT571R1_AFFINE_ZS = new ECFieldElement[1]
  {
    (ECFieldElement) new SecT571FieldElement(BigInteger.One)
  };
  protected readonly SecT571R1Point m_infinity;
  internal static readonly SecT571FieldElement SecT571R1_B = new SecT571FieldElement(new BigInteger(1, Hex.DecodeStrict("02F40E7E2221F295DE297117B7F3D62F5C6A97FFCB8CEFF1CD6BA8CE4A9A18AD84FFABBD8EFA59332BE7AD6756A66E294AFD185A78FF12AA520E4DE739BACA0C7FFEFF7F2955727A")));
  internal static readonly SecT571FieldElement SecT571R1_B_SQRT = (SecT571FieldElement) SecT571R1Curve.SecT571R1_B.Sqrt();

  public SecT571R1Curve()
    : base(571, 2, 5, 10)
  {
    this.m_infinity = new SecT571R1Point((ECCurve) this, (ECFieldElement) null, (ECFieldElement) null);
    this.m_a = this.FromBigInteger(BigInteger.One);
    this.m_b = (ECFieldElement) SecT571R1Curve.SecT571R1_B;
    this.m_order = new BigInteger(1, Hex.DecodeStrict("03FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFE661CE18FF55987308059B186823851EC7DD9CA1161DE93D5174D66E8382E9BB2FE84E47"));
    this.m_cofactor = BigInteger.Two;
    this.m_coord = 6;
  }

  protected override ECCurve CloneCurve() => (ECCurve) new SecT571R1Curve();

  public override bool SupportsCoordinateSystem(int coord) => coord == 6;

  public override ECPoint Infinity => (ECPoint) this.m_infinity;

  public override int FieldSize => 571;

  public override ECFieldElement FromBigInteger(BigInteger x)
  {
    return (ECFieldElement) new SecT571FieldElement(x);
  }

  protected internal override ECPoint CreateRawPoint(ECFieldElement x, ECFieldElement y)
  {
    return (ECPoint) new SecT571R1Point((ECCurve) this, x, y);
  }

  protected internal override ECPoint CreateRawPoint(
    ECFieldElement x,
    ECFieldElement y,
    ECFieldElement[] zs)
  {
    return (ECPoint) new SecT571R1Point((ECCurve) this, x, y, zs);
  }

  public override bool IsKoblitz => false;

  public virtual int M => 571;

  public virtual bool IsTrinomial => false;

  public virtual int K1 => 2;

  public virtual int K2 => 5;

  public virtual int K3 => 10;

  public override ECLookupTable CreateCacheSafeLookupTable(ECPoint[] points, int off, int len)
  {
    ulong[] numArray = new ulong[len * 9 * 2];
    int zOff1 = 0;
    for (int index = 0; index < len; ++index)
    {
      ECPoint point = points[off + index];
      Nat576.Copy64(((SecT571FieldElement) point.RawXCoord).x, 0, numArray, zOff1);
      int zOff2 = zOff1 + 9;
      Nat576.Copy64(((SecT571FieldElement) point.RawYCoord).x, 0, numArray, zOff2);
      zOff1 = zOff2 + 9;
    }
    return (ECLookupTable) new SecT571R1Curve.SecT571R1LookupTable(this, numArray, len);
  }

  private class SecT571R1LookupTable : AbstractECLookupTable
  {
    private readonly SecT571R1Curve m_outer;
    private readonly ulong[] m_table;
    private readonly int m_size;

    internal SecT571R1LookupTable(SecT571R1Curve outer, ulong[] table, int size)
    {
      this.m_outer = outer;
      this.m_table = table;
      this.m_size = size;
    }

    public override int Size => this.m_size;

    public override ECPoint Lookup(int index)
    {
      ulong[] x = Nat576.Create64();
      ulong[] y = Nat576.Create64();
      int num1 = 0;
      for (int index1 = 0; index1 < this.m_size; ++index1)
      {
        ulong num2 = (ulong) ((index1 ^ index) - 1 >> 31 /*0x1F*/);
        for (int index2 = 0; index2 < 9; ++index2)
        {
          x[index2] ^= this.m_table[num1 + index2] & num2;
          y[index2] ^= this.m_table[num1 + 9 + index2] & num2;
        }
        num1 += 18;
      }
      return this.CreatePoint(x, y);
    }

    public override ECPoint LookupVar(int index)
    {
      ulong[] x = Nat576.Create64();
      ulong[] y = Nat576.Create64();
      int num = index * 9 * 2;
      for (int index1 = 0; index1 < 9; ++index1)
      {
        x[index1] = this.m_table[num + index1];
        y[index1] = this.m_table[num + 9 + index1];
      }
      return this.CreatePoint(x, y);
    }

    private ECPoint CreatePoint(ulong[] x, ulong[] y)
    {
      return this.m_outer.CreateRawPoint((ECFieldElement) new SecT571FieldElement(x), (ECFieldElement) new SecT571FieldElement(y), SecT571R1Curve.SECT571R1_AFFINE_ZS);
    }
  }
}
