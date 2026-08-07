// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Math.EC.Custom.Sec.SecP256R1Curve
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Math.Raw;
using Org.BouncyCastle.Security;
using Org.BouncyCastle.Utilities.Encoders;

#nullable disable
namespace Org.BouncyCastle.Math.EC.Custom.Sec;

internal class SecP256R1Curve : AbstractFpCurve
{
  public static readonly BigInteger q = SecP256R1FieldElement.Q;
  private const int SECP256R1_DEFAULT_COORDS = 2;
  private const int SECP256R1_FE_INTS = 8;
  private static readonly ECFieldElement[] SECP256R1_AFFINE_ZS = new ECFieldElement[1]
  {
    (ECFieldElement) new SecP256R1FieldElement(BigInteger.One)
  };
  protected readonly SecP256R1Point m_infinity;

  public SecP256R1Curve()
    : base(SecP256R1Curve.q, true)
  {
    this.m_infinity = new SecP256R1Point((ECCurve) this, (ECFieldElement) null, (ECFieldElement) null);
    this.m_a = this.FromBigInteger(new BigInteger(1, Hex.DecodeStrict("FFFFFFFF00000001000000000000000000000000FFFFFFFFFFFFFFFFFFFFFFFC")));
    this.m_b = this.FromBigInteger(new BigInteger(1, Hex.DecodeStrict("5AC635D8AA3A93E7B3EBBD55769886BC651D06B0CC53B0F63BCE3C3E27D2604B")));
    this.m_order = new BigInteger(1, Hex.DecodeStrict("FFFFFFFF00000000FFFFFFFFFFFFFFFFBCE6FAADA7179E84F3B9CAC2FC632551"));
    this.m_cofactor = BigInteger.One;
    this.m_coord = 2;
  }

  protected override ECCurve CloneCurve() => (ECCurve) new SecP256R1Curve();

  public override bool SupportsCoordinateSystem(int coord) => coord == 2;

  public virtual BigInteger Q => SecP256R1Curve.q;

  public override ECPoint Infinity => (ECPoint) this.m_infinity;

  public override int FieldSize => SecP256R1Curve.q.BitLength;

  public override ECFieldElement FromBigInteger(BigInteger x)
  {
    return (ECFieldElement) new SecP256R1FieldElement(x);
  }

  protected internal override ECPoint CreateRawPoint(ECFieldElement x, ECFieldElement y)
  {
    return (ECPoint) new SecP256R1Point((ECCurve) this, x, y);
  }

  protected internal override ECPoint CreateRawPoint(
    ECFieldElement x,
    ECFieldElement y,
    ECFieldElement[] zs)
  {
    return (ECPoint) new SecP256R1Point((ECCurve) this, x, y, zs);
  }

  public override ECLookupTable CreateCacheSafeLookupTable(ECPoint[] points, int off, int len)
  {
    uint[] numArray = new uint[len * 8 * 2];
    int zOff1 = 0;
    for (int index = 0; index < len; ++index)
    {
      ECPoint point = points[off + index];
      Nat256.Copy(((SecP256R1FieldElement) point.RawXCoord).x, 0, numArray, zOff1);
      int zOff2 = zOff1 + 8;
      Nat256.Copy(((SecP256R1FieldElement) point.RawYCoord).x, 0, numArray, zOff2);
      zOff1 = zOff2 + 8;
    }
    return (ECLookupTable) new SecP256R1Curve.SecP256R1LookupTable(this, numArray, len);
  }

  public override ECFieldElement RandomFieldElement(SecureRandom r)
  {
    uint[] numArray = Nat256.Create();
    SecP256R1Field.Random(r, numArray);
    return (ECFieldElement) new SecP256R1FieldElement(numArray);
  }

  public override ECFieldElement RandomFieldElementMult(SecureRandom r)
  {
    uint[] numArray = Nat256.Create();
    SecP256R1Field.RandomMult(r, numArray);
    return (ECFieldElement) new SecP256R1FieldElement(numArray);
  }

  private class SecP256R1LookupTable : AbstractECLookupTable
  {
    private readonly SecP256R1Curve m_outer;
    private readonly uint[] m_table;
    private readonly int m_size;

    internal SecP256R1LookupTable(SecP256R1Curve outer, uint[] table, int size)
    {
      this.m_outer = outer;
      this.m_table = table;
      this.m_size = size;
    }

    public override int Size => this.m_size;

    public override ECPoint Lookup(int index)
    {
      uint[] x = Nat256.Create();
      uint[] y = Nat256.Create();
      int num1 = 0;
      for (int index1 = 0; index1 < this.m_size; ++index1)
      {
        uint num2 = (uint) ((index1 ^ index) - 1 >> 31 /*0x1F*/);
        for (int index2 = 0; index2 < 8; ++index2)
        {
          x[index2] ^= this.m_table[num1 + index2] & num2;
          y[index2] ^= this.m_table[num1 + 8 + index2] & num2;
        }
        num1 += 16 /*0x10*/;
      }
      return this.CreatePoint(x, y);
    }

    public override ECPoint LookupVar(int index)
    {
      uint[] x = Nat256.Create();
      uint[] y = Nat256.Create();
      int num = index * 8 * 2;
      for (int index1 = 0; index1 < 8; ++index1)
      {
        x[index1] = this.m_table[num + index1];
        y[index1] = this.m_table[num + 8 + index1];
      }
      return this.CreatePoint(x, y);
    }

    private ECPoint CreatePoint(uint[] x, uint[] y)
    {
      return this.m_outer.CreateRawPoint((ECFieldElement) new SecP256R1FieldElement(x), (ECFieldElement) new SecP256R1FieldElement(y), SecP256R1Curve.SECP256R1_AFFINE_ZS);
    }
  }
}
