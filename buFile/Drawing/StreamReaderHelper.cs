// Decompiled with JetBrains decompiler
// Type: PdfSharp.Drawing.StreamReaderHelper
// Assembly: buFile, Version=1.50.4740.0, Culture=neutral, PublicKeyToken=f94615aa0424f9eb
// MVID: 1F93257A-1245-4898-8C4E-DC1AB39EF50B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buFile.dll

using System;
using System.Diagnostics;
using System.IO;

#nullable disable
namespace PdfSharp.Drawing;

internal class StreamReaderHelper
{
  private readonly Stream _stream;
  private int _currentOffset;
  private readonly byte[] _data;
  private readonly int _length;

  internal StreamReaderHelper(Stream stream)
  {
    this._stream = stream;
    this._stream.Position = 0L;
    this._length = this._stream.Length <= (long) int.MaxValue ? (int) this._stream.Length : throw new ArgumentException("Stream is too large.", nameof (stream));
    this._data = new byte[this._length];
    this._stream.Read(this._data, 0, this._length);
  }

  internal byte GetByte(int offset)
  {
    byte num;
    if (this._currentOffset + offset >= this._length)
    {
      Debug.Assert(false);
      num = (byte) 0;
    }
    else
      num = this._data[this._currentOffset + offset];
    return num;
  }

  internal ushort GetWord(int offset, bool bigEndian)
  {
    return bigEndian ? (ushort) ((int) this.GetByte(offset) * 256 /*0x0100*/ + (int) this.GetByte(offset + 1)) : (ushort) ((int) this.GetByte(offset) + (int) this.GetByte(offset + 1) * 256 /*0x0100*/);
  }

  internal uint GetDWord(int offset, bool bigEndian)
  {
    return bigEndian ? (uint) this.GetWord(offset, true) * 65536U /*0x010000*/ + (uint) this.GetWord(offset + 2, true) : (uint) this.GetWord(offset, false) + (uint) this.GetWord(offset + 2, false) * 65536U /*0x010000*/;
  }

  private static void CopyStream(Stream input, Stream output)
  {
    byte[] buffer = new byte[65536 /*0x010000*/];
    int count;
    while ((count = input.Read(buffer, 0, buffer.Length)) > 0)
      output.Write(buffer, 0, count);
  }

  public void Reset() => this._currentOffset = 0;

  public Stream OriginalStream => this._stream;

  internal int CurrentOffset
  {
    get => this._currentOffset;
    set => this._currentOffset = value;
  }

  public byte[] Data => this._data;

  public int Length => this._length;
}
