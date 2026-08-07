// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Utilities.Pack
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;

#nullable disable
namespace Org.BouncyCastle.Crypto.Utilities;

internal static class Pack
{
  internal static void UInt16_To_BE(ushort n, byte[] bs)
  {
    bs[0] = (byte) ((uint) n >> 8);
    bs[1] = (byte) n;
  }

  internal static void UInt16_To_BE(ushort n, byte[] bs, int off)
  {
    bs[off] = (byte) ((uint) n >> 8);
    bs[off + 1] = (byte) n;
  }

  internal static void UInt16_To_BE(ushort[] ns, byte[] bs, int off)
  {
    for (int index = 0; index < ns.Length; ++index)
    {
      Pack.UInt16_To_BE(ns[index], bs, off);
      off += 2;
    }
  }

  internal static void UInt16_To_BE(ushort[] ns, int nsOff, int nsLen, byte[] bs, int bsOff)
  {
    for (int index = 0; index < nsLen; ++index)
    {
      Pack.UInt16_To_BE(ns[nsOff + index], bs, bsOff);
      bsOff += 2;
    }
  }

  internal static byte[] UInt16_To_BE(ushort n)
  {
    byte[] bs = new byte[2];
    Pack.UInt16_To_BE(n, bs, 0);
    return bs;
  }

  internal static byte[] UInt16_To_BE(ushort[] ns) => Pack.UInt16_To_BE(ns, 0, ns.Length);

  internal static byte[] UInt16_To_BE(ushort[] ns, int nsOff, int nsLen)
  {
    byte[] bs = new byte[2 * nsLen];
    Pack.UInt16_To_BE(ns, nsOff, nsLen, bs, 0);
    return bs;
  }

  internal static ushort BE_To_UInt16(byte[] bs, int off)
  {
    return (ushort) ((uint) bs[off] << 8 | (uint) bs[off + 1]);
  }

  internal static void BE_To_UInt16(byte[] bs, int bsOff, ushort[] ns, int nsOff)
  {
    ns[nsOff] = Pack.BE_To_UInt16(bs, bsOff);
  }

  internal static ushort[] BE_To_UInt16(byte[] bs) => Pack.BE_To_UInt16(bs, 0, bs.Length);

  internal static ushort[] BE_To_UInt16(byte[] bs, int off, int len)
  {
    ushort[] ns = (len & 1) == 0 ? new ushort[len / 2] : throw new ArgumentException("must be a multiple of 2", nameof (len));
    for (int index = 0; index < len; index += 2)
      Pack.BE_To_UInt16(bs, off + index, ns, index >> 1);
    return ns;
  }

  internal static void UInt24_To_BE(uint n, byte[] bs)
  {
    bs[0] = (byte) (n >> 16 /*0x10*/);
    bs[1] = (byte) (n >> 8);
    bs[2] = (byte) n;
  }

  internal static void UInt24_To_BE(uint n, byte[] bs, int off)
  {
    bs[off] = (byte) (n >> 16 /*0x10*/);
    bs[off + 1] = (byte) (n >> 8);
    bs[off + 2] = (byte) n;
  }

  internal static uint BE_To_UInt24(byte[] bs)
  {
    return (uint) ((int) bs[0] << 16 /*0x10*/ | (int) bs[1] << 8) | (uint) bs[2];
  }

  internal static uint BE_To_UInt24(byte[] bs, int off)
  {
    return (uint) ((int) bs[off] << 16 /*0x10*/ | (int) bs[off + 1] << 8) | (uint) bs[off + 2];
  }

  internal static void UInt32_To_BE(uint n, byte[] bs)
  {
    bs[0] = (byte) (n >> 24);
    bs[1] = (byte) (n >> 16 /*0x10*/);
    bs[2] = (byte) (n >> 8);
    bs[3] = (byte) n;
  }

  internal static void UInt32_To_BE(uint n, byte[] bs, int off)
  {
    bs[off] = (byte) (n >> 24);
    bs[off + 1] = (byte) (n >> 16 /*0x10*/);
    bs[off + 2] = (byte) (n >> 8);
    bs[off + 3] = (byte) n;
  }

  internal static void UInt32_To_BE_High(uint n, byte[] bs, int off, int len)
  {
    int num = 24;
    bs[off] = (byte) (n >> 24);
    for (int index = 1; index < len; ++index)
    {
      num -= 8;
      bs[off + index] = (byte) (n >> num);
    }
  }

  internal static void UInt32_To_BE_Low(uint n, byte[] bs, int off, int len)
  {
    Pack.UInt32_To_BE_High(n << (4 - len << 3), bs, off, len);
  }

  internal static void UInt32_To_BE(uint[] ns, byte[] bs, int off)
  {
    for (int index = 0; index < ns.Length; ++index)
    {
      Pack.UInt32_To_BE(ns[index], bs, off);
      off += 4;
    }
  }

  internal static void UInt32_To_BE(uint[] ns, int nsOff, int nsLen, byte[] bs, int bsOff)
  {
    for (int index = 0; index < nsLen; ++index)
    {
      Pack.UInt32_To_BE(ns[nsOff + index], bs, bsOff);
      bsOff += 4;
    }
  }

  internal static byte[] UInt32_To_BE(uint n)
  {
    byte[] bs = new byte[4];
    Pack.UInt32_To_BE(n, bs, 0);
    return bs;
  }

  internal static byte[] UInt32_To_BE(uint[] ns)
  {
    byte[] bs = new byte[4 * ns.Length];
    Pack.UInt32_To_BE(ns, bs, 0);
    return bs;
  }

  internal static uint BE_To_UInt32(byte[] bs)
  {
    return (uint) ((int) bs[0] << 24 | (int) bs[1] << 16 /*0x10*/ | (int) bs[2] << 8) | (uint) bs[3];
  }

  internal static uint BE_To_UInt32(byte[] bs, int off)
  {
    return (uint) ((int) bs[off] << 24 | (int) bs[off + 1] << 16 /*0x10*/ | (int) bs[off + 2] << 8) | (uint) bs[off + 3];
  }

  internal static uint BE_To_UInt32_High(byte[] bs, int off, int len)
  {
    return Pack.BE_To_UInt32_Low(bs, off, len) << (4 - len << 3);
  }

  internal static uint BE_To_UInt32_Low(byte[] bs, int off, int len)
  {
    uint uint32Low = (uint) bs[off];
    for (int index = 1; index < len; ++index)
      uint32Low = uint32Low << 8 | (uint) bs[off + index];
    return uint32Low;
  }

  internal static void BE_To_UInt32(byte[] bs, int off, uint[] ns)
  {
    for (int index = 0; index < ns.Length; ++index)
    {
      ns[index] = Pack.BE_To_UInt32(bs, off);
      off += 4;
    }
  }

  internal static void BE_To_UInt32(byte[] bs, int bsOff, uint[] ns, int nsOff, int nsLen)
  {
    for (int index = 0; index < nsLen; ++index)
    {
      ns[nsOff + index] = Pack.BE_To_UInt32(bs, bsOff);
      bsOff += 4;
    }
  }

  internal static byte[] UInt64_To_BE(ulong n)
  {
    byte[] bs = new byte[8];
    Pack.UInt64_To_BE(n, bs, 0);
    return bs;
  }

  internal static void UInt64_To_BE(ulong n, byte[] bs)
  {
    Pack.UInt32_To_BE((uint) (n >> 32 /*0x20*/), bs);
    Pack.UInt32_To_BE((uint) n, bs, 4);
  }

  internal static void UInt64_To_BE(ulong n, byte[] bs, int off)
  {
    Pack.UInt32_To_BE((uint) (n >> 32 /*0x20*/), bs, off);
    Pack.UInt32_To_BE((uint) n, bs, off + 4);
  }

  internal static void UInt64_To_BE_High(ulong n, byte[] bs, int off, int len)
  {
    int num = 56;
    bs[off] = (byte) (n >> 56);
    for (int index = 1; index < len; ++index)
    {
      num -= 8;
      bs[off + index] = (byte) (n >> num);
    }
  }

  internal static void UInt64_To_BE_Low(ulong n, byte[] bs, int off, int len)
  {
    Pack.UInt64_To_BE_High(n << (8 - len << 3), bs, off, len);
  }

  internal static byte[] UInt64_To_BE(ulong[] ns)
  {
    byte[] bs = new byte[8 * ns.Length];
    Pack.UInt64_To_BE(ns, bs, 0);
    return bs;
  }

  internal static void UInt64_To_BE(ulong[] ns, byte[] bs, int off)
  {
    for (int index = 0; index < ns.Length; ++index)
    {
      Pack.UInt64_To_BE(ns[index], bs, off);
      off += 8;
    }
  }

  internal static void UInt64_To_BE(ulong[] ns, int nsOff, int nsLen, byte[] bs, int bsOff)
  {
    for (int index = 0; index < nsLen; ++index)
    {
      Pack.UInt64_To_BE(ns[nsOff + index], bs, bsOff);
      bsOff += 8;
    }
  }

  internal static ulong BE_To_UInt64(byte[] bs)
  {
    return (ulong) Pack.BE_To_UInt32(bs) << 32 /*0x20*/ | (ulong) Pack.BE_To_UInt32(bs, 4);
  }

  internal static ulong BE_To_UInt64(byte[] bs, int off)
  {
    return (ulong) Pack.BE_To_UInt32(bs, off) << 32 /*0x20*/ | (ulong) Pack.BE_To_UInt32(bs, off + 4);
  }

  internal static ulong BE_To_UInt64_High(byte[] bs, int off, int len)
  {
    return Pack.BE_To_UInt64_Low(bs, off, len) << (8 - len << 3);
  }

  internal static ulong BE_To_UInt64_Low(byte[] bs, int off, int len)
  {
    ulong uint64Low = (ulong) bs[off];
    for (int index = 1; index < len; ++index)
      uint64Low = uint64Low << 8 | (ulong) bs[off + index];
    return uint64Low;
  }

  internal static void BE_To_UInt64(byte[] bs, int off, ulong[] ns)
  {
    for (int index = 0; index < ns.Length; ++index)
    {
      ns[index] = Pack.BE_To_UInt64(bs, off);
      off += 8;
    }
  }

  internal static void BE_To_UInt64(byte[] bs, int bsOff, ulong[] ns, int nsOff, int nsLen)
  {
    for (int index = 0; index < nsLen; ++index)
    {
      ns[nsOff + index] = Pack.BE_To_UInt64(bs, bsOff);
      bsOff += 8;
    }
  }

  internal static void UInt16_To_LE(ushort n, byte[] bs)
  {
    bs[0] = (byte) n;
    bs[1] = (byte) ((uint) n >> 8);
  }

  internal static void UInt16_To_LE(ushort n, byte[] bs, int off)
  {
    bs[off] = (byte) n;
    bs[off + 1] = (byte) ((uint) n >> 8);
  }

  internal static byte[] UInt16_To_LE(ushort n)
  {
    byte[] bs = new byte[2];
    Pack.UInt16_To_LE(n, bs, 0);
    return bs;
  }

  internal static byte[] UInt16_To_LE(ushort[] ns)
  {
    byte[] bs = new byte[2 * ns.Length];
    Pack.UInt16_To_LE(ns, bs, 0);
    return bs;
  }

  internal static void UInt16_To_LE(ushort[] ns, byte[] bs, int off)
  {
    for (int index = 0; index < ns.Length; ++index)
    {
      Pack.UInt16_To_LE(ns[index], bs, off);
      off += 2;
    }
  }

  internal static void UInt16_To_LE(ushort[] ns, int nsOff, int nsLen, byte[] bs, int bsOff)
  {
    for (int index = 0; index < nsLen; ++index)
    {
      Pack.UInt16_To_LE(ns[nsOff + index], bs, bsOff);
      bsOff += 2;
    }
  }

  internal static ushort LE_To_UInt16(byte[] bs) => (ushort) ((uint) bs[0] | (uint) bs[1] << 8);

  internal static ushort LE_To_UInt16(byte[] bs, int off)
  {
    return (ushort) ((uint) bs[off] | (uint) bs[off + 1] << 8);
  }

  internal static void LE_To_UInt16(byte[] bs, int off, ushort[] ns)
  {
    for (int index = 0; index < ns.Length; ++index)
    {
      ns[index] = Pack.LE_To_UInt16(bs, off);
      off += 2;
    }
  }

  internal static void LE_To_UInt16(byte[] bs, int bOff, ushort[] ns, int nOff, int count)
  {
    for (int index = 0; index < count; ++index)
    {
      ns[nOff + index] = Pack.LE_To_UInt16(bs, bOff);
      bOff += 2;
    }
  }

  internal static ushort[] LE_To_UInt16(byte[] bs, int off, int count)
  {
    ushort[] ns = new ushort[count];
    Pack.LE_To_UInt16(bs, off, ns);
    return ns;
  }

  internal static byte[] UInt32_To_LE(uint n)
  {
    byte[] bs = new byte[4];
    Pack.UInt32_To_LE(n, bs, 0);
    return bs;
  }

  internal static void UInt32_To_LE(uint n, byte[] bs)
  {
    bs[0] = (byte) n;
    bs[1] = (byte) (n >> 8);
    bs[2] = (byte) (n >> 16 /*0x10*/);
    bs[3] = (byte) (n >> 24);
  }

  internal static void UInt32_To_LE(uint n, byte[] bs, int off)
  {
    bs[off] = (byte) n;
    bs[off + 1] = (byte) (n >> 8);
    bs[off + 2] = (byte) (n >> 16 /*0x10*/);
    bs[off + 3] = (byte) (n >> 24);
  }

  internal static byte[] UInt32_To_LE(uint[] ns)
  {
    byte[] bs = new byte[4 * ns.Length];
    Pack.UInt32_To_LE(ns, bs, 0);
    return bs;
  }

  internal static void UInt32_To_LE(uint[] ns, byte[] bs, int off)
  {
    for (int index = 0; index < ns.Length; ++index)
    {
      Pack.UInt32_To_LE(ns[index], bs, off);
      off += 4;
    }
  }

  internal static void UInt32_To_LE(uint[] ns, int nsOff, int nsLen, byte[] bs, int bsOff)
  {
    for (int index = 0; index < nsLen; ++index)
    {
      Pack.UInt32_To_LE(ns[nsOff + index], bs, bsOff);
      bsOff += 4;
    }
  }

  internal static uint LE_To_UInt24(byte[] bs, int off)
  {
    return (uint) ((int) bs[off] | (int) bs[off + 1] << 8 | (int) bs[off + 2] << 16 /*0x10*/);
  }

  internal static uint LE_To_UInt32(byte[] bs)
  {
    return (uint) ((int) bs[0] | (int) bs[1] << 8 | (int) bs[2] << 16 /*0x10*/ | (int) bs[3] << 24);
  }

  internal static uint LE_To_UInt32(byte[] bs, int off)
  {
    return (uint) ((int) bs[off] | (int) bs[off + 1] << 8 | (int) bs[off + 2] << 16 /*0x10*/ | (int) bs[off + 3] << 24);
  }

  internal static void LE_To_UInt32(byte[] bs, int off, uint[] ns)
  {
    for (int index = 0; index < ns.Length; ++index)
    {
      ns[index] = Pack.LE_To_UInt32(bs, off);
      off += 4;
    }
  }

  internal static void LE_To_UInt32(byte[] bs, int bOff, uint[] ns, int nOff, int count)
  {
    for (int index = 0; index < count; ++index)
    {
      ns[nOff + index] = Pack.LE_To_UInt32(bs, bOff);
      bOff += 4;
    }
  }

  internal static uint[] LE_To_UInt32(byte[] bs, int off, int count)
  {
    uint[] ns = new uint[count];
    Pack.LE_To_UInt32(bs, off, ns);
    return ns;
  }

  internal static byte[] UInt64_To_LE(ulong n)
  {
    byte[] bs = new byte[8];
    Pack.UInt64_To_LE(n, bs, 0);
    return bs;
  }

  internal static void UInt64_To_LE(ulong n, byte[] bs)
  {
    Pack.UInt32_To_LE((uint) n, bs);
    Pack.UInt32_To_LE((uint) (n >> 32 /*0x20*/), bs, 4);
  }

  internal static void UInt64_To_LE(ulong n, byte[] bs, int off)
  {
    Pack.UInt32_To_LE((uint) n, bs, off);
    Pack.UInt32_To_LE((uint) (n >> 32 /*0x20*/), bs, off + 4);
  }

  internal static byte[] UInt64_To_LE(ulong[] ns)
  {
    byte[] bs = new byte[8 * ns.Length];
    Pack.UInt64_To_LE(ns, bs, 0);
    return bs;
  }

  internal static void UInt64_To_LE(ulong[] ns, byte[] bs, int off)
  {
    for (int index = 0; index < ns.Length; ++index)
    {
      Pack.UInt64_To_LE(ns[index], bs, off);
      off += 8;
    }
  }

  internal static void UInt64_To_LE(ulong[] ns, int nsOff, int nsLen, byte[] bs, int bsOff)
  {
    for (int index = 0; index < nsLen; ++index)
    {
      Pack.UInt64_To_LE(ns[nsOff + index], bs, bsOff);
      bsOff += 8;
    }
  }

  internal static ulong LE_To_UInt64(byte[] bs)
  {
    uint uint32 = Pack.LE_To_UInt32(bs);
    return (ulong) Pack.LE_To_UInt32(bs, 4) << 32 /*0x20*/ | (ulong) uint32;
  }

  internal static ulong LE_To_UInt64(byte[] bs, int off)
  {
    uint uint32 = Pack.LE_To_UInt32(bs, off);
    return (ulong) Pack.LE_To_UInt32(bs, off + 4) << 32 /*0x20*/ | (ulong) uint32;
  }

  internal static void LE_To_UInt64(byte[] bs, int off, ulong[] ns)
  {
    for (int index = 0; index < ns.Length; ++index)
    {
      ns[index] = Pack.LE_To_UInt64(bs, off);
      off += 8;
    }
  }

  internal static void LE_To_UInt64(byte[] bs, int bsOff, ulong[] ns, int nsOff, int nsLen)
  {
    for (int index = 0; index < nsLen; ++index)
    {
      ns[nsOff + index] = Pack.LE_To_UInt64(bs, bsOff);
      bsOff += 8;
    }
  }

  internal static ulong[] LE_To_UInt64(byte[] bs, int off, int count)
  {
    ulong[] ns = new ulong[count];
    Pack.LE_To_UInt64(bs, off, ns);
    return ns;
  }
}
