using System.Collections.Generic;
using System.Globalization;
using System.IdentityModel.Claims;
using System.IdentityModel.Selectors;
using System.IdentityModel.Tokens;
using System.Net;
using System.Runtime;
using System.ServiceModel.Channels;
using System.ServiceModel.Diagnostics;
using System.ServiceModel.Security.Tokens;
using System.Threading.Tasks;
using System.Xml;

namespace System.ServiceModel.Security;

internal static class SecuritySessionClientSettings
{
	internal const string defaultKeyRenewalIntervalString = "10:00:00";

	internal const string defaultKeyRolloverIntervalString = "00:05:00";

	internal static readonly TimeSpan defaultKeyRenewalInterval = TimeSpan.Parse("10:00:00", CultureInfo.InvariantCulture);

	internal static readonly TimeSpan defaultKeyRolloverInterval = TimeSpan.Parse("00:05:00", CultureInfo.InvariantCulture);

	internal const bool defaultTolerateTransportFailures = true;
}
internal sealed class SecuritySessionClientSettings<TChannel> : IChannelSecureConversationSessionSettings, ISecurityCommunicationObject
{
	private abstract class ClientSecuritySessionChannel : ChannelBase
	{
		protected class SoapSecurityOutputSession : ISecureConversationSession, ISecuritySession, ISession, IOutputSession
		{
			private ClientSecuritySessionChannel _channel;

			private UniqueId _sessionId;

			private SecurityKeyIdentifierClause _sessionTokenIdentifier;

			private SecurityStandardsManager _standardsManager;

			public string Id
			{
				get
				{
					if (_sessionId == null)
					{
						throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.ChannelMustBeOpenedToGetSessionId));
					}
					return _sessionId.ToString();
				}
			}

			public EndpointIdentity RemoteIdentity { get; private set; }

			public SoapSecurityOutputSession(ClientSecuritySessionChannel channel)
			{
				_channel = channel;
			}

			internal void Initialize(SecurityToken sessionToken, SecuritySessionClientSettings<TChannel> settings)
			{
				if (sessionToken == null)
				{
					throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("sessionToken");
				}
				if (settings == null)
				{
					throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("settings");
				}
				Claim primaryIdentityClaim = SecurityUtils.GetPrimaryIdentityClaim(((GenericXmlSecurityToken)sessionToken).AuthorizationPolicies);
				if (primaryIdentityClaim != null)
				{
					RemoteIdentity = EndpointIdentity.CreateIdentity(primaryIdentityClaim);
				}
				_standardsManager = settings.SessionProtocolFactory.StandardsManager;
				_sessionId = GetSessionId(sessionToken, _standardsManager);
				_sessionTokenIdentifier = settings.IssuedSecurityTokenParameters.CreateKeyIdentifierClause(sessionToken, SecurityTokenReferenceStyle.External);
			}

			private UniqueId GetSessionId(SecurityToken sessionToken, SecurityStandardsManager standardsManager)
			{
				if (!(sessionToken is GenericXmlSecurityToken genericXmlSecurityToken))
				{
					throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new NotSupportedException(System.SR.Format(System.SR.SessionTokenIsNotGenericXmlToken, sessionToken, typeof(GenericXmlSecurityToken))));
				}
				return standardsManager.SecureConversationDriver.GetSecurityContextTokenId(XmlDictionaryReader.CreateDictionaryReader(new XmlNodeReader(genericXmlSecurityToken.TokenXml)));
			}

			public void WriteSessionTokenIdentifier(XmlDictionaryWriter writer)
			{
				_channel.ThrowIfDisposedOrNotOpen();
				_standardsManager.SecurityTokenSerializer.WriteKeyIdentifierClause(writer, _sessionTokenIdentifier);
			}

			public bool TryReadSessionTokenIdentifier(XmlReader reader)
			{
				_channel.ThrowIfDisposedOrNotOpen();
				if (!_standardsManager.SecurityTokenSerializer.CanReadKeyIdentifierClause(reader))
				{
					return false;
				}
				if (_standardsManager.SecurityTokenSerializer.ReadKeyIdentifierClause(reader) is SecurityContextKeyIdentifierClause securityContextKeyIdentifierClause)
				{
					return securityContextKeyIdentifierClause.Matches(_sessionId, null);
				}
				return false;
			}
		}

		private ChannelParameterCollection _channelParameters;

		private SecurityToken _currentSessionToken;

		private SecurityToken _previousSessionToken;

		private DateTime _keyRenewalTime;

		private DateTime _keyRolloverTime;

		private SecurityProtocol _securityProtocol;

		private SecurityTokenProvider _sessionTokenProvider;

		private bool _isKeyRenewalOngoing;

		private InterruptibleWaitObject _keyRenewalCompletedEvent;

		private bool _sentClose;

		private bool _receivedClose;

		private volatile bool _isOutputClosed;

		private volatile bool _isInputClosed;

		private InterruptibleWaitObject _inputSessionClosedHandle = new InterruptibleWaitObject(signaled: false);

		private bool _isCompositeDuplexConnection;

		private Message _closeResponse;

		private InterruptibleWaitObject _outputSessionCloseHandle = new InterruptibleWaitObject(signaled: true);

		private WebHeaderCollection _webHeaderCollection;

		protected SecuritySessionClientSettings<TChannel> Settings { get; }

		protected IClientReliableChannelBinder ChannelBinder { get; private set; }

		public EndpointAddress RemoteAddress { get; }

		public Uri Via { get; }

		protected bool SendCloseHandshake { get; private set; }

		protected EndpointAddress InternalLocalAddress
		{
			get
			{
				if (ChannelBinder != null)
				{
					return ChannelBinder.LocalAddress;
				}
				return null;
			}
		}

		protected virtual bool CanDoSecurityCorrelation => false;

		public MessageVersion MessageVersion { get; }

		protected bool IsInputClosed => _isInputClosed;

		protected bool IsOutputClosed => _isOutputClosed;

		protected abstract bool ExpectClose { get; }

		protected abstract string SessionId { get; }

		protected ClientSecuritySessionChannel(SecuritySessionClientSettings<TChannel> settings, EndpointAddress to, Uri via)
			: base(settings.SecurityChannelFactory)
		{
			Settings = settings;
			RemoteAddress = to;
			Via = via;
			_keyRenewalCompletedEvent = new InterruptibleWaitObject(signaled: false);
			MessageVersion = settings.SecurityChannelFactory.MessageVersion;
			_channelParameters = new ChannelParameterCollection(this);
			InitializeChannelBinder();
			_webHeaderCollection = new WebHeaderCollection();
			base.SupportsAsyncOpenClose = true;
		}

		public override T GetProperty<T>()
		{
			if (typeof(T) == typeof(ChannelParameterCollection))
			{
				return _channelParameters as T;
			}
			if (typeof(T) == typeof(FaultConverter) && ChannelBinder != null)
			{
				return new SecurityChannelFaultConverter(ChannelBinder.Channel) as T;
			}
			if (typeof(T) == typeof(WebHeaderCollection))
			{
				return (T)(object)_webHeaderCollection;
			}
			T property = base.GetProperty<T>();
			if (property == null && ChannelBinder != null && ChannelBinder.Channel != null)
			{
				property = ChannelBinder.Channel.GetProperty<T>();
			}
			return property;
		}

		protected abstract void InitializeSession(SecurityToken sessionToken);

		private void InitializeSecurityState(SecurityToken sessionToken)
		{
			InitializeSession(sessionToken);
			_currentSessionToken = sessionToken;
			_previousSessionToken = null;
			List<SecurityToken> list = new List<SecurityToken>(1);
			list.Add(sessionToken);
			((IInitiatorSecuritySessionProtocol)_securityProtocol).SetIdentityCheckAuthenticator(new GenericXmlSecurityTokenAuthenticator());
			((IInitiatorSecuritySessionProtocol)_securityProtocol).SetIncomingSessionTokens(list);
			((IInitiatorSecuritySessionProtocol)_securityProtocol).SetOutgoingSessionToken(sessionToken);
			if (CanDoSecurityCorrelation)
			{
				((IInitiatorSecuritySessionProtocol)_securityProtocol).ReturnCorrelationState = true;
			}
			_keyRenewalTime = GetKeyRenewalTime(sessionToken);
		}

		private void SetupSessionTokenProvider()
		{
			InitiatorServiceModelSecurityTokenRequirement initiatorServiceModelSecurityTokenRequirement = new InitiatorServiceModelSecurityTokenRequirement();
			Settings.IssuedSecurityTokenParameters.InitializeSecurityTokenRequirement(initiatorServiceModelSecurityTokenRequirement);
			initiatorServiceModelSecurityTokenRequirement.KeyUsage = SecurityKeyUsage.Signature;
			initiatorServiceModelSecurityTokenRequirement.SupportSecurityContextCancellation = true;
			initiatorServiceModelSecurityTokenRequirement.SecurityAlgorithmSuite = Settings.SessionProtocolFactory.OutgoingAlgorithmSuite;
			initiatorServiceModelSecurityTokenRequirement.SecurityBindingElement = Settings.SessionProtocolFactory.SecurityBindingElement;
			initiatorServiceModelSecurityTokenRequirement.TargetAddress = RemoteAddress;
			initiatorServiceModelSecurityTokenRequirement.Via = Via;
			initiatorServiceModelSecurityTokenRequirement.MessageSecurityVersion = Settings.SessionProtocolFactory.MessageSecurityVersion.SecurityTokenVersion;
			initiatorServiceModelSecurityTokenRequirement.WebHeaders = _webHeaderCollection;
			if (_channelParameters != null)
			{
				initiatorServiceModelSecurityTokenRequirement.Properties[ServiceModelSecurityTokenRequirement.ChannelParametersCollectionProperty] = _channelParameters;
			}
			if (ChannelBinder.LocalAddress != null)
			{
				initiatorServiceModelSecurityTokenRequirement.DuplexClientLocalAddress = ChannelBinder.LocalAddress;
			}
			_sessionTokenProvider = Settings.SessionProtocolFactory.SecurityTokenManager.CreateSecurityTokenProvider(initiatorServiceModelSecurityTokenRequirement);
		}

		private async Task OpenCoreAsync(SecurityToken sessionToken, TimeSpan timeout)
		{
			TimeoutHelper timeoutHelper = new TimeoutHelper(timeout);
			_securityProtocol = Settings.SessionProtocolFactory.CreateSecurityProtocol(RemoteAddress, Via, null, isReturnLegSecurityRequired: true, timeoutHelper.RemainingTime());
			if (!(_securityProtocol is IInitiatorSecuritySessionProtocol))
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.Format(System.SR.ProtocolMisMatch, "IInitiatorSecuritySessionProtocol", GetType().ToString())));
			}
			await _securityProtocol.OpenAsync(timeoutHelper.RemainingTime());
			await ChannelBinder.OpenAsync(timeoutHelper.RemainingTime());
			InitializeSecurityState(sessionToken);
		}

		protected override void OnFaulted()
		{
			AbortCore();
			_inputSessionClosedHandle.Fault(this);
			_keyRenewalCompletedEvent.Fault(this);
			_outputSessionCloseHandle.Fault(this);
			base.OnFaulted();
		}

		protected override void OnOpen(TimeSpan timeout)
		{
			throw ExceptionHelper.PlatformNotSupported();
		}

		protected override IAsyncResult OnBeginOpen(TimeSpan timeout, AsyncCallback callback, object state)
		{
			throw ExceptionHelper.PlatformNotSupported();
		}

		protected override void OnEndOpen(IAsyncResult result)
		{
			throw ExceptionHelper.PlatformNotSupported();
		}

		protected internal override async Task OnOpenAsync(TimeSpan timeout)
		{
			TimeoutHelper timeoutHelper = new TimeoutHelper(timeout);
			SetupSessionTokenProvider();
			await SecurityUtils.OpenTokenProviderIfRequiredAsync(_sessionTokenProvider, timeoutHelper.RemainingTime());
			using (DiagnosticUtility.ShouldUseActivity ? ServiceModelActivity.CreateBoundedActivity() : null)
			{
				SecurityToken sessionToken = await _sessionTokenProvider.GetTokenAsync(timeoutHelper.RemainingTime());
				SendCloseHandshake = true;
				await OpenCoreAsync(sessionToken, timeoutHelper.RemainingTime());
			}
		}

		private void InitializeChannelBinder()
		{
			ChannelBuilder channelBuilder = Settings.ChannelBuilder;
			TolerateFaultsMode faultMode = (Settings.TolerateTransportFailures ? TolerateFaultsMode.Always : TolerateFaultsMode.Never);
			if (channelBuilder.CanBuildChannelFactory<IDuplexSessionChannel>())
			{
				ChannelBinder = ClientReliableChannelBinder<IDuplexSessionChannel>.CreateBinder(RemoteAddress, Via, (IChannelFactory<IDuplexSessionChannel>)Settings.InnerChannelFactory, MaskingMode.None, faultMode, _channelParameters, DefaultCloseTimeout, base.DefaultSendTimeout);
			}
			else if (channelBuilder.CanBuildChannelFactory<IDuplexChannel>())
			{
				ChannelBinder = ClientReliableChannelBinder<IDuplexChannel>.CreateBinder(RemoteAddress, Via, (IChannelFactory<IDuplexChannel>)Settings.InnerChannelFactory, MaskingMode.None, faultMode, _channelParameters, DefaultCloseTimeout, base.DefaultSendTimeout);
				_isCompositeDuplexConnection = true;
			}
			else if (channelBuilder.CanBuildChannelFactory<IRequestChannel>())
			{
				ChannelBinder = ClientReliableChannelBinder<IRequestChannel>.CreateBinder(RemoteAddress, Via, (IChannelFactory<IRequestChannel>)Settings.InnerChannelFactory, MaskingMode.None, faultMode, _channelParameters, DefaultCloseTimeout, base.DefaultSendTimeout);
			}
			else if (channelBuilder.CanBuildChannelFactory<IRequestSessionChannel>())
			{
				ChannelBinder = ClientReliableChannelBinder<IRequestSessionChannel>.CreateBinder(RemoteAddress, Via, (IChannelFactory<IRequestSessionChannel>)Settings.InnerChannelFactory, MaskingMode.None, faultMode, _channelParameters, DefaultCloseTimeout, base.DefaultSendTimeout);
			}
			ChannelBinder.Faulted += OnInnerFaulted;
		}

		private void OnInnerFaulted(IReliableChannelBinder sender, Exception exception)
		{
			Fault(exception);
		}

		protected virtual bool OnCloseResponseReceived()
		{
			bool flag = false;
			bool flag2 = false;
			lock (base.ThisLock)
			{
				flag2 = _sentClose;
				if (flag2 && !_isInputClosed)
				{
					_isInputClosed = true;
					flag = true;
				}
			}
			if (!flag2)
			{
				Fault(new ProtocolException(System.SR.UnexpectedSecuritySessionCloseResponse));
				return false;
			}
			if (flag)
			{
				_inputSessionClosedHandle.Set();
			}
			return true;
		}

		protected virtual bool OnCloseReceived()
		{
			if (!ExpectClose)
			{
				Fault(new ProtocolException(System.SR.UnexpectedSecuritySessionClose));
				return false;
			}
			bool flag = false;
			lock (base.ThisLock)
			{
				if (!_isInputClosed)
				{
					_isInputClosed = true;
					_receivedClose = true;
					flag = true;
				}
			}
			if (flag)
			{
				_inputSessionClosedHandle.Set();
			}
			return true;
		}

		private Message PrepareCloseMessage()
		{
			SecurityToken currentSessionToken;
			lock (base.ThisLock)
			{
				currentSessionToken = _currentSessionToken;
			}
			RequestSecurityToken requestSecurityToken = new RequestSecurityToken(Settings.SecurityStandardsManager);
			requestSecurityToken.RequestType = Settings.SecurityStandardsManager.TrustDriver.RequestTypeClose;
			requestSecurityToken.CloseTarget = Settings.IssuedSecurityTokenParameters.CreateKeyIdentifierClause(currentSessionToken, SecurityTokenReferenceStyle.External);
			requestSecurityToken.MakeReadOnly();
			Message message = Message.CreateMessage(MessageVersion, ActionHeader.Create(Settings.SecurityStandardsManager.SecureConversationDriver.CloseAction, MessageVersion.Addressing), requestSecurityToken);
			RequestReplyCorrelator.PrepareRequest(message);
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
			if (InternalLocalAddress != null)
			{
				message.Headers.ReplyTo = InternalLocalAddress;
			}
			else if (message.Version.Addressing == AddressingVersion.WSAddressing10)
			{
				message.Headers.ReplyTo = null;
			}
			else
			{
				if (message.Version.Addressing != AddressingVersion.WSAddressingAugust2004)
				{
					throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ProtocolException(System.SR.Format(System.SR.AddressingVersionNotSupported, message.Version.Addressing)));
				}
				message.Headers.ReplyTo = EndpointAddress.AnonymousAddress;
			}
			if (TraceUtility.PropagateUserActivity || TraceUtility.ShouldPropagateActivity)
			{
				TraceUtility.AddAmbientActivityToMessage(message);
			}
			return message;
		}

		protected async Task<SecurityProtocolCorrelationState> SendCloseMessageAsync(TimeSpan timeout)
		{
			TimeoutHelper timeoutHelper = new TimeoutHelper(timeout);
			Message closeMessage = PrepareCloseMessage();
			try
			{
				SecurityProtocolCorrelationState closeCorrelationState;
				(closeCorrelationState, closeMessage) = await _securityProtocol.SecureOutgoingMessageAsync(closeMessage, timeoutHelper.RemainingTime(), null);
				await ChannelBinder.SendAsync(closeMessage, timeoutHelper.RemainingTime());
				return closeCorrelationState;
			}
			finally
			{
				closeMessage.Close();
			}
		}

		protected async Task SendCloseResponseMessageAsync(TimeSpan timeout)
		{
			TimeoutHelper timeoutHelper = new TimeoutHelper(timeout);
			Message message = null;
			try
			{
				message = _closeResponse;
				(SecurityProtocolCorrelationState, Message) tuple = await _securityProtocol.SecureOutgoingMessageAsync(message, timeoutHelper.RemainingTime(), null);
				_ = tuple.Item1;
				message = tuple.Item2;
				await ChannelBinder.SendAsync(message, timeoutHelper.RemainingTime());
			}
			finally
			{
				message.Close();
			}
		}

		private MessageFault GetProtocolFault(ref Message message, out bool isKeyRenewalFault, out bool isSessionAbortedFault)
		{
			isKeyRenewalFault = false;
			isSessionAbortedFault = false;
			MessageFault result = null;
			using (MessageBuffer messageBuffer = message.CreateBufferedCopy(int.MaxValue))
			{
				message = messageBuffer.CreateMessage();
				Message message2 = messageBuffer.CreateMessage();
				MessageFault messageFault = MessageFault.CreateFault(message2, 16384);
				if (messageFault.Code.IsSenderFault)
				{
					FaultCode subCode = messageFault.Code.SubCode;
					if (subCode != null)
					{
						SecurityStandardsManager standardsManager = _securityProtocol.SecurityProtocolFactory.StandardsManager;
						SecureConversationDriver secureConversationDriver = standardsManager.SecureConversationDriver;
						if (subCode.Namespace == secureConversationDriver.Namespace.Value && subCode.Name == secureConversationDriver.RenewNeededFaultCode.Value)
						{
							result = messageFault;
							isKeyRenewalFault = true;
						}
						else if (subCode.Namespace == "http://schemas.microsoft.com/ws/2006/05/security" && subCode.Name == "SecuritySessionAborted")
						{
							result = messageFault;
							isSessionAbortedFault = true;
						}
					}
				}
			}
			return result;
		}

		private void ProcessKeyRenewalFault()
		{
			lock (base.ThisLock)
			{
				_keyRenewalTime = DateTime.UtcNow;
			}
		}

		private void ProcessSessionAbortedFault(MessageFault sessionAbortedFault)
		{
			Fault(new FaultException(sessionAbortedFault));
		}

		private void ProcessCloseResponse(Message response)
		{
			if (response.Headers.Action != Settings.SecurityStandardsManager.SecureConversationDriver.CloseResponseAction.Value)
			{
				throw TraceUtility.ThrowHelperError(new MessageSecurityException(System.SR.Format(System.SR.InvalidCloseResponseAction, response.Headers.Action)), response);
			}
			RequestSecurityTokenResponse requestSecurityTokenResponse = null;
			XmlDictionaryReader readerAtBodyContents = response.GetReaderAtBodyContents();
			using (readerAtBodyContents)
			{
				if (Settings.SecurityStandardsManager.MessageSecurityVersion.TrustVersion == TrustVersion.WSTrustFeb2005)
				{
					requestSecurityTokenResponse = Settings.SecurityStandardsManager.TrustDriver.CreateRequestSecurityTokenResponse(readerAtBodyContents);
				}
				else
				{
					if (Settings.SecurityStandardsManager.MessageSecurityVersion.TrustVersion != TrustVersion.WSTrust13)
					{
						throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new NotSupportedException());
					}
					RequestSecurityTokenResponseCollection requestSecurityTokenResponseCollection = Settings.SecurityStandardsManager.TrustDriver.CreateRequestSecurityTokenResponseCollection(readerAtBodyContents);
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
			if (!requestSecurityTokenResponse.IsRequestedTokenClosed)
			{
				throw TraceUtility.ThrowHelperError(new MessageSecurityException(System.SR.SessionTokenWasNotClosed), response);
			}
		}

		private void PrepareReply(Message request, Message reply)
		{
			if (request.Headers.ReplyTo != null)
			{
				request.Headers.ReplyTo.ApplyTo(reply);
			}
			else if (request.Headers.From != null)
			{
				request.Headers.From.ApplyTo(reply);
			}
			if (request.Headers.MessageId != null)
			{
				reply.Headers.RelatesTo = request.Headers.MessageId;
			}
			TraceUtility.CopyActivity(request, reply);
			if (TraceUtility.PropagateUserActivity || TraceUtility.ShouldPropagateActivity)
			{
				TraceUtility.AddActivityHeader(reply);
			}
		}

		private bool DoesSkiClauseMatchSigningToken(SecurityContextKeyIdentifierClause skiClause, Message request)
		{
			if (SessionId == null)
			{
				return false;
			}
			return skiClause.ContextId.ToString() == SessionId;
		}

		private void ProcessCloseMessage(Message message)
		{
			XmlDictionaryReader readerAtBodyContents = message.GetReaderAtBodyContents();
			RequestSecurityToken requestSecurityToken;
			using (readerAtBodyContents)
			{
				requestSecurityToken = Settings.SecurityStandardsManager.TrustDriver.CreateRequestSecurityToken(readerAtBodyContents);
				message.ReadFromBodyContentsToEnd(readerAtBodyContents);
			}
			if (requestSecurityToken.RequestType != null && requestSecurityToken.RequestType != Settings.SecurityStandardsManager.TrustDriver.RequestTypeClose)
			{
				throw TraceUtility.ThrowHelperWarning(new MessageSecurityException(System.SR.Format(System.SR.InvalidRstRequestType, requestSecurityToken.RequestType)), message);
			}
			if (requestSecurityToken.CloseTarget == null)
			{
				throw TraceUtility.ThrowHelperWarning(new MessageSecurityException(System.SR.NoCloseTargetSpecified), message);
			}
			if (!(requestSecurityToken.CloseTarget is SecurityContextKeyIdentifierClause skiClause) || !DoesSkiClauseMatchSigningToken(skiClause, message))
			{
				throw TraceUtility.ThrowHelperWarning(new MessageSecurityException(System.SR.Format(System.SR.BadCloseTarget, requestSecurityToken.CloseTarget)), message);
			}
			RequestSecurityTokenResponse requestSecurityTokenResponse = new RequestSecurityTokenResponse(Settings.SecurityStandardsManager);
			requestSecurityTokenResponse.Context = requestSecurityToken.Context;
			requestSecurityTokenResponse.IsRequestedTokenClosed = true;
			requestSecurityTokenResponse.MakeReadOnly();
			Message message2 = null;
			if (Settings.SecurityStandardsManager.MessageSecurityVersion.TrustVersion == TrustVersion.WSTrustFeb2005)
			{
				message2 = Message.CreateMessage(message.Version, ActionHeader.Create(Settings.SecurityStandardsManager.SecureConversationDriver.CloseResponseAction, message.Version.Addressing), requestSecurityTokenResponse);
			}
			else
			{
				if (Settings.SecurityStandardsManager.MessageSecurityVersion.TrustVersion != TrustVersion.WSTrust13)
				{
					throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new NotSupportedException());
				}
				List<RequestSecurityTokenResponse> list = new List<RequestSecurityTokenResponse>();
				list.Add(requestSecurityTokenResponse);
				RequestSecurityTokenResponseCollection body = new RequestSecurityTokenResponseCollection(list, Settings.SecurityStandardsManager);
				message2 = Message.CreateMessage(message.Version, ActionHeader.Create(Settings.SecurityStandardsManager.SecureConversationDriver.CloseResponseAction, message.Version.Addressing), body);
			}
			PrepareReply(message, message2);
			_closeResponse = message2;
		}

		private bool ShouldWrapException(Exception e)
		{
			if (!(e is FormatException))
			{
				return e is XmlException;
			}
			return true;
		}

		protected Message ProcessIncomingMessage(Message message, TimeSpan timeout, SecurityProtocolCorrelationState correlationState, out MessageFault protocolFault)
		{
			protocolFault = null;
			lock (base.ThisLock)
			{
				DoKeyRolloverIfNeeded();
			}
			try
			{
				VerifyIncomingMessage(ref message, timeout, correlationState);
				string action = message.Headers.Action;
				if (action == Settings.SecurityStandardsManager.SecureConversationDriver.CloseResponseAction.Value)
				{
					ProcessCloseResponse(message);
					OnCloseResponseReceived();
				}
				else if (action == Settings.SecurityStandardsManager.SecureConversationDriver.CloseAction.Value)
				{
					ProcessCloseMessage(message);
					OnCloseReceived();
				}
				else
				{
					if (!(action == "http://schemas.microsoft.com/ws/2006/05/security/SecureConversationFault"))
					{
						return message;
					}
					protocolFault = GetProtocolFault(ref message, out var isKeyRenewalFault, out var isSessionAbortedFault);
					if (isKeyRenewalFault)
					{
						ProcessKeyRenewalFault();
					}
					else
					{
						if (!isSessionAbortedFault)
						{
							return message;
						}
						ProcessSessionAbortedFault(protocolFault);
					}
				}
			}
			catch (Exception ex)
			{
				if (ex is CommunicationException || ex is TimeoutException || Fx.IsFatal(ex) || !ShouldWrapException(ex))
				{
					throw;
				}
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperWarning(new MessageSecurityException(System.SR.MessageSecurityVerificationFailed, ex));
			}
			message.Close();
			return null;
		}

		protected Message ProcessRequestContext(RequestContext requestContext, TimeSpan timeout, SecurityProtocolCorrelationState correlationState)
		{
			if (requestContext == null)
			{
				return null;
			}
			TimeoutHelper timeoutHelper = new TimeoutHelper(timeout);
			Message requestMessage = requestContext.RequestMessage;
			Message message = requestMessage;
			try
			{
				Exception ex = null;
				try
				{
					MessageFault protocolFault;
					return ProcessIncomingMessage(requestMessage, timeoutHelper.RemainingTime(), correlationState, out protocolFault);
				}
				catch (MessageSecurityException ex2)
				{
					if (!_isCompositeDuplexConnection)
					{
						if (message.IsFault)
						{
							MessageFault fault = MessageFault.CreateFault(message, 16384);
							if (SecurityUtils.IsSecurityFault(fault, Settings._sessionProtocolFactory.StandardsManager))
							{
								ex = SecurityUtils.CreateSecurityFaultException(fault);
							}
						}
						else
						{
							ex = ex2;
						}
					}
				}
				if (ex != null)
				{
					Fault(ex);
					throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(ex);
				}
				return null;
			}
			finally
			{
				requestContext.Close(timeoutHelper.RemainingTime());
			}
		}

		private void DoKeyRolloverIfNeeded()
		{
			if (DateTime.UtcNow >= _keyRolloverTime && _previousSessionToken != null)
			{
				_previousSessionToken = null;
				List<SecurityToken> list = new List<SecurityToken>(1);
				list.Add(_currentSessionToken);
				((IInitiatorSecuritySessionProtocol)_securityProtocol).SetIncomingSessionTokens(list);
			}
		}

		private DateTime GetKeyRenewalTime(SecurityToken token)
		{
			TimeSpan timeout = TimeSpan.FromTicks((token.ValidTo.Ticks - token.ValidFrom.Ticks) * Settings._issuedTokenRenewalThreshold / 100);
			DateTime dateTime = TimeoutHelper.Add(token.ValidFrom, timeout);
			DateTime dateTime2 = TimeoutHelper.Add(token.ValidFrom, Settings._keyRenewalInterval);
			if (dateTime < dateTime2)
			{
				return dateTime;
			}
			return dateTime2;
		}

		private bool IsKeyRenewalNeeded()
		{
			return DateTime.UtcNow >= _keyRenewalTime;
		}

		private void UpdateSessionTokens(SecurityToken newToken)
		{
			lock (base.ThisLock)
			{
				_previousSessionToken = _currentSessionToken;
				_keyRolloverTime = TimeoutHelper.Add(DateTime.UtcNow, Settings.KeyRolloverInterval);
				_currentSessionToken = newToken;
				_keyRenewalTime = GetKeyRenewalTime(newToken);
				List<SecurityToken> list = new List<SecurityToken>(2);
				list.Add(_previousSessionToken);
				list.Add(_currentSessionToken);
				((IInitiatorSecuritySessionProtocol)_securityProtocol).SetIncomingSessionTokens(list);
				((IInitiatorSecuritySessionProtocol)_securityProtocol).SetOutgoingSessionToken(_currentSessionToken);
			}
		}

		private async Task RenewKeyAsync(TimeSpan timeout)
		{
			if (!Settings.CanRenewSession)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperWarning(new SessionKeyExpiredException(System.SR.SessionKeyRenewalNotSupported));
			}
			bool flag;
			lock (base.ThisLock)
			{
				if (!_isKeyRenewalOngoing)
				{
					_isKeyRenewalOngoing = true;
					_keyRenewalCompletedEvent.Reset();
					flag = true;
				}
				else
				{
					flag = false;
				}
			}
			if (flag)
			{
				try
				{
					using (DiagnosticUtility.ShouldUseActivity ? ServiceModelActivity.CreateBoundedActivity() : null)
					{
						UpdateSessionTokens(await _sessionTokenProvider.RenewTokenAsync(timeout, _currentSessionToken));
					}
					return;
				}
				finally
				{
					lock (base.ThisLock)
					{
						_isKeyRenewalOngoing = false;
						_keyRenewalCompletedEvent.Set();
					}
				}
			}
			await _keyRenewalCompletedEvent.WaitAsync(timeout);
			lock (base.ThisLock)
			{
				if (IsKeyRenewalNeeded())
				{
					throw DiagnosticUtility.ExceptionUtility.ThrowHelperWarning(new SessionKeyExpiredException(System.SR.UnableToRenewSessionKey));
				}
			}
		}

		private bool CheckIfKeyRenewalNeeded()
		{
			bool flag = false;
			lock (base.ThisLock)
			{
				flag = IsKeyRenewalNeeded();
				DoKeyRolloverIfNeeded();
				return flag;
			}
		}

		protected async Task<(SecurityProtocolCorrelationState, Message)> SecureOutgoingMessageAsync(Message message, TimeSpan timeout)
		{
			bool flag = CheckIfKeyRenewalNeeded();
			TimeoutHelper timeoutHelper = new TimeoutHelper(timeout);
			if (flag)
			{
				await RenewKeyAsync(timeoutHelper.RemainingTime());
			}
			return await _securityProtocol.SecureOutgoingMessageAsync(message, timeoutHelper.RemainingTime(), null);
		}

		protected void VerifyIncomingMessage(ref Message message, TimeSpan timeout, SecurityProtocolCorrelationState correlationState)
		{
			_securityProtocol.VerifyIncomingMessage(ref message, timeout, correlationState);
		}

		protected virtual void AbortCore()
		{
			if (ChannelBinder != null)
			{
				ChannelBinder.Abort();
			}
			if (_sessionTokenProvider != null)
			{
				SecurityUtils.AbortTokenProviderIfRequired(_sessionTokenProvider);
			}
		}

		protected virtual async Task CloseCoreAsync(TimeSpan timeout)
		{
			TimeoutHelper timeoutHelper = new TimeoutHelper(timeout);
			try
			{
				if (ChannelBinder != null)
				{
					await ChannelBinder.CloseAsync(timeoutHelper.RemainingTime());
				}
				if (_sessionTokenProvider != null)
				{
					SecurityUtils.CloseTokenProviderIfRequired(_sessionTokenProvider, timeoutHelper.RemainingTime());
				}
				_keyRenewalCompletedEvent.Abort(this);
				_inputSessionClosedHandle.Abort(this);
			}
			catch (CommunicationObjectAbortedException)
			{
				if (base.State != CommunicationState.Closed)
				{
					throw;
				}
			}
		}

		protected async Task<Message> ReceiveInternalAsync(TimeSpan timeout, SecurityProtocolCorrelationState correlationState)
		{
			TimeoutHelper timeoutHelper = new TimeoutHelper(timeout);
			while (!_isInputClosed)
			{
				var (flag, requestContext) = await ChannelBinder.TryReceiveAsync(timeoutHelper.RemainingTime());
				if (flag)
				{
					if (requestContext == null)
					{
						return null;
					}
					Message message = ProcessRequestContext(requestContext, timeoutHelper.RemainingTime(), correlationState);
					if (message != null)
					{
						return message;
					}
				}
				if (timeoutHelper.RemainingTime() == TimeSpan.Zero)
				{
					break;
				}
			}
			return null;
		}

		protected async Task<(bool, bool)> CloseSessionAsync(TimeSpan timeout)
		{
			using ServiceModelActivity activity = (DiagnosticUtility.ShouldUseActivity ? ServiceModelActivity.CreateBoundedActivity() : null);
			if (DiagnosticUtility.ShouldUseActivity)
			{
				ServiceModelActivity.Start(activity, System.SR.ActivitySecurityClose, ActivityType.SecuritySetup);
			}
			TimeoutHelper timeoutHelper = new TimeoutHelper(timeout);
			bool wasAborted = false;
			try
			{
				await CloseOutputSessionAsync(timeoutHelper.RemainingTime());
				return (await _inputSessionClosedHandle.WaitAsync(timeoutHelper.RemainingTime(), throwTimeoutException: false), wasAborted);
			}
			catch (CommunicationObjectAbortedException)
			{
				if (base.State != CommunicationState.Closed)
				{
					throw;
				}
				wasAborted = true;
			}
			return (false, wasAborted);
		}

		private void DetermineCloseMessageToSend(out bool sendClose, out bool sendCloseResponse)
		{
			sendClose = false;
			sendCloseResponse = false;
			lock (base.ThisLock)
			{
				if (!_isOutputClosed)
				{
					_isOutputClosed = true;
					if (_receivedClose)
					{
						sendCloseResponse = true;
					}
					else
					{
						sendClose = true;
						_sentClose = true;
					}
					_outputSessionCloseHandle.Reset();
				}
			}
		}

		protected virtual async Task<SecurityProtocolCorrelationState> CloseOutputSessionAsync(TimeSpan timeout)
		{
			ThrowIfFaulted();
			if (!SendCloseHandshake)
			{
				return null;
			}
			DetermineCloseMessageToSend(out var sendClose, out var sendCloseResponse);
			if (sendClose || sendCloseResponse)
			{
				try
				{
					if (sendClose)
					{
						return await SendCloseMessageAsync(timeout);
					}
					await SendCloseResponseMessageAsync(timeout);
					return null;
				}
				finally
				{
					_outputSessionCloseHandle.Set();
				}
			}
			return null;
		}

		protected void CheckOutputOpen()
		{
			ThrowIfClosedOrNotOpen();
			lock (base.ThisLock)
			{
				if (_isOutputClosed)
				{
					throw DiagnosticUtility.ExceptionUtility.ThrowHelperWarning(new CommunicationException(System.SR.OutputNotExpected));
				}
			}
		}

		protected override void OnAbort()
		{
			AbortCore();
			_inputSessionClosedHandle.Abort(this);
			_keyRenewalCompletedEvent.Abort(this);
			_outputSessionCloseHandle.Abort(this);
		}

		protected internal override async Task OnCloseAsync(TimeSpan timeout)
		{
			TimeoutHelper timeoutHelper = new TimeoutHelper(timeout);
			if (SendCloseHandshake)
			{
				(bool, bool) tuple = await CloseSessionAsync(timeout);
				var (flag, _) = tuple;
				if (tuple.Item2)
				{
					return;
				}
				if (!flag)
				{
					throw DiagnosticUtility.ExceptionUtility.ThrowHelperWarning(new TimeoutException(System.SR.Format(System.SR.ClientSecurityCloseTimeout, timeout)));
				}
				try
				{
					if (!(await _outputSessionCloseHandle.WaitAsync(timeoutHelper.RemainingTime(), throwTimeoutException: false)))
					{
						throw DiagnosticUtility.ExceptionUtility.ThrowHelperWarning(new TimeoutException(System.SR.Format(System.SR.ClientSecurityOutputSessionCloseTimeout, timeoutHelper.OriginalTimeout)));
					}
				}
				catch (CommunicationObjectAbortedException)
				{
					if (base.State == CommunicationState.Closed)
					{
						return;
					}
					throw;
				}
			}
			await CloseCoreAsync(timeoutHelper.RemainingTime());
		}

		protected override void OnClose(TimeSpan timeout)
		{
			throw ExceptionHelper.PlatformNotSupported();
		}

		protected override IAsyncResult OnBeginClose(TimeSpan timeout, AsyncCallback callback, object state)
		{
			throw ExceptionHelper.PlatformNotSupported();
		}

		protected override void OnEndClose(IAsyncResult result)
		{
			throw ExceptionHelper.PlatformNotSupported();
		}
	}

	private abstract class ClientSecuritySimplexSessionChannel : ClientSecuritySessionChannel
	{
		private SoapSecurityOutputSession _outputSession;

		public IOutputSession Session => _outputSession;

		protected override bool ExpectClose => false;

		protected override string SessionId => Session.Id;

		protected ClientSecuritySimplexSessionChannel(SecuritySessionClientSettings<TChannel> settings, EndpointAddress to, Uri via)
			: base(settings, to, via)
		{
			_outputSession = new SoapSecurityOutputSession(this);
		}

		protected override void InitializeSession(SecurityToken sessionToken)
		{
			_outputSession.Initialize(sessionToken, base.Settings);
		}
	}

	private sealed class SecurityRequestSessionChannel : ClientSecuritySimplexSessionChannel, IAsyncRequestSessionChannel, IRequestSessionChannel, IRequestChannel, IChannel, ICommunicationObject, ISessionChannel<IOutputSession>, IAsyncRequestChannel, IAsyncCommunicationObject
	{
		protected override bool CanDoSecurityCorrelation => true;

		public SecurityRequestSessionChannel(SecuritySessionClientSettings<TChannel> settings, EndpointAddress to, Uri via)
			: base(settings, to, via)
		{
		}

		protected override async Task<SecurityProtocolCorrelationState> CloseOutputSessionAsync(TimeSpan timeout)
		{
			ThrowIfFaulted();
			TimeoutHelper timeoutHelper = new TimeoutHelper(timeout);
			SecurityProtocolCorrelationState correlationState = await base.CloseOutputSessionAsync(timeoutHelper.RemainingTime());
			Message message = await ReceiveInternalAsync(timeoutHelper.RemainingTime(), correlationState);
			if (message != null)
			{
				using (message)
				{
					ProtocolException exception = ProtocolException.ReceiveShutdownReturnedNonNull(message);
					throw TraceUtility.ThrowHelperWarning(exception, message);
				}
			}
			return null;
		}

		public Task<Message> RequestAsync(Message message)
		{
			return RequestAsync(message, base.DefaultSendTimeout);
		}

		Message IRequestChannel.Request(Message message)
		{
			return ((IRequestChannel)this).Request(message, base.DefaultSendTimeout);
		}

		Message IRequestChannel.Request(Message message, TimeSpan timeout)
		{
			return RequestAsyncInternal(message, timeout).WaitForCompletionNoSpin();
		}

		IAsyncResult IRequestChannel.BeginRequest(Message message, AsyncCallback callback, object state)
		{
			return ((IRequestChannel)this).BeginRequest(message, base.DefaultSendTimeout, callback, state);
		}

		IAsyncResult IRequestChannel.BeginRequest(Message message, TimeSpan timeout, AsyncCallback callback, object state)
		{
			return RequestAsyncInternal(message, timeout).ToApm(callback, state);
		}

		Message IRequestChannel.EndRequest(IAsyncResult result)
		{
			return result.ToApmEnd<Message>();
		}

		private Message ProcessReply(Message reply, TimeSpan timeout, SecurityProtocolCorrelationState correlationState)
		{
			if (reply == null)
			{
				return null;
			}
			Message message = null;
			MessageFault protocolFault = null;
			Exception ex = null;
			try
			{
				message = ProcessIncomingMessage(reply, timeout, correlationState, out protocolFault);
			}
			catch (MessageSecurityException)
			{
				if (reply.IsFault)
				{
					MessageFault fault = MessageFault.CreateFault(reply, 16384);
					if (SecurityUtils.IsSecurityFault(fault, base.Settings._standardsManager))
					{
						ex = SecurityUtils.CreateSecurityFaultException(fault);
					}
				}
				if (ex == null)
				{
					throw;
				}
			}
			if (ex != null)
			{
				Fault(ex);
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(ex);
			}
			if (message == null && protocolFault != null)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new MessageSecurityException(System.SR.SecuritySessionFaultReplyWasSent, new FaultException(protocolFault)));
			}
			return message;
		}

		private async Task<Message> RequestAsyncInternal(Message message, TimeSpan timeout)
		{
			await TaskHelpers.EnsureDefaultTaskScheduler();
			return await RequestAsync(message, timeout);
		}

		public async Task<Message> RequestAsync(Message message, TimeSpan timeout)
		{
			ThrowIfFaulted();
			CheckOutputOpen();
			TimeoutHelper timeoutHelper = new TimeoutHelper(timeout);
			SecurityProtocolCorrelationState correlationState;
			(correlationState, message) = await SecureOutgoingMessageAsync(message, timeoutHelper.RemainingTime());
			return ProcessReply(await base.ChannelBinder.RequestAsync(message, timeoutHelper.RemainingTime()), timeoutHelper.RemainingTime(), correlationState);
		}
	}

	private class ClientSecurityDuplexSessionChannel : ClientSecuritySessionChannel, IAsyncDuplexSessionChannel, IDuplexSessionChannel, IDuplexChannel, IInputChannel, IChannel, ICommunicationObject, IOutputChannel, ISessionChannel<IDuplexSession>, IAsyncDuplexChannel, IAsyncInputChannel, IAsyncCommunicationObject, IAsyncOutputChannel, ISessionChannel<IAsyncDuplexSession>
	{
		private class SoapSecurityClientDuplexSession : SoapSecurityOutputSession, IDuplexSession, IInputSession, ISession, IOutputSession, IAsyncDuplexSession
		{
			private ClientSecurityDuplexSessionChannel _channel;

			private bool _initialized;

			public SoapSecurityClientDuplexSession(ClientSecurityDuplexSessionChannel channel)
				: base((ClientSecuritySessionChannel)channel)
			{
				_channel = channel;
			}

			internal new void Initialize(SecurityToken sessionToken, SecuritySessionClientSettings<TChannel> settings)
			{
				base.Initialize(sessionToken, settings);
				_initialized = true;
			}

			private void CheckInitialized()
			{
				if (!_initialized)
				{
					throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.ChannelNotOpen));
				}
			}

			public void CloseOutputSession()
			{
				CloseOutputSessionAsync().GetAwaiter().GetResult();
			}

			public Task CloseOutputSessionAsync()
			{
				return CloseOutputSessionAsync(_channel.DefaultCloseTimeout);
			}

			public void CloseOutputSession(TimeSpan timeout)
			{
				CloseOutputSessionAsync(timeout).GetAwaiter().GetResult();
			}

			public async Task CloseOutputSessionAsync(TimeSpan timeout)
			{
				CheckInitialized();
				_channel.ThrowIfFaulted();
				_channel.ThrowIfNotOpened();
				Exception pendingException = null;
				try
				{
					await _channel.CloseOutputSessionAsync(timeout);
				}
				catch (CommunicationObjectAbortedException)
				{
					if (_channel.State != CommunicationState.Closed)
					{
						throw;
					}
				}
				catch (Exception ex2)
				{
					if (Fx.IsFatal(ex2))
					{
						throw;
					}
					pendingException = ex2;
				}
				if (pendingException != null)
				{
					_channel.Fault(pendingException);
					throw pendingException;
				}
			}

			public IAsyncResult BeginCloseOutputSession(AsyncCallback callback, object state)
			{
				return CloseOutputSessionAsync().ToApm(callback, state);
			}

			public IAsyncResult BeginCloseOutputSession(TimeSpan timeout, AsyncCallback callback, object state)
			{
				return CloseOutputSessionAsync(timeout).ToApm(callback, state);
			}

			public void EndCloseOutputSession(IAsyncResult result)
			{
				result.ToApmEnd();
			}
		}

		private SoapSecurityClientDuplexSession _session;

		private InputQueue<Message> _queue;

		public EndpointAddress LocalAddress => base.InternalLocalAddress;

		IDuplexSession ISessionChannel<IDuplexSession>.Session => _session;

		IAsyncDuplexSession ISessionChannel<IAsyncDuplexSession>.Session => _session;

		protected override bool ExpectClose => true;

		protected override string SessionId => _session.Id;

		public ClientSecurityDuplexSessionChannel(SecuritySessionClientSettings<TChannel> settings, EndpointAddress to, Uri via)
			: base(settings, to, via)
		{
			_session = new SoapSecurityClientDuplexSession(this);
			_queue = TraceUtility.CreateInputQueue<Message>();
		}

		public Message Receive()
		{
			return ReceiveAsync().GetAwaiter().GetResult();
		}

		public Task<Message> ReceiveAsync()
		{
			return ReceiveAsync(base.DefaultReceiveTimeout);
		}

		public Message Receive(TimeSpan timeout)
		{
			return ReceiveAsync(timeout).GetAwaiter().GetResult();
		}

		public Task<Message> ReceiveAsync(TimeSpan timeout)
		{
			return InputChannel.HelpReceiveAsync(this, timeout);
		}

		public IAsyncResult BeginReceive(AsyncCallback callback, object state)
		{
			return ReceiveAsync().ToApm(callback, state);
		}

		public IAsyncResult BeginReceive(TimeSpan timeout, AsyncCallback callback, object state)
		{
			return ReceiveAsync(timeout).ToApm(callback, state);
		}

		public Message EndReceive(IAsyncResult result)
		{
			return result.ToApmEnd<Message>();
		}

		public IAsyncResult BeginTryReceive(TimeSpan timeout, AsyncCallback callback, object state)
		{
			return TryReceiveAsync(timeout).ToApm(callback, state);
		}

		public bool EndTryReceive(IAsyncResult result, out Message message)
		{
			bool result2;
			(result2, message) = result.ToApmEnd<(bool, Message)>();
			return result2;
		}

		protected override void OnOpened()
		{
			base.OnOpened();
			StartReceiving();
		}

		public bool TryReceive(TimeSpan timeout, out Message message)
		{
			bool result;
			(result, message) = TryReceiveAsync(timeout).GetAwaiter().GetResult();
			return result;
		}

		public async Task<(bool, Message)> TryReceiveAsync(TimeSpan timeout)
		{
			ThrowIfFaulted();
			var (item, message) = await _queue.TryDequeueAsync(timeout);
			if (message == null)
			{
				ThrowIfFaulted();
			}
			return (item, message);
		}

		public void Send(Message message)
		{
			SendAsync(message).GetAwaiter().GetResult();
		}

		public Task SendAsync(Message message)
		{
			return SendAsync(message, base.DefaultSendTimeout);
		}

		public void Send(Message message, TimeSpan timeout)
		{
			SendAsync(message, timeout).GetAwaiter().GetResult();
		}

		public async Task SendAsync(Message message, TimeSpan timeout)
		{
			ThrowIfFaulted();
			CheckOutputOpen();
			TimeoutHelper timeoutHelper = new TimeoutHelper(timeout);
			(SecurityProtocolCorrelationState, Message) tuple = await SecureOutgoingMessageAsync(message, timeoutHelper.RemainingTime());
			_ = tuple.Item1;
			message = tuple.Item2;
			await base.ChannelBinder.SendAsync(message, timeoutHelper.RemainingTime());
		}

		public IAsyncResult BeginSend(Message message, AsyncCallback callback, object state)
		{
			return SendAsync(message).ToApm(callback, state);
		}

		public IAsyncResult BeginSend(Message message, TimeSpan timeout, AsyncCallback callback, object state)
		{
			return SendAsync(message, timeout).ToApm(callback, state);
		}

		public void EndSend(IAsyncResult result)
		{
			result.ToApmEnd();
		}

		protected override void InitializeSession(SecurityToken sessionToken)
		{
			_session.Initialize(sessionToken, base.Settings);
		}

		private async void StartReceiving()
		{
			while (base.State != CommunicationState.Closed && base.State != CommunicationState.Faulted && !base.IsInputClosed)
			{
				try
				{
					Message message = await ReceiveInternalAsync(TimeSpan.MaxValue, null);
					if (message == null)
					{
						continue;
					}
					ActionItem.Schedule(Fx.ThunkCallback<object>(delegate
					{
						try
						{
							_queue.EnqueueAndDispatch(message);
						}
						catch (Exception exception)
						{
							if (Fx.IsFatal(exception))
							{
								throw;
							}
						}
					}), null);
				}
				catch (CommunicationException)
				{
				}
				catch (TimeoutException)
				{
				}
			}
		}

		protected override void AbortCore()
		{
			try
			{
				_queue.Dispose();
			}
			catch (CommunicationException)
			{
			}
			catch (TimeoutException)
			{
			}
			base.AbortCore();
		}

		public bool WaitForMessage(TimeSpan timeout)
		{
			return WaitForMessageAsync(timeout).GetAwaiter().GetResult();
		}

		public Task<bool> WaitForMessageAsync(TimeSpan timeout)
		{
			return _queue.WaitForItemAsync(timeout);
		}

		public IAsyncResult BeginWaitForMessage(TimeSpan timeout, AsyncCallback callback, object state)
		{
			return WaitForMessageAsync(timeout).ToApm(callback, state);
		}

		public bool EndWaitForMessage(IAsyncResult result)
		{
			return result.ToApmEnd<bool>();
		}

		protected override void OnFaulted()
		{
			_queue.Shutdown(() => GetPendingException());
			base.OnFaulted();
		}

		protected override bool OnCloseResponseReceived()
		{
			if (base.OnCloseResponseReceived())
			{
				_queue.Shutdown();
				return true;
			}
			return false;
		}

		protected override bool OnCloseReceived()
		{
			if (base.OnCloseReceived())
			{
				_queue.Shutdown();
				return true;
			}
			return false;
		}
	}

	private SecurityProtocolFactory _sessionProtocolFactory;

	private TimeSpan _keyRenewalInterval;

	private TimeSpan _keyRolloverInterval;

	private bool _tolerateTransportFailures;

	private WrapperSecurityCommunicationObject _communicationObject;

	private SecurityStandardsManager _standardsManager;

	private SecurityTokenParameters _issuedTokenParameters;

	private int _issuedTokenRenewalThreshold;

	private object _thisLock = new object();

	private IChannelFactory InnerChannelFactory { get; set; }

	internal ChannelBuilder ChannelBuilder { get; set; }

	private SecurityChannelFactory<TChannel> SecurityChannelFactory { get; set; }

	public SecurityProtocolFactory SessionProtocolFactory
	{
		get
		{
			return _sessionProtocolFactory;
		}
		set
		{
			_communicationObject.ThrowIfDisposedOrImmutable();
			_sessionProtocolFactory = value;
		}
	}

	public TimeSpan KeyRenewalInterval
	{
		get
		{
			return _keyRenewalInterval;
		}
		set
		{
			if (value <= TimeSpan.Zero)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentOutOfRangeException("value", System.SR.TimeSpanMustbeGreaterThanTimeSpanZero));
			}
			_communicationObject.ThrowIfDisposedOrImmutable();
			_keyRenewalInterval = value;
		}
	}

	public TimeSpan KeyRolloverInterval
	{
		get
		{
			return _keyRolloverInterval;
		}
		set
		{
			if (value <= TimeSpan.Zero)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentOutOfRangeException("value", System.SR.TimeSpanMustbeGreaterThanTimeSpanZero));
			}
			_communicationObject.ThrowIfDisposedOrImmutable();
			_keyRolloverInterval = value;
		}
	}

	public bool TolerateTransportFailures
	{
		get
		{
			return _tolerateTransportFailures;
		}
		set
		{
			_communicationObject.ThrowIfDisposedOrImmutable();
			_tolerateTransportFailures = value;
		}
	}

	public bool CanRenewSession { get; set; } = true;

	public SecurityTokenParameters IssuedSecurityTokenParameters
	{
		get
		{
			return _issuedTokenParameters;
		}
		set
		{
			_communicationObject.ThrowIfDisposedOrImmutable();
			_issuedTokenParameters = value;
		}
	}

	public SecurityStandardsManager SecurityStandardsManager
	{
		get
		{
			return _standardsManager;
		}
		set
		{
			_communicationObject.ThrowIfDisposedOrImmutable();
			_standardsManager = value;
		}
	}

	public TimeSpan DefaultOpenTimeout => ServiceDefaults.OpenTimeout;

	public TimeSpan DefaultCloseTimeout => ServiceDefaults.CloseTimeout;

	public SecuritySessionClientSettings()
	{
		_keyRenewalInterval = SecuritySessionClientSettings.defaultKeyRenewalInterval;
		_keyRolloverInterval = SecuritySessionClientSettings.defaultKeyRolloverInterval;
		_tolerateTransportFailures = true;
		_communicationObject = new WrapperSecurityCommunicationObject(this);
	}

	internal IChannelFactory CreateInnerChannelFactory()
	{
		if (ChannelBuilder.CanBuildChannelFactory<IDuplexSessionChannel>())
		{
			return ChannelBuilder.BuildChannelFactory<IDuplexSessionChannel>();
		}
		if (ChannelBuilder.CanBuildChannelFactory<IDuplexChannel>())
		{
			return ChannelBuilder.BuildChannelFactory<IDuplexChannel>();
		}
		if (ChannelBuilder.CanBuildChannelFactory<IRequestChannel>())
		{
			return ChannelBuilder.BuildChannelFactory<IRequestChannel>();
		}
		throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new NotSupportedException());
	}

	public void OnClosed()
	{
	}

	public void OnClosing()
	{
	}

	public void OnFaulted()
	{
	}

	public void OnOpened()
	{
	}

	public void OnOpening()
	{
	}

	public Task OnCloseAsync(TimeSpan timeout)
	{
		if (_sessionProtocolFactory != null)
		{
			return _sessionProtocolFactory.CloseAsync(aborted: false, timeout);
		}
		return Task.CompletedTask;
	}

	public void OnAbort()
	{
		if (_sessionProtocolFactory != null)
		{
			_sessionProtocolFactory.CloseAsync(aborted: true, TimeSpan.Zero).Wait();
		}
	}

	public Task OnOpenAsync(TimeSpan timeout)
	{
		TimeoutHelper timeoutHelper = new TimeoutHelper(timeout);
		if (_sessionProtocolFactory == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.SecuritySessionProtocolFactoryShouldBeSetBeforeThisOperation));
		}
		if (_standardsManager == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.Format(System.SR.SecurityStandardsManagerNotSet, GetType().ToString())));
		}
		if (_issuedTokenParameters == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.Format(System.SR.IssuedSecurityTokenParametersNotSet, GetType())));
		}
		if (_keyRenewalInterval < _keyRolloverInterval)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.KeyRolloverGreaterThanKeyRenewal));
		}
		_issuedTokenRenewalThreshold = _sessionProtocolFactory.SecurityBindingElement.LocalClientSettings.CookieRenewalThresholdPercentage;
		ConfigureSessionProtocolFactory();
		return _sessionProtocolFactory.OpenAsync(actAsInitiator: true, timeoutHelper.RemainingTime());
	}

	internal Task CloseAsync(TimeSpan timeout)
	{
		return ((IAsyncCommunicationObject)_communicationObject).CloseAsync(timeout);
	}

	internal void Abort()
	{
		_communicationObject.Abort();
	}

	internal Task OpenAsync(SecurityChannelFactory<TChannel> securityChannelFactory, IChannelFactory innerChannelFactory, ChannelBuilder channelBuilder, TimeSpan timeout)
	{
		SecurityChannelFactory = securityChannelFactory;
		InnerChannelFactory = innerChannelFactory;
		ChannelBuilder = channelBuilder;
		return ((IAsyncCommunicationObject)_communicationObject).OpenAsync(timeout);
	}

	internal TChannel OnCreateChannel(EndpointAddress remoteAddress, Uri via)
	{
		if (typeof(TChannel) == typeof(IRequestSessionChannel))
		{
			return (TChannel)(object)new SecurityRequestSessionChannel(this, remoteAddress, via);
		}
		if (typeof(TChannel) == typeof(IDuplexSessionChannel))
		{
			return (TChannel)(object)new ClientSecurityDuplexSessionChannel(this, remoteAddress, via);
		}
		throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentException(System.SR.Format(System.SR.ChannelTypeNotSupported, typeof(TChannel)), "TChannel"));
	}

	private void ConfigureSessionProtocolFactory()
	{
		if (_sessionProtocolFactory is SessionSymmetricTransportSecurityProtocolFactory)
		{
			SessionSymmetricTransportSecurityProtocolFactory sessionSymmetricTransportSecurityProtocolFactory = (SessionSymmetricTransportSecurityProtocolFactory)_sessionProtocolFactory;
			sessionSymmetricTransportSecurityProtocolFactory.AddTimestamp = true;
			sessionSymmetricTransportSecurityProtocolFactory.SecurityTokenParameters.RequireDerivedKeys = false;
			return;
		}
		throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new NotSupportedException());
	}
}
