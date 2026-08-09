using System.Reflection;
using System.Runtime;
using System.Runtime.Diagnostics;
using System.ServiceModel.Description;
using System.ServiceModel.Diagnostics;
using System.Threading.Tasks;

namespace System.ServiceModel.Dispatcher;

public class TaskMethodInvoker : IOperationInvoker
{
	private const string ResultMethodName = "Result";

	private InvokeDelegate _invokeDelegate;

	private int _inputParameterCount;

	private int _outputParameterCount;

	private string _methodName;

	private MethodInfo _taskTResultGetMethod;

	private bool _isGenericTask;

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

	public TaskMethodInvoker(MethodInfo taskMethod, Type taskType)
	{
		Method = taskMethod ?? throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentNullException("taskMethod"));
		if (taskType != ServiceReflector.VoidType)
		{
			_taskTResultGetMethod = ((PropertyInfo)taskMethod.ReturnType.GetMember("Result")[0]).GetGetMethod();
			_isGenericTask = true;
		}
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
		if (!(result is Task<Tuple<object, object[]>> task))
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentException(System.SR.SFxInvalidCallbackIAsyncResult));
		}
		AggregateException ex = null;
		Tuple<object, object[]> tuple = null;
		Task task2 = null;
		if (task.IsFaulted)
		{
			ex = task.Exception;
		}
		else
		{
			tuple = task.Result;
			task2 = tuple.Item1 as Task;
			if (task2.IsFaulted)
			{
				ex = task2.Exception;
			}
		}
		if (ex != null)
		{
			throw FxTrace.Exception.AsError<FaultException>(ex);
		}
		if (task2.IsCanceled)
		{
			throw FxTrace.Exception.AsError(new TaskCanceledException(task2));
		}
		outputs = tuple.Item2;
		if (_isGenericTask)
		{
			MethodInfo taskTResultGetMethod = _taskTResultGetMethod;
			Task obj = task2;
			object[] emptyTypes = Type.EmptyTypes;
			return taskTResultGetMethod.Invoke(obj, emptyTypes);
		}
		return null;
	}

	private async Task<Tuple<object, object[]>> InvokeAsync(object instance, object[] inputs)
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
		object[] outputs = EmptyArray<object>.Allocate(_outputParameterCount);
		long beginOperation = 0L;
		bool callSucceeded = false;
		bool callFaulted = false;
		EventTraceActivity eventTraceActivity = null;
		if (WcfEventSource.Instance.OperationCompletedIsEnabled() || WcfEventSource.Instance.OperationFaultedIsEnabled() || WcfEventSource.Instance.OperationFailedIsEnabled())
		{
			beginOperation = DateTime.UtcNow.Ticks;
			OperationContext current = OperationContext.Current;
			if (current != null && current.IncomingMessage != null)
			{
				eventTraceActivity = EventTraceActivityHelper.TryExtractActivity(current.IncomingMessage);
			}
		}
		object returnValue;
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
				returnValue = _invokeDelegate(instance, inputs, outputs);
				if (returnValue == null)
				{
					throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("task");
				}
				if (returnValue is Task task)
				{
					await task;
				}
				callSucceeded = true;
			}
		}
		catch (FaultException)
		{
			callFaulted = true;
			throw;
		}
		finally
		{
			if (beginOperation != 0L)
			{
				if (callSucceeded)
				{
					if (WcfEventSource.Instance.OperationCompletedIsEnabled())
					{
						WcfEventSource.Instance.OperationCompleted(eventTraceActivity, _methodName, TraceUtility.GetUtcBasedDurationForTrace(beginOperation));
					}
				}
				else if (callFaulted)
				{
					if (WcfEventSource.Instance.OperationFaultedIsEnabled())
					{
						WcfEventSource.Instance.OperationFaulted(eventTraceActivity, _methodName, TraceUtility.GetUtcBasedDurationForTrace(beginOperation));
					}
				}
				else if (WcfEventSource.Instance.OperationFailedIsEnabled())
				{
					WcfEventSource.Instance.OperationFailed(eventTraceActivity, _methodName, TraceUtility.GetUtcBasedDurationForTrace(beginOperation));
				}
			}
		}
		return Tuple.Create(returnValue, outputs);
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
