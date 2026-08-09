using System.ServiceModel.Channels;
using System.ServiceModel.Security;

namespace System.ServiceModel;

public class MessageSecurityOverHttp
{
	internal const MessageCredentialType DefaultClientCredentialType = MessageCredentialType.Windows;

	internal const bool DefaultNegotiateServiceCredential = true;

	private MessageCredentialType _clientCredentialType;

	private SecurityAlgorithmSuite _algorithmSuite;

	private bool _wasAlgorithmSuiteSet;

	public MessageCredentialType ClientCredentialType
	{
		get
		{
			return _clientCredentialType;
		}
		set
		{
			if (!MessageCredentialTypeHelper.IsDefined(value))
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentOutOfRangeException("value"));
			}
			_clientCredentialType = value;
		}
	}

	public bool NegotiateServiceCredential { get; set; }

	public SecurityAlgorithmSuite AlgorithmSuite
	{
		get
		{
			return _algorithmSuite;
		}
		set
		{
			_algorithmSuite = value ?? throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("value");
			_wasAlgorithmSuiteSet = true;
		}
	}

	public MessageSecurityOverHttp()
	{
		_clientCredentialType = MessageCredentialType.Windows;
		NegotiateServiceCredential = true;
		_algorithmSuite = SecurityAlgorithmSuite.Default;
	}

	protected virtual bool IsSecureConversationEnabled()
	{
		return true;
	}

	internal SecurityBindingElement CreateSecurityBindingElement(bool isSecureTransportMode, bool isReliableSession, MessageSecurityVersion version)
	{
		if (isReliableSession && !IsSecureConversationEnabled())
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.SecureConversationRequiredByReliableSession));
		}
		bool flag = false;
		if (!isSecureTransportMode)
		{
			throw ExceptionHelper.PlatformNotSupported();
		}
		SecurityBindingElement securityBindingElement = _clientCredentialType switch
		{
			MessageCredentialType.None => throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.ClientCredentialTypeMustBeSpecifiedForMixedMode)), 
			MessageCredentialType.UserName => SecurityBindingElement.CreateUserNameOverTransportBindingElement(), 
			MessageCredentialType.Certificate => SecurityBindingElement.CreateCertificateOverTransportBindingElement(), 
			MessageCredentialType.Windows => throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new NotSupportedException()), 
			MessageCredentialType.IssuedToken => throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new NotSupportedException()), 
			_ => throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new NotSupportedException()), 
		};
		SecurityBindingElement securityBindingElement2 = ((!IsSecureConversationEnabled()) ? securityBindingElement : SecurityBindingElement.CreateSecureConversationBindingElement(securityBindingElement, requireCancellation: true));
		if (_wasAlgorithmSuiteSet || !flag)
		{
			SecurityAlgorithmSuite defaultAlgorithmSuite = (securityBindingElement.DefaultAlgorithmSuite = AlgorithmSuite);
			securityBindingElement2.DefaultAlgorithmSuite = defaultAlgorithmSuite;
		}
		else if (flag)
		{
			throw ExceptionHelper.PlatformNotSupported();
		}
		securityBindingElement2.IncludeTimestamp = true;
		securityBindingElement.MessageSecurityVersion = version;
		securityBindingElement2.MessageSecurityVersion = version;
		if (!isReliableSession)
		{
			securityBindingElement2.LocalClientSettings.ReconnectTransportOnFailure = false;
		}
		else
		{
			securityBindingElement2.LocalClientSettings.ReconnectTransportOnFailure = true;
		}
		return securityBindingElement2;
	}
}
