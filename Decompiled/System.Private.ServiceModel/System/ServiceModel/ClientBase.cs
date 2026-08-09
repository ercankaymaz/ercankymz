using System.ComponentModel;
using System.Diagnostics;
using System.Runtime;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Diagnostics;
using System.ServiceModel.Dispatcher;
using System.Threading;
using System.Threading.Tasks;

namespace System.ServiceModel;

public abstract class ClientBase<TChannel> : ICommunicationObject, IDisposable, IAsyncDisposable where TChannel : class
{
	protected delegate IAsyncResult BeginOperationDelegate(object[] inValues, AsyncCallback asyncCallback, object state);

	protected delegate object[] EndOperationDelegate(IAsyncResult result);

	protected class InvokeAsyncCompletedEventArgs : AsyncCompletedEventArgs
	{
		public object[] Results { get; }

		internal InvokeAsyncCompletedEventArgs(object[] results, Exception error, bool cancelled, object userState)
			: base(error, cancelled, userState)
		{
			Results = results;
		}
	}

	protected class AsyncOperationContext
	{
		private SendOrPostCallback _completionCallback;

		internal AsyncOperation AsyncOperation { get; }

		internal EndOperationDelegate EndDelegate { get; }

		internal SendOrPostCallback CompletionCallback => _completionCallback;

		internal AsyncOperationContext(AsyncOperation asyncOperation, EndOperationDelegate endDelegate, SendOrPostCallback completionCallback)
		{
			AsyncOperation = asyncOperation;
			EndDelegate = endDelegate;
			_completionCallback = completionCallback;
		}
	}

	protected class ChannelBase<T> : IClientChannel, IContextChannel, IChannel, ICommunicationObject, IExtensibleObject<IContextChannel>, IDisposable, IOutputChannel, IRequestChannel, IChannelBaseProxy where T : class
	{
		private ServiceChannel _channel;

		private ImmutableClientRuntime _runtime;

		bool IClientChannel.AllowInitializationUI
		{
			get
			{
				return ((IClientChannel)_channel).AllowInitializationUI;
			}
			set
			{
				((IClientChannel)_channel).AllowInitializationUI = value;
			}
		}

		bool IClientChannel.DidInteractiveInitialization => ((IClientChannel)_channel).DidInteractiveInitialization;

		Uri IClientChannel.Via => ((IClientChannel)_channel).Via;

		bool IContextChannel.AllowOutputBatching
		{
			get
			{
				return ((IContextChannel)_channel).AllowOutputBatching;
			}
			set
			{
				((IContextChannel)_channel).AllowOutputBatching = value;
			}
		}

		IInputSession IContextChannel.InputSession => ((IContextChannel)_channel).InputSession;

		EndpointAddress IContextChannel.LocalAddress => ((IContextChannel)_channel).LocalAddress;

		TimeSpan IContextChannel.OperationTimeout
		{
			get
			{
				return ((IContextChannel)_channel).OperationTimeout;
			}
			set
			{
				((IContextChannel)_channel).OperationTimeout = value;
			}
		}

		IOutputSession IContextChannel.OutputSession => ((IContextChannel)_channel).OutputSession;

		EndpointAddress IContextChannel.RemoteAddress => ((IContextChannel)_channel).RemoteAddress;

		string IContextChannel.SessionId => ((IContextChannel)_channel).SessionId;

		CommunicationState ICommunicationObject.State => ((ICommunicationObject)_channel).State;

		IExtensionCollection<IContextChannel> IExtensibleObject<IContextChannel>.Extensions => ((IExtensibleObject<IContextChannel>)_channel).Extensions;

		Uri IOutputChannel.Via => ((IOutputChannel)_channel).Via;

		EndpointAddress IOutputChannel.RemoteAddress => ((IOutputChannel)_channel).RemoteAddress;

		Uri IRequestChannel.Via => ((IRequestChannel)_channel).Via;

		EndpointAddress IRequestChannel.RemoteAddress => ((IRequestChannel)_channel).RemoteAddress;

		event EventHandler<UnknownMessageReceivedEventArgs> IClientChannel.UnknownMessageReceived
		{
			add
			{
				((IClientChannel)_channel).UnknownMessageReceived += value;
			}
			remove
			{
				((IClientChannel)_channel).UnknownMessageReceived -= value;
			}
		}

		event EventHandler ICommunicationObject.Closed
		{
			add
			{
				((ICommunicationObject)_channel).Closed += value;
			}
			remove
			{
				((ICommunicationObject)_channel).Closed -= value;
			}
		}

		event EventHandler ICommunicationObject.Closing
		{
			add
			{
				((ICommunicationObject)_channel).Closing += value;
			}
			remove
			{
				((ICommunicationObject)_channel).Closing -= value;
			}
		}

		event EventHandler ICommunicationObject.Faulted
		{
			add
			{
				((ICommunicationObject)_channel).Faulted += value;
			}
			remove
			{
				((ICommunicationObject)_channel).Faulted -= value;
			}
		}

		event EventHandler ICommunicationObject.Opened
		{
			add
			{
				((ICommunicationObject)_channel).Opened += value;
			}
			remove
			{
				((ICommunicationObject)_channel).Opened -= value;
			}
		}

		event EventHandler ICommunicationObject.Opening
		{
			add
			{
				((ICommunicationObject)_channel).Opening += value;
			}
			remove
			{
				((ICommunicationObject)_channel).Opening -= value;
			}
		}

		protected ChannelBase(ClientBase<T> client)
		{
			if (client.Endpoint.Address == null)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.SFxChannelFactoryEndpointAddressUri));
			}
			ChannelFactory<T> channelFactory = client.ChannelFactory;
			channelFactory.EnsureOpened();
			_channel = channelFactory.ServiceChannelFactory.CreateServiceChannel(client.Endpoint.Address, client.Endpoint.Address.Uri);
			_channel.InstanceContext = channelFactory.CallbackInstance;
			_runtime = _channel.ClientRuntime.GetRuntime();
		}

		protected IAsyncResult BeginInvoke(string methodName, object[] args, AsyncCallback callback, object state)
		{
			object[] array = new object[args.Length + 2];
			Array.Copy(args, array, args.Length);
			array[^2] = callback;
			array[^1] = state;
			MethodCall methodCall = new MethodCall(array);
			ProxyOperationRuntime operationByName = GetOperationByName(methodName);
			object[] ins = operationByName.MapAsyncBeginInputs(methodCall, out callback, out state);
			return _channel.BeginCall(operationByName.Action, operationByName.IsOneWay, operationByName, ins, callback, state);
		}

		protected object EndInvoke(string methodName, object[] args, IAsyncResult result)
		{
			object[] array = new object[args.Length + 1];
			Array.Copy(args, array, args.Length);
			array[^1] = result;
			MethodCall methodCall = new MethodCall(array);
			ProxyOperationRuntime operationByName = GetOperationByName(methodName);
			operationByName.MapAsyncEndInputs(methodCall, out result, out var outs);
			object ret = _channel.EndCall(operationByName.Action, outs, result);
			object[] array2 = operationByName.MapAsyncOutputs(methodCall, outs, ref ret);
			if (array2 != null)
			{
				Array.Copy(array2, args, args.Length);
			}
			return ret;
		}

		private ProxyOperationRuntime GetOperationByName(string methodName)
		{
			ProxyOperationRuntime operationByName = _runtime.GetOperationByName(methodName);
			if (operationByName == null)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new NotSupportedException(System.SR.Format(System.SR.SFxMethodNotSupported1, methodName)));
			}
			return operationByName;
		}

		void IClientChannel.DisplayInitializationUI()
		{
			((IClientChannel)_channel).DisplayInitializationUI();
		}

		IAsyncResult IClientChannel.BeginDisplayInitializationUI(AsyncCallback callback, object state)
		{
			return ((IClientChannel)_channel).BeginDisplayInitializationUI(callback, state);
		}

		void IClientChannel.EndDisplayInitializationUI(IAsyncResult result)
		{
			((IClientChannel)_channel).EndDisplayInitializationUI(result);
		}

		TProperty IChannel.GetProperty<TProperty>()
		{
			return ((IChannel)_channel).GetProperty<TProperty>();
		}

		void ICommunicationObject.Abort()
		{
			((ICommunicationObject)_channel).Abort();
		}

		void ICommunicationObject.Close()
		{
			((ICommunicationObject)_channel).Close();
		}

		void ICommunicationObject.Close(TimeSpan timeout)
		{
			((ICommunicationObject)_channel).Close(timeout);
		}

		IAsyncResult ICommunicationObject.BeginClose(AsyncCallback callback, object state)
		{
			return ((ICommunicationObject)_channel).BeginClose(callback, state);
		}

		IAsyncResult ICommunicationObject.BeginClose(TimeSpan timeout, AsyncCallback callback, object state)
		{
			return ((ICommunicationObject)_channel).BeginClose(timeout, callback, state);
		}

		void ICommunicationObject.EndClose(IAsyncResult result)
		{
			((ICommunicationObject)_channel).EndClose(result);
		}

		void ICommunicationObject.Open()
		{
			((ICommunicationObject)_channel).Open();
		}

		void ICommunicationObject.Open(TimeSpan timeout)
		{
			((ICommunicationObject)_channel).Open(timeout);
		}

		IAsyncResult ICommunicationObject.BeginOpen(AsyncCallback callback, object state)
		{
			return ((ICommunicationObject)_channel).BeginOpen(callback, state);
		}

		IAsyncResult ICommunicationObject.BeginOpen(TimeSpan timeout, AsyncCallback callback, object state)
		{
			return ((ICommunicationObject)_channel).BeginOpen(timeout, callback, state);
		}

		void ICommunicationObject.EndOpen(IAsyncResult result)
		{
			((ICommunicationObject)_channel).EndOpen(result);
		}

		void IDisposable.Dispose()
		{
			((IDisposable)_channel).Dispose();
		}

		void IOutputChannel.Send(Message message)
		{
			((IOutputChannel)_channel).Send(message);
		}

		void IOutputChannel.Send(Message message, TimeSpan timeout)
		{
			((IOutputChannel)_channel).Send(message, timeout);
		}

		IAsyncResult IOutputChannel.BeginSend(Message message, AsyncCallback callback, object state)
		{
			return ((IOutputChannel)_channel).BeginSend(message, callback, state);
		}

		IAsyncResult IOutputChannel.BeginSend(Message message, TimeSpan timeout, AsyncCallback callback, object state)
		{
			return ((IOutputChannel)_channel).BeginSend(message, timeout, callback, state);
		}

		void IOutputChannel.EndSend(IAsyncResult result)
		{
			((IOutputChannel)_channel).EndSend(result);
		}

		Message IRequestChannel.Request(Message message)
		{
			return ((IRequestChannel)_channel).Request(message);
		}

		Message IRequestChannel.Request(Message message, TimeSpan timeout)
		{
			return ((IRequestChannel)_channel).Request(message, timeout);
		}

		IAsyncResult IRequestChannel.BeginRequest(Message message, AsyncCallback callback, object state)
		{
			return ((IRequestChannel)_channel).BeginRequest(message, callback, state);
		}

		IAsyncResult IRequestChannel.BeginRequest(Message message, TimeSpan timeout, AsyncCallback callback, object state)
		{
			return ((IRequestChannel)_channel).BeginRequest(message, timeout, callback, state);
		}

		Message IRequestChannel.EndRequest(IAsyncResult result)
		{
			return ((IRequestChannel)_channel).EndRequest(result);
		}

		ServiceChannel IChannelBaseProxy.GetServiceChannel()
		{
			return _channel;
		}
	}

	private TChannel _channel;

	private ChannelFactoryRef<TChannel> _channelFactoryRef;

	private EndpointTrait<TChannel> _endpointTrait;

	private bool _canShareFactory = true;

	private bool _useCachedFactory;

	private bool _sharingFinalized;

	private bool _channelFactoryRefReleased;

	private bool _releasedLastRef;

	private object finalizeLock = new object();

	private const int MaxNumChannelFactories = 32;

	private static ChannelFactoryRefCache<TChannel> s_factoryRefCache = new ChannelFactoryRefCache<TChannel>(32);

	private static object s_staticLock = new object();

	private static object s_cacheLock = new object();

	private static CacheSetting s_cacheSetting = CacheSetting.Default;

	private static bool s_isCacheSettingReadOnly;

	private static AsyncCallback s_onAsyncCallCompleted = Fx.ThunkCallback(OnAsyncCallCompleted);

	private object ThisLock { get; } = new object();

	protected TChannel Channel
	{
		get
		{
			if (_channel == null)
			{
				lock (ThisLock)
				{
					if (_channel == null)
					{
						using ServiceModelActivity activity = (DiagnosticUtility.ShouldUseActivity ? ServiceModelActivity.CreateBoundedActivity() : null);
						if (DiagnosticUtility.ShouldUseActivity)
						{
							ServiceModelActivity.Start(activity, System.SR.Format(System.SR.ActivityOpenClientBase, typeof(TChannel).FullName), ActivityType.OpenClient);
						}
						if (_useCachedFactory)
						{
							try
							{
								CreateChannelInternal();
							}
							catch (Exception ex)
							{
								if (!_useCachedFactory || (!(ex is CommunicationException) && !(ex is ObjectDisposedException) && !(ex is TimeoutException)))
								{
									throw;
								}
								DiagnosticUtility.TraceHandledException(ex, TraceEventType.Warning);
								InvalidateCacheAndCreateChannel();
							}
						}
						else
						{
							CreateChannelInternal();
						}
					}
				}
			}
			return _channel;
		}
	}

	public static CacheSetting CacheSetting
	{
		get
		{
			return s_cacheSetting;
		}
		set
		{
			lock (s_cacheLock)
			{
				if (s_isCacheSettingReadOnly && s_cacheSetting != value)
				{
					throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.Format(System.SR.SFxImmutableClientBaseCacheSetting, typeof(TChannel).ToString())));
				}
				s_cacheSetting = value;
			}
		}
	}

	public ChannelFactory<TChannel> ChannelFactory
	{
		get
		{
			if (s_cacheSetting == CacheSetting.Default)
			{
				TryDisableSharing();
			}
			return GetChannelFactory();
		}
	}

	public ClientCredentials ClientCredentials => ChannelFactory.Credentials;

	public CommunicationState State
	{
		get
		{
			IChannel channel = (IChannel)_channel;
			if (channel != null)
			{
				return channel.State;
			}
			if (!_useCachedFactory)
			{
				return GetChannelFactory().State;
			}
			return CommunicationState.Created;
		}
	}

	public IClientChannel InnerChannel => (IClientChannel)Channel;

	public ServiceEndpoint Endpoint => ChannelFactory.Endpoint;

	event EventHandler ICommunicationObject.Closed
	{
		add
		{
			InnerChannel.Closed += value;
		}
		remove
		{
			InnerChannel.Closed -= value;
		}
	}

	event EventHandler ICommunicationObject.Closing
	{
		add
		{
			InnerChannel.Closing += value;
		}
		remove
		{
			InnerChannel.Closing -= value;
		}
	}

	event EventHandler ICommunicationObject.Faulted
	{
		add
		{
			InnerChannel.Faulted += value;
		}
		remove
		{
			InnerChannel.Faulted -= value;
		}
	}

	event EventHandler ICommunicationObject.Opened
	{
		add
		{
			InnerChannel.Opened += value;
		}
		remove
		{
			InnerChannel.Opened -= value;
		}
	}

	event EventHandler ICommunicationObject.Opening
	{
		add
		{
			InnerChannel.Opening += value;
		}
		remove
		{
			InnerChannel.Opening -= value;
		}
	}

	protected ClientBase()
	{
		throw new PlatformNotSupportedException(System.SR.ConfigurationFilesNotSupported);
	}

	protected ClientBase(string endpointConfigurationName)
	{
		throw new PlatformNotSupportedException(System.SR.ConfigurationFilesNotSupported);
	}

	protected ClientBase(string endpointConfigurationName, string remoteAddress)
	{
		throw new PlatformNotSupportedException(System.SR.ConfigurationFilesNotSupported);
	}

	protected ClientBase(string endpointConfigurationName, EndpointAddress remoteAddress)
	{
		throw new PlatformNotSupportedException(System.SR.ConfigurationFilesNotSupported);
	}

	protected ClientBase(Binding binding, EndpointAddress remoteAddress)
	{
		if (binding == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("binding");
		}
		if (remoteAddress == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("remoteAddress");
		}
		MakeCacheSettingReadOnly();
		if (s_cacheSetting == CacheSetting.AlwaysOn)
		{
			_endpointTrait = new ProgrammaticEndpointTrait<TChannel>(binding, remoteAddress, null);
			InitializeChannelFactoryRef();
		}
		else
		{
			_channelFactoryRef = new ChannelFactoryRef<TChannel>(new ChannelFactory<TChannel>(binding, remoteAddress));
			_channelFactoryRef.ChannelFactory.TraceOpenAndClose = false;
			TryDisableSharing();
		}
	}

	protected ClientBase(ServiceEndpoint endpoint)
	{
		if (endpoint == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("endpoint");
		}
		MakeCacheSettingReadOnly();
		if (s_cacheSetting == CacheSetting.AlwaysOn)
		{
			_endpointTrait = new ServiceEndpointTrait<TChannel>(endpoint, null);
			InitializeChannelFactoryRef();
		}
		else
		{
			_channelFactoryRef = new ChannelFactoryRef<TChannel>(new ChannelFactory<TChannel>(endpoint));
			_channelFactoryRef.ChannelFactory.TraceOpenAndClose = false;
			TryDisableSharing();
		}
	}

	protected ClientBase(InstanceContext callbackInstance, Binding binding, EndpointAddress remoteAddress)
	{
		if (callbackInstance == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("callbackInstance");
		}
		if (binding == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("binding");
		}
		if (remoteAddress == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("remoteAddress");
		}
		MakeCacheSettingReadOnly();
		if (s_cacheSetting == CacheSetting.AlwaysOn)
		{
			_endpointTrait = new ProgrammaticEndpointTrait<TChannel>(binding, remoteAddress, callbackInstance);
			InitializeChannelFactoryRef();
		}
		else
		{
			_channelFactoryRef = new ChannelFactoryRef<TChannel>(new DuplexChannelFactory<TChannel>(callbackInstance, binding, remoteAddress));
			_channelFactoryRef.ChannelFactory.TraceOpenAndClose = false;
			TryDisableSharing();
		}
	}

	protected T GetDefaultValueForInitialization<T>()
	{
		return default(T);
	}

	public void Open()
	{
		((ICommunicationObject)this).Open(GetChannelFactory().InternalOpenTimeout);
	}

	public Task OpenAsync()
	{
		return OpenAsync(GetChannelFactory().InternalOpenTimeout);
	}

	private async Task OpenAsync(TimeSpan timeout)
	{
		TimeoutHelper timeoutHelper = new TimeoutHelper(timeout);
		await TaskHelpers.EnsureDefaultTaskScheduler();
		if (!_useCachedFactory)
		{
			await GetChannelFactory().OpenHelperAsync(timeoutHelper.RemainingTime());
		}
		await InnerChannel.OpenHelperAsync(timeoutHelper.RemainingTime());
	}

	public void Abort()
	{
		((IChannel)_channel)?.Abort();
		if (!_channelFactoryRefReleased)
		{
			lock (s_staticLock)
			{
				if (!_channelFactoryRefReleased)
				{
					if (_channelFactoryRef.Release())
					{
						_releasedLastRef = true;
					}
					_channelFactoryRefReleased = true;
				}
			}
		}
		if (_releasedLastRef)
		{
			_channelFactoryRef.Abort();
		}
	}

	public void Close()
	{
		((ICommunicationObject)this).Close(GetChannelFactory().InternalCloseTimeout);
	}

	public Task CloseAsync()
	{
		TimeSpan internalCloseTimeout = GetChannelFactory().InternalCloseTimeout;
		return CloseAsync(internalCloseTimeout);
	}

	private async Task CloseAsync(TimeSpan timeout)
	{
		using ServiceModelActivity activity = (DiagnosticUtility.ShouldUseActivity ? ServiceModelActivity.CreateBoundedActivity() : null);
		if (DiagnosticUtility.ShouldUseActivity)
		{
			ServiceModelActivity.Start(activity, System.SR.Format(System.SR.ActivityCloseClientBase, typeof(TChannel).FullName), ActivityType.Close);
		}
		TimeoutHelper timeoutHelper = new TimeoutHelper(timeout);
		await TaskHelpers.EnsureDefaultTaskScheduler();
		if (_channel != null)
		{
			await InnerChannel.CloseHelperAsync(timeoutHelper.RemainingTime());
		}
		if (_channelFactoryRefReleased)
		{
			return;
		}
		lock (s_staticLock)
		{
			if (!_channelFactoryRefReleased)
			{
				if (_channelFactoryRef.Release())
				{
					_releasedLastRef = true;
				}
				_channelFactoryRefReleased = true;
			}
		}
		if (_releasedLastRef)
		{
			if (!_useCachedFactory)
			{
				await GetChannelFactory().CloseHelperAsync(timeoutHelper.RemainingTime());
			}
			else
			{
				_channelFactoryRef.Abort();
			}
		}
	}

	private void MakeCacheSettingReadOnly()
	{
		if (s_isCacheSettingReadOnly)
		{
			return;
		}
		lock (s_cacheLock)
		{
			s_isCacheSettingReadOnly = true;
		}
	}

	private void CreateChannelInternal()
	{
		try
		{
			_channel = CreateChannel();
			if (_sharingFinalized && _canShareFactory && !_useCachedFactory)
			{
				TryAddChannelFactoryToCache();
			}
		}
		finally
		{
			if (!_sharingFinalized && s_cacheSetting == CacheSetting.Default)
			{
				TryDisableSharing();
			}
		}
	}

	protected virtual TChannel CreateChannel()
	{
		if (_sharingFinalized)
		{
			return GetChannelFactory().CreateChannel();
		}
		lock (finalizeLock)
		{
			_sharingFinalized = true;
			return GetChannelFactory().CreateChannel();
		}
	}

	void IDisposable.Dispose()
	{
		Close();
	}

	async ValueTask IAsyncDisposable.DisposeAsync()
	{
		try
		{
			if (State == CommunicationState.Opened)
			{
				await CloseAsync();
			}
			if (State != CommunicationState.Closed)
			{
				Abort();
			}
		}
		catch (CommunicationException)
		{
			Abort();
		}
		catch (TimeoutException)
		{
			Abort();
		}
	}

	void ICommunicationObject.Open(TimeSpan timeout)
	{
		TimeoutHelper timeoutHelper = new TimeoutHelper(timeout);
		if (!_useCachedFactory)
		{
			GetChannelFactory().Open(timeoutHelper.RemainingTime());
		}
		InnerChannel.Open(timeoutHelper.RemainingTime());
	}

	void ICommunicationObject.Close(TimeSpan timeout)
	{
		using ServiceModelActivity activity = (DiagnosticUtility.ShouldUseActivity ? ServiceModelActivity.CreateBoundedActivity() : null);
		if (DiagnosticUtility.ShouldUseActivity)
		{
			ServiceModelActivity.Start(activity, System.SR.Format(System.SR.ActivityCloseClientBase, typeof(TChannel).FullName), ActivityType.Close);
		}
		TimeoutHelper timeoutHelper = new TimeoutHelper(timeout);
		if (_channel != null)
		{
			InnerChannel.Close(timeoutHelper.RemainingTime());
		}
		if (_channelFactoryRefReleased)
		{
			return;
		}
		lock (s_staticLock)
		{
			if (!_channelFactoryRefReleased)
			{
				if (_channelFactoryRef.Release())
				{
					_releasedLastRef = true;
				}
				_channelFactoryRefReleased = true;
			}
		}
		if (_releasedLastRef)
		{
			if (_useCachedFactory)
			{
				_channelFactoryRef.Abort();
			}
			else
			{
				_channelFactoryRef.Close(timeoutHelper.RemainingTime());
			}
		}
	}

	IAsyncResult ICommunicationObject.BeginClose(AsyncCallback callback, object state)
	{
		return ((ICommunicationObject)this).BeginClose(GetChannelFactory().InternalCloseTimeout, callback, state);
	}

	IAsyncResult ICommunicationObject.BeginClose(TimeSpan timeout, AsyncCallback callback, object state)
	{
		return CloseAsync(timeout).ToApm(callback, state);
	}

	void ICommunicationObject.EndClose(IAsyncResult result)
	{
		result.ToApmEnd();
	}

	IAsyncResult ICommunicationObject.BeginOpen(AsyncCallback callback, object state)
	{
		return ((ICommunicationObject)this).BeginOpen(GetChannelFactory().InternalOpenTimeout, callback, state);
	}

	IAsyncResult ICommunicationObject.BeginOpen(TimeSpan timeout, AsyncCallback callback, object state)
	{
		return OpenAsync(timeout).ToApm(callback, state);
	}

	void ICommunicationObject.EndOpen(IAsyncResult result)
	{
		result.ToApmEnd();
	}

	private ChannelFactory<TChannel> GetChannelFactory()
	{
		return _channelFactoryRef.ChannelFactory;
	}

	private void InitializeChannelFactoryRef()
	{
		lock (s_staticLock)
		{
			if (s_factoryRefCache.TryGetValue(_endpointTrait, out var value))
			{
				if (value.ChannelFactory.State == CommunicationState.Opened)
				{
					_channelFactoryRef = value;
					_channelFactoryRef.AddRef();
					_useCachedFactory = true;
					if (WcfEventSource.Instance.ClientBaseChannelFactoryCacheHitIsEnabled())
					{
						WcfEventSource.Instance.ClientBaseChannelFactoryCacheHit(this);
					}
					return;
				}
				s_factoryRefCache.Remove(_endpointTrait);
			}
		}
		if (_channelFactoryRef == null)
		{
			_channelFactoryRef = CreateChannelFactoryRef(_endpointTrait);
		}
	}

	private static ChannelFactoryRef<TChannel> CreateChannelFactoryRef(EndpointTrait<TChannel> endpointTrait)
	{
		ChannelFactory<TChannel> channelFactory = endpointTrait.CreateChannelFactory();
		channelFactory.TraceOpenAndClose = false;
		return new ChannelFactoryRef<TChannel>(channelFactory);
	}

	private void TryDisableSharing()
	{
		if (_sharingFinalized)
		{
			return;
		}
		lock (finalizeLock)
		{
			if (_sharingFinalized)
			{
				return;
			}
			_canShareFactory = false;
			_sharingFinalized = true;
			if (_useCachedFactory)
			{
				ChannelFactoryRef<TChannel> channelFactoryRef = _channelFactoryRef;
				_channelFactoryRef = CreateChannelFactoryRef(_endpointTrait);
				_useCachedFactory = false;
				lock (s_staticLock)
				{
					if (!channelFactoryRef.Release())
					{
						channelFactoryRef = null;
					}
				}
				channelFactoryRef?.Abort();
			}
		}
		if (WcfEventSource.Instance.ClientBaseUsingLocalChannelFactoryIsEnabled())
		{
			WcfEventSource.Instance.ClientBaseUsingLocalChannelFactory(this);
		}
	}

	private void TryAddChannelFactoryToCache()
	{
		lock (s_staticLock)
		{
			if (!s_factoryRefCache.TryGetValue(_endpointTrait, out var _))
			{
				_channelFactoryRef.AddRef();
				s_factoryRefCache.Add(_endpointTrait, _channelFactoryRef);
				_useCachedFactory = true;
				if (WcfEventSource.Instance.ClientBaseCachedChannelFactoryCountIsEnabled())
				{
					WcfEventSource.Instance.ClientBaseCachedChannelFactoryCount(s_factoryRefCache.Count, 32, this);
				}
			}
		}
	}

	private void InvalidateCacheAndCreateChannel()
	{
		RemoveFactoryFromCache();
		TryDisableSharing();
		CreateChannelInternal();
	}

	private void RemoveFactoryFromCache()
	{
		lock (s_staticLock)
		{
			if (s_factoryRefCache.TryGetValue(_endpointTrait, out var value) && _channelFactoryRef == value)
			{
				s_factoryRefCache.Remove(_endpointTrait);
			}
		}
	}

	protected void InvokeAsync(BeginOperationDelegate beginOperationDelegate, object[] inValues, EndOperationDelegate endOperationDelegate, SendOrPostCallback operationCompletedCallback, object userState)
	{
		if (beginOperationDelegate == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("beginOperationDelegate");
		}
		if (endOperationDelegate == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("endOperationDelegate");
		}
		AsyncOperation asyncOperation = AsyncOperationManager.CreateOperation(userState);
		AsyncOperationContext asyncOperationContext = new AsyncOperationContext(asyncOperation, endOperationDelegate, operationCompletedCallback);
		Exception ex = null;
		object[] results = null;
		IAsyncResult asyncResult = null;
		try
		{
			asyncResult = beginOperationDelegate(inValues, s_onAsyncCallCompleted, asyncOperationContext);
			if (asyncResult.CompletedSynchronously)
			{
				results = endOperationDelegate(asyncResult);
			}
		}
		catch (Exception ex2)
		{
			if (Fx.IsFatal(ex2))
			{
				throw;
			}
			ex = ex2;
		}
		if (ex != null || asyncResult.CompletedSynchronously)
		{
			CompleteAsyncCall(asyncOperationContext, results, ex);
		}
	}

	private static void OnAsyncCallCompleted(IAsyncResult result)
	{
		if (result.CompletedSynchronously)
		{
			return;
		}
		AsyncOperationContext asyncOperationContext = (AsyncOperationContext)result.AsyncState;
		Exception error = null;
		object[] results = null;
		try
		{
			results = asyncOperationContext.EndDelegate(result);
		}
		catch (Exception ex)
		{
			if (Fx.IsFatal(ex))
			{
				throw;
			}
			error = ex;
		}
		CompleteAsyncCall(asyncOperationContext, results, error);
	}

	private static void CompleteAsyncCall(AsyncOperationContext context, object[] results, Exception error)
	{
		if (context.CompletionCallback != null)
		{
			InvokeAsyncCompletedEventArgs arg = new InvokeAsyncCompletedEventArgs(results, error, cancelled: false, context.AsyncOperation.UserSuppliedState);
			context.AsyncOperation.PostOperationCompleted(context.CompletionCallback, arg);
		}
		else
		{
			context.AsyncOperation.OperationCompleted();
		}
	}
}
