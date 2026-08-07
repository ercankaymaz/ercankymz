// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Utilities.Longs
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Math.Raw;
using System;

#nullable disable
namespace Org.BouncyCastle.Utilities;

public static class Longs
{
  public const int NumBits = 64 /*0x40*/;
  public const int NumBytes = 8;
  private static readonly byte[] DeBruijnTZ = new byte[64 /*0x40*/]
  {
    (byte) 63 /*0x3F*/,
    (byte) 0,
    (byte) 1,
    (byte) 52,
    (byte) 2,
    (byte) 6,
    (byte) 53,
    (byte) 26,
    (byte) 3,
    (byte) 37,
    (byte) 40,
    (byte) 7,
    (byte) 33,
    (byte) 54,
    (byte) 47,
    (byte) 27,
    (byte) 61,
    (byte) 4,
    (byte) 38,
    (byte) 45,
    (byte) 43,
    (byte) 41,
    (byte) 21,
    (byte) 8,
    (byte) 23,
    (byte) 34,
    (byte) 58,
    (byte) 55,
    (byte) 48 /*0x30*/,
    (byte) 17,
    (byte) 28,
    (byte) 10,
    (byte) 62,
    (byte) 51,
    (byte) 5,
    (byte) 25,
    (byte) 36,
    (byte) 39,
    (byte) 32 /*0x20*/,
    (byte) 46,
    (byte) 60,
    (byte) 44,
    (byte) 42,
    (byte) 20,
    (byte) 22,
    (byte) 57,
    (byte) 16 /*0x10*/,
    (byte) 9,
    (byte) 50,
    (byte) 24,
    (byte) 35,
    (byte) 31 /*0x1F*/,
    (byte) 59,
    (byte) 19,
    (byte) 56,
    (byte) 15,
    (byte) 49,
    (byte) 30,
    (byte) 18,
    (byte) 14,
    (byte) 29,
    (byte) 13,
    (byte) 12,
    (byte) 11
  };

  public static long HighestOneBit(long i) => (long) Longs.HighestOneBit((ulong) i);

  [CLSCompliant(false)]
  public static ulong HighestOneBit(ulong i)
  {
    i |= i >> 1;
    i |= i >> 2;
    i |= i >> 4;
    i |= i >> 8;
    i |= i >> 16 /*0x10*/;
    i |= i >> 32 /*0x20*/;
    return i - (i >> 1);
  }

  public static long LowestOneBit(long i) => i & -i;

  [CLSCompliant(false)]
  public static ulong LowestOneBit(ulong i) => (ulong) Longs.LowestOneBit((long) i);

  public static int NumberOfLeadingZeros(long i)
  {
    int i1 = (int) (i >> 32 /*0x20*/);
    int num = 0;
    if (i1 == 0)
    {
      num = 32 /*0x20*/;
      i1 = (int) i;
    }
    return num + Integers.NumberOfLeadingZeros(i1);
  }

  public static int NumberOfTrailingZeros(long i)
  {
    return (int) Longs.DeBruijnTZ[(int) (uint) ((i & -i) * 315175865370177754L >>> 58)] - (int) ((i & (long) uint.MaxValue | i >>> 32 /*0x20*/) - 1L >> 63 /*0x3F*/);
  }

  public static long Reverse(long i) => (long) Longs.Reverse((ulong) i);

  [CLSCompliant(false)]
  public static ulong Reverse(ulong i)
  {
    i = Bits.BitPermuteStepSimple(i, 6148914691236517205UL /*0x5555555555555555*/, 1);
    i = Bits.BitPermuteStepSimple(i, 3689348814741910323UL /*0x3333333333333333*/, 2);
    i = Bits.BitPermuteStepSimple(i, 1085102592571150095UL, 4);
    return Longs.ReverseBytes(i);
  }

  public static long ReverseBytes(long i) => (long) Longs.ReverseBytes((ulong) i);

  [CLSCompliant(false)]
  public static ulong ReverseBytes(ulong i)
  {
    return Longs.RotateLeft(i & 18374686483949813760UL /*0xFF000000FF000000*/, 8) | Longs.RotateLeft(i & 71776119077928960UL /*0xFF000000FF0000*/, 24) | Longs.RotateLeft(i & 280375465148160UL /*0xFF000000FF00*/, 40) | Longs.RotateLeft(i & 1095216660735UL /*0xFF000000FF*/, 56);
  }

  public static long RotateLeft(long i, int distance) => i << distance | i >>> -distance;

  [CLSCompliant(false)]
  public static ulong RotateLeft(ulong i, int distance) => i << distance | i >> -distance;

  public static long RotateRight(long i, int distance) => i >>> distance | i << -distance;

  [CLSCompliant(false)]
  public static ulong RotateRight(ulong i, int distance) => i >> distance | i << -distance;
}
