// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Tls.TlsStream
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Utilities.IO;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

#nullable disable
namespace Org.BouncyCastle.Tls;

internal class TlsStream : Stream
{
  private readonly TlsProtocol m_handler;

  internal TlsStream(TlsProtocol handler) => this.m_handler = handler;

  public override bool CanRead => true;

  public override bool CanSeek => false;

  public override bool CanWrite => true;

  public override Task CopyToAsync(
    Stream destination,
    int bufferSize,
    CancellationToken cancellationToken)
  {
    return Streams.CopyToAsync((Stream) this, destination, bufferSize, cancellationToken);
  }

  protected override void Dispose(bool disposing)
  {
    if (disposing)
      this.m_handler.Close();
    base.Dispose(disposing);
  }

  public override void Flush() => this.m_handler.Flush();

  public override long Length => throw new NotSupportedException();

  public override long Position
  {
    get => throw new NotSupportedException();
    set => throw new NotSupportedException();
  }

  public override int Read(byte[] buffer, int offset, int count)
  {
    return this.m_handler.ReadApplicationData(buffer, offset, count);
  }

  public override int ReadByte()
  {
    byte[] buffer = new byte[1];
    return this.m_handler.ReadApplicationData(buffer, 0, 1) > 0 ? (int) buffer[0] : -1;
  }

  public override long Seek(long offset, SeekOrigin origin) => throw new NotSupportedException();

  public override void SetLength(long value) => throw new NotSupportedException();

  public override void Write(byte[] buffer, int offset, int count)
  {
    this.m_handler.WriteApplicationData(buffer, offset, count);
  }

  public override void WriteByte(byte value)
  {
    this.m_handler.WriteApplicationData(new byte[1]{ value }, 0, 1);
  }
}
