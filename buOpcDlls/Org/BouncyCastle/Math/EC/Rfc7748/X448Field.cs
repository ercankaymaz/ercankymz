// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Math.EC.Rfc7748.X448Field
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Math.Raw;
using System;

#nullable disable
namespace Org.BouncyCastle.Math.EC.Rfc7748;

[CLSCompliant(false)]
public static class X448Field
{
  public const int Size = 16 /*0x10*/;
  private const uint M28 = 268435455 /*0x0FFFFFFF*/;
  private static readonly uint[] P32 = new uint[14]
  {
    uint.MaxValue,
    uint.MaxValue,
    uint.MaxValue,
    uint.MaxValue,
    uint.MaxValue,
    uint.MaxValue,
    uint.MaxValue,
    4294967294U,
    uint.MaxValue,
    uint.MaxValue,
    uint.MaxValue,
    uint.MaxValue,
    uint.MaxValue,
    uint.MaxValue
  };

  public static void Add(uint[] x, uint[] y, uint[] z)
  {
    for (int index = 0; index < 16 /*0x10*/; ++index)
      z[index] = x[index] + y[index];
  }

  public static void AddOne(uint[] z) => ++z[0];

  public static void AddOne(uint[] z, int zOff) => ++z[zOff];

  public static int AreEqual(uint[] x, uint[] y)
  {
    uint num = 0;
    for (int index = 0; index < 16 /*0x10*/; ++index)
      num |= x[index] ^ y[index];
    return (int) ((num | num >> 16 /*0x10*/) & (uint) ushort.MaxValue) - 1 >> 31 /*0x1F*/;
  }

  public static bool AreEqualVar(uint[] x, uint[] y) => X448Field.AreEqual(x, y) != 0;

  public static void Carry(uint[] z)
  {
    uint num1 = z[0];
    uint num2 = z[1];
    uint num3 = z[2];
    uint num4 = z[3];
    uint num5 = z[4];
    uint num6 = z[5];
    uint num7 = z[6];
    uint num8 = z[7];
    uint num9 = z[8];
    uint num10 = z[9];
    uint num11 = z[10];
    uint num12 = z[11];
    uint num13 = z[12];
    uint num14 = z[13];
    uint num15 = z[14];
    uint num16 = z[15];
    uint num17 = num2 + (num1 >> 28);
    uint num18 = num1 & 268435455U /*0x0FFFFFFF*/;
    uint num19 = num6 + (num5 >> 28);
    uint num20 = num5 & 268435455U /*0x0FFFFFFF*/;
    uint num21 = num10 + (num9 >> 28);
    uint num22 = num9 & 268435455U /*0x0FFFFFFF*/;
    uint num23 = num14 + (num13 >> 28);
    uint num24 = num13 & 268435455U /*0x0FFFFFFF*/;
    uint num25 = num3 + (num17 >> 28);
    uint num26 = num17 & 268435455U /*0x0FFFFFFF*/;
    uint num27 = num7 + (num19 >> 28);
    uint num28 = num19 & 268435455U /*0x0FFFFFFF*/;
    uint num29 = num11 + (num21 >> 28);
    uint num30 = num21 & 268435455U /*0x0FFFFFFF*/;
    uint num31 = num15 + (num23 >> 28);
    uint num32 = num23 & 268435455U /*0x0FFFFFFF*/;
    uint num33 = num4 + (num25 >> 28);
    uint num34 = num25 & 268435455U /*0x0FFFFFFF*/;
    uint num35 = num8 + (num27 >> 28);
    uint num36 = num27 & 268435455U /*0x0FFFFFFF*/;
    uint num37 = num12 + (num29 >> 28);
    uint num38 = num29 & 268435455U /*0x0FFFFFFF*/;
    uint num39 = num16 + (num31 >> 28);
    uint num40 = num31 & 268435455U /*0x0FFFFFFF*/;
    uint num41 = num39 >> 28;
    uint num42 = num39 & 268435455U /*0x0FFFFFFF*/;
    uint num43 = num18 + num41;
    uint num44 = num22 + num41;
    uint num45 = num20 + (num33 >> 28);
    uint num46 = num33 & 268435455U /*0x0FFFFFFF*/;
    uint num47 = num44 + (num35 >> 28);
    uint num48 = num35 & 268435455U /*0x0FFFFFFF*/;
    uint num49 = num24 + (num37 >> 28);
    uint num50 = num37 & 268435455U /*0x0FFFFFFF*/;
    uint num51 = num26 + (num43 >> 28);
    uint num52 = num43 & 268435455U /*0x0FFFFFFF*/;
    uint num53 = num28 + (num45 >> 28);
    uint num54 = num45 & 268435455U /*0x0FFFFFFF*/;
    uint num55 = num30 + (num47 >> 28);
    uint num56 = num47 & 268435455U /*0x0FFFFFFF*/;
    uint num57 = num32 + (num49 >> 28);
    uint num58 = num49 & 268435455U /*0x0FFFFFFF*/;
    z[0] = num52;
    z[1] = num51;
    z[2] = num34;
    z[3] = num46;
    z[4] = num54;
    z[5] = num53;
    z[6] = num36;
    z[7] = num48;
    z[8] = num56;
    z[9] = num55;
    z[10] = num38;
    z[11] = num50;
    z[12] = num58;
    z[13] = num57;
    z[14] = num40;
    z[15] = num42;
  }

  public static void CMov(int cond, uint[] x, int xOff, uint[] z, int zOff)
  {
    uint num1 = (uint) cond;
    for (int index = 0; index < 16 /*0x10*/; ++index)
    {
      uint num2 = z[zOff + index];
      uint num3 = num2 ^ x[xOff + index];
      uint num4 = num2 ^ num3 & num1;
      z[zOff + index] = num4;
    }
  }

  public static void CNegate(int negate, uint[] z)
  {
    uint[] numArray = X448Field.Create();
    X448Field.Sub(numArray, z, numArray);
    X448Field.CMov(-negate, numArray, 0, z, 0);
  }

  public static void Copy(uint[] x, int xOff, uint[] z, int zOff)
  {
    for (int index = 0; index < 16 /*0x10*/; ++index)
      z[zOff + index] = x[xOff + index];
  }

  public static uint[] Create() => new uint[16 /*0x10*/];

  public static uint[] CreateTable(int n) => new uint[16 /*0x10*/ * n];

  public static void CSwap(int swap, uint[] a, uint[] b)
  {
    uint num1 = (uint) -swap;
    for (int index = 0; index < 16 /*0x10*/; ++index)
    {
      uint num2 = a[index];
      uint num3 = b[index];
      uint num4 = num1 & (num2 ^ num3);
      a[index] = num2 ^ num4;
      b[index] = num3 ^ num4;
    }
  }

  public static void Decode(uint[] x, int xOff, uint[] z)
  {
    X448Field.Decode224(x, xOff, z, 0);
    X448Field.Decode224(x, xOff + 7, z, 8);
  }

  public static void Decode(byte[] x, uint[] z)
  {
    X448Field.Decode56(x, 0, z, 0);
    X448Field.Decode56(x, 7, z, 2);
    X448Field.Decode56(x, 14, z, 4);
    X448Field.Decode56(x, 21, z, 6);
    X448Field.Decode56(x, 28, z, 8);
    X448Field.Decode56(x, 35, z, 10);
    X448Field.Decode56(x, 42, z, 12);
    X448Field.Decode56(x, 49, z, 14);
  }

  public static void Decode(byte[] x, int xOff, uint[] z)
  {
    X448Field.Decode56(x, xOff, z, 0);
    X448Field.Decode56(x, xOff + 7, z, 2);
    X448Field.Decode56(x, xOff + 14, z, 4);
    X448Field.Decode56(x, xOff + 21, z, 6);
    X448Field.Decode56(x, xOff + 28, z, 8);
    X448Field.Decode56(x, xOff + 35, z, 10);
    X448Field.Decode56(x, xOff + 42, z, 12);
    X448Field.Decode56(x, xOff + 49, z, 14);
  }

  public static void Decode(byte[] x, int xOff, uint[] z, int zOff)
  {
    X448Field.Decode56(x, xOff, z, zOff);
    X448Field.Decode56(x, xOff + 7, z, zOff + 2);
    X448Field.Decode56(x, xOff + 14, z, zOff + 4);
    X448Field.Decode56(x, xOff + 21, z, zOff + 6);
    X448Field.Decode56(x, xOff + 28, z, zOff + 8);
    X448Field.Decode56(x, xOff + 35, z, zOff + 10);
    X448Field.Decode56(x, xOff + 42, z, zOff + 12);
    X448Field.Decode56(x, xOff + 49, z, zOff + 14);
  }

  private static void Decode224(uint[] x, int xOff, uint[] z, int zOff)
  {
    uint num1 = x[xOff];
    uint num2 = x[xOff + 1];
    uint num3 = x[xOff + 2];
    uint num4 = x[xOff + 3];
    uint num5 = x[xOff + 4];
    uint num6 = x[xOff + 5];
    uint num7 = x[xOff + 6];
    z[zOff] = num1 & 268435455U /*0x0FFFFFFF*/;
    z[zOff + 1] = (uint) (((int) (num1 >> 28) | (int) num2 << 4) & 268435455 /*0x0FFFFFFF*/);
    z[zOff + 2] = (uint) (((int) (num2 >> 24) | (int) num3 << 8) & 268435455 /*0x0FFFFFFF*/);
    z[zOff + 3] = (uint) (((int) (num3 >> 20) | (int) num4 << 12) & 268435455 /*0x0FFFFFFF*/);
    z[zOff + 4] = (uint) (((int) (num4 >> 16 /*0x10*/) | (int) num5 << 16 /*0x10*/) & 268435455 /*0x0FFFFFFF*/);
    z[zOff + 5] = (uint) (((int) (num5 >> 12) | (int) num6 << 20) & 268435455 /*0x0FFFFFFF*/);
    z[zOff + 6] = (uint) (((int) (num6 >> 8) | (int) num7 << 24) & 268435455 /*0x0FFFFFFF*/);
    z[zOff + 7] = num7 >> 4;
  }

  private static uint Decode24(byte[] bs, int off)
  {
    return (uint) ((int) bs[off] | (int) bs[++off] << 8 | (int) bs[++off] << 16 /*0x10*/);
  }

  private static uint Decode32(byte[] bs, int off)
  {
    return (uint) ((int) bs[off] | (int) bs[++off] << 8 | (int) bs[++off] << 16 /*0x10*/ | (int) bs[++off] << 24);
  }

  private static void Decode56(byte[] bs, int off, uint[] z, int zOff)
  {
    uint num1 = X448Field.Decode32(bs, off);
    uint num2 = X448Field.Decode24(bs, off + 4);
    z[zOff] = num1 & 268435455U /*0x0FFFFFFF*/;
    z[zOff + 1] = num1 >> 28 | num2 << 4;
  }

  public static void Encode(uint[] x, uint[] z, int zOff)
  {
    X448Field.Encode224(x, 0, z, zOff);
    X448Field.Encode224(x, 8, z, zOff + 7);
  }

  public static void Encode(uint[] x, byte[] z)
  {
    X448Field.Encode56(x, 0, z, 0);
    X448Field.Encode56(x, 2, z, 7);
    X448Field.Encode56(x, 4, z, 14);
    X448Field.Encode56(x, 6, z, 21);
    X448Field.Encode56(x, 8, z, 28);
    X448Field.Encode56(x, 10, z, 35);
    X448Field.Encode56(x, 12, z, 42);
    X448Field.Encode56(x, 14, z, 49);
  }

  public static void Encode(uint[] x, byte[] z, int zOff)
  {
    X448Field.Encode56(x, 0, z, zOff);
    X448Field.Encode56(x, 2, z, zOff + 7);
    X448Field.Encode56(x, 4, z, zOff + 14);
    X448Field.Encode56(x, 6, z, zOff + 21);
    X448Field.Encode56(x, 8, z, zOff + 28);
    X448Field.Encode56(x, 10, z, zOff + 35);
    X448Field.Encode56(x, 12, z, zOff + 42);
    X448Field.Encode56(x, 14, z, zOff + 49);
  }

  public static void Encode(uint[] x, int xOff, byte[] z, int zOff)
  {
    X448Field.Encode56(x, xOff, z, zOff);
    X448Field.Encode56(x, xOff + 2, z, zOff + 7);
    X448Field.Encode56(x, xOff + 4, z, zOff + 14);
    X448Field.Encode56(x, xOff + 6, z, zOff + 21);
    X448Field.Encode56(x, xOff + 8, z, zOff + 28);
    X448Field.Encode56(x, xOff + 10, z, zOff + 35);
    X448Field.Encode56(x, xOff + 12, z, zOff + 42);
    X448Field.Encode56(x, xOff + 14, z, zOff + 49);
  }

  private static void Encode224(uint[] x, int xOff, uint[] z, int zOff)
  {
    uint num1 = x[xOff];
    uint num2 = x[xOff + 1];
    uint num3 = x[xOff + 2];
    uint num4 = x[xOff + 3];
    uint num5 = x[xOff + 4];
    uint num6 = x[xOff + 5];
    uint num7 = x[xOff + 6];
    uint num8 = x[xOff + 7];
    z[zOff] = num1 | num2 << 28;
    z[zOff + 1] = num2 >> 4 | num3 << 24;
    z[zOff + 2] = num3 >> 8 | num4 << 20;
    z[zOff + 3] = num4 >> 12 | num5 << 16 /*0x10*/;
    z[zOff + 4] = num5 >> 16 /*0x10*/ | num6 << 12;
    z[zOff + 5] = num6 >> 20 | num7 << 8;
    z[zOff + 6] = num7 >> 24 | num8 << 4;
  }

  private static void Encode24(uint n, byte[] bs, int off)
  {
    bs[off] = (byte) n;
    bs[++off] = (byte) (n >> 8);
    bs[++off] = (byte) (n >> 16 /*0x10*/);
  }

  private static void Encode32(uint n, byte[] bs, int off)
  {
    bs[off] = (byte) n;
    bs[++off] = (byte) (n >> 8);
    bs[++off] = (byte) (n >> 16 /*0x10*/);
    bs[++off] = (byte) (n >> 24);
  }

  private static void Encode56(uint[] x, int xOff, byte[] bs, int off)
  {
    int num1 = (int) x[xOff];
    uint num2 = x[xOff + 1];
    int num3 = (int) num2 << 28;
    X448Field.Encode32((uint) (num1 | num3), bs, off);
    X448Field.Encode24(num2 >> 4, bs, off + 4);
  }

  public static void Inv(uint[] x, uint[] z)
  {
    uint[] numArray1 = X448Field.Create();
    uint[] numArray2 = new uint[14];
    X448Field.Copy(x, 0, numArray1, 0);
    X448Field.Normalize(numArray1);
    X448Field.Encode(numArray1, numArray2, 0);
    int num = (int) Mod.ModOddInverse(X448Field.P32, numArray2, numArray2);
    X448Field.Decode(numArray2, 0, z);
  }

  public static void InvVar(uint[] x, uint[] z)
  {
    uint[] numArray1 = X448Field.Create();
    uint[] numArray2 = new uint[14];
    X448Field.Copy(x, 0, numArray1, 0);
    X448Field.Normalize(numArray1);
    X448Field.Encode(numArray1, numArray2, 0);
    Mod.ModOddInverseVar(X448Field.P32, numArray2, numArray2);
    X448Field.Decode(numArray2, 0, z);
  }

  public static int IsOne(uint[] x)
  {
    uint num = x[0] ^ 1U;
    for (int index = 1; index < 16 /*0x10*/; ++index)
      num |= x[index];
    return (int) ((num | num >> 16 /*0x10*/) & (uint) ushort.MaxValue) - 1 >> 31 /*0x1F*/;
  }

  public static bool IsOneVar(uint[] x) => X448Field.IsOne(x) != 0;

  public static int IsZero(uint[] x)
  {
    uint num = 0;
    for (int index = 0; index < 16 /*0x10*/; ++index)
      num |= x[index];
    return (int) ((num | num >> 16 /*0x10*/) & (uint) ushort.MaxValue) - 1 >> 31 /*0x1F*/;
  }

  public static bool IsZeroVar(uint[] x) => X448Field.IsZero(x) != 0;

  public static void Mul(uint[] x, uint y, uint[] z)
  {
    uint num1 = x[0];
    uint num2 = x[1];
    uint num3 = x[2];
    uint num4 = x[3];
    uint num5 = x[4];
    uint num6 = x[5];
    uint num7 = x[6];
    uint num8 = x[7];
    uint num9 = x[8];
    uint num10 = x[9];
    uint num11 = x[10];
    uint num12 = x[11];
    uint num13 = x[12];
    int num14 = (int) x[13];
    uint num15 = x[14];
    uint num16 = x[15];
    ulong num17 = (ulong) num2 * (ulong) y;
    uint num18 = (uint) num17 & 268435455U /*0x0FFFFFFF*/;
    ulong num19 = num17 >> 28;
    ulong num20 = (ulong) num6 * (ulong) y;
    uint num21 = (uint) num20 & 268435455U /*0x0FFFFFFF*/;
    ulong num22 = num20 >> 28;
    ulong num23 = (ulong) num10 * (ulong) y;
    uint num24 = (uint) num23 & 268435455U /*0x0FFFFFFF*/;
    ulong num25 = num23 >> 28;
    ulong num26 = (ulong) (uint) num14 * (ulong) y;
    uint num27 = (uint) num26 & 268435455U /*0x0FFFFFFF*/;
    ulong num28 = num26 >> 28;
    ulong num29 = num19 + (ulong) num3 * (ulong) y;
    z[2] = (uint) num29 & 268435455U /*0x0FFFFFFF*/;
    ulong num30 = num29 >> 28;
    ulong num31 = num22 + (ulong) num7 * (ulong) y;
    z[6] = (uint) num31 & 268435455U /*0x0FFFFFFF*/;
    ulong num32 = num31 >> 28;
    ulong num33 = num25 + (ulong) num11 * (ulong) y;
    z[10] = (uint) num33 & 268435455U /*0x0FFFFFFF*/;
    ulong num34 = num33 >> 28;
    ulong num35 = num28 + (ulong) num15 * (ulong) y;
    z[14] = (uint) num35 & 268435455U /*0x0FFFFFFF*/;
    ulong num36 = num35 >> 28;
    ulong num37 = num30 + (ulong) num4 * (ulong) y;
    z[3] = (uint) num37 & 268435455U /*0x0FFFFFFF*/;
    ulong num38 = num37 >> 28;
    ulong num39 = num32 + (ulong) num8 * (ulong) y;
    z[7] = (uint) num39 & 268435455U /*0x0FFFFFFF*/;
    ulong num40 = num39 >> 28;
    ulong num41 = num34 + (ulong) num12 * (ulong) y;
    z[11] = (uint) num41 & 268435455U /*0x0FFFFFFF*/;
    ulong num42 = num41 >> 28;
    ulong num43 = num36 + (ulong) num16 * (ulong) y;
    z[15] = (uint) num43 & 268435455U /*0x0FFFFFFF*/;
    ulong num44 = num43 >> 28;
    ulong num45 = num40 + num44;
    ulong num46 = num38 + (ulong) num5 * (ulong) y;
    z[4] = (uint) num46 & 268435455U /*0x0FFFFFFF*/;
    ulong num47 = num46 >> 28;
    ulong num48 = num45 + (ulong) num9 * (ulong) y;
    z[8] = (uint) num48 & 268435455U /*0x0FFFFFFF*/;
    ulong num49 = num48 >> 28;
    ulong num50 = num42 + (ulong) num13 * (ulong) y;
    z[12] = (uint) num50 & 268435455U /*0x0FFFFFFF*/;
    ulong num51 = num50 >> 28;
    ulong num52 = num44 + (ulong) num1 * (ulong) y;
    z[0] = (uint) num52 & 268435455U /*0x0FFFFFFF*/;
    ulong num53 = num52 >> 28;
    z[1] = num18 + (uint) num53;
    z[5] = num21 + (uint) num47;
    z[9] = num24 + (uint) num49;
    z[13] = num27 + (uint) num51;
  }

  public static void Mul(uint[] x, uint[] y, uint[] z)
  {
    uint num1 = x[0];
    uint num2 = x[1];
    uint num3 = x[2];
    uint num4 = x[3];
    uint num5 = x[4];
    uint num6 = x[5];
    uint num7 = x[6];
    uint num8 = x[7];
    uint num9 = x[8];
    uint num10 = x[9];
    uint num11 = x[10];
    uint num12 = x[11];
    uint num13 = x[12];
    uint num14 = x[13];
    uint num15 = x[14];
    uint num16 = x[15];
    uint num17 = y[0];
    uint num18 = y[1];
    uint num19 = y[2];
    uint num20 = y[3];
    uint num21 = y[4];
    uint num22 = y[5];
    uint num23 = y[6];
    uint num24 = y[7];
    uint num25 = y[8];
    uint num26 = y[9];
    uint num27 = y[10];
    uint num28 = y[11];
    uint num29 = y[12];
    uint num30 = y[13];
    uint num31 = y[14];
    uint num32 = y[15];
    uint num33 = num1 + num9;
    uint num34 = num2 + num10;
    uint num35 = num3 + num11;
    uint num36 = num4 + num12;
    uint num37 = num5 + num13;
    uint num38 = num6 + num14;
    uint num39 = num7 + num15;
    uint num40 = num8 + num16;
    uint num41 = num17 + num25;
    uint num42 = num18 + num26;
    uint num43 = num19 + num27;
    uint num44 = num20 + num28;
    uint num45 = num21 + num29;
    uint num46 = num22 + num30;
    uint num47 = num23 + num31;
    uint num48 = num24 + num32;
    ulong num49 = (ulong) num1 * (ulong) num17;
    ulong num50 = (ulong) ((long) num8 * (long) num18 + (long) num7 * (long) num19 + (long) num6 * (long) num20 + (long) num5 * (long) num21 + (long) num4 * (long) num22 + (long) num3 * (long) num23 + (long) num2 * (long) num24);
    ulong num51 = (ulong) num9 * (ulong) num25;
    long num52 = (long) num16 * (long) num26 + (long) num15 * (long) num27 + (long) num14 * (long) num28 + (long) num13 * (long) num29 + (long) num12 * (long) num30 + (long) num11 * (long) num31 + (long) num10 * (long) num32;
    ulong num53 = (ulong) num33 * (ulong) num41;
    ulong num54 = (ulong) ((long) num40 * (long) num42 + (long) num39 * (long) num43 + (long) num38 * (long) num44 + (long) num37 * (long) num45 + (long) num36 * (long) num46 + (long) num35 * (long) num47 + (long) num34 * (long) num48);
    ulong num55 = num49 + num51 + num54 - num50;
    uint num56 = (uint) num55 & 268435455U /*0x0FFFFFFF*/;
    ulong num57 = num55 >> 28;
    long num58 = (long) num53;
    ulong num59 = (ulong) (num52 + num58) - num49 + num54;
    uint num60 = (uint) num59 & 268435455U /*0x0FFFFFFF*/;
    ulong num61 = num59 >> 28;
    ulong num62 = (ulong) ((long) num2 * (long) num17 + (long) num1 * (long) num18);
    ulong num63 = (ulong) ((long) num8 * (long) num19 + (long) num7 * (long) num20 + (long) num6 * (long) num21 + (long) num5 * (long) num22 + (long) num4 * (long) num23 + (long) num3 * (long) num24);
    ulong num64 = (ulong) ((long) num10 * (long) num25 + (long) num9 * (long) num26);
    ulong num65 = (ulong) ((long) num16 * (long) num27 + (long) num15 * (long) num28 + (long) num14 * (long) num29 + (long) num13 * (long) num30 + (long) num12 * (long) num31 + (long) num11 * (long) num32);
    ulong num66 = (ulong) ((long) num34 * (long) num41 + (long) num33 * (long) num42);
    ulong num67 = (ulong) ((long) num40 * (long) num43 + (long) num39 * (long) num44 + (long) num38 * (long) num45 + (long) num37 * (long) num46 + (long) num36 * (long) num47 + (long) num35 * (long) num48);
    ulong num68 = num57 + (num62 + num64 + num67 - num63);
    uint num69 = (uint) num68 & 268435455U /*0x0FFFFFFF*/;
    ulong num70 = num68 >> 28;
    ulong num71 = num61 + (num65 + num66 - num62 + num67);
    uint num72 = (uint) num71 & 268435455U /*0x0FFFFFFF*/;
    ulong num73 = num71 >> 28;
    ulong num74 = (ulong) ((long) num3 * (long) num17 + (long) num2 * (long) num18 + (long) num1 * (long) num19);
    ulong num75 = (ulong) ((long) num8 * (long) num20 + (long) num7 * (long) num21 + (long) num6 * (long) num22 + (long) num5 * (long) num23 + (long) num4 * (long) num24);
    ulong num76 = (ulong) ((long) num11 * (long) num25 + (long) num10 * (long) num26 + (long) num9 * (long) num27);
    ulong num77 = (ulong) ((long) num16 * (long) num28 + (long) num15 * (long) num29 + (long) num14 * (long) num30 + (long) num13 * (long) num31 + (long) num12 * (long) num32);
    ulong num78 = (ulong) ((long) num35 * (long) num41 + (long) num34 * (long) num42 + (long) num33 * (long) num43);
    ulong num79 = (ulong) ((long) num40 * (long) num44 + (long) num39 * (long) num45 + (long) num38 * (long) num46 + (long) num37 * (long) num47 + (long) num36 * (long) num48);
    ulong num80 = num70 + (num74 + num76 + num79 - num75);
    uint num81 = (uint) num80 & 268435455U /*0x0FFFFFFF*/;
    ulong num82 = num80 >> 28;
    ulong num83 = num73 + (num77 + num78 - num74 + num79);
    uint num84 = (uint) num83 & 268435455U /*0x0FFFFFFF*/;
    ulong num85 = num83 >> 28;
    ulong num86 = (ulong) ((long) num4 * (long) num17 + (long) num3 * (long) num18 + (long) num2 * (long) num19 + (long) num1 * (long) num20);
    ulong num87 = (ulong) ((long) num8 * (long) num21 + (long) num7 * (long) num22 + (long) num6 * (long) num23 + (long) num5 * (long) num24);
    ulong num88 = (ulong) ((long) num12 * (long) num25 + (long) num11 * (long) num26 + (long) num10 * (long) num27 + (long) num9 * (long) num28);
    ulong num89 = (ulong) ((long) num16 * (long) num29 + (long) num15 * (long) num30 + (long) num14 * (long) num31 + (long) num13 * (long) num32);
    ulong num90 = (ulong) ((long) num36 * (long) num41 + (long) num35 * (long) num42 + (long) num34 * (long) num43 + (long) num33 * (long) num44);
    ulong num91 = (ulong) ((long) num40 * (long) num45 + (long) num39 * (long) num46 + (long) num38 * (long) num47 + (long) num37 * (long) num48);
    ulong num92 = num82 + (num86 + num88 + num91 - num87);
    uint num93 = (uint) num92 & 268435455U /*0x0FFFFFFF*/;
    ulong num94 = num92 >> 28;
    ulong num95 = num85 + (num89 + num90 - num86 + num91);
    uint num96 = (uint) num95 & 268435455U /*0x0FFFFFFF*/;
    ulong num97 = num95 >> 28;
    ulong num98 = (ulong) ((long) num5 * (long) num17 + (long) num4 * (long) num18 + (long) num3 * (long) num19 + (long) num2 * (long) num20 + (long) num1 * (long) num21);
    ulong num99 = (ulong) ((long) num8 * (long) num22 + (long) num7 * (long) num23 + (long) num6 * (long) num24);
    ulong num100 = (ulong) ((long) num13 * (long) num25 + (long) num12 * (long) num26 + (long) num11 * (long) num27 + (long) num10 * (long) num28 + (long) num9 * (long) num29);
    ulong num101 = (ulong) ((long) num16 * (long) num30 + (long) num15 * (long) num31 + (long) num14 * (long) num32);
    ulong num102 = (ulong) ((long) num37 * (long) num41 + (long) num36 * (long) num42 + (long) num35 * (long) num43 + (long) num34 * (long) num44 + (long) num33 * (long) num45);
    ulong num103 = (ulong) ((long) num40 * (long) num46 + (long) num39 * (long) num47 + (long) num38 * (long) num48);
    ulong num104 = num94 + (num98 + num100 + num103 - num99);
    uint num105 = (uint) num104 & 268435455U /*0x0FFFFFFF*/;
    ulong num106 = num104 >> 28;
    ulong num107 = num97 + (num101 + num102 - num98 + num103);
    uint num108 = (uint) num107 & 268435455U /*0x0FFFFFFF*/;
    ulong num109 = num107 >> 28;
    ulong num110 = (ulong) ((long) num6 * (long) num17 + (long) num5 * (long) num18 + (long) num4 * (long) num19 + (long) num3 * (long) num20 + (long) num2 * (long) num21 + (long) num1 * (long) num22);
    ulong num111 = (ulong) ((long) num8 * (long) num23 + (long) num7 * (long) num24);
    ulong num112 = (ulong) ((long) num14 * (long) num25 + (long) num13 * (long) num26 + (long) num12 * (long) num27 + (long) num11 * (long) num28 + (long) num10 * (long) num29 + (long) num9 * (long) num30);
    ulong num113 = (ulong) ((long) num16 * (long) num31 + (long) num15 * (long) num32);
    ulong num114 = (ulong) ((long) num38 * (long) num41 + (long) num37 * (long) num42 + (long) num36 * (long) num43 + (long) num35 * (long) num44 + (long) num34 * (long) num45 + (long) num33 * (long) num46);
    ulong num115 = (ulong) ((long) num40 * (long) num47 + (long) num39 * (long) num48);
    ulong num116 = num106 + (num110 + num112 + num115 - num111);
    uint num117 = (uint) num116 & 268435455U /*0x0FFFFFFF*/;
    ulong num118 = num116 >> 28;
    ulong num119 = num109 + (num113 + num114 - num110 + num115);
    uint num120 = (uint) num119 & 268435455U /*0x0FFFFFFF*/;
    ulong num121 = num119 >> 28;
    ulong num122 = (ulong) ((long) num7 * (long) num17 + (long) num6 * (long) num18 + (long) num5 * (long) num19 + (long) num4 * (long) num20 + (long) num3 * (long) num21 + (long) num2 * (long) num22 + (long) num1 * (long) num23);
    ulong num123 = (ulong) num8 * (ulong) num24;
    ulong num124 = (ulong) ((long) num15 * (long) num25 + (long) num14 * (long) num26 + (long) num13 * (long) num27 + (long) num12 * (long) num28 + (long) num11 * (long) num29 + (long) num10 * (long) num30 + (long) num9 * (long) num31);
    ulong num125 = (ulong) num16 * (ulong) num32;
    ulong num126 = (ulong) ((long) num39 * (long) num41 + (long) num38 * (long) num42 + (long) num37 * (long) num43 + (long) num36 * (long) num44 + (long) num35 * (long) num45 + (long) num34 * (long) num46 + (long) num33 * (long) num47);
    ulong num127 = (ulong) num40 * (ulong) num48;
    ulong num128 = num118 + (num122 + num124 + num127 - num123);
    uint num129 = (uint) num128 & 268435455U /*0x0FFFFFFF*/;
    ulong num130 = num128 >> 28;
    ulong num131 = num121 + (num125 + num126 - num122 + num127);
    uint num132 = (uint) num131 & 268435455U /*0x0FFFFFFF*/;
    ulong num133 = num131 >> 28;
    ulong num134 = (ulong) ((long) num8 * (long) num17 + (long) num7 * (long) num18 + (long) num6 * (long) num19 + (long) num5 * (long) num20 + (long) num4 * (long) num21 + (long) num3 * (long) num22 + (long) num2 * (long) num23 + (long) num1 * (long) num24);
    ulong num135 = (ulong) ((long) num16 * (long) num25 + (long) num15 * (long) num26 + (long) num14 * (long) num27 + (long) num13 * (long) num28 + (long) num12 * (long) num29 + (long) num11 * (long) num30 + (long) num10 * (long) num31 + (long) num9 * (long) num32);
    ulong num136 = (ulong) ((long) num40 * (long) num41 + (long) num39 * (long) num42 + (long) num38 * (long) num43 + (long) num37 * (long) num44 + (long) num36 * (long) num45 + (long) num35 * (long) num46 + (long) num34 * (long) num47 + (long) num33 * (long) num48);
    ulong num137 = num130 + (num134 + num135);
    uint num138 = (uint) num137 & 268435455U /*0x0FFFFFFF*/;
    ulong num139 = num137 >> 28;
    ulong num140 = num133 + (num136 - num134);
    uint num141 = (uint) num140 & 268435455U /*0x0FFFFFFF*/;
    ulong num142 = num140 >> 28;
    ulong num143 = num139 + num142 + (ulong) num60;
    uint num144 = (uint) num143 & 268435455U /*0x0FFFFFFF*/;
    ulong num145 = num143 >> 28;
    ulong num146 = num142 + (ulong) num56;
    uint num147 = (uint) num146 & 268435455U /*0x0FFFFFFF*/;
    ulong num148 = num146 >> 28;
    uint num149 = num72 + (uint) num145;
    uint num150 = num69 + (uint) num148;
    z[0] = num147;
    z[1] = num150;
    z[2] = num81;
    z[3] = num93;
    z[4] = num105;
    z[5] = num117;
    z[6] = num129;
    z[7] = num138;
    z[8] = num144;
    z[9] = num149;
    z[10] = num84;
    z[11] = num96;
    z[12] = num108;
    z[13] = num120;
    z[14] = num132;
    z[15] = num141;
  }

  public static void Negate(uint[] x, uint[] z) => X448Field.Sub(X448Field.Create(), x, z);

  public static void Normalize(uint[] z)
  {
    X448Field.Reduce(z, 1);
    X448Field.Reduce(z, -1);
  }

  public static void One(uint[] z)
  {
    z[0] = 1U;
    for (int index = 1; index < 16 /*0x10*/; ++index)
      z[index] = 0U;
  }

  private static void PowPm3d4(uint[] x, uint[] z)
  {
    uint[] numArray1 = X448Field.Create();
    X448Field.Sqr(x, numArray1);
    X448Field.Mul(x, numArray1, numArray1);
    uint[] numArray2 = X448Field.Create();
    X448Field.Sqr(numArray1, numArray2);
    X448Field.Mul(x, numArray2, numArray2);
    uint[] numArray3 = X448Field.Create();
    X448Field.Sqr(numArray2, 3, numArray3);
    X448Field.Mul(numArray2, numArray3, numArray3);
    uint[] numArray4 = X448Field.Create();
    X448Field.Sqr(numArray3, 3, numArray4);
    X448Field.Mul(numArray2, numArray4, numArray4);
    uint[] numArray5 = X448Field.Create();
    X448Field.Sqr(numArray4, 9, numArray5);
    X448Field.Mul(numArray4, numArray5, numArray5);
    uint[] numArray6 = X448Field.Create();
    X448Field.Sqr(numArray5, numArray6);
    X448Field.Mul(x, numArray6, numArray6);
    uint[] numArray7 = X448Field.Create();
    X448Field.Sqr(numArray6, 18, numArray7);
    X448Field.Mul(numArray5, numArray7, numArray7);
    uint[] numArray8 = X448Field.Create();
    X448Field.Sqr(numArray7, 37, numArray8);
    X448Field.Mul(numArray7, numArray8, numArray8);
    uint[] numArray9 = X448Field.Create();
    X448Field.Sqr(numArray8, 37, numArray9);
    X448Field.Mul(numArray7, numArray9, numArray9);
    uint[] numArray10 = X448Field.Create();
    X448Field.Sqr(numArray9, 111, numArray10);
    X448Field.Mul(numArray9, numArray10, numArray10);
    uint[] numArray11 = X448Field.Create();
    X448Field.Sqr(numArray10, numArray11);
    X448Field.Mul(x, numArray11, numArray11);
    uint[] numArray12 = X448Field.Create();
    X448Field.Sqr(numArray11, 223, numArray12);
    X448Field.Mul(numArray12, numArray10, z);
  }

  private static void Reduce(uint[] z, int x)
  {
    int num1 = (int) z[15];
    uint num2 = (uint) (num1 & 268435455 /*0x0FFFFFFF*/);
    int num3 = (num1 >>> 28) + x;
    long num4 = (long) num3;
    for (int index = 0; index < 8; ++index)
    {
      long num5 = num4 + (long) z[index];
      z[index] = (uint) num5 & 268435455U /*0x0FFFFFFF*/;
      num4 = num5 >> 28;
    }
    long num6 = num4 + (long) num3;
    for (int index = 8; index < 15; ++index)
    {
      long num7 = num6 + (long) z[index];
      z[index] = (uint) num7 & 268435455U /*0x0FFFFFFF*/;
      num6 = num7 >> 28;
    }
    z[15] = num2 + (uint) num6;
  }

  public static void Sqr(uint[] x, uint[] z)
  {
    uint num1 = x[0];
    uint num2 = x[1];
    uint num3 = x[2];
    uint num4 = x[3];
    uint num5 = x[4];
    uint num6 = x[5];
    uint num7 = x[6];
    uint num8 = x[7];
    uint num9 = x[8];
    uint num10 = x[9];
    uint num11 = x[10];
    uint num12 = x[11];
    uint num13 = x[12];
    uint num14 = x[13];
    uint num15 = x[14];
    uint num16 = x[15];
    uint num17 = num1 * 2U;
    uint num18 = num2 * 2U;
    uint num19 = num3 * 2U;
    uint num20 = num4 * 2U;
    uint num21 = num5 * 2U;
    uint num22 = num6 * 2U;
    uint num23 = num7 * 2U;
    uint num24 = num9 * 2U;
    uint num25 = num10 * 2U;
    uint num26 = num11 * 2U;
    uint num27 = num12 * 2U;
    uint num28 = num13 * 2U;
    uint num29 = num14 * 2U;
    uint num30 = num15 * 2U;
    uint num31 = num1 + num9;
    uint num32 = num2 + num10;
    uint num33 = num3 + num11;
    uint num34 = num4 + num12;
    uint num35 = num5 + num13;
    uint num36 = num6 + num14;
    uint num37 = num7 + num15;
    uint num38 = num8 + num16;
    uint num39 = num31 * 2U;
    uint num40 = num32 * 2U;
    uint num41 = num33 * 2U;
    uint num42 = num34 * 2U;
    uint num43 = num35 * 2U;
    uint num44 = num36 * 2U;
    uint num45 = num37 * 2U;
    ulong num46 = (ulong) num1 * (ulong) num1;
    ulong num47 = (ulong) ((long) num8 * (long) num18 + (long) num7 * (long) num19 + (long) num6 * (long) num20 + (long) num5 * (long) num5);
    ulong num48 = (ulong) num9 * (ulong) num9;
    long num49 = (long) num16 * (long) num25 + (long) num15 * (long) num26 + (long) num14 * (long) num27 + (long) num13 * (long) num13;
    ulong num50 = (ulong) num31 * (ulong) num31;
    ulong num51 = (ulong) ((long) num38 * (long) num40 + (long) num37 * (long) num41 + (long) num36 * (long) num42 + (long) num35 * (long) num35);
    ulong num52 = num46 + num48 + num51 - num47;
    uint num53 = (uint) num52 & 268435455U /*0x0FFFFFFF*/;
    ulong num54 = num52 >> 28;
    long num55 = (long) num50;
    ulong num56 = (ulong) (num49 + num55) - num46 + num51;
    uint num57 = (uint) num56 & 268435455U /*0x0FFFFFFF*/;
    ulong num58 = num56 >> 28;
    ulong num59 = (ulong) num2 * (ulong) num17;
    ulong num60 = (ulong) ((long) num8 * (long) num19 + (long) num7 * (long) num20 + (long) num6 * (long) num21);
    ulong num61 = (ulong) num10 * (ulong) num24;
    ulong num62 = (ulong) ((long) num16 * (long) num26 + (long) num15 * (long) num27 + (long) num14 * (long) num28);
    ulong num63 = (ulong) num32 * (ulong) num39;
    ulong num64 = (ulong) ((long) num38 * (long) num41 + (long) num37 * (long) num42 + (long) num36 * (long) num43);
    ulong num65 = num54 + (num59 + num61 + num64 - num60);
    uint num66 = (uint) num65 & 268435455U /*0x0FFFFFFF*/;
    ulong num67 = num65 >> 28;
    ulong num68 = num58 + (num62 + num63 - num59 + num64);
    uint num69 = (uint) num68 & 268435455U /*0x0FFFFFFF*/;
    ulong num70 = num68 >> 28;
    ulong num71 = (ulong) ((long) num3 * (long) num17 + (long) num2 * (long) num2);
    ulong num72 = (ulong) ((long) num8 * (long) num20 + (long) num7 * (long) num21 + (long) num6 * (long) num6);
    ulong num73 = (ulong) ((long) num11 * (long) num24 + (long) num10 * (long) num10);
    ulong num74 = (ulong) ((long) num16 * (long) num27 + (long) num15 * (long) num28 + (long) num14 * (long) num14);
    ulong num75 = (ulong) ((long) num33 * (long) num39 + (long) num32 * (long) num32);
    ulong num76 = (ulong) ((long) num38 * (long) num42 + (long) num37 * (long) num43 + (long) num36 * (long) num36);
    ulong num77 = num67 + (num71 + num73 + num76 - num72);
    uint num78 = (uint) num77 & 268435455U /*0x0FFFFFFF*/;
    ulong num79 = num77 >> 28;
    ulong num80 = num70 + (num74 + num75 - num71 + num76);
    uint num81 = (uint) num80 & 268435455U /*0x0FFFFFFF*/;
    ulong num82 = num80 >> 28;
    ulong num83 = (ulong) ((long) num4 * (long) num17 + (long) num3 * (long) num18);
    ulong num84 = (ulong) ((long) num8 * (long) num21 + (long) num7 * (long) num22);
    ulong num85 = (ulong) ((long) num12 * (long) num24 + (long) num11 * (long) num25);
    ulong num86 = (ulong) ((long) num16 * (long) num28 + (long) num15 * (long) num29);
    ulong num87 = (ulong) ((long) num34 * (long) num39 + (long) num33 * (long) num40);
    ulong num88 = (ulong) ((long) num38 * (long) num43 + (long) num37 * (long) num44);
    ulong num89 = num79 + (num83 + num85 + num88 - num84);
    uint num90 = (uint) num89 & 268435455U /*0x0FFFFFFF*/;
    ulong num91 = num89 >> 28;
    ulong num92 = num82 + (num86 + num87 - num83 + num88);
    uint num93 = (uint) num92 & 268435455U /*0x0FFFFFFF*/;
    ulong num94 = num92 >> 28;
    ulong num95 = (ulong) ((long) num5 * (long) num17 + (long) num4 * (long) num18 + (long) num3 * (long) num3);
    ulong num96 = (ulong) ((long) num8 * (long) num22 + (long) num7 * (long) num7);
    ulong num97 = (ulong) ((long) num13 * (long) num24 + (long) num12 * (long) num25 + (long) num11 * (long) num11);
    ulong num98 = (ulong) ((long) num16 * (long) num29 + (long) num15 * (long) num15);
    ulong num99 = (ulong) ((long) num35 * (long) num39 + (long) num34 * (long) num40 + (long) num33 * (long) num33);
    ulong num100 = (ulong) ((long) num38 * (long) num44 + (long) num37 * (long) num37);
    ulong num101 = num91 + (num95 + num97 + num100 - num96);
    uint num102 = (uint) num101 & 268435455U /*0x0FFFFFFF*/;
    ulong num103 = num101 >> 28;
    ulong num104 = num94 + (num98 + num99 - num95 + num100);
    uint num105 = (uint) num104 & 268435455U /*0x0FFFFFFF*/;
    ulong num106 = num104 >> 28;
    ulong num107 = (ulong) ((long) num6 * (long) num17 + (long) num5 * (long) num18 + (long) num4 * (long) num19);
    ulong num108 = (ulong) num8 * (ulong) num23;
    ulong num109 = (ulong) ((long) num14 * (long) num24 + (long) num13 * (long) num25 + (long) num12 * (long) num26);
    ulong num110 = (ulong) num16 * (ulong) num30;
    ulong num111 = (ulong) ((long) num36 * (long) num39 + (long) num35 * (long) num40 + (long) num34 * (long) num41);
    ulong num112 = (ulong) num38 * (ulong) num45;
    ulong num113 = num103 + (num107 + num109 + num112 - num108);
    uint num114 = (uint) num113 & 268435455U /*0x0FFFFFFF*/;
    ulong num115 = num113 >> 28;
    ulong num116 = num106 + (num110 + num111 - num107 + num112);
    uint num117 = (uint) num116 & 268435455U /*0x0FFFFFFF*/;
    ulong num118 = num116 >> 28;
    ulong num119 = (ulong) ((long) num7 * (long) num17 + (long) num6 * (long) num18 + (long) num5 * (long) num19 + (long) num4 * (long) num4);
    ulong num120 = (ulong) num8 * (ulong) num8;
    ulong num121 = (ulong) ((long) num15 * (long) num24 + (long) num14 * (long) num25 + (long) num13 * (long) num26 + (long) num12 * (long) num12);
    ulong num122 = (ulong) num16 * (ulong) num16;
    ulong num123 = (ulong) ((long) num37 * (long) num39 + (long) num36 * (long) num40 + (long) num35 * (long) num41 + (long) num34 * (long) num34);
    ulong num124 = (ulong) num38 * (ulong) num38;
    ulong num125 = num115 + (num119 + num121 + num124 - num120);
    uint num126 = (uint) num125 & 268435455U /*0x0FFFFFFF*/;
    ulong num127 = num125 >> 28;
    ulong num128 = num118 + (num122 + num123 - num119 + num124);
    uint num129 = (uint) num128 & 268435455U /*0x0FFFFFFF*/;
    ulong num130 = num128 >> 28;
    ulong num131 = (ulong) ((long) num8 * (long) num17 + (long) num7 * (long) num18 + (long) num6 * (long) num19 + (long) num5 * (long) num20);
    ulong num132 = (ulong) ((long) num16 * (long) num24 + (long) num15 * (long) num25 + (long) num14 * (long) num26 + (long) num13 * (long) num27);
    ulong num133 = (ulong) ((long) num38 * (long) num39 + (long) num37 * (long) num40 + (long) num36 * (long) num41 + (long) num35 * (long) num42);
    ulong num134 = num127 + (num131 + num132);
    uint num135 = (uint) num134 & 268435455U /*0x0FFFFFFF*/;
    ulong num136 = num134 >> 28;
    ulong num137 = num130 + (num133 - num131);
    uint num138 = (uint) num137 & 268435455U /*0x0FFFFFFF*/;
    ulong num139 = num137 >> 28;
    ulong num140 = num136 + num139 + (ulong) num57;
    uint num141 = (uint) num140 & 268435455U /*0x0FFFFFFF*/;
    ulong num142 = num140 >> 28;
    ulong num143 = num139 + (ulong) num53;
    uint num144 = (uint) num143 & 268435455U /*0x0FFFFFFF*/;
    ulong num145 = num143 >> 28;
    uint num146 = num69 + (uint) num142;
    uint num147 = num66 + (uint) num145;
    z[0] = num144;
    z[1] = num147;
    z[2] = num78;
    z[3] = num90;
    z[4] = num102;
    z[5] = num114;
    z[6] = num126;
    z[7] = num135;
    z[8] = num141;
    z[9] = num146;
    z[10] = num81;
    z[11] = num93;
    z[12] = num105;
    z[13] = num117;
    z[14] = num129;
    z[15] = num138;
  }

  public static void Sqr(uint[] x, int n, uint[] z)
  {
    X448Field.Sqr(x, z);
    while (--n > 0)
      X448Field.Sqr(z, z);
  }

  public static bool SqrtRatioVar(uint[] u, uint[] v, uint[] z)
  {
    uint[] numArray1 = X448Field.Create();
    uint[] numArray2 = X448Field.Create();
    X448Field.Sqr(u, numArray1);
    X448Field.Mul(numArray1, v, numArray1);
    X448Field.Sqr(numArray1, numArray2);
    X448Field.Mul(numArray1, u, numArray1);
    X448Field.Mul(numArray2, u, numArray2);
    X448Field.Mul(numArray2, v, numArray2);
    uint[] numArray3 = X448Field.Create();
    X448Field.PowPm3d4(numArray2, numArray3);
    X448Field.Mul(numArray3, numArray1, numArray3);
    uint[] numArray4 = X448Field.Create();
    X448Field.Sqr(numArray3, numArray4);
    X448Field.Mul(numArray4, v, numArray4);
    X448Field.Sub(u, numArray4, numArray4);
    X448Field.Normalize(numArray4);
    if (!X448Field.IsZeroVar(numArray4))
      return false;
    X448Field.Copy(numArray3, 0, z, 0);
    return true;
  }

  public static void Sub(uint[] x, uint[] y, uint[] z)
  {
    int num1 = (int) x[0];
    uint num2 = x[1];
    uint num3 = x[2];
    uint num4 = x[3];
    uint num5 = x[4];
    uint num6 = x[5];
    uint num7 = x[6];
    uint num8 = x[7];
    uint num9 = x[8];
    uint num10 = x[9];
    uint num11 = x[10];
    uint num12 = x[11];
    uint num13 = x[12];
    uint num14 = x[13];
    uint num15 = x[14];
    uint num16 = x[15];
    uint num17 = y[0];
    uint num18 = y[1];
    uint num19 = y[2];
    uint num20 = y[3];
    uint num21 = y[4];
    uint num22 = y[5];
    uint num23 = y[6];
    uint num24 = y[7];
    uint num25 = y[8];
    uint num26 = y[9];
    uint num27 = y[10];
    uint num28 = y[11];
    uint num29 = y[12];
    uint num30 = y[13];
    uint num31 = y[14];
    uint num32 = y[15];
    uint num33 = (uint) (num1 + 536870910) - num17;
    uint num34 = num2 + 536870910U - num18;
    uint num35 = num3 + 536870910U - num19;
    uint num36 = num4 + 536870910U - num20;
    uint num37 = num5 + 536870910U - num21;
    uint num38 = num6 + 536870910U - num22;
    uint num39 = num7 + 536870910U - num23;
    uint num40 = num8 + 536870910U - num24;
    uint num41 = num9 + 536870908U - num25;
    uint num42 = num10 + 536870910U - num26;
    uint num43 = num11 + 536870910U - num27;
    uint num44 = num12 + 536870910U - num28;
    uint num45 = num13 + 536870910U - num29;
    uint num46 = num14 + 536870910U - num30;
    uint num47 = num15 + 536870910U - num31;
    uint num48 = num16 + 536870910U - num32;
    uint num49 = num35 + (num34 >> 28);
    uint num50 = num34 & 268435455U /*0x0FFFFFFF*/;
    uint num51 = num39 + (num38 >> 28);
    uint num52 = num38 & 268435455U /*0x0FFFFFFF*/;
    uint num53 = num43 + (num42 >> 28);
    uint num54 = num42 & 268435455U /*0x0FFFFFFF*/;
    uint num55 = num47 + (num46 >> 28);
    uint num56 = num46 & 268435455U /*0x0FFFFFFF*/;
    uint num57 = num36 + (num49 >> 28);
    uint num58 = num49 & 268435455U /*0x0FFFFFFF*/;
    uint num59 = num40 + (num51 >> 28);
    uint num60 = num51 & 268435455U /*0x0FFFFFFF*/;
    uint num61 = num44 + (num53 >> 28);
    uint num62 = num53 & 268435455U /*0x0FFFFFFF*/;
    uint num63 = num48 + (num55 >> 28);
    uint num64 = num55 & 268435455U /*0x0FFFFFFF*/;
    uint num65 = num63 >> 28;
    uint num66 = num63 & 268435455U /*0x0FFFFFFF*/;
    uint num67 = num33 + num65;
    uint num68 = num41 + num65;
    uint num69 = num37 + (num57 >> 28);
    uint num70 = num57 & 268435455U /*0x0FFFFFFF*/;
    uint num71 = num68 + (num59 >> 28);
    uint num72 = num59 & 268435455U /*0x0FFFFFFF*/;
    uint num73 = num45 + (num61 >> 28);
    uint num74 = num61 & 268435455U /*0x0FFFFFFF*/;
    uint num75 = num50 + (num67 >> 28);
    uint num76 = num67 & 268435455U /*0x0FFFFFFF*/;
    uint num77 = num52 + (num69 >> 28);
    uint num78 = num69 & 268435455U /*0x0FFFFFFF*/;
    uint num79 = num54 + (num71 >> 28);
    uint num80 = num71 & 268435455U /*0x0FFFFFFF*/;
    uint num81 = num56 + (num73 >> 28);
    uint num82 = num73 & 268435455U /*0x0FFFFFFF*/;
    z[0] = num76;
    z[1] = num75;
    z[2] = num58;
    z[3] = num70;
    z[4] = num78;
    z[5] = num77;
    z[6] = num60;
    z[7] = num72;
    z[8] = num80;
    z[9] = num79;
    z[10] = num62;
    z[11] = num74;
    z[12] = num82;
    z[13] = num81;
    z[14] = num64;
    z[15] = num66;
  }

  public static void SubOne(uint[] z)
  {
    uint[] y = X448Field.Create();
    y[0] = 1U;
    X448Field.Sub(z, y, z);
  }

  public static void Zero(uint[] z)
  {
    for (int index = 0; index < 16 /*0x10*/; ++index)
      z[index] = 0U;
  }
}
