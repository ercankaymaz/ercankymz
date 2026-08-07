// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Pqc.Crypto.Cmce.Utils
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto.Utilities;

#nullable disable
namespace Org.BouncyCastle.Pqc.Crypto.Cmce;

internal class Utils
{
  internal static void StoreGF(byte[] dest, int offset, ushort a)
  {
    Pack.UInt16_To_LE(a, dest, offset);
  }

  internal static ushort LoadGF(byte[] src, int offset, int gfmask)
  {
    return (ushort) ((uint) Pack.LE_To_UInt16(src, offset) & (uint) gfmask);
  }

  internal static uint Load4(byte[] input, int offset) => Pack.LE_To_UInt32(input, offset);

  internal static void Store8(byte[] output, int offset, ulong input)
  {
    Pack.UInt64_To_LE(input, output, offset);
  }

  internal static void Store8(byte[] output, int offset, ulong[] input, int inOff, int inLen)
  {
    Pack.UInt64_To_LE(input, inOff, inLen, output, offset);
  }

  internal static ulong Load8(byte[] input, int offset) => Pack.LE_To_UInt64(input, offset);

  internal static void Load8(byte[] input, int offset, ulong[] output, int outOff, int outLen)
  {
    Pack.LE_To_UInt64(input, offset, output, outOff, outLen);
  }

  internal static ushort Bitrev(ushort a, int GFBITS)
  {
    a = (ushort) (((int) a & (int) byte.MaxValue) << 8 | ((int) a & 65280) >> 8);
    a = (ushort) (((int) a & 3855) << 4 | ((int) a & 61680) >> 4);
    a = (ushort) (((int) a & 13107 /*0x3333*/) << 2 | ((int) a & 52428 /*0xCCCC*/) >> 2);
    a = (ushort) (((int) a & 21845 /*0x5555*/) << 1 | ((int) a & 43690 /*0xAAAA*/) >> 1);
    return (ushort) ((uint) a >> 16 /*0x10*/ - GFBITS);
  }
}
