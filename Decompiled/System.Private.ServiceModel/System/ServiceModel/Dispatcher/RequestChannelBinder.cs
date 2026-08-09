using System.ServiceModel.Channels;
using System.ServiceModel.Diagnostics;

namespace System.ServiceModel.Dispatcher;

internal class RequestChannelBinder : IChannelBinder
{
	private IRequestChannel _channel;

	public IChannel Channel => _channel;

	public bool HasSession => _channel is ISessionChannel<IOutputSession>;

	public Uri ListenUri => null;

	public EndpointAddress LocalAddress => EndpointAddress.AnonymousAddress;

	public EndpointAddress RemoteAddress => _channel.RemoteAddress;

	internal RequestChannelBinder(IRequestChannel channel)
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
		throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(System.NotImplemented.ByDesign);
	}

	public bool EndTryReceive(IAsyncResult result, out RequestContext requestContext)
	{
		throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(System.NotImplemented.ByDesign);
	}

	public RequestContext CreateRequestContext(Message message)
	{
		throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(System.NotImplemented.ByDesign);
	}

	public IAsyncResult BeginSend(Message message, TimeSpan timeout, AsyncCallback callback, object state)
	{
		return _channel.BeginRequest(message, timeout, callback, state);
	}

	public void EndSend(IAsyncResult result)
	{
		ValidateNullReply(_channel.EndRequest(result));
	}

	public void Send(Message message, TimeSpan timeout)
	{
		ValidateNullReply(_channel.Request(message, timeout));
	}

	public IAsyncResult BeginRequest(Message message, TimeSpan timeout, AsyncCallback callback, object state)
	{
		return _channel.BeginRequest(message, timeout, callback, state);
	}

	public Message EndRequest(IAsyncResult result)
	{
		return _channel.EndRequest(result);
	}

	public bool TryReceive(TimeSpan timeout, out RequestContext requestContext)
	{
		throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(System.NotImplemented.ByDesign);
	}

	public Message Request(Message message, TimeSpan timeout)
	{
		return _channel.Request(message, timeout);
	}

	private void ValidateNullReply(Message message)
	{
		if (message != null && !(message is NullMessage))
		{
			ProtocolException exception = ProtocolException.OneWayOperationReturnedNonNull(message);
			throw TraceUtility.ThrowHelperError(exception, message);
		}
	}

	public bool WaitForMessage(TimeSpan timeout)
	{
		throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(System.NotImplemented.ByDesign);
	}

	public IAsyncResult BeginWaitForMessage(TimeSpan timeout, AsyncCallback callback, object state)
	{
		throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(System.NotImplemented.ByDesign);
	}

	public bool EndWaitForMessage(IAsyncResult result)
	{
		throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(System.NotImplemented.ByDesign);
	}
}
