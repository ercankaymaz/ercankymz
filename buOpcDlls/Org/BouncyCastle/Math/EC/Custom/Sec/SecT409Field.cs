// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Math.EC.Custom.Sec.SecT409Field
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Math.Raw;
using System;

#nullable disable
namespace Org.BouncyCastle.Math.EC.Custom.Sec;

internal static class SecT409Field
{
  private const ulong M25 = 33554431 /*0x01FFFFFF*/;
  private const ulong M59 = 576460752303423487 /*0x07FFFFFFFFFFFFFF*/;

  public static void Add(ulong[] x, ulong[] y, ulong[] z)
  {
    z[0] = x[0] ^ y[0];
    z[1] = x[1] ^ y[1];
    z[2] = x[2] ^ y[2];
    z[3] = x[3] ^ y[3];
    z[4] = x[4] ^ y[4];
    z[5] = x[5] ^ y[5];
    z[6] = x[6] ^ y[6];
  }

  public static void AddBothTo(ulong[] x, ulong[] y, ulong[] z)
  {
    z[0] ^= x[0] ^ y[0];
    z[1] ^= x[1] ^ y[1];
    z[2] ^= x[2] ^ y[2];
    z[3] ^= x[3] ^ y[3];
    z[4] ^= x[4] ^ y[4];
    z[5] ^= x[5] ^ y[5];
    z[6] ^= x[6] ^ y[6];
  }

  public static void AddExt(ulong[] xx, ulong[] yy, ulong[] zz)
  {
    for (int index = 0; index < 13; ++index)
      zz[index] = xx[index] ^ yy[index];
  }

  public static void AddOne(ulong[] x, ulong[] z)
  {
    z[0] = x[0] ^ 1UL;
    z[1] = x[1];
    z[2] = x[2];
    z[3] = x[3];
    z[4] = x[4];
    z[5] = x[5];
    z[6] = x[6];
  }

  public static void AddTo(ulong[] x, ulong[] z)
  {
    z[0] ^= x[0];
    z[1] ^= x[1];
    z[2] ^= x[2];
    z[3] ^= x[3];
    z[4] ^= x[4];
    z[5] ^= x[5];
    z[6] ^= x[6];
  }

  public static ulong[] FromBigInteger(BigInteger x) => Nat.FromBigInteger64(409, x);

  public static void HalfTrace(ulong[] x, ulong[] z)
  {
    ulong[] numArray = Nat.Create64(13);
    Nat448.Copy64(x, z);
    for (int index = 1; index < 409; index += 2)
    {
      SecT409Field.ImplSquare(z, numArray);
      SecT409Field.Reduce(numArray, z);
      SecT409Field.ImplSquare(z, numArray);
      SecT409Field.Reduce(numArray, z);
      SecT409Field.AddTo(x, z);
    }
  }

  public static void Invert(ulong[] x, ulong[] z)
  {
    if (Nat448.IsZero64(x))
      throw new InvalidOperationException();
    ulong[] numArray1 = Nat448.Create64();
    ulong[] numArray2 = Nat448.Create64();
    ulong[] numArray3 = Nat448.Create64();
    SecT409Field.Square(x, numArray1);
    SecT409Field.SquareN(numArray1, 1, numArray2);
    SecT409Field.Multiply(numArray1, numArray2, numArray1);
    SecT409Field.SquareN(numArray2, 1, numArray2);
    SecT409Field.Multiply(numArray1, numArray2, numArray1);
    SecT409Field.SquareN(numArray1, 3, numArray2);
    SecT409Field.Multiply(numArray1, numArray2, numArray1);
    SecT409Field.SquareN(numArray1, 6, numArray2);
    SecT409Field.Multiply(numArray1, numArray2, numArray1);
    SecT409Field.SquareN(numArray1, 12, numArray2);
    SecT409Field.Multiply(numArray1, numArray2, numArray3);
    SecT409Field.SquareN(numArray3, 24, numArray1);
    SecT409Field.SquareN(numArray1, 24, numArray2);
    SecT409Field.Multiply(numArray1, numArray2, numArray1);
    SecT409Field.SquareN(numArray1, 48 /*0x30*/, numArray2);
    SecT409Field.Multiply(numArray1, numArray2, numArray1);
    SecT409Field.SquareN(numArray1, 96 /*0x60*/, numArray2);
    SecT409Field.Multiply(numArray1, numArray2, numArray1);
    SecT409Field.SquareN(numArray1, 192 /*0xC0*/, numArray2);
    SecT409Field.Multiply(numArray1, numArray2, numArray1);
    SecT409Field.Multiply(numArray1, numArray3, z);
  }

  public static void Multiply(ulong[] x, ulong[] y, ulong[] z)
  {
    ulong[] ext64 = Nat448.CreateExt64();
    SecT409Field.ImplMultiply(x, y, ext64);
    SecT409Field.Reduce(ext64, z);
  }

  public static void MultiplyAddToExt(ulong[] x, ulong[] y, ulong[] zz)
  {
    ulong[] ext64 = Nat448.CreateExt64();
    SecT409Field.ImplMultiply(x, y, ext64);
    SecT409Field.AddExt(zz, ext64, zz);
  }

  public static void MultiplyExt(ulong[] x, ulong[] y, ulong[] zz)
  {
    Array.Clear((Array) zz, 0, 10);
    SecT409Field.ImplMultiply(x, y, zz);
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
    long num8 = (long) xx[7];
    ulong num9 = xx[12];
    ulong num10 = num6 ^ num9 << 39;
    ulong num11 = num7 ^ num9 >> 25 ^ num9 << 62;
    long num12 = (long) (num9 >> 2);
    long num13 = num8 ^ num12;
    ulong num14 = xx[11];
    ulong num15 = num5 ^ num14 << 39;
    ulong num16 = num10 ^ num14 >> 25 ^ num14 << 62;
    ulong num17 = num11 ^ num14 >> 2;
    ulong num18 = xx[10];
    ulong num19 = num4 ^ num18 << 39;
    ulong num20 = num15 ^ num18 >> 25 ^ num18 << 62;
    ulong num21 = num16 ^ num18 >> 2;
    ulong num22 = xx[9];
    ulong num23 = num3 ^ num22 << 39;
    ulong num24 = num19 ^ num22 >> 25 ^ num22 << 62;
    ulong num25 = num20 ^ num22 >> 2;
    ulong num26 = xx[8];
    ulong num27 = num2 ^ num26 << 39;
    ulong num28 = num23 ^ num26 >> 25 ^ num26 << 62;
    ulong num29 = num24 ^ num26 >> 2;
    ulong num30 = (ulong) num13;
    ulong num31 = num1 ^ num30 << 39;
    ulong num32 = num27 ^ num30 >> 25 ^ num30 << 62;
    ulong num33 = num28 ^ num30 >> 2;
    ulong num34 = num17 >> 25;
    z[0] = num31 ^ num34;
    z[1] = num32 ^ num34 << 23;
    z[2] = num33;
    z[3] = num29;
    z[4] = num25;
    z[5] = num21;
    z[6] = num17 & 33554431UL /*0x01FFFFFF*/;
  }

  public static void Reduce39(ulong[] z, int zOff)
  {
    ulong num1 = z[zOff + 6];
    ulong num2 = num1 >> 25;
    z[zOff] ^= num2;
    z[zOff + 1] ^= num2 << 23;
    z[zOff + 6] = num1 & 33554431UL /*0x01FFFFFF*/;
  }

  public static void Sqrt(ulong[] x, ulong[] z)
  {
    ulong even1;
    ulong num1 = Interleave.Unshuffle(x[0], x[1], out even1);
    ulong even2;
    ulong num2 = Interleave.Unshuffle(x[2], x[3], out even2);
    ulong even3;
    ulong num3 = Interleave.Unshuffle(x[4], x[5], out even3);
    ulong even4;
    ulong num4 = Interleave.Unshuffle(x[6], out even4);
    z[0] = even1 ^ num1 << 44;
    z[1] = even2 ^ num2 << 44 ^ num1 >> 20;
    z[2] = even3 ^ num3 << 44 ^ num2 >> 20;
    z[3] = (ulong) ((long) even4 ^ (long) num4 << 44 ^ (long) (num3 >> 20) ^ (long) num1 << 13);
    z[4] = num4 >> 20 ^ num2 << 13 ^ num1 >> 51;
    z[5] = num3 << 13 ^ num2 >> 51;
    z[6] = num4 << 13 ^ num3 >> 51;
  }

  public static void Square(ulong[] x, ulong[] z)
  {
    ulong[] numArray = Nat.Create64(13);
    SecT409Field.ImplSquare(x, numArray);
    SecT409Field.Reduce(numArray, z);
  }

  public static void SquareAddToExt(ulong[] x, ulong[] zz)
  {
    ulong[] numArray = Nat.Create64(13);
    SecT409Field.ImplSquare(x, numArray);
    SecT409Field.AddExt(zz, numArray, zz);
  }

  public static void SquareExt(ulong[] x, ulong[] zz) => SecT409Field.ImplSquare(x, zz);

  public static void SquareN(ulong[] x, int n, ulong[] z)
  {
    ulong[] numArray = Nat.Create64(13);
    SecT409Field.ImplSquare(x, numArray);
    SecT409Field.Reduce(numArray, z);
    while (--n > 0)
    {
      SecT409Field.ImplSquare(z, numArray);
      SecT409Field.Reduce(numArray, z);
    }
  }

  public static uint Trace(ulong[] x) => (uint) x[0] & 1U;

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
    ulong num11 = zz[10];
    ulong num12 = zz[11];
    ulong num13 = zz[12];
    ulong num14 = zz[13];
    zz[0] = num1 ^ num2 << 59;
    zz[1] = num2 >> 5 ^ num3 << 54;
    zz[2] = num3 >> 10 ^ num4 << 49;
    zz[3] = num4 >> 15 ^ num5 << 44;
    zz[4] = num5 >> 20 ^ num6 << 39;
    zz[5] = num6 >> 25 ^ num7 << 34;
    zz[6] = num7 >> 30 ^ num8 << 29;
    zz[7] = num8 >> 35 ^ num9 << 24;
    zz[8] = num9 >> 40 ^ num10 << 19;
    zz[9] = num10 >> 45 ^ num11 << 14;
    zz[10] = num11 >> 50 ^ num12 << 9;
    zz[11] = (ulong) ((long) (num12 >> 55) ^ (long) num13 << 4 ^ (long) num14 << 63 /*0x3F*/);
    zz[12] = num14 >> 1;
  }

  private static void ImplExpand(ulong[] x, ulong[] z)
  {
    ulong num1 = x[0];
    ulong num2 = x[1];
    ulong num3 = x[2];
    ulong num4 = x[3];
    ulong num5 = x[4];
    ulong num6 = x[5];
    ulong num7 = x[6];
    z[0] = num1 & 576460752303423487UL /*0x07FFFFFFFFFFFFFF*/;
    z[1] = (ulong) (((long) (num1 >> 59) ^ (long) num2 << 5) & 576460752303423487L /*0x07FFFFFFFFFFFFFF*/);
    z[2] = (ulong) (((long) (num2 >> 54) ^ (long) num3 << 10) & 576460752303423487L /*0x07FFFFFFFFFFFFFF*/);
    z[3] = (ulong) (((long) (num3 >> 49) ^ (long) num4 << 15) & 576460752303423487L /*0x07FFFFFFFFFFFFFF*/);
    z[4] = (ulong) (((long) (num4 >> 44) ^ (long) num5 << 20) & 576460752303423487L /*0x07FFFFFFFFFFFFFF*/);
    z[5] = (ulong) (((long) (num5 >> 39) ^ (long) num6 << 25) & 576460752303423487L /*0x07FFFFFFFFFFFFFF*/);
    z[6] = num6 >> 34 ^ num7 << 30;
  }

  private static void ImplMultiply(ulong[] x, ulong[] y, ulong[] zz)
  {
    ulong[] z1 = new ulong[7];
    ulong[] z2 = new ulong[7];
    SecT409Field.ImplExpand(x, z1);
    SecT409Field.ImplExpand(y, z2);
    ulong[] u = new ulong[8];
    for (int index = 0; index < 7; ++index)
      SecT409Field.ImplMulwAcc(u, z1[index], z2[index], zz, index << 1);
    ulong num1 = zz[0];
    ulong num2 = zz[1];
    ulong num3 = num1 ^ zz[2];
    zz[1] = num3 ^ num2;
    ulong num4 = num2 ^ zz[3];
    ulong num5 = num3 ^ zz[4];
    zz[2] = num5 ^ num4;
    ulong num6 = num4 ^ zz[5];
    ulong num7 = num5 ^ zz[6];
    zz[3] = num7 ^ num6;
    ulong num8 = num6 ^ zz[7];
    ulong num9 = num7 ^ zz[8];
    zz[4] = num9 ^ num8;
    ulong num10 = num8 ^ zz[9];
    ulong num11 = num9 ^ zz[10];
    zz[5] = num11 ^ num10;
    ulong num12 = num10 ^ zz[11];
    ulong num13 = num11 ^ zz[12];
    zz[6] = num13 ^ num12;
    ulong num14 = num12 ^ zz[13];
    ulong num15 = num13 ^ num14;
    zz[7] = zz[0] ^ num15;
    zz[8] = zz[1] ^ num15;
    zz[9] = zz[2] ^ num15;
    zz[10] = zz[3] ^ num15;
    zz[11] = zz[4] ^ num15;
    zz[12] = zz[5] ^ num15;
    zz[13] = zz[6] ^ num15;
    SecT409Field.ImplMulwAcc(u, z1[0] ^ z1[1], z2[0] ^ z2[1], zz, 1);
    SecT409Field.ImplMulwAcc(u, z1[0] ^ z1[2], z2[0] ^ z2[2], zz, 2);
    SecT409Field.ImplMulwAcc(u, z1[0] ^ z1[3], z2[0] ^ z2[3], zz, 3);
    SecT409Field.ImplMulwAcc(u, z1[1] ^ z1[2], z2[1] ^ z2[2], zz, 3);
    SecT409Field.ImplMulwAcc(u, z1[0] ^ z1[4], z2[0] ^ z2[4], zz, 4);
    SecT409Field.ImplMulwAcc(u, z1[1] ^ z1[3], z2[1] ^ z2[3], zz, 4);
    SecT409Field.ImplMulwAcc(u, z1[0] ^ z1[5], z2[0] ^ z2[5], zz, 5);
    SecT409Field.ImplMulwAcc(u, z1[1] ^ z1[4], z2[1] ^ z2[4], zz, 5);
    SecT409Field.ImplMulwAcc(u, z1[2] ^ z1[3], z2[2] ^ z2[3], zz, 5);
    SecT409Field.ImplMulwAcc(u, z1[0] ^ z1[6], z2[0] ^ z2[6], zz, 6);
    SecT409Field.ImplMulwAcc(u, z1[1] ^ z1[5], z2[1] ^ z2[5], zz, 6);
    SecT409Field.ImplMulwAcc(u, z1[2] ^ z1[4], z2[2] ^ z2[4], zz, 6);
    SecT409Field.ImplMulwAcc(u, z1[1] ^ z1[6], z2[1] ^ z2[6], zz, 7);
    SecT409Field.ImplMulwAcc(u, z1[2] ^ z1[5], z2[2] ^ z2[5], zz, 7);
    SecT409Field.ImplMulwAcc(u, z1[3] ^ z1[4], z2[3] ^ z2[4], zz, 7);
    SecT409Field.ImplMulwAcc(u, z1[2] ^ z1[6], z2[2] ^ z2[6], zz, 8);
    SecT409Field.ImplMulwAcc(u, z1[3] ^ z1[5], z2[3] ^ z2[5], zz, 8);
    SecT409Field.ImplMulwAcc(u, z1[3] ^ z1[6], z2[3] ^ z2[6], zz, 9);
    SecT409Field.ImplMulwAcc(u, z1[4] ^ z1[5], z2[4] ^ z2[5], zz, 9);
    SecT409Field.ImplMulwAcc(u, z1[4] ^ z1[6], z2[4] ^ z2[6], zz, 10);
    SecT409Field.ImplMulwAcc(u, z1[5] ^ z1[6], z2[5] ^ z2[6], zz, 11);
    SecT409Field.ImplCompactExt(zz);
  }

  private static void ImplMulwAcc(ulong[] u, ulong x, ulong y, ulong[] z, int zOff)
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
    ulong num3 = u[(int) num1 & 7] ^ u[(int) (num1 >> 3) & 7] << 3;
    int num4 = 54;
    do
    {
      uint num5 = (uint) (x >> num4);
      ulong num6 = u[(int) num5 & 7] ^ u[(int) (num5 >> 3) & 7] << 3;
      num3 ^= num6 << num4;
      num2 ^= num6 >> -num4;
    }
    while ((num4 -= 6) > 0);
    z[zOff] ^= num3 & 576460752303423487UL /*0x07FFFFFFFFFFFFFF*/;
    z[zOff + 1] ^= num3 >> 59 ^ num2 << 5;
  }

  private static void ImplSquare(ulong[] x, ulong[] zz)
  {
    zz[12] = Interleave.Expand32to64((uint) x[6]);
    Interleave.Expand64To128(x, 0, 6, zz, 0);
  }
}
