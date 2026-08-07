// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Math.EC.Custom.Sec.SecP256R1Field
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto.Utilities;
using Org.BouncyCastle.Math.Raw;
using Org.BouncyCastle.Security;

#nullable disable
namespace Org.BouncyCastle.Math.EC.Custom.Sec;

internal class SecP256R1Field
{
  internal static readonly uint[] P = new uint[8]
  {
    uint.MaxValue,
    uint.MaxValue,
    uint.MaxValue,
    0U,
    0U,
    0U,
    1U,
    uint.MaxValue
  };
  private static readonly uint[] PExt = new uint[16 /*0x10*/]
  {
    1U,
    0U,
    0U,
    4294967294U,
    uint.MaxValue,
    uint.MaxValue,
    4294967294U,
    1U,
    4294967294U,
    1U,
    4294967294U,
    1U,
    1U,
    4294967294U,
    2U,
    4294967294U
  };
  private const uint P7 = 4294967295 /*0xFFFFFFFF*/;
  private const uint PExt15 = 4294967294;

  public static void Add(uint[] x, uint[] y, uint[] z)
  {
    if (Nat256.Add(x, y, z) == 0U && (z[7] != uint.MaxValue || !Nat256.Gte(z, SecP256R1Field.P)))
      return;
    SecP256R1Field.AddPInvTo(z);
  }

  public static void AddExt(uint[] xx, uint[] yy, uint[] zz)
  {
    if (Nat.Add(16 /*0x10*/, xx, yy, zz) == 0U && (zz[15] < 4294967294U || !Nat.Gte(16 /*0x10*/, zz, SecP256R1Field.PExt)))
      return;
    Nat.SubFrom(16 /*0x10*/, SecP256R1Field.PExt, zz);
  }

  public static void AddOne(uint[] x, uint[] z)
  {
    if (Nat.Inc(8, x, z) == 0U && (z[7] != uint.MaxValue || !Nat256.Gte(z, SecP256R1Field.P)))
      return;
    SecP256R1Field.AddPInvTo(z);
  }

  public static uint[] FromBigInteger(BigInteger x)
  {
    uint[] numArray = Nat.FromBigInteger(256 /*0x0100*/, x);
    if (numArray[7] == uint.MaxValue && Nat256.Gte(numArray, SecP256R1Field.P))
      Nat256.SubFrom(SecP256R1Field.P, numArray, 0);
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
      uint c = Nat256.Add(x, SecP256R1Field.P, z);
      int num2 = (int) Nat.ShiftDownBit(8, z, c);
    }
  }

  public static void Inv(uint[] x, uint[] z) => Mod.CheckedModOddInverse(SecP256R1Field.P, x, z);

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
    SecP256R1Field.Reduce(ext, z);
  }

  public static void Multiply(uint[] x, uint[] y, uint[] z, uint[] tt)
  {
    Nat256.Mul(x, y, tt);
    SecP256R1Field.Reduce(tt, z);
  }

  public static void MultiplyAddToExt(uint[] x, uint[] y, uint[] zz)
  {
    if (Nat256.MulAddTo(x, y, zz) == 0U && (zz[15] < 4294967294U || !Nat.Gte(16 /*0x10*/, zz, SecP256R1Field.PExt)))
      return;
    Nat.SubFrom(16 /*0x10*/, SecP256R1Field.PExt, zz);
  }

  public static void Negate(uint[] x, uint[] z)
  {
    if (SecP256R1Field.IsZero(x) != 0)
      Nat256.Sub(SecP256R1Field.P, SecP256R1Field.P, z);
    else
      Nat256.Sub(SecP256R1Field.P, x, z);
  }

  public static void Random(SecureRandom r, uint[] z)
  {
    byte[] numArray = new byte[32 /*0x20*/];
    do
    {
      r.NextBytes(numArray);
      Pack.LE_To_UInt32(numArray, 0, z, 0, 8);
    }
    while (Nat.LessThan(8, z, SecP256R1Field.P) == 0);
  }

  public static void RandomMult(SecureRandom r, uint[] z)
  {
    do
    {
      SecP256R1Field.Random(r, z);
    }
    while (SecP256R1Field.IsZero(z) != 0);
  }

  public static void Reduce(uint[] xx, uint[] z)
  {
    long num1 = (long) xx[8];
    long num2 = (long) xx[9];
    long num3 = (long) xx[10];
    long num4 = (long) xx[11];
    long num5 = (long) xx[12];
    long num6 = (long) xx[13];
    long num7 = (long) xx[14];
    long num8 = (long) xx[15];
    long num9 = num1 - 6L;
    long num10 = num9 + num2;
    long num11 = num2 + num3;
    long num12 = num3 + num4 - num8;
    long num13 = num4 + num5;
    long num14 = num5 + num6;
    long num15 = num6 + num7;
    long num16 = num7 + num8;
    long num17 = num15 - num10;
    long num18 = 0L + ((long) xx[0] - num13 - num17);
    z[0] = (uint) num18;
    long num19 = (num18 >> 32 /*0x20*/) + ((long) xx[1] + num11 - num14 - num16);
    z[1] = (uint) num19;
    long num20 = (num19 >> 32 /*0x20*/) + ((long) xx[2] + num12 - num15);
    z[2] = (uint) num20;
    long num21 = (num20 >> 32 /*0x20*/) + ((long) xx[3] + (num13 << 1) + num17 - num16);
    z[3] = (uint) num21;
    long num22 = (num21 >> 32 /*0x20*/) + ((long) xx[4] + (num14 << 1) + num7 - num11);
    z[4] = (uint) num22;
    long num23 = (num22 >> 32 /*0x20*/) + ((long) xx[5] + (num15 << 1) - num12);
    z[5] = (uint) num23;
    long num24 = (num23 >> 32 /*0x20*/) + ((long) xx[6] + (num16 << 1) + num17);
    z[6] = (uint) num24;
    long num25 = (num24 >> 32 /*0x20*/) + ((long) xx[7] + (num8 << 1) + num9 - num12 - num14);
    z[7] = (uint) num25;
    SecP256R1Field.Reduce32((uint) ((num25 >> 32 /*0x20*/) + 6L), z);
  }

  public static void Reduce32(uint x, uint[] z)
  {
    long num1 = 0;
    if (x != 0U)
    {
      long num2 = (long) x;
      long num3 = num1 + ((long) z[0] + num2);
      z[0] = (uint) num3;
      long num4 = num3 >> 32 /*0x20*/;
      if (num4 != 0L)
      {
        long num5 = num4 + (long) z[1];
        z[1] = (uint) num5;
        long num6 = (num5 >> 32 /*0x20*/) + (long) z[2];
        z[2] = (uint) num6;
        num4 = num6 >> 32 /*0x20*/;
      }
      long num7 = num4 + ((long) z[3] - num2);
      z[3] = (uint) num7;
      long num8 = num7 >> 32 /*0x20*/;
      if (num8 != 0L)
      {
        long num9 = num8 + (long) z[4];
        z[4] = (uint) num9;
        long num10 = (num9 >> 32 /*0x20*/) + (long) z[5];
        z[5] = (uint) num10;
        num8 = num10 >> 32 /*0x20*/;
      }
      long num11 = num8 + ((long) z[6] - num2);
      z[6] = (uint) num11;
      long num12 = (num11 >> 32 /*0x20*/) + ((long) z[7] + num2);
      z[7] = (uint) num12;
      num1 = num12 >> 32 /*0x20*/;
    }
    if (num1 == 0L && (z[7] != uint.MaxValue || !Nat256.Gte(z, SecP256R1Field.P)))
      return;
    SecP256R1Field.AddPInvTo(z);
  }

  public static void Square(uint[] x, uint[] z)
  {
    uint[] ext = Nat256.CreateExt();
    Nat256.Square(x, ext);
    SecP256R1Field.Reduce(ext, z);
  }

  public static void Square(uint[] x, uint[] z, uint[] tt)
  {
    Nat256.Square(x, tt);
    SecP256R1Field.Reduce(tt, z);
  }

  public static void SquareN(uint[] x, int n, uint[] z)
  {
    uint[] ext = Nat256.CreateExt();
    Nat256.Square(x, ext);
    SecP256R1Field.Reduce(ext, z);
    while (--n > 0)
    {
      Nat256.Square(z, ext);
      SecP256R1Field.Reduce(ext, z);
    }
  }

  public static void SquareN(uint[] x, int n, uint[] z, uint[] tt)
  {
    Nat256.Square(x, tt);
    SecP256R1Field.Reduce(tt, z);
    while (--n > 0)
    {
      Nat256.Square(z, tt);
      SecP256R1Field.Reduce(tt, z);
    }
  }

  public static void Subtract(uint[] x, uint[] y, uint[] z)
  {
    if (Nat256.Sub(x, y, z) == 0)
      return;
    SecP256R1Field.SubPInvFrom(z);
  }

  public static void SubtractExt(uint[] xx, uint[] yy, uint[] zz)
  {
    if (Nat.Sub(16 /*0x10*/, xx, yy, zz) == 0)
      return;
    int num = (int) Nat.AddTo(16 /*0x10*/, SecP256R1Field.PExt, zz);
  }

  public static void Twice(uint[] x, uint[] z)
  {
    if (Nat.ShiftUpBit(8, x, 0U, z) == 0U && (z[7] != uint.MaxValue || !Nat256.Gte(z, SecP256R1Field.P)))
      return;
    SecP256R1Field.AddPInvTo(z);
  }

  private static void AddPInvTo(uint[] z)
  {
    long num1 = (long) z[0] + 1L;
    z[0] = (uint) num1;
    long num2 = num1 >> 32 /*0x20*/;
    if (num2 != 0L)
    {
      long num3 = num2 + (long) z[1];
      z[1] = (uint) num3;
      long num4 = (num3 >> 32 /*0x20*/) + (long) z[2];
      z[2] = (uint) num4;
      num2 = num4 >> 32 /*0x20*/;
    }
    long num5 = num2 + ((long) z[3] - 1L);
    z[3] = (uint) num5;
    long num6 = num5 >> 32 /*0x20*/;
    if (num6 != 0L)
    {
      long num7 = num6 + (long) z[4];
      z[4] = (uint) num7;
      long num8 = (num7 >> 32 /*0x20*/) + (long) z[5];
      z[5] = (uint) num8;
      num6 = num8 >> 32 /*0x20*/;
    }
    long num9 = num6 + ((long) z[6] - 1L);
    z[6] = (uint) num9;
    long num10 = (num9 >> 32 /*0x20*/) + ((long) z[7] + 1L);
    z[7] = (uint) num10;
  }

  private static void SubPInvFrom(uint[] z)
  {
    long num1 = (long) z[0] - 1L;
    z[0] = (uint) num1;
    long num2 = num1 >> 32 /*0x20*/;
    if (num2 != 0L)
    {
      long num3 = num2 + (long) z[1];
      z[1] = (uint) num3;
      long num4 = (num3 >> 32 /*0x20*/) + (long) z[2];
      z[2] = (uint) num4;
      num2 = num4 >> 32 /*0x20*/;
    }
    long num5 = num2 + ((long) z[3] + 1L);
    z[3] = (uint) num5;
    long num6 = num5 >> 32 /*0x20*/;
    if (num6 != 0L)
    {
      long num7 = num6 + (long) z[4];
      z[4] = (uint) num7;
      long num8 = (num7 >> 32 /*0x20*/) + (long) z[5];
      z[5] = (uint) num8;
      num6 = num8 >> 32 /*0x20*/;
    }
    long num9 = num6 + ((long) z[6] + 1L);
    z[6] = (uint) num9;
    long num10 = (num9 >> 32 /*0x20*/) + ((long) z[7] - 1L);
    z[7] = (uint) num10;
  }
}
