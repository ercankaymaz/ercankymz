// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Math.EC.Custom.Sec.SecT163Field
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Math.Raw;
using System;

#nullable disable
namespace Org.BouncyCastle.Math.EC.Custom.Sec;

internal static class SecT163Field
{
  private const ulong M35 = 34359738367 /*0x07FFFFFFFF*/;
  private const ulong M55 = 36028797018963967 /*0x7FFFFFFFFFFFFF*/;
  private static readonly ulong[] ROOT_Z = new ulong[3]
  {
    13176245766935393968UL,
    5270498306774195053UL,
    19634136210UL /*0x0492492492*/
  };

  public static void Add(ulong[] x, ulong[] y, ulong[] z)
  {
    z[0] = x[0] ^ y[0];
    z[1] = x[1] ^ y[1];
    z[2] = x[2] ^ y[2];
  }

  public static void AddBothTo(ulong[] x, ulong[] y, ulong[] z)
  {
    z[0] ^= x[0] ^ y[0];
    z[1] ^= x[1] ^ y[1];
    z[2] ^= x[2] ^ y[2];
  }

  public static void AddExt(ulong[] xx, ulong[] yy, ulong[] zz)
  {
    zz[0] = xx[0] ^ yy[0];
    zz[1] = xx[1] ^ yy[1];
    zz[2] = xx[2] ^ yy[2];
    zz[3] = xx[3] ^ yy[3];
    zz[4] = xx[4] ^ yy[4];
    zz[5] = xx[5] ^ yy[5];
  }

  public static void AddOne(ulong[] x, ulong[] z)
  {
    z[0] = x[0] ^ 1UL;
    z[1] = x[1];
    z[2] = x[2];
  }

  public static void AddTo(ulong[] x, ulong[] z)
  {
    z[0] ^= x[0];
    z[1] ^= x[1];
    z[2] ^= x[2];
  }

  public static ulong[] FromBigInteger(BigInteger x) => Nat.FromBigInteger64(163, x);

  public static void HalfTrace(ulong[] x, ulong[] z)
  {
    ulong[] ext64 = Nat192.CreateExt64();
    Nat192.Copy64(x, z);
    for (int index = 1; index < 163; index += 2)
    {
      SecT163Field.ImplSquare(z, ext64);
      SecT163Field.Reduce(ext64, z);
      SecT163Field.ImplSquare(z, ext64);
      SecT163Field.Reduce(ext64, z);
      SecT163Field.AddTo(x, z);
    }
  }

  public static void Invert(ulong[] x, ulong[] z)
  {
    if (Nat192.IsZero64(x))
      throw new InvalidOperationException();
    ulong[] numArray1 = Nat192.Create64();
    ulong[] numArray2 = Nat192.Create64();
    SecT163Field.Square(x, numArray1);
    SecT163Field.SquareN(numArray1, 1, numArray2);
    SecT163Field.Multiply(numArray1, numArray2, numArray1);
    SecT163Field.SquareN(numArray2, 1, numArray2);
    SecT163Field.Multiply(numArray1, numArray2, numArray1);
    SecT163Field.SquareN(numArray1, 3, numArray2);
    SecT163Field.Multiply(numArray1, numArray2, numArray1);
    SecT163Field.SquareN(numArray2, 3, numArray2);
    SecT163Field.Multiply(numArray1, numArray2, numArray1);
    SecT163Field.SquareN(numArray1, 9, numArray2);
    SecT163Field.Multiply(numArray1, numArray2, numArray1);
    SecT163Field.SquareN(numArray2, 9, numArray2);
    SecT163Field.Multiply(numArray1, numArray2, numArray1);
    SecT163Field.SquareN(numArray1, 27, numArray2);
    SecT163Field.Multiply(numArray1, numArray2, numArray1);
    SecT163Field.SquareN(numArray2, 27, numArray2);
    SecT163Field.Multiply(numArray1, numArray2, numArray1);
    SecT163Field.SquareN(numArray1, 81, numArray2);
    SecT163Field.Multiply(numArray1, numArray2, z);
  }

  public static void Multiply(ulong[] x, ulong[] y, ulong[] z)
  {
    ulong[] numArray = new ulong[8];
    SecT163Field.ImplMultiply(x, y, numArray);
    SecT163Field.Reduce(numArray, z);
  }

  public static void MultiplyAddToExt(ulong[] x, ulong[] y, ulong[] zz)
  {
    ulong[] numArray = new ulong[8];
    SecT163Field.ImplMultiply(x, y, numArray);
    SecT163Field.AddExt(zz, numArray, zz);
  }

  public static void MultiplyExt(ulong[] x, ulong[] y, ulong[] zz)
  {
    SecT163Field.ImplMultiply(x, y, zz);
  }

  public static void Reduce(ulong[] xx, ulong[] z)
  {
    ulong num1 = xx[0];
    ulong num2 = xx[1];
    ulong num3 = xx[2];
    ulong num4 = xx[3];
    ulong num5 = xx[4];
    ulong num6 = xx[5];
    ulong num7 = num3 ^ (ulong) ((long) num6 << 29 ^ (long) num6 << 32 /*0x20*/ ^ (long) num6 << 35 ^ (long) num6 << 36);
    ulong num8 = num4 ^ num6 >> 35 ^ num6 >> 32 /*0x20*/ ^ num6 >> 29 ^ num6 >> 28;
    ulong num9 = num2 ^ (ulong) ((long) num5 << 29 ^ (long) num5 << 32 /*0x20*/ ^ (long) num5 << 35 ^ (long) num5 << 36);
    ulong num10 = num7 ^ num5 >> 35 ^ num5 >> 32 /*0x20*/ ^ num5 >> 29 ^ num5 >> 28;
    ulong num11 = num1 ^ (ulong) ((long) num8 << 29 ^ (long) num8 << 32 /*0x20*/ ^ (long) num8 << 35 ^ (long) num8 << 36);
    ulong num12 = num9 ^ num8 >> 35 ^ num8 >> 32 /*0x20*/ ^ num8 >> 29 ^ num8 >> 28;
    ulong num13 = num10 >> 35;
    z[0] = (ulong) ((long) num11 ^ (long) num13 ^ (long) num13 << 3 ^ (long) num13 << 6 ^ (long) num13 << 7);
    z[1] = num12;
    z[2] = num10 & 34359738367UL /*0x07FFFFFFFF*/;
  }

  public static void Reduce29(ulong[] z, int zOff)
  {
    ulong num1 = z[zOff + 2];
    ulong num2 = num1 >> 35;
    z[zOff] ^= (ulong) ((long) num2 ^ (long) num2 << 3 ^ (long) num2 << 6 ^ (long) num2 << 7);
    z[zOff + 2] = num1 & 34359738367UL /*0x07FFFFFFFF*/;
  }

  public static void Sqrt(ulong[] x, ulong[] z)
  {
    ulong[] x1 = Nat192.Create64();
    ulong even1;
    x1[0] = Interleave.Unshuffle(x[0], x[1], out even1);
    ulong even2;
    x1[1] = Interleave.Unshuffle(x[2], out even2);
    SecT163Field.Multiply(x1, SecT163Field.ROOT_Z, z);
    z[0] ^= even1;
    z[1] ^= even2;
  }

  public static void Square(ulong[] x, ulong[] z)
  {
    ulong[] ext64 = Nat192.CreateExt64();
    SecT163Field.ImplSquare(x, ext64);
    SecT163Field.Reduce(ext64, z);
  }

  public static void SquareAddToExt(ulong[] x, ulong[] zz)
  {
    ulong[] ext64 = Nat256.CreateExt64();
    SecT163Field.ImplSquare(x, ext64);
    SecT163Field.AddExt(zz, ext64, zz);
  }

  public static void SquareExt(ulong[] x, ulong[] zz) => SecT163Field.ImplSquare(x, zz);

  public static void SquareN(ulong[] x, int n, ulong[] z)
  {
    ulong[] ext64 = Nat192.CreateExt64();
    SecT163Field.ImplSquare(x, ext64);
    SecT163Field.Reduce(ext64, z);
    while (--n > 0)
    {
      SecT163Field.ImplSquare(z, ext64);
      SecT163Field.Reduce(ext64, z);
    }
  }

  public static uint Trace(ulong[] x) => (uint) (x[0] ^ x[2] >> 29) & 1U;

  private static void ImplCompactExt(ulong[] zz)
  {
    ulong num1 = zz[0];
    ulong num2 = zz[1];
    ulong num3 = zz[2];
    ulong num4 = zz[3];
    ulong num5 = zz[4];
    ulong num6 = zz[5];
    zz[0] = num1 ^ num2 << 55;
    zz[1] = num2 >> 9 ^ num3 << 46;
    zz[2] = num3 >> 18 ^ num4 << 37;
    zz[3] = num4 >> 27 ^ num5 << 28;
    zz[4] = num5 >> 36 ^ num6 << 19;
    zz[5] = num6 >> 45;
  }

  private static void ImplMultiply(ulong[] x, ulong[] y, ulong[] zz)
  {
    ulong num1 = x[0];
    ulong num2 = x[1];
    ulong num3 = x[2];
    ulong x1 = num2 >> 46 ^ num3 << 18;
    ulong num4 = (ulong) (((long) (num1 >> 55) ^ (long) num2 << 9) & 36028797018963967L /*0x7FFFFFFFFFFFFF*/);
    ulong x2 = num1 & 36028797018963967UL /*0x7FFFFFFFFFFFFF*/;
    ulong num5 = y[0];
    ulong num6 = y[1];
    ulong num7 = y[2];
    ulong y1 = num6 >> 46 ^ num7 << 18;
    ulong num8 = (ulong) (((long) (num5 >> 55) ^ (long) num6 << 9) & 36028797018963967L /*0x7FFFFFFFFFFFFF*/);
    ulong y2 = num5 & 36028797018963967UL /*0x7FFFFFFFFFFFFF*/;
    ulong[] u = zz;
    ulong[] z = new ulong[10];
    SecT163Field.ImplMulw(u, x2, y2, z, 0);
    SecT163Field.ImplMulw(u, x1, y1, z, 2);
    ulong x3 = x2 ^ num4 ^ x1;
    ulong y3 = y2 ^ num8 ^ y1;
    SecT163Field.ImplMulw(u, x3, y3, z, 4);
    ulong num9 = (ulong) ((long) num4 << 1 ^ (long) x1 << 2);
    ulong num10 = (ulong) ((long) num8 << 1 ^ (long) y1 << 2);
    SecT163Field.ImplMulw(u, x2 ^ num9, y2 ^ num10, z, 6);
    SecT163Field.ImplMulw(u, x3 ^ num9, y3 ^ num10, z, 8);
    long num11 = (long) z[6] ^ (long) z[8];
    ulong num12 = z[7] ^ z[9];
    ulong num13 = (ulong) (num11 << 1) ^ z[6];
    ulong num14 = (ulong) (num11 ^ (long) num12 << 1) ^ z[7];
    ulong num15 = num12;
    ulong num16 = z[0];
    ulong num17 = z[1] ^ z[0] ^ z[4];
    ulong num18 = z[1] ^ z[5];
    ulong num19 = (ulong) ((long) num16 ^ (long) num13 ^ (long) z[2] << 4 ^ (long) z[2] << 1);
    ulong num20 = (ulong) ((long) num17 ^ (long) num14 ^ (long) z[3] << 4 ^ (long) z[3] << 1);
    ulong num21 = num18 ^ num15;
    ulong num22 = num20 ^ num19 >> 55;
    ulong num23 = num19 & 36028797018963967UL /*0x7FFFFFFFFFFFFF*/;
    ulong num24 = num21 ^ num22 >> 55;
    ulong num25 = num22 & 36028797018963967UL /*0x7FFFFFFFFFFFFF*/;
    ulong num26 = num23 >> 1 ^ (ulong) (((long) num25 & 1L) << 54);
    ulong num27 = num25 >> 1 ^ (ulong) (((long) num24 & 1L) << 54);
    ulong num28 = num24 >> 1;
    ulong num29 = num26 ^ num26 << 1;
    ulong num30 = num29 ^ num29 << 2;
    ulong num31 = num30 ^ num30 << 4;
    ulong num32 = num31 ^ num31 << 8;
    ulong num33 = num32 ^ num32 << 16 /*0x10*/;
    ulong num34 = (num33 ^ num33 << 32 /*0x20*/) & 36028797018963967UL /*0x7FFFFFFFFFFFFF*/;
    ulong num35 = num27 ^ num34 >> 54;
    ulong num36 = num35 ^ num35 << 1;
    ulong num37 = num36 ^ num36 << 2;
    ulong num38 = num37 ^ num37 << 4;
    ulong num39 = num38 ^ num38 << 8;
    ulong num40 = num39 ^ num39 << 16 /*0x10*/;
    ulong num41 = (num40 ^ num40 << 32 /*0x20*/) & 36028797018963967UL /*0x7FFFFFFFFFFFFF*/;
    ulong num42 = num28 ^ num41 >> 54;
    ulong num43 = num42 ^ num42 << 1;
    ulong num44 = num43 ^ num43 << 2;
    ulong num45 = num44 ^ num44 << 4;
    ulong num46 = num45 ^ num45 << 8;
    ulong num47 = num46 ^ num46 << 16 /*0x10*/;
    ulong num48 = num47 ^ num47 << 32 /*0x20*/;
    zz[0] = num16;
    zz[1] = num17 ^ num34 ^ z[2];
    zz[2] = num18 ^ num41 ^ num34 ^ z[3];
    zz[3] = num48 ^ num41;
    zz[4] = num48 ^ z[2];
    zz[5] = z[3];
    SecT163Field.ImplCompactExt(zz);
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
    ulong num3 = u[(int) num1 & 3];
    int num4 = 47;
    do
    {
      uint num5 = (uint) (x >> num4);
      ulong num6 = (ulong) ((long) u[(int) num5 & 7] ^ (long) u[(int) (num5 >> 3) & 7] << 3 ^ (long) u[(int) (num5 >> 6) & 7] << 6);
      num3 ^= num6 << num4;
      num2 ^= num6 >> -num4;
    }
    while ((num4 -= 9) > 0);
    z[zOff] = num3 & 36028797018963967UL /*0x7FFFFFFFFFFFFF*/;
    z[zOff + 1] = num3 >> 55 ^ num2 << 9;
  }

  private static void ImplSquare(ulong[] x, ulong[] zz) => Interleave.Expand64To128(x, 0, 3, zz, 0);
}
