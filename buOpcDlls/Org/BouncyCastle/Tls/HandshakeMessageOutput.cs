// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Tls.HandshakeMessageOutput
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.IO;

#nullable disable
namespace Org.BouncyCastle.Tls;

internal sealed class HandshakeMessageOutput : MemoryStream
{
  internal static int GetLength(int bodyLength) => 4 + bodyLength;

  internal static void Send(TlsProtocol protocol, short handshakeType, byte[] body)
  {
    HandshakeMessageOutput handshakeMessageOutput = new HandshakeMessageOutput(handshakeType, body.Length);
    handshakeMessageOutput.Write(body, 0, body.Length);
    handshakeMessageOutput.Send(protocol);
  }

  internal HandshakeMessageOutput(short handshakeType)
    : this(handshakeType, 60)
  {
  }

  internal HandshakeMessageOutput(short handshakeType, int bodyLength)
    : base(HandshakeMessageOutput.GetLength(bodyLength))
  {
    TlsUtilities.CheckUint8(handshakeType);
    TlsUtilities.WriteUint8(handshakeType, (Stream) this);
    this.Seek(3L, SeekOrigin.Current);
  }

  internal void Send(TlsProtocol protocol)
  {
    int i = Convert.ToInt32(this.Length) - 4;
    TlsUtilities.CheckUint24(i);
    this.Seek(1L, SeekOrigin.Begin);
    TlsUtilities.WriteUint24(i, (Stream) this);
    byte[] buffer = this.GetBuffer();
    int int32 = Convert.ToInt32(this.Length);
    protocol.WriteHandshakeMessage(buffer, 0, int32);
    this.Dispose();
  }

  internal void PrepareClientHello(TlsHandshakeHash handshakeHash, int bindersSize)
  {
    int i = Convert.ToInt32(this.Length) - 4 + bindersSize;
    TlsUtilities.CheckUint24(i);
    this.Seek(1L, SeekOrigin.Begin);
    TlsUtilities.WriteUint24(i, (Stream) this);
    byte[] buffer = this.GetBuffer();
    int int32 = Convert.ToInt32(this.Length);
    handshakeHash.Update(buffer, 0, int32);
    this.Seek(0L, SeekOrigin.End);
  }

  internal void SendClientHello(
    TlsClientProtocol clientProtocol,
    TlsHandshakeHash handshakeHash,
    int bindersSize)
  {
    byte[] buffer = this.GetBuffer();
    int int32 = Convert.ToInt32(this.Length);
    if (bindersSize > 0)
      handshakeHash.Update(buffer, int32 - bindersSize, bindersSize);
    clientProtocol.WriteHandshakeMessage(buffer, 0, int32);
    this.Dispose();
  }
}
