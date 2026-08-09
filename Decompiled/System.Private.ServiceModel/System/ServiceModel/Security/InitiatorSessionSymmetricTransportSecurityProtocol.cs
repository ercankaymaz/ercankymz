using System.Collections.Generic;
using System.IdentityModel.Selectors;
using System.IdentityModel.Tokens;
using System.ServiceModel.Channels;
using System.ServiceModel.Security.Tokens;
using System.Threading.Tasks;

namespace System.ServiceModel.Security;

internal class InitiatorSessionSymmetricTransportSecurityProtocol : TransportSecurityProtocol, IInitiatorSecuritySessionProtocol
{
	private SecurityToken _outgoingSessionToken;

	private List<SecurityToken> _incomingSessionTokens;

	private DerivedKeySecurityToken _derivedSignatureToken;

	private bool _requireDerivedKeys;

	private SessionSymmetricTransportSecurityProtocolFactory Factory => (SessionSymmetricTransportSecurityProtocolFactory)base.SecurityProtocolFactory;

	private object ThisLock { get; } = new object();

	public bool ReturnCorrelationState
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public InitiatorSessionSymmetricTransportSecurityProtocol(SessionSymmetricTransportSecurityProtocolFactory factory, EndpointAddress target, Uri via)
		: base(factory, target, via)
	{
		if (!factory.ActAsInitiator)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new NotSupportedException(System.SR.Format(System.SR.ProtocolMustBeInitiator, "InitiatorSessionSymmetricTransportSecurityProtocol")));
		}
		_requireDerivedKeys = factory.SecurityTokenParameters.RequireDerivedKeys;
	}

	public SecurityToken GetOutgoingSessionToken()
	{
		lock (ThisLock)
		{
			return _outgoingSessionToken;
		}
	}

	public void SetIdentityCheckAuthenticator(SecurityTokenAuthenticator authenticator)
	{
	}

	public void SetOutgoingSessionToken(SecurityToken token)
	{
		if (token == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("token");
		}
		lock (ThisLock)
		{
			_outgoingSessionToken = token;
			if (_requireDerivedKeys)
			{
				throw ExceptionHelper.PlatformNotSupported();
			}
		}
	}

	public List<SecurityToken> GetIncomingSessionTokens()
	{
		lock (ThisLock)
		{
			return _incomingSessionTokens;
		}
	}

	public void SetIncomingSessionTokens(List<SecurityToken> tokens)
	{
		if (tokens == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("tokens");
		}
		lock (ThisLock)
		{
			_incomingSessionTokens = new List<SecurityToken>(tokens);
		}
	}

	private void GetTokensForOutgoingMessages(out SecurityToken signingToken, out SecurityToken sourceToken, out SecurityTokenParameters tokenParameters)
	{
		lock (ThisLock)
		{
			if (_requireDerivedKeys)
			{
				signingToken = _derivedSignatureToken;
				sourceToken = _outgoingSessionToken;
			}
			else
			{
				signingToken = _outgoingSessionToken;
				sourceToken = null;
			}
		}
		tokenParameters = Factory.GetTokenParameters();
	}

	internal void SetupDelayedSecurityExecution(string actor, ref Message message, SecurityToken signingToken, SecurityToken sourceToken, SecurityTokenParameters tokenParameters, IList<SupportingTokenSpecification> supportingTokens)
	{
		SendSecurityHeader sendSecurityHeader = CreateSendSecurityHeaderForTransportProtocol(message, actor, Factory);
		sendSecurityHeader.RequireMessageProtection = false;
		if (sourceToken != null)
		{
			throw ExceptionHelper.PlatformNotSupported();
		}
		AddSupportingTokens(sendSecurityHeader, supportingTokens);
		sendSecurityHeader.AddEndorsingSupportingToken(signingToken, tokenParameters);
		message = sendSecurityHeader.SetupExecution();
	}

	protected override async Task<Message> SecureOutgoingMessageAtInitiatorAsync(Message message, string actor, TimeSpan timeout)
	{
		GetTokensForOutgoingMessages(out var signingToken, out var sourceToken, out var tokenParameters);
		IList<SupportingTokenSpecification> supportingTokens = await TryGetSupportingTokensAsync(base.SecurityProtocolFactory, base.Target, base.Via, message, timeout);
		SetupDelayedSecurityExecution(actor, ref message, signingToken, sourceToken, tokenParameters, supportingTokens);
		return message;
	}
}
