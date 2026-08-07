// Decompiled with JetBrains decompiler
// Type: Opc.Ua.Configuration.ApplicationConfigurationBuilder
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Xml;

#nullable disable
namespace Opc.Ua.Configuration;

[ComVisible(true)]
public class ApplicationConfigurationBuilder : 
  IApplicationConfigurationBuilder,
  IApplicationConfigurationBuilderTypes,
  IApplicationConfigurationBuilderTransportQuotas,
  IApplicationConfigurationBuilderServer,
  IApplicationConfigurationBuilderClient,
  IApplicationConfigurationBuilderTransportQuotasSet,
  IApplicationConfigurationBuilderServerSelected,
  IApplicationConfigurationBuilderServerPolicies,
  IApplicationConfigurationBuilderServerOptions,
  IApplicationConfigurationBuilderSecurity,
  IApplicationConfigurationBuilderClientSelected,
  IApplicationConfigurationBuilderClientOptions,
  IApplicationConfigurationBuilderSecurityOptions,
  IApplicationConfigurationBuilderTraceConfiguration,
  IApplicationConfigurationBuilderCreate,
  IApplicationConfigurationBuilderExtension,
  IApplicationConfigurationBuilderSecurityOptionStores
{
  private bool m_typeSelected;

  public ApplicationConfigurationBuilder(ApplicationInstance applicationInstance)
  {
    this.ApplicationInstance = applicationInstance;
  }

  public ApplicationInstance ApplicationInstance { get; private set; }

  public ApplicationConfiguration ApplicationConfiguration
  {
    get => this.ApplicationInstance.ApplicationConfiguration;
  }

  public IApplicationConfigurationBuilderClientSelected AsClient()
  {
    switch (this.ApplicationInstance.ApplicationType)
    {
      case ApplicationType.Server:
        this.ApplicationInstance.ApplicationType = this.m_typeSelected ? ApplicationType.ClientAndServer : ApplicationType.Client;
        goto case ApplicationType.Client;
      case ApplicationType.Client:
      case ApplicationType.ClientAndServer:
        this.m_typeSelected = true;
        this.ApplicationConfiguration.ClientConfiguration = new ClientConfiguration();
        return (IApplicationConfigurationBuilderClientSelected) this;
      default:
        throw new ArgumentException("Invalid application type for client.");
    }
  }

  public IApplicationConfigurationBuilderSecurityOptions AddSecurityConfiguration(
    string subjectName,
    string pkiRoot = null,
    string appRoot = null,
    string rejectedRoot = null)
  {
    pkiRoot = this.DefaultPKIRoot(pkiRoot);
    appRoot = appRoot == null ? pkiRoot : this.DefaultPKIRoot(appRoot);
    rejectedRoot = rejectedRoot == null ? pkiRoot : this.DefaultPKIRoot(rejectedRoot);
    string storeType1 = CertificateStoreIdentifier.DetermineStoreType(appRoot);
    string storeType2 = CertificateStoreIdentifier.DetermineStoreType(pkiRoot);
    string storeType3 = CertificateStoreIdentifier.DetermineStoreType(rejectedRoot);
    ApplicationConfiguration applicationConfiguration = this.ApplicationConfiguration;
    SecurityConfiguration securityConfiguration = new SecurityConfiguration();
    securityConfiguration.ApplicationCertificate = new CertificateIdentifier()
    {
      StoreType = storeType1,
      StorePath = this.DefaultCertificateStorePath(ApplicationConfigurationBuilder.TrustlistType.Application, appRoot),
      SubjectName = Utils.ReplaceDCLocalhost(subjectName)
    };
    CertificateTrustList certificateTrustList1 = new CertificateTrustList();
    certificateTrustList1.StoreType = storeType2;
    certificateTrustList1.StorePath = this.DefaultCertificateStorePath(ApplicationConfigurationBuilder.TrustlistType.Trusted, pkiRoot);
    securityConfiguration.TrustedPeerCertificates = certificateTrustList1;
    CertificateTrustList certificateTrustList2 = new CertificateTrustList();
    certificateTrustList2.StoreType = storeType2;
    certificateTrustList2.StorePath = this.DefaultCertificateStorePath(ApplicationConfigurationBuilder.TrustlistType.Issuer, pkiRoot);
    securityConfiguration.TrustedIssuerCertificates = certificateTrustList2;
    CertificateTrustList certificateTrustList3 = new CertificateTrustList();
    certificateTrustList3.StoreType = storeType2;
    certificateTrustList3.StorePath = this.DefaultCertificateStorePath(ApplicationConfigurationBuilder.TrustlistType.TrustedHttps, pkiRoot);
    securityConfiguration.TrustedHttpsCertificates = certificateTrustList3;
    CertificateTrustList certificateTrustList4 = new CertificateTrustList();
    certificateTrustList4.StoreType = storeType2;
    certificateTrustList4.StorePath = this.DefaultCertificateStorePath(ApplicationConfigurationBuilder.TrustlistType.IssuerHttps, pkiRoot);
    securityConfiguration.HttpsIssuerCertificates = certificateTrustList4;
    CertificateTrustList certificateTrustList5 = new CertificateTrustList();
    certificateTrustList5.StoreType = storeType2;
    certificateTrustList5.StorePath = this.DefaultCertificateStorePath(ApplicationConfigurationBuilder.TrustlistType.TrustedUser, pkiRoot);
    securityConfiguration.TrustedUserCertificates = certificateTrustList5;
    CertificateTrustList certificateTrustList6 = new CertificateTrustList();
    certificateTrustList6.StoreType = storeType2;
    certificateTrustList6.StorePath = this.DefaultCertificateStorePath(ApplicationConfigurationBuilder.TrustlistType.IssuerUser, pkiRoot);
    securityConfiguration.UserIssuerCertificates = certificateTrustList6;
    CertificateTrustList certificateTrustList7 = new CertificateTrustList();
    certificateTrustList7.StoreType = storeType3;
    certificateTrustList7.StorePath = this.DefaultCertificateStorePath(ApplicationConfigurationBuilder.TrustlistType.Rejected, rejectedRoot);
    securityConfiguration.RejectedCertificateStore = (CertificateStoreIdentifier) certificateTrustList7;
    applicationConfiguration.SecurityConfiguration = securityConfiguration;
    this.SetSecureDefaults(this.ApplicationConfiguration.SecurityConfiguration);
    return (IApplicationConfigurationBuilderSecurityOptions) this;
  }

  public IApplicationConfigurationBuilderSecurityOptionStores AddSecurityConfigurationStores(
    string subjectName,
    string appRoot,
    string trustedRoot,
    string issuerRoot,
    string rejectedRoot = null)
  {
    string storeType1 = CertificateStoreIdentifier.DetermineStoreType(appRoot);
    string storeType2 = CertificateStoreIdentifier.DetermineStoreType(issuerRoot);
    string storeType3 = CertificateStoreIdentifier.DetermineStoreType(trustedRoot);
    rejectedRoot = rejectedRoot ?? this.DefaultPKIRoot((string) null);
    string storeType4 = CertificateStoreIdentifier.DetermineStoreType(rejectedRoot);
    ApplicationConfiguration applicationConfiguration = this.ApplicationConfiguration;
    SecurityConfiguration securityConfiguration = new SecurityConfiguration();
    securityConfiguration.ApplicationCertificate = new CertificateIdentifier()
    {
      StoreType = storeType1,
      StorePath = this.DefaultCertificateStorePath(ApplicationConfigurationBuilder.TrustlistType.Application, appRoot),
      SubjectName = Utils.ReplaceDCLocalhost(subjectName)
    };
    CertificateTrustList certificateTrustList1 = new CertificateTrustList();
    certificateTrustList1.StoreType = storeType3;
    certificateTrustList1.StorePath = this.DefaultCertificateStorePath(ApplicationConfigurationBuilder.TrustlistType.Trusted, trustedRoot);
    securityConfiguration.TrustedPeerCertificates = certificateTrustList1;
    CertificateTrustList certificateTrustList2 = new CertificateTrustList();
    certificateTrustList2.StoreType = storeType2;
    certificateTrustList2.StorePath = this.DefaultCertificateStorePath(ApplicationConfigurationBuilder.TrustlistType.Issuer, issuerRoot);
    securityConfiguration.TrustedIssuerCertificates = certificateTrustList2;
    CertificateTrustList certificateTrustList3 = new CertificateTrustList();
    certificateTrustList3.StoreType = storeType4;
    certificateTrustList3.StorePath = this.DefaultCertificateStorePath(ApplicationConfigurationBuilder.TrustlistType.Rejected, rejectedRoot);
    securityConfiguration.RejectedCertificateStore = (CertificateStoreIdentifier) certificateTrustList3;
    applicationConfiguration.SecurityConfiguration = securityConfiguration;
    this.SetSecureDefaults(this.ApplicationConfiguration.SecurityConfiguration);
    return (IApplicationConfigurationBuilderSecurityOptionStores) this;
  }

  public IApplicationConfigurationBuilderSecurityOptionStores AddSecurityConfigurationUserStore(
    string trustedRoot,
    string issuerRoot)
  {
    string storeType1 = CertificateStoreIdentifier.DetermineStoreType(trustedRoot);
    string storeType2 = CertificateStoreIdentifier.DetermineStoreType(issuerRoot);
    SecurityConfiguration securityConfiguration1 = this.ApplicationConfiguration.SecurityConfiguration;
    CertificateTrustList certificateTrustList1 = new CertificateTrustList();
    certificateTrustList1.StoreType = storeType1;
    certificateTrustList1.StorePath = this.DefaultCertificateStorePath(ApplicationConfigurationBuilder.TrustlistType.TrustedUser, trustedRoot);
    securityConfiguration1.TrustedUserCertificates = certificateTrustList1;
    SecurityConfiguration securityConfiguration2 = this.ApplicationConfiguration.SecurityConfiguration;
    CertificateTrustList certificateTrustList2 = new CertificateTrustList();
    certificateTrustList2.StoreType = storeType2;
    certificateTrustList2.StorePath = this.DefaultCertificateStorePath(ApplicationConfigurationBuilder.TrustlistType.IssuerUser, issuerRoot);
    securityConfiguration2.UserIssuerCertificates = certificateTrustList2;
    return (IApplicationConfigurationBuilderSecurityOptionStores) this;
  }

  public IApplicationConfigurationBuilderSecurityOptionStores AddSecurityConfigurationHttpsStore(
    string trustedRoot,
    string issuerRoot)
  {
    string storeType1 = CertificateStoreIdentifier.DetermineStoreType(trustedRoot);
    string storeType2 = CertificateStoreIdentifier.DetermineStoreType(issuerRoot);
    SecurityConfiguration securityConfiguration1 = this.ApplicationConfiguration.SecurityConfiguration;
    CertificateTrustList certificateTrustList1 = new CertificateTrustList();
    certificateTrustList1.StoreType = storeType1;
    certificateTrustList1.StorePath = this.DefaultCertificateStorePath(ApplicationConfigurationBuilder.TrustlistType.TrustedHttps, storeType1);
    securityConfiguration1.TrustedHttpsCertificates = certificateTrustList1;
    SecurityConfiguration securityConfiguration2 = this.ApplicationConfiguration.SecurityConfiguration;
    CertificateTrustList certificateTrustList2 = new CertificateTrustList();
    certificateTrustList2.StoreType = storeType2;
    certificateTrustList2.StorePath = this.DefaultCertificateStorePath(ApplicationConfigurationBuilder.TrustlistType.IssuerHttps, issuerRoot);
    securityConfiguration2.HttpsIssuerCertificates = certificateTrustList2;
    return (IApplicationConfigurationBuilderSecurityOptionStores) this;
  }

  public async Task<ApplicationConfiguration> Create()
  {
    if ((this.ApplicationInstance.ApplicationType == ApplicationType.Server || this.ApplicationInstance.ApplicationType == ApplicationType.ClientAndServer) && this.ApplicationConfiguration.ServerConfiguration == null)
      throw new ArgumentException("ApplicationType Server is not configured.");
    if ((this.ApplicationInstance.ApplicationType == ApplicationType.Client || this.ApplicationInstance.ApplicationType == ApplicationType.ClientAndServer) && this.ApplicationConfiguration.ClientConfiguration == null)
      throw new ArgumentException("ApplicationType Client is not configured.");
    ServerConfiguration serverConfiguration1 = this.ApplicationConfiguration.ServerConfiguration;
    if ((serverConfiguration1 != null ? (serverConfiguration1.UserTokenPolicies.Count == 0 ? 1 : 0) : 0) != 0)
      this.ApplicationConfiguration.ServerConfiguration.UserTokenPolicies.Add(new UserTokenPolicy(UserTokenType.Anonymous));
    ServerConfiguration serverConfiguration2 = this.ApplicationConfiguration.ServerConfiguration;
    if ((serverConfiguration2 != null ? (serverConfiguration2.SecurityPolicies.Count == 0 ? 1 : 0) : 0) != 0)
      this.AddSecurityPolicies();
    this.ApplicationConfiguration.TraceConfiguration?.ApplySettings();
    await this.ApplicationConfiguration.Validate(this.ApplicationInstance.ApplicationType).ConfigureAwait(false);
    await this.ApplicationConfiguration.CertificateValidator.Update(this.ApplicationConfiguration.SecurityConfiguration).ConfigureAwait(false);
    return this.ApplicationConfiguration;
  }

  public IApplicationConfigurationBuilderServerSelected AsServer(
    string[] baseAddresses,
    string[] alternateBaseAddresses = null)
  {
    switch (this.ApplicationInstance.ApplicationType)
    {
      case ApplicationType.Server:
      case ApplicationType.ClientAndServer:
        this.m_typeSelected = true;
        ServerConfiguration serverConfiguration = new ServerConfiguration();
        serverConfiguration.MaxRegistrationInterval = 0;
        foreach (string baseAddress in baseAddresses)
          serverConfiguration.BaseAddresses.Add(Utils.ReplaceLocalhost(baseAddress));
        if (alternateBaseAddresses != null)
        {
          foreach (string alternateBaseAddress in alternateBaseAddresses)
            serverConfiguration.AlternateBaseAddresses.Add(Utils.ReplaceLocalhost(alternateBaseAddress));
        }
        serverConfiguration.SecurityPolicies = new ServerSecurityPolicyCollection();
        serverConfiguration.UserTokenPolicies = new UserTokenPolicyCollection();
        this.ApplicationConfiguration.ServerConfiguration = serverConfiguration;
        return (IApplicationConfigurationBuilderServerSelected) this;
      case ApplicationType.Client:
        this.ApplicationInstance.ApplicationType = this.m_typeSelected ? ApplicationType.ClientAndServer : ApplicationType.Server;
        goto case ApplicationType.Server;
      default:
        throw new ArgumentException("Invalid application type for server.");
    }
  }

  public IApplicationConfigurationBuilderServerSelected AddUnsecurePolicyNone(bool addPolicy = true)
  {
    if (addPolicy)
      this.InternalAddPolicy(this.ApplicationConfiguration.ServerConfiguration.SecurityPolicies, MessageSecurityMode.None, "http://opcfoundation.org/UA/SecurityPolicy#None");
    return (IApplicationConfigurationBuilderServerSelected) this;
  }

  public IApplicationConfigurationBuilderServerSelected AddSignPolicies(bool addPolicies = true)
  {
    if (addPolicies)
      this.AddSecurityPolicies(true);
    return (IApplicationConfigurationBuilderServerSelected) this;
  }

  public IApplicationConfigurationBuilderServerSelected AddSignAndEncryptPolicies(bool addPolicies = true)
  {
    if (addPolicies)
      this.AddSecurityPolicies();
    return (IApplicationConfigurationBuilderServerSelected) this;
  }

  public IApplicationConfigurationBuilderServerSelected AddPolicy(
    MessageSecurityMode securityMode,
    string securityPolicy)
  {
    if (SecurityPolicies.GetDisplayName(securityPolicy) == null)
      throw new ArgumentException("Unknown security policy", nameof (securityPolicy));
    if (securityMode == MessageSecurityMode.None || securityPolicy.Equals("http://opcfoundation.org/UA/SecurityPolicy#None"))
      throw new ArgumentException("Use AddUnsecurePolicyNone to add no security policy.");
    this.InternalAddPolicy(this.ApplicationConfiguration.ServerConfiguration.SecurityPolicies, securityMode, securityPolicy);
    return (IApplicationConfigurationBuilderServerSelected) this;
  }

  public IApplicationConfigurationBuilderServerSelected AddUserTokenPolicy(
    UserTokenType userTokenType)
  {
    this.ApplicationConfiguration.ServerConfiguration.UserTokenPolicies.Add(new UserTokenPolicy(userTokenType));
    return (IApplicationConfigurationBuilderServerSelected) this;
  }

  public IApplicationConfigurationBuilderServerSelected AddUserTokenPolicy(
    UserTokenPolicy userTokenPolicy)
  {
    if (userTokenPolicy == null)
      throw new ArgumentNullException(nameof (userTokenPolicy));
    this.ApplicationConfiguration.ServerConfiguration.UserTokenPolicies.Add(userTokenPolicy);
    return (IApplicationConfigurationBuilderServerSelected) this;
  }

  public IApplicationConfigurationBuilderSecurityOptions SetAutoAcceptUntrustedCertificates(
    bool autoAccept)
  {
    this.ApplicationConfiguration.SecurityConfiguration.AutoAcceptUntrustedCertificates = autoAccept;
    return (IApplicationConfigurationBuilderSecurityOptions) this;
  }

  public IApplicationConfigurationBuilderSecurityOptions SetAddAppCertToTrustedStore(
    bool addToTrustedStore)
  {
    this.ApplicationConfiguration.SecurityConfiguration.AddAppCertToTrustedStore = addToTrustedStore;
    return (IApplicationConfigurationBuilderSecurityOptions) this;
  }

  public IApplicationConfigurationBuilderSecurityOptions SetRejectSHA1SignedCertificates(
    bool rejectSHA1Signed)
  {
    this.ApplicationConfiguration.SecurityConfiguration.RejectSHA1SignedCertificates = rejectSHA1Signed;
    return (IApplicationConfigurationBuilderSecurityOptions) this;
  }

  public IApplicationConfigurationBuilderSecurityOptions SetRejectUnknownRevocationStatus(
    bool rejectUnknownRevocationStatus)
  {
    this.ApplicationConfiguration.SecurityConfiguration.RejectUnknownRevocationStatus = rejectUnknownRevocationStatus;
    return (IApplicationConfigurationBuilderSecurityOptions) this;
  }

  public IApplicationConfigurationBuilderSecurityOptions SetUseValidatedCertificates(
    bool useValidatedCertificates)
  {
    this.ApplicationConfiguration.SecurityConfiguration.UseValidatedCertificates = useValidatedCertificates;
    return (IApplicationConfigurationBuilderSecurityOptions) this;
  }

  public IApplicationConfigurationBuilderSecurityOptions SetSuppressNonceValidationErrors(
    bool suppressNonceValidationErrors)
  {
    this.ApplicationConfiguration.SecurityConfiguration.SuppressNonceValidationErrors = suppressNonceValidationErrors;
    return (IApplicationConfigurationBuilderSecurityOptions) this;
  }

  public IApplicationConfigurationBuilderSecurityOptions SetSendCertificateChain(
    bool sendCertificateChain)
  {
    this.ApplicationConfiguration.SecurityConfiguration.SendCertificateChain = sendCertificateChain;
    return (IApplicationConfigurationBuilderSecurityOptions) this;
  }

  public IApplicationConfigurationBuilderSecurityOptions SetMinimumCertificateKeySize(ushort keySize)
  {
    this.ApplicationConfiguration.SecurityConfiguration.MinimumCertificateKeySize = keySize;
    return (IApplicationConfigurationBuilderSecurityOptions) this;
  }

  public IApplicationConfigurationBuilderSecurityOptions AddCertificatePasswordProvider(
    ICertificatePasswordProvider certificatePasswordProvider)
  {
    this.ApplicationConfiguration.SecurityConfiguration.CertificatePasswordProvider = certificatePasswordProvider;
    return (IApplicationConfigurationBuilderSecurityOptions) this;
  }

  public IApplicationConfigurationBuilderTransportQuotasSet SetTransportQuotas(
    TransportQuotas transportQuotas)
  {
    this.ApplicationConfiguration.TransportQuotas = transportQuotas;
    return (IApplicationConfigurationBuilderTransportQuotasSet) this;
  }

  public IApplicationConfigurationBuilderTransportQuotas SetOperationTimeout(int operationTimeout)
  {
    this.ApplicationConfiguration.TransportQuotas.OperationTimeout = operationTimeout;
    return (IApplicationConfigurationBuilderTransportQuotas) this;
  }

  public IApplicationConfigurationBuilderTransportQuotas SetMaxStringLength(int maxStringLength)
  {
    this.ApplicationConfiguration.TransportQuotas.MaxStringLength = maxStringLength;
    return (IApplicationConfigurationBuilderTransportQuotas) this;
  }

  public IApplicationConfigurationBuilderTransportQuotas SetMaxByteStringLength(
    int maxByteStringLength)
  {
    this.ApplicationConfiguration.TransportQuotas.MaxByteStringLength = maxByteStringLength;
    return (IApplicationConfigurationBuilderTransportQuotas) this;
  }

  public IApplicationConfigurationBuilderTransportQuotas SetMaxArrayLength(int maxArrayLength)
  {
    this.ApplicationConfiguration.TransportQuotas.MaxArrayLength = maxArrayLength;
    return (IApplicationConfigurationBuilderTransportQuotas) this;
  }

  public IApplicationConfigurationBuilderTransportQuotas SetMaxMessageSize(int maxMessageSize)
  {
    this.ApplicationConfiguration.TransportQuotas.MaxMessageSize = maxMessageSize;
    return (IApplicationConfigurationBuilderTransportQuotas) this;
  }

  public IApplicationConfigurationBuilderTransportQuotas SetMaxBufferSize(int maxBufferSize)
  {
    this.ApplicationConfiguration.TransportQuotas.MaxBufferSize = maxBufferSize;
    return (IApplicationConfigurationBuilderTransportQuotas) this;
  }

  public IApplicationConfigurationBuilderTransportQuotas SetChannelLifetime(int channelLifetime)
  {
    this.ApplicationConfiguration.TransportQuotas.ChannelLifetime = channelLifetime;
    return (IApplicationConfigurationBuilderTransportQuotas) this;
  }

  public IApplicationConfigurationBuilderTransportQuotas SetSecurityTokenLifetime(
    int securityTokenLifetime)
  {
    this.ApplicationConfiguration.TransportQuotas.SecurityTokenLifetime = securityTokenLifetime;
    return (IApplicationConfigurationBuilderTransportQuotas) this;
  }

  public IApplicationConfigurationBuilderServerOptions SetMinRequestThreadCount(
    int minRequestThreadCount)
  {
    this.ApplicationConfiguration.ServerConfiguration.MinRequestThreadCount = minRequestThreadCount;
    return (IApplicationConfigurationBuilderServerOptions) this;
  }

  public IApplicationConfigurationBuilderServerOptions SetMaxRequestThreadCount(
    int maxRequestThreadCount)
  {
    this.ApplicationConfiguration.ServerConfiguration.MaxRequestThreadCount = maxRequestThreadCount;
    return (IApplicationConfigurationBuilderServerOptions) this;
  }

  public IApplicationConfigurationBuilderServerOptions SetMaxQueuedRequestCount(
    int maxQueuedRequestCount)
  {
    this.ApplicationConfiguration.ServerConfiguration.MaxQueuedRequestCount = maxQueuedRequestCount;
    return (IApplicationConfigurationBuilderServerOptions) this;
  }

  public IApplicationConfigurationBuilderServerOptions SetDiagnosticsEnabled(bool diagnosticsEnabled)
  {
    this.ApplicationConfiguration.ServerConfiguration.DiagnosticsEnabled = diagnosticsEnabled;
    return (IApplicationConfigurationBuilderServerOptions) this;
  }

  public IApplicationConfigurationBuilderServerOptions SetMaxSessionCount(int maxSessionCount)
  {
    this.ApplicationConfiguration.ServerConfiguration.MaxSessionCount = maxSessionCount;
    return (IApplicationConfigurationBuilderServerOptions) this;
  }

  public IApplicationConfigurationBuilderServerOptions SetMinSessionTimeout(int minSessionTimeout)
  {
    this.ApplicationConfiguration.ServerConfiguration.MinSessionTimeout = minSessionTimeout;
    return (IApplicationConfigurationBuilderServerOptions) this;
  }

  public IApplicationConfigurationBuilderServerOptions SetMaxSessionTimeout(int maxSessionTimeout)
  {
    this.ApplicationConfiguration.ServerConfiguration.MaxSessionTimeout = maxSessionTimeout;
    return (IApplicationConfigurationBuilderServerOptions) this;
  }

  public IApplicationConfigurationBuilderServerOptions SetMaxBrowseContinuationPoints(
    int maxBrowseContinuationPoints)
  {
    this.ApplicationConfiguration.ServerConfiguration.MaxBrowseContinuationPoints = maxBrowseContinuationPoints;
    return (IApplicationConfigurationBuilderServerOptions) this;
  }

  public IApplicationConfigurationBuilderServerOptions SetMaxQueryContinuationPoints(
    int maxQueryContinuationPoints)
  {
    this.ApplicationConfiguration.ServerConfiguration.MaxQueryContinuationPoints = maxQueryContinuationPoints;
    return (IApplicationConfigurationBuilderServerOptions) this;
  }

  public IApplicationConfigurationBuilderServerOptions SetMaxHistoryContinuationPoints(
    int maxHistoryContinuationPoints)
  {
    this.ApplicationConfiguration.ServerConfiguration.MaxHistoryContinuationPoints = maxHistoryContinuationPoints;
    return (IApplicationConfigurationBuilderServerOptions) this;
  }

  public IApplicationConfigurationBuilderServerOptions SetMaxRequestAge(int maxRequestAge)
  {
    this.ApplicationConfiguration.ServerConfiguration.MaxRequestAge = maxRequestAge;
    return (IApplicationConfigurationBuilderServerOptions) this;
  }

  public IApplicationConfigurationBuilderServerOptions SetMinPublishingInterval(
    int minPublishingInterval)
  {
    this.ApplicationConfiguration.ServerConfiguration.MinPublishingInterval = minPublishingInterval;
    return (IApplicationConfigurationBuilderServerOptions) this;
  }

  public IApplicationConfigurationBuilderServerOptions SetMaxPublishingInterval(
    int maxPublishingInterval)
  {
    this.ApplicationConfiguration.ServerConfiguration.MaxPublishingInterval = maxPublishingInterval;
    return (IApplicationConfigurationBuilderServerOptions) this;
  }

  public IApplicationConfigurationBuilderServerOptions SetPublishingResolution(
    int publishingResolution)
  {
    this.ApplicationConfiguration.ServerConfiguration.PublishingResolution = publishingResolution;
    return (IApplicationConfigurationBuilderServerOptions) this;
  }

  public IApplicationConfigurationBuilderServerOptions SetMaxSubscriptionLifetime(
    int maxSubscriptionLifetime)
  {
    this.ApplicationConfiguration.ServerConfiguration.MaxSubscriptionLifetime = maxSubscriptionLifetime;
    return (IApplicationConfigurationBuilderServerOptions) this;
  }

  public IApplicationConfigurationBuilderServerOptions SetMaxMessageQueueSize(
    int maxMessageQueueSize)
  {
    this.ApplicationConfiguration.ServerConfiguration.MaxMessageQueueSize = maxMessageQueueSize;
    return (IApplicationConfigurationBuilderServerOptions) this;
  }

  public IApplicationConfigurationBuilderServerOptions SetMaxNotificationQueueSize(
    int maxNotificationQueueSize)
  {
    this.ApplicationConfiguration.ServerConfiguration.MaxNotificationQueueSize = maxNotificationQueueSize;
    return (IApplicationConfigurationBuilderServerOptions) this;
  }

  public IApplicationConfigurationBuilderServerOptions SetMaxNotificationsPerPublish(
    int maxNotificationsPerPublish)
  {
    this.ApplicationConfiguration.ServerConfiguration.MaxNotificationsPerPublish = maxNotificationsPerPublish;
    return (IApplicationConfigurationBuilderServerOptions) this;
  }

  public IApplicationConfigurationBuilderServerOptions SetMinMetadataSamplingInterval(
    int minMetadataSamplingInterval)
  {
    this.ApplicationConfiguration.ServerConfiguration.MinMetadataSamplingInterval = minMetadataSamplingInterval;
    return (IApplicationConfigurationBuilderServerOptions) this;
  }

  public IApplicationConfigurationBuilderServerOptions SetAvailableSamplingRates(
    SamplingRateGroupCollection availableSampleRates)
  {
    this.ApplicationConfiguration.ServerConfiguration.AvailableSamplingRates = availableSampleRates;
    return (IApplicationConfigurationBuilderServerOptions) this;
  }

  public IApplicationConfigurationBuilderServerOptions SetRegistrationEndpoint(
    EndpointDescription registrationEndpoint)
  {
    this.ApplicationConfiguration.ServerConfiguration.RegistrationEndpoint = registrationEndpoint;
    return (IApplicationConfigurationBuilderServerOptions) this;
  }

  public IApplicationConfigurationBuilderServerOptions SetMaxRegistrationInterval(
    int maxRegistrationInterval)
  {
    this.ApplicationConfiguration.ServerConfiguration.MaxRegistrationInterval = maxRegistrationInterval;
    return (IApplicationConfigurationBuilderServerOptions) this;
  }

  public IApplicationConfigurationBuilderServerOptions SetNodeManagerSaveFile(
    string nodeManagerSaveFile)
  {
    this.ApplicationConfiguration.ServerConfiguration.NodeManagerSaveFile = nodeManagerSaveFile;
    return (IApplicationConfigurationBuilderServerOptions) this;
  }

  public IApplicationConfigurationBuilderServerOptions SetMinSubscriptionLifetime(
    int minSubscriptionLifetime)
  {
    this.ApplicationConfiguration.ServerConfiguration.MinSubscriptionLifetime = minSubscriptionLifetime;
    return (IApplicationConfigurationBuilderServerOptions) this;
  }

  public IApplicationConfigurationBuilderServerOptions SetMaxPublishRequestCount(
    int maxPublishRequestCount)
  {
    this.ApplicationConfiguration.ServerConfiguration.MaxPublishRequestCount = maxPublishRequestCount;
    return (IApplicationConfigurationBuilderServerOptions) this;
  }

  public IApplicationConfigurationBuilderServerOptions SetMaxSubscriptionCount(
    int maxSubscriptionCount)
  {
    this.ApplicationConfiguration.ServerConfiguration.MaxSubscriptionCount = maxSubscriptionCount;
    return (IApplicationConfigurationBuilderServerOptions) this;
  }

  public IApplicationConfigurationBuilderServerOptions SetMaxEventQueueSize(int setMaxEventQueueSize)
  {
    this.ApplicationConfiguration.ServerConfiguration.MaxEventQueueSize = setMaxEventQueueSize;
    return (IApplicationConfigurationBuilderServerOptions) this;
  }

  public IApplicationConfigurationBuilderServerOptions AddServerProfile(string serverProfile)
  {
    this.ApplicationConfiguration.ServerConfiguration.ServerProfileArray.Add(serverProfile);
    return (IApplicationConfigurationBuilderServerOptions) this;
  }

  public IApplicationConfigurationBuilderServerOptions SetShutdownDelay(int shutdownDelay)
  {
    this.ApplicationConfiguration.ServerConfiguration.ShutdownDelay = shutdownDelay;
    return (IApplicationConfigurationBuilderServerOptions) this;
  }

  public IApplicationConfigurationBuilderServerOptions AddServerCapabilities(string serverCapability)
  {
    this.ApplicationConfiguration.ServerConfiguration.ServerCapabilities.Add(serverCapability);
    return (IApplicationConfigurationBuilderServerOptions) this;
  }

  public IApplicationConfigurationBuilderServerOptions SetSupportedPrivateKeyFormats(
    StringCollection supportedPrivateKeyFormats)
  {
    this.ApplicationConfiguration.ServerConfiguration.SupportedPrivateKeyFormats = supportedPrivateKeyFormats;
    return (IApplicationConfigurationBuilderServerOptions) this;
  }

  public IApplicationConfigurationBuilderServerOptions SetMaxTrustListSize(int maxTrustListSize)
  {
    this.ApplicationConfiguration.ServerConfiguration.MaxTrustListSize = maxTrustListSize;
    return (IApplicationConfigurationBuilderServerOptions) this;
  }

  public IApplicationConfigurationBuilderServerOptions SetMultiCastDnsEnabled(
    bool multiCastDnsEnabled)
  {
    this.ApplicationConfiguration.ServerConfiguration.MultiCastDnsEnabled = multiCastDnsEnabled;
    return (IApplicationConfigurationBuilderServerOptions) this;
  }

  public IApplicationConfigurationBuilderServerOptions SetReverseConnect(
    ReverseConnectServerConfiguration reverseConnectConfiguration)
  {
    this.ApplicationConfiguration.ServerConfiguration.ReverseConnect = reverseConnectConfiguration;
    return (IApplicationConfigurationBuilderServerOptions) this;
  }

  public IApplicationConfigurationBuilderServerOptions SetOperationLimits(
    OperationLimits operationLimits)
  {
    this.ApplicationConfiguration.ServerConfiguration.OperationLimits = operationLimits;
    return (IApplicationConfigurationBuilderServerOptions) this;
  }

  public IApplicationConfigurationBuilderServerOptions SetAuditingEnabled(bool auditingEnabled)
  {
    this.ApplicationConfiguration.ServerConfiguration.AuditingEnabled = auditingEnabled;
    return (IApplicationConfigurationBuilderServerOptions) this;
  }

  public IApplicationConfigurationBuilderClientOptions SetDefaultSessionTimeout(
    int defaultSessionTimeout)
  {
    this.ApplicationConfiguration.ClientConfiguration.DefaultSessionTimeout = defaultSessionTimeout;
    return (IApplicationConfigurationBuilderClientOptions) this;
  }

  public IApplicationConfigurationBuilderClientOptions AddWellKnownDiscoveryUrls(
    string wellKnownDiscoveryUrl)
  {
    this.ApplicationConfiguration.ClientConfiguration.WellKnownDiscoveryUrls.Add(wellKnownDiscoveryUrl);
    return (IApplicationConfigurationBuilderClientOptions) this;
  }

  public IApplicationConfigurationBuilderClientOptions AddDiscoveryServer(
    EndpointDescription discoveryServer)
  {
    this.ApplicationConfiguration.ClientConfiguration.DiscoveryServers.Add(discoveryServer);
    return (IApplicationConfigurationBuilderClientOptions) this;
  }

  public IApplicationConfigurationBuilderClientOptions SetEndpointCacheFilePath(
    string endpointCacheFilePath)
  {
    this.ApplicationConfiguration.ClientConfiguration.EndpointCacheFilePath = endpointCacheFilePath;
    return (IApplicationConfigurationBuilderClientOptions) this;
  }

  IApplicationConfigurationBuilderClientOptions IApplicationConfigurationBuilderClientOptions.SetMinSubscriptionLifetime(
    int minSubscriptionLifetime)
  {
    this.ApplicationConfiguration.ClientConfiguration.MinSubscriptionLifetime = minSubscriptionLifetime;
    return (IApplicationConfigurationBuilderClientOptions) this;
  }

  public IApplicationConfigurationBuilderClientOptions SetReverseConnect(
    ReverseConnectClientConfiguration reverseConnect)
  {
    this.ApplicationConfiguration.ClientConfiguration.ReverseConnect = reverseConnect;
    return (IApplicationConfigurationBuilderClientOptions) this;
  }

  public IApplicationConfigurationBuilderClientOptions SetClientOperationLimits(
    OperationLimits operationLimits)
  {
    this.ApplicationConfiguration.ClientConfiguration.OperationLimits = operationLimits;
    return (IApplicationConfigurationBuilderClientOptions) this;
  }

  public IApplicationConfigurationBuilderTraceConfiguration SetOutputFilePath(string outputFilePath)
  {
    this.ApplicationConfiguration.TraceConfiguration.OutputFilePath = outputFilePath;
    return (IApplicationConfigurationBuilderTraceConfiguration) this;
  }

  public IApplicationConfigurationBuilderTraceConfiguration SetDeleteOnLoad(bool deleteOnLoad)
  {
    this.ApplicationConfiguration.TraceConfiguration.DeleteOnLoad = deleteOnLoad;
    return (IApplicationConfigurationBuilderTraceConfiguration) this;
  }

  public IApplicationConfigurationBuilderTraceConfiguration SetTraceMasks(int traceMasks)
  {
    this.ApplicationConfiguration.TraceConfiguration.TraceMasks = traceMasks;
    return (IApplicationConfigurationBuilderTraceConfiguration) this;
  }

  public IApplicationConfigurationBuilderExtension AddExtension<T>(
    XmlQualifiedName elementName,
    object value)
  {
    this.ApplicationConfiguration.UpdateExtension<T>(elementName, value);
    return (IApplicationConfigurationBuilderExtension) this;
  }

  private string DefaultPKIRoot(string root)
  {
    if (root == null || root.Equals("Directory", StringComparison.OrdinalIgnoreCase))
      return CertificateStoreIdentifier.DefaultPKIRoot;
    return root.Equals("X509Store", StringComparison.OrdinalIgnoreCase) ? CertificateStoreIdentifier.CurrentUser : root;
  }

  private string DefaultCertificateStorePath(
    ApplicationConfigurationBuilder.TrustlistType trustListType,
    string pkiRoot)
  {
    string storeType = CertificateStoreIdentifier.DetermineStoreType(pkiRoot);
    if (storeType.Equals("Directory", StringComparison.OrdinalIgnoreCase))
    {
      string path2 = "";
      switch (trustListType)
      {
        case ApplicationConfigurationBuilder.TrustlistType.Application:
          path2 = "own";
          break;
        case ApplicationConfigurationBuilder.TrustlistType.Trusted:
          path2 = "trusted";
          break;
        case ApplicationConfigurationBuilder.TrustlistType.Issuer:
          path2 = "issuer";
          break;
        case ApplicationConfigurationBuilder.TrustlistType.TrustedHttps:
          path2 = "trustedHttps";
          break;
        case ApplicationConfigurationBuilder.TrustlistType.IssuerHttps:
          path2 = "issuerHttps";
          break;
        case ApplicationConfigurationBuilder.TrustlistType.TrustedUser:
          path2 = "trustedUser";
          break;
        case ApplicationConfigurationBuilder.TrustlistType.IssuerUser:
          path2 = "issuerUser";
          break;
        case ApplicationConfigurationBuilder.TrustlistType.Rejected:
          path2 = "rejected";
          break;
      }
      int startIndex = pkiRoot.Length - path2.Length;
      char ch = pkiRoot.Last<char>();
      if ((int) ch == (int) Path.DirectorySeparatorChar || (int) ch == (int) Path.AltDirectorySeparatorChar)
        --startIndex;
      return startIndex > 0 && pkiRoot.Substring(startIndex, path2.Length).Equals(path2, StringComparison.OrdinalIgnoreCase) ? pkiRoot : Path.Combine(pkiRoot, path2);
    }
    if (!storeType.Equals("X509Store", StringComparison.OrdinalIgnoreCase))
      return pkiRoot;
    switch (trustListType)
    {
      case ApplicationConfigurationBuilder.TrustlistType.Application:
        return pkiRoot + "UA_MachineDefault";
      case ApplicationConfigurationBuilder.TrustlistType.Trusted:
        return pkiRoot + "UA_Trusted";
      case ApplicationConfigurationBuilder.TrustlistType.Issuer:
        return pkiRoot + "UA_Issuer";
      case ApplicationConfigurationBuilder.TrustlistType.TrustedHttps:
        return pkiRoot + "UA_Trusted_Https";
      case ApplicationConfigurationBuilder.TrustlistType.IssuerHttps:
        return pkiRoot + "UA_Issuer_Https";
      case ApplicationConfigurationBuilder.TrustlistType.TrustedUser:
        return pkiRoot + "UA_Trusted_User";
      case ApplicationConfigurationBuilder.TrustlistType.IssuerUser:
        return pkiRoot + "UA_Issuer_User";
      case ApplicationConfigurationBuilder.TrustlistType.Rejected:
        return pkiRoot + "UA_Rejected";
      default:
        throw new NotSupportedException("Unsupported store type.");
    }
  }

  private void AddSecurityPolicies(bool includeSign = false, bool deprecated = false, bool policyNone = false)
  {
    string[] strArray = SecurityPolicies.GetDefaultUris();
    if (deprecated)
    {
      string[] displayNames = SecurityPolicies.GetDisplayNames();
      List<string> stringList = new List<string>();
      foreach (string displayName in displayNames)
      {
        string uri = SecurityPolicies.GetUri(displayName);
        if (uri != null)
          stringList.Add(uri);
      }
      strArray = stringList.ToArray();
    }
    foreach (MessageSecurityMode enumValue in typeof (MessageSecurityMode).GetEnumValues())
    {
      ServerSecurityPolicyCollection securityPolicies = this.ApplicationConfiguration.ServerConfiguration.SecurityPolicies;
      if (policyNone && enumValue == MessageSecurityMode.None)
        this.InternalAddPolicy(securityPolicies, MessageSecurityMode.None, "http://opcfoundation.org/UA/SecurityPolicy#None");
      else if (enumValue >= MessageSecurityMode.SignAndEncrypt || includeSign && enumValue == MessageSecurityMode.Sign)
      {
        foreach (string policyUri in strArray)
          this.InternalAddPolicy(securityPolicies, enumValue, policyUri);
      }
    }
  }

  private void SetSecureDefaults(SecurityConfiguration securityConfiguration)
  {
    securityConfiguration.AutoAcceptUntrustedCertificates = false;
    securityConfiguration.AddAppCertToTrustedStore = false;
    securityConfiguration.RejectSHA1SignedCertificates = true;
    securityConfiguration.RejectUnknownRevocationStatus = true;
    securityConfiguration.SuppressNonceValidationErrors = false;
    securityConfiguration.SendCertificateChain = true;
    securityConfiguration.MinimumCertificateKeySize = CertificateFactory.DefaultKeySize;
  }

  private bool InternalAddPolicy(
    ServerSecurityPolicyCollection policies,
    MessageSecurityMode securityMode,
    string policyUri)
  {
    ServerSecurityPolicy newPolicy = securityMode != MessageSecurityMode.Invalid ? new ServerSecurityPolicy()
    {
      SecurityMode = securityMode,
      SecurityPolicyUri = policyUri
    } : throw new ArgumentException("Invalid security mode selected", nameof (securityMode));
    if (policies.Find((Predicate<ServerSecurityPolicy>) (s => s.SecurityMode == newPolicy.SecurityMode && string.Equals(s.SecurityPolicyUri, newPolicy.SecurityPolicyUri, StringComparison.Ordinal))) != null)
      return false;
    policies.Add(newPolicy);
    return true;
  }

  private enum TrustlistType
  {
    Application,
    Trusted,
    Issuer,
    TrustedHttps,
    IssuerHttps,
    TrustedUser,
    IssuerUser,
    Rejected,
  }
}
