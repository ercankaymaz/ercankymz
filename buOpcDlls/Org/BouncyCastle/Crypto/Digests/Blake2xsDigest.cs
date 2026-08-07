// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Digests.Blake2xsDigest
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Crypto.Digests;

public sealed class Blake2xsDigest : IXof, IDigest
{
  public const int UnknownDigestLength = 65535 /*0xFFFF*/;
  private const int DigestLength = 32 /*0x20*/;
  private const long MaxNumberBlocks = 4294967296 /*0x0100000000*/;
  private int digestLength;
  private Blake2sDigest hash;
  private byte[] h0;
  private byte[] buf = new byte[32 /*0x20*/];
  private int bufPos = 32 /*0x20*/;
  private int digestPos;
  private long blockPos;
  private long nodeOffset;

  public Blake2xsDigest()
    : this((int) ushort.MaxValue)
  {
  }

  public Blake2xsDigest(int digestBytes)
    : this(digestBytes, (byte[]) null, (byte[]) null, (byte[]) null)
  {
  }

  public Blake2xsDigest(int digestBytes, byte[] key)
    : this(digestBytes, key, (byte[]) null, (byte[]) null)
  {
  }

  public Blake2xsDigest(int digestBytes, byte[] key, byte[] salt, byte[] personalization)
  {
    this.digestLength = digestBytes >= 1 && digestBytes <= (int) ushort.MaxValue ? digestBytes : throw new ArgumentException("BLAKE2xs digest length must be between 1 and 2^16-1");
    this.nodeOffset = this.ComputeNodeOffset();
    this.hash = new Blake2sDigest(32 /*0x20*/, key, salt, personalization, this.nodeOffset);
  }

  public Blake2xsDigest(Blake2xsDigest digest)
  {
    this.digestLength = digest.digestLength;
    this.hash = new Blake2sDigest(digest.hash);
    this.h0 = Arrays.Clone(digest.h0);
    this.buf = Arrays.Clone(digest.buf);
    this.bufPos = digest.bufPos;
    this.digestPos = digest.digestPos;
    this.blockPos = digest.blockPos;
    this.nodeOffset = digest.nodeOffset;
  }

  public string AlgorithmName => "BLAKE2xs";

  public int GetDigestSize() => this.digestLength;

  public int GetByteLength() => this.hash.GetByteLength();

  public long GetUnknownMaxLength() => 137438953472 /*0x2000000000*/;

  public void Update(byte b) => this.hash.Update(b);

  public void BlockUpdate(byte[] input, int inOff, int inLen)
  {
    this.hash.BlockUpdate(input, inOff, inLen);
  }

  public void Reset()
  {
    this.hash.Reset();
    this.h0 = (byte[]) null;
    this.bufPos = 32 /*0x20*/;
    this.digestPos = 0;
    this.blockPos = 0L;
    this.nodeOffset = this.ComputeNodeOffset();
  }

  public int DoFinal(byte[] output, int outOff)
  {
    return this.OutputFinal(output, outOff, this.digestLength);
  }

  public int OutputFinal(byte[] output, int outOff, int outLen)
  {
    int num = this.Output(output, outOff, outLen);
    this.Reset();
    return num;
  }

  public int Output(byte[] output, int outOff, int outLen)
  {
    Org.BouncyCastle.Crypto.Check.OutputLength(output, outOff, outLen, "output buffer too short");
    if (this.h0 == null)
    {
      this.h0 = new byte[this.hash.GetDigestSize()];
      this.hash.DoFinal(this.h0, 0);
    }
    if (this.digestLength != (int) ushort.MaxValue)
    {
      if (this.digestPos + outLen > this.digestLength)
        throw new ArgumentException("Output length is above the digest length");
    }
    else if (this.blockPos << 5 >= this.GetUnknownMaxLength())
      throw new ArgumentException("Maximum length is 2^32 blocks of 32 bytes");
    for (int index = 0; index < outLen; ++index)
    {
      if (this.bufPos >= 32 /*0x20*/)
      {
        Blake2sDigest blake2sDigest = new Blake2sDigest(this.ComputeStepLength(), 32 /*0x20*/, this.nodeOffset);
        blake2sDigest.BlockUpdate(this.h0, 0, this.h0.Length);
        Arrays.Fill(this.buf, (byte) 0);
        blake2sDigest.DoFinal(this.buf, 0);
        this.bufPos = 0;
        ++this.nodeOffset;
        ++this.blockPos;
      }
      output[outOff + index] = this.buf[this.bufPos];
      ++this.bufPos;
      ++this.digestPos;
    }
    return outLen;
  }

  private int ComputeStepLength()
  {
    return this.digestLength == (int) ushort.MaxValue ? 32 /*0x20*/ : Math.Min(32 /*0x20*/, this.digestLength - this.digestPos);
  }

  private long ComputeNodeOffset() => (long) this.digestLength * 4294967296L /*0x0100000000*/;
}
