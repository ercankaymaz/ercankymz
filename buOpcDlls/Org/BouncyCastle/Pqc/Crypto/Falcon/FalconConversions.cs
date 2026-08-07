// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Pqc.Crypto.Falcon.FalconConversions
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

#nullable disable
namespace Org.BouncyCastle.Pqc.Crypto.Falcon;

internal class FalconConversions
{
  internal FalconConversions()
  {
  }

  internal byte[] int_to_bytes(int x)
  {
    return new byte[4]
    {
      (byte) x,
      (byte) (x >> 8),
      (byte) (x >> 16 /*0x10*/),
      (byte) (x >> 24)
    };
  }

  internal uint bytes_to_uint(byte[] src, int pos)
  {
    return (uint) ((int) src[pos] | (int) src[pos + 1] << 8 | (int) src[pos + 2] << 16 /*0x10*/ | (int) src[pos + 3] << 24);
  }

  internal byte[] ulong_to_bytes(ulong x)
  {
    return new byte[8]
    {
      (byte) x,
      (byte) (x >> 8),
      (byte) (x >> 16 /*0x10*/),
      (byte) (x >> 24),
      (byte) (x >> 32 /*0x20*/),
      (byte) (x >> 40),
      (byte) (x >> 48 /*0x30*/),
      (byte) (x >> 56)
    };
  }

  internal ulong bytes_to_ulong(byte[] src, int pos)
  {
    return (ulong) ((long) src[pos] | (long) src[pos + 1] << 8 | (long) src[pos + 2] << 16 /*0x10*/ | (long) src[pos + 3] << 24 | (long) src[pos + 4] << 32 /*0x20*/ | (long) src[pos + 5] << 40 | (long) src[pos + 6] << 48 /*0x30*/ | (long) src[pos + 7] << 56);
  }

  internal uint[] bytes_to_uint_array(byte[] src, int pos, int num)
  {
    uint[] uintArray = new uint[num];
    for (int index = 0; index < num; ++index)
      uintArray[index] = this.bytes_to_uint(src, pos + 4 * index);
    return uintArray;
  }
}
