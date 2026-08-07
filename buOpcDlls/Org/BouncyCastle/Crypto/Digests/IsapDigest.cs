// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Digests.IsapDigest
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto.Utilities;
using Org.BouncyCastle.Utilities;
using System;
using System.IO;

#nullable disable
namespace Org.BouncyCastle.Crypto.Digests;

public sealed class IsapDigest : IDigest
{
  private readonly MemoryStream buffer = new MemoryStream();
  private ulong x0;
  private ulong x1;
  private ulong x2;
  private ulong x3;
  private ulong x4;

  public string AlgorithmName => "ISAP Hash";

  public int GetDigestSize() => 32 /*0x20*/;

  public int GetByteLength() => 8;

  public void Update(byte input) => this.buffer.WriteByte(input);

  public void BlockUpdate(byte[] input, int inOff, int inLen)
  {
    Org.BouncyCastle.Crypto.Check.DataLength(input, inOff, inLen, "input buffer too short");
    this.buffer.Write(input, inOff, inLen);
  }

  public int DoFinal(byte[] output, int outOff)
  {
    Org.BouncyCastle.Crypto.Check.OutputLength(output, outOff, 32 /*0x20*/, "output buffer is too short");
    this.x0 = 17191252062196199485UL;
    this.x1 = 10066134719181819906UL;
    this.x2 = 13009371945472744034UL;
    this.x3 = 4834782570098516968UL;
    this.x4 = 3787428097924915520UL;
    byte[] buffer = this.buffer.GetBuffer();
    int int32 = Convert.ToInt32(this.buffer.Length);
    int off = 0;
    while (int32 >= 8)
    {
      this.x0 ^= Pack.BE_To_UInt64(buffer, off);
      off += 8;
      int32 -= 8;
      this.P12();
    }
    this.x0 ^= (ulong) (128L /*0x80*/ << (7 - int32 << 3));
    if (int32 > 0)
      this.x0 ^= Pack.BE_To_UInt64_High(buffer, off, int32);
    for (int index = 0; index < 4; ++index)
    {
      this.P12();
      Pack.UInt64_To_BE(this.x0, output, outOff + (index << 3));
    }
    return 32 /*0x20*/;
  }

  public void Reset() => this.buffer.SetLength(0L);

  private void P12()
  {
    this.ROUND(240UL /*0xF0*/);
    this.ROUND(225UL);
    this.ROUND(210UL);
    this.ROUND(195UL);
    this.ROUND(180UL);
    this.ROUND(165UL);
    this.ROUND(150UL);
    this.ROUND(135UL);
    this.ROUND(120UL);
    this.ROUND(105UL);
    this.ROUND(90UL);
    this.ROUND(75UL);
  }

  private void ROUND(ulong C)
  {
    ulong i1 = (ulong) ((long) this.x0 ^ (long) this.x1 ^ (long) this.x2 ^ (long) this.x3 ^ (long) C ^ (long) this.x1 & ((long) this.x0 ^ (long) this.x2 ^ (long) this.x4 ^ (long) C));
    ulong i2 = (ulong) ((long) this.x0 ^ (long) this.x2 ^ (long) this.x3 ^ (long) this.x4 ^ (long) C ^ ((long) this.x1 ^ (long) this.x2 ^ (long) C) & ((long) this.x1 ^ (long) this.x3));
    ulong i3 = (ulong) ((long) this.x1 ^ (long) this.x2 ^ (long) this.x4 ^ (long) C ^ (long) this.x3 & (long) this.x4);
    ulong i4 = (ulong) ((long) this.x0 ^ (long) this.x1 ^ (long) this.x2 ^ (long) C ^ ~(long) this.x0 & ((long) this.x3 ^ (long) this.x4));
    ulong i5 = (ulong) ((long) this.x1 ^ (long) this.x3 ^ (long) this.x4 ^ ((long) this.x0 ^ (long) this.x4) & (long) this.x1);
    this.x0 = i1 ^ Longs.RotateRight(i1, 19) ^ Longs.RotateRight(i1, 28);
    this.x1 = i2 ^ Longs.RotateRight(i2, 39) ^ Longs.RotateRight(i2, 61);
    this.x2 = (ulong) ~((long) i3 ^ (long) Longs.RotateRight(i3, 1) ^ (long) Longs.RotateRight(i3, 6));
    this.x3 = i4 ^ Longs.RotateRight(i4, 10) ^ Longs.RotateRight(i4, 17);
    this.x4 = i5 ^ Longs.RotateRight(i5, 7) ^ Longs.RotateRight(i5, 41);
  }
}
