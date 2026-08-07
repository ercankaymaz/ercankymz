// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Math.EC.Custom.Sec.SecT283Field
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Math.Raw;
using System;

#nullable disable
namespace Org.BouncyCastle.Math.EC.Custom.Sec;

internal static class SecT283Field
{
  private const ulong M27 = 134217727 /*0x07FFFFFF*/;
  private const ulong M57 = 144115188075855871 /*0x01FFFFFFFFFFFFFF*/;
  private static readonly ulong[] ROOT_Z = new ulong[5]
  {
    878416384462358536UL,
    3513665537849438403UL,
    9369774767598502668UL,
    585610922974906400UL /*0x0820820820820820*/,
    34087042UL
  };

  public static void Add(ulong[] x, ulong[] y, ulong[] z)
  {
    z[0] = x[0] ^ y[0];
    z[1] = x[1] ^ y[1];
    z[2] = x[2] ^ y[2];
    z[3] = x[3] ^ y[3];
    z[4] = x[4] ^ y[4];
  }

  public static void AddBothTo(ulong[] x, ulong[] y, ulong[] z)
  {
    z[0] ^= x[0] ^ y[0];
    z[1] ^= x[1] ^ y[1];
    z[2] ^= x[2] ^ y[2];
    z[3] ^= x[3] ^ y[3];
    z[4] ^= x[4] ^ y[4];
  }

  public static void AddExt(ulong[] xx, ulong[] yy, ulong[] zz)
  {
    zz[0] = xx[0] ^ yy[0];
    zz[1] = xx[1] ^ yy[1];
    zz[2] = xx[2] ^ yy[2];
    zz[3] = xx[3] ^ yy[3];
    zz[4] = xx[4] ^ yy[4];
    zz[5] = xx[5] ^ yy[5];
    zz[6] = xx[6] ^ yy[6];
    zz[7] = xx[7] ^ yy[7];
    zz[8] = xx[8] ^ yy[8];
  }

  public static void AddOne(ulong[] x, ulong[] z)
  {
    z[0] = x[0] ^ 1UL;
    z[1] = x[1];
    z[2] = x[2];
    z[3] = x[3];
    z[4] = x[4];
  }

  public static void AddTo(ulong[] x, ulong[] z)
  {
    z[0] ^= x[0];
    z[1] ^= x[1];
    z[2] ^= x[2];
    z[3] ^= x[3];
    z[4] ^= x[4];
  }

  public static ulong[] FromBigInteger(BigInteger x) => Nat.FromBigInteger64(283, x);

  public static void HalfTrace(ulong[] x, ulong[] z)
  {
    ulong[] numArray = Nat.Create64(9);
    Nat320.Copy64(x, z);
    for (int index = 1; index < 283; index += 2)
    {
      SecT283Field.ImplSquare(z, numArray);
      SecT283Field.Reduce(numArray, z);
      SecT283Field.ImplSquare(z, numArray);
      SecT283Field.Reduce(numArray, z);
      SecT283Field.AddTo(x, z);
    }
  }

  public static void Invert(ulong[] x, ulong[] z)
  {
    if (Nat320.IsZero64(x))
      throw new InvalidOperationException();
    ulong[] numArray1 = Nat320.Create64();
    ulong[] numArray2 = Nat320.Create64();
    SecT283Field.Square(x, numArray1);
    SecT283Field.Multiply(numArray1, x, numArray1);
    SecT283Field.SquareN(numArray1, 2, numArray2);
    SecT283Field.Multiply(numArray2, numArray1, numArray2);
    SecT283Field.SquareN(numArray2, 4, numArray1);
    SecT283Field.Multiply(numArray1, numArray2, numArray1);
    SecT283Field.SquareN(numArray1, 8, numArray2);
    SecT283Field.Multiply(numArray2, numArray1, numArray2);
    SecT283Field.Square(numArray2, numArray2);
    SecT283Field.Multiply(numArray2, x, numArray2);
    SecT283Field.SquareN(numArray2, 17, numArray1);
    SecT283Field.Multiply(numArray1, numArray2, numArray1);
    SecT283Field.Square(numArray1, numArray1);
    SecT283Field.Multiply(numArray1, x, numArray1);
    SecT283Field.SquareN(numArray1, 35, numArray2);
    SecT283Field.Multiply(numArray2, numArray1, numArray2);
    SecT283Field.SquareN(numArray2, 70, numArray1);
    SecT283Field.Multiply(numArray1, numArray2, numArray1);
    SecT283Field.Square(numArray1, numArray1);
    SecT283Field.Multiply(numArray1, x, numArray1);
    SecT283Field.SquareN(numArray1, 141, numArray2);
    SecT283Field.Multiply(numArray2, numArray1, numArray2);
    SecT283Field.Square(numArray2, z);
  }

  public static void Multiply(ulong[] x, ulong[] y, ulong[] z)
  {
    ulong[] ext64 = Nat320.CreateExt64();
    SecT283Field.ImplMultiply(x, y, ext64);
    SecT283Field.Reduce(ext64, z);
  }

  public static void MultiplyAddToExt(ulong[] x, ulong[] y, ulong[] zz)
  {
    ulong[] ext64 = Nat320.CreateExt64();
    SecT283Field.ImplMultiply(x, y, ext64);
    SecT283Field.AddExt(zz, ext64, zz);
  }

  public static void MultiplyExt(ulong[] x, ulong[] y, ulong[] zz)
  {
    Array.Clear((Array) zz, 0, 10);
    SecT283Field.ImplMultiply(x, y, zz);
  }

  public static void Reduce(ulong[] xx, ulong[] z)
  {
    ulong num1 = xx[0];
    ulong num2 = xx[1];
    ulong num3 = xx[2];
    ulong num4 = xx[3];
    ulong num5 = xx[4];
    ulong num6 = xx[5];
    ulong num7 = xx[6];
    ulong num8 = xx[7];
    ulong num9 = xx[8];
    ulong num10 = num4 ^ (ulong) ((long) num9 << 37 ^ (long) num9 << 42 ^ (long) num9 << 44 ^ (long) num9 << 49);
    ulong num11 = num5 ^ num9 >> 27 ^ num9 >> 22 ^ num9 >> 20 ^ num9 >> 15;
    ulong num12 = num3 ^ (ulong) ((long) num8 << 37 ^ (long) num8 << 42 ^ (long) num8 << 44 ^ (long) num8 << 49);
    ulong num13 = num10 ^ num8 >> 27 ^ num8 >> 22 ^ num8 >> 20 ^ num8 >> 15;
    ulong num14 = num2 ^ (ulong) ((long) num7 << 37 ^ (long) num7 << 42 ^ (long) num7 << 44 ^ (long) num7 << 49);
    ulong num15 = num12 ^ num7 >> 27 ^ num7 >> 22 ^ num7 >> 20 ^ num7 >> 15;
    ulong num16 = num1 ^ (ulong) ((long) num6 << 37 ^ (long) num6 << 42 ^ (long) num6 << 44 ^ (long) num6 << 49);
    ulong num17 = num14 ^ num6 >> 27 ^ num6 >> 22 ^ num6 >> 20 ^ num6 >> 15;
    ulong num18 = num11 >> 27;
    z[0] = (ulong) ((long) num16 ^ (long) num18 ^ (long) num18 << 5 ^ (long) num18 << 7 ^ (long) num18 << 12);
    z[1] = num17;
    z[2] = num15;
    z[3] = num13;
    z[4] = num11 & 134217727UL /*0x07FFFFFF*/;
  }

  public static void Reduce37(ulong[] z, int zOff)
  {
    ulong num1 = z[zOff + 4];
    ulong num2 = num1 >> 27;
    z[zOff] ^= (ulong) ((long) num2 ^ (long) num2 << 5 ^ (long) num2 << 7 ^ (long) num2 << 12);
    z[zOff + 4] = num1 & 134217727UL /*0x07FFFFFF*/;
  }

  public static void Sqrt(ulong[] x, ulong[] z)
  {
    ulong[] x1 = Nat320.Create64();
    ulong even1;
    x1[0] = Interleave.Unshuffle(x[0], x[1], out even1);
    ulong even2;
    x1[1] = Interleave.Unshuffle(x[2], x[3], out even2);
    ulong even3;
    x1[2] = Interleave.Unshuffle(x[4], out even3);
    SecT283Field.Multiply(x1, SecT283Field.ROOT_Z, z);
    z[0] ^= even1;
    z[1] ^= even2;
    z[2] ^= even3;
  }

  public static void Square(ulong[] x, ulong[] z)
  {
    ulong[] numArray = Nat.Create64(9);
    SecT283Field.ImplSquare(x, numArray);
    SecT283Field.Reduce(numArray, z);
  }

  public static void SquareAddToExt(ulong[] x, ulong[] zz)
  {
    ulong[] numArray = Nat.Create64(9);
    SecT283Field.ImplSquare(x, numArray);
    SecT283Field.AddExt(zz, numArray, zz);
  }

  public static void SquareExt(ulong[] x, ulong[] zz) => SecT283Field.ImplSquare(x, zz);

  public static void SquareN(ulong[] x, int n, ulong[] z)
  {
    ulong[] numArray = Nat.Create64(9);
    SecT283Field.ImplSquare(x, numArray);
    SecT283Field.Reduce(numArray, z);
    while (--n > 0)
    {
      SecT283Field.ImplSquare(z, numArray);
      SecT283Field.Reduce(numArray, z);
    }
  }

  public static uint Trace(ulong[] x) => (uint) (x[0] ^ x[4] >> 15) & 1U;

  private static void ImplCompactExt(ulong[] zz)
  {
    ulong num1 = zz[0];
    ulong num2 = zz[1];
    ulong num3 = zz[2];
    ulong num4 = zz[3];
    ulong num5 = zz[4];
    ulong num6 = zz[5];
    ulong num7 = zz[6];
    ulong num8 = zz[7];
    ulong num9 = zz[8];
    ulong num10 = zz[9];
    zz[0] = num1 ^ num2 << 57;
    zz[1] = num2 >> 7 ^ num3 << 50;
    zz[2] = num3 >> 14 ^ num4 << 43;
    zz[3] = num4 >> 21 ^ num5 << 36;
    zz[4] = num5 >> 28 ^ num6 << 29;
    zz[5] = num6 >> 35 ^ num7 << 22;
    zz[6] = num7 >> 42 ^ num8 << 15;
    zz[7] = num8 >> 49 ^ num9 << 8;
    zz[8] = num9 >> 56 ^ num10 << 1;
    zz[9] = num10 >> 63 /*0x3F*/;
  }

  private static void ImplExpand(ulong[] x, ulong[] z)
  {
    ulong num1 = x[0];
    ulong num2 = x[1];
    ulong num3 = x[2];
    ulong num4 = x[3];
    ulong num5 = x[4];
    z[0] = num1 & 144115188075855871UL /*0x01FFFFFFFFFFFFFF*/;
    z[1] = (ulong) (((long) (num1 >> 57) ^ (long) num2 << 7) & 144115188075855871L /*0x01FFFFFFFFFFFFFF*/);
    z[2] = (ulong) (((long) (num2 >> 50) ^ (long) num3 << 14) & 144115188075855871L /*0x01FFFFFFFFFFFFFF*/);
    z[3] = (ulong) (((long) (num3 >> 43) ^ (long) num4 << 21) & 144115188075855871L /*0x01FFFFFFFFFFFFFF*/);
    z[4] = num4 >> 36 ^ num5 << 28;
  }

  private static void ImplMultiply(ulong[] x, ulong[] y, ulong[] zz)
  {
    ulong[] z1 = new ulong[5];
    ulong[] z2 = new ulong[5];
    SecT283Field.ImplExpand(x, z1);
    SecT283Field.ImplExpand(y, z2);
    ulong[] u = zz;
    ulong[] z3 = new ulong[26];
    SecT283Field.ImplMulw(u, z1[0], z2[0], z3, 0);
    SecT283Field.ImplMulw(u, z1[1], z2[1], z3, 2);
    SecT283Field.ImplMulw(u, z1[2], z2[2], z3, 4);
    SecT283Field.ImplMulw(u, z1[3], z2[3], z3, 6);
    SecT283Field.ImplMulw(u, z1[4], z2[4], z3, 8);
    ulong x1 = z1[0] ^ z1[1];
    ulong y1 = z2[0] ^ z2[1];
    ulong x2 = z1[0] ^ z1[2];
    ulong y2 = z2[0] ^ z2[2];
    ulong x3 = z1[2] ^ z1[4];
    ulong y3 = z2[2] ^ z2[4];
    ulong x4 = z1[3] ^ z1[4];
    ulong y4 = z2[3] ^ z2[4];
    SecT283Field.ImplMulw(u, x2 ^ z1[3], y2 ^ z2[3], z3, 18);
    SecT283Field.ImplMulw(u, x3 ^ z1[1], y3 ^ z2[1], z3, 20);
    ulong x5 = x1 ^ x4;
    ulong y5 = y1 ^ y4;
    ulong x6 = x5 ^ z1[2];
    ulong y6 = y5 ^ z2[2];
    SecT283Field.ImplMulw(u, x5, y5, z3, 22);
    SecT283Field.ImplMulw(u, x6, y6, z3, 24);
    SecT283Field.ImplMulw(u, x1, y1, z3, 10);
    SecT283Field.ImplMulw(u, x2, y2, z3, 12);
    SecT283Field.ImplMulw(u, x3, y3, z3, 14);
    SecT283Field.ImplMulw(u, x4, y4, z3, 16 /*0x10*/);
    zz[0] = z3[0];
    zz[9] = z3[9];
    long num1 = (long) z3[0] ^ (long) z3[1];
    long num2 = num1 ^ (long) z3[2];
    ulong num3 = (ulong) num2 ^ z3[10];
    zz[1] = num3;
    ulong num4 = z3[3] ^ z3[4];
    ulong num5 = z3[11] ^ z3[12];
    ulong num6 = (ulong) num2 ^ num4 ^ num5;
    zz[2] = num6;
    long num7 = num1 ^ (long) num4;
    ulong num8 = z3[5] ^ z3[6];
    long num9 = (long) num8;
    long num10 = num7 ^ num9 ^ (long) z3[8];
    ulong num11 = z3[13] ^ z3[14];
    ulong num12 = (ulong) num10 ^ num11 ^ z3[18] ^ z3[22] ^ z3[24];
    zz[3] = num12;
    long num13 = (long) z3[7] ^ (long) z3[8] ^ (long) z3[9];
    ulong num14 = (ulong) num13 ^ z3[17];
    zz[8] = num14;
    ulong num15 = (ulong) num13 ^ num8 ^ z3[15] ^ z3[16 /*0x10*/];
    zz[7] = num15;
    ulong num16 = num15 ^ num3;
    long num17 = (long) z3[19] ^ (long) z3[20];
    ulong num18 = z3[25] ^ z3[24];
    ulong num19 = z3[18] ^ z3[23];
    long num20 = (long) num18;
    long num21 = num17 ^ num20;
    ulong num22 = (ulong) num21 ^ num19 ^ num16;
    zz[4] = num22;
    ulong num23 = (ulong) num21 ^ num6 ^ num14 ^ z3[21] ^ z3[22];
    zz[5] = num23;
    ulong num24 = (ulong) num10 ^ z3[0] ^ z3[9] ^ num11 ^ z3[21] ^ z3[23] ^ z3[25];
    zz[6] = num24;
    SecT283Field.ImplCompactExt(zz);
  }

  private static void ImplMulw(ulong[] u, ulong x, ulong y, ulong[] z, int zOff)
  {
    u[1] = y;
    u[2] = u[1] << 1;
    u[3] = u[2] ^ y;
    u[4] = u[2] << 1;
    u[5] = u[4] ^ y;
    u[6] = u[3] << 1;
    u[7] = u[6] ^ y;
    uint num1 = (uint) x;
    ulong num2 = 0;
    ulong num3 = u[(int) num1 & 7];
    int num4 = 48 /*0x30*/;
    do
    {
      uint num5 = (uint) (x >> num4);
      ulong num6 = (ulong) ((long) u[(int) num5 & 7] ^ (long) u[(int) (num5 >> 3) & 7] << 3 ^ (long) u[(int) (num5 >> 6) & 7] << 6);
      num3 ^= num6 << num4;
      num2 ^= num6 >> -num4;
    }
    while ((num4 -= 9) > 0);
    ulong num7 = num2 ^ (ulong) (((long) x & 72198606942111744L /*0x0100804020100800*/ & (long) y << 7 >> 63 /*0x3F*/) >>> 8);
    z[zOff] = num3 & 144115188075855871UL /*0x01FFFFFFFFFFFFFF*/;
    z[zOff + 1] = num3 >> 57 ^ num7 << 7;
  }

  private static void ImplSquare(ulong[] x, ulong[] zz)
  {
    zz[8] = Interleave.Expand32to64((uint) x[4]);
    Interleave.Expand64To128(x, 0, 4, zz, 0);
  }
}
