// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Pqc.Crypto.SphincsPlus.HarakaS512Digest
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;

#nullable disable
namespace Org.BouncyCastle.Pqc.Crypto.SphincsPlus;

internal sealed class HarakaS512Digest : HarakaSBase
{
  public HarakaS512Digest(HarakaSBase harakaSBase) => this.haraka512_rc = harakaSBase.haraka512_rc;

  public string AlgorithmName => "HarakaS-512";

  public int GetDigestSize() => 32 /*0x20*/;

  public void Update(byte input)
  {
    this.buffer[this.off++] = this.off <= 63 /*0x3F*/ ? (byte) (int) input : throw new ArgumentException("total input cannot be more than 64 bytes");
  }

  public void BlockUpdate(byte[] input, int inOff, int len)
  {
    if (this.off > 64 /*0x40*/ - len)
      throw new ArgumentException("total input cannot be more than 64 bytes");
    Array.Copy((Array) input, inOff, (Array) this.buffer, this.off, len);
    this.off += len;
  }

  public int DoFinal(byte[] output, int outOff)
  {
    byte[] numArray = new byte[64 /*0x40*/];
    this.Haraka512Perm(numArray);
    HarakaSBase.Xor(numArray, 8, this.buffer, 8, output, outOff, 8);
    HarakaSBase.Xor(numArray, 24, this.buffer, 24, output, outOff + 8, 16 /*0x10*/);
    HarakaSBase.Xor(numArray, 48 /*0x30*/, this.buffer, 48 /*0x30*/, output, outOff + 24, 8);
    this.Reset();
    return 32 /*0x20*/;
  }
}
