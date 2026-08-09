using System.Collections.Generic;
using System.Runtime;
using System.ServiceModel.Channels;
using System.ServiceModel.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace System.ServiceModel.Dispatcher;

public sealed class DispatchRuntime
{
	internal class UnhandledActionInvoker : IOperationInvoker
	{
		private readonly DispatchRuntime _dispatchRuntime;

		public UnhandledActionInvoker(DispatchRuntime dispatchRuntime)
		{
			_dispatchRuntime = dispatchRuntime;
		}

		public object[] AllocateInputs()
		{
			return new object[1];
		}

		public Task<object> InvokeAsync(object instance, object[] inputs, out object[] outputs)
		{
			outputs = EmptyArray<object>.Allocate(0);
			if (!(inputs[0] is Message message))
			{
				return null;
			}
			string action = message.Headers.Action;
			FaultCode code = FaultCode.CreateSenderFaultCode("ActionNotSupported", message.Version.Addressing.Namespace);
			string text = System.SR.Format(System.SR.SFxNoEndpointMatchingContract, action);
			FaultReason reason = new FaultReason(text);
			FaultException exception = new FaultException(reason, code);
			ErrorBehavior.ThrowAndCatch(exception);
			ServiceChannel serviceChannel = OperationContext.Current.InternalServiceChannel;
			OperationContext.Current.OperationCompleted += delegate
			{
				ChannelDispatcher channelDispatcher = _dispatchRuntime.ChannelDispatcher;
				if (!channelDispatcher.HandleError(exception) && serviceChannel.HasSession)
				{
					try
					{
						serviceChannel.Close(ChannelHandler.CloseAfterFaultTimeout);
					}
					catch (Exception ex)
					{
						if (Fx.IsFatal(ex))
						{
							throw;
						}
						channelDispatcher.HandleError(ex);
					}
				}
			};
			if (_dispatchRuntime._shared.EnableFaults)
			{
				MessageFault fault = MessageFault.CreateFault(code, reason, action);
				return Task.FromResult((object)Message.CreateMessage(message.Version, fault, message.Version.Addressing.DefaultFaultAction));
			}
			OperationContext.Current.RequestContext.Close();
			OperationContext.Current.RequestContext = null;
			return Task.FromResult<object>(null);
		}

		public IAsyncResult InvokeBegin(object instance, object[] inputs, AsyncCallback callback, object state)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new NotImplementedException());
		}

		public object InvokeEnd(object instance, out object[] outputs, IAsyncResult result)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new NotImplementedException());
		}
	}

	internal class DispatchBehaviorCollection<T> : SynchronizedCollection<T>
	{
		private DispatchRuntime _outer;

		internal DispatchBehaviorCollection(DispatchRuntime outer)
			: base(outer.ThisLock)
		{
			_outer = outer;
		}

		protected override void ClearItems()
		{
			_outer.InvalidateRuntime();
			base.ClearItems();
		}

		protected override void InsertItem(int index, T item)
		{
			if (item == null)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("item");
			}
			_outer.InvalidateRuntime();
			base.InsertItem(index, item);
		}

		protected override void RemoveItem(int index)
		{
			_outer.InvalidateRuntime();
			base.RemoveItem(index);
		}

		protected override void SetItem(int index, T item)
		{
			if (item == null)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("item");
			}
			_outer.InvalidateRuntime();
			base.SetItem(index, item);
		}
	}

	internal class OperationCollection : SynchronizedKeyedCollection<string, DispatchOperation>
	{
		private DispatchRuntime _outer;

		internal OperationCollection(DispatchRuntime outer)
			: base(outer.ThisLock)
		{
			_outer = outer;
		}

		protected override void ClearItems()
		{
			_outer.InvalidateRuntime();
			base.ClearItems();
		}

		protected override string GetKeyForItem(DispatchOperation item)
		{
			return item.Name;
		}

		protected override void InsertItem(int index, DispatchOperation item)
		{
			if (item == null)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("item");
			}
			if (item.Parent != _outer)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgument(System.SR.SFxMismatchedOperationParent);
			}
			_outer.InvalidateRuntime();
			base.InsertItem(index, item);
		}

		protected override void RemoveItem(int index)
		{
			_outer.InvalidateRuntime();
			base.RemoveItem(index);
		}

		protected override void SetItem(int index, DispatchOperation item)
		{
			if (item == null)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("item");
			}
			if (item.Parent != _outer)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgument(System.SR.SFxMismatchedOperationParent);
			}
			_outer.InvalidateRuntime();
			base.SetItem(index, item);
		}
	}

	private class CallbackInstanceProvider : IInstanceProvider
	{
		object IInstanceProvider.GetInstance(InstanceContext instanceContext)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.SFxCannotActivateCallbackInstace));
		}

		object IInstanceProvider.GetInstance(InstanceContext instanceContext, Message message)
		{
			throw TraceUtility.ThrowHelperError(new InvalidOperationException(System.SR.SFxCannotActivateCallbackInstace), message);
		}

		void IInstanceProvider.ReleaseInstance(InstanceContext instanceContext, object instance)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.SFxCannotActivateCallbackInstace));
		}
	}

	private ConcurrencyMode _concurrencyMode;

	private bool _ensureOrderedDispatch;

	private bool _automaticInputSessionShutdown;

	private ChannelDispatcher _channelDispatcher;

	private IInstanceProvider _instanceProvider;

	private IInstanceContextProvider _instanceContextProvider;

	private SynchronizedCollection<IDispatchMessageInspector> _messageInspectors;

	private OperationCollection _operations;

	private ImmutableDispatchRuntime _runtime;

	private SynchronizationContext _synchronizationContext;

	private Type _type;

	private DispatchOperation _unhandled;

	private SharedRuntimeState _shared;

	public IInstanceContextProvider InstanceContextProvider
	{
		get
		{
			return _instanceContextProvider;
		}
		set
		{
			if (value == null)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentNullException("value"));
			}
			lock (ThisLock)
			{
				InvalidateRuntime();
				_instanceContextProvider = value;
			}
		}
	}

	public ConcurrencyMode ConcurrencyMode
	{
		get
		{
			return _concurrencyMode;
		}
		set
		{
			lock (ThisLock)
			{
				InvalidateRuntime();
				_concurrencyMode = value;
			}
		}
	}

	public bool EnsureOrderedDispatch
	{
		get
		{
			return _ensureOrderedDispatch;
		}
		set
		{
			lock (ThisLock)
			{
				InvalidateRuntime();
				_ensureOrderedDispatch = value;
			}
		}
	}

	public bool AutomaticInputSessionShutdown
	{
		get
		{
			return _automaticInputSessionShutdown;
		}
		set
		{
			lock (ThisLock)
			{
				InvalidateRuntime();
				_automaticInputSessionShutdown = value;
			}
		}
	}

	public ChannelDispatcher ChannelDispatcher => _channelDispatcher ?? EndpointDispatcher.ChannelDispatcher;

	public ClientRuntime CallbackClientRuntime
	{
		get
		{
			if (ClientRuntime == null)
			{
				lock (ThisLock)
				{
					if (ClientRuntime == null)
					{
						ClientRuntime = new ClientRuntime(this, _shared);
					}
				}
			}
			return ClientRuntime;
		}
	}

	public EndpointDispatcher EndpointDispatcher { get; }

	public IInstanceProvider InstanceProvider
	{
		get
		{
			return _instanceProvider;
		}
		set
		{
			lock (ThisLock)
			{
				InvalidateRuntime();
				_instanceProvider = value;
			}
		}
	}

	public SynchronizedCollection<IDispatchMessageInspector> MessageInspectors => _messageInspectors;

	public SynchronizedKeyedCollection<string, DispatchOperation> Operations => _operations;

	public SynchronizationContext SynchronizationContext
	{
		get
		{
			return _synchronizationContext;
		}
		set
		{
			lock (ThisLock)
			{
				InvalidateRuntime();
				_synchronizationContext = value;
			}
		}
	}

	public Type Type
	{
		get
		{
			return _type;
		}
		set
		{
			lock (ThisLock)
			{
				InvalidateRuntime();
				_type = value;
			}
		}
	}

	public DispatchOperation UnhandledDispatchOperation
	{
		get
		{
			return _unhandled;
		}
		set
		{
			if (value == null)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("value");
			}
			lock (ThisLock)
			{
				InvalidateRuntime();
				_unhandled = value;
			}
		}
	}

	internal bool HasMatchAllOperation => false;

	internal bool EnableFaults
	{
		get
		{
			if (IsOnServer)
			{
				return ChannelDispatcher?.EnableFaults ?? false;
			}
			return _shared.EnableFaults;
		}
	}

	internal bool IsOnServer => _shared.IsOnServer;

	internal bool ManualAddressing
	{
		get
		{
			if (IsOnServer)
			{
				return ChannelDispatcher?.ManualAddressing ?? false;
			}
			return _shared.ManualAddressing;
		}
	}

	internal int MaxParameterInspectors
	{
		get
		{
			lock (ThisLock)
			{
				int val = 0;
				for (int i = 0; i < _operations.Count; i++)
				{
					val = Math.Max(val, _operations[i].ParameterInspectors.Count);
				}
				return Math.Max(val, _unhandled.ParameterInspectors.Count);
			}
		}
	}

	internal ClientRuntime ClientRuntime { get; private set; }

	internal object ThisLock => _shared;

	internal DispatchRuntime(ClientRuntime proxyRuntime, SharedRuntimeState shared)
		: this(shared)
	{
		ClientRuntime = proxyRuntime ?? throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("proxyRuntime");
		_instanceProvider = new CallbackInstanceProvider();
		_channelDispatcher = new ChannelDispatcher(shared);
		_instanceContextProvider = InstanceContextProviderBase.GetProviderForMode(InstanceContextMode.PerSession, this);
	}

	private DispatchRuntime(SharedRuntimeState shared)
	{
		_shared = shared;
		_operations = new OperationCollection(this);
		_messageInspectors = NewBehaviorCollection<IDispatchMessageInspector>();
		_synchronizationContext = ThreadBehavior.GetCurrentSynchronizationContext();
		_automaticInputSessionShutdown = true;
		_unhandled = new DispatchOperation(this, "*", "*", "*");
		_unhandled.InternalFormatter = MessageOperationFormatter.Instance;
		_unhandled.InternalInvoker = new UnhandledActionInvoker(this);
	}

	internal DispatchOperationRuntime GetOperation(ref Message message)
	{
		ImmutableDispatchRuntime runtime = GetRuntime();
		return runtime.GetOperation(ref message);
	}

	internal ImmutableDispatchRuntime GetRuntime()
	{
		ImmutableDispatchRuntime runtime = _runtime;
		if (runtime != null)
		{
			return runtime;
		}
		return GetRuntimeCore();
	}

	private ImmutableDispatchRuntime GetRuntimeCore()
	{
		lock (ThisLock)
		{
			if (_runtime == null)
			{
				_runtime = new ImmutableDispatchRuntime(this);
			}
			return _runtime;
		}
	}

	internal void InvalidateRuntime()
	{
		lock (ThisLock)
		{
			_shared.ThrowIfImmutable();
			_runtime = null;
		}
	}

	internal void LockDownProperties()
	{
		_shared.LockDownProperties();
	}

	internal SynchronizedCollection<T> NewBehaviorCollection<T>()
	{
		return new DispatchBehaviorCollection<T>(this);
	}
}
