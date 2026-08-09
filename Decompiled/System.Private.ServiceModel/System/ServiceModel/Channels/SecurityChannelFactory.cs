using System.Runtime;
using System.ServiceModel.Security;
using System.Threading.Tasks;

namespace System.ServiceModel.Channels;

internal sealed class SecurityChannelFactory<TChannel> : LayeredChannelFactory<TChannel>
{
	private abstract class ClientSecurityChannel<UChannel> : SecurityChannel<UChannel> where UChannel : class, IChannel
	{
		private ChannelParameterCollection _channelParameters;

		protected SecurityProtocolFactory SecurityProtocolFactory { get; }

		public EndpointAddress RemoteAddress { get; }

		public Uri Via { get; }

		protected ClientSecurityChannel(ChannelManagerBase factory, SecurityProtocolFactory securityProtocolFactory, UChannel innerChannel, EndpointAddress to, Uri via)
			: base(factory, innerChannel)
		{
			RemoteAddress = to;
			Via = via;
			SecurityProtocolFactory = securityProtocolFactory;
			_channelParameters = new ChannelParameterCollection(this);
		}

		protected bool TryGetSecurityFaultException(Message faultMessage, out Exception faultException)
		{
			faultException = null;
			if (!faultMessage.IsFault)
			{
				return false;
			}
			MessageFault fault = MessageFault.CreateFault(faultMessage, 16384);
			faultException = SecurityUtils.CreateSecurityFaultException(fault);
			return true;
		}

		protected internal override async Task OnOpenAsync(TimeSpan timeout)
		{
			TimeoutHelper timeoutHelper = new TimeoutHelper(timeout);
			EnableChannelBindingSupport();
			SecurityProtocol securityProtocol = SecurityProtocolFactory.CreateSecurityProtocol(RemoteAddress, Via, null, typeof(TChannel) == typeof(IRequestChannel), timeoutHelper.RemainingTime());
			OnProtocolCreationComplete(securityProtocol);
			await base.SecurityProtocol.OpenAsync(timeoutHelper.RemainingTime());
			await base.OnOpenAsync(timeoutHelper.RemainingTime());
		}

		private void EnableChannelBindingSupport()
		{
			if (SecurityProtocolFactory != null && SecurityProtocolFactory.ExtendedProtectionPolicy != null && SecurityProtocolFactory.ExtendedProtectionPolicy.CustomChannelBinding != null)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new NotSupportedException(System.SR.Format(System.SR.ExtendedProtectionPolicyCustomChannelBindingNotSupported)));
			}
			if (!SecurityUtils.IsChannelBindingDisabled && SecurityUtils.IsSecurityBindingSuitableForChannelBinding(SecurityProtocolFactory.SecurityBindingElement as TransportSecurityBindingElement) && base.InnerChannel != null)
			{
				base.InnerChannel.GetProperty<IChannelBindingProvider>()?.EnableChannelBindingSupport();
			}
		}

		private void OnProtocolCreationComplete(SecurityProtocol securityProtocol)
		{
			base.SecurityProtocol = securityProtocol;
			base.SecurityProtocol.ChannelParameters = _channelParameters;
		}

		public override T GetProperty<T>()
		{
			if (typeof(T) == typeof(ChannelParameterCollection))
			{
				return (T)(object)_channelParameters;
			}
			return base.GetProperty<T>();
		}
	}

	private class SecurityOutputChannel : ClientSecurityChannel<IOutputChannel>, IOutputChannel, IChannel, ICommunicationObject, IAsyncOutputChannel, IAsyncCommunicationObject
	{
		public SecurityOutputChannel(ChannelManagerBase factory, SecurityProtocolFactory securityProtocolFactory, IOutputChannel innerChannel, EndpointAddress to, Uri via)
			: base(factory, securityProtocolFactory, innerChannel, to, via)
		{
		}

		public IAsyncResult BeginSend(Message message, AsyncCallback callback, object state)
		{
			return BeginSend(message, base.DefaultSendTimeout, callback, state);
		}

		public IAsyncResult BeginSend(Message message, TimeSpan timeout, AsyncCallback callback, object state)
		{
			return SendAsync(message, timeout).ToApm(callback, state);
		}

		public void EndSend(IAsyncResult result)
		{
			result.ToApmEnd();
		}

		public Task SendAsync(Message message)
		{
			return SendAsync(message, base.DefaultSendTimeout);
		}

		public async Task SendAsync(Message message, TimeSpan timeout)
		{
			ThrowIfFaulted();
			ThrowIfDisposedOrNotOpen(message);
			TimeoutHelper timeoutHelper = new TimeoutHelper(timeout);
			message = await base.SecurityProtocol.SecureOutgoingMessageAsync(message, timeoutHelper.RemainingTime());
			if (!(base.InnerChannel is IAsyncOutputChannel asyncOutputChannel))
			{
				await Task.Factory.FromAsync(base.InnerChannel.BeginSend, base.InnerChannel.EndSend, message, timeoutHelper.RemainingTime(), null);
			}
			else
			{
				await asyncOutputChannel.SendAsync(message, timeoutHelper.RemainingTime());
			}
		}

		public void Send(Message message)
		{
			Send(message, base.DefaultSendTimeout);
		}

		public void Send(Message message, TimeSpan timeout)
		{
			SendAsync(message, timeout).GetAwaiter().GetResult();
		}
	}

	private sealed class SecurityOutputSessionChannel : SecurityOutputChannel, IOutputSessionChannel, IOutputChannel, IChannel, ICommunicationObject, ISessionChannel<IOutputSession>
	{
		public IOutputSession Session => ((IOutputSessionChannel)base.InnerChannel).Session;

		public SecurityOutputSessionChannel(ChannelManagerBase factory, SecurityProtocolFactory securityProtocolFactory, IOutputSessionChannel innerChannel, EndpointAddress to, Uri via)
			: base(factory, securityProtocolFactory, (IOutputChannel)innerChannel, to, via)
		{
		}
	}

	private class SecurityRequestChannel : ClientSecurityChannel<IRequestChannel>, IAsyncRequestChannel, IRequestChannel, IChannel, ICommunicationObject, IAsyncCommunicationObject
	{
		public SecurityRequestChannel(ChannelManagerBase factory, SecurityProtocolFactory securityProtocolFactory, IRequestChannel innerChannel, EndpointAddress to, Uri via)
			: base(factory, securityProtocolFactory, innerChannel, to, via)
		{
		}

		public IAsyncResult BeginRequest(Message message, AsyncCallback callback, object state)
		{
			return BeginRequest(message, base.DefaultSendTimeout, callback, state);
		}

		public IAsyncResult BeginRequest(Message message, TimeSpan timeout, AsyncCallback callback, object state)
		{
			return RequestAsyncInternal(message, timeout).ToApm(callback, state);
		}

		public Message EndRequest(IAsyncResult result)
		{
			return result.ToApmEnd<Message>();
		}

		public Message Request(Message message)
		{
			return Request(message, base.DefaultSendTimeout);
		}

		internal Message ProcessReply(Message reply, SecurityProtocolCorrelationState correlationState, TimeSpan timeout)
		{
			if (reply != null)
			{
				Message faultMessage = reply;
				Exception faultException = null;
				try
				{
					base.SecurityProtocol.VerifyIncomingMessage(ref reply, timeout, correlationState);
				}
				catch (MessageSecurityException)
				{
					TryGetSecurityFaultException(faultMessage, out faultException);
					if (faultException == null)
					{
						throw;
					}
				}
				if (faultException != null)
				{
					Fault(faultException);
					throw DiagnosticUtility.ExceptionUtility.ThrowHelperWarning(faultException);
				}
			}
			return reply;
		}

		public Task<Message> RequestAsync(Message message)
		{
			return RequestAsync(message, base.DefaultSendTimeout);
		}

		public async Task<Message> RequestAsync(Message message, TimeSpan timeout)
		{
			ThrowIfFaulted();
			ThrowIfDisposedOrNotOpen(message);
			TimeoutHelper timeoutHelper = new TimeoutHelper(timeout);
			SecurityProtocolCorrelationState correlationState;
			(correlationState, message) = await base.SecurityProtocol.SecureOutgoingMessageAsync(message, timeoutHelper.RemainingTime(), null);
			return ProcessReply(await Task.Factory.FromAsync((Func<Message, TimeSpan, AsyncCallback, object?, IAsyncResult>)base.InnerChannel.BeginRequest, (Func<IAsyncResult, Message>)base.InnerChannel.EndRequest, message, timeoutHelper.RemainingTime(), (object?)null), correlationState, timeoutHelper.RemainingTime());
		}

		private async Task<Message> RequestAsyncInternal(Message message, TimeSpan timeout)
		{
			await TaskHelpers.EnsureDefaultTaskScheduler();
			return await RequestAsync(message, timeout);
		}

		public Message Request(Message message, TimeSpan timeout)
		{
			return RequestAsyncInternal(message, timeout).GetAwaiter().GetResult();
		}
	}

	private sealed class SecurityRequestSessionChannel : SecurityRequestChannel, IAsyncRequestSessionChannel, IRequestSessionChannel, IRequestChannel, IChannel, ICommunicationObject, ISessionChannel<IOutputSession>, IAsyncRequestChannel, IAsyncCommunicationObject
	{
		public IOutputSession Session => ((IRequestSessionChannel)base.InnerChannel).Session;

		public SecurityRequestSessionChannel(ChannelManagerBase factory, SecurityProtocolFactory securityProtocolFactory, IRequestSessionChannel innerChannel, EndpointAddress to, Uri via)
			: base(factory, securityProtocolFactory, (IRequestChannel)innerChannel, to, via)
		{
		}
	}

	private class SecurityDuplexChannel : SecurityOutputChannel, IDuplexChannel, IInputChannel, IChannel, ICommunicationObject, IOutputChannel, IAsyncDuplexChannel, IAsyncInputChannel, IAsyncCommunicationObject, IAsyncOutputChannel
	{
		internal IDuplexChannel InnerDuplexChannel => (IDuplexChannel)base.InnerChannel;

		public EndpointAddress LocalAddress => InnerDuplexChannel.LocalAddress;

		internal virtual bool AcceptUnsecuredFaults => false;

		public SecurityDuplexChannel(ChannelManagerBase factory, SecurityProtocolFactory securityProtocolFactory, IDuplexChannel innerChannel, EndpointAddress to, Uri via)
			: base(factory, securityProtocolFactory, (IOutputChannel)innerChannel, to, via)
		{
		}

		public Task<Message> ReceiveAsync()
		{
			return ReceiveAsync(base.DefaultReceiveTimeout);
		}

		public Task<Message> ReceiveAsync(TimeSpan timeout)
		{
			return InputChannel.HelpReceiveAsync(this, timeout);
		}

		public Message Receive()
		{
			return Receive(base.DefaultReceiveTimeout);
		}

		public Message Receive(TimeSpan timeout)
		{
			return ReceiveAsync(timeout).GetAwaiter().GetResult();
		}

		public IAsyncResult BeginReceive(AsyncCallback callback, object state)
		{
			return BeginReceive(base.DefaultReceiveTimeout, callback, state);
		}

		public IAsyncResult BeginReceive(TimeSpan timeout, AsyncCallback callback, object state)
		{
			return ReceiveAsync(timeout).ToApm(callback, state);
		}

		public Message EndReceive(IAsyncResult result)
		{
			return result.ToApmEnd<Message>();
		}

		public virtual IAsyncResult BeginTryReceive(TimeSpan timeout, AsyncCallback callback, object state)
		{
			return TryReceiveAsync(timeout).ToApm(callback, state);
		}

		public virtual bool EndTryReceive(IAsyncResult result, out Message message)
		{
			bool result2;
			(result2, message) = result.ToApmEnd<(bool, Message)>();
			return result2;
		}

		internal Message ProcessMessage(Message message, TimeSpan timeout)
		{
			if (message == null)
			{
				return null;
			}
			Message faultMessage = message;
			Exception faultException = null;
			try
			{
				base.SecurityProtocol.VerifyIncomingMessage(ref message, timeout);
			}
			catch (MessageSecurityException)
			{
				TryGetSecurityFaultException(faultMessage, out faultException);
				if (faultException == null)
				{
					throw;
				}
			}
			if (faultException != null)
			{
				if (AcceptUnsecuredFaults)
				{
					Fault(faultException);
				}
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperWarning(faultException);
			}
			return message;
		}

		public async Task<(bool, Message)> TryReceiveAsync(TimeSpan timeout)
		{
			if (DoneReceivingInCurrentState())
			{
				return (true, null);
			}
			TimeoutHelper timeoutHelper = new TimeoutHelper(timeout);
			bool flag;
			Message message;
			if (InnerDuplexChannel is IAsyncDuplexChannel asyncDuplexChannel)
			{
				(flag, message) = await asyncDuplexChannel.TryReceiveAsync(timeoutHelper.RemainingTime());
			}
			else
			{
				(flag, message) = await TaskHelpers.FromAsync<TimeSpan, bool, Message>(InnerDuplexChannel.BeginTryReceive, InnerDuplexChannel.EndTryReceive, timeout, null);
			}
			if (flag)
			{
				message = ProcessMessage(message, timeoutHelper.RemainingTime());
			}
			return (flag, message);
		}

		public bool TryReceive(TimeSpan timeout, out Message message)
		{
			bool result;
			(result, message) = TryReceiveAsync(timeout).GetAwaiter().GetResult();
			return result;
		}

		public Task<bool> WaitForMessageAsync(TimeSpan timeout)
		{
			if (InnerDuplexChannel is IAsyncDuplexChannel asyncDuplexChannel)
			{
				return asyncDuplexChannel.WaitForMessageAsync(timeout);
			}
			return Task.Factory.FromAsync((Func<TimeSpan, AsyncCallback, object?, IAsyncResult>)InnerDuplexChannel.BeginWaitForMessage, (Func<IAsyncResult, bool>)InnerDuplexChannel.EndWaitForMessage, timeout, (object?)null);
		}

		public bool WaitForMessage(TimeSpan timeout)
		{
			return InnerDuplexChannel.WaitForMessage(timeout);
		}

		public IAsyncResult BeginWaitForMessage(TimeSpan timeout, AsyncCallback callback, object state)
		{
			return InnerDuplexChannel.BeginWaitForMessage(timeout, callback, state);
		}

		public bool EndWaitForMessage(IAsyncResult result)
		{
			return InnerDuplexChannel.EndWaitForMessage(result);
		}
	}

	private sealed class SecurityDuplexSessionChannel : SecurityDuplexChannel, IDuplexSessionChannel, IDuplexChannel, IInputChannel, IChannel, ICommunicationObject, IOutputChannel, ISessionChannel<IDuplexSession>, IAsyncDuplexSessionChannel, IAsyncDuplexChannel, IAsyncInputChannel, IAsyncCommunicationObject, IAsyncOutputChannel, ISessionChannel<IAsyncDuplexSession>
	{
		IDuplexSession ISessionChannel<IDuplexSession>.Session => ((ISessionChannel<IDuplexSession>)base.InnerChannel).Session;

		IAsyncDuplexSession ISessionChannel<IAsyncDuplexSession>.Session => ((ISessionChannel<IAsyncDuplexSession>)base.InnerChannel).Session;

		internal override bool AcceptUnsecuredFaults => true;

		public SecurityDuplexSessionChannel(ChannelManagerBase factory, SecurityProtocolFactory securityProtocolFactory, IDuplexSessionChannel innerChannel, EndpointAddress to, Uri via)
			: base(factory, securityProtocolFactory, (IDuplexChannel)innerChannel, to, via)
		{
		}
	}

	private SecuritySessionClientSettings<TChannel> _sessionClientSettings;

	private ISecurityCapabilities _securityCapabilities;

	public ChannelBuilder ChannelBuilder { get; }

	public SecurityProtocolFactory SecurityProtocolFactory { get; private set; }

	public SecuritySessionClientSettings<TChannel> SessionClientSettings => _sessionClientSettings;

	public bool SessionMode { get; }

	private bool SupportsDuplex
	{
		get
		{
			ThrowIfProtocolFactoryNotSet();
			return SecurityProtocolFactory.SupportsDuplex;
		}
	}

	private bool SupportsRequestReply
	{
		get
		{
			ThrowIfProtocolFactoryNotSet();
			return SecurityProtocolFactory.SupportsRequestReply;
		}
	}

	public MessageVersion MessageVersion { get; }

	public SecurityChannelFactory(ISecurityCapabilities securityCapabilities, BindingContext context, SecuritySessionClientSettings<TChannel> sessionClientSettings)
		: this(securityCapabilities, context, sessionClientSettings.ChannelBuilder, sessionClientSettings.CreateInnerChannelFactory())
	{
		SessionMode = true;
		_sessionClientSettings = sessionClientSettings;
	}

	public SecurityChannelFactory(ISecurityCapabilities securityCapabilities, BindingContext context, ChannelBuilder channelBuilder, SecurityProtocolFactory protocolFactory)
		: this(securityCapabilities, context, channelBuilder, protocolFactory, (IChannelFactory)channelBuilder.BuildChannelFactory<TChannel>())
	{
	}

	public SecurityChannelFactory(ISecurityCapabilities securityCapabilities, BindingContext context, ChannelBuilder channelBuilder, SecurityProtocolFactory protocolFactory, IChannelFactory innerChannelFactory)
		: this(securityCapabilities, context, channelBuilder, innerChannelFactory)
	{
		SecurityProtocolFactory = protocolFactory;
	}

	private SecurityChannelFactory(ISecurityCapabilities securityCapabilities, BindingContext context, ChannelBuilder channelBuilder, IChannelFactory innerChannelFactory)
		: base((IDefaultCommunicationTimeouts)context.Binding, innerChannelFactory)
	{
		ChannelBuilder = channelBuilder;
		MessageVersion = context.Binding.MessageVersion;
		_securityCapabilities = securityCapabilities;
	}

	private Task CloseProtocolFactoryAsync(bool aborted, TimeSpan timeout)
	{
		if (SecurityProtocolFactory != null && !SessionMode)
		{
			SecurityProtocolFactory securityProtocolFactory = SecurityProtocolFactory;
			SecurityProtocolFactory = null;
			return securityProtocolFactory.CloseAsync(aborted, timeout);
		}
		return Task.CompletedTask;
	}

	public override T GetProperty<T>()
	{
		if (SessionMode && typeof(T) == typeof(IChannelSecureConversationSessionSettings))
		{
			return (T)(object)SessionClientSettings;
		}
		if (typeof(T) == typeof(ISecurityCapabilities))
		{
			return (T)_securityCapabilities;
		}
		return base.GetProperty<T>();
	}

	protected override void OnAbort()
	{
		base.OnAbort();
		CloseProtocolFactoryAsync(aborted: true, TimeSpan.Zero);
		if (_sessionClientSettings != null)
		{
			_sessionClientSettings.Abort();
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

	protected internal override async Task OnCloseAsync(TimeSpan timeout)
	{
		TimeoutHelper timeoutHelper = new TimeoutHelper(timeout);
		await base.OnCloseAsync(timeout);
		await CloseProtocolFactoryAsync(aborted: false, timeoutHelper.RemainingTime());
		if (_sessionClientSettings != null)
		{
			await _sessionClientSettings.CloseAsync(timeoutHelper.RemainingTime());
		}
	}

	protected override void OnClose(TimeSpan timeout)
	{
		OnCloseAsync(timeout).Wait();
	}

	protected override TChannel OnCreateChannel(EndpointAddress address, Uri via)
	{
		ThrowIfDisposed();
		if (SessionMode)
		{
			return _sessionClientSettings.OnCreateChannel(address, via);
		}
		if (typeof(TChannel) == typeof(IAsyncOutputChannel) || typeof(TChannel) == typeof(IOutputChannel))
		{
			return (TChannel)(object)new SecurityOutputChannel(this, SecurityProtocolFactory, ((IChannelFactory<IOutputChannel>)base.InnerChannelFactory).CreateChannel(address, via), address, via);
		}
		if (typeof(TChannel) == typeof(IAsyncOutputSessionChannel) || typeof(TChannel) == typeof(IOutputSessionChannel))
		{
			return (TChannel)(object)new SecurityOutputSessionChannel(this, SecurityProtocolFactory, ((IChannelFactory<IOutputSessionChannel>)base.InnerChannelFactory).CreateChannel(address, via), address, via);
		}
		if (typeof(TChannel) == typeof(IAsyncDuplexChannel) || typeof(TChannel) == typeof(IDuplexChannel))
		{
			return (TChannel)(object)new SecurityDuplexChannel(this, SecurityProtocolFactory, ((IChannelFactory<IDuplexChannel>)base.InnerChannelFactory).CreateChannel(address, via), address, via);
		}
		if (typeof(TChannel) == typeof(IAsyncDuplexSessionChannel) || typeof(TChannel) == typeof(IDuplexSessionChannel))
		{
			return (TChannel)(object)new SecurityDuplexSessionChannel(this, SecurityProtocolFactory, ((IChannelFactory<IDuplexSessionChannel>)base.InnerChannelFactory).CreateChannel(address, via), address, via);
		}
		if (typeof(TChannel) == typeof(IAsyncRequestChannel) || typeof(TChannel) == typeof(IRequestChannel))
		{
			return (TChannel)(object)new SecurityRequestChannel(this, SecurityProtocolFactory, ((IChannelFactory<IRequestChannel>)base.InnerChannelFactory).CreateChannel(address, via), address, via);
		}
		return (TChannel)(object)new SecurityRequestSessionChannel(this, SecurityProtocolFactory, ((IChannelFactory<IRequestSessionChannel>)base.InnerChannelFactory).CreateChannel(address, via), address, via);
	}

	protected internal override async Task OnOpenAsync(TimeSpan timeout)
	{
		TimeoutHelper timeoutHelper = new TimeoutHelper(timeout);
		await OnOpenCoreAsync(timeoutHelper.RemainingTime());
		await base.OnOpenAsync(timeoutHelper.RemainingTime());
		SetBufferManager();
	}

	protected override void OnOpen(TimeSpan timeout)
	{
		OnOpenAsync(timeout).Wait();
	}

	private void SetBufferManager()
	{
		ITransportFactorySettings property = GetProperty<ITransportFactorySettings>();
		if (property == null)
		{
			return;
		}
		BufferManager bufferManager = property.BufferManager;
		if (bufferManager != null)
		{
			if (SessionMode && SessionClientSettings != null && SessionClientSettings.SessionProtocolFactory != null)
			{
				SessionClientSettings.SessionProtocolFactory.StreamBufferManager = bufferManager;
				return;
			}
			ThrowIfProtocolFactoryNotSet();
			SecurityProtocolFactory.StreamBufferManager = bufferManager;
		}
	}

	protected override IAsyncResult OnBeginOpen(TimeSpan timeout, AsyncCallback callback, object state)
	{
		return OnOpenAsync(timeout).ToApm(callback, state);
	}

	protected override void OnEndOpen(IAsyncResult result)
	{
		result.ToApmEnd();
	}

	private Task OnOpenCoreAsync(TimeSpan timeout)
	{
		TimeoutHelper timeoutHelper = new TimeoutHelper(timeout);
		if (SessionMode)
		{
			return SessionClientSettings.OpenAsync(this, base.InnerChannelFactory, ChannelBuilder, timeoutHelper.RemainingTime());
		}
		ThrowIfProtocolFactoryNotSet();
		return SecurityProtocolFactory.OpenAsync(actAsInitiator: true, timeoutHelper.RemainingTime());
	}

	private void ThrowIfProtocolFactoryNotSet()
	{
		if (SecurityProtocolFactory == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.Format(System.SR.SecurityProtocolFactoryShouldBeSetBeforeThisOperation)));
		}
	}
}
