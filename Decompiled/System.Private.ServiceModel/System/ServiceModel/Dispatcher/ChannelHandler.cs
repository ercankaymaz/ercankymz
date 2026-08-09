using System.Globalization;
using System.Runtime;
using System.Runtime.Diagnostics;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Diagnostics;
using System.Xml;

namespace System.ServiceModel.Dispatcher;

internal class ChannelHandler
{
	private struct RequestInfo(ChannelHandler channelHandler)
	{
		public EndpointDispatcher Endpoint = null;

		public InstanceContext ExistingInstanceContext = null;

		public ServiceChannel Channel = null;

		public bool EndpointLookupDone = false;

		public DispatchRuntime DispatchRuntime = null;

		public RequestContext RequestContext = null;

		public ChannelHandler ChannelHandler = channelHandler;

		public void Cleanup()
		{
			Endpoint = null;
			ExistingInstanceContext = null;
			Channel = null;
			EndpointLookupDone = false;
			RequestContext = null;
		}
	}

	private struct ContinuationState
	{
		public ChannelHandler ChannelHandler;

		public Exception Exception;

		public RequestContext Request;

		public Message Reply;

		public ServiceChannel Channel;

		public ErrorHandlerFaultInfo FaultInfo;
	}

	public static readonly TimeSpan CloseAfterFaultTimeout = TimeSpan.FromSeconds(10.0);

	public const string MessageBufferPropertyName = "_RequestMessageBuffer_";

	private readonly DuplexChannelBinder _duplexBinder;

	private readonly bool _incrementedActivityCountInConstructor;

	private readonly bool _isCallback;

	private readonly ListenerHandler _listener;

	private readonly ServiceChannel.SessionIdleManager _idleManager;

	private readonly bool _sendAsynchronously;

	private static AsyncCallback s_onAsyncReplyComplete = Fx.ThunkCallback(OnAsyncReplyComplete);

	private static AsyncCallback s_onAsyncReceiveComplete = Fx.ThunkCallback(OnAsyncReceiveComplete);

	private static Action<object> s_onContinueAsyncReceive = OnContinueAsyncReceive;

	private static Action<object> s_onStartSyncMessagePump = OnStartSyncMessagePump;

	private static Action<object> s_onStartAsyncMessagePump = OnStartAsyncMessagePump;

	private static Action<object> s_openAndEnsurePump = OpenAndEnsurePump;

	private RequestInfo _requestInfo;

	private bool _doneReceiving;

	private bool _hasSession;

	private int _isPumpAcquired;

	private bool _isChannelTerminated;

	private bool _isConcurrent;

	private bool _isManualAddressing;

	private MessageVersion _messageVersion;

	private ErrorHandlingReceiver _receiver;

	private bool _receiveSynchronously;

	private RequestContext _replied;

	private EventTraceActivity _eventTraceActivity;

	private bool _shouldRejectMessageWithOnOpenActionHeader;

	private object _acquirePumpLock = new object();

	internal IChannelBinder Binder { get; }

	internal ServiceChannel Channel { get; private set; }

	internal bool HasRegisterBeenCalled { get; private set; }

	private bool IsOpen => Binder.Channel.State == CommunicationState.Opened;

	private object ThisLock => this;

	private EventTraceActivity EventTraceActivity
	{
		get
		{
			if (_eventTraceActivity == null)
			{
				_eventTraceActivity = new EventTraceActivity();
			}
			return _eventTraceActivity;
		}
	}

	internal ChannelHandler(MessageVersion messageVersion, IChannelBinder binder, ServiceChannel channel)
	{
		ClientRuntime clientRuntime = channel.ClientRuntime;
		_messageVersion = messageVersion;
		_isManualAddressing = clientRuntime.ManualAddressing;
		Binder = binder;
		Channel = channel;
		_isConcurrent = true;
		_duplexBinder = binder as DuplexChannelBinder;
		_hasSession = binder.HasSession;
		_isCallback = true;
		DispatchRuntime dispatchRuntime = clientRuntime.DispatchRuntime;
		if (dispatchRuntime == null)
		{
			_receiver = new ErrorHandlingReceiver(binder, null);
		}
		else
		{
			_receiver = new ErrorHandlingReceiver(binder, dispatchRuntime.ChannelDispatcher);
		}
		_requestInfo = new RequestInfo(this);
	}

	internal ChannelHandler(MessageVersion messageVersion, IChannelBinder binder, ListenerHandler listener, ServiceChannel.SessionIdleManager idleManager)
	{
		ChannelDispatcher channelDispatcher = listener.ChannelDispatcher;
		_messageVersion = messageVersion;
		_isManualAddressing = channelDispatcher.ManualAddressing;
		Binder = binder;
		_listener = listener;
		_receiveSynchronously = channelDispatcher.ReceiveSynchronously;
		_sendAsynchronously = channelDispatcher.SendAsynchronously;
		_duplexBinder = binder as DuplexChannelBinder;
		_hasSession = binder.HasSession;
		_isConcurrent = ConcurrencyBehavior.IsConcurrent(channelDispatcher, _hasSession);
		if (channelDispatcher.MaxPendingReceives > 1)
		{
			throw System.NotImplemented.ByDesign;
		}
		if (channelDispatcher.BufferedReceiveEnabled)
		{
			Binder = new BufferedReceiveBinder(Binder);
		}
		_receiver = new ErrorHandlingReceiver(Binder, channelDispatcher);
		_idleManager = idleManager;
		_requestInfo = new RequestInfo(this);
		if (_listener.State == CommunicationState.Opened)
		{
			_listener.ChannelDispatcher.Channels.IncrementActivityCount();
			_incrementedActivityCountInConstructor = true;
		}
	}

	internal static void Register(ChannelHandler handler)
	{
		handler.Register();
	}

	internal static void Register(ChannelHandler handler, RequestContext request)
	{
		BufferedReceiveBinder bufferedReceiveBinder = handler.Binder as BufferedReceiveBinder;
		bufferedReceiveBinder.InjectRequest(request);
		handler.Register();
	}

	private void Register()
	{
		HasRegisterBeenCalled = true;
		if (Binder.Channel.State == CommunicationState.Created)
		{
			ActionItem.Schedule(s_openAndEnsurePump, this);
		}
		else
		{
			EnsurePump();
		}
	}

	private void AsyncMessagePump()
	{
		IAsyncResult asyncResult = BeginTryReceive();
		if (asyncResult != null && asyncResult.CompletedSynchronously)
		{
			AsyncMessagePump(asyncResult);
		}
	}

	private void AsyncMessagePump(IAsyncResult result)
	{
		if (WcfEventSource.Instance.ChannelReceiveStopIsEnabled())
		{
			WcfEventSource.Instance.ChannelReceiveStop(EventTraceActivity, GetHashCode());
		}
		while (true)
		{
			if (!EndTryReceive(result, out var requestContext))
			{
				result = BeginTryReceive();
				if (result == null || !result.CompletedSynchronously)
				{
					break;
				}
				continue;
			}
			if (HandleRequest(requestContext, null) && TryAcquirePump())
			{
				result = BeginTryReceive();
				if (result == null || !result.CompletedSynchronously)
				{
					break;
				}
				continue;
			}
			break;
		}
	}

	private IAsyncResult BeginTryReceive()
	{
		_requestInfo.Cleanup();
		if (WcfEventSource.Instance.ChannelReceiveStartIsEnabled())
		{
			WcfEventSource.Instance.ChannelReceiveStart(EventTraceActivity, GetHashCode());
		}
		return _receiver.BeginTryReceive(TimeSpan.MaxValue, s_onAsyncReceiveComplete, this);
	}

	private bool DispatchAndReleasePump(RequestContext request, bool cleanThread, OperationContext currentOperationContext)
	{
		ServiceChannel channel = _requestInfo.Channel;
		EndpointDispatcher endpoint = _requestInfo.Endpoint;
		bool flag = false;
		try
		{
			DispatchRuntime dispatchRuntime = _requestInfo.DispatchRuntime;
			if (channel == null || dispatchRuntime == null)
			{
				return true;
			}
			EventTraceActivity eventTraceActivity = TraceDispatchMessageStart(request.RequestMessage);
			Message message = request.RequestMessage;
			DispatchOperationRuntime operation = dispatchRuntime.GetOperation(ref message);
			if (operation == null)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(string.Format(CultureInfo.InvariantCulture, "No DispatchOperationRuntime found to process message.")));
			}
			if (_shouldRejectMessageWithOnOpenActionHeader && message.Headers.Action == "http://schemas.microsoft.com/2011/02/session/onopen")
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.Format(System.SR.SFxNoEndpointMatchingAddressForConnectionOpeningMessage, message.Headers.Action, "Open")));
			}
			if (MessageLogger.LoggingEnabled)
			{
				MessageLogger.LogMessage(ref message, (MessageLoggingSource)((operation.IsOneWay ? 16 : 64) | 0x800));
			}
			if (operation.IsTerminating && _hasSession)
			{
				_isChannelTerminated = true;
			}
			bool isOperationContextSet;
			if (currentOperationContext != null)
			{
				isOperationContextSet = true;
				currentOperationContext.ReInit(request, message, channel);
			}
			else
			{
				isOperationContextSet = false;
				currentOperationContext = new OperationContext(request, message, channel);
			}
			MessageRpc rpc = new MessageRpc(request, message, operation, channel, this, cleanThread, currentOperationContext, _requestInfo.ExistingInstanceContext, eventTraceActivity);
			TraceUtility.MessageFlowAtMessageReceived(message, currentOperationContext, eventTraceActivity, createNewActivityId: true);
			ReleasePump();
			flag = true;
			return operation.Parent.Dispatch(ref rpc, isOperationContextSet);
		}
		catch (Exception ex)
		{
			if (Fx.IsFatal(ex))
			{
				throw;
			}
			return HandleError(ex, request, channel);
		}
		finally
		{
			if (!flag)
			{
				ReleasePump();
			}
		}
	}

	internal void DispatchDone()
	{
	}

	private bool EndTryReceive(IAsyncResult result, out RequestContext requestContext)
	{
		bool flag = _receiver.EndTryReceive(result, out requestContext);
		if (flag)
		{
			HandleReceiveComplete(requestContext);
		}
		return flag;
	}

	private void EnsureChannelAndEndpoint(RequestContext request)
	{
		_requestInfo.Channel = Channel;
		if (_requestInfo.Channel == null)
		{
			bool addressMatched;
			if (_hasSession)
			{
				_requestInfo.Channel = GetSessionChannel(request.RequestMessage, out _requestInfo.Endpoint, out addressMatched);
			}
			else
			{
				_requestInfo.Channel = GetDatagramChannel(request.RequestMessage, out _requestInfo.Endpoint, out addressMatched);
			}
			if (_requestInfo.Channel == null)
			{
				if (addressMatched)
				{
					ReplyContractFilterDidNotMatch(request);
				}
				else
				{
					ReplyAddressFilterDidNotMatch(request);
				}
			}
		}
		else
		{
			_requestInfo.Endpoint = _requestInfo.Channel.EndpointDispatcher;
		}
		_requestInfo.EndpointLookupDone = true;
		if (_requestInfo.Channel == null)
		{
			TraceUtility.TraceDroppedMessage(request.RequestMessage, _requestInfo.Endpoint);
			request.Close();
		}
		else if (_requestInfo.Channel.HasSession || _isCallback)
		{
			_requestInfo.DispatchRuntime = _requestInfo.Channel.DispatchRuntime;
		}
		else
		{
			_requestInfo.DispatchRuntime = _requestInfo.Endpoint.DispatchRuntime;
		}
	}

	private void EnsurePump()
	{
		if (!TryAcquirePump())
		{
			return;
		}
		if (_receiveSynchronously)
		{
			ActionItem.Schedule(s_onStartSyncMessagePump, this);
			return;
		}
		IAsyncResult asyncResult = BeginTryReceive();
		if (asyncResult != null && asyncResult.CompletedSynchronously)
		{
			ActionItem.Schedule(s_onContinueAsyncReceive, asyncResult);
		}
	}

	private ServiceChannel GetDatagramChannel(Message message, out EndpointDispatcher endpoint, out bool addressMatched)
	{
		addressMatched = false;
		endpoint = GetEndpointDispatcher(message, out addressMatched);
		if (endpoint == null)
		{
			return null;
		}
		if (endpoint.DatagramChannel == null)
		{
			lock (_listener.ThisLock)
			{
				if (endpoint.DatagramChannel == null)
				{
					endpoint.DatagramChannel = new ServiceChannel(Binder, endpoint, _listener.ChannelDispatcher, _idleManager);
					InitializeServiceChannel(endpoint.DatagramChannel);
				}
			}
		}
		return endpoint.DatagramChannel;
	}

	private EndpointDispatcher GetEndpointDispatcher(Message message, out bool addressMatched)
	{
		return _listener.Endpoints.Lookup(message, out addressMatched);
	}

	private ServiceChannel GetSessionChannel(Message message, out EndpointDispatcher endpoint, out bool addressMatched)
	{
		addressMatched = false;
		if (Channel == null)
		{
			lock (ThisLock)
			{
				if (Channel == null)
				{
					endpoint = GetEndpointDispatcher(message, out addressMatched);
					if (endpoint != null)
					{
						Channel = new ServiceChannel(Binder, endpoint, _listener.ChannelDispatcher, _idleManager);
						InitializeServiceChannel(Channel);
					}
				}
			}
		}
		if (Channel == null)
		{
			endpoint = null;
		}
		else
		{
			endpoint = Channel.EndpointDispatcher;
		}
		return Channel;
	}

	private void InitializeServiceChannel(ServiceChannel channel)
	{
		ClientRuntime clientRuntime = channel.ClientRuntime;
		if (clientRuntime != null)
		{
			Type contractClientType = clientRuntime.ContractClientType;
			Type callbackClientType = clientRuntime.CallbackClientType;
			if (contractClientType != null)
			{
				channel.Proxy = ServiceChannelFactory.CreateProxy(contractClientType, callbackClientType, MessageDirection.Output, channel);
			}
		}
		if (_listener != null)
		{
			_listener.ChannelDispatcher.InitializeChannel((IClientChannel)channel.Proxy);
		}
		((ICommunicationObject)channel).Open();
	}

	private void ProvideFault(Exception e, ref ErrorHandlerFaultInfo faultInfo)
	{
		if (_listener != null)
		{
			_listener.ChannelDispatcher.ProvideFault(e, (_requestInfo.Channel == null) ? Binder.Channel.GetProperty<FaultConverter>() : _requestInfo.Channel.GetProperty<FaultConverter>(), ref faultInfo);
		}
		else if (Channel != null)
		{
			DispatchRuntime callbackDispatchRuntime = Channel.ClientRuntime.CallbackDispatchRuntime;
			callbackDispatchRuntime.ChannelDispatcher.ProvideFault(e, Channel.GetProperty<FaultConverter>(), ref faultInfo);
		}
	}

	internal bool HandleError(Exception e)
	{
		ErrorHandlerFaultInfo faultInfo = default(ErrorHandlerFaultInfo);
		return HandleError(e, ref faultInfo);
	}

	private bool HandleError(Exception e, ref ErrorHandlerFaultInfo faultInfo)
	{
		if (e == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.SFxNonExceptionThrown));
		}
		if (_listener != null)
		{
			return _listener.ChannelDispatcher.HandleError(e, ref faultInfo);
		}
		if (Channel != null)
		{
			return Channel.ClientRuntime.CallbackDispatchRuntime.ChannelDispatcher.HandleError(e, ref faultInfo);
		}
		return false;
	}

	private bool HandleError(Exception e, RequestContext request, ServiceChannel channel)
	{
		ErrorHandlerFaultInfo faultInfo = new ErrorHandlerFaultInfo(_messageVersion.Addressing.DefaultFaultAction);
		ProvideFaultAndReplyFailure(request, e, ref faultInfo, out var replied, out var replySentAsync);
		if (!replySentAsync)
		{
			return HandleErrorContinuation(e, request, channel, ref faultInfo, replied);
		}
		return false;
	}

	private bool HandleErrorContinuation(Exception e, RequestContext request, ServiceChannel channel, ref ErrorHandlerFaultInfo faultInfo, bool replied)
	{
		if (replied)
		{
			try
			{
				request.Close();
			}
			catch (Exception ex)
			{
				if (Fx.IsFatal(ex))
				{
					throw;
				}
				HandleError(ex);
			}
		}
		else
		{
			request.Abort();
		}
		if (!HandleError(e, ref faultInfo) && _hasSession)
		{
			if (channel != null)
			{
				if (replied)
				{
					TimeoutHelper timeoutHelper = new TimeoutHelper(CloseAfterFaultTimeout);
					try
					{
						channel.Close(timeoutHelper.RemainingTime());
					}
					catch (Exception ex2)
					{
						if (Fx.IsFatal(ex2))
						{
							throw;
						}
						HandleError(ex2);
					}
					try
					{
						Binder.CloseAfterFault(timeoutHelper.RemainingTime());
					}
					catch (Exception ex3)
					{
						if (Fx.IsFatal(ex3))
						{
							throw;
						}
						HandleError(ex3);
					}
				}
				else
				{
					channel.Abort();
					Binder.Abort();
				}
			}
			else if (replied)
			{
				try
				{
					Binder.CloseAfterFault(CloseAfterFaultTimeout);
				}
				catch (Exception ex4)
				{
					if (Fx.IsFatal(ex4))
					{
						throw;
					}
					HandleError(ex4);
				}
			}
			else
			{
				Binder.Abort();
			}
		}
		return true;
	}

	private void HandleReceiveComplete(RequestContext context)
	{
		try
		{
			if (Channel != null)
			{
				Channel.HandleReceiveComplete(context);
			}
			else
			{
				if (context != null || !_hasSession)
				{
					return;
				}
				bool flag;
				lock (ThisLock)
				{
					flag = !_doneReceiving;
					_doneReceiving = true;
				}
				if (flag)
				{
					_receiver.Close();
					if (_idleManager != null)
					{
						_idleManager.CancelTimer();
					}
				}
			}
		}
		finally
		{
			if (context == null && _incrementedActivityCountInConstructor)
			{
				_listener.ChannelDispatcher.Channels.DecrementActivityCount();
			}
		}
	}

	private bool HandleRequest(RequestContext request, OperationContext currentOperationContext)
	{
		if (request == null)
		{
			return false;
		}
		ServiceModelActivity activity = (DiagnosticUtility.ShouldUseActivity ? TraceUtility.ExtractActivity(request.RequestMessage) : null);
		using (ServiceModelActivity.BoundOperation(activity))
		{
			if (HandleRequestAsReply(request))
			{
				ReleasePump();
				return true;
			}
			if (_isChannelTerminated)
			{
				ReleasePump();
				ReplyChannelTerminated(request);
				return true;
			}
			_ = _requestInfo.RequestContext;
			_requestInfo.RequestContext = request;
			if (!TryRetrievingInstanceContext(request))
			{
				return true;
			}
			_requestInfo.Channel.CompletedIOOperation();
			if (!DispatchAndReleasePump(request, cleanThread: true, currentOperationContext))
			{
				return false;
			}
		}
		return true;
	}

	private bool HandleRequestAsReply(RequestContext request)
	{
		if (_duplexBinder != null && _duplexBinder.HandleRequestAsReply(request.RequestMessage))
		{
			return true;
		}
		return false;
	}

	private static void OnStartAsyncMessagePump(object state)
	{
		((ChannelHandler)state).AsyncMessagePump();
	}

	private static void OnStartSyncMessagePump(object state)
	{
		ChannelHandler channelHandler = state as ChannelHandler;
		if (WcfEventSource.Instance.ChannelReceiveStopIsEnabled())
		{
			WcfEventSource.Instance.ChannelReceiveStop(channelHandler.EventTraceActivity, state.GetHashCode());
		}
		channelHandler.SyncMessagePump();
	}

	private static void OnAsyncReceiveComplete(IAsyncResult result)
	{
		if (!result.CompletedSynchronously)
		{
			((ChannelHandler)result.AsyncState).AsyncMessagePump(result);
		}
	}

	private static void OnContinueAsyncReceive(object state)
	{
		IAsyncResult asyncResult = (IAsyncResult)state;
		((ChannelHandler)asyncResult.AsyncState).AsyncMessagePump(asyncResult);
	}

	private static void OpenAndEnsurePump(object state)
	{
		((ChannelHandler)state).OpenAndEnsurePump();
	}

	private void OpenAndEnsurePump()
	{
		Exception ex = null;
		try
		{
			Binder.Channel.Open();
		}
		catch (Exception ex2)
		{
			if (Fx.IsFatal(ex2))
			{
				throw;
			}
			ex = ex2;
		}
		if (ex != null)
		{
			_idleManager?.CancelTimer();
			bool flag = HandleError(ex);
			if (_incrementedActivityCountInConstructor)
			{
				_listener.ChannelDispatcher.Channels.DecrementActivityCount();
			}
			if (!flag)
			{
				Binder.Channel.Abort();
			}
		}
		else
		{
			EnsurePump();
		}
	}

	private bool TryReceive(TimeSpan timeout, out RequestContext requestContext)
	{
		_shouldRejectMessageWithOnOpenActionHeader = false;
		bool flag = _receiver.TryReceive(timeout, out requestContext);
		if (flag)
		{
			HandleReceiveComplete(requestContext);
		}
		return flag;
	}

	private void ReplyAddressFilterDidNotMatch(RequestContext request)
	{
		FaultCode code = FaultCode.CreateSenderFaultCode("DestinationUnreachable", _messageVersion.Addressing.Namespace);
		string reason = System.SR.Format(System.SR.SFxNoEndpointMatchingAddress, request.RequestMessage.Headers.To);
		ReplyFailure(request, code, reason);
	}

	private void ReplyContractFilterDidNotMatch(RequestContext request)
	{
		AddressingVersion addressing = _messageVersion.Addressing;
		if (addressing != AddressingVersion.None && request.RequestMessage.Headers.Action == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new MessageHeaderException(System.SR.Format(System.SR.SFxMissingActionHeader, addressing.Namespace), "Action", addressing.Namespace));
		}
		FaultCode code = FaultCode.CreateSenderFaultCode("ActionNotSupported", _messageVersion.Addressing.Namespace);
		string reason = System.SR.Format(System.SR.SFxNoEndpointMatchingContract, request.RequestMessage.Headers.Action);
		ReplyFailure(request, code, reason, _messageVersion.Addressing.FaultAction);
	}

	private void ReplyChannelTerminated(RequestContext request)
	{
		FaultCode faultCode = FaultCode.CreateSenderFaultCode("SessionTerminated", "http://schemas.microsoft.com/net/2005/12/windowscommunicationfoundation/dispatcher");
		string reason = System.SR.Format(System.SR.SFxChannelTerminated0);
		string action = "http://schemas.microsoft.com/net/2005/12/windowscommunicationfoundation/dispatcher/fault";
		Message fault = Message.CreateMessage(_messageVersion, faultCode, reason, action);
		ReplyFailure(request, fault, action, reason, faultCode);
	}

	private void ReplyFailure(RequestContext request, FaultCode code, string reason)
	{
		string defaultFaultAction = _messageVersion.Addressing.DefaultFaultAction;
		ReplyFailure(request, code, reason, defaultFaultAction);
	}

	private void ReplyFailure(RequestContext request, FaultCode code, string reason, string action)
	{
		Message fault = Message.CreateMessage(_messageVersion, code, reason, action);
		ReplyFailure(request, fault, action, reason, code);
	}

	private void ReplyFailure(RequestContext request, Message fault, string action, string reason, FaultCode code)
	{
		FaultException ex = new FaultException(reason, code);
		ErrorBehavior.ThrowAndCatch(ex);
		ErrorHandlerFaultInfo faultInfo = new ErrorHandlerFaultInfo(action);
		faultInfo.Fault = fault;
		ProvideFaultAndReplyFailure(request, ex, ref faultInfo, out var _, out var _);
		HandleError(ex, ref faultInfo);
	}

	private void ProvideFaultAndReplyFailure(RequestContext request, Exception exception, ref ErrorHandlerFaultInfo faultInfo, out bool replied, out bool replySentAsync)
	{
		replied = false;
		replySentAsync = false;
		bool flag = false;
		try
		{
			flag = request.RequestMessage.IsFault;
		}
		catch (Exception exception2)
		{
			if (Fx.IsFatal(exception2))
			{
				throw;
			}
		}
		bool flag2 = false;
		if (_listener != null)
		{
			flag2 = _listener.ChannelDispatcher.EnableFaults;
		}
		else if (Channel != null && Channel.IsClient)
		{
			flag2 = Channel.ClientRuntime.EnableFaults;
		}
		if (!(!flag && flag2))
		{
			return;
		}
		ProvideFault(exception, ref faultInfo);
		if (faultInfo.Fault == null)
		{
			return;
		}
		Message fault = faultInfo.Fault;
		try
		{
			try
			{
				if (!PrepareReply(request, fault))
				{
					return;
				}
				if (_sendAsynchronously)
				{
					ContinuationState continuationState = new ContinuationState
					{
						ChannelHandler = this,
						Channel = Channel,
						Exception = exception,
						FaultInfo = faultInfo,
						Request = request,
						Reply = fault
					};
					IAsyncResult asyncResult = request.BeginReply(fault, s_onAsyncReplyComplete, continuationState);
					if (asyncResult.CompletedSynchronously)
					{
						AsyncReplyComplete(asyncResult, continuationState);
						replied = true;
					}
					else
					{
						replySentAsync = true;
					}
				}
				else
				{
					request.Reply(fault);
					replied = true;
				}
			}
			finally
			{
				if (!replySentAsync)
				{
					fault.Close();
				}
			}
		}
		catch (Exception ex)
		{
			if (Fx.IsFatal(ex))
			{
				throw;
			}
			HandleError(ex);
		}
	}

	private bool PrepareReply(RequestContext request, Message reply)
	{
		if (_replied == request)
		{
			return false;
		}
		_replied = request;
		bool flag = true;
		Message message = null;
		try
		{
			message = request.RequestMessage;
		}
		catch (Exception exception)
		{
			if (Fx.IsFatal(exception))
			{
				throw;
			}
		}
		if (message != null)
		{
			UniqueId uniqueId = null;
			try
			{
				uniqueId = message.Headers.MessageId;
			}
			catch (MessageHeaderException)
			{
			}
			if ((object)uniqueId != null && !_isManualAddressing)
			{
				RequestReplyCorrelator.PrepareReply(reply, uniqueId);
			}
			if (!_hasSession && !_isManualAddressing)
			{
				try
				{
					flag = RequestReplyCorrelator.AddressReply(reply, message);
				}
				catch (MessageHeaderException)
				{
				}
			}
		}
		return IsOpen && flag;
	}

	private static void AsyncReplyComplete(IAsyncResult result, ContinuationState state)
	{
		try
		{
			state.Request.EndReply(result);
		}
		catch (Exception ex)
		{
			if (Fx.IsFatal(ex))
			{
				throw;
			}
			state.ChannelHandler.HandleError(ex);
		}
		try
		{
			state.Reply.Close();
		}
		catch (Exception ex2)
		{
			if (Fx.IsFatal(ex2))
			{
				throw;
			}
			state.ChannelHandler.HandleError(ex2);
		}
		try
		{
			state.ChannelHandler.HandleErrorContinuation(state.Exception, state.Request, state.Channel, ref state.FaultInfo, replied: true);
		}
		catch (Exception ex3)
		{
			if (Fx.IsFatal(ex3))
			{
				throw;
			}
			state.ChannelHandler.HandleError(ex3);
		}
		state.ChannelHandler.EnsurePump();
	}

	private static void OnAsyncReplyComplete(IAsyncResult result)
	{
		if (result.CompletedSynchronously)
		{
			return;
		}
		try
		{
			ContinuationState state = (ContinuationState)result.AsyncState;
			AsyncReplyComplete(result, state);
		}
		catch (Exception exception)
		{
			if (Fx.IsFatal(exception))
			{
				throw;
			}
		}
	}

	private void ReleasePump()
	{
		if (_isConcurrent)
		{
			lock (_acquirePumpLock)
			{
				_isPumpAcquired = 0;
			}
		}
	}

	private void SyncMessagePump()
	{
		OperationContext current = OperationContext.Current;
		try
		{
			OperationContext operationContext = (OperationContext.Current = new OperationContext());
			while (true)
			{
				_requestInfo.Cleanup();
				RequestContext requestContext;
				while (!TryReceive(TimeSpan.MaxValue, out requestContext))
				{
				}
				if (!HandleRequest(requestContext, operationContext) || !TryAcquirePump())
				{
					break;
				}
				operationContext.Recycle();
			}
		}
		finally
		{
			OperationContext.Current = current;
		}
	}

	private bool TryRetrievingInstanceContext(RequestContext request)
	{
		bool flag = true;
		try
		{
			if (!_requestInfo.EndpointLookupDone)
			{
				EnsureChannelAndEndpoint(request);
			}
			if (_requestInfo.Channel == null)
			{
				return false;
			}
			if (_requestInfo.DispatchRuntime == null)
			{
				TraceUtility.TraceDroppedMessage(request.RequestMessage, _requestInfo.Endpoint);
				request.Close();
				return false;
			}
			IContextChannel channel = _requestInfo.Channel.Proxy as IContextChannel;
			try
			{
				_requestInfo.ExistingInstanceContext = _requestInfo.DispatchRuntime.InstanceContextProvider.GetExistingInstanceContext(request.RequestMessage, channel);
				flag = false;
			}
			catch (Exception ex)
			{
				if (Fx.IsFatal(ex))
				{
					throw;
				}
				_requestInfo.Channel = null;
				HandleError(ex, request, Channel);
				return false;
			}
		}
		catch (Exception ex2)
		{
			if (Fx.IsFatal(ex2))
			{
				throw;
			}
			HandleError(ex2, request, Channel);
			return false;
		}
		finally
		{
			if (flag)
			{
				ReleasePump();
			}
		}
		return true;
	}

	private bool TryAcquirePump()
	{
		if (_isConcurrent)
		{
			lock (_acquirePumpLock)
			{
				if (_isPumpAcquired != 0)
				{
					return false;
				}
				_isPumpAcquired = 1;
				return true;
			}
		}
		return true;
	}

	private EventTraceActivity TraceDispatchMessageStart(Message message)
	{
		if (FxTrace.Trace.IsEnd2EndActivityTracingEnabled && message != null)
		{
			EventTraceActivity eventTraceActivity = EventTraceActivityHelper.TryExtractActivity(message);
			if (WcfEventSource.Instance.DispatchMessageStartIsEnabled())
			{
				WcfEventSource.Instance.DispatchMessageStart(eventTraceActivity);
			}
			return eventTraceActivity;
		}
		return null;
	}
}
