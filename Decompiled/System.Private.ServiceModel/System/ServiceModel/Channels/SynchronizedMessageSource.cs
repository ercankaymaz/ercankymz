using System.Runtime;
using System.Threading;
using System.Threading.Tasks;

namespace System.ServiceModel.Channels;

internal class SynchronizedMessageSource
{
	private IMessageSource _source;

	private SemaphoreSlim _sourceLock;

	public SynchronizedMessageSource(IMessageSource source)
	{
		_source = source;
		_sourceLock = new SemaphoreSlim(1);
	}

	public async Task<bool> WaitForMessageAsync(TimeSpan timeout)
	{
		TimeoutHelper timeoutHelper = new TimeoutHelper(timeout);
		if (!(await _sourceLock.WaitAsync(TimeoutHelper.ToMilliseconds(timeout))))
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new TimeoutException(System.SR.Format(System.SR.WaitForMessageTimedOut, timeout), TimeoutHelper.CreateEnterTimedOutException(timeout)));
		}
		try
		{
			return await _source.WaitForMessageAsync(timeoutHelper.RemainingTime());
		}
		finally
		{
			_sourceLock.Release();
		}
	}

	public bool WaitForMessage(TimeSpan timeout)
	{
		TimeoutHelper timeoutHelper = new TimeoutHelper(timeout);
		if (!_sourceLock.Wait(TimeoutHelper.ToMilliseconds(timeout)))
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new TimeoutException(System.SR.Format(System.SR.WaitForMessageTimedOut, timeout), TimeoutHelper.CreateEnterTimedOutException(timeout)));
		}
		try
		{
			return _source.WaitForMessage(timeoutHelper.RemainingTime());
		}
		finally
		{
			_sourceLock.Release();
		}
	}

	public async Task<Message> ReceiveAsync(TimeSpan timeout)
	{
		TimeoutHelper timeoutHelper = new TimeoutHelper(timeout);
		if (!(await _sourceLock.WaitAsync(TimeoutHelper.ToMilliseconds(timeout))))
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new TimeoutException(System.SR.Format(System.SR.ReceiveTimedOut2, timeout), TimeoutHelper.CreateEnterTimedOutException(timeout)));
		}
		try
		{
			return await _source.ReceiveAsync(timeoutHelper.RemainingTime());
		}
		finally
		{
			_sourceLock.Release();
		}
	}

	public Message Receive(TimeSpan timeout)
	{
		TimeoutHelper timeoutHelper = new TimeoutHelper(timeout);
		if (!_sourceLock.Wait(TimeoutHelper.ToMilliseconds(timeout)))
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new TimeoutException(System.SR.Format(System.SR.ReceiveTimedOut2, timeout), TimeoutHelper.CreateEnterTimedOutException(timeout)));
		}
		try
		{
			return _source.Receive(timeoutHelper.RemainingTime());
		}
		finally
		{
			_sourceLock.Release();
		}
	}
}
