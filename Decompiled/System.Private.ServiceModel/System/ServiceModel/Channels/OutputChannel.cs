using System.Runtime;
using System.Threading.Tasks;

namespace System.ServiceModel.Channels;

public abstract class OutputChannel : ChannelBase, IOutputChannel, IChannel, ICommunicationObject, IAsyncOutputChannel, IAsyncCommunicationObject
{
	public abstract EndpointAddress RemoteAddress { get; }

	public abstract Uri Via { get; }

	protected OutputChannel(ChannelManagerBase manager)
		: base(manager)
	{
	}

	public IAsyncResult BeginSend(Message message, AsyncCallback callback, object state)
	{
		return BeginSend(message, base.DefaultSendTimeout, callback, state);
	}

	public IAsyncResult BeginSend(Message message, TimeSpan timeout, AsyncCallback callback, object state)
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
		EmitTrace(message);
		return OnSendAsync(message, timeout).ToApm(callback, state);
	}

	public void EndSend(IAsyncResult result)
	{
		result.ToApmEnd();
	}

	public override T GetProperty<T>()
	{
		if (typeof(T) == typeof(IOutputChannel))
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

	protected abstract void OnSend(Message message, TimeSpan timeout);

	protected abstract Task OnSendAsync(Message message, TimeSpan timeout);

	public void Send(Message message)
	{
		Send(message, base.DefaultSendTimeout);
	}

	public void Send(Message message, TimeSpan timeout)
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
		EmitTrace(message);
		OnSend(message, timeout);
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
		EmitTrace(message);
		return OnSendAsync(message, timeout);
	}

	private void EmitTrace(Message message)
	{
	}

	protected virtual void AddHeadersTo(Message message)
	{
	}
}
