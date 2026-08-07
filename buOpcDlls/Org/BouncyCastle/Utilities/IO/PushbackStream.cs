// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Utilities.IO.PushbackStream
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

#nullable disable
namespace Org.BouncyCastle.Utilities.IO;

public class PushbackStream(Stream s) : FilterStream(s)
{
  private int m_buf = -1;

  public override async Task CopyToAsync(
    Stream destination,
    int bufferSize,
    CancellationToken cancellationToken)
  {
    PushbackStream pushbackStream = this;
    if (pushbackStream.m_buf != -1)
    {
      byte[] buffer = new byte[1]
      {
        (byte) pushbackStream.m_buf
      };
      await destination.WriteAsync(buffer, 0, 1, cancellationToken).ConfigureAwait(false);
      pushbackStream.m_buf = -1;
    }
    await Streams.CopyToAsync(pushbackStream.s, destination, bufferSize, cancellationToken);
  }

  public override int Read(byte[] buffer, int offset, int count)
  {
    Streams.ValidateBufferArguments(buffer, offset, count);
    if (this.m_buf == -1)
      return this.s.Read(buffer, offset, count);
    if (count < 1)
      return 0;
    buffer[offset] = (byte) this.m_buf;
    this.m_buf = -1;
    return 1;
  }

  public override int ReadByte()
  {
    if (this.m_buf == -1)
      return this.s.ReadByte();
    int buf = this.m_buf;
    this.m_buf = -1;
    return buf;
  }

  public virtual void Unread(int b)
  {
    if (this.m_buf != -1)
      throw new InvalidOperationException("Can only push back one byte");
    this.m_buf = b & (int) byte.MaxValue;
  }
}
