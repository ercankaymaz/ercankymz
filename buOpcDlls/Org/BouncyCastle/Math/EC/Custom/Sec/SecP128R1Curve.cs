// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Math.EC.Custom.Sec.SecP128R1Curve
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Math.Raw;
using Org.BouncyCastle.Security;
using Org.BouncyCastle.Utilities.Encoders;

#nullable disable
namespace Org.BouncyCastle.Math.EC.Custom.Sec;

internal class SecP128R1Curve : AbstractFpCurve
{
  public static readonly BigInteger q = SecP128R1FieldElement.Q;
  private const int SECP128R1_DEFAULT_COORDS = 2;
  private const int SECP128R1_FE_INTS = 4;
  private static readonly ECFieldElement[] SECP128R1_AFFINE_ZS = new ECFieldElement[1]
  {
    (ECFieldElement) new SecP128R1FieldElement(BigInteger.One)
  };
  protected readonly SecP128R1Point m_infinity;

  public SecP128R1Curve()
    : base(SecP128R1Curve.q, true)
  {
    this.m_infinity = new SecP128R1Point((ECCurve) this, (ECFieldElement) null, (ECFieldElement) null);
    this.m_a = this.FromBigInteger(new BigInteger(1, Hex.DecodeStrict("FFFFFFFDFFFFFFFFFFFFFFFFFFFFFFFC")));
    this.m_b = this.FromBigInteger(new BigInteger(1, Hex.DecodeStrict("E87579C11079F43DD824993C2CEE5ED3")));
    this.m_order = new BigInteger(1, Hex.DecodeStrict("FFFFFFFE0000000075A30D1B9038A115"));
    this.m_cofactor = BigInteger.One;
    this.m_coord = 2;
  }

  protected override ECCurve CloneCurve() => (ECCurve) new SecP128R1Curve();

  public override bool SupportsCoordinateSystem(int coord) => coord == 2;

  public virtual BigInteger Q => SecP128R1Curve.q;

  public override ECPoint Infinity => (ECPoint) this.m_infinity;

  public override int FieldSize => SecP128R1Curve.q.BitLength;

  public override ECFieldElement FromBigInteger(BigInteger x)
  {
    return (ECFieldElement) new SecP128R1FieldElement(x);
  }

  protected internal override ECPoint CreateRawPoint(ECFieldElement x, ECFieldElement y)
  {
    return (ECPoint) new SecP128R1Point((ECCurve) this, x, y);
  }

  protected internal override ECPoint CreateRawPoint(
    ECFieldElement x,
    ECFieldElement y,
    ECFieldElement[] zs)
  {
    return (ECPoint) new SecP128R1Point((ECCurve) this, x, y, zs);
  }

  public override ECLookupTable CreateCacheSafeLookupTable(ECPoint[] points, int off, int len)
  {
    uint[] numArray = new uint[len * 4 * 2];
    int zOff1 = 0;
    for (int index = 0; index < len; ++index)
    {
      ECPoint point = points[off + index];
      Nat128.Copy(((SecP128R1FieldElement) point.RawXCoord).x, 0, numArray, zOff1);
      int zOff2 = zOff1 + 4;
      Nat128.Copy(((SecP128R1FieldElement) point.RawYCoord).x, 0, numArray, zOff2);
      zOff1 = zOff2 + 4;
    }
    return (ECLookupTable) new SecP128R1Curve.SecP128R1LookupTable(this, numArray, len);
  }

  public override ECFieldElement RandomFieldElement(SecureRandom r)
  {
    uint[] numArray = Nat128.Create();
    SecP128R1Field.Random(r, numArray);
    return (ECFieldElement) new SecP128R1FieldElement(numArray);
  }

  public override ECFieldElement RandomFieldElementMult(SecureRandom r)
  {
    uint[] numArray = Nat128.Create();
    SecP128R1Field.RandomMult(r, numArray);
    return (ECFieldElement) new SecP128R1FieldElement(numArray);
  }

  private class SecP128R1LookupTable : AbstractECLookupTable
  {
    private readonly SecP128R1Curve m_outer;
    private readonly uint[] m_table;
    private readonly int m_size;

    internal SecP128R1LookupTable(SecP128R1Curve outer, uint[] table, int size)
    {
      this.m_outer = outer;
      this.m_table = table;
      this.m_size = size;
    }

    public override int Size => this.m_size;

    public override ECPoint Lookup(int index)
    {
      uint[] x = Nat128.Create();
      uint[] y = Nat128.Create();
      int num1 = 0;
      for (int index1 = 0; index1 < this.m_size; ++index1)
      {
        uint num2 = (uint) ((index1 ^ index) - 1 >> 31 /*0x1F*/);
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
      uint[] x = Nat128.Create();
      uint[] y = Nat128.Create();
      int num = index * 4 * 2;
      for (int index1 = 0; index1 < 4; ++index1)
      {
        x[index1] = this.m_table[num + index1];
        y[index1] = this.m_table[num + 4 + index1];
      }
      return this.CreatePoint(x, y);
    }

    private ECPoint CreatePoint(uint[] x, uint[] y)
    {
      return this.m_outer.CreateRawPoint((ECFieldElement) new SecP128R1FieldElement(x), (ECFieldElement) new SecP128R1FieldElement(y), SecP128R1Curve.SECP128R1_AFFINE_ZS);
    }
  }
}
