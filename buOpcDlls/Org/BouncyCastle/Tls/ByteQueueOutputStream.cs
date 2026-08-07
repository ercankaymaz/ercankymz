// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Tls.ByteQueueOutputStream
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Utilities.IO;

#nullable disable
namespace Org.BouncyCastle.Tls;

public sealed class ByteQueueOutputStream : BaseOutputStream
{
  private readonly ByteQueue m_buffer;

  public ByteQueueOutputStream() => this.m_buffer = new ByteQueue();

  public ByteQueue Buffer => this.m_buffer;

  public override void Write(byte[] buffer, int offset, int count)
  {
    Streams.ValidateBufferArguments(buffer, offset, count);
    this.m_buffer.AddData(buffer, offset, count);
  }

  public override void WriteByte(byte value)
  {
    this.m_buffer.AddData(new byte[1]{ value }, 0, 1);
  }
}
