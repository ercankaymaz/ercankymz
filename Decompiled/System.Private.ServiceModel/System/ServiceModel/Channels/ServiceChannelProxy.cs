using System.Collections.Concurrent;
using System.Globalization;
using System.Reflection;
using System.ServiceModel.Description;
using System.ServiceModel.Diagnostics;
using System.ServiceModel.Dispatcher;
using System.Threading.Tasks;

namespace System.ServiceModel.Channels;

public class ServiceChannelProxy : DispatchProxy, ICommunicationObject, IChannel, IClientChannel, IContextChannel, IExtensibleObject<IContextChannel>, IDisposable, IOutputChannel, IRequestChannel, IServiceChannel, IDuplexContextChannel
{
	internal static class TaskCreator
	{
		public static Task CreateTask(ServiceChannel channel, MethodCall methodCall, ProxyOperationRuntime operation)
		{
			if (operation.TaskTResult == ServiceReflector.VoidType)
			{
				return CreateTask(channel, operation, methodCall.InArgs);
			}
			return CreateGenericTask(channel, operation, methodCall.InArgs);
		}

		private static Task CreateGenericTask(ServiceChannel channel, ProxyOperationRuntime operation, object[] inputParameters)
		{
			TaskCompletionSourceProxy tcsp = new TaskCompletionSourceProxy(operation.TaskTResult);
			bool completedCallback = false;
			Action<IAsyncResult> action = delegate(IAsyncResult asyncResult2)
			{
				completedCallback = true;
				OperationContext current = OperationContext.Current;
				OperationContext.Current = asyncResult2.AsyncState as OperationContext;
				try
				{
					object result = channel.EndCall(operation.Action, Array.Empty<object>(), asyncResult2);
					OperationContext.Current = current;
					tcsp.TrySetResult(result);
				}
				catch (Exception exception2)
				{
					OperationContext.Current = current;
					tcsp.TrySetException(exception2);
				}
			};
			try
			{
				IAsyncResult asyncResult = ServiceChannel.BeginCall(channel, operation, inputParameters, action.Invoke, OperationContext.Current);
				if (asyncResult.CompletedSynchronously && !completedCallback)
				{
					action(asyncResult);
				}
			}
			catch (Exception exception)
			{
				tcsp.TrySetException(exception);
			}
			return tcsp.Task;
		}

		private static Task CreateTask(ServiceChannel channel, ProxyOperationRuntime operation, object[] inputParameters)
		{
			TaskCompletionSource<object> tcs = new TaskCompletionSource<object>();
			bool completedCallback = false;
			Action<IAsyncResult> action = delegate(IAsyncResult asyncResult2)
			{
				completedCallback = true;
				OperationContext current = OperationContext.Current;
				OperationContext.Current = asyncResult2.AsyncState as OperationContext;
				try
				{
					channel.EndCall(operation.Action, Array.Empty<object>(), asyncResult2);
					OperationContext.Current = current;
					tcs.TrySetResult(null);
				}
				catch (Exception exception2)
				{
					OperationContext.Current = current;
					tcs.TrySetException(exception2);
				}
			};
			try
			{
				IAsyncResult asyncResult = ServiceChannel.BeginCall(channel, operation, inputParameters, action.Invoke, OperationContext.Current);
				if (asyncResult.CompletedSynchronously && !completedCallback)
				{
					action(asyncResult);
				}
			}
			catch (Exception exception)
			{
				tcs.TrySetException(exception);
			}
			return tcs.Task;
		}
	}

	private class TaskCompletionSourceProxy
	{
		private TaskCompletionSourceInfo _tcsInfo;

		private object _tcsInstance;

		public Task Task => (Task)_tcsInfo.TaskProperty.GetValue(_tcsInstance);

		public TaskCompletionSourceProxy(Type resultType)
		{
			_tcsInfo = TaskCompletionSourceInfo.GetTaskCompletionSourceInfo(resultType);
			_tcsInstance = Activator.CreateInstance(_tcsInfo.GenericType);
		}

		public bool TrySetResult(object result)
		{
			return (bool)_tcsInfo.TrySetResultMethod.Invoke(_tcsInstance, new object[1] { result });
		}

		public bool TrySetException(Exception exception)
		{
			return (bool)_tcsInfo.TrySetExceptionMethod.Invoke(_tcsInstance, new object[1] { exception });
		}

		public bool TrySetCanceled()
		{
			return (bool)_tcsInfo.TrySetCanceledMethod.Invoke(_tcsInstance, Array.Empty<object>());
		}
	}

	private class TaskCompletionSourceInfo
	{
		private static ConcurrentDictionary<Type, TaskCompletionSourceInfo> s_cache = new ConcurrentDictionary<Type, TaskCompletionSourceInfo>();

		public Type ResultType { get; private set; }

		public Type GenericType { get; private set; }

		public PropertyInfo TaskProperty { get; private set; }

		public MethodInfo TrySetResultMethod { get; private set; }

		public MethodInfo TrySetExceptionMethod { get; set; }

		public MethodInfo TrySetCanceledMethod { get; set; }

		public TaskCompletionSourceInfo(Type resultType)
		{
			ResultType = resultType;
			Type typeFromHandle = typeof(TaskCompletionSource<>);
			GenericType = typeFromHandle.MakeGenericType(resultType);
			TaskProperty = GenericType.GetTypeInfo().GetDeclaredProperty("Task");
			TrySetResultMethod = GenericType.GetTypeInfo().GetDeclaredMethod("TrySetResult");
			TrySetExceptionMethod = GenericType.GetRuntimeMethod("TrySetException", new Type[1] { typeof(Exception) });
			TrySetCanceledMethod = GenericType.GetRuntimeMethod("TrySetCanceled", Array.Empty<Type>());
		}

		public static TaskCompletionSourceInfo GetTaskCompletionSourceInfo(Type resultType)
		{
			return s_cache.GetOrAdd(resultType, (Type t) => new TaskCompletionSourceInfo(t));
		}
	}

	internal class MethodDataCache
	{
		private MethodData[] _methodDatas;

		private object ThisLock => this;

		public MethodDataCache()
		{
			_methodDatas = new MethodData[4];
		}

		public bool TryGetMethodData(MethodBase method, out MethodData methodData)
		{
			lock (ThisLock)
			{
				MethodData[] methodDatas = _methodDatas;
				int num = FindMethod(methodDatas, method);
				if (num >= 0)
				{
					methodData = methodDatas[num];
					return true;
				}
				methodData = default(MethodData);
				return false;
			}
		}

		private static int FindMethod(MethodData[] methodDatas, MethodBase methodToFind)
		{
			for (int i = 0; i < methodDatas.Length; i++)
			{
				MethodBase methodBase = methodDatas[i].MethodBase;
				if (methodBase == null)
				{
					break;
				}
				if (methodBase == methodToFind)
				{
					return i;
				}
			}
			return -1;
		}

		public void SetMethodData(MethodData methodData)
		{
			lock (ThisLock)
			{
				int num = FindMethod(_methodDatas, methodData.MethodBase);
				if (num >= 0)
				{
					return;
				}
				for (int i = 0; i < _methodDatas.Length; i++)
				{
					if (_methodDatas[i].MethodBase == null)
					{
						_methodDatas[i] = methodData;
						return;
					}
				}
				MethodData[] array = new MethodData[_methodDatas.Length * 2];
				Array.Copy(_methodDatas, array, _methodDatas.Length);
				array[_methodDatas.Length] = methodData;
				_methodDatas = array;
			}
		}
	}

	internal enum MethodType
	{
		Service,
		BeginService,
		EndService,
		Channel,
		Object,
		GetType,
		TaskService
	}

	internal struct MethodData
	{
		private ProxyOperationRuntime _operation;

		public MethodBase MethodBase { get; }

		public MethodType MethodType { get; }

		public ProxyOperationRuntime Operation => _operation;

		public MethodData(MethodBase methodBase, MethodType methodType)
			: this(methodBase, methodType, null)
		{
		}

		public MethodData(MethodBase methodBase, MethodType methodType, ProxyOperationRuntime operation)
		{
			MethodBase = methodBase;
			MethodType = methodType;
			_operation = operation;
		}
	}

	private const string activityIdSlotName = "E2ETrace.ActivityID";

	private Type _proxiedType;

	private ServiceChannel _serviceChannel;

	private ImmutableClientRuntime _proxyRuntime;

	private MethodDataCache _methodDataCache;

	CommunicationState ICommunicationObject.State => _serviceChannel.State;

	bool IClientChannel.AllowInitializationUI
	{
		get
		{
			return ((IClientChannel)_serviceChannel).AllowInitializationUI;
		}
		set
		{
			((IClientChannel)_serviceChannel).AllowInitializationUI = value;
		}
	}

	bool IClientChannel.DidInteractiveInitialization => ((IClientChannel)_serviceChannel).DidInteractiveInitialization;

	Uri IClientChannel.Via => _serviceChannel.Via;

	bool IContextChannel.AllowOutputBatching
	{
		get
		{
			return ((IContextChannel)_serviceChannel).AllowOutputBatching;
		}
		set
		{
			((IContextChannel)_serviceChannel).AllowOutputBatching = value;
		}
	}

	IInputSession IContextChannel.InputSession => ((IContextChannel)_serviceChannel).InputSession;

	EndpointAddress IContextChannel.LocalAddress => ((IContextChannel)_serviceChannel).LocalAddress;

	TimeSpan IContextChannel.OperationTimeout
	{
		get
		{
			return ((IContextChannel)_serviceChannel).OperationTimeout;
		}
		set
		{
			((IContextChannel)_serviceChannel).OperationTimeout = value;
		}
	}

	IOutputSession IContextChannel.OutputSession => ((IContextChannel)_serviceChannel).OutputSession;

	EndpointAddress IOutputChannel.RemoteAddress => ((IContextChannel)_serviceChannel).RemoteAddress;

	Uri IOutputChannel.Via => _serviceChannel.Via;

	EndpointAddress IContextChannel.RemoteAddress => ((IContextChannel)_serviceChannel).RemoteAddress;

	string IContextChannel.SessionId => ((IContextChannel)_serviceChannel).SessionId;

	IExtensionCollection<IContextChannel> IExtensibleObject<IContextChannel>.Extensions => ((IExtensibleObject<IContextChannel>)_serviceChannel).Extensions;

	EndpointAddress IRequestChannel.RemoteAddress => ((IContextChannel)_serviceChannel).RemoteAddress;

	Uri IRequestChannel.Via => _serviceChannel.Via;

	Uri IServiceChannel.ListenUri => _serviceChannel.ListenUri;

	public bool AutomaticInputSessionShutdown
	{
		get
		{
			return ((IDuplexContextChannel)_serviceChannel).AutomaticInputSessionShutdown;
		}
		set
		{
			((IDuplexContextChannel)_serviceChannel).AutomaticInputSessionShutdown = value;
		}
	}

	public InstanceContext CallbackInstance
	{
		get
		{
			return ((IDuplexContextChannel)_serviceChannel).CallbackInstance;
		}
		set
		{
			((IDuplexContextChannel)_serviceChannel).CallbackInstance = value;
		}
	}

	event EventHandler ICommunicationObject.Closed
	{
		add
		{
			_serviceChannel.Closed += value;
		}
		remove
		{
			_serviceChannel.Closed -= value;
		}
	}

	event EventHandler ICommunicationObject.Closing
	{
		add
		{
			_serviceChannel.Closing += value;
		}
		remove
		{
			_serviceChannel.Closing -= value;
		}
	}

	event EventHandler ICommunicationObject.Faulted
	{
		add
		{
			_serviceChannel.Faulted += value;
		}
		remove
		{
			_serviceChannel.Faulted -= value;
		}
	}

	event EventHandler ICommunicationObject.Opened
	{
		add
		{
			_serviceChannel.Opened += value;
		}
		remove
		{
			_serviceChannel.Opened -= value;
		}
	}

	event EventHandler ICommunicationObject.Opening
	{
		add
		{
			_serviceChannel.Opening += value;
		}
		remove
		{
			_serviceChannel.Opening -= value;
		}
	}

	event EventHandler<UnknownMessageReceivedEventArgs> IClientChannel.UnknownMessageReceived
	{
		add
		{
			((IClientChannel)_serviceChannel).UnknownMessageReceived += value;
		}
		remove
		{
			((IClientChannel)_serviceChannel).UnknownMessageReceived -= value;
		}
	}

	internal static TChannel CreateProxy<TChannel>(MessageDirection direction, ServiceChannel serviceChannel)
	{
		TChannel val = DispatchProxy.Create<TChannel, ServiceChannelProxy>();
		if (val == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.Format(System.SR.FailedToCreateTypedProxy, typeof(TChannel))));
		}
		ServiceChannelProxy serviceChannelProxy = (ServiceChannelProxy)(object)val;
		serviceChannelProxy._proxiedType = typeof(TChannel);
		serviceChannelProxy._serviceChannel = serviceChannel;
		serviceChannelProxy._proxyRuntime = serviceChannel.ClientRuntime.GetRuntime();
		serviceChannelProxy._methodDataCache = new MethodDataCache();
		return val;
	}

	public override string ToString()
	{
		return _proxiedType.ToString();
	}

	private MethodData GetMethodData(MethodCall methodCall)
	{
		MethodBase methodBase = methodCall.MethodBase;
		if (_methodDataCache.TryGetMethodData(methodBase, out var methodData))
		{
			return methodData;
		}
		Type declaringType = methodBase.DeclaringType;
		bool canCacheResult;
		if (declaringType == typeof(object) && methodBase == typeof(object).GetMethod("GetType"))
		{
			canCacheResult = true;
			methodData = new MethodData(methodBase, MethodType.GetType);
		}
		else if (declaringType.IsAssignableFrom(_serviceChannel.GetType()))
		{
			canCacheResult = true;
			methodData = new MethodData(methodBase, MethodType.Channel);
		}
		else
		{
			ProxyOperationRuntime operation = _proxyRuntime.GetOperation(methodBase, methodCall.Args, out canCacheResult);
			if (operation == null)
			{
				if (_serviceChannel.Factory != null)
				{
					throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new NotSupportedException(System.SR.Format(System.SR.SFxMethodNotSupported1, methodBase.Name)));
				}
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new NotSupportedException(System.SR.Format(System.SR.SFxMethodNotSupportedOnCallback1, methodBase.Name)));
			}
			MethodType methodType = (operation.IsTaskCall(methodCall) ? MethodType.TaskService : ((!operation.IsSyncCall(methodCall)) ? (operation.IsBeginCall(methodCall) ? MethodType.BeginService : MethodType.EndService) : MethodType.Service));
			methodData = new MethodData(methodBase, methodType, operation);
		}
		if (canCacheResult)
		{
			_methodDataCache.SetMethodData(methodData);
		}
		return methodData;
	}

	internal ServiceChannel GetServiceChannel()
	{
		return _serviceChannel;
	}

	protected override object Invoke(MethodInfo targetMethod, object[] args)
	{
		if (args == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("args");
		}
		if (targetMethod == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.Format(System.SR.InvalidTypedProxyMethodHandle, _proxiedType.Name)));
		}
		MethodCall methodCall = new MethodCall(targetMethod, args);
		MethodData methodData = GetMethodData(methodCall);
		return methodData.MethodType switch
		{
			MethodType.Service => InvokeService(methodCall, methodData.Operation), 
			MethodType.BeginService => InvokeBeginService(methodCall, methodData.Operation), 
			MethodType.EndService => InvokeEndService(methodCall, methodData.Operation), 
			MethodType.TaskService => InvokeTaskService(methodCall, methodData.Operation), 
			MethodType.Channel => InvokeChannel(methodCall), 
			MethodType.GetType => InvokeGetType(methodCall), 
			_ => throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(string.Format(CultureInfo.InvariantCulture, "Invalid proxy method type"))), 
		};
	}

	private object InvokeTaskService(MethodCall methodCall, ProxyOperationRuntime operation)
	{
		return TaskCreator.CreateTask(_serviceChannel, methodCall, operation);
	}

	private object InvokeChannel(MethodCall methodCall)
	{
		string text = null;
		ActivityType activityType = ActivityType.Unknown;
		if (DiagnosticUtility.ShouldUseActivity && (ServiceModelActivity.Current == null || ServiceModelActivity.Current.ActivityType != ActivityType.Close))
		{
			MethodData methodData = GetMethodData(methodCall);
			if (methodData.MethodBase.DeclaringType == typeof(ICommunicationObject) && methodData.MethodBase.Name.Equals("Close", StringComparison.Ordinal))
			{
				text = System.SR.Format(System.SR.ActivityClose, _serviceChannel.GetType().FullName);
				activityType = ActivityType.Close;
			}
		}
		using ServiceModelActivity activity = (string.IsNullOrEmpty(text) ? null : ServiceModelActivity.CreateBoundedActivity());
		if (DiagnosticUtility.ShouldUseActivity)
		{
			ServiceModelActivity.Start(activity, text, activityType);
		}
		return ExecuteMessage(_serviceChannel, methodCall);
	}

	private object InvokeGetType(MethodCall methodCall)
	{
		return _proxiedType;
	}

	private object InvokeBeginService(MethodCall methodCall, ProxyOperationRuntime operation)
	{
		AsyncCallback callback;
		object asyncState;
		object[] ins = operation.MapAsyncBeginInputs(methodCall, out callback, out asyncState);
		return _serviceChannel.BeginCall(operation.Action, operation.IsOneWay, operation, ins, callback, asyncState);
	}

	private object InvokeEndService(MethodCall methodCall, ProxyOperationRuntime operation)
	{
		operation.MapAsyncEndInputs(methodCall, out var result, out var outs);
		object ret = _serviceChannel.EndCall(operation.Action, outs, result);
		operation.MapAsyncOutputs(methodCall, outs, ref ret);
		return ret;
	}

	private object InvokeService(MethodCall methodCall, ProxyOperationRuntime operation)
	{
		object[] outs;
		object[] ins = operation.MapSyncInputs(methodCall, out outs);
		object ret = _serviceChannel.Call(operation.Action, operation.IsOneWay, operation, ins, outs);
		operation.MapSyncOutputs(methodCall, outs, ref ret);
		return ret;
	}

	private object ExecuteMessage(object target, MethodCall methodCall)
	{
		MethodBase methodBase = methodCall.MethodBase;
		object[] args = methodCall.Args;
		object obj = null;
		try
		{
			return methodBase.Invoke(target, args);
		}
		catch (TargetInvocationException ex)
		{
			throw ex.InnerException;
		}
	}

	T IChannel.GetProperty<T>()
	{
		return _serviceChannel.GetProperty<T>();
	}

	void ICommunicationObject.Abort()
	{
		_serviceChannel.Abort();
	}

	void ICommunicationObject.Close()
	{
		_serviceChannel.Close();
	}

	void ICommunicationObject.Close(TimeSpan timeout)
	{
		_serviceChannel.Close(timeout);
	}

	IAsyncResult ICommunicationObject.BeginClose(AsyncCallback callback, object state)
	{
		return _serviceChannel.BeginClose(callback, state);
	}

	IAsyncResult ICommunicationObject.BeginClose(TimeSpan timeout, AsyncCallback callback, object state)
	{
		return _serviceChannel.BeginClose(timeout, callback, state);
	}

	void ICommunicationObject.EndClose(IAsyncResult result)
	{
		_serviceChannel.EndClose(result);
	}

	void ICommunicationObject.Open()
	{
		_serviceChannel.Open();
	}

	void ICommunicationObject.Open(TimeSpan timeout)
	{
		_serviceChannel.Open(timeout);
	}

	IAsyncResult ICommunicationObject.BeginOpen(AsyncCallback callback, object state)
	{
		return _serviceChannel.BeginOpen(callback, state);
	}

	IAsyncResult ICommunicationObject.BeginOpen(TimeSpan timeout, AsyncCallback callback, object state)
	{
		return _serviceChannel.BeginOpen(timeout, callback, state);
	}

	void ICommunicationObject.EndOpen(IAsyncResult result)
	{
		_serviceChannel.EndOpen(result);
	}

	IAsyncResult IClientChannel.BeginDisplayInitializationUI(AsyncCallback callback, object state)
	{
		return _serviceChannel.BeginDisplayInitializationUI(callback, state);
	}

	void IClientChannel.DisplayInitializationUI()
	{
		_serviceChannel.DisplayInitializationUI();
	}

	void IClientChannel.EndDisplayInitializationUI(IAsyncResult result)
	{
		_serviceChannel.EndDisplayInitializationUI(result);
	}

	void IDisposable.Dispose()
	{
		((IDisposable)_serviceChannel).Dispose();
	}

	IAsyncResult IOutputChannel.BeginSend(Message message, AsyncCallback callback, object state)
	{
		return _serviceChannel.BeginSend(message, callback, state);
	}

	IAsyncResult IOutputChannel.BeginSend(Message message, TimeSpan timeout, AsyncCallback callback, object state)
	{
		return _serviceChannel.BeginSend(message, timeout, callback, state);
	}

	void IOutputChannel.EndSend(IAsyncResult result)
	{
		_serviceChannel.EndSend(result);
	}

	void IOutputChannel.Send(Message message)
	{
		_serviceChannel.Send(message);
	}

	void IOutputChannel.Send(Message message, TimeSpan timeout)
	{
		_serviceChannel.Send(message, timeout);
	}

	Message IRequestChannel.Request(Message message)
	{
		return _serviceChannel.Request(message);
	}

	Message IRequestChannel.Request(Message message, TimeSpan timeout)
	{
		return _serviceChannel.Request(message, timeout);
	}

	IAsyncResult IRequestChannel.BeginRequest(Message message, AsyncCallback callback, object state)
	{
		return _serviceChannel.BeginRequest(message, callback, state);
	}

	IAsyncResult IRequestChannel.BeginRequest(Message message, TimeSpan timeout, AsyncCallback callback, object state)
	{
		return _serviceChannel.BeginRequest(message, timeout, callback, state);
	}

	Message IRequestChannel.EndRequest(IAsyncResult result)
	{
		return _serviceChannel.EndRequest(result);
	}

	public IAsyncResult BeginCloseOutputSession(TimeSpan timeout, AsyncCallback callback, object state)
	{
		return ((IDuplexContextChannel)_serviceChannel).BeginCloseOutputSession(timeout, callback, state);
	}

	public void EndCloseOutputSession(IAsyncResult result)
	{
		((IDuplexContextChannel)_serviceChannel).EndCloseOutputSession(result);
	}

	public void CloseOutputSession(TimeSpan timeout)
	{
		((IDuplexContextChannel)_serviceChannel).CloseOutputSession(timeout);
	}
}
