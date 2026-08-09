using System.Collections.ObjectModel;
using System.Runtime;
using System.Threading.Tasks;

namespace System.ServiceModel.Channels;

internal abstract class ConnectionOrientedTransportChannelFactory<TChannel> : TransportChannelFactory<TChannel>, IConnectionOrientedTransportChannelFactorySettings, IConnectionOrientedTransportFactorySettings, ITransportFactorySettings, IDefaultCommunicationTimeouts, IConnectionOrientedConnectionSettings
{
	private IConnectionInitiator _connectionInitiator;

	private ConnectionPool _connectionPool;

	private bool _exposeConnectionProperty;

	private int _maxOutboundConnectionsPerEndpoint;

	private ISecurityCapabilities _securityCapabilities;

	private StreamUpgradeProvider _upgrade;

	private bool _flowIdentity;

	public int ConnectionBufferSize { get; }

	internal IConnectionInitiator ConnectionInitiator
	{
		get
		{
			if (_connectionInitiator == null)
			{
				lock (base.ThisLock)
				{
					if (_connectionInitiator == null)
					{
						_connectionInitiator = GetConnectionInitiator();
					}
				}
			}
			return _connectionInitiator;
		}
	}

	public string ConnectionPoolGroupName { get; }

	public TimeSpan IdleTimeout { get; }

	public int MaxBufferSize { get; }

	public int MaxOutboundConnectionsPerEndpoint => _maxOutboundConnectionsPerEndpoint;

	public TimeSpan MaxOutputDelay { get; }

	public StreamUpgradeProvider Upgrade
	{
		get
		{
			StreamUpgradeProvider upgrade = _upgrade;
			CommunicationObjectInternal.ThrowIfDisposed(this);
			return upgrade;
		}
	}

	public TransferMode TransferMode { get; }

	int IConnectionOrientedTransportFactorySettings.MaxBufferSize => MaxBufferSize;

	TransferMode IConnectionOrientedTransportFactorySettings.TransferMode => TransferMode;

	StreamUpgradeProvider IConnectionOrientedTransportFactorySettings.Upgrade => Upgrade;

	internal ConnectionOrientedTransportChannelFactory(ConnectionOrientedTransportBindingElement bindingElement, BindingContext context, string connectionPoolGroupName, TimeSpan idleTimeout, int maxOutboundConnectionsPerEndpoint, bool supportsImpersonationDuringAsyncOpen)
		: base((TransportBindingElement)bindingElement, context)
	{
		if (bindingElement.TransferMode == TransferMode.Buffered && bindingElement.MaxReceivedMessageSize > int.MaxValue)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentOutOfRangeException("bindingElement.MaxReceivedMessageSize", System.SR.MaxReceivedMessageSizeMustBeInIntegerRange));
		}
		ConnectionBufferSize = bindingElement.ConnectionBufferSize;
		ConnectionPoolGroupName = connectionPoolGroupName;
		_exposeConnectionProperty = bindingElement.ExposeConnectionProperty;
		IdleTimeout = idleTimeout;
		MaxBufferSize = bindingElement.MaxBufferSize;
		_maxOutboundConnectionsPerEndpoint = maxOutboundConnectionsPerEndpoint;
		MaxOutputDelay = bindingElement.MaxOutputDelay;
		TransferMode = bindingElement.TransferMode;
		Collection<StreamUpgradeBindingElement> collection = context.BindingParameters.FindAll<StreamUpgradeBindingElement>();
		if (collection.Count > 1)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.MultipleStreamUpgradeProvidersInParameters));
		}
		if (collection.Count == 1 && SupportsUpgrade(collection[0]))
		{
			_upgrade = collection[0].BuildClientStreamUpgradeProvider(context);
			context.BindingParameters.Remove<StreamUpgradeBindingElement>();
			_securityCapabilities = collection[0].GetProperty<ISecurityCapabilities>(context);
			_flowIdentity = supportsImpersonationDuringAsyncOpen;
		}
		base.SupportsAsyncOpenClose = true;
	}

	public override T GetProperty<T>()
	{
		if (typeof(T) == typeof(ISecurityCapabilities))
		{
			return (T)_securityCapabilities;
		}
		T property = base.GetProperty<T>();
		if (property == null && _upgrade != null)
		{
			property = _upgrade.GetProperty<T>();
		}
		return property;
	}

	public override int GetMaxBufferSize()
	{
		return MaxBufferSize;
	}

	internal abstract IConnectionInitiator GetConnectionInitiator();

	internal abstract ConnectionPool GetConnectionPool();

	internal abstract void ReleaseConnectionPool(ConnectionPool pool, TimeSpan timeout);

	protected override TChannel OnCreateChannel(EndpointAddress address, Uri via)
	{
		ValidateScheme(via);
		if (TransferMode == TransferMode.Buffered)
		{
			return (TChannel)(object)new ClientFramingDuplexSessionChannel(this, this, address, via, ConnectionInitiator, _connectionPool, _exposeConnectionProperty, _flowIdentity);
		}
		return (TChannel)(object)new StreamedFramingRequestChannel(this, this, address, via, ConnectionInitiator, _connectionPool);
	}

	private bool GetUpgradeAndConnectionPool(out StreamUpgradeProvider upgradeCopy, out ConnectionPool poolCopy)
	{
		if (_upgrade != null || _connectionPool != null)
		{
			lock (base.ThisLock)
			{
				if (_upgrade != null || _connectionPool != null)
				{
					upgradeCopy = _upgrade;
					poolCopy = _connectionPool;
					_upgrade = null;
					_connectionPool = null;
					return true;
				}
			}
		}
		upgradeCopy = null;
		poolCopy = null;
		return false;
	}

	protected override void OnAbort()
	{
		if (GetUpgradeAndConnectionPool(out var upgradeCopy, out var poolCopy))
		{
			if (poolCopy != null)
			{
				ReleaseConnectionPool(poolCopy, TimeSpan.Zero);
			}
			upgradeCopy?.Abort();
		}
	}

	protected override void OnClose(TimeSpan timeout)
	{
		if (GetUpgradeAndConnectionPool(out var upgradeCopy, out var poolCopy))
		{
			TimeoutHelper timeoutHelper = new TimeoutHelper(timeout);
			if (poolCopy != null)
			{
				ReleaseConnectionPool(poolCopy, timeoutHelper.RemainingTime());
			}
			upgradeCopy?.Close(timeoutHelper.RemainingTime());
		}
	}

	protected override void OnOpening()
	{
		base.OnOpening();
		_connectionPool = GetConnectionPool();
	}

	protected override IAsyncResult OnBeginOpen(TimeSpan timeout, AsyncCallback callback, object state)
	{
		throw ExceptionHelper.PlatformNotSupported("ConnectionOrientedTransportChannelFactory async open path");
	}

	protected override void OnEndOpen(IAsyncResult result)
	{
		throw ExceptionHelper.PlatformNotSupported("ConnectionOrientedTransportChannelFactory async open path");
	}

	protected override void OnOpen(TimeSpan timeout)
	{
		Upgrade?.Open(timeout);
	}

	protected internal override async Task OnOpenAsync(TimeSpan timeout)
	{
		StreamUpgradeProvider upgrade = Upgrade;
		if (upgrade != null)
		{
			await ((IAsyncCommunicationObject)upgrade).OpenAsync(timeout);
		}
	}

	protected internal override async Task OnCloseAsync(TimeSpan timeout)
	{
		if (GetUpgradeAndConnectionPool(out var upgradeCopy, out var poolCopy))
		{
			TimeoutHelper timeoutHelper = new TimeoutHelper(timeout);
			if (poolCopy != null)
			{
				ReleaseConnectionPool(poolCopy, timeoutHelper.RemainingTime());
			}
			if (upgradeCopy != null)
			{
				await ((IAsyncCommunicationObject)upgradeCopy).CloseAsync(timeoutHelper.RemainingTime());
			}
		}
	}

	protected virtual bool SupportsUpgrade(StreamUpgradeBindingElement upgradeBindingElement)
	{
		return true;
	}
}
