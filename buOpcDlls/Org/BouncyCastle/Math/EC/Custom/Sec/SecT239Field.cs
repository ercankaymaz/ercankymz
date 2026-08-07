// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Math.EC.Custom.Sec.SecT239Field
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Math.Raw;
using System;

#nullable disable
namespace Org.BouncyCastle.Math.EC.Custom.Sec;

internal static class SecT239Field
{
  private const ulong M47 = 140737488355327 /*0x7FFFFFFFFFFF*/;
  private const ulong M60 = 1152921504606846975 /*0x0FFFFFFFFFFFFFFF*/;

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
    zz[7] = xx[7] ^ yy[7];
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

  public static ulong[] FromBigInteger(BigInteger x) => Nat.FromBigInteger64(239, x);

  public static void HalfTrace(ulong[] x, ulong[] z)
  {
    ulong[] ext64 = Nat256.CreateExt64();
    Nat256.Copy64(x, z);
    for (int index = 1; index < 239; index += 2)
    {
      SecT239Field.ImplSquare(z, ext64);
      SecT239Field.Reduce(ext64, z);
      SecT239Field.ImplSquare(z, ext64);
      SecT239Field.Reduce(ext64, z);
      SecT239Field.AddTo(x, z);
    }
  }

  public static void Invert(ulong[] x, ulong[] z)
  {
    if (Nat256.IsZero64(x))
      throw new InvalidOperationException();
    ulong[] numArray1 = Nat256.Create64();
    ulong[] numArray2 = Nat256.Create64();
    SecT239Field.Square(x, numArray1);
    SecT239Field.Multiply(numArray1, x, numArray1);
    SecT239Field.Square(numArray1, numArray1);
    SecT239Field.Multiply(numArray1, x, numArray1);
    SecT239Field.SquareN(numArray1, 3, numArray2);
    SecT239Field.Multiply(numArray2, numArray1, numArray2);
    SecT239Field.Square(numArray2, numArray2);
    SecT239Field.Multiply(numArray2, x, numArray2);
    SecT239Field.SquareN(numArray2, 7, numArray1);
    SecT239Field.Multiply(numArray1, numArray2, numArray1);
    SecT239Field.SquareN(numArray1, 14, numArray2);
    SecT239Field.Multiply(numArray2, numArray1, numArray2);
    SecT239Field.Square(numArray2, numArray2);
    SecT239Field.Multiply(numArray2, x, numArray2);
    SecT239Field.SquareN(numArray2, 29, numArray1);
    SecT239Field.Multiply(numArray1, numArray2, numArray1);
    SecT239Field.Square(numArray1, numArray1);
    SecT239Field.Multiply(numArray1, x, numArray1);
    SecT239Field.SquareN(numArray1, 59, numArray2);
    SecT239Field.Multiply(numArray2, numArray1, numArray2);
    SecT239Field.Square(numArray2, numArray2);
    SecT239Field.Multiply(numArray2, x, numArray2);
    SecT239Field.SquareN(numArray2, 119, numArray1);
    SecT239Field.Multiply(numArray1, numArray2, numArray1);
    SecT239Field.Square(numArray1, z);
  }

  public static void Multiply(ulong[] x, ulong[] y, ulong[] z)
  {
    ulong[] ext64 = Nat256.CreateExt64();
    SecT239Field.ImplMultiply(x, y, ext64);
    SecT239Field.Reduce(ext64, z);
  }

  public static void MultiplyAddToExt(ulong[] x, ulong[] y, ulong[] zz)
  {
    ulong[] ext64 = Nat256.CreateExt64();
    SecT239Field.ImplMultiply(x, y, ext64);
    SecT239Field.AddExt(zz, ext64, zz);
  }

  public static void MultiplyExt(ulong[] x, ulong[] y, ulong[] zz)
  {
    Array.Clear((Array) zz, 0, 8);
    SecT239Field.ImplMultiply(x, y, zz);
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
    ulong num9 = num4 ^ num8 << 17;
    ulong num10 = num5 ^ num8 >> 47;
    ulong num11 = num6 ^ num8 << 47;
    ulong num12 = num7 ^ num8 >> 17;
    ulong num13 = num3 ^ num12 << 17;
    ulong num14 = num9 ^ num12 >> 47;
    ulong num15 = num10 ^ num12 << 47;
    ulong num16 = num11 ^ num12 >> 17;
    ulong num17 = num2 ^ num16 << 17;
    ulong num18 = num13 ^ num16 >> 47;
    ulong num19 = num14 ^ num16 << 47;
    ulong num20 = num15 ^ num16 >> 17;
    ulong num21 = num1 ^ num20 << 17;
    ulong num22 = num17 ^ num20 >> 47;
    ulong num23 = num18 ^ num20 << 47;
    ulong num24 = num19 ^ num20 >> 17;
    ulong num25 = num24 >> 47;
    z[0] = num21 ^ num25;
    z[1] = num22;
    z[2] = num23 ^ num25 << 30;
    z[3] = num24 & 140737488355327UL /*0x7FFFFFFFFFFF*/;
  }

  public static void Reduce17(ulong[] z, int zOff)
  {
    ulong num1 = z[zOff + 3];
    ulong num2 = num1 >> 47;
    z[zOff] ^= num2;
    z[zOff + 2] ^= num2 << 30;
    z[zOff + 3] = num1 & 140737488355327UL /*0x7FFFFFFFFFFF*/;
  }

  public static void Sqrt(ulong[] x, ulong[] z)
  {
    ulong even1;
    ulong num1 = Interleave.Unshuffle(x[0], x[1], out even1);
    ulong even2;
    ulong num2 = Interleave.Unshuffle(x[2], x[3], out even2);
    ulong num3 = num2 >> 49;
    ulong num4 = num1 >> 49 | num2 << 15;
    ulong num5 = num2 ^ num1 << 15;
    ulong[] ext64 = Nat256.CreateExt64();
    int[] numArray = new int[2]{ 39, 120 };
    for (int index1 = 0; index1 < numArray.Length; ++index1)
    {
      int index2 = numArray[index1] >> 6;
      int num6 = numArray[index1] & 63 /*0x3F*/;
      ext64[index2] ^= num1 << num6;
      ext64[index2 + 1] ^= num5 << num6 | num1 >> -num6;
      ext64[index2 + 2] ^= num4 << num6 | num5 >> -num6;
      ext64[index2 + 3] ^= num3 << num6 | num4 >> -num6;
      ext64[index2 + 4] ^= num3 >> -num6;
    }
    SecT239Field.Reduce(ext64, z);
    z[0] ^= even1;
    z[1] ^= even2;
  }

  public static void Square(ulong[] x, ulong[] z)
  {
    ulong[] ext64 = Nat256.CreateExt64();
    SecT239Field.ImplSquare(x, ext64);
    SecT239Field.Reduce(ext64, z);
  }

  public static void SquareAddToExt(ulong[] x, ulong[] zz)
  {
    ulong[] ext64 = Nat256.CreateExt64();
    SecT239Field.ImplSquare(x, ext64);
    SecT239Field.AddExt(zz, ext64, zz);
  }

  public static void SquareExt(ulong[] x, ulong[] zz) => SecT239Field.ImplSquare(x, zz);

  public static void SquareN(ulong[] x, int n, ulong[] z)
  {
    ulong[] ext64 = Nat256.CreateExt64();
    SecT239Field.ImplSquare(x, ext64);
    SecT239Field.Reduce(ext64, z);
    while (--n > 0)
    {
      SecT239Field.ImplSquare(z, ext64);
      SecT239Field.Reduce(ext64, z);
    }
  }

  public static uint Trace(ulong[] x) => (uint) (x[0] ^ x[1] >> 17 ^ x[2] >> 34) & 1U;

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
    zz[0] = num1 ^ num2 << 60;
    zz[1] = num2 >> 4 ^ num3 << 56;
    zz[2] = num3 >> 8 ^ num4 << 52;
    zz[3] = num4 >> 12 ^ num5 << 48 /*0x30*/;
    zz[4] = num5 >> 16 /*0x10*/ ^ num6 << 44;
    zz[5] = num6 >> 20 ^ num7 << 40;
    zz[6] = num7 >> 24 ^ num8 << 36;
    zz[7] = num8 >> 28;
  }

  private static void ImplExpand(ulong[] x, ulong[] z)
  {
    ulong num1 = x[0];
    ulong num2 = x[1];
    ulong num3 = x[2];
    ulong num4 = x[3];
    z[0] = num1 & 1152921504606846975UL /*0x0FFFFFFFFFFFFFFF*/;
    z[1] = (ulong) (((long) (num1 >> 60) ^ (long) num2 << 4) & 1152921504606846975L /*0x0FFFFFFFFFFFFFFF*/);
    z[2] = (ulong) (((long) (num2 >> 56) ^ (long) num3 << 8) & 1152921504606846975L /*0x0FFFFFFFFFFFFFFF*/);
    z[3] = num3 >> 52 ^ num4 << 12;
  }

  private static void ImplMultiply(ulong[] x, ulong[] y, ulong[] zz)
  {
    ulong[] z1 = new ulong[4];
    ulong[] z2 = new ulong[4];
    SecT239Field.ImplExpand(x, z1);
    SecT239Field.ImplExpand(y, z2);
    ulong[] u = new ulong[8];
    SecT239Field.ImplMulwAcc(u, z1[0], z2[0], zz, 0);
    SecT239Field.ImplMulwAcc(u, z1[1], z2[1], zz, 1);
    SecT239Field.ImplMulwAcc(u, z1[2], z2[2], zz, 2);
    SecT239Field.ImplMulwAcc(u, z1[3], z2[3], zz, 3);
    for (int index = 5; index > 0; --index)
      zz[index] ^= zz[index - 1];
    SecT239Field.ImplMulwAcc(u, z1[0] ^ z1[1], z2[0] ^ z2[1], zz, 1);
    SecT239Field.ImplMulwAcc(u, z1[2] ^ z1[3], z2[2] ^ z2[3], zz, 3);
    for (int index = 7; index > 1; --index)
      zz[index] ^= zz[index - 2];
    ulong x1 = z1[0] ^ z1[2];
    ulong x2 = z1[1] ^ z1[3];
    ulong y1 = z2[0] ^ z2[2];
    ulong y2 = z2[1] ^ z2[3];
    SecT239Field.ImplMulwAcc(u, x1 ^ x2, y1 ^ y2, zz, 3);
    ulong[] z3 = new ulong[3];
    SecT239Field.ImplMulwAcc(u, x1, y1, z3, 0);
    SecT239Field.ImplMulwAcc(u, x2, y2, z3, 1);
    ulong num1 = z3[0];
    ulong num2 = z3[1];
    ulong num3 = z3[2];
    zz[2] ^= num1;
    zz[3] ^= num1 ^ num2;
    zz[4] ^= num3 ^ num2;
    zz[5] ^= num3;
    SecT239Field.ImplCompactExt(zz);
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
    ulong num7 = num2 ^ (ulong) (((long) x & 585610922974906400L /*0x0820820820820820*/ & (long) y << 4 >> 63 /*0x3F*/) >>> 5);
    z[zOff] ^= num3 & 1152921504606846975UL /*0x0FFFFFFFFFFFFFFF*/;
    z[zOff + 1] ^= num3 >> 60 ^ num7 << 4;
  }

  private static void ImplSquare(ulong[] x, ulong[] zz) => Interleave.Expand64To128(x, 0, 4, zz, 0);
}
