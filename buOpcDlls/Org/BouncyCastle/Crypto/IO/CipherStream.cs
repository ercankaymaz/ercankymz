// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.IO.CipherStream
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Utilities.IO;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

#nullable disable
namespace Org.BouncyCastle.Crypto.IO;

public sealed class CipherStream : Stream
{
  private readonly Stream m_stream;
  private readonly IBufferedCipher m_readCipher;
  private readonly IBufferedCipher m_writeCipher;
  private byte[] m_readBuf;
  private int m_readBufPos;
  private bool m_readEnded;

  public CipherStream(Stream stream, IBufferedCipher readCipher, IBufferedCipher writeCipher)
  {
    this.m_stream = stream;
    if (readCipher != null)
    {
      this.m_readCipher = readCipher;
      this.m_readBuf = (byte[]) null;
    }
    if (writeCipher == null)
      return;
    this.m_writeCipher = writeCipher;
  }

  public IBufferedCipher ReadCipher => this.m_readCipher;

  public IBufferedCipher WriteCipher => this.m_writeCipher;

  public override bool CanRead => this.m_stream.CanRead;

  public override bool CanSeek => false;

  public override bool CanWrite => this.m_stream.CanWrite;

  public override Task CopyToAsync(
    Stream destination,
    int bufferSize,
    CancellationToken cancellationToken)
  {
    return Streams.CopyToAsync(this.ReadSource, destination, bufferSize, cancellationToken);
  }

  public override void Flush() => this.m_stream.Flush();

  public override long Length => throw new NotSupportedException();

  public override long Position
  {
    get => throw new NotSupportedException();
    set => throw new NotSupportedException();
  }

  public override int Read(byte[] buffer, int offset, int count)
  {
    if (this.m_readCipher == null)
      return this.m_stream.Read(buffer, offset, count);
    Streams.ValidateBufferArguments(buffer, offset, count);
    int num;
    int length;
    for (num = 0; num < count && (this.m_readBuf != null && this.m_readBufPos < this.m_readBuf.Length || this.FillInBuf()); num += length)
    {
      length = Math.Min(count - num, this.m_readBuf.Length - this.m_readBufPos);
      Array.Copy((Array) this.m_readBuf, this.m_readBufPos, (Array) buffer, offset + num, length);
      this.m_readBufPos += length;
    }
    return num;
  }

  public override int ReadByte()
  {
    if (this.m_readCipher == null)
      return this.m_stream.ReadByte();
    return (this.m_readBuf == null || this.m_readBufPos >= this.m_readBuf.Length) && !this.FillInBuf() ? -1 : (int) this.m_readBuf[this.m_readBufPos++];
  }

  public override long Seek(long offset, SeekOrigin origin) => throw new NotSupportedException();

  public override void SetLength(long length) => throw new NotSupportedException();

  public override void Write(byte[] buffer, int offset, int count)
  {
    if (this.m_writeCipher == null)
    {
      this.m_stream.Write(buffer, offset, count);
    }
    else
    {
      Streams.ValidateBufferArguments(buffer, offset, count);
      if (count < 1)
        return;
      int updateOutputSize = this.m_writeCipher.GetUpdateOutputSize(count);
      byte[] numArray = (byte[]) null;
      if (updateOutputSize > 0)
        numArray = new byte[updateOutputSize];
      try
      {
        int count1 = this.m_writeCipher.ProcessBytes(buffer, offset, count, numArray, 0);
        if (count1 <= 0)
          return;
        this.m_stream.Write(numArray, 0, count1);
      }
      finally
      {
        if (numArray != null)
          Array.Clear((Array) numArray, 0, numArray.Length);
      }
    }
  }

  public override void WriteByte(byte value)
  {
    if (this.m_writeCipher == null)
    {
      this.m_stream.WriteByte(value);
    }
    else
    {
      byte[] buffer = this.m_writeCipher.ProcessByte(value);
      if (buffer == null)
        return;
      this.m_stream.Write(buffer, 0, buffer.Length);
    }
  }

  protected override void Dispose(bool disposing)
  {
    if (disposing)
    {
      if (this.m_writeCipher != null)
      {
        byte[] numArray = new byte[this.m_writeCipher.GetOutputSize(0)];
        int count = this.m_writeCipher.DoFinal(numArray, 0);
        this.m_stream.Write(numArray, 0, count);
        Array.Clear((Array) numArray, 0, numArray.Length);
      }
      this.m_stream.Dispose();
    }
    base.Dispose(disposing);
  }

  private bool FillInBuf()
  {
    if (this.m_readEnded)
      return false;
    this.m_readBufPos = 0;
    do
    {
      this.m_readBuf = this.ReadAndProcessBlock();
    }
    while (!this.m_readEnded && this.m_readBuf == null);
    return this.m_readBuf != null;
  }

  private byte[] ReadAndProcessBlock()
  {
    int blockSize = this.m_readCipher.GetBlockSize();
    byte[] numArray1 = new byte[blockSize == 0 ? 256 /*0x0100*/ : blockSize];
    int num1 = 0;
    do
    {
      int num2 = this.m_stream.Read(numArray1, num1, numArray1.Length - num1);
      if (num2 >= 1)
        num1 += num2;
      else
        goto label_3;
    }
    while (num1 < numArray1.Length);
    goto label_4;
label_3:
    this.m_readEnded = true;
label_4:
    byte[] numArray2 = this.m_readEnded ? this.m_readCipher.DoFinal(numArray1, 0, num1) : this.m_readCipher.ProcessBytes(numArray1);
    if (numArray2 != null && numArray2.Length == 0)
      numArray2 = (byte[]) null;
    return numArray2;
  }

  private Stream ReadSource => this.m_readCipher != null ? (Stream) this : this.m_stream;

  private Stream WriteDestination => this.m_writeCipher != null ? (Stream) this : this.m_stream;
}
