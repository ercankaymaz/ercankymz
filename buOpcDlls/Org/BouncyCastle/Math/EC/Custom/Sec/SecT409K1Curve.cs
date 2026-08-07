// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Math.EC.Custom.Sec.SecT409K1Curve
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Math.EC.Multiplier;
using Org.BouncyCastle.Math.Raw;
using Org.BouncyCastle.Utilities.Encoders;

#nullable disable
namespace Org.BouncyCastle.Math.EC.Custom.Sec;

internal class SecT409K1Curve : AbstractF2mCurve
{
  private const int SECT409K1_DEFAULT_COORDS = 6;
  private const int SECT409K1_FE_LONGS = 7;
  private static readonly ECFieldElement[] SECT409K1_AFFINE_ZS = new ECFieldElement[1]
  {
    (ECFieldElement) new SecT409FieldElement(BigInteger.One)
  };
  protected readonly SecT409K1Point m_infinity;

  public SecT409K1Curve()
    : base(409, 87, 0, 0)
  {
    this.m_infinity = new SecT409K1Point((ECCurve) this, (ECFieldElement) null, (ECFieldElement) null);
    this.m_a = this.FromBigInteger(BigInteger.Zero);
    this.m_b = this.FromBigInteger(BigInteger.One);
    this.m_order = new BigInteger(1, Hex.DecodeStrict("7FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFE5F83B2D4EA20400EC4557D5ED3E3E7CA5B4B5C83B8E01E5FCF"));
    this.m_cofactor = BigInteger.ValueOf(4L);
    this.m_coord = 6;
  }

  protected override ECCurve CloneCurve() => (ECCurve) new SecT409K1Curve();

  public override bool SupportsCoordinateSystem(int coord) => coord == 6;

  protected override ECMultiplier CreateDefaultMultiplier()
  {
    return (ECMultiplier) new WTauNafMultiplier();
  }

  public override ECPoint Infinity => (ECPoint) this.m_infinity;

  public override int FieldSize => 409;

  public override ECFieldElement FromBigInteger(BigInteger x)
  {
    return (ECFieldElement) new SecT409FieldElement(x);
  }

  protected internal override ECPoint CreateRawPoint(ECFieldElement x, ECFieldElement y)
  {
    return (ECPoint) new SecT409K1Point((ECCurve) this, x, y);
  }

  protected internal override ECPoint CreateRawPoint(
    ECFieldElement x,
    ECFieldElement y,
    ECFieldElement[] zs)
  {
    return (ECPoint) new SecT409K1Point((ECCurve) this, x, y, zs);
  }

  public override bool IsKoblitz => true;

  public virtual int M => 409;

  public virtual bool IsTrinomial => true;

  public virtual int K1 => 87;

  public virtual int K2 => 0;

  public virtual int K3 => 0;

  public override ECLookupTable CreateCacheSafeLookupTable(ECPoint[] points, int off, int len)
  {
    ulong[] numArray = new ulong[len * 7 * 2];
    int zOff1 = 0;
    for (int index = 0; index < len; ++index)
    {
      ECPoint point = points[off + index];
      Nat448.Copy64(((SecT409FieldElement) point.RawXCoord).x, 0, numArray, zOff1);
      int zOff2 = zOff1 + 7;
      Nat448.Copy64(((SecT409FieldElement) point.RawYCoord).x, 0, numArray, zOff2);
      zOff1 = zOff2 + 7;
    }
    return (ECLookupTable) new SecT409K1Curve.SecT409K1LookupTable(this, numArray, len);
  }

  private class SecT409K1LookupTable : AbstractECLookupTable
  {
    private readonly SecT409K1Curve m_outer;
    private readonly ulong[] m_table;
    private readonly int m_size;

    internal SecT409K1LookupTable(SecT409K1Curve outer, ulong[] table, int size)
    {
      this.m_outer = outer;
      this.m_table = table;
      this.m_size = size;
    }

    public override int Size => this.m_size;

    public override ECPoint Lookup(int index)
    {
      ulong[] x = Nat448.Create64();
      ulong[] y = Nat448.Create64();
      int num1 = 0;
      for (int index1 = 0; index1 < this.m_size; ++index1)
      {
        ulong num2 = (ulong) ((index1 ^ index) - 1 >> 31 /*0x1F*/);
        for (int index2 = 0; index2 < 7; ++index2)
        {
          x[index2] ^= this.m_table[num1 + index2] & num2;
          y[index2] ^= this.m_table[num1 + 7 + index2] & num2;
        }
        num1 += 14;
      }
      return this.CreatePoint(x, y);
    }

    public override ECPoint LookupVar(int index)
    {
      ulong[] x = Nat448.Create64();
      ulong[] y = Nat448.Create64();
      int num = index * 7 * 2;
      for (int index1 = 0; index1 < 7; ++index1)
      {
        x[index1] = this.m_table[num + index1];
        y[index1] = this.m_table[num + 7 + index1];
      }
      return this.CreatePoint(x, y);
    }

    private ECPoint CreatePoint(ulong[] x, ulong[] y)
    {
      return this.m_outer.CreateRawPoint((ECFieldElement) new SecT409FieldElement(x), (ECFieldElement) new SecT409FieldElement(y), SecT409K1Curve.SECT409K1_AFFINE_ZS);
    }
  }
}
