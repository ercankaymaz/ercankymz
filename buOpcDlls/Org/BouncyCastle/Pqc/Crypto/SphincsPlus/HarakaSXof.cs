// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Pqc.Crypto.SphincsPlus.HarakaSXof
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;

#nullable disable
namespace Org.BouncyCastle.Pqc.Crypto.SphincsPlus;

internal sealed class HarakaSXof : HarakaSBase
{
  public string AlgorithmName => "Haraka-S";

  public HarakaSXof(byte[] pkSeed)
  {
    byte[] numArray = new byte[640];
    this.BlockUpdate(pkSeed, 0, pkSeed.Length);
    this.OutputFinal(numArray, 0, numArray.Length);
    this.haraka512_rc = new ulong[10][];
    this.haraka256_rc = new uint[10][];
    for (int index = 0; index < 10; ++index)
    {
      this.haraka512_rc[index] = new ulong[8];
      this.haraka256_rc[index] = new uint[8];
      HarakaSBase.InterleaveConstant32(this.haraka256_rc[index], numArray, index << 5);
      HarakaSBase.InterleaveConstant(this.haraka512_rc[index], numArray, index << 6);
    }
  }

  public void Update(byte input)
  {
    this.buffer[this.off++] ^= input;
    if (this.off != 32 /*0x20*/)
      return;
    this.Haraka512Perm(this.buffer);
    this.off = 0;
  }

  public void BlockUpdate(byte[] input, int inOff, int len)
  {
    int num1 = inOff;
    int num2 = len + this.off >> 5;
    for (int index = 0; index < num2; ++index)
    {
      while (this.off < 32 /*0x20*/)
        this.buffer[this.off++] ^= input[num1++];
      this.Haraka512Perm(this.buffer);
      this.off = 0;
    }
    byte[] buffer;
    int index1;
    for (; num1 < inOff + len; buffer[index1] ^= input[num1++])
    {
      buffer = this.buffer;
      index1 = this.off++;
    }
  }

  public int OutputFinal(byte[] output, int outOff, int len)
  {
    int num = len;
    this.buffer[this.off] ^= (byte) 31 /*0x1F*/;
    this.buffer[31 /*0x1F*/] ^= (byte) 128 /*0x80*/;
    for (; len >= 32 /*0x20*/; len -= 32 /*0x20*/)
    {
      this.Haraka512Perm(this.buffer);
      Array.Copy((Array) this.buffer, 0, (Array) output, outOff, 32 /*0x20*/);
      outOff += 32 /*0x20*/;
    }
    if (len > 0)
    {
      this.Haraka512Perm(this.buffer);
      Array.Copy((Array) this.buffer, 0, (Array) output, outOff, len);
    }
    this.Reset();
    return num;
  }
}
