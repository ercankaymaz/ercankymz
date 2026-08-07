// Decompiled with JetBrains decompiler
// Type: PdfSharp.SharpZipLib.Zip.Compression.Streams.OutputWindow
// Assembly: buFile, Version=1.50.4740.0, Culture=neutral, PublicKeyToken=f94615aa0424f9eb
// MVID: 1F93257A-1245-4898-8C4E-DC1AB39EF50B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buFile.dll

using System;

#nullable disable
namespace PdfSharp.SharpZipLib.Zip.Compression.Streams;

internal class OutputWindow
{
  private const int WindowSize = 32768 /*0x8000*/;
  private const int WindowMask = 32767 /*0x7FFF*/;
  private byte[] window = new byte[32768 /*0x8000*/];
  private int windowEnd;
  private int windowFilled;

  public void Write(int value)
  {
    if (this.windowFilled++ == 32768 /*0x8000*/)
      throw new InvalidOperationException("Window full");
    this.window[this.windowEnd++] = (byte) value;
    this.windowEnd &= (int) short.MaxValue;
  }

  private void SlowRepeat(int repStart, int length, int distance)
  {
    while (length-- > 0)
    {
      this.window[this.windowEnd++] = this.window[repStart++];
      this.windowEnd &= (int) short.MaxValue;
      repStart &= (int) short.MaxValue;
    }
  }

  public void Repeat(int length, int distance)
  {
    if ((this.windowFilled += length) > 32768 /*0x8000*/)
      throw new InvalidOperationException("Window full");
    int num1 = this.windowEnd - distance & (int) short.MaxValue;
    int num2 = 32768 /*0x8000*/ - length;
    if ((num1 > num2 ? 0 : (this.windowEnd < num2 ? 1 : 0)) != 0)
    {
      if (length <= distance)
      {
        Array.Copy((Array) this.window, num1, (Array) this.window, this.windowEnd, length);
        this.windowEnd += length;
      }
      else
      {
        while (length-- > 0)
          this.window[this.windowEnd++] = this.window[num1++];
      }
    }
    else
      this.SlowRepeat(num1, length, distance);
  }

  public int CopyStored(StreamManipulator input, int length)
  {
    length = Math.Min(Math.Min(length, 32768 /*0x8000*/ - this.windowFilled), input.AvailableBytes);
    int length1 = 32768 /*0x8000*/ - this.windowEnd;
    int num;
    if (length > length1)
    {
      num = input.CopyBytes(this.window, this.windowEnd, length1);
      if (num == length1)
        num += input.CopyBytes(this.window, 0, length - length1);
    }
    else
      num = input.CopyBytes(this.window, this.windowEnd, length);
    this.windowEnd = this.windowEnd + num & (int) short.MaxValue;
    this.windowFilled += num;
    return num;
  }

  public void CopyDict(byte[] dictionary, int offset, int length)
  {
    if (dictionary == null)
      throw new ArgumentNullException(nameof (dictionary));
    if (this.windowFilled > 0)
      throw new InvalidOperationException();
    if (length > 32768 /*0x8000*/)
    {
      offset += length - 32768 /*0x8000*/;
      length = 32768 /*0x8000*/;
    }
    Array.Copy((Array) dictionary, offset, (Array) this.window, 0, length);
    this.windowEnd = length & (int) short.MaxValue;
  }

  public int GetFreeSpace() => 32768 /*0x8000*/ - this.windowFilled;

  public int GetAvailable() => this.windowFilled;

  public int CopyOutput(byte[] output, int offset, int len)
  {
    int num1 = this.windowEnd;
    if (len > this.windowFilled)
      len = this.windowFilled;
    else
      num1 = this.windowEnd - this.windowFilled + len & (int) short.MaxValue;
    int num2 = len;
    int length = len - num1;
    if (length > 0)
    {
      Array.Copy((Array) this.window, 32768 /*0x8000*/ - length, (Array) output, offset, length);
      offset += length;
      len = num1;
    }
    Array.Copy((Array) this.window, num1 - len, (Array) output, offset, len);
    this.windowFilled -= num2;
    if (this.windowFilled < 0)
      throw new InvalidOperationException();
    return num2;
  }

  public void Reset()
  {
    this.windowEnd = 0;
    this.windowFilled = 0;
  }
}
