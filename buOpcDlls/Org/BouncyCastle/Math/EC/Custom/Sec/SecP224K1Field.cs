// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Math.EC.Custom.Sec.SecP224K1Field
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto.Utilities;
using Org.BouncyCastle.Math.Raw;
using Org.BouncyCastle.Security;

#nullable disable
namespace Org.BouncyCastle.Math.EC.Custom.Sec;

internal class SecP224K1Field
{
  internal static readonly uint[] P = new uint[7]
  {
    4294960493U,
    4294967294U,
    uint.MaxValue,
    uint.MaxValue,
    uint.MaxValue,
    uint.MaxValue,
    uint.MaxValue
  };
  private static readonly uint[] PExt = new uint[14]
  {
    46280809U,
    13606U,
    1U,
    0U,
    0U,
    0U,
    0U,
    4294953690U,
    4294967293U,
    uint.MaxValue,
    uint.MaxValue,
    uint.MaxValue,
    uint.MaxValue,
    uint.MaxValue
  };
  private static readonly uint[] PExtInv = new uint[9]
  {
    4248686487U,
    4294953689U,
    4294967294U,
    uint.MaxValue,
    uint.MaxValue,
    uint.MaxValue,
    uint.MaxValue,
    13605U,
    2U
  };
  private const uint P6 = 4294967295 /*0xFFFFFFFF*/;
  private const uint PExt13 = 4294967295 /*0xFFFFFFFF*/;
  private const uint PInv33 = 6803;

  public static void Add(uint[] x, uint[] y, uint[] z)
  {
    if (Nat224.Add(x, y, z) == 0U && (z[6] != uint.MaxValue || !Nat224.Gte(z, SecP224K1Field.P)))
      return;
    int num = (int) Nat.Add33To(7, 6803U, z);
  }

  public static void AddExt(uint[] xx, uint[] yy, uint[] zz)
  {
    if (Nat.Add(14, xx, yy, zz) == 0U && (zz[13] != uint.MaxValue || !Nat.Gte(14, zz, SecP224K1Field.PExt)) || Nat.AddTo(SecP224K1Field.PExtInv.Length, SecP224K1Field.PExtInv, zz) == 0U)
      return;
    int num = (int) Nat.IncAt(14, zz, SecP224K1Field.PExtInv.Length);
  }

  public static void AddOne(uint[] x, uint[] z)
  {
    if (Nat.Inc(7, x, z) == 0U && (z[6] != uint.MaxValue || !Nat224.Gte(z, SecP224K1Field.P)))
      return;
    int num = (int) Nat.Add33To(7, 6803U, z);
  }

  public static uint[] FromBigInteger(BigInteger x)
  {
    uint[] numArray = Nat.FromBigInteger(224 /*0xE0*/, x);
    if (numArray[6] == uint.MaxValue && Nat224.Gte(numArray, SecP224K1Field.P))
      Nat224.SubFrom(SecP224K1Field.P, numArray);
    return numArray;
  }

  public static void Half(uint[] x, uint[] z)
  {
    if (((int) x[0] & 1) == 0)
    {
      int num1 = (int) Nat.ShiftDownBit(7, x, 0U, z);
    }
    else
    {
      uint c = Nat224.Add(x, SecP224K1Field.P, z);
      int num2 = (int) Nat.ShiftDownBit(7, z, c);
    }
  }

  public static void Inv(uint[] x, uint[] z) => Mod.CheckedModOddInverse(SecP224K1Field.P, x, z);

  public static int IsZero(uint[] x)
  {
    uint num = 0;
    for (int index = 0; index < 7; ++index)
      num |= x[index];
    return (int) (num >> 1 | num & 1U) - 1 >> 31 /*0x1F*/;
  }

  public static void Multiply(uint[] x, uint[] y, uint[] z)
  {
    uint[] ext = Nat224.CreateExt();
    Nat224.Mul(x, y, ext);
    SecP224K1Field.Reduce(ext, z);
  }

  public static void MultiplyAddToExt(uint[] x, uint[] y, uint[] zz)
  {
    if (Nat224.MulAddTo(x, y, zz) == 0U && (zz[13] != uint.MaxValue || !Nat.Gte(14, zz, SecP224K1Field.PExt)) || Nat.AddTo(SecP224K1Field.PExtInv.Length, SecP224K1Field.PExtInv, zz) == 0U)
      return;
    int num = (int) Nat.IncAt(14, zz, SecP224K1Field.PExtInv.Length);
  }

  public static void Negate(uint[] x, uint[] z)
  {
    if (SecP224K1Field.IsZero(x) != 0)
      Nat224.Sub(SecP224K1Field.P, SecP224K1Field.P, z);
    else
      Nat224.Sub(SecP224K1Field.P, x, z);
  }

  public static void Random(SecureRandom r, uint[] z)
  {
    byte[] numArray = new byte[28];
    do
    {
      r.NextBytes(numArray);
      Pack.LE_To_UInt32(numArray, 0, z, 0, 7);
    }
    while (Nat.LessThan(7, z, SecP224K1Field.P) == 0);
  }

  public static void RandomMult(SecureRandom r, uint[] z)
  {
    do
    {
      SecP224K1Field.Random(r, z);
    }
    while (SecP224K1Field.IsZero(z) != 0);
  }

  public static void Reduce(uint[] xx, uint[] z)
  {
    if (Nat224.Mul33DWordAdd(6803U, Nat224.Mul33Add(6803U, xx, 7, xx, 0, z, 0), z, 0) == 0U && (z[6] != uint.MaxValue || !Nat224.Gte(z, SecP224K1Field.P)))
      return;
    int num = (int) Nat.Add33To(7, 6803U, z);
  }

  public static void Reduce32(uint x, uint[] z)
  {
    if ((x == 0U || Nat224.Mul33WordAdd(6803U, x, z, 0) == 0U) && (z[6] != uint.MaxValue || !Nat224.Gte(z, SecP224K1Field.P)))
      return;
    int num = (int) Nat.Add33To(7, 6803U, z);
  }

  public static void Square(uint[] x, uint[] z)
  {
    uint[] ext = Nat224.CreateExt();
    Nat224.Square(x, ext);
    SecP224K1Field.Reduce(ext, z);
  }

  public static void SquareN(uint[] x, int n, uint[] z)
  {
    uint[] ext = Nat224.CreateExt();
    Nat224.Square(x, ext);
    SecP224K1Field.Reduce(ext, z);
    while (--n > 0)
    {
      Nat224.Square(z, ext);
      SecP224K1Field.Reduce(ext, z);
    }
  }

  public static void Subtract(uint[] x, uint[] y, uint[] z)
  {
    if (Nat224.Sub(x, y, z) == 0)
      return;
    Nat.Sub33From(7, 6803U, z);
  }

  public static void SubtractExt(uint[] xx, uint[] yy, uint[] zz)
  {
    if (Nat.Sub(14, xx, yy, zz) == 0 || Nat.SubFrom(SecP224K1Field.PExtInv.Length, SecP224K1Field.PExtInv, zz) == 0)
      return;
    Nat.DecAt(14, zz, SecP224K1Field.PExtInv.Length);
  }

  public static void Twice(uint[] x, uint[] z)
  {
    if (Nat.ShiftUpBit(7, x, 0U, z) == 0U && (z[6] != uint.MaxValue || !Nat224.Gte(z, SecP224K1Field.P)))
      return;
    int num = (int) Nat.Add33To(7, 6803U, z);
  }
}
