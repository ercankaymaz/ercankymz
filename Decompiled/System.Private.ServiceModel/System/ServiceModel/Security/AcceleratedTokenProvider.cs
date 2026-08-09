using System.Collections.ObjectModel;
using System.IdentityModel;
using System.IdentityModel.Policy;
using System.IdentityModel.Tokens;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Diagnostics;
using System.Threading.Tasks;
using System.Xml;

namespace System.ServiceModel.Security;

internal class AcceleratedTokenProvider : NegotiationTokenProvider<AcceleratedTokenProviderState>
{
	internal const SecurityKeyEntropyMode defaultKeyEntropyMode = SecurityKeyEntropyMode.CombinedEntropy;

	private SecurityKeyEntropyMode _keyEntropyMode = SecurityKeyEntropyMode.CombinedEntropy;

	private SecurityBindingElement _bootstrapSecurityBindingElement;

	private ChannelParameterCollection _channelParameters;

	public SecurityKeyEntropyMode KeyEntropyMode
	{
		get
		{
			return _keyEntropyMode;
		}
		set
		{
			base.CommunicationObject.ThrowIfDisposedOrImmutable();
			SecurityKeyEntropyModeHelper.Validate(value);
			_keyEntropyMode = value;
		}
	}

	public SecurityBindingElement BootstrapSecurityBindingElement
	{
		get
		{
			return _bootstrapSecurityBindingElement;
		}
		set
		{
			base.CommunicationObject.ThrowIfDisposedOrImmutable();
			if (value == null)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("value");
			}
			_bootstrapSecurityBindingElement = (SecurityBindingElement)value.Clone();
		}
	}

	public ChannelParameterCollection ChannelParameters
	{
		get
		{
			return _channelParameters;
		}
		set
		{
			base.CommunicationObject.ThrowIfDisposedOrImmutable();
			_channelParameters = value;
		}
	}

	protected override bool IsMultiLegNegotiation => false;

	public override XmlDictionaryString RequestSecurityTokenAction => base.StandardsManager.SecureConversationDriver.IssueAction;

	public override XmlDictionaryString RequestSecurityTokenResponseAction => base.StandardsManager.SecureConversationDriver.IssueResponseAction;

	public override Task OnOpenAsync(TimeSpan timeout)
	{
		if (BootstrapSecurityBindingElement == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.Format(System.SR.BootstrapSecurityBindingElementNotSet, GetType())));
		}
		return base.OnOpenAsync(timeout);
	}

	public override void OnOpening()
	{
		base.OnOpening();
		if (BootstrapSecurityBindingElement == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.Format(System.SR.BootstrapSecurityBindingElementNotSet, GetType())));
		}
	}

	public override Task OnCloseAsync(TimeSpan timeout)
	{
		return base.OnCloseAsync(timeout);
	}

	public override void OnAbort()
	{
		base.OnAbort();
	}

	protected override IChannelFactory<IAsyncRequestChannel> GetNegotiationChannelFactory(IChannelFactory<IAsyncRequestChannel> transportChannelFactory, ChannelBuilder channelBuilder)
	{
		ISecurityCapabilities property = _bootstrapSecurityBindingElement.GetProperty<ISecurityCapabilities>(base.IssuerBindingContext);
		SecurityCredentialsManager securityCredentialsManager = base.IssuerBindingContext.BindingParameters.Find<SecurityCredentialsManager>();
		if (securityCredentialsManager == null)
		{
			securityCredentialsManager = ClientCredentials.CreateDefaultCredentials();
		}
		_bootstrapSecurityBindingElement.ReaderQuotas = base.IssuerBindingContext.GetInnerProperty<XmlDictionaryReaderQuotas>();
		if (_bootstrapSecurityBindingElement.ReaderQuotas == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.EncodingBindingElementDoesNotHandleReaderQuotas));
		}
		TransportBindingElement transportBindingElement = base.IssuerBindingContext.RemainingBindingElements.Find<TransportBindingElement>();
		if (transportBindingElement != null)
		{
			_bootstrapSecurityBindingElement.MaxReceivedMessageSize = transportBindingElement.MaxReceivedMessageSize;
		}
		SecurityProtocolFactory protocolFactory = _bootstrapSecurityBindingElement.CreateSecurityProtocolFactory<IAsyncRequestChannel>(base.IssuerBindingContext.Clone(), securityCredentialsManager, isForService: false, base.IssuerBindingContext.Clone());
		return new SecurityChannelFactory<IAsyncRequestChannel>(property, base.IssuerBindingContext, channelBuilder, protocolFactory, transportChannelFactory);
	}

	protected override IAsyncRequestChannel CreateClientChannel(EndpointAddress target, Uri via)
	{
		IAsyncRequestChannel asyncRequestChannel = base.CreateClientChannel(target, via);
		if (_channelParameters != null)
		{
			_channelParameters.PropagateChannelParameters(asyncRequestChannel);
		}
		return asyncRequestChannel;
	}

	protected override Task<AcceleratedTokenProviderState> CreateNegotiationStateAsync(EndpointAddress target, Uri via, TimeSpan timeout)
	{
		byte[] array;
		if (_keyEntropyMode == SecurityKeyEntropyMode.ClientEntropy || _keyEntropyMode == SecurityKeyEntropyMode.CombinedEntropy)
		{
			array = new byte[base.SecurityAlgorithmSuite.DefaultSymmetricKeyLength / 8];
			CryptoHelper.FillRandomBytes(array);
		}
		else
		{
			array = null;
		}
		return Task.FromResult(new AcceleratedTokenProviderState(array));
	}

	protected override BodyWriter GetFirstOutgoingMessageBody(AcceleratedTokenProviderState negotiationState, out MessageProperties messageProperties)
	{
		messageProperties = null;
		RequestSecurityToken requestSecurityToken = new RequestSecurityToken(base.StandardsManager);
		requestSecurityToken.Context = negotiationState.Context;
		requestSecurityToken.KeySize = base.SecurityAlgorithmSuite.DefaultSymmetricKeyLength;
		requestSecurityToken.TokenType = base.SecurityContextTokenUri;
		byte[] requestorEntropy = negotiationState.GetRequestorEntropy();
		if (requestorEntropy != null)
		{
			requestSecurityToken.SetRequestorEntropy(requestorEntropy);
		}
		requestSecurityToken.MakeReadOnly();
		return requestSecurityToken;
	}

	protected override BodyWriter GetNextOutgoingMessageBody(Message incomingMessage, AcceleratedTokenProviderState negotiationState)
	{
		IssuanceTokenProviderBase<AcceleratedTokenProviderState>.ThrowIfFault(incomingMessage, base.TargetAddress);
		if (incomingMessage.Headers.Action != RequestSecurityTokenResponseAction.Value)
		{
			throw TraceUtility.ThrowHelperError(new SecurityNegotiationException(System.SR.Format(System.SR.InvalidActionForNegotiationMessage, incomingMessage.Headers.Action)), incomingMessage);
		}
		SecurityMessageProperty security = incomingMessage.Properties.Security;
		ReadOnlyCollection<IAuthorizationPolicy> authorizationPolicies = ((security == null || security.ServiceSecurityContext == null) ? EmptyReadOnlyCollection<IAuthorizationPolicy>.Instance : security.ServiceSecurityContext.AuthorizationPolicies);
		RequestSecurityTokenResponse requestSecurityTokenResponse = null;
		XmlDictionaryReader readerAtBodyContents = incomingMessage.GetReaderAtBodyContents();
		using (readerAtBodyContents)
		{
			if (base.StandardsManager.MessageSecurityVersion.TrustVersion == TrustVersion.WSTrustFeb2005)
			{
				requestSecurityTokenResponse = RequestSecurityTokenResponse.CreateFrom(base.StandardsManager, readerAtBodyContents);
			}
			else
			{
				if (base.StandardsManager.MessageSecurityVersion.TrustVersion != TrustVersion.WSTrust13)
				{
					throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new NotSupportedException());
				}
				RequestSecurityTokenResponseCollection requestSecurityTokenResponseCollection = base.StandardsManager.TrustDriver.CreateRequestSecurityTokenResponseCollection(readerAtBodyContents);
				foreach (RequestSecurityTokenResponse item in requestSecurityTokenResponseCollection.RstrCollection)
				{
					if (requestSecurityTokenResponse != null)
					{
						throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new MessageSecurityException(System.SR.MoreThanOneRSTRInRSTRC));
					}
					requestSecurityTokenResponse = item;
				}
			}
			incomingMessage.ReadFromBodyContentsToEnd(readerAtBodyContents);
		}
		if (requestSecurityTokenResponse.Context != negotiationState.Context)
		{
			throw TraceUtility.ThrowHelperError(new SecurityNegotiationException(System.SR.BadSecurityNegotiationContext), incomingMessage);
		}
		byte[] requestorEntropy = negotiationState.GetRequestorEntropy();
		GenericXmlSecurityToken issuedToken = requestSecurityTokenResponse.GetIssuedToken(null, null, _keyEntropyMode, requestorEntropy, base.SecurityContextTokenUri, authorizationPolicies, base.SecurityAlgorithmSuite.DefaultSymmetricKeyLength, isBearerKeyType: false);
		negotiationState.SetServiceToken(issuedToken);
		return null;
	}
}
