// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Math.EC.Custom.Sec.SecP384R1Curve
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Math.Raw;
using Org.BouncyCastle.Security;
using Org.BouncyCastle.Utilities.Encoders;

#nullable disable
namespace Org.BouncyCastle.Math.EC.Custom.Sec;

internal class SecP384R1Curve : AbstractFpCurve
{
  public static readonly BigInteger q = SecP384R1FieldElement.Q;
  private const int SECP384R1_DEFAULT_COORDS = 2;
  private const int SECP384R1_FE_INTS = 12;
  private static readonly ECFieldElement[] SECP384R1_AFFINE_ZS = new ECFieldElement[1]
  {
    (ECFieldElement) new SecP384R1FieldElement(BigInteger.One)
  };
  protected readonly SecP384R1Point m_infinity;

  public SecP384R1Curve()
    : base(SecP384R1Curve.q, true)
  {
    this.m_infinity = new SecP384R1Point((ECCurve) this, (ECFieldElement) null, (ECFieldElement) null);
    this.m_a = this.FromBigInteger(new BigInteger(1, Hex.DecodeStrict("FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFEFFFFFFFF0000000000000000FFFFFFFC")));
    this.m_b = this.FromBigInteger(new BigInteger(1, Hex.DecodeStrict("B3312FA7E23EE7E4988E056BE3F82D19181D9C6EFE8141120314088F5013875AC656398D8A2ED19D2A85C8EDD3EC2AEF")));
    this.m_order = new BigInteger(1, Hex.DecodeStrict("FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFC7634D81F4372DDF581A0DB248B0A77AECEC196ACCC52973"));
    this.m_cofactor = BigInteger.One;
    this.m_coord = 2;
  }

  protected override ECCurve CloneCurve() => (ECCurve) new SecP384R1Curve();

  public override bool SupportsCoordinateSystem(int coord) => coord == 2;

  public virtual BigInteger Q => SecP384R1Curve.q;

  public override ECPoint Infinity => (ECPoint) this.m_infinity;

  public override int FieldSize => SecP384R1Curve.q.BitLength;

  public override ECFieldElement FromBigInteger(BigInteger x)
  {
    return (ECFieldElement) new SecP384R1FieldElement(x);
  }

  protected internal override ECPoint CreateRawPoint(ECFieldElement x, ECFieldElement y)
  {
    return (ECPoint) new SecP384R1Point((ECCurve) this, x, y);
  }

  protected internal override ECPoint CreateRawPoint(
    ECFieldElement x,
    ECFieldElement y,
    ECFieldElement[] zs)
  {
    return (ECPoint) new SecP384R1Point((ECCurve) this, x, y, zs);
  }

  public override ECLookupTable CreateCacheSafeLookupTable(ECPoint[] points, int off, int len)
  {
    uint[] numArray = new uint[len * 12 * 2];
    int zOff1 = 0;
    for (int index = 0; index < len; ++index)
    {
      ECPoint point = points[off + index];
      Nat.Copy(12, ((SecP384R1FieldElement) point.RawXCoord).x, 0, numArray, zOff1);
      int zOff2 = zOff1 + 12;
      Nat.Copy(12, ((SecP384R1FieldElement) point.RawYCoord).x, 0, numArray, zOff2);
      zOff1 = zOff2 + 12;
    }
    return (ECLookupTable) new SecP384R1Curve.SecP384R1LookupTable(this, numArray, len);
  }

  public override ECFieldElement RandomFieldElement(SecureRandom r)
  {
    uint[] numArray = Nat.Create(12);
    SecP384R1Field.Random(r, numArray);
    return (ECFieldElement) new SecP384R1FieldElement(numArray);
  }

  public override ECFieldElement RandomFieldElementMult(SecureRandom r)
  {
    uint[] numArray = Nat.Create(12);
    SecP384R1Field.RandomMult(r, numArray);
    return (ECFieldElement) new SecP384R1FieldElement(numArray);
  }

  private class SecP384R1LookupTable : AbstractECLookupTable
  {
    private readonly SecP384R1Curve m_outer;
    private readonly uint[] m_table;
    private readonly int m_size;

    internal SecP384R1LookupTable(SecP384R1Curve outer, uint[] table, int size)
    {
      this.m_outer = outer;
      this.m_table = table;
      this.m_size = size;
    }

    public override int Size => this.m_size;

    public override ECPoint Lookup(int index)
    {
      uint[] x = Nat.Create(12);
      uint[] y = Nat.Create(12);
      int num1 = 0;
      for (int index1 = 0; index1 < this.m_size; ++index1)
      {
        uint num2 = (uint) ((index1 ^ index) - 1 >> 31 /*0x1F*/);
        for (int index2 = 0; index2 < 12; ++index2)
        {
          x[index2] ^= this.m_table[num1 + index2] & num2;
          y[index2] ^= this.m_table[num1 + 12 + index2] & num2;
        }
        num1 += 24;
      }
      return this.CreatePoint(x, y);
    }

    public override ECPoint LookupVar(int index)
    {
      uint[] x = Nat.Create(12);
      uint[] y = Nat.Create(12);
      int num = index * 12 * 2;
      for (int index1 = 0; index1 < 12; ++index1)
      {
        x[index1] = this.m_table[num + index1];
        y[index1] = this.m_table[num + 12 + index1];
      }
      return this.CreatePoint(x, y);
    }

    private ECPoint CreatePoint(uint[] x, uint[] y)
    {
      return this.m_outer.CreateRawPoint((ECFieldElement) new SecP384R1FieldElement(x), (ECFieldElement) new SecP384R1FieldElement(y), SecP384R1Curve.SECP384R1_AFFINE_ZS);
    }
  }
}
