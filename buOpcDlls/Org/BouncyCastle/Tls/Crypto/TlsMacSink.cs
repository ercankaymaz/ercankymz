// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Tls.Crypto.TlsMacSink
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Utilities.IO;

#nullable disable
namespace Org.BouncyCastle.Tls.Crypto;

public class TlsMacSink : BaseOutputStream
{
  private readonly TlsMac m_mac;

  public TlsMacSink(TlsMac mac) => this.m_mac = mac;

  public virtual TlsMac Mac => this.m_mac;

  public override void Write(byte[] buffer, int offset, int count)
  {
    Streams.ValidateBufferArguments(buffer, offset, count);
    if (count <= 0)
      return;
    this.m_mac.Update(buffer, offset, count);
  }

  public override void WriteByte(byte value)
  {
    this.m_mac.Update(new byte[1]{ value }, 0, 1);
  }
}
