// Decompiled with JetBrains decompiler
// Type: PdfSharp.Pdf.Advanced.BitReader
// Assembly: buFile, Version=1.50.4740.0, Culture=neutral, PublicKeyToken=f94615aa0424f9eb
// MVID: 1F93257A-1245-4898-8C4E-DC1AB39EF50B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buFile.dll

using System.Diagnostics;

#nullable disable
namespace PdfSharp.Pdf.Advanced;

internal class BitReader
{
  private readonly byte[] _imageBits;
  private uint _bytesOffsetRead;
  private readonly uint _bytesFileOffset;
  private byte _buffer;
  private uint _bitsInBuffer;
  private readonly uint _bitsTotal;

  internal BitReader(byte[] imageBits, uint bytesFileOffset, uint bits)
  {
    this._imageBits = imageBits;
    this._bytesFileOffset = bytesFileOffset;
    this._bitsTotal = bits;
    this._bytesOffsetRead = bytesFileOffset;
    this._buffer = imageBits[(int) this._bytesOffsetRead];
    this._bitsInBuffer = 8U;
  }

  internal void SetPosition(uint position)
  {
    this._bytesOffsetRead = this._bytesFileOffset + (position >> 3);
    this._buffer = this._imageBits[(int) this._bytesOffsetRead];
    this._bitsInBuffer = (uint) (8 - ((int) position & 7));
  }

  internal bool GetBit(uint position)
  {
    bool bit;
    if (position >= this._bitsTotal)
    {
      bit = false;
    }
    else
    {
      this.SetPosition(position);
      bit = ((int) this.PeekByte(out uint _) & 128 /*0x80*/) > 0;
    }
    return bit;
  }

  internal byte PeekByte(out uint bits)
  {
    byte num;
    if (this._bitsInBuffer == 8U)
    {
      bits = 8U;
      num = this._buffer;
    }
    else
    {
      bits = this._bitsInBuffer;
      num = (byte) ((uint) this._buffer << 8 - (int) this._bitsInBuffer);
    }
    return num;
  }

  internal void NextByte()
  {
    this._buffer = this._imageBits[(int) ++this._bytesOffsetRead];
    this._bitsInBuffer = 8U;
  }

  internal void SkipBits(uint bits)
  {
    Debug.Assert(bits <= this._bitsInBuffer, "Buffer underrun");
    if ((int) bits == (int) this._bitsInBuffer)
      this.NextByte();
    else
      this._bitsInBuffer -= bits;
  }
}
