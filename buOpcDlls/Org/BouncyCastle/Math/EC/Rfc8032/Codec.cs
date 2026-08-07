// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Math.EC.Rfc8032.Codec
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

#nullable disable
namespace Org.BouncyCastle.Math.EC.Rfc8032;

internal static class Codec
{
  internal static uint Decode16(byte[] bs, int off) => (uint) bs[off] | (uint) bs[++off] << 8;

  internal static uint Decode24(byte[] bs, int off)
  {
    return (uint) ((int) bs[off] | (int) bs[++off] << 8 | (int) bs[++off] << 16 /*0x10*/);
  }

  internal static uint Decode32(byte[] bs, int off)
  {
    return (uint) ((int) bs[off] | (int) bs[++off] << 8 | (int) bs[++off] << 16 /*0x10*/ | (int) bs[++off] << 24);
  }

  internal static void Decode32(byte[] bs, int bsOff, uint[] n, int nOff, int nLen)
  {
    for (int index = 0; index < nLen; ++index)
      n[nOff + index] = Codec.Decode32(bs, bsOff + index * 4);
  }

  internal static void Encode24(uint n, byte[] bs, int off)
  {
    bs[off] = (byte) n;
    bs[++off] = (byte) (n >> 8);
    bs[++off] = (byte) (n >> 16 /*0x10*/);
  }

  internal static void Encode32(uint n, byte[] bs, int off)
  {
    bs[off] = (byte) n;
    bs[++off] = (byte) (n >> 8);
    bs[++off] = (byte) (n >> 16 /*0x10*/);
    bs[++off] = (byte) (n >> 24);
  }

  internal static void Encode32(uint[] n, int nOff, int nLen, byte[] bs, int bsOff)
  {
    for (int index = 0; index < nLen; ++index)
      Codec.Encode32(n[nOff + index], bs, bsOff + index * 4);
  }

  internal static void Encode56(ulong n, byte[] bs, int off)
  {
    Codec.Encode32((uint) n, bs, off);
    Codec.Encode24((uint) (n >> 32 /*0x20*/), bs, off + 4);
  }
}
