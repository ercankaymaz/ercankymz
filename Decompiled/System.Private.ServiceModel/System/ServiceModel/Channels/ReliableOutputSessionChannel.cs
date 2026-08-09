using System.Runtime;
using System.Threading.Tasks;

namespace System.ServiceModel.Channels;

internal abstract class ReliableOutputSessionChannel : OutputChannel, IOutputSessionChannel, IOutputChannel, IChannel, ICommunicationObject, ISessionChannel<IOutputSession>, IAsyncOutputSessionChannel, IAsyncOutputChannel, IAsyncCommunicationObject
{
	private IClientReliableChannelBinder _binder;

	private ChannelParameterCollection _channelParameters;

	private ReliableRequestor _closeRequestor;

	private Exception _maxRetryCountException;

	private ClientReliableSession _session;

	private ReliableRequestor _terminateRequestor;

	protected IReliableChannelBinder Binder => _binder;

	protected ReliableOutputConnection Connection { get; private set; }

	protected Exception MaxRetryCountException
	{
		set
		{
			_maxRetryCountException = value;
		}
	}

	protected ChannelReliableSession ReliableSession => _session;

	public override EndpointAddress RemoteAddress => _binder.RemoteAddress;

	protected abstract bool RequestAcks { get; }

	public IOutputSession Session => _session;

	public override Uri Via => _binder.Via;

	protected IReliableFactorySettings Settings { get; }

	protected ReliableOutputSessionChannel(ChannelManagerBase factory, IReliableFactorySettings settings, IClientReliableChannelBinder binder, FaultHelper faultHelper, LateBoundChannelParameterCollection channelParameters)
		: base(factory)
	{
		Settings = settings;
		_binder = binder;
		_session = new ClientReliableSession(this, settings, binder, faultHelper, null);
		_session.PollingCallback = PollingAsyncCallback;
		_session.UnblockChannelCloseCallback = UnblockClose;
		_binder.Faulted += OnBinderFaulted;
		_binder.OnException += OnBinderException;
		_channelParameters = channelParameters;
		channelParameters.SetChannel(this);
	}

	private async Task CloseSequenceAsync(TimeSpan timeout)
	{
		CreateCloseRequestor();
		ProcessCloseOrTerminateReply(close: true, await _closeRequestor.RequestAsync(timeout));
	}

	private void ConfigureRequestor(ReliableRequestor requestor)
	{
		requestor.MessageVersion = Settings.MessageVersion;
		requestor.Binder = _binder;
		requestor.SetRequestResponsePattern();
	}

	private void CreateCloseRequestor()
	{
		ReliableRequestor reliableRequestor = CreateRequestor();
		ConfigureRequestor(reliableRequestor);
		reliableRequestor.TimeoutString1Index = System.SR.TimeoutOnClose;
		reliableRequestor.MessageAction = WsrmIndex.GetCloseSequenceActionHeader(Settings.MessageVersion.Addressing);
		reliableRequestor.MessageBody = new CloseSequence(_session.OutputID, Connection.Last);
		lock (base.ThisLock)
		{
			ThrowIfClosed();
			_closeRequestor = reliableRequestor;
		}
	}

	protected abstract ReliableRequestor CreateRequestor();

	private void CreateTerminateRequestor()
	{
		ReliableRequestor reliableRequestor = CreateRequestor();
		ConfigureRequestor(reliableRequestor);
		ReliableMessagingVersion reliableMessagingVersion = Settings.ReliableMessagingVersion;
		reliableRequestor.MessageAction = WsrmIndex.GetTerminateSequenceActionHeader(Settings.MessageVersion.Addressing, reliableMessagingVersion);
		reliableRequestor.MessageBody = new TerminateSequence(reliableMessagingVersion, _session.OutputID, Connection.Last);
		lock (base.ThisLock)
		{
			ThrowIfClosed();
			_terminateRequestor = reliableRequestor;
			_session.CloseSession();
		}
	}

	public override T GetProperty<T>()
	{
		if (typeof(T) == typeof(IOutputSessionChannel))
		{
			return (T)(object)this;
		}
		if (typeof(T) == typeof(ChannelParameterCollection))
		{
			return (T)(object)_channelParameters;
		}
		T property = base.GetProperty<T>();
		if (property != null)
		{
			return property;
		}
		T property2 = _binder.Channel.GetProperty<T>();
		if (property2 == null && typeof(T) == typeof(FaultConverter))
		{
			return (T)(object)FaultConverter.GetDefaultFaultConverter(Settings.MessageVersion);
		}
		return property2;
	}

	protected override void OnAbort()
	{
		if (Connection != null)
		{
			Connection.Abort(this);
		}
		_closeRequestor?.Abort(this);
		_terminateRequestor?.Abort(this);
		_session.Abort();
	}

	protected override IAsyncResult OnBeginClose(TimeSpan timeout, AsyncCallback callback, object state)
	{
		return CommunicationObjectInternal.OnBeginClose(this, timeout, callback, state);
	}

	protected override IAsyncResult OnBeginOpen(TimeSpan timeout, AsyncCallback callback, object state)
	{
		return CommunicationObjectInternal.OnBeginOpen(this, timeout, callback, state);
	}

	private void OnBinderException(IReliableChannelBinder sender, Exception exception)
	{
		if (exception is QuotaExceededException)
		{
			if (base.State == CommunicationState.Opening || base.State == CommunicationState.Opened || base.State == CommunicationState.Closing)
			{
				_session.OnLocalFault(exception, SequenceTerminatedFault.CreateQuotaExceededFault(_session.OutputID), null);
			}
		}
		else
		{
			AddPendingException(exception);
		}
	}

	private void OnBinderFaulted(IReliableChannelBinder sender, Exception exception)
	{
		_binder.Abort();
		if (base.State == CommunicationState.Opening || base.State == CommunicationState.Opened || base.State == CommunicationState.Closing)
		{
			exception = new CommunicationException(System.SR.EarlySecurityFaulted, exception);
			_session.OnLocalFault(exception, (Message)null, (RequestContext)null);
		}
	}

	protected override void OnClose(TimeSpan timeout)
	{
		CommunicationObjectInternal.OnClose(this, timeout);
	}

	protected internal override async Task OnCloseAsync(TimeSpan timeout)
	{
		TimeoutHelper timeoutHelper = new TimeoutHelper(timeout);
		await Connection.CloseAsync(timeoutHelper.RemainingTime());
		if (Settings.ReliableMessagingVersion == ReliableMessagingVersion.WSReliableMessaging11)
		{
			await CloseSequenceAsync(timeoutHelper.RemainingTime());
		}
		await TerminateSequenceAsync(timeoutHelper.RemainingTime());
		await _session.CloseAsync(timeoutHelper.RemainingTime());
		await _binder.CloseAsync(timeoutHelper.RemainingTime(), MaskingMode.Handled);
	}

	protected override void OnClosed()
	{
		base.OnClosed();
		_binder.Faulted -= OnBinderFaulted;
	}

	protected abstract Task OnConnectionSendAsync(Message message, TimeSpan timeout, bool saveHandledException, bool maskUnhandledException);

	private async Task OnConnectionSendAckRequestedAsyncHandler(TimeSpan timeout)
	{
		_session.OnLocalActivity();
		using Message message = WsrmUtilities.CreateAckRequestedMessage(Settings.MessageVersion, Settings.ReliableMessagingVersion, ReliableSession.OutputID);
		await OnConnectionSendAsync(message, timeout, saveHandledException: false, maskUnhandledException: true);
	}

	private async Task OnConnectionSendAsyncHandler(MessageAttemptInfo attemptInfo, TimeSpan timeout, bool maskUnhandledException)
	{
		using (attemptInfo.Message)
		{
			if (attemptInfo.RetryCount > Settings.MaxRetryCount)
			{
				if (WcfEventSource.Instance.MaxRetryCyclesExceededIsEnabled())
				{
					WcfEventSource.Instance.MaxRetryCyclesExceeded(System.SR.MaximumRetryCountExceeded);
				}
				_session.OnLocalFault(new CommunicationException(System.SR.MaximumRetryCountExceeded, _maxRetryCountException), SequenceTerminatedFault.CreateMaxRetryCountExceededFault(_session.OutputID), null);
			}
			else
			{
				_session.OnLocalActivity();
				await OnConnectionSendAsync(attemptInfo.Message, timeout, attemptInfo.RetryCount == Settings.MaxRetryCount, maskUnhandledException);
			}
		}
	}

	protected abstract Task OnConnectionSendMessageAsync(Message message, TimeSpan timeout, MaskingMode maskingMode);

	private void OnComponentFaulted(Exception faultException, WsrmFault fault)
	{
		_session.OnLocalFault(faultException, fault, null);
	}

	private void OnComponentException(Exception exception)
	{
		ReliableSession.OnUnknownException(exception);
	}

	protected override void OnEndClose(IAsyncResult result)
	{
		CommunicationObjectInternal.OnEnd(result);
	}

	protected override void OnEndOpen(IAsyncResult result)
	{
		CommunicationObjectInternal.OnEnd(result);
	}

	protected override void OnFaulted()
	{
		_session.OnFaulted();
		UnblockClose();
		base.OnFaulted();
	}

	protected override void OnOpen(TimeSpan timeout)
	{
		CommunicationObjectInternal.OnOpen(this, timeout);
	}

	protected internal override async Task OnOpenAsync(TimeSpan timeout)
	{
		TimeoutHelper timeoutHelper = new TimeoutHelper(timeout);
		bool throwing = true;
		try
		{
			await _binder.OpenAsync(timeoutHelper.RemainingTime());
			await _session.OpenAsync(timeoutHelper.RemainingTime());
			throwing = false;
		}
		finally
		{
			if (throwing)
			{
				await Binder.CloseAsync(timeoutHelper.RemainingTime());
			}
		}
	}

	protected override async Task OnSendAsync(Message message, TimeSpan timeout)
	{
		if (!(await Connection.AddMessageAsync(message, timeout, null)))
		{
			ThrowInvalidAddException();
		}
	}

	protected override void OnSend(Message message, TimeSpan timeout)
	{
		OnSendAsync(message, timeout).WaitForCompletionNoSpin();
	}

	protected override void OnOpened()
	{
		base.OnOpened();
		Connection = new ReliableOutputConnection(_session.OutputID, Settings.MaxTransferWindowSize, Settings.MessageVersion, Settings.ReliableMessagingVersion, _session.InitiationTime, RequestAcks, base.DefaultSendTimeout);
		ReliableOutputConnection connection = Connection;
		connection.Faulted = (ComponentFaultedHandler)Delegate.Combine(connection.Faulted, new ComponentFaultedHandler(OnComponentFaulted));
		ReliableOutputConnection connection2 = Connection;
		connection2.OnException = (ComponentExceptionHandler)Delegate.Combine(connection2.OnException, new ComponentExceptionHandler(OnComponentException));
		Connection.SendAsyncHandler = OnConnectionSendAsyncHandler;
		Connection.SendAckRequestedAsyncHandler = OnConnectionSendAckRequestedAsyncHandler;
	}

	private async Task PollingAsyncCallback()
	{
		using Message request = WsrmUtilities.CreateAckRequestedMessage(Settings.MessageVersion, Settings.ReliableMessagingVersion, ReliableSession.OutputID);
		await OnConnectionSendMessageAsync(request, base.DefaultSendTimeout, MaskingMode.All);
	}

	private void ProcessCloseOrTerminateReply(bool close, Message reply)
	{
		if (reply == null)
		{
			throw Fx.AssertAndThrow("Argument reply cannot be null.");
		}
		ReliableRequestor reliableRequestor = (close ? _closeRequestor : _terminateRequestor);
		WsrmMessageInfo info = reliableRequestor.GetInfo();
		if (info != null)
		{
			return;
		}
		try
		{
			info = WsrmMessageInfo.Get(Settings.MessageVersion, Settings.ReliableMessagingVersion, _binder.Channel, _binder.GetInnerSession(), reply);
			ReliableSession.ProcessInfo(info, null, throwException: true);
			ReliableSession.VerifyDuplexProtocolElements(info, null, throwException: true);
			WsrmFault wsrmFault = (close ? WsrmUtilities.ValidateCloseSequenceResponse(_session, reliableRequestor.MessageId, info, Connection.Last) : WsrmUtilities.ValidateTerminateSequenceResponse(_session, reliableRequestor.MessageId, info, Connection.Last));
			if (wsrmFault != null)
			{
				ReliableSession.OnLocalFault(null, wsrmFault, null);
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(wsrmFault.CreateException());
			}
		}
		finally
		{
			reply.Close();
		}
	}

	protected async Task ProcessMessageAsync(Message message)
	{
		bool closeMessage = true;
		WsrmMessageInfo messageInfo = WsrmMessageInfo.Get(Settings.MessageVersion, Settings.ReliableMessagingVersion, _binder.Channel, _binder.GetInnerSession(), message);
		bool flag = Settings.ReliableMessagingVersion == ReliableMessagingVersion.WSReliableMessaging11;
		try
		{
			if (!_session.ProcessInfo(messageInfo, null))
			{
				closeMessage = false;
				return;
			}
			if (!ReliableSession.VerifySimplexProtocolElements(messageInfo, null))
			{
				closeMessage = false;
				return;
			}
			bool flag2 = false;
			if (messageInfo.AcknowledgementInfo != null)
			{
				flag2 = flag && messageInfo.AcknowledgementInfo.Final;
				int quotaRemaining = -1;
				if (Settings.FlowControlEnabled)
				{
					quotaRemaining = messageInfo.AcknowledgementInfo.BufferRemaining;
				}
				Connection.ProcessTransferred(messageInfo.AcknowledgementInfo.Ranges, quotaRemaining);
			}
			if (flag)
			{
				WsrmFault wsrmFault = null;
				if (messageInfo.TerminateSequenceResponseInfo != null)
				{
					wsrmFault = WsrmUtilities.ValidateTerminateSequenceResponse(_session, _terminateRequestor.MessageId, messageInfo, Connection.Last);
					if (wsrmFault == null)
					{
						wsrmFault = ProcessRequestorResponse(_terminateRequestor, "TerminateSequence", messageInfo);
					}
				}
				else if (messageInfo.CloseSequenceResponseInfo != null)
				{
					wsrmFault = WsrmUtilities.ValidateCloseSequenceResponse(_session, _closeRequestor.MessageId, messageInfo, Connection.Last);
					if (wsrmFault == null)
					{
						wsrmFault = ProcessRequestorResponse(_closeRequestor, "CloseSequence", messageInfo);
					}
				}
				else if (messageInfo.TerminateSequenceInfo != null)
				{
					if (!WsrmUtilities.ValidateWsrmRequest(_session, messageInfo.TerminateSequenceInfo, _binder, null))
					{
						return;
					}
					WsrmAcknowledgmentInfo acknowledgementInfo = messageInfo.AcknowledgementInfo;
					wsrmFault = WsrmUtilities.ValidateFinalAckExists(_session, acknowledgementInfo);
					if (wsrmFault == null && !Connection.IsFinalAckConsistent(acknowledgementInfo.Ranges))
					{
						wsrmFault = new InvalidAcknowledgementFault(_session.OutputID, acknowledgementInfo.Ranges);
					}
					if (wsrmFault == null)
					{
						Message response = WsrmUtilities.CreateTerminateResponseMessage(Settings.MessageVersion, messageInfo.TerminateSequenceInfo.MessageId, _session.OutputID);
						try
						{
							await OnConnectionSendAsync(response, base.DefaultSendTimeout, saveHandledException: false, maskUnhandledException: true);
						}
						finally
						{
							response.Close();
						}
						_session.OnRemoteFault(new ProtocolException(System.SR.UnsupportedTerminateSequenceExceptionString));
						return;
					}
				}
				else if (flag2)
				{
					if (_closeRequestor == null)
					{
						string unsupportedCloseExceptionString = System.SR.UnsupportedCloseExceptionString;
						string sequenceTerminatedUnsupportedClose = System.SR.SequenceTerminatedUnsupportedClose;
						wsrmFault = SequenceTerminatedFault.CreateProtocolFault(_session.OutputID, sequenceTerminatedUnsupportedClose, unsupportedCloseExceptionString);
					}
					else
					{
						wsrmFault = WsrmUtilities.ValidateFinalAck(_session, messageInfo, Connection.Last);
						if (wsrmFault == null)
						{
							_closeRequestor.SetInfo(messageInfo);
						}
					}
				}
				else if (messageInfo.WsrmHeaderFault != null)
				{
					if (!(messageInfo.WsrmHeaderFault is UnknownSequenceFault))
					{
						throw Fx.AssertAndThrow("Fault must be UnknownSequence fault.");
					}
					if (_terminateRequestor == null)
					{
						throw Fx.AssertAndThrow("In wsrm11, if we start getting UnknownSequence, terminateRequestor cannot be null.");
					}
					_terminateRequestor.SetInfo(messageInfo);
				}
				if (wsrmFault != null)
				{
					_session.OnLocalFault(wsrmFault.CreateException(), wsrmFault, null);
					return;
				}
			}
			_session.OnRemoteActivity(Connection.Strategy.QuotaRemaining == 0);
		}
		finally
		{
			if (closeMessage)
			{
				messageInfo.Message.Close();
			}
		}
	}

	protected abstract WsrmFault ProcessRequestorResponse(ReliableRequestor requestor, string requestName, WsrmMessageInfo info);

	private async Task TerminateSequenceAsync(TimeSpan timeout)
	{
		ReliableMessagingVersion reliableMessagingVersion = Settings.ReliableMessagingVersion;
		if (reliableMessagingVersion == ReliableMessagingVersion.WSReliableMessagingFebruary2005)
		{
			_session.CloseSession();
			Message message = WsrmUtilities.CreateTerminateMessage(Settings.MessageVersion, reliableMessagingVersion, _session.OutputID);
			await OnConnectionSendMessageAsync(message, timeout, MaskingMode.Handled);
			return;
		}
		if (reliableMessagingVersion == ReliableMessagingVersion.WSReliableMessaging11)
		{
			CreateTerminateRequestor();
			Message message2 = await _terminateRequestor.RequestAsync(timeout);
			if (message2 != null)
			{
				ProcessCloseOrTerminateReply(close: false, message2);
			}
			return;
		}
		throw Fx.AssertAndThrow("Reliable messaging version not supported.");
	}

	private void ThrowInvalidAddException()
	{
		if (base.State == CommunicationState.Faulted)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(GetTerminalException());
		}
		throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(CreateClosedException());
	}

	private void UnblockClose()
	{
		if (Connection != null)
		{
			Connection.Fault(this);
		}
		_closeRequestor?.Fault(this);
		_terminateRequestor?.Fault(this);
	}
}
