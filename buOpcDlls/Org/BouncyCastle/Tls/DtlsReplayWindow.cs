// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Tls.DtlsReplayWindow
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;

#nullable disable
namespace Org.BouncyCastle.Tls;

internal sealed class DtlsReplayWindow
{
  private const long ValidSeqMask = 281474976710655 /*0xFFFFFFFFFFFF*/;
  private const long WindowSize = 64 /*0x40*/;
  private long m_latestConfirmedSeq = -1;
  private ulong m_bitmap;

  internal bool ShouldDiscard(long seq)
  {
    if ((seq & 281474976710655L /*0xFFFFFFFFFFFF*/) != seq)
      return true;
    if (seq <= this.m_latestConfirmedSeq)
    {
      long num = this.m_latestConfirmedSeq - seq;
      if (num >= 64L /*0x40*/ || ((long) this.m_bitmap & 1L << (int) num) != 0L)
        return true;
    }
    return false;
  }

  internal void ReportAuthenticated(long seq, out bool isLatestConfirmed)
  {
    if ((seq & 281474976710655L /*0xFFFFFFFFFFFF*/) != seq)
      throw new ArgumentException("out of range", nameof (seq));
    if (seq <= this.m_latestConfirmedSeq)
    {
      long num = this.m_latestConfirmedSeq - seq;
      if (num < 64L /*0x40*/)
        this.m_bitmap |= (ulong) (1L << (int) num);
      isLatestConfirmed = false;
    }
    else
    {
      long num = seq - this.m_latestConfirmedSeq;
      if (num >= 64L /*0x40*/)
      {
        this.m_bitmap = 1UL;
      }
      else
      {
        this.m_bitmap <<= (int) num;
        this.m_bitmap |= 1UL;
      }
      this.m_latestConfirmedSeq = seq;
      isLatestConfirmed = true;
    }
  }

  internal void Reset(long seq)
  {
    this.m_latestConfirmedSeq = (seq & 281474976710655L /*0xFFFFFFFFFFFF*/) == seq ? seq : throw new ArgumentException("out of range", nameof (seq));
    this.m_bitmap = ulong.MaxValue >> (int) Math.Max(0L, 63L /*0x3F*/ - seq);
  }
}
