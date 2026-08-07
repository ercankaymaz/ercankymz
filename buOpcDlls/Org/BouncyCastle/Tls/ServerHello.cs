// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Tls.ServerHello
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Utilities;
using System.Collections.Generic;
using System.IO;

#nullable disable
namespace Org.BouncyCastle.Tls;

public sealed class ServerHello
{
  private static readonly byte[] HelloRetryRequestMagic = new byte[32 /*0x20*/]
  {
    (byte) 207,
    (byte) 33,
    (byte) 173,
    (byte) 116,
    (byte) 229,
    (byte) 154,
    (byte) 97,
    (byte) 17,
    (byte) 190,
    (byte) 29,
    (byte) 140,
    (byte) 2,
    (byte) 30,
    (byte) 101,
    (byte) 184,
    (byte) 145,
    (byte) 194,
    (byte) 162,
    (byte) 17,
    (byte) 22,
    (byte) 122,
    (byte) 187,
    (byte) 140,
    (byte) 94,
    (byte) 7,
    (byte) 158,
    (byte) 9,
    (byte) 226,
    (byte) 200,
    (byte) 168,
    (byte) 51,
    (byte) 156
  };
  private readonly ProtocolVersion m_version;
  private readonly byte[] m_random;
  private readonly byte[] m_sessionID;
  private readonly int m_cipherSuite;
  private readonly IDictionary<int, byte[]> m_extensions;

  public ServerHello(byte[] sessionID, int cipherSuite, IDictionary<int, byte[]> extensions)
    : this(ProtocolVersion.TLSv12, Arrays.Clone(ServerHello.HelloRetryRequestMagic), sessionID, cipherSuite, extensions)
  {
  }

  public ServerHello(
    ProtocolVersion version,
    byte[] random,
    byte[] sessionID,
    int cipherSuite,
    IDictionary<int, byte[]> extensions)
  {
    this.m_version = version;
    this.m_random = random;
    this.m_sessionID = sessionID;
    this.m_cipherSuite = cipherSuite;
    this.m_extensions = extensions;
  }

  public int CipherSuite => this.m_cipherSuite;

  public IDictionary<int, byte[]> Extensions => this.m_extensions;

  public byte[] Random => this.m_random;

  public byte[] SessionID => this.m_sessionID;

  public ProtocolVersion Version => this.m_version;

  public bool IsHelloRetryRequest()
  {
    return Arrays.AreEqual(ServerHello.HelloRetryRequestMagic, this.m_random);
  }

  public void Encode(TlsContext context, Stream output)
  {
    TlsUtilities.WriteVersion(this.m_version, output);
    output.Write(this.m_random, 0, this.m_random.Length);
    TlsUtilities.WriteOpaque8(this.m_sessionID, output);
    TlsUtilities.WriteUint16(this.m_cipherSuite, output);
    TlsUtilities.WriteUint8((short) 0, output);
    TlsProtocol.WriteExtensions(output, this.m_extensions);
  }

  public static ServerHello Parse(MemoryStream input)
  {
    ProtocolVersion version = TlsUtilities.ReadVersion((Stream) input);
    byte[] numArray1 = TlsUtilities.ReadFully(32 /*0x20*/, (Stream) input);
    byte[] numArray2 = TlsUtilities.ReadOpaque8((Stream) input, 0, 32 /*0x20*/);
    int num = TlsUtilities.ReadUint16((Stream) input);
    IDictionary<int, byte[]> dictionary = TlsUtilities.ReadUint8((Stream) input) == (short) 0 ? TlsProtocol.ReadExtensions(input) : throw new TlsFatalAlert((short) 47);
    byte[] random = numArray1;
    byte[] sessionID = numArray2;
    int cipherSuite = num;
    IDictionary<int, byte[]> extensions = dictionary;
    return new ServerHello(version, random, sessionID, cipherSuite, extensions);
  }
}
