// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Tls.ProtocolName
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Utilities;
using System;
using System.IO;

#nullable disable
namespace Org.BouncyCastle.Tls;

public sealed class ProtocolName
{
  public static readonly ProtocolName Http_1_1 = ProtocolName.AsUtf8Encoding("http/1.1");
  public static readonly ProtocolName Spdy_1 = ProtocolName.AsUtf8Encoding("spdy/1");
  public static readonly ProtocolName Spdy_2 = ProtocolName.AsUtf8Encoding("spdy/2");
  public static readonly ProtocolName Spdy_3 = ProtocolName.AsUtf8Encoding("spdy/3");
  public static readonly ProtocolName Stun_Turn = ProtocolName.AsUtf8Encoding("stun.turn");
  public static readonly ProtocolName Stun_Nat_Discovery = ProtocolName.AsUtf8Encoding("stun.nat-discovery");
  public static readonly ProtocolName Http_2_Tls = ProtocolName.AsUtf8Encoding("h2");
  public static readonly ProtocolName Http_2_Tcp = ProtocolName.AsUtf8Encoding("h2c");
  public static readonly ProtocolName WebRtc = ProtocolName.AsUtf8Encoding("webrtc");
  public static readonly ProtocolName WebRtc_Confidential = ProtocolName.AsUtf8Encoding("c-webrtc");
  public static readonly ProtocolName Ftp = ProtocolName.AsUtf8Encoding("ftp");
  public static readonly ProtocolName Imap = ProtocolName.AsUtf8Encoding("imap");
  public static readonly ProtocolName Pop3 = ProtocolName.AsUtf8Encoding("pop3");
  public static readonly ProtocolName ManageSieve = ProtocolName.AsUtf8Encoding("managesieve");
  public static readonly ProtocolName Coap = ProtocolName.AsUtf8Encoding("coap");
  public static readonly ProtocolName Xmpp_Client = ProtocolName.AsUtf8Encoding("xmpp-client");
  public static readonly ProtocolName Xmpp_Server = ProtocolName.AsUtf8Encoding("xmpp-server");
  public static readonly ProtocolName Acme_Tls_1 = ProtocolName.AsUtf8Encoding("acme-tls/1");
  public static readonly ProtocolName Oasis_Mqtt = ProtocolName.AsUtf8Encoding("mqtt");
  public static readonly ProtocolName Dns_Over_Tls = ProtocolName.AsUtf8Encoding("dot");
  public static readonly ProtocolName Ntske_1 = ProtocolName.AsUtf8Encoding("ntske/1");
  public static readonly ProtocolName Sun_Rpc = ProtocolName.AsUtf8Encoding("sunrpc");
  public static readonly ProtocolName Http_3 = ProtocolName.AsUtf8Encoding("h3");
  public static readonly ProtocolName Smb_2 = ProtocolName.AsUtf8Encoding("smb");
  public static readonly ProtocolName Irc = ProtocolName.AsUtf8Encoding("irc");
  public static readonly ProtocolName Nntp_Reading = ProtocolName.AsUtf8Encoding("nntp");
  public static readonly ProtocolName Nntp_Transit = ProtocolName.AsUtf8Encoding("nnsp");
  public static readonly ProtocolName Dns_Over_Quic = ProtocolName.AsUtf8Encoding("doq");
  private readonly byte[] m_bytes;

  public static ProtocolName AsRawBytes(byte[] bytes) => new ProtocolName(Arrays.Clone(bytes));

  public static ProtocolName AsUtf8Encoding(string name)
  {
    return new ProtocolName(Strings.ToUtf8ByteArray(name));
  }

  private ProtocolName(byte[] bytes)
  {
    if (bytes == null)
      throw new ArgumentNullException(nameof (bytes));
    this.m_bytes = bytes.Length >= 1 && bytes.Length <= (int) byte.MaxValue ? bytes : throw new ArgumentException("must have length from 1 to 255", nameof (bytes));
  }

  public byte[] GetBytes() => Arrays.Clone(this.m_bytes);

  public string GetUtf8Decoding() => Strings.FromUtf8ByteArray(this.m_bytes);

  public void Encode(Stream output) => TlsUtilities.WriteOpaque8(this.m_bytes, output);

  public static ProtocolName Parse(Stream input)
  {
    return new ProtocolName(TlsUtilities.ReadOpaque8(input, 1));
  }

  public override bool Equals(object obj)
  {
    return obj is ProtocolName && Arrays.AreEqual(this.m_bytes, ((ProtocolName) obj).m_bytes);
  }

  public override int GetHashCode() => Arrays.GetHashCode(this.m_bytes);
}
