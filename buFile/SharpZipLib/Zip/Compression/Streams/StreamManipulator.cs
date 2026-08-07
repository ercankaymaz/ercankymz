// Decompiled with JetBrains decompiler
// Type: PdfSharp.SharpZipLib.Zip.Compression.Streams.StreamManipulator
// Assembly: buFile, Version=1.50.4740.0, Culture=neutral, PublicKeyToken=f94615aa0424f9eb
// MVID: 1F93257A-1245-4898-8C4E-DC1AB39EF50B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buFile.dll

using System;

#nullable disable
namespace PdfSharp.SharpZipLib.Zip.Compression.Streams;

internal class StreamManipulator
{
  private byte[] window_;
  private int windowStart_;
  private int windowEnd_;
  private uint buffer_;
  private int bitsInBuffer_;

  public int PeekBits(int bitCount)
  {
    int num;
    if (this.bitsInBuffer_ < bitCount)
    {
      if (this.windowStart_ == this.windowEnd_)
      {
        num = -1;
        goto label_5;
      }
      this.buffer_ |= (uint) (((int) this.window_[this.windowStart_++] & (int) byte.MaxValue | ((int) this.window_[this.windowStart_++] & (int) byte.MaxValue) << 8) << this.bitsInBuffer_);
      this.bitsInBuffer_ += 16 /*0x10*/;
    }
    num = (int) ((long) this.buffer_ & (long) ((1 << bitCount) - 1));
label_5:
    return num;
  }

  public void DropBits(int bitCount)
  {
    this.buffer_ >>= bitCount;
    this.bitsInBuffer_ -= bitCount;
  }

  public int GetBits(int bitCount)
  {
    int bits = this.PeekBits(bitCount);
    if (bits >= 0)
      this.DropBits(bitCount);
    return bits;
  }

  public int AvailableBits => this.bitsInBuffer_;

  public int AvailableBytes => this.windowEnd_ - this.windowStart_ + (this.bitsInBuffer_ >> 3);

  public void SkipToByteBoundary()
  {
    this.buffer_ >>= this.bitsInBuffer_ & 7;
    this.bitsInBuffer_ &= -8;
  }

  public bool IsNeedingInput => this.windowStart_ == this.windowEnd_;

  public int CopyBytes(byte[] output, int offset, int length)
  {
    if (length < 0)
      throw new ArgumentOutOfRangeException(nameof (length));
    if ((this.bitsInBuffer_ & 7) != 0)
      throw new InvalidOperationException("Bit buffer is not byte aligned!");
    int num1 = 0;
    while ((this.bitsInBuffer_ <= 0 ? 0 : (length > 0 ? 1 : 0)) != 0)
    {
      output[offset++] = (byte) this.buffer_;
      this.buffer_ >>= 8;
      this.bitsInBuffer_ -= 8;
      --length;
      ++num1;
    }
    int num2;
    if (length == 0)
    {
      num2 = num1;
    }
    else
    {
      int num3 = this.windowEnd_ - this.windowStart_;
      if (length > num3)
        length = num3;
      Array.Copy((Array) this.window_, this.windowStart_, (Array) output, offset, length);
      this.windowStart_ += length;
      if ((this.windowStart_ - this.windowEnd_ & 1) != 0)
      {
        this.buffer_ = (uint) this.window_[this.windowStart_++] & (uint) byte.MaxValue;
        this.bitsInBuffer_ = 8;
      }
      num2 = num1 + length;
    }
    return num2;
  }

  public void Reset()
  {
    this.buffer_ = 0U;
    this.bitsInBuffer_ = 0;
    this.windowEnd_ = 0;
    this.windowStart_ = 0;
  }

  public void SetInput(byte[] buffer, int offset, int count)
  {
    if (buffer == null)
      throw new ArgumentNullException(nameof (buffer));
    if (offset < 0)
      throw new ArgumentOutOfRangeException(nameof (offset), "Cannot be negative");
    if (count < 0)
      throw new ArgumentOutOfRangeException(nameof (count), "Cannot be negative");
    if (this.windowStart_ < this.windowEnd_)
      throw new InvalidOperationException("Old input was not completely processed");
    int num = offset + count;
    if ((offset > num ? 1 : (num > buffer.Length ? 1 : 0)) != 0)
      throw new ArgumentOutOfRangeException(nameof (count));
    if ((count & 1) != 0)
    {
      this.buffer_ |= (uint) (((int) buffer[offset++] & (int) byte.MaxValue) << this.bitsInBuffer_);
      this.bitsInBuffer_ += 8;
    }
    this.window_ = buffer;
    this.windowStart_ = offset;
    this.windowEnd_ = num;
  }
}
