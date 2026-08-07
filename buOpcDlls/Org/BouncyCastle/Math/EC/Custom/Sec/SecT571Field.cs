// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Math.EC.Custom.Sec.SecT571Field
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Math.Raw;
using System;

#nullable disable
namespace Org.BouncyCastle.Math.EC.Custom.Sec;

internal static class SecT571Field
{
  private const ulong M59 = 576460752303423487 /*0x07FFFFFFFFFFFFFF*/;
  private static readonly ulong[] ROOT_Z = new ulong[9]
  {
    3161836309350906777UL,
    10804290191530228771UL,
    14625517132619890193UL,
    7312758566309945096UL,
    17890083061325672324UL,
    8945041530681231562UL,
    13695892802195391589UL,
    6847946401097695794UL,
    541669439031730457UL
  };

  public static void Add(ulong[] x, ulong[] y, ulong[] z) => Nat.Xor64(9, x, y, z);

  private static void Add(ulong[] x, int xOff, ulong[] y, int yOff, ulong[] z, int zOff)
  {
    Nat.Xor64(9, x, xOff, y, yOff, z, zOff);
  }

  public static void AddBothTo(ulong[] x, ulong[] y, ulong[] z)
  {
    for (int index = 0; index < 9; ++index)
      z[index] ^= x[index] ^ y[index];
  }

  private static void AddBothTo(ulong[] x, int xOff, ulong[] y, int yOff, ulong[] z, int zOff)
  {
    for (int index = 0; index < 9; ++index)
      z[zOff + index] ^= x[xOff + index] ^ y[yOff + index];
  }

  public static void AddExt(ulong[] xx, ulong[] yy, ulong[] zz) => Nat.Xor64(18, xx, yy, zz);

  public static void AddOne(ulong[] x, ulong[] z)
  {
    z[0] = x[0] ^ 1UL;
    for (int index = 1; index < 9; ++index)
      z[index] = x[index];
  }

  public static void AddTo(ulong[] x, ulong[] z) => Nat.XorTo64(9, x, z);

  public static ulong[] FromBigInteger(BigInteger x) => Nat.FromBigInteger64(571, x);

  public static void HalfTrace(ulong[] x, ulong[] z)
  {
    ulong[] ext64 = Nat576.CreateExt64();
    Nat576.Copy64(x, z);
    for (int index = 1; index < 571; index += 2)
    {
      SecT571Field.ImplSquare(z, ext64);
      SecT571Field.Reduce(ext64, z);
      SecT571Field.ImplSquare(z, ext64);
      SecT571Field.Reduce(ext64, z);
      SecT571Field.AddTo(x, z);
    }
  }

  public static void Invert(ulong[] x, ulong[] z)
  {
    if (Nat576.IsZero64(x))
      throw new InvalidOperationException();
    ulong[] numArray1 = Nat576.Create64();
    ulong[] numArray2 = Nat576.Create64();
    ulong[] numArray3 = Nat576.Create64();
    SecT571Field.Square(x, numArray3);
    SecT571Field.Square(numArray3, numArray1);
    SecT571Field.Square(numArray1, numArray2);
    SecT571Field.Multiply(numArray1, numArray2, numArray1);
    SecT571Field.SquareN(numArray1, 2, numArray2);
    SecT571Field.Multiply(numArray1, numArray2, numArray1);
    SecT571Field.Multiply(numArray1, numArray3, numArray1);
    SecT571Field.SquareN(numArray1, 5, numArray2);
    SecT571Field.Multiply(numArray1, numArray2, numArray1);
    SecT571Field.SquareN(numArray2, 5, numArray2);
    SecT571Field.Multiply(numArray1, numArray2, numArray1);
    SecT571Field.SquareN(numArray1, 15, numArray2);
    SecT571Field.Multiply(numArray1, numArray2, numArray3);
    SecT571Field.SquareN(numArray3, 30, numArray1);
    SecT571Field.SquareN(numArray1, 30, numArray2);
    SecT571Field.Multiply(numArray1, numArray2, numArray1);
    SecT571Field.SquareN(numArray1, 60, numArray2);
    SecT571Field.Multiply(numArray1, numArray2, numArray1);
    SecT571Field.SquareN(numArray2, 60, numArray2);
    SecT571Field.Multiply(numArray1, numArray2, numArray1);
    SecT571Field.SquareN(numArray1, 180, numArray2);
    SecT571Field.Multiply(numArray1, numArray2, numArray1);
    SecT571Field.SquareN(numArray2, 180, numArray2);
    SecT571Field.Multiply(numArray1, numArray2, numArray1);
    SecT571Field.Multiply(numArray1, numArray3, z);
  }

  public static void Multiply(ulong[] x, ulong[] y, ulong[] z)
  {
    ulong[] ext64 = Nat576.CreateExt64();
    SecT571Field.ImplMultiply(x, y, ext64);
    SecT571Field.Reduce(ext64, z);
  }

  public static void MultiplyAddToExt(ulong[] x, ulong[] y, ulong[] zz)
  {
    ulong[] ext64 = Nat576.CreateExt64();
    SecT571Field.ImplMultiply(x, y, ext64);
    SecT571Field.AddExt(zz, ext64, zz);
  }

  public static void MultiplyExt(ulong[] x, ulong[] y, ulong[] zz)
  {
    Array.Clear((Array) zz, 0, 18);
    SecT571Field.ImplMultiply(x, y, zz);
  }

  public static void MultiplyPrecomp(ulong[] x, ulong[] precomp, ulong[] z)
  {
    ulong[] ext64 = Nat576.CreateExt64();
    SecT571Field.ImplMultiplyPrecomp(x, precomp, ext64);
    SecT571Field.Reduce(ext64, z);
  }

  public static void MultiplyPrecompAddToExt(ulong[] x, ulong[] precomp, ulong[] zz)
  {
    ulong[] ext64 = Nat576.CreateExt64();
    SecT571Field.ImplMultiplyPrecomp(x, precomp, ext64);
    SecT571Field.AddExt(zz, ext64, zz);
  }

  public static ulong[] PrecompMultiplicand(ulong[] x)
  {
    int num1 = 144 /*0x90*/;
    ulong[] numArray = new ulong[288];
    Array.Copy((Array) x, 0, (Array) numArray, 9, 9);
    int num2 = 0;
    for (int index = 7; index > 0; --index)
    {
      num2 += 18;
      long num3 = (long) Nat.ShiftUpBit64(9, numArray, num2 >> 1, 0UL, numArray, num2);
      SecT571Field.Reduce5(numArray, num2);
      SecT571Field.Add(numArray, 9, numArray, num2, numArray, num2 + 9);
    }
    long num4 = (long) Nat.ShiftUpBits64(num1, numArray, 0, 4, 0UL, numArray, num1);
    return numArray;
  }

  public static void Reduce(ulong[] xx, ulong[] z)
  {
    ulong num1 = xx[9];
    ulong num2 = xx[17];
    ulong num3 = num1 ^ num2 >> 59 ^ num2 >> 57 ^ num2 >> 54 ^ num2 >> 49;
    ulong num4 = (ulong) ((long) xx[8] ^ (long) num2 << 5 ^ (long) num2 << 7 ^ (long) num2 << 10 ^ (long) num2 << 15);
    for (int index = 16 /*0x10*/; index >= 10; --index)
    {
      ulong num5 = xx[index];
      z[index - 8] = num4 ^ num5 >> 59 ^ num5 >> 57 ^ num5 >> 54 ^ num5 >> 49;
      num4 = (ulong) ((long) xx[index - 9] ^ (long) num5 << 5 ^ (long) num5 << 7 ^ (long) num5 << 10 ^ (long) num5 << 15);
    }
    ulong num6 = num3;
    z[1] = num4 ^ num6 >> 59 ^ num6 >> 57 ^ num6 >> 54 ^ num6 >> 49;
    ulong num7 = (ulong) ((long) xx[0] ^ (long) num6 << 5 ^ (long) num6 << 7 ^ (long) num6 << 10 ^ (long) num6 << 15);
    ulong num8 = z[8];
    ulong num9 = num8 >> 59;
    z[0] = (ulong) ((long) num7 ^ (long) num9 ^ (long) num9 << 2 ^ (long) num9 << 5 ^ (long) num9 << 10);
    z[8] = num8 & 576460752303423487UL /*0x07FFFFFFFFFFFFFF*/;
  }

  public static void Reduce5(ulong[] z, int zOff)
  {
    ulong num1 = z[zOff + 8];
    ulong num2 = num1 >> 59;
    z[zOff] ^= (ulong) ((long) num2 ^ (long) num2 << 2 ^ (long) num2 << 5 ^ (long) num2 << 10);
    z[zOff + 8] = num1 & 576460752303423487UL /*0x07FFFFFFFFFFFFFF*/;
  }

  public static void Sqrt(ulong[] x, ulong[] z)
  {
    ulong[] y = Nat576.Create64();
    ulong[] x1 = Nat576.Create64();
    x1[0] = Interleave.Unshuffle(x[0], x[1], out y[0]);
    x1[1] = Interleave.Unshuffle(x[2], x[3], out y[1]);
    x1[2] = Interleave.Unshuffle(x[4], x[5], out y[2]);
    x1[3] = Interleave.Unshuffle(x[6], x[7], out y[3]);
    x1[4] = Interleave.Unshuffle(x[8], out y[4]);
    SecT571Field.Multiply(x1, SecT571Field.ROOT_Z, z);
    SecT571Field.Add(z, y, z);
  }

  public static void Square(ulong[] x, ulong[] z)
  {
    ulong[] ext64 = Nat576.CreateExt64();
    SecT571Field.ImplSquare(x, ext64);
    SecT571Field.Reduce(ext64, z);
  }

  public static void SquareAddToExt(ulong[] x, ulong[] zz)
  {
    ulong[] ext64 = Nat576.CreateExt64();
    SecT571Field.ImplSquare(x, ext64);
    SecT571Field.AddExt(zz, ext64, zz);
  }

  public static void SquareExt(ulong[] x, ulong[] zz) => SecT571Field.ImplSquare(x, zz);

  public static void SquareN(ulong[] x, int n, ulong[] z)
  {
    ulong[] ext64 = Nat576.CreateExt64();
    SecT571Field.ImplSquare(x, ext64);
    SecT571Field.Reduce(ext64, z);
    while (--n > 0)
    {
      SecT571Field.ImplSquare(z, ext64);
      SecT571Field.Reduce(ext64, z);
    }
  }

  public static uint Trace(ulong[] x) => (uint) (x[0] ^ x[8] >> 49 ^ x[8] >> 57) & 1U;

  private static void ImplMultiply(ulong[] x, ulong[] y, ulong[] zz)
  {
    ulong[] u = new ulong[16 /*0x10*/];
    for (int index = 0; index < 9; ++index)
      SecT571Field.ImplMulwAcc(u, x[index], y[index], zz, index << 1);
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
    ulong num15 = num13 ^ zz[14];
    zz[7] = num15 ^ num14;
    ulong num16 = num14 ^ zz[15];
    ulong num17 = num15 ^ zz[16 /*0x10*/];
    zz[8] = num17 ^ num16;
    ulong num18 = num16 ^ zz[17];
    ulong num19 = num17 ^ num18;
    zz[9] = zz[0] ^ num19;
    zz[10] = zz[1] ^ num19;
    zz[11] = zz[2] ^ num19;
    zz[12] = zz[3] ^ num19;
    zz[13] = zz[4] ^ num19;
    zz[14] = zz[5] ^ num19;
    zz[15] = zz[6] ^ num19;
    zz[16 /*0x10*/] = zz[7] ^ num19;
    zz[17] = zz[8] ^ num19;
    SecT571Field.ImplMulwAcc(u, x[0] ^ x[1], y[0] ^ y[1], zz, 1);
    SecT571Field.ImplMulwAcc(u, x[0] ^ x[2], y[0] ^ y[2], zz, 2);
    SecT571Field.ImplMulwAcc(u, x[0] ^ x[3], y[0] ^ y[3], zz, 3);
    SecT571Field.ImplMulwAcc(u, x[1] ^ x[2], y[1] ^ y[2], zz, 3);
    SecT571Field.ImplMulwAcc(u, x[0] ^ x[4], y[0] ^ y[4], zz, 4);
    SecT571Field.ImplMulwAcc(u, x[1] ^ x[3], y[1] ^ y[3], zz, 4);
    SecT571Field.ImplMulwAcc(u, x[0] ^ x[5], y[0] ^ y[5], zz, 5);
    SecT571Field.ImplMulwAcc(u, x[1] ^ x[4], y[1] ^ y[4], zz, 5);
    SecT571Field.ImplMulwAcc(u, x[2] ^ x[3], y[2] ^ y[3], zz, 5);
    SecT571Field.ImplMulwAcc(u, x[0] ^ x[6], y[0] ^ y[6], zz, 6);
    SecT571Field.ImplMulwAcc(u, x[1] ^ x[5], y[1] ^ y[5], zz, 6);
    SecT571Field.ImplMulwAcc(u, x[2] ^ x[4], y[2] ^ y[4], zz, 6);
    SecT571Field.ImplMulwAcc(u, x[0] ^ x[7], y[0] ^ y[7], zz, 7);
    SecT571Field.ImplMulwAcc(u, x[1] ^ x[6], y[1] ^ y[6], zz, 7);
    SecT571Field.ImplMulwAcc(u, x[2] ^ x[5], y[2] ^ y[5], zz, 7);
    SecT571Field.ImplMulwAcc(u, x[3] ^ x[4], y[3] ^ y[4], zz, 7);
    SecT571Field.ImplMulwAcc(u, x[0] ^ x[8], y[0] ^ y[8], zz, 8);
    SecT571Field.ImplMulwAcc(u, x[1] ^ x[7], y[1] ^ y[7], zz, 8);
    SecT571Field.ImplMulwAcc(u, x[2] ^ x[6], y[2] ^ y[6], zz, 8);
    SecT571Field.ImplMulwAcc(u, x[3] ^ x[5], y[3] ^ y[5], zz, 8);
    SecT571Field.ImplMulwAcc(u, x[1] ^ x[8], y[1] ^ y[8], zz, 9);
    SecT571Field.ImplMulwAcc(u, x[2] ^ x[7], y[2] ^ y[7], zz, 9);
    SecT571Field.ImplMulwAcc(u, x[3] ^ x[6], y[3] ^ y[6], zz, 9);
    SecT571Field.ImplMulwAcc(u, x[4] ^ x[5], y[4] ^ y[5], zz, 9);
    SecT571Field.ImplMulwAcc(u, x[2] ^ x[8], y[2] ^ y[8], zz, 10);
    SecT571Field.ImplMulwAcc(u, x[3] ^ x[7], y[3] ^ y[7], zz, 10);
    SecT571Field.ImplMulwAcc(u, x[4] ^ x[6], y[4] ^ y[6], zz, 10);
    SecT571Field.ImplMulwAcc(u, x[3] ^ x[8], y[3] ^ y[8], zz, 11);
    SecT571Field.ImplMulwAcc(u, x[4] ^ x[7], y[4] ^ y[7], zz, 11);
    SecT571Field.ImplMulwAcc(u, x[5] ^ x[6], y[5] ^ y[6], zz, 11);
    SecT571Field.ImplMulwAcc(u, x[4] ^ x[8], y[4] ^ y[8], zz, 12);
    SecT571Field.ImplMulwAcc(u, x[5] ^ x[7], y[5] ^ y[7], zz, 12);
    SecT571Field.ImplMulwAcc(u, x[5] ^ x[8], y[5] ^ y[8], zz, 13);
    SecT571Field.ImplMulwAcc(u, x[6] ^ x[7], y[6] ^ y[7], zz, 13);
    SecT571Field.ImplMulwAcc(u, x[6] ^ x[8], y[6] ^ y[8], zz, 14);
    SecT571Field.ImplMulwAcc(u, x[7] ^ x[8], y[7] ^ y[8], zz, 15);
  }

  private static void ImplMultiplyPrecomp(ulong[] x, ulong[] precomp, ulong[] zz)
  {
    uint num1 = 15;
    for (int index1 = 56; index1 >= 0; index1 -= 8)
    {
      for (int index2 = 1; index2 < 9; index2 += 2)
      {
        int num2 = (int) (uint) (x[index2] >> index1);
        uint num3 = (uint) num2 & num1;
        uint num4 = (uint) (num2 >>> 4) & num1;
        SecT571Field.AddBothTo(precomp, 9 * (int) num3, precomp, 9 * ((int) num4 + 16 /*0x10*/), zz, index2 - 1);
      }
      long num5 = (long) Nat.ShiftUpBits64(16 /*0x10*/, zz, 0, 8, 0UL);
    }
    for (int index = 56; index >= 0; index -= 8)
    {
      for (int zOff = 0; zOff < 9; zOff += 2)
      {
        int num6 = (int) (uint) (x[zOff] >> index);
        uint num7 = (uint) num6 & num1;
        uint num8 = (uint) (num6 >>> 4) & num1;
        SecT571Field.AddBothTo(precomp, 9 * (int) num7, precomp, 9 * ((int) num8 + 16 /*0x10*/), zz, zOff);
      }
      if (index > 0)
      {
        long num9 = (long) Nat.ShiftUpBits64(18, zz, 0, 8, 0UL);
      }
    }
  }

  private static void ImplMulwAcc(ulong[] u, ulong x, ulong y, ulong[] z, int zOff)
  {
    u[1] = y;
    for (int index = 2; index < 16 /*0x10*/; index += 2)
    {
      u[index] = u[index >> 1] << 1;
      u[index + 1] = u[index] ^ y;
    }
    uint num1 = (uint) x;
    ulong num2 = 0;
    ulong num3 = u[(int) num1 & 15] ^ u[(int) (num1 >> 4) & 15] << 4;
    int num4 = 56;
    do
    {
      uint num5 = (uint) (x >> num4);
      ulong num6 = u[(int) num5 & 15] ^ u[(int) (num5 >> 4) & 15] << 4;
      num3 ^= num6 << num4;
      num2 ^= num6 >> -num4;
    }
    while ((num4 -= 8) > 0);
    for (int index = 0; index < 7; ++index)
    {
      x = (x & 18374403900871474942UL /*0xFEFEFEFEFEFEFEFE*/) >> 1;
      num2 ^= x & (ulong) ((long) y << index >> 63 /*0x3F*/);
    }
    z[zOff] ^= num3;
    z[zOff + 1] ^= num2;
  }

  private static void ImplSquare(ulong[] x, ulong[] zz) => Interleave.Expand64To128(x, 0, 9, zz, 0);
}
