// Decompiled with JetBrains decompiler
// Type: PdfSharp.Pdf.Advanced.BitWriter
// Assembly: buFile, Version=1.50.4740.0, Culture=neutral, PublicKeyToken=f94615aa0424f9eb
// MVID: 1F93257A-1245-4898-8C4E-DC1AB39EF50B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buFile.dll

using System;

#nullable disable
namespace PdfSharp.Pdf.Advanced;

internal class BitWriter
{
  private static readonly uint[] masks = new uint[9]
  {
    0U,
    1U,
    3U,
    7U,
    15U,
    31U /*0x1F*/,
    63U /*0x3F*/,
    (uint) sbyte.MaxValue,
    (uint) byte.MaxValue
  };
  private int _bytesOffsetWrite;
  private readonly byte[] _imageData;
  private uint _buffer;
  private uint _bitsInBuffer;

  internal BitWriter(ref byte[] imageData) => this._imageData = imageData;

  internal void FlushBuffer()
  {
    if (this._bitsInBuffer <= 0U)
      return;
    this.WriteBits(0U, 8U - this._bitsInBuffer);
  }

  internal void WriteBits(uint value, uint bits)
  {
    uint num;
    for (; bits + this._bitsInBuffer > 8U; bits = num)
    {
      uint bits1 = 8U - this._bitsInBuffer;
      num = bits - bits1;
      this.WriteBits(value >> (int) num, bits1);
    }
    this._buffer = (uint) (((int) this._buffer << (int) bits) + ((int) value & (int) BitWriter.masks[(int) bits]));
    this._bitsInBuffer += bits;
    if (this._bitsInBuffer != 8U)
      return;
    this._imageData[this._bytesOffsetWrite] = (byte) this._buffer;
    this._bitsInBuffer = 0U;
    ++this._bytesOffsetWrite;
  }

  internal void WriteTableLine(uint[] table, uint line)
  {
    this.WriteBits(table[(int) line * 2], table[(int) line * 2 + 1]);
  }

  [Obsolete]
  internal void WriteEOL() => this.WriteTableLine(PdfImage.WhiteMakeUpCodes, 40U);

  internal int BytesWritten()
  {
    this.FlushBuffer();
    return this._bytesOffsetWrite;
  }
}
