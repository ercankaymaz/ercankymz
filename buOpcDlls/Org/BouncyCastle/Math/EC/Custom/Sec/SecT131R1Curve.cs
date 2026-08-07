// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Math.EC.Custom.Sec.SecT131R1Curve
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Math.Raw;
using Org.BouncyCastle.Utilities.Encoders;

#nullable disable
namespace Org.BouncyCastle.Math.EC.Custom.Sec;

internal class SecT131R1Curve : AbstractF2mCurve
{
  private const int SECT131R1_DEFAULT_COORDS = 6;
  private const int SECT131R1_FE_LONGS = 3;
  private static readonly ECFieldElement[] SECT131R1_AFFINE_ZS = new ECFieldElement[1]
  {
    (ECFieldElement) new SecT131FieldElement(BigInteger.One)
  };
  protected readonly SecT131R1Point m_infinity;

  public SecT131R1Curve()
    : base(131, 2, 3, 8)
  {
    this.m_infinity = new SecT131R1Point((ECCurve) this, (ECFieldElement) null, (ECFieldElement) null);
    this.m_a = this.FromBigInteger(new BigInteger(1, Hex.DecodeStrict("07A11B09A76B562144418FF3FF8C2570B8")));
    this.m_b = this.FromBigInteger(new BigInteger(1, Hex.DecodeStrict("0217C05610884B63B9C6C7291678F9D341")));
    this.m_order = new BigInteger(1, Hex.DecodeStrict("0400000000000000023123953A9464B54D"));
    this.m_cofactor = BigInteger.Two;
    this.m_coord = 6;
  }

  protected override ECCurve CloneCurve() => (ECCurve) new SecT131R1Curve();

  public override bool SupportsCoordinateSystem(int coord) => coord == 6;

  public override ECPoint Infinity => (ECPoint) this.m_infinity;

  public override int FieldSize => 131;

  public override ECFieldElement FromBigInteger(BigInteger x)
  {
    return (ECFieldElement) new SecT131FieldElement(x);
  }

  protected internal override ECPoint CreateRawPoint(ECFieldElement x, ECFieldElement y)
  {
    return (ECPoint) new SecT131R1Point((ECCurve) this, x, y);
  }

  protected internal override ECPoint CreateRawPoint(
    ECFieldElement x,
    ECFieldElement y,
    ECFieldElement[] zs)
  {
    return (ECPoint) new SecT131R1Point((ECCurve) this, x, y, zs);
  }

  public override bool IsKoblitz => false;

  public virtual int M => 131;

  public virtual bool IsTrinomial => false;

  public virtual int K1 => 2;

  public virtual int K2 => 3;

  public virtual int K3 => 8;

  public override ECLookupTable CreateCacheSafeLookupTable(ECPoint[] points, int off, int len)
  {
    ulong[] numArray = new ulong[len * 3 * 2];
    int zOff1 = 0;
    for (int index = 0; index < len; ++index)
    {
      ECPoint point = points[off + index];
      Nat192.Copy64(((SecT131FieldElement) point.RawXCoord).x, 0, numArray, zOff1);
      int zOff2 = zOff1 + 3;
      Nat192.Copy64(((SecT131FieldElement) point.RawYCoord).x, 0, numArray, zOff2);
      zOff1 = zOff2 + 3;
    }
    return (ECLookupTable) new SecT131R1Curve.SecT131R1LookupTable(this, numArray, len);
  }

  private class SecT131R1LookupTable : AbstractECLookupTable
  {
    private readonly SecT131R1Curve m_outer;
    private readonly ulong[] m_table;
    private readonly int m_size;

    internal SecT131R1LookupTable(SecT131R1Curve outer, ulong[] table, int size)
    {
      this.m_outer = outer;
      this.m_table = table;
      this.m_size = size;
    }

    public override int Size => this.m_size;

    public override ECPoint Lookup(int index)
    {
      ulong[] x = Nat192.Create64();
      ulong[] y = Nat192.Create64();
      int num1 = 0;
      for (int index1 = 0; index1 < this.m_size; ++index1)
      {
        ulong num2 = (ulong) ((index1 ^ index) - 1 >> 31 /*0x1F*/);
        for (int index2 = 0; index2 < 3; ++index2)
        {
          x[index2] ^= this.m_table[num1 + index2] & num2;
          y[index2] ^= this.m_table[num1 + 3 + index2] & num2;
        }
        num1 += 6;
      }
      return this.CreatePoint(x, y);
    }

    public override ECPoint LookupVar(int index)
    {
      ulong[] x = Nat192.Create64();
      ulong[] y = Nat192.Create64();
      int num = index * 3 * 2;
      for (int index1 = 0; index1 < 3; ++index1)
      {
        x[index1] = this.m_table[num + index1];
        y[index1] = this.m_table[num + 3 + index1];
      }
      return this.CreatePoint(x, y);
    }

    private ECPoint CreatePoint(ulong[] x, ulong[] y)
    {
      return this.m_outer.CreateRawPoint((ECFieldElement) new SecT131FieldElement(x), (ECFieldElement) new SecT131FieldElement(y), SecT131R1Curve.SECT131R1_AFFINE_ZS);
    }
  }
}
