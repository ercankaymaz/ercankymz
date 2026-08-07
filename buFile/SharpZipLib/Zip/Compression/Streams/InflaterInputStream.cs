// Decompiled with JetBrains decompiler
// Type: PdfSharp.SharpZipLib.Zip.Compression.Streams.InflaterInputStream
// Assembly: buFile, Version=1.50.4740.0, Culture=neutral, PublicKeyToken=f94615aa0424f9eb
// MVID: 1F93257A-1245-4898-8C4E-DC1AB39EF50B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buFile.dll

using System;
using System.IO;

#nullable disable
namespace PdfSharp.SharpZipLib.Zip.Compression.Streams;

internal class InflaterInputStream : Stream
{
  protected Inflater inf;
  protected InflaterInputBuffer inputBuffer;
  private Stream baseInputStream;
  private bool isClosed;
  private bool isStreamOwner = true;

  public InflaterInputStream(Stream baseInputStream)
    : this(baseInputStream, new Inflater(), 4096 /*0x1000*/)
  {
  }

  public InflaterInputStream(Stream baseInputStream, Inflater inf)
    : this(baseInputStream, inf, 4096 /*0x1000*/)
  {
  }

  public InflaterInputStream(Stream baseInputStream, Inflater inflater, int bufferSize)
  {
    if (baseInputStream == null)
      throw new ArgumentNullException(nameof (baseInputStream));
    if (inflater == null)
      throw new ArgumentNullException(nameof (inflater));
    if (bufferSize <= 0)
      throw new ArgumentOutOfRangeException(nameof (bufferSize));
    this.baseInputStream = baseInputStream;
    this.inf = inflater;
    this.inputBuffer = new InflaterInputBuffer(baseInputStream, bufferSize);
  }

  public bool IsStreamOwner
  {
    get => this.isStreamOwner;
    set => this.isStreamOwner = value;
  }

  public long Skip(long count)
  {
    if (count <= 0L)
      throw new ArgumentOutOfRangeException(nameof (count));
    long num1;
    if (this.baseInputStream.CanSeek)
    {
      this.baseInputStream.Seek(count, SeekOrigin.Current);
      num1 = count;
    }
    else
    {
      int count1 = 2048 /*0x0800*/;
      if (count < 2048L /*0x0800*/)
        count1 = (int) count;
      byte[] buffer = new byte[count1];
      int num2 = 1;
      long num3;
      for (num3 = count; (num3 <= 0L ? 0 : (num2 > 0 ? 1 : 0)) != 0; num3 -= (long) num2)
      {
        if (num3 < (long) count1)
          count1 = (int) num3;
        num2 = this.baseInputStream.Read(buffer, 0, count1);
      }
      num1 = count - num3;
    }
    return num1;
  }

  protected void StopDecrypting()
  {
  }

  public virtual int Available => this.inf.IsFinished ? 0 : 1;

  protected void Fill()
  {
    if (this.inputBuffer.Available <= 0)
    {
      this.inputBuffer.Fill();
      if (this.inputBuffer.Available <= 0)
        throw new SharpZipBaseException("Unexpected EOF");
    }
    this.inputBuffer.SetInflaterInput(this.inf);
  }

  public override bool CanRead => this.baseInputStream.CanRead;

  public override bool CanSeek => false;

  public override bool CanWrite => false;

  public override long Length => (long) this.inputBuffer.RawLength;

  public override long Position
  {
    get => this.baseInputStream.Position;
    set => throw new NotSupportedException("InflaterInputStream Position not supported");
  }

  public override void Flush() => this.baseInputStream.Flush();

  public override long Seek(long offset, SeekOrigin origin)
  {
    throw new NotSupportedException("Seek not supported");
  }

  public override void SetLength(long value)
  {
    throw new NotSupportedException("InflaterInputStream SetLength not supported");
  }

  public override void Write(byte[] buffer, int offset, int count)
  {
    throw new NotSupportedException("InflaterInputStream Write not supported");
  }

  public override void WriteByte(byte value)
  {
    throw new NotSupportedException("InflaterInputStream WriteByte not supported");
  }

  public override IAsyncResult BeginWrite(
    byte[] buffer,
    int offset,
    int count,
    AsyncCallback callback,
    object state)
  {
    throw new NotSupportedException("InflaterInputStream BeginWrite not supported");
  }

  public override void Close()
  {
    if (this.isClosed)
      return;
    this.isClosed = true;
    if (!this.isStreamOwner)
      return;
    this.baseInputStream.Close();
  }

  public override int Read(byte[] buffer, int offset, int count)
  {
    if (this.inf.IsNeedingDictionary)
      throw new SharpZipBaseException("Need a dictionary");
    int count1 = count;
    while (true)
    {
      int num;
      do
      {
        num = this.inf.Inflate(buffer, offset, count1);
        offset += num;
        count1 -= num;
        if ((count1 == 0 ? 1 : (this.inf.IsFinished ? 1 : 0)) == 0)
        {
          if (this.inf.IsNeedingInput)
            goto label_4;
        }
        else
          goto label_10;
      }
      while (num != 0);
      break;
label_4:
      try
      {
        this.Fill();
      }
      catch (SharpZipBaseException ex)
      {
        if (ex.Message != "Unexpected EOF")
          throw;
        goto label_10;
      }
    }
    throw new ZipException("Don't know what to do");
label_10:
    return count - count1;
  }
}
