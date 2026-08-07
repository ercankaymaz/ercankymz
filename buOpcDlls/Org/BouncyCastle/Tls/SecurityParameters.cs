// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Tls.SecurityParameters
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Tls.Crypto;
using System.Collections.Generic;

#nullable disable
namespace Org.BouncyCastle.Tls;

public sealed class SecurityParameters
{
  internal int m_entity = -1;
  internal bool m_resumedSession;
  internal bool m_secureRenegotiation;
  internal int m_cipherSuite;
  internal short m_maxFragmentLength = -1;
  internal int m_prfAlgorithm = -1;
  internal int m_prfCryptoHashAlgorithm = -1;
  internal int m_prfHashLength = -1;
  internal int m_verifyDataLength = -1;
  internal TlsSecret m_baseKeyClient;
  internal TlsSecret m_baseKeyServer;
  internal TlsSecret m_earlyExporterMasterSecret;
  internal TlsSecret m_earlySecret;
  internal TlsSecret m_exporterMasterSecret;
  internal TlsSecret m_handshakeSecret;
  internal TlsSecret m_masterSecret;
  internal TlsSecret m_trafficSecretClient;
  internal TlsSecret m_trafficSecretServer;
  internal byte[] m_clientRandom;
  internal byte[] m_serverRandom;
  internal byte[] m_sessionHash;
  internal byte[] m_sessionID;
  internal byte[] m_pskIdentity;
  internal byte[] m_srpIdentity;
  internal byte[] m_tlsServerEndPoint;
  internal byte[] m_tlsUnique;
  internal bool m_encryptThenMac;
  internal bool m_extendedMasterSecret;
  internal bool m_extendedPadding;
  internal bool m_truncatedHmac;
  internal ProtocolName m_applicationProtocol;
  internal bool m_applicationProtocolSet;
  internal short[] m_clientCertTypes;
  internal IList<ServerName> m_clientServerNames;
  internal IList<SignatureAndHashAlgorithm> m_clientSigAlgs;
  internal IList<SignatureAndHashAlgorithm> m_clientSigAlgsCert;
  internal int[] m_clientSupportedGroups;
  internal IList<SignatureAndHashAlgorithm> m_serverSigAlgs;
  internal IList<SignatureAndHashAlgorithm> m_serverSigAlgsCert;
  internal int[] m_serverSupportedGroups;
  internal int m_keyExchangeAlgorithm = -1;
  internal Certificate m_localCertificate;
  internal Certificate m_peerCertificate;
  internal ProtocolVersion m_negotiatedVersion;
  internal int m_statusRequestVersion;
  internal short m_clientCertificateType = -1;
  internal byte[] m_localVerifyData;
  internal byte[] m_peerVerifyData;
  internal byte[] m_connectionIDLocal;
  internal byte[] m_connectionIDPeer;

  internal void Clear()
  {
    this.m_sessionHash = (byte[]) null;
    this.m_sessionID = (byte[]) null;
    this.m_clientCertTypes = (short[]) null;
    this.m_clientServerNames = (IList<ServerName>) null;
    this.m_clientSigAlgs = (IList<SignatureAndHashAlgorithm>) null;
    this.m_clientSigAlgsCert = (IList<SignatureAndHashAlgorithm>) null;
    this.m_clientSupportedGroups = (int[]) null;
    this.m_serverSigAlgs = (IList<SignatureAndHashAlgorithm>) null;
    this.m_serverSigAlgsCert = (IList<SignatureAndHashAlgorithm>) null;
    this.m_serverSupportedGroups = (int[]) null;
    this.m_statusRequestVersion = 0;
    this.m_baseKeyClient = SecurityParameters.ClearSecret(this.m_baseKeyClient);
    this.m_baseKeyServer = SecurityParameters.ClearSecret(this.m_baseKeyServer);
    this.m_earlyExporterMasterSecret = SecurityParameters.ClearSecret(this.m_earlyExporterMasterSecret);
    this.m_earlySecret = SecurityParameters.ClearSecret(this.m_earlySecret);
    this.m_exporterMasterSecret = SecurityParameters.ClearSecret(this.m_exporterMasterSecret);
    this.m_handshakeSecret = SecurityParameters.ClearSecret(this.m_handshakeSecret);
    this.m_masterSecret = SecurityParameters.ClearSecret(this.m_masterSecret);
  }

  public ProtocolName ApplicationProtocol => this.m_applicationProtocol;

  public TlsSecret BaseKeyClient => this.m_baseKeyClient;

  public TlsSecret BaseKeyServer => this.m_baseKeyServer;

  public int CipherSuite => this.m_cipherSuite;

  public short ClientCertificateType => this.m_clientCertificateType;

  public short[] ClientCertTypes => this.m_clientCertTypes;

  public byte[] ClientRandom => this.m_clientRandom;

  public IList<ServerName> ClientServerNames => this.m_clientServerNames;

  public IList<SignatureAndHashAlgorithm> ClientSigAlgs => this.m_clientSigAlgs;

  public IList<SignatureAndHashAlgorithm> ClientSigAlgsCert => this.m_clientSigAlgsCert;

  public int[] ClientSupportedGroups => this.m_clientSupportedGroups;

  public byte[] ConnectionIDLocal => this.m_connectionIDLocal;

  public byte[] ConnectionIDPeer => this.m_connectionIDPeer;

  public TlsSecret EarlyExporterMasterSecret => this.m_earlyExporterMasterSecret;

  public TlsSecret EarlySecret => this.m_earlySecret;

  public TlsSecret ExporterMasterSecret => this.m_exporterMasterSecret;

  public int Entity => this.m_entity;

  public TlsSecret HandshakeSecret => this.m_handshakeSecret;

  public bool IsApplicationProtocolSet => this.m_applicationProtocolSet;

  public bool IsEncryptThenMac => this.m_encryptThenMac;

  public bool IsExtendedMasterSecret => this.m_extendedMasterSecret;

  public bool IsExtendedPadding => this.m_extendedPadding;

  public bool IsResumedSession => this.m_resumedSession;

  public bool IsSecureRenegotiation => this.m_secureRenegotiation;

  public bool IsTruncatedHmac => this.m_truncatedHmac;

  public int KeyExchangeAlgorithm => this.m_keyExchangeAlgorithm;

  public Certificate LocalCertificate => this.m_localCertificate;

  public byte[] LocalVerifyData => this.m_localVerifyData;

  public TlsSecret MasterSecret => this.m_masterSecret;

  public short MaxFragmentLength => this.m_maxFragmentLength;

  public ProtocolVersion NegotiatedVersion => this.m_negotiatedVersion;

  public Certificate PeerCertificate => this.m_peerCertificate;

  public byte[] PeerVerifyData => this.m_peerVerifyData;

  public int PrfAlgorithm => this.m_prfAlgorithm;

  public int PrfCryptoHashAlgorithm => this.m_prfCryptoHashAlgorithm;

  public int PrfHashLength => this.m_prfHashLength;

  public byte[] PskIdentity => this.m_pskIdentity;

  public byte[] ServerRandom => this.m_serverRandom;

  public IList<SignatureAndHashAlgorithm> ServerSigAlgs => this.m_serverSigAlgs;

  public IList<SignatureAndHashAlgorithm> ServerSigAlgsCert => this.m_serverSigAlgsCert;

  public int[] ServerSupportedGroups => this.m_serverSupportedGroups;

  public byte[] SessionHash => this.m_sessionHash;

  public byte[] SessionID => this.m_sessionID;

  public byte[] SrpIdentity => this.m_srpIdentity;

  public int StatusRequestVersion => this.m_statusRequestVersion;

  public byte[] TlsServerEndPoint => this.m_tlsServerEndPoint;

  public byte[] TlsUnique => this.m_tlsUnique;

  public TlsSecret TrafficSecretClient => this.m_trafficSecretClient;

  public TlsSecret TrafficSecretServer => this.m_trafficSecretServer;

  public int VerifyDataLength => this.m_verifyDataLength;

  private static TlsSecret ClearSecret(TlsSecret secret)
  {
    secret?.Destroy();
    return (TlsSecret) null;
  }
}
