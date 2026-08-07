// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Tls.ClientHello
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Utilities;
using Org.BouncyCastle.Utilities.IO;
using System;
using System.Collections.Generic;
using System.IO;

#nullable disable
namespace Org.BouncyCastle.Tls;

public sealed class ClientHello
{
  private readonly ProtocolVersion m_version;
  private readonly byte[] m_random;
  private readonly byte[] m_sessionID;
  private readonly byte[] m_cookie;
  private readonly int[] m_cipherSuites;
  private readonly IDictionary<int, byte[]> m_extensions;
  private readonly int m_bindersSize;

  public ClientHello(
    ProtocolVersion version,
    byte[] random,
    byte[] sessionID,
    byte[] cookie,
    int[] cipherSuites,
    IDictionary<int, byte[]> extensions,
    int bindersSize)
  {
    this.m_version = version;
    this.m_random = random;
    this.m_sessionID = sessionID;
    this.m_cookie = cookie;
    this.m_cipherSuites = cipherSuites;
    this.m_extensions = extensions;
    this.m_bindersSize = bindersSize;
  }

  public int BindersSize => this.m_bindersSize;

  public int[] CipherSuites => this.m_cipherSuites;

  public byte[] Cookie => this.m_cookie;

  public IDictionary<int, byte[]> Extensions => this.m_extensions;

  public byte[] Random => this.m_random;

  public byte[] SessionID => this.m_sessionID;

  public ProtocolVersion Version => this.m_version;

  public void Encode(TlsContext context, Stream output)
  {
    if (this.m_bindersSize < 0)
      throw new TlsFatalAlert((short) 80 /*0x50*/);
    TlsUtilities.WriteVersion(this.m_version, output);
    output.Write(this.m_random, 0, this.m_random.Length);
    TlsUtilities.WriteOpaque8(this.m_sessionID, output);
    if (this.m_cookie != null)
      TlsUtilities.WriteOpaque8(this.m_cookie, output);
    TlsUtilities.WriteUint16ArrayWithUint16Length(this.m_cipherSuites, output);
    TlsUtilities.WriteUint8ArrayWithUint8Length(new short[1], output);
    TlsProtocol.WriteExtensions(output, this.m_extensions, this.m_bindersSize);
  }

  public static ClientHello Parse(MemoryStream messageInput, Stream dtlsOutput)
  {
    try
    {
      return ClientHello.ImplParse(messageInput, dtlsOutput);
    }
    catch (TlsFatalAlert ex)
    {
      throw;
    }
    catch (IOException ex)
    {
      throw new TlsFatalAlert((short) 50, (Exception) ex);
    }
  }

  private static ClientHello ImplParse(MemoryStream messageInput, Stream dtlsOutput)
  {
    Stream input = (Stream) messageInput;
    if (dtlsOutput != null)
      input = (Stream) new TeeInputStream(input, dtlsOutput);
    ProtocolVersion version = TlsUtilities.ReadVersion(input);
    byte[] random = TlsUtilities.ReadFully(32 /*0x20*/, input);
    byte[] sessionID = TlsUtilities.ReadOpaque8(input, 0, 32 /*0x20*/);
    byte[] cookie = (byte[]) null;
    if (dtlsOutput != null)
    {
      int maxLength = ProtocolVersion.DTLSv12.IsEqualOrEarlierVersionOf(version) ? (int) byte.MaxValue : 32 /*0x20*/;
      cookie = TlsUtilities.ReadOpaque8((Stream) messageInput, 0, maxLength);
    }
    int num = TlsUtilities.ReadUint16(input);
    if (num < 2 || (num & 1) != 0 || Convert.ToInt32(messageInput.Length - messageInput.Position) < num)
      throw new TlsFatalAlert((short) 50);
    int[] cipherSuites = TlsUtilities.ReadUint16Array(num / 2, input);
    if (!Arrays.Contains(TlsUtilities.ReadUint8ArrayWithUint8Length(input, 1), (short) 0))
      throw new TlsFatalAlert((short) 40);
    IDictionary<int, byte[]> extensions = (IDictionary<int, byte[]>) null;
    if (messageInput.Position < messageInput.Length)
    {
      byte[] extBytes = TlsUtilities.ReadOpaque16(input);
      TlsProtocol.AssertEmpty(messageInput);
      extensions = TlsProtocol.ReadExtensionsDataClientHello(extBytes);
    }
    return new ClientHello(version, random, sessionID, cookie, cipherSuites, extensions, -1);
  }
}
