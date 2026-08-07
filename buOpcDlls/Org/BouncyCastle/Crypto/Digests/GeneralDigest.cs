// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Digests.GeneralDigest
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Crypto.Digests;

public abstract class GeneralDigest : IDigest, IMemoable
{
  private const int BYTE_LENGTH = 64 /*0x40*/;
  private byte[] xBuf;
  private int xBufOff;
  private long byteCount;

  internal GeneralDigest() => this.xBuf = new byte[4];

  internal GeneralDigest(GeneralDigest t)
  {
    this.xBuf = new byte[t.xBuf.Length];
    this.CopyIn(t);
  }

  protected void CopyIn(GeneralDigest t)
  {
    Array.Copy((Array) t.xBuf, 0, (Array) this.xBuf, 0, t.xBuf.Length);
    this.xBufOff = t.xBufOff;
    this.byteCount = t.byteCount;
  }

  public void Update(byte input)
  {
    this.xBuf[this.xBufOff++] = input;
    if (this.xBufOff == this.xBuf.Length)
    {
      this.ProcessWord(this.xBuf, 0);
      this.xBufOff = 0;
    }
    ++this.byteCount;
  }

  public void BlockUpdate(byte[] input, int inOff, int length)
  {
    length = Math.Max(0, length);
    int num = 0;
    if (this.xBufOff != 0)
    {
      while (num < length)
      {
        this.xBuf[this.xBufOff++] = input[inOff + num++];
        if (this.xBufOff == 4)
        {
          this.ProcessWord(this.xBuf, 0);
          this.xBufOff = 0;
          break;
        }
      }
    }
    for (int index = length - 3; num < index; num += 4)
      this.ProcessWord(input, inOff + num);
    while (num < length)
      this.xBuf[this.xBufOff++] = input[inOff + num++];
    this.byteCount += (long) length;
  }

  public void Finish()
  {
    long bitLength = this.byteCount << 3;
    this.Update((byte) 128 /*0x80*/);
    while (this.xBufOff != 0)
      this.Update((byte) 0);
    this.ProcessLength(bitLength);
    this.ProcessBlock();
  }

  public virtual void Reset()
  {
    this.byteCount = 0L;
    this.xBufOff = 0;
    Array.Clear((Array) this.xBuf, 0, this.xBuf.Length);
  }

  public int GetByteLength() => 64 /*0x40*/;

  internal abstract void ProcessWord(byte[] input, int inOff);

  internal abstract void ProcessLength(long bitLength);

  internal abstract void ProcessBlock();

  public abstract string AlgorithmName { get; }

  public abstract int GetDigestSize();

  public abstract int DoFinal(byte[] output, int outOff);

  public abstract IMemoable Copy();

  public abstract void Reset(IMemoable t);
}
