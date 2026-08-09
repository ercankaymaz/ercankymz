using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.ServiceModel.Channels;
using System.ServiceModel.Security;

namespace System.ServiceModel;

public sealed class MessageSecurityOverTcp
{
	internal const MessageCredentialType DefaultClientCredentialType = MessageCredentialType.Windows;

	private MessageCredentialType _clientCredentialType;

	private SecurityAlgorithmSuite _algorithmSuite;

	[DefaultValue(MessageCredentialType.Windows)]
	public MessageCredentialType ClientCredentialType
	{
		get
		{
			if (_clientCredentialType == MessageCredentialType.IssuedToken || _clientCredentialType == MessageCredentialType.Windows)
			{
				throw ExceptionHelper.PlatformNotSupported($"MessageSecurityOverTcp.ClientCredentialType is not supported for value {_clientCredentialType}.");
			}
			return _clientCredentialType;
		}
		set
		{
			if (!MessageCredentialTypeHelper.IsDefined(value))
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentOutOfRangeException("value"));
			}
			if (value == MessageCredentialType.IssuedToken || value == MessageCredentialType.Windows)
			{
				throw ExceptionHelper.PlatformNotSupported($"MessageSecurityOverTcp.ClientCredentialType is not supported for value {value}.");
			}
			_clientCredentialType = value;
		}
	}

	[DefaultValue(typeof(SecurityAlgorithmSuite), "Default")]
	public SecurityAlgorithmSuite AlgorithmSuite
	{
		get
		{
			return _algorithmSuite;
		}
		set
		{
			_algorithmSuite = value ?? throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("value");
		}
	}

	public MessageSecurityOverTcp()
	{
		_clientCredentialType = MessageCredentialType.Windows;
		_algorithmSuite = SecurityAlgorithmSuite.Default;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal SecurityBindingElement CreateSecurityBindingElement(bool isSecureTransportMode, bool isReliableSession, BindingElement transportBindingElement)
	{
		if (!isSecureTransportMode)
		{
			throw ExceptionHelper.PlatformNotSupported();
		}
		SecurityBindingElement securityBindingElement = _clientCredentialType switch
		{
			MessageCredentialType.None => throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.ClientCredentialTypeMustBeSpecifiedForMixedMode)), 
			MessageCredentialType.UserName => SecurityBindingElement.CreateUserNameOverTransportBindingElement(), 
			MessageCredentialType.Certificate => SecurityBindingElement.CreateCertificateOverTransportBindingElement(), 
			MessageCredentialType.Windows => throw ExceptionHelper.PlatformNotSupported("MessageCredentialType.Windows"), 
			MessageCredentialType.IssuedToken => throw ExceptionHelper.PlatformNotSupported("MessageCredentialType.IssuedToken"), 
			_ => throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new NotSupportedException()), 
		};
		SecurityBindingElement securityBindingElement2 = SecurityBindingElement.CreateSecureConversationBindingElement(securityBindingElement);
		SecurityAlgorithmSuite defaultAlgorithmSuite = (securityBindingElement.DefaultAlgorithmSuite = AlgorithmSuite);
		securityBindingElement2.DefaultAlgorithmSuite = defaultAlgorithmSuite;
		securityBindingElement2.IncludeTimestamp = true;
		if (!isReliableSession)
		{
			securityBindingElement2.LocalClientSettings.ReconnectTransportOnFailure = false;
		}
		else
		{
			securityBindingElement2.LocalClientSettings.ReconnectTransportOnFailure = true;
		}
		securityBindingElement2.MessageSecurityVersion = MessageSecurityVersion.WSSecurity11WSTrustFebruary2005WSSecureConversationFebruary2005WSSecurityPolicy11;
		securityBindingElement.MessageSecurityVersion = MessageSecurityVersion.WSSecurity11WSTrustFebruary2005WSSecureConversationFebruary2005WSSecurityPolicy11;
		return securityBindingElement2;
	}
}
