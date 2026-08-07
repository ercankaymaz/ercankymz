// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Tls.ByteQueueInputStream
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Utilities.IO;
using System;

#nullable disable
namespace Org.BouncyCastle.Tls;

public sealed class ByteQueueInputStream : BaseInputStream
{
  private readonly ByteQueue m_buffer;

  public ByteQueueInputStream() => this.m_buffer = new ByteQueue();

  public void AddBytes(byte[] buf) => this.m_buffer.AddData(buf, 0, buf.Length);

  public void AddBytes(byte[] buf, int bufOff, int bufLen)
  {
    this.m_buffer.AddData(buf, bufOff, bufLen);
  }

  public int Peek(byte[] buf)
  {
    int len = Math.Min(this.m_buffer.Available, buf.Length);
    this.m_buffer.Read(buf, 0, len, 0);
    return len;
  }

  public override int Read(byte[] buffer, int offset, int count)
  {
    Streams.ValidateBufferArguments(buffer, offset, count);
    int len = Math.Min(this.m_buffer.Available, count);
    this.m_buffer.RemoveData(buffer, offset, len, 0);
    return len;
  }

  public override int ReadByte()
  {
    return this.m_buffer.Available == 0 ? -1 : (int) this.m_buffer.RemoveData(1, 0)[0];
  }

  public long Skip(long n)
  {
    int i = Math.Min((int) n, this.m_buffer.Available);
    this.m_buffer.RemoveData(i);
    return (long) i;
  }

  public int Available => this.m_buffer.Available;
}
