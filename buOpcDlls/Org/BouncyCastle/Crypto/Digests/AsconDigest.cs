// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Digests.AsconDigest
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto.Utilities;
using Org.BouncyCastle.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Crypto.Digests;

public sealed class AsconDigest : IDigest
{
  private readonly AsconDigest.AsconParameters m_asconParameters;
  private readonly int ASCON_PB_ROUNDS;
  private ulong x0;
  private ulong x1;
  private ulong x2;
  private ulong x3;
  private ulong x4;
  private readonly byte[] m_buf = new byte[8];
  private int m_bufPos;

  public AsconDigest(AsconDigest.AsconParameters parameters)
  {
    this.m_asconParameters = parameters;
    if (parameters != AsconDigest.AsconParameters.AsconHash)
    {
      if (parameters != AsconDigest.AsconParameters.AsconHashA)
        throw new ArgumentException("Invalid parameter settings for Ascon Hash");
      this.ASCON_PB_ROUNDS = 8;
    }
    else
      this.ASCON_PB_ROUNDS = 12;
    this.Reset();
  }

  public string AlgorithmName
  {
    get
    {
      switch (this.m_asconParameters)
      {
        case AsconDigest.AsconParameters.AsconHash:
          return "Ascon-Hash";
        case AsconDigest.AsconParameters.AsconHashA:
          return "Ascon-HashA";
        default:
          throw new InvalidOperationException();
      }
    }
  }

  public int GetDigestSize() => 32 /*0x20*/;

  public int GetByteLength() => 8;

  public void Update(byte input)
  {
    this.m_buf[this.m_bufPos] = input;
    if (++this.m_bufPos != 8)
      return;
    this.x0 ^= Pack.BE_To_UInt64(this.m_buf, 0);
    this.P(this.ASCON_PB_ROUNDS);
    this.m_bufPos = 0;
  }

  public void BlockUpdate(byte[] input, int inOff, int inLen)
  {
    Org.BouncyCastle.Crypto.Check.DataLength(input, inOff, inLen, "input buffer too short");
    if (inLen < 1)
      return;
    int length1 = 8 - this.m_bufPos;
    if (inLen < length1)
    {
      Array.Copy((Array) input, inOff, (Array) this.m_buf, this.m_bufPos, inLen);
      this.m_bufPos += inLen;
    }
    else
    {
      int num = 0;
      if (this.m_bufPos > 0)
      {
        Array.Copy((Array) input, inOff, (Array) this.m_buf, this.m_bufPos, length1);
        num += length1;
        this.x0 ^= Pack.BE_To_UInt64(this.m_buf, 0);
        this.P(this.ASCON_PB_ROUNDS);
      }
      int length2;
      for (; (length2 = inLen - num) >= 8; num += 8)
      {
        this.x0 ^= Pack.BE_To_UInt64(input, inOff + num);
        this.P(this.ASCON_PB_ROUNDS);
      }
      Array.Copy((Array) input, inOff + num, (Array) this.m_buf, 0, length2);
      this.m_bufPos = length2;
    }
  }

  public int DoFinal(byte[] output, int outOff)
  {
    Org.BouncyCastle.Crypto.Check.OutputLength(output, outOff, 32 /*0x20*/, "output buffer is too short");
    this.FinishAbsorbing();
    Pack.UInt64_To_BE(this.x0, output, outOff);
    for (int index = 0; index < 3; ++index)
    {
      outOff += 8;
      this.P(this.ASCON_PB_ROUNDS);
      Pack.UInt64_To_BE(this.x0, output, outOff);
    }
    this.Reset();
    return 32 /*0x20*/;
  }

  public void Reset()
  {
    Array.Clear((Array) this.m_buf, 0, this.m_buf.Length);
    this.m_bufPos = 0;
    switch (this.m_asconParameters)
    {
      case AsconDigest.AsconParameters.AsconHash:
        this.x0 = 17191252062196199485UL;
        this.x1 = 10066134719181819906UL;
        this.x2 = 13009371945472744034UL;
        this.x3 = 4834782570098516968UL;
        this.x4 = 3787428097924915520UL;
        break;
      case AsconDigest.AsconParameters.AsconHashA:
        this.x0 = 92044056785660070UL;
        this.x1 = 8326807761760157607UL;
        this.x2 = 3371194088139667532UL;
        this.x3 = 15489749720654559101UL;
        this.x4 = 11618234402860862855UL;
        break;
      default:
        throw new InvalidOperationException();
    }
  }

  private void FinishAbsorbing()
  {
    this.m_buf[this.m_bufPos] = (byte) 128 /*0x80*/;
    this.x0 ^= Pack.BE_To_UInt64(this.m_buf, 0) & (ulong) (-1L << 56 - (this.m_bufPos << 3));
    this.P(12);
  }

  private void P(int nr)
  {
    if (nr == 12)
    {
      this.ROUND(240UL /*0xF0*/);
      this.ROUND(225UL);
      this.ROUND(210UL);
      this.ROUND(195UL);
    }
    this.ROUND(180UL);
    this.ROUND(165UL);
    this.ROUND(150UL);
    this.ROUND(135UL);
    this.ROUND(120UL);
    this.ROUND(105UL);
    this.ROUND(90UL);
    this.ROUND(75UL);
  }

  private void ROUND(ulong c)
  {
    ulong i1 = (ulong) ((long) this.x0 ^ (long) this.x1 ^ (long) this.x2 ^ (long) this.x3 ^ (long) c ^ (long) this.x1 & ((long) this.x0 ^ (long) this.x2 ^ (long) this.x4 ^ (long) c));
    ulong i2 = (ulong) ((long) this.x0 ^ (long) this.x2 ^ (long) this.x3 ^ (long) this.x4 ^ (long) c ^ ((long) this.x1 ^ (long) this.x2 ^ (long) c) & ((long) this.x1 ^ (long) this.x3));
    ulong i3 = (ulong) ((long) this.x1 ^ (long) this.x2 ^ (long) this.x4 ^ (long) c ^ (long) this.x3 & (long) this.x4);
    ulong i4 = (ulong) ((long) this.x0 ^ (long) this.x1 ^ (long) this.x2 ^ (long) c ^ ~(long) this.x0 & ((long) this.x3 ^ (long) this.x4));
    ulong i5 = (ulong) ((long) this.x1 ^ (long) this.x3 ^ (long) this.x4 ^ ((long) this.x0 ^ (long) this.x4) & (long) this.x1);
    this.x0 = i1 ^ Longs.RotateRight(i1, 19) ^ Longs.RotateRight(i1, 28);
    this.x1 = i2 ^ Longs.RotateRight(i2, 39) ^ Longs.RotateRight(i2, 61);
    this.x2 = (ulong) ~((long) i3 ^ (long) Longs.RotateRight(i3, 1) ^ (long) Longs.RotateRight(i3, 6));
    this.x3 = i4 ^ Longs.RotateRight(i4, 10) ^ Longs.RotateRight(i4, 17);
    this.x4 = i5 ^ Longs.RotateRight(i5, 7) ^ Longs.RotateRight(i5, 41);
  }

  public enum AsconParameters
  {
    AsconHash,
    AsconHashA,
  }
}
