// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Math.EC.Custom.Sec.SecT193Field
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Math.Raw;
using System;

#nullable disable
namespace Org.BouncyCastle.Math.EC.Custom.Sec;

internal static class SecT193Field
{
  private const ulong M01 = 1;
  private const ulong M49 = 562949953421311 /*0x01FFFFFFFFFFFF*/;

  public static void Add(ulong[] x, ulong[] y, ulong[] z)
  {
    z[0] = x[0] ^ y[0];
    z[1] = x[1] ^ y[1];
    z[2] = x[2] ^ y[2];
    z[3] = x[3] ^ y[3];
  }

  public static void AddBothTo(ulong[] x, ulong[] y, ulong[] z)
  {
    z[0] ^= x[0] ^ y[0];
    z[1] ^= x[1] ^ y[1];
    z[2] ^= x[2] ^ y[2];
    z[3] ^= x[3] ^ y[3];
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
  }

  public static void AddOne(ulong[] x, ulong[] z)
  {
    z[0] = x[0] ^ 1UL;
    z[1] = x[1];
    z[2] = x[2];
    z[3] = x[3];
  }

  public static void AddTo(ulong[] x, ulong[] z)
  {
    z[0] ^= x[0];
    z[1] ^= x[1];
    z[2] ^= x[2];
    z[3] ^= x[3];
  }

  public static ulong[] FromBigInteger(BigInteger x) => Nat.FromBigInteger64(193, x);

  public static void HalfTrace(ulong[] x, ulong[] z)
  {
    ulong[] ext64 = Nat256.CreateExt64();
    Nat256.Copy64(x, z);
    for (int index = 1; index < 193; index += 2)
    {
      SecT193Field.ImplSquare(z, ext64);
      SecT193Field.Reduce(ext64, z);
      SecT193Field.ImplSquare(z, ext64);
      SecT193Field.Reduce(ext64, z);
      SecT193Field.AddTo(x, z);
    }
  }

  public static void Invert(ulong[] x, ulong[] z)
  {
    if (Nat256.IsZero64(x))
      throw new InvalidOperationException();
    ulong[] numArray1 = Nat256.Create64();
    ulong[] numArray2 = Nat256.Create64();
    SecT193Field.Square(x, numArray1);
    SecT193Field.SquareN(numArray1, 1, numArray2);
    SecT193Field.Multiply(numArray1, numArray2, numArray1);
    SecT193Field.SquareN(numArray2, 1, numArray2);
    SecT193Field.Multiply(numArray1, numArray2, numArray1);
    SecT193Field.SquareN(numArray1, 3, numArray2);
    SecT193Field.Multiply(numArray1, numArray2, numArray1);
    SecT193Field.SquareN(numArray1, 6, numArray2);
    SecT193Field.Multiply(numArray1, numArray2, numArray1);
    SecT193Field.SquareN(numArray1, 12, numArray2);
    SecT193Field.Multiply(numArray1, numArray2, numArray1);
    SecT193Field.SquareN(numArray1, 24, numArray2);
    SecT193Field.Multiply(numArray1, numArray2, numArray1);
    SecT193Field.SquareN(numArray1, 48 /*0x30*/, numArray2);
    SecT193Field.Multiply(numArray1, numArray2, numArray1);
    SecT193Field.SquareN(numArray1, 96 /*0x60*/, numArray2);
    SecT193Field.Multiply(numArray1, numArray2, z);
  }

  public static void Multiply(ulong[] x, ulong[] y, ulong[] z)
  {
    ulong[] ext64 = Nat256.CreateExt64();
    SecT193Field.ImplMultiply(x, y, ext64);
    SecT193Field.Reduce(ext64, z);
  }

  public static void MultiplyAddToExt(ulong[] x, ulong[] y, ulong[] zz)
  {
    ulong[] ext64 = Nat256.CreateExt64();
    SecT193Field.ImplMultiply(x, y, ext64);
    SecT193Field.AddExt(zz, ext64, zz);
  }

  public static void MultiplyExt(ulong[] x, ulong[] y, ulong[] zz)
  {
    Array.Clear((Array) zz, 0, 8);
    SecT193Field.ImplMultiply(x, y, zz);
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
    ulong num8 = num3 ^ num7 << 63 /*0x3F*/;
    ulong num9 = num4 ^ num7 >> 1 ^ num7 << 14;
    ulong num10 = num5 ^ num7 >> 50;
    ulong num11 = num2 ^ num6 << 63 /*0x3F*/;
    ulong num12 = num8 ^ num6 >> 1 ^ num6 << 14;
    ulong num13 = num9 ^ num6 >> 50;
    ulong num14 = num1 ^ num10 << 63 /*0x3F*/;
    ulong num15 = num11 ^ num10 >> 1 ^ num10 << 14;
    ulong num16 = num12 ^ num10 >> 50;
    ulong num17 = num13 >> 1;
    z[0] = (ulong) ((long) num14 ^ (long) num17 ^ (long) num17 << 15);
    z[1] = num15 ^ num17 >> 49;
    z[2] = num16;
    z[3] = num13 & 1UL;
  }

  public static void Reduce63(ulong[] z, int zOff)
  {
    ulong num1 = z[zOff + 3];
    ulong num2 = num1 >> 1;
    z[zOff] ^= num2 ^ num2 << 15;
    z[zOff + 1] ^= num2 >> 49;
    z[zOff + 3] = num1 & 1UL;
  }

  public static void Sqrt(ulong[] x, ulong[] z)
  {
    ulong even1;
    ulong num1 = Interleave.Unshuffle(x[0], x[1], out even1);
    ulong even2;
    ulong num2 = Interleave.Unshuffle(x[2], out even2);
    ulong num3 = even2 ^ x[3] << 32 /*0x20*/;
    z[0] = even1 ^ num1 << 8;
    z[1] = (ulong) ((long) num3 ^ (long) num2 << 8 ^ (long) (num1 >> 56) ^ (long) num1 << 33);
    z[2] = num2 >> 56 ^ num2 << 33 ^ num1 >> 31 /*0x1F*/;
    z[3] = num2 >> 31 /*0x1F*/;
  }

  public static void Square(ulong[] x, ulong[] z)
  {
    ulong[] ext64 = Nat256.CreateExt64();
    SecT193Field.ImplSquare(x, ext64);
    SecT193Field.Reduce(ext64, z);
  }

  public static void SquareAddToExt(ulong[] x, ulong[] zz)
  {
    ulong[] ext64 = Nat256.CreateExt64();
    SecT193Field.ImplSquare(x, ext64);
    SecT193Field.AddExt(zz, ext64, zz);
  }

  public static void SquareExt(ulong[] x, ulong[] zz) => SecT193Field.ImplSquare(x, zz);

  public static void SquareN(ulong[] x, int n, ulong[] z)
  {
    ulong[] ext64 = Nat256.CreateExt64();
    SecT193Field.ImplSquare(x, ext64);
    SecT193Field.Reduce(ext64, z);
    while (--n > 0)
    {
      SecT193Field.ImplSquare(z, ext64);
      SecT193Field.Reduce(ext64, z);
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
    zz[0] = num1 ^ num2 << 49;
    zz[1] = num2 >> 15 ^ num3 << 34;
    zz[2] = num3 >> 30 ^ num4 << 19;
    zz[3] = (ulong) ((long) (num4 >> 45) ^ (long) num5 << 4 ^ (long) num6 << 53);
    zz[4] = num5 >> 60 ^ num7 << 38 ^ num6 >> 11;
    zz[5] = num7 >> 26 ^ num8 << 23;
    zz[6] = num8 >> 41;
    zz[7] = 0UL;
  }

  private static void ImplExpand(ulong[] x, ulong[] z)
  {
    ulong num1 = x[0];
    ulong num2 = x[1];
    ulong num3 = x[2];
    ulong num4 = x[3];
    z[0] = num1 & 562949953421311UL /*0x01FFFFFFFFFFFF*/;
    z[1] = (ulong) (((long) (num1 >> 49) ^ (long) num2 << 15) & 562949953421311L /*0x01FFFFFFFFFFFF*/);
    z[2] = (ulong) (((long) (num2 >> 34) ^ (long) num3 << 30) & 562949953421311L /*0x01FFFFFFFFFFFF*/);
    z[3] = num3 >> 19 ^ num4 << 45;
  }

  private static void ImplMultiply(ulong[] x, ulong[] y, ulong[] zz)
  {
    ulong[] z1 = new ulong[4];
    ulong[] z2 = new ulong[4];
    SecT193Field.ImplExpand(x, z1);
    SecT193Field.ImplExpand(y, z2);
    ulong[] u = new ulong[8];
    SecT193Field.ImplMulwAcc(u, z1[0], z2[0], zz, 0);
    SecT193Field.ImplMulwAcc(u, z1[1], z2[1], zz, 1);
    SecT193Field.ImplMulwAcc(u, z1[2], z2[2], zz, 2);
    SecT193Field.ImplMulwAcc(u, z1[3], z2[3], zz, 3);
    for (int index = 5; index > 0; --index)
      zz[index] ^= zz[index - 1];
    SecT193Field.ImplMulwAcc(u, z1[0] ^ z1[1], z2[0] ^ z2[1], zz, 1);
    SecT193Field.ImplMulwAcc(u, z1[2] ^ z1[3], z2[2] ^ z2[3], zz, 3);
    for (int index = 7; index > 1; --index)
      zz[index] ^= zz[index - 2];
    ulong x1 = z1[0] ^ z1[2];
    ulong x2 = z1[1] ^ z1[3];
    ulong y1 = z2[0] ^ z2[2];
    ulong y2 = z2[1] ^ z2[3];
    SecT193Field.ImplMulwAcc(u, x1 ^ x2, y1 ^ y2, zz, 3);
    ulong[] z3 = new ulong[3];
    SecT193Field.ImplMulwAcc(u, x1, y1, z3, 0);
    SecT193Field.ImplMulwAcc(u, x2, y2, z3, 1);
    ulong num1 = z3[0];
    ulong num2 = z3[1];
    ulong num3 = z3[2];
    zz[2] ^= num1;
    zz[3] ^= num1 ^ num2;
    zz[4] ^= num3 ^ num2;
    zz[5] ^= num3;
    SecT193Field.ImplCompactExt(zz);
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
    int num4 = 36;
    do
    {
      uint num5 = (uint) (x >> num4);
      ulong num6 = (ulong) ((long) u[(int) num5 & 7] ^ (long) u[(int) (num5 >> 3) & 7] << 3 ^ (long) u[(int) (num5 >> 6) & 7] << 6 ^ (long) u[(int) (num5 >> 9) & 7] << 9 ^ (long) u[(int) (num5 >> 12) & 7] << 12);
      num3 ^= num6 << num4;
      num2 ^= num6 >> -num4;
    }
    while ((num4 -= 15) > 0);
    z[zOff] ^= num3 & 562949953421311UL /*0x01FFFFFFFFFFFF*/;
    z[zOff + 1] ^= num3 >> 49 ^ num2 << 15;
  }

  private static void ImplSquare(ulong[] x, ulong[] zz)
  {
    zz[6] = x[3] & 1UL;
    Interleave.Expand64To128(x, 0, 3, zz, 0);
  }
}
