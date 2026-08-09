using System.Runtime;
using System.ServiceModel.Channels;
using System.ServiceModel.Diagnostics;

namespace System.ServiceModel.Dispatcher;

internal class InputChannelBinder : IChannelBinder
{
	internal class InputRequestContext : RequestContextBase
	{
		private InputChannelBinder _binder;

		internal InputRequestContext(Message request, InputChannelBinder binder)
			: base(request, TimeSpan.Zero, TimeSpan.Zero)
		{
			_binder = binder;
		}

		protected override void OnAbort()
		{
		}

		protected override void OnClose(TimeSpan timeout)
		{
		}

		protected override void OnReply(Message message, TimeSpan timeout)
		{
		}

		protected override IAsyncResult OnBeginReply(Message message, TimeSpan timeout, AsyncCallback callback, object state)
		{
			return new CompletedAsyncResult(callback, state);
		}

		protected override void OnEndReply(IAsyncResult result)
		{
			CompletedAsyncResult.End(result);
		}
	}

	private IInputChannel _channel;

	public IChannel Channel => _channel;

	public bool HasSession => _channel is ISessionChannel<IInputSession>;

	public Uri ListenUri { get; }

	public EndpointAddress LocalAddress => _channel.LocalAddress;

	public EndpointAddress RemoteAddress
	{
		get
		{
			throw ExceptionHelper.AsError(System.NotImplemented.ByDesign);
		}
	}

	internal InputChannelBinder(IInputChannel channel, Uri listenUri)
	{
		if (channel == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("channel");
		}
		_channel = channel;
		ListenUri = listenUri;
	}

	public void Abort()
	{
		_channel.Abort();
	}

	public void CloseAfterFault(TimeSpan timeout)
	{
		_channel.Close(timeout);
	}

	public IAsyncResult BeginTryReceive(TimeSpan timeout, AsyncCallback callback, object state)
	{
		return _channel.BeginTryReceive(timeout, callback, state);
	}

	public bool EndTryReceive(IAsyncResult result, out RequestContext requestContext)
	{
		if (_channel.EndTryReceive(result, out var message))
		{
			requestContext = WrapMessage(message);
			return true;
		}
		requestContext = null;
		return false;
	}

	public RequestContext CreateRequestContext(Message message)
	{
		return WrapMessage(message);
	}

	public IAsyncResult BeginSend(Message message, TimeSpan timeout, AsyncCallback callback, object state)
	{
		throw TraceUtility.ThrowHelperError(System.NotImplemented.ByDesign, message);
	}

	public void EndSend(IAsyncResult result)
	{
		throw ExceptionHelper.AsError(System.NotImplemented.ByDesign);
	}

	public void Send(Message message, TimeSpan timeout)
	{
		throw TraceUtility.ThrowHelperError(System.NotImplemented.ByDesign, message);
	}

	public bool TryReceive(TimeSpan timeout, out RequestContext requestContext)
	{
		if (_channel.TryReceive(timeout, out var message))
		{
			requestContext = WrapMessage(message);
			return true;
		}
		requestContext = null;
		return false;
	}

	public IAsyncResult BeginRequest(Message message, TimeSpan timeout, AsyncCallback callback, object state)
	{
		throw TraceUtility.ThrowHelperError(System.NotImplemented.ByDesign, message);
	}

	public Message EndRequest(IAsyncResult result)
	{
		throw ExceptionHelper.AsError(System.NotImplemented.ByDesign);
	}

	public Message Request(Message message, TimeSpan timeout)
	{
		throw TraceUtility.ThrowHelperError(System.NotImplemented.ByDesign, message);
	}

	public bool WaitForMessage(TimeSpan timeout)
	{
		return _channel.WaitForMessage(timeout);
	}

	public IAsyncResult BeginWaitForMessage(TimeSpan timeout, AsyncCallback callback, object state)
	{
		return _channel.BeginWaitForMessage(timeout, callback, state);
	}

	public bool EndWaitForMessage(IAsyncResult result)
	{
		return _channel.EndWaitForMessage(result);
	}

	private RequestContext WrapMessage(Message message)
	{
		if (message == null)
		{
			return null;
		}
		return new InputRequestContext(message, this);
	}
}
