using System.ServiceModel.Channels;
using System.ServiceModel.Security;

namespace System.ServiceModel;

public sealed class BasicHttpMessageSecurity
{
	internal const BasicHttpMessageCredentialType DefaultClientCredentialType = BasicHttpMessageCredentialType.UserName;

	private BasicHttpMessageCredentialType clientCredentialType;

	private SecurityAlgorithmSuite algorithmSuite;

	public BasicHttpMessageCredentialType ClientCredentialType
	{
		get
		{
			return clientCredentialType;
		}
		set
		{
			if (!BasicHttpMessageCredentialTypeHelper.IsDefined(value))
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentOutOfRangeException("value"));
			}
			clientCredentialType = value;
		}
	}

	public SecurityAlgorithmSuite AlgorithmSuite
	{
		get
		{
			return algorithmSuite;
		}
		set
		{
			if (value == null)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("value");
			}
			algorithmSuite = value;
		}
	}

	public BasicHttpMessageSecurity()
	{
		clientCredentialType = BasicHttpMessageCredentialType.UserName;
		algorithmSuite = SecurityAlgorithmSuite.Default;
	}

	internal SecurityBindingElement CreateMessageSecurity(bool isSecureTransportMode)
	{
		SecurityBindingElement securityBindingElement;
		if (isSecureTransportMode)
		{
			MessageSecurityVersion wSSecurity10WSTrustFebruary2005WSSecureConversationFebruary2005WSSecurityPolicy11BasicSecurityProfile = MessageSecurityVersion.WSSecurity10WSTrustFebruary2005WSSecureConversationFebruary2005WSSecurityPolicy11BasicSecurityProfile10;
			switch (clientCredentialType)
			{
			case BasicHttpMessageCredentialType.Certificate:
				securityBindingElement = SecurityBindingElement.CreateCertificateOverTransportBindingElement(wSSecurity10WSTrustFebruary2005WSSecureConversationFebruary2005WSSecurityPolicy11BasicSecurityProfile);
				break;
			case BasicHttpMessageCredentialType.UserName:
				securityBindingElement = SecurityBindingElement.CreateUserNameOverTransportBindingElement();
				securityBindingElement.MessageSecurityVersion = wSSecurity10WSTrustFebruary2005WSSecureConversationFebruary2005WSSecurityPolicy11BasicSecurityProfile;
				break;
			default:
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new NotSupportedException());
			}
		}
		else
		{
			if (clientCredentialType != BasicHttpMessageCredentialType.Certificate)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.BasicHttpMessageSecurityRequiresCertificate));
			}
			securityBindingElement = SecurityBindingElement.CreateMutualCertificateBindingElement(MessageSecurityVersion.WSSecurity10WSTrustFebruary2005WSSecureConversationFebruary2005WSSecurityPolicy11BasicSecurityProfile10, allowSerializedSigningTokenOnReply: true);
		}
		securityBindingElement.DefaultAlgorithmSuite = AlgorithmSuite;
		securityBindingElement.SecurityHeaderLayout = SecurityHeaderLayout.Lax;
		securityBindingElement.SetKeyDerivation(requireDerivedKeys: false);
		return securityBindingElement;
	}
}
