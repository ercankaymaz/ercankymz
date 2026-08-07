// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Utilities.IO.FilterStream
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

#nullable disable
namespace Org.BouncyCastle.Utilities.IO;

public class FilterStream : Stream
{
  protected readonly Stream s;

  public FilterStream(Stream s) => this.s = s ?? throw new ArgumentNullException(nameof (s));

  public override bool CanRead => this.s.CanRead;

  public override bool CanSeek => this.s.CanSeek;

  public override bool CanWrite => this.s.CanWrite;

  public override Task CopyToAsync(
    Stream destination,
    int bufferSize,
    CancellationToken cancellationToken)
  {
    return Streams.CopyToAsync(this.s, destination, bufferSize, cancellationToken);
  }

  public override void Flush() => this.s.Flush();

  public override long Length => this.s.Length;

  public override long Position
  {
    get => this.s.Position;
    set => this.s.Position = value;
  }

  public override int Read(byte[] buffer, int offset, int count)
  {
    return this.s.Read(buffer, offset, count);
  }

  public override int ReadByte() => this.s.ReadByte();

  public override long Seek(long offset, SeekOrigin origin) => this.s.Seek(offset, origin);

  public override void SetLength(long value) => this.s.SetLength(value);

  public override void Write(byte[] buffer, int offset, int count)
  {
    this.s.Write(buffer, offset, count);
  }

  public override void WriteByte(byte value) => this.s.WriteByte(value);

  protected void Detach(bool disposing) => base.Dispose(disposing);

  protected override void Dispose(bool disposing)
  {
    if (disposing)
      this.s.Dispose();
    base.Dispose(disposing);
  }
}
