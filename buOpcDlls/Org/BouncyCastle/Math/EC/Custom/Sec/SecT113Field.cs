// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Math.EC.Custom.Sec.SecT113Field
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Math.Raw;
using System;

#nullable disable
namespace Org.BouncyCastle.Math.EC.Custom.Sec;

internal static class SecT113Field
{
  private const ulong M49 = 562949953421311 /*0x01FFFFFFFFFFFF*/;
  private const ulong M57 = 144115188075855871 /*0x01FFFFFFFFFFFFFF*/;

  public static void Add(ulong[] x, ulong[] y, ulong[] z)
  {
    z[0] = x[0] ^ y[0];
    z[1] = x[1] ^ y[1];
  }

  public static void AddBothTo(ulong[] x, ulong[] y, ulong[] z)
  {
    z[0] ^= x[0] ^ y[0];
    z[1] ^= x[1] ^ y[1];
  }

  public static void AddExt(ulong[] xx, ulong[] yy, ulong[] zz)
  {
    zz[0] = xx[0] ^ yy[0];
    zz[1] = xx[1] ^ yy[1];
    zz[2] = xx[2] ^ yy[2];
    zz[3] = xx[3] ^ yy[3];
  }

  public static void AddOne(ulong[] x, ulong[] z)
  {
    z[0] = x[0] ^ 1UL;
    z[1] = x[1];
  }

  public static void AddTo(ulong[] x, ulong[] z)
  {
    z[0] ^= x[0];
    z[1] ^= x[1];
  }

  public static ulong[] FromBigInteger(BigInteger x) => Nat.FromBigInteger64(113, x);

  public static void HalfTrace(ulong[] x, ulong[] z)
  {
    ulong[] ext64 = Nat128.CreateExt64();
    Nat128.Copy64(x, z);
    for (int index = 1; index < 113; index += 2)
    {
      SecT113Field.ImplSquare(z, ext64);
      SecT113Field.Reduce(ext64, z);
      SecT113Field.ImplSquare(z, ext64);
      SecT113Field.Reduce(ext64, z);
      SecT113Field.AddTo(x, z);
    }
  }

  public static void Invert(ulong[] x, ulong[] z)
  {
    if (Nat128.IsZero64(x))
      throw new InvalidOperationException();
    ulong[] numArray1 = Nat128.Create64();
    ulong[] numArray2 = Nat128.Create64();
    SecT113Field.Square(x, numArray1);
    SecT113Field.Multiply(numArray1, x, numArray1);
    SecT113Field.Square(numArray1, numArray1);
    SecT113Field.Multiply(numArray1, x, numArray1);
    SecT113Field.SquareN(numArray1, 3, numArray2);
    SecT113Field.Multiply(numArray2, numArray1, numArray2);
    SecT113Field.Square(numArray2, numArray2);
    SecT113Field.Multiply(numArray2, x, numArray2);
    SecT113Field.SquareN(numArray2, 7, numArray1);
    SecT113Field.Multiply(numArray1, numArray2, numArray1);
    SecT113Field.SquareN(numArray1, 14, numArray2);
    SecT113Field.Multiply(numArray2, numArray1, numArray2);
    SecT113Field.SquareN(numArray2, 28, numArray1);
    SecT113Field.Multiply(numArray1, numArray2, numArray1);
    SecT113Field.SquareN(numArray1, 56, numArray2);
    SecT113Field.Multiply(numArray2, numArray1, numArray2);
    SecT113Field.Square(numArray2, z);
  }

  public static void Multiply(ulong[] x, ulong[] y, ulong[] z)
  {
    ulong[] numArray = new ulong[8];
    SecT113Field.ImplMultiply(x, y, numArray);
    SecT113Field.Reduce(numArray, z);
  }

  public static void MultiplyAddToExt(ulong[] x, ulong[] y, ulong[] zz)
  {
    ulong[] numArray = new ulong[8];
    SecT113Field.ImplMultiply(x, y, numArray);
    SecT113Field.AddExt(zz, numArray, zz);
  }

  public static void MultiplyExt(ulong[] x, ulong[] y, ulong[] zz)
  {
    SecT113Field.ImplMultiply(x, y, zz);
  }

  public static void Reduce(ulong[] xx, ulong[] z)
  {
    ulong num1 = xx[0];
    ulong num2 = xx[1];
    ulong num3 = xx[2];
    ulong num4 = xx[3];
    ulong num5 = num2 ^ (ulong) ((long) num4 << 15 ^ (long) num4 << 24);
    ulong num6 = num3 ^ num4 >> 49 ^ num4 >> 40;
    ulong num7 = num1 ^ (ulong) ((long) num6 << 15 ^ (long) num6 << 24);
    ulong num8 = num5 ^ num6 >> 49 ^ num6 >> 40;
    ulong num9 = num8 >> 49;
    z[0] = (ulong) ((long) num7 ^ (long) num9 ^ (long) num9 << 9);
    z[1] = num8 & 562949953421311UL /*0x01FFFFFFFFFFFF*/;
  }

  public static void Reduce15(ulong[] z, int zOff)
  {
    ulong num1 = z[zOff + 1];
    ulong num2 = num1 >> 49;
    z[zOff] ^= num2 ^ num2 << 9;
    z[zOff + 1] = num1 & 562949953421311UL /*0x01FFFFFFFFFFFF*/;
  }

  public static void Sqrt(ulong[] x, ulong[] z)
  {
    ulong even;
    ulong num = Interleave.Unshuffle(x[0], x[1], out even);
    z[0] = (ulong) ((long) even ^ (long) num << 57 ^ (long) num << 5);
    z[1] = num >> 7 ^ num >> 59;
  }

  public static void Square(ulong[] x, ulong[] z)
  {
    ulong[] ext64 = Nat128.CreateExt64();
    SecT113Field.ImplSquare(x, ext64);
    SecT113Field.Reduce(ext64, z);
  }

  public static void SquareAddToExt(ulong[] x, ulong[] zz)
  {
    ulong[] ext64 = Nat128.CreateExt64();
    SecT113Field.ImplSquare(x, ext64);
    SecT113Field.AddExt(zz, ext64, zz);
  }

  public static void SquareExt(ulong[] x, ulong[] zz) => SecT113Field.ImplSquare(x, zz);

  public static void SquareN(ulong[] x, int n, ulong[] z)
  {
    ulong[] ext64 = Nat128.CreateExt64();
    SecT113Field.ImplSquare(x, ext64);
    SecT113Field.Reduce(ext64, z);
    while (--n > 0)
    {
      SecT113Field.ImplSquare(z, ext64);
      SecT113Field.Reduce(ext64, z);
    }
  }

  public static uint Trace(ulong[] x) => (uint) x[0] & 1U;

  private static void ImplMultiply(ulong[] x, ulong[] y, ulong[] zz)
  {
    ulong num1 = x[0];
    ulong num2 = x[1];
    ulong x1 = (ulong) (((long) (num1 >> 57) ^ (long) num2 << 7) & 144115188075855871L /*0x01FFFFFFFFFFFFFF*/);
    ulong x2 = num1 & 144115188075855871UL /*0x01FFFFFFFFFFFFFF*/;
    ulong num3 = y[0];
    ulong num4 = y[1];
    ulong y1 = (ulong) (((long) (num3 >> 57) ^ (long) num4 << 7) & 144115188075855871L /*0x01FFFFFFFFFFFFFF*/);
    ulong y2 = num3 & 144115188075855871UL /*0x01FFFFFFFFFFFFFF*/;
    ulong[] u = zz;
    ulong[] z = new ulong[6];
    SecT113Field.ImplMulw(u, x2, y2, z, 0);
    SecT113Field.ImplMulw(u, x1, y1, z, 2);
    SecT113Field.ImplMulw(u, x2 ^ x1, y2 ^ y1, z, 4);
    ulong num5 = z[1] ^ z[2];
    ulong num6 = z[0];
    ulong num7 = z[3];
    ulong num8 = z[4] ^ num6 ^ num5;
    ulong num9 = z[5] ^ num7 ^ num5;
    zz[0] = num6 ^ num8 << 57;
    zz[1] = num8 >> 7 ^ num9 << 50;
    zz[2] = num9 >> 14 ^ num7 << 43;
    zz[3] = num7 >> 21;
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

  private static void ImplSquare(ulong[] x, ulong[] zz) => Interleave.Expand64To128(x, 0, 2, zz, 0);
}
