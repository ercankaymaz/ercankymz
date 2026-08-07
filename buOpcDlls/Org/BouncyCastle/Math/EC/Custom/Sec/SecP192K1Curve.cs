// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Math.EC.Custom.Sec.SecP192K1Curve
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Math.Raw;
using Org.BouncyCastle.Security;
using Org.BouncyCastle.Utilities.Encoders;

#nullable disable
namespace Org.BouncyCastle.Math.EC.Custom.Sec;

internal class SecP192K1Curve : AbstractFpCurve
{
  public static readonly BigInteger q = SecP192K1FieldElement.Q;
  private const int SECP192K1_DEFAULT_COORDS = 2;
  private const int SECP192K1_FE_INTS = 6;
  private static readonly ECFieldElement[] SECP192K1_AFFINE_ZS = new ECFieldElement[1]
  {
    (ECFieldElement) new SecP192K1FieldElement(BigInteger.One)
  };
  protected readonly SecP192K1Point m_infinity;

  public SecP192K1Curve()
    : base(SecP192K1Curve.q, true)
  {
    this.m_infinity = new SecP192K1Point((ECCurve) this, (ECFieldElement) null, (ECFieldElement) null);
    this.m_a = this.FromBigInteger(BigInteger.Zero);
    this.m_b = this.FromBigInteger(BigInteger.ValueOf(3L));
    this.m_order = new BigInteger(1, Hex.DecodeStrict("FFFFFFFFFFFFFFFFFFFFFFFE26F2FC170F69466A74DEFD8D"));
    this.m_cofactor = BigInteger.One;
    this.m_coord = 2;
  }

  protected override ECCurve CloneCurve() => (ECCurve) new SecP192K1Curve();

  public override bool SupportsCoordinateSystem(int coord) => coord == 2;

  public virtual BigInteger Q => SecP192K1Curve.q;

  public override ECPoint Infinity => (ECPoint) this.m_infinity;

  public override int FieldSize => SecP192K1Curve.q.BitLength;

  public override ECFieldElement FromBigInteger(BigInteger x)
  {
    return (ECFieldElement) new SecP192K1FieldElement(x);
  }

  protected internal override ECPoint CreateRawPoint(ECFieldElement x, ECFieldElement y)
  {
    return (ECPoint) new SecP192K1Point((ECCurve) this, x, y);
  }

  protected internal override ECPoint CreateRawPoint(
    ECFieldElement x,
    ECFieldElement y,
    ECFieldElement[] zs)
  {
    return (ECPoint) new SecP192K1Point((ECCurve) this, x, y, zs);
  }

  public override ECLookupTable CreateCacheSafeLookupTable(ECPoint[] points, int off, int len)
  {
    uint[] numArray = new uint[len * 6 * 2];
    int zOff1 = 0;
    for (int index = 0; index < len; ++index)
    {
      ECPoint point = points[off + index];
      Nat192.Copy(((SecP192K1FieldElement) point.RawXCoord).x, 0, numArray, zOff1);
      int zOff2 = zOff1 + 6;
      Nat192.Copy(((SecP192K1FieldElement) point.RawYCoord).x, 0, numArray, zOff2);
      zOff1 = zOff2 + 6;
    }
    return (ECLookupTable) new SecP192K1Curve.SecP192K1LookupTable(this, numArray, len);
  }

  public override ECFieldElement RandomFieldElement(SecureRandom r)
  {
    uint[] numArray = Nat192.Create();
    SecP192K1Field.Random(r, numArray);
    return (ECFieldElement) new SecP192K1FieldElement(numArray);
  }

  public override ECFieldElement RandomFieldElementMult(SecureRandom r)
  {
    uint[] numArray = Nat192.Create();
    SecP192K1Field.RandomMult(r, numArray);
    return (ECFieldElement) new SecP192K1FieldElement(numArray);
  }

  private class SecP192K1LookupTable : AbstractECLookupTable
  {
    private readonly SecP192K1Curve m_outer;
    private readonly uint[] m_table;
    private readonly int m_size;

    internal SecP192K1LookupTable(SecP192K1Curve outer, uint[] table, int size)
    {
      this.m_outer = outer;
      this.m_table = table;
      this.m_size = size;
    }

    public override int Size => this.m_size;

    public override ECPoint Lookup(int index)
    {
      uint[] x = Nat192.Create();
      uint[] y = Nat192.Create();
      int num1 = 0;
      for (int index1 = 0; index1 < this.m_size; ++index1)
      {
        uint num2 = (uint) ((index1 ^ index) - 1 >> 31 /*0x1F*/);
        for (int index2 = 0; index2 < 6; ++index2)
        {
          x[index2] ^= this.m_table[num1 + index2] & num2;
          y[index2] ^= this.m_table[num1 + 6 + index2] & num2;
        }
        num1 += 12;
      }
      return this.CreatePoint(x, y);
    }

    public override ECPoint LookupVar(int index)
    {
      uint[] x = Nat192.Create();
      uint[] y = Nat192.Create();
      int num = index * 6 * 2;
      for (int index1 = 0; index1 < 6; ++index1)
      {
        x[index1] = this.m_table[num + index1];
        y[index1] = this.m_table[num + 6 + index1];
      }
      return this.CreatePoint(x, y);
    }

    private ECPoint CreatePoint(uint[] x, uint[] y)
    {
      return this.m_outer.CreateRawPoint((ECFieldElement) new SecP192K1FieldElement(x), (ECFieldElement) new SecP192K1FieldElement(y), SecP192K1Curve.SECP192K1_AFFINE_ZS);
    }
  }
}
