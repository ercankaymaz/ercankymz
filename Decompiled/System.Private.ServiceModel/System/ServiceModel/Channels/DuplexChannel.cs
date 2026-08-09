using System.Runtime;
using System.Threading.Tasks;

namespace System.ServiceModel.Channels;

internal abstract class DuplexChannel : InputQueueChannel<Message>, IDuplexChannel, IInputChannel, IChannel, ICommunicationObject, IOutputChannel, IAsyncDuplexChannel, IAsyncInputChannel, IAsyncCommunicationObject, IAsyncOutputChannel
{
	public virtual EndpointAddress LocalAddress { get; }

	public abstract EndpointAddress RemoteAddress { get; }

	public abstract Uri Via { get; }

	protected DuplexChannel(ChannelManagerBase channelManager, EndpointAddress localAddress)
		: base(channelManager)
	{
		LocalAddress = localAddress;
	}

	public Task SendAsync(Message message)
	{
		return SendAsync(message, base.DefaultSendTimeout);
	}

	public Task SendAsync(Message message, TimeSpan timeout)
	{
		if (message == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("message");
		}
		if (timeout < TimeSpan.Zero)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentOutOfRangeException("timeout", timeout, System.SR.SFxTimeoutOutOfRange0));
		}
		ThrowIfDisposedOrNotOpen();
		AddHeadersTo(message);
		return OnSendAsync(message, timeout);
	}

	public IAsyncResult BeginSend(Message message, AsyncCallback callback, object state)
	{
		return BeginSend(message, base.DefaultSendTimeout, callback, state);
	}

	public IAsyncResult BeginSend(Message message, TimeSpan timeout, AsyncCallback callback, object state)
	{
		return SendAsync(message).ToApm(callback, state);
	}

	public void EndSend(IAsyncResult result)
	{
		result.ToApmEnd();
	}

	public override T GetProperty<T>()
	{
		if (typeof(T) == typeof(IDuplexChannel))
		{
			return (T)(object)this;
		}
		T property = base.GetProperty<T>();
		if (property != null)
		{
			return property;
		}
		return null;
	}

	protected abstract Task OnSendAsync(Message message, TimeSpan timeout);

	public void Send(Message message)
	{
		Send(message, base.DefaultSendTimeout);
	}

	public void Send(Message message, TimeSpan timeout)
	{
		SendAsync(message, timeout).WaitForCompletionNoSpin();
	}

	protected virtual void AddHeadersTo(Message message)
	{
	}

	public Task<Message> ReceiveAsync()
	{
		return ReceiveAsync(base.DefaultReceiveTimeout);
	}

	public Task<Message> ReceiveAsync(TimeSpan timeout)
	{
		if (timeout < TimeSpan.Zero)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentOutOfRangeException("timeout", timeout, System.SR.SFxTimeoutOutOfRange0));
		}
		ThrowPending();
		return InputChannel.HelpReceiveAsync(this, timeout);
	}

	public Message Receive()
	{
		return Receive(base.DefaultReceiveTimeout);
	}

	public Message Receive(TimeSpan timeout)
	{
		return ReceiveAsync(timeout).WaitForCompletion();
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

	public Task<(bool, Message)> TryReceiveAsync(TimeSpan timeout)
	{
		if (timeout < TimeSpan.Zero)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentOutOfRangeException("timeout", timeout, System.SR.SFxTimeoutOutOfRange0));
		}
		ThrowPending();
		return DequeueAsync(timeout);
	}

	public bool TryReceive(TimeSpan timeout, out Message message)
	{
		bool result;
		(result, message) = TryReceiveAsync(timeout).WaitForCompletion();
		return result;
	}

	public IAsyncResult BeginTryReceive(TimeSpan timeout, AsyncCallback callback, object state)
	{
		return TryReceiveAsync(timeout).ToApm(callback, state);
	}

	public bool EndTryReceive(IAsyncResult result, out Message message)
	{
		bool result2;
		(result2, message) = result.ToApmEnd<(bool, Message)>();
		return result2;
	}

	public Task<bool> WaitForMessageAsync(TimeSpan timeout)
	{
		if (timeout < TimeSpan.Zero)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentOutOfRangeException("timeout", timeout, System.SR.SFxTimeoutOutOfRange0));
		}
		ThrowPending();
		return WaitForItemAsync(timeout);
	}

	public bool WaitForMessage(TimeSpan timeout)
	{
		return WaitForMessageAsync(timeout).WaitForCompletion();
	}

	public IAsyncResult BeginWaitForMessage(TimeSpan timeout, AsyncCallback callback, object state)
	{
		return WaitForMessageAsync(timeout).ToApm(callback, state);
	}

	public bool EndWaitForMessage(IAsyncResult result)
	{
		return result.ToApmEnd<bool>();
	}
}
