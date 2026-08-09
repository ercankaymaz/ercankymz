using System.Runtime;
using System.ServiceModel.Channels;
using System.Threading;

namespace System.ServiceModel.Dispatcher;

internal class BufferedReceiveBinder : IChannelBinder
{
	private class RequestContextWrapper
	{
		public RequestContext RequestContext { get; private set; }

		public RequestContextWrapper(RequestContext requestContext)
		{
			RequestContext = requestContext;
		}
	}

	private static Action<object> s_tryReceive = TryReceive;

	private static AsyncCallback s_tryReceiveCallback = Fx.ThunkCallback(TryReceiveCallback);

	private IChannelBinder _channelBinder;

	private InputQueue<RequestContextWrapper> _inputQueue;

	private int _pendingOperationSemaphore;

	public IChannel Channel => _channelBinder.Channel;

	public bool HasSession => _channelBinder.HasSession;

	public Uri ListenUri => _channelBinder.ListenUri;

	public EndpointAddress LocalAddress => _channelBinder.LocalAddress;

	public EndpointAddress RemoteAddress => _channelBinder.RemoteAddress;

	public BufferedReceiveBinder(IChannelBinder channelBinder)
	{
		_channelBinder = channelBinder;
		_inputQueue = new InputQueue<RequestContextWrapper>();
	}

	public void Abort()
	{
		_inputQueue.Close();
		_channelBinder.Abort();
	}

	public void CloseAfterFault(TimeSpan timeout)
	{
		_inputQueue.Close();
		_channelBinder.CloseAfterFault(timeout);
	}

	public bool TryReceive(TimeSpan timeout, out RequestContext requestContext)
	{
		if (Interlocked.CompareExchange(ref _pendingOperationSemaphore, 1, 0) == 0)
		{
			ActionItem.Schedule(s_tryReceive, this);
		}
		RequestContextWrapper value;
		bool flag = _inputQueue.Dequeue(timeout, out value);
		if (flag && value != null)
		{
			requestContext = value.RequestContext;
		}
		else
		{
			requestContext = null;
		}
		return flag;
	}

	public IAsyncResult BeginTryReceive(TimeSpan timeout, AsyncCallback callback, object state)
	{
		if (Interlocked.CompareExchange(ref _pendingOperationSemaphore, 1, 0) == 0)
		{
			IAsyncResult asyncResult = _channelBinder.BeginTryReceive(timeout, s_tryReceiveCallback, this);
			if (asyncResult.CompletedSynchronously)
			{
				HandleEndTryReceive(asyncResult);
			}
		}
		return _inputQueue.BeginDequeue(timeout, callback, state);
	}

	public bool EndTryReceive(IAsyncResult result, out RequestContext requestContext)
	{
		RequestContextWrapper value;
		bool flag = _inputQueue.EndDequeue(result, out value);
		if (flag && value != null)
		{
			requestContext = value.RequestContext;
		}
		else
		{
			requestContext = null;
		}
		return flag;
	}

	public RequestContext CreateRequestContext(Message message)
	{
		return _channelBinder.CreateRequestContext(message);
	}

	public void Send(Message message, TimeSpan timeout)
	{
		_channelBinder.Send(message, timeout);
	}

	public IAsyncResult BeginSend(Message message, TimeSpan timeout, AsyncCallback callback, object state)
	{
		return _channelBinder.BeginSend(message, timeout, callback, state);
	}

	public void EndSend(IAsyncResult result)
	{
		_channelBinder.EndSend(result);
	}

	public Message Request(Message message, TimeSpan timeout)
	{
		return _channelBinder.Request(message, timeout);
	}

	public IAsyncResult BeginRequest(Message message, TimeSpan timeout, AsyncCallback callback, object state)
	{
		return _channelBinder.BeginRequest(message, timeout, callback, state);
	}

	public Message EndRequest(IAsyncResult result)
	{
		return _channelBinder.EndRequest(result);
	}

	public bool WaitForMessage(TimeSpan timeout)
	{
		return _channelBinder.WaitForMessage(timeout);
	}

	public IAsyncResult BeginWaitForMessage(TimeSpan timeout, AsyncCallback callback, object state)
	{
		return _channelBinder.BeginWaitForMessage(timeout, callback, state);
	}

	public bool EndWaitForMessage(IAsyncResult result)
	{
		return _channelBinder.EndWaitForMessage(result);
	}

	internal void InjectRequest(RequestContext requestContext)
	{
		_inputQueue.EnqueueAndDispatch(new RequestContextWrapper(requestContext));
	}

	private static void TryReceive(object state)
	{
		BufferedReceiveBinder bufferedReceiveBinder = (BufferedReceiveBinder)state;
		bool flag = false;
		try
		{
			if (bufferedReceiveBinder._channelBinder.TryReceive(TimeSpan.MaxValue, out var requestContext))
			{
				flag = bufferedReceiveBinder._inputQueue.EnqueueWithoutDispatch(new RequestContextWrapper(requestContext), null);
			}
		}
		catch (Exception exception)
		{
			if (Fx.IsFatal(exception))
			{
				throw;
			}
			flag = bufferedReceiveBinder._inputQueue.EnqueueWithoutDispatch(exception, null);
		}
		finally
		{
			Interlocked.Exchange(ref bufferedReceiveBinder._pendingOperationSemaphore, 0);
			if (flag)
			{
				bufferedReceiveBinder._inputQueue.Dispatch();
			}
		}
	}

	private static void TryReceiveCallback(IAsyncResult result)
	{
		if (!result.CompletedSynchronously)
		{
			HandleEndTryReceive(result);
		}
	}

	private static void HandleEndTryReceive(IAsyncResult result)
	{
		BufferedReceiveBinder bufferedReceiveBinder = (BufferedReceiveBinder)result.AsyncState;
		bool flag = false;
		try
		{
			if (bufferedReceiveBinder._channelBinder.EndTryReceive(result, out var requestContext))
			{
				flag = bufferedReceiveBinder._inputQueue.EnqueueWithoutDispatch(new RequestContextWrapper(requestContext), null);
			}
		}
		catch (Exception exception)
		{
			if (Fx.IsFatal(exception))
			{
				throw;
			}
			flag = bufferedReceiveBinder._inputQueue.EnqueueWithoutDispatch(exception, null);
		}
		finally
		{
			Interlocked.Exchange(ref bufferedReceiveBinder._pendingOperationSemaphore, 0);
			if (flag)
			{
				bufferedReceiveBinder._inputQueue.Dispatch();
			}
		}
	}
}
