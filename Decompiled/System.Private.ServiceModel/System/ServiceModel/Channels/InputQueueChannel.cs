using System.Runtime;
using System.ServiceModel.Diagnostics;
using System.Threading.Tasks;

namespace System.ServiceModel.Channels;

internal abstract class InputQueueChannel<TDisposable> : ChannelBase where TDisposable : class, IDisposable
{
	private InputQueue<TDisposable> _inputQueue;

	public int InternalPendingItems => _inputQueue.PendingCount;

	public int PendingItems
	{
		get
		{
			ThrowIfDisposedOrNotOpen();
			return InternalPendingItems;
		}
	}

	protected InputQueueChannel(ChannelManagerBase channelManager)
		: base(channelManager)
	{
		_inputQueue = TraceUtility.CreateInputQueue<TDisposable>();
	}

	public void EnqueueAndDispatch(TDisposable item)
	{
		EnqueueAndDispatch(item, null);
	}

	public void EnqueueAndDispatch(TDisposable item, Action dequeuedCallback, bool canDispatchOnThisThread)
	{
		OnEnqueueItem(item);
		_inputQueue.EnqueueAndDispatch(item, dequeuedCallback, canDispatchOnThisThread);
	}

	public void EnqueueAndDispatch(Exception exception, Action dequeuedCallback, bool canDispatchOnThisThread)
	{
		_inputQueue.EnqueueAndDispatch(exception, dequeuedCallback, canDispatchOnThisThread);
	}

	public void EnqueueAndDispatch(TDisposable item, Action dequeuedCallback)
	{
		OnEnqueueItem(item);
		_inputQueue.EnqueueAndDispatch(item, dequeuedCallback);
	}

	public bool EnqueueWithoutDispatch(Exception exception, Action dequeuedCallback)
	{
		return _inputQueue.EnqueueWithoutDispatch(exception, dequeuedCallback);
	}

	public bool EnqueueWithoutDispatch(TDisposable item, Action dequeuedCallback)
	{
		OnEnqueueItem(item);
		return _inputQueue.EnqueueWithoutDispatch(item, dequeuedCallback);
	}

	public void Dispatch()
	{
		_inputQueue.Dispatch();
	}

	public void Shutdown()
	{
		_inputQueue.Shutdown();
	}

	protected override void OnFaulted()
	{
		base.OnFaulted();
		_inputQueue.Shutdown(() => GetPendingException());
	}

	protected virtual void OnEnqueueItem(TDisposable item)
	{
	}

	protected async Task<(bool dequeued, TDisposable item)> DequeueAsync(TimeSpan timeout)
	{
		ThrowIfNotOpened();
		var (item, val) = await _inputQueue.TryDequeueAsync(timeout);
		if (val == null)
		{
			ThrowIfFaulted();
			ThrowIfAborted();
		}
		return (dequeued: item, item: val);
	}

	protected async Task<bool> WaitForItemAsync(TimeSpan timeout)
	{
		ThrowIfNotOpened();
		bool result = await _inputQueue.WaitForItemAsync(timeout);
		ThrowIfFaulted();
		ThrowIfAborted();
		return result;
	}

	protected override void OnClosing()
	{
		base.OnClosing();
		_inputQueue.Shutdown(() => GetPendingException());
	}

	protected override void OnAbort()
	{
		_inputQueue.Close();
	}

	protected override void OnClose(TimeSpan timeout)
	{
		_inputQueue.Close();
	}

	protected internal override Task OnCloseAsync(TimeSpan timeout)
	{
		_inputQueue.Close();
		return Task.CompletedTask;
	}

	protected override IAsyncResult OnBeginClose(TimeSpan timeout, AsyncCallback callback, object state)
	{
		_inputQueue.Close();
		return new CompletedAsyncResult(callback, state);
	}

	protected override void OnEndClose(IAsyncResult result)
	{
		CompletedAsyncResult.End(result);
	}
}
