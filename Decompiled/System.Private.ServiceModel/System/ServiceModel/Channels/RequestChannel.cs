using System.Collections.Generic;
using System.Runtime;
using System.ServiceModel.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace System.ServiceModel.Channels;

public abstract class RequestChannel : ChannelBase, IRequestChannel, IChannel, ICommunicationObject, IAsyncRequestChannel, IAsyncCommunicationObject
{
	private List<IRequestBase> _outstandingRequests = new List<IRequestBase>();

	private TaskCompletionSource<object> _closedTcs;

	private bool _closed;

	private int _outstandRequestCloseCount;

	protected bool ManualAddressing { get; }

	public EndpointAddress RemoteAddress { get; }

	public Uri Via { get; }

	protected RequestChannel(ChannelManagerBase channelFactory, EndpointAddress to, Uri via, bool manualAddressing)
		: base(channelFactory)
	{
		if (!manualAddressing && to == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("to");
		}
		ManualAddressing = manualAddressing;
		RemoteAddress = to;
		Via = via;
	}

	protected void AbortPendingRequests()
	{
		IRequestBase[] array = CopyPendingRequests(createTcsIfNecessary: false);
		if (array != null)
		{
			IRequestBase[] array2 = array;
			foreach (IRequestBase requestBase in array2)
			{
				requestBase.Abort(this);
			}
		}
	}

	private void FinishClose()
	{
		lock (_outstandingRequests)
		{
			if (!_closed)
			{
				_closed = true;
				TaskCompletionSource<object> closedTcs = _closedTcs;
				if (closedTcs != null)
				{
					closedTcs.TrySetResult(null);
					_closedTcs = null;
				}
			}
		}
	}

	private IRequestBase[] SetupWaitForPendingRequests()
	{
		return CopyPendingRequests(createTcsIfNecessary: true);
	}

	protected void WaitForPendingRequests(TimeSpan timeout)
	{
		WaitForPendingRequestsAsync(timeout).Wait();
	}

	protected internal async Task WaitForPendingRequestsAsync(TimeSpan timeout)
	{
		IRequestBase[] pendingRequests = SetupWaitForPendingRequests();
		if (pendingRequests != null && !(await _closedTcs.Task.AwaitWithTimeout(timeout)))
		{
			IRequestBase[] array = pendingRequests;
			foreach (IRequestBase requestBase in array)
			{
				requestBase.Abort(this);
			}
		}
		FinishClose();
	}

	private IRequestBase[] CopyPendingRequests(bool createTcsIfNecessary)
	{
		IRequestBase[] array = null;
		lock (_outstandingRequests)
		{
			if (_outstandingRequests.Count > 0)
			{
				array = new IRequestBase[_outstandingRequests.Count];
				_outstandingRequests.CopyTo(array);
				_outstandingRequests.Clear();
				if (createTcsIfNecessary && _closedTcs == null)
				{
					_closedTcs = new TaskCompletionSource<object>();
				}
			}
		}
		return array;
	}

	protected void FaultPendingRequests()
	{
		IRequestBase[] array = CopyPendingRequests(createTcsIfNecessary: false);
		if (array != null)
		{
			IRequestBase[] array2 = array;
			foreach (IRequestBase requestBase in array2)
			{
				requestBase.Fault(this);
			}
		}
	}

	public override T GetProperty<T>()
	{
		if (typeof(T) == typeof(IRequestChannel))
		{
			return (T)(object)this;
		}
		T property = base.GetProperty<T>();
		if (property != null)
		{
			return property;
		}
		return null;
	}

	protected override void OnAbort()
	{
		AbortPendingRequests();
	}

	private void ReleaseRequest(IRequestBase request)
	{
		try
		{
			request?.OnReleaseRequest();
		}
		finally
		{
			lock (_outstandingRequests)
			{
				_outstandingRequests.Remove(request);
				if (Interlocked.Decrement(ref _outstandRequestCloseCount) == 0 && _closedTcs != null && !_closed)
				{
					_closedTcs?.TrySetResult(null);
				}
			}
		}
	}

	private void TrackRequest(IRequestBase request)
	{
		lock (_outstandingRequests)
		{
			ThrowIfDisposedOrNotOpen();
			_outstandingRequests.Add(request);
			Interlocked.Increment(ref _outstandRequestCloseCount);
		}
	}

	public IAsyncResult BeginRequest(Message message, AsyncCallback callback, object state)
	{
		return BeginRequest(message, base.DefaultSendTimeout, callback, state);
	}

	public IAsyncResult BeginRequest(Message message, TimeSpan timeout, AsyncCallback callback, object state)
	{
		return RequestAsyncInternal(message, timeout).ToApm(callback, state);
	}

	protected abstract IAsyncRequest CreateAsyncRequest(Message message);

	public Message EndRequest(IAsyncResult result)
	{
		return result.ToApmEnd<Message>();
	}

	public Message Request(Message message)
	{
		return Request(message, base.DefaultSendTimeout);
	}

	public Message Request(Message message, TimeSpan timeout)
	{
		return RequestAsyncInternal(message, timeout).WaitForCompletionNoSpin();
	}

	public Task<Message> RequestAsync(Message message)
	{
		return RequestAsync(message, base.DefaultSendTimeout);
	}

	private async Task<Message> RequestAsyncInternal(Message message, TimeSpan timeout)
	{
		await TaskHelpers.EnsureDefaultTaskScheduler();
		return await RequestAsync(message, timeout);
	}

	public async Task<Message> RequestAsync(Message message, TimeSpan timeout)
	{
		if (message == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("message");
		}
		if (timeout < TimeSpan.Zero)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentOutOfRangeException("timeout", timeout, System.SR.SFxTimeoutOutOfRange0));
		}
		ThrowIfDisposedOrNotOpen();
		AddHeadersTo(message);
		IAsyncRequest request = CreateAsyncRequest(message);
		TrackRequest(request);
		try
		{
			TimeoutHelper timeoutHelper = new TimeoutHelper(timeout);
			TimeSpan savedTimeout = timeoutHelper.RemainingTime();
			try
			{
				await request.SendRequestAsync(message, timeoutHelper);
			}
			catch (TimeoutException innerException)
			{
				throw TraceUtility.ThrowHelperError(new TimeoutException(System.SR.Format(System.SR.RequestChannelSendTimedOut, savedTimeout), innerException), message);
			}
			savedTimeout = timeoutHelper.RemainingTime();
			try
			{
				return await request.ReceiveReplyAsync(timeoutHelper);
			}
			catch (TimeoutException innerException2)
			{
				throw TraceUtility.ThrowHelperError(new TimeoutException(System.SR.Format(System.SR.RequestChannelWaitForReplyTimedOut, savedTimeout), innerException2), message);
			}
		}
		finally
		{
			ReleaseRequest(request);
		}
	}

	protected virtual void AddHeadersTo(Message message)
	{
		if (!ManualAddressing && RemoteAddress != null)
		{
			RemoteAddress.ApplyTo(message);
		}
	}
}
