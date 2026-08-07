// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Tls.DtlsReassembler
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.Collections.Generic;

#nullable disable
namespace Org.BouncyCastle.Tls;

internal sealed class DtlsReassembler
{
  private readonly short m_msg_type;
  private readonly byte[] m_body;
  private readonly List<DtlsReassembler.Range> m_missing = new List<DtlsReassembler.Range>();

  internal DtlsReassembler(short msg_type, int length)
  {
    this.m_msg_type = msg_type;
    this.m_body = new byte[length];
    this.m_missing.Add(new DtlsReassembler.Range(0, length));
  }

  internal short MsgType => this.m_msg_type;

  internal byte[] GetBodyIfComplete() => this.m_missing.Count <= 0 ? this.m_body : (byte[]) null;

  internal void ContributeFragment(
    short msg_type,
    int length,
    byte[] buf,
    int off,
    int fragment_offset,
    int fragment_length)
  {
    int val2 = fragment_offset + fragment_length;
    if ((int) this.m_msg_type != (int) msg_type || this.m_body.Length != length || val2 > length)
      return;
    if (fragment_length == 0)
    {
      if (fragment_offset != 0 || this.m_missing.Count <= 0 || this.m_missing[0].End != 0)
        return;
      this.m_missing.RemoveAt(0);
    }
    else
    {
      for (int index = 0; index < this.m_missing.Count; ++index)
      {
        DtlsReassembler.Range range = this.m_missing[index];
        if (range.Start >= val2)
          break;
        if (range.End > fragment_offset)
        {
          int destinationIndex = Math.Max(range.Start, fragment_offset);
          int start = Math.Min(range.End, val2);
          int length1 = start - destinationIndex;
          Array.Copy((Array) buf, off + destinationIndex - fragment_offset, (Array) this.m_body, destinationIndex, length1);
          if (destinationIndex == range.Start)
          {
            if (start == range.End)
              this.m_missing.RemoveAt(index--);
            else
              range.Start = start;
          }
          else
          {
            if (start != range.End)
              this.m_missing.Insert(++index, new DtlsReassembler.Range(start, range.End));
            range.End = destinationIndex;
          }
        }
      }
    }
  }

  internal void Reset()
  {
    this.m_missing.Clear();
    this.m_missing.Add(new DtlsReassembler.Range(0, this.m_body.Length));
  }

  private sealed class Range
  {
    private int m_start;
    private int m_end;

    internal Range(int start, int end)
    {
      this.m_start = start;
      this.m_end = end;
    }

    public int Start
    {
      get => this.m_start;
      set => this.m_start = value;
    }

    public int End
    {
      get => this.m_end;
      set => this.m_end = value;
    }
  }
}
