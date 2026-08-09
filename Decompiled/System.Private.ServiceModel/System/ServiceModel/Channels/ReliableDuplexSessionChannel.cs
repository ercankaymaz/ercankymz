using System.Runtime;
using System.Threading.Tasks;
using System.Xml;

namespace System.ServiceModel.Channels;

internal abstract class ReliableDuplexSessionChannel : DuplexChannel, IDuplexSessionChannel, IDuplexChannel, IInputChannel, IChannel, ICommunicationObject, IOutputChannel, ISessionChannel<IDuplexSession>, IAsyncDuplexSessionChannel, IAsyncDuplexChannel, IAsyncInputChannel, IAsyncCommunicationObject, IAsyncOutputChannel, ISessionChannel<IAsyncDuplexSession>
{
	private bool _acknowledgementScheduled;

	private IOThreadTimer _acknowledgementTimer;

	private ulong _ackVersion = 1uL;

	private bool _advertisedZero;

	private InterruptibleWaitObject _closeOutputWaitObject;

	private SendWaitReliableRequestor _closeRequestor;

	private DeliveryStrategy<Message> _deliveryStrategy;

	private Guard _guard = new Guard(int.MaxValue);

	private ReliableInputConnection _inputConnection;

	private Exception _maxRetryCountException;

	private int _pendingAcknowledgements;

	private SendWaitReliableRequestor _terminateRequestor;

	private static Action<object> s_processMessageStatic = ProcessMessageStatic;

	protected static Func<object, Task> s_startReceivingAsyncStatic = StartReceivingAsyncStatic;

	public IReliableChannelBinder Binder { get; }

	public override EndpointAddress LocalAddress => Binder.LocalAddress;

	protected ReliableOutputConnection OutputConnection { get; private set; }

	protected UniqueId OutputID => ReliableSession.OutputID;

	protected ChannelReliableSession ReliableSession { get; private set; }

	public override EndpointAddress RemoteAddress => Binder.RemoteAddress;

	protected IReliableFactorySettings Settings { get; }

	public override Uri Via => RemoteAddress.Uri;

	public IDuplexSession Session => (IDuplexSession)ReliableSession;

	IAsyncDuplexSession ISessionChannel<IAsyncDuplexSession>.Session => (IAsyncDuplexSession)ReliableSession;

	protected ReliableDuplexSessionChannel(ChannelManagerBase manager, IReliableFactorySettings settings, IReliableChannelBinder binder)
		: base(manager, binder.LocalAddress)
	{
		Binder = binder;
		Settings = settings;
		_acknowledgementTimer = new IOThreadTimer((Func<object, Task>)OnAcknowledgementTimeoutElapsedAsync, (object)null, true);
		Binder.Faulted += OnBinderFaulted;
		Binder.OnException += OnBinderException;
	}

	private void AddPendingAcknowledgements(Message message)
	{
		using (base.ThisAsyncLock.TakeLock())
		{
			if (_pendingAcknowledgements > 0)
			{
				_acknowledgementTimer.Cancel();
				_acknowledgementScheduled = false;
				_pendingAcknowledgements = 0;
				_ackVersion++;
				int bufferRemaining = GetBufferRemaining();
				WsrmUtilities.AddAcknowledgementHeader(Settings.ReliableMessagingVersion, message, ReliableSession.InputID, _inputConnection.Ranges, _inputConnection.IsLastKnown, bufferRemaining);
			}
		}
	}

	private Task CloseSequenceAsync(TimeSpan timeout)
	{
		CreateCloseRequestor();
		return _closeRequestor.RequestAsync(timeout);
	}

	private void ConfigureRequestor(ReliableRequestor requestor)
	{
		requestor.MessageVersion = Settings.MessageVersion;
		requestor.Binder = Binder;
		requestor.SetRequestResponsePattern();
	}

	private Message CreateAcknowledgmentMessage()
	{
		using (base.ThisAsyncLock.TakeLock())
		{
			_ackVersion++;
		}
		int bufferRemaining = GetBufferRemaining();
		Message result = WsrmUtilities.CreateAcknowledgmentMessage(Settings.MessageVersion, Settings.ReliableMessagingVersion, ReliableSession.InputID, _inputConnection.Ranges, _inputConnection.IsLastKnown, bufferRemaining);
		if (WcfEventSource.Instance.SequenceAcknowledgementSentIsEnabled())
		{
			WcfEventSource.Instance.SequenceAcknowledgementSent(ReliableSession.Id);
		}
		return result;
	}

	private void CreateCloseRequestor()
	{
		SendWaitReliableRequestor sendWaitReliableRequestor = new SendWaitReliableRequestor();
		ConfigureRequestor(sendWaitReliableRequestor);
		sendWaitReliableRequestor.TimeoutString1Index = System.SR.TimeoutOnClose;
		sendWaitReliableRequestor.MessageAction = WsrmIndex.GetCloseSequenceActionHeader(Settings.MessageVersion.Addressing);
		sendWaitReliableRequestor.MessageBody = new CloseSequence(ReliableSession.OutputID, OutputConnection.Last);
		using (base.ThisAsyncLock.TakeLock())
		{
			ThrowIfClosed();
			_closeRequestor = sendWaitReliableRequestor;
		}
	}

	private void CreateTerminateRequestor()
	{
		SendWaitReliableRequestor sendWaitReliableRequestor = new SendWaitReliableRequestor();
		ConfigureRequestor(sendWaitReliableRequestor);
		ReliableMessagingVersion reliableMessagingVersion = Settings.ReliableMessagingVersion;
		sendWaitReliableRequestor.MessageAction = WsrmIndex.GetTerminateSequenceActionHeader(Settings.MessageVersion.Addressing, reliableMessagingVersion);
		sendWaitReliableRequestor.MessageBody = new TerminateSequence(reliableMessagingVersion, ReliableSession.OutputID, OutputConnection.Last);
		using (base.ThisAsyncLock.TakeLock())
		{
			ThrowIfClosed();
			_terminateRequestor = sendWaitReliableRequestor;
			if (_inputConnection.IsLastKnown)
			{
				ReliableSession.CloseSession();
			}
		}
	}

	private int GetBufferRemaining()
	{
		int num = -1;
		if (Settings.FlowControlEnabled)
		{
			num = Settings.MaxTransferWindowSize - _deliveryStrategy.EnqueuedCount;
			_advertisedZero = num == 0;
		}
		return num;
	}

	public override T GetProperty<T>()
	{
		if (typeof(T) == typeof(IDuplexSessionChannel))
		{
			return (T)(object)this;
		}
		T property = base.GetProperty<T>();
		if (property != null)
		{
			return property;
		}
		T property2 = Binder.Channel.GetProperty<T>();
		if (property2 == null && typeof(T) == typeof(FaultConverter))
		{
			return (T)(object)FaultConverter.GetDefaultFaultConverter(Settings.MessageVersion);
		}
		return property2;
	}

	private async Task InternalCloseOutputSessionAsync(TimeSpan timeout)
	{
		TimeoutHelper timeoutHelper = new TimeoutHelper(timeout);
		await OutputConnection.CloseAsync(timeoutHelper.RemainingTime());
		if (Settings.ReliableMessagingVersion == ReliableMessagingVersion.WSReliableMessaging11)
		{
			await CloseSequenceAsync(timeoutHelper.RemainingTime());
		}
		await TerminateSequenceAsync(timeoutHelper.RemainingTime());
	}

	protected virtual void OnRemoteActivity()
	{
		ReliableSession.OnRemoteActivity(fastPolling: false);
	}

	private WsrmFault ProcessCloseOrTerminateSequenceResponse(bool close, WsrmMessageInfo info)
	{
		SendWaitReliableRequestor sendWaitReliableRequestor = (close ? _closeRequestor : _terminateRequestor);
		if (sendWaitReliableRequestor != null)
		{
			WsrmFault wsrmFault = (close ? WsrmUtilities.ValidateCloseSequenceResponse(ReliableSession, _closeRequestor.MessageId, info, OutputConnection.Last) : WsrmUtilities.ValidateTerminateSequenceResponse(ReliableSession, _terminateRequestor.MessageId, info, OutputConnection.Last));
			if (wsrmFault != null)
			{
				return wsrmFault;
			}
			sendWaitReliableRequestor.SetInfo(info);
			return null;
		}
		string p = (close ? "CloseSequence" : "TerminateSequence");
		string faultReason = System.SR.Format(System.SR.ReceivedResponseBeforeRequestFaultString, p);
		string exceptionMessage = System.SR.Format(System.SR.ReceivedResponseBeforeRequestExceptionString, p);
		return SequenceTerminatedFault.CreateProtocolFault(ReliableSession.OutputID, faultReason, exceptionMessage);
	}

	protected async Task ProcessDuplexMessageAsync(WsrmMessageInfo info)
	{
		bool closeMessage = true;
		try
		{
			bool flag = Settings.ReliableMessagingVersion == ReliableMessagingVersion.WSReliableMessagingFebruary2005;
			bool flag2 = Settings.ReliableMessagingVersion == ReliableMessagingVersion.WSReliableMessaging11;
			bool flag3 = false;
			if (OutputConnection != null && info.AcknowledgementInfo != null)
			{
				flag3 = flag2 && info.AcknowledgementInfo.Final;
				int quotaRemaining = -1;
				if (Settings.FlowControlEnabled)
				{
					quotaRemaining = info.AcknowledgementInfo.BufferRemaining;
				}
				OutputConnection.ProcessTransferred(info.AcknowledgementInfo.Ranges, quotaRemaining);
			}
			OnRemoteActivity();
			bool flag4 = info.AckRequestedInfo != null;
			bool flag5 = false;
			bool terminate = false;
			bool flag6 = false;
			ulong num = 0uL;
			WsrmFault wsrmFault = null;
			Message message = null;
			Exception remoteFaultException = null;
			if (info.SequencedMessageInfo != null)
			{
				bool flag7 = false;
				using (base.ThisAsyncLock.TakeLock())
				{
					if (base.Aborted || base.State == CommunicationState.Faulted)
					{
						return;
					}
					long sequenceNumber = info.SequencedMessageInfo.SequenceNumber;
					bool isLast = flag && info.SequencedMessageInfo.LastMessage;
					if (!_inputConnection.IsValid(sequenceNumber, isLast))
					{
						if (flag)
						{
							wsrmFault = new LastMessageNumberExceededFault(ReliableSession.InputID);
						}
						else
						{
							message = new SequenceClosedFault(ReliableSession.InputID).CreateMessage(Settings.MessageVersion, Settings.ReliableMessagingVersion);
							flag5 = true;
							OnMessageDropped();
						}
					}
					else if (_inputConnection.Ranges.Contains(sequenceNumber))
					{
						OnMessageDropped();
						flag4 = true;
					}
					else if (flag && info.Action == "http://schemas.xmlsoap.org/ws/2005/02/rm/LastMessage")
					{
						_inputConnection.Merge(sequenceNumber, isLast);
						if (_inputConnection.AllAdded)
						{
							flag6 = true;
							if (OutputConnection.CheckForTermination())
							{
								ReliableSession.CloseSession();
							}
						}
					}
					else if (base.State == CommunicationState.Closing)
					{
						if (flag)
						{
							wsrmFault = SequenceTerminatedFault.CreateProtocolFault(ReliableSession.InputID, System.SR.SequenceTerminatedSessionClosedBeforeDone, System.SR.SessionClosedBeforeDone);
						}
						else
						{
							message = new SequenceClosedFault(ReliableSession.InputID).CreateMessage(Settings.MessageVersion, Settings.ReliableMessagingVersion);
							flag5 = true;
							OnMessageDropped();
						}
					}
					else if (_deliveryStrategy.CanEnqueue(sequenceNumber) && (Settings.Ordered || _inputConnection.CanMerge(sequenceNumber)))
					{
						_inputConnection.Merge(sequenceNumber, isLast);
						flag7 = _deliveryStrategy.Enqueue(info.Message, sequenceNumber);
						closeMessage = false;
						num = _ackVersion;
						_pendingAcknowledgements++;
						if (_inputConnection.AllAdded)
						{
							flag6 = true;
							if (OutputConnection.CheckForTermination())
							{
								ReliableSession.CloseSession();
							}
						}
					}
					else
					{
						OnMessageDropped();
					}
					if (_inputConnection.IsLastKnown || _pendingAcknowledgements == Settings.MaxTransferWindowSize)
					{
						flag4 = true;
					}
					if ((flag4 || (_pendingAcknowledgements > 0 && wsrmFault == null)) && !_acknowledgementScheduled)
					{
						_acknowledgementScheduled = true;
						_acknowledgementTimer.Set(Settings.AcknowledgementInterval);
					}
				}
				if (flag7)
				{
					Dispatch();
				}
			}
			else if (flag && info.TerminateSequenceInfo != null)
			{
				bool flag8;
				using (base.ThisAsyncLock.TakeLock())
				{
					flag8 = !_inputConnection.Terminate();
				}
				if (flag8)
				{
					wsrmFault = SequenceTerminatedFault.CreateProtocolFault(ReliableSession.InputID, System.SR.SequenceTerminatedEarlyTerminateSequence, System.SR.EarlyTerminateSequence);
				}
			}
			else if (flag2)
			{
				if ((info.TerminateSequenceInfo != null && info.TerminateSequenceInfo.Identifier == ReliableSession.InputID) || info.CloseSequenceInfo != null)
				{
					bool flag9 = info.TerminateSequenceInfo != null;
					WsrmRequestInfo wsrmRequestInfo = (flag9 ? ((WsrmRequestInfo)info.TerminateSequenceInfo) : ((WsrmRequestInfo)info.CloseSequenceInfo));
					long num2 = (flag9 ? info.TerminateSequenceInfo.LastMsgNumber : info.CloseSequenceInfo.LastMsgNumber);
					if (!WsrmUtilities.ValidateWsrmRequest(ReliableSession, wsrmRequestInfo, Binder, null))
					{
						return;
					}
					bool isLastLargeEnough = true;
					bool flag10 = true;
					using (base.ThisAsyncLock.TakeLock())
					{
						if (!_inputConnection.IsLastKnown)
						{
							if (flag9)
							{
								if (_inputConnection.SetTerminateSequenceLast(num2, out isLastLargeEnough))
								{
									flag6 = true;
								}
								else if (isLastLargeEnough)
								{
									remoteFaultException = new ProtocolException(System.SR.EarlyTerminateSequence);
								}
							}
							else
							{
								flag6 = _inputConnection.SetCloseSequenceLast(num2);
								isLastLargeEnough = flag6;
							}
							if (flag6)
							{
								ReliableSession.SetFinalAck(_inputConnection.Ranges);
								if (_terminateRequestor != null)
								{
									ReliableSession.CloseSession();
								}
								_deliveryStrategy.Dispose();
							}
						}
						else
						{
							flag10 = num2 == _inputConnection.Last;
							if (flag9 && flag10 && _inputConnection.IsSequenceClosed)
							{
								terminate = true;
							}
						}
					}
					if (!isLastLargeEnough)
					{
						string sequenceTerminatedSmallLastMsgNumber = System.SR.SequenceTerminatedSmallLastMsgNumber;
						string smallLastMsgNumberExceptionString = System.SR.SmallLastMsgNumberExceptionString;
						wsrmFault = SequenceTerminatedFault.CreateProtocolFault(ReliableSession.InputID, sequenceTerminatedSmallLastMsgNumber, smallLastMsgNumberExceptionString);
					}
					else if (!flag10)
					{
						string sequenceTerminatedInconsistentLastMsgNumber = System.SR.SequenceTerminatedInconsistentLastMsgNumber;
						string inconsistentLastMsgNumberExceptionString = System.SR.InconsistentLastMsgNumberExceptionString;
						wsrmFault = SequenceTerminatedFault.CreateProtocolFault(ReliableSession.InputID, sequenceTerminatedInconsistentLastMsgNumber, inconsistentLastMsgNumberExceptionString);
					}
					else
					{
						message = (flag9 ? WsrmUtilities.CreateTerminateResponseMessage(Settings.MessageVersion, wsrmRequestInfo.MessageId, ReliableSession.InputID) : WsrmUtilities.CreateCloseSequenceResponse(Settings.MessageVersion, wsrmRequestInfo.MessageId, ReliableSession.InputID));
						flag5 = true;
					}
				}
				else if (info.TerminateSequenceInfo != null)
				{
					wsrmFault = SequenceTerminatedFault.CreateProtocolFault(ReliableSession.InputID, System.SR.SequenceTerminatedUnsupportedTerminateSequence, System.SR.UnsupportedTerminateSequenceExceptionString);
				}
				else if (info.TerminateSequenceResponseInfo != null)
				{
					wsrmFault = ProcessCloseOrTerminateSequenceResponse(close: false, info);
				}
				else if (info.CloseSequenceResponseInfo != null)
				{
					wsrmFault = ProcessCloseOrTerminateSequenceResponse(close: true, info);
				}
				else if (flag3)
				{
					if (_closeRequestor == null)
					{
						string unsupportedCloseExceptionString = System.SR.UnsupportedCloseExceptionString;
						string sequenceTerminatedUnsupportedClose = System.SR.SequenceTerminatedUnsupportedClose;
						wsrmFault = SequenceTerminatedFault.CreateProtocolFault(ReliableSession.OutputID, sequenceTerminatedUnsupportedClose, unsupportedCloseExceptionString);
					}
					else
					{
						wsrmFault = WsrmUtilities.ValidateFinalAck(ReliableSession, info, OutputConnection.Last);
						if (wsrmFault == null)
						{
							_closeRequestor.SetInfo(info);
						}
					}
				}
				else if (info.WsrmHeaderFault != null)
				{
					if (!(info.WsrmHeaderFault is UnknownSequenceFault))
					{
						throw Fx.AssertAndThrow("Fault must be UnknownSequence fault.");
					}
					if (_terminateRequestor == null)
					{
						throw Fx.AssertAndThrow("In wsrm11, if we start getting UnknownSequence, terminateRequestor cannot be null.");
					}
					_terminateRequestor.SetInfo(info);
				}
			}
			if (wsrmFault != null)
			{
				ReliableSession.OnLocalFault(wsrmFault.CreateException(), wsrmFault, null);
				return;
			}
			if (flag6)
			{
				ActionItem.Schedule((Action<object>)ShutdownCallback, (object)null);
			}
			if (message != null)
			{
				if (flag5)
				{
					WsrmUtilities.AddAcknowledgementHeader(Settings.ReliableMessagingVersion, message, ReliableSession.InputID, _inputConnection.Ranges, final: true, GetBufferRemaining());
				}
				else if (flag4)
				{
					AddPendingAcknowledgements(message);
				}
			}
			else if (flag4)
			{
				using (base.ThisAsyncLock.TakeLock())
				{
					if (num != 0L && num != _ackVersion)
					{
						return;
					}
					if (_acknowledgementScheduled)
					{
						_acknowledgementTimer.Cancel();
						_acknowledgementScheduled = false;
					}
					_pendingAcknowledgements = 0;
				}
				message = CreateAcknowledgmentMessage();
			}
			if (message != null)
			{
				using (message)
				{
					if (_guard.Enter())
					{
						try
						{
							await Binder.SendAsync(message, base.DefaultSendTimeout);
						}
						finally
						{
							_guard.Exit();
						}
					}
				}
			}
			if (terminate)
			{
				using (base.ThisAsyncLock.TakeLock())
				{
					_inputConnection.Terminate();
				}
			}
			if (remoteFaultException != null)
			{
				ReliableSession.OnRemoteFault(remoteFaultException);
			}
		}
		finally
		{
			if (closeMessage)
			{
				info.Message.Close();
			}
		}
	}

	private static void ProcessMessageStatic(object state)
	{
		var (reliableDuplexSessionChannel, info) = ((ReliableDuplexSessionChannel, WsrmMessageInfo))state;
		reliableDuplexSessionChannel.ProcessMessageAsync(info);
	}

	protected abstract Task ProcessMessageAsync(WsrmMessageInfo info);

	protected override void OnAbort()
	{
		if (OutputConnection != null)
		{
			OutputConnection.Abort(this);
		}
		if (_inputConnection != null)
		{
			_inputConnection.Abort(this);
		}
		_guard.Abort();
		_closeRequestor?.Abort(this);
		_terminateRequestor?.Abort(this);
		ReliableSession.Abort();
	}

	private async Task OnAcknowledgementTimeoutElapsedAsync(object state)
	{
		await using (await base.ThisAsyncLock.TakeLockAsync())
		{
			_acknowledgementScheduled = false;
			_pendingAcknowledgements = 0;
			if (base.State == CommunicationState.Closing || base.State == CommunicationState.Closed || base.State == CommunicationState.Faulted)
			{
				return;
			}
		}
		if (!_guard.Enter())
		{
			return;
		}
		try
		{
			using Message message = CreateAcknowledgmentMessage();
			await Binder.SendAsync(message, base.DefaultSendTimeout);
		}
		finally
		{
			_guard.Exit();
		}
	}

	protected override IAsyncResult OnBeginClose(TimeSpan timeout, AsyncCallback callback, object state)
	{
		return OnCloseAsync(timeout).ToApm(callback, state);
	}

	private void OnBinderException(IReliableChannelBinder sender, Exception exception)
	{
		if (exception is QuotaExceededException)
		{
			if (base.State == CommunicationState.Opening || base.State == CommunicationState.Opened || base.State == CommunicationState.Closing)
			{
				ReliableSession.OnLocalFault(exception, SequenceTerminatedFault.CreateQuotaExceededFault(ReliableSession.OutputID), null);
			}
		}
		else
		{
			EnqueueAndDispatch(exception, null, canDispatchOnThisThread: false);
		}
	}

	private void OnBinderFaulted(IReliableChannelBinder sender, Exception exception)
	{
		Binder.Abort();
		if (base.State == CommunicationState.Opening || base.State == CommunicationState.Opened || base.State == CommunicationState.Closing)
		{
			exception = new CommunicationException(System.SR.EarlySecurityFaulted, exception);
			ReliableSession.OnLocalFault(exception, (Message)null, (RequestContext)null);
		}
	}

	protected internal override async Task OnCloseAsync(TimeSpan timeout)
	{
		ThrowIfCloseInvalid();
		TimeoutHelper timeoutHelper = new TimeoutHelper(timeout);
		if (OutputConnection != null)
		{
			if (_closeOutputWaitObject == null)
			{
				await InternalCloseOutputSessionAsync(timeoutHelper.RemainingTime());
			}
			else
			{
				await _closeOutputWaitObject.WaitAsync(timeoutHelper.RemainingTime());
			}
			await _inputConnection.CloseAsync(timeoutHelper.RemainingTime());
		}
		await _guard.CloseAsync(timeoutHelper.RemainingTime());
		await ReliableSession.CloseAsync(timeoutHelper.RemainingTime());
		await Binder.CloseAsync(timeoutHelper.RemainingTime(), MaskingMode.Handled);
		await base.OnCloseAsync(timeoutHelper.RemainingTime());
	}

	protected override void OnClose(TimeSpan timeout)
	{
		OnCloseAsync(timeout).WaitForCompletionNoSpin();
	}

	protected async Task OnCloseOutputSessionAsync(TimeSpan timeout)
	{
		using (base.ThisAsyncLock.TakeLock())
		{
			ThrowIfNotOpened();
			ThrowIfFaulted();
			if (base.State != CommunicationState.Opened || _closeOutputWaitObject != null)
			{
				return;
			}
			_closeOutputWaitObject = new InterruptibleWaitObject(signaled: false, throwTimeoutByDefault: true);
		}
		bool throwing = true;
		try
		{
			await InternalCloseOutputSessionAsync(timeout);
			throwing = false;
		}
		finally
		{
			if (throwing)
			{
				ReliableSession.OnLocalFault(null, SequenceTerminatedFault.CreateCommunicationFault(ReliableSession.OutputID, System.SR.CloseOutputSessionErrorReason, null), null);
				_closeOutputWaitObject.Fault(this);
			}
			else
			{
				_closeOutputWaitObject.Set();
			}
		}
	}

	protected override void OnClosed()
	{
		base.OnClosed();
		Binder.Faulted -= OnBinderFaulted;
		if (_deliveryStrategy != null)
		{
			_deliveryStrategy.Dispose();
		}
	}

	protected override void OnClosing()
	{
		base.OnClosing();
		_acknowledgementTimer.Cancel();
	}

	private void OnComponentFaulted(Exception faultException, WsrmFault fault)
	{
		ReliableSession.OnLocalFault(faultException, fault, null);
	}

	private void OnComponentException(Exception exception)
	{
		ReliableSession.OnUnknownException(exception);
	}

	protected override void OnEndClose(IAsyncResult result)
	{
		result.ToApmEnd();
	}

	protected override void OnFaulted()
	{
		ReliableSession.OnFaulted();
		UnblockClose();
		base.OnFaulted();
	}

	protected override async Task OnSendAsync(Message message, TimeSpan timeout)
	{
		if (!(await OutputConnection.AddMessageAsync(message, timeout, null)))
		{
			ThrowInvalidAddException();
		}
	}

	private async Task OnSendAsyncHandler(MessageAttemptInfo attemptInfo, TimeSpan timeout, bool maskUnhandledException)
	{
		using (attemptInfo.Message)
		{
			if (attemptInfo.RetryCount > Settings.MaxRetryCount)
			{
				ReliableSession.OnLocalFault(new CommunicationException(System.SR.MaximumRetryCountExceeded, _maxRetryCountException), SequenceTerminatedFault.CreateMaxRetryCountExceededFault(ReliableSession.OutputID), null);
				return;
			}
			ReliableSession.OnLocalActivity();
			AddPendingAcknowledgements(attemptInfo.Message);
			MaskingMode maskingMode = (maskUnhandledException ? MaskingMode.Unhandled : MaskingMode.None);
			if (attemptInfo.RetryCount < Settings.MaxRetryCount)
			{
				maskingMode |= MaskingMode.Handled;
				await Binder.SendAsync(attemptInfo.Message, timeout, maskingMode);
				return;
			}
			try
			{
				await Binder.SendAsync(attemptInfo.Message, timeout, maskingMode);
			}
			catch (Exception ex)
			{
				if (Fx.IsFatal(ex))
				{
					throw;
				}
				if (Binder.IsHandleable(ex))
				{
					_maxRetryCountException = ex;
					return;
				}
				throw;
			}
		}
	}

	private async Task OnSendAckRequestedAsyncHandler(TimeSpan timeout)
	{
		ReliableSession.OnLocalActivity();
		using Message message = WsrmUtilities.CreateAckRequestedMessage(Settings.MessageVersion, Settings.ReliableMessagingVersion, ReliableSession.OutputID);
		await Binder.SendAsync(message, timeout, MaskingMode.Handled);
	}

	protected virtual void OnMessageDropped()
	{
	}

	protected void SetConnections()
	{
		OutputConnection = new ReliableOutputConnection(ReliableSession.OutputID, Settings.MaxTransferWindowSize, Settings.MessageVersion, Settings.ReliableMessagingVersion, ReliableSession.InitiationTime, requestAcks: true, base.DefaultSendTimeout);
		ReliableOutputConnection outputConnection = OutputConnection;
		outputConnection.Faulted = (ComponentFaultedHandler)Delegate.Combine(outputConnection.Faulted, new ComponentFaultedHandler(OnComponentFaulted));
		ReliableOutputConnection outputConnection2 = OutputConnection;
		outputConnection2.OnException = (ComponentExceptionHandler)Delegate.Combine(outputConnection2.OnException, new ComponentExceptionHandler(OnComponentException));
		OutputConnection.SendAsyncHandler = OnSendAsyncHandler;
		OutputConnection.SendAckRequestedAsyncHandler = OnSendAckRequestedAsyncHandler;
		_inputConnection = new ReliableInputConnection();
		_inputConnection.ReliableMessagingVersion = Settings.ReliableMessagingVersion;
		if (Settings.Ordered)
		{
			_deliveryStrategy = new OrderedDeliveryStrategy<Message>(this, Settings.MaxTransferWindowSize, isEnqueueInOrder: false);
		}
		else
		{
			_deliveryStrategy = new UnorderedDeliveryStrategy<Message>(this, Settings.MaxTransferWindowSize);
		}
		_deliveryStrategy.DequeueCallback = OnDeliveryStrategyItemDequeued;
	}

	protected void SetSession(ChannelReliableSession session)
	{
		session.UnblockChannelCloseCallback = UnblockClose;
		ReliableSession = session;
	}

	private void OnDeliveryStrategyItemDequeued()
	{
		if (_advertisedZero)
		{
			OnAcknowledgementTimeoutElapsedAsync(null);
		}
	}

	private static Task StartReceivingAsyncStatic(object state)
	{
		ReliableDuplexSessionChannel reliableDuplexSessionChannel = (ReliableDuplexSessionChannel)state;
		return reliableDuplexSessionChannel.StartReceivingAsync();
	}

	protected async Task StartReceivingAsync()
	{
		try
		{
			while (true)
			{
				var (flag, requestContext) = await Binder.TryReceiveAsync(TimeSpan.MaxValue);
				if (flag)
				{
					if (requestContext == null)
					{
						break;
					}
					Message requestMessage = requestContext.RequestMessage;
					requestContext.Close();
					WsrmMessageInfo item = WsrmMessageInfo.Get(Settings.MessageVersion, Settings.ReliableMessagingVersion, Binder.Channel, Binder.GetInnerSession(), requestMessage);
					ActionItem.Schedule(s_processMessageStatic, (this, item));
				}
			}
			bool flag2 = false;
			using (base.ThisAsyncLock.TakeLock())
			{
				flag2 = _inputConnection.Terminate();
			}
			if (!flag2 && Binder.State == CommunicationState.Opened)
			{
				Exception e = new CommunicationException(System.SR.EarlySecurityClose);
				ReliableSession.OnLocalFault(e, (Message)null, (RequestContext)null);
			}
		}
		catch (Exception ex)
		{
			if (Fx.IsFatal(ex))
			{
				throw;
			}
			ReliableSession.OnUnknownException(ex);
		}
	}

	private void ShutdownCallback(object state)
	{
		Shutdown();
	}

	private async Task TerminateSequenceAsync(TimeSpan timeout)
	{
		ReliableMessagingVersion reliableMessagingVersion = Settings.ReliableMessagingVersion;
		if (reliableMessagingVersion == ReliableMessagingVersion.WSReliableMessagingFebruary2005)
		{
			if (OutputConnection.CheckForTermination())
			{
				ReliableSession.CloseSession();
			}
			Message message = WsrmUtilities.CreateTerminateMessage(Settings.MessageVersion, reliableMessagingVersion, ReliableSession.OutputID);
			await Binder.SendAsync(message, timeout, MaskingMode.Handled);
		}
		else
		{
			if (reliableMessagingVersion != ReliableMessagingVersion.WSReliableMessaging11)
			{
				throw Fx.AssertAndThrow("Reliable messaging version not supported.");
			}
			CreateTerminateRequestor();
			await _terminateRequestor.RequestAsync(timeout);
		}
	}

	private void ThrowIfCloseInvalid()
	{
		bool flag = false;
		if (Settings.ReliableMessagingVersion == ReliableMessagingVersion.WSReliableMessagingFebruary2005)
		{
			if (_deliveryStrategy.EnqueuedCount > 0 || _inputConnection.Ranges.Count > 1)
			{
				flag = true;
			}
		}
		else if (Settings.ReliableMessagingVersion == ReliableMessagingVersion.WSReliableMessaging11 && _deliveryStrategy.EnqueuedCount > 0)
		{
			flag = true;
		}
		if (flag)
		{
			WsrmFault wsrmFault = SequenceTerminatedFault.CreateProtocolFault(ReliableSession.InputID, System.SR.SequenceTerminatedSessionClosedBeforeDone, System.SR.SessionClosedBeforeDone);
			ReliableSession.OnLocalFault(null, wsrmFault, null);
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(wsrmFault.CreateException());
		}
	}

	private void ThrowInvalidAddException()
	{
		if (base.State == CommunicationState.Opened)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.SendCannotBeCalledAfterCloseOutputSession));
		}
		if (base.State == CommunicationState.Faulted)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(GetTerminalException());
		}
		throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(CreateClosedException());
	}

	private void UnblockClose()
	{
		if (OutputConnection != null)
		{
			OutputConnection.Fault(this);
		}
		if (_inputConnection != null)
		{
			_inputConnection.Fault(this);
		}
		_closeRequestor?.Fault(this);
		_terminateRequestor?.Fault(this);
	}
}
