using System.Runtime;
using System.ServiceModel.Diagnostics;
using System.ServiceModel.Security;
using System.Threading.Tasks;

namespace System.ServiceModel.Channels;

internal abstract class ClientReliableChannelBinder<TChannel> : ReliableChannelBinder<TChannel>, IClientReliableChannelBinder, IReliableChannelBinder where TChannel : class, IChannel
{
	private abstract class DuplexClientReliableChannelBinder<TDuplexChannel> : ClientReliableChannelBinder<TDuplexChannel> where TDuplexChannel : class, IDuplexChannel
	{
		public override EndpointAddress LocalAddress => base.Synchronizer.CurrentChannel?.LocalAddress;

		public override EndpointAddress RemoteAddress => base.Synchronizer.CurrentChannel?.RemoteAddress;

		public DuplexClientReliableChannelBinder(EndpointAddress to, Uri via, IChannelFactory<TDuplexChannel> factory, MaskingMode maskingMode, TolerateFaultsMode faultMode, ChannelParameterCollection channelParameters, TimeSpan defaultCloseTimeout, TimeSpan defaultSendTimeout)
			: base(to, via, factory, maskingMode, faultMode, channelParameters, defaultCloseTimeout, defaultSendTimeout)
		{
		}

		protected virtual void OnReadNullMessage()
		{
		}

		protected override Task OnSendAsync(TDuplexChannel channel, Message message, TimeSpan timeout)
		{
			if (channel is IAsyncDuplexSessionChannel)
			{
				return ((IAsyncDuplexSessionChannel)channel).SendAsync(message, timeout);
			}
			return Task.Factory.FromAsync(channel.BeginSend, channel.EndSend, message, timeout, null);
		}

		protected override async Task<(bool, RequestContext)> OnTryReceiveAsync(TDuplexChannel channel, TimeSpan timeout)
		{
			bool flag;
			Message message;
			if (!(channel is IAsyncDuplexSessionChannel))
			{
				(flag, message) = await TaskHelpers.FromAsync<TimeSpan, bool, Message>(channel.BeginTryReceive, channel.EndTryReceive, timeout, null);
			}
			else
			{
				(flag, message) = await ((IAsyncDuplexSessionChannel)channel).TryReceiveAsync(timeout);
			}
			if (flag && message == null)
			{
				OnReadNullMessage();
			}
			RequestContext item = WrapMessage(message);
			return (flag, item);
		}
	}

	private sealed class DuplexClientReliableChannelBinder : DuplexClientReliableChannelBinder<IDuplexChannel>
	{
		public override bool HasSession => false;

		public DuplexClientReliableChannelBinder(EndpointAddress to, Uri via, IChannelFactory<IDuplexChannel> factory, MaskingMode maskingMode, ChannelParameterCollection channelParameters, TimeSpan defaultCloseTimeout, TimeSpan defaultSendTimeout)
			: base(to, via, factory, maskingMode, TolerateFaultsMode.Never, channelParameters, defaultCloseTimeout, defaultSendTimeout)
		{
		}

		public override ISession GetInnerSession()
		{
			return null;
		}

		protected override bool HasSecuritySession(IDuplexChannel channel)
		{
			return false;
		}
	}

	private sealed class DuplexSessionClientReliableChannelBinder : DuplexClientReliableChannelBinder<IDuplexSessionChannel>
	{
		public override bool HasSession => true;

		public DuplexSessionClientReliableChannelBinder(EndpointAddress to, Uri via, IChannelFactory<IDuplexSessionChannel> factory, MaskingMode maskingMode, TolerateFaultsMode faultMode, ChannelParameterCollection channelParameters, TimeSpan defaultCloseTimeout, TimeSpan defaultSendTimeout)
			: base(to, via, factory, maskingMode, faultMode, channelParameters, defaultCloseTimeout, defaultSendTimeout)
		{
		}

		public override ISession GetInnerSession()
		{
			return ((ISessionChannel<IAsyncDuplexSession>)base.Synchronizer.CurrentChannel).Session;
		}

		protected override Task CloseChannelAsync(IDuplexSessionChannel channel, TimeSpan timeout)
		{
			return ReliableChannelBinderHelper.CloseDuplexSessionChannelAsync(this, channel, timeout);
		}

		protected override bool HasSecuritySession(IDuplexSessionChannel channel)
		{
			return ((ISessionChannel<IAsyncDuplexSession>)channel).Session is ISecuritySession;
		}

		protected override void OnReadNullMessage()
		{
			base.Synchronizer.OnReadEof();
		}
	}

	private abstract class RequestClientReliableChannelBinder<TRequestChannel> : ClientReliableChannelBinder<TRequestChannel> where TRequestChannel : class, IRequestChannel
	{
		private InputQueue<Message> _inputMessages;

		public override EndpointAddress LocalAddress => EndpointAddress.AnonymousAddress;

		public override EndpointAddress RemoteAddress => base.Synchronizer.CurrentChannel?.RemoteAddress;

		public RequestClientReliableChannelBinder(EndpointAddress to, Uri via, IChannelFactory<TRequestChannel> factory, MaskingMode maskingMode, TolerateFaultsMode faultMode, ChannelParameterCollection channelParameters, TimeSpan defaultCloseTimeout, TimeSpan defaultSendTimeout)
			: base(to, via, factory, maskingMode, faultMode, channelParameters, defaultCloseTimeout, defaultSendTimeout)
		{
		}

		protected void EnqueueMessageIfNotNull(Message message)
		{
			if (message != null)
			{
				GetInputMessages().EnqueueAndDispatch(message);
			}
		}

		private InputQueue<Message> GetInputMessages()
		{
			lock (base.ThisLock)
			{
				if (base.State == CommunicationState.Created)
				{
					throw Fx.AssertAndThrow("The method GetInputMessages() cannot be called when the binder is in the Created state.");
				}
				if (base.State == CommunicationState.Opening)
				{
					throw Fx.AssertAndThrow("The method GetInputMessages() cannot be called when the binder is in the Opening state.");
				}
				if (_inputMessages == null)
				{
					_inputMessages = TraceUtility.CreateInputQueue<Message>();
				}
			}
			return _inputMessages;
		}

		protected override Task<Message> OnRequestAsync(TRequestChannel channel, Message message, TimeSpan timeout, MaskingMode maskingMode)
		{
			if (channel is IAsyncRequestChannel)
			{
				return ((IAsyncRequestChannel)channel).RequestAsync(message, timeout);
			}
			return Task.Factory.FromAsync((Func<Message, TimeSpan, AsyncCallback, object?, IAsyncResult>)channel.BeginRequest, (Func<IAsyncResult, Message>)channel.EndRequest, message, timeout, (object?)null);
		}

		protected override async Task OnSendAsync(TRequestChannel channel, Message message, TimeSpan timeout)
		{
			message = await OnRequestAsync(channel, message, timeout, base.DefaultMaskingMode);
			EnqueueMessageIfNotNull(message);
		}

		protected override void OnShutdown()
		{
			if (_inputMessages != null)
			{
				_inputMessages.Close();
			}
		}

		public override async Task<(bool, RequestContext)> TryReceiveAsync(TimeSpan timeout)
		{
			(bool, Message) tuple = await GetInputMessages().TryDequeueAsync(timeout);
			bool item = tuple.Item1;
			Message item2 = tuple.Item2;
			RequestContext item3 = WrapMessage(item2);
			return (item, item3);
		}
	}

	private sealed class RequestClientReliableChannelBinder : RequestClientReliableChannelBinder<IRequestChannel>
	{
		public override bool HasSession => false;

		public RequestClientReliableChannelBinder(EndpointAddress to, Uri via, IChannelFactory<IRequestChannel> factory, MaskingMode maskingMode, ChannelParameterCollection channelParameters, TimeSpan defaultCloseTimeout, TimeSpan defaultSendTimeout)
			: base(to, via, factory, maskingMode, TolerateFaultsMode.Never, channelParameters, defaultCloseTimeout, defaultSendTimeout)
		{
		}

		public override ISession GetInnerSession()
		{
			return null;
		}

		protected override bool HasSecuritySession(IRequestChannel channel)
		{
			return false;
		}
	}

	private sealed class RequestSessionClientReliableChannelBinder : RequestClientReliableChannelBinder<IRequestSessionChannel>
	{
		public override bool HasSession => true;

		public RequestSessionClientReliableChannelBinder(EndpointAddress to, Uri via, IChannelFactory<IRequestSessionChannel> factory, MaskingMode maskingMode, TolerateFaultsMode faultMode, ChannelParameterCollection channelParameters, TimeSpan defaultCloseTimeout, TimeSpan defaultSendTimeout)
			: base(to, via, factory, maskingMode, faultMode, channelParameters, defaultCloseTimeout, defaultSendTimeout)
		{
		}

		public override ISession GetInnerSession()
		{
			return base.Synchronizer.CurrentChannel.Session;
		}

		protected override bool HasSecuritySession(IRequestSessionChannel channel)
		{
			return channel.Session is ISecuritySession;
		}
	}

	private ChannelParameterCollection _channelParameters;

	private IChannelFactory<TChannel> _factory;

	private EndpointAddress _to;

	protected override bool CanGetChannelForReceive => false;

	public override bool CanSendAsynchronously => true;

	public override ChannelParameterCollection ChannelParameters => _channelParameters;

	protected override bool MustCloseChannel => true;

	protected override bool MustOpenChannel => true;

	public Uri Via { get; }

	protected ClientReliableChannelBinder(EndpointAddress to, Uri via, IChannelFactory<TChannel> factory, MaskingMode maskingMode, TolerateFaultsMode faultMode, ChannelParameterCollection channelParameters, TimeSpan defaultCloseTimeout, TimeSpan defaultSendTimeout)
		: base(factory.CreateChannel(to, via), maskingMode, faultMode, defaultCloseTimeout, defaultSendTimeout)
	{
		_to = to;
		Via = via;
		_factory = factory;
		_channelParameters = channelParameters ?? throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("channelParameters");
	}

	public static IClientReliableChannelBinder CreateBinder(EndpointAddress to, Uri via, IChannelFactory<TChannel> factory, MaskingMode maskingMode, TolerateFaultsMode faultMode, ChannelParameterCollection channelParameters, TimeSpan defaultCloseTimeout, TimeSpan defaultSendTimeout)
	{
		Type typeFromHandle = typeof(TChannel);
		if (typeFromHandle == typeof(IDuplexChannel))
		{
			return new DuplexClientReliableChannelBinder(to, via, (IChannelFactory<IDuplexChannel>)factory, maskingMode, channelParameters, defaultCloseTimeout, defaultSendTimeout);
		}
		if (typeFromHandle == typeof(IDuplexSessionChannel))
		{
			return new DuplexSessionClientReliableChannelBinder(to, via, (IChannelFactory<IDuplexSessionChannel>)factory, maskingMode, faultMode, channelParameters, defaultCloseTimeout, defaultSendTimeout);
		}
		if (typeFromHandle == typeof(IRequestChannel))
		{
			return new RequestClientReliableChannelBinder(to, via, (IChannelFactory<IRequestChannel>)factory, maskingMode, channelParameters, defaultCloseTimeout, defaultSendTimeout);
		}
		if (typeFromHandle == typeof(IRequestSessionChannel))
		{
			return new RequestSessionClientReliableChannelBinder(to, via, (IChannelFactory<IRequestSessionChannel>)factory, maskingMode, faultMode, channelParameters, defaultCloseTimeout, defaultSendTimeout);
		}
		throw Fx.AssertAndThrow("ClientReliableChannelBinder supports creation of IDuplexChannel, IDuplexSessionChannel, IRequestChannel, and IRequestSessionChannel only.");
	}

	public Task<bool> EnsureChannelForRequestAsync()
	{
		return base.Synchronizer.EnsureChannelAsync();
	}

	protected override void OnAbort()
	{
	}

	protected override Task OnCloseAsync(TimeSpan timeout)
	{
		return Task.CompletedTask;
	}

	protected override Task OnOpenAsync(TimeSpan timeout)
	{
		return Task.CompletedTask;
	}

	protected virtual Task<Message> OnRequestAsync(TChannel channel, Message message, TimeSpan timeout, MaskingMode maskingMode)
	{
		throw Fx.AssertAndThrow("The derived class does not support the OnRequest operation.");
	}

	public Task<Message> RequestAsync(Message message, TimeSpan timeout)
	{
		return RequestAsync(message, timeout, base.DefaultMaskingMode);
	}

	public async Task<Message> RequestAsync(Message message, TimeSpan timeout, MaskingMode maskingMode)
	{
		if (!ValidateOutputOperation(message, timeout, maskingMode))
		{
			return null;
		}
		bool autoAborted = false;
		try
		{
			TimeoutHelper timeoutHelper = new TimeoutHelper(timeout);
			var (flag, val) = await base.Synchronizer.TryGetChannelForOutputAsync(timeoutHelper.RemainingTime(), maskingMode);
			if (!flag)
			{
				if (!ReliableChannelBinderHelper.MaskHandled(maskingMode))
				{
					throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new TimeoutException(System.SR.Format(System.SR.TimeoutOnRequest, timeout)));
				}
				return null;
			}
			if (val == null)
			{
				return null;
			}
			try
			{
				return await OnRequestAsync(val, message, timeoutHelper.RemainingTime(), maskingMode);
			}
			finally
			{
				autoAborted = base.Synchronizer.Aborting;
				base.Synchronizer.ReturnChannel();
			}
		}
		catch (Exception ex)
		{
			if (Fx.IsFatal(ex))
			{
				throw;
			}
			if (!HandleException(ex, maskingMode, autoAborted))
			{
				throw;
			}
			return null;
		}
	}

	protected override Task<bool> TryGetChannelAsync(TimeSpan timeout)
	{
		CommunicationState state = base.State;
		TChannel val = null;
		if (state == CommunicationState.Created || state == CommunicationState.Opening || state == CommunicationState.Opened)
		{
			val = _factory.CreateChannel(_to, Via);
			if (!base.Synchronizer.SetChannel(val))
			{
				val.Abort();
			}
		}
		else
		{
			val = null;
		}
		return Task.FromResult(result: true);
	}
}
