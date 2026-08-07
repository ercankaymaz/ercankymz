// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Tls.DtlsClientProtocol
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

public class DtlsClientProtocol : DtlsProtocol
{
  public virtual DtlsTransport Connect(TlsClient client, DatagramTransport transport)
  {
    if (client == null)
      throw new ArgumentNullException(nameof (client));
    if (transport == null)
      throw new ArgumentNullException(nameof (transport));
    DtlsClientProtocol.ClientHandshakeState state = new DtlsClientProtocol.ClientHandshakeState();
    state.client = client;
    state.clientContext = new TlsClientContextImpl(client.Crypto);
    client.Init((TlsClientContext) state.clientContext);
    state.clientContext.HandshakeBeginning((TlsPeer) client);
    SecurityParameters securityParameters = state.clientContext.SecurityParameters;
    securityParameters.m_extendedPadding = client.ShouldUseExtendedPadding();
    TlsSession sessionToResume = state.client.GetSessionToResume();
    if (sessionToResume != null && sessionToResume.IsResumable)
    {
      SessionParameters sessionParameters = sessionToResume.ExportSessionParameters();
      if (sessionParameters != null && (sessionParameters.IsExtendedMasterSecret || !state.client.RequiresExtendedMasterSecret() && state.client.AllowLegacyResumption()))
      {
        TlsSecret masterSecret = sessionParameters.MasterSecret;
        lock (masterSecret)
        {
          if (masterSecret.IsAlive())
          {
            state.tlsSession = sessionToResume;
            state.sessionParameters = sessionParameters;
            state.sessionMasterSecret = state.clientContext.Crypto.AdoptSecret(masterSecret);
          }
        }
      }
    }
    DtlsRecordLayer dtlsRecordLayer = new DtlsRecordLayer((TlsContext) state.clientContext, (TlsPeer) state.client, transport);
    client.NotifyCloseHandle((TlsCloseable) dtlsRecordLayer);
    try
    {
      return this.ClientHandshake(state, dtlsRecordLayer);
    }
    catch (TlsFatalAlert ex)
    {
      this.AbortClientHandshake(state, dtlsRecordLayer, ex.AlertDescription);
      throw;
    }
    catch (IOException ex)
    {
      this.AbortClientHandshake(state, dtlsRecordLayer, (short) 80 /*0x50*/);
      throw;
    }
    catch (Exception ex)
    {
      this.AbortClientHandshake(state, dtlsRecordLayer, (short) 80 /*0x50*/);
      throw new TlsFatalAlert((short) 80 /*0x50*/, ex);
    }
    finally
    {
      securityParameters.Clear();
    }
  }

  internal virtual void AbortClientHandshake(
    DtlsClientProtocol.ClientHandshakeState state,
    DtlsRecordLayer recordLayer,
    short alertDescription)
  {
    recordLayer.Fail(alertDescription);
    this.InvalidateSession(state);
  }

  internal virtual DtlsTransport ClientHandshake(
    DtlsClientProtocol.ClientHandshakeState state,
    DtlsRecordLayer recordLayer)
  {
    SecurityParameters securityParameters = state.clientContext.SecurityParameters;
    DtlsReliableHandshake handshake = new DtlsReliableHandshake((TlsContext) state.clientContext, recordLayer, state.client.GetHandshakeTimeoutMillis(), TlsUtilities.GetHandshakeResendTimeMillis((TlsPeer) state.client), (DtlsRequest) null);
    byte[] clientHello = this.GenerateClientHello(state);
    recordLayer.SetWriteVersion(ProtocolVersion.DTLSv10);
    handshake.SendMessage((short) 1, clientHello);
    DtlsReliableHandshake.Message message1;
    for (message1 = handshake.ReceiveMessage(); message1.Type == (short) 3; message1 = handshake.ReceiveMessage())
    {
      byte[] cookie = this.ProcessHelloVerifyRequest(state, message1.Body);
      byte[] body = DtlsClientProtocol.PatchClientHelloWithCookie(clientHello, cookie);
      handshake.ResetAfterHelloVerifyRequestClient();
      handshake.SendMessage((short) 1, body);
    }
    if (message1.Type != (short) 2)
      throw new TlsFatalAlert((short) 10);
    ProtocolVersion readVersion = recordLayer.ReadVersion;
    this.ReportServerVersion(state, readVersion);
    recordLayer.SetWriteVersion(readVersion);
    this.ProcessServerHello(state, message1.Body);
    handshake.HandshakeHash.NotifyPrfDetermined();
    DtlsProtocol.ApplyMaxFragmentLengthExtension(recordLayer, securityParameters.MaxFragmentLength);
    if (state.resumedSession)
    {
      securityParameters.m_masterSecret = state.sessionMasterSecret;
      recordLayer.InitPendingEpoch(TlsUtilities.InitCipher((TlsContext) state.clientContext));
      securityParameters.m_peerVerifyData = TlsUtilities.CalculateVerifyData((TlsContext) state.clientContext, handshake.HandshakeHash, true);
      this.ProcessFinished(handshake.ReceiveMessageBody((short) 20), securityParameters.PeerVerifyData);
      securityParameters.m_localVerifyData = TlsUtilities.CalculateVerifyData((TlsContext) state.clientContext, handshake.HandshakeHash, false);
      handshake.SendMessage((short) 20, securityParameters.LocalVerifyData);
      handshake.Finish();
      if (securityParameters.IsExtendedMasterSecret)
        securityParameters.m_tlsUnique = securityParameters.PeerVerifyData;
      securityParameters.m_localCertificate = state.sessionParameters.LocalCertificate;
      securityParameters.m_peerCertificate = state.sessionParameters.PeerCertificate;
      securityParameters.m_pskIdentity = state.sessionParameters.PskIdentity;
      securityParameters.m_srpIdentity = state.sessionParameters.SrpIdentity;
      state.clientContext.HandshakeComplete((TlsPeer) state.client, state.tlsSession);
      recordLayer.InitHeartbeat(state.heartbeat, (short) 1 == state.heartbeatPolicy);
      return new DtlsTransport(recordLayer, state.client.IgnoreCorruptDtlsRecords);
    }
    this.InvalidateSession(state);
    state.tlsSession = TlsUtilities.ImportSession(securityParameters.SessionID, (SessionParameters) null);
    DtlsReliableHandshake.Message message2 = handshake.ReceiveMessage();
    if (message2.Type == (short) 23)
    {
      this.ProcessServerSupplementalData(state, message2.Body);
      message2 = handshake.ReceiveMessage();
    }
    else
      state.client.ProcessServerSupplementalData((IList<SupplementalDataEntry>) null);
    state.keyExchange = TlsUtilities.InitKeyExchangeClient((TlsClientContext) state.clientContext, state.client);
    if (message2.Type == (short) 11)
    {
      this.ProcessServerCertificate(state, message2.Body);
      message2 = handshake.ReceiveMessage();
    }
    else
      state.authentication = (TlsAuthentication) null;
    if (message2.Type == (short) 22)
    {
      if (securityParameters.StatusRequestVersion < 1)
        throw new TlsFatalAlert((short) 10);
      this.ProcessCertificateStatus(state, message2.Body);
      message2 = handshake.ReceiveMessage();
    }
    TlsUtilities.ProcessServerCertificate((TlsClientContext) state.clientContext, state.certificateStatus, state.keyExchange, state.authentication, state.clientExtensions, state.serverExtensions);
    if (message2.Type == (short) 12)
    {
      this.ProcessServerKeyExchange(state, message2.Body);
      message2 = handshake.ReceiveMessage();
    }
    else
      state.keyExchange.SkipServerKeyExchange();
    if (message2.Type == (short) 13)
    {
      this.ProcessCertificateRequest(state, message2.Body);
      TlsUtilities.EstablishServerSigAlgs(securityParameters, state.certificateRequest);
      message2 = handshake.ReceiveMessage();
    }
    if (message2.Type != (short) 14)
      throw new TlsFatalAlert((short) 10);
    if (message2.Body.Length != 0)
      throw new TlsFatalAlert((short) 50);
    TlsCredentials clientCredentials = (TlsCredentials) null;
    TlsCredentialedSigner credentialedSigner = (TlsCredentialedSigner) null;
    Certificate certificate = (Certificate) null;
    SignatureAndHashAlgorithm andHashAlgorithm = (SignatureAndHashAlgorithm) null;
    TlsStreamSigner clientAuthStreamSigner = (TlsStreamSigner) null;
    if (state.certificateRequest != null)
    {
      clientCredentials = TlsUtilities.EstablishClientCredentials(state.authentication, state.certificateRequest);
      if (clientCredentials != null)
      {
        certificate = clientCredentials.Certificate;
        if (clientCredentials is TlsCredentialedSigner)
        {
          credentialedSigner = (TlsCredentialedSigner) clientCredentials;
          andHashAlgorithm = TlsUtilities.GetSignatureAndHashAlgorithm(securityParameters.NegotiatedVersion, credentialedSigner);
          clientAuthStreamSigner = credentialedSigner.GetStreamSigner();
          if (ProtocolVersion.DTLSv12.Equals(securityParameters.NegotiatedVersion))
          {
            TlsUtilities.VerifySupportedSignatureAlgorithm(securityParameters.ServerSigAlgs, andHashAlgorithm, (short) 80 /*0x50*/);
            if (clientAuthStreamSigner == null)
              TlsUtilities.TrackHashAlgorithmClient(handshake.HandshakeHash, andHashAlgorithm);
          }
          if (clientAuthStreamSigner != null)
            handshake.HandshakeHash.ForceBuffering();
        }
      }
    }
    handshake.HandshakeHash.SealHashAlgorithms();
    if (clientCredentials == null)
      state.keyExchange.SkipClientCredentials();
    else
      state.keyExchange.ProcessClientCredentials(clientCredentials);
    IList<SupplementalDataEntry> supplementalData1 = state.client.GetClientSupplementalData();
    if (supplementalData1 != null)
    {
      byte[] supplementalData2 = DtlsProtocol.GenerateSupplementalData(supplementalData1);
      handshake.SendMessage((short) 23, supplementalData2);
    }
    if (state.certificateRequest != null)
      DtlsProtocol.SendCertificateMessage((TlsContext) state.clientContext, handshake, certificate, (Stream) null);
    byte[] clientKeyExchange = this.GenerateClientKeyExchange(state);
    handshake.SendMessage((short) 16 /*0x10*/, clientKeyExchange);
    securityParameters.m_sessionHash = TlsUtilities.GetCurrentPrfHash(handshake.HandshakeHash);
    TlsProtocol.EstablishMasterSecret((TlsContext) state.clientContext, state.keyExchange);
    recordLayer.InitPendingEpoch(TlsUtilities.InitCipher((TlsContext) state.clientContext));
    if (credentialedSigner != null)
    {
      DigitallySigned certificateVerifyClient = TlsUtilities.GenerateCertificateVerifyClient((TlsClientContext) state.clientContext, credentialedSigner, andHashAlgorithm, clientAuthStreamSigner, handshake.HandshakeHash);
      byte[] certificateVerify = this.GenerateCertificateVerify(state, certificateVerifyClient);
      handshake.SendMessage((short) 15, certificateVerify);
    }
    handshake.PrepareToFinish();
    securityParameters.m_localVerifyData = TlsUtilities.CalculateVerifyData((TlsContext) state.clientContext, handshake.HandshakeHash, false);
    handshake.SendMessage((short) 20, securityParameters.LocalVerifyData);
    if (state.expectSessionTicket)
    {
      DtlsReliableHandshake.Message message3 = handshake.ReceiveMessage();
      if (message3.Type != (short) 4)
        throw new TlsFatalAlert((short) 10);
      securityParameters.m_sessionID = TlsUtilities.EmptyBytes;
      this.InvalidateSession(state);
      state.tlsSession = TlsUtilities.ImportSession(securityParameters.SessionID, (SessionParameters) null);
      this.ProcessNewSessionTicket(state, message3.Body);
    }
    securityParameters.m_peerVerifyData = TlsUtilities.CalculateVerifyData((TlsContext) state.clientContext, handshake.HandshakeHash, true);
    this.ProcessFinished(handshake.ReceiveMessageBody((short) 20), securityParameters.PeerVerifyData);
    handshake.Finish();
    state.sessionMasterSecret = securityParameters.MasterSecret;
    state.sessionParameters = new SessionParameters.Builder().SetCipherSuite(securityParameters.CipherSuite).SetExtendedMasterSecret(securityParameters.IsExtendedMasterSecret).SetLocalCertificate(securityParameters.LocalCertificate).SetMasterSecret(state.clientContext.Crypto.AdoptSecret(state.sessionMasterSecret)).SetNegotiatedVersion(securityParameters.NegotiatedVersion).SetPeerCertificate(securityParameters.PeerCertificate).SetPskIdentity(securityParameters.PskIdentity).SetSrpIdentity(securityParameters.SrpIdentity).SetServerExtensions(state.serverExtensions).Build();
    state.tlsSession = TlsUtilities.ImportSession(securityParameters.SessionID, state.sessionParameters);
    securityParameters.m_tlsUnique = securityParameters.LocalVerifyData;
    state.clientContext.HandshakeComplete((TlsPeer) state.client, state.tlsSession);
    recordLayer.InitHeartbeat(state.heartbeat, (short) 1 == state.heartbeatPolicy);
    return new DtlsTransport(recordLayer, state.client.IgnoreCorruptDtlsRecords);
  }

  protected virtual byte[] GenerateCertificateVerify(
    DtlsClientProtocol.ClientHandshakeState state,
    DigitallySigned certificateVerify)
  {
    MemoryStream output = new MemoryStream();
    certificateVerify.Encode((Stream) output);
    return output.ToArray();
  }

  protected virtual byte[] GenerateClientHello(DtlsClientProtocol.ClientHandshakeState state)
  {
    TlsClientContextImpl clientContext1 = state.clientContext;
    SecurityParameters securityParameters = clientContext1.SecurityParameters;
    clientContext1.SetClientSupportedVersions(state.client.GetProtocolVersions());
    ProtocolVersion latestDtls = ProtocolVersion.GetLatestDtls(clientContext1.ClientSupportedVersions);
    if (!ProtocolVersion.IsSupportedDtlsVersionClient(latestDtls))
      throw new TlsFatalAlert((short) 80 /*0x50*/);
    clientContext1.SetClientVersion(latestDtls);
    bool useGmtUnixTime = ProtocolVersion.DTLSv12.IsEqualOrLaterVersionOf(latestDtls) && state.client.ShouldUseGmtUnixTime();
    securityParameters.m_clientRandom = TlsProtocol.CreateRandomBlock(useGmtUnixTime, (TlsContext) state.clientContext);
    byte[] sessionID = TlsUtilities.GetSessionID(state.tlsSession);
    int num = state.client.IsFallback() ? 1 : 0;
    state.offeredCipherSuites = state.client.GetCipherSuites();
    if (sessionID.Length != 0 && state.sessionParameters != null && !Arrays.Contains(state.offeredCipherSuites, state.sessionParameters.CipherSuite))
      sessionID = TlsUtilities.EmptyBytes;
    state.clientExtensions = TlsExtensionsUtilities.EnsureExtensionsInitialised(state.client.GetClientExtensions());
    ProtocolVersion protocolVersion = latestDtls;
    if (latestDtls.IsLaterVersionOf(ProtocolVersion.DTLSv12))
    {
      protocolVersion = ProtocolVersion.DTLSv12;
      TlsExtensionsUtilities.AddSupportedVersionsExtensionClient(state.clientExtensions, clientContext1.ClientSupportedVersions);
    }
    clientContext1.SetRsaPreMasterSecretVersion(protocolVersion);
    securityParameters.m_clientServerNames = TlsExtensionsUtilities.GetServerNameExtensionClient(state.clientExtensions);
    if (TlsUtilities.IsSignatureAlgorithmsExtensionAllowed(latestDtls))
      TlsUtilities.EstablishClientSigAlgs(securityParameters, state.clientExtensions);
    securityParameters.m_clientSupportedGroups = TlsExtensionsUtilities.GetSupportedGroupsExtension(state.clientExtensions);
    state.clientAgreements = TlsUtilities.AddKeyShareToClientHello((TlsClientContext) state.clientContext, state.client, state.clientExtensions);
    if (TlsUtilities.IsExtendedMasterSecretOptionalDtls(clientContext1.ClientSupportedVersions) && state.client.ShouldUseExtendedMasterSecret())
      TlsExtensionsUtilities.AddExtendedMasterSecretExtension(state.clientExtensions);
    else if (!TlsUtilities.IsTlsV13(latestDtls) && state.client.RequiresExtendedMasterSecret())
      throw new TlsFatalAlert((short) 80 /*0x50*/);
    if (TlsUtilities.GetExtensionData(state.clientExtensions, 65281) == null & !Arrays.Contains(state.offeredCipherSuites, (int) byte.MaxValue))
      state.offeredCipherSuites = Arrays.Append(state.offeredCipherSuites, (int) byte.MaxValue);
    if (num != 0 && !Arrays.Contains(state.offeredCipherSuites, 22016))
      state.offeredCipherSuites = Arrays.Append(state.offeredCipherSuites, 22016);
    state.heartbeat = state.client.GetHeartbeat();
    state.heartbeatPolicy = state.client.GetHeartbeatPolicy();
    if (state.heartbeat != null || (short) 1 == state.heartbeatPolicy)
      TlsExtensionsUtilities.AddHeartbeatExtension(state.clientExtensions, new HeartbeatExtension(state.heartbeatPolicy));
    ClientHello clientHello = new ClientHello(protocolVersion, securityParameters.ClientRandom, sessionID, TlsUtilities.EmptyBytes, state.offeredCipherSuites, state.clientExtensions, 0);
    MemoryStream memoryStream = new MemoryStream();
    TlsClientContextImpl clientContext2 = state.clientContext;
    MemoryStream output = memoryStream;
    clientHello.Encode((TlsContext) clientContext2, (Stream) output);
    return memoryStream.ToArray();
  }

  protected virtual byte[] GenerateClientKeyExchange(DtlsClientProtocol.ClientHandshakeState state)
  {
    MemoryStream output = new MemoryStream();
    state.keyExchange.GenerateClientKeyExchange((Stream) output);
    return output.ToArray();
  }

  protected virtual void InvalidateSession(DtlsClientProtocol.ClientHandshakeState state)
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

  protected virtual void ProcessCertificateRequest(
    DtlsClientProtocol.ClientHandshakeState state,
    byte[] body)
  {
    if (state.authentication == null)
      throw new TlsFatalAlert((short) 40);
    MemoryStream memoryStream = new MemoryStream(body, false);
    CertificateRequest certificateRequest = CertificateRequest.Parse((TlsContext) state.clientContext, (Stream) memoryStream);
    TlsProtocol.AssertEmpty(memoryStream);
    state.certificateRequest = TlsUtilities.ValidateCertificateRequest(certificateRequest, state.keyExchange);
    state.clientContext.SecurityParameters.m_clientCertificateType = TlsExtensionsUtilities.GetClientCertificateTypeExtensionServer(state.serverExtensions, (short) 0);
  }

  protected virtual void ProcessCertificateStatus(
    DtlsClientProtocol.ClientHandshakeState state,
    byte[] body)
  {
    MemoryStream memoryStream = new MemoryStream(body, false);
    state.certificateStatus = CertificateStatus.Parse((TlsContext) state.clientContext, (Stream) memoryStream);
    TlsProtocol.AssertEmpty(memoryStream);
  }

  protected virtual byte[] ProcessHelloVerifyRequest(
    DtlsClientProtocol.ClientHandshakeState state,
    byte[] body)
  {
    MemoryStream memoryStream = new MemoryStream(body, false);
    ProtocolVersion version = TlsUtilities.ReadVersion((Stream) memoryStream);
    byte[] numArray = TlsUtilities.ReadOpaque8((Stream) memoryStream, 0, ProtocolVersion.DTLSv12.IsEqualOrEarlierVersionOf(version) ? (int) byte.MaxValue : 32 /*0x20*/);
    TlsProtocol.AssertEmpty(memoryStream);
    if (!version.IsEqualOrEarlierVersionOf(state.clientContext.ClientVersion))
      throw new TlsFatalAlert((short) 47);
    return numArray;
  }

  protected virtual void ProcessNewSessionTicket(
    DtlsClientProtocol.ClientHandshakeState state,
    byte[] body)
  {
    MemoryStream memoryStream = new MemoryStream(body, false);
    NewSessionTicket newSessionTicket = NewSessionTicket.Parse((Stream) memoryStream);
    TlsProtocol.AssertEmpty(memoryStream);
    state.client.NotifyNewSessionTicket(newSessionTicket);
  }

  protected virtual void ProcessServerCertificate(
    DtlsClientProtocol.ClientHandshakeState state,
    byte[] body)
  {
    state.authentication = TlsUtilities.ReceiveServerCertificate((TlsClientContext) state.clientContext, state.client, new MemoryStream(body, false), state.serverExtensions);
  }

  protected virtual void ProcessServerHello(
    DtlsClientProtocol.ClientHandshakeState state,
    byte[] body)
  {
    ServerHello serverHello = ServerHello.Parse(new MemoryStream(body, false));
    ProtocolVersion version = serverHello.Version;
    state.serverExtensions = serverHello.Extensions;
    SecurityParameters securityParameters = state.clientContext.SecurityParameters;
    this.ReportServerVersion(state, version);
    securityParameters.m_serverRandom = serverHello.Random;
    if (!state.clientContext.ClientVersion.Equals(version))
      TlsUtilities.CheckDowngradeMarker(version, securityParameters.ServerRandom);
    byte[] sessionId = serverHello.SessionID;
    securityParameters.m_sessionID = sessionId;
    state.client.NotifySessionID(sessionId);
    state.resumedSession = sessionId.Length != 0 && state.tlsSession != null && Arrays.AreEqual(sessionId, state.tlsSession.SessionID);
    int num = DtlsProtocol.ValidateSelectedCipherSuite(serverHello.CipherSuite, (short) 47);
    if (!TlsUtilities.IsValidCipherSuiteSelection(state.offeredCipherSuites, num) || !TlsUtilities.IsValidVersionForCipherSuite(num, securityParameters.NegotiatedVersion))
      throw new TlsFatalAlert((short) 47);
    TlsUtilities.NegotiatedCipherSuite(securityParameters, num);
    state.client.NotifySelectedCipherSuite(num);
    if (TlsUtilities.IsTlsV13(version))
    {
      securityParameters.m_extendedMasterSecret = true;
    }
    else
    {
      bool flag;
      if (flag = TlsExtensionsUtilities.HasExtendedMasterSecretExtension(state.serverExtensions))
      {
        if (!state.resumedSession && !state.client.ShouldUseExtendedMasterSecret())
          throw new TlsFatalAlert((short) 40);
      }
      else if (state.client.RequiresExtendedMasterSecret() || state.resumedSession && !state.client.AllowLegacyResumption())
        throw new TlsFatalAlert((short) 40);
      securityParameters.m_extendedMasterSecret = flag;
    }
    if (state.serverExtensions != null)
    {
      foreach (int key in (IEnumerable<int>) state.serverExtensions.Keys)
      {
        if (key != 65281 && TlsUtilities.GetExtensionData(state.clientExtensions, key) == null)
          throw new TlsFatalAlert((short) 110);
      }
    }
    byte[] extensionData = TlsUtilities.GetExtensionData(state.serverExtensions, 65281);
    if (extensionData != null)
    {
      securityParameters.m_secureRenegotiation = true;
      if (!Arrays.FixedTimeEquals(extensionData, TlsProtocol.CreateRenegotiationInfo(TlsUtilities.EmptyBytes)))
        throw new TlsFatalAlert((short) 40);
    }
    state.client.NotifySecureRenegotiation(securityParameters.IsSecureRenegotiation);
    securityParameters.m_applicationProtocol = TlsExtensionsUtilities.GetAlpnExtensionServer(state.serverExtensions);
    securityParameters.m_applicationProtocolSet = true;
    if (ProtocolVersion.DTLSv12.Equals(securityParameters.NegotiatedVersion))
    {
      byte[] connectionIdExtension = TlsExtensionsUtilities.GetConnectionIDExtension(state.serverExtensions);
      if (connectionIdExtension != null)
      {
        byte[] numArray = TlsExtensionsUtilities.GetConnectionIDExtension(state.clientExtensions) ?? throw new TlsFatalAlert((short) 80 /*0x50*/);
        securityParameters.m_connectionIDLocal = connectionIdExtension;
        securityParameters.m_connectionIDPeer = numArray;
      }
    }
    HeartbeatExtension heartbeatExtension = TlsExtensionsUtilities.GetHeartbeatExtension(state.serverExtensions);
    if (heartbeatExtension == null)
    {
      state.heartbeat = (TlsHeartbeat) null;
      state.heartbeatPolicy = (short) 2;
    }
    else if ((short) 1 != heartbeatExtension.Mode)
      state.heartbeat = (TlsHeartbeat) null;
    IDictionary<int, byte[]> clientExtensions = state.clientExtensions;
    IDictionary<int, byte[]> dictionary = state.serverExtensions;
    if (state.resumedSession)
    {
      if (securityParameters.CipherSuite != state.sessionParameters.CipherSuite || !version.Equals(state.sessionParameters.NegotiatedVersion))
        throw new TlsFatalAlert((short) 47);
      clientExtensions = (IDictionary<int, byte[]>) null;
      dictionary = state.sessionParameters.ReadServerExtensions();
    }
    if (dictionary != null && dictionary.Count > 0)
    {
      bool flag;
      if ((flag = TlsExtensionsUtilities.HasEncryptThenMacExtension(dictionary)) && !TlsUtilities.IsBlockCipherSuite(securityParameters.CipherSuite))
        throw new TlsFatalAlert((short) 47);
      securityParameters.m_encryptThenMac = flag;
      securityParameters.m_maxFragmentLength = DtlsProtocol.EvaluateMaxFragmentLengthExtension(state.resumedSession, clientExtensions, dictionary, (short) 47);
      securityParameters.m_truncatedHmac = TlsExtensionsUtilities.HasTruncatedHmacExtension(dictionary);
      if (!state.resumedSession)
      {
        if (TlsUtilities.HasExpectedEmptyExtensionData(dictionary, 17, (short) 47))
          securityParameters.m_statusRequestVersion = 2;
        else if (TlsUtilities.HasExpectedEmptyExtensionData(dictionary, 5, (short) 47))
          securityParameters.m_statusRequestVersion = 1;
      }
      state.expectSessionTicket = !state.resumedSession && TlsUtilities.HasExpectedEmptyExtensionData(dictionary, 35, (short) 47);
    }
    if (clientExtensions == null)
      return;
    state.client.ProcessServerExtensions(dictionary);
  }

  protected virtual void ProcessServerKeyExchange(
    DtlsClientProtocol.ClientHandshakeState state,
    byte[] body)
  {
    MemoryStream memoryStream = new MemoryStream(body, false);
    state.keyExchange.ProcessServerKeyExchange((Stream) memoryStream);
    TlsProtocol.AssertEmpty(memoryStream);
  }

  protected virtual void ProcessServerSupplementalData(
    DtlsClientProtocol.ClientHandshakeState state,
    byte[] body)
  {
    IList<SupplementalDataEntry> serverSupplementalData = TlsProtocol.ReadSupplementalDataMessage(new MemoryStream(body, false));
    state.client.ProcessServerSupplementalData(serverSupplementalData);
  }

  protected virtual void ReportServerVersion(
    DtlsClientProtocol.ClientHandshakeState state,
    ProtocolVersion server_version)
  {
    TlsClientContextImpl clientContext = state.clientContext;
    SecurityParameters securityParameters = clientContext.SecurityParameters;
    ProtocolVersion negotiatedVersion = securityParameters.NegotiatedVersion;
    if (negotiatedVersion != null)
    {
      if (!negotiatedVersion.Equals(server_version))
        throw new TlsFatalAlert((short) 47);
    }
    else
    {
      if (!ProtocolVersion.Contains(clientContext.ClientSupportedVersions, server_version))
        throw new TlsFatalAlert((short) 70);
      securityParameters.m_negotiatedVersion = server_version;
      TlsUtilities.NegotiatedVersionDtlsClient((TlsClientContext) state.clientContext, state.client);
    }
  }

  protected static byte[] PatchClientHelloWithCookie(byte[] clientHelloBody, byte[] cookie)
  {
    int num1 = 35 + (int) TlsUtilities.ReadUint8(clientHelloBody, 34);
    int num2 = num1 + 1;
    byte[] numArray = new byte[clientHelloBody.Length + cookie.Length];
    Array.Copy((Array) clientHelloBody, 0, (Array) numArray, 0, num1);
    TlsUtilities.CheckUint8(cookie.Length);
    TlsUtilities.WriteUint8(cookie.Length, numArray, num1);
    Array.Copy((Array) cookie, 0, (Array) numArray, num2, cookie.Length);
    Array.Copy((Array) clientHelloBody, num2, (Array) numArray, num2 + cookie.Length, clientHelloBody.Length - num2);
    return numArray;
  }

  protected internal class ClientHandshakeState
  {
    internal TlsClient client;
    internal TlsClientContextImpl clientContext;
    internal TlsSession tlsSession;
    internal SessionParameters sessionParameters;
    internal TlsSecret sessionMasterSecret;
    internal SessionParameters.Builder sessionParametersBuilder;
    internal int[] offeredCipherSuites;
    internal IDictionary<int, byte[]> clientExtensions;
    internal IDictionary<int, byte[]> serverExtensions;
    internal bool resumedSession;
    internal bool expectSessionTicket;
    internal IDictionary<int, TlsAgreement> clientAgreements;
    internal TlsKeyExchange keyExchange;
    internal TlsAuthentication authentication;
    internal CertificateStatus certificateStatus;
    internal CertificateRequest certificateRequest;
    internal TlsHeartbeat heartbeat;
    internal short heartbeatPolicy = 2;
  }
}
