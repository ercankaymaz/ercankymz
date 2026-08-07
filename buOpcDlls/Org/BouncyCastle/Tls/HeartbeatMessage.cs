// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Tls.HeartbeatMessage
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Utilities;
using Org.BouncyCastle.Utilities.IO;
using System;
using System.IO;

#nullable disable
namespace Org.BouncyCastle.Tls;

public sealed class HeartbeatMessage
{
  private readonly short m_type;
  private readonly byte[] m_payload;
  private readonly byte[] m_padding;

  public static HeartbeatMessage Create(TlsContext context, short type, byte[] payload)
  {
    return HeartbeatMessage.Create(context, type, payload, 16 /*0x10*/);
  }

  public static HeartbeatMessage Create(
    TlsContext context,
    short type,
    byte[] payload,
    int paddingLength)
  {
    byte[] nonce = context.NonceGenerator.GenerateNonce(paddingLength);
    return new HeartbeatMessage(type, payload, nonce);
  }

  public HeartbeatMessage(short type, byte[] payload, byte[] padding)
  {
    if (!HeartbeatMessageType.IsValid(type))
      throw new ArgumentException("not a valid HeartbeatMessageType value", nameof (type));
    if (payload == null || payload.Length >= 65536 /*0x010000*/)
      throw new ArgumentException("must have length < 2^16", nameof (payload));
    if (padding == null || padding.Length < 16 /*0x10*/)
      throw new ArgumentException("must have length >= 16", nameof (padding));
    this.m_type = type;
    this.m_payload = payload;
    this.m_padding = padding;
  }

  public int PaddingLength => this.m_padding.Length;

  public byte[] Payload => this.m_payload;

  public short Type => this.m_type;

  public void Encode(Stream output)
  {
    TlsUtilities.WriteUint8(this.m_type, output);
    TlsUtilities.CheckUint16(this.m_payload.Length);
    TlsUtilities.WriteUint16(this.m_payload.Length, output);
    output.Write(this.m_payload, 0, this.m_payload.Length);
    output.Write(this.m_padding, 0, this.m_padding.Length);
  }

  public static HeartbeatMessage Parse(Stream input)
  {
    short num = TlsUtilities.ReadUint8(input);
    if (!HeartbeatMessageType.IsValid(num))
      throw new TlsFatalAlert((short) 47);
    int payloadLength = TlsUtilities.ReadUint16(input);
    byte[] payloadBuffer = Streams.ReadAll(input);
    byte[] payload = HeartbeatMessage.GetPayload(payloadBuffer, payloadLength);
    if (payload == null)
      return (HeartbeatMessage) null;
    byte[] padding = HeartbeatMessage.GetPadding(payloadBuffer, payloadLength);
    return new HeartbeatMessage(num, payload, padding);
  }

  private static byte[] GetPayload(byte[] payloadBuffer, int payloadLength)
  {
    int num = payloadBuffer.Length - 16 /*0x10*/;
    return payloadLength > num ? (byte[]) null : Arrays.CopyOf(payloadBuffer, payloadLength);
  }

  private static byte[] GetPadding(byte[] payloadBuffer, int payloadLength)
  {
    return TlsUtilities.CopyOfRangeExact(payloadBuffer, payloadLength, payloadBuffer.Length);
  }
}
