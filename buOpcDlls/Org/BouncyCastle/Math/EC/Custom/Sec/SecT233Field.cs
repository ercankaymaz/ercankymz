// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Math.EC.Custom.Sec.SecT233Field
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Math.Raw;
using System;

#nullable disable
namespace Org.BouncyCastle.Math.EC.Custom.Sec;

internal static class SecT233Field
{
  private const ulong M41 = 2199023255551 /*0x01FFFFFFFFFF*/;
  private const ulong M59 = 576460752303423487 /*0x07FFFFFFFFFFFFFF*/;

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

  public static ulong[] FromBigInteger(BigInteger x) => Nat.FromBigInteger64(233, x);

  public static void HalfTrace(ulong[] x, ulong[] z)
  {
    ulong[] ext64 = Nat256.CreateExt64();
    Nat256.Copy64(x, z);
    for (int index = 1; index < 233; index += 2)
    {
      SecT233Field.ImplSquare(z, ext64);
      SecT233Field.Reduce(ext64, z);
      SecT233Field.ImplSquare(z, ext64);
      SecT233Field.Reduce(ext64, z);
      SecT233Field.AddTo(x, z);
    }
  }

  public static void Invert(ulong[] x, ulong[] z)
  {
    if (Nat256.IsZero64(x))
      throw new InvalidOperationException();
    ulong[] numArray1 = Nat256.Create64();
    ulong[] numArray2 = Nat256.Create64();
    SecT233Field.Square(x, numArray1);
    SecT233Field.Multiply(numArray1, x, numArray1);
    SecT233Field.Square(numArray1, numArray1);
    SecT233Field.Multiply(numArray1, x, numArray1);
    SecT233Field.SquareN(numArray1, 3, numArray2);
    SecT233Field.Multiply(numArray2, numArray1, numArray2);
    SecT233Field.Square(numArray2, numArray2);
    SecT233Field.Multiply(numArray2, x, numArray2);
    SecT233Field.SquareN(numArray2, 7, numArray1);
    SecT233Field.Multiply(numArray1, numArray2, numArray1);
    SecT233Field.SquareN(numArray1, 14, numArray2);
    SecT233Field.Multiply(numArray2, numArray1, numArray2);
    SecT233Field.Square(numArray2, numArray2);
    SecT233Field.Multiply(numArray2, x, numArray2);
    SecT233Field.SquareN(numArray2, 29, numArray1);
    SecT233Field.Multiply(numArray1, numArray2, numArray1);
    SecT233Field.SquareN(numArray1, 58, numArray2);
    SecT233Field.Multiply(numArray2, numArray1, numArray2);
    SecT233Field.SquareN(numArray2, 116, numArray1);
    SecT233Field.Multiply(numArray1, numArray2, numArray1);
    SecT233Field.Square(numArray1, z);
  }

  public static void Multiply(ulong[] x, ulong[] y, ulong[] z)
  {
    ulong[] ext64 = Nat256.CreateExt64();
    SecT233Field.ImplMultiply(x, y, ext64);
    SecT233Field.Reduce(ext64, z);
  }

  public static void MultiplyAddToExt(ulong[] x, ulong[] y, ulong[] zz)
  {
    ulong[] ext64 = Nat256.CreateExt64();
    SecT233Field.ImplMultiply(x, y, ext64);
    SecT233Field.AddExt(zz, ext64, zz);
  }

  public static void MultiplyExt(ulong[] x, ulong[] y, ulong[] zz)
  {
    Array.Clear((Array) zz, 0, 8);
    SecT233Field.ImplMultiply(x, y, zz);
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
    ulong num9 = num4 ^ num8 << 23;
    ulong num10 = num5 ^ num8 >> 41 ^ num8 << 33;
    ulong num11 = num6 ^ num8 >> 31 /*0x1F*/;
    ulong num12 = num3 ^ num7 << 23;
    ulong num13 = num9 ^ num7 >> 41 ^ num7 << 33;
    ulong num14 = num10 ^ num7 >> 31 /*0x1F*/;
    ulong num15 = num2 ^ num11 << 23;
    ulong num16 = num12 ^ num11 >> 41 ^ num11 << 33;
    ulong num17 = num13 ^ num11 >> 31 /*0x1F*/;
    ulong num18 = num1 ^ num14 << 23;
    ulong num19 = num15 ^ num14 >> 41 ^ num14 << 33;
    ulong num20 = num16 ^ num14 >> 31 /*0x1F*/;
    ulong num21 = num17 >> 41;
    z[0] = num18 ^ num21;
    z[1] = num19 ^ num21 << 10;
    z[2] = num20;
    z[3] = num17 & 2199023255551UL /*0x01FFFFFFFFFF*/;
  }

  public static void Reduce23(ulong[] z, int zOff)
  {
    ulong num1 = z[zOff + 3];
    ulong num2 = num1 >> 41;
    z[zOff] ^= num2;
    z[zOff + 1] ^= num2 << 10;
    z[zOff + 3] = num1 & 2199023255551UL /*0x01FFFFFFFFFF*/;
  }

  public static void Sqrt(ulong[] x, ulong[] z)
  {
    ulong even1;
    ulong num1 = Interleave.Unshuffle(x[0], x[1], out even1);
    ulong even2;
    ulong num2 = Interleave.Unshuffle(x[2], x[3], out even2);
    ulong num3 = num2 >> 27;
    ulong num4 = num2 ^ (num1 >> 27 | num2 << 37);
    ulong num5 = num1 ^ num1 << 37;
    ulong[] ext64 = Nat256.CreateExt64();
    int[] numArray = new int[3]{ 32 /*0x20*/, 117, 191 };
    for (int index1 = 0; index1 < numArray.Length; ++index1)
    {
      int index2 = numArray[index1] >> 6;
      int num6 = numArray[index1] & 63 /*0x3F*/;
      ext64[index2] ^= num5 << num6;
      ext64[index2 + 1] ^= num4 << num6 | num5 >> -num6;
      ext64[index2 + 2] ^= num3 << num6 | num4 >> -num6;
      ext64[index2 + 3] ^= num3 >> -num6;
    }
    SecT233Field.Reduce(ext64, z);
    z[0] ^= even1;
    z[1] ^= even2;
  }

  public static void Square(ulong[] x, ulong[] z)
  {
    ulong[] ext64 = Nat256.CreateExt64();
    SecT233Field.ImplSquare(x, ext64);
    SecT233Field.Reduce(ext64, z);
  }

  public static void SquareAddToExt(ulong[] x, ulong[] zz)
  {
    ulong[] ext64 = Nat256.CreateExt64();
    SecT233Field.ImplSquare(x, ext64);
    SecT233Field.AddExt(zz, ext64, zz);
  }

  public static void SquareExt(ulong[] x, ulong[] zz) => SecT233Field.ImplSquare(x, zz);

  public static void SquareN(ulong[] x, int n, ulong[] z)
  {
    ulong[] ext64 = Nat256.CreateExt64();
    SecT233Field.ImplSquare(x, ext64);
    SecT233Field.Reduce(ext64, z);
    while (--n > 0)
    {
      SecT233Field.ImplSquare(z, ext64);
      SecT233Field.Reduce(ext64, z);
    }
  }

  public static uint Trace(ulong[] x) => (uint) (x[0] ^ x[2] >> 31 /*0x1F*/) & 1U;

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
    zz[0] = num1 ^ num2 << 59;
    zz[1] = num2 >> 5 ^ num3 << 54;
    zz[2] = num3 >> 10 ^ num4 << 49;
    zz[3] = num4 >> 15 ^ num5 << 44;
    zz[4] = num5 >> 20 ^ num6 << 39;
    zz[5] = num6 >> 25 ^ num7 << 34;
    zz[6] = num7 >> 30 ^ num8 << 29;
    zz[7] = num8 >> 35;
  }

  private static void ImplExpand(ulong[] x, ulong[] z)
  {
    ulong num1 = x[0];
    ulong num2 = x[1];
    ulong num3 = x[2];
    ulong num4 = x[3];
    z[0] = num1 & 576460752303423487UL /*0x07FFFFFFFFFFFFFF*/;
    z[1] = (ulong) (((long) (num1 >> 59) ^ (long) num2 << 5) & 576460752303423487L /*0x07FFFFFFFFFFFFFF*/);
    z[2] = (ulong) (((long) (num2 >> 54) ^ (long) num3 << 10) & 576460752303423487L /*0x07FFFFFFFFFFFFFF*/);
    z[3] = num3 >> 49 ^ num4 << 15;
  }

  private static void ImplMultiply(ulong[] x, ulong[] y, ulong[] zz)
  {
    ulong[] z1 = new ulong[4];
    ulong[] z2 = new ulong[4];
    SecT233Field.ImplExpand(x, z1);
    SecT233Field.ImplExpand(y, z2);
    ulong[] u = new ulong[8];
    SecT233Field.ImplMulwAcc(u, z1[0], z2[0], zz, 0);
    SecT233Field.ImplMulwAcc(u, z1[1], z2[1], zz, 1);
    SecT233Field.ImplMulwAcc(u, z1[2], z2[2], zz, 2);
    SecT233Field.ImplMulwAcc(u, z1[3], z2[3], zz, 3);
    for (int index = 5; index > 0; --index)
      zz[index] ^= zz[index - 1];
    SecT233Field.ImplMulwAcc(u, z1[0] ^ z1[1], z2[0] ^ z2[1], zz, 1);
    SecT233Field.ImplMulwAcc(u, z1[2] ^ z1[3], z2[2] ^ z2[3], zz, 3);
    for (int index = 7; index > 1; --index)
      zz[index] ^= zz[index - 2];
    ulong x1 = z1[0] ^ z1[2];
    ulong x2 = z1[1] ^ z1[3];
    ulong y1 = z2[0] ^ z2[2];
    ulong y2 = z2[1] ^ z2[3];
    SecT233Field.ImplMulwAcc(u, x1 ^ x2, y1 ^ y2, zz, 3);
    ulong[] z3 = new ulong[3];
    SecT233Field.ImplMulwAcc(u, x1, y1, z3, 0);
    SecT233Field.ImplMulwAcc(u, x2, y2, z3, 1);
    ulong num1 = z3[0];
    ulong num2 = z3[1];
    ulong num3 = z3[2];
    zz[2] ^= num1;
    zz[3] ^= num1 ^ num2;
    zz[4] ^= num3 ^ num2;
    zz[5] ^= num3;
    SecT233Field.ImplCompactExt(zz);
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

  private static void ImplSquare(ulong[] x, ulong[] zz) => Interleave.Expand64To128(x, 0, 4, zz, 0);
}
