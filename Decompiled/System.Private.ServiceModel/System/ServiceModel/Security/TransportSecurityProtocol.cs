using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IdentityModel.Policy;
using System.IdentityModel.Tokens;
using System.Runtime;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Diagnostics;
using System.Threading.Tasks;

namespace System.ServiceModel.Security;

internal class TransportSecurityProtocol : SecurityProtocol
{
	public TransportSecurityProtocol(TransportSecurityProtocolFactory factory, EndpointAddress target, Uri via)
		: base(factory, target, via)
	{
	}

	public override async Task<Message> SecureOutgoingMessageAsync(Message message, TimeSpan timeout)
	{
		if (message == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("message");
		}
		base.CommunicationObject.ThrowIfClosedOrNotOpen();
		string empty = string.Empty;
		try
		{
			if (!base.SecurityProtocolFactory.ActAsInitiator)
			{
				throw ExceptionHelper.PlatformNotSupported();
			}
			message = await SecureOutgoingMessageAtInitiatorAsync(message, empty, timeout);
			base.OnOutgoingMessageSecured(message);
		}
		catch
		{
			base.OnSecureOutgoingMessageFailure(message);
			throw;
		}
		return message;
	}

	protected virtual async Task<Message> SecureOutgoingMessageAtInitiatorAsync(Message message, string actor, TimeSpan timeout)
	{
		SetUpDelayedSecurityExecution(ref message, actor, await TryGetSupportingTokensAsync(base.SecurityProtocolFactory, base.Target, base.Via, message, timeout));
		return message;
	}

	internal void SetUpDelayedSecurityExecution(ref Message message, string actor, IList<SupportingTokenSpecification> supportingTokens)
	{
		SendSecurityHeader sendSecurityHeader = CreateSendSecurityHeaderForTransportProtocol(message, actor, base.SecurityProtocolFactory);
		AddSupportingTokens(sendSecurityHeader, supportingTokens);
		message = sendSecurityHeader.SetupExecution();
	}

	public sealed override void VerifyIncomingMessage(ref Message message, TimeSpan timeout)
	{
		if (message == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("message");
		}
		base.CommunicationObject.ThrowIfClosedOrNotOpen();
		try
		{
			VerifyIncomingMessageCore(ref message, timeout);
		}
		catch (MessageSecurityException exception)
		{
			base.OnVerifyIncomingMessageFailure(message, exception);
			throw;
		}
		catch (Exception ex)
		{
			if (Fx.IsFatal(ex))
			{
				throw;
			}
			base.OnVerifyIncomingMessageFailure(message, ex);
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new MessageSecurityException(System.SR.MessageSecurityVerificationFailed, ex));
		}
	}

	protected void AttachRecipientSecurityProperty(Message message, IList<SecurityToken> basicTokens, IList<SecurityToken> endorsingTokens, IList<SecurityToken> signedEndorsingTokens, IList<SecurityToken> signedTokens, Dictionary<SecurityToken, ReadOnlyCollection<IAuthorizationPolicy>> tokenPoliciesMapping)
	{
		SecurityMessageProperty orCreate = SecurityMessageProperty.GetOrCreate(message);
		AddSupportingTokenSpecification(orCreate, basicTokens, endorsingTokens, signedEndorsingTokens, signedTokens, tokenPoliciesMapping);
		orCreate.ServiceSecurityContext = new ServiceSecurityContext(orCreate.GetInitiatorTokenAuthorizationPolicies());
	}

	protected virtual void VerifyIncomingMessageCore(ref Message message, TimeSpan timeout)
	{
		TransportSecurityProtocolFactory transportSecurityProtocolFactory = (TransportSecurityProtocolFactory)base.SecurityProtocolFactory;
		string empty = string.Empty;
		ReceiveSecurityHeader receiveSecurityHeader = transportSecurityProtocolFactory.StandardsManager.TryCreateReceiveSecurityHeader(message, empty, transportSecurityProtocolFactory.IncomingAlgorithmSuite, transportSecurityProtocolFactory.ActAsInitiator ? MessageDirection.Output : MessageDirection.Input);
		bool expectSignedTokens;
		bool expectBasicTokens;
		bool expectEndorsingTokens;
		IList<SupportingTokenAuthenticatorSpecification> supportingTokenAuthenticators = transportSecurityProtocolFactory.GetSupportingTokenAuthenticators(message.Headers.Action, out expectSignedTokens, out expectBasicTokens, out expectEndorsingTokens);
		if (receiveSecurityHeader == null)
		{
			bool flag = expectEndorsingTokens || expectSignedTokens || expectBasicTokens;
			if ((!transportSecurityProtocolFactory.ActAsInitiator || (transportSecurityProtocolFactory.AddTimestamp && !transportSecurityProtocolFactory.SecurityBindingElement.EnableUnsecuredResponse)) && (transportSecurityProtocolFactory.ActAsInitiator || transportSecurityProtocolFactory.AddTimestamp || flag))
			{
				if (string.IsNullOrEmpty(empty))
				{
					throw TraceUtility.ThrowHelperError(new MessageSecurityException(System.SR.UnableToFindSecurityHeaderInMessageNoActor), message);
				}
				throw TraceUtility.ThrowHelperError(new MessageSecurityException(System.SR.Format(System.SR.UnableToFindSecurityHeaderInMessage, empty)), message);
			}
			return;
		}
		receiveSecurityHeader.RequireMessageProtection = false;
		receiveSecurityHeader.ExpectBasicTokens = expectBasicTokens;
		receiveSecurityHeader.ExpectSignedTokens = expectSignedTokens;
		receiveSecurityHeader.ExpectEndorsingTokens = expectEndorsingTokens;
		receiveSecurityHeader.MaxReceivedMessageSize = transportSecurityProtocolFactory.SecurityBindingElement.MaxReceivedMessageSize;
		receiveSecurityHeader.ReaderQuotas = transportSecurityProtocolFactory.SecurityBindingElement.ReaderQuotas;
		TimeoutHelper timeoutHelper = new TimeoutHelper(timeout);
		if (!transportSecurityProtocolFactory.ActAsInitiator)
		{
			throw ExceptionHelper.PlatformNotSupported();
		}
		receiveSecurityHeader.ReplayDetectionEnabled = transportSecurityProtocolFactory.DetectReplays;
		receiveSecurityHeader.SetTimeParameters(transportSecurityProtocolFactory.NonceCache, transportSecurityProtocolFactory.ReplayWindow, transportSecurityProtocolFactory.MaxClockSkew);
		receiveSecurityHeader.Process(timeoutHelper.RemainingTime(), SecurityUtils.GetChannelBindingFromMessage(message), transportSecurityProtocolFactory.ExtendedProtectionPolicy);
		message = receiveSecurityHeader.ProcessedMessage;
		if (!transportSecurityProtocolFactory.ActAsInitiator)
		{
			AttachRecipientSecurityProperty(message, receiveSecurityHeader.BasicSupportingTokens, receiveSecurityHeader.EndorsingSupportingTokens, receiveSecurityHeader.SignedEndorsingSupportingTokens, receiveSecurityHeader.SignedSupportingTokens, receiveSecurityHeader.SecurityTokenAuthorizationPoliciesMapping);
		}
		base.OnIncomingMessageVerified(message);
	}
}
