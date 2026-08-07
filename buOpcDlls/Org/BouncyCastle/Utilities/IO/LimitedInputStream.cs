// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Utilities.IO.LimitedInputStream
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.IO;

#nullable disable
namespace Org.BouncyCastle.Utilities.IO;

internal sealed class LimitedInputStream : BaseInputStream
{
  private readonly Stream m_stream;
  private long m_limit;

  internal LimitedInputStream(Stream stream, long limit)
  {
    this.m_stream = stream;
    this.m_limit = limit;
  }

  internal long CurrentLimit => this.m_limit;

  public override int Read(byte[] buffer, int offset, int count)
  {
    int num = this.m_stream.Read(buffer, offset, count);
    return num <= 0 || (this.m_limit -= (long) num) >= 0L ? num : throw new StreamOverflowException("Data Overflow");
  }

  public override int ReadByte()
  {
    int num = this.m_stream.ReadByte();
    return num < 0 || --this.m_limit >= 0L ? num : throw new StreamOverflowException("Data Overflow");
  }
}
