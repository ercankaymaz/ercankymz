// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Tls.UrlAndHash
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Utilities;
using System;
using System.IO;

#nullable disable
namespace Org.BouncyCastle.Tls;

public sealed class UrlAndHash
{
  private readonly string m_url;
  private readonly byte[] m_sha1Hash;

  public UrlAndHash(string url, byte[] sha1Hash)
  {
    if (TlsUtilities.IsNullOrEmpty(url) || url.Length >= 65536 /*0x010000*/)
      throw new ArgumentException("must have length from 1 to (2^16 - 1)", nameof (url));
    if (sha1Hash != null && sha1Hash.Length != 20)
      throw new ArgumentException("must have length == 20, if present", nameof (sha1Hash));
    this.m_url = url;
    this.m_sha1Hash = sha1Hash;
  }

  public string Url => this.m_url;

  public byte[] Sha1Hash => this.m_sha1Hash;

  public void Encode(Stream output)
  {
    TlsUtilities.WriteOpaque16(Strings.ToByteArray(this.m_url), output);
    if (this.m_sha1Hash == null)
    {
      TlsUtilities.WriteUint8(0, output);
    }
    else
    {
      TlsUtilities.WriteUint8(1, output);
      output.Write(this.m_sha1Hash, 0, this.m_sha1Hash.Length);
    }
  }

  public static UrlAndHash Parse(TlsContext context, Stream input)
  {
    string url = Strings.FromByteArray(TlsUtilities.ReadOpaque16(input, 1));
    byte[] sha1Hash = (byte[]) null;
    switch (TlsUtilities.ReadUint8(input))
    {
      case 0:
        if (TlsUtilities.IsTlsV12(context))
          throw new TlsFatalAlert((short) 47);
        break;
      case 1:
        sha1Hash = TlsUtilities.ReadFully(20, input);
        break;
      default:
        throw new TlsFatalAlert((short) 47);
    }
    return new UrlAndHash(url, sha1Hash);
  }
}
