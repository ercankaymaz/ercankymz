// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Utilities.IO.BaseOutputStream
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

#nullable disable
namespace Org.BouncyCastle.Utilities.IO;

public abstract class BaseOutputStream : Stream
{
  public sealed override bool CanRead => false;

  public sealed override bool CanSeek => false;

  public sealed override bool CanWrite => true;

  public override Task CopyToAsync(
    Stream destination,
    int bufferSize,
    CancellationToken cancellationToken)
  {
    throw new NotSupportedException();
  }

  public override void Flush()
  {
  }

  public sealed override long Length => throw new NotSupportedException();

  public sealed override long Position
  {
    get => throw new NotSupportedException();
    set => throw new NotSupportedException();
  }

  public sealed override int Read(byte[] buffer, int offset, int count)
  {
    throw new NotSupportedException();
  }

  public sealed override long Seek(long offset, SeekOrigin origin)
  {
    throw new NotSupportedException();
  }

  public sealed override void SetLength(long value) => throw new NotSupportedException();

  public override void Write(byte[] buffer, int offset, int count)
  {
    Streams.ValidateBufferArguments(buffer, offset, count);
    for (int index = 0; index < count; ++index)
      this.WriteByte(buffer[offset + index]);
  }

  public virtual void Write(params byte[] buffer) => this.Write(buffer, 0, buffer.Length);
}
