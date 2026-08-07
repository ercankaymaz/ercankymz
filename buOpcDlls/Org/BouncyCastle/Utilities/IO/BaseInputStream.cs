// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Utilities.IO.BaseInputStream
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

#nullable disable
namespace Org.BouncyCastle.Utilities.IO;

public abstract class BaseInputStream : Stream
{
  public sealed override bool CanRead => true;

  public sealed override bool CanSeek => false;

  public sealed override bool CanWrite => false;

  public override Task CopyToAsync(
    Stream destination,
    int bufferSize,
    CancellationToken cancellationToken)
  {
    return Streams.CopyToAsync((Stream) this, destination, bufferSize, cancellationToken);
  }

  public sealed override void Flush()
  {
  }

  public sealed override long Length => throw new NotSupportedException();

  public sealed override long Position
  {
    get => throw new NotSupportedException();
    set => throw new NotSupportedException();
  }

  public override int Read(byte[] buffer, int offset, int count)
  {
    Streams.ValidateBufferArguments(buffer, offset, count);
    int num1 = 0;
    try
    {
      int num2;
      for (; num1 < count; buffer[offset + num1++] = (byte) num2)
      {
        num2 = this.ReadByte();
        if (num2 < 0)
          break;
      }
    }
    catch (IOException ex)
    {
      if (num1 == 0)
        throw;
    }
    return num1;
  }

  public sealed override long Seek(long offset, SeekOrigin origin)
  {
    throw new NotSupportedException();
  }

  public sealed override void SetLength(long value) => throw new NotSupportedException();

  public sealed override void Write(byte[] buffer, int offset, int count)
  {
    throw new NotSupportedException();
  }
}
