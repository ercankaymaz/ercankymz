using System;
using System.Runtime.InteropServices;
using System.Threading;

namespace Opc.Ua;

[ComVisible(true)]
public class AsyncResultBase : IAsyncResult, IDisposable
{
	private AsyncCallback m_callback;

	private ManualResetEvent m_waitHandle;

	private DateTime m_deadline;

	private Timer m_timer;

	private CancellationTokenSource m_cts;

	public object Lock { get; } = new object();

	public IAsyncResult InnerResult { get; set; }

	public Exception Exception { get; set; }

	public CancellationToken CancellationToken
	{
		get
		{
			if (m_cts != null)
			{
				return m_cts.Token;
			}
			return CancellationToken.None;
		}
	}

	public object AsyncState { get; private set; }

	public WaitHandle AsyncWaitHandle
	{
		get
		{
			lock (Lock)
			{
				if (m_waitHandle == null)
				{
					m_waitHandle = new ManualResetEvent(initialState: false);
				}
				return m_waitHandle;
			}
		}
	}

	public bool CompletedSynchronously => false;

	public bool IsCompleted { get; private set; }

	public AsyncResultBase(AsyncCallback callback, object callbackData, int timeout)
		: this(callback, callbackData, timeout, null)
	{
	}

	public AsyncResultBase(AsyncCallback callback, object callbackData, int timeout, CancellationTokenSource cts)
	{
		m_callback = callback;
		AsyncState = callbackData;
		m_deadline = DateTime.MinValue;
		m_cts = cts;
		if (timeout > 0)
		{
			m_deadline = DateTime.UtcNow.AddMilliseconds(timeout);
			if (m_callback != null)
			{
				m_timer = new Timer(OnTimeout, null, timeout, -1);
			}
		}
	}

	public void Dispose()
	{
		Dispose(disposing: true);
	}

	protected virtual void Dispose(bool disposing)
	{
		if (disposing)
		{
			DisposeTimer();
			DisposeWaitHandle(set: true);
			if (m_cts != null)
			{
				Utils.SilentDispose(m_cts);
				m_cts = null;
			}
		}
	}

	public static void WaitForComplete(IAsyncResult ar)
	{
		if (!((ar as AsyncResultBase) ?? throw new ArgumentException("IAsyncResult passed to call is not an instance of AsyncResultBase.")).WaitForComplete())
		{
			throw new TimeoutException();
		}
	}

	public bool WaitForComplete()
	{
		try
		{
			WaitHandle waitHandle = null;
			int num = -1;
			lock (Lock)
			{
				if (Exception != null)
				{
					throw new ServiceResultException(Exception, 2147811328u);
				}
				if (m_deadline != DateTime.MinValue)
				{
					num = (int)(m_deadline - DateTime.UtcNow).TotalMilliseconds;
					if (num <= 0)
					{
						return false;
					}
				}
				if (IsCompleted)
				{
					return true;
				}
				if (m_waitHandle == null)
				{
					m_waitHandle = new ManualResetEvent(initialState: false);
				}
				waitHandle = m_waitHandle;
			}
			if (waitHandle != null)
			{
				try
				{
					if (!waitHandle.WaitOne(num))
					{
						return false;
					}
					lock (Lock)
					{
						if (Exception != null)
						{
							throw new ServiceResultException(Exception, 2147811328u);
						}
					}
				}
				catch (ObjectDisposedException)
				{
					return false;
				}
			}
		}
		finally
		{
			DisposeTimer();
			DisposeWaitHandle(set: false);
		}
		return true;
	}

	public void Reset()
	{
		lock (Lock)
		{
			IsCompleted = false;
			m_waitHandle?.Reset();
		}
	}

	public void OperationCompleted()
	{
		lock (Lock)
		{
			IsCompleted = true;
			try
			{
				m_waitHandle?.Set();
			}
			catch (ObjectDisposedException exception)
			{
				Utils.LogTrace(exception, "Unexpected error handling OperationCompleted for AsyncResult operation.");
			}
		}
		m_callback?.Invoke(this);
	}

	private void DisposeTimer()
	{
		lock (Lock)
		{
			try
			{
				m_timer?.Dispose();
			}
			catch (Exception exception)
			{
				Utils.LogTrace(exception, "Unexpected error handling dispose of timer for AsyncResult operation.");
			}
			finally
			{
				m_timer = null;
			}
		}
	}

	private void DisposeWaitHandle(bool set)
	{
		ManualResetEvent manualResetEvent = Interlocked.Exchange(ref m_waitHandle, null);
		if (manualResetEvent == null)
		{
			return;
		}
		try
		{
			if (set)
			{
				manualResetEvent.Set();
			}
			manualResetEvent.Dispose();
		}
		catch (Exception exception)
		{
			Utils.LogTrace(exception, "Unexpected error handling dispose of wait handle for AsyncResult operation.");
		}
	}

	private void OnTimeout(object state)
	{
		try
		{
			Exception = new TimeoutException();
			m_cts?.Cancel();
			OperationCompleted();
		}
		catch (Exception exception)
		{
			Utils.LogTrace(exception, "Unexpected error handling timeout for ChannelAsyncResult operation.");
		}
	}
}
