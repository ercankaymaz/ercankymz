// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Math.EC.Custom.Sec.SecP160R2Field
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto.Utilities;
using Org.BouncyCastle.Math.Raw;
using Org.BouncyCastle.Security;

#nullable disable
namespace Org.BouncyCastle.Math.EC.Custom.Sec;

internal class SecP160R2Field
{
  internal static readonly uint[] P = new uint[5]
  {
    4294945907U,
    4294967294U,
    uint.MaxValue,
    uint.MaxValue,
    uint.MaxValue
  };
  private static readonly uint[] PExt = new uint[10]
  {
    457489321U,
    42778U,
    1U,
    0U,
    0U,
    4294924518U,
    4294967293U,
    uint.MaxValue,
    uint.MaxValue,
    uint.MaxValue
  };
  private static readonly uint[] PExtInv = new uint[7]
  {
    3837477975U,
    4294924517U,
    4294967294U,
    uint.MaxValue,
    uint.MaxValue,
    42777U,
    2U
  };
  private const uint P4 = 4294967295 /*0xFFFFFFFF*/;
  private const uint PExt9 = 4294967295 /*0xFFFFFFFF*/;
  private const uint PInv33 = 21389;

  public static void Add(uint[] x, uint[] y, uint[] z)
  {
    if (Nat160.Add(x, y, z) == 0U && (z[4] != uint.MaxValue || !Nat160.Gte(z, SecP160R2Field.P)))
      return;
    int num = (int) Nat.Add33To(5, 21389U, z);
  }

  public static void AddExt(uint[] xx, uint[] yy, uint[] zz)
  {
    if (Nat.Add(10, xx, yy, zz) == 0U && (zz[9] != uint.MaxValue || !Nat.Gte(10, zz, SecP160R2Field.PExt)) || Nat.AddTo(SecP160R2Field.PExtInv.Length, SecP160R2Field.PExtInv, zz) == 0U)
      return;
    int num = (int) Nat.IncAt(10, zz, SecP160R2Field.PExtInv.Length);
  }

  public static void AddOne(uint[] x, uint[] z)
  {
    if (Nat.Inc(5, x, z) == 0U && (z[4] != uint.MaxValue || !Nat160.Gte(z, SecP160R2Field.P)))
      return;
    int num = (int) Nat.Add33To(5, 21389U, z);
  }

  public static uint[] FromBigInteger(BigInteger x)
  {
    uint[] numArray = Nat.FromBigInteger(160 /*0xA0*/, x);
    if (numArray[4] == uint.MaxValue && Nat160.Gte(numArray, SecP160R2Field.P))
      Nat160.SubFrom(SecP160R2Field.P, numArray);
    return numArray;
  }

  public static void Half(uint[] x, uint[] z)
  {
    if (((int) x[0] & 1) == 0)
    {
      int num1 = (int) Nat.ShiftDownBit(5, x, 0U, z);
    }
    else
    {
      uint c = Nat160.Add(x, SecP160R2Field.P, z);
      int num2 = (int) Nat.ShiftDownBit(5, z, c);
    }
  }

  public static void Inv(uint[] x, uint[] z) => Mod.CheckedModOddInverse(SecP160R2Field.P, x, z);

  public static int IsZero(uint[] x)
  {
    uint num = 0;
    for (int index = 0; index < 5; ++index)
      num |= x[index];
    return (int) (num >> 1 | num & 1U) - 1 >> 31 /*0x1F*/;
  }

  public static void Multiply(uint[] x, uint[] y, uint[] z)
  {
    uint[] ext = Nat160.CreateExt();
    Nat160.Mul(x, y, ext);
    SecP160R2Field.Reduce(ext, z);
  }

  public static void MultiplyAddToExt(uint[] x, uint[] y, uint[] zz)
  {
    if (Nat160.MulAddTo(x, y, zz) == 0U && (zz[9] != uint.MaxValue || !Nat.Gte(10, zz, SecP160R2Field.PExt)) || Nat.AddTo(SecP160R2Field.PExtInv.Length, SecP160R2Field.PExtInv, zz) == 0U)
      return;
    int num = (int) Nat.IncAt(10, zz, SecP160R2Field.PExtInv.Length);
  }

  public static void Negate(uint[] x, uint[] z)
  {
    if (SecP160R2Field.IsZero(x) != 0)
      Nat160.Sub(SecP160R2Field.P, SecP160R2Field.P, z);
    else
      Nat160.Sub(SecP160R2Field.P, x, z);
  }

  public static void Random(SecureRandom r, uint[] z)
  {
    byte[] numArray = new byte[20];
    do
    {
      r.NextBytes(numArray);
      Pack.LE_To_UInt32(numArray, 0, z, 0, 5);
    }
    while (Nat.LessThan(5, z, SecP160R2Field.P) == 0);
  }

  public static void RandomMult(SecureRandom r, uint[] z)
  {
    do
    {
      SecP160R2Field.Random(r, z);
    }
    while (SecP160R2Field.IsZero(z) != 0);
  }

  public static void Reduce(uint[] xx, uint[] z)
  {
    if (Nat160.Mul33DWordAdd(21389U, Nat160.Mul33Add(21389U, xx, 5, xx, 0, z, 0), z, 0) == 0U && (z[4] != uint.MaxValue || !Nat160.Gte(z, SecP160R2Field.P)))
      return;
    int num = (int) Nat.Add33To(5, 21389U, z);
  }

  public static void Reduce32(uint x, uint[] z)
  {
    if ((x == 0U || Nat160.Mul33WordAdd(21389U, x, z, 0) == 0U) && (z[4] != uint.MaxValue || !Nat160.Gte(z, SecP160R2Field.P)))
      return;
    int num = (int) Nat.Add33To(5, 21389U, z);
  }

  public static void Square(uint[] x, uint[] z)
  {
    uint[] ext = Nat160.CreateExt();
    Nat160.Square(x, ext);
    SecP160R2Field.Reduce(ext, z);
  }

  public static void SquareN(uint[] x, int n, uint[] z)
  {
    uint[] ext = Nat160.CreateExt();
    Nat160.Square(x, ext);
    SecP160R2Field.Reduce(ext, z);
    while (--n > 0)
    {
      Nat160.Square(z, ext);
      SecP160R2Field.Reduce(ext, z);
    }
  }

  public static void Subtract(uint[] x, uint[] y, uint[] z)
  {
    if (Nat160.Sub(x, y, z) == 0)
      return;
    Nat.Sub33From(5, 21389U, z);
  }

  public static void SubtractExt(uint[] xx, uint[] yy, uint[] zz)
  {
    if (Nat.Sub(10, xx, yy, zz) == 0 || Nat.SubFrom(SecP160R2Field.PExtInv.Length, SecP160R2Field.PExtInv, zz) == 0)
      return;
    Nat.DecAt(10, zz, SecP160R2Field.PExtInv.Length);
  }

  public static void Twice(uint[] x, uint[] z)
  {
    if (Nat.ShiftUpBit(5, x, 0U, z) == 0U && (z[4] != uint.MaxValue || !Nat160.Gte(z, SecP160R2Field.P)))
      return;
    int num = (int) Nat.Add33To(5, 21389U, z);
  }
}
