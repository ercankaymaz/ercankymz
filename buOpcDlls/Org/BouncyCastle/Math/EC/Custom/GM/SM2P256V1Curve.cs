// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Math.EC.Custom.GM.SM2P256V1Curve
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Math.Raw;
using Org.BouncyCastle.Security;
using Org.BouncyCastle.Utilities.Encoders;

#nullable disable
namespace Org.BouncyCastle.Math.EC.Custom.GM;

internal class SM2P256V1Curve : AbstractFpCurve
{
  public static readonly BigInteger q = SM2P256V1FieldElement.Q;
  private const int SM2P256V1_DEFAULT_COORDS = 2;
  private const int SM2P256V1_FE_INTS = 8;
  private static readonly ECFieldElement[] SM2P256V1_AFFINE_ZS = new ECFieldElement[1]
  {
    (ECFieldElement) new SM2P256V1FieldElement(BigInteger.One)
  };
  protected readonly SM2P256V1Point m_infinity;

  public SM2P256V1Curve()
    : base(SM2P256V1Curve.q, true)
  {
    this.m_infinity = new SM2P256V1Point((ECCurve) this, (ECFieldElement) null, (ECFieldElement) null);
    this.m_a = this.FromBigInteger(new BigInteger(1, Hex.DecodeStrict("FFFFFFFEFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF00000000FFFFFFFFFFFFFFFC")));
    this.m_b = this.FromBigInteger(new BigInteger(1, Hex.DecodeStrict("28E9FA9E9D9F5E344D5A9E4BCF6509A7F39789F515AB8F92DDBCBD414D940E93")));
    this.m_order = new BigInteger(1, Hex.DecodeStrict("FFFFFFFEFFFFFFFFFFFFFFFFFFFFFFFF7203DF6B21C6052B53BBF40939D54123"));
    this.m_cofactor = BigInteger.One;
    this.m_coord = 2;
  }

  protected override ECCurve CloneCurve() => (ECCurve) new SM2P256V1Curve();

  public override bool SupportsCoordinateSystem(int coord) => coord == 2;

  public virtual BigInteger Q => SM2P256V1Curve.q;

  public override ECPoint Infinity => (ECPoint) this.m_infinity;

  public override int FieldSize => SM2P256V1Curve.q.BitLength;

  public override ECFieldElement FromBigInteger(BigInteger x)
  {
    return (ECFieldElement) new SM2P256V1FieldElement(x);
  }

  protected internal override ECPoint CreateRawPoint(ECFieldElement x, ECFieldElement y)
  {
    return (ECPoint) new SM2P256V1Point((ECCurve) this, x, y);
  }

  protected internal override ECPoint CreateRawPoint(
    ECFieldElement x,
    ECFieldElement y,
    ECFieldElement[] zs)
  {
    return (ECPoint) new SM2P256V1Point((ECCurve) this, x, y, zs);
  }

  public override ECLookupTable CreateCacheSafeLookupTable(ECPoint[] points, int off, int len)
  {
    uint[] numArray = new uint[len * 8 * 2];
    int zOff1 = 0;
    for (int index = 0; index < len; ++index)
    {
      ECPoint point = points[off + index];
      Nat256.Copy(((SM2P256V1FieldElement) point.RawXCoord).x, 0, numArray, zOff1);
      int zOff2 = zOff1 + 8;
      Nat256.Copy(((SM2P256V1FieldElement) point.RawYCoord).x, 0, numArray, zOff2);
      zOff1 = zOff2 + 8;
    }
    return (ECLookupTable) new SM2P256V1Curve.SM2P256V1LookupTable(this, numArray, len);
  }

  public override ECFieldElement RandomFieldElement(SecureRandom r)
  {
    uint[] numArray = Nat256.Create();
    SM2P256V1Field.Random(r, numArray);
    return (ECFieldElement) new SM2P256V1FieldElement(numArray);
  }

  public override ECFieldElement RandomFieldElementMult(SecureRandom r)
  {
    uint[] numArray = Nat256.Create();
    SM2P256V1Field.RandomMult(r, numArray);
    return (ECFieldElement) new SM2P256V1FieldElement(numArray);
  }

  private class SM2P256V1LookupTable : AbstractECLookupTable
  {
    private readonly SM2P256V1Curve m_outer;
    private readonly uint[] m_table;
    private readonly int m_size;

    internal SM2P256V1LookupTable(SM2P256V1Curve outer, uint[] table, int size)
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
      return this.m_outer.CreateRawPoint((ECFieldElement) new SM2P256V1FieldElement(x), (ECFieldElement) new SM2P256V1FieldElement(y), SM2P256V1Curve.SM2P256V1_AFFINE_ZS);
    }
  }
}
