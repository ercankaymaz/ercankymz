// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.IO.SignerStream
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

public sealed class SignerStream : Stream
{
  private readonly Stream m_stream;
  private readonly ISigner m_readSigner;
  private readonly ISigner m_writeSigner;

  public SignerStream(Stream stream, ISigner readSigner, ISigner writeSigner)
  {
    this.m_stream = stream;
    this.m_readSigner = readSigner;
    this.m_writeSigner = writeSigner;
  }

  public ISigner ReadSigner => this.m_readSigner;

  public ISigner WriteSigner => this.m_writeSigner;

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
    int inLen = this.m_stream.Read(buffer, offset, count);
    if (this.m_readSigner != null && inLen > 0)
      this.m_readSigner.BlockUpdate(buffer, offset, inLen);
    return inLen;
  }

  public override int ReadByte()
  {
    int input = this.m_stream.ReadByte();
    if (this.m_readSigner != null && input >= 0)
      this.m_readSigner.Update((byte) input);
    return input;
  }

  public override long Seek(long offset, SeekOrigin origin) => throw new NotSupportedException();

  public override void SetLength(long length) => throw new NotSupportedException();

  public override void Write(byte[] buffer, int offset, int count)
  {
    this.m_stream.Write(buffer, offset, count);
    if (this.m_writeSigner == null || count <= 0)
      return;
    this.m_writeSigner.BlockUpdate(buffer, offset, count);
  }

  public override void WriteByte(byte value)
  {
    this.m_stream.WriteByte(value);
    if (this.m_writeSigner == null)
      return;
    this.m_writeSigner.Update(value);
  }

  protected override void Dispose(bool disposing)
  {
    if (disposing)
      this.m_stream.Dispose();
    base.Dispose(disposing);
  }

  private Stream ReadSource => this.m_readSigner != null ? (Stream) this : this.m_stream;

  private Stream WriteDestination => this.m_writeSigner != null ? (Stream) this : this.m_stream;
}
