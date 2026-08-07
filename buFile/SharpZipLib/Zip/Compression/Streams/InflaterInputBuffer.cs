// Decompiled with JetBrains decompiler
// Type: PdfSharp.SharpZipLib.Zip.Compression.Streams.InflaterInputBuffer
// Assembly: buFile, Version=1.50.4740.0, Culture=neutral, PublicKeyToken=f94615aa0424f9eb
// MVID: 1F93257A-1245-4898-8C4E-DC1AB39EF50B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buFile.dll

using System;
using System.IO;

#nullable disable
namespace PdfSharp.SharpZipLib.Zip.Compression.Streams;

internal class InflaterInputBuffer
{
  private int rawLength;
  private byte[] rawData;
  private int clearTextLength;
  private byte[] clearText;
  private int available;
  private Stream inputStream;

  public InflaterInputBuffer(Stream stream)
    : this(stream, 4096 /*0x1000*/)
  {
  }

  public InflaterInputBuffer(Stream stream, int bufferSize)
  {
    this.inputStream = stream;
    if (bufferSize < 1024 /*0x0400*/)
      bufferSize = 1024 /*0x0400*/;
    this.rawData = new byte[bufferSize];
    this.clearText = this.rawData;
  }

  public int RawLength => this.rawLength;

  public byte[] RawData => this.rawData;

  public int ClearTextLength => this.clearTextLength;

  public byte[] ClearText => this.clearText;

  public int Available
  {
    get => this.available;
    set => this.available = value;
  }

  public void SetInflaterInput(Inflater inflater)
  {
    if (this.available <= 0)
      return;
    inflater.SetInput(this.clearText, this.clearTextLength - this.available, this.available);
    this.available = 0;
  }

  public void Fill()
  {
    this.rawLength = 0;
    int num;
    for (int length = this.rawData.Length; length > 0; length -= num)
    {
      num = this.inputStream.Read(this.rawData, this.rawLength, length);
      if (num > 0)
        this.rawLength += num;
      else
        break;
    }
    this.clearTextLength = this.rawLength;
    this.available = this.clearTextLength;
  }

  public int ReadRawBuffer(byte[] buffer) => this.ReadRawBuffer(buffer, 0, buffer.Length);

  public int ReadRawBuffer(byte[] outBuffer, int offset, int length)
  {
    if (length < 0)
      throw new ArgumentOutOfRangeException(nameof (length));
    int destinationIndex = offset;
    int val1 = length;
    int num;
    while (val1 > 0)
    {
      if (this.available <= 0)
      {
        this.Fill();
        if (this.available <= 0)
        {
          num = 0;
          goto label_9;
        }
      }
      int length1 = Math.Min(val1, this.available);
      Array.Copy((Array) this.rawData, this.rawLength - this.available, (Array) outBuffer, destinationIndex, length1);
      destinationIndex += length1;
      val1 -= length1;
      this.available -= length1;
    }
    num = length;
label_9:
    return num;
  }

  public int ReadClearTextBuffer(byte[] outBuffer, int offset, int length)
  {
    if (length < 0)
      throw new ArgumentOutOfRangeException(nameof (length));
    int destinationIndex = offset;
    int val1 = length;
    int num;
    while (val1 > 0)
    {
      if (this.available <= 0)
      {
        this.Fill();
        if (this.available <= 0)
        {
          num = 0;
          goto label_9;
        }
      }
      int length1 = Math.Min(val1, this.available);
      Array.Copy((Array) this.clearText, this.clearTextLength - this.available, (Array) outBuffer, destinationIndex, length1);
      destinationIndex += length1;
      val1 -= length1;
      this.available -= length1;
    }
    num = length;
label_9:
    return num;
  }

  public int ReadLeByte()
  {
    if (this.available <= 0)
    {
      this.Fill();
      if (this.available <= 0)
        throw new ZipException("EOF in header");
    }
    byte num = this.rawData[this.rawLength - this.available];
    --this.available;
    return (int) num;
  }

  public int ReadLeShort() => this.ReadLeByte() | this.ReadLeByte() << 8;

  public int ReadLeInt() => this.ReadLeShort() | this.ReadLeShort() << 16 /*0x10*/;

  public long ReadLeLong()
  {
    return (long) (uint) this.ReadLeInt() | (long) this.ReadLeInt() << 32 /*0x20*/;
  }
}
