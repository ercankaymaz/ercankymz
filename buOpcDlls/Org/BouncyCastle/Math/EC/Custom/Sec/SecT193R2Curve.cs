// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Math.EC.Custom.Sec.SecT193R2Curve
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Math.Raw;
using Org.BouncyCastle.Utilities.Encoders;

#nullable disable
namespace Org.BouncyCastle.Math.EC.Custom.Sec;

internal class SecT193R2Curve : AbstractF2mCurve
{
  private const int SECT193R2_DEFAULT_COORDS = 6;
  private const int SECT193R2_FE_LONGS = 4;
  private static readonly ECFieldElement[] SECT193R2_AFFINE_ZS = new ECFieldElement[1]
  {
    (ECFieldElement) new SecT193FieldElement(BigInteger.One)
  };
  protected readonly SecT193R2Point m_infinity;

  public SecT193R2Curve()
    : base(193, 15, 0, 0)
  {
    this.m_infinity = new SecT193R2Point((ECCurve) this, (ECFieldElement) null, (ECFieldElement) null);
    this.m_a = this.FromBigInteger(new BigInteger(1, Hex.DecodeStrict("0163F35A5137C2CE3EA6ED8667190B0BC43ECD69977702709B")));
    this.m_b = this.FromBigInteger(new BigInteger(1, Hex.DecodeStrict("00C9BB9E8927D4D64C377E2AB2856A5B16E3EFB7F61D4316AE")));
    this.m_order = new BigInteger(1, Hex.DecodeStrict("010000000000000000000000015AAB561B005413CCD4EE99D5"));
    this.m_cofactor = BigInteger.Two;
    this.m_coord = 6;
  }

  protected override ECCurve CloneCurve() => (ECCurve) new SecT193R2Curve();

  public override bool SupportsCoordinateSystem(int coord) => coord == 6;

  public override ECPoint Infinity => (ECPoint) this.m_infinity;

  public override int FieldSize => 193;

  public override ECFieldElement FromBigInteger(BigInteger x)
  {
    return (ECFieldElement) new SecT193FieldElement(x);
  }

  protected internal override ECPoint CreateRawPoint(ECFieldElement x, ECFieldElement y)
  {
    return (ECPoint) new SecT193R2Point((ECCurve) this, x, y);
  }

  protected internal override ECPoint CreateRawPoint(
    ECFieldElement x,
    ECFieldElement y,
    ECFieldElement[] zs)
  {
    return (ECPoint) new SecT193R2Point((ECCurve) this, x, y, zs);
  }

  public override bool IsKoblitz => false;

  public virtual int M => 193;

  public virtual bool IsTrinomial => true;

  public virtual int K1 => 15;

  public virtual int K2 => 0;

  public virtual int K3 => 0;

  public override ECLookupTable CreateCacheSafeLookupTable(ECPoint[] points, int off, int len)
  {
    ulong[] numArray = new ulong[len * 4 * 2];
    int zOff1 = 0;
    for (int index = 0; index < len; ++index)
    {
      ECPoint point = points[off + index];
      Nat256.Copy64(((SecT193FieldElement) point.RawXCoord).x, 0, numArray, zOff1);
      int zOff2 = zOff1 + 4;
      Nat256.Copy64(((SecT193FieldElement) point.RawYCoord).x, 0, numArray, zOff2);
      zOff1 = zOff2 + 4;
    }
    return (ECLookupTable) new SecT193R2Curve.SecT193R2LookupTable(this, numArray, len);
  }

  private class SecT193R2LookupTable : AbstractECLookupTable
  {
    private readonly SecT193R2Curve m_outer;
    private readonly ulong[] m_table;
    private readonly int m_size;

    internal SecT193R2LookupTable(SecT193R2Curve outer, ulong[] table, int size)
    {
      this.m_outer = outer;
      this.m_table = table;
      this.m_size = size;
    }

    public override int Size => this.m_size;

    public override ECPoint Lookup(int index)
    {
      ulong[] x = Nat256.Create64();
      ulong[] y = Nat256.Create64();
      int num1 = 0;
      for (int index1 = 0; index1 < this.m_size; ++index1)
      {
        ulong num2 = (ulong) ((index1 ^ index) - 1 >> 31 /*0x1F*/);
        for (int index2 = 0; index2 < 4; ++index2)
        {
          x[index2] ^= this.m_table[num1 + index2] & num2;
          y[index2] ^= this.m_table[num1 + 4 + index2] & num2;
        }
        num1 += 8;
      }
      return this.CreatePoint(x, y);
    }

    public override ECPoint LookupVar(int index)
    {
      ulong[] x = Nat256.Create64();
      ulong[] y = Nat256.Create64();
      int num = index * 4 * 2;
      for (int index1 = 0; index1 < 4; ++index1)
      {
        x[index1] = this.m_table[num + index1];
        y[index1] = this.m_table[num + 4 + index1];
      }
      return this.CreatePoint(x, y);
    }

    private ECPoint CreatePoint(ulong[] x, ulong[] y)
    {
      return this.m_outer.CreateRawPoint((ECFieldElement) new SecT193FieldElement(x), (ECFieldElement) new SecT193FieldElement(y), SecT193R2Curve.SECT193R2_AFFINE_ZS);
    }
  }
}
