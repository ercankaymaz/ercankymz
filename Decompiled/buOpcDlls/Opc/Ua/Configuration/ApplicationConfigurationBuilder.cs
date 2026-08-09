using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Xml;

namespace Opc.Ua.Configuration;

[ComVisible(true)]
public class ApplicationConfigurationBuilder : IApplicationConfigurationBuilder, IApplicationConfigurationBuilderTypes, IApplicationConfigurationBuilderTransportQuotas, IApplicationConfigurationBuilderServer, IApplicationConfigurationBuilderClient, IApplicationConfigurationBuilderTransportQuotasSet, IApplicationConfigurationBuilderServerSelected, IApplicationConfigurationBuilderServerPolicies, IApplicationConfigurationBuilderServerOptions, IApplicationConfigurationBuilderSecurity, IApplicationConfigurationBuilderClientSelected, IApplicationConfigurationBuilderClientOptions, IApplicationConfigurationBuilderSecurityOptions, IApplicationConfigurationBuilderTraceConfiguration, IApplicationConfigurationBuilderCreate, IApplicationConfigurationBuilderExtension, IApplicationConfigurationBuilderSecurityOptionStores
{
	private enum TrustlistType
	{
		Application,
		Trusted,
		Issuer,
		TrustedHttps,
		IssuerHttps,
		TrustedUser,
		IssuerUser,
		Rejected
	}

	private bool m_typeSelected;

	public ApplicationInstance ApplicationInstance { get; private set; }

	public ApplicationConfiguration ApplicationConfiguration => ApplicationInstance.ApplicationConfiguration;

	public ApplicationConfigurationBuilder(ApplicationInstance applicationInstance)
	{
		ApplicationInstance = applicationInstance;
	}

	public IApplicationConfigurationBuilderClientSelected AsClient()
	{
		switch (ApplicationInstance.ApplicationType)
		{
		case ApplicationType.Server:
			ApplicationInstance.ApplicationType = ((!m_typeSelected) ? ApplicationType.Client : ApplicationType.ClientAndServer);
			break;
		default:
			throw new ArgumentException("Invalid application type for client.");
		case ApplicationType.Client:
		case ApplicationType.ClientAndServer:
			break;
		}
		m_typeSelected = true;
		ApplicationConfiguration.ClientConfiguration = new ClientConfiguration();
		return this;
	}

	public IApplicationConfigurationBuilderSecurityOptions AddSecurityConfiguration(string subjectName, string pkiRoot = null, string appRoot = null, string rejectedRoot = null)
	{
		pkiRoot = DefaultPKIRoot(pkiRoot);
		appRoot = ((appRoot == null) ? pkiRoot : DefaultPKIRoot(appRoot));
		rejectedRoot = ((rejectedRoot == null) ? pkiRoot : DefaultPKIRoot(rejectedRoot));
		string storeType = CertificateStoreIdentifier.DetermineStoreType(appRoot);
		string storeType2 = CertificateStoreIdentifier.DetermineStoreType(pkiRoot);
		string storeType3 = CertificateStoreIdentifier.DetermineStoreType(rejectedRoot);
		ApplicationConfiguration.SecurityConfiguration = new SecurityConfiguration
		{
			ApplicationCertificate = new CertificateIdentifier
			{
				StoreType = storeType,
				StorePath = DefaultCertificateStorePath(TrustlistType.Application, appRoot),
				SubjectName = Utils.ReplaceDCLocalhost(subjectName)
			},
			TrustedPeerCertificates = new CertificateTrustList
			{
				StoreType = storeType2,
				StorePath = DefaultCertificateStorePath(TrustlistType.Trusted, pkiRoot)
			},
			TrustedIssuerCertificates = new CertificateTrustList
			{
				StoreType = storeType2,
				StorePath = DefaultCertificateStorePath(TrustlistType.Issuer, pkiRoot)
			},
			TrustedHttpsCertificates = new CertificateTrustList
			{
				StoreType = storeType2,
				StorePath = DefaultCertificateStorePath(TrustlistType.TrustedHttps, pkiRoot)
			},
			HttpsIssuerCertificates = new CertificateTrustList
			{
				StoreType = storeType2,
				StorePath = DefaultCertificateStorePath(TrustlistType.IssuerHttps, pkiRoot)
			},
			TrustedUserCertificates = new CertificateTrustList
			{
				StoreType = storeType2,
				StorePath = DefaultCertificateStorePath(TrustlistType.TrustedUser, pkiRoot)
			},
			UserIssuerCertificates = new CertificateTrustList
			{
				StoreType = storeType2,
				StorePath = DefaultCertificateStorePath(TrustlistType.IssuerUser, pkiRoot)
			},
			RejectedCertificateStore = new CertificateTrustList
			{
				StoreType = storeType3,
				StorePath = DefaultCertificateStorePath(TrustlistType.Rejected, rejectedRoot)
			}
		};
		SetSecureDefaults(ApplicationConfiguration.SecurityConfiguration);
		return this;
	}

	public IApplicationConfigurationBuilderSecurityOptionStores AddSecurityConfigurationStores(string subjectName, string appRoot, string trustedRoot, string issuerRoot, string rejectedRoot = null)
	{
		string storeType = CertificateStoreIdentifier.DetermineStoreType(appRoot);
		string storeType2 = CertificateStoreIdentifier.DetermineStoreType(issuerRoot);
		string storeType3 = CertificateStoreIdentifier.DetermineStoreType(trustedRoot);
		rejectedRoot = rejectedRoot ?? DefaultPKIRoot(null);
		string storeType4 = CertificateStoreIdentifier.DetermineStoreType(rejectedRoot);
		ApplicationConfiguration.SecurityConfiguration = new SecurityConfiguration
		{
			ApplicationCertificate = new CertificateIdentifier
			{
				StoreType = storeType,
				StorePath = DefaultCertificateStorePath(TrustlistType.Application, appRoot),
				SubjectName = Utils.ReplaceDCLocalhost(subjectName)
			},
			TrustedPeerCertificates = new CertificateTrustList
			{
				StoreType = storeType3,
				StorePath = DefaultCertificateStorePath(TrustlistType.Trusted, trustedRoot)
			},
			TrustedIssuerCertificates = new CertificateTrustList
			{
				StoreType = storeType2,
				StorePath = DefaultCertificateStorePath(TrustlistType.Issuer, issuerRoot)
			},
			RejectedCertificateStore = new CertificateTrustList
			{
				StoreType = storeType4,
				StorePath = DefaultCertificateStorePath(TrustlistType.Rejected, rejectedRoot)
			}
		};
		SetSecureDefaults(ApplicationConfiguration.SecurityConfiguration);
		return this;
	}

	public IApplicationConfigurationBuilderSecurityOptionStores AddSecurityConfigurationUserStore(string trustedRoot, string issuerRoot)
	{
		string storeType = CertificateStoreIdentifier.DetermineStoreType(trustedRoot);
		string storeType2 = CertificateStoreIdentifier.DetermineStoreType(issuerRoot);
		ApplicationConfiguration.SecurityConfiguration.TrustedUserCertificates = new CertificateTrustList
		{
			StoreType = storeType,
			StorePath = DefaultCertificateStorePath(TrustlistType.TrustedUser, trustedRoot)
		};
		ApplicationConfiguration.SecurityConfiguration.UserIssuerCertificates = new CertificateTrustList
		{
			StoreType = storeType2,
			StorePath = DefaultCertificateStorePath(TrustlistType.IssuerUser, issuerRoot)
		};
		return this;
	}

	public IApplicationConfigurationBuilderSecurityOptionStores AddSecurityConfigurationHttpsStore(string trustedRoot, string issuerRoot)
	{
		string text = CertificateStoreIdentifier.DetermineStoreType(trustedRoot);
		string storeType = CertificateStoreIdentifier.DetermineStoreType(issuerRoot);
		ApplicationConfiguration.SecurityConfiguration.TrustedHttpsCertificates = new CertificateTrustList
		{
			StoreType = text,
			StorePath = DefaultCertificateStorePath(TrustlistType.TrustedHttps, text)
		};
		ApplicationConfiguration.SecurityConfiguration.HttpsIssuerCertificates = new CertificateTrustList
		{
			StoreType = storeType,
			StorePath = DefaultCertificateStorePath(TrustlistType.IssuerHttps, issuerRoot)
		};
		return this;
	}

	public async Task<ApplicationConfiguration> Create()
	{
		if ((ApplicationInstance.ApplicationType == ApplicationType.Server || ApplicationInstance.ApplicationType == ApplicationType.ClientAndServer) && ApplicationConfiguration.ServerConfiguration == null)
		{
			throw new ArgumentException("ApplicationType Server is not configured.");
		}
		if ((ApplicationInstance.ApplicationType == ApplicationType.Client || ApplicationInstance.ApplicationType == ApplicationType.ClientAndServer) && ApplicationConfiguration.ClientConfiguration == null)
		{
			throw new ArgumentException("ApplicationType Client is not configured.");
		}
		ServerConfiguration serverConfiguration = ApplicationConfiguration.ServerConfiguration;
		if (serverConfiguration != null && serverConfiguration.UserTokenPolicies.Count == 0)
		{
			ApplicationConfiguration.ServerConfiguration.UserTokenPolicies.Add(new UserTokenPolicy(UserTokenType.Anonymous));
		}
		ServerConfiguration serverConfiguration2 = ApplicationConfiguration.ServerConfiguration;
		if (serverConfiguration2 != null && serverConfiguration2.SecurityPolicies.Count == 0)
		{
			AddSecurityPolicies();
		}
		ApplicationConfiguration.TraceConfiguration?.ApplySettings();
		await ApplicationConfiguration.Validate(ApplicationInstance.ApplicationType).ConfigureAwait(continueOnCapturedContext: false);
		await ApplicationConfiguration.CertificateValidator.Update(ApplicationConfiguration.SecurityConfiguration).ConfigureAwait(continueOnCapturedContext: false);
		return ApplicationConfiguration;
	}

	public IApplicationConfigurationBuilderServerSelected AsServer(string[] baseAddresses, string[] alternateBaseAddresses = null)
	{
		switch (ApplicationInstance.ApplicationType)
		{
		case ApplicationType.Client:
			ApplicationInstance.ApplicationType = (m_typeSelected ? ApplicationType.ClientAndServer : ApplicationType.Server);
			break;
		default:
			throw new ArgumentException("Invalid application type for server.");
		case ApplicationType.Server:
		case ApplicationType.ClientAndServer:
			break;
		}
		m_typeSelected = true;
		ServerConfiguration serverConfiguration = new ServerConfiguration();
		serverConfiguration.MaxRegistrationInterval = 0;
		string[] array = baseAddresses;
		foreach (string uri in array)
		{
			serverConfiguration.BaseAddresses.Add(Utils.ReplaceLocalhost(uri));
		}
		if (alternateBaseAddresses != null)
		{
			array = alternateBaseAddresses;
			foreach (string uri2 in array)
			{
				serverConfiguration.AlternateBaseAddresses.Add(Utils.ReplaceLocalhost(uri2));
			}
		}
		serverConfiguration.SecurityPolicies = new ServerSecurityPolicyCollection();
		serverConfiguration.UserTokenPolicies = new UserTokenPolicyCollection();
		ApplicationConfiguration.ServerConfiguration = serverConfiguration;
		return this;
	}

	public IApplicationConfigurationBuilderServerSelected AddUnsecurePolicyNone(bool addPolicy = true)
	{
		if (addPolicy)
		{
			ServerSecurityPolicyCollection securityPolicies = ApplicationConfiguration.ServerConfiguration.SecurityPolicies;
			InternalAddPolicy(securityPolicies, MessageSecurityMode.None, "http://opcfoundation.org/UA/SecurityPolicy#None");
		}
		return this;
	}

	public IApplicationConfigurationBuilderServerSelected AddSignPolicies(bool addPolicies = true)
	{
		if (addPolicies)
		{
			AddSecurityPolicies(includeSign: true);
		}
		return this;
	}

	public IApplicationConfigurationBuilderServerSelected AddSignAndEncryptPolicies(bool addPolicies = true)
	{
		if (addPolicies)
		{
			AddSecurityPolicies();
		}
		return this;
	}

	public IApplicationConfigurationBuilderServerSelected AddPolicy(MessageSecurityMode securityMode, string securityPolicy)
	{
		if (SecurityPolicies.GetDisplayName(securityPolicy) == null)
		{
			throw new ArgumentException("Unknown security policy", "securityPolicy");
		}
		if (securityMode == MessageSecurityMode.None || securityPolicy.Equals("http://opcfoundation.org/UA/SecurityPolicy#None"))
		{
			throw new ArgumentException("Use AddUnsecurePolicyNone to add no security policy.");
		}
		InternalAddPolicy(ApplicationConfiguration.ServerConfiguration.SecurityPolicies, securityMode, securityPolicy);
		return this;
	}

	public IApplicationConfigurationBuilderServerSelected AddUserTokenPolicy(UserTokenType userTokenType)
	{
		ApplicationConfiguration.ServerConfiguration.UserTokenPolicies.Add(new UserTokenPolicy(userTokenType));
		return this;
	}

	public IApplicationConfigurationBuilderServerSelected AddUserTokenPolicy(UserTokenPolicy userTokenPolicy)
	{
		if (userTokenPolicy == null)
		{
			throw new ArgumentNullException("userTokenPolicy");
		}
		ApplicationConfiguration.ServerConfiguration.UserTokenPolicies.Add(userTokenPolicy);
		return this;
	}

	public IApplicationConfigurationBuilderSecurityOptions SetAutoAcceptUntrustedCertificates(bool autoAccept)
	{
		ApplicationConfiguration.SecurityConfiguration.AutoAcceptUntrustedCertificates = autoAccept;
		return this;
	}

	public IApplicationConfigurationBuilderSecurityOptions SetAddAppCertToTrustedStore(bool addToTrustedStore)
	{
		ApplicationConfiguration.SecurityConfiguration.AddAppCertToTrustedStore = addToTrustedStore;
		return this;
	}

	public IApplicationConfigurationBuilderSecurityOptions SetRejectSHA1SignedCertificates(bool rejectSHA1Signed)
	{
		ApplicationConfiguration.SecurityConfiguration.RejectSHA1SignedCertificates = rejectSHA1Signed;
		return this;
	}

	public IApplicationConfigurationBuilderSecurityOptions SetRejectUnknownRevocationStatus(bool rejectUnknownRevocationStatus)
	{
		ApplicationConfiguration.SecurityConfiguration.RejectUnknownRevocationStatus = rejectUnknownRevocationStatus;
		return this;
	}

	public IApplicationConfigurationBuilderSecurityOptions SetUseValidatedCertificates(bool useValidatedCertificates)
	{
		ApplicationConfiguration.SecurityConfiguration.UseValidatedCertificates = useValidatedCertificates;
		return this;
	}

	public IApplicationConfigurationBuilderSecurityOptions SetSuppressNonceValidationErrors(bool suppressNonceValidationErrors)
	{
		ApplicationConfiguration.SecurityConfiguration.SuppressNonceValidationErrors = suppressNonceValidationErrors;
		return this;
	}

	public IApplicationConfigurationBuilderSecurityOptions SetSendCertificateChain(bool sendCertificateChain)
	{
		ApplicationConfiguration.SecurityConfiguration.SendCertificateChain = sendCertificateChain;
		return this;
	}

	public IApplicationConfigurationBuilderSecurityOptions SetMinimumCertificateKeySize(ushort keySize)
	{
		ApplicationConfiguration.SecurityConfiguration.MinimumCertificateKeySize = keySize;
		return this;
	}

	public IApplicationConfigurationBuilderSecurityOptions AddCertificatePasswordProvider(ICertificatePasswordProvider certificatePasswordProvider)
	{
		ApplicationConfiguration.SecurityConfiguration.CertificatePasswordProvider = certificatePasswordProvider;
		return this;
	}

	public IApplicationConfigurationBuilderTransportQuotasSet SetTransportQuotas(TransportQuotas transportQuotas)
	{
		ApplicationConfiguration.TransportQuotas = transportQuotas;
		return this;
	}

	public IApplicationConfigurationBuilderTransportQuotas SetOperationTimeout(int operationTimeout)
	{
		ApplicationConfiguration.TransportQuotas.OperationTimeout = operationTimeout;
		return this;
	}

	public IApplicationConfigurationBuilderTransportQuotas SetMaxStringLength(int maxStringLength)
	{
		ApplicationConfiguration.TransportQuotas.MaxStringLength = maxStringLength;
		return this;
	}

	public IApplicationConfigurationBuilderTransportQuotas SetMaxByteStringLength(int maxByteStringLength)
	{
		ApplicationConfiguration.TransportQuotas.MaxByteStringLength = maxByteStringLength;
		return this;
	}

	public IApplicationConfigurationBuilderTransportQuotas SetMaxArrayLength(int maxArrayLength)
	{
		ApplicationConfiguration.TransportQuotas.MaxArrayLength = maxArrayLength;
		return this;
	}

	public IApplicationConfigurationBuilderTransportQuotas SetMaxMessageSize(int maxMessageSize)
	{
		ApplicationConfiguration.TransportQuotas.MaxMessageSize = maxMessageSize;
		return this;
	}

	public IApplicationConfigurationBuilderTransportQuotas SetMaxBufferSize(int maxBufferSize)
	{
		ApplicationConfiguration.TransportQuotas.MaxBufferSize = maxBufferSize;
		return this;
	}

	public IApplicationConfigurationBuilderTransportQuotas SetChannelLifetime(int channelLifetime)
	{
		ApplicationConfiguration.TransportQuotas.ChannelLifetime = channelLifetime;
		return this;
	}

	public IApplicationConfigurationBuilderTransportQuotas SetSecurityTokenLifetime(int securityTokenLifetime)
	{
		ApplicationConfiguration.TransportQuotas.SecurityTokenLifetime = securityTokenLifetime;
		return this;
	}

	public IApplicationConfigurationBuilderServerOptions SetMinRequestThreadCount(int minRequestThreadCount)
	{
		ApplicationConfiguration.ServerConfiguration.MinRequestThreadCount = minRequestThreadCount;
		return this;
	}

	public IApplicationConfigurationBuilderServerOptions SetMaxRequestThreadCount(int maxRequestThreadCount)
	{
		ApplicationConfiguration.ServerConfiguration.MaxRequestThreadCount = maxRequestThreadCount;
		return this;
	}

	public IApplicationConfigurationBuilderServerOptions SetMaxQueuedRequestCount(int maxQueuedRequestCount)
	{
		ApplicationConfiguration.ServerConfiguration.MaxQueuedRequestCount = maxQueuedRequestCount;
		return this;
	}

	public IApplicationConfigurationBuilderServerOptions SetDiagnosticsEnabled(bool diagnosticsEnabled)
	{
		ApplicationConfiguration.ServerConfiguration.DiagnosticsEnabled = diagnosticsEnabled;
		return this;
	}

	public IApplicationConfigurationBuilderServerOptions SetMaxSessionCount(int maxSessionCount)
	{
		ApplicationConfiguration.ServerConfiguration.MaxSessionCount = maxSessionCount;
		return this;
	}

	public IApplicationConfigurationBuilderServerOptions SetMinSessionTimeout(int minSessionTimeout)
	{
		ApplicationConfiguration.ServerConfiguration.MinSessionTimeout = minSessionTimeout;
		return this;
	}

	public IApplicationConfigurationBuilderServerOptions SetMaxSessionTimeout(int maxSessionTimeout)
	{
		ApplicationConfiguration.ServerConfiguration.MaxSessionTimeout = maxSessionTimeout;
		return this;
	}

	public IApplicationConfigurationBuilderServerOptions SetMaxBrowseContinuationPoints(int maxBrowseContinuationPoints)
	{
		ApplicationConfiguration.ServerConfiguration.MaxBrowseContinuationPoints = maxBrowseContinuationPoints;
		return this;
	}

	public IApplicationConfigurationBuilderServerOptions SetMaxQueryContinuationPoints(int maxQueryContinuationPoints)
	{
		ApplicationConfiguration.ServerConfiguration.MaxQueryContinuationPoints = maxQueryContinuationPoints;
		return this;
	}

	public IApplicationConfigurationBuilderServerOptions SetMaxHistoryContinuationPoints(int maxHistoryContinuationPoints)
	{
		ApplicationConfiguration.ServerConfiguration.MaxHistoryContinuationPoints = maxHistoryContinuationPoints;
		return this;
	}

	public IApplicationConfigurationBuilderServerOptions SetMaxRequestAge(int maxRequestAge)
	{
		ApplicationConfiguration.ServerConfiguration.MaxRequestAge = maxRequestAge;
		return this;
	}

	public IApplicationConfigurationBuilderServerOptions SetMinPublishingInterval(int minPublishingInterval)
	{
		ApplicationConfiguration.ServerConfiguration.MinPublishingInterval = minPublishingInterval;
		return this;
	}

	public IApplicationConfigurationBuilderServerOptions SetMaxPublishingInterval(int maxPublishingInterval)
	{
		ApplicationConfiguration.ServerConfiguration.MaxPublishingInterval = maxPublishingInterval;
		return this;
	}

	public IApplicationConfigurationBuilderServerOptions SetPublishingResolution(int publishingResolution)
	{
		ApplicationConfiguration.ServerConfiguration.PublishingResolution = publishingResolution;
		return this;
	}

	public IApplicationConfigurationBuilderServerOptions SetMaxSubscriptionLifetime(int maxSubscriptionLifetime)
	{
		ApplicationConfiguration.ServerConfiguration.MaxSubscriptionLifetime = maxSubscriptionLifetime;
		return this;
	}

	public IApplicationConfigurationBuilderServerOptions SetMaxMessageQueueSize(int maxMessageQueueSize)
	{
		ApplicationConfiguration.ServerConfiguration.MaxMessageQueueSize = maxMessageQueueSize;
		return this;
	}

	public IApplicationConfigurationBuilderServerOptions SetMaxNotificationQueueSize(int maxNotificationQueueSize)
	{
		ApplicationConfiguration.ServerConfiguration.MaxNotificationQueueSize = maxNotificationQueueSize;
		return this;
	}

	public IApplicationConfigurationBuilderServerOptions SetMaxNotificationsPerPublish(int maxNotificationsPerPublish)
	{
		ApplicationConfiguration.ServerConfiguration.MaxNotificationsPerPublish = maxNotificationsPerPublish;
		return this;
	}

	public IApplicationConfigurationBuilderServerOptions SetMinMetadataSamplingInterval(int minMetadataSamplingInterval)
	{
		ApplicationConfiguration.ServerConfiguration.MinMetadataSamplingInterval = minMetadataSamplingInterval;
		return this;
	}

	public IApplicationConfigurationBuilderServerOptions SetAvailableSamplingRates(SamplingRateGroupCollection availableSampleRates)
	{
		ApplicationConfiguration.ServerConfiguration.AvailableSamplingRates = availableSampleRates;
		return this;
	}

	public IApplicationConfigurationBuilderServerOptions SetRegistrationEndpoint(EndpointDescription registrationEndpoint)
	{
		ApplicationConfiguration.ServerConfiguration.RegistrationEndpoint = registrationEndpoint;
		return this;
	}

	public IApplicationConfigurationBuilderServerOptions SetMaxRegistrationInterval(int maxRegistrationInterval)
	{
		ApplicationConfiguration.ServerConfiguration.MaxRegistrationInterval = maxRegistrationInterval;
		return this;
	}

	public IApplicationConfigurationBuilderServerOptions SetNodeManagerSaveFile(string nodeManagerSaveFile)
	{
		ApplicationConfiguration.ServerConfiguration.NodeManagerSaveFile = nodeManagerSaveFile;
		return this;
	}

	public IApplicationConfigurationBuilderServerOptions SetMinSubscriptionLifetime(int minSubscriptionLifetime)
	{
		ApplicationConfiguration.ServerConfiguration.MinSubscriptionLifetime = minSubscriptionLifetime;
		return this;
	}

	public IApplicationConfigurationBuilderServerOptions SetMaxPublishRequestCount(int maxPublishRequestCount)
	{
		ApplicationConfiguration.ServerConfiguration.MaxPublishRequestCount = maxPublishRequestCount;
		return this;
	}

	public IApplicationConfigurationBuilderServerOptions SetMaxSubscriptionCount(int maxSubscriptionCount)
	{
		ApplicationConfiguration.ServerConfiguration.MaxSubscriptionCount = maxSubscriptionCount;
		return this;
	}

	public IApplicationConfigurationBuilderServerOptions SetMaxEventQueueSize(int setMaxEventQueueSize)
	{
		ApplicationConfiguration.ServerConfiguration.MaxEventQueueSize = setMaxEventQueueSize;
		return this;
	}

	public IApplicationConfigurationBuilderServerOptions AddServerProfile(string serverProfile)
	{
		ApplicationConfiguration.ServerConfiguration.ServerProfileArray.Add(serverProfile);
		return this;
	}

	public IApplicationConfigurationBuilderServerOptions SetShutdownDelay(int shutdownDelay)
	{
		ApplicationConfiguration.ServerConfiguration.ShutdownDelay = shutdownDelay;
		return this;
	}

	public IApplicationConfigurationBuilderServerOptions AddServerCapabilities(string serverCapability)
	{
		ApplicationConfiguration.ServerConfiguration.ServerCapabilities.Add(serverCapability);
		return this;
	}

	public IApplicationConfigurationBuilderServerOptions SetSupportedPrivateKeyFormats(StringCollection supportedPrivateKeyFormats)
	{
		ApplicationConfiguration.ServerConfiguration.SupportedPrivateKeyFormats = supportedPrivateKeyFormats;
		return this;
	}

	public IApplicationConfigurationBuilderServerOptions SetMaxTrustListSize(int maxTrustListSize)
	{
		ApplicationConfiguration.ServerConfiguration.MaxTrustListSize = maxTrustListSize;
		return this;
	}

	public IApplicationConfigurationBuilderServerOptions SetMultiCastDnsEnabled(bool multiCastDnsEnabled)
	{
		ApplicationConfiguration.ServerConfiguration.MultiCastDnsEnabled = multiCastDnsEnabled;
		return this;
	}

	public IApplicationConfigurationBuilderServerOptions SetReverseConnect(ReverseConnectServerConfiguration reverseConnectConfiguration)
	{
		ApplicationConfiguration.ServerConfiguration.ReverseConnect = reverseConnectConfiguration;
		return this;
	}

	public IApplicationConfigurationBuilderServerOptions SetOperationLimits(OperationLimits operationLimits)
	{
		ApplicationConfiguration.ServerConfiguration.OperationLimits = operationLimits;
		return this;
	}

	public IApplicationConfigurationBuilderServerOptions SetAuditingEnabled(bool auditingEnabled)
	{
		ApplicationConfiguration.ServerConfiguration.AuditingEnabled = auditingEnabled;
		return this;
	}

	public IApplicationConfigurationBuilderClientOptions SetDefaultSessionTimeout(int defaultSessionTimeout)
	{
		ApplicationConfiguration.ClientConfiguration.DefaultSessionTimeout = defaultSessionTimeout;
		return this;
	}

	public IApplicationConfigurationBuilderClientOptions AddWellKnownDiscoveryUrls(string wellKnownDiscoveryUrl)
	{
		ApplicationConfiguration.ClientConfiguration.WellKnownDiscoveryUrls.Add(wellKnownDiscoveryUrl);
		return this;
	}

	public IApplicationConfigurationBuilderClientOptions AddDiscoveryServer(EndpointDescription discoveryServer)
	{
		ApplicationConfiguration.ClientConfiguration.DiscoveryServers.Add(discoveryServer);
		return this;
	}

	public IApplicationConfigurationBuilderClientOptions SetEndpointCacheFilePath(string endpointCacheFilePath)
	{
		ApplicationConfiguration.ClientConfiguration.EndpointCacheFilePath = endpointCacheFilePath;
		return this;
	}

	IApplicationConfigurationBuilderClientOptions IApplicationConfigurationBuilderClientOptions.SetMinSubscriptionLifetime(int minSubscriptionLifetime)
	{
		ApplicationConfiguration.ClientConfiguration.MinSubscriptionLifetime = minSubscriptionLifetime;
		return this;
	}

	public IApplicationConfigurationBuilderClientOptions SetReverseConnect(ReverseConnectClientConfiguration reverseConnect)
	{
		ApplicationConfiguration.ClientConfiguration.ReverseConnect = reverseConnect;
		return this;
	}

	public IApplicationConfigurationBuilderClientOptions SetClientOperationLimits(OperationLimits operationLimits)
	{
		ApplicationConfiguration.ClientConfiguration.OperationLimits = operationLimits;
		return this;
	}

	public IApplicationConfigurationBuilderTraceConfiguration SetOutputFilePath(string outputFilePath)
	{
		ApplicationConfiguration.TraceConfiguration.OutputFilePath = outputFilePath;
		return this;
	}

	public IApplicationConfigurationBuilderTraceConfiguration SetDeleteOnLoad(bool deleteOnLoad)
	{
		ApplicationConfiguration.TraceConfiguration.DeleteOnLoad = deleteOnLoad;
		return this;
	}

	public IApplicationConfigurationBuilderTraceConfiguration SetTraceMasks(int traceMasks)
	{
		ApplicationConfiguration.TraceConfiguration.TraceMasks = traceMasks;
		return this;
	}

	public IApplicationConfigurationBuilderExtension AddExtension<T>(XmlQualifiedName elementName, object value)
	{
		ApplicationConfiguration.UpdateExtension<T>(elementName, value);
		return this;
	}

	private string DefaultPKIRoot(string root)
	{
		if (root == null || root.Equals("Directory", StringComparison.OrdinalIgnoreCase))
		{
			return CertificateStoreIdentifier.DefaultPKIRoot;
		}
		if (root.Equals("X509Store", StringComparison.OrdinalIgnoreCase))
		{
			return CertificateStoreIdentifier.CurrentUser;
		}
		return root;
	}

	private string DefaultCertificateStorePath(TrustlistType trustListType, string pkiRoot)
	{
		string text = CertificateStoreIdentifier.DetermineStoreType(pkiRoot);
		if (text.Equals("Directory", StringComparison.OrdinalIgnoreCase))
		{
			string text2 = "";
			switch (trustListType)
			{
			case TrustlistType.Application:
				text2 = "own";
				break;
			case TrustlistType.Trusted:
				text2 = "trusted";
				break;
			case TrustlistType.Issuer:
				text2 = "issuer";
				break;
			case TrustlistType.TrustedHttps:
				text2 = "trustedHttps";
				break;
			case TrustlistType.IssuerHttps:
				text2 = "issuerHttps";
				break;
			case TrustlistType.TrustedUser:
				text2 = "trustedUser";
				break;
			case TrustlistType.IssuerUser:
				text2 = "issuerUser";
				break;
			case TrustlistType.Rejected:
				text2 = "rejected";
				break;
			}
			int num = pkiRoot.Length - text2.Length;
			char c = pkiRoot.Last();
			if (c == Path.DirectorySeparatorChar || c == Path.AltDirectorySeparatorChar)
			{
				num--;
			}
			if (num > 0 && pkiRoot.Substring(num, text2.Length).Equals(text2, StringComparison.OrdinalIgnoreCase))
			{
				return pkiRoot;
			}
			return Path.Combine(pkiRoot, text2);
		}
		if (text.Equals("X509Store", StringComparison.OrdinalIgnoreCase))
		{
			return trustListType switch
			{
				TrustlistType.Application => pkiRoot + "UA_MachineDefault", 
				TrustlistType.Trusted => pkiRoot + "UA_Trusted", 
				TrustlistType.Issuer => pkiRoot + "UA_Issuer", 
				TrustlistType.TrustedHttps => pkiRoot + "UA_Trusted_Https", 
				TrustlistType.IssuerHttps => pkiRoot + "UA_Issuer_Https", 
				TrustlistType.TrustedUser => pkiRoot + "UA_Trusted_User", 
				TrustlistType.IssuerUser => pkiRoot + "UA_Issuer_User", 
				TrustlistType.Rejected => pkiRoot + "UA_Rejected", 
				_ => throw new NotSupportedException("Unsupported store type."), 
			};
		}
		return pkiRoot;
	}

	private void AddSecurityPolicies(bool includeSign = false, bool deprecated = false, bool policyNone = false)
	{
		string[] array = SecurityPolicies.GetDefaultUris();
		if (deprecated)
		{
			string[] displayNames = SecurityPolicies.GetDisplayNames();
			List<string> list = new List<string>();
			string[] array2 = displayNames;
			for (int i = 0; i < array2.Length; i++)
			{
				string uri = SecurityPolicies.GetUri(array2[i]);
				if (uri != null)
				{
					list.Add(uri);
				}
			}
			array = list.ToArray();
		}
		foreach (MessageSecurityMode enumValue in typeof(MessageSecurityMode).GetEnumValues())
		{
			ServerSecurityPolicyCollection securityPolicies = ApplicationConfiguration.ServerConfiguration.SecurityPolicies;
			if (policyNone && enumValue == MessageSecurityMode.None)
			{
				InternalAddPolicy(securityPolicies, MessageSecurityMode.None, "http://opcfoundation.org/UA/SecurityPolicy#None");
			}
			else if (enumValue >= MessageSecurityMode.SignAndEncrypt || (includeSign && enumValue == MessageSecurityMode.Sign))
			{
				string[] array2 = array;
				foreach (string policyUri in array2)
				{
					InternalAddPolicy(securityPolicies, enumValue, policyUri);
				}
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

	private bool InternalAddPolicy(ServerSecurityPolicyCollection policies, MessageSecurityMode securityMode, string policyUri)
	{
		if (securityMode == MessageSecurityMode.Invalid)
		{
			throw new ArgumentException("Invalid security mode selected", "securityMode");
		}
		ServerSecurityPolicy newPolicy = new ServerSecurityPolicy
		{
			SecurityMode = securityMode,
			SecurityPolicyUri = policyUri
		};
		if (policies.Find((ServerSecurityPolicy s) => s.SecurityMode == newPolicy.SecurityMode && string.Equals(s.SecurityPolicyUri, newPolicy.SecurityPolicyUri, StringComparison.Ordinal)) == null)
		{
			policies.Add(newPolicy);
			return true;
		}
		return false;
	}
}
