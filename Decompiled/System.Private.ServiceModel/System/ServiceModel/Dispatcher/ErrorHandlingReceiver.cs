using System.Runtime;
using System.ServiceModel.Channels;

namespace System.ServiceModel.Dispatcher;

internal class ErrorHandlingReceiver
{
	private class ErrorHandlingCompletedAsyncResult : CompletedAsyncResult<bool>
	{
		internal ErrorHandlingCompletedAsyncResult(bool data, AsyncCallback callback, object state)
			: base(data, callback, state)
		{
		}
	}

	private ChannelDispatcher _dispatcher;

	private IChannelBinder _binder;

	internal ErrorHandlingReceiver(IChannelBinder binder, ChannelDispatcher dispatcher)
	{
		_binder = binder;
		_dispatcher = dispatcher;
	}

	internal void Close()
	{
		try
		{
			_binder.Channel.Close();
		}
		catch (Exception ex)
		{
			if (Fx.IsFatal(ex))
			{
				throw;
			}
			HandleError(ex);
		}
	}

	private void HandleError(Exception e)
	{
		if (_dispatcher != null)
		{
			_dispatcher.HandleError(e);
		}
	}

	private void HandleErrorOrAbort(Exception e)
	{
		if ((_dispatcher == null || !_dispatcher.HandleError(e)) && _binder.HasSession)
		{
			_binder.Abort();
		}
	}

	internal bool TryReceive(TimeSpan timeout, out RequestContext requestContext)
	{
		try
		{
			return _binder.TryReceive(timeout, out requestContext);
		}
		catch (CommunicationObjectAbortedException)
		{
			requestContext = null;
			return true;
		}
		catch (CommunicationObjectFaultedException)
		{
			requestContext = null;
			return true;
		}
		catch (CommunicationException e)
		{
			HandleError(e);
			requestContext = null;
			return false;
		}
		catch (TimeoutException e2)
		{
			HandleError(e2);
			requestContext = null;
			return false;
		}
		catch (Exception ex3)
		{
			if (Fx.IsFatal(ex3))
			{
				throw;
			}
			HandleErrorOrAbort(ex3);
			requestContext = null;
			return false;
		}
	}

	internal IAsyncResult BeginTryReceive(TimeSpan timeout, AsyncCallback callback, object state)
	{
		try
		{
			return _binder.BeginTryReceive(timeout, callback, state);
		}
		catch (CommunicationObjectAbortedException)
		{
			return new ErrorHandlingCompletedAsyncResult(data: true, callback, state);
		}
		catch (CommunicationObjectFaultedException)
		{
			return new ErrorHandlingCompletedAsyncResult(data: true, callback, state);
		}
		catch (CommunicationException e)
		{
			HandleError(e);
			return new ErrorHandlingCompletedAsyncResult(data: false, callback, state);
		}
		catch (TimeoutException e2)
		{
			HandleError(e2);
			return new ErrorHandlingCompletedAsyncResult(data: false, callback, state);
		}
		catch (Exception ex3)
		{
			if (Fx.IsFatal(ex3))
			{
				throw;
			}
			HandleErrorOrAbort(ex3);
			return new ErrorHandlingCompletedAsyncResult(data: false, callback, state);
		}
	}

	internal bool EndTryReceive(IAsyncResult result, out RequestContext requestContext)
	{
		if (result is ErrorHandlingCompletedAsyncResult result2)
		{
			requestContext = null;
			return CompletedAsyncResult<bool>.End(result2);
		}
		try
		{
			return _binder.EndTryReceive(result, out requestContext);
		}
		catch (CommunicationObjectAbortedException)
		{
			requestContext = null;
			return true;
		}
		catch (CommunicationObjectFaultedException)
		{
			requestContext = null;
			return true;
		}
		catch (CommunicationException e)
		{
			HandleError(e);
			requestContext = null;
			return false;
		}
		catch (TimeoutException e2)
		{
			HandleError(e2);
			requestContext = null;
			return false;
		}
		catch (Exception ex3)
		{
			if (Fx.IsFatal(ex3))
			{
				throw;
			}
			HandleErrorOrAbort(ex3);
			requestContext = null;
			return false;
		}
	}
}
