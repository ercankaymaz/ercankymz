// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Math.EC.Custom.Sec.SecP224R1Curve
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Math.Raw;
using Org.BouncyCastle.Security;
using Org.BouncyCastle.Utilities.Encoders;

#nullable disable
namespace Org.BouncyCastle.Math.EC.Custom.Sec;

internal class SecP224R1Curve : AbstractFpCurve
{
  public static readonly BigInteger q = SecP224R1FieldElement.Q;
  private const int SECP224R1_DEFAULT_COORDS = 2;
  private const int SECP224R1_FE_INTS = 7;
  private static readonly ECFieldElement[] SECP224R1_AFFINE_ZS = new ECFieldElement[1]
  {
    (ECFieldElement) new SecP224R1FieldElement(BigInteger.One)
  };
  protected readonly SecP224R1Point m_infinity;

  public SecP224R1Curve()
    : base(SecP224R1Curve.q, true)
  {
    this.m_infinity = new SecP224R1Point((ECCurve) this, (ECFieldElement) null, (ECFieldElement) null);
    this.m_a = this.FromBigInteger(new BigInteger(1, Hex.DecodeStrict("FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFEFFFFFFFFFFFFFFFFFFFFFFFE")));
    this.m_b = this.FromBigInteger(new BigInteger(1, Hex.DecodeStrict("B4050A850C04B3ABF54132565044B0B7D7BFD8BA270B39432355FFB4")));
    this.m_order = new BigInteger(1, Hex.DecodeStrict("FFFFFFFFFFFFFFFFFFFFFFFFFFFF16A2E0B8F03E13DD29455C5C2A3D"));
    this.m_cofactor = BigInteger.One;
    this.m_coord = 2;
  }

  protected override ECCurve CloneCurve() => (ECCurve) new SecP224R1Curve();

  public override bool SupportsCoordinateSystem(int coord) => coord == 2;

  public virtual BigInteger Q => SecP224R1Curve.q;

  public override ECPoint Infinity => (ECPoint) this.m_infinity;

  public override int FieldSize => SecP224R1Curve.q.BitLength;

  public override ECFieldElement FromBigInteger(BigInteger x)
  {
    return (ECFieldElement) new SecP224R1FieldElement(x);
  }

  protected internal override ECPoint CreateRawPoint(ECFieldElement x, ECFieldElement y)
  {
    return (ECPoint) new SecP224R1Point((ECCurve) this, x, y);
  }

  protected internal override ECPoint CreateRawPoint(
    ECFieldElement x,
    ECFieldElement y,
    ECFieldElement[] zs)
  {
    return (ECPoint) new SecP224R1Point((ECCurve) this, x, y, zs);
  }

  public override ECLookupTable CreateCacheSafeLookupTable(ECPoint[] points, int off, int len)
  {
    uint[] numArray = new uint[len * 7 * 2];
    int zOff1 = 0;
    for (int index = 0; index < len; ++index)
    {
      ECPoint point = points[off + index];
      Nat224.Copy(((SecP224R1FieldElement) point.RawXCoord).x, 0, numArray, zOff1);
      int zOff2 = zOff1 + 7;
      Nat224.Copy(((SecP224R1FieldElement) point.RawYCoord).x, 0, numArray, zOff2);
      zOff1 = zOff2 + 7;
    }
    return (ECLookupTable) new SecP224R1Curve.SecP224R1LookupTable(this, numArray, len);
  }

  public override ECFieldElement RandomFieldElement(SecureRandom r)
  {
    uint[] numArray = Nat224.Create();
    SecP224R1Field.Random(r, numArray);
    return (ECFieldElement) new SecP224R1FieldElement(numArray);
  }

  public override ECFieldElement RandomFieldElementMult(SecureRandom r)
  {
    uint[] numArray = Nat224.Create();
    SecP224R1Field.RandomMult(r, numArray);
    return (ECFieldElement) new SecP224R1FieldElement(numArray);
  }

  private class SecP224R1LookupTable : AbstractECLookupTable
  {
    private readonly SecP224R1Curve m_outer;
    private readonly uint[] m_table;
    private readonly int m_size;

    internal SecP224R1LookupTable(SecP224R1Curve outer, uint[] table, int size)
    {
      this.m_outer = outer;
      this.m_table = table;
      this.m_size = size;
    }

    public override int Size => this.m_size;

    public override ECPoint Lookup(int index)
    {
      uint[] x = Nat224.Create();
      uint[] y = Nat224.Create();
      int num1 = 0;
      for (int index1 = 0; index1 < this.m_size; ++index1)
      {
        uint num2 = (uint) ((index1 ^ index) - 1 >> 31 /*0x1F*/);
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
      uint[] x = Nat224.Create();
      uint[] y = Nat224.Create();
      int num = index * 7 * 2;
      for (int index1 = 0; index1 < 7; ++index1)
      {
        x[index1] = this.m_table[num + index1];
        y[index1] = this.m_table[num + 7 + index1];
      }
      return this.CreatePoint(x, y);
    }

    private ECPoint CreatePoint(uint[] x, uint[] y)
    {
      return this.m_outer.CreateRawPoint((ECFieldElement) new SecP224R1FieldElement(x), (ECFieldElement) new SecP224R1FieldElement(y), SecP224R1Curve.SECP224R1_AFFINE_ZS);
    }
  }
}
