using System.Collections.Generic;
using System.Globalization;
using System.IdentityModel.Selectors;
using System.IdentityModel.Tokens;
using System.Net.Security;
using System.ServiceModel.Security;
using System.ServiceModel.Security.Tokens;
using System.Text;
using System.Xml;

namespace System.ServiceModel.Channels;

public abstract class SecurityBindingElement : BindingElement
{
	internal static readonly SecurityAlgorithmSuite defaultDefaultAlgorithmSuite = SecurityAlgorithmSuite.Default;

	internal const bool defaultIncludeTimestamp = true;

	internal const bool defaultAllowInsecureTransport = false;

	internal const bool defaultRequireSignatureConfirmation = false;

	internal const bool defaultEnableUnsecuredResponse = false;

	internal const bool defaultProtectTokens = false;

	private SecurityAlgorithmSuite _defaultAlgorithmSuite;

	private SecurityKeyEntropyMode _keyEntropyMode;

	private Dictionary<string, SupportingTokenParameters> _operationSupportingTokenParameters;

	private Dictionary<string, SupportingTokenParameters> _optionalOperationSupportingTokenParameters;

	private MessageSecurityVersion _messageSecurityVersion;

	private SecurityHeaderLayout _securityHeaderLayout;

	private bool _protectTokens;

	public SupportingTokenParameters EndpointSupportingTokenParameters { get; }

	public SupportingTokenParameters OptionalEndpointSupportingTokenParameters { get; }

	public IDictionary<string, SupportingTokenParameters> OperationSupportingTokenParameters => _operationSupportingTokenParameters;

	public IDictionary<string, SupportingTokenParameters> OptionalOperationSupportingTokenParameters => _optionalOperationSupportingTokenParameters;

	public SecurityHeaderLayout SecurityHeaderLayout
	{
		get
		{
			return _securityHeaderLayout;
		}
		set
		{
			if (!SecurityHeaderLayoutHelper.IsDefined(value))
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentOutOfRangeException("value"));
			}
			_securityHeaderLayout = value;
		}
	}

	public MessageSecurityVersion MessageSecurityVersion
	{
		get
		{
			return _messageSecurityVersion;
		}
		set
		{
			_messageSecurityVersion = value ?? throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentNullException("value"));
		}
	}

	public bool EnableUnsecuredResponse { get; set; }

	public bool IncludeTimestamp { get; set; }

	public SecurityAlgorithmSuite DefaultAlgorithmSuite
	{
		get
		{
			return _defaultAlgorithmSuite;
		}
		set
		{
			_defaultAlgorithmSuite = value ?? throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentNullException("value"));
		}
	}

	public LocalClientSecuritySettings LocalClientSettings { get; }

	public SecurityKeyEntropyMode KeyEntropyMode
	{
		get
		{
			return _keyEntropyMode;
		}
		set
		{
			if (!SecurityKeyEntropyModeHelper.IsDefined(value))
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentOutOfRangeException("value"));
			}
			_keyEntropyMode = value;
		}
	}

	internal virtual bool SessionMode => false;

	internal virtual bool SupportsDuplex => false;

	internal virtual bool SupportsRequestReply => false;

	internal long MaxReceivedMessageSize { get; set; } = 65536L;

	internal XmlDictionaryReaderQuotas ReaderQuotas { get; set; }

	internal SecurityBindingElement()
	{
		_messageSecurityVersion = MessageSecurityVersion.Default;
		_keyEntropyMode = SecurityKeyEntropyMode.CombinedEntropy;
		IncludeTimestamp = true;
		_defaultAlgorithmSuite = defaultDefaultAlgorithmSuite;
		LocalClientSettings = new LocalClientSecuritySettings();
		EndpointSupportingTokenParameters = new SupportingTokenParameters();
		OptionalEndpointSupportingTokenParameters = new SupportingTokenParameters();
		_operationSupportingTokenParameters = new Dictionary<string, SupportingTokenParameters>();
		_optionalOperationSupportingTokenParameters = new Dictionary<string, SupportingTokenParameters>();
		_securityHeaderLayout = SecurityHeaderLayout.Strict;
	}

	internal SecurityBindingElement(SecurityBindingElement elementToBeCloned)
		: base(elementToBeCloned)
	{
		if (elementToBeCloned == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("elementToBeCloned");
		}
		_defaultAlgorithmSuite = elementToBeCloned._defaultAlgorithmSuite;
		IncludeTimestamp = elementToBeCloned.IncludeTimestamp;
		_keyEntropyMode = elementToBeCloned._keyEntropyMode;
		_messageSecurityVersion = elementToBeCloned._messageSecurityVersion;
		_securityHeaderLayout = elementToBeCloned._securityHeaderLayout;
		EndpointSupportingTokenParameters = elementToBeCloned.EndpointSupportingTokenParameters.Clone();
		OptionalEndpointSupportingTokenParameters = elementToBeCloned.OptionalEndpointSupportingTokenParameters.Clone();
		_operationSupportingTokenParameters = new Dictionary<string, SupportingTokenParameters>();
		foreach (string key in elementToBeCloned._operationSupportingTokenParameters.Keys)
		{
			_operationSupportingTokenParameters[key] = elementToBeCloned._operationSupportingTokenParameters[key].Clone();
		}
		_optionalOperationSupportingTokenParameters = new Dictionary<string, SupportingTokenParameters>();
		foreach (string key2 in elementToBeCloned._optionalOperationSupportingTokenParameters.Keys)
		{
			_optionalOperationSupportingTokenParameters[key2] = elementToBeCloned._optionalOperationSupportingTokenParameters[key2].Clone();
		}
		LocalClientSettings = elementToBeCloned.LocalClientSettings.Clone();
		MaxReceivedMessageSize = elementToBeCloned.MaxReceivedMessageSize;
		ReaderQuotas = elementToBeCloned.ReaderQuotas;
		EnableUnsecuredResponse = elementToBeCloned.EnableUnsecuredResponse;
	}

	private void GetSupportingTokensCapabilities(ICollection<SecurityTokenParameters> parameters, out bool supportsClientAuth, out bool supportsWindowsIdentity)
	{
		supportsClientAuth = false;
		supportsWindowsIdentity = false;
		foreach (SecurityTokenParameters parameter in parameters)
		{
			if (parameter.SupportsClientAuthentication)
			{
				supportsClientAuth = true;
			}
			if (parameter.SupportsClientWindowsIdentity)
			{
				supportsWindowsIdentity = true;
			}
		}
	}

	private void GetSupportingTokensCapabilities(SupportingTokenParameters requirements, out bool supportsClientAuth, out bool supportsWindowsIdentity)
	{
		supportsClientAuth = false;
		supportsWindowsIdentity = false;
		GetSupportingTokensCapabilities(requirements.Endorsing, out var supportsClientAuth2, out var supportsWindowsIdentity2);
		supportsClientAuth |= supportsClientAuth2;
		supportsWindowsIdentity |= supportsWindowsIdentity2;
		GetSupportingTokensCapabilities(requirements.SignedEndorsing, out supportsClientAuth2, out supportsWindowsIdentity2);
		supportsClientAuth |= supportsClientAuth2;
		supportsWindowsIdentity |= supportsWindowsIdentity2;
		GetSupportingTokensCapabilities(requirements.SignedEncrypted, out supportsClientAuth2, out supportsWindowsIdentity2);
		supportsClientAuth |= supportsClientAuth2;
		supportsWindowsIdentity |= supportsWindowsIdentity2;
	}

	internal void GetSupportingTokensCapabilities(out bool supportsClientAuth, out bool supportsWindowsIdentity)
	{
		GetSupportingTokensCapabilities(EndpointSupportingTokenParameters, out supportsClientAuth, out supportsWindowsIdentity);
	}

	protected static void SetIssuerBindingContextIfRequired(SecurityTokenParameters parameters, BindingContext issuerBindingContext)
	{
	}

	private static void SetIssuerBindingContextIfRequired(SupportingTokenParameters supportingParameters, BindingContext issuerBindingContext)
	{
		for (int i = 0; i < supportingParameters.Endorsing.Count; i++)
		{
			SetIssuerBindingContextIfRequired(supportingParameters.Endorsing[i], issuerBindingContext);
		}
		for (int j = 0; j < supportingParameters.SignedEndorsing.Count; j++)
		{
			SetIssuerBindingContextIfRequired(supportingParameters.SignedEndorsing[j], issuerBindingContext);
		}
		for (int k = 0; k < supportingParameters.Signed.Count; k++)
		{
			SetIssuerBindingContextIfRequired(supportingParameters.Signed[k], issuerBindingContext);
		}
		for (int l = 0; l < supportingParameters.SignedEncrypted.Count; l++)
		{
			SetIssuerBindingContextIfRequired(supportingParameters.SignedEncrypted[l], issuerBindingContext);
		}
	}

	private void SetIssuerBindingContextIfRequired(BindingContext issuerBindingContext)
	{
		SetIssuerBindingContextIfRequired(EndpointSupportingTokenParameters, issuerBindingContext);
	}

	internal bool RequiresChannelDemuxer(SecurityTokenParameters parameters)
	{
		return parameters is SecureConversationSecurityTokenParameters;
	}

	internal virtual bool RequiresChannelDemuxer()
	{
		foreach (SecurityTokenParameters item in EndpointSupportingTokenParameters.Endorsing)
		{
			if (RequiresChannelDemuxer(item))
			{
				return true;
			}
		}
		foreach (SecurityTokenParameters item2 in EndpointSupportingTokenParameters.SignedEndorsing)
		{
			if (RequiresChannelDemuxer(item2))
			{
				return true;
			}
		}
		return false;
	}

	private void SetPrivacyNoticeUriIfRequired(SecurityProtocolFactory factory, Binding binding)
	{
	}

	internal void ConfigureProtocolFactory(SecurityProtocolFactory factory, SecurityCredentialsManager credentialsManager, bool isForService, BindingContext issuerBindingContext, Binding binding)
	{
		if (factory == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentNullException("factory"));
		}
		if (credentialsManager == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentNullException("credentialsManager"));
		}
		factory.AddTimestamp = IncludeTimestamp;
		factory.IncomingAlgorithmSuite = DefaultAlgorithmSuite;
		factory.OutgoingAlgorithmSuite = DefaultAlgorithmSuite;
		factory.SecurityHeaderLayout = SecurityHeaderLayout;
		if (!isForService)
		{
			factory.TimestampValidityDuration = LocalClientSettings.TimestampValidityDuration;
			factory.DetectReplays = LocalClientSettings.DetectReplays;
			factory.MaxCachedNonces = LocalClientSettings.ReplayCacheSize;
			factory.MaxClockSkew = LocalClientSettings.MaxClockSkew;
			factory.ReplayWindow = LocalClientSettings.ReplayWindow;
			if (LocalClientSettings.DetectReplays)
			{
				factory.NonceCache = LocalClientSettings.NonceCache;
			}
			factory.SecurityBindingElement = (SecurityBindingElement)Clone();
			factory.SecurityBindingElement.SetIssuerBindingContextIfRequired(issuerBindingContext);
			factory.SecurityTokenManager = credentialsManager.CreateSecurityTokenManager();
			SecurityTokenSerializer tokenSerializer = factory.SecurityTokenManager.CreateSecurityTokenSerializer(_messageSecurityVersion.SecurityTokenVersion);
			factory.StandardsManager = new SecurityStandardsManager(_messageSecurityVersion, tokenSerializer);
			if (!isForService)
			{
				SetPrivacyNoticeUriIfRequired(factory, binding);
			}
			return;
		}
		throw ExceptionHelper.PlatformNotSupported();
	}

	internal abstract SecurityProtocolFactory CreateSecurityProtocolFactory<TChannel>(BindingContext context, SecurityCredentialsManager credentialsManager, bool isForService, BindingContext issuanceBindingContext);

	public override IChannelFactory<TChannel> BuildChannelFactory<TChannel>(BindingContext context)
	{
		if (context == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("context");
		}
		if (!CanBuildChannelFactory<TChannel>(context))
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentException(System.SR.Format(System.SR.ChannelTypeNotSupported, typeof(TChannel)), "TChannel"));
		}
		ReaderQuotas = context.GetInnerProperty<XmlDictionaryReaderQuotas>();
		if (ReaderQuotas == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.EncodingBindingElementDoesNotHandleReaderQuotas));
		}
		TransportBindingElement transportBindingElement = null;
		if (context.RemainingBindingElements != null)
		{
			transportBindingElement = context.RemainingBindingElements.Find<TransportBindingElement>();
		}
		if (transportBindingElement != null)
		{
			MaxReceivedMessageSize = transportBindingElement.MaxReceivedMessageSize;
		}
		return BuildChannelFactoryCore<TChannel>(context);
	}

	protected abstract IChannelFactory<TChannel> BuildChannelFactoryCore<TChannel>(BindingContext context);

	public override bool CanBuildChannelFactory<TChannel>(BindingContext context)
	{
		if (context == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("context");
		}
		if (SessionMode)
		{
			return CanBuildSessionChannelFactory<TChannel>(context);
		}
		if (!context.CanBuildInnerChannelFactory<TChannel>())
		{
			return false;
		}
		if (!(typeof(TChannel) == typeof(IOutputChannel)) && !(typeof(TChannel) == typeof(IOutputSessionChannel)) && (!SupportsDuplex || (!(typeof(TChannel) == typeof(IDuplexChannel)) && !(typeof(TChannel) == typeof(IDuplexSessionChannel)))))
		{
			if (SupportsRequestReply)
			{
				if (!(typeof(TChannel) == typeof(IRequestChannel)))
				{
					return typeof(TChannel) == typeof(IRequestSessionChannel);
				}
				return true;
			}
			return false;
		}
		return true;
	}

	private bool CanBuildSessionChannelFactory<TChannel>(BindingContext context)
	{
		if (!context.CanBuildInnerChannelFactory<IRequestChannel>() && !context.CanBuildInnerChannelFactory<IRequestSessionChannel>() && !context.CanBuildInnerChannelFactory<IDuplexChannel>() && !context.CanBuildInnerChannelFactory<IDuplexSessionChannel>())
		{
			return false;
		}
		if (typeof(TChannel) == typeof(IRequestSessionChannel))
		{
			if (!context.CanBuildInnerChannelFactory<IRequestChannel>())
			{
				return context.CanBuildInnerChannelFactory<IRequestSessionChannel>();
			}
			return true;
		}
		if (typeof(TChannel) == typeof(IDuplexSessionChannel))
		{
			if (!context.CanBuildInnerChannelFactory<IDuplexChannel>())
			{
				return context.CanBuildInnerChannelFactory<IDuplexSessionChannel>();
			}
			return true;
		}
		return false;
	}

	public virtual void SetKeyDerivation(bool requireDerivedKeys)
	{
		EndpointSupportingTokenParameters.SetKeyDerivation(requireDerivedKeys);
	}

	internal virtual bool IsSetKeyDerivation(bool requireDerivedKeys)
	{
		if (!EndpointSupportingTokenParameters.IsSetKeyDerivation(requireDerivedKeys))
		{
			return false;
		}
		return true;
	}

	public override T GetProperty<T>(BindingContext context)
	{
		if (context == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("context");
		}
		if (typeof(T) == typeof(ISecurityCapabilities))
		{
			return (T)GetSecurityCapabilities(context);
		}
		if (typeof(T) == typeof(IdentityVerifier))
		{
			return (T)(object)LocalClientSettings.IdentityVerifier;
		}
		return context.GetInnerProperty<T>();
	}

	internal abstract ISecurityCapabilities GetIndividualISecurityCapabilities();

	private ISecurityCapabilities GetSecurityCapabilities(BindingContext context)
	{
		ISecurityCapabilities individualISecurityCapabilities = GetIndividualISecurityCapabilities();
		ISecurityCapabilities innerProperty = context.GetInnerProperty<ISecurityCapabilities>();
		if (innerProperty == null)
		{
			return individualISecurityCapabilities;
		}
		bool supportsClientAuthentication = individualISecurityCapabilities.SupportsClientAuthentication;
		bool supportsClientWindowsIdentity = individualISecurityCapabilities.SupportsClientWindowsIdentity;
		bool supportsServerAuth = individualISecurityCapabilities.SupportsServerAuthentication || innerProperty.SupportsServerAuthentication;
		ProtectionLevel requestProtectionLevel = ProtectionLevelHelper.Max(individualISecurityCapabilities.SupportedRequestProtectionLevel, innerProperty.SupportedRequestProtectionLevel);
		ProtectionLevel responseProtectionLevel = ProtectionLevelHelper.Max(individualISecurityCapabilities.SupportedResponseProtectionLevel, innerProperty.SupportedResponseProtectionLevel);
		return new SecurityCapabilities(supportsClientAuthentication, supportsServerAuth, supportsClientWindowsIdentity, requestProtectionLevel, responseProtectionLevel);
	}

	internal void ApplyPropertiesOnDemuxer(ChannelBuilder builder, BindingContext context)
	{
	}

	public static SecurityBindingElement CreateMutualCertificateBindingElement()
	{
		return CreateMutualCertificateBindingElement(MessageSecurityVersion.WSSecurity11WSTrustFebruary2005WSSecureConversationFebruary2005WSSecurityPolicy11);
	}

	public static SecurityBindingElement CreateMutualCertificateBindingElement(MessageSecurityVersion version)
	{
		return CreateMutualCertificateBindingElement(version, allowSerializedSigningTokenOnReply: false);
	}

	public static SecurityBindingElement CreateMutualCertificateBindingElement(MessageSecurityVersion version, bool allowSerializedSigningTokenOnReply)
	{
		if (version == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("version");
		}
		throw ExceptionHelper.PlatformNotSupported("SecurityBindingElement.CreateMutualCertificateBindingElement is not supported.");
	}

	public static TransportSecurityBindingElement CreateUserNameOverTransportBindingElement()
	{
		TransportSecurityBindingElement transportSecurityBindingElement = new TransportSecurityBindingElement();
		transportSecurityBindingElement.EndpointSupportingTokenParameters.SignedEncrypted.Add(new UserNameSecurityTokenParameters());
		transportSecurityBindingElement.IncludeTimestamp = true;
		transportSecurityBindingElement.LocalClientSettings.DetectReplays = false;
		return transportSecurityBindingElement;
	}

	public static TransportSecurityBindingElement CreateCertificateOverTransportBindingElement()
	{
		return CreateCertificateOverTransportBindingElement(MessageSecurityVersion.Default);
	}

	public static TransportSecurityBindingElement CreateCertificateOverTransportBindingElement(MessageSecurityVersion version)
	{
		if (version == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("version");
		}
		X509KeyIdentifierClauseType x509ReferenceStyle = ((version.SecurityVersion != SecurityVersion.WSSecurity10) ? X509KeyIdentifierClauseType.Thumbprint : X509KeyIdentifierClauseType.Any);
		TransportSecurityBindingElement transportSecurityBindingElement = new TransportSecurityBindingElement();
		X509SecurityTokenParameters item = new X509SecurityTokenParameters(x509ReferenceStyle, SecurityTokenInclusionMode.AlwaysToRecipient, requireDerivedKeys: false);
		transportSecurityBindingElement.EndpointSupportingTokenParameters.Endorsing.Add(item);
		transportSecurityBindingElement.IncludeTimestamp = true;
		transportSecurityBindingElement.LocalClientSettings.DetectReplays = false;
		transportSecurityBindingElement.MessageSecurityVersion = version;
		return transportSecurityBindingElement;
	}

	public static TransportSecurityBindingElement CreateIssuedTokenOverTransportBindingElement(IssuedSecurityTokenParameters issuedTokenParameters)
	{
		if (issuedTokenParameters == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("issuedTokenParameters");
		}
		issuedTokenParameters.RequireDerivedKeys = false;
		TransportSecurityBindingElement transportSecurityBindingElement = new TransportSecurityBindingElement();
		if (issuedTokenParameters.KeyType == SecurityKeyType.BearerKey)
		{
			transportSecurityBindingElement.EndpointSupportingTokenParameters.Signed.Add(issuedTokenParameters);
			transportSecurityBindingElement.MessageSecurityVersion = MessageSecurityVersion.WSSXDefault;
		}
		else
		{
			transportSecurityBindingElement.EndpointSupportingTokenParameters.Endorsing.Add(issuedTokenParameters);
			transportSecurityBindingElement.MessageSecurityVersion = MessageSecurityVersion.Default;
		}
		transportSecurityBindingElement.LocalClientSettings.DetectReplays = false;
		transportSecurityBindingElement.IncludeTimestamp = true;
		return transportSecurityBindingElement;
	}

	public static SecurityBindingElement CreateSecureConversationBindingElement(SecurityBindingElement bootstrapSecurity)
	{
		return CreateSecureConversationBindingElement(bootstrapSecurity, requireCancellation: true, null);
	}

	public static SecurityBindingElement CreateSecureConversationBindingElement(SecurityBindingElement bootstrapSecurity, bool requireCancellation)
	{
		return CreateSecureConversationBindingElement(bootstrapSecurity, requireCancellation, null);
	}

	public static SecurityBindingElement CreateSecureConversationBindingElement(SecurityBindingElement bootstrapSecurity, bool requireCancellation, ChannelProtectionRequirements bootstrapProtectionRequirements)
	{
		if (bootstrapSecurity == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("bootstrapSecurity");
		}
		if (bootstrapSecurity is TransportSecurityBindingElement)
		{
			TransportSecurityBindingElement transportSecurityBindingElement = new TransportSecurityBindingElement();
			SecureConversationSecurityTokenParameters secureConversationSecurityTokenParameters = new SecureConversationSecurityTokenParameters(bootstrapSecurity, requireCancellation, bootstrapProtectionRequirements);
			secureConversationSecurityTokenParameters.RequireDerivedKeys = false;
			transportSecurityBindingElement.EndpointSupportingTokenParameters.Endorsing.Add(secureConversationSecurityTokenParameters);
			transportSecurityBindingElement.LocalClientSettings.DetectReplays = false;
			transportSecurityBindingElement.IncludeTimestamp = true;
			return transportSecurityBindingElement;
		}
		throw ExceptionHelper.PlatformNotSupported();
	}

	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendLine(string.Format(CultureInfo.InvariantCulture, "{0}:", GetType().ToString()));
		stringBuilder.AppendLine(string.Format(CultureInfo.InvariantCulture, "DefaultAlgorithmSuite: {0}", _defaultAlgorithmSuite.ToString()));
		stringBuilder.AppendLine(string.Format(CultureInfo.InvariantCulture, "IncludeTimestamp: {0}", IncludeTimestamp.ToString()));
		stringBuilder.AppendLine(string.Format(CultureInfo.InvariantCulture, "KeyEntropyMode: {0}", _keyEntropyMode.ToString()));
		stringBuilder.AppendLine(string.Format(CultureInfo.InvariantCulture, "MessageSecurityVersion: {0}", MessageSecurityVersion.ToString()));
		stringBuilder.AppendLine(string.Format(CultureInfo.InvariantCulture, "SecurityHeaderLayout: {0}", _securityHeaderLayout.ToString()));
		stringBuilder.AppendLine(string.Format(CultureInfo.InvariantCulture, "ProtectTokens: {0}", _protectTokens.ToString()));
		stringBuilder.AppendLine("EndpointSupportingTokenParameters:");
		stringBuilder.AppendLine("  " + EndpointSupportingTokenParameters.ToString().Trim().Replace("\n", "\n  "));
		stringBuilder.AppendLine("OptionalEndpointSupportingTokenParameters:");
		stringBuilder.AppendLine("  " + OptionalEndpointSupportingTokenParameters.ToString().Trim().Replace("\n", "\n  "));
		if (_operationSupportingTokenParameters.Count == 0)
		{
			stringBuilder.AppendLine(string.Format(CultureInfo.InvariantCulture, "OperationSupportingTokenParameters: none"));
		}
		else
		{
			foreach (string key in OperationSupportingTokenParameters.Keys)
			{
				stringBuilder.AppendLine(string.Format(CultureInfo.InvariantCulture, "OperationSupportingTokenParameters[\"{0}\"]:", key));
				stringBuilder.AppendLine("  " + OperationSupportingTokenParameters[key].ToString().Trim().Replace("\n", "\n  "));
			}
		}
		if (_optionalOperationSupportingTokenParameters.Count == 0)
		{
			stringBuilder.AppendLine(string.Format(CultureInfo.InvariantCulture, "OptionalOperationSupportingTokenParameters: none"));
		}
		else
		{
			foreach (string key2 in OptionalOperationSupportingTokenParameters.Keys)
			{
				stringBuilder.AppendLine(string.Format(CultureInfo.InvariantCulture, "OptionalOperationSupportingTokenParameters[\"{0}\"]:", key2));
				stringBuilder.AppendLine("  " + OptionalOperationSupportingTokenParameters[key2].ToString().Trim().Replace("\n", "\n  "));
			}
		}
		return stringBuilder.ToString().Trim();
	}
}
