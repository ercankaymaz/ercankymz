// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Math.Raw.Interleave
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

#nullable disable
namespace Org.BouncyCastle.Math.Raw;

internal static class Interleave
{
  private const ulong M32 = 1431655765 /*0x55555555*/;
  private const ulong M64 = 6148914691236517205 /*0x5555555555555555*/;
  private const ulong M64R = 12297829382473034410 /*0xAAAAAAAAAAAAAAAA*/;

  internal static uint Expand8to16(byte x)
  {
    int num1 = (int) x;
    int num2 = (num1 | num1 << 4) & 3855;
    int num3 = (num2 | num2 << 2) & 13107 /*0x3333*/;
    return (uint) ((num3 | num3 << 1) & 21845 /*0x5555*/);
  }

  internal static uint Expand16to32(ushort x)
  {
    int num1 = (int) x;
    int num2 = (num1 | num1 << 8) & 16711935;
    int num3 = (num2 | num2 << 4) & 252645135;
    int num4 = (num3 | num3 << 2) & 858993459 /*0x33333333*/;
    return (uint) ((num4 | num4 << 1) & 1431655765 /*0x55555555*/);
  }

  internal static ulong Expand32to64(uint x)
  {
    x = Bits.BitPermuteStep(x, 65280U, 8);
    x = Bits.BitPermuteStep(x, 15728880U /*0xF000F0*/, 4);
    x = Bits.BitPermuteStep(x, 202116108U, 2);
    x = Bits.BitPermuteStep(x, 572662306U /*0x22222222*/, 1);
    return (ulong) (((long) (x >> 1) & 1431655765L /*0x55555555*/) << 32 /*0x20*/ | (long) x & 1431655765L /*0x55555555*/);
  }

  internal static void Expand64To128(ulong x, ulong[] z, int zOff)
  {
    x = Bits.BitPermuteStep(x, 4294901760UL, 16 /*0x10*/);
    x = Bits.BitPermuteStep(x, 280375465148160UL /*0xFF000000FF00*/, 8);
    x = Bits.BitPermuteStep(x, 67555025218437360UL /*0xF000F000F000F0*/, 4);
    x = Bits.BitPermuteStep(x, 868082074056920076UL, 2);
    x = Bits.BitPermuteStep(x, 2459565876494606882UL /*0x2222222222222222*/, 1);
    z[zOff] = x & 6148914691236517205UL /*0x5555555555555555*/;
    z[zOff + 1] = x >> 1 & 6148914691236517205UL /*0x5555555555555555*/;
  }

  internal static void Expand64To128(ulong[] xs, int xsOff, int xsLen, ulong[] zs, int zsOff)
  {
    int num = xsLen;
    int zOff = zsOff + (xsLen << 1);
    while (--num >= 0)
    {
      zOff -= 2;
      Interleave.Expand64To128(xs[xsOff + num], zs, zOff);
    }
  }

  internal static ulong Expand64To128Rev(ulong x, out ulong low)
  {
    x = Bits.BitPermuteStep(x, 4294901760UL, 16 /*0x10*/);
    x = Bits.BitPermuteStep(x, 280375465148160UL /*0xFF000000FF00*/, 8);
    x = Bits.BitPermuteStep(x, 67555025218437360UL /*0xF000F000F000F0*/, 4);
    x = Bits.BitPermuteStep(x, 868082074056920076UL, 2);
    x = Bits.BitPermuteStep(x, 2459565876494606882UL /*0x2222222222222222*/, 1);
    low = x & 12297829382473034410UL /*0xAAAAAAAAAAAAAAAA*/;
    return (ulong) ((long) x << 1 & -6148914691236517206L /*0xAAAAAAAAAAAAAAAA*/);
  }

  internal static uint Shuffle(uint x)
  {
    x = Bits.BitPermuteStep(x, 65280U, 8);
    x = Bits.BitPermuteStep(x, 15728880U /*0xF000F0*/, 4);
    x = Bits.BitPermuteStep(x, 202116108U, 2);
    x = Bits.BitPermuteStep(x, 572662306U /*0x22222222*/, 1);
    return x;
  }

  internal static ulong Shuffle(ulong x)
  {
    x = Bits.BitPermuteStep(x, 4294901760UL, 16 /*0x10*/);
    x = Bits.BitPermuteStep(x, 280375465148160UL /*0xFF000000FF00*/, 8);
    x = Bits.BitPermuteStep(x, 67555025218437360UL /*0xF000F000F000F0*/, 4);
    x = Bits.BitPermuteStep(x, 868082074056920076UL, 2);
    x = Bits.BitPermuteStep(x, 2459565876494606882UL /*0x2222222222222222*/, 1);
    return x;
  }

  internal static uint Shuffle2(uint x)
  {
    x = Bits.BitPermuteStep(x, 11141290U, 7);
    x = Bits.BitPermuteStep(x, 52428U /*0xCCCC*/, 14);
    x = Bits.BitPermuteStep(x, 15728880U /*0xF000F0*/, 4);
    x = Bits.BitPermuteStep(x, 65280U, 8);
    return x;
  }

  internal static uint Unshuffle(uint x)
  {
    x = Bits.BitPermuteStep(x, 572662306U /*0x22222222*/, 1);
    x = Bits.BitPermuteStep(x, 202116108U, 2);
    x = Bits.BitPermuteStep(x, 15728880U /*0xF000F0*/, 4);
    x = Bits.BitPermuteStep(x, 65280U, 8);
    return x;
  }

  internal static ulong Unshuffle(ulong x)
  {
    x = Bits.BitPermuteStep(x, 2459565876494606882UL /*0x2222222222222222*/, 1);
    x = Bits.BitPermuteStep(x, 868082074056920076UL, 2);
    x = Bits.BitPermuteStep(x, 67555025218437360UL /*0xF000F000F000F0*/, 4);
    x = Bits.BitPermuteStep(x, 280375465148160UL /*0xFF000000FF00*/, 8);
    x = Bits.BitPermuteStep(x, 4294901760UL, 16 /*0x10*/);
    return x;
  }

  internal static ulong Unshuffle(ulong x, out ulong even)
  {
    ulong num = Interleave.Unshuffle(x);
    even = num & (ulong) uint.MaxValue;
    return num >> 32 /*0x20*/;
  }

  internal static ulong Unshuffle(ulong x0, ulong x1, out ulong even)
  {
    ulong num1 = Interleave.Unshuffle(x0);
    ulong num2 = Interleave.Unshuffle(x1);
    even = (ulong) ((long) num2 << 32 /*0x20*/ | (long) num1 & (long) uint.MaxValue);
    return num1 >> 32 /*0x20*/ | num2 & 18446744069414584320UL;
  }

  internal static uint Unshuffle2(uint x)
  {
    x = Bits.BitPermuteStep(x, 65280U, 8);
    x = Bits.BitPermuteStep(x, 15728880U /*0xF000F0*/, 4);
    x = Bits.BitPermuteStep(x, 52428U /*0xCCCC*/, 14);
    x = Bits.BitPermuteStep(x, 11141290U, 7);
    return x;
  }
}
