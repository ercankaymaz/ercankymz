// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.IO.MacSink
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Utilities.IO;

#nullable disable
namespace Org.BouncyCastle.Crypto.IO;

public sealed class MacSink : BaseOutputStream
{
  private readonly IMac m_mac;

  public MacSink(IMac mac) => this.m_mac = mac;

  public IMac Mac => this.m_mac;

  public override void Write(byte[] buffer, int offset, int count)
  {
    Streams.ValidateBufferArguments(buffer, offset, count);
    if (count <= 0)
      return;
    this.m_mac.BlockUpdate(buffer, offset, count);
  }

  public override void WriteByte(byte value) => this.m_mac.Update(value);
}
