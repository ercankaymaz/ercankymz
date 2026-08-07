// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Math.EC.Custom.Sec.SecP256K1Field
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto.Utilities;
using Org.BouncyCastle.Math.Raw;
using Org.BouncyCastle.Security;

#nullable disable
namespace Org.BouncyCastle.Math.EC.Custom.Sec;

internal class SecP256K1Field
{
  internal static readonly uint[] P = new uint[8]
  {
    4294966319U,
    4294967294U,
    uint.MaxValue,
    uint.MaxValue,
    uint.MaxValue,
    uint.MaxValue,
    uint.MaxValue,
    uint.MaxValue
  };
  private static readonly uint[] PExt = new uint[16 /*0x10*/]
  {
    954529U,
    1954U,
    1U,
    0U,
    0U,
    0U,
    0U,
    0U,
    4294965342U,
    4294967293U,
    uint.MaxValue,
    uint.MaxValue,
    uint.MaxValue,
    uint.MaxValue,
    uint.MaxValue,
    uint.MaxValue
  };
  private static readonly uint[] PExtInv = new uint[10]
  {
    4294012767U,
    4294965341U,
    4294967294U,
    uint.MaxValue,
    uint.MaxValue,
    uint.MaxValue,
    uint.MaxValue,
    uint.MaxValue,
    1953U,
    2U
  };
  private const uint P7 = 4294967295 /*0xFFFFFFFF*/;
  private const uint PExt15 = 4294967295 /*0xFFFFFFFF*/;
  private const uint PInv33 = 977;

  public static void Add(uint[] x, uint[] y, uint[] z)
  {
    if (Nat256.Add(x, y, z) == 0U && (z[7] != uint.MaxValue || !Nat256.Gte(z, SecP256K1Field.P)))
      return;
    int num = (int) Nat.Add33To(8, 977U, z);
  }

  public static void AddExt(uint[] xx, uint[] yy, uint[] zz)
  {
    if (Nat.Add(16 /*0x10*/, xx, yy, zz) == 0U && (zz[15] != uint.MaxValue || !Nat.Gte(16 /*0x10*/, zz, SecP256K1Field.PExt)) || Nat.AddTo(SecP256K1Field.PExtInv.Length, SecP256K1Field.PExtInv, zz) == 0U)
      return;
    int num = (int) Nat.IncAt(16 /*0x10*/, zz, SecP256K1Field.PExtInv.Length);
  }

  public static void AddOne(uint[] x, uint[] z)
  {
    if (Nat.Inc(8, x, z) == 0U && (z[7] != uint.MaxValue || !Nat256.Gte(z, SecP256K1Field.P)))
      return;
    int num = (int) Nat.Add33To(8, 977U, z);
  }

  public static uint[] FromBigInteger(BigInteger x)
  {
    uint[] numArray = Nat.FromBigInteger(256 /*0x0100*/, x);
    if (numArray[7] == uint.MaxValue && Nat256.Gte(numArray, SecP256K1Field.P))
      Nat256.SubFrom(SecP256K1Field.P, numArray, 0);
    return numArray;
  }

  public static void Half(uint[] x, uint[] z)
  {
    if (((int) x[0] & 1) == 0)
    {
      int num1 = (int) Nat.ShiftDownBit(8, x, 0U, z);
    }
    else
    {
      uint c = Nat256.Add(x, SecP256K1Field.P, z);
      int num2 = (int) Nat.ShiftDownBit(8, z, c);
    }
  }

  public static void Inv(uint[] x, uint[] z) => Mod.CheckedModOddInverse(SecP256K1Field.P, x, z);

  public static int IsZero(uint[] x)
  {
    uint num = 0;
    for (int index = 0; index < 8; ++index)
      num |= x[index];
    return (int) (num >> 1 | num & 1U) - 1 >> 31 /*0x1F*/;
  }

  public static void Multiply(uint[] x, uint[] y, uint[] z)
  {
    uint[] ext = Nat256.CreateExt();
    Nat256.Mul(x, y, ext);
    SecP256K1Field.Reduce(ext, z);
  }

  public static void Multiply(uint[] x, uint[] y, uint[] z, uint[] tt)
  {
    Nat256.Mul(x, y, tt);
    SecP256K1Field.Reduce(tt, z);
  }

  public static void MultiplyAddToExt(uint[] x, uint[] y, uint[] zz)
  {
    if (Nat256.MulAddTo(x, y, zz) == 0U && (zz[15] != uint.MaxValue || !Nat.Gte(16 /*0x10*/, zz, SecP256K1Field.PExt)) || Nat.AddTo(SecP256K1Field.PExtInv.Length, SecP256K1Field.PExtInv, zz) == 0U)
      return;
    int num = (int) Nat.IncAt(16 /*0x10*/, zz, SecP256K1Field.PExtInv.Length);
  }

  public static void Negate(uint[] x, uint[] z)
  {
    if (SecP256K1Field.IsZero(x) != 0)
      Nat256.Sub(SecP256K1Field.P, SecP256K1Field.P, z);
    else
      Nat256.Sub(SecP256K1Field.P, x, z);
  }

  public static void Random(SecureRandom r, uint[] z)
  {
    byte[] numArray = new byte[32 /*0x20*/];
    do
    {
      r.NextBytes(numArray);
      Pack.LE_To_UInt32(numArray, 0, z, 0, 8);
    }
    while (Nat.LessThan(8, z, SecP256K1Field.P) == 0);
  }

  public static void RandomMult(SecureRandom r, uint[] z)
  {
    do
    {
      SecP256K1Field.Random(r, z);
    }
    while (SecP256K1Field.IsZero(z) != 0);
  }

  public static void Reduce(uint[] xx, uint[] z)
  {
    if (Nat256.Mul33DWordAdd(977U, Nat256.Mul33Add(977U, xx, 8, xx, 0, z, 0), z, 0) == 0U && (z[7] != uint.MaxValue || !Nat256.Gte(z, SecP256K1Field.P)))
      return;
    int num = (int) Nat.Add33To(8, 977U, z);
  }

  public static void Reduce32(uint x, uint[] z)
  {
    if ((x == 0U || Nat256.Mul33WordAdd(977U, x, z, 0) == 0U) && (z[7] != uint.MaxValue || !Nat256.Gte(z, SecP256K1Field.P)))
      return;
    int num = (int) Nat.Add33To(8, 977U, z);
  }

  public static void Square(uint[] x, uint[] z)
  {
    uint[] ext = Nat256.CreateExt();
    Nat256.Square(x, ext);
    SecP256K1Field.Reduce(ext, z);
  }

  public static void Square(uint[] x, uint[] z, uint[] tt)
  {
    Nat256.Square(x, tt);
    SecP256K1Field.Reduce(tt, z);
  }

  public static void SquareN(uint[] x, int n, uint[] z)
  {
    uint[] ext = Nat256.CreateExt();
    Nat256.Square(x, ext);
    SecP256K1Field.Reduce(ext, z);
    while (--n > 0)
    {
      Nat256.Square(z, ext);
      SecP256K1Field.Reduce(ext, z);
    }
  }

  public static void SquareN(uint[] x, int n, uint[] z, uint[] tt)
  {
    Nat256.Square(x, tt);
    SecP256K1Field.Reduce(tt, z);
    while (--n > 0)
    {
      Nat256.Square(z, tt);
      SecP256K1Field.Reduce(tt, z);
    }
  }

  public static void Subtract(uint[] x, uint[] y, uint[] z)
  {
    if (Nat256.Sub(x, y, z) == 0)
      return;
    Nat.Sub33From(8, 977U, z);
  }

  public static void SubtractExt(uint[] xx, uint[] yy, uint[] zz)
  {
    if (Nat.Sub(16 /*0x10*/, xx, yy, zz) == 0 || Nat.SubFrom(SecP256K1Field.PExtInv.Length, SecP256K1Field.PExtInv, zz) == 0)
      return;
    Nat.DecAt(16 /*0x10*/, zz, SecP256K1Field.PExtInv.Length);
  }

  public static void Twice(uint[] x, uint[] z)
  {
    if (Nat.ShiftUpBit(8, x, 0U, z) == 0U && (z[7] != uint.MaxValue || !Nat256.Gte(z, SecP256K1Field.P)))
      return;
    int num = (int) Nat.Add33To(8, 977U, z);
  }
}
