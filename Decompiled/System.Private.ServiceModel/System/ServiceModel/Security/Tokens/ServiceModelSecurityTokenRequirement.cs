using System.Globalization;
using System.IdentityModel.Selectors;
using System.ServiceModel.Channels;
using System.Text;

namespace System.ServiceModel.Security.Tokens;

public abstract class ServiceModelSecurityTokenRequirement : SecurityTokenRequirement
{
	protected const string Namespace = "http://schemas.microsoft.com/ws/2006/05/servicemodel/securitytokenrequirement";

	private const string securityAlgorithmSuiteProperty = "http://schemas.microsoft.com/ws/2006/05/servicemodel/securitytokenrequirement/SecurityAlgorithmSuite";

	private const string securityBindingElementProperty = "http://schemas.microsoft.com/ws/2006/05/servicemodel/securitytokenrequirement/SecurityBindingElement";

	private const string issuerAddressProperty = "http://schemas.microsoft.com/ws/2006/05/servicemodel/securitytokenrequirement/IssuerAddress";

	private const string issuerBindingProperty = "http://schemas.microsoft.com/ws/2006/05/servicemodel/securitytokenrequirement/IssuerBinding";

	private const string secureConversationSecurityBindingElementProperty = "http://schemas.microsoft.com/ws/2006/05/servicemodel/securitytokenrequirement/SecureConversationSecurityBindingElement";

	private const string supportSecurityContextCancellationProperty = "http://schemas.microsoft.com/ws/2006/05/servicemodel/securitytokenrequirement/SupportSecurityContextCancellation";

	private const string messageSecurityVersionProperty = "http://schemas.microsoft.com/ws/2006/05/servicemodel/securitytokenrequirement/MessageSecurityVersion";

	private const string defaultMessageSecurityVersionProperty = "http://schemas.microsoft.com/ws/2006/05/servicemodel/securitytokenrequirement/DefaultMessageSecurityVersion";

	private const string issuerBindingContextProperty = "http://schemas.microsoft.com/ws/2006/05/servicemodel/securitytokenrequirement/IssuerBindingContext";

	private const string transportSchemeProperty = "http://schemas.microsoft.com/ws/2006/05/servicemodel/securitytokenrequirement/TransportScheme";

	private const string isInitiatorProperty = "http://schemas.microsoft.com/ws/2006/05/servicemodel/securitytokenrequirement/IsInitiator";

	private const string targetAddressProperty = "http://schemas.microsoft.com/ws/2006/05/servicemodel/securitytokenrequirement/TargetAddress";

	private const string viaProperty = "http://schemas.microsoft.com/ws/2006/05/servicemodel/securitytokenrequirement/Via";

	private const string listenUriProperty = "http://schemas.microsoft.com/ws/2006/05/servicemodel/securitytokenrequirement/ListenUri";

	private const string auditLogLocationProperty = "http://schemas.microsoft.com/ws/2006/05/servicemodel/securitytokenrequirement/AuditLogLocation";

	private const string suppressAuditFailureProperty = "http://schemas.microsoft.com/ws/2006/05/servicemodel/securitytokenrequirement/SuppressAuditFailure";

	private const string messageAuthenticationAuditLevelProperty = "http://schemas.microsoft.com/ws/2006/05/servicemodel/securitytokenrequirement/MessageAuthenticationAuditLevel";

	private const string isOutOfBandTokenProperty = "http://schemas.microsoft.com/ws/2006/05/servicemodel/securitytokenrequirement/IsOutOfBandToken";

	private const string preferSslCertificateAuthenticatorProperty = "http://schemas.microsoft.com/ws/2006/05/servicemodel/securitytokenrequirement/PreferSslCertificateAuthenticator";

	private const string supportingTokenAttachmentModeProperty = "http://schemas.microsoft.com/ws/2006/05/servicemodel/securitytokenrequirement/SupportingTokenAttachmentMode";

	private const string messageDirectionProperty = "http://schemas.microsoft.com/ws/2006/05/servicemodel/securitytokenrequirement/MessageDirection";

	private const string httpAuthenticationSchemeProperty = "http://schemas.microsoft.com/ws/2006/05/servicemodel/securitytokenrequirement/HttpAuthenticationScheme";

	private const string issuedSecurityTokenParametersProperty = "http://schemas.microsoft.com/ws/2006/05/servicemodel/securitytokenrequirement/IssuedSecurityTokenParameters";

	private const string privacyNoticeUriProperty = "http://schemas.microsoft.com/ws/2006/05/servicemodel/securitytokenrequirement/PrivacyNoticeUri";

	private const string privacyNoticeVersionProperty = "http://schemas.microsoft.com/ws/2006/05/servicemodel/securitytokenrequirement/PrivacyNoticeVersion";

	private const string duplexClientLocalAddressProperty = "http://schemas.microsoft.com/ws/2006/05/servicemodel/securitytokenrequirement/DuplexClientLocalAddress";

	private const string endpointFilterTableProperty = "http://schemas.microsoft.com/ws/2006/05/servicemodel/securitytokenrequirement/EndpointFilterTable";

	private const string channelParametersCollectionProperty = "http://schemas.microsoft.com/ws/2006/05/servicemodel/securitytokenrequirement/ChannelParametersCollection";

	private const string extendedProtectionPolicy = "http://schemas.microsoft.com/ws/2006/05/servicemodel/securitytokenrequirement/ExtendedProtectionPolicy";

	private const bool defaultSupportSecurityContextCancellation = false;

	public static string SecurityAlgorithmSuiteProperty => "http://schemas.microsoft.com/ws/2006/05/servicemodel/securitytokenrequirement/SecurityAlgorithmSuite";

	public static string SecurityBindingElementProperty => "http://schemas.microsoft.com/ws/2006/05/servicemodel/securitytokenrequirement/SecurityBindingElement";

	public static string IssuerAddressProperty => "http://schemas.microsoft.com/ws/2006/05/servicemodel/securitytokenrequirement/IssuerAddress";

	public static string IssuerBindingProperty => "http://schemas.microsoft.com/ws/2006/05/servicemodel/securitytokenrequirement/IssuerBinding";

	public static string SecureConversationSecurityBindingElementProperty => "http://schemas.microsoft.com/ws/2006/05/servicemodel/securitytokenrequirement/SecureConversationSecurityBindingElement";

	public static string SupportSecurityContextCancellationProperty => "http://schemas.microsoft.com/ws/2006/05/servicemodel/securitytokenrequirement/SupportSecurityContextCancellation";

	public static string MessageSecurityVersionProperty => "http://schemas.microsoft.com/ws/2006/05/servicemodel/securitytokenrequirement/MessageSecurityVersion";

	internal static string DefaultMessageSecurityVersionProperty => "http://schemas.microsoft.com/ws/2006/05/servicemodel/securitytokenrequirement/DefaultMessageSecurityVersion";

	public static string IssuerBindingContextProperty => "http://schemas.microsoft.com/ws/2006/05/servicemodel/securitytokenrequirement/IssuerBindingContext";

	public static string TransportSchemeProperty => "http://schemas.microsoft.com/ws/2006/05/servicemodel/securitytokenrequirement/TransportScheme";

	public static string IsInitiatorProperty => "http://schemas.microsoft.com/ws/2006/05/servicemodel/securitytokenrequirement/IsInitiator";

	public static string TargetAddressProperty => "http://schemas.microsoft.com/ws/2006/05/servicemodel/securitytokenrequirement/TargetAddress";

	public static string ViaProperty => "http://schemas.microsoft.com/ws/2006/05/servicemodel/securitytokenrequirement/Via";

	public static string ListenUriProperty => "http://schemas.microsoft.com/ws/2006/05/servicemodel/securitytokenrequirement/ListenUri";

	public static string AuditLogLocationProperty => "http://schemas.microsoft.com/ws/2006/05/servicemodel/securitytokenrequirement/AuditLogLocation";

	public static string SuppressAuditFailureProperty => "http://schemas.microsoft.com/ws/2006/05/servicemodel/securitytokenrequirement/SuppressAuditFailure";

	public static string MessageAuthenticationAuditLevelProperty => "http://schemas.microsoft.com/ws/2006/05/servicemodel/securitytokenrequirement/MessageAuthenticationAuditLevel";

	public static string IsOutOfBandTokenProperty => "http://schemas.microsoft.com/ws/2006/05/servicemodel/securitytokenrequirement/IsOutOfBandToken";

	public static string PreferSslCertificateAuthenticatorProperty => "http://schemas.microsoft.com/ws/2006/05/servicemodel/securitytokenrequirement/PreferSslCertificateAuthenticator";

	public static string SupportingTokenAttachmentModeProperty => "http://schemas.microsoft.com/ws/2006/05/servicemodel/securitytokenrequirement/SupportingTokenAttachmentMode";

	public static string MessageDirectionProperty => "http://schemas.microsoft.com/ws/2006/05/servicemodel/securitytokenrequirement/MessageDirection";

	public static string HttpAuthenticationSchemeProperty => "http://schemas.microsoft.com/ws/2006/05/servicemodel/securitytokenrequirement/HttpAuthenticationScheme";

	public static string IssuedSecurityTokenParametersProperty => "http://schemas.microsoft.com/ws/2006/05/servicemodel/securitytokenrequirement/IssuedSecurityTokenParameters";

	public static string PrivacyNoticeUriProperty => "http://schemas.microsoft.com/ws/2006/05/servicemodel/securitytokenrequirement/PrivacyNoticeUri";

	public static string PrivacyNoticeVersionProperty => "http://schemas.microsoft.com/ws/2006/05/servicemodel/securitytokenrequirement/PrivacyNoticeVersion";

	public static string DuplexClientLocalAddressProperty => "http://schemas.microsoft.com/ws/2006/05/servicemodel/securitytokenrequirement/DuplexClientLocalAddress";

	public static string EndpointFilterTableProperty => "http://schemas.microsoft.com/ws/2006/05/servicemodel/securitytokenrequirement/EndpointFilterTable";

	public static string ChannelParametersCollectionProperty => "http://schemas.microsoft.com/ws/2006/05/servicemodel/securitytokenrequirement/ChannelParametersCollection";

	public static string ExtendedProtectionPolicy => "http://schemas.microsoft.com/ws/2006/05/servicemodel/securitytokenrequirement/ExtendedProtectionPolicy";

	public bool IsInitiator => GetPropertyOrDefault(IsInitiatorProperty, defaultValue: false);

	public SecurityAlgorithmSuite SecurityAlgorithmSuite
	{
		get
		{
			return GetPropertyOrDefault<SecurityAlgorithmSuite>(SecurityAlgorithmSuiteProperty, null);
		}
		set
		{
			base.Properties[SecurityAlgorithmSuiteProperty] = value;
		}
	}

	public SecurityBindingElement SecurityBindingElement
	{
		get
		{
			return GetPropertyOrDefault<SecurityBindingElement>(SecurityBindingElementProperty, null);
		}
		set
		{
			base.Properties[SecurityBindingElementProperty] = value;
		}
	}

	public EndpointAddress IssuerAddress
	{
		get
		{
			return GetPropertyOrDefault<EndpointAddress>(IssuerAddressProperty, null);
		}
		set
		{
			base.Properties[IssuerAddressProperty] = value;
		}
	}

	public Binding IssuerBinding
	{
		get
		{
			return GetPropertyOrDefault<Binding>(IssuerBindingProperty, null);
		}
		set
		{
			base.Properties[IssuerBindingProperty] = value;
		}
	}

	public SecurityBindingElement SecureConversationSecurityBindingElement
	{
		get
		{
			return GetPropertyOrDefault<SecurityBindingElement>(SecureConversationSecurityBindingElementProperty, null);
		}
		set
		{
			base.Properties[SecureConversationSecurityBindingElementProperty] = value;
		}
	}

	public SecurityTokenVersion MessageSecurityVersion
	{
		get
		{
			return GetPropertyOrDefault<SecurityTokenVersion>(MessageSecurityVersionProperty, null);
		}
		set
		{
			base.Properties[MessageSecurityVersionProperty] = value;
		}
	}

	internal MessageSecurityVersion DefaultMessageSecurityVersion
	{
		get
		{
			if (!TryGetProperty<MessageSecurityVersion>(DefaultMessageSecurityVersionProperty, out var result))
			{
				return null;
			}
			return result;
		}
		set
		{
			base.Properties[DefaultMessageSecurityVersionProperty] = value;
		}
	}

	public string TransportScheme
	{
		get
		{
			return GetPropertyOrDefault<string>(TransportSchemeProperty, null);
		}
		set
		{
			base.Properties[TransportSchemeProperty] = value;
		}
	}

	internal bool SupportSecurityContextCancellation
	{
		get
		{
			return GetPropertyOrDefault(SupportSecurityContextCancellationProperty, defaultValue: false);
		}
		set
		{
			base.Properties[SupportSecurityContextCancellationProperty] = value;
		}
	}

	internal EndpointAddress DuplexClientLocalAddress
	{
		get
		{
			return GetPropertyOrDefault<EndpointAddress>("http://schemas.microsoft.com/ws/2006/05/servicemodel/securitytokenrequirement/DuplexClientLocalAddress", null);
		}
		set
		{
			base.Properties["http://schemas.microsoft.com/ws/2006/05/servicemodel/securitytokenrequirement/DuplexClientLocalAddress"] = value;
		}
	}

	protected ServiceModelSecurityTokenRequirement()
	{
		base.Properties[SupportSecurityContextCancellationProperty] = false;
	}

	internal TValue GetPropertyOrDefault<TValue>(string propertyName, TValue defaultValue)
	{
		if (!TryGetProperty<TValue>(propertyName, out var result))
		{
			return defaultValue;
		}
		return result;
	}

	internal string InternalToString()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendLine(string.Format(CultureInfo.InvariantCulture, "{0}:", GetType().ToString()));
		foreach (string key in base.Properties.Keys)
		{
			object arg = base.Properties[key];
			stringBuilder.AppendLine(string.Format(CultureInfo.InvariantCulture, "PropertyName: {0}", key));
			stringBuilder.AppendLine(string.Format(CultureInfo.InvariantCulture, "PropertyValue: {0}", arg));
			stringBuilder.AppendLine(string.Format(CultureInfo.InvariantCulture, "---"));
		}
		return stringBuilder.ToString().Trim();
	}
}
