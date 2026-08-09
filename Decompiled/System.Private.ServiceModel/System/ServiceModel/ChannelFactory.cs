using System.Runtime;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Diagnostics;
using System.ServiceModel.Security;
using System.Threading.Tasks;

namespace System.ServiceModel;

public abstract class ChannelFactory : CommunicationObject, IChannelFactory, ICommunicationObject, IDisposable, IAsyncDisposable
{
	private string _configurationName;

	private ClientCredentials _readOnlyClientCredentials;

	private object _openLock = new object();

	public ClientCredentials Credentials
	{
		get
		{
			if (Endpoint == null)
			{
				return null;
			}
			if (base.State == CommunicationState.Created || base.State == CommunicationState.Opening)
			{
				return EnsureCredentials(Endpoint);
			}
			if (_readOnlyClientCredentials == null)
			{
				ClientCredentials clientCredentials = new ClientCredentials();
				clientCredentials.MakeReadOnly();
				_readOnlyClientCredentials = clientCredentials;
			}
			return _readOnlyClientCredentials;
		}
	}

	protected override TimeSpan DefaultCloseTimeout
	{
		get
		{
			if (Endpoint != null && Endpoint.Binding != null)
			{
				return Endpoint.Binding.CloseTimeout;
			}
			return ServiceDefaults.CloseTimeout;
		}
	}

	protected override TimeSpan DefaultOpenTimeout
	{
		get
		{
			if (Endpoint != null && Endpoint.Binding != null)
			{
				return Endpoint.Binding.OpenTimeout;
			}
			return ServiceDefaults.OpenTimeout;
		}
	}

	public ServiceEndpoint Endpoint { get; private set; }

	internal IChannelFactory InnerFactory { get; private set; }

	internal bool UseActiveAutoClose { get; set; }

	protected ChannelFactory()
	{
		TraceUtility.SetEtwProviderId();
		base.TraceOpenAndClose = true;
	}

	protected internal void EnsureOpened()
	{
		ThrowIfDisposed();
		if (base.State == CommunicationState.Opened)
		{
			return;
		}
		lock (_openLock)
		{
			if (base.State != CommunicationState.Opened)
			{
				Open();
			}
		}
	}

	protected virtual void ApplyConfiguration(string configurationName)
	{
		if (!string.IsNullOrEmpty(configurationName))
		{
			throw ExceptionHelper.PlatformNotSupported();
		}
	}

	protected abstract ServiceEndpoint CreateDescription();

	internal EndpointAddress CreateEndpointAddress(ServiceEndpoint endpoint)
	{
		if (endpoint.Address == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.SFxChannelFactoryEndpointAddressUri));
		}
		return endpoint.Address;
	}

	protected virtual IChannelFactory CreateFactory()
	{
		if (Endpoint == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.SFxChannelFactoryCannotCreateFactoryWithoutDescription));
		}
		if (Endpoint.Binding == null)
		{
			if (_configurationName != null)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.Format(System.SR.SFxChannelFactoryNoBindingFoundInConfig1, _configurationName)));
			}
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.SFxChannelFactoryNoBindingFoundInConfigOrCode));
		}
		return ServiceChannelFactory.BuildChannelFactory(Endpoint, UseActiveAutoClose);
	}

	void IDisposable.Dispose()
	{
		Close();
	}

	async ValueTask IAsyncDisposable.DisposeAsync()
	{
		try
		{
			if (base.State == CommunicationState.Opened)
			{
				await ((IAsyncCommunicationObject)this).CloseAsync(DefaultCloseTimeout);
			}
			if (base.State != CommunicationState.Closed)
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

	private void EnsureSecurityCredentialsManager(ServiceEndpoint endpoint)
	{
		if (endpoint.Behaviors.Find<SecurityCredentialsManager>() == null)
		{
			endpoint.Behaviors.Add(new ClientCredentials());
		}
	}

	private ClientCredentials EnsureCredentials(ServiceEndpoint endpoint)
	{
		ClientCredentials clientCredentials = endpoint.Behaviors.Find<ClientCredentials>();
		if (clientCredentials == null)
		{
			clientCredentials = new ClientCredentials();
			endpoint.Behaviors.Add(clientCredentials);
		}
		return clientCredentials;
	}

	public T GetProperty<T>() where T : class
	{
		if (InnerFactory != null)
		{
			return InnerFactory.GetProperty<T>();
		}
		return null;
	}

	internal bool HasDuplexOperations()
	{
		OperationDescriptionCollection operations = Endpoint.Contract.Operations;
		for (int i = 0; i < operations.Count; i++)
		{
			OperationDescription operationDescription = operations[i];
			if (operationDescription.IsServerInitiated())
			{
				return true;
			}
		}
		return false;
	}

	protected void InitializeEndpoint(string configurationName, EndpointAddress address)
	{
		Endpoint = CreateDescription();
		ServiceEndpoint serviceEndpoint = null;
		if (configurationName != null)
		{
			throw ExceptionHelper.PlatformNotSupported();
		}
		if (serviceEndpoint != null)
		{
			Endpoint = serviceEndpoint;
		}
		else
		{
			if (address != null)
			{
				Endpoint.Address = address;
			}
			ApplyConfiguration(configurationName);
		}
		_configurationName = configurationName;
		EnsureSecurityCredentialsManager(Endpoint);
	}

	protected void InitializeEndpoint(ServiceEndpoint endpoint)
	{
		Endpoint = endpoint ?? throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("endpoint");
		ApplyConfiguration(null);
		EnsureSecurityCredentialsManager(Endpoint);
	}

	protected void InitializeEndpoint(Binding binding, EndpointAddress address)
	{
		Endpoint = CreateDescription();
		if (binding != null)
		{
			Endpoint.Binding = binding;
		}
		if (address != null)
		{
			Endpoint.Address = address;
		}
		ApplyConfiguration(null);
		EnsureSecurityCredentialsManager(Endpoint);
	}

	protected override void OnOpened()
	{
		if (Endpoint != null)
		{
			ClientCredentials clientCredentials = Endpoint.Behaviors.Find<ClientCredentials>();
			if (clientCredentials != null)
			{
				ClientCredentials clientCredentials2 = clientCredentials.Clone();
				clientCredentials2.MakeReadOnly();
				_readOnlyClientCredentials = clientCredentials2;
			}
		}
		base.OnOpened();
	}

	protected override void OnAbort()
	{
		if (InnerFactory != null)
		{
			InnerFactory.Abort();
		}
	}

	protected override IAsyncResult OnBeginClose(TimeSpan timeout, AsyncCallback callback, object state)
	{
		return CommunicationObjectInternal.OnBeginClose(this, timeout, callback, state);
	}

	protected override void OnEndClose(IAsyncResult result)
	{
		CommunicationObjectInternal.OnEnd(result);
	}

	protected internal override async Task OnCloseAsync(TimeSpan timeout)
	{
		if (InnerFactory != null)
		{
			await CloseOtherAsync(InnerFactory, timeout);
		}
	}

	protected override IAsyncResult OnBeginOpen(TimeSpan timeout, AsyncCallback callback, object state)
	{
		return CommunicationObjectInternal.OnBeginOpen(this, timeout, callback, state);
	}

	protected override void OnEndOpen(IAsyncResult result)
	{
		CommunicationObjectInternal.OnEnd(result);
	}

	protected internal override async Task OnOpenAsync(TimeSpan timeout)
	{
		if (InnerFactory != null)
		{
			await OpenOtherAsync(InnerFactory, timeout);
		}
	}

	protected override void OnClose(TimeSpan timeout)
	{
		if (InnerFactory != null)
		{
			InnerFactory.Close(timeout);
		}
	}

	protected override void OnOpen(TimeSpan timeout)
	{
		InnerFactory.Open(timeout);
	}

	protected override void OnOpening()
	{
		base.OnOpening();
		InnerFactory = CreateFactory();
		if (WcfEventSource.Instance.ChannelFactoryCreatedIsEnabled())
		{
			WcfEventSource.Instance.ChannelFactoryCreated(this);
		}
		if (InnerFactory == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.InnerChannelFactoryWasNotSet));
		}
	}
}
public class ChannelFactory<TChannel> : ChannelFactory, IChannelFactory<TChannel>, IChannelFactory, ICommunicationObject
{
	private Type _channelType;

	private TypeLoader _typeLoader;

	internal InstanceContext CallbackInstance { get; set; }

	internal Type CallbackType { get; set; }

	internal ServiceChannelFactory ServiceChannelFactory => (ServiceChannelFactory)base.InnerFactory;

	internal TypeLoader TypeLoader
	{
		get
		{
			if (_typeLoader == null)
			{
				_typeLoader = new TypeLoader();
			}
			return _typeLoader;
		}
	}

	protected ChannelFactory(Type channelType)
	{
		if (channelType == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("channelType");
		}
		if (!channelType.IsInterface())
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.SFxChannelFactoryTypeMustBeInterface));
		}
		_channelType = channelType;
	}

	public ChannelFactory()
		: this(typeof(TChannel))
	{
		using ServiceModelActivity activity = (DiagnosticUtility.ShouldUseActivity ? ServiceModelActivity.CreateBoundedActivity() : null);
		if (DiagnosticUtility.ShouldUseActivity)
		{
			ServiceModelActivity.Start(activity, System.SR.Format(System.SR.ActivityConstructChannelFactory, typeof(TChannel).FullName), ActivityType.Construct);
		}
		InitializeEndpoint((string)null, (EndpointAddress)null);
	}

	public ChannelFactory(string endpointConfigurationName)
		: this(endpointConfigurationName, (EndpointAddress)null)
	{
	}

	public ChannelFactory(string endpointConfigurationName, EndpointAddress remoteAddress)
		: this(typeof(TChannel))
	{
		using ServiceModelActivity activity = (DiagnosticUtility.ShouldUseActivity ? ServiceModelActivity.CreateBoundedActivity() : null);
		if (DiagnosticUtility.ShouldUseActivity)
		{
			ServiceModelActivity.Start(activity, System.SR.Format(System.SR.ActivityConstructChannelFactory, typeof(TChannel).FullName), ActivityType.Construct);
		}
		if (endpointConfigurationName == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("endpointConfigurationName");
		}
		InitializeEndpoint(endpointConfigurationName, remoteAddress);
	}

	public ChannelFactory(Binding binding)
		: this(binding, (EndpointAddress)null)
	{
	}

	public ChannelFactory(Binding binding, string remoteAddress)
		: this(binding, new EndpointAddress(remoteAddress))
	{
	}

	public ChannelFactory(Binding binding, EndpointAddress remoteAddress)
		: this(typeof(TChannel))
	{
		using ServiceModelActivity activity = (DiagnosticUtility.ShouldUseActivity ? ServiceModelActivity.CreateBoundedActivity() : null);
		if (DiagnosticUtility.ShouldUseActivity)
		{
			ServiceModelActivity.Start(activity, System.SR.Format(System.SR.ActivityConstructChannelFactory, typeof(TChannel).FullName), ActivityType.Construct);
		}
		if (binding == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("binding");
		}
		InitializeEndpoint(binding, remoteAddress);
	}

	public ChannelFactory(ServiceEndpoint endpoint)
		: this(typeof(TChannel))
	{
		using ServiceModelActivity activity = (DiagnosticUtility.ShouldUseActivity ? ServiceModelActivity.CreateBoundedActivity() : null);
		if (DiagnosticUtility.ShouldUseActivity)
		{
			ServiceModelActivity.Start(activity, System.SR.Format(System.SR.ActivityConstructChannelFactory, typeof(TChannel).FullName), ActivityType.Construct);
		}
		if (endpoint == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("endpoint");
		}
		InitializeEndpoint(endpoint);
	}

	public TChannel CreateChannel(EndpointAddress address)
	{
		if (address == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("address");
		}
		return CreateChannel(address, address.Uri);
	}

	public virtual TChannel CreateChannel(EndpointAddress address, Uri via)
	{
		bool traceOpenAndClose = base.TraceOpenAndClose;
		try
		{
			if (address == null)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("address");
			}
			if (HasDuplexOperations())
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.Format(System.SR.SFxCreateNonDuplexChannel1, base.Endpoint.Contract.Name)));
			}
			EnsureOpened();
			return ServiceChannelFactory.CreateChannel<TChannel>(address, via);
		}
		finally
		{
			base.TraceOpenAndClose = traceOpenAndClose;
		}
	}

	public TChannel CreateChannel()
	{
		return CreateChannel(CreateEndpointAddress(base.Endpoint), null);
	}

	internal UChannel CreateChannel<UChannel>(EndpointAddress address, Uri via)
	{
		EnsureOpened();
		return ServiceChannelFactory.CreateChannel<UChannel>(address, via);
	}

	internal UChannel CreateChannel<UChannel>(EndpointAddress address)
	{
		EnsureOpened();
		return ServiceChannelFactory.CreateChannel<UChannel>(address);
	}

	protected override ServiceEndpoint CreateDescription()
	{
		ContractDescription contract = TypeLoader.LoadContractDescription(_channelType);
		ServiceEndpoint serviceEndpoint = new ServiceEndpoint(contract);
		ReflectOnCallbackInstance(serviceEndpoint);
		TypeLoader.AddBehaviorsSFx(serviceEndpoint, _channelType);
		return serviceEndpoint;
	}

	private void ReflectOnCallbackInstance(ServiceEndpoint endpoint)
	{
		if (CallbackType != null)
		{
			if (endpoint.Contract.CallbackContractType == null)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.Format(System.SR.SfxCallbackTypeCannotBeNull, endpoint.Contract.ContractType.FullName)));
			}
			TypeLoader.AddBehaviorsFromImplementationType(endpoint, CallbackType);
		}
		else if (CallbackInstance != null && CallbackInstance.UserObject != null)
		{
			if (endpoint.Contract.CallbackContractType == null)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.Format(System.SR.SfxCallbackTypeCannotBeNull, endpoint.Contract.ContractType.FullName)));
			}
			object userObject = CallbackInstance.UserObject;
			Type type = userObject.GetType();
			TypeLoader.AddBehaviorsFromImplementationType(endpoint, type);
			if (userObject is IEndpointBehavior item)
			{
				endpoint.Behaviors.Add(item);
			}
			if (userObject is IContractBehavior item2)
			{
				endpoint.Contract.Behaviors.Add(item2);
			}
		}
	}

	protected static TChannel CreateChannel(string endpointConfigurationName)
	{
		ChannelFactory<TChannel> channelFactory = new ChannelFactory<TChannel>(endpointConfigurationName);
		if (channelFactory.HasDuplexOperations())
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.Format(System.SR.SFxInvalidStaticOverloadCalledForDuplexChannelFactory1, channelFactory._channelType.Name)));
		}
		TChannel val = channelFactory.CreateChannel();
		SetFactoryToAutoClose(val);
		return val;
	}

	public static TChannel CreateChannel(Binding binding, EndpointAddress endpointAddress)
	{
		ChannelFactory<TChannel> channelFactory = new ChannelFactory<TChannel>(binding, endpointAddress);
		if (channelFactory.HasDuplexOperations())
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.Format(System.SR.SFxInvalidStaticOverloadCalledForDuplexChannelFactory1, channelFactory._channelType.Name)));
		}
		TChannel val = channelFactory.CreateChannel();
		SetFactoryToAutoClose(val);
		return val;
	}

	public static TChannel CreateChannel(Binding binding, EndpointAddress endpointAddress, Uri via)
	{
		ChannelFactory<TChannel> channelFactory = new ChannelFactory<TChannel>(binding);
		if (channelFactory.HasDuplexOperations())
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.Format(System.SR.SFxInvalidStaticOverloadCalledForDuplexChannelFactory1, channelFactory._channelType.Name)));
		}
		TChannel val = channelFactory.CreateChannel(endpointAddress, via);
		SetFactoryToAutoClose(val);
		return val;
	}

	internal static void SetFactoryToAutoClose(TChannel channel)
	{
		ServiceChannel serviceChannel = ServiceChannelFactory.GetServiceChannel(channel);
		serviceChannel.CloseFactory = true;
	}
}
