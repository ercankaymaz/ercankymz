// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Math.EC.Rfc7748.X25519Field
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Math.Raw;
using System;

#nullable disable
namespace Org.BouncyCastle.Math.EC.Rfc7748;

public static class X25519Field
{
  public const int Size = 10;
  private const int M24 = 16777215 /*0xFFFFFF*/;
  private const int M25 = 33554431 /*0x01FFFFFF*/;
  private const int M26 = 67108863 /*0x03FFFFFF*/;
  private static readonly uint[] P32 = new uint[8]
  {
    4294967277U,
    uint.MaxValue,
    uint.MaxValue,
    uint.MaxValue,
    uint.MaxValue,
    uint.MaxValue,
    uint.MaxValue,
    (uint) int.MaxValue
  };
  private static readonly int[] RootNegOne = new int[10]
  {
    34513072,
    59165138,
    4688974,
    3500415,
    6194736,
    33281959,
    54535759,
    32551604,
    163342,
    5703241
  };

  public static void Add(int[] x, int[] y, int[] z)
  {
    for (int index = 0; index < 10; ++index)
      z[index] = x[index] + y[index];
  }

  public static void AddOne(int[] z) => ++z[0];

  public static void AddOne(int[] z, int zOff) => ++z[zOff];

  public static void Apm(int[] x, int[] y, int[] zp, int[] zm)
  {
    for (int index = 0; index < 10; ++index)
    {
      int num1 = x[index];
      int num2 = y[index];
      zp[index] = num1 + num2;
      zm[index] = num1 - num2;
    }
  }

  public static int AreEqual(int[] x, int[] y)
  {
    int num = 0;
    for (int index = 0; index < 10; ++index)
      num |= x[index] ^ y[index];
    return ((num | num >> 16 /*0x10*/) & (int) ushort.MaxValue) - 1 >> 31 /*0x1F*/;
  }

  public static bool AreEqualVar(int[] x, int[] y) => X25519Field.AreEqual(x, y) != 0;

  public static void Carry(int[] z)
  {
    int num1 = z[0];
    int num2 = z[1];
    int num3 = z[2];
    int num4 = z[3];
    int num5 = z[4];
    int num6 = z[5];
    int num7 = z[6];
    int num8 = z[7];
    int num9 = z[8];
    int num10 = z[9];
    int num11 = num3 + (num2 >> 26);
    int num12 = num2 & 67108863 /*0x03FFFFFF*/;
    int num13 = num5 + (num4 >> 26);
    int num14 = num4 & 67108863 /*0x03FFFFFF*/;
    int num15 = num8 + (num7 >> 26);
    int num16 = num7 & 67108863 /*0x03FFFFFF*/;
    int num17 = num10 + (num9 >> 26);
    int num18 = num9 & 67108863 /*0x03FFFFFF*/;
    int num19 = num14 + (num11 >> 25);
    int num20 = num11 & 33554431 /*0x01FFFFFF*/;
    int num21 = num6 + (num13 >> 25);
    int num22 = num13 & 33554431 /*0x01FFFFFF*/;
    int num23 = num18 + (num15 >> 25);
    int num24 = num15 & 33554431 /*0x01FFFFFF*/;
    int num25 = num1 + (num17 >> 25) * 38;
    int num26 = num17 & 33554431 /*0x01FFFFFF*/;
    int num27 = num12 + (num25 >> 26);
    int num28 = num25 & 67108863 /*0x03FFFFFF*/;
    int num29 = num16 + (num21 >> 26);
    int num30 = num21 & 67108863 /*0x03FFFFFF*/;
    int num31 = num20 + (num27 >> 26);
    int num32 = num27 & 67108863 /*0x03FFFFFF*/;
    int num33 = num22 + (num19 >> 26);
    int num34 = num19 & 67108863 /*0x03FFFFFF*/;
    int num35 = num24 + (num29 >> 26);
    int num36 = num29 & 67108863 /*0x03FFFFFF*/;
    int num37 = num26 + (num23 >> 26);
    int num38 = num23 & 67108863 /*0x03FFFFFF*/;
    z[0] = num28;
    z[1] = num32;
    z[2] = num31;
    z[3] = num34;
    z[4] = num33;
    z[5] = num30;
    z[6] = num36;
    z[7] = num35;
    z[8] = num38;
    z[9] = num37;
  }

  public static void CMov(int cond, int[] x, int xOff, int[] z, int zOff)
  {
    for (int index = 0; index < 10; ++index)
    {
      int num1 = z[zOff + index];
      int num2 = num1 ^ x[xOff + index];
      int num3 = num1 ^ num2 & cond;
      z[zOff + index] = num3;
    }
  }

  public static void CNegate(int negate, int[] z)
  {
    int num = -negate;
    for (int index = 0; index < 10; ++index)
      z[index] = (z[index] ^ num) - num;
  }

  public static void Copy(int[] x, int xOff, int[] z, int zOff)
  {
    for (int index = 0; index < 10; ++index)
      z[zOff + index] = x[xOff + index];
  }

  public static int[] Create() => new int[10];

  public static int[] CreateTable(int n) => new int[10 * n];

  public static void CSwap(int swap, int[] a, int[] b)
  {
    int num1 = -swap;
    for (int index = 0; index < 10; ++index)
    {
      int num2 = a[index];
      int num3 = b[index];
      int num4 = num1 & (num2 ^ num3);
      a[index] = num2 ^ num4;
      b[index] = num3 ^ num4;
    }
  }

  [CLSCompliant(false)]
  public static void Decode(uint[] x, int xOff, int[] z)
  {
    X25519Field.Decode128(x, xOff, z, 0);
    X25519Field.Decode128(x, xOff + 4, z, 5);
    z[9] &= 16777215 /*0xFFFFFF*/;
  }

  public static void Decode(byte[] x, int[] z)
  {
    X25519Field.Decode128(x, 0, z, 0);
    X25519Field.Decode128(x, 16 /*0x10*/, z, 5);
    z[9] &= 16777215 /*0xFFFFFF*/;
  }

  public static void Decode(byte[] x, int xOff, int[] z)
  {
    X25519Field.Decode128(x, xOff, z, 0);
    X25519Field.Decode128(x, xOff + 16 /*0x10*/, z, 5);
    z[9] &= 16777215 /*0xFFFFFF*/;
  }

  public static void Decode(byte[] x, int xOff, int[] z, int zOff)
  {
    X25519Field.Decode128(x, xOff, z, zOff);
    X25519Field.Decode128(x, xOff + 16 /*0x10*/, z, zOff + 5);
    z[zOff + 9] &= 16777215 /*0xFFFFFF*/;
  }

  private static void Decode128(uint[] x, int xOff, int[] z, int zOff)
  {
    uint num1 = x[xOff];
    uint num2 = x[xOff + 1];
    uint num3 = x[xOff + 2];
    uint num4 = x[xOff + 3];
    z[zOff] = (int) num1 & 67108863 /*0x03FFFFFF*/;
    z[zOff + 1] = ((int) num2 << 6 | (int) (num1 >> 26)) & 67108863 /*0x03FFFFFF*/;
    z[zOff + 2] = ((int) num3 << 12 | (int) (num2 >> 20)) & 33554431 /*0x01FFFFFF*/;
    z[zOff + 3] = ((int) num4 << 19 | (int) (num3 >> 13)) & 67108863 /*0x03FFFFFF*/;
    z[zOff + 4] = (int) (num4 >> 7);
  }

  private static void Decode128(byte[] bs, int off, int[] z, int zOff)
  {
    uint num1 = X25519Field.Decode32(bs, off);
    uint num2 = X25519Field.Decode32(bs, off + 4);
    uint num3 = X25519Field.Decode32(bs, off + 8);
    uint num4 = X25519Field.Decode32(bs, off + 12);
    z[zOff] = (int) num1 & 67108863 /*0x03FFFFFF*/;
    z[zOff + 1] = ((int) num2 << 6 | (int) (num1 >> 26)) & 67108863 /*0x03FFFFFF*/;
    z[zOff + 2] = ((int) num3 << 12 | (int) (num2 >> 20)) & 33554431 /*0x01FFFFFF*/;
    z[zOff + 3] = ((int) num4 << 19 | (int) (num3 >> 13)) & 67108863 /*0x03FFFFFF*/;
    z[zOff + 4] = (int) (num4 >> 7);
  }

  private static uint Decode32(byte[] bs, int off)
  {
    return (uint) ((int) bs[off] | (int) bs[++off] << 8 | (int) bs[++off] << 16 /*0x10*/ | (int) bs[++off] << 24);
  }

  [CLSCompliant(false)]
  public static void Encode(int[] x, uint[] z, int zOff)
  {
    X25519Field.Encode128(x, 0, z, zOff);
    X25519Field.Encode128(x, 5, z, zOff + 4);
  }

  public static void Encode(int[] x, byte[] z)
  {
    X25519Field.Encode128(x, 0, z, 0);
    X25519Field.Encode128(x, 5, z, 16 /*0x10*/);
  }

  public static void Encode(int[] x, byte[] z, int zOff)
  {
    X25519Field.Encode128(x, 0, z, zOff);
    X25519Field.Encode128(x, 5, z, zOff + 16 /*0x10*/);
  }

  public static void Encode(int[] x, int xOff, byte[] z, int zOff)
  {
    X25519Field.Encode128(x, xOff, z, zOff);
    X25519Field.Encode128(x, xOff + 5, z, zOff + 16 /*0x10*/);
  }

  private static void Encode128(int[] x, int xOff, uint[] z, int zOff)
  {
    uint num1 = (uint) x[xOff];
    uint num2 = (uint) x[xOff + 1];
    uint num3 = (uint) x[xOff + 2];
    uint num4 = (uint) x[xOff + 3];
    uint num5 = (uint) x[xOff + 4];
    z[zOff] = num1 | num2 << 26;
    z[zOff + 1] = num2 >> 6 | num3 << 20;
    z[zOff + 2] = num3 >> 12 | num4 << 13;
    z[zOff + 3] = num4 >> 19 | num5 << 7;
  }

  private static void Encode128(int[] x, int xOff, byte[] bs, int off)
  {
    int num1 = x[xOff];
    uint num2 = (uint) x[xOff + 1];
    uint num3 = (uint) x[xOff + 2];
    uint num4 = (uint) x[xOff + 3];
    uint num5 = (uint) x[xOff + 4];
    int num6 = (int) num2 << 26;
    X25519Field.Encode32((uint) (num1 | num6), bs, off);
    X25519Field.Encode32(num2 >> 6 | num3 << 20, bs, off + 4);
    X25519Field.Encode32(num3 >> 12 | num4 << 13, bs, off + 8);
    X25519Field.Encode32(num4 >> 19 | num5 << 7, bs, off + 12);
  }

  private static void Encode32(uint n, byte[] bs, int off)
  {
    bs[off] = (byte) n;
    bs[++off] = (byte) (n >> 8);
    bs[++off] = (byte) (n >> 16 /*0x10*/);
    bs[++off] = (byte) (n >> 24);
  }

  public static void Inv(int[] x, int[] z)
  {
    int[] numArray1 = X25519Field.Create();
    uint[] numArray2 = new uint[8];
    X25519Field.Copy(x, 0, numArray1, 0);
    X25519Field.Normalize(numArray1);
    X25519Field.Encode(numArray1, numArray2, 0);
    int num = (int) Mod.ModOddInverse(X25519Field.P32, numArray2, numArray2);
    X25519Field.Decode(numArray2, 0, z);
  }

  public static void InvVar(int[] x, int[] z)
  {
    int[] numArray1 = X25519Field.Create();
    uint[] numArray2 = new uint[8];
    X25519Field.Copy(x, 0, numArray1, 0);
    X25519Field.Normalize(numArray1);
    X25519Field.Encode(numArray1, numArray2, 0);
    Mod.ModOddInverseVar(X25519Field.P32, numArray2, numArray2);
    X25519Field.Decode(numArray2, 0, z);
  }

  public static int IsOne(int[] x)
  {
    int num = x[0] ^ 1;
    for (int index = 1; index < 10; ++index)
      num |= x[index];
    return ((num | num >> 16 /*0x10*/) & (int) ushort.MaxValue) - 1 >> 31 /*0x1F*/;
  }

  public static bool IsOneVar(int[] x) => X25519Field.IsOne(x) != 0;

  public static int IsZero(int[] x)
  {
    int num = 0;
    for (int index = 0; index < 10; ++index)
      num |= x[index];
    return ((num | num >> 16 /*0x10*/) & (int) ushort.MaxValue) - 1 >> 31 /*0x1F*/;
  }

  public static bool IsZeroVar(int[] x) => X25519Field.IsZero(x) != 0;

  public static void Mul(int[] x, int y, int[] z)
  {
    int num1 = x[0];
    int num2 = x[1];
    int num3 = x[2];
    int num4 = x[3];
    int num5 = x[4];
    int num6 = x[5];
    int num7 = x[6];
    int num8 = x[7];
    int num9 = x[8];
    int num10 = x[9];
    long num11 = (long) num3 * (long) y;
    int num12 = (int) num11 & 33554431 /*0x01FFFFFF*/;
    long num13 = num11 >> 25;
    long num14 = (long) num5 * (long) y;
    int num15 = (int) num14 & 33554431 /*0x01FFFFFF*/;
    long num16 = num14 >> 25;
    long num17 = (long) num8 * (long) y;
    int num18 = (int) num17 & 33554431 /*0x01FFFFFF*/;
    long num19 = num17 >> 25;
    long num20 = (long) num10 * (long) y;
    int num21 = (int) num20 & 33554431 /*0x01FFFFFF*/;
    long num22 = (num20 >> 25) * 38L + (long) num1 * (long) y;
    z[0] = (int) num22 & 67108863 /*0x03FFFFFF*/;
    long num23 = num22 >> 26;
    long num24 = num16 + (long) num6 * (long) y;
    z[5] = (int) num24 & 67108863 /*0x03FFFFFF*/;
    long num25 = num24 >> 26;
    long num26 = num23 + (long) num2 * (long) y;
    z[1] = (int) num26 & 67108863 /*0x03FFFFFF*/;
    long num27 = num26 >> 26;
    long num28 = num13 + (long) num4 * (long) y;
    z[3] = (int) num28 & 67108863 /*0x03FFFFFF*/;
    long num29 = num28 >> 26;
    long num30 = num25 + (long) num7 * (long) y;
    z[6] = (int) num30 & 67108863 /*0x03FFFFFF*/;
    long num31 = num30 >> 26;
    long num32 = num19 + (long) num9 * (long) y;
    z[8] = (int) num32 & 67108863 /*0x03FFFFFF*/;
    long num33 = num32 >> 26;
    z[2] = num12 + (int) num27;
    z[4] = num15 + (int) num29;
    z[7] = num18 + (int) num31;
    z[9] = num21 + (int) num33;
  }

  public static void Mul(int[] x, int[] y, int[] z)
  {
    int num1 = x[0];
    int num2 = y[0];
    int num3 = x[1];
    int num4 = y[1];
    int num5 = x[2];
    int num6 = y[2];
    int num7 = x[3];
    int num8 = y[3];
    int num9 = x[4];
    int num10 = y[4];
    int num11 = x[5];
    int num12 = y[5];
    int num13 = x[6];
    int num14 = y[6];
    int num15 = x[7];
    int num16 = y[7];
    int num17 = x[8];
    int num18 = y[8];
    int num19 = x[9];
    int num20 = y[9];
    long num21 = (long) num1 * (long) num2;
    long num22 = (long) num1 * (long) num4 + (long) num3 * (long) num2;
    long num23 = (long) num1 * (long) num6 + (long) num3 * (long) num4 + (long) num5 * (long) num2;
    long num24 = ((long) num3 * (long) num6 + (long) num5 * (long) num4 << 1) + ((long) num1 * (long) num8 + (long) num7 * (long) num2);
    long num25 = ((long) num5 * (long) num6 << 1) + ((long) num1 * (long) num10 + (long) num3 * (long) num8 + (long) num7 * (long) num4 + (long) num9 * (long) num2);
    long num26 = (long) num3 * (long) num10 + (long) num5 * (long) num8 + (long) num7 * (long) num6 + (long) num9 * (long) num4 << 1;
    long num27 = ((long) num5 * (long) num10 + (long) num9 * (long) num6 << 1) + (long) num7 * (long) num8;
    long num28 = (long) num7 * (long) num10 + (long) num9 * (long) num8;
    long num29 = (long) num9 * (long) num10 << 1;
    long num30 = (long) num11 * (long) num12;
    long num31 = (long) num11 * (long) num14 + (long) num13 * (long) num12;
    long num32 = (long) num11 * (long) num16 + (long) num13 * (long) num14 + (long) num15 * (long) num12;
    long num33 = ((long) num13 * (long) num16 + (long) num15 * (long) num14 << 1) + ((long) num11 * (long) num18 + (long) num17 * (long) num12);
    long num34 = ((long) num15 * (long) num16 << 1) + ((long) num11 * (long) num20 + (long) num13 * (long) num18 + (long) num17 * (long) num14 + (long) num19 * (long) num12);
    long num35 = (long) num13 * (long) num20 + (long) num15 * (long) num18 + (long) num17 * (long) num16 + (long) num19 * (long) num14;
    long num36 = ((long) num15 * (long) num20 + (long) num19 * (long) num16 << 1) + (long) num17 * (long) num18;
    long num37 = (long) num17 * (long) num20 + (long) num19 * (long) num18;
    long num38 = (long) num19 * (long) num20;
    long num39 = num21 - num35 * 76L;
    long num40 = num22 - num36 * 38L;
    long num41 = num23 - num37 * 38L;
    long num42 = num24 - num38 * 76L;
    long num43 = num26 - num30;
    long num44 = num27 - num31;
    long num45 = num28 - num32;
    long num46 = num29 - num33;
    int num47 = num1 + num11;
    int num48 = num2 + num12;
    int num49 = num3 + num13;
    int num50 = num4 + num14;
    int num51 = num5 + num15;
    int num52 = num6 + num16;
    int num53 = num7 + num17;
    int num54 = num8 + num18;
    int num55 = num9 + num19;
    int num56 = num10 + num20;
    long num57 = (long) num47 * (long) num48;
    long num58 = (long) num47 * (long) num50 + (long) num49 * (long) num48;
    long num59 = (long) num47 * (long) num52 + (long) num49 * (long) num50 + (long) num51 * (long) num48;
    long num60 = ((long) num49 * (long) num52 + (long) num51 * (long) num50 << 1) + ((long) num47 * (long) num54 + (long) num53 * (long) num48);
    long num61 = ((long) num51 * (long) num52 << 1) + ((long) num47 * (long) num56 + (long) num49 * (long) num54 + (long) num53 * (long) num50 + (long) num55 * (long) num48);
    long num62 = (long) num49 * (long) num56 + (long) num51 * (long) num54 + (long) num53 * (long) num52 + (long) num55 * (long) num50 << 1;
    long num63 = ((long) num51 * (long) num56 + (long) num55 * (long) num52 << 1) + (long) num53 * (long) num54;
    long num64 = (long) num53 * (long) num56 + (long) num55 * (long) num54;
    long num65 = (long) num55 * (long) num56 << 1;
    long num66 = num46 + (num60 - num42);
    int num67 = (int) num66 & 67108863 /*0x03FFFFFF*/;
    long num68 = (num66 >> 26) + (num61 - num25 - num34);
    int num69 = (int) num68 & 33554431 /*0x01FFFFFF*/;
    long num70 = num68 >> 25;
    long num71 = num39 + (num70 + num62 - num43) * 38L;
    z[0] = (int) num71 & 67108863 /*0x03FFFFFF*/;
    long num72 = (num71 >> 26) + (num40 + (num63 - num44) * 38L);
    z[1] = (int) num72 & 67108863 /*0x03FFFFFF*/;
    long num73 = (num72 >> 26) + (num41 + (num64 - num45) * 38L);
    z[2] = (int) num73 & 33554431 /*0x01FFFFFF*/;
    long num74 = (num73 >> 25) + (num42 + (num65 - num46) * 38L);
    z[3] = (int) num74 & 67108863 /*0x03FFFFFF*/;
    long num75 = (num74 >> 26) + (num25 + num34 * 38L);
    z[4] = (int) num75 & 33554431 /*0x01FFFFFF*/;
    long num76 = (num75 >> 25) + (num43 + (num57 - num39));
    z[5] = (int) num76 & 67108863 /*0x03FFFFFF*/;
    long num77 = (num76 >> 26) + (num44 + (num58 - num40));
    z[6] = (int) num77 & 67108863 /*0x03FFFFFF*/;
    long num78 = (num77 >> 26) + (num45 + (num59 - num41));
    z[7] = (int) num78 & 33554431 /*0x01FFFFFF*/;
    long num79 = (num78 >> 25) + (long) num67;
    z[8] = (int) num79 & 67108863 /*0x03FFFFFF*/;
    long num80 = num79 >> 26;
    z[9] = num69 + (int) num80;
  }

  public static void Negate(int[] x, int[] z)
  {
    for (int index = 0; index < 10; ++index)
      z[index] = -x[index];
  }

  public static void Normalize(int[] z)
  {
    int x = z[9] >> 23 & 1;
    X25519Field.Reduce(z, x);
    X25519Field.Reduce(z, -x);
  }

  public static void One(int[] z)
  {
    z[0] = 1;
    for (int index = 1; index < 10; ++index)
      z[index] = 0;
  }

  private static void PowPm5d8(int[] x, int[] rx2, int[] rz)
  {
    int[] numArray1 = rx2;
    X25519Field.Sqr(x, numArray1);
    X25519Field.Mul(x, numArray1, numArray1);
    int[] numArray2 = X25519Field.Create();
    X25519Field.Sqr(numArray1, numArray2);
    X25519Field.Mul(x, numArray2, numArray2);
    int[] numArray3 = numArray2;
    X25519Field.Sqr(numArray2, 2, numArray3);
    X25519Field.Mul(numArray1, numArray3, numArray3);
    int[] numArray4 = X25519Field.Create();
    X25519Field.Sqr(numArray3, 5, numArray4);
    X25519Field.Mul(numArray3, numArray4, numArray4);
    int[] numArray5 = X25519Field.Create();
    X25519Field.Sqr(numArray4, 5, numArray5);
    X25519Field.Mul(numArray3, numArray5, numArray5);
    int[] numArray6 = numArray3;
    X25519Field.Sqr(numArray5, 10, numArray6);
    X25519Field.Mul(numArray4, numArray6, numArray6);
    int[] numArray7 = numArray4;
    X25519Field.Sqr(numArray6, 25, numArray7);
    X25519Field.Mul(numArray6, numArray7, numArray7);
    int[] numArray8 = numArray5;
    X25519Field.Sqr(numArray7, 25, numArray8);
    X25519Field.Mul(numArray6, numArray8, numArray8);
    int[] numArray9 = numArray6;
    X25519Field.Sqr(numArray8, 50, numArray9);
    X25519Field.Mul(numArray7, numArray9, numArray9);
    int[] numArray10 = numArray7;
    X25519Field.Sqr(numArray9, 125, numArray10);
    X25519Field.Mul(numArray9, numArray10, numArray10);
    int[] numArray11 = numArray9;
    X25519Field.Sqr(numArray10, 2, numArray11);
    X25519Field.Mul(numArray11, x, rz);
  }

  private static void Reduce(int[] z, int x)
  {
    int num1 = z[9];
    int num2 = num1 & 16777215 /*0xFFFFFF*/;
    long num3 = (long) (((num1 >> 24) + x) * 19) + (long) z[0];
    z[0] = (int) num3 & 67108863 /*0x03FFFFFF*/;
    long num4 = (num3 >> 26) + (long) z[1];
    z[1] = (int) num4 & 67108863 /*0x03FFFFFF*/;
    long num5 = (num4 >> 26) + (long) z[2];
    z[2] = (int) num5 & 33554431 /*0x01FFFFFF*/;
    long num6 = (num5 >> 25) + (long) z[3];
    z[3] = (int) num6 & 67108863 /*0x03FFFFFF*/;
    long num7 = (num6 >> 26) + (long) z[4];
    z[4] = (int) num7 & 33554431 /*0x01FFFFFF*/;
    long num8 = (num7 >> 25) + (long) z[5];
    z[5] = (int) num8 & 67108863 /*0x03FFFFFF*/;
    long num9 = (num8 >> 26) + (long) z[6];
    z[6] = (int) num9 & 67108863 /*0x03FFFFFF*/;
    long num10 = (num9 >> 26) + (long) z[7];
    z[7] = (int) num10 & 33554431 /*0x01FFFFFF*/;
    long num11 = (num10 >> 25) + (long) z[8];
    z[8] = (int) num11 & 67108863 /*0x03FFFFFF*/;
    long num12 = num11 >> 26;
    z[9] = num2 + (int) num12;
  }

  public static void Sqr(int[] x, int[] z)
  {
    int num1 = x[0];
    int num2 = x[1];
    int num3 = x[2];
    int num4 = x[3];
    int num5 = x[4];
    int num6 = x[5];
    int num7 = x[6];
    int num8 = x[7];
    int num9 = x[8];
    int num10 = x[9];
    int num11 = num2 * 2;
    int num12 = num3 * 2;
    int num13 = num4 * 2;
    int num14 = num5 * 2;
    long num15 = (long) num1 * (long) num1;
    long num16 = (long) num1 * (long) num11;
    long num17 = (long) num1 * (long) num12 + (long) num2 * (long) num2;
    long num18 = (long) num11 * (long) num12 + (long) num1 * (long) num13;
    long num19 = (long) num3 * (long) num12 + (long) num1 * (long) num14 + (long) num2 * (long) num13;
    long num20 = (long) num11 * (long) num14 + (long) num12 * (long) num13;
    long num21 = (long) num12 * (long) num14 + (long) num4 * (long) num4;
    long num22 = (long) num4 * (long) num14;
    long num23 = (long) num5 * (long) num14;
    int num24 = num7 * 2;
    int num25 = num8 * 2;
    int num26 = num9 * 2;
    int num27 = num10 * 2;
    long num28 = (long) num6 * (long) num6;
    long num29 = (long) num6 * (long) num24;
    long num30 = (long) num6 * (long) num25 + (long) num7 * (long) num7;
    long num31 = (long) num24 * (long) num25 + (long) num6 * (long) num26;
    long num32 = (long) num8 * (long) num25 + (long) num6 * (long) num27 + (long) num7 * (long) num26;
    long num33 = (long) num24 * (long) num27 + (long) num25 * (long) num26;
    long num34 = (long) num25 * (long) num27 + (long) num9 * (long) num9;
    long num35 = (long) num9 * (long) num27;
    long num36 = (long) num10 * (long) num27;
    long num37 = num15 - num33 * 38L;
    long num38 = num16 - num34 * 38L;
    long num39 = num17 - num35 * 38L;
    long num40 = num18 - num36 * 38L;
    long num41 = num20 - num28;
    long num42 = num21 - num29;
    long num43 = num22 - num30;
    long num44 = num23 - num31;
    int num45 = num1 + num6;
    int num46 = num2 + num7;
    int num47 = num3 + num8;
    int num48 = num4 + num9;
    int num49 = num5 + num10;
    int num50 = num46 * 2;
    int num51 = num47 * 2;
    int num52 = num48 * 2;
    int num53 = num49 * 2;
    long num54 = (long) num45 * (long) num45;
    long num55 = (long) num45 * (long) num50;
    long num56 = (long) num45 * (long) num51 + (long) num46 * (long) num46;
    long num57 = (long) num50 * (long) num51 + (long) num45 * (long) num52;
    long num58 = (long) num47 * (long) num51 + (long) num45 * (long) num53 + (long) num46 * (long) num52;
    long num59 = (long) num50 * (long) num53 + (long) num51 * (long) num52;
    long num60 = (long) num51 * (long) num53 + (long) num48 * (long) num48;
    long num61 = (long) num48 * (long) num53;
    long num62 = (long) num49 * (long) num53;
    long num63 = num44 + (num57 - num40);
    int num64 = (int) num63 & 67108863 /*0x03FFFFFF*/;
    long num65 = (num63 >> 26) + (num58 - num19 - num32);
    int num66 = (int) num65 & 33554431 /*0x01FFFFFF*/;
    long num67 = num65 >> 25;
    long num68 = num37 + (num67 + num59 - num41) * 38L;
    z[0] = (int) num68 & 67108863 /*0x03FFFFFF*/;
    long num69 = (num68 >> 26) + (num38 + (num60 - num42) * 38L);
    z[1] = (int) num69 & 67108863 /*0x03FFFFFF*/;
    long num70 = (num69 >> 26) + (num39 + (num61 - num43) * 38L);
    z[2] = (int) num70 & 33554431 /*0x01FFFFFF*/;
    long num71 = (num70 >> 25) + (num40 + (num62 - num44) * 38L);
    z[3] = (int) num71 & 67108863 /*0x03FFFFFF*/;
    long num72 = (num71 >> 26) + (num19 + num32 * 38L);
    z[4] = (int) num72 & 33554431 /*0x01FFFFFF*/;
    long num73 = (num72 >> 25) + (num41 + (num54 - num37));
    z[5] = (int) num73 & 67108863 /*0x03FFFFFF*/;
    long num74 = (num73 >> 26) + (num42 + (num55 - num38));
    z[6] = (int) num74 & 67108863 /*0x03FFFFFF*/;
    long num75 = (num74 >> 26) + (num43 + (num56 - num39));
    z[7] = (int) num75 & 33554431 /*0x01FFFFFF*/;
    long num76 = (num75 >> 25) + (long) num64;
    z[8] = (int) num76 & 67108863 /*0x03FFFFFF*/;
    long num77 = num76 >> 26;
    z[9] = num66 + (int) num77;
  }

  public static void Sqr(int[] x, int n, int[] z)
  {
    X25519Field.Sqr(x, z);
    while (--n > 0)
      X25519Field.Sqr(z, z);
  }

  public static bool SqrtRatioVar(int[] u, int[] v, int[] z)
  {
    int[] numArray1 = X25519Field.Create();
    int[] numArray2 = X25519Field.Create();
    X25519Field.Mul(u, v, numArray1);
    X25519Field.Sqr(v, numArray2);
    X25519Field.Mul(numArray1, numArray2, numArray1);
    X25519Field.Sqr(numArray2, numArray2);
    X25519Field.Mul(numArray2, numArray1, numArray2);
    int[] numArray3 = X25519Field.Create();
    int[] numArray4 = X25519Field.Create();
    X25519Field.PowPm5d8(numArray2, numArray3, numArray4);
    X25519Field.Mul(numArray4, numArray1, numArray4);
    int[] numArray5 = X25519Field.Create();
    X25519Field.Sqr(numArray4, numArray5);
    X25519Field.Mul(numArray5, v, numArray5);
    X25519Field.Sub(numArray5, u, numArray3);
    X25519Field.Normalize(numArray3);
    if (X25519Field.IsZeroVar(numArray3))
    {
      X25519Field.Copy(numArray4, 0, z, 0);
      return true;
    }
    X25519Field.Add(numArray5, u, numArray3);
    X25519Field.Normalize(numArray3);
    if (!X25519Field.IsZeroVar(numArray3))
      return false;
    X25519Field.Mul(numArray4, X25519Field.RootNegOne, z);
    return true;
  }

  public static void Sub(int[] x, int[] y, int[] z)
  {
    for (int index = 0; index < 10; ++index)
      z[index] = x[index] - y[index];
  }

  public static void SubOne(int[] z) => --z[0];

  public static void Zero(int[] z)
  {
    for (int index = 0; index < 10; ++index)
      z[index] = 0;
  }
}
