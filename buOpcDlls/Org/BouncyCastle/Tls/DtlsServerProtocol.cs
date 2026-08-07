// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Tls.DtlsServerProtocol
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

public class DtlsServerProtocol : DtlsProtocol
{
  protected bool m_verifyRequests = true;

  public virtual bool VerifyRequests
  {
    get => this.m_verifyRequests;
    set => this.m_verifyRequests = value;
  }

  public virtual DtlsTransport Accept(TlsServer server, DatagramTransport transport)
  {
    return this.Accept(server, transport, (DtlsRequest) null);
  }

  public virtual DtlsTransport Accept(
    TlsServer server,
    DatagramTransport transport,
    DtlsRequest request)
  {
    if (server == null)
      throw new ArgumentNullException(nameof (server));
    if (transport == null)
      throw new ArgumentNullException(nameof (transport));
    DtlsServerProtocol.ServerHandshakeState state = new DtlsServerProtocol.ServerHandshakeState();
    state.server = server;
    state.serverContext = new TlsServerContextImpl(server.Crypto);
    server.Init((TlsServerContext) state.serverContext);
    state.serverContext.HandshakeBeginning((TlsPeer) server);
    SecurityParameters securityParameters = state.serverContext.SecurityParameters;
    securityParameters.m_extendedPadding = server.ShouldUseExtendedPadding();
    DtlsRecordLayer dtlsRecordLayer = new DtlsRecordLayer((TlsContext) state.serverContext, (TlsPeer) state.server, transport);
    server.NotifyCloseHandle((TlsCloseable) dtlsRecordLayer);
    try
    {
      return this.ServerHandshake(state, dtlsRecordLayer, request);
    }
    catch (TlsFatalAlert ex)
    {
      this.AbortServerHandshake(state, dtlsRecordLayer, ex.AlertDescription);
      throw;
    }
    catch (IOException ex)
    {
      this.AbortServerHandshake(state, dtlsRecordLayer, (short) 80 /*0x50*/);
      throw;
    }
    catch (Exception ex)
    {
      this.AbortServerHandshake(state, dtlsRecordLayer, (short) 80 /*0x50*/);
      throw new TlsFatalAlert((short) 80 /*0x50*/, ex);
    }
    finally
    {
      securityParameters.Clear();
    }
  }

  internal virtual void AbortServerHandshake(
    DtlsServerProtocol.ServerHandshakeState state,
    DtlsRecordLayer recordLayer,
    short alertDescription)
  {
    recordLayer.Fail(alertDescription);
    this.InvalidateSession(state);
  }

  internal virtual DtlsTransport ServerHandshake(
    DtlsServerProtocol.ServerHandshakeState state,
    DtlsRecordLayer recordLayer,
    DtlsRequest request)
  {
    SecurityParameters securityParameters = state.serverContext.SecurityParameters;
    DtlsReliableHandshake handshake = new DtlsReliableHandshake((TlsContext) state.serverContext, recordLayer, state.server.GetHandshakeTimeoutMillis(), TlsUtilities.GetHandshakeResendTimeMillis((TlsPeer) state.server), request);
    if (request == null)
    {
      DtlsReliableHandshake.Message message = handshake.ReceiveMessage();
      if (message.Type != (short) 1)
        throw new TlsFatalAlert((short) 10);
      this.ProcessClientHello(state, message.Body);
    }
    else
      this.ProcessClientHello(state, request.ClientHello);
    state.tlsSession = TlsUtilities.ImportSession(TlsUtilities.EmptyBytes, (SessionParameters) null);
    state.sessionParameters = (SessionParameters) null;
    state.sessionMasterSecret = (TlsSecret) null;
    securityParameters.m_sessionID = state.tlsSession.SessionID;
    state.server.NotifySession(state.tlsSession);
    byte[] serverHello = this.GenerateServerHello(state, recordLayer);
    ProtocolVersion serverVersion = state.serverContext.ServerVersion;
    recordLayer.ReadVersion = serverVersion;
    recordLayer.SetWriteVersion(serverVersion);
    handshake.SendMessage((short) 2, serverHello);
    handshake.HandshakeHash.NotifyPrfDetermined();
    IList<SupplementalDataEntry> supplementalData1 = state.server.GetServerSupplementalData();
    if (supplementalData1 != null)
    {
      byte[] supplementalData2 = DtlsProtocol.GenerateSupplementalData(supplementalData1);
      handshake.SendMessage((short) 23, supplementalData2);
    }
    state.keyExchange = TlsUtilities.InitKeyExchangeServer((TlsServerContext) state.serverContext, state.server);
    state.serverCredentials = (TlsCredentials) null;
    if (!KeyExchangeAlgorithm.IsAnonymous(securityParameters.KeyExchangeAlgorithm))
      state.serverCredentials = TlsUtilities.EstablishServerCredentials(state.server);
    Certificate certificate = (Certificate) null;
    MemoryStream endPointHash = new MemoryStream();
    if (state.serverCredentials == null)
    {
      state.keyExchange.SkipServerCredentials();
    }
    else
    {
      state.keyExchange.ProcessServerCredentials(state.serverCredentials);
      certificate = state.serverCredentials.Certificate;
      DtlsProtocol.SendCertificateMessage((TlsContext) state.serverContext, handshake, certificate, (Stream) endPointHash);
    }
    securityParameters.m_tlsServerEndPoint = endPointHash.ToArray();
    if (certificate == null || certificate.IsEmpty)
      securityParameters.m_statusRequestVersion = 0;
    if (securityParameters.StatusRequestVersion > 0)
    {
      CertificateStatus certificateStatus1 = state.server.GetCertificateStatus();
      if (certificateStatus1 != null)
      {
        byte[] certificateStatus2 = this.GenerateCertificateStatus(state, certificateStatus1);
        handshake.SendMessage((short) 22, certificateStatus2);
      }
    }
    byte[] serverKeyExchange = state.keyExchange.GenerateServerKeyExchange();
    if (serverKeyExchange != null)
      handshake.SendMessage((short) 12, serverKeyExchange);
    if (state.serverCredentials != null)
    {
      state.certificateRequest = state.server.GetCertificateRequest();
      if (state.certificateRequest == null)
      {
        if (!state.keyExchange.RequiresCertificateVerify)
          throw new TlsFatalAlert((short) 80 /*0x50*/);
      }
      else
      {
        if (TlsUtilities.IsTlsV12((TlsContext) state.serverContext) != (state.certificateRequest.SupportedSignatureAlgorithms != null))
          throw new TlsFatalAlert((short) 80 /*0x50*/);
        state.certificateRequest = TlsUtilities.ValidateCertificateRequest(state.certificateRequest, state.keyExchange);
        TlsUtilities.EstablishServerSigAlgs(securityParameters, state.certificateRequest);
        if (ProtocolVersion.DTLSv12.Equals(securityParameters.NegotiatedVersion))
        {
          TlsUtilities.TrackHashAlgorithms(handshake.HandshakeHash, securityParameters.ServerSigAlgs);
          if (state.serverContext.Crypto.HasAnyStreamVerifiers(securityParameters.ServerSigAlgs))
            handshake.HandshakeHash.ForceBuffering();
        }
        else if (state.serverContext.Crypto.HasAnyStreamVerifiersLegacy(state.certificateRequest.CertificateTypes))
          handshake.HandshakeHash.ForceBuffering();
      }
    }
    handshake.HandshakeHash.SealHashAlgorithms();
    if (state.certificateRequest != null)
    {
      byte[] certificateRequest = this.GenerateCertificateRequest(state, state.certificateRequest);
      handshake.SendMessage((short) 13, certificateRequest);
    }
    handshake.SendMessage((short) 14, TlsUtilities.EmptyBytes);
    DtlsReliableHandshake.Message message1 = handshake.ReceiveMessage();
    if (message1.Type == (short) 23)
    {
      this.ProcessClientSupplementalData(state, message1.Body);
      message1 = handshake.ReceiveMessage();
    }
    else
      state.server.ProcessClientSupplementalData((IList<SupplementalDataEntry>) null);
    if (state.certificateRequest == null)
      state.keyExchange.SkipClientCredentials();
    else if (message1.Type == (short) 11)
    {
      this.ProcessClientCertificate(state, message1.Body);
      message1 = handshake.ReceiveMessage();
    }
    else
    {
      if (TlsUtilities.IsTlsV12((TlsContext) state.serverContext))
        throw new TlsFatalAlert((short) 10);
      this.NotifyClientCertificate(state, Certificate.EmptyChain);
    }
    if (message1.Type != (short) 16 /*0x10*/)
      throw new TlsFatalAlert((short) 10);
    this.ProcessClientKeyExchange(state, message1.Body);
    securityParameters.m_sessionHash = TlsUtilities.GetCurrentPrfHash(handshake.HandshakeHash);
    TlsProtocol.EstablishMasterSecret((TlsContext) state.serverContext, state.keyExchange);
    recordLayer.InitPendingEpoch(TlsUtilities.InitCipher((TlsContext) state.serverContext));
    if (this.ExpectCertificateVerifyMessage(state))
    {
      DtlsReliableHandshake.Message messageDelayedDigest = handshake.ReceiveMessageDelayedDigest((short) 15);
      byte[] body = messageDelayedDigest.Body;
      this.ProcessCertificateVerify(state, body, handshake.HandshakeHash);
      handshake.PrepareToFinish();
      handshake.UpdateHandshakeMessagesDigest(messageDelayedDigest);
    }
    else
      handshake.PrepareToFinish();
    securityParameters.m_peerVerifyData = TlsUtilities.CalculateVerifyData((TlsContext) state.serverContext, handshake.HandshakeHash, false);
    this.ProcessFinished(handshake.ReceiveMessageBody((short) 20), securityParameters.PeerVerifyData);
    if (state.expectSessionTicket)
    {
      NewSessionTicket newSessionTicket1 = state.server.GetNewSessionTicket();
      byte[] newSessionTicket2 = this.GenerateNewSessionTicket(state, newSessionTicket1);
      handshake.SendMessage((short) 4, newSessionTicket2);
    }
    securityParameters.m_localVerifyData = TlsUtilities.CalculateVerifyData((TlsContext) state.serverContext, handshake.HandshakeHash, true);
    handshake.SendMessage((short) 20, securityParameters.LocalVerifyData);
    handshake.Finish();
    state.sessionMasterSecret = securityParameters.MasterSecret;
    state.sessionParameters = new SessionParameters.Builder().SetCipherSuite(securityParameters.CipherSuite).SetExtendedMasterSecret(securityParameters.IsExtendedMasterSecret).SetLocalCertificate(securityParameters.LocalCertificate).SetMasterSecret(state.serverContext.Crypto.AdoptSecret(state.sessionMasterSecret)).SetNegotiatedVersion(securityParameters.NegotiatedVersion).SetPeerCertificate(securityParameters.PeerCertificate).SetPskIdentity(securityParameters.PskIdentity).SetSrpIdentity(securityParameters.SrpIdentity).SetServerExtensions(state.serverExtensions).Build();
    state.tlsSession = TlsUtilities.ImportSession(state.tlsSession.SessionID, state.sessionParameters);
    securityParameters.m_tlsUnique = securityParameters.PeerVerifyData;
    state.serverContext.HandshakeComplete((TlsPeer) state.server, state.tlsSession);
    recordLayer.InitHeartbeat(state.heartbeat, (short) 1 == state.heartbeatPolicy);
    return new DtlsTransport(recordLayer, state.server.IgnoreCorruptDtlsRecords);
  }

  protected virtual byte[] GenerateCertificateRequest(
    DtlsServerProtocol.ServerHandshakeState state,
    CertificateRequest certificateRequest)
  {
    MemoryStream output = new MemoryStream();
    certificateRequest.Encode((TlsContext) state.serverContext, (Stream) output);
    return output.ToArray();
  }

  protected virtual byte[] GenerateCertificateStatus(
    DtlsServerProtocol.ServerHandshakeState state,
    CertificateStatus certificateStatus)
  {
    MemoryStream output = new MemoryStream();
    certificateStatus.Encode((Stream) output);
    return output.ToArray();
  }

  protected virtual byte[] GenerateNewSessionTicket(
    DtlsServerProtocol.ServerHandshakeState state,
    NewSessionTicket newSessionTicket)
  {
    MemoryStream output = new MemoryStream();
    newSessionTicket.Encode((Stream) output);
    return output.ToArray();
  }

  internal virtual byte[] GenerateServerHello(
    DtlsServerProtocol.ServerHandshakeState state,
    DtlsRecordLayer recordLayer)
  {
    TlsServerContextImpl serverContext1 = state.serverContext;
    SecurityParameters securityParameters = serverContext1.SecurityParameters;
    ProtocolVersion serverVersion = state.server.GetServerVersion();
    if (!ProtocolVersion.Contains(serverContext1.ClientSupportedVersions, serverVersion))
      throw new TlsFatalAlert((short) 80 /*0x50*/);
    securityParameters.m_negotiatedVersion = serverVersion;
    TlsUtilities.NegotiatedVersionDtlsServer((TlsServerContext) serverContext1);
    bool useGmtUnixTime = ProtocolVersion.DTLSv12.IsEqualOrLaterVersionOf(serverVersion) && state.server.ShouldUseGmtUnixTime();
    securityParameters.m_serverRandom = TlsProtocol.CreateRandomBlock(useGmtUnixTime, (TlsContext) serverContext1);
    if (!serverVersion.Equals(ProtocolVersion.GetLatestDtls(state.server.GetProtocolVersions())))
      TlsUtilities.WriteDowngradeMarker(serverVersion, securityParameters.ServerRandom);
    int cipherSuite = DtlsProtocol.ValidateSelectedCipherSuite(state.server.GetSelectedCipherSuite(), (short) 80 /*0x50*/);
    if (!TlsUtilities.IsValidCipherSuiteSelection(state.offeredCipherSuites, cipherSuite) || !TlsUtilities.IsValidVersionForCipherSuite(cipherSuite, securityParameters.NegotiatedVersion))
      throw new TlsFatalAlert((short) 80 /*0x50*/);
    TlsUtilities.NegotiatedCipherSuite(securityParameters, cipherSuite);
    state.serverExtensions = TlsExtensionsUtilities.EnsureExtensionsInitialised(state.server.GetServerExtensions());
    state.server.GetServerExtensionsForConnection(state.serverExtensions);
    ProtocolVersion version = serverVersion;
    if (serverVersion.IsLaterVersionOf(ProtocolVersion.DTLSv12))
    {
      version = ProtocolVersion.DTLSv12;
      TlsExtensionsUtilities.AddSupportedVersionsExtensionServer(state.serverExtensions, serverVersion);
    }
    if (securityParameters.IsSecureRenegotiation && TlsUtilities.GetExtensionData(state.serverExtensions, 65281) == null)
      state.serverExtensions[65281] = TlsProtocol.CreateRenegotiationInfo(TlsUtilities.EmptyBytes);
    if (TlsUtilities.IsTlsV13(serverVersion))
    {
      securityParameters.m_extendedMasterSecret = true;
    }
    else
    {
      securityParameters.m_extendedMasterSecret = state.offeredExtendedMasterSecret && state.server.ShouldUseExtendedMasterSecret();
      if (securityParameters.IsExtendedMasterSecret)
      {
        TlsExtensionsUtilities.AddExtendedMasterSecretExtension(state.serverExtensions);
      }
      else
      {
        if (state.server.RequiresExtendedMasterSecret())
          throw new TlsFatalAlert((short) 40);
        if (state.resumedSession && !state.server.AllowLegacyResumption())
          throw new TlsFatalAlert((short) 80 /*0x50*/);
      }
    }
    if (state.heartbeat != null || (short) 1 == state.heartbeatPolicy)
      TlsExtensionsUtilities.AddHeartbeatExtension(state.serverExtensions, new HeartbeatExtension(state.heartbeatPolicy));
    securityParameters.m_applicationProtocol = TlsExtensionsUtilities.GetAlpnExtensionServer(state.serverExtensions);
    securityParameters.m_applicationProtocolSet = true;
    if (ProtocolVersion.DTLSv12.Equals(securityParameters.NegotiatedVersion))
    {
      byte[] connectionIdExtension = TlsExtensionsUtilities.GetConnectionIDExtension(state.serverExtensions);
      if (connectionIdExtension != null)
      {
        byte[] numArray = TlsExtensionsUtilities.GetConnectionIDExtension(state.clientExtensions) ?? throw new TlsFatalAlert((short) 80 /*0x50*/);
        securityParameters.m_connectionIDLocal = numArray;
        securityParameters.m_connectionIDPeer = connectionIdExtension;
      }
    }
    if (state.serverExtensions.Count > 0)
    {
      securityParameters.m_encryptThenMac = TlsExtensionsUtilities.HasEncryptThenMacExtension(state.serverExtensions);
      securityParameters.m_maxFragmentLength = DtlsProtocol.EvaluateMaxFragmentLengthExtension(state.resumedSession, state.clientExtensions, state.serverExtensions, (short) 80 /*0x50*/);
      securityParameters.m_truncatedHmac = TlsExtensionsUtilities.HasTruncatedHmacExtension(state.serverExtensions);
      if (!state.resumedSession)
      {
        if (TlsUtilities.HasExpectedEmptyExtensionData(state.serverExtensions, 17, (short) 80 /*0x50*/))
          securityParameters.m_statusRequestVersion = 2;
        else if (TlsUtilities.HasExpectedEmptyExtensionData(state.serverExtensions, 5, (short) 80 /*0x50*/))
          securityParameters.m_statusRequestVersion = 1;
      }
      state.expectSessionTicket = !state.resumedSession && TlsUtilities.HasExpectedEmptyExtensionData(state.serverExtensions, 35, (short) 80 /*0x50*/);
    }
    DtlsProtocol.ApplyMaxFragmentLengthExtension(recordLayer, securityParameters.MaxFragmentLength);
    ServerHello serverHello = new ServerHello(version, securityParameters.ServerRandom, state.tlsSession.SessionID, securityParameters.CipherSuite, state.serverExtensions);
    MemoryStream memoryStream = new MemoryStream();
    TlsServerContextImpl serverContext2 = state.serverContext;
    MemoryStream output = memoryStream;
    serverHello.Encode((TlsContext) serverContext2, (Stream) output);
    return memoryStream.ToArray();
  }

  protected virtual void InvalidateSession(DtlsServerProtocol.ServerHandshakeState state)
  {
    if (state.sessionMasterSecret != null)
    {
      state.sessionMasterSecret.Destroy();
      state.sessionMasterSecret = (TlsSecret) null;
    }
    if (state.sessionParameters != null)
    {
      state.sessionParameters.Clear();
      state.sessionParameters = (SessionParameters) null;
    }
    if (state.tlsSession == null)
      return;
    state.tlsSession.Invalidate();
    state.tlsSession = (TlsSession) null;
  }

  protected virtual void NotifyClientCertificate(
    DtlsServerProtocol.ServerHandshakeState state,
    Certificate clientCertificate)
  {
    if (state.certificateRequest == null)
      throw new TlsFatalAlert((short) 80 /*0x50*/);
    TlsUtilities.ProcessClientCertificate((TlsServerContext) state.serverContext, clientCertificate, state.keyExchange, state.server);
  }

  protected virtual void ProcessClientCertificate(
    DtlsServerProtocol.ServerHandshakeState state,
    byte[] body)
  {
    MemoryStream memoryStream = new MemoryStream(body, false);
    Certificate clientCertificate = Certificate.Parse(new Certificate.ParseOptions()
    {
      CertificateType = TlsExtensionsUtilities.GetClientCertificateTypeExtensionServer(state.clientExtensions, (short) 0),
      MaxChainLength = state.server.GetMaxCertificateChainLength()
    }, (TlsContext) state.serverContext, (Stream) memoryStream, (Stream) null);
    TlsProtocol.AssertEmpty(memoryStream);
    this.NotifyClientCertificate(state, clientCertificate);
  }

  protected virtual void ProcessCertificateVerify(
    DtlsServerProtocol.ServerHandshakeState state,
    byte[] body,
    TlsHandshakeHash handshakeHash)
  {
    if (state.certificateRequest == null)
      throw new InvalidOperationException();
    MemoryStream memoryStream = new MemoryStream(body, false);
    TlsServerContextImpl serverContext = state.serverContext;
    DigitallySigned certificateVerify = DigitallySigned.Parse((TlsContext) serverContext, (Stream) memoryStream);
    TlsProtocol.AssertEmpty(memoryStream);
    TlsUtilities.VerifyCertificateVerifyClient((TlsServerContext) serverContext, state.certificateRequest, certificateVerify, handshakeHash);
  }

  protected virtual void ProcessClientHello(
    DtlsServerProtocol.ServerHandshakeState state,
    byte[] body)
  {
    ClientHello clientHello = ClientHello.Parse(new MemoryStream(body, false), Stream.Null);
    this.ProcessClientHello(state, clientHello);
  }

  protected virtual void ProcessClientHello(
    DtlsServerProtocol.ServerHandshakeState state,
    ClientHello clientHello)
  {
    ProtocolVersion version = clientHello.Version;
    state.offeredCipherSuites = clientHello.CipherSuites;
    state.clientExtensions = clientHello.Extensions;
    TlsServerContextImpl serverContext = state.serverContext;
    SecurityParameters securityParameters = serverContext.SecurityParameters;
    if (!version.IsDtls)
      throw new TlsFatalAlert((short) 47);
    serverContext.SetRsaPreMasterSecretVersion(version);
    serverContext.SetClientSupportedVersions(TlsExtensionsUtilities.GetSupportedVersionsExtensionClient(state.clientExtensions));
    ProtocolVersion protocolVersion = version;
    if (serverContext.ClientSupportedVersions == null)
    {
      if (protocolVersion.IsLaterVersionOf(ProtocolVersion.DTLSv12))
        protocolVersion = ProtocolVersion.DTLSv12;
      serverContext.SetClientSupportedVersions(protocolVersion.DownTo(ProtocolVersion.DTLSv10));
    }
    else
      protocolVersion = ProtocolVersion.GetLatestDtls(serverContext.ClientSupportedVersions);
    if (!ProtocolVersion.SERVER_EARLIEST_SUPPORTED_DTLS.IsEqualOrEarlierVersionOf(protocolVersion))
      throw new TlsFatalAlert((short) 70);
    serverContext.SetClientVersion(protocolVersion);
    state.server.NotifyClientVersion(serverContext.ClientVersion);
    securityParameters.m_clientRandom = clientHello.Random;
    state.server.NotifyFallback(Arrays.Contains(state.offeredCipherSuites, 22016));
    state.server.NotifyOfferedCipherSuites(state.offeredCipherSuites);
    if (Arrays.Contains(state.offeredCipherSuites, (int) byte.MaxValue))
      securityParameters.m_secureRenegotiation = true;
    byte[] extensionData = TlsUtilities.GetExtensionData(state.clientExtensions, 65281);
    if (extensionData != null)
    {
      securityParameters.m_secureRenegotiation = true;
      if (!Arrays.FixedTimeEquals(extensionData, TlsProtocol.CreateRenegotiationInfo(TlsUtilities.EmptyBytes)))
        throw new TlsFatalAlert((short) 40);
    }
    state.server.NotifySecureRenegotiation(securityParameters.IsSecureRenegotiation);
    state.offeredExtendedMasterSecret = TlsExtensionsUtilities.HasExtendedMasterSecretExtension(state.clientExtensions);
    if (state.clientExtensions == null)
      return;
    TlsExtensionsUtilities.GetPaddingExtension(state.clientExtensions);
    securityParameters.m_clientServerNames = TlsExtensionsUtilities.GetServerNameExtensionClient(state.clientExtensions);
    if (TlsUtilities.IsSignatureAlgorithmsExtensionAllowed(protocolVersion))
      TlsUtilities.EstablishClientSigAlgs(securityParameters, state.clientExtensions);
    securityParameters.m_clientSupportedGroups = TlsExtensionsUtilities.GetSupportedGroupsExtension(state.clientExtensions);
    HeartbeatExtension heartbeatExtension = TlsExtensionsUtilities.GetHeartbeatExtension(state.clientExtensions);
    if (heartbeatExtension != null)
    {
      if ((short) 1 == heartbeatExtension.Mode)
        state.heartbeat = state.server.GetHeartbeat();
      state.heartbeatPolicy = state.server.GetHeartbeatPolicy();
    }
    state.server.ProcessClientExtensions(state.clientExtensions);
  }

  protected virtual void ProcessClientKeyExchange(
    DtlsServerProtocol.ServerHandshakeState state,
    byte[] body)
  {
    MemoryStream memoryStream = new MemoryStream(body, false);
    state.keyExchange.ProcessClientKeyExchange((Stream) memoryStream);
    TlsProtocol.AssertEmpty(memoryStream);
  }

  protected virtual void ProcessClientSupplementalData(
    DtlsServerProtocol.ServerHandshakeState state,
    byte[] body)
  {
    IList<SupplementalDataEntry> clientSupplementalData = TlsProtocol.ReadSupplementalDataMessage(new MemoryStream(body, false));
    state.server.ProcessClientSupplementalData(clientSupplementalData);
  }

  protected virtual bool ExpectCertificateVerifyMessage(
    DtlsServerProtocol.ServerHandshakeState state)
  {
    if (state.certificateRequest == null)
      return false;
    Certificate peerCertificate = state.serverContext.SecurityParameters.PeerCertificate;
    if (peerCertificate == null || peerCertificate.IsEmpty)
      return false;
    return state.keyExchange == null || state.keyExchange.RequiresCertificateVerify;
  }

  protected internal class ServerHandshakeState
  {
    internal TlsServer server;
    internal TlsServerContextImpl serverContext;
    internal TlsSession tlsSession;
    internal SessionParameters sessionParameters;
    internal TlsSecret sessionMasterSecret;
    internal SessionParameters.Builder sessionParametersBuilder;
    internal int[] offeredCipherSuites;
    internal IDictionary<int, byte[]> clientExtensions;
    internal IDictionary<int, byte[]> serverExtensions;
    internal bool offeredExtendedMasterSecret;
    internal bool resumedSession;
    internal bool expectSessionTicket;
    internal TlsKeyExchange keyExchange;
    internal TlsCredentials serverCredentials;
    internal CertificateRequest certificateRequest;
    internal TlsHeartbeat heartbeat;
    internal short heartbeatPolicy = 2;
  }
}
