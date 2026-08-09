using System.Runtime;
using System.ServiceModel.Channels;
using System.ServiceModel.Diagnostics;

namespace System.ServiceModel.Dispatcher;

internal class DispatchOperationRuntime
{
	private static AsyncCallback s_invokeCallback = Fx.ThunkCallback(InvokeCallback);

	private readonly bool _isSessionOpenNotificationEnabled;

	private readonly bool _deserializeRequest;

	private readonly bool _serializeReply;

	private readonly bool _disposeParameters;

	internal string Action { get; }

	internal bool DisposeParameters => _disposeParameters;

	internal IDispatchFaultFormatter FaultFormatter { get; }

	internal IDispatchMessageFormatter Formatter { get; }

	internal IOperationInvoker Invoker { get; }

	internal bool IsOneWay { get; }

	internal bool IsTerminating { get; }

	internal string Name { get; }

	internal IParameterInspector[] ParameterInspectors { get; }

	internal ImmutableDispatchRuntime Parent { get; }

	internal string ReplyAction { get; }

	internal DispatchOperationRuntime(DispatchOperation operation, ImmutableDispatchRuntime parent)
	{
		if (operation == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("operation");
		}
		if (operation.Invoker == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.RuntimeRequiresInvoker0));
		}
		_disposeParameters = operation.AutoDisposeParameters && !operation.HasNoDisposableParameters;
		Parent = parent ?? throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("parent");
		ParameterInspectors = EmptyArray<IParameterInspector>.ToArray(operation.ParameterInspectors);
		FaultFormatter = operation.FaultFormatter;
		_deserializeRequest = operation.DeserializeRequest;
		_serializeReply = operation.SerializeReply;
		Formatter = operation.Formatter;
		Invoker = operation.Invoker;
		IsTerminating = operation.IsTerminating;
		_isSessionOpenNotificationEnabled = operation.IsSessionOpenNotificationEnabled;
		Action = operation.Action;
		Name = operation.Name;
		ReplyAction = operation.ReplyAction;
		IsOneWay = operation.IsOneWay;
		if (Formatter == null && (_deserializeRequest || _serializeReply))
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.Format(System.SR.DispatchRuntimeRequiresFormatter0, Name)));
		}
	}

	private void DeserializeInputs(ref MessageRpc rpc)
	{
		bool flag = false;
		try
		{
			rpc.InputParameters = Invoker.AllocateInputs();
			if (!_isSessionOpenNotificationEnabled)
			{
				if (_deserializeRequest)
				{
					if (WcfEventSource.Instance.DispatchFormatterDeserializeRequestStartIsEnabled())
					{
						WcfEventSource.Instance.DispatchFormatterDeserializeRequestStart(rpc.EventTraceActivity);
					}
					Formatter.DeserializeRequest(rpc.Request, rpc.InputParameters);
					if (WcfEventSource.Instance.DispatchFormatterDeserializeRequestStopIsEnabled())
					{
						WcfEventSource.Instance.DispatchFormatterDeserializeRequestStop(rpc.EventTraceActivity);
					}
				}
				else
				{
					rpc.InputParameters[0] = rpc.Request;
				}
			}
			flag = true;
		}
		finally
		{
			rpc.DidDeserializeRequestBody = rpc.Request.State != MessageState.Created;
			if (!flag && MessageLogger.LoggingEnabled)
			{
				MessageLogger.LogMessage(ref rpc.Request, MessageLoggingSource.Malformed);
			}
		}
	}

	private void InspectInputs(ref MessageRpc rpc)
	{
		if (ParameterInspectors.Length != 0)
		{
			InspectInputsCore(ref rpc);
		}
	}

	private void InspectInputsCore(ref MessageRpc rpc)
	{
		for (int i = 0; i < ParameterInspectors.Length; i++)
		{
			IParameterInspector parameterInspector = ParameterInspectors[i];
			rpc.Correlation[i] = parameterInspector.BeforeCall(Name, rpc.InputParameters);
			if (WcfEventSource.Instance.ParameterInspectorBeforeCallInvokedIsEnabled())
			{
				WcfEventSource.Instance.ParameterInspectorBeforeCallInvoked(rpc.EventTraceActivity, ParameterInspectors[i].GetType().FullName);
			}
		}
	}

	private void InspectOutputs(ref MessageRpc rpc)
	{
		if (ParameterInspectors.Length != 0)
		{
			InspectOutputsCore(ref rpc);
		}
	}

	private void InspectOutputsCore(ref MessageRpc rpc)
	{
		for (int num = ParameterInspectors.Length - 1; num >= 0; num--)
		{
			IParameterInspector parameterInspector = ParameterInspectors[num];
			parameterInspector.AfterCall(Name, rpc.OutputParameters, rpc.ReturnParameter, rpc.Correlation[num]);
			if (WcfEventSource.Instance.ParameterInspectorAfterCallInvokedIsEnabled())
			{
				WcfEventSource.Instance.ParameterInspectorAfterCallInvoked(rpc.EventTraceActivity, ParameterInspectors[num].GetType().FullName);
			}
		}
	}

	internal void InvokeBegin(ref MessageRpc rpc)
	{
		if (rpc.Error != null)
		{
			return;
		}
		object instance = rpc.Instance;
		DeserializeInputs(ref rpc);
		InspectInputs(ref rpc);
		ValidateMustUnderstand(ref rpc);
		bool flag = false;
		IResumeMessageRpc state = rpc.Pause();
		IAsyncResult asyncResult;
		try
		{
			asyncResult = Invoker.InvokeBegin(instance, rpc.InputParameters, s_invokeCallback, state);
			flag = true;
		}
		finally
		{
			if (!flag)
			{
				rpc.UnPause();
			}
		}
		if (asyncResult == null)
		{
			throw TraceUtility.ThrowHelperError(new ArgumentNullException("IOperationInvoker.BeginDispatch"), rpc.Request);
		}
		if (asyncResult.CompletedSynchronously)
		{
			rpc.UnPause();
			rpc.AsyncResult = asyncResult;
		}
	}

	private static void InvokeCallback(IAsyncResult result)
	{
		if (!result.CompletedSynchronously)
		{
			if (!(result.AsyncState is IResumeMessageRpc resumeMessageRpc))
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgument(System.SR.SFxInvalidAsyncResultState0);
			}
			resumeMessageRpc.SignalConditionalResume(result);
		}
	}

	internal void InvokeEnd(ref MessageRpc rpc)
	{
		if (rpc.Error == null)
		{
			rpc.ReturnParameter = Invoker.InvokeEnd(rpc.Instance, out rpc.OutputParameters, rpc.AsyncResult);
			InspectOutputs(ref rpc);
			SerializeOutputs(ref rpc);
		}
	}

	private void SerializeOutputs(ref MessageRpc rpc)
	{
		if (IsOneWay || !Parent.EnableFaults)
		{
			return;
		}
		Message message;
		if (_serializeReply)
		{
			if (WcfEventSource.Instance.DispatchFormatterSerializeReplyStartIsEnabled())
			{
				WcfEventSource.Instance.DispatchFormatterSerializeReplyStart(rpc.EventTraceActivity);
			}
			message = Formatter.SerializeReply(rpc.RequestVersion, rpc.OutputParameters, rpc.ReturnParameter);
			if (WcfEventSource.Instance.DispatchFormatterSerializeReplyStopIsEnabled())
			{
				WcfEventSource.Instance.DispatchFormatterSerializeReplyStop(rpc.EventTraceActivity);
			}
			if (message == null)
			{
				string message2 = System.SR.Format(System.SR.SFxNullReplyFromFormatter2, Formatter.GetType().ToString(), Name ?? "");
				ErrorBehavior.ThrowAndCatch(new InvalidOperationException(message2));
			}
		}
		else
		{
			if (rpc.ReturnParameter == null && rpc.OperationContext.RequestContext != null)
			{
				string message3 = System.SR.Format(System.SR.SFxDispatchRuntimeMessageCannotBeNull, Name);
				ErrorBehavior.ThrowAndCatch(new InvalidOperationException(message3));
			}
			message = (Message)rpc.ReturnParameter;
			if (message != null && !ProxyOperationRuntime.IsValidAction(message, ReplyAction))
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.Format(System.SR.SFxInvalidReplyAction, Name, message.Headers.Action ?? "{NULL}", ReplyAction)));
			}
		}
		if (DiagnosticUtility.ShouldUseActivity && rpc.Activity != null && message != null)
		{
			TraceUtility.SetActivity(message, rpc.Activity);
			if (TraceUtility.ShouldPropagateActivity)
			{
				TraceUtility.AddActivityHeader(message);
			}
		}
		else if (TraceUtility.ShouldPropagateActivity && message != null && rpc.ResponseActivityId != Guid.Empty)
		{
			ActivityIdHeader activityIdHeader = new ActivityIdHeader(rpc.ResponseActivityId);
			activityIdHeader.AddTo(message);
		}
		if (TraceUtility.MessageFlowTracingOnly)
		{
			if (rpc.OperationContext.IncomingMessage != null && MessageState.Closed != rpc.OperationContext.IncomingMessage.State)
			{
				FxTrace.Trace.SetAndTraceTransfer(TraceUtility.GetReceivedActivityId(rpc.OperationContext), emitTransfer: true);
			}
			else if (rpc.ResponseActivityId != Guid.Empty)
			{
				FxTrace.Trace.SetAndTraceTransfer(rpc.ResponseActivityId, emitTransfer: true);
			}
		}
		if (MessageLogger.LoggingEnabled && message != null)
		{
			MessageLogger.LogMessage(ref message, MessageLoggingSource.ServiceLevelSendReply | MessageLoggingSource.LastChance);
		}
		rpc.Reply = message;
	}

	private void ValidateMustUnderstand(ref MessageRpc rpc)
	{
		if (Parent.ValidateMustUnderstand)
		{
			rpc.NotUnderstoodHeaders = rpc.Request.Headers.GetHeadersNotUnderstood();
			if (rpc.NotUnderstoodHeaders != null)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new MustUnderstandSoapException(rpc.NotUnderstoodHeaders, rpc.Request.Version.Envelope));
			}
		}
	}
}
