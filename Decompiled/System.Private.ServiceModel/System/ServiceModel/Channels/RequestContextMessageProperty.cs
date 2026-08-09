using System.Runtime;

namespace System.ServiceModel.Channels;

internal class RequestContextMessageProperty : IDisposable
{
	private RequestContext _context;

	private object _thisLock = new object();

	public static string Name => "requestContext";

	public RequestContextMessageProperty(RequestContext context)
	{
		_context = context;
	}

	void IDisposable.Dispose()
	{
		bool flag = false;
		RequestContext context;
		lock (_thisLock)
		{
			if (_context == null)
			{
				return;
			}
			context = _context;
			_context = null;
		}
		try
		{
			context.Close();
			flag = true;
		}
		catch (CommunicationException)
		{
		}
		catch (TimeoutException ex2)
		{
			if (WcfEventSource.Instance.CloseTimeoutIsEnabled())
			{
				WcfEventSource.Instance.CloseTimeout(ex2.Message);
			}
		}
		finally
		{
			if (!flag)
			{
				context.Abort();
			}
		}
	}
}
