using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using System.Threading.Tasks;

namespace System.ServiceModel.Channels;

internal abstract class ServiceChannelFactory : ChannelFactoryBase
{
	internal abstract class TypedServiceChannelFactory<TChannel> : ServiceChannelFactory where TChannel : class, IChannel
	{
		protected IChannelFactory<TChannel> InnerChannelFactory { get; }

		protected TypedServiceChannelFactory(IChannelFactory<TChannel> innerChannelFactory, ClientRuntime clientRuntime, Binding binding)
			: base(clientRuntime, binding)
		{
			InnerChannelFactory = innerChannelFactory;
		}

		protected override void OnAbort()
		{
			base.OnAbort();
			InnerChannelFactory.Abort();
		}

		protected override void OnOpen(TimeSpan timeout)
		{
			InnerChannelFactory.Open(timeout);
		}

		protected override IAsyncResult OnBeginOpen(TimeSpan timeout, AsyncCallback callback, object state)
		{
			return InnerChannelFactory.BeginOpen(timeout, callback, state);
		}

		protected override void OnEndOpen(IAsyncResult result)
		{
			InnerChannelFactory.EndOpen(result);
		}

		protected override void OnClose(TimeSpan timeout)
		{
			TimeoutHelper timeoutHelper = new TimeoutHelper(timeout);
			base.OnClose(timeoutHelper.RemainingTime());
			InnerChannelFactory.Close(timeoutHelper.RemainingTime());
		}

		protected override IAsyncResult OnBeginClose(TimeSpan timeout, AsyncCallback callback, object state)
		{
			return OnCloseAsync(timeout).ToApm(callback, state);
		}

		protected override void OnEndClose(IAsyncResult result)
		{
			result.ToApmEnd();
		}

		protected internal override Task OnCloseAsync(TimeSpan timeout)
		{
			return OnCloseAsyncInternal(timeout);
		}

		protected internal override Task OnOpenAsync(TimeSpan timeout)
		{
			return OpenOtherAsync(InnerChannelFactory, timeout);
		}

		public override T GetProperty<T>()
		{
			if (typeof(T) == typeof(TypedServiceChannelFactory<TChannel>))
			{
				return (T)(object)this;
			}
			T property = base.GetProperty<T>();
			if (property != null)
			{
				return property;
			}
			return InnerChannelFactory.GetProperty<T>();
		}

		private new async Task OnCloseAsyncInternal(TimeSpan timeout)
		{
			TimeoutHelper timeoutHelper = new TimeoutHelper(timeout);
			if (!_isSynchronousClose)
			{
				await Task.Factory.FromAsync([DebuggerHidden] (TimeSpan timeout2, AsyncCallback callback, object state) => base.OnBeginClose(timeout2, callback, state), [DebuggerHidden] (IAsyncResult result) =>
				{
					base.OnEndClose(result);
				}, timeoutHelper.RemainingTime(), TaskCreationOptions.None);
			}
			else
			{
				await TaskHelpers.CallActionAsync([DebuggerHidden] (TimeSpan timeout2) =>
				{
					base.OnClose(timeout2);
				}, timeoutHelper.RemainingTime());
			}
			await CloseOtherAsync(InnerChannelFactory, timeoutHelper.RemainingTime());
		}
	}

	private class ServiceChannelFactoryOverOutput : TypedServiceChannelFactory<IOutputChannel>
	{
		public ServiceChannelFactoryOverOutput(IChannelFactory<IOutputChannel> innerChannelFactory, ClientRuntime clientRuntime, Binding binding)
			: base(innerChannelFactory, clientRuntime, binding)
		{
		}

		protected override IChannelBinder CreateInnerChannelBinder(EndpointAddress to, Uri via)
		{
			return new OutputChannelBinder(base.InnerChannelFactory.CreateChannel(to, via));
		}

		public override bool CanCreateChannel<TChannel>()
		{
			if (!(typeof(TChannel) == typeof(IOutputChannel)))
			{
				return typeof(TChannel) == typeof(IRequestChannel);
			}
			return true;
		}
	}

	private class ServiceChannelFactoryOverDuplex : TypedServiceChannelFactory<IDuplexChannel>
	{
		public ServiceChannelFactoryOverDuplex(IChannelFactory<IDuplexChannel> innerChannelFactory, ClientRuntime clientRuntime, Binding binding)
			: base(innerChannelFactory, clientRuntime, binding)
		{
		}

		protected override IChannelBinder CreateInnerChannelBinder(EndpointAddress to, Uri via)
		{
			return new DuplexChannelBinder(base.InnerChannelFactory.CreateChannel(to, via), base.RequestReplyCorrelator);
		}

		public override bool CanCreateChannel<TChannel>()
		{
			if (!(typeof(TChannel) == typeof(IOutputChannel)) && !(typeof(TChannel) == typeof(IRequestChannel)))
			{
				return typeof(TChannel) == typeof(IDuplexChannel);
			}
			return true;
		}
	}

	private class ServiceChannelFactoryOverRequest : TypedServiceChannelFactory<IRequestChannel>
	{
		public ServiceChannelFactoryOverRequest(IChannelFactory<IRequestChannel> innerChannelFactory, ClientRuntime clientRuntime, Binding binding)
			: base(innerChannelFactory, clientRuntime, binding)
		{
		}

		protected override IChannelBinder CreateInnerChannelBinder(EndpointAddress to, Uri via)
		{
			return new RequestChannelBinder(base.InnerChannelFactory.CreateChannel(to, via));
		}

		public override bool CanCreateChannel<TChannel>()
		{
			if (!(typeof(TChannel) == typeof(IOutputChannel)))
			{
				return typeof(TChannel) == typeof(IRequestChannel);
			}
			return true;
		}
	}

	internal class ServiceChannelFactoryOverOutputSession : TypedServiceChannelFactory<IOutputSessionChannel>
	{
		private bool _datagramAdapter;

		public ServiceChannelFactoryOverOutputSession(IChannelFactory<IOutputSessionChannel> innerChannelFactory, ClientRuntime clientRuntime, Binding binding, bool datagramAdapter)
			: base(innerChannelFactory, clientRuntime, binding)
		{
			_datagramAdapter = datagramAdapter;
		}

		protected override IChannelBinder CreateInnerChannelBinder(EndpointAddress to, Uri via)
		{
			IOutputChannel channel = base.InnerChannelFactory.CreateChannel(to, via);
			return new OutputChannelBinder(channel);
		}

		public override bool CanCreateChannel<TChannel>()
		{
			if (!(typeof(TChannel) == typeof(IOutputChannel)) && !(typeof(TChannel) == typeof(IOutputSessionChannel)) && !(typeof(TChannel) == typeof(IRequestChannel)))
			{
				return typeof(TChannel) == typeof(IRequestSessionChannel);
			}
			return true;
		}
	}

	internal class ServiceChannelFactoryOverDuplexSession : TypedServiceChannelFactory<IDuplexSessionChannel>
	{
		private bool _useActiveAutoClose;

		public ServiceChannelFactoryOverDuplexSession(IChannelFactory<IDuplexSessionChannel> innerChannelFactory, ClientRuntime clientRuntime, Binding binding, bool useActiveAutoClose)
			: base(innerChannelFactory, clientRuntime, binding)
		{
			_useActiveAutoClose = useActiveAutoClose;
		}

		protected override IChannelBinder CreateInnerChannelBinder(EndpointAddress to, Uri via)
		{
			return new DuplexChannelBinder(base.InnerChannelFactory.CreateChannel(to, via), base.RequestReplyCorrelator, _useActiveAutoClose);
		}

		public override bool CanCreateChannel<TChannel>()
		{
			if (!(typeof(TChannel) == typeof(IOutputChannel)) && !(typeof(TChannel) == typeof(IRequestChannel)) && !(typeof(TChannel) == typeof(IDuplexChannel)) && !(typeof(TChannel) == typeof(IOutputSessionChannel)) && !(typeof(TChannel) == typeof(IRequestSessionChannel)))
			{
				return typeof(TChannel) == typeof(IDuplexSessionChannel);
			}
			return true;
		}
	}

	internal class ServiceChannelFactoryOverRequestSession : TypedServiceChannelFactory<IRequestSessionChannel>
	{
		private bool _datagramAdapter;

		public ServiceChannelFactoryOverRequestSession(IChannelFactory<IRequestSessionChannel> innerChannelFactory, ClientRuntime clientRuntime, Binding binding, bool datagramAdapter)
			: base(innerChannelFactory, clientRuntime, binding)
		{
			_datagramAdapter = datagramAdapter;
		}

		protected override IChannelBinder CreateInnerChannelBinder(EndpointAddress to, Uri via)
		{
			IRequestChannel channel = base.InnerChannelFactory.CreateChannel(to, via);
			return new RequestChannelBinder(channel);
		}

		public override bool CanCreateChannel<TChannel>()
		{
			if (!(typeof(TChannel) == typeof(IOutputChannel)) && !(typeof(TChannel) == typeof(IOutputSessionChannel)) && !(typeof(TChannel) == typeof(IRequestChannel)))
			{
				return typeof(TChannel) == typeof(IRequestSessionChannel);
			}
			return true;
		}
	}

	internal class DefaultCommunicationTimeouts : IDefaultCommunicationTimeouts
	{
		private TimeSpan _sendTimeout;

		public TimeSpan CloseTimeout { get; }

		public TimeSpan OpenTimeout { get; }

		public TimeSpan ReceiveTimeout { get; }

		public TimeSpan SendTimeout => _sendTimeout;

		public DefaultCommunicationTimeouts(IDefaultCommunicationTimeouts timeouts)
		{
			CloseTimeout = timeouts.CloseTimeout;
			OpenTimeout = timeouts.OpenTimeout;
			ReceiveTimeout = timeouts.ReceiveTimeout;
			_sendTimeout = timeouts.SendTimeout;
		}
	}

	private string _bindingName;

	private List<IChannel> _channelsList;

	private ClientRuntime _clientRuntime;

	private RequestReplyCorrelator _requestReplyCorrelator = new RequestReplyCorrelator();

	private IDefaultCommunicationTimeouts _timeouts;

	public ClientRuntime ClientRuntime
	{
		get
		{
			ThrowIfDisposed();
			return _clientRuntime;
		}
	}

	internal RequestReplyCorrelator RequestReplyCorrelator
	{
		get
		{
			ThrowIfDisposed();
			return _requestReplyCorrelator;
		}
	}

	protected override TimeSpan DefaultCloseTimeout => _timeouts.CloseTimeout;

	protected override TimeSpan DefaultReceiveTimeout => _timeouts.ReceiveTimeout;

	protected override TimeSpan DefaultOpenTimeout => _timeouts.OpenTimeout;

	protected override TimeSpan DefaultSendTimeout => _timeouts.SendTimeout;

	public MessageVersion MessageVersion { get; }

	public ServiceChannelFactory(ClientRuntime clientRuntime, Binding binding)
	{
		_bindingName = binding.Name;
		_channelsList = new List<IChannel>();
		_clientRuntime = clientRuntime ?? throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("clientRuntime");
		_timeouts = new DefaultCommunicationTimeouts(binding);
		MessageVersion = binding.MessageVersion;
	}

	public static ServiceChannelFactory BuildChannelFactory(ChannelBuilder channelBuilder, ClientRuntime clientRuntime)
	{
		if (channelBuilder.CanBuildChannelFactory<IDuplexChannel>())
		{
			return new ServiceChannelFactoryOverDuplex(channelBuilder.BuildChannelFactory<IDuplexChannel>(), clientRuntime, channelBuilder.Binding);
		}
		if (channelBuilder.CanBuildChannelFactory<IDuplexSessionChannel>())
		{
			return new ServiceChannelFactoryOverDuplexSession(channelBuilder.BuildChannelFactory<IDuplexSessionChannel>(), clientRuntime, channelBuilder.Binding, useActiveAutoClose: false);
		}
		return new ServiceChannelFactoryOverRequestSession(channelBuilder.BuildChannelFactory<IRequestSessionChannel>(), clientRuntime, channelBuilder.Binding, datagramAdapter: false);
	}

	public static ServiceChannelFactory BuildChannelFactory(ServiceEndpoint serviceEndpoint)
	{
		return BuildChannelFactory(serviceEndpoint, useActiveAutoClose: false);
	}

	public static ServiceChannelFactory BuildChannelFactory(ServiceEndpoint serviceEndpoint, bool useActiveAutoClose)
	{
		if (serviceEndpoint == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("serviceEndpoint");
		}
		serviceEndpoint.EnsureInvariants();
		serviceEndpoint.ValidateForClient();
		ContractDescription contract = serviceEndpoint.Contract;
		ChannelRequirements.ComputeContractRequirements(contract, out var requirements);
		BindingParameterCollection parameters;
		ClientRuntime clientRuntime = DispatcherBuilder.BuildProxyBehavior(serviceEndpoint, out parameters);
		Binding binding = serviceEndpoint.Binding;
		Type[] array = ChannelRequirements.ComputeRequiredChannels(ref requirements);
		CustomBinding binding2 = new CustomBinding(binding);
		BindingContext bindingContext = new BindingContext(binding2, parameters);
		binding2 = new CustomBinding(bindingContext.RemainingBindingElements);
		binding2.CopyTimeouts(serviceEndpoint.Binding);
		Type[] array2 = array;
		foreach (Type type in array2)
		{
			if (type == typeof(IOutputChannel) && binding2.CanBuildChannelFactory<IOutputChannel>(parameters))
			{
				return new ServiceChannelFactoryOverOutput(binding2.BuildChannelFactory<IOutputChannel>(parameters), clientRuntime, binding);
			}
			if (type == typeof(IRequestChannel) && binding2.CanBuildChannelFactory<IRequestChannel>(parameters))
			{
				return new ServiceChannelFactoryOverRequest(binding2.BuildChannelFactory<IRequestChannel>(parameters), clientRuntime, binding);
			}
			if (type == typeof(IDuplexChannel) && binding2.CanBuildChannelFactory<IDuplexChannel>(parameters))
			{
				if (requirements.usesReply && binding.CreateBindingElements().Find<TransportBindingElement>().ManualAddressing)
				{
					throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.CantCreateChannelWithManualAddressing));
				}
				return new ServiceChannelFactoryOverDuplex(binding2.BuildChannelFactory<IDuplexChannel>(parameters), clientRuntime, binding);
			}
			if (type == typeof(IOutputSessionChannel) && binding2.CanBuildChannelFactory<IOutputSessionChannel>(parameters))
			{
				return new ServiceChannelFactoryOverOutputSession(binding2.BuildChannelFactory<IOutputSessionChannel>(parameters), clientRuntime, binding, datagramAdapter: false);
			}
			if (type == typeof(IRequestSessionChannel) && binding2.CanBuildChannelFactory<IRequestSessionChannel>(parameters))
			{
				return new ServiceChannelFactoryOverRequestSession(binding2.BuildChannelFactory<IRequestSessionChannel>(parameters), clientRuntime, binding, datagramAdapter: false);
			}
			if (type == typeof(IDuplexSessionChannel) && binding2.CanBuildChannelFactory<IDuplexSessionChannel>(parameters))
			{
				if (requirements.usesReply && binding.CreateBindingElements().Find<TransportBindingElement>().ManualAddressing)
				{
					throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.CantCreateChannelWithManualAddressing));
				}
				return new ServiceChannelFactoryOverDuplexSession(binding2.BuildChannelFactory<IDuplexSessionChannel>(parameters), clientRuntime, binding, useActiveAutoClose);
			}
		}
		Type[] array3 = array;
		foreach (Type type2 in array3)
		{
			if (type2 == typeof(IOutputChannel) && binding2.CanBuildChannelFactory<IOutputSessionChannel>(parameters))
			{
				return new ServiceChannelFactoryOverOutputSession(binding2.BuildChannelFactory<IOutputSessionChannel>(parameters), clientRuntime, binding, datagramAdapter: true);
			}
			if (type2 == typeof(IRequestChannel) && binding2.CanBuildChannelFactory<IRequestSessionChannel>(parameters))
			{
				return new ServiceChannelFactoryOverRequestSession(binding2.BuildChannelFactory<IRequestSessionChannel>(parameters), clientRuntime, binding, datagramAdapter: true);
			}
			if (type2 == typeof(IRequestSessionChannel) && binding2.CanBuildChannelFactory<IRequestChannel>(parameters) && binding2.GetProperty<IContextSessionProvider>(parameters) != null)
			{
				return new ServiceChannelFactoryOverRequest(binding2.BuildChannelFactory<IRequestChannel>(parameters), clientRuntime, binding);
			}
		}
		Dictionary<Type, byte> dictionary = new Dictionary<Type, byte>();
		if (binding2.CanBuildChannelFactory<IOutputChannel>(parameters))
		{
			dictionary.Add(typeof(IOutputChannel), 0);
		}
		if (binding2.CanBuildChannelFactory<IRequestChannel>(parameters))
		{
			dictionary.Add(typeof(IRequestChannel), 0);
		}
		if (binding2.CanBuildChannelFactory<IDuplexChannel>(parameters))
		{
			dictionary.Add(typeof(IDuplexChannel), 0);
		}
		if (binding2.CanBuildChannelFactory<IOutputSessionChannel>(parameters))
		{
			dictionary.Add(typeof(IOutputSessionChannel), 0);
		}
		if (binding2.CanBuildChannelFactory<IRequestSessionChannel>(parameters))
		{
			dictionary.Add(typeof(IRequestSessionChannel), 0);
		}
		if (binding2.CanBuildChannelFactory<IDuplexSessionChannel>(parameters))
		{
			dictionary.Add(typeof(IDuplexSessionChannel), 0);
		}
		throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(ChannelRequirements.CantCreateChannelException(dictionary.Keys, array, binding.Name));
	}

	protected override void OnAbort()
	{
		IChannel channel = null;
		lock (base.ThisLock)
		{
			channel = ((_channelsList.Count > 0) ? _channelsList[_channelsList.Count - 1] : null);
		}
		while (channel != null)
		{
			channel.Abort();
			lock (base.ThisLock)
			{
				_channelsList.Remove(channel);
				channel = ((_channelsList.Count > 0) ? _channelsList[_channelsList.Count - 1] : null);
			}
		}
	}

	protected override void OnClose(TimeSpan timeout)
	{
		TimeoutHelper timeoutHelper = new TimeoutHelper(timeout);
		while (true)
		{
			IChannel channel;
			lock (base.ThisLock)
			{
				if (_channelsList.Count == 0)
				{
					break;
				}
				channel = _channelsList[0];
			}
			channel.Close(timeoutHelper.RemainingTime());
		}
	}

	protected override IAsyncResult OnBeginClose(TimeSpan timeout, AsyncCallback callback, object state)
	{
		List<ICommunicationObject> list;
		lock (base.ThisLock)
		{
			list = new List<ICommunicationObject>();
			for (int i = 0; i < _channelsList.Count; i++)
			{
				list.Add(_channelsList[i]);
			}
		}
		return new CloseCollectionAsyncResult(timeout, callback, state, list);
	}

	protected override void OnEndClose(IAsyncResult result)
	{
		CloseCollectionAsyncResult.End(result);
	}

	protected internal override Task OnCloseAsync(TimeSpan timeout)
	{
		return OnCloseAsyncInternal(timeout);
	}

	protected override void OnOpened()
	{
		base.OnOpened();
		_clientRuntime.LockDownProperties();
	}

	public void ChannelCreated(IChannel channel)
	{
		lock (base.ThisLock)
		{
			ThrowIfDisposed();
			_channelsList.Add(channel);
		}
	}

	public void ChannelDisposed(IChannel channel)
	{
		lock (base.ThisLock)
		{
			_channelsList.Remove(channel);
		}
	}

	public virtual ServiceChannel CreateServiceChannel(EndpointAddress address, Uri via)
	{
		IChannelBinder channelBinder = CreateInnerChannelBinder(address, via);
		ServiceChannel serviceChannel = new ServiceChannel(this, channelBinder);
		if (channelBinder is DuplexChannelBinder)
		{
			DuplexChannelBinder duplexChannelBinder = channelBinder as DuplexChannelBinder;
			duplexChannelBinder.ChannelHandler = new ChannelHandler(MessageVersion, channelBinder, serviceChannel);
			duplexChannelBinder.DefaultCloseTimeout = DefaultCloseTimeout;
			duplexChannelBinder.DefaultSendTimeout = DefaultSendTimeout;
			duplexChannelBinder.IdentityVerifier = _clientRuntime.IdentityVerifier;
		}
		return serviceChannel;
	}

	public TChannel CreateChannel<TChannel>(EndpointAddress address)
	{
		return CreateChannel<TChannel>(address, null);
	}

	public TChannel CreateChannel<TChannel>(EndpointAddress address, Uri via)
	{
		if (via == null)
		{
			via = ClientRuntime.Via;
			if (via == null)
			{
				via = address.Uri;
			}
		}
		ServiceChannel serviceChannel = CreateServiceChannel(address, via);
		serviceChannel.Proxy = CreateProxy<TChannel>(MessageDirection.Input, serviceChannel);
		IClientChannel clientChannel = serviceChannel.Proxy as IClientChannel;
		if (clientChannel == null)
		{
			clientChannel = serviceChannel;
		}
		serviceChannel.ClientRuntime.GetRuntime().InitializeChannel(clientChannel);
		OperationContext current = OperationContext.Current;
		if (current != null && current.InstanceContext != null)
		{
			current.InstanceContext.WmiChannels.Add((IChannel)serviceChannel.Proxy);
		}
		return (TChannel)serviceChannel.Proxy;
	}

	public abstract bool CanCreateChannel<TChannel>();

	internal static object CreateProxy(Type interfaceType, Type proxiedType, MessageDirection direction, ServiceChannel serviceChannel)
	{
		throw ExceptionHelper.PlatformNotSupported();
	}

	internal static object CreateProxy<TChannel>(MessageDirection direction, ServiceChannel serviceChannel)
	{
		if (!typeof(TChannel).IsInterface())
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.SFxChannelFactoryTypeMustBeInterface));
		}
		return ServiceChannelProxy.CreateProxy<TChannel>(direction, serviceChannel);
	}

	internal static ServiceChannel GetServiceChannel(object transparentProxy)
	{
		if (transparentProxy is IChannelBaseProxy channelBaseProxy)
		{
			return channelBaseProxy.GetServiceChannel();
		}
		if (transparentProxy is ServiceChannelProxy serviceChannelProxy)
		{
			return serviceChannelProxy.GetServiceChannel();
		}
		return null;
	}

	private async Task OnCloseAsyncInternal(TimeSpan timeout)
	{
		TimeoutHelper timeoutHelper = new TimeoutHelper(timeout);
		while (true)
		{
			IChannel other;
			lock (base.ThisLock)
			{
				if (_channelsList.Count == 0)
				{
					break;
				}
				other = _channelsList[0];
			}
			await CloseOtherAsync(other, timeoutHelper.RemainingTime());
		}
	}

	protected abstract IChannelBinder CreateInnerChannelBinder(EndpointAddress address, Uri via);
}
