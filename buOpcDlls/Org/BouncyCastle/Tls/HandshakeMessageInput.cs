// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Tls.HandshakeMessageInput
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Tls.Crypto;
using System;
using System.IO;

#nullable disable
namespace Org.BouncyCastle.Tls;

public sealed class HandshakeMessageInput : MemoryStream
{
  private readonly int m_offset;

  internal HandshakeMessageInput(byte[] buf, int offset, int length)
    : base(buf, offset, length, false, true)
  {
    this.m_offset = offset;
  }

  public void UpdateHash(TlsHash hash) => this.WriteTo((Stream) new TlsHashSink(hash));

  internal void UpdateHashPrefix(TlsHash hash, int bindersSize)
  {
    byte[] buffer = this.GetBuffer();
    int int32 = Convert.ToInt32(this.Length);
    hash.Update(buffer, this.m_offset, int32 - bindersSize);
  }

  internal void UpdateHashSuffix(TlsHash hash, int bindersSize)
  {
    byte[] buffer = this.GetBuffer();
    int int32 = Convert.ToInt32(this.Length);
    hash.Update(buffer, this.m_offset + int32 - bindersSize, bindersSize);
  }
}
