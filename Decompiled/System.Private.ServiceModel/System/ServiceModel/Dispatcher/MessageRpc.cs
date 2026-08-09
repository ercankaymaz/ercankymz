using System.Collections.ObjectModel;
using System.Runtime;
using System.Runtime.Diagnostics;
using System.Security;
using System.ServiceModel.Channels;
using System.ServiceModel.Diagnostics;
using System.Xml;

namespace System.ServiceModel.Dispatcher;

internal struct MessageRpc
{
	private class CallbackState
	{
		public ChannelHandler ChannelHandler { get; set; }
	}

	internal class Wrapper : IResumeMessageRpc
	{
		private MessageRpc _rpc;

		private bool _alreadyResumed;

		internal Wrapper(ref MessageRpc rpc)
		{
			_rpc = rpc;
			_ = rpc.NextProcessor;
			_rpc.IncrementBusyCount();
		}

		public InstanceContext GetMessageInstanceContext()
		{
			return _rpc.InstanceContext;
		}

		public void Resume(out bool alreadyResumedNoLock)
		{
			try
			{
				alreadyResumedNoLock = _alreadyResumed;
				_alreadyResumed = true;
				_rpc.SwitchedThreads = true;
				if (_rpc.Process(isOperationContextSet: false) && !_rpc.InvokeNotification.DidInvokerEnsurePump)
				{
					_rpc.EnsureReceive();
				}
			}
			finally
			{
				_rpc.DecrementBusyCount();
			}
		}

		public void Resume(IAsyncResult result)
		{
			_rpc.AsyncResult = result;
			Resume();
		}

		public void Resume(object instance)
		{
			_rpc.Instance = instance;
			Resume();
		}

		public void Resume()
		{
			using (ServiceModelActivity.BoundOperation(_rpc.Activity, addTransfer: true))
			{
				Resume(out var alreadyResumedNoLock);
				if (alreadyResumedNoLock)
				{
					string message = System.SR.Format(System.SR.SFxMultipleCallbackFromAsyncOperation, string.Empty);
					Exception exception = new InvalidOperationException(message);
					throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(exception);
				}
			}
		}

		public void SignalConditionalResume(IAsyncResult result)
		{
			if (_rpc._invokeContinueGate.Signal(result))
			{
				_rpc.AsyncResult = result;
				Resume();
			}
		}
	}

	internal readonly ServiceChannel Channel;

	internal readonly ChannelHandler channelHandler;

	internal readonly object[] Correlation;

	internal readonly OperationContext OperationContext;

	internal ServiceModelActivity Activity;

	internal Guid ResponseActivityId;

	internal IAsyncResult AsyncResult;

	internal bool CanSendReply;

	internal bool SuccessfullySendReply;

	internal object[] InputParameters;

	internal object[] OutputParameters;

	internal object ReturnParameter;

	internal bool ParametersDisposed;

	internal bool DidDeserializeRequestBody;

	internal Exception Error;

	internal MessageRpcProcessor ErrorProcessor;

	internal ErrorHandlerFaultInfo FaultInfo;

	internal bool HasSecurityContext;

	internal object Instance;

	internal bool MessageRpcOwnsInstanceContextThrottle;

	internal MessageRpcProcessor NextProcessor;

	internal Collection<MessageHeaderInfo> NotUnderstoodHeaders;

	internal DispatchOperationRuntime Operation;

	internal Message Request;

	internal RequestContext RequestContext;

	internal bool RequestContextThrewOnReply;

	internal UniqueId RequestID;

	internal Message Reply;

	internal TimeoutHelper ReplyTimeoutHelper;

	internal RequestReplyCorrelator.ReplyToInfo ReplyToInfo;

	internal MessageVersion RequestVersion;

	internal ServiceSecurityContext SecurityContext;

	internal InstanceContext InstanceContext;

	internal bool SuccessfullyBoundInstance;

	internal bool SuccessfullyIncrementedActivity;

	internal bool SuccessfullyLockedInstance;

	internal MessageRpcInvokeNotification InvokeNotification;

	internal EventTraceActivity EventTraceActivity;

	private bool _isInstanceContextSingleton;

	private SignalGate<IAsyncResult> _invokeContinueGate;

	internal bool IsPaused { get; private set; }

	internal bool SwitchedThreads { get; private set; }

	internal MessageRpc(RequestContext requestContext, Message request, DispatchOperationRuntime operation, ServiceChannel channel, ChannelHandler channelHandler, bool cleanThread, OperationContext operationContext, InstanceContext instanceContext, EventTraceActivity eventTraceActivity)
	{
		Activity = null;
		EventTraceActivity = eventTraceActivity;
		AsyncResult = null;
		CanSendReply = true;
		Channel = channel;
		this.channelHandler = channelHandler;
		Correlation = EmptyArray<object>.Allocate(operation.Parent.CorrelationCount);
		DidDeserializeRequestBody = false;
		Error = null;
		ErrorProcessor = null;
		FaultInfo = new ErrorHandlerFaultInfo(request.Version.Addressing.DefaultFaultAction);
		HasSecurityContext = false;
		Instance = null;
		MessageRpcOwnsInstanceContextThrottle = false;
		NextProcessor = null;
		NotUnderstoodHeaders = null;
		Operation = operation;
		OperationContext = operationContext;
		IsPaused = false;
		ParametersDisposed = false;
		Request = request;
		RequestContext = requestContext;
		RequestContextThrewOnReply = false;
		SuccessfullySendReply = false;
		RequestVersion = request.Version;
		Reply = null;
		ReplyTimeoutHelper = default(TimeoutHelper);
		SecurityContext = null;
		InstanceContext = instanceContext;
		SuccessfullyBoundInstance = false;
		SuccessfullyIncrementedActivity = false;
		SuccessfullyLockedInstance = false;
		SwitchedThreads = !cleanThread;
		InputParameters = null;
		OutputParameters = null;
		ReturnParameter = null;
		_isInstanceContextSingleton = false;
		_invokeContinueGate = null;
		if (!operation.IsOneWay && !operation.Parent.ManualAddressing)
		{
			RequestID = request.Headers.MessageId;
			ReplyToInfo = new RequestReplyCorrelator.ReplyToInfo(request);
		}
		else
		{
			RequestID = null;
			ReplyToInfo = default(RequestReplyCorrelator.ReplyToInfo);
		}
		if (DiagnosticUtility.ShouldUseActivity)
		{
			Activity = TraceUtility.ExtractActivity(Request);
		}
		if (DiagnosticUtility.ShouldUseActivity || TraceUtility.ShouldPropagateActivity)
		{
			ResponseActivityId = ActivityIdHeader.ExtractActivityId(Request);
		}
		else
		{
			ResponseActivityId = Guid.Empty;
		}
		InvokeNotification = new MessageRpcInvokeNotification(Activity, this.channelHandler);
		if (EventTraceActivity == null && FxTrace.Trace.IsEnd2EndActivityTracingEnabled && Request != null)
		{
			EventTraceActivity = EventTraceActivityHelper.TryExtractActivity(Request, createIfNotExist: true);
		}
	}

	internal void Abort()
	{
		AbortRequestContext();
		AbortChannel();
		AbortInstanceContext();
	}

	private void AbortRequestContext(RequestContext requestContext)
	{
		try
		{
			requestContext.Abort();
		}
		catch (Exception ex)
		{
			if (Fx.IsFatal(ex))
			{
				throw;
			}
			channelHandler.HandleError(ex);
		}
	}

	internal void AbortRequestContext()
	{
		if (OperationContext.RequestContext != null)
		{
			AbortRequestContext(OperationContext.RequestContext);
		}
		if (RequestContext != null && RequestContext != OperationContext.RequestContext)
		{
			AbortRequestContext(RequestContext);
		}
		TraceCallDurationInDispatcherIfNecessary(requestContextWasClosedSuccessfully: false);
	}

	private void TraceCallDurationInDispatcherIfNecessary(bool requestContextWasClosedSuccessfully)
	{
	}

	internal void CloseRequestContext()
	{
		if (OperationContext.RequestContext != null)
		{
			DisposeRequestContext(OperationContext.RequestContext);
		}
		if (RequestContext != null && RequestContext != OperationContext.RequestContext)
		{
			DisposeRequestContext(RequestContext);
		}
		TraceCallDurationInDispatcherIfNecessary(requestContextWasClosedSuccessfully: true);
	}

	private void DisposeRequestContext(RequestContext context)
	{
		try
		{
			context.Close();
		}
		catch (Exception ex)
		{
			if (Fx.IsFatal(ex))
			{
				throw;
			}
			AbortRequestContext(context);
			channelHandler.HandleError(ex);
		}
	}

	internal void AbortChannel()
	{
		if (Channel == null || !Channel.HasSession)
		{
			return;
		}
		try
		{
			Channel.Abort();
		}
		catch (Exception ex)
		{
			if (Fx.IsFatal(ex))
			{
				throw;
			}
			channelHandler.HandleError(ex);
		}
	}

	internal void CloseChannel()
	{
		if (Channel == null || !Channel.HasSession)
		{
			return;
		}
		try
		{
			Channel.Close(ChannelHandler.CloseAfterFaultTimeout);
		}
		catch (Exception ex)
		{
			if (Fx.IsFatal(ex))
			{
				throw;
			}
			channelHandler.HandleError(ex);
		}
	}

	internal void AbortInstanceContext()
	{
		if (InstanceContext == null || _isInstanceContextSingleton)
		{
			return;
		}
		try
		{
			InstanceContext.Abort();
		}
		catch (Exception ex)
		{
			if (Fx.IsFatal(ex))
			{
				throw;
			}
			channelHandler.HandleError(ex);
		}
	}

	internal void EnsureReceive()
	{
		using (ServiceModelActivity.BoundOperation(Activity))
		{
			ChannelHandler.Register(channelHandler);
		}
	}

	private bool ProcessError(Exception e)
	{
		MessageRpcProcessor errorProcessor = ErrorProcessor;
		try
		{
			if (TraceUtility.MessageFlowTracingOnly)
			{
				TraceUtility.SetActivityId(Request.Properties);
				if (Guid.Empty == DiagnosticTraceBase.ActivityId)
				{
					Guid guid = TraceUtility.ExtractActivityId(Request);
					if (Guid.Empty != guid)
					{
						DiagnosticTraceBase.ActivityId = guid;
					}
				}
			}
			Error = e;
			if (ErrorProcessor != null)
			{
				ErrorProcessor(ref this);
			}
			return Error == null;
		}
		catch (Exception ex)
		{
			if (Fx.IsFatal(ex))
			{
				throw;
			}
			return errorProcessor != ErrorProcessor && ProcessError(ex);
		}
	}

	internal void DisposeParameters(bool excludeInput)
	{
		if (Operation.DisposeParameters)
		{
			DisposeParametersCore(excludeInput);
		}
	}

	internal void DisposeParametersCore(bool excludeInput)
	{
		if (ParametersDisposed)
		{
			return;
		}
		if (!excludeInput)
		{
			DisposeParameterList(InputParameters);
		}
		DisposeParameterList(OutputParameters);
		if (ReturnParameter is IDisposable disposable)
		{
			try
			{
				disposable.Dispose();
			}
			catch (Exception ex)
			{
				if (Fx.IsFatal(ex))
				{
					throw;
				}
				channelHandler.HandleError(ex);
			}
		}
		ParametersDisposed = true;
	}

	private void DisposeParameterList(object[] parameters)
	{
		IDisposable disposable = null;
		if (parameters == null)
		{
			return;
		}
		foreach (object obj in parameters)
		{
			if (!(obj is IDisposable disposable2))
			{
				continue;
			}
			try
			{
				disposable2.Dispose();
			}
			catch (Exception ex)
			{
				if (Fx.IsFatal(ex))
				{
					throw;
				}
				channelHandler.HandleError(ex);
			}
		}
	}

	internal IResumeMessageRpc Pause()
	{
		Wrapper result = new Wrapper(ref this);
		IsPaused = true;
		return result;
	}

	[SecuritySafeCritical]
	internal bool Process(bool isOperationContextSet)
	{
		using (ServiceModelActivity.BoundOperation(Activity))
		{
			bool flag = true;
			if (NextProcessor != null)
			{
				MessageRpcProcessor nextProcessor = NextProcessor;
				NextProcessor = null;
				OperationContext current = (isOperationContextSet ? null : OperationContext.Current);
				IncrementBusyCount();
				try
				{
					if (!isOperationContextSet)
					{
						OperationContext.Current = OperationContext;
					}
					nextProcessor(ref this);
					if (!IsPaused)
					{
						OperationContext.SetClientReply(null, closeMessage: false);
					}
				}
				catch (Exception ex)
				{
					if (Fx.IsFatal(ex))
					{
						throw;
					}
					if (!ProcessError(ex) && FaultInfo.Fault == null)
					{
						Abort();
					}
				}
				finally
				{
					try
					{
						DecrementBusyCount();
						if (!isOperationContextSet)
						{
							OperationContext.Current = current;
						}
						flag = !IsPaused;
						if (flag)
						{
							channelHandler.DispatchDone();
							OperationContext.ClearClientReplyNoThrow();
						}
					}
					catch (Exception ex2)
					{
						if (Fx.IsFatal(ex2))
						{
							throw;
						}
						throw DiagnosticUtility.ExceptionUtility.ThrowHelperFatal(ex2.Message, ex2);
					}
				}
			}
			return flag;
		}
	}

	internal void UnPause()
	{
		IsPaused = false;
		DecrementBusyCount();
	}

	internal bool UnlockInvokeContinueGate(out IAsyncResult result)
	{
		return _invokeContinueGate.Unlock(out result);
	}

	internal void PrepareInvokeContinueGate()
	{
		_invokeContinueGate = new SignalGate<IAsyncResult>();
	}

	private void IncrementBusyCount()
	{
	}

	private void DecrementBusyCount()
	{
	}
}
