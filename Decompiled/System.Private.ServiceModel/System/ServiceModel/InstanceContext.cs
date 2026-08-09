using System.Collections.Generic;
using System.Runtime;
using System.ServiceModel.Channels;
using System.ServiceModel.Diagnostics;
using System.ServiceModel.Dispatcher;
using System.Threading;
using System.Threading.Tasks;

namespace System.ServiceModel;

public sealed class InstanceContext : CommunicationObject, IExtensibleObject<InstanceContext>
{
	private InstanceBehavior _behavior;

	private ConcurrencyInstanceContextFacet _concurrency;

	private ServiceChannelManager _channels;

	private ExtensionCollection<InstanceContext> _extensions;

	private object _serviceInstanceLock = new object();

	private SynchronizationContext _synchronizationContext;

	private object _userObject;

	private bool _wellKnown;

	private SynchronizedCollection<IChannel> _wmiChannels;

	private bool _isUserCreated;

	internal InstanceBehavior Behavior
	{
		get
		{
			return _behavior;
		}
		set
		{
			if (_behavior == null)
			{
				_behavior = value;
			}
		}
	}

	internal ConcurrencyInstanceContextFacet Concurrency
	{
		get
		{
			if (_concurrency == null)
			{
				lock (ThisLock)
				{
					if (_concurrency == null)
					{
						_concurrency = new ConcurrencyInstanceContextFacet();
					}
				}
			}
			return _concurrency;
		}
	}

	protected override TimeSpan DefaultCloseTimeout => ServiceDefaults.CloseTimeout;

	protected override TimeSpan DefaultOpenTimeout => ServiceDefaults.OpenTimeout;

	public IExtensionCollection<InstanceContext> Extensions
	{
		get
		{
			ThrowIfClosed();
			lock (ThisLock)
			{
				if (_extensions == null)
				{
					_extensions = new ExtensionCollection<InstanceContext>(this, ThisLock);
				}
				return _extensions;
			}
		}
	}

	public ICollection<IChannel> IncomingChannels
	{
		get
		{
			ThrowIfClosed();
			return _channels.IncomingChannels;
		}
	}

	public ICollection<IChannel> OutgoingChannels
	{
		get
		{
			ThrowIfClosed();
			return _channels.OutgoingChannels;
		}
	}

	public SynchronizationContext SynchronizationContext
	{
		get
		{
			return _synchronizationContext;
		}
		set
		{
			ThrowIfClosedOrOpened();
			_synchronizationContext = value;
		}
	}

	internal new object ThisLock => base.ThisLock;

	internal object UserObject => _userObject;

	internal ICollection<IChannel> WmiChannels
	{
		get
		{
			if (_wmiChannels == null)
			{
				lock (ThisLock)
				{
					if (_wmiChannels == null)
					{
						_wmiChannels = new SynchronizedCollection<IChannel>();
					}
				}
			}
			return _wmiChannels;
		}
	}

	public InstanceContext(object implementation)
		: this(implementation, isUserCreated: true)
	{
	}

	internal InstanceContext(object implementation, bool isUserCreated)
		: this(implementation, wellKnown: true, isUserCreated)
	{
	}

	internal InstanceContext(object implementation, bool wellKnown, bool isUserCreated)
	{
		if (implementation != null)
		{
			_userObject = implementation;
			_wellKnown = wellKnown;
		}
		_channels = new ServiceChannelManager(this);
		_isUserCreated = isUserCreated;
	}

	protected override void OnAbort()
	{
		_channels.Abort();
	}

	internal void BindRpc(ref MessageRpc rpc)
	{
		ThrowIfClosed();
		_channels.IncrementActivityCount();
		rpc.SuccessfullyBoundInstance = true;
	}

	internal void FaultInternal()
	{
		Fault();
	}

	public object GetServiceInstance(Message message)
	{
		lock (_serviceInstanceLock)
		{
			ThrowIfClosedOrNotOpen();
			object userObject = _userObject;
			if (userObject != null)
			{
				return userObject;
			}
			if (_behavior == null)
			{
				Exception exception = new InvalidOperationException(System.SR.SFxInstanceNotInitialized);
				if (message != null)
				{
					throw TraceUtility.ThrowHelperError(exception, message);
				}
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(exception);
			}
			object obj = ((message == null) ? _behavior.GetInstance(this) : _behavior.GetInstance(this, message));
			if (obj != null)
			{
				SetUserObject(obj);
			}
			return obj;
		}
	}

	protected override IAsyncResult OnBeginClose(TimeSpan timeout, AsyncCallback callback, object state)
	{
		return OnCloseAsync(timeout).ToApm(callback, state);
	}

	protected override void OnEndClose(IAsyncResult result)
	{
		result.ToApmEnd();
	}

	protected override IAsyncResult OnBeginOpen(TimeSpan timeout, AsyncCallback callback, object state)
	{
		return new CompletedAsyncResult(callback, state);
	}

	protected override void OnEndOpen(IAsyncResult result)
	{
		CompletedAsyncResult.End(result);
	}

	protected override void OnClose(TimeSpan timeout)
	{
		_channels.Close(timeout);
	}

	protected override void OnOpen(TimeSpan timeout)
	{
		TimeoutHelper timeoutHelper = new TimeoutHelper(timeout);
	}

	protected override void OnOpened()
	{
		base.OnOpened();
	}

	protected override void OnOpening()
	{
		base.OnOpening();
	}

	protected internal override Task OnCloseAsync(TimeSpan timeout)
	{
		return _channels.CloseAsync(timeout);
	}

	protected internal override Task OnOpenAsync(TimeSpan timeout)
	{
		TimeoutHelper timeoutHelper = new TimeoutHelper(timeout);
		return TaskHelpers.CompletedTask();
	}

	private void SetUserObject(object newUserObject)
	{
		if (_behavior != null && !_wellKnown)
		{
			object obj = Interlocked.Exchange(ref _userObject, newUserObject);
		}
	}

	internal void UnbindRpc(ref MessageRpc rpc)
	{
		if (rpc.InstanceContext == this && rpc.SuccessfullyBoundInstance)
		{
			_channels.DecrementActivityCount();
		}
	}
}
