// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Tls.AbstractTlsServer
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Tls.Crypto;
using Org.BouncyCastle.Utilities;
using System;
using System.Collections.Generic;

#nullable disable
namespace Org.BouncyCastle.Tls;

public abstract class AbstractTlsServer : AbstractTlsPeer, TlsServer, TlsPeer
{
  protected TlsServerContext m_context;
  protected ProtocolVersion[] m_protocolVersions;
  protected int[] m_cipherSuites;
  protected int[] m_offeredCipherSuites;
  protected IDictionary<int, byte[]> m_clientExtensions;
  protected bool m_encryptThenMACOffered;
  protected short m_maxFragmentLengthOffered;
  protected bool m_truncatedHMacOffered;
  protected bool m_clientSentECPointFormats;
  protected CertificateStatusRequest m_certificateStatusRequest;
  protected IList<CertificateStatusRequestItemV2> m_statusRequestV2;
  protected IList<TrustedAuthority> m_trustedCAKeys;
  protected int m_selectedCipherSuite;
  protected IList<ProtocolName> m_clientProtocolNames;
  protected ProtocolName m_selectedProtocolName;
  protected readonly IDictionary<int, byte[]> m_serverExtensions = (IDictionary<int, byte[]>) new Dictionary<int, byte[]>();

  public AbstractTlsServer(TlsCrypto crypto)
    : base(crypto)
  {
  }

  protected virtual bool AllowCertificateStatus() => true;

  protected virtual bool AllowEncryptThenMac() => true;

  protected virtual bool AllowMultiCertStatus() => false;

  protected virtual bool AllowTruncatedHmac() => false;

  protected virtual bool AllowTrustedCAIndication() => false;

  protected virtual int GetMaximumNegotiableCurveBits()
  {
    int[] clientSupportedGroups = this.m_context.SecurityParameters.ClientSupportedGroups;
    if (clientSupportedGroups == null)
      return NamedGroup.GetMaximumCurveBits();
    int val1 = 0;
    for (int index = 0; index < clientSupportedGroups.Length; ++index)
      val1 = Math.Max(val1, NamedGroup.GetCurveBits(clientSupportedGroups[index]));
    return val1;
  }

  protected virtual int GetMaximumNegotiableFiniteFieldBits()
  {
    int[] clientSupportedGroups = this.m_context.SecurityParameters.ClientSupportedGroups;
    if (clientSupportedGroups == null)
      return NamedGroup.GetMaximumFiniteFieldBits();
    int val1 = 0;
    for (int index = 0; index < clientSupportedGroups.Length; ++index)
      val1 = Math.Max(val1, NamedGroup.GetFiniteFieldBits(clientSupportedGroups[index]));
    return val1;
  }

  protected virtual IList<ProtocolName> GetProtocolNames() => (IList<ProtocolName>) null;

  protected virtual bool IsSelectableCipherSuite(
    int cipherSuite,
    int availCurveBits,
    int availFiniteFieldBits,
    IList<short> sigAlgs)
  {
    return TlsUtilities.IsValidVersionForCipherSuite(cipherSuite, this.m_context.ServerVersion) && availCurveBits >= TlsEccUtilities.GetMinimumCurveBits(cipherSuite) && availFiniteFieldBits >= TlsDHUtilities.GetMinimumFiniteFieldBits(cipherSuite) && TlsUtilities.IsValidCipherSuiteForSignatureAlgorithms(cipherSuite, sigAlgs);
  }

  protected virtual bool PreferLocalCipherSuites() => false;

  protected virtual bool SelectCipherSuite(int cipherSuite)
  {
    this.m_selectedCipherSuite = cipherSuite;
    return true;
  }

  protected virtual int SelectDH(int minimumFiniteFieldBits)
  {
    int[] clientSupportedGroups = this.m_context.SecurityParameters.ClientSupportedGroups;
    if (clientSupportedGroups == null)
      return this.SelectDHDefault(minimumFiniteFieldBits);
    for (int index = 0; index < clientSupportedGroups.Length; ++index)
    {
      int namedGroup = clientSupportedGroups[index];
      if (NamedGroup.GetFiniteFieldBits(namedGroup) >= minimumFiniteFieldBits)
        return namedGroup;
    }
    return -1;
  }

  protected virtual int SelectDHDefault(int minimumFiniteFieldBits)
  {
    if (minimumFiniteFieldBits <= 2048 /*0x0800*/)
      return 256 /*0x0100*/;
    if (minimumFiniteFieldBits <= 3072 /*0x0C00*/)
      return 257;
    if (minimumFiniteFieldBits <= 4096 /*0x1000*/)
      return 258;
    if (minimumFiniteFieldBits <= 6144)
      return 259;
    return minimumFiniteFieldBits > 8192 /*0x2000*/ ? -1 : 260;
  }

  protected virtual int SelectECDH(int minimumCurveBits)
  {
    int[] clientSupportedGroups = this.m_context.SecurityParameters.ClientSupportedGroups;
    if (clientSupportedGroups == null)
      return this.SelectECDHDefault(minimumCurveBits);
    for (int index = 0; index < clientSupportedGroups.Length; ++index)
    {
      int namedGroup = clientSupportedGroups[index];
      if (NamedGroup.GetCurveBits(namedGroup) >= minimumCurveBits)
        return namedGroup;
    }
    return -1;
  }

  protected virtual int SelectECDHDefault(int minimumCurveBits)
  {
    if (minimumCurveBits <= 256 /*0x0100*/)
      return 23;
    if (minimumCurveBits <= 384)
      return 24;
    return minimumCurveBits > 521 ? -1 : 25;
  }

  protected virtual ProtocolName SelectProtocolName()
  {
    IList<ProtocolName> protocolNames = this.GetProtocolNames();
    if (protocolNames == null || protocolNames.Count < 1)
      return (ProtocolName) null;
    return this.SelectProtocolName(this.m_clientProtocolNames, protocolNames) ?? throw new TlsFatalAlert((short) 120);
  }

  protected virtual ProtocolName SelectProtocolName(
    IList<ProtocolName> clientProtocolNames,
    IList<ProtocolName> serverProtocolNames)
  {
    foreach (ProtocolName serverProtocolName in (IEnumerable<ProtocolName>) serverProtocolNames)
    {
      if (clientProtocolNames.Contains(serverProtocolName))
        return serverProtocolName;
    }
    return (ProtocolName) null;
  }

  protected virtual bool ShouldSelectProtocolNameEarly() => true;

  protected virtual bool PreferLocalClientCertificateTypes() => false;

  protected virtual short[] GetAllowedClientCertificateTypes() => (short[]) null;

  protected virtual byte[] GetNewConnectionID() => (byte[]) null;

  public virtual void Init(TlsServerContext context)
  {
    this.m_context = context;
    this.m_protocolVersions = this.GetSupportedVersions();
    this.m_cipherSuites = this.GetSupportedCipherSuites();
  }

  public override ProtocolVersion[] GetProtocolVersions() => this.m_protocolVersions;

  public override int[] GetCipherSuites() => this.m_cipherSuites;

  public override void NotifyHandshakeBeginning()
  {
    base.NotifyHandshakeBeginning();
    this.m_offeredCipherSuites = (int[]) null;
    this.m_clientExtensions = (IDictionary<int, byte[]>) null;
    this.m_encryptThenMACOffered = false;
    this.m_maxFragmentLengthOffered = (short) 0;
    this.m_truncatedHMacOffered = false;
    this.m_clientSentECPointFormats = false;
    this.m_certificateStatusRequest = (CertificateStatusRequest) null;
    this.m_selectedCipherSuite = -1;
    this.m_selectedProtocolName = (ProtocolName) null;
    this.m_serverExtensions.Clear();
  }

  public virtual TlsSession GetSessionToResume(byte[] sessionID) => (TlsSession) null;

  public virtual byte[] GetNewSessionID() => (byte[]) null;

  public virtual TlsPskExternal GetExternalPsk(IList<PskIdentity> identities)
  {
    return (TlsPskExternal) null;
  }

  public virtual void NotifySession(TlsSession session)
  {
  }

  public virtual void NotifyClientVersion(ProtocolVersion clientVersion)
  {
  }

  public virtual void NotifyFallback(bool isFallback)
  {
    if (!isFallback)
      return;
    ProtocolVersion[] protocolVersions = this.GetProtocolVersions();
    ProtocolVersion clientVersion = this.m_context.ClientVersion;
    ProtocolVersion protocolVersion;
    if (clientVersion.IsTls)
    {
      protocolVersion = ProtocolVersion.GetLatestTls(protocolVersions);
    }
    else
    {
      if (!clientVersion.IsDtls)
        throw new TlsFatalAlert((short) 80 /*0x50*/);
      protocolVersion = ProtocolVersion.GetLatestDtls(protocolVersions);
    }
    if (protocolVersion != null && protocolVersion.IsLaterVersionOf(clientVersion))
      throw new TlsFatalAlert((short) 86);
  }

  public virtual void NotifyOfferedCipherSuites(int[] offeredCipherSuites)
  {
    this.m_offeredCipherSuites = offeredCipherSuites;
  }

  public virtual void ProcessClientExtensions(IDictionary<int, byte[]> clientExtensions)
  {
    this.m_clientExtensions = clientExtensions;
    if (clientExtensions == null)
      return;
    this.m_clientProtocolNames = TlsExtensionsUtilities.GetAlpnExtensionClient(clientExtensions);
    if (this.ShouldSelectProtocolNameEarly() && this.m_clientProtocolNames != null && this.m_clientProtocolNames.Count > 0)
      this.m_selectedProtocolName = this.SelectProtocolName();
    this.m_encryptThenMACOffered = TlsExtensionsUtilities.HasEncryptThenMacExtension(clientExtensions);
    this.m_truncatedHMacOffered = TlsExtensionsUtilities.HasTruncatedHmacExtension(clientExtensions);
    this.m_statusRequestV2 = TlsExtensionsUtilities.GetStatusRequestV2Extension(clientExtensions);
    this.m_trustedCAKeys = TlsExtensionsUtilities.GetTrustedCAKeysExtensionClient(clientExtensions);
    this.m_clientSentECPointFormats = TlsExtensionsUtilities.GetSupportedPointFormatsExtension(clientExtensions) != null;
    this.m_certificateStatusRequest = TlsExtensionsUtilities.GetStatusRequestExtension(clientExtensions);
    this.m_maxFragmentLengthOffered = TlsExtensionsUtilities.GetMaxFragmentLengthExtension(clientExtensions);
    if (this.m_maxFragmentLengthOffered >= (short) 0 && !MaxFragmentLength.IsValid(this.m_maxFragmentLengthOffered))
      throw new TlsFatalAlert((short) 47);
  }

  public virtual ProtocolVersion GetServerVersion()
  {
    ProtocolVersion[] protocolVersions = this.GetProtocolVersions();
    foreach (ProtocolVersion supportedVersion in this.m_context.ClientSupportedVersions)
    {
      if (ProtocolVersion.Contains(protocolVersions, supportedVersion))
        return supportedVersion;
    }
    throw new TlsFatalAlert((short) 70);
  }

  public virtual int[] GetSupportedGroups()
  {
    return new int[7]
    {
      29,
      30,
      23,
      24,
      256 /*0x0100*/,
      257,
      258
    };
  }

  public virtual int GetSelectedCipherSuite()
  {
    SecurityParameters securityParameters = this.m_context.SecurityParameters;
    ProtocolVersion negotiatedVersion = securityParameters.NegotiatedVersion;
    if (TlsUtilities.IsTlsV13(negotiatedVersion))
    {
      int commonCipherSuite13 = TlsUtilities.GetCommonCipherSuite13(negotiatedVersion, this.m_offeredCipherSuites, this.GetCipherSuites(), this.PreferLocalCipherSuites());
      if (commonCipherSuite13 >= 0 && this.SelectCipherSuite(commonCipherSuite13))
        return commonCipherSuite13;
    }
    else
    {
      IList<short> signatureAlgorithms = TlsUtilities.GetUsableSignatureAlgorithms(securityParameters.ClientSigAlgs);
      int negotiableCurveBits = this.GetMaximumNegotiableCurveBits();
      int negotiableFiniteFieldBits = this.GetMaximumNegotiableFiniteFieldBits();
      foreach (int commonCipherSuite in TlsUtilities.GetCommonCipherSuites(this.m_offeredCipherSuites, this.GetCipherSuites(), this.PreferLocalCipherSuites()))
      {
        if (this.IsSelectableCipherSuite(commonCipherSuite, negotiableCurveBits, negotiableFiniteFieldBits, signatureAlgorithms) && this.SelectCipherSuite(commonCipherSuite))
          return commonCipherSuite;
      }
    }
    throw new TlsFatalAlert((short) 40, "No selectable cipher suite");
  }

  public virtual IDictionary<int, byte[]> GetServerExtensions()
  {
    if (TlsUtilities.IsTlsV13((TlsContext) this.m_context))
    {
      if (this.m_certificateStatusRequest == null || !this.AllowCertificateStatus())
        ;
    }
    else
    {
      if (this.m_encryptThenMACOffered && this.AllowEncryptThenMac() && TlsUtilities.IsBlockCipherSuite(this.m_selectedCipherSuite))
        TlsExtensionsUtilities.AddEncryptThenMacExtension(this.m_serverExtensions);
      if (this.m_truncatedHMacOffered && this.AllowTruncatedHmac())
        TlsExtensionsUtilities.AddTruncatedHmacExtension(this.m_serverExtensions);
      if (this.m_clientSentECPointFormats && TlsEccUtilities.IsEccCipherSuite(this.m_selectedCipherSuite))
        TlsExtensionsUtilities.AddSupportedPointFormatsExtension(this.m_serverExtensions, new short[1]);
      if (this.m_statusRequestV2 != null && this.AllowMultiCertStatus())
        TlsExtensionsUtilities.AddEmptyExtensionData(this.m_serverExtensions, 17);
      else if (this.m_certificateStatusRequest != null && this.AllowCertificateStatus())
        TlsExtensionsUtilities.AddEmptyExtensionData(this.m_serverExtensions, 5);
      if (this.m_trustedCAKeys != null && this.AllowTrustedCAIndication())
        TlsExtensionsUtilities.AddTrustedCAKeysExtensionServer(this.m_serverExtensions);
    }
    if (this.m_maxFragmentLengthOffered >= (short) 0 && MaxFragmentLength.IsValid(this.m_maxFragmentLengthOffered))
      TlsExtensionsUtilities.AddMaxFragmentLengthExtension(this.m_serverExtensions, this.m_maxFragmentLengthOffered);
    short[] typeExtensionClient1 = TlsExtensionsUtilities.GetServerCertificateTypeExtensionClient(this.m_clientExtensions);
    if (typeExtensionClient1 != null)
    {
      TlsCredentials credentials = this.GetCredentials();
      if (credentials == null || !Arrays.Contains(typeExtensionClient1, credentials.Certificate.CertificateType))
        throw new TlsFatalAlert((short) 43);
      TlsExtensionsUtilities.AddServerCertificateTypeExtensionServer(this.m_serverExtensions, credentials.Certificate.CertificateType);
    }
    short[] typeExtensionClient2 = TlsExtensionsUtilities.GetClientCertificateTypeExtensionClient(this.m_clientExtensions);
    if (typeExtensionClient2 != null)
    {
      short[] certificateTypes = this.GetAllowedClientCertificateTypes();
      if (certificateTypes != null)
      {
        short[] numArray;
        short[] a;
        if (this.PreferLocalClientCertificateTypes())
        {
          numArray = certificateTypes;
          a = typeExtensionClient2;
        }
        else
        {
          numArray = typeExtensionClient2;
          a = certificateTypes;
        }
        short certificateType = -1;
        for (int index = 0; index < numArray.Length; ++index)
        {
          if (Arrays.Contains(a, numArray[index]))
          {
            certificateType = numArray[index];
            break;
          }
        }
        if (certificateType == (short) -1)
          throw new TlsFatalAlert((short) 43);
        TlsExtensionsUtilities.AddClientCertificateTypeExtensionServer(this.m_serverExtensions, certificateType);
      }
    }
    return this.m_serverExtensions;
  }

  public virtual void GetServerExtensionsForConnection(IDictionary<int, byte[]> serverExtensions)
  {
    if (!this.ShouldSelectProtocolNameEarly() && this.m_clientProtocolNames != null && this.m_clientProtocolNames.Count > 0)
      this.m_selectedProtocolName = this.SelectProtocolName();
    if (this.m_selectedProtocolName == null)
      serverExtensions.Remove(16 /*0x10*/);
    else
      TlsExtensionsUtilities.AddAlpnExtensionServer(serverExtensions, this.m_selectedProtocolName);
    if (!ProtocolVersion.DTLSv12.Equals(this.m_context.ServerVersion) || !this.m_clientExtensions.ContainsKey(54))
      return;
    byte[] newConnectionId = this.GetNewConnectionID();
    if (newConnectionId == null)
      return;
    TlsExtensionsUtilities.AddConnectionIDExtension(this.m_serverExtensions, newConnectionId);
  }

  public virtual IList<SupplementalDataEntry> GetServerSupplementalData()
  {
    return (IList<SupplementalDataEntry>) null;
  }

  public abstract TlsCredentials GetCredentials();

  public virtual CertificateStatus GetCertificateStatus() => (CertificateStatus) null;

  public virtual CertificateRequest GetCertificateRequest() => (CertificateRequest) null;

  public virtual TlsPskIdentityManager GetPskIdentityManager() => (TlsPskIdentityManager) null;

  public virtual TlsSrpLoginParameters GetSrpLoginParameters() => (TlsSrpLoginParameters) null;

  public virtual TlsDHConfig GetDHConfig()
  {
    return TlsDHUtilities.CreateNamedDHConfig((TlsContext) this.m_context, this.SelectDH(TlsDHUtilities.GetMinimumFiniteFieldBits(this.m_selectedCipherSuite)));
  }

  public virtual TlsECConfig GetECDHConfig()
  {
    return TlsEccUtilities.CreateNamedECConfig((TlsContext) this.m_context, this.SelectECDH(TlsEccUtilities.GetMinimumCurveBits(this.m_selectedCipherSuite)));
  }

  public virtual void ProcessClientSupplementalData(
    IList<SupplementalDataEntry> clientSupplementalData)
  {
    if (clientSupplementalData != null)
      throw new TlsFatalAlert((short) 10);
  }

  public virtual void NotifyClientCertificate(Certificate clientCertificate)
  {
    throw new TlsFatalAlert((short) 80 /*0x50*/);
  }

  public virtual NewSessionTicket GetNewSessionTicket()
  {
    return new NewSessionTicket(0L, TlsUtilities.EmptyBytes);
  }
}
