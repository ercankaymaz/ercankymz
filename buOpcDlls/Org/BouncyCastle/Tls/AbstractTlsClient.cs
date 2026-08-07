// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Tls.AbstractTlsClient
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1.Ocsp;
using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.Tls.Crypto;
using System.Collections.Generic;

#nullable disable
namespace Org.BouncyCastle.Tls;

public abstract class AbstractTlsClient(TlsCrypto crypto) : AbstractTlsPeer(crypto), TlsClient, TlsPeer
{
  protected TlsClientContext m_context;
  protected ProtocolVersion[] m_protocolVersions;
  protected int[] m_cipherSuites;
  protected IList<int> m_supportedGroups;
  protected IList<SignatureAndHashAlgorithm> m_supportedSignatureAlgorithms;
  protected IList<SignatureAndHashAlgorithm> m_supportedSignatureAlgorithmsCert;

  protected virtual bool AllowUnexpectedServerExtension(int extensionType, byte[] extensionData)
  {
    if (extensionType != 10)
    {
      if (extensionType != 11)
        return false;
      TlsExtensionsUtilities.ReadSupportedPointFormatsExtension(extensionData);
      return true;
    }
    TlsExtensionsUtilities.ReadSupportedGroupsExtension(extensionData);
    return true;
  }

  protected virtual IList<int> GetNamedGroupRoles()
  {
    IList<int> namedGroupRoles = TlsUtilities.GetNamedGroupRoles(this.GetCipherSuites());
    IList<SignatureAndHashAlgorithm> signatureAlgorithms = this.m_supportedSignatureAlgorithms;
    IList<SignatureAndHashAlgorithm> signatureAlgorithmsCert = this.m_supportedSignatureAlgorithmsCert;
    if (signatureAlgorithms == null || TlsUtilities.ContainsAnySignatureAlgorithm(signatureAlgorithms, (short) 3) || signatureAlgorithmsCert != null && TlsUtilities.ContainsAnySignatureAlgorithm(signatureAlgorithmsCert, (short) 3))
      TlsUtilities.AddToSet<int>(namedGroupRoles, 3);
    return namedGroupRoles;
  }

  protected virtual void CheckForUnexpectedServerExtension(
    IDictionary<int, byte[]> serverExtensions,
    int extensionType)
  {
    byte[] extensionData = TlsUtilities.GetExtensionData(serverExtensions, extensionType);
    if (extensionData != null && !this.AllowUnexpectedServerExtension(extensionType, extensionData))
      throw new TlsFatalAlert((short) 47);
  }

  protected virtual byte[] GetNewConnectionID() => (byte[]) null;

  public virtual TlsPskIdentity GetPskIdentity() => (TlsPskIdentity) null;

  public virtual TlsSrpIdentity GetSrpIdentity() => (TlsSrpIdentity) null;

  public virtual TlsDHGroupVerifier GetDHGroupVerifier()
  {
    return (TlsDHGroupVerifier) new DefaultTlsDHGroupVerifier();
  }

  public virtual TlsSrpConfigVerifier GetSrpConfigVerifier()
  {
    return (TlsSrpConfigVerifier) new DefaultTlsSrpConfigVerifier();
  }

  protected virtual IList<X509Name> GetCertificateAuthorities() => (IList<X509Name>) null;

  protected virtual IList<ProtocolName> GetProtocolNames() => (IList<ProtocolName>) null;

  protected virtual CertificateStatusRequest GetCertificateStatusRequest()
  {
    return new CertificateStatusRequest((short) 1, (object) new OcspStatusRequest((IList<ResponderID>) null, (X509Extensions) null));
  }

  protected virtual IList<CertificateStatusRequestItemV2> GetMultiCertStatusRequest()
  {
    return (IList<CertificateStatusRequestItemV2>) null;
  }

  protected virtual IList<ServerName> GetSniServerNames() => (IList<ServerName>) null;

  protected virtual IList<int> GetSupportedGroups(IList<int> namedGroupRoles)
  {
    TlsCrypto crypto = this.Crypto;
    List<int> supportedGroups = new List<int>();
    if (namedGroupRoles.Contains(2))
      TlsUtilities.AddIfSupported((IList<int>) supportedGroups, crypto, new int[2]
      {
        29,
        30
      });
    if (namedGroupRoles.Contains(2) || namedGroupRoles.Contains(3))
      TlsUtilities.AddIfSupported((IList<int>) supportedGroups, crypto, new int[2]
      {
        23,
        24
      });
    if (namedGroupRoles.Contains(1))
      TlsUtilities.AddIfSupported((IList<int>) supportedGroups, crypto, new int[3]
      {
        256 /*0x0100*/,
        257,
        258
      });
    return (IList<int>) supportedGroups;
  }

  protected virtual IList<SignatureAndHashAlgorithm> GetSupportedSignatureAlgorithms()
  {
    return TlsUtilities.GetDefaultSupportedSignatureAlgorithms((TlsContext) this.m_context);
  }

  protected virtual IList<SignatureAndHashAlgorithm> GetSupportedSignatureAlgorithmsCert()
  {
    return (IList<SignatureAndHashAlgorithm>) null;
  }

  protected virtual IList<TrustedAuthority> GetTrustedCAIndication()
  {
    return (IList<TrustedAuthority>) null;
  }

  protected virtual short[] GetAllowedClientCertificateTypes() => (short[]) null;

  protected virtual short[] GetAllowedServerCertificateTypes() => (short[]) null;

  public virtual void Init(TlsClientContext context)
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
    this.m_supportedGroups = (IList<int>) null;
    this.m_supportedSignatureAlgorithms = (IList<SignatureAndHashAlgorithm>) null;
    this.m_supportedSignatureAlgorithmsCert = (IList<SignatureAndHashAlgorithm>) null;
  }

  public virtual TlsSession GetSessionToResume() => (TlsSession) null;

  public virtual IList<TlsPskExternal> GetExternalPsks() => (IList<TlsPskExternal>) null;

  public virtual bool IsFallback() => false;

  public virtual IDictionary<int, byte[]> GetClientExtensions()
  {
    Dictionary<int, byte[]> extensions = new Dictionary<int, byte[]>();
    bool flag1 = false;
    bool flag2 = false;
    bool flag3 = false;
    foreach (ProtocolVersion protocolVersion in this.GetProtocolVersions())
    {
      if (TlsUtilities.IsTlsV13(protocolVersion))
        flag1 = true;
      else
        flag2 = true;
      flag3 |= ProtocolVersion.DTLSv12.Equals(protocolVersion);
    }
    IList<ProtocolName> protocolNames = this.GetProtocolNames();
    if (protocolNames != null)
      TlsExtensionsUtilities.AddAlpnExtensionClient((IDictionary<int, byte[]>) extensions, protocolNames);
    IList<ServerName> sniServerNames = this.GetSniServerNames();
    if (sniServerNames != null)
      TlsExtensionsUtilities.AddServerNameExtensionClient((IDictionary<int, byte[]>) extensions, sniServerNames);
    CertificateStatusRequest certificateStatusRequest = this.GetCertificateStatusRequest();
    if (certificateStatusRequest != null)
      TlsExtensionsUtilities.AddStatusRequestExtension((IDictionary<int, byte[]>) extensions, certificateStatusRequest);
    if (flag1)
    {
      IList<X509Name> certificateAuthorities = this.GetCertificateAuthorities();
      if (certificateAuthorities != null)
        TlsExtensionsUtilities.AddCertificateAuthoritiesExtension((IDictionary<int, byte[]>) extensions, certificateAuthorities);
    }
    if (flag2)
    {
      TlsExtensionsUtilities.AddEncryptThenMacExtension((IDictionary<int, byte[]>) extensions);
      IList<CertificateStatusRequestItemV2> certStatusRequest = this.GetMultiCertStatusRequest();
      if (certStatusRequest != null)
        TlsExtensionsUtilities.AddStatusRequestV2Extension((IDictionary<int, byte[]>) extensions, certStatusRequest);
      IList<TrustedAuthority> trustedCaIndication = this.GetTrustedCAIndication();
      if (trustedCaIndication != null)
        TlsExtensionsUtilities.AddTrustedCAKeysExtensionClient((IDictionary<int, byte[]>) extensions, trustedCaIndication);
    }
    if (TlsUtilities.IsSignatureAlgorithmsExtensionAllowed(this.m_context.ClientVersion))
    {
      IList<SignatureAndHashAlgorithm> signatureAlgorithms = this.GetSupportedSignatureAlgorithms();
      if (signatureAlgorithms != null && signatureAlgorithms.Count > 0)
      {
        this.m_supportedSignatureAlgorithms = signatureAlgorithms;
        TlsExtensionsUtilities.AddSignatureAlgorithmsExtension((IDictionary<int, byte[]>) extensions, signatureAlgorithms);
      }
      IList<SignatureAndHashAlgorithm> signatureAlgorithmsCert = this.GetSupportedSignatureAlgorithmsCert();
      if (signatureAlgorithmsCert != null && signatureAlgorithmsCert.Count > 0)
      {
        this.m_supportedSignatureAlgorithmsCert = signatureAlgorithmsCert;
        TlsExtensionsUtilities.AddSignatureAlgorithmsCertExtension((IDictionary<int, byte[]>) extensions, signatureAlgorithmsCert);
      }
    }
    IList<int> namedGroupRoles = this.GetNamedGroupRoles();
    IList<int> supportedGroups = this.GetSupportedGroups(namedGroupRoles);
    if (supportedGroups != null && supportedGroups.Count > 0)
    {
      this.m_supportedGroups = supportedGroups;
      TlsExtensionsUtilities.AddSupportedGroupsExtension((IDictionary<int, byte[]>) extensions, supportedGroups);
    }
    if (flag2 && (namedGroupRoles.Contains(2) || namedGroupRoles.Contains(3)))
      TlsExtensionsUtilities.AddSupportedPointFormatsExtension((IDictionary<int, byte[]>) extensions, new short[1]);
    short[] certificateTypes1 = this.GetAllowedClientCertificateTypes();
    if (certificateTypes1 != null && (certificateTypes1.Length > 1 || certificateTypes1[0] != (short) 0))
      TlsExtensionsUtilities.AddClientCertificateTypeExtensionClient((IDictionary<int, byte[]>) extensions, certificateTypes1);
    short[] certificateTypes2 = this.GetAllowedServerCertificateTypes();
    if (certificateTypes2 != null && (certificateTypes2.Length > 1 || certificateTypes2[0] != (short) 0))
      TlsExtensionsUtilities.AddServerCertificateTypeExtensionClient((IDictionary<int, byte[]>) extensions, certificateTypes2);
    if (flag3)
    {
      byte[] newConnectionId = this.GetNewConnectionID();
      if (newConnectionId != null)
        TlsExtensionsUtilities.AddConnectionIDExtension((IDictionary<int, byte[]>) extensions, newConnectionId);
    }
    return (IDictionary<int, byte[]>) extensions;
  }

  public virtual IList<int> GetEarlyKeyShareGroups()
  {
    if (this.m_supportedGroups == null || this.m_supportedGroups.Count < 1)
      return (IList<int>) null;
    if (this.m_supportedGroups.Contains(29))
      return TlsUtilities.VectorOfOne<int>(29);
    return this.m_supportedGroups.Contains(23) ? TlsUtilities.VectorOfOne<int>(23) : TlsUtilities.VectorOfOne<int>(this.m_supportedGroups[0]);
  }

  public virtual void NotifyServerVersion(ProtocolVersion serverVersion)
  {
  }

  public virtual void NotifySessionToResume(TlsSession session)
  {
  }

  public virtual void NotifySessionID(byte[] sessionID)
  {
  }

  public virtual void NotifySelectedCipherSuite(int selectedCipherSuite)
  {
  }

  public virtual void NotifySelectedPsk(TlsPsk selectedPsk)
  {
  }

  public virtual void ProcessServerExtensions(IDictionary<int, byte[]> serverExtensions)
  {
    if (serverExtensions == null)
      return;
    SecurityParameters securityParameters = this.m_context.SecurityParameters;
    if (TlsUtilities.IsTlsV13(securityParameters.NegotiatedVersion))
      return;
    this.CheckForUnexpectedServerExtension(serverExtensions, 13);
    this.CheckForUnexpectedServerExtension(serverExtensions, 50);
    this.CheckForUnexpectedServerExtension(serverExtensions, 10);
    if (TlsEccUtilities.IsEccCipherSuite(securityParameters.CipherSuite))
      TlsExtensionsUtilities.GetSupportedPointFormatsExtension(serverExtensions);
    else
      this.CheckForUnexpectedServerExtension(serverExtensions, 11);
    this.CheckForUnexpectedServerExtension(serverExtensions, 21);
  }

  public virtual void ProcessServerSupplementalData(
    IList<SupplementalDataEntry> serverSupplementalData)
  {
    if (serverSupplementalData != null)
      throw new TlsFatalAlert((short) 10);
  }

  public abstract TlsAuthentication GetAuthentication();

  public virtual IList<SupplementalDataEntry> GetClientSupplementalData()
  {
    return (IList<SupplementalDataEntry>) null;
  }

  public virtual void NotifyNewSessionTicket(NewSessionTicket newSessionTicket)
  {
  }
}
