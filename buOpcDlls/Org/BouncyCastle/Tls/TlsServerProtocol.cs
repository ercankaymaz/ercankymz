// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Tls.TlsServerProtocol
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

public class TlsServerProtocol : TlsProtocol
{
  protected TlsServer m_tlsServer;
  internal TlsServerContextImpl m_tlsServerContext;
  protected int[] m_offeredCipherSuites;
  protected TlsKeyExchange m_keyExchange;
  protected CertificateRequest m_certificateRequest;

  public TlsServerProtocol()
  {
  }

  public TlsServerProtocol(Stream stream)
    : base(stream)
  {
  }

  public TlsServerProtocol(Stream input, Stream output)
    : base(input, output)
  {
  }

  public void Accept(TlsServer tlsServer)
  {
    if (tlsServer == null)
      throw new ArgumentNullException(nameof (tlsServer));
    this.m_tlsServer = this.m_tlsServer == null ? tlsServer : throw new InvalidOperationException("'Accept' can only be called once");
    this.m_tlsServerContext = new TlsServerContextImpl(tlsServer.Crypto);
    tlsServer.Init((TlsServerContext) this.m_tlsServerContext);
    tlsServer.NotifyCloseHandle((TlsCloseable) this);
    this.BeginHandshake();
    if (!this.m_blocking)
      return;
    this.BlockForHandshake();
  }

  protected override void CleanupHandshake()
  {
    base.CleanupHandshake();
    this.m_offeredCipherSuites = (int[]) null;
    this.m_keyExchange = (TlsKeyExchange) null;
    this.m_certificateRequest = (CertificateRequest) null;
  }

  protected virtual bool ExpectCertificateVerifyMessage()
  {
    if (this.m_certificateRequest == null)
      return false;
    Certificate peerCertificate = this.m_tlsServerContext.SecurityParameters.PeerCertificate;
    if (peerCertificate == null || peerCertificate.IsEmpty)
      return false;
    return this.m_keyExchange == null || this.m_keyExchange.RequiresCertificateVerify;
  }

  protected virtual ServerHello Generate13HelloRetryRequest(ClientHello clientHello)
  {
    if (this.m_retryGroup < 0)
      throw new TlsFatalAlert((short) 80 /*0x50*/);
    SecurityParameters securityParameters = this.m_tlsServerContext.SecurityParameters;
    ProtocolVersion negotiatedVersion = securityParameters.NegotiatedVersion;
    Dictionary<int, byte[]> extensions = new Dictionary<int, byte[]>();
    TlsExtensionsUtilities.AddSupportedVersionsExtensionServer((IDictionary<int, byte[]>) extensions, negotiatedVersion);
    if (this.m_retryGroup >= 0)
      TlsExtensionsUtilities.AddKeyShareHelloRetryRequest((IDictionary<int, byte[]>) extensions, this.m_retryGroup);
    if (this.m_retryCookie != null)
      TlsExtensionsUtilities.AddCookieExtension((IDictionary<int, byte[]>) extensions, this.m_retryCookie);
    TlsUtilities.CheckExtensionData13((IDictionary<int, byte[]>) extensions, 6, (short) 80 /*0x50*/);
    return new ServerHello(clientHello.SessionID, securityParameters.CipherSuite, (IDictionary<int, byte[]>) extensions);
  }

  protected virtual ServerHello Generate13ServerHello(
    ClientHello clientHello,
    HandshakeMessageInput clientHelloMessage,
    bool afterHelloRetryRequest)
  {
    SecurityParameters securityParameters = this.m_tlsServerContext.SecurityParameters;
    byte[] sessionId = clientHello.SessionID;
    IDictionary<int, byte[]> extensions1 = clientHello.Extensions;
    if (extensions1 == null)
      throw new TlsFatalAlert((short) 109);
    ProtocolVersion negotiatedVersion = securityParameters.NegotiatedVersion;
    TlsCrypto crypto = this.m_tlsServerContext.Crypto;
    OfferedPsks.SelectedConfig selectedConfig = TlsUtilities.SelectPreSharedKey((TlsServerContext) this.m_tlsServerContext, this.m_tlsServer, extensions1, clientHelloMessage, this.m_handshakeHash, afterHelloRetryRequest);
    IList<KeyShareEntry> shareClientHello = TlsExtensionsUtilities.GetKeyShareClientHello(extensions1);
    KeyShareEntry keyShareEntry;
    if (afterHelloRetryRequest)
    {
      if (this.m_retryGroup < 0)
        throw new TlsFatalAlert((short) 80 /*0x50*/);
      if (selectedConfig == null)
      {
        if (securityParameters.ClientSigAlgs == null)
          throw new TlsFatalAlert((short) 109);
      }
      else if (selectedConfig.m_psk.PrfAlgorithm != securityParameters.PrfAlgorithm)
        throw new TlsFatalAlert((short) 47);
      this.m_retryCookie = Arrays.AreEqual(this.m_retryCookie, TlsExtensionsUtilities.GetCookieExtension(extensions1)) ? (byte[]) null : throw new TlsFatalAlert((short) 47);
      keyShareEntry = TlsUtilities.SelectKeyShare(shareClientHello, this.m_retryGroup);
      if (keyShareEntry == null)
        throw new TlsFatalAlert((short) 47);
    }
    else
    {
      securityParameters.m_serverRandom = TlsProtocol.CreateRandomBlock(false, (TlsContext) this.m_tlsServerContext);
      if (!negotiatedVersion.Equals(ProtocolVersion.GetLatestTls(this.m_tlsServer.GetProtocolVersions())))
        TlsUtilities.WriteDowngradeMarker(negotiatedVersion, securityParameters.ServerRandom);
      this.m_clientExtensions = extensions1;
      securityParameters.m_secureRenegotiation = false;
      TlsExtensionsUtilities.GetPaddingExtension(extensions1);
      securityParameters.m_clientServerNames = TlsExtensionsUtilities.GetServerNameExtensionClient(extensions1);
      TlsUtilities.EstablishClientSigAlgs(securityParameters, extensions1);
      if (selectedConfig == null && securityParameters.ClientSigAlgs == null)
        throw new TlsFatalAlert((short) 109);
      this.m_tlsServer.ProcessClientExtensions(extensions1);
      securityParameters.m_resumedSession = false;
      this.m_tlsSession = TlsUtilities.ImportSession(TlsUtilities.EmptyBytes, (SessionParameters) null);
      this.m_sessionParameters = (SessionParameters) null;
      this.m_sessionMasterSecret = (TlsSecret) null;
      securityParameters.m_sessionID = this.m_tlsSession.SessionID;
      this.m_tlsServer.NotifySession(this.m_tlsSession);
      TlsUtilities.NegotiatedVersionTlsServer((TlsServerContext) this.m_tlsServerContext);
      int selectedCipherSuite = this.m_tlsServer.GetSelectedCipherSuite();
      if (!TlsUtilities.IsValidCipherSuiteSelection(this.m_offeredCipherSuites, selectedCipherSuite) || !TlsUtilities.IsValidVersionForCipherSuite(selectedCipherSuite, negotiatedVersion))
        throw new TlsFatalAlert((short) 80 /*0x50*/);
      TlsUtilities.NegotiatedCipherSuite(securityParameters, selectedCipherSuite);
      int[] clientSupportedGroups = securityParameters.ClientSupportedGroups;
      int[] serverSupportedGroups = securityParameters.ServerSupportedGroups;
      keyShareEntry = TlsUtilities.SelectKeyShare(crypto, negotiatedVersion, shareClientHello, clientSupportedGroups, serverSupportedGroups);
      if (keyShareEntry == null)
      {
        this.m_retryGroup = TlsUtilities.SelectKeyShareGroup(crypto, negotiatedVersion, clientSupportedGroups, serverSupportedGroups);
        if (this.m_retryGroup < 0)
          throw new TlsFatalAlert((short) 40);
        this.m_retryCookie = this.m_tlsServerContext.NonceGenerator.GenerateNonce(16 /*0x10*/);
        return this.Generate13HelloRetryRequest(clientHello);
      }
      int namedGroup = keyShareEntry.NamedGroup;
    }
    Dictionary<int, byte[]> extensions2 = new Dictionary<int, byte[]>();
    IDictionary<int, byte[]> dictionary = TlsExtensionsUtilities.EnsureExtensionsInitialised(this.m_tlsServer.GetServerExtensions());
    this.m_tlsServer.GetServerExtensionsForConnection(dictionary);
    ProtocolVersion tlSv12 = ProtocolVersion.TLSv12;
    TlsExtensionsUtilities.AddSupportedVersionsExtensionServer((IDictionary<int, byte[]>) extensions2, negotiatedVersion);
    securityParameters.m_extendedMasterSecret = true;
    securityParameters.m_applicationProtocol = TlsExtensionsUtilities.GetAlpnExtensionServer(dictionary);
    securityParameters.m_applicationProtocolSet = true;
    if (dictionary.Count > 0)
      securityParameters.m_maxFragmentLength = this.ProcessMaxFragmentLengthExtension(securityParameters.IsResumedSession ? (IDictionary<int, byte[]>) null : extensions1, dictionary, (short) 80 /*0x50*/);
    securityParameters.m_encryptThenMac = false;
    securityParameters.m_truncatedHmac = false;
    securityParameters.m_statusRequestVersion = extensions1.ContainsKey(5) ? 1 : 0;
    this.m_expectSessionTicket = false;
    TlsSecret pskEarlySecret = (TlsSecret) null;
    if (selectedConfig != null)
    {
      pskEarlySecret = selectedConfig.m_earlySecret;
      this.m_selectedPsk13 = true;
      TlsExtensionsUtilities.AddPreSharedKeyServerHello((IDictionary<int, byte[]>) extensions2, selectedConfig.m_index);
    }
    int namedGroup1 = keyShareEntry.NamedGroup;
    TlsAgreement tlsAgreement;
    if (NamedGroup.RefersToASpecificCurve(namedGroup1))
      tlsAgreement = crypto.CreateECDomain(new TlsECConfig(namedGroup1)).CreateECDH();
    else
      tlsAgreement = NamedGroup.RefersToASpecificFiniteField(namedGroup1) ? crypto.CreateDHDomain(new TlsDHConfig(namedGroup1, true)).CreateDH() : throw new TlsFatalAlert((short) 80 /*0x50*/);
    byte[] ephemeral = tlsAgreement.GenerateEphemeral();
    KeyShareEntry serverShare = new KeyShareEntry(namedGroup1, ephemeral);
    TlsExtensionsUtilities.AddKeyShareServerHello((IDictionary<int, byte[]>) extensions2, serverShare);
    tlsAgreement.ReceivePeerValue(keyShareEntry.KeyExchange);
    TlsSecret secret = tlsAgreement.CalculateSecret();
    TlsUtilities.Establish13PhaseSecrets((TlsContext) this.m_tlsServerContext, pskEarlySecret, secret);
    this.m_serverExtensions = dictionary;
    this.ApplyMaxFragmentLengthExtension(securityParameters.MaxFragmentLength);
    TlsUtilities.CheckExtensionData13((IDictionary<int, byte[]>) extensions2, 2, (short) 80 /*0x50*/);
    byte[] serverRandom = securityParameters.ServerRandom;
    byte[] sessionID = sessionId;
    int cipherSuite = securityParameters.CipherSuite;
    Dictionary<int, byte[]> extensions3 = extensions2;
    return new ServerHello(tlSv12, serverRandom, sessionID, cipherSuite, (IDictionary<int, byte[]>) extensions3);
  }

  protected virtual ServerHello GenerateServerHello(
    ClientHello clientHello,
    HandshakeMessageInput clientHelloMessage)
  {
    ProtocolVersion version = clientHello.Version;
    if (!version.IsTls)
      throw new TlsFatalAlert((short) 47);
    this.m_offeredCipherSuites = clientHello.CipherSuites;
    SecurityParameters securityParameters = this.m_tlsServerContext.SecurityParameters;
    this.m_tlsServerContext.SetClientSupportedVersions(TlsExtensionsUtilities.GetSupportedVersionsExtensionClient(clientHello.Extensions));
    ProtocolVersion protocolVersion = version;
    if (this.m_tlsServerContext.ClientSupportedVersions == null)
    {
      if (protocolVersion.IsLaterVersionOf(ProtocolVersion.TLSv12))
        protocolVersion = ProtocolVersion.TLSv12;
      this.m_tlsServerContext.SetClientSupportedVersions(protocolVersion.DownTo(ProtocolVersion.SSLv3));
    }
    else
      protocolVersion = ProtocolVersion.GetLatestTls(this.m_tlsServerContext.ClientSupportedVersions);
    this.m_recordStream.SetWriteVersion(protocolVersion);
    if (!ProtocolVersion.SERVER_EARLIEST_SUPPORTED_TLS.IsEqualOrEarlierVersionOf(protocolVersion))
      throw new TlsFatalAlert((short) 70);
    this.m_tlsServerContext.SetClientVersion(protocolVersion);
    this.m_tlsServer.NotifyClientVersion(this.m_tlsServerContext.ClientVersion);
    securityParameters.m_clientRandom = clientHello.Random;
    this.m_tlsServer.NotifyFallback(Arrays.Contains(this.m_offeredCipherSuites, 22016));
    this.m_tlsServer.NotifyOfferedCipherSuites(this.m_offeredCipherSuites);
    ProtocolVersion serverVersion = this.m_tlsServer.GetServerVersion();
    if (!ProtocolVersion.Contains(this.m_tlsServerContext.ClientSupportedVersions, serverVersion))
      throw new TlsFatalAlert((short) 80 /*0x50*/);
    securityParameters.m_negotiatedVersion = serverVersion;
    securityParameters.m_clientSupportedGroups = TlsExtensionsUtilities.GetSupportedGroupsExtension(clientHello.Extensions);
    securityParameters.m_serverSupportedGroups = this.m_tlsServer.GetSupportedGroups();
    if (ProtocolVersion.TLSv13.IsEqualOrEarlierVersionOf(serverVersion))
    {
      this.m_recordStream.SetIgnoreChangeCipherSpec(true);
      this.m_recordStream.SetWriteVersion(ProtocolVersion.TLSv12);
      return this.Generate13ServerHello(clientHello, clientHelloMessage, false);
    }
    this.m_recordStream.SetWriteVersion(serverVersion);
    bool useGmtUnixTime = this.m_tlsServer.ShouldUseGmtUnixTime();
    securityParameters.m_serverRandom = TlsProtocol.CreateRandomBlock(useGmtUnixTime, (TlsContext) this.m_tlsServerContext);
    if (!serverVersion.Equals(ProtocolVersion.GetLatestTls(this.m_tlsServer.GetProtocolVersions())))
      TlsUtilities.WriteDowngradeMarker(serverVersion, securityParameters.ServerRandom);
    this.m_clientExtensions = clientHello.Extensions;
    byte[] extensionData = TlsUtilities.GetExtensionData(this.m_clientExtensions, 65281);
    if (Arrays.Contains(this.m_offeredCipherSuites, (int) byte.MaxValue))
      securityParameters.m_secureRenegotiation = true;
    if (extensionData != null)
    {
      securityParameters.m_secureRenegotiation = true;
      if (!Arrays.FixedTimeEquals(extensionData, TlsProtocol.CreateRenegotiationInfo(TlsUtilities.EmptyBytes)))
        throw new TlsFatalAlert((short) 40);
    }
    this.m_tlsServer.NotifySecureRenegotiation(securityParameters.IsSecureRenegotiation);
    bool flag1 = TlsExtensionsUtilities.HasExtendedMasterSecretExtension(this.m_clientExtensions);
    if (this.m_clientExtensions != null)
    {
      TlsExtensionsUtilities.GetPaddingExtension(this.m_clientExtensions);
      securityParameters.m_clientServerNames = TlsExtensionsUtilities.GetServerNameExtensionClient(this.m_clientExtensions);
      if (TlsUtilities.IsSignatureAlgorithmsExtensionAllowed(protocolVersion))
        TlsUtilities.EstablishClientSigAlgs(securityParameters, this.m_clientExtensions);
      securityParameters.m_clientSupportedGroups = TlsExtensionsUtilities.GetSupportedGroupsExtension(this.m_clientExtensions);
      this.m_tlsServer.ProcessClientExtensions(this.m_clientExtensions);
    }
    bool flag2 = this.EstablishSession(this.m_tlsServer.GetSessionToResume(clientHello.SessionID));
    securityParameters.m_resumedSession = flag2;
    if (!flag2)
    {
      this.m_tlsSession = TlsUtilities.ImportSession(this.m_tlsServer.GetNewSessionID() ?? TlsUtilities.EmptyBytes, (SessionParameters) null);
      this.m_sessionParameters = (SessionParameters) null;
      this.m_sessionMasterSecret = (TlsSecret) null;
    }
    securityParameters.m_sessionID = this.m_tlsSession.SessionID;
    this.m_tlsServer.NotifySession(this.m_tlsSession);
    TlsUtilities.NegotiatedVersionTlsServer((TlsServerContext) this.m_tlsServerContext);
    int cipherSuite = flag2 ? this.m_sessionParameters.CipherSuite : this.m_tlsServer.GetSelectedCipherSuite();
    if (!TlsUtilities.IsValidCipherSuiteSelection(this.m_offeredCipherSuites, cipherSuite) || !TlsUtilities.IsValidVersionForCipherSuite(cipherSuite, serverVersion))
      throw new TlsFatalAlert((short) 80 /*0x50*/);
    TlsUtilities.NegotiatedCipherSuite(securityParameters, cipherSuite);
    this.m_tlsServerContext.SetRsaPreMasterSecretVersion(version);
    this.m_serverExtensions = TlsExtensionsUtilities.EnsureExtensionsInitialised(flag2 ? this.m_sessionParameters.ReadServerExtensions() : this.m_tlsServer.GetServerExtensions());
    this.m_tlsServer.GetServerExtensionsForConnection(this.m_serverExtensions);
    if (securityParameters.IsSecureRenegotiation && TlsUtilities.GetExtensionData(this.m_serverExtensions, 65281) == null)
      this.m_serverExtensions[65281] = TlsProtocol.CreateRenegotiationInfo(TlsUtilities.EmptyBytes);
    if (flag2)
    {
      if (!this.m_sessionParameters.IsExtendedMasterSecret)
        throw new TlsFatalAlert((short) 80 /*0x50*/);
      if (!flag1)
        throw new TlsFatalAlert((short) 40);
      securityParameters.m_extendedMasterSecret = true;
      TlsExtensionsUtilities.AddExtendedMasterSecretExtension(this.m_serverExtensions);
    }
    else
    {
      securityParameters.m_extendedMasterSecret = flag1 && !serverVersion.IsSsl && this.m_tlsServer.ShouldUseExtendedMasterSecret();
      if (securityParameters.IsExtendedMasterSecret)
        TlsExtensionsUtilities.AddExtendedMasterSecretExtension(this.m_serverExtensions);
      else if (this.m_tlsServer.RequiresExtendedMasterSecret())
        throw new TlsFatalAlert((short) 40);
    }
    securityParameters.m_applicationProtocol = TlsExtensionsUtilities.GetAlpnExtensionServer(this.m_serverExtensions);
    securityParameters.m_applicationProtocolSet = true;
    if (this.m_serverExtensions.Count > 0)
    {
      securityParameters.m_encryptThenMac = TlsExtensionsUtilities.HasEncryptThenMacExtension(this.m_serverExtensions);
      securityParameters.m_maxFragmentLength = this.ProcessMaxFragmentLengthExtension(flag2 ? (IDictionary<int, byte[]>) null : this.m_clientExtensions, this.m_serverExtensions, (short) 80 /*0x50*/);
      securityParameters.m_truncatedHmac = TlsExtensionsUtilities.HasTruncatedHmacExtension(this.m_serverExtensions);
      if (!flag2)
      {
        if (TlsUtilities.HasExpectedEmptyExtensionData(this.m_serverExtensions, 17, (short) 80 /*0x50*/))
          securityParameters.m_statusRequestVersion = 2;
        else if (TlsUtilities.HasExpectedEmptyExtensionData(this.m_serverExtensions, 5, (short) 80 /*0x50*/))
          securityParameters.m_statusRequestVersion = 1;
        this.m_expectSessionTicket = TlsUtilities.HasExpectedEmptyExtensionData(this.m_serverExtensions, 35, (short) 80 /*0x50*/);
      }
    }
    this.ApplyMaxFragmentLengthExtension(securityParameters.MaxFragmentLength);
    return new ServerHello(serverVersion, securityParameters.ServerRandom, this.m_tlsSession.SessionID, securityParameters.CipherSuite, this.m_serverExtensions);
  }

  protected override TlsContext Context => (TlsContext) this.m_tlsServerContext;

  internal override AbstractTlsContext ContextAdmin => (AbstractTlsContext) this.m_tlsServerContext;

  protected override TlsPeer Peer => (TlsPeer) this.m_tlsServer;

  protected virtual void Handle13HandshakeMessage(short type, HandshakeMessageInput buf)
  {
    if (!this.IsTlsV13ConnectionState())
      throw new TlsFatalAlert((short) 80 /*0x50*/);
    switch (type)
    {
      case 1:
        switch (this.m_connectionState)
        {
          case 0:
            throw new TlsFatalAlert((short) 80 /*0x50*/);
          case 2:
            ClientHello clientHelloMessage = this.ReceiveClientHelloMessage((MemoryStream) buf);
            this.m_connectionState = (short) 3;
            ServerHello serverHello = this.Generate13ServerHello(clientHelloMessage, buf, true);
            this.SendServerHelloMessage(serverHello);
            this.m_connectionState = (short) 4;
            this.Send13ServerHelloCoda(serverHello, true);
            return;
          default:
            throw new TlsFatalAlert((short) 10);
        }
      case 11:
        if (this.m_connectionState != (short) 20)
          throw new TlsFatalAlert((short) 10);
        this.Receive13ClientCertificate((MemoryStream) buf);
        this.m_connectionState = (short) 15;
        break;
      case 15:
        if (this.m_connectionState != (short) 15)
          throw new TlsFatalAlert((short) 10);
        this.Receive13ClientCertificateVerify((MemoryStream) buf);
        buf.UpdateHash((TlsHash) this.m_handshakeHash);
        this.m_connectionState = (short) 17;
        break;
      case 20:
        switch (this.m_connectionState)
        {
          case 15:
          case 17:
          case 20:
            if (this.m_connectionState == (short) 20)
              this.Skip13ClientCertificate();
            if (this.m_connectionState != (short) 17)
              this.Skip13ClientCertificateVerify();
            this.Receive13ClientFinished((MemoryStream) buf);
            this.m_connectionState = (short) 18;
            this.m_recordStream.SetIgnoreChangeCipherSpec(false);
            this.m_recordStream.EnablePendingCipherRead(false);
            this.CompleteHandshake();
            return;
          default:
            throw new TlsFatalAlert((short) 10);
        }
      case 24:
        this.Receive13KeyUpdate((MemoryStream) buf);
        break;
      default:
        throw new TlsFatalAlert((short) 10);
    }
  }

  protected override void HandleHandshakeMessage(short type, HandshakeMessageInput buf)
  {
    SecurityParameters securityParameters = this.m_tlsServerContext.SecurityParameters;
    if (this.m_connectionState > (short) 1 && TlsUtilities.IsTlsV13(securityParameters.NegotiatedVersion))
    {
      if (securityParameters.IsResumedSession)
        throw new TlsFatalAlert((short) 80 /*0x50*/);
      this.Handle13HandshakeMessage(type, buf);
    }
    else
    {
      if (!this.IsLegacyConnectionState())
        throw new TlsFatalAlert((short) 80 /*0x50*/);
      if (securityParameters.IsResumedSession)
      {
        if (type != (short) 20 || this.m_connectionState != (short) 20)
          throw new TlsFatalAlert((short) 10);
        this.ProcessFinishedMessage((MemoryStream) buf);
        this.m_connectionState = (short) 18;
        this.CompleteHandshake();
      }
      else
      {
        switch (type)
        {
          case 1:
            if (this.IsApplicationDataReady)
            {
              this.RefuseRenegotiation();
              break;
            }
            switch (this.m_connectionState)
            {
              case 0:
                ClientHello clientHelloMessage = this.ReceiveClientHelloMessage((MemoryStream) buf);
                this.m_connectionState = (short) 1;
                ServerHello serverHello = this.GenerateServerHello(clientHelloMessage, buf);
                this.m_handshakeHash.NotifyPrfDetermined();
                if (TlsUtilities.IsTlsV13(securityParameters.NegotiatedVersion))
                {
                  this.m_handshakeHash.SealHashAlgorithms();
                  if (serverHello.IsHelloRetryRequest())
                  {
                    TlsUtilities.AdjustTranscriptForRetry(this.m_handshakeHash);
                    this.SendServerHelloMessage(serverHello);
                    this.m_connectionState = (short) 2;
                    this.SendChangeCipherSpecMessage();
                    return;
                  }
                  this.SendServerHelloMessage(serverHello);
                  this.m_connectionState = (short) 4;
                  this.SendChangeCipherSpecMessage();
                  this.Send13ServerHelloCoda(serverHello, false);
                  return;
                }
                buf.UpdateHash((TlsHash) this.m_handshakeHash);
                this.SendServerHelloMessage(serverHello);
                this.m_connectionState = (short) 4;
                if (securityParameters.IsResumedSession)
                {
                  securityParameters.m_masterSecret = this.m_sessionMasterSecret;
                  this.m_recordStream.SetPendingCipher(TlsUtilities.InitCipher((TlsContext) this.m_tlsServerContext));
                  this.SendChangeCipherSpec();
                  this.SendFinishedMessage();
                  this.m_connectionState = (short) 20;
                  return;
                }
                IList<SupplementalDataEntry> supplementalData = this.m_tlsServer.GetServerSupplementalData();
                if (supplementalData != null)
                {
                  this.SendSupplementalDataMessage(supplementalData);
                  this.m_connectionState = (short) 6;
                }
                this.m_keyExchange = TlsUtilities.InitKeyExchangeServer((TlsServerContext) this.m_tlsServerContext, this.m_tlsServer);
                TlsCredentials serverCredentials = (TlsCredentials) null;
                if (!KeyExchangeAlgorithm.IsAnonymous(securityParameters.KeyExchangeAlgorithm))
                  serverCredentials = TlsUtilities.EstablishServerCredentials(this.m_tlsServer);
                Certificate certificate = (Certificate) null;
                MemoryStream endPointHash = new MemoryStream();
                if (serverCredentials == null)
                {
                  this.m_keyExchange.SkipServerCredentials();
                }
                else
                {
                  this.m_keyExchange.ProcessServerCredentials(serverCredentials);
                  certificate = serverCredentials.Certificate;
                  this.SendCertificateMessage(certificate, (Stream) endPointHash);
                  this.m_connectionState = (short) 7;
                }
                securityParameters.m_tlsServerEndPoint = endPointHash.ToArray();
                if (certificate == null || certificate.IsEmpty)
                  securityParameters.m_statusRequestVersion = 0;
                if (securityParameters.StatusRequestVersion > 0)
                {
                  CertificateStatus certificateStatus = this.m_tlsServer.GetCertificateStatus();
                  if (certificateStatus != null)
                  {
                    this.SendCertificateStatusMessage(certificateStatus);
                    this.m_connectionState = (short) 8;
                  }
                }
                byte[] serverKeyExchange = this.m_keyExchange.GenerateServerKeyExchange();
                if (serverKeyExchange != null)
                {
                  this.SendServerKeyExchangeMessage(serverKeyExchange);
                  this.m_connectionState = (short) 10;
                }
                if (serverCredentials != null)
                {
                  this.m_certificateRequest = this.m_tlsServer.GetCertificateRequest();
                  if (this.m_certificateRequest == null)
                  {
                    if (!this.m_keyExchange.RequiresCertificateVerify)
                      throw new TlsFatalAlert((short) 80 /*0x50*/);
                  }
                  else
                  {
                    if (TlsUtilities.IsTlsV12((TlsContext) this.m_tlsServerContext) != (this.m_certificateRequest.SupportedSignatureAlgorithms != null))
                      throw new TlsFatalAlert((short) 80 /*0x50*/);
                    this.m_certificateRequest = TlsUtilities.ValidateCertificateRequest(this.m_certificateRequest, this.m_keyExchange);
                    TlsUtilities.EstablishServerSigAlgs(securityParameters, this.m_certificateRequest);
                    if (ProtocolVersion.TLSv12.Equals(securityParameters.NegotiatedVersion))
                    {
                      TlsUtilities.TrackHashAlgorithms(this.m_handshakeHash, securityParameters.ServerSigAlgs);
                      if (this.m_tlsServerContext.Crypto.HasAnyStreamVerifiers(securityParameters.ServerSigAlgs))
                        this.m_handshakeHash.ForceBuffering();
                    }
                    else if (this.m_tlsServerContext.Crypto.HasAnyStreamVerifiersLegacy(this.m_certificateRequest.CertificateTypes))
                      this.m_handshakeHash.ForceBuffering();
                  }
                }
                this.m_handshakeHash.SealHashAlgorithms();
                if (this.m_certificateRequest != null)
                {
                  this.SendCertificateRequestMessage(this.m_certificateRequest);
                  this.m_connectionState = (short) 11;
                }
                this.SendServerHelloDoneMessage();
                this.m_connectionState = (short) 12;
                return;
              case 21:
                throw new TlsFatalAlert((short) 80 /*0x50*/);
              default:
                throw new TlsFatalAlert((short) 10);
            }
          case 11:
            switch (this.m_connectionState)
            {
              case 12:
              case 14:
                if (this.m_connectionState != (short) 14)
                  this.m_tlsServer.ProcessClientSupplementalData((IList<SupplementalDataEntry>) null);
                this.ReceiveCertificateMessage((MemoryStream) buf);
                this.m_connectionState = (short) 15;
                return;
              default:
                throw new TlsFatalAlert((short) 10);
            }
          case 15:
            if (this.m_connectionState != (short) 16 /*0x10*/)
              throw new TlsFatalAlert((short) 10);
            if (!this.ExpectCertificateVerifyMessage())
              throw new TlsFatalAlert((short) 10);
            this.ReceiveCertificateVerifyMessage((MemoryStream) buf);
            buf.UpdateHash((TlsHash) this.m_handshakeHash);
            this.m_connectionState = (short) 17;
            break;
          case 16 /*0x10*/:
            switch (this.m_connectionState)
            {
              case 12:
              case 14:
              case 15:
                if (this.m_connectionState == (short) 12)
                  this.m_tlsServer.ProcessClientSupplementalData((IList<SupplementalDataEntry>) null);
                if (this.m_connectionState != (short) 15)
                {
                  if (this.m_certificateRequest == null)
                  {
                    this.m_keyExchange.SkipClientCredentials();
                  }
                  else
                  {
                    if (TlsUtilities.IsTlsV12((TlsContext) this.m_tlsServerContext))
                      throw new TlsFatalAlert((short) 10);
                    if (TlsUtilities.IsSsl((TlsContext) this.m_tlsServerContext))
                      throw new TlsFatalAlert((short) 10);
                    this.NotifyClientCertificate(Certificate.EmptyChain);
                  }
                }
                this.ReceiveClientKeyExchangeMessage((MemoryStream) buf);
                this.m_connectionState = (short) 16 /*0x10*/;
                return;
              default:
                throw new TlsFatalAlert((short) 10);
            }
          case 20:
            switch (this.m_connectionState)
            {
              case 16 /*0x10*/:
              case 17:
                if (this.m_connectionState != (short) 17 && this.ExpectCertificateVerifyMessage())
                  throw new TlsFatalAlert((short) 10);
                this.ProcessFinishedMessage((MemoryStream) buf);
                buf.UpdateHash((TlsHash) this.m_handshakeHash);
                this.m_connectionState = (short) 18;
                if (this.m_expectSessionTicket)
                {
                  this.SendNewSessionTicketMessage(this.m_tlsServer.GetNewSessionTicket());
                  this.m_connectionState = (short) 19;
                }
                this.SendChangeCipherSpec();
                this.SendFinishedMessage();
                this.m_connectionState = (short) 20;
                this.CompleteHandshake();
                return;
              default:
                throw new TlsFatalAlert((short) 10);
            }
          case 23:
            if (this.m_connectionState != (short) 12)
              throw new TlsFatalAlert((short) 10);
            this.m_tlsServer.ProcessClientSupplementalData(TlsProtocol.ReadSupplementalDataMessage((MemoryStream) buf));
            this.m_connectionState = (short) 14;
            break;
          default:
            throw new TlsFatalAlert((short) 10);
        }
      }
    }
  }

  protected override void HandleAlertWarningMessage(short alertDescription)
  {
    if ((short) 41 == alertDescription && this.m_certificateRequest != null && TlsUtilities.IsSsl((TlsContext) this.m_tlsServerContext))
    {
      switch (this.m_connectionState)
      {
        case 12:
        case 14:
          if (this.m_connectionState != (short) 14)
            this.m_tlsServer.ProcessClientSupplementalData((IList<SupplementalDataEntry>) null);
          this.NotifyClientCertificate(Certificate.EmptyChain);
          this.m_connectionState = (short) 15;
          return;
      }
    }
    base.HandleAlertWarningMessage(alertDescription);
  }

  protected virtual void NotifyClientCertificate(Certificate clientCertificate)
  {
    if (this.m_certificateRequest == null)
      throw new TlsFatalAlert((short) 80 /*0x50*/);
    TlsUtilities.ProcessClientCertificate((TlsServerContext) this.m_tlsServerContext, clientCertificate, this.m_keyExchange, this.m_tlsServer);
  }

  protected virtual void Receive13ClientCertificate(MemoryStream buf)
  {
    if (this.m_certificateRequest == null)
      throw new TlsFatalAlert((short) 10);
    Certificate clientCertificate = Certificate.Parse(new Certificate.ParseOptions()
    {
      CertificateType = TlsExtensionsUtilities.GetClientCertificateTypeExtensionServer(this.m_serverExtensions, (short) 0),
      MaxChainLength = this.m_tlsServer.GetMaxCertificateChainLength()
    }, (TlsContext) this.m_tlsServerContext, (Stream) buf, (Stream) null);
    TlsProtocol.AssertEmpty(buf);
    this.NotifyClientCertificate(clientCertificate);
  }

  protected void Receive13ClientCertificateVerify(MemoryStream buf)
  {
    Certificate peerCertificate = this.m_tlsServerContext.SecurityParameters.PeerCertificate;
    if (peerCertificate == null || peerCertificate.IsEmpty)
      throw new TlsFatalAlert((short) 80 /*0x50*/);
    CertificateVerify certificateVerify = CertificateVerify.Parse((TlsContext) this.m_tlsServerContext, (Stream) buf);
    TlsProtocol.AssertEmpty(buf);
    TlsUtilities.Verify13CertificateVerifyClient((TlsServerContext) this.m_tlsServerContext, this.m_handshakeHash, certificateVerify);
  }

  protected virtual void Receive13ClientFinished(MemoryStream buf)
  {
    this.Process13FinishedMessage(buf);
  }

  protected virtual void ReceiveCertificateMessage(MemoryStream buf)
  {
    if (this.m_certificateRequest == null)
      throw new TlsFatalAlert((short) 10);
    Certificate clientCertificate = Certificate.Parse(new Certificate.ParseOptions()
    {
      CertificateType = TlsExtensionsUtilities.GetClientCertificateTypeExtensionServer(this.m_serverExtensions, (short) 0),
      MaxChainLength = this.m_tlsServer.GetMaxCertificateChainLength()
    }, (TlsContext) this.m_tlsServerContext, (Stream) buf, (Stream) null);
    TlsProtocol.AssertEmpty(buf);
    this.NotifyClientCertificate(clientCertificate);
  }

  protected virtual void ReceiveCertificateVerifyMessage(MemoryStream buf)
  {
    DigitallySigned certificateVerify = DigitallySigned.Parse((TlsContext) this.m_tlsServerContext, (Stream) buf);
    TlsProtocol.AssertEmpty(buf);
    TlsUtilities.VerifyCertificateVerifyClient((TlsServerContext) this.m_tlsServerContext, this.m_certificateRequest, certificateVerify, this.m_handshakeHash);
    this.m_handshakeHash.StopTracking();
  }

  protected virtual ClientHello ReceiveClientHelloMessage(MemoryStream buf)
  {
    return ClientHello.Parse(buf, (Stream) null);
  }

  protected virtual void ReceiveClientKeyExchangeMessage(MemoryStream buf)
  {
    this.m_keyExchange.ProcessClientKeyExchange((Stream) buf);
    TlsProtocol.AssertEmpty(buf);
    int num = TlsUtilities.IsSsl((TlsContext) this.m_tlsServerContext) ? 1 : 0;
    if (num != 0)
      TlsProtocol.EstablishMasterSecret((TlsContext) this.m_tlsServerContext, this.m_keyExchange);
    this.m_tlsServerContext.SecurityParameters.m_sessionHash = TlsUtilities.GetCurrentPrfHash(this.m_handshakeHash);
    if (num == 0)
      TlsProtocol.EstablishMasterSecret((TlsContext) this.m_tlsServerContext, this.m_keyExchange);
    this.m_recordStream.SetPendingCipher(TlsUtilities.InitCipher((TlsContext) this.m_tlsServerContext));
    if (this.ExpectCertificateVerifyMessage())
      return;
    this.m_handshakeHash.StopTracking();
  }

  protected virtual void Send13EncryptedExtensionsMessage(IDictionary<int, byte[]> serverExtensions)
  {
    byte[] buf = TlsProtocol.WriteExtensionsData(serverExtensions);
    HandshakeMessageOutput handshakeMessageOutput = new HandshakeMessageOutput((short) 8);
    HandshakeMessageOutput output = handshakeMessageOutput;
    TlsUtilities.WriteOpaque16(buf, (Stream) output);
    handshakeMessageOutput.Send((TlsProtocol) this);
  }

  protected virtual void Send13ServerHelloCoda(ServerHello serverHello, bool afterHelloRetryRequest)
  {
    SecurityParameters securityParameters = this.m_tlsServerContext.SecurityParameters;
    TlsUtilities.Establish13PhaseHandshake((TlsContext) this.m_tlsServerContext, TlsUtilities.GetCurrentPrfHash(this.m_handshakeHash), this.m_recordStream);
    this.m_recordStream.EnablePendingCipherWrite();
    this.m_recordStream.EnablePendingCipherRead(true);
    this.Send13EncryptedExtensionsMessage(this.m_serverExtensions);
    this.m_connectionState = (short) 5;
    if (!this.m_selectedPsk13)
    {
      this.m_certificateRequest = this.m_tlsServer.GetCertificateRequest();
      if (this.m_certificateRequest != null)
      {
        if (!this.m_certificateRequest.HasCertificateRequestContext(TlsUtilities.EmptyBytes))
          throw new TlsFatalAlert((short) 80 /*0x50*/);
        TlsUtilities.EstablishServerSigAlgs(securityParameters, this.m_certificateRequest);
        this.SendCertificateRequestMessage(this.m_certificateRequest);
        this.m_connectionState = (short) 11;
      }
      TlsCredentialedSigner credentialedSigner = TlsUtilities.Establish13ServerCredentials(this.m_tlsServer);
      if (credentialedSigner == null)
        throw new TlsFatalAlert((short) 80 /*0x50*/);
      this.Send13CertificateMessage(credentialedSigner.Certificate);
      securityParameters.m_tlsServerEndPoint = (byte[]) null;
      this.m_connectionState = (short) 7;
      this.Send13CertificateVerifyMessage(TlsUtilities.Generate13CertificateVerify((TlsContext) this.m_tlsServerContext, credentialedSigner, this.m_handshakeHash));
      this.m_connectionState = (short) 17;
    }
    this.Send13FinishedMessage();
    this.m_connectionState = (short) 20;
    TlsUtilities.Establish13PhaseApplication((TlsContext) this.m_tlsServerContext, TlsUtilities.GetCurrentPrfHash(this.m_handshakeHash), this.m_recordStream);
    this.m_recordStream.EnablePendingCipherWrite();
  }

  protected virtual void SendCertificateRequestMessage(CertificateRequest certificateRequest)
  {
    HandshakeMessageOutput output = new HandshakeMessageOutput((short) 13);
    certificateRequest.Encode((TlsContext) this.m_tlsServerContext, (Stream) output);
    output.Send((TlsProtocol) this);
  }

  protected virtual void SendCertificateStatusMessage(CertificateStatus certificateStatus)
  {
    HandshakeMessageOutput output = new HandshakeMessageOutput((short) 22);
    certificateStatus.Encode((Stream) output);
    output.Send((TlsProtocol) this);
  }

  protected virtual void SendHelloRequestMessage()
  {
    HandshakeMessageOutput.Send((TlsProtocol) this, (short) 0, TlsUtilities.EmptyBytes);
  }

  protected virtual void SendNewSessionTicketMessage(NewSessionTicket newSessionTicket)
  {
    if (newSessionTicket == null)
      throw new TlsFatalAlert((short) 80 /*0x50*/);
    HandshakeMessageOutput output = new HandshakeMessageOutput((short) 4);
    newSessionTicket.Encode((Stream) output);
    output.Send((TlsProtocol) this);
  }

  protected virtual void SendServerHelloDoneMessage()
  {
    HandshakeMessageOutput.Send((TlsProtocol) this, (short) 14, TlsUtilities.EmptyBytes);
  }

  protected virtual void SendServerHelloMessage(ServerHello serverHello)
  {
    HandshakeMessageOutput output = new HandshakeMessageOutput((short) 2);
    serverHello.Encode((TlsContext) this.m_tlsServerContext, (Stream) output);
    output.Send((TlsProtocol) this);
  }

  protected virtual void SendServerKeyExchangeMessage(byte[] serverKeyExchange)
  {
    HandshakeMessageOutput.Send((TlsProtocol) this, (short) 12, serverKeyExchange);
  }

  protected virtual void Skip13ClientCertificate()
  {
    if (this.m_certificateRequest != null)
      throw new TlsFatalAlert((short) 10);
  }

  protected virtual void Skip13ClientCertificateVerify()
  {
    if (this.ExpectCertificateVerifyMessage())
      throw new TlsFatalAlert((short) 10);
  }
}
