// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Math.EC.Custom.Sec.SecT113R1Curve
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Math.Raw;
using Org.BouncyCastle.Utilities.Encoders;

#nullable disable
namespace Org.BouncyCastle.Math.EC.Custom.Sec;

internal class SecT113R1Curve : AbstractF2mCurve
{
  private const int SECT113R1_DEFAULT_COORDS = 6;
  private const int SECT113R1_FE_LONGS = 2;
  private static readonly ECFieldElement[] SECT113R1_AFFINE_ZS = new ECFieldElement[1]
  {
    (ECFieldElement) new SecT113FieldElement(BigInteger.One)
  };
  protected readonly SecT113R1Point m_infinity;

  public SecT113R1Curve()
    : base(113, 9, 0, 0)
  {
    this.m_infinity = new SecT113R1Point((ECCurve) this, (ECFieldElement) null, (ECFieldElement) null);
    this.m_a = this.FromBigInteger(new BigInteger(1, Hex.DecodeStrict("003088250CA6E7C7FE649CE85820F7")));
    this.m_b = this.FromBigInteger(new BigInteger(1, Hex.DecodeStrict("00E8BEE4D3E2260744188BE0E9C723")));
    this.m_order = new BigInteger(1, Hex.DecodeStrict("0100000000000000D9CCEC8A39E56F"));
    this.m_cofactor = BigInteger.Two;
    this.m_coord = 6;
  }

  protected override ECCurve CloneCurve() => (ECCurve) new SecT113R1Curve();

  public override bool SupportsCoordinateSystem(int coord) => coord == 6;

  public override ECPoint Infinity => (ECPoint) this.m_infinity;

  public override int FieldSize => 113;

  public override ECFieldElement FromBigInteger(BigInteger x)
  {
    return (ECFieldElement) new SecT113FieldElement(x);
  }

  protected internal override ECPoint CreateRawPoint(ECFieldElement x, ECFieldElement y)
  {
    return (ECPoint) new SecT113R1Point((ECCurve) this, x, y);
  }

  protected internal override ECPoint CreateRawPoint(
    ECFieldElement x,
    ECFieldElement y,
    ECFieldElement[] zs)
  {
    return (ECPoint) new SecT113R1Point((ECCurve) this, x, y, zs);
  }

  public override bool IsKoblitz => false;

  public virtual int M => 113;

  public virtual bool IsTrinomial => true;

  public virtual int K1 => 9;

  public virtual int K2 => 0;

  public virtual int K3 => 0;

  public override ECLookupTable CreateCacheSafeLookupTable(ECPoint[] points, int off, int len)
  {
    ulong[] numArray = new ulong[len * 2 * 2];
    int zOff1 = 0;
    for (int index = 0; index < len; ++index)
    {
      ECPoint point = points[off + index];
      Nat128.Copy64(((SecT113FieldElement) point.RawXCoord).x, 0, numArray, zOff1);
      int zOff2 = zOff1 + 2;
      Nat128.Copy64(((SecT113FieldElement) point.RawYCoord).x, 0, numArray, zOff2);
      zOff1 = zOff2 + 2;
    }
    return (ECLookupTable) new SecT113R1Curve.SecT113R1LookupTable(this, numArray, len);
  }

  private class SecT113R1LookupTable : AbstractECLookupTable
  {
    private readonly SecT113R1Curve m_outer;
    private readonly ulong[] m_table;
    private readonly int m_size;

    internal SecT113R1LookupTable(SecT113R1Curve outer, ulong[] table, int size)
    {
      this.m_outer = outer;
      this.m_table = table;
      this.m_size = size;
    }

    public override int Size => this.m_size;

    public override ECPoint Lookup(int index)
    {
      ulong[] x = Nat128.Create64();
      ulong[] y = Nat128.Create64();
      int num1 = 0;
      for (int index1 = 0; index1 < this.m_size; ++index1)
      {
        ulong num2 = (ulong) ((index1 ^ index) - 1 >> 31 /*0x1F*/);
        for (int index2 = 0; index2 < 2; ++index2)
        {
          x[index2] ^= this.m_table[num1 + index2] & num2;
          y[index2] ^= this.m_table[num1 + 2 + index2] & num2;
        }
        num1 += 4;
      }
      return this.CreatePoint(x, y);
    }

    public override ECPoint LookupVar(int index)
    {
      ulong[] x = Nat128.Create64();
      ulong[] y = Nat128.Create64();
      int num = index * 2 * 2;
      for (int index1 = 0; index1 < 2; ++index1)
      {
        x[index1] = this.m_table[num + index1];
        y[index1] = this.m_table[num + 2 + index1];
      }
      return this.CreatePoint(x, y);
    }

    private ECPoint CreatePoint(ulong[] x, ulong[] y)
    {
      return this.m_outer.CreateRawPoint((ECFieldElement) new SecT113FieldElement(x), (ECFieldElement) new SecT113FieldElement(y), SecT113R1Curve.SECT113R1_AFFINE_ZS);
    }
  }
}
