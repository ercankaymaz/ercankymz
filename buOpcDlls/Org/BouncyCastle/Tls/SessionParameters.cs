// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Tls.SessionParameters
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Tls.Crypto;
using Org.BouncyCastle.Utilities;
using System;
using System.Collections.Generic;
using System.IO;

#nullable disable
namespace Org.BouncyCastle.Tls;

public sealed class SessionParameters
{
  private readonly int m_cipherSuite;
  private readonly Certificate m_localCertificate;
  private readonly TlsSecret m_masterSecret;
  private readonly ProtocolVersion m_negotiatedVersion;
  private readonly Certificate m_peerCertificate;
  private readonly byte[] m_pskIdentity;
  private readonly byte[] m_srpIdentity;
  private readonly byte[] m_encodedServerExtensions;
  private readonly bool m_extendedMasterSecret;

  private SessionParameters(
    int cipherSuite,
    Certificate localCertificate,
    TlsSecret masterSecret,
    ProtocolVersion negotiatedVersion,
    Certificate peerCertificate,
    byte[] pskIdentity,
    byte[] srpIdentity,
    byte[] encodedServerExtensions,
    bool extendedMasterSecret)
  {
    this.m_cipherSuite = cipherSuite;
    this.m_localCertificate = localCertificate;
    this.m_masterSecret = masterSecret;
    this.m_negotiatedVersion = negotiatedVersion;
    this.m_peerCertificate = peerCertificate;
    this.m_pskIdentity = Arrays.Clone(pskIdentity);
    this.m_srpIdentity = Arrays.Clone(srpIdentity);
    this.m_encodedServerExtensions = encodedServerExtensions;
    this.m_extendedMasterSecret = extendedMasterSecret;
  }

  public int CipherSuite => this.m_cipherSuite;

  public void Clear()
  {
    if (this.m_masterSecret == null)
      return;
    this.m_masterSecret.Destroy();
  }

  public SessionParameters Copy()
  {
    return new SessionParameters(this.m_cipherSuite, this.m_localCertificate, this.m_masterSecret, this.m_negotiatedVersion, this.m_peerCertificate, this.m_pskIdentity, this.m_srpIdentity, this.m_encodedServerExtensions, this.m_extendedMasterSecret);
  }

  public bool IsExtendedMasterSecret => this.m_extendedMasterSecret;

  public Certificate LocalCertificate => this.m_localCertificate;

  public TlsSecret MasterSecret => this.m_masterSecret;

  public ProtocolVersion NegotiatedVersion => this.m_negotiatedVersion;

  public Certificate PeerCertificate => this.m_peerCertificate;

  public byte[] PskIdentity => this.m_pskIdentity;

  public IDictionary<int, byte[]> ReadServerExtensions()
  {
    return this.m_encodedServerExtensions == null ? (IDictionary<int, byte[]>) null : TlsProtocol.ReadExtensions(new MemoryStream(this.m_encodedServerExtensions, false));
  }

  public byte[] SrpIdentity => this.m_srpIdentity;

  public sealed class Builder
  {
    private int m_cipherSuite = -1;
    private Certificate m_localCertificate;
    private TlsSecret m_masterSecret;
    private ProtocolVersion m_negotiatedVersion;
    private Certificate m_peerCertificate;
    private byte[] m_pskIdentity;
    private byte[] m_srpIdentity;
    private byte[] m_encodedServerExtensions;
    private bool m_extendedMasterSecret;

    public SessionParameters Build()
    {
      this.Validate(this.m_cipherSuite >= 0, "cipherSuite");
      this.Validate(this.m_masterSecret != null, "masterSecret");
      return new SessionParameters(this.m_cipherSuite, this.m_localCertificate, this.m_masterSecret, this.m_negotiatedVersion, this.m_peerCertificate, this.m_pskIdentity, this.m_srpIdentity, this.m_encodedServerExtensions, this.m_extendedMasterSecret);
    }

    public SessionParameters.Builder SetCipherSuite(int cipherSuite)
    {
      this.m_cipherSuite = cipherSuite;
      return this;
    }

    public SessionParameters.Builder SetExtendedMasterSecret(bool extendedMasterSecret)
    {
      this.m_extendedMasterSecret = extendedMasterSecret;
      return this;
    }

    public SessionParameters.Builder SetLocalCertificate(Certificate localCertificate)
    {
      this.m_localCertificate = localCertificate;
      return this;
    }

    public SessionParameters.Builder SetMasterSecret(TlsSecret masterSecret)
    {
      this.m_masterSecret = masterSecret;
      return this;
    }

    public SessionParameters.Builder SetNegotiatedVersion(ProtocolVersion negotiatedVersion)
    {
      this.m_negotiatedVersion = negotiatedVersion;
      return this;
    }

    public SessionParameters.Builder SetPeerCertificate(Certificate peerCertificate)
    {
      this.m_peerCertificate = peerCertificate;
      return this;
    }

    public SessionParameters.Builder SetPskIdentity(byte[] pskIdentity)
    {
      this.m_pskIdentity = pskIdentity;
      return this;
    }

    public SessionParameters.Builder SetSrpIdentity(byte[] srpIdentity)
    {
      this.m_srpIdentity = srpIdentity;
      return this;
    }

    public SessionParameters.Builder SetServerExtensions(IDictionary<int, byte[]> serverExtensions)
    {
      if (serverExtensions != null && serverExtensions.Count >= 1)
      {
        MemoryStream output = new MemoryStream();
        TlsProtocol.WriteExtensions((Stream) output, serverExtensions);
        this.m_encodedServerExtensions = output.ToArray();
      }
      else
        this.m_encodedServerExtensions = (byte[]) null;
      return this;
    }

    private void Validate(bool condition, string parameter)
    {
      if (!condition)
        throw new InvalidOperationException($"Required session parameter '{parameter}' not configured");
    }
  }
}
