// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Math.EC.Custom.GM.SM2P256V1Field
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto.Utilities;
using Org.BouncyCastle.Math.Raw;
using Org.BouncyCastle.Security;

#nullable disable
namespace Org.BouncyCastle.Math.EC.Custom.GM;

internal class SM2P256V1Field
{
  internal static readonly uint[] P = new uint[8]
  {
    uint.MaxValue,
    uint.MaxValue,
    0U,
    uint.MaxValue,
    uint.MaxValue,
    uint.MaxValue,
    uint.MaxValue,
    4294967294U
  };
  private static readonly uint[] PExt = new uint[16 /*0x10*/]
  {
    1U,
    0U,
    4294967294U,
    1U,
    1U,
    4294967294U,
    0U,
    2U,
    4294967294U,
    4294967293U,
    3U,
    4294967294U,
    uint.MaxValue,
    uint.MaxValue,
    0U,
    4294967294U
  };
  private const uint P7 = 4294967294;
  private const uint PExt15 = 4294967294;

  public static void Add(uint[] x, uint[] y, uint[] z)
  {
    if (Nat256.Add(x, y, z) == 0U && (z[7] < 4294967294U || !Nat256.Gte(z, SM2P256V1Field.P)))
      return;
    SM2P256V1Field.AddPInvTo(z);
  }

  public static void AddExt(uint[] xx, uint[] yy, uint[] zz)
  {
    if (Nat.Add(16 /*0x10*/, xx, yy, zz) == 0U && (zz[15] < 4294967294U || !Nat.Gte(16 /*0x10*/, zz, SM2P256V1Field.PExt)))
      return;
    Nat.SubFrom(16 /*0x10*/, SM2P256V1Field.PExt, zz);
  }

  public static void AddOne(uint[] x, uint[] z)
  {
    if (Nat.Inc(8, x, z) == 0U && (z[7] < 4294967294U || !Nat256.Gte(z, SM2P256V1Field.P)))
      return;
    SM2P256V1Field.AddPInvTo(z);
  }

  public static uint[] FromBigInteger(BigInteger x)
  {
    uint[] numArray = Nat.FromBigInteger(256 /*0x0100*/, x);
    if (numArray[7] >= 4294967294U && Nat256.Gte(numArray, SM2P256V1Field.P))
      Nat256.SubFrom(SM2P256V1Field.P, numArray, 0);
    return numArray;
  }

  public static void Inv(uint[] x, uint[] z) => Mod.CheckedModOddInverse(SM2P256V1Field.P, x, z);

  public static void Half(uint[] x, uint[] z)
  {
    if (((int) x[0] & 1) == 0)
    {
      int num1 = (int) Nat.ShiftDownBit(8, x, 0U, z);
    }
    else
    {
      uint c = Nat256.Add(x, SM2P256V1Field.P, z);
      int num2 = (int) Nat.ShiftDownBit(8, z, c);
    }
  }

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
    SM2P256V1Field.Reduce(ext, z);
  }

  public static void MultiplyAddToExt(uint[] x, uint[] y, uint[] zz)
  {
    if (Nat256.MulAddTo(x, y, zz) == 0U && (zz[15] < 4294967294U || !Nat.Gte(16 /*0x10*/, zz, SM2P256V1Field.PExt)))
      return;
    Nat.SubFrom(16 /*0x10*/, SM2P256V1Field.PExt, zz);
  }

  public static void Negate(uint[] x, uint[] z)
  {
    if (SM2P256V1Field.IsZero(x) != 0)
      Nat256.Sub(SM2P256V1Field.P, SM2P256V1Field.P, z);
    else
      Nat256.Sub(SM2P256V1Field.P, x, z);
  }

  public static void Random(SecureRandom r, uint[] z)
  {
    byte[] numArray = new byte[32 /*0x20*/];
    do
    {
      r.NextBytes(numArray);
      Pack.LE_To_UInt32(numArray, 0, z, 0, 8);
    }
    while (Nat.LessThan(8, z, SM2P256V1Field.P) == 0);
  }

  public static void RandomMult(SecureRandom r, uint[] z)
  {
    do
    {
      SM2P256V1Field.Random(r, z);
    }
    while (SM2P256V1Field.IsZero(z) != 0);
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
    long num9 = num1 + num2;
    long num10 = num3 + num4;
    long num11 = num5 + num8;
    long num12 = num6 + num7;
    long num13 = num12 + (num8 << 1);
    long num14 = num12;
    long num15 = num9 + num14;
    long num16 = num10 + num11 + num15;
    long num17 = 0L + ((long) xx[0] + num16 + num6 + num7 + num8);
    z[0] = (uint) num17;
    long num18 = (num17 >> 32 /*0x20*/) + ((long) xx[1] + num16 - num1 + num7 + num8);
    z[1] = (uint) num18;
    long num19 = (num18 >> 32 /*0x20*/) + ((long) xx[2] - num15);
    z[2] = (uint) num19;
    long num20 = (num19 >> 32 /*0x20*/) + ((long) xx[3] + num16 - num2 - num3 + num6);
    z[3] = (uint) num20;
    long num21 = (num20 >> 32 /*0x20*/) + ((long) xx[4] + num16 - num10 - num1 + num7);
    z[4] = (uint) num21;
    long num22 = (num21 >> 32 /*0x20*/) + ((long) xx[5] + num13 + num3);
    z[5] = (uint) num22;
    long num23 = (num22 >> 32 /*0x20*/) + ((long) xx[6] + num4 + num7 + num8);
    z[6] = (uint) num23;
    long num24 = (num23 >> 32 /*0x20*/) + ((long) xx[7] + num16 + num13 + num5);
    z[7] = (uint) num24;
    SM2P256V1Field.Reduce32((uint) (num24 >> 32 /*0x20*/), z);
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
        num4 = num5 >> 32 /*0x20*/;
      }
      long num6 = num4 + ((long) z[2] - num2);
      z[2] = (uint) num6;
      long num7 = (num6 >> 32 /*0x20*/) + ((long) z[3] + num2);
      z[3] = (uint) num7;
      long num8 = num7 >> 32 /*0x20*/;
      if (num8 != 0L)
      {
        long num9 = num8 + (long) z[4];
        z[4] = (uint) num9;
        long num10 = (num9 >> 32 /*0x20*/) + (long) z[5];
        z[5] = (uint) num10;
        long num11 = (num10 >> 32 /*0x20*/) + (long) z[6];
        z[6] = (uint) num11;
        num8 = num11 >> 32 /*0x20*/;
      }
      long num12 = num8 + ((long) z[7] + num2);
      z[7] = (uint) num12;
      num1 = num12 >> 32 /*0x20*/;
    }
    if (num1 == 0L && (z[7] < 4294967294U || !Nat256.Gte(z, SM2P256V1Field.P)))
      return;
    SM2P256V1Field.AddPInvTo(z);
  }

  public static void Square(uint[] x, uint[] z)
  {
    uint[] ext = Nat256.CreateExt();
    Nat256.Square(x, ext);
    SM2P256V1Field.Reduce(ext, z);
  }

  public static void SquareN(uint[] x, int n, uint[] z)
  {
    uint[] ext = Nat256.CreateExt();
    Nat256.Square(x, ext);
    SM2P256V1Field.Reduce(ext, z);
    while (--n > 0)
    {
      Nat256.Square(z, ext);
      SM2P256V1Field.Reduce(ext, z);
    }
  }

  public static void Subtract(uint[] x, uint[] y, uint[] z)
  {
    if (Nat256.Sub(x, y, z) == 0)
      return;
    SM2P256V1Field.SubPInvFrom(z);
  }

  public static void SubtractExt(uint[] xx, uint[] yy, uint[] zz)
  {
    if (Nat.Sub(16 /*0x10*/, xx, yy, zz) == 0)
      return;
    int num = (int) Nat.AddTo(16 /*0x10*/, SM2P256V1Field.PExt, zz);
  }

  public static void Twice(uint[] x, uint[] z)
  {
    if (Nat.ShiftUpBit(8, x, 0U, z) == 0U && (z[7] < 4294967294U || !Nat256.Gte(z, SM2P256V1Field.P)))
      return;
    SM2P256V1Field.AddPInvTo(z);
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
      num2 = num3 >> 32 /*0x20*/;
    }
    long num4 = num2 + ((long) z[2] - 1L);
    z[2] = (uint) num4;
    long num5 = (num4 >> 32 /*0x20*/) + ((long) z[3] + 1L);
    z[3] = (uint) num5;
    long num6 = num5 >> 32 /*0x20*/;
    if (num6 != 0L)
    {
      long num7 = num6 + (long) z[4];
      z[4] = (uint) num7;
      long num8 = (num7 >> 32 /*0x20*/) + (long) z[5];
      z[5] = (uint) num8;
      long num9 = (num8 >> 32 /*0x20*/) + (long) z[6];
      z[6] = (uint) num9;
      num6 = num9 >> 32 /*0x20*/;
    }
    long num10 = num6 + ((long) z[7] + 1L);
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
      num2 = num3 >> 32 /*0x20*/;
    }
    long num4 = num2 + ((long) z[2] + 1L);
    z[2] = (uint) num4;
    long num5 = (num4 >> 32 /*0x20*/) + ((long) z[3] - 1L);
    z[3] = (uint) num5;
    long num6 = num5 >> 32 /*0x20*/;
    if (num6 != 0L)
    {
      long num7 = num6 + (long) z[4];
      z[4] = (uint) num7;
      long num8 = (num7 >> 32 /*0x20*/) + (long) z[5];
      z[5] = (uint) num8;
      long num9 = (num8 >> 32 /*0x20*/) + (long) z[6];
      z[6] = (uint) num9;
      num6 = num9 >> 32 /*0x20*/;
    }
    long num10 = num6 + ((long) z[7] - 1L);
    z[7] = (uint) num10;
  }
}
