// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Pqc.Crypto.Falcon.FalconRNG
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;

#nullable disable
namespace Org.BouncyCastle.Pqc.Crypto.Falcon;

internal class FalconRNG
{
  private byte[] bd;
  private byte[] sd;
  private int ptr;
  private FalconConversions convertor;

  internal FalconRNG()
  {
    this.bd = new byte[512 /*0x0200*/];
    this.sd = new byte[256 /*0x0100*/];
    this.convertor = new FalconConversions();
  }

  internal void prng_init(SHAKE256 src)
  {
    byte[] outsrc = new byte[56];
    src.i_shake256_extract(outsrc, 0, 56);
    for (int index = 0; index < 14; ++index)
      Array.Copy((Array) this.convertor.int_to_bytes((int) outsrc[index << 2] | (int) outsrc[(index << 2) + 1] << 8 | (int) outsrc[(index << 2) + 2] << 16 /*0x10*/ | (int) outsrc[(index << 2) + 3] << 24), 0, (Array) this.sd, index << 2, 4);
    Array.Copy((Array) this.convertor.ulong_to_bytes((ulong) this.convertor.bytes_to_uint(this.sd, 48 /*0x30*/) + ((ulong) this.convertor.bytes_to_uint(this.sd, 52) << 32 /*0x20*/)), 0, (Array) this.sd, 48 /*0x30*/, 8);
    this.prng_refill();
  }

  private void QROUND(uint[] state, int a, int b, int c, int d)
  {
    state[a] += state[b];
    state[d] ^= state[a];
    state[d] = state[d] << 16 /*0x10*/ | state[d] >> 16 /*0x10*/;
    state[c] += state[d];
    state[b] ^= state[c];
    state[b] = state[b] << 12 | state[b] >> 20;
    state[a] += state[b];
    state[d] ^= state[a];
    state[d] = state[d] << 8 | state[d] >> 24;
    state[c] += state[d];
    state[b] ^= state[c];
    state[b] = state[b] << 7 | state[b] >> 25;
  }

  private void prng_refill()
  {
    uint[] sourceArray = new uint[4]
    {
      1634760805U,
      857760878U,
      2036477234U,
      1797285236U
    };
    ulong x = this.convertor.bytes_to_ulong(this.sd, 48 /*0x30*/);
    for (int index1 = 0; index1 < 8; ++index1)
    {
      uint[] numArray = new uint[16 /*0x10*/];
      Array.Copy((Array) sourceArray, 0, (Array) numArray, 0, 4);
      Array.Copy((Array) this.convertor.bytes_to_uint_array(this.sd, 0, 12), 0, (Array) numArray, 4, 12);
      numArray[14] ^= (uint) x;
      numArray[15] ^= (uint) (x >> 32 /*0x20*/);
      for (int index2 = 0; index2 < 10; ++index2)
      {
        this.QROUND(numArray, 0, 4, 8, 12);
        this.QROUND(numArray, 1, 5, 9, 13);
        this.QROUND(numArray, 2, 6, 10, 14);
        this.QROUND(numArray, 3, 7, 11, 15);
        this.QROUND(numArray, 0, 5, 10, 15);
        this.QROUND(numArray, 1, 6, 11, 12);
        this.QROUND(numArray, 2, 7, 8, 13);
        this.QROUND(numArray, 3, 4, 9, 14);
      }
      for (int index3 = 0; index3 < 4; ++index3)
        numArray[index3] += sourceArray[index3];
      for (int index4 = 4; index4 < 14; ++index4)
        numArray[index4] += this.convertor.bytes_to_uint(this.sd, 4 * index4 - 16 /*0x10*/);
      numArray[14] += (uint) ((ulong) this.convertor.bytes_to_uint(this.sd, 40) ^ (ulong) (int) x);
      numArray[15] += (uint) ((ulong) this.convertor.bytes_to_uint(this.sd, 44) ^ (ulong) (int) (x >> 32 /*0x20*/));
      ++x;
      for (int index5 = 0; index5 < 16 /*0x10*/; ++index5)
      {
        this.bd[(index1 << 2) + (index5 << 5)] = (byte) numArray[index5];
        this.bd[(index1 << 2) + (index5 << 5) + 1] = (byte) (numArray[index5] >> 8);
        this.bd[(index1 << 2) + (index5 << 5) + 2] = (byte) (numArray[index5] >> 16 /*0x10*/);
        this.bd[(index1 << 2) + (index5 << 5) + 3] = (byte) (numArray[index5] >> 24);
      }
    }
    Array.Copy((Array) this.convertor.ulong_to_bytes(x), 0, (Array) this.sd, 48 /*0x30*/, 8);
    this.ptr = 0;
  }

  internal void prng_get_bytes(byte[] dstsrc, int dst, int len)
  {
    int destinationIndex = dst;
    while (len > 0)
    {
      int length = this.bd.Length - this.ptr;
      if (length > len)
        length = len;
      Array.Copy((Array) this.bd, 0, (Array) dstsrc, destinationIndex, length);
      destinationIndex += length;
      len -= length;
      this.ptr += length;
      if (this.ptr == this.bd.Length)
        this.prng_refill();
    }
  }

  internal ulong prng_get_u64()
  {
    int index = this.ptr;
    if (index >= this.bd.Length - 9)
    {
      this.prng_refill();
      index = 0;
    }
    this.ptr = index + 8;
    return (ulong) ((long) this.bd[index] | (long) this.bd[index + 1] << 8 | (long) this.bd[index + 2] << 16 /*0x10*/ | (long) this.bd[index + 3] << 24 | (long) this.bd[index + 4] << 32 /*0x20*/ | (long) this.bd[index + 5] << 40 | (long) this.bd[index + 6] << 48 /*0x30*/ | (long) this.bd[index + 7] << 56);
  }

  internal uint prng_get_u8()
  {
    int u8 = (int) this.bd[this.ptr++];
    if (this.ptr != this.bd.Length)
      return (uint) u8;
    this.prng_refill();
    return (uint) u8;
  }
}
