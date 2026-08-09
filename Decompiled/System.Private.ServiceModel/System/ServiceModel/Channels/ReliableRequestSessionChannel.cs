using System.Runtime;
using System.Threading.Tasks;
using System.Xml;

namespace System.ServiceModel.Channels;

internal sealed class ReliableRequestSessionChannel : RequestChannel, IRequestSessionChannel, IRequestChannel, IChannel, ICommunicationObject, ISessionChannel<IOutputSession>, IAsyncRequestChannel, IAsyncCommunicationObject
{
	private interface IReliableRequest : IRequestBase
	{
		void Set(Message reply);

		void Complete();
	}

	private class AsyncRequest : IReliableRequest, IRequestBase, IAsyncRequest
	{
		private bool _aborted;

		private bool _completed;

		private TaskCompletionSource<object> _tcs;

		private bool _faulted;

		private TimeSpan _originalTimeout;

		private Message _reply;

		private ReliableRequestSessionChannel _parent;

		private object ThisLock { get; } = new object();

		public AsyncRequest(ReliableRequestSessionChannel parent)
		{
			_parent = parent;
		}

		public void Abort(RequestChannel channel)
		{
			lock (ThisLock)
			{
				if (!_completed)
				{
					_aborted = true;
					_completed = true;
					_tcs?.SetResult(null);
				}
			}
		}

		public void Fault(RequestChannel channel)
		{
			lock (ThisLock)
			{
				if (!_completed)
				{
					_faulted = true;
					_completed = true;
					_tcs?.SetResult(null);
				}
			}
		}

		public void Complete()
		{
		}

		public async Task SendRequestAsync(Message message, TimeoutHelper timeoutHelper)
		{
			_originalTimeout = timeoutHelper.OriginalTimeout;
			if (!(await _parent.connection.AddMessageAsync(message, timeoutHelper.RemainingTime(), this)))
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(_parent.GetInvalidAddException());
			}
		}

		public void Set(Message reply)
		{
			lock (ThisLock)
			{
				if (!_completed)
				{
					_reply = reply;
					_completed = true;
					_tcs?.SetResult(null);
					return;
				}
			}
			reply?.Close();
		}

		public async Task<Message> ReceiveReplyAsync(TimeoutHelper timeoutHelper)
		{
			bool throwing = true;
			try
			{
				bool flag = false;
				if (!_completed)
				{
					bool flag2 = false;
					lock (ThisLock)
					{
						if (!_completed)
						{
							flag2 = true;
							_tcs = new TaskCompletionSource<object>(TaskCreationOptions.RunContinuationsAsynchronously);
						}
					}
					if (flag2)
					{
						flag = !(await _tcs.Task.AwaitWithTimeout(timeoutHelper.RemainingTime()));
						lock (ThisLock)
						{
							if (!_completed)
							{
								_completed = true;
							}
							else
							{
								flag = false;
							}
						}
					}
				}
				if (_aborted)
				{
					throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(_parent.CreateClosedException());
				}
				if (_faulted)
				{
					throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(_parent.GetTerminalException());
				}
				if (flag)
				{
					throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new TimeoutException(System.SR.Format(System.SR.TimeoutOnRequest, _originalTimeout)));
				}
				throwing = false;
				return _reply;
			}
			finally
			{
				if (throwing)
				{
					WsrmFault fault = SequenceTerminatedFault.CreateCommunicationFault(_parent.session.InputID, System.SR.SequenceTerminatedReliableRequestThrew, null);
					_parent.session.OnLocalFault(null, fault, null);
				}
			}
		}

		public void OnReleaseRequest()
		{
		}
	}

	private IClientReliableChannelBinder binder;

	private ChannelParameterCollection channelParameters;

	private ReliableRequestor closeRequestor;

	private ReliableOutputConnection connection;

	private bool isLastKnown;

	private Exception maxRetryCountException;

	private SequenceRangeCollection ranges = SequenceRangeCollection.Empty;

	private Guard replyAckConsistencyGuard;

	private ClientReliableSession session;

	private IReliableFactorySettings settings;

	private InterruptibleWaitObject shutdownHandle;

	private ReliableRequestor terminateRequestor;

	public IOutputSession Session => session;

	public ReliableRequestSessionChannel(ChannelManagerBase factory, IReliableFactorySettings settings, IClientReliableChannelBinder binder, FaultHelper faultHelper, LateBoundChannelParameterCollection channelParameters, UniqueId inputID)
		: base(factory, binder.RemoteAddress, binder.Via, manualAddressing: true)
	{
		this.settings = settings;
		this.binder = binder;
		session = new ClientReliableSession(this, settings, binder, faultHelper, inputID);
		session.PollingCallback = PollingCallback;
		session.UnblockChannelCloseCallback = UnblockClose;
		if (this.settings.ReliableMessagingVersion == ReliableMessagingVersion.WSReliableMessagingFebruary2005)
		{
			shutdownHandle = new InterruptibleWaitObject(signaled: false);
		}
		else
		{
			replyAckConsistencyGuard = new Guard(int.MaxValue);
		}
		this.binder.Faulted += OnBinderFaulted;
		this.binder.OnException += OnBinderException;
		this.channelParameters = channelParameters;
		channelParameters.SetChannel(this);
	}

	private void AddAcknowledgementHeader(Message message, bool force)
	{
		if (ranges.Count != 0)
		{
			WsrmUtilities.AddAcknowledgementHeader(settings.ReliableMessagingVersion, message, session.InputID, ranges, isLastKnown);
		}
	}

	private async Task CloseSequenceAsync(TimeSpan timeout)
	{
		CreateCloseRequestor();
		ProcessCloseOrTerminateReply(close: true, await closeRequestor.RequestAsync(timeout));
	}

	private void ConfigureRequestor(ReliableRequestor requestor)
	{
		ReliableMessagingVersion reliableMessagingVersion = settings.ReliableMessagingVersion;
		requestor.MessageVersion = settings.MessageVersion;
		requestor.Binder = binder;
		requestor.SetRequestResponsePattern();
		requestor.MessageHeader = new WsrmAcknowledgmentHeader(reliableMessagingVersion, session.InputID, ranges, final: true, -1);
	}

	private Message CreateAckRequestedMessage()
	{
		Message message = WsrmUtilities.CreateAckRequestedMessage(settings.MessageVersion, settings.ReliableMessagingVersion, session.OutputID);
		AddAcknowledgementHeader(message, force: true);
		return message;
	}

	protected override IAsyncRequest CreateAsyncRequest(Message message)
	{
		return new AsyncRequest(this);
	}

	private void CreateCloseRequestor()
	{
		RequestReliableRequestor requestReliableRequestor = new RequestReliableRequestor();
		ConfigureRequestor(requestReliableRequestor);
		requestReliableRequestor.TimeoutString1Index = System.SR.TimeoutOnClose;
		requestReliableRequestor.MessageAction = WsrmIndex.GetCloseSequenceActionHeader(settings.MessageVersion.Addressing);
		requestReliableRequestor.MessageBody = new CloseSequence(session.OutputID, connection.Last);
		lock (base.ThisLock)
		{
			ThrowIfClosed();
			closeRequestor = requestReliableRequestor;
		}
	}

	private void CreateTerminateRequestor()
	{
		RequestReliableRequestor requestReliableRequestor = new RequestReliableRequestor();
		ConfigureRequestor(requestReliableRequestor);
		requestReliableRequestor.MessageAction = WsrmIndex.GetTerminateSequenceActionHeader(settings.MessageVersion.Addressing, settings.ReliableMessagingVersion);
		requestReliableRequestor.MessageBody = new TerminateSequence(settings.ReliableMessagingVersion, session.OutputID, connection.Last);
		lock (base.ThisLock)
		{
			ThrowIfClosed();
			terminateRequestor = requestReliableRequestor;
			session.CloseSession();
		}
	}

	private Exception GetInvalidAddException()
	{
		if (base.State == CommunicationState.Faulted)
		{
			return GetTerminalException();
		}
		return CreateClosedException();
	}

	public override T GetProperty<T>()
	{
		if (typeof(T) == typeof(IRequestSessionChannel))
		{
			return (T)(object)this;
		}
		if (typeof(T) == typeof(ChannelParameterCollection))
		{
			return (T)(object)channelParameters;
		}
		T property = base.GetProperty<T>();
		if (property != null)
		{
			return property;
		}
		T property2 = binder.Channel.GetProperty<T>();
		if (property2 == null && typeof(T) == typeof(FaultConverter))
		{
			return (T)(object)FaultConverter.GetDefaultFaultConverter(settings.MessageVersion);
		}
		return property2;
	}

	protected override void OnAbort()
	{
		if (connection != null)
		{
			connection.Abort(this);
		}
		if (shutdownHandle != null)
		{
			shutdownHandle.Abort(this);
		}
		closeRequestor?.Abort(this);
		terminateRequestor?.Abort(this);
		session.Abort();
		base.OnAbort();
	}

	protected override IAsyncResult OnBeginClose(TimeSpan timeout, AsyncCallback callback, object state)
	{
		return OnCloseAsync(timeout).ToApm(callback, state);
	}

	protected override IAsyncResult OnBeginOpen(TimeSpan timeout, AsyncCallback callback, object state)
	{
		return OnOpenAsync(timeout).ToApm(callback, state);
	}

	private void OnBinderException(IReliableChannelBinder sender, Exception exception)
	{
		if (exception is QuotaExceededException)
		{
			if (base.State == CommunicationState.Opening || base.State == CommunicationState.Opened || base.State == CommunicationState.Closing)
			{
				session.OnLocalFault(exception, SequenceTerminatedFault.CreateQuotaExceededFault(session.OutputID), null);
			}
		}
		else
		{
			AddPendingException(exception);
		}
	}

	private void OnBinderFaulted(IReliableChannelBinder sender, Exception exception)
	{
		binder.Abort();
		if (base.State == CommunicationState.Opening || base.State == CommunicationState.Opened || base.State == CommunicationState.Closing)
		{
			exception = new CommunicationException(System.SR.EarlySecurityFaulted, exception);
			session.OnLocalFault(exception, (Message)null, (RequestContext)null);
		}
	}

	protected internal override async Task OnCloseAsync(TimeSpan timeout)
	{
		TimeoutHelper timeoutHelper = new TimeoutHelper(timeout);
		await connection.CloseAsync(timeoutHelper.RemainingTime());
		await WaitForShutdownAsync(timeoutHelper.RemainingTime());
		if (settings.ReliableMessagingVersion == ReliableMessagingVersion.WSReliableMessaging11)
		{
			await CloseSequenceAsync(timeoutHelper.RemainingTime());
		}
		await TerminateSequenceAsync(timeoutHelper.RemainingTime());
		await session.CloseAsync(timeoutHelper.RemainingTime());
		await binder.CloseAsync(timeoutHelper.RemainingTime(), MaskingMode.Handled);
	}

	protected override void OnClose(TimeSpan timeout)
	{
		OnCloseAsync(timeout).WaitForCompletionNoSpin();
	}

	protected override void OnClosed()
	{
		base.OnClosed();
		binder.Faulted -= OnBinderFaulted;
	}

	private async Task OnConnectionSendAsync(MessageAttemptInfo attemptInfo, TimeSpan timeout, bool maskUnhandledException)
	{
		using (attemptInfo.Message)
		{
			if (attemptInfo.RetryCount > settings.MaxRetryCount)
			{
				if (WcfEventSource.Instance.MaxRetryCyclesExceededIsEnabled())
				{
					WcfEventSource.Instance.MaxRetryCyclesExceeded(System.SR.MaximumRetryCountExceeded);
				}
				session.OnLocalFault(new CommunicationException(System.SR.MaximumRetryCountExceeded, maxRetryCountException), SequenceTerminatedFault.CreateMaxRetryCountExceededFault(session.OutputID), null);
				return;
			}
			AddAcknowledgementHeader(attemptInfo.Message, force: false);
			session.OnLocalActivity();
			Message reply = null;
			MaskingMode maskingMode = (maskUnhandledException ? MaskingMode.Unhandled : MaskingMode.None);
			if (attemptInfo.RetryCount < settings.MaxRetryCount)
			{
				maskingMode |= MaskingMode.Handled;
				reply = await binder.RequestAsync(attemptInfo.Message, timeout, maskingMode);
			}
			else
			{
				try
				{
					reply = await binder.RequestAsync(attemptInfo.Message, timeout, maskingMode);
				}
				catch (Exception ex)
				{
					if (Fx.IsFatal(ex))
					{
						throw;
					}
					if (!binder.IsHandleable(ex))
					{
						throw;
					}
					maxRetryCountException = ex;
				}
			}
			if (reply != null)
			{
				ProcessReply(reply, (IReliableRequest)attemptInfo.State, attemptInfo.GetSequenceNumber());
			}
		}
	}

	private Task OnConnectionSendAckAsyncRequested(TimeSpan timeout)
	{
		return Task.CompletedTask;
	}

	private void OnComponentFaulted(Exception faultException, WsrmFault fault)
	{
		session.OnLocalFault(faultException, fault, null);
	}

	private void OnComponentException(Exception exception)
	{
		session.OnUnknownException(exception);
	}

	protected override void OnEndClose(IAsyncResult result)
	{
		result.ToApmEnd();
	}

	protected override void OnEndOpen(IAsyncResult result)
	{
		result.ToApmEnd();
	}

	protected override void OnFaulted()
	{
		session.OnFaulted();
		UnblockClose();
		base.OnFaulted();
	}

	protected internal override async Task OnOpenAsync(TimeSpan timeout)
	{
		TimeoutHelper timeoutHelper = new TimeoutHelper(timeout);
		bool throwing = true;
		try
		{
			await binder.OpenAsync(timeoutHelper.RemainingTime());
			await session.OpenAsync(timeoutHelper.RemainingTime());
			throwing = false;
		}
		finally
		{
			if (throwing)
			{
				await binder.CloseAsync(timeoutHelper.RemainingTime());
			}
		}
	}

	protected override void OnOpen(TimeSpan timeout)
	{
		OnOpenAsync(timeout).WaitForCompletionNoSpin();
	}

	protected override void OnOpened()
	{
		base.OnOpened();
		connection = new ReliableOutputConnection(session.OutputID, settings.MaxTransferWindowSize, settings.MessageVersion, settings.ReliableMessagingVersion, session.InitiationTime, requestAcks: false, base.DefaultSendTimeout);
		ReliableOutputConnection reliableOutputConnection = connection;
		reliableOutputConnection.Faulted = (ComponentFaultedHandler)Delegate.Combine(reliableOutputConnection.Faulted, new ComponentFaultedHandler(OnComponentFaulted));
		ReliableOutputConnection reliableOutputConnection2 = connection;
		reliableOutputConnection2.OnException = (ComponentExceptionHandler)Delegate.Combine(reliableOutputConnection2.OnException, new ComponentExceptionHandler(OnComponentException));
		connection.SendAsyncHandler = OnConnectionSendAsync;
		connection.SendAckRequestedAsyncHandler = OnConnectionSendAckAsyncRequested;
	}

	private async Task PollingCallback()
	{
		Message message = CreateAckRequestedMessage();
		Message message2 = await binder.RequestAsync(message, base.DefaultSendTimeout, MaskingMode.All);
		if (message2 != null)
		{
			ProcessReply(message2, null, 0L);
		}
	}

	private void ProcessCloseOrTerminateReply(bool close, Message reply)
	{
		if (reply == null)
		{
			throw Fx.AssertAndThrow("Argument reply cannot be null.");
		}
		ReliableMessagingVersion reliableMessagingVersion = settings.ReliableMessagingVersion;
		if (reliableMessagingVersion == ReliableMessagingVersion.WSReliableMessagingFebruary2005)
		{
			if (close)
			{
				throw Fx.AssertAndThrow("Close does not exist in Feb2005.");
			}
			reply.Close();
			return;
		}
		if (reliableMessagingVersion == ReliableMessagingVersion.WSReliableMessaging11)
		{
			WsrmMessageInfo info = closeRequestor.GetInfo();
			if (info != null)
			{
				return;
			}
			try
			{
				info = WsrmMessageInfo.Get(settings.MessageVersion, reliableMessagingVersion, binder.Channel, binder.GetInnerSession(), reply);
				session.ProcessInfo(info, null, throwException: true);
				session.VerifyDuplexProtocolElements(info, null, throwException: true);
				WsrmFault wsrmFault = (close ? WsrmUtilities.ValidateCloseSequenceResponse(session, closeRequestor.MessageId, info, connection.Last) : WsrmUtilities.ValidateTerminateSequenceResponse(session, terminateRequestor.MessageId, info, connection.Last));
				if (wsrmFault != null)
				{
					session.OnLocalFault(null, wsrmFault, null);
					throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(wsrmFault.CreateException());
				}
				return;
			}
			finally
			{
				reply.Close();
			}
		}
		throw Fx.AssertAndThrow("Reliable messaging version not supported.");
	}

	private void ProcessReply(Message reply, IReliableRequest request, long requestSequenceNumber)
	{
		WsrmMessageInfo wsrmMessageInfo = WsrmMessageInfo.Get(settings.MessageVersion, settings.ReliableMessagingVersion, binder.Channel, binder.GetInnerSession(), reply);
		if (!session.ProcessInfo(wsrmMessageInfo, null) || !session.VerifyDuplexProtocolElements(wsrmMessageInfo, null))
		{
			return;
		}
		bool flag = settings.ReliableMessagingVersion == ReliableMessagingVersion.WSReliableMessaging11;
		if (wsrmMessageInfo.WsrmHeaderFault != null)
		{
			wsrmMessageInfo.Message.Close();
			if (!(wsrmMessageInfo.WsrmHeaderFault is UnknownSequenceFault))
			{
				throw Fx.AssertAndThrow("Fault must be UnknownSequence fault.");
			}
			if (terminateRequestor == null)
			{
				throw Fx.AssertAndThrow("If we start getting UnknownSequence, terminateRequestor cannot be null.");
			}
			terminateRequestor.SetInfo(wsrmMessageInfo);
			return;
		}
		if (wsrmMessageInfo.AcknowledgementInfo == null)
		{
			WsrmFault wsrmFault = SequenceTerminatedFault.CreateProtocolFault(session.InputID, System.SR.SequenceTerminatedReplyMissingAcknowledgement, System.SR.ReplyMissingAcknowledgement);
			wsrmMessageInfo.Message.Close();
			session.OnLocalFault(wsrmFault.CreateException(), wsrmFault, null);
			return;
		}
		if (flag && wsrmMessageInfo.TerminateSequenceInfo != null)
		{
			UniqueId sequenceID = ((wsrmMessageInfo.TerminateSequenceInfo.Identifier == session.OutputID) ? session.InputID : session.OutputID);
			WsrmFault wsrmFault2 = SequenceTerminatedFault.CreateProtocolFault(sequenceID, System.SR.SequenceTerminatedUnsupportedTerminateSequence, System.SR.UnsupportedTerminateSequenceExceptionString);
			wsrmMessageInfo.Message.Close();
			session.OnLocalFault(wsrmFault2.CreateException(), wsrmFault2, null);
			return;
		}
		if (flag && wsrmMessageInfo.AcknowledgementInfo.Final)
		{
			wsrmMessageInfo.Message.Close();
			if (closeRequestor == null)
			{
				string unsupportedCloseExceptionString = System.SR.UnsupportedCloseExceptionString;
				string sequenceTerminatedUnsupportedClose = System.SR.SequenceTerminatedUnsupportedClose;
				WsrmFault wsrmFault3 = SequenceTerminatedFault.CreateProtocolFault(session.OutputID, sequenceTerminatedUnsupportedClose, unsupportedCloseExceptionString);
				session.OnLocalFault(wsrmFault3.CreateException(), wsrmFault3, null);
			}
			else
			{
				WsrmFault wsrmFault4 = WsrmUtilities.ValidateFinalAck(session, wsrmMessageInfo, connection.Last);
				if (wsrmFault4 == null)
				{
					closeRequestor.SetInfo(wsrmMessageInfo);
				}
				else
				{
					session.OnLocalFault(wsrmFault4.CreateException(), wsrmFault4, null);
				}
			}
			return;
		}
		int quotaRemaining = -1;
		if (settings.FlowControlEnabled)
		{
			quotaRemaining = wsrmMessageInfo.AcknowledgementInfo.BufferRemaining;
		}
		if (wsrmMessageInfo.SequencedMessageInfo != null && !ReliableInputConnection.CanMerge(wsrmMessageInfo.SequencedMessageInfo.SequenceNumber, ranges))
		{
			wsrmMessageInfo.Message.Close();
			return;
		}
		bool flag2 = replyAckConsistencyGuard != null && replyAckConsistencyGuard.Enter();
		try
		{
			connection.ProcessTransferred(requestSequenceNumber, wsrmMessageInfo.AcknowledgementInfo.Ranges, quotaRemaining);
			session.OnRemoteActivity(connection.Strategy.QuotaRemaining == 0);
			if (wsrmMessageInfo.SequencedMessageInfo != null)
			{
				lock (base.ThisLock)
				{
					ranges = ranges.MergeWith(wsrmMessageInfo.SequencedMessageInfo.SequenceNumber);
				}
			}
		}
		finally
		{
			if (flag2)
			{
				replyAckConsistencyGuard.Exit();
			}
		}
		if (request != null)
		{
			if (WsrmUtilities.IsWsrmAction(settings.ReliableMessagingVersion, wsrmMessageInfo.Action))
			{
				wsrmMessageInfo.Message.Close();
				request.Set(null);
			}
			else
			{
				request.Set(wsrmMessageInfo.Message);
			}
		}
		if (shutdownHandle != null && connection.CheckForTermination())
		{
			shutdownHandle.Set();
		}
		request?.Complete();
	}

	private async Task TerminateSequenceAsync(TimeSpan timeout)
	{
		CreateTerminateRequestor();
		Message message = await terminateRequestor.RequestAsync(timeout);
		if (message != null)
		{
			ProcessCloseOrTerminateReply(close: false, message);
		}
	}

	private void UnblockClose()
	{
		FaultPendingRequests();
		if (connection != null)
		{
			connection.Fault(this);
		}
		if (shutdownHandle != null)
		{
			shutdownHandle.Fault(this);
		}
		closeRequestor?.Fault(this);
		terminateRequestor?.Fault(this);
	}

	private Task WaitForShutdownAsync(TimeSpan timeout)
	{
		TimeoutHelper timeoutHelper = new TimeoutHelper(timeout);
		if (settings.ReliableMessagingVersion == ReliableMessagingVersion.WSReliableMessagingFebruary2005)
		{
			return shutdownHandle.WaitAsync(timeoutHelper.RemainingTime());
		}
		isLastKnown = true;
		return replyAckConsistencyGuard.CloseAsync(timeoutHelper.RemainingTime());
	}
}
