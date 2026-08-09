using System.Reflection;
using System.Runtime;
using System.Runtime.Diagnostics;
using System.ServiceModel.Diagnostics;
using System.Threading.Tasks;

namespace System.ServiceModel.Dispatcher;

public class SyncMethodInvoker : IOperationInvoker
{
	private InvokeDelegate _invokeDelegate;

	private int _inputParameterCount;

	private int _outputParameterCount;

	private string _methodName;

	public MethodInfo Method { get; }

	public string MethodName
	{
		get
		{
			if (_methodName == null)
			{
				_methodName = Method.Name;
			}
			return _methodName;
		}
	}

	public SyncMethodInvoker(MethodInfo method)
	{
		Method = method ?? throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentNullException("method"));
	}

	public object[] AllocateInputs()
	{
		EnsureIsInitialized();
		return EmptyArray<object>.Allocate(_inputParameterCount);
	}

	public IAsyncResult InvokeBegin(object instance, object[] inputs, AsyncCallback callback, object state)
	{
		return InvokeAsync(instance, inputs).ToApm(callback, state);
	}

	public object InvokeEnd(object instance, out object[] outputs, IAsyncResult result)
	{
		if (!(result is Task<Tuple<object, object[]>> { Result: var result2 }))
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentException(System.SR.SFxInvalidCallbackIAsyncResult));
		}
		outputs = result2.Item2;
		return result2.Item1;
	}

	private Task<Tuple<object, object[]>> InvokeAsync(object instance, object[] inputs)
	{
		EnsureIsInitialized();
		if (instance == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.SFxNoServiceObject));
		}
		if (inputs == null)
		{
			if (_inputParameterCount > 0)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.Format(System.SR.SFxInputParametersToServiceNull, _inputParameterCount)));
			}
		}
		else if (inputs.Length != _inputParameterCount)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.Format(System.SR.SFxInputParametersToServiceInvalid, _inputParameterCount, inputs.Length)));
		}
		object[] array = EmptyArray<object>.Allocate(_outputParameterCount);
		long num = 0L;
		bool flag = false;
		bool flag2 = false;
		EventTraceActivity eventTraceActivity = null;
		if (WcfEventSource.Instance.OperationCompletedIsEnabled() || WcfEventSource.Instance.OperationFaultedIsEnabled() || WcfEventSource.Instance.OperationFailedIsEnabled())
		{
			num = DateTime.UtcNow.Ticks;
			OperationContext current = OperationContext.Current;
			if (current != null && current.IncomingMessage != null)
			{
				eventTraceActivity = EventTraceActivityHelper.TryExtractActivity(current.IncomingMessage);
			}
		}
		object item;
		try
		{
			ServiceModelActivity serviceModelActivity = null;
			IDisposable disposable = null;
			if (DiagnosticUtility.ShouldUseActivity)
			{
				serviceModelActivity = ServiceModelActivity.CreateBoundedActivity(suspendCurrent: true);
				disposable = serviceModelActivity;
			}
			else if (TraceUtility.MessageFlowTracingOnly)
			{
				Guid receivedActivityId = TraceUtility.GetReceivedActivityId(OperationContext.Current);
				if (receivedActivityId != Guid.Empty)
				{
					DiagnosticTraceBase.ActivityId = receivedActivityId;
				}
			}
			else if (TraceUtility.ShouldPropagateActivity)
			{
				Guid guid = ActivityIdHeader.ExtractActivityId(OperationContext.Current.IncomingMessage);
				if (guid != Guid.Empty)
				{
					disposable = Activity.CreateActivity(guid);
				}
			}
			using (disposable)
			{
				if (DiagnosticUtility.ShouldUseActivity)
				{
					ServiceModelActivity.Start(serviceModelActivity, System.SR.Format(System.SR.ActivityExecuteMethod, Method.DeclaringType.FullName, Method.Name), ActivityType.ExecuteUserCode);
				}
				if (WcfEventSource.Instance.OperationInvokedIsEnabled())
				{
					WcfEventSource.Instance.OperationInvoked(eventTraceActivity, MethodName, TraceUtility.GetCallerInfo(OperationContext.Current));
				}
				item = _invokeDelegate(instance, inputs, array);
				flag = true;
			}
		}
		catch (FaultException)
		{
			flag2 = true;
			throw;
		}
		finally
		{
			if (num != 0L)
			{
				if (flag)
				{
					if (WcfEventSource.Instance.OperationCompletedIsEnabled())
					{
						WcfEventSource.Instance.OperationCompleted(eventTraceActivity, _methodName, TraceUtility.GetUtcBasedDurationForTrace(num));
					}
				}
				else if (flag2)
				{
					if (WcfEventSource.Instance.OperationFaultedIsEnabled())
					{
						WcfEventSource.Instance.OperationFaulted(eventTraceActivity, _methodName, TraceUtility.GetUtcBasedDurationForTrace(num));
					}
				}
				else if (WcfEventSource.Instance.OperationFailedIsEnabled())
				{
					WcfEventSource.Instance.OperationFailed(eventTraceActivity, _methodName, TraceUtility.GetUtcBasedDurationForTrace(num));
				}
			}
		}
		return Task.FromResult(Tuple.Create(item, array));
	}

	private void EnsureIsInitialized()
	{
		if (_invokeDelegate == null)
		{
			EnsureIsInitializedCore();
		}
	}

	private void EnsureIsInitializedCore()
	{
		int inputParameterCount;
		int outputParameterCount;
		InvokeDelegate invokeDelegate = new InvokerUtil().GenerateInvokeDelegate(Method, out inputParameterCount, out outputParameterCount);
		_outputParameterCount = outputParameterCount;
		_inputParameterCount = inputParameterCount;
		_invokeDelegate = invokeDelegate;
	}
}
