// Decompiled with JetBrains decompiler
// Type: PdfSharp.SharpZipLib.Zip.Compression.Streams.DeflaterOutputStream
// Assembly: buFile, Version=1.50.4740.0, Culture=neutral, PublicKeyToken=f94615aa0424f9eb
// MVID: 1F93257A-1245-4898-8C4E-DC1AB39EF50B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buFile.dll

using PdfSharp.SharpZipLib.Checksums;
using System;
using System.IO;

#nullable disable
namespace PdfSharp.SharpZipLib.Zip.Compression.Streams;

internal class DeflaterOutputStream : Stream
{
  private string password;
  private uint[] keys;
  private byte[] buffer_;
  protected Deflater deflater_;
  protected Stream baseOutputStream_;
  private bool isClosed_;
  private bool isStreamOwner_ = true;

  public DeflaterOutputStream(Stream baseOutputStream)
    : this(baseOutputStream, new Deflater(), 512 /*0x0200*/)
  {
  }

  public DeflaterOutputStream(Stream baseOutputStream, Deflater deflater)
    : this(baseOutputStream, deflater, 512 /*0x0200*/)
  {
  }

  public DeflaterOutputStream(Stream baseOutputStream, Deflater deflater, int bufferSize)
  {
    if (baseOutputStream == null)
      throw new ArgumentNullException(nameof (baseOutputStream));
    if (!baseOutputStream.CanWrite)
      throw new ArgumentException("Must support writing", nameof (baseOutputStream));
    if (deflater == null)
      throw new ArgumentNullException(nameof (deflater));
    if (bufferSize < 512 /*0x0200*/)
      throw new ArgumentOutOfRangeException(nameof (bufferSize));
    this.baseOutputStream_ = baseOutputStream;
    this.buffer_ = new byte[bufferSize];
    this.deflater_ = deflater;
  }

  public virtual void Finish()
  {
    this.deflater_.Finish();
    while (!this.deflater_.IsFinished)
    {
      int num = this.deflater_.Deflate(this.buffer_, 0, this.buffer_.Length);
      if (num > 0)
      {
        if (this.keys != null)
          this.EncryptBlock(this.buffer_, 0, num);
        this.baseOutputStream_.Write(this.buffer_, 0, num);
      }
      else
        break;
    }
    if (!this.deflater_.IsFinished)
      throw new SharpZipBaseException("Can't deflate all input?");
    this.baseOutputStream_.Flush();
    if (this.keys == null)
      return;
    this.keys = (uint[]) null;
  }

  public bool IsStreamOwner
  {
    get => this.isStreamOwner_;
    set => this.isStreamOwner_ = value;
  }

  public bool CanPatchEntries => this.baseOutputStream_.CanSeek;

  public string Password
  {
    get => this.password;
    set
    {
      if ((value == null ? 0 : (value.Length == 0 ? 1 : 0)) != 0)
        this.password = (string) null;
      else
        this.password = value;
    }
  }

  protected void EncryptBlock(byte[] buffer, int offset, int length)
  {
    for (int index = offset; index < offset + length; ++index)
    {
      byte ch = buffer[index];
      buffer[index] ^= this.EncryptByte();
      this.UpdateKeys(ch);
    }
  }

  protected void InitializePassword(string password)
  {
    this.keys = new uint[3]
    {
      305419896U,
      591751049U,
      878082192U
    };
    foreach (byte ch in ZipConstants.ConvertToArray(password))
      this.UpdateKeys(ch);
  }

  protected byte EncryptByte()
  {
    uint num = (uint) ((int) this.keys[2] & (int) ushort.MaxValue | 2);
    return (byte) (num * (num ^ 1U) >> 8);
  }

  protected void UpdateKeys(byte ch)
  {
    this.keys[0] = Crc32.ComputeCrc32(this.keys[0], ch);
    this.keys[1] = this.keys[1] + (uint) (byte) this.keys[0];
    this.keys[1] = (uint) ((int) this.keys[1] * 134775813 + 1);
    this.keys[2] = Crc32.ComputeCrc32(this.keys[2], (byte) (this.keys[1] >> 24));
  }

  protected void Deflate()
  {
    while (!this.deflater_.IsNeedingInput)
    {
      int num = this.deflater_.Deflate(this.buffer_, 0, this.buffer_.Length);
      if (num > 0)
      {
        if (this.keys != null)
          this.EncryptBlock(this.buffer_, 0, num);
        this.baseOutputStream_.Write(this.buffer_, 0, num);
      }
      else
        break;
    }
    if (!this.deflater_.IsNeedingInput)
      throw new SharpZipBaseException("DeflaterOutputStream can't deflate all input?");
  }

  public override bool CanRead => false;

  public override bool CanSeek => false;

  public override bool CanWrite => this.baseOutputStream_.CanWrite;

  public override long Length => this.baseOutputStream_.Length;

  public override long Position
  {
    get => this.baseOutputStream_.Position;
    set => throw new NotSupportedException("Position property not supported");
  }

  public override long Seek(long offset, SeekOrigin origin)
  {
    throw new NotSupportedException("DeflaterOutputStream Seek not supported");
  }

  public override void SetLength(long value)
  {
    throw new NotSupportedException("DeflaterOutputStream SetLength not supported");
  }

  public override int ReadByte()
  {
    throw new NotSupportedException("DeflaterOutputStream ReadByte not supported");
  }

  public override int Read(byte[] buffer, int offset, int count)
  {
    throw new NotSupportedException("DeflaterOutputStream Read not supported");
  }

  public override IAsyncResult BeginRead(
    byte[] buffer,
    int offset,
    int count,
    AsyncCallback callback,
    object state)
  {
    throw new NotSupportedException("DeflaterOutputStream BeginRead not currently supported");
  }

  public override IAsyncResult BeginWrite(
    byte[] buffer,
    int offset,
    int count,
    AsyncCallback callback,
    object state)
  {
    throw new NotSupportedException("BeginWrite is not supported");
  }

  public override void Flush()
  {
    this.deflater_.Flush();
    this.Deflate();
    this.baseOutputStream_.Flush();
  }

  public override void Close()
  {
    if (this.isClosed_)
      return;
    this.isClosed_ = true;
    try
    {
      this.Finish();
      this.keys = (uint[]) null;
    }
    finally
    {
      if (this.isStreamOwner_)
        this.baseOutputStream_.Close();
    }
  }

  private void GetAuthCodeIfAES()
  {
  }

  public override void WriteByte(byte value)
  {
    this.Write(new byte[1]{ value }, 0, 1);
  }

  public override void Write(byte[] buffer, int offset, int count)
  {
    this.deflater_.SetInput(buffer, offset, count);
    this.Deflate();
  }
}
