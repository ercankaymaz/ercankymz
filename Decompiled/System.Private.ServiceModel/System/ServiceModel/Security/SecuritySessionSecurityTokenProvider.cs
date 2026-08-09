using System.Collections.ObjectModel;
using System.IdentityModel;
using System.IdentityModel.Policy;
using System.IdentityModel.Tokens;
using System.Net;
using System.Runtime;
using System.Runtime.Diagnostics;
using System.Security.Authentication.ExtendedProtection;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Diagnostics;
using System.ServiceModel.Dispatcher;
using System.ServiceModel.Security.Tokens;
using System.Threading.Tasks;
using System.Xml;

namespace System.ServiceModel.Security;

internal class SecuritySessionSecurityTokenProvider : CommunicationObjectSecurityTokenProvider
{
	internal class RequestChannelFactory : ChannelFactoryBase<IAsyncRequestChannel>, IChannelFactory<IRequestChannel>, IChannelFactory, ICommunicationObject
	{
		private ServiceChannelFactory _serviceChannelFactory;

		public RequestChannelFactory(ServiceChannelFactory serviceChannelFactory)
		{
			_serviceChannelFactory = serviceChannelFactory;
		}

		protected override IAsyncRequestChannel OnCreateChannel(EndpointAddress address, Uri via)
		{
			return _serviceChannelFactory.CreateChannel<IAsyncRequestChannel>(address, via);
		}

		protected internal override Task OnOpenAsync(TimeSpan timeout)
		{
			return _serviceChannelFactory.OpenHelperAsync(timeout);
		}

		protected override IAsyncResult OnBeginOpen(TimeSpan timeout, AsyncCallback callback, object state)
		{
			return _serviceChannelFactory.BeginOpen(timeout, callback, state);
		}

		protected override void OnEndOpen(IAsyncResult result)
		{
			_serviceChannelFactory.EndOpen(result);
		}

		protected internal override async Task OnCloseAsync(TimeSpan timeout)
		{
			await base.OnCloseAsync(timeout);
			await _serviceChannelFactory.CloseHelperAsync(timeout);
		}

		protected override IAsyncResult OnBeginClose(TimeSpan timeout, AsyncCallback callback, object state)
		{
			return OnCloseAsync(timeout).ToApm(callback, state);
		}

		protected override void OnEndClose(IAsyncResult result)
		{
			result.ToApmEnd();
		}

		protected override void OnClose(TimeSpan timeout)
		{
			base.OnClose(timeout);
			_serviceChannelFactory.Close(timeout);
		}

		protected override void OnOpen(TimeSpan timeout)
		{
			_serviceChannelFactory.Open(timeout);
		}

		protected override void OnAbort()
		{
			_serviceChannelFactory.Abort();
			base.OnAbort();
		}

		public override T GetProperty<T>()
		{
			return _serviceChannelFactory.GetProperty<T>();
		}

		IRequestChannel IChannelFactory<IRequestChannel>.CreateChannel(EndpointAddress to)
		{
			return CreateChannel(to);
		}

		IRequestChannel IChannelFactory<IRequestChannel>.CreateChannel(EndpointAddress to, Uri via)
		{
			return CreateChannel(to, via);
		}
	}

	private static readonly MessageOperationFormatter s_operationFormatter = new MessageOperationFormatter();

	private BindingContext _issuerBindingContext;

	private SecurityChannelFactory<IAsyncRequestChannel> _rstChannelFactory;

	private SecurityAlgorithmSuite _securityAlgorithmSuite;

	private SecurityStandardsManager _standardsManager;

	private object _thisLock = new object();

	private SecurityKeyEntropyMode _keyEntropyMode;

	private SecurityTokenParameters _issuedTokenParameters;

	private bool _requiresManualReplyAddressing;

	private EndpointAddress _targetAddress;

	private SecurityBindingElement _bootstrapSecurityBindingElement;

	private Uri _via;

	private string _sctUri;

	private Uri _privacyNoticeUri;

	private int _privacyNoticeVersion;

	private EndpointAddress _localAddress;

	private ChannelParameterCollection _channelParameters;

	private WebHeaderCollection _webHeaderCollection;

	public WebHeaderCollection WebHeaders
	{
		get
		{
			return _webHeaderCollection;
		}
		set
		{
			base.CommunicationObject.ThrowIfDisposedOrImmutable();
			_webHeaderCollection = value;
		}
	}

	public SecurityAlgorithmSuite SecurityAlgorithmSuite
	{
		get
		{
			return _securityAlgorithmSuite;
		}
		set
		{
			base.CommunicationObject.ThrowIfDisposedOrImmutable();
			_securityAlgorithmSuite = value;
		}
	}

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

	private MessageVersion MessageVersion { get; set; }

	public EndpointAddress TargetAddress
	{
		get
		{
			return _targetAddress;
		}
		set
		{
			base.CommunicationObject.ThrowIfDisposedOrImmutable();
			_targetAddress = value;
		}
	}

	public EndpointAddress LocalAddress
	{
		get
		{
			return _localAddress;
		}
		set
		{
			base.CommunicationObject.ThrowIfDisposedOrImmutable();
			_localAddress = value;
		}
	}

	public Uri Via
	{
		get
		{
			return _via;
		}
		set
		{
			base.CommunicationObject.ThrowIfDisposedOrImmutable();
			_via = value;
		}
	}

	public BindingContext IssuerBindingContext
	{
		get
		{
			return _issuerBindingContext;
		}
		set
		{
			base.CommunicationObject.ThrowIfDisposedOrImmutable();
			if (value == null)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("value");
			}
			_issuerBindingContext = value.Clone();
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

	public SecurityStandardsManager StandardsManager
	{
		get
		{
			return _standardsManager;
		}
		set
		{
			base.CommunicationObject.ThrowIfDisposedOrImmutable();
			if (value == null)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentNullException("value"));
			}
			if (!value.TrustDriver.IsSessionSupported)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentException(System.SR.TrustDriverVersionDoesNotSupportSession, "value"));
			}
			if (!value.SecureConversationDriver.IsSessionSupported)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentException(System.SR.SecureConversationDriverVersionDoesNotSupportSession, "value"));
			}
			_standardsManager = value;
		}
	}

	public SecurityTokenParameters IssuedSecurityTokenParameters
	{
		get
		{
			return _issuedTokenParameters;
		}
		set
		{
			base.CommunicationObject.ThrowIfDisposedOrImmutable();
			_issuedTokenParameters = value;
		}
	}

	public Uri PrivacyNoticeUri
	{
		get
		{
			return _privacyNoticeUri;
		}
		set
		{
			base.CommunicationObject.ThrowIfDisposedOrImmutable();
			_privacyNoticeUri = value;
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

	public int PrivacyNoticeVersion
	{
		get
		{
			return _privacyNoticeVersion;
		}
		set
		{
			base.CommunicationObject.ThrowIfDisposedOrImmutable();
			_privacyNoticeVersion = value;
		}
	}

	public virtual XmlDictionaryString IssueAction => _standardsManager.SecureConversationDriver.IssueAction;

	public virtual XmlDictionaryString IssueResponseAction => _standardsManager.SecureConversationDriver.IssueResponseAction;

	public virtual XmlDictionaryString RenewAction => _standardsManager.SecureConversationDriver.RenewAction;

	public virtual XmlDictionaryString RenewResponseAction => _standardsManager.SecureConversationDriver.RenewResponseAction;

	public virtual XmlDictionaryString CloseAction => _standardsManager.SecureConversationDriver.CloseAction;

	public virtual XmlDictionaryString CloseResponseAction => _standardsManager.SecureConversationDriver.CloseResponseAction;

	public SecuritySessionSecurityTokenProvider()
	{
		_standardsManager = SecurityStandardsManager.DefaultInstance;
		_keyEntropyMode = SecurityKeyEntropyMode.CombinedEntropy;
	}

	public override void OnAbort()
	{
		if (_rstChannelFactory != null)
		{
			_rstChannelFactory.Abort();
			_rstChannelFactory = null;
		}
		FreeCredentialsHandle();
	}

	public override async Task OnOpenAsync(TimeSpan timeout)
	{
		TimeoutHelper timeoutHelper = new TimeoutHelper(timeout);
		if (_targetAddress == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.Format(System.SR.TargetAddressIsNotSet, GetType())));
		}
		if (IssuerBindingContext == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.Format(System.SR.IssuerBuildContextNotSet, GetType())));
		}
		if (IssuedSecurityTokenParameters == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.Format(System.SR.IssuedSecurityTokenParametersNotSet, GetType())));
		}
		if (BootstrapSecurityBindingElement == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.Format(System.SR.BootstrapSecurityBindingElementNotSet, GetType())));
		}
		if (SecurityAlgorithmSuite == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.Format(System.SR.SecurityAlgorithmSuiteNotSet, GetType())));
		}
		InitializeFactories();
		await _rstChannelFactory.OpenHelperAsync(timeoutHelper.RemainingTime());
		_sctUri = StandardsManager.SecureConversationDriver.TokenTypeUri;
	}

	public override void OnOpening()
	{
		base.OnOpening();
		if (IssuerBindingContext == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.Format(System.SR.IssuerBuildContextNotSet, GetType())));
		}
		if (BootstrapSecurityBindingElement == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.Format(System.SR.BootstrapSecurityBindingElementNotSet, GetType())));
		}
	}

	public override async Task OnCloseAsync(TimeSpan timeout)
	{
		TimeoutHelper timeoutHelper = new TimeoutHelper(timeout);
		if (_rstChannelFactory != null)
		{
			await _rstChannelFactory.CloseHelperAsync(timeoutHelper.RemainingTime());
			_rstChannelFactory = null;
		}
		FreeCredentialsHandle();
	}

	private void FreeCredentialsHandle()
	{
	}

	private void InitializeFactories()
	{
		ISecurityCapabilities property = BootstrapSecurityBindingElement.GetProperty<ISecurityCapabilities>(IssuerBindingContext);
		SecurityCredentialsManager securityCredentialsManager = IssuerBindingContext.BindingParameters.Find<SecurityCredentialsManager>();
		if (securityCredentialsManager == null)
		{
			securityCredentialsManager = ClientCredentials.CreateDefaultCredentials();
		}
		BindingContext issuerBindingContext = IssuerBindingContext;
		_bootstrapSecurityBindingElement.ReaderQuotas = issuerBindingContext.GetInnerProperty<XmlDictionaryReaderQuotas>();
		if (_bootstrapSecurityBindingElement.ReaderQuotas == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.EncodingBindingElementDoesNotHandleReaderQuotas));
		}
		TransportBindingElement transportBindingElement = issuerBindingContext.RemainingBindingElements.Find<TransportBindingElement>();
		if (transportBindingElement != null)
		{
			_bootstrapSecurityBindingElement.MaxReceivedMessageSize = transportBindingElement.MaxReceivedMessageSize;
		}
		SecurityProtocolFactory protocolFactory = BootstrapSecurityBindingElement.CreateSecurityProtocolFactory<IRequestChannel>(IssuerBindingContext.Clone(), securityCredentialsManager, isForService: false, IssuerBindingContext.Clone());
		if (_localAddress != null)
		{
			MessageFilter filter = new SessionActionFilter(_standardsManager, IssueResponseAction.Value, RenewResponseAction.Value);
			issuerBindingContext.BindingParameters.Add(new LocalAddressProvider(_localAddress, filter));
		}
		ChannelBuilder channelBuilder = new ChannelBuilder(issuerBindingContext, addChannelDemuxerIfRequired: true);
		IChannelFactory innerChannelFactory;
		if (channelBuilder.CanBuildChannelFactory<IRequestChannel>())
		{
			innerChannelFactory = channelBuilder.BuildChannelFactory<IRequestChannel>();
			_requiresManualReplyAddressing = true;
		}
		else
		{
			ClientRuntime clientRuntime = new ClientRuntime("RequestSecuritySession", "http://tempuri.org/");
			clientRuntime.UseSynchronizationContext = false;
			clientRuntime.AddTransactionFlowProperties = false;
			clientRuntime.ValidateMustUnderstand = false;
			ServiceChannelFactory serviceChannelFactory = ServiceChannelFactory.BuildChannelFactory(channelBuilder, clientRuntime);
			ClientOperation clientOperation = new ClientOperation(serviceChannelFactory.ClientRuntime, "Issue", IssueAction.Value);
			clientOperation.Formatter = s_operationFormatter;
			serviceChannelFactory.ClientRuntime.Operations.Add(clientOperation);
			ClientOperation clientOperation2 = new ClientOperation(serviceChannelFactory.ClientRuntime, "Renew", RenewAction.Value);
			clientOperation2.Formatter = s_operationFormatter;
			serviceChannelFactory.ClientRuntime.Operations.Add(clientOperation2);
			innerChannelFactory = new RequestChannelFactory(serviceChannelFactory);
			_requiresManualReplyAddressing = false;
		}
		SecurityChannelFactory<IAsyncRequestChannel> securityChannelFactory = new SecurityChannelFactory<IAsyncRequestChannel>(property, IssuerBindingContext, channelBuilder, protocolFactory, innerChannelFactory);
		if (transportBindingElement != null && securityChannelFactory.SecurityProtocolFactory != null)
		{
			securityChannelFactory.SecurityProtocolFactory.ExtendedProtectionPolicy = transportBindingElement.GetProperty<ExtendedProtectionPolicy>(issuerBindingContext);
		}
		_rstChannelFactory = securityChannelFactory;
		MessageVersion = securityChannelFactory.MessageVersion;
	}

	protected override SecurityToken GetTokenCore(TimeSpan timeout)
	{
		base.CommunicationObject.ThrowIfClosedOrNotOpen();
		return DoOperationAsync(SecuritySessionOperation.Issue, _targetAddress, _via, null, timeout).GetAwaiter().GetResult();
	}

	internal override Task<SecurityToken> GetTokenCoreInternalAsync(TimeSpan timeout)
	{
		base.CommunicationObject.ThrowIfClosedOrNotOpen();
		return DoOperationAsync(SecuritySessionOperation.Issue, _targetAddress, _via, null, timeout);
	}

	internal override Task<SecurityToken> RenewTokenCoreInternalAsync(TimeSpan timeout, SecurityToken tokenToBeRenewed)
	{
		base.CommunicationObject.ThrowIfClosedOrNotOpen();
		return DoOperationAsync(SecuritySessionOperation.Renew, _targetAddress, _via, tokenToBeRenewed, timeout);
	}

	private IAsyncRequestChannel CreateChannel(SecuritySessionOperation operation, EndpointAddress target, Uri via)
	{
		if (operation == SecuritySessionOperation.Issue || operation == SecuritySessionOperation.Renew)
		{
			IChannelFactory<IAsyncRequestChannel> rstChannelFactory = _rstChannelFactory;
			IAsyncRequestChannel asyncRequestChannel = ((!(via != null)) ? rstChannelFactory.CreateChannel(target) : rstChannelFactory.CreateChannel(target, via));
			if (_channelParameters != null)
			{
				_channelParameters.PropagateChannelParameters(asyncRequestChannel);
			}
			return asyncRequestChannel;
		}
		throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new NotSupportedException());
	}

	private Message CreateRequest(SecuritySessionOperation operation, EndpointAddress target, SecurityToken currentToken, out object requestState)
	{
		return operation switch
		{
			SecuritySessionOperation.Issue => CreateIssueRequest(target, out requestState), 
			SecuritySessionOperation.Renew => CreateRenewRequest(target, currentToken, out requestState), 
			_ => throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new NotSupportedException()), 
		};
	}

	private GenericXmlSecurityToken ProcessReply(Message reply, SecuritySessionOperation operation, object requestState)
	{
		ThrowIfFault(reply, _targetAddress);
		GenericXmlSecurityToken result = null;
		switch (operation)
		{
		case SecuritySessionOperation.Issue:
			result = ProcessIssueResponse(reply, requestState);
			break;
		case SecuritySessionOperation.Renew:
			result = ProcessRenewResponse(reply, requestState);
			break;
		}
		return result;
	}

	private void OnOperationSuccess(SecuritySessionOperation operation, EndpointAddress target, SecurityToken issuedToken, SecurityToken currentToken)
	{
	}

	private void OnOperationFailure(SecuritySessionOperation operation, EndpointAddress target, SecurityToken currentToken, Exception e, IChannel channel)
	{
		channel?.Abort();
	}

	private async Task<SecurityToken> DoOperationAsync(SecuritySessionOperation operation, EndpointAddress target, Uri via, SecurityToken currentToken, TimeSpan timeout)
	{
		if (target == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("target");
		}
		if (operation == SecuritySessionOperation.Renew && currentToken == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("currentToken");
		}
		IAsyncRequestChannel channel = null;
		try
		{
			channel = CreateChannel(operation, target, via);
			TimeoutHelper timeoutHelper = new TimeoutHelper(timeout);
			await channel.OpenAsync(timeoutHelper.RemainingTime());
			object requestState;
			GenericXmlSecurityToken issuedToken;
			using (Message requestMessage = CreateRequest(operation, target, currentToken, out requestState))
			{
				EventTraceActivity eventTraceActivity = null;
				TraceUtility.ProcessOutgoingMessage(requestMessage, eventTraceActivity);
				using Message message = await channel.RequestAsync(requestMessage, timeoutHelper.RemainingTime());
				if (message == null)
				{
					throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new CommunicationException(System.SR.FailToReceiveReplyFromNegotiation));
				}
				TraceUtility.ProcessIncomingMessage(message, eventTraceActivity);
				ThrowIfFault(message, _targetAddress);
				issuedToken = ProcessReply(message, operation, requestState);
				ValidateKeySize(issuedToken);
			}
			await channel.CloseAsync(timeoutHelper.RemainingTime());
			OnOperationSuccess(operation, target, issuedToken, currentToken);
			return issuedToken;
		}
		catch (Exception ex)
		{
			if (Fx.IsFatal(ex))
			{
				throw;
			}
			if (ex is TimeoutException)
			{
				ex = new TimeoutException(System.SR.Format(System.SR.ClientSecuritySessionRequestTimeout, timeout), ex);
			}
			OnOperationFailure(operation, target, currentToken, ex, channel);
			throw;
		}
	}

	private byte[] GenerateEntropy(int entropySize)
	{
		byte[] array = Fx.AllocateByteArray(entropySize / 8);
		CryptoHelper.FillRandomBytes(array);
		return array;
	}

	private RequestSecurityToken CreateRst(EndpointAddress target, out object requestState)
	{
		RequestSecurityToken requestSecurityToken = new RequestSecurityToken(_standardsManager);
		requestSecurityToken.KeySize = SecurityAlgorithmSuite.DefaultSymmetricKeyLength;
		requestSecurityToken.TokenType = _sctUri;
		if (KeyEntropyMode == SecurityKeyEntropyMode.ClientEntropy || KeyEntropyMode == SecurityKeyEntropyMode.CombinedEntropy)
		{
			byte[] array = GenerateEntropy(requestSecurityToken.KeySize);
			requestSecurityToken.SetRequestorEntropy(array);
			requestState = array;
		}
		else
		{
			requestState = null;
		}
		return requestSecurityToken;
	}

	private void PrepareRequest(Message message)
	{
		RequestReplyCorrelator.PrepareRequest(message);
		if (_requiresManualReplyAddressing)
		{
			if (_localAddress != null)
			{
				message.Headers.ReplyTo = LocalAddress;
			}
			else
			{
				message.Headers.ReplyTo = EndpointAddress.AnonymousAddress;
			}
		}
		if (_webHeaderCollection != null && _webHeaderCollection.Count > 0)
		{
			object value = null;
			HttpRequestMessageProperty httpRequestMessageProperty = null;
			if (message.Properties.TryGetValue(HttpRequestMessageProperty.Name, out value))
			{
				httpRequestMessageProperty = value as HttpRequestMessageProperty;
			}
			else
			{
				httpRequestMessageProperty = new HttpRequestMessageProperty();
				message.Properties.Add(HttpRequestMessageProperty.Name, httpRequestMessageProperty);
			}
			if (httpRequestMessageProperty != null && httpRequestMessageProperty.Headers != null)
			{
				httpRequestMessageProperty.Headers.Add(_webHeaderCollection);
			}
		}
	}

	protected virtual Message CreateIssueRequest(EndpointAddress target, out object requestState)
	{
		base.CommunicationObject.ThrowIfClosedOrNotOpen();
		RequestSecurityToken requestSecurityToken = CreateRst(target, out requestState);
		requestSecurityToken.RequestType = StandardsManager.TrustDriver.RequestTypeIssue;
		requestSecurityToken.MakeReadOnly();
		Message message = Message.CreateMessage(MessageVersion, ActionHeader.Create(IssueAction, MessageVersion.Addressing), requestSecurityToken);
		PrepareRequest(message);
		return message;
	}

	private GenericXmlSecurityToken ExtractToken(Message response, object requestState)
	{
		SecurityMessageProperty security = response.Properties.Security;
		ReadOnlyCollection<IAuthorizationPolicy> authorizationPolicies = ((security == null || security.ServiceSecurityContext == null) ? EmptyReadOnlyCollection<IAuthorizationPolicy>.Instance : security.ServiceSecurityContext.AuthorizationPolicies);
		RequestSecurityTokenResponse requestSecurityTokenResponse = null;
		XmlDictionaryReader readerAtBodyContents = response.GetReaderAtBodyContents();
		using (readerAtBodyContents)
		{
			if (StandardsManager.MessageSecurityVersion.TrustVersion == TrustVersion.WSTrustFeb2005)
			{
				requestSecurityTokenResponse = StandardsManager.TrustDriver.CreateRequestSecurityTokenResponse(readerAtBodyContents);
			}
			else
			{
				if (StandardsManager.MessageSecurityVersion.TrustVersion != TrustVersion.WSTrust13)
				{
					throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new NotSupportedException());
				}
				RequestSecurityTokenResponseCollection requestSecurityTokenResponseCollection = StandardsManager.TrustDriver.CreateRequestSecurityTokenResponseCollection(readerAtBodyContents);
				foreach (RequestSecurityTokenResponse item in requestSecurityTokenResponseCollection.RstrCollection)
				{
					if (requestSecurityTokenResponse != null)
					{
						throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new MessageSecurityException(System.SR.MoreThanOneRSTRInRSTRC));
					}
					requestSecurityTokenResponse = item;
				}
			}
			response.ReadFromBodyContentsToEnd(readerAtBodyContents);
		}
		return requestSecurityTokenResponse.GetIssuedToken(requestorEntropy: (requestState == null) ? null : ((byte[])requestState), resolver: null, allowedAuthenticators: null, keyEntropyMode: KeyEntropyMode, expectedTokenType: _sctUri, authorizationPolicies: authorizationPolicies, defaultKeySize: SecurityAlgorithmSuite.DefaultSymmetricKeyLength, isBearerKeyType: false);
	}

	protected virtual GenericXmlSecurityToken ProcessIssueResponse(Message response, object requestState)
	{
		base.CommunicationObject.ThrowIfClosedOrNotOpen();
		return ExtractToken(response, requestState);
	}

	protected virtual Message CreateRenewRequest(EndpointAddress target, SecurityToken currentSessionToken, out object requestState)
	{
		base.CommunicationObject.ThrowIfClosedOrNotOpen();
		RequestSecurityToken requestSecurityToken = CreateRst(target, out requestState);
		requestSecurityToken.RequestType = StandardsManager.TrustDriver.RequestTypeRenew;
		requestSecurityToken.RenewTarget = IssuedSecurityTokenParameters.CreateKeyIdentifierClause(currentSessionToken, SecurityTokenReferenceStyle.External);
		requestSecurityToken.MakeReadOnly();
		Message message = Message.CreateMessage(MessageVersion, ActionHeader.Create(RenewAction, MessageVersion.Addressing), requestSecurityToken);
		SecurityMessageProperty securityMessageProperty = new SecurityMessageProperty();
		securityMessageProperty.OutgoingSupportingTokens.Add(new SupportingTokenSpecification(currentSessionToken, EmptyReadOnlyCollection<IAuthorizationPolicy>.Instance, SecurityTokenAttachmentMode.Endorsing, IssuedSecurityTokenParameters));
		message.Properties.Security = securityMessageProperty;
		PrepareRequest(message);
		return message;
	}

	protected virtual GenericXmlSecurityToken ProcessRenewResponse(Message response, object requestState)
	{
		base.CommunicationObject.ThrowIfClosedOrNotOpen();
		if (response.Headers.Action != RenewResponseAction.Value)
		{
			throw TraceUtility.ThrowHelperError(new SecurityNegotiationException(System.SR.Format(System.SR.InvalidRenewResponseAction, response.Headers.Action)), response);
		}
		return ExtractToken(response, requestState);
	}

	protected static void ThrowIfFault(Message message, EndpointAddress target)
	{
		SecurityUtils.ThrowIfNegotiationFault(message, target);
	}

	protected void ValidateKeySize(GenericXmlSecurityToken issuedToken)
	{
		base.CommunicationObject.ThrowIfClosedOrNotOpen();
		ReadOnlyCollection<SecurityKey> securityKeys = issuedToken.SecurityKeys;
		if (securityKeys != null && securityKeys.Count == 1)
		{
			if (securityKeys[0] is SymmetricSecurityKey symmetricSecurityKey && !SecurityAlgorithmSuite.IsSymmetricKeyLengthSupported(symmetricSecurityKey.KeySize))
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new SecurityNegotiationException(System.SR.Format(System.SR.InvalidIssuedTokenKeySize, symmetricSecurityKey.KeySize)));
			}
			return;
		}
		throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new SecurityNegotiationException(System.SR.CannotObtainIssuedTokenKeySize));
	}
}
