// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Tls.TlsClientProtocol
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

public class TlsClientProtocol : TlsProtocol
{
  protected TlsClient m_tlsClient;
  internal TlsClientContextImpl m_tlsClientContext;
  protected IDictionary<int, TlsAgreement> m_clientAgreements;
  internal OfferedPsks.BindersConfig m_clientBinders;
  protected ClientHello m_clientHello;
  protected TlsKeyExchange m_keyExchange;
  protected TlsAuthentication m_authentication;
  protected CertificateStatus m_certificateStatus;
  protected CertificateRequest m_certificateRequest;

  public TlsClientProtocol()
  {
  }

  public TlsClientProtocol(Stream stream)
    : base(stream)
  {
  }

  public TlsClientProtocol(Stream input, Stream output)
    : base(input, output)
  {
  }

  public virtual void Connect(TlsClient tlsClient)
  {
    if (tlsClient == null)
      throw new ArgumentNullException(nameof (tlsClient));
    this.m_tlsClient = this.m_tlsClient == null ? tlsClient : throw new InvalidOperationException("'Connect' can only be called once");
    this.m_tlsClientContext = new TlsClientContextImpl(tlsClient.Crypto);
    tlsClient.Init((TlsClientContext) this.m_tlsClientContext);
    tlsClient.NotifyCloseHandle((TlsCloseable) this);
    this.BeginHandshake();
    if (!this.m_blocking)
      return;
    this.BlockForHandshake();
  }

  protected override void BeginHandshake()
  {
    base.BeginHandshake();
    this.SendClientHello();
    this.m_connectionState = (short) 1;
  }

  protected override void CleanupHandshake()
  {
    base.CleanupHandshake();
    this.m_clientAgreements = (IDictionary<int, TlsAgreement>) null;
    this.m_clientBinders = (OfferedPsks.BindersConfig) null;
    this.m_clientHello = (ClientHello) null;
    this.m_keyExchange = (TlsKeyExchange) null;
    this.m_authentication = (TlsAuthentication) null;
    this.m_certificateStatus = (CertificateStatus) null;
    this.m_certificateRequest = (CertificateRequest) null;
  }

  protected override TlsContext Context => (TlsContext) this.m_tlsClientContext;

  internal override AbstractTlsContext ContextAdmin => (AbstractTlsContext) this.m_tlsClientContext;

  protected override TlsPeer Peer => (TlsPeer) this.m_tlsClient;

  protected virtual void Handle13HandshakeMessage(short type, HandshakeMessageInput buf)
  {
    if (!this.IsTlsV13ConnectionState())
      throw new TlsFatalAlert((short) 80 /*0x50*/);
    switch (type)
    {
      case 2:
        switch (this.m_connectionState)
        {
          case 1:
            throw new TlsFatalAlert((short) 80 /*0x50*/);
          case 3:
            ServerHello serverHelloMessage = this.ReceiveServerHelloMessage((MemoryStream) buf);
            if (serverHelloMessage.IsHelloRetryRequest())
              throw new TlsFatalAlert((short) 10);
            this.Process13ServerHello(serverHelloMessage, true);
            buf.UpdateHash((TlsHash) this.m_handshakeHash);
            this.m_connectionState = (short) 4;
            this.Process13ServerHelloCoda(serverHelloMessage, true);
            return;
          default:
            throw new TlsFatalAlert((short) 10);
        }
      case 4:
        this.Receive13NewSessionTicket((MemoryStream) buf);
        break;
      case 8:
        if (this.m_connectionState != (short) 4)
          throw new TlsFatalAlert((short) 10);
        this.Receive13EncryptedExtensions((MemoryStream) buf);
        this.m_connectionState = (short) 5;
        break;
      case 11:
        switch (this.m_connectionState)
        {
          case 5:
          case 11:
            if (this.m_connectionState != (short) 11)
              this.Skip13CertificateRequest();
            this.Receive13ServerCertificate((MemoryStream) buf);
            this.m_connectionState = (short) 7;
            return;
          default:
            throw new TlsFatalAlert((short) 10);
        }
      case 13:
        if (this.m_connectionState != (short) 5)
          throw new TlsFatalAlert((short) 10);
        this.Receive13CertificateRequest((MemoryStream) buf, false);
        this.m_connectionState = (short) 11;
        break;
      case 15:
        if (this.m_connectionState != (short) 7)
          throw new TlsFatalAlert((short) 10);
        this.Receive13ServerCertificateVerify((MemoryStream) buf);
        buf.UpdateHash((TlsHash) this.m_handshakeHash);
        this.m_connectionState = (short) 9;
        break;
      case 20:
        switch (this.m_connectionState)
        {
          case 5:
          case 9:
          case 11:
            if (this.m_connectionState == (short) 5)
              this.Skip13CertificateRequest();
            if (this.m_connectionState != (short) 9)
              this.Skip13ServerCertificate();
            this.Receive13ServerFinished((MemoryStream) buf);
            buf.UpdateHash((TlsHash) this.m_handshakeHash);
            this.m_connectionState = (short) 20;
            byte[] currentPrfHash = TlsUtilities.GetCurrentPrfHash(this.m_handshakeHash);
            this.m_recordStream.SetIgnoreChangeCipherSpec(false);
            if (this.m_certificateRequest != null)
            {
              TlsCredentialedSigner credentialedSigner = TlsUtilities.Establish13ClientCredentials(this.m_authentication, this.m_certificateRequest);
              Certificate certificate = (Certificate) null;
              if (credentialedSigner != null)
                certificate = credentialedSigner.Certificate;
              if (certificate == null)
                certificate = Certificate.EmptyChainTls13;
              this.Send13CertificateMessage(certificate);
              this.m_connectionState = (short) 15;
              if (credentialedSigner != null)
              {
                this.Send13CertificateVerifyMessage(TlsUtilities.Generate13CertificateVerify((TlsContext) this.m_tlsClientContext, credentialedSigner, this.m_handshakeHash));
                this.m_connectionState = (short) 17;
              }
            }
            this.Send13FinishedMessage();
            this.m_connectionState = (short) 18;
            TlsUtilities.Establish13PhaseApplication((TlsContext) this.m_tlsClientContext, currentPrfHash, this.m_recordStream);
            this.m_recordStream.EnablePendingCipherWrite();
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
    SecurityParameters securityParameters = this.m_tlsClientContext.SecurityParameters;
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
        if (type != (short) 20 || this.m_connectionState != (short) 4)
          throw new TlsFatalAlert((short) 10);
        this.ProcessFinishedMessage((MemoryStream) buf);
        buf.UpdateHash((TlsHash) this.m_handshakeHash);
        this.m_connectionState = (short) 20;
        this.SendChangeCipherSpec();
        this.SendFinishedMessage();
        this.m_connectionState = (short) 18;
        this.CompleteHandshake();
      }
      else
      {
        switch (type)
        {
          case 0:
            TlsProtocol.AssertEmpty((MemoryStream) buf);
            if (!this.IsApplicationDataReady)
              break;
            this.RefuseRenegotiation();
            break;
          case 2:
            if (this.m_connectionState != (short) 1)
              throw new TlsFatalAlert((short) 10);
            ServerHello serverHelloMessage = this.ReceiveServerHelloMessage((MemoryStream) buf);
            if (serverHelloMessage.IsHelloRetryRequest())
            {
              this.Process13HelloRetryRequest(serverHelloMessage);
              this.m_handshakeHash.NotifyPrfDetermined();
              this.m_handshakeHash.SealHashAlgorithms();
              TlsUtilities.AdjustTranscriptForRetry(this.m_handshakeHash);
              buf.UpdateHash((TlsHash) this.m_handshakeHash);
              this.m_connectionState = (short) 2;
              this.Send13ClientHelloRetry();
              this.m_connectionState = (short) 3;
              break;
            }
            this.ProcessServerHello(serverHelloMessage);
            this.m_handshakeHash.NotifyPrfDetermined();
            if (TlsUtilities.IsTlsV13(securityParameters.NegotiatedVersion))
              this.m_handshakeHash.SealHashAlgorithms();
            buf.UpdateHash((TlsHash) this.m_handshakeHash);
            this.m_connectionState = (short) 4;
            if (!TlsUtilities.IsTlsV13(securityParameters.NegotiatedVersion))
              break;
            this.Process13ServerHelloCoda(serverHelloMessage, false);
            break;
          case 4:
            if (this.m_connectionState != (short) 18)
              throw new TlsFatalAlert((short) 10);
            if (!this.m_expectSessionTicket)
              throw new TlsFatalAlert((short) 10);
            securityParameters.m_sessionID = TlsUtilities.EmptyBytes;
            this.InvalidateSession();
            this.m_tlsSession = TlsUtilities.ImportSession(securityParameters.SessionID, (SessionParameters) null);
            this.ReceiveNewSessionTicket((MemoryStream) buf);
            this.m_connectionState = (short) 19;
            break;
          case 11:
            switch (this.m_connectionState)
            {
              case 4:
              case 6:
                if (this.m_connectionState != (short) 6)
                  this.HandleSupplementalData((IList<SupplementalDataEntry>) null);
                this.m_authentication = TlsUtilities.ReceiveServerCertificate((TlsClientContext) this.m_tlsClientContext, this.m_tlsClient, (MemoryStream) buf, this.m_serverExtensions);
                this.m_connectionState = (short) 7;
                return;
              default:
                throw new TlsFatalAlert((short) 10);
            }
          case 12:
            switch (this.m_connectionState)
            {
              case 4:
              case 6:
              case 7:
              case 8:
                if (this.m_connectionState == (short) 4)
                  this.HandleSupplementalData((IList<SupplementalDataEntry>) null);
                if (this.m_connectionState != (short) 7 && this.m_connectionState != (short) 8)
                  this.m_authentication = (TlsAuthentication) null;
                this.HandleServerCertificate();
                this.m_keyExchange.ProcessServerKeyExchange((Stream) buf);
                TlsProtocol.AssertEmpty((MemoryStream) buf);
                this.m_connectionState = (short) 10;
                return;
              default:
                throw new TlsFatalAlert((short) 10);
            }
          case 13:
            switch (this.m_connectionState)
            {
              case 7:
              case 8:
              case 10:
                if (this.m_connectionState != (short) 10)
                {
                  this.HandleServerCertificate();
                  this.m_keyExchange.SkipServerKeyExchange();
                }
                this.ReceiveCertificateRequest((MemoryStream) buf);
                TlsUtilities.EstablishServerSigAlgs(securityParameters, this.m_certificateRequest);
                this.m_connectionState = (short) 11;
                return;
              default:
                throw new TlsFatalAlert((short) 10);
            }
          case 14:
            switch (this.m_connectionState)
            {
              case 4:
              case 6:
              case 7:
              case 8:
              case 10:
              case 11:
                if (this.m_connectionState == (short) 4)
                  this.HandleSupplementalData((IList<SupplementalDataEntry>) null);
                if (this.m_connectionState == (short) 4 || this.m_connectionState == (short) 6)
                  this.m_authentication = (TlsAuthentication) null;
                if (this.m_connectionState != (short) 10 && this.m_connectionState != (short) 11)
                {
                  this.HandleServerCertificate();
                  this.m_keyExchange.SkipServerKeyExchange();
                }
                TlsProtocol.AssertEmpty((MemoryStream) buf);
                this.m_connectionState = (short) 12;
                TlsCredentials clientCredentials = (TlsCredentials) null;
                TlsCredentialedSigner credentialedSigner = (TlsCredentialedSigner) null;
                Certificate certificate = (Certificate) null;
                SignatureAndHashAlgorithm andHashAlgorithm = (SignatureAndHashAlgorithm) null;
                TlsStreamSigner clientAuthStreamSigner = (TlsStreamSigner) null;
                if (this.m_certificateRequest != null)
                {
                  clientCredentials = TlsUtilities.EstablishClientCredentials(this.m_authentication, this.m_certificateRequest);
                  if (clientCredentials != null)
                  {
                    certificate = clientCredentials.Certificate;
                    if (clientCredentials is TlsCredentialedSigner)
                    {
                      credentialedSigner = (TlsCredentialedSigner) clientCredentials;
                      andHashAlgorithm = TlsUtilities.GetSignatureAndHashAlgorithm(securityParameters.NegotiatedVersion, credentialedSigner);
                      clientAuthStreamSigner = credentialedSigner.GetStreamSigner();
                      if (ProtocolVersion.TLSv12.Equals(securityParameters.NegotiatedVersion))
                      {
                        TlsUtilities.VerifySupportedSignatureAlgorithm(securityParameters.ServerSigAlgs, andHashAlgorithm, (short) 80 /*0x50*/);
                        if (clientAuthStreamSigner == null)
                          TlsUtilities.TrackHashAlgorithmClient(this.m_handshakeHash, andHashAlgorithm);
                      }
                      if (clientAuthStreamSigner != null)
                        this.m_handshakeHash.ForceBuffering();
                    }
                  }
                }
                this.m_handshakeHash.SealHashAlgorithms();
                if (clientCredentials == null)
                  this.m_keyExchange.SkipClientCredentials();
                else
                  this.m_keyExchange.ProcessClientCredentials(clientCredentials);
                IList<SupplementalDataEntry> supplementalData = this.m_tlsClient.GetClientSupplementalData();
                if (supplementalData != null)
                {
                  this.SendSupplementalDataMessage(supplementalData);
                  this.m_connectionState = (short) 14;
                }
                if (this.m_certificateRequest != null)
                {
                  this.SendCertificateMessage(certificate, (Stream) null);
                  this.m_connectionState = (short) 15;
                }
                this.SendClientKeyExchange();
                this.m_connectionState = (short) 16 /*0x10*/;
                int num = TlsUtilities.IsSsl((TlsContext) this.m_tlsClientContext) ? 1 : 0;
                if (num != 0)
                  TlsProtocol.EstablishMasterSecret((TlsContext) this.m_tlsClientContext, this.m_keyExchange);
                securityParameters.m_sessionHash = TlsUtilities.GetCurrentPrfHash(this.m_handshakeHash);
                if (num == 0)
                  TlsProtocol.EstablishMasterSecret((TlsContext) this.m_tlsClientContext, this.m_keyExchange);
                this.m_recordStream.SetPendingCipher(TlsUtilities.InitCipher((TlsContext) this.m_tlsClientContext));
                if (credentialedSigner != null)
                {
                  this.SendCertificateVerifyMessage(TlsUtilities.GenerateCertificateVerifyClient((TlsClientContext) this.m_tlsClientContext, credentialedSigner, andHashAlgorithm, clientAuthStreamSigner, this.m_handshakeHash));
                  this.m_connectionState = (short) 17;
                }
                this.m_handshakeHash.StopTracking();
                this.SendChangeCipherSpec();
                this.SendFinishedMessage();
                this.m_connectionState = (short) 18;
                return;
              default:
                throw new TlsFatalAlert((short) 10);
            }
          case 20:
            switch (this.m_connectionState)
            {
              case 18:
              case 19:
                if (this.m_connectionState != (short) 19 && this.m_expectSessionTicket)
                  throw new TlsFatalAlert((short) 10);
                this.ProcessFinishedMessage((MemoryStream) buf);
                this.m_connectionState = (short) 20;
                this.CompleteHandshake();
                return;
              default:
                throw new TlsFatalAlert((short) 10);
            }
          case 22:
            if (this.m_connectionState != (short) 7)
              throw new TlsFatalAlert((short) 10);
            if (securityParameters.StatusRequestVersion < 1)
              throw new TlsFatalAlert((short) 10);
            this.m_certificateStatus = CertificateStatus.Parse((TlsContext) this.m_tlsClientContext, (Stream) buf);
            TlsProtocol.AssertEmpty((MemoryStream) buf);
            this.m_connectionState = (short) 8;
            break;
          case 23:
            if (this.m_connectionState != (short) 4)
              throw new TlsFatalAlert((short) 10);
            this.HandleSupplementalData(TlsProtocol.ReadSupplementalDataMessage((MemoryStream) buf));
            break;
          default:
            throw new TlsFatalAlert((short) 10);
        }
      }
    }
  }

  protected virtual void HandleServerCertificate()
  {
    TlsUtilities.ProcessServerCertificate((TlsClientContext) this.m_tlsClientContext, this.m_certificateStatus, this.m_keyExchange, this.m_authentication, this.m_clientExtensions, this.m_serverExtensions);
  }

  protected virtual void HandleSupplementalData(
    IList<SupplementalDataEntry> serverSupplementalData)
  {
    this.m_tlsClient.ProcessServerSupplementalData(serverSupplementalData);
    this.m_connectionState = (short) 6;
    this.m_keyExchange = TlsUtilities.InitKeyExchangeClient((TlsClientContext) this.m_tlsClientContext, this.m_tlsClient);
  }

  protected virtual void Process13HelloRetryRequest(ServerHello helloRetryRequest)
  {
    this.m_recordStream.SetWriteVersion(ProtocolVersion.TLSv12);
    SecurityParameters securityParameters = this.m_tlsClientContext.SecurityParameters;
    ProtocolVersion version = helloRetryRequest.Version;
    byte[] sessionId = helloRetryRequest.SessionID;
    int cipherSuite = helloRetryRequest.CipherSuite;
    if (!ProtocolVersion.TLSv12.Equals(version) || !Arrays.AreEqual(this.m_clientHello.SessionID, sessionId) || !TlsUtilities.IsValidCipherSuiteSelection(this.m_clientHello.CipherSuites, cipherSuite))
      throw new TlsFatalAlert((short) 47);
    IDictionary<int, byte[]> extensions = helloRetryRequest.Extensions;
    if (extensions == null)
      throw new TlsFatalAlert((short) 47);
    TlsUtilities.CheckExtensionData13(extensions, 6, (short) 47);
    foreach (int key in (IEnumerable<int>) extensions.Keys)
    {
      if (44 != key && TlsUtilities.GetExtensionData(this.m_clientExtensions, key) == null)
        throw new TlsFatalAlert((short) 110);
    }
    ProtocolVersion versionsExtensionServer = TlsExtensionsUtilities.GetSupportedVersionsExtensionServer(extensions);
    if (versionsExtensionServer == null)
      throw new TlsFatalAlert((short) 109);
    if (!ProtocolVersion.TLSv13.IsEqualOrEarlierVersionOf(versionsExtensionServer) || !ProtocolVersion.Contains(this.m_tlsClientContext.ClientSupportedVersions, versionsExtensionServer) || !TlsUtilities.IsValidVersionForCipherSuite(cipherSuite, versionsExtensionServer))
      throw new TlsFatalAlert((short) 47);
    if (this.m_clientBinders != null && !Arrays.Contains(this.m_clientBinders.m_pskKeyExchangeModes, (short) 1))
    {
      this.m_clientBinders = (OfferedPsks.BindersConfig) null;
      this.m_tlsClient.NotifySelectedPsk((TlsPsk) null);
    }
    int helloRetryRequest1 = TlsExtensionsUtilities.GetKeyShareHelloRetryRequest(extensions);
    if (!TlsUtilities.IsValidKeyShareSelection(versionsExtensionServer, securityParameters.ClientSupportedGroups, this.m_clientAgreements, helloRetryRequest1))
      throw new TlsFatalAlert((short) 47);
    byte[] cookieExtension = TlsExtensionsUtilities.GetCookieExtension(extensions);
    securityParameters.m_negotiatedVersion = versionsExtensionServer;
    TlsUtilities.NegotiatedVersionTlsClient((TlsClientContext) this.m_tlsClientContext, this.m_tlsClient);
    securityParameters.m_resumedSession = false;
    securityParameters.m_sessionID = TlsUtilities.EmptyBytes;
    this.m_tlsClient.NotifySessionID(TlsUtilities.EmptyBytes);
    TlsUtilities.NegotiatedCipherSuite(securityParameters, cipherSuite);
    this.m_tlsClient.NotifySelectedCipherSuite(cipherSuite);
    this.m_clientAgreements = (IDictionary<int, TlsAgreement>) null;
    this.m_retryCookie = cookieExtension;
    this.m_retryGroup = helloRetryRequest1;
  }

  protected virtual void Process13ServerHello(ServerHello serverHello, bool afterHelloRetryRequest)
  {
    SecurityParameters securityParameters = this.m_tlsClientContext.SecurityParameters;
    ProtocolVersion version = serverHello.Version;
    byte[] sessionId = serverHello.SessionID;
    int cipherSuite = serverHello.CipherSuite;
    if (!ProtocolVersion.TLSv12.Equals(version) || !Arrays.AreEqual(this.m_clientHello.SessionID, sessionId))
      throw new TlsFatalAlert((short) 47);
    IDictionary<int, byte[]> extensions = serverHello.Extensions;
    if (extensions == null)
      throw new TlsFatalAlert((short) 47);
    TlsUtilities.CheckExtensionData13(extensions, 2, (short) 47);
    if (afterHelloRetryRequest)
    {
      ProtocolVersion versionsExtensionServer = TlsExtensionsUtilities.GetSupportedVersionsExtensionServer(extensions);
      if (versionsExtensionServer == null)
        throw new TlsFatalAlert((short) 109);
      if (!securityParameters.NegotiatedVersion.Equals(versionsExtensionServer) || securityParameters.CipherSuite != cipherSuite)
        throw new TlsFatalAlert((short) 47);
    }
    else
    {
      if (!TlsUtilities.IsValidCipherSuiteSelection(this.m_clientHello.CipherSuites, cipherSuite) || !TlsUtilities.IsValidVersionForCipherSuite(cipherSuite, securityParameters.NegotiatedVersion))
        throw new TlsFatalAlert((short) 47);
      securityParameters.m_resumedSession = false;
      securityParameters.m_sessionID = TlsUtilities.EmptyBytes;
      this.m_tlsClient.NotifySessionID(TlsUtilities.EmptyBytes);
      TlsUtilities.NegotiatedCipherSuite(securityParameters, cipherSuite);
      this.m_tlsClient.NotifySelectedCipherSuite(cipherSuite);
    }
    this.m_clientHello = (ClientHello) null;
    securityParameters.m_serverRandom = serverHello.Random;
    securityParameters.m_secureRenegotiation = false;
    securityParameters.m_extendedMasterSecret = true;
    securityParameters.m_statusRequestVersion = this.m_clientExtensions.ContainsKey(5) ? 1 : 0;
    TlsSecret pskEarlySecret = (TlsSecret) null;
    int sharedKeyServerHello = TlsExtensionsUtilities.GetPreSharedKeyServerHello(extensions);
    TlsPsk selectedPsk = (TlsPsk) null;
    if (sharedKeyServerHello >= 0)
    {
      if (this.m_clientBinders == null || sharedKeyServerHello >= this.m_clientBinders.m_psks.Length)
        throw new TlsFatalAlert((short) 47);
      selectedPsk = this.m_clientBinders.m_psks[sharedKeyServerHello];
      if (selectedPsk.PrfAlgorithm != securityParameters.PrfAlgorithm)
        throw new TlsFatalAlert((short) 47);
      pskEarlySecret = this.m_clientBinders.m_earlySecrets[sharedKeyServerHello];
      this.m_selectedPsk13 = true;
    }
    this.m_tlsClient.NotifySelectedPsk(selectedPsk);
    TlsSecret sharedSecret = (TlsSecret) null;
    KeyShareEntry shareServerHello = TlsExtensionsUtilities.GetKeyShareServerHello(extensions);
    if (shareServerHello == null)
    {
      if (afterHelloRetryRequest || pskEarlySecret == null || !Arrays.Contains(this.m_clientBinders.m_pskKeyExchangeModes, (short) 0))
        throw new TlsFatalAlert((short) 47);
    }
    else
    {
      if (pskEarlySecret != null && !Arrays.Contains(this.m_clientBinders.m_pskKeyExchangeModes, (short) 1))
        throw new TlsFatalAlert((short) 47);
      TlsAgreement tlsAgreement;
      if (!this.m_clientAgreements.TryGetValue(shareServerHello.NamedGroup, out tlsAgreement))
        throw new TlsFatalAlert((short) 47);
      tlsAgreement.ReceivePeerValue(shareServerHello.KeyExchange);
      sharedSecret = tlsAgreement.CalculateSecret();
    }
    this.m_clientAgreements = (IDictionary<int, TlsAgreement>) null;
    this.m_clientBinders = (OfferedPsks.BindersConfig) null;
    TlsUtilities.Establish13PhaseSecrets((TlsContext) this.m_tlsClientContext, pskEarlySecret, sharedSecret);
    this.InvalidateSession();
    this.m_tlsSession = TlsUtilities.ImportSession(securityParameters.SessionID, (SessionParameters) null);
  }

  protected virtual void Process13ServerHelloCoda(
    ServerHello serverHello,
    bool afterHelloRetryRequest)
  {
    TlsUtilities.Establish13PhaseHandshake((TlsContext) this.m_tlsClientContext, TlsUtilities.GetCurrentPrfHash(this.m_handshakeHash), this.m_recordStream);
    if (!afterHelloRetryRequest)
    {
      this.m_recordStream.SetIgnoreChangeCipherSpec(true);
      this.SendChangeCipherSpecMessage();
    }
    this.m_recordStream.EnablePendingCipherWrite();
    this.m_recordStream.EnablePendingCipherRead(false);
  }

  protected virtual void ProcessServerHello(ServerHello serverHello)
  {
    IDictionary<int, byte[]> extensions = serverHello.Extensions;
    ProtocolVersion version = serverHello.Version;
    ProtocolVersion versionsExtensionServer = TlsExtensionsUtilities.GetSupportedVersionsExtensionServer(extensions);
    ProtocolVersion protocolVersion;
    if (versionsExtensionServer == null)
    {
      protocolVersion = version;
    }
    else
    {
      if (!ProtocolVersion.TLSv12.Equals(version) || !ProtocolVersion.TLSv13.IsEqualOrEarlierVersionOf(versionsExtensionServer))
        throw new TlsFatalAlert((short) 47);
      protocolVersion = versionsExtensionServer;
    }
    SecurityParameters securityParameters = this.m_tlsClientContext.SecurityParameters;
    if (!ProtocolVersion.Contains(this.m_tlsClientContext.ClientSupportedVersions, protocolVersion))
      throw new TlsFatalAlert((short) 70);
    this.m_recordStream.SetWriteVersion(protocolVersion.IsLaterVersionOf(ProtocolVersion.TLSv12) ? ProtocolVersion.TLSv12 : protocolVersion);
    securityParameters.m_negotiatedVersion = protocolVersion;
    TlsUtilities.NegotiatedVersionTlsClient((TlsClientContext) this.m_tlsClientContext, this.m_tlsClient);
    if (ProtocolVersion.TLSv13.IsEqualOrEarlierVersionOf(protocolVersion))
    {
      this.Process13ServerHello(serverHello, false);
    }
    else
    {
      int[] cipherSuites = this.m_clientHello.CipherSuites;
      this.m_clientHello = (ClientHello) null;
      this.m_retryCookie = (byte[]) null;
      this.m_retryGroup = -1;
      securityParameters.m_serverRandom = serverHello.Random;
      if (!this.m_tlsClientContext.ClientVersion.Equals(protocolVersion))
        TlsUtilities.CheckDowngradeMarker(protocolVersion, securityParameters.ServerRandom);
      byte[] sessionId = serverHello.SessionID;
      securityParameters.m_sessionID = sessionId;
      this.m_tlsClient.NotifySessionID(sessionId);
      securityParameters.m_resumedSession = sessionId.Length != 0 && this.m_tlsSession != null && Arrays.AreEqual(sessionId, this.m_tlsSession.SessionID);
      int cipherSuite1 = serverHello.CipherSuite;
      int cipherSuite2 = cipherSuite1;
      if (!TlsUtilities.IsValidCipherSuiteSelection(cipherSuites, cipherSuite2) || !TlsUtilities.IsValidVersionForCipherSuite(cipherSuite1, securityParameters.NegotiatedVersion))
        throw new TlsFatalAlert((short) 47);
      TlsUtilities.NegotiatedCipherSuite(securityParameters, cipherSuite1);
      this.m_tlsClient.NotifySelectedCipherSuite(cipherSuite1);
      this.m_serverExtensions = extensions;
      if (this.m_serverExtensions != null)
      {
        foreach (int key in (IEnumerable<int>) this.m_serverExtensions.Keys)
        {
          if (65281 != key)
          {
            if (TlsUtilities.GetExtensionData(this.m_clientExtensions, key) == null)
              throw new TlsFatalAlert((short) 110);
            int num = securityParameters.IsResumedSession ? 1 : 0;
          }
        }
      }
      byte[] extensionData = TlsUtilities.GetExtensionData(this.m_serverExtensions, 65281);
      if (extensionData == null)
      {
        securityParameters.m_secureRenegotiation = false;
      }
      else
      {
        securityParameters.m_secureRenegotiation = true;
        if (!Arrays.FixedTimeEquals(extensionData, TlsProtocol.CreateRenegotiationInfo(TlsUtilities.EmptyBytes)))
          throw new TlsFatalAlert((short) 40);
      }
      this.m_tlsClient.NotifySecureRenegotiation(securityParameters.IsSecureRenegotiation);
      bool flag1 = TlsExtensionsUtilities.HasExtendedMasterSecretExtension(this.m_serverExtensions);
      bool isResumedSession = securityParameters.IsResumedSession;
      if (flag1)
      {
        if (protocolVersion.IsSsl || !isResumedSession && !this.m_tlsClient.ShouldUseExtendedMasterSecret())
          throw new TlsFatalAlert((short) 40);
      }
      else if (this.m_tlsClient.RequiresExtendedMasterSecret() || isResumedSession && !this.m_tlsClient.AllowLegacyResumption())
        throw new TlsFatalAlert((short) 40);
      securityParameters.m_extendedMasterSecret = flag1;
      securityParameters.m_applicationProtocol = TlsExtensionsUtilities.GetAlpnExtensionServer(this.m_serverExtensions);
      securityParameters.m_applicationProtocolSet = true;
      IDictionary<int, byte[]> clientExtensions = this.m_clientExtensions;
      IDictionary<int, byte[]> dictionary = this.m_serverExtensions;
      if (securityParameters.IsResumedSession)
      {
        if (securityParameters.CipherSuite != this.m_sessionParameters.CipherSuite || !protocolVersion.Equals(this.m_sessionParameters.NegotiatedVersion))
          throw new TlsFatalAlert((short) 47);
        clientExtensions = (IDictionary<int, byte[]>) null;
        dictionary = this.m_sessionParameters.ReadServerExtensions();
      }
      if (dictionary != null && dictionary.Count > 0)
      {
        bool flag2;
        if ((flag2 = TlsExtensionsUtilities.HasEncryptThenMacExtension(dictionary)) && !TlsUtilities.IsBlockCipherSuite(securityParameters.CipherSuite))
          throw new TlsFatalAlert((short) 47);
        securityParameters.m_encryptThenMac = flag2;
        securityParameters.m_maxFragmentLength = this.ProcessMaxFragmentLengthExtension(clientExtensions, dictionary, (short) 47);
        securityParameters.m_truncatedHmac = TlsExtensionsUtilities.HasTruncatedHmacExtension(dictionary);
        if (!securityParameters.IsResumedSession)
        {
          if (TlsUtilities.HasExpectedEmptyExtensionData(dictionary, 17, (short) 47))
            securityParameters.m_statusRequestVersion = 2;
          else if (TlsUtilities.HasExpectedEmptyExtensionData(dictionary, 5, (short) 47))
            securityParameters.m_statusRequestVersion = 1;
          this.m_expectSessionTicket = TlsUtilities.HasExpectedEmptyExtensionData(dictionary, 35, (short) 47);
        }
      }
      if (clientExtensions != null)
        this.m_tlsClient.ProcessServerExtensions(dictionary);
      this.ApplyMaxFragmentLengthExtension(securityParameters.MaxFragmentLength);
      if (securityParameters.IsResumedSession)
      {
        securityParameters.m_masterSecret = this.m_sessionMasterSecret;
        this.m_recordStream.SetPendingCipher(TlsUtilities.InitCipher((TlsContext) this.m_tlsClientContext));
      }
      else
      {
        this.InvalidateSession();
        this.m_tlsSession = TlsUtilities.ImportSession(securityParameters.SessionID, (SessionParameters) null);
      }
    }
  }

  protected virtual void Receive13CertificateRequest(MemoryStream buf, bool postHandshakeAuth)
  {
    if (postHandshakeAuth)
      throw new TlsFatalAlert((short) 80 /*0x50*/);
    if (this.m_selectedPsk13)
      throw new TlsFatalAlert((short) 10);
    CertificateRequest certificateRequest = CertificateRequest.Parse((TlsContext) this.m_tlsClientContext, (Stream) buf);
    TlsProtocol.AssertEmpty(buf);
    this.m_certificateRequest = certificateRequest.HasCertificateRequestContext(TlsUtilities.EmptyBytes) ? certificateRequest : throw new TlsFatalAlert((short) 47);
    this.m_tlsClientContext.SecurityParameters.m_clientCertificateType = TlsExtensionsUtilities.GetClientCertificateTypeExtensionServer(this.m_serverExtensions, (short) 0);
    TlsUtilities.EstablishServerSigAlgs(this.m_tlsClientContext.SecurityParameters, certificateRequest);
  }

  protected virtual void Receive13EncryptedExtensions(MemoryStream buf)
  {
    byte[] extBytes = TlsUtilities.ReadOpaque16((Stream) buf);
    TlsProtocol.AssertEmpty(buf);
    this.m_serverExtensions = TlsProtocol.ReadExtensionsData13(8, extBytes);
    foreach (int key in (IEnumerable<int>) this.m_serverExtensions.Keys)
    {
      if (TlsUtilities.GetExtensionData(this.m_clientExtensions, key) == null)
        throw new TlsFatalAlert((short) 110);
    }
    SecurityParameters securityParameters = this.m_tlsClientContext.SecurityParameters;
    ProtocolVersion negotiatedVersion = securityParameters.NegotiatedVersion;
    securityParameters.m_applicationProtocol = TlsExtensionsUtilities.GetAlpnExtensionServer(this.m_serverExtensions);
    securityParameters.m_applicationProtocolSet = true;
    IDictionary<int, byte[]> clientExtensions = this.m_clientExtensions;
    IDictionary<int, byte[]> serverExtensions = this.m_serverExtensions;
    if (securityParameters.IsResumedSession)
    {
      if (securityParameters.CipherSuite != this.m_sessionParameters.CipherSuite || !negotiatedVersion.Equals(this.m_sessionParameters.NegotiatedVersion))
        throw new TlsFatalAlert((short) 47);
      clientExtensions = (IDictionary<int, byte[]>) null;
      serverExtensions = this.m_sessionParameters.ReadServerExtensions();
    }
    securityParameters.m_maxFragmentLength = this.ProcessMaxFragmentLengthExtension(clientExtensions, serverExtensions, (short) 47);
    securityParameters.m_encryptThenMac = false;
    securityParameters.m_truncatedHmac = false;
    securityParameters.m_statusRequestVersion = this.m_clientExtensions.ContainsKey(5) ? 1 : 0;
    this.m_expectSessionTicket = false;
    if (clientExtensions != null)
      this.m_tlsClient.ProcessServerExtensions(this.m_serverExtensions);
    this.ApplyMaxFragmentLengthExtension(securityParameters.MaxFragmentLength);
  }

  protected virtual void Receive13NewSessionTicket(MemoryStream buf)
  {
    if (!this.IsApplicationDataReady)
      throw new TlsFatalAlert((short) 10);
    TlsUtilities.ReadUint32((Stream) buf);
    TlsUtilities.ReadUint32((Stream) buf);
    TlsUtilities.ReadOpaque8((Stream) buf);
    TlsUtilities.ReadOpaque16((Stream) buf);
    TlsUtilities.ReadOpaque16((Stream) buf);
    TlsProtocol.AssertEmpty(buf);
  }

  protected virtual void Receive13ServerCertificate(MemoryStream buf)
  {
    if (this.m_selectedPsk13)
      throw new TlsFatalAlert((short) 10);
    this.m_authentication = TlsUtilities.Receive13ServerCertificate((TlsClientContext) this.m_tlsClientContext, this.m_tlsClient, buf, this.m_serverExtensions);
    this.HandleServerCertificate();
  }

  protected virtual void Receive13ServerCertificateVerify(MemoryStream buf)
  {
    Certificate peerCertificate = this.m_tlsClientContext.SecurityParameters.PeerCertificate;
    if (peerCertificate == null || peerCertificate.IsEmpty)
      throw new TlsFatalAlert((short) 80 /*0x50*/);
    CertificateVerify certificateVerify = CertificateVerify.Parse((TlsContext) this.m_tlsClientContext, (Stream) buf);
    TlsProtocol.AssertEmpty(buf);
    TlsUtilities.Verify13CertificateVerifyServer((TlsClientContext) this.m_tlsClientContext, this.m_handshakeHash, certificateVerify);
  }

  protected virtual void Receive13ServerFinished(MemoryStream buf)
  {
    this.Process13FinishedMessage(buf);
  }

  protected virtual void ReceiveCertificateRequest(MemoryStream buf)
  {
    if (this.m_authentication == null)
      throw new TlsFatalAlert((short) 40);
    CertificateRequest certificateRequest = CertificateRequest.Parse((TlsContext) this.m_tlsClientContext, (Stream) buf);
    TlsProtocol.AssertEmpty(buf);
    this.m_certificateRequest = TlsUtilities.ValidateCertificateRequest(certificateRequest, this.m_keyExchange);
    this.m_tlsClientContext.SecurityParameters.m_clientCertificateType = TlsExtensionsUtilities.GetClientCertificateTypeExtensionServer(this.m_serverExtensions, (short) 0);
  }

  protected virtual void ReceiveNewSessionTicket(MemoryStream buf)
  {
    NewSessionTicket newSessionTicket = NewSessionTicket.Parse((Stream) buf);
    TlsProtocol.AssertEmpty(buf);
    this.m_tlsClient.NotifyNewSessionTicket(newSessionTicket);
  }

  protected virtual ServerHello ReceiveServerHelloMessage(MemoryStream buf)
  {
    return ServerHello.Parse(buf);
  }

  protected virtual void Send13ClientHelloRetry()
  {
    IDictionary<int, byte[]> extensions = this.m_clientHello.Extensions;
    extensions.Remove(44);
    extensions.Remove(42);
    extensions.Remove(51);
    extensions.Remove(41);
    if (this.m_retryCookie != null)
    {
      TlsExtensionsUtilities.AddCookieExtension(extensions, this.m_retryCookie);
      this.m_retryCookie = (byte[]) null;
    }
    if (this.m_clientBinders != null)
    {
      this.m_clientBinders = TlsUtilities.AddPreSharedKeyToClientHelloRetry((TlsClientContext) this.m_tlsClientContext, this.m_clientBinders, extensions);
      if (this.m_clientBinders == null)
        this.m_tlsClient.NotifySelectedPsk((TlsPsk) null);
    }
    if (this.m_retryGroup < 0)
      throw new TlsFatalAlert((short) 80 /*0x50*/);
    this.m_clientAgreements = TlsUtilities.AddKeyShareToClientHelloRetry((TlsClientContext) this.m_tlsClientContext, extensions, this.m_retryGroup);
    this.m_recordStream.SetIgnoreChangeCipherSpec(true);
    this.SendChangeCipherSpecMessage();
    this.SendClientHelloMessage();
  }

  protected virtual void SendCertificateVerifyMessage(DigitallySigned certificateVerify)
  {
    HandshakeMessageOutput output = new HandshakeMessageOutput((short) 15);
    certificateVerify.Encode((Stream) output);
    output.Send((TlsProtocol) this);
  }

  protected virtual void SendClientHello()
  {
    SecurityParameters securityParameters = this.m_tlsClientContext.SecurityParameters;
    ProtocolVersion[] protocolVersions = this.m_tlsClient.GetProtocolVersions();
    if (ProtocolVersion.Contains(protocolVersions, ProtocolVersion.SSLv3))
      this.m_recordStream.SetWriteVersion(ProtocolVersion.SSLv3);
    else
      this.m_recordStream.SetWriteVersion(ProtocolVersion.TLSv10);
    ProtocolVersion earliestTls = ProtocolVersion.GetEarliestTls(protocolVersions);
    ProtocolVersion latestTls = ProtocolVersion.GetLatestTls(protocolVersions);
    if (!ProtocolVersion.IsSupportedTlsVersionClient(latestTls))
      throw new TlsFatalAlert((short) 80 /*0x50*/);
    this.m_tlsClientContext.SetClientVersion(latestTls);
    this.m_tlsClientContext.SetClientSupportedVersions(protocolVersions);
    bool flag1 = ProtocolVersion.TLSv12.IsEqualOrLaterVersionOf(earliestTls);
    bool flag2;
    bool useGmtUnixTime = !(flag2 = ProtocolVersion.TLSv13.IsEqualOrEarlierVersionOf(latestTls)) && this.m_tlsClient.ShouldUseGmtUnixTime();
    securityParameters.m_clientRandom = TlsProtocol.CreateRandomBlock(useGmtUnixTime, (TlsContext) this.m_tlsClientContext);
    this.EstablishSession(flag1 ? this.m_tlsClient.GetSessionToResume() : (TlsSession) null);
    this.m_tlsClient.NotifySessionToResume(this.m_tlsSession);
    byte[] sessionID = TlsUtilities.GetSessionID(this.m_tlsSession);
    bool flag3 = this.m_tlsClient.IsFallback();
    int[] numArray = this.m_tlsClient.GetCipherSuites();
    if (sessionID.Length != 0 && this.m_sessionParameters != null && !Arrays.Contains(numArray, this.m_sessionParameters.CipherSuite))
      sessionID = TlsUtilities.EmptyBytes;
    this.m_clientExtensions = TlsExtensionsUtilities.EnsureExtensionsInitialised(this.m_tlsClient.GetClientExtensions());
    ProtocolVersion protocolVersion = latestTls;
    if (flag2)
    {
      protocolVersion = ProtocolVersion.TLSv12;
      TlsExtensionsUtilities.AddSupportedVersionsExtensionClient(this.m_clientExtensions, protocolVersions);
      if (sessionID.Length < 1)
        sessionID = this.m_tlsClientContext.NonceGenerator.GenerateNonce(32 /*0x20*/);
    }
    this.m_tlsClientContext.SetRsaPreMasterSecretVersion(protocolVersion);
    securityParameters.m_clientServerNames = TlsExtensionsUtilities.GetServerNameExtensionClient(this.m_clientExtensions);
    if (TlsUtilities.IsSignatureAlgorithmsExtensionAllowed(latestTls))
      TlsUtilities.EstablishClientSigAlgs(securityParameters, this.m_clientExtensions);
    securityParameters.m_clientSupportedGroups = TlsExtensionsUtilities.GetSupportedGroupsExtension(this.m_clientExtensions);
    this.m_clientBinders = TlsUtilities.AddPreSharedKeyToClientHello((TlsClientContext) this.m_tlsClientContext, this.m_tlsClient, this.m_clientExtensions, numArray);
    this.m_clientAgreements = TlsUtilities.AddKeyShareToClientHello((TlsClientContext) this.m_tlsClientContext, this.m_tlsClient, this.m_clientExtensions);
    if (TlsUtilities.IsExtendedMasterSecretOptionalTls(protocolVersions) && (this.m_tlsClient.ShouldUseExtendedMasterSecret() || this.m_sessionParameters != null && this.m_sessionParameters.IsExtendedMasterSecret))
      TlsExtensionsUtilities.AddExtendedMasterSecretExtension(this.m_clientExtensions);
    else if (!flag2 && this.m_tlsClient.RequiresExtendedMasterSecret())
      throw new TlsFatalAlert((short) 80 /*0x50*/);
    if (TlsUtilities.GetExtensionData(this.m_clientExtensions, 65281) == null & !Arrays.Contains(numArray, (int) byte.MaxValue))
      numArray = Arrays.Append(numArray, (int) byte.MaxValue);
    if (flag3 && !Arrays.Contains(numArray, 22016))
      numArray = Arrays.Append(numArray, 22016);
    int bindersSize = this.m_clientBinders == null ? 0 : this.m_clientBinders.m_bindersSize;
    this.m_clientHello = new ClientHello(protocolVersion, securityParameters.ClientRandom, sessionID, (byte[]) null, numArray, this.m_clientExtensions, bindersSize);
    this.SendClientHelloMessage();
  }

  protected virtual void SendClientHelloMessage()
  {
    HandshakeMessageOutput output = new HandshakeMessageOutput((short) 1);
    this.m_clientHello.Encode((TlsContext) this.m_tlsClientContext, (Stream) output);
    output.PrepareClientHello(this.m_handshakeHash, this.m_clientHello.BindersSize);
    if (this.m_clientBinders != null)
      OfferedPsks.EncodeBinders((Stream) output, this.m_tlsClientContext.Crypto, this.m_handshakeHash, this.m_clientBinders);
    output.SendClientHello(this, this.m_handshakeHash, this.m_clientHello.BindersSize);
  }

  protected virtual void SendClientKeyExchange()
  {
    HandshakeMessageOutput output = new HandshakeMessageOutput((short) 16 /*0x10*/);
    this.m_keyExchange.GenerateClientKeyExchange((Stream) output);
    output.Send((TlsProtocol) this);
  }

  protected virtual void Skip13CertificateRequest()
  {
    this.m_certificateRequest = (CertificateRequest) null;
  }

  protected virtual void Skip13ServerCertificate()
  {
    if (!this.m_selectedPsk13)
      throw new TlsFatalAlert((short) 10);
    this.m_authentication = TlsUtilities.Skip13ServerCertificate((TlsClientContext) this.m_tlsClientContext);
  }
}
