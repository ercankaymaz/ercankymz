using System.Collections.Specialized;
using System.Runtime;
using System.Runtime.Diagnostics;
using System.ServiceModel.Channels;
using System.ServiceModel.Diagnostics;

namespace System.ServiceModel.Dispatcher;

internal class ImmutableDispatchRuntime
{
	private interface IDemuxer
	{
		DispatchOperationRuntime GetOperation(ref Message request);
	}

	private class ActionDemuxer : IDemuxer
	{
		private readonly HybridDictionary _map;

		private DispatchOperationRuntime _unhandled;

		internal ActionDemuxer()
		{
			_map = new HybridDictionary();
		}

		internal void Add(string action, DispatchOperationRuntime operation)
		{
			if (_map.Contains(action))
			{
				DispatchOperationRuntime dispatchOperationRuntime = (DispatchOperationRuntime)_map[action];
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.Format(System.SR.SFxActionDemuxerDuplicate, dispatchOperationRuntime.Name, operation.Name, action)));
			}
			_map.Add(action, operation);
		}

		internal void SetUnhandled(DispatchOperationRuntime operation)
		{
			_unhandled = operation;
		}

		public DispatchOperationRuntime GetOperation(ref Message request)
		{
			string text = request.Headers.Action;
			if (text == null)
			{
				text = "*";
			}
			DispatchOperationRuntime dispatchOperationRuntime = (DispatchOperationRuntime)_map[text];
			if (dispatchOperationRuntime != null)
			{
				return dispatchOperationRuntime;
			}
			return _unhandled;
		}
	}

	private readonly ConcurrencyBehavior _concurrency;

	private readonly IDemuxer _demuxer;

	private readonly ErrorBehavior _error;

	private InstanceBehavior _instance;

	private readonly IDispatchMessageInspector[] _messageInspectors;

	private readonly TerminatingOperationBehavior _terminate;

	private readonly ThreadBehavior _thread;

	private readonly bool _sendAsynchronously;

	private readonly MessageRpcProcessor _processMessage1;

	private readonly MessageRpcProcessor _processMessage11;

	private readonly MessageRpcProcessor _processMessage2;

	private readonly MessageRpcProcessor _processMessage3;

	private readonly MessageRpcProcessor _processMessage31;

	private readonly MessageRpcProcessor _processMessage4;

	private readonly MessageRpcProcessor _processMessage41;

	private readonly MessageRpcProcessor _processMessage5;

	private readonly MessageRpcProcessor _processMessage6;

	private readonly MessageRpcProcessor _processMessage7;

	private readonly MessageRpcProcessor _processMessage8;

	private readonly MessageRpcProcessor _processMessage9;

	private readonly MessageRpcProcessor _processMessageCleanup;

	private readonly MessageRpcProcessor _processMessageCleanupError;

	private static AsyncCallback s_onReplyCompleted = Fx.ThunkCallback(OnReplyCompletedCallback);

	internal int CorrelationCount { get; }

	internal bool EnableFaults { get; }

	internal bool ManualAddressing { get; }

	internal bool ValidateMustUnderstand { get; }

	internal int MessageInspectorCorrelationOffset => 0;

	internal ImmutableDispatchRuntime(DispatchRuntime dispatch)
	{
		_concurrency = new ConcurrencyBehavior(dispatch);
		_error = new ErrorBehavior(dispatch.ChannelDispatcher);
		EnableFaults = dispatch.EnableFaults;
		_instance = new InstanceBehavior(dispatch, this);
		ManualAddressing = dispatch.ManualAddressing;
		_messageInspectors = EmptyArray<IDispatchMessageInspector>.ToArray(dispatch.MessageInspectors);
		_terminate = TerminatingOperationBehavior.CreateIfNecessary(dispatch);
		_thread = new ThreadBehavior(dispatch);
		_sendAsynchronously = dispatch.ChannelDispatcher.SendAsynchronously;
		CorrelationCount = dispatch.MaxParameterInspectors;
		DispatchOperationRuntime unhandled = new DispatchOperationRuntime(dispatch.UnhandledDispatchOperation, this);
		ActionDemuxer actionDemuxer = new ActionDemuxer();
		for (int i = 0; i < dispatch.Operations.Count; i++)
		{
			DispatchOperation dispatchOperation = dispatch.Operations[i];
			DispatchOperationRuntime operation = new DispatchOperationRuntime(dispatchOperation, this);
			actionDemuxer.Add(dispatchOperation.Action, operation);
		}
		actionDemuxer.SetUnhandled(unhandled);
		_demuxer = actionDemuxer;
		_processMessage1 = ProcessMessage1;
		_processMessage11 = ProcessMessage11;
		_processMessage2 = ProcessMessage2;
		_processMessage3 = ProcessMessage3;
		_processMessage31 = ProcessMessage31;
		_processMessage4 = ProcessMessage4;
		_processMessage41 = ProcessMessage41;
		_processMessage5 = ProcessMessage5;
		_processMessage6 = ProcessMessage6;
		_processMessage7 = ProcessMessage7;
		_processMessage8 = ProcessMessage8;
		_processMessage9 = ProcessMessage9;
		_processMessageCleanup = ProcessMessageCleanup;
		_processMessageCleanupError = ProcessMessageCleanupError;
	}

	internal void AfterReceiveRequest(ref MessageRpc rpc)
	{
		if (_messageInspectors.Length != 0)
		{
			AfterReceiveRequestCore(ref rpc);
		}
	}

	internal void AfterReceiveRequestCore(ref MessageRpc rpc)
	{
		int messageInspectorCorrelationOffset = MessageInspectorCorrelationOffset;
		try
		{
			for (int i = 0; i < _messageInspectors.Length; i++)
			{
				rpc.Correlation[messageInspectorCorrelationOffset + i] = _messageInspectors[i].AfterReceiveRequest(ref rpc.Request, (IClientChannel)rpc.Channel.Proxy, rpc.InstanceContext);
				if (WcfEventSource.Instance.MessageInspectorAfterReceiveInvokedIsEnabled())
				{
					WcfEventSource.Instance.MessageInspectorAfterReceiveInvoked(rpc.EventTraceActivity, _messageInspectors[i].GetType().FullName);
				}
			}
		}
		catch (Exception ex)
		{
			if (Fx.IsFatal(ex))
			{
				throw;
			}
			if (ErrorBehavior.ShouldRethrowExceptionAsIs(ex))
			{
				throw;
			}
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperCallback(ex);
		}
	}

	private void BeforeSendReply(ref MessageRpc rpc, ref Exception exception, ref bool thereIsAnUnhandledException)
	{
		if (_messageInspectors.Length != 0)
		{
			BeforeSendReplyCore(ref rpc, ref exception, ref thereIsAnUnhandledException);
		}
	}

	internal void BeforeSendReplyCore(ref MessageRpc rpc, ref Exception exception, ref bool thereIsAnUnhandledException)
	{
		int messageInspectorCorrelationOffset = MessageInspectorCorrelationOffset;
		for (int i = 0; i < _messageInspectors.Length; i++)
		{
			try
			{
				Message reply = rpc.Reply;
				Message reply2 = reply;
				_messageInspectors[i].BeforeSendReply(ref reply2, rpc.Correlation[messageInspectorCorrelationOffset + i]);
				if (WcfEventSource.Instance.MessageInspectorBeforeSendInvokedIsEnabled())
				{
					WcfEventSource.Instance.MessageInspectorBeforeSendInvoked(rpc.EventTraceActivity, _messageInspectors[i].GetType().FullName);
				}
				if (reply2 == null && reply != null)
				{
					string message = System.SR.Format(System.SR.SFxNullReplyFromExtension2, _messageInspectors[i].GetType().ToString(), rpc.Operation.Name ?? "");
					ErrorBehavior.ThrowAndCatch(new InvalidOperationException(message));
				}
				rpc.Reply = reply2;
			}
			catch (Exception ex)
			{
				if (Fx.IsFatal(ex))
				{
					throw;
				}
				if (!ErrorBehavior.ShouldRethrowExceptionAsIs(ex))
				{
					throw DiagnosticUtility.ExceptionUtility.ThrowHelperCallback(ex);
				}
				if (exception == null)
				{
					exception = ex;
				}
				thereIsAnUnhandledException = !_error.HandleError(ex) | thereIsAnUnhandledException;
			}
		}
	}

	private void Reply(ref MessageRpc rpc)
	{
		rpc.RequestContextThrewOnReply = true;
		rpc.SuccessfullySendReply = false;
		try
		{
			rpc.RequestContext.Reply(rpc.Reply, rpc.ReplyTimeoutHelper.RemainingTime());
			rpc.RequestContextThrewOnReply = false;
			rpc.SuccessfullySendReply = true;
			if (WcfEventSource.Instance.DispatchMessageStopIsEnabled())
			{
				WcfEventSource.Instance.DispatchMessageStop(rpc.EventTraceActivity);
			}
		}
		catch (CommunicationException error)
		{
			_error.HandleError(error);
		}
		catch (TimeoutException error2)
		{
			_error.HandleError(error2);
		}
		catch (Exception ex)
		{
			if (Fx.IsFatal(ex))
			{
				throw;
			}
			if (!_error.HandleError(ex))
			{
				rpc.RequestContextThrewOnReply = true;
				rpc.CanSendReply = false;
			}
		}
	}

	private void BeginReply(ref MessageRpc rpc)
	{
		bool flag = false;
		try
		{
			IResumeMessageRpc state = rpc.Pause();
			rpc.AsyncResult = rpc.RequestContext.BeginReply(rpc.Reply, rpc.ReplyTimeoutHelper.RemainingTime(), s_onReplyCompleted, state);
			flag = true;
			if (rpc.AsyncResult.CompletedSynchronously)
			{
				rpc.UnPause();
			}
		}
		catch (CommunicationException error)
		{
			_error.HandleError(error);
		}
		catch (TimeoutException error2)
		{
			_error.HandleError(error2);
		}
		catch (Exception ex)
		{
			if (Fx.IsFatal(ex))
			{
				throw;
			}
			if (!_error.HandleError(ex))
			{
				rpc.RequestContextThrewOnReply = true;
				rpc.CanSendReply = false;
			}
		}
		finally
		{
			if (!flag)
			{
				rpc.UnPause();
			}
		}
	}

	internal bool Dispatch(ref MessageRpc rpc, bool isOperationContextSet)
	{
		rpc.ErrorProcessor = _processMessage8;
		rpc.NextProcessor = _processMessage1;
		return rpc.Process(isOperationContextSet);
	}

	private bool EndReply(ref MessageRpc rpc)
	{
		bool result = false;
		try
		{
			rpc.RequestContext.EndReply(rpc.AsyncResult);
			rpc.RequestContextThrewOnReply = false;
			result = true;
			if (WcfEventSource.Instance.DispatchMessageStopIsEnabled())
			{
				WcfEventSource.Instance.DispatchMessageStop(rpc.EventTraceActivity);
			}
		}
		catch (Exception ex)
		{
			if (Fx.IsFatal(ex))
			{
				throw;
			}
			_error.HandleError(ex);
		}
		return result;
	}

	private void SetActivityIdOnThread(ref MessageRpc rpc)
	{
		if (FxTrace.Trace.IsEnd2EndActivityTracingEnabled && rpc.EventTraceActivity != null)
		{
			EventTraceActivityHelper.SetOnThread(rpc.EventTraceActivity);
		}
	}

	private void TransferChannelFromPendingList(ref MessageRpc rpc)
	{
		if (!rpc.Channel.IsPending)
		{
			return;
		}
		rpc.Channel.IsPending = false;
		ChannelDispatcher channelDispatcher = rpc.Channel.ChannelDispatcher;
		IInstanceContextProvider instanceContextProvider = _instance.InstanceContextProvider;
		if (!InstanceContextProviderBase.IsProviderSessionful(instanceContextProvider) && !InstanceContextProviderBase.IsProviderSingleton(instanceContextProvider))
		{
			IChannel item = rpc.Channel.Proxy as IChannel;
			if (!rpc.InstanceContext.IncomingChannels.Contains(item))
			{
				channelDispatcher.Channels.Add(item);
			}
		}
		channelDispatcher.PendingChannels.Remove(rpc.Channel.Binder.Channel);
	}

	private void AddMessageProperties(Message message, OperationContext context, ServiceChannel replyChannel)
	{
		if (context.InternalServiceChannel == replyChannel)
		{
			if (context.HasOutgoingMessageHeaders)
			{
				message.Headers.CopyHeadersFrom(context.OutgoingMessageHeaders);
			}
			if (context.HasOutgoingMessageProperties)
			{
				message.Properties.MergeProperties(context.OutgoingMessageProperties);
			}
		}
	}

	private static void OnReplyCompletedCallback(IAsyncResult result)
	{
		if (!result.CompletedSynchronously)
		{
			if (!(result.AsyncState is IResumeMessageRpc resumeMessageRpc))
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgument(System.SR.SFxInvalidAsyncResultState0);
			}
			resumeMessageRpc.Resume(result);
		}
	}

	private void PrepareReply(ref MessageRpc rpc)
	{
		RequestContext requestContext = rpc.OperationContext.RequestContext;
		Exception exception = null;
		bool thereIsAnUnhandledException = false;
		if (!rpc.Operation.IsOneWay && requestContext != null && rpc.Reply != null)
		{
			try
			{
				rpc.CanSendReply = PrepareAndAddressReply(ref rpc);
			}
			catch (Exception ex)
			{
				if (Fx.IsFatal(ex))
				{
					throw;
				}
				thereIsAnUnhandledException = !_error.HandleError(ex);
				exception = ex;
			}
		}
		BeforeSendReply(ref rpc, ref exception, ref thereIsAnUnhandledException);
		if (rpc.Operation.IsOneWay)
		{
			rpc.CanSendReply = false;
		}
		if (!rpc.Operation.IsOneWay && requestContext != null && rpc.Reply != null)
		{
			if (exception == null)
			{
				return;
			}
			rpc.Error = exception;
			_error.ProvideOnlyFaultOfLastResort(ref rpc);
			try
			{
				rpc.CanSendReply = PrepareAndAddressReply(ref rpc);
				return;
			}
			catch (Exception ex2)
			{
				if (Fx.IsFatal(ex2))
				{
					throw;
				}
				_error.HandleError(ex2);
				return;
			}
		}
		if (exception != null && thereIsAnUnhandledException)
		{
			rpc.Abort();
		}
	}

	private bool PrepareAndAddressReply(ref MessageRpc rpc)
	{
		bool result = true;
		if (!ManualAddressing)
		{
			if ((object)rpc.RequestID != null)
			{
				RequestReplyCorrelator.PrepareReply(rpc.Reply, rpc.RequestID);
			}
			if (!rpc.Channel.HasSession)
			{
				result = RequestReplyCorrelator.AddressReply(rpc.Reply, rpc.ReplyToInfo);
			}
		}
		AddMessageProperties(rpc.Reply, rpc.OperationContext, rpc.Channel);
		if (FxTrace.Trace.IsEnd2EndActivityTracingEnabled && rpc.EventTraceActivity != null)
		{
			rpc.Reply.Properties[EventTraceActivity.Name] = rpc.EventTraceActivity;
		}
		return result;
	}

	internal DispatchOperationRuntime GetOperation(ref Message message)
	{
		return _demuxer.GetOperation(ref message);
	}

	internal bool IsConcurrent(ref MessageRpc rpc)
	{
		return _concurrency.IsConcurrent(ref rpc);
	}

	internal void ProcessMessage1(ref MessageRpc rpc)
	{
		rpc.NextProcessor = _processMessage11;
		if (!rpc.IsPaused)
		{
			ProcessMessage11(ref rpc);
		}
	}

	internal void ProcessMessage11(ref MessageRpc rpc)
	{
		rpc.NextProcessor = _processMessage2;
		if (rpc.Operation.IsOneWay)
		{
			rpc.RequestContext.Reply(null);
			rpc.OperationContext.RequestContext = null;
		}
		else
		{
			if (!rpc.Channel.IsReplyChannel && (object)rpc.RequestID == null && rpc.Operation.Action != "*")
			{
				CommunicationException exception = new CommunicationException(System.SR.SFxOneWayMessageToTwoWayMethod0);
				throw TraceUtility.ThrowHelperError(exception, rpc.Request);
			}
			if (!ManualAddressing)
			{
				EndpointAddress replyTo = rpc.ReplyToInfo.ReplyTo;
				if (replyTo != null && replyTo.IsNone && rpc.Channel.IsReplyChannel)
				{
					CommunicationException exception2 = new CommunicationException(System.SR.SFxRequestReplyNone);
					throw TraceUtility.ThrowHelperError(exception2, rpc.Request);
				}
			}
		}
		if (_concurrency.IsConcurrent(ref rpc))
		{
			rpc.Channel.IncrementActivity();
			rpc.SuccessfullyIncrementedActivity = true;
		}
		_instance.EnsureInstanceContext(ref rpc);
		TransferChannelFromPendingList(ref rpc);
		if (!rpc.IsPaused)
		{
			ProcessMessage2(ref rpc);
		}
	}

	private void ProcessMessage2(ref MessageRpc rpc)
	{
		rpc.NextProcessor = _processMessage3;
		AfterReceiveRequest(ref rpc);
		_concurrency.LockInstance(ref rpc);
		if (!rpc.IsPaused)
		{
			ProcessMessage3(ref rpc);
		}
	}

	private void ProcessMessage3(ref MessageRpc rpc)
	{
		rpc.NextProcessor = _processMessage31;
		rpc.SuccessfullyLockedInstance = true;
		if (!rpc.IsPaused)
		{
			ProcessMessage31(ref rpc);
		}
	}

	private void ProcessMessage31(ref MessageRpc rpc)
	{
		rpc.NextProcessor = _processMessage4;
		if (!rpc.IsPaused)
		{
			ProcessMessage4(ref rpc);
		}
	}

	private void ProcessMessage4(ref MessageRpc rpc)
	{
		rpc.NextProcessor = _processMessage41;
		try
		{
			_thread.BindThread(ref rpc);
		}
		catch (Exception ex)
		{
			if (Fx.IsFatal(ex))
			{
				throw;
			}
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperFatal(ex.Message, ex);
		}
		if (!rpc.IsPaused)
		{
			ProcessMessage41(ref rpc);
		}
	}

	private void ProcessMessage41(ref MessageRpc rpc)
	{
		rpc.NextProcessor = _processMessage5;
		if (_concurrency.IsConcurrent(ref rpc))
		{
			rpc.EnsureReceive();
		}
		_instance.EnsureServiceInstance(ref rpc);
		if (!rpc.IsPaused)
		{
			ProcessMessage5(ref rpc);
		}
	}

	private void ProcessMessage5(ref MessageRpc rpc)
	{
		rpc.NextProcessor = _processMessage6;
		bool flag = false;
		try
		{
			rpc.PrepareInvokeContinueGate();
			SetActivityIdOnThread(ref rpc);
			rpc.Operation.InvokeBegin(ref rpc);
			flag = true;
		}
		finally
		{
			try
			{
				if (rpc.IsPaused && rpc.UnlockInvokeContinueGate(out rpc.AsyncResult))
				{
					rpc.UnPause();
				}
			}
			catch (Exception ex)
			{
				if (Fx.IsFatal(ex))
				{
					throw;
				}
				if (flag && !rpc.IsPaused)
				{
					throw;
				}
				_error.HandleError(ex);
			}
		}
		if (!rpc.IsPaused)
		{
			ProcessMessage6(ref rpc);
		}
	}

	private void ProcessMessage6(ref MessageRpc rpc)
	{
		rpc.NextProcessor = _processMessage7;
		try
		{
			_thread.BindEndThread(ref rpc);
		}
		catch (Exception ex)
		{
			if (Fx.IsFatal(ex))
			{
				throw;
			}
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperFatal(ex.Message, ex);
		}
		if (!rpc.IsPaused)
		{
			ProcessMessage7(ref rpc);
		}
	}

	private void ProcessMessage7(ref MessageRpc rpc)
	{
		rpc.NextProcessor = null;
		rpc.Operation.InvokeEnd(ref rpc);
		ProcessMessage8(ref rpc);
	}

	private void ProcessMessage8(ref MessageRpc rpc)
	{
		rpc.NextProcessor = _processMessage9;
		try
		{
			_error.ProvideMessageFault(ref rpc);
		}
		catch (Exception ex)
		{
			if (Fx.IsFatal(ex))
			{
				throw;
			}
			_error.HandleError(ex);
		}
		PrepareReply(ref rpc);
		if (rpc.CanSendReply)
		{
			rpc.ReplyTimeoutHelper = new TimeoutHelper(rpc.Channel.OperationTimeout);
		}
		if (!rpc.IsPaused)
		{
			ProcessMessage9(ref rpc);
		}
	}

	private void ProcessMessage9(ref MessageRpc rpc)
	{
		rpc.NextProcessor = _processMessageCleanup;
		if (rpc.CanSendReply)
		{
			if (rpc.Reply != null)
			{
				TraceUtility.MessageFlowAtMessageSent(rpc.Reply, rpc.EventTraceActivity);
			}
			if (_sendAsynchronously)
			{
				BeginReply(ref rpc);
			}
			else
			{
				Reply(ref rpc);
			}
		}
		if (!rpc.IsPaused)
		{
			ProcessMessageCleanup(ref rpc);
		}
	}

	private void ProcessMessageCleanup(ref MessageRpc rpc)
	{
		rpc.ErrorProcessor = _processMessageCleanupError;
		bool flag = false;
		if (rpc.CanSendReply)
		{
			flag = ((!_sendAsynchronously) ? rpc.SuccessfullySendReply : EndReply(ref rpc));
		}
		try
		{
			try
			{
				if (rpc.DidDeserializeRequestBody)
				{
					rpc.Request.Close();
				}
			}
			catch (Exception ex)
			{
				if (Fx.IsFatal(ex))
				{
					throw;
				}
				_error.HandleError(ex);
			}
			rpc.DisposeParameters(excludeInput: false);
			if (rpc.FaultInfo.IsConsideredUnhandled)
			{
				if (!flag)
				{
					rpc.AbortRequestContext();
					rpc.AbortChannel();
				}
				else
				{
					rpc.CloseRequestContext();
					rpc.CloseChannel();
				}
				rpc.AbortInstanceContext();
			}
			else if (rpc.RequestContextThrewOnReply)
			{
				rpc.AbortRequestContext();
			}
			else
			{
				rpc.CloseRequestContext();
			}
			if (rpc.Reply != null && rpc.Reply != rpc.ReturnParameter)
			{
				try
				{
					rpc.Reply.Close();
				}
				catch (Exception ex2)
				{
					if (Fx.IsFatal(ex2))
					{
						throw;
					}
					_error.HandleError(ex2);
				}
			}
			if (rpc.FaultInfo.Fault != null && rpc.FaultInfo.Fault.State != MessageState.Closed)
			{
				try
				{
					rpc.FaultInfo.Fault.Close();
				}
				catch (Exception ex3)
				{
					if (Fx.IsFatal(ex3))
					{
						throw;
					}
					_error.HandleError(ex3);
				}
			}
			try
			{
				rpc.OperationContext.FireOperationCompleted();
			}
			catch (Exception ex4)
			{
				if (Fx.IsFatal(ex4))
				{
					throw;
				}
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperCallback(ex4);
			}
			_instance.AfterReply(ref rpc, _error);
			if (rpc.SuccessfullyLockedInstance)
			{
				try
				{
					_concurrency.UnlockInstance(ref rpc);
				}
				catch (Exception ex5)
				{
					if (Fx.IsFatal(ex5))
					{
						throw;
					}
					rpc.InstanceContext.FaultInternal();
					_error.HandleError(ex5);
				}
			}
			if (_terminate != null)
			{
				try
				{
					_terminate.AfterReply(ref rpc);
				}
				catch (Exception ex6)
				{
					if (Fx.IsFatal(ex6))
					{
						throw;
					}
					_error.HandleError(ex6);
				}
			}
			if (rpc.SuccessfullyIncrementedActivity)
			{
				try
				{
					rpc.Channel.DecrementActivity();
				}
				catch (Exception ex7)
				{
					if (Fx.IsFatal(ex7))
					{
						throw;
					}
					_error.HandleError(ex7);
				}
			}
		}
		finally
		{
			if (rpc.Activity != null && DiagnosticUtility.ShouldUseActivity)
			{
				rpc.Activity.Stop();
			}
		}
		_error.HandleError(ref rpc);
	}

	private void ProcessMessageCleanupError(ref MessageRpc rpc)
	{
		_error.HandleError(ref rpc);
	}
}
