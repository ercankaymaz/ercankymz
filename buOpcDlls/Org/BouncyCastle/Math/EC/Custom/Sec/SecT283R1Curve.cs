// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Math.EC.Custom.Sec.SecT283R1Curve
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Math.Raw;
using Org.BouncyCastle.Utilities.Encoders;

#nullable disable
namespace Org.BouncyCastle.Math.EC.Custom.Sec;

internal class SecT283R1Curve : AbstractF2mCurve
{
  private const int SECT283R1_DEFAULT_COORDS = 6;
  private const int SECT283R1_FE_LONGS = 5;
  private static readonly ECFieldElement[] SECT283R1_AFFINE_ZS = new ECFieldElement[1]
  {
    (ECFieldElement) new SecT283FieldElement(BigInteger.One)
  };
  protected readonly SecT283R1Point m_infinity;

  public SecT283R1Curve()
    : base(283, 5, 7, 12)
  {
    this.m_infinity = new SecT283R1Point((ECCurve) this, (ECFieldElement) null, (ECFieldElement) null);
    this.m_a = this.FromBigInteger(BigInteger.One);
    this.m_b = this.FromBigInteger(new BigInteger(1, Hex.DecodeStrict("027B680AC8B8596DA5A4AF8A19A0303FCA97FD7645309FA2A581485AF6263E313B79A2F5")));
    this.m_order = new BigInteger(1, Hex.DecodeStrict("03FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFEF90399660FC938A90165B042A7CEFADB307"));
    this.m_cofactor = BigInteger.Two;
    this.m_coord = 6;
  }

  protected override ECCurve CloneCurve() => (ECCurve) new SecT283R1Curve();

  public override bool SupportsCoordinateSystem(int coord) => coord == 6;

  public override ECPoint Infinity => (ECPoint) this.m_infinity;

  public override int FieldSize => 283;

  public override ECFieldElement FromBigInteger(BigInteger x)
  {
    return (ECFieldElement) new SecT283FieldElement(x);
  }

  protected internal override ECPoint CreateRawPoint(ECFieldElement x, ECFieldElement y)
  {
    return (ECPoint) new SecT283R1Point((ECCurve) this, x, y);
  }

  protected internal override ECPoint CreateRawPoint(
    ECFieldElement x,
    ECFieldElement y,
    ECFieldElement[] zs)
  {
    return (ECPoint) new SecT283R1Point((ECCurve) this, x, y, zs);
  }

  public override bool IsKoblitz => false;

  public virtual int M => 283;

  public virtual bool IsTrinomial => false;

  public virtual int K1 => 5;

  public virtual int K2 => 7;

  public virtual int K3 => 12;

  public override ECLookupTable CreateCacheSafeLookupTable(ECPoint[] points, int off, int len)
  {
    ulong[] numArray = new ulong[len * 5 * 2];
    int zOff1 = 0;
    for (int index = 0; index < len; ++index)
    {
      ECPoint point = points[off + index];
      Nat320.Copy64(((SecT283FieldElement) point.RawXCoord).x, 0, numArray, zOff1);
      int zOff2 = zOff1 + 5;
      Nat320.Copy64(((SecT283FieldElement) point.RawYCoord).x, 0, numArray, zOff2);
      zOff1 = zOff2 + 5;
    }
    return (ECLookupTable) new SecT283R1Curve.SecT283R1LookupTable(this, numArray, len);
  }

  private class SecT283R1LookupTable : AbstractECLookupTable
  {
    private readonly SecT283R1Curve m_outer;
    private readonly ulong[] m_table;
    private readonly int m_size;

    internal SecT283R1LookupTable(SecT283R1Curve outer, ulong[] table, int size)
    {
      this.m_outer = outer;
      this.m_table = table;
      this.m_size = size;
    }

    public override int Size => this.m_size;

    public override ECPoint Lookup(int index)
    {
      ulong[] x = Nat320.Create64();
      ulong[] y = Nat320.Create64();
      int num1 = 0;
      for (int index1 = 0; index1 < this.m_size; ++index1)
      {
        ulong num2 = (ulong) ((index1 ^ index) - 1 >> 31 /*0x1F*/);
        for (int index2 = 0; index2 < 5; ++index2)
        {
          x[index2] ^= this.m_table[num1 + index2] & num2;
          y[index2] ^= this.m_table[num1 + 5 + index2] & num2;
        }
        num1 += 10;
      }
      return this.CreatePoint(x, y);
    }

    public override ECPoint LookupVar(int index)
    {
      ulong[] x = Nat320.Create64();
      ulong[] y = Nat320.Create64();
      int num = index * 5 * 2;
      for (int index1 = 0; index1 < 5; ++index1)
      {
        x[index1] = this.m_table[num + index1];
        y[index1] = this.m_table[num + 5 + index1];
      }
      return this.CreatePoint(x, y);
    }

    private ECPoint CreatePoint(ulong[] x, ulong[] y)
    {
      return this.m_outer.CreateRawPoint((ECFieldElement) new SecT283FieldElement(x), (ECFieldElement) new SecT283FieldElement(y), SecT283R1Curve.SECT283R1_AFFINE_ZS);
    }
  }
}
