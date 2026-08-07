// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Tls.Crypto.TlsEncodeResult
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

#nullable disable
namespace Org.BouncyCastle.Tls.Crypto;

public sealed class TlsEncodeResult
{
  public readonly byte[] buf;
  public readonly int off;
  public readonly int len;
  public readonly short recordType;

  public TlsEncodeResult(byte[] buf, int off, int len, short recordType)
  {
    this.buf = buf;
    this.off = off;
    this.len = len;
    this.recordType = recordType;
  }
}
