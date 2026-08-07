// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Pqc.Crypto.SphincsPlus.HarakaS256Digest
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;

#nullable disable
namespace Org.BouncyCastle.Pqc.Crypto.SphincsPlus;

internal sealed class HarakaS256Digest : HarakaSBase
{
  public HarakaS256Digest(HarakaSXof harakaSXof) => this.haraka256_rc = harakaSXof.haraka256_rc;

  public string AlgorithmName => "HarakaS-256";

  public int GetDigestSize() => 32 /*0x20*/;

  public void Update(byte input)
  {
    this.buffer[this.off++] = this.off <= 31 /*0x1F*/ ? (byte) (int) input : throw new ArgumentException("total input cannot be more than 32 bytes");
  }

  public void BlockUpdate(byte[] input, int inOff, int len)
  {
    if (this.off > 32 /*0x20*/ - len)
      throw new ArgumentException("total input cannot be more than 32 bytes");
    Array.Copy((Array) input, inOff, (Array) this.buffer, this.off, len);
    this.off += len;
  }

  public int DoFinal(byte[] output, int outOff)
  {
    byte[] numArray = new byte[32 /*0x20*/];
    this.Haraka256Perm(numArray);
    HarakaSBase.Xor(numArray, 0, this.buffer, 0, output, outOff, 32 /*0x20*/);
    this.Reset();
    return 32 /*0x20*/;
  }
}
