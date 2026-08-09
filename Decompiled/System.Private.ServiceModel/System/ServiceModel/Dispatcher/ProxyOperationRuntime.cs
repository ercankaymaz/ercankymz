using System.Collections.ObjectModel;
using System.Reflection;
using System.Runtime;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;

namespace System.ServiceModel.Dispatcher;

internal class ProxyOperationRuntime
{
	private readonly IClientMessageFormatter _formatter;

	private readonly bool _isSessionOpenNotificationEnabled;

	private readonly IParameterInspector[] _parameterInspectors;

	private readonly ImmutableClientRuntime _parent;

	private bool _deserializeReply;

	private string _replyAction;

	private MethodInfo _beginMethod;

	private MethodInfo _syncMethod;

	private MethodInfo _taskMethod;

	private ParameterInfo[] _inParams;

	private ParameterInfo[] _outParams;

	private ParameterInfo[] _endOutParams;

	private ParameterInfo _returnParam;

	internal string Action { get; }

	internal IClientFaultFormatter FaultFormatter { get; }

	internal bool IsInitiating { get; }

	internal bool IsOneWay { get; }

	internal bool IsTerminating { get; }

	internal bool IsSessionOpenNotificationEnabled => _isSessionOpenNotificationEnabled;

	internal string Name { get; }

	internal ImmutableClientRuntime Parent => _parent;

	internal string ReplyAction => _replyAction;

	internal bool DeserializeReply => _deserializeReply;

	internal bool SerializeRequest { get; }

	internal Type TaskTResult { get; set; }

	internal ProxyOperationRuntime(ClientOperation operation, ImmutableClientRuntime parent)
	{
		if (operation == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("operation");
		}
		_parent = parent ?? throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("parent");
		_formatter = operation.Formatter;
		IsInitiating = operation.IsInitiating;
		IsOneWay = operation.IsOneWay;
		IsTerminating = operation.IsTerminating;
		_isSessionOpenNotificationEnabled = operation.IsSessionOpenNotificationEnabled;
		Name = operation.Name;
		_parameterInspectors = EmptyArray<IParameterInspector>.ToArray(operation.ParameterInspectors);
		FaultFormatter = operation.FaultFormatter;
		SerializeRequest = operation.SerializeRequest;
		_deserializeReply = operation.DeserializeReply;
		Action = operation.Action;
		_replyAction = operation.ReplyAction;
		_beginMethod = operation.BeginMethod;
		_syncMethod = operation.SyncMethod;
		_taskMethod = operation.TaskMethod;
		TaskTResult = operation.TaskTResult;
		if (_beginMethod != null)
		{
			_inParams = ServiceReflector.GetInputParameters(_beginMethod, asyncPattern: true);
			if (_syncMethod != null)
			{
				_outParams = ServiceReflector.GetOutputParameters(_syncMethod, asyncPattern: false);
			}
			else
			{
				_outParams = Array.Empty<ParameterInfo>();
			}
			_endOutParams = ServiceReflector.GetOutputParameters(operation.EndMethod, asyncPattern: true);
			_returnParam = operation.EndMethod.ReturnParameter;
		}
		else if (_syncMethod != null)
		{
			_inParams = ServiceReflector.GetInputParameters(_syncMethod, asyncPattern: false);
			_outParams = ServiceReflector.GetOutputParameters(_syncMethod, asyncPattern: false);
			_returnParam = _syncMethod.ReturnParameter;
		}
		if (_formatter == null && (SerializeRequest || _deserializeReply))
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.Format(System.SR.ClientRuntimeRequiresFormatter0, Name)));
		}
	}

	internal void AfterReply(ref ProxyRpc rpc)
	{
		if (IsOneWay)
		{
			return;
		}
		Message reply = rpc.Reply;
		if (_deserializeReply)
		{
			if (WcfEventSource.Instance.ClientFormatterDeserializeReplyStartIsEnabled())
			{
				WcfEventSource.Instance.ClientFormatterDeserializeReplyStart(rpc.EventTraceActivity);
			}
			rpc.ReturnValue = _formatter.DeserializeReply(reply, rpc.OutputParameters);
			if (WcfEventSource.Instance.ClientFormatterDeserializeReplyStopIsEnabled())
			{
				WcfEventSource.Instance.ClientFormatterDeserializeReplyStop(rpc.EventTraceActivity);
			}
		}
		else
		{
			rpc.ReturnValue = reply;
		}
		int parameterInspectorCorrelationOffset = _parent.ParameterInspectorCorrelationOffset;
		try
		{
			for (int num = _parameterInspectors.Length - 1; num >= 0; num--)
			{
				_parameterInspectors[num].AfterCall(Name, rpc.OutputParameters, rpc.ReturnValue, rpc.Correlation[parameterInspectorCorrelationOffset + num]);
				if (WcfEventSource.Instance.ClientParameterInspectorAfterCallInvokedIsEnabled())
				{
					WcfEventSource.Instance.ClientParameterInspectorAfterCallInvoked(rpc.EventTraceActivity, _parameterInspectors[num].GetType().FullName);
				}
			}
		}
		catch (Exception ex)
		{
			if (Fx.IsFatal(ex))
			{
				throw;
			}
			if (ErrorBehavior.ShouldRethrowClientSideExceptionAsIs(ex))
			{
				throw;
			}
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperCallback(ex);
		}
		if (_parent.ValidateMustUnderstand)
		{
			Collection<MessageHeaderInfo> headersNotUnderstood = reply.Headers.GetHeadersNotUnderstood();
			if (headersNotUnderstood != null && headersNotUnderstood.Count > 0)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ProtocolException(System.SR.Format(System.SR.SFxHeaderNotUnderstood, headersNotUnderstood[0].Name, headersNotUnderstood[0].Namespace)));
			}
		}
	}

	internal void BeforeRequest(ref ProxyRpc rpc)
	{
		int parameterInspectorCorrelationOffset = _parent.ParameterInspectorCorrelationOffset;
		try
		{
			for (int i = 0; i < _parameterInspectors.Length; i++)
			{
				rpc.Correlation[parameterInspectorCorrelationOffset + i] = _parameterInspectors[i].BeforeCall(Name, rpc.InputParameters);
				if (WcfEventSource.Instance.ClientParameterInspectorBeforeCallInvokedIsEnabled())
				{
					WcfEventSource.Instance.ClientParameterInspectorBeforeCallInvoked(rpc.EventTraceActivity, _parameterInspectors[i].GetType().FullName);
				}
			}
		}
		catch (Exception ex)
		{
			if (Fx.IsFatal(ex))
			{
				throw;
			}
			if (ErrorBehavior.ShouldRethrowClientSideExceptionAsIs(ex))
			{
				throw;
			}
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperCallback(ex);
		}
		if (SerializeRequest)
		{
			if (WcfEventSource.Instance.ClientFormatterSerializeRequestStartIsEnabled())
			{
				WcfEventSource.Instance.ClientFormatterSerializeRequestStart(rpc.EventTraceActivity);
			}
			rpc.Request = _formatter.SerializeRequest(rpc.MessageVersion, rpc.InputParameters);
			if (WcfEventSource.Instance.ClientFormatterSerializeRequestStopIsEnabled())
			{
				WcfEventSource.Instance.ClientFormatterSerializeRequestStop(rpc.EventTraceActivity);
			}
		}
		else
		{
			if (rpc.InputParameters[0] == null)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.Format(System.SR.SFxProxyRuntimeMessageCannotBeNull, Name)));
			}
			rpc.Request = (Message)rpc.InputParameters[0];
			if (!IsValidAction(rpc.Request, Action))
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.Format(System.SR.SFxInvalidRequestAction, Name, rpc.Request.Headers.Action ?? "{NULL}", Action)));
			}
		}
	}

	internal static object GetDefaultParameterValue(Type parameterType)
	{
		if (!parameterType.IsValueType() || !(parameterType != typeof(void)))
		{
			return null;
		}
		return Activator.CreateInstance(parameterType);
	}

	internal bool IsSyncCall(MethodCall methodCall)
	{
		if (_syncMethod == null)
		{
			return false;
		}
		return methodCall.MethodBase.MethodHandle.Value.Equals((object?)(nint)_syncMethod.MethodHandle.Value);
	}

	internal bool IsBeginCall(MethodCall methodCall)
	{
		if (_beginMethod == null)
		{
			return false;
		}
		return methodCall.MethodBase.MethodHandle.Value.Equals((object?)(nint)_beginMethod.MethodHandle.Value);
	}

	internal bool IsTaskCall(MethodCall methodCall)
	{
		if (_taskMethod == null)
		{
			return false;
		}
		return methodCall.MethodBase.MethodHandle.Value.Equals((object?)(nint)_taskMethod.MethodHandle.Value);
	}

	internal object[] MapSyncInputs(MethodCall methodCall, out object[] outs)
	{
		if (_outParams.Length == 0)
		{
			outs = Array.Empty<object>();
		}
		else
		{
			outs = new object[_outParams.Length];
		}
		if (_inParams.Length == 0)
		{
			return Array.Empty<object>();
		}
		return methodCall.InArgs;
	}

	internal object[] MapAsyncBeginInputs(MethodCall methodCall, out AsyncCallback callback, out object asyncState)
	{
		object[] array = ((_inParams.Length != 0) ? new object[_inParams.Length] : Array.Empty<object>());
		object[] args = methodCall.Args;
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = args[_inParams[i].Position];
		}
		callback = args[methodCall.Args.Length - 2] as AsyncCallback;
		asyncState = args[methodCall.Args.Length - 1];
		return array;
	}

	internal void MapAsyncEndInputs(MethodCall methodCall, out IAsyncResult result, out object[] outs)
	{
		outs = new object[_endOutParams.Length];
		result = methodCall.Args[methodCall.Args.Length - 1] as IAsyncResult;
	}

	internal object[] MapSyncOutputs(MethodCall methodCall, object[] outs, ref object ret)
	{
		return MapOutputs(_outParams, methodCall, outs, ref ret);
	}

	internal object[] MapAsyncOutputs(MethodCall methodCall, object[] outs, ref object ret)
	{
		return MapOutputs(_endOutParams, methodCall, outs, ref ret);
	}

	private object[] MapOutputs(ParameterInfo[] parameters, MethodCall methodCall, object[] outs, ref object ret)
	{
		if (ret == null && _returnParam != null)
		{
			ret = GetDefaultParameterValue(TypeLoader.GetParameterType(_returnParam));
		}
		if (parameters.Length == 0)
		{
			return null;
		}
		object[] args = methodCall.Args;
		for (int i = 0; i < parameters.Length; i++)
		{
			if (outs[i] == null)
			{
				args[parameters[i].Position] = GetDefaultParameterValue(TypeLoader.GetParameterType(parameters[i]));
			}
			else
			{
				args[parameters[i].Position] = outs[i];
			}
		}
		return args;
	}

	internal static bool IsValidAction(Message message, string action)
	{
		if (message == null)
		{
			return false;
		}
		if (message.IsFault)
		{
			return true;
		}
		if (action == "*")
		{
			return true;
		}
		return string.CompareOrdinal(message.Headers.Action, action) == 0;
	}
}
