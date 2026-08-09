using System.ServiceModel.Channels;
using System.ServiceModel.Diagnostics;

namespace System.ServiceModel.Dispatcher;

internal class OutputChannelBinder : IChannelBinder
{
	private IOutputChannel _channel;

	public IChannel Channel => _channel;

	public bool HasSession => _channel is ISessionChannel<IOutputSession>;

	public Uri ListenUri => null;

	public EndpointAddress LocalAddress
	{
		get
		{
			throw ExceptionHelper.AsError(System.NotImplemented.ByDesign);
		}
	}

	public EndpointAddress RemoteAddress => _channel.RemoteAddress;

	internal OutputChannelBinder(IOutputChannel channel)
	{
		if (channel == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("channel");
		}
		_channel = channel;
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
		throw ExceptionHelper.AsError(System.NotImplemented.ByDesign);
	}

	public bool EndTryReceive(IAsyncResult result, out RequestContext requestContext)
	{
		throw ExceptionHelper.AsError(System.NotImplemented.ByDesign);
	}

	public RequestContext CreateRequestContext(Message message)
	{
		throw ExceptionHelper.AsError(System.NotImplemented.ByDesign);
	}

	public IAsyncResult BeginSend(Message message, TimeSpan timeout, AsyncCallback callback, object state)
	{
		return _channel.BeginSend(message, timeout, callback, state);
	}

	public void EndSend(IAsyncResult result)
	{
		_channel.EndSend(result);
	}

	public void Send(Message message, TimeSpan timeout)
	{
		_channel.Send(message, timeout);
	}

	public IAsyncResult BeginRequest(Message message, TimeSpan timeout, AsyncCallback callback, object state)
	{
		throw TraceUtility.ThrowHelperError(System.NotImplemented.ByDesign, message);
	}

	public Message EndRequest(IAsyncResult result)
	{
		throw ExceptionHelper.AsError(System.NotImplemented.ByDesign);
	}

	public bool TryReceive(TimeSpan timeout, out RequestContext requestContext)
	{
		throw ExceptionHelper.AsError(System.NotImplemented.ByDesign);
	}

	public Message Request(Message message, TimeSpan timeout)
	{
		throw TraceUtility.ThrowHelperError(System.NotImplemented.ByDesign, message);
	}

	public bool WaitForMessage(TimeSpan timeout)
	{
		throw ExceptionHelper.AsError(System.NotImplemented.ByDesign);
	}

	public IAsyncResult BeginWaitForMessage(TimeSpan timeout, AsyncCallback callback, object state)
	{
		throw ExceptionHelper.AsError(System.NotImplemented.ByDesign);
	}

	public bool EndWaitForMessage(IAsyncResult result)
	{
		throw ExceptionHelper.AsError(System.NotImplemented.ByDesign);
	}
}
