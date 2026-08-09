using System.Runtime;
using System.Threading.Tasks;

namespace System.ServiceModel.Channels;

internal class LayeredInputChannel : LayeredChannel<IInputChannel>, IAsyncInputChannel, IInputChannel, IChannel, ICommunicationObject, IAsyncCommunicationObject
{
	public virtual EndpointAddress LocalAddress => base.InnerChannel.LocalAddress;

	public LayeredInputChannel(ChannelManagerBase channelManager, IInputChannel innerChannel)
		: base(channelManager, innerChannel)
	{
	}

	private Task InternalOnReceiveAsync(Message message)
	{
		if (message != null)
		{
			return OnReceiveAsync(message);
		}
		return Task.CompletedTask;
	}

	protected virtual Task OnReceiveAsync(Message message)
	{
		return Task.CompletedTask;
	}

	public Message Receive()
	{
		return ReceiveAsync().GetAwaiter().GetResult();
	}

	public async Task<Message> ReceiveAsync(TimeSpan timeout)
	{
		Message message = ((!(base.InnerChannel is IAsyncInputChannel asyncInputChannel)) ? (await Task.Factory.FromAsync((Func<TimeSpan, AsyncCallback, object?, IAsyncResult>)base.InnerChannel.BeginReceive, (Func<IAsyncResult, Message>)base.InnerChannel.EndReceive, timeout, (object?)null)) : (await asyncInputChannel.ReceiveAsync(timeout)));
		await InternalOnReceiveAsync(message);
		return message;
	}

	public async Task<Message> ReceiveAsync()
	{
		Message message = ((!(base.InnerChannel is IAsyncInputChannel asyncInputChannel)) ? (await Task.Factory.FromAsync((Func<AsyncCallback, object?, IAsyncResult>)base.InnerChannel.BeginReceive, (Func<IAsyncResult, Message>)base.InnerChannel.EndReceive, (object?)null)) : (await asyncInputChannel.ReceiveAsync()));
		await InternalOnReceiveAsync(message);
		return message;
	}

	public Message Receive(TimeSpan timeout)
	{
		return ReceiveAsync(timeout).GetAwaiter().GetResult();
	}

	public IAsyncResult BeginReceive(AsyncCallback callback, object state)
	{
		return ReceiveAsync().ToApm(callback, state);
	}

	public IAsyncResult BeginReceive(TimeSpan timeout, AsyncCallback callback, object state)
	{
		return ReceiveAsync(timeout).ToApm(callback, state);
	}

	public Message EndReceive(IAsyncResult result)
	{
		return result.ToApmEnd<Message>();
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

	public async Task<(bool, Message)> TryReceiveAsync(TimeSpan timeout)
	{
		bool retVal;
		Message message;
		if (base.InnerChannel is IAsyncInputChannel asyncInputChannel)
		{
			(retVal, message) = await asyncInputChannel.TryReceiveAsync(timeout);
		}
		else
		{
			(retVal, message) = await TaskHelpers.FromAsync<TimeSpan, bool, Message>(base.InnerChannel.BeginTryReceive, base.InnerChannel.EndTryReceive, timeout, null);
		}
		await InternalOnReceiveAsync(message);
		return (retVal, message);
	}

	public bool TryReceive(TimeSpan timeout, out Message message)
	{
		bool result;
		(result, message) = TryReceiveAsync(timeout).GetAwaiter().GetResult();
		return result;
	}

	public Task<bool> WaitForMessageAsync(TimeSpan timeout)
	{
		if (base.InnerChannel is IAsyncInputChannel asyncInputChannel)
		{
			return asyncInputChannel.WaitForMessageAsync(timeout);
		}
		return Task.Factory.FromAsync((Func<TimeSpan, AsyncCallback, object?, IAsyncResult>)base.InnerChannel.BeginWaitForMessage, (Func<IAsyncResult, bool>)base.InnerChannel.EndWaitForMessage, timeout, (object?)null);
	}

	public bool WaitForMessage(TimeSpan timeout)
	{
		return WaitForMessageAsync(timeout).GetAwaiter().GetResult();
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
