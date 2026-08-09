using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Runtime;
using System.Runtime.Diagnostics;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;

namespace System.ServiceModel.Dispatcher;

public class ChannelDispatcher : ChannelDispatcherBase
{
	internal class EndpointDispatcherCollection : SynchronizedCollection<EndpointDispatcher>
	{
		private ChannelDispatcher _owner;

		internal EndpointDispatcherCollection(ChannelDispatcher owner)
			: base(owner.ThisLock)
		{
			_owner = owner;
		}

		protected override void ClearItems()
		{
			foreach (EndpointDispatcher item in base.Items)
			{
				_owner.OnRemoveEndpoint(item);
			}
			base.ClearItems();
		}

		protected override void InsertItem(int index, EndpointDispatcher item)
		{
			if (item == null)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("item");
			}
			_owner.OnAddEndpoint(item);
			base.InsertItem(index, item);
		}

		protected override void RemoveItem(int index)
		{
			EndpointDispatcher endpoint = base.Items[index];
			base.RemoveItem(index);
			_owner.OnRemoveEndpoint(endpoint);
		}

		protected override void SetItem(int index, EndpointDispatcher item)
		{
			Exception exception = new InvalidOperationException(System.SR.SFxCollectionDoesNotSupportSet0);
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(exception);
		}
	}

	internal class ChannelDispatcherBehaviorCollection<T> : SynchronizedCollection<T>
	{
		private ChannelDispatcher _outer;

		internal ChannelDispatcherBehaviorCollection(ChannelDispatcher outer)
			: base(outer.ThisLock)
		{
			_outer = outer;
		}

		protected override void ClearItems()
		{
			_outer.ThrowIfDisposedOrImmutable();
			base.ClearItems();
		}

		protected override void InsertItem(int index, T item)
		{
			if (item == null)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("item");
			}
			_outer.ThrowIfDisposedOrImmutable();
			base.InsertItem(index, item);
		}

		protected override void RemoveItem(int index)
		{
			_outer.ThrowIfDisposedOrImmutable();
			base.RemoveItem(index);
		}

		protected override void SetItem(int index, T item)
		{
			if (item == null)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("item");
			}
			_outer.ThrowIfDisposedOrImmutable();
			base.SetItem(index, item);
		}
	}

	private SynchronizedCollection<IChannelInitializer> _channelInitializers;

	private EndpointDispatcherCollection _endpointDispatchers;

	private bool _receiveContextEnabled;

	private readonly IChannelListener _listener;

	private ListenerHandler _listenerHandler;

	private int _maxTransactedBatchSize;

	private MessageVersion _messageVersion;

	private bool _receiveSynchronously;

	private bool _sendAsynchronously;

	private int _maxPendingReceives;

	private bool _includeExceptionDetailInFaults;

	private bool _session;

	private SharedRuntimeState _shared;

	private TimeSpan _transactionTimeout;

	private bool _performDefaultCloseInput;

	private EventTraceActivity _eventTraceActivity;

	private ErrorBehavior _errorBehavior;

	protected override TimeSpan DefaultCloseTimeout
	{
		get
		{
			if (DefaultCommunicationTimeouts != null)
			{
				return DefaultCommunicationTimeouts.CloseTimeout;
			}
			return ServiceDefaults.CloseTimeout;
		}
	}

	protected override TimeSpan DefaultOpenTimeout
	{
		get
		{
			if (DefaultCommunicationTimeouts != null)
			{
				return DefaultCommunicationTimeouts.OpenTimeout;
			}
			return ServiceDefaults.OpenTimeout;
		}
	}

	internal EndpointDispatcherTable EndpointDispatcherTable { get; private set; }

	internal CommunicationObjectManager<IChannel> Channels { get; private set; }

	public SynchronizedCollection<EndpointDispatcher> Endpoints => _endpointDispatchers;

	public Collection<IErrorHandler> ErrorHandlers { get; private set; }

	public MessageVersion MessageVersion
	{
		get
		{
			return _messageVersion;
		}
		set
		{
			_messageVersion = value;
			ThrowIfDisposedOrImmutable();
		}
	}

	internal bool EnableFaults
	{
		get
		{
			return _shared.EnableFaults;
		}
		set
		{
			ThrowIfDisposedOrImmutable();
			_shared.EnableFaults = value;
		}
	}

	internal bool IsOnServer => _shared.IsOnServer;

	public bool ReceiveContextEnabled
	{
		get
		{
			return _receiveContextEnabled;
		}
		set
		{
			ThrowIfDisposedOrImmutable();
			_receiveContextEnabled = value;
		}
	}

	internal bool BufferedReceiveEnabled { get; set; }

	public override IChannelListener Listener => _listener;

	public int MaxTransactedBatchSize
	{
		get
		{
			return _maxTransactedBatchSize;
		}
		set
		{
			if (value < 0)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentOutOfRangeException("value", value, System.SR.ValueMustBeNonNegative));
			}
			ThrowIfDisposedOrImmutable();
			_maxTransactedBatchSize = value;
		}
	}

	public bool ManualAddressing
	{
		get
		{
			return _shared.ManualAddressing;
		}
		set
		{
			ThrowIfDisposedOrImmutable();
			_shared.ManualAddressing = value;
		}
	}

	internal SynchronizedChannelCollection<IChannel> PendingChannels { get; private set; }

	public bool ReceiveSynchronously
	{
		get
		{
			return _receiveSynchronously;
		}
		set
		{
			ThrowIfDisposedOrImmutable();
			_receiveSynchronously = value;
		}
	}

	public bool SendAsynchronously
	{
		get
		{
			return _sendAsynchronously;
		}
		set
		{
			ThrowIfDisposedOrImmutable();
			_sendAsynchronously = value;
		}
	}

	public int MaxPendingReceives
	{
		get
		{
			return _maxPendingReceives;
		}
		set
		{
			ThrowIfDisposedOrImmutable();
			_maxPendingReceives = value;
		}
	}

	public bool IncludeExceptionDetailInFaults
	{
		get
		{
			return _includeExceptionDetailInFaults;
		}
		set
		{
			lock (base.ThisLock)
			{
				ThrowIfDisposedOrImmutable();
				_includeExceptionDetailInFaults = value;
			}
		}
	}

	internal IDefaultCommunicationTimeouts DefaultCommunicationTimeouts { get; }

	internal ChannelDispatcher(SharedRuntimeState shared)
	{
		Initialize(shared);
	}

	private void Initialize(SharedRuntimeState shared)
	{
		_shared = shared;
		_endpointDispatchers = new EndpointDispatcherCollection(this);
		_channelInitializers = NewBehaviorCollection<IChannelInitializer>();
		Channels = new CommunicationObjectManager<IChannel>(base.ThisLock);
		PendingChannels = new SynchronizedChannelCollection<IChannel>(base.ThisLock);
		ErrorHandlers = new Collection<IErrorHandler>();
		_receiveSynchronously = false;
		_transactionTimeout = TimeSpan.Zero;
		_maxPendingReceives = 1;
		if (_listener != null)
		{
			_listener.Faulted += OnListenerFaulted;
		}
	}

	private void AbortPendingChannels()
	{
		lock (base.ThisLock)
		{
			for (int num = PendingChannels.Count - 1; num >= 0; num--)
			{
				PendingChannels[num].Abort();
			}
		}
	}

	internal override void CloseInput(TimeSpan timeout)
	{
		CloseInput();
		if (_performDefaultCloseInput)
		{
			TimeoutHelper timeoutHelper = new TimeoutHelper(timeout);
			lock (base.ThisLock)
			{
				_listenerHandler?.CloseInput(timeoutHelper.RemainingTime());
			}
			if (!_session)
			{
				_listenerHandler?.Close(timeoutHelper.RemainingTime());
			}
		}
	}

	public override void CloseInput()
	{
		_performDefaultCloseInput = true;
	}

	private void OnListenerFaulted(object sender, EventArgs e)
	{
		Fault();
	}

	internal bool HandleError(Exception error)
	{
		ErrorHandlerFaultInfo faultInfo = default(ErrorHandlerFaultInfo);
		return HandleError(error, ref faultInfo);
	}

	internal bool HandleError(Exception error, ref ErrorHandlerFaultInfo faultInfo)
	{
		ErrorBehavior errorBehavior;
		lock (base.ThisLock)
		{
			errorBehavior = ((_errorBehavior == null) ? new ErrorBehavior(this) : _errorBehavior);
		}
		return errorBehavior?.HandleError(error, ref faultInfo) ?? false;
	}

	internal void InitializeChannel(IClientChannel channel)
	{
		ThrowIfDisposedOrNotOpen();
		try
		{
			for (int i = 0; i < _channelInitializers.Count; i++)
			{
				_channelInitializers[i].Initialize(channel);
			}
		}
		catch (Exception ex)
		{
			if (Fx.IsFatal(ex))
			{
				throw;
			}
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperCallback(ex);
		}
	}

	internal SynchronizedCollection<T> NewBehaviorCollection<T>()
	{
		return new ChannelDispatcherBehaviorCollection<T>(this);
	}

	private void OnAddEndpoint(EndpointDispatcher endpoint)
	{
		lock (base.ThisLock)
		{
			endpoint.Attach(this);
			if (base.State == CommunicationState.Opened)
			{
				EndpointDispatcherTable.AddEndpoint(endpoint);
			}
		}
	}

	private void OnRemoveEndpoint(EndpointDispatcher endpoint)
	{
		lock (base.ThisLock)
		{
			if (base.State == CommunicationState.Opened)
			{
				EndpointDispatcherTable.RemoveEndpoint(endpoint);
			}
			endpoint.Detach(this);
		}
	}

	protected override void OnAbort()
	{
		if (_listener != null)
		{
			_listener.Abort();
		}
		_listenerHandler?.Abort();
		AbortPendingChannels();
	}

	protected override void OnClose(TimeSpan timeout)
	{
		TimeoutHelper timeoutHelper = new TimeoutHelper(timeout);
		if (_listener != null)
		{
			_listener.Close(timeoutHelper.RemainingTime());
		}
		_listenerHandler?.Close(timeoutHelper.RemainingTime());
		AbortPendingChannels();
	}

	protected override IAsyncResult OnBeginClose(TimeSpan timeout, AsyncCallback callback, object state)
	{
		List<ICommunicationObject> list = new List<ICommunicationObject>();
		if (_listener != null)
		{
			list.Add(_listener);
		}
		ListenerHandler listenerHandler = _listenerHandler;
		if (listenerHandler != null)
		{
			list.Add(listenerHandler);
		}
		return new CloseCollectionAsyncResult(timeout, callback, state, list);
	}

	protected override void OnEndClose(IAsyncResult result)
	{
		try
		{
			CloseCollectionAsyncResult.End(result);
		}
		finally
		{
			AbortPendingChannels();
		}
	}

	protected override void OnClosed()
	{
		base.OnClosed();
	}

	protected override void OnOpen(TimeSpan timeout)
	{
		ThrowIfNoMessageVersion();
		if (_listener != null)
		{
			try
			{
				_listener.Open(timeout);
			}
			catch (InvalidOperationException e)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(CreateOuterExceptionWithEndpointsInformation(e));
			}
		}
	}

	protected internal override Task OnCloseAsync(TimeSpan timeout)
	{
		OnClose(timeout);
		return TaskHelpers.CompletedTask();
	}

	protected internal override Task OnOpenAsync(TimeSpan timeout)
	{
		OnOpen(timeout);
		return TaskHelpers.CompletedTask();
	}

	private InvalidOperationException CreateOuterExceptionWithEndpointsInformation(InvalidOperationException e)
	{
		string text = CreateContractListString();
		if (string.IsNullOrEmpty(text))
		{
			return new InvalidOperationException(System.SR.Format(System.SR.SFxChannelDispatcherUnableToOpen1, _listener.Uri), e);
		}
		return new InvalidOperationException(System.SR.Format(System.SR.SFxChannelDispatcherUnableToOpen2, _listener.Uri, text), e);
	}

	internal string CreateContractListString()
	{
		Collection<string> collection = new Collection<string>();
		StringBuilder stringBuilder = new StringBuilder();
		lock (base.ThisLock)
		{
			foreach (EndpointDispatcher endpoint in Endpoints)
			{
				if (!collection.Contains(endpoint.ContractName))
				{
					if (stringBuilder.Length > 0)
					{
						stringBuilder.Append(CultureInfo.CurrentCulture.TextInfo.ListSeparator);
						stringBuilder.Append(" ");
					}
					stringBuilder.Append("\"");
					stringBuilder.Append(endpoint.ContractName);
					stringBuilder.Append("\"");
					collection.Add(endpoint.ContractName);
				}
			}
		}
		return stringBuilder.ToString();
	}

	protected override IAsyncResult OnBeginOpen(TimeSpan timeout, AsyncCallback callback, object state)
	{
		ThrowIfNoMessageVersion();
		if (_listener != null)
		{
			try
			{
				return _listener.BeginOpen(timeout, callback, state);
			}
			catch (InvalidOperationException e)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(CreateOuterExceptionWithEndpointsInformation(e));
			}
		}
		return new CompletedAsyncResult(callback, state);
	}

	protected override void OnEndOpen(IAsyncResult result)
	{
		if (_listener != null)
		{
			try
			{
				_listener.EndOpen(result);
				return;
			}
			catch (InvalidOperationException e)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(CreateOuterExceptionWithEndpointsInformation(e));
			}
		}
		CompletedAsyncResult.End(result);
	}

	protected override void OnOpening()
	{
		if (WcfEventSource.Instance.ListenerOpenStartIsEnabled())
		{
			_eventTraceActivity = EventTraceActivity.GetFromThreadOrCreate();
			WcfEventSource.Instance.ListenerOpenStart(_eventTraceActivity, (Listener != null) ? Listener.Uri.ToString() : string.Empty, Guid.Empty);
		}
		base.OnOpening();
	}

	protected override void OnOpened()
	{
		base.OnOpened();
		if (WcfEventSource.Instance.ListenerOpenStopIsEnabled())
		{
			WcfEventSource.Instance.ListenerOpenStop(_eventTraceActivity);
			_eventTraceActivity = null;
		}
		_errorBehavior = new ErrorBehavior(this);
		EndpointDispatcherTable = new EndpointDispatcherTable(base.ThisLock);
		for (int i = 0; i < _endpointDispatchers.Count; i++)
		{
			EndpointDispatcher endpointDispatcher = _endpointDispatchers[i];
			endpointDispatcher.DispatchRuntime.LockDownProperties();
			EndpointDispatcherTable.AddEndpoint(endpointDispatcher);
		}
		IListenerBinder binder = ListenerBinder.GetBinder(_listener, _messageVersion);
		_listenerHandler = new ListenerHandler(binder, this, DefaultCommunicationTimeouts);
		_listenerHandler.Open();
	}

	internal void ProvideFault(Exception e, FaultConverter faultConverter, ref ErrorHandlerFaultInfo faultInfo)
	{
		ErrorBehavior errorBehavior;
		lock (base.ThisLock)
		{
			errorBehavior = ((_errorBehavior == null) ? new ErrorBehavior(this) : _errorBehavior);
		}
		errorBehavior.ProvideFault(e, faultConverter, ref faultInfo);
	}

	internal new void ThrowIfDisposedOrImmutable()
	{
		base.ThrowIfDisposedOrImmutable();
		_shared.ThrowIfImmutable();
	}

	private void ThrowIfNoMessageVersion()
	{
		if (_messageVersion == null)
		{
			Exception exception = new InvalidOperationException(System.SR.SFxChannelDispatcherNoMessageVersion);
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(exception);
		}
	}
}
