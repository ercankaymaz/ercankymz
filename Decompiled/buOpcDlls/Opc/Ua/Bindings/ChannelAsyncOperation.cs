using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;

namespace Opc.Ua.Bindings;

[ComVisible(true)]
public class ChannelAsyncOperation<T> : IAsyncResult, IDisposable
{
	private readonly object m_lock = new object();

	private AsyncCallback m_callback;

	private object m_asyncState;

	private bool m_synchronous;

	private bool m_completed;

	private ManualResetEvent m_event;

	private TaskCompletionSource<bool> m_tcs;

	private T m_response;

	private ServiceResult m_error;

	private Timer m_timer;

	private Dictionary<string, object> m_properties;

	public IDictionary<string, object> Properties
	{
		get
		{
			lock (m_lock)
			{
				if (m_properties == null)
				{
					m_properties = new Dictionary<string, object>();
				}
				return m_properties;
			}
		}
	}

	public object AsyncState
	{
		get
		{
			lock (m_lock)
			{
				return m_asyncState;
			}
		}
	}

	public WaitHandle AsyncWaitHandle
	{
		get
		{
			lock (m_lock)
			{
				if (m_event == null)
				{
					m_event = new ManualResetEvent(m_completed);
				}
				return m_event;
			}
		}
	}

	public bool CompletedSynchronously
	{
		get
		{
			lock (m_lock)
			{
				return m_synchronous;
			}
		}
	}

	public bool IsCompleted
	{
		get
		{
			lock (m_lock)
			{
				return m_completed;
			}
		}
	}

	public ChannelAsyncOperation(int timeout, AsyncCallback callback, object asyncState)
	{
		m_callback = callback;
		m_asyncState = asyncState;
		m_synchronous = false;
		m_completed = false;
		if (timeout > 0 && timeout != int.MaxValue)
		{
			m_timer = new Timer(OnTimeout, null, timeout, -1);
		}
	}

	public void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	protected virtual void Dispose(bool disposing)
	{
		if (!disposing)
		{
			return;
		}
		lock (m_lock)
		{
			Utils.SilentDispose(m_timer);
			m_timer = null;
			if (m_event != null)
			{
				m_event.Set();
				m_event.Dispose();
				m_event = null;
			}
			if (m_tcs != null)
			{
				if (!m_tcs.Task.IsCompleted)
				{
					m_tcs.TrySetCanceled();
				}
				m_tcs = null;
			}
		}
	}

	public bool Complete(T response)
	{
		return InternalComplete(doNotBlock: true, response);
	}

	public bool Complete(bool doNotBlock, T response)
	{
		return InternalComplete(doNotBlock, response);
	}

	public bool Fault(ServiceResult error)
	{
		return InternalComplete(doNotBlock: true, error);
	}

	public bool Fault(bool doNotBlock, ServiceResult error)
	{
		return InternalComplete(doNotBlock, error);
	}

	public bool Fault(uint code, string format, params object[] args)
	{
		return InternalComplete(doNotBlock: true, ServiceResult.Create(code, format, args));
	}

	public bool Fault(bool doNotBlock, uint code, string format, params object[] args)
	{
		return InternalComplete(doNotBlock, ServiceResult.Create(code, format, args));
	}

	public bool Fault(Exception e, uint defaultCode, string format, params object[] args)
	{
		return InternalComplete(doNotBlock: true, ServiceResult.Create(e, defaultCode, format, args));
	}

	public bool Fault(bool doNotBlock, Exception e, uint defaultCode, string format, params object[] args)
	{
		return InternalComplete(doNotBlock, ServiceResult.Create(e, defaultCode, format, args));
	}

	public T End(int timeout, bool throwOnError = true)
	{
		bool flag = false;
		lock (m_lock)
		{
			flag = !m_completed;
			if (flag)
			{
				m_event = new ManualResetEvent(initialState: false);
			}
		}
		if (flag)
		{
			try
			{
				if (!m_event.WaitOne(timeout) && throwOnError)
				{
					throw new ServiceResultException(2156134400u);
				}
			}
			finally
			{
				lock (m_lock)
				{
					if (m_event != null)
					{
						m_event.Dispose();
						m_event = null;
					}
				}
			}
		}
		lock (m_lock)
		{
			if (m_error != null && throwOnError)
			{
				throw new ServiceResultException(m_error);
			}
			return m_response;
		}
	}

	public async Task<T> EndAsync(int timeout, bool throwOnError = true, CancellationToken ct = default(CancellationToken))
	{
		bool flag = false;
		lock (m_lock)
		{
			flag = !m_completed;
			if (flag)
			{
				m_tcs = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
			}
		}
		if (flag)
		{
			bool badRequestInterrupted = false;
			try
			{
				Task<bool> task = m_tcs.Task;
				if (timeout != int.MaxValue || ct != default(CancellationToken))
				{
					Task task2 = await Task.WhenAny(m_tcs.Task, Task.Delay(timeout, ct)).ConfigureAwait(continueOnCapturedContext: false);
					if (m_tcs.Task == task2)
					{
						if (!m_tcs.Task.Result)
						{
							badRequestInterrupted = true;
						}
					}
					else
					{
						m_tcs.TrySetCanceled(ct);
						badRequestInterrupted = true;
					}
				}
				else if (!(await task.ConfigureAwait(continueOnCapturedContext: false)))
				{
					badRequestInterrupted = true;
				}
			}
			catch (TimeoutException)
			{
				badRequestInterrupted = true;
			}
			catch (TaskCanceledException)
			{
				badRequestInterrupted = true;
			}
			finally
			{
				lock (m_lock)
				{
					m_tcs = null;
				}
			}
			if (badRequestInterrupted && throwOnError)
			{
				throw new ServiceResultException(2156134400u);
			}
		}
		lock (m_lock)
		{
			if (m_error != null && throwOnError)
			{
				throw new ServiceResultException(m_error);
			}
			return m_response;
		}
	}

	private void OnTimeout(object state)
	{
		if (m_timer != null)
		{
			InternalComplete(doNotBlock: false, new ServiceResult(2156199936u));
		}
	}

	protected virtual bool InternalComplete(bool doNotBlock, object result)
	{
		lock (m_lock)
		{
			if (m_completed)
			{
				return false;
			}
			if (result is T)
			{
				m_response = (T)result;
			}
			else
			{
				m_error = result as ServiceResult;
			}
			m_completed = true;
			if (m_timer != null)
			{
				m_timer.Dispose();
				m_timer = null;
			}
			if (m_event != null)
			{
				m_event.Set();
			}
			if (m_tcs != null)
			{
				m_tcs.TrySetResult(result: true);
			}
		}
		if (m_callback != null)
		{
			if (doNotBlock)
			{
				Task.Run(delegate
				{
					m_callback(this);
				});
			}
			else
			{
				try
				{
					m_callback(this);
				}
				catch (Exception exception)
				{
					Utils.LogError(exception, "ClientChannel: Unexpected error invoking AsyncCallback.");
				}
			}
		}
		return true;
	}
}
