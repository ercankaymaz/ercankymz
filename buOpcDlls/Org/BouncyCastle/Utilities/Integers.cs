// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Utilities.Integers
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Math.Raw;
using System;

#nullable disable
namespace Org.BouncyCastle.Utilities;

public static class Integers
{
  public const int NumBits = 32 /*0x20*/;
  public const int NumBytes = 4;
  private static readonly byte[] DeBruijnTZ = new byte[32 /*0x20*/]
  {
    (byte) 31 /*0x1F*/,
    (byte) 0,
    (byte) 27,
    (byte) 1,
    (byte) 28,
    (byte) 13,
    (byte) 23,
    (byte) 2,
    (byte) 29,
    (byte) 21,
    (byte) 19,
    (byte) 14,
    (byte) 24,
    (byte) 16 /*0x10*/,
    (byte) 3,
    (byte) 7,
    (byte) 30,
    (byte) 26,
    (byte) 12,
    (byte) 22,
    (byte) 20,
    (byte) 18,
    (byte) 15,
    (byte) 6,
    (byte) 25,
    (byte) 11,
    (byte) 17,
    (byte) 5,
    (byte) 10,
    (byte) 4,
    (byte) 9,
    (byte) 8
  };

  public static int HighestOneBit(int i) => (int) Integers.HighestOneBit((uint) i);

  [CLSCompliant(false)]
  public static uint HighestOneBit(uint i)
  {
    i |= i >> 1;
    i |= i >> 2;
    i |= i >> 4;
    i |= i >> 8;
    i |= i >> 16 /*0x10*/;
    return i - (i >> 1);
  }

  public static int LowestOneBit(int i) => i & -i;

  [CLSCompliant(false)]
  public static uint LowestOneBit(uint i) => (uint) Integers.LowestOneBit((int) i);

  public static int NumberOfLeadingZeros(int i)
  {
    if (i <= 0)
      return ~i >> 26 & 32 /*0x20*/;
    uint num1 = (uint) i;
    int num2 = 1;
    if (num1 >> 16 /*0x10*/ == 0U)
    {
      num2 += 16 /*0x10*/;
      num1 <<= 16 /*0x10*/;
    }
    if (num1 >> 24 == 0U)
    {
      num2 += 8;
      num1 <<= 8;
    }
    if (num1 >> 28 == 0U)
    {
      num2 += 4;
      num1 <<= 4;
    }
    if (num1 >> 30 == 0U)
    {
      num2 += 2;
      num1 <<= 2;
    }
    return num2 - (int) (num1 >> 31 /*0x1F*/);
  }

  public static int NumberOfTrailingZeros(int i)
  {
    return (int) Integers.DeBruijnTZ[(i & -i) * 251226722 >>> 27] - ((i & (int) ushort.MaxValue | i >>> 16 /*0x10*/) - 1 >> 31 /*0x1F*/);
  }

  public static int PopCount(int i) => Integers.PopCount((uint) i);

  [CLSCompliant(false)]
  public static int PopCount(uint u)
  {
    u -= u >> 1 & 1431655765U /*0x55555555*/;
    u = (uint) (((int) u & 858993459 /*0x33333333*/) + ((int) (u >> 2) & 858993459 /*0x33333333*/));
    u = (uint) ((int) u + (int) (u >> 4) & 252645135);
    u += u >> 8;
    u += u >> 16 /*0x10*/;
    u &= 63U /*0x3F*/;
    return (int) u;
  }

  public static int Reverse(int i) => (int) Integers.Reverse((uint) i);

  [CLSCompliant(false)]
  public static uint Reverse(uint i)
  {
    i = Bits.BitPermuteStepSimple(i, 1431655765U /*0x55555555*/, 1);
    i = Bits.BitPermuteStepSimple(i, 858993459U /*0x33333333*/, 2);
    i = Bits.BitPermuteStepSimple(i, 252645135U, 4);
    return Integers.ReverseBytes(i);
  }

  public static int ReverseBytes(int i) => (int) Integers.ReverseBytes((uint) i);

  [CLSCompliant(false)]
  public static uint ReverseBytes(uint i)
  {
    return Integers.RotateLeft(i & 4278255360U /*0xFF00FF00*/, 8) | Integers.RotateLeft(i & 16711935U, 24);
  }

  public static int RotateLeft(int i, int distance) => i << distance | i >>> -distance;

  [CLSCompliant(false)]
  public static uint RotateLeft(uint i, int distance) => i << distance | i >> -distance;

  public static int RotateRight(int i, int distance) => i >>> distance | i << -distance;

  [CLSCompliant(false)]
  public static uint RotateRight(uint i, int distance) => i >> distance | i << -distance;
}
