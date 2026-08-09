using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace System.Runtime;

internal sealed class InputQueue<T> : IDisposable where T : class
{
	private enum QueueState
	{
		Open,
		Shutdown,
		Closed
	}

	private interface IQueueReader
	{
		void Set(Item item);
	}

	private interface IQueueWaiter
	{
		void Set(bool itemAvailable);
	}

	internal struct Item
	{
		private T _value;

		public Action DequeuedCallback { get; }

		public Exception Exception { get; }

		public T Value => _value;

		public Item(T value, Action dequeuedCallback)
			: this(value, null, dequeuedCallback)
		{
		}

		public Item(Exception exception, Action dequeuedCallback)
			: this(null, exception, dequeuedCallback)
		{
		}

		private Item(T value, Exception exception, Action dequeuedCallback)
		{
			_value = value;
			Exception = exception;
			DequeuedCallback = dequeuedCallback;
		}

		public T GetValue()
		{
			if (Exception != null)
			{
				throw Fx.Exception.AsError(Exception);
			}
			return _value;
		}
	}

	internal class AsyncQueueReader : AsyncResult, IQueueReader
	{
		private static Action<object> s_timerCallback = TimerCallback;

		private bool _expired;

		private InputQueue<T> _inputQueue;

		private T _item;

		private Timer _timer;

		public AsyncQueueReader(InputQueue<T> inputQueue, TimeSpan timeout, AsyncCallback callback, object state)
			: base(callback, state)
		{
			if (inputQueue.AsyncCallbackGenerator != null)
			{
				base.VirtualCallback = inputQueue.AsyncCallbackGenerator();
			}
			_inputQueue = inputQueue;
			if (timeout != TimeSpan.MaxValue)
			{
				_timer = new Timer(s_timerCallback.Invoke, this, timeout, TimeSpan.FromMilliseconds(-1.0));
			}
		}

		public static bool End(IAsyncResult result, out T value)
		{
			AsyncQueueReader asyncQueueReader = AsyncResult.End<AsyncQueueReader>(result);
			if (asyncQueueReader._expired)
			{
				value = null;
				return false;
			}
			value = asyncQueueReader._item;
			return true;
		}

		public void Set(Item item)
		{
			_item = item.Value;
			if (_timer != null)
			{
				_timer.Change(TimeSpan.FromMilliseconds(-1.0), TimeSpan.FromMilliseconds(-1.0));
			}
			Complete(completedSynchronously: false, item.Exception);
		}

		private static void TimerCallback(object state)
		{
			AsyncQueueReader asyncQueueReader = (AsyncQueueReader)state;
			if (asyncQueueReader._inputQueue.RemoveReader(asyncQueueReader))
			{
				asyncQueueReader._expired = true;
				asyncQueueReader.Complete(completedSynchronously: false);
			}
		}
	}

	internal class AsyncQueueWaiter : AsyncResult, IQueueWaiter
	{
		private static Action<object> s_timerCallback = TimerCallback;

		private bool _itemAvailable;

		private Timer _timer;

		private object ThisLock { get; } = new object();

		public AsyncQueueWaiter(TimeSpan timeout, AsyncCallback callback, object state)
			: base(callback, state)
		{
			if (timeout != TimeSpan.MaxValue)
			{
				_timer = new Timer(s_timerCallback.Invoke, this, timeout, TimeSpan.FromMilliseconds(-1.0));
			}
		}

		public static bool End(IAsyncResult result)
		{
			AsyncQueueWaiter asyncQueueWaiter = AsyncResult.End<AsyncQueueWaiter>(result);
			return asyncQueueWaiter._itemAvailable;
		}

		public void Set(bool itemAvailable)
		{
			bool flag;
			lock (ThisLock)
			{
				flag = _timer == null || _timer.Change(TimeSpan.FromMilliseconds(-1.0), TimeSpan.FromMilliseconds(-1.0));
				_itemAvailable = itemAvailable;
			}
			if (flag)
			{
				Complete(completedSynchronously: false);
			}
		}

		private static void TimerCallback(object state)
		{
			AsyncQueueWaiter asyncQueueWaiter = (AsyncQueueWaiter)state;
			asyncQueueWaiter.Complete(completedSynchronously: false);
		}
	}

	internal class ItemQueue
	{
		private int _head;

		private Item[] _items;

		private int _pendingCount;

		public bool HasAnyItem => ItemCount > 0;

		public bool HasAvailableItem => ItemCount > _pendingCount;

		public int ItemCount { get; private set; }

		public ItemQueue()
		{
			_items = new Item[1];
		}

		public Item DequeueAnyItem()
		{
			if (_pendingCount == ItemCount)
			{
				_pendingCount--;
			}
			return DequeueItemCore();
		}

		public Item DequeueAvailableItem()
		{
			Fx.AssertAndThrow(ItemCount != _pendingCount, "ItemQueue does not contain any available items");
			return DequeueItemCore();
		}

		public void EnqueueAvailableItem(Item item)
		{
			EnqueueItemCore(item);
		}

		public void EnqueuePendingItem(Item item)
		{
			EnqueueItemCore(item);
			_pendingCount++;
		}

		public void MakePendingItemAvailable()
		{
			Fx.AssertAndThrow(_pendingCount != 0, "ItemQueue does not contain any pending items");
			_pendingCount--;
		}

		private Item DequeueItemCore()
		{
			Fx.AssertAndThrow(ItemCount != 0, "ItemQueue does not contain any items");
			Item result = _items[_head];
			_items[_head] = default(Item);
			ItemCount--;
			_head = (_head + 1) % _items.Length;
			return result;
		}

		private void EnqueueItemCore(Item item)
		{
			if (ItemCount == _items.Length)
			{
				Item[] array = new Item[_items.Length * 2];
				for (int i = 0; i < ItemCount; i++)
				{
					array[i] = _items[(_head + i) % _items.Length];
				}
				_head = 0;
				_items = array;
			}
			int num = (_head + ItemCount) % _items.Length;
			_items[num] = item;
			ItemCount++;
		}
	}

	internal class WaitQueueReader : IQueueReader
	{
		private Exception _exception;

		private InputQueue<T> _inputQueue;

		private T _item;

		private ManualResetEvent _waitEvent;

		public WaitQueueReader(InputQueue<T> inputQueue)
		{
			_inputQueue = inputQueue;
			_waitEvent = new ManualResetEvent(initialState: false);
		}

		public void Set(Item item)
		{
			lock (this)
			{
				_exception = item.Exception;
				_item = item.Value;
				_waitEvent.Set();
			}
		}

		public bool Wait(TimeSpan timeout, out T value)
		{
			bool flag = false;
			try
			{
				if (!TimeoutHelper.WaitOne(_waitEvent, timeout))
				{
					if (_inputQueue.RemoveReader(this))
					{
						value = null;
						flag = true;
						return false;
					}
					_waitEvent.WaitOne();
				}
				flag = true;
			}
			finally
			{
				if (flag)
				{
					_waitEvent.Dispose();
				}
			}
			if (_exception != null)
			{
				throw Fx.Exception.AsError(_exception);
			}
			value = _item;
			return true;
		}
	}

	internal class TaskQueueReader : IQueueReader
	{
		private TaskCompletionSource<T> _tcs = new TaskCompletionSource<T>();

		private InputQueue<T> _inputQueue;

		public TaskQueueReader(InputQueue<T> inputQueue)
		{
			_inputQueue = inputQueue;
		}

		public void Set(Item item)
		{
			if (item.Exception != null)
			{
				_tcs.TrySetException(item.Exception);
			}
			else
			{
				_tcs.TrySetResult(item.Value);
			}
		}

		public async Task<(bool, T)> WaitAsync(TimeSpan timeout)
		{
			if (!(await _tcs.Task.AwaitWithTimeout(timeout)))
			{
				if (_inputQueue.RemoveReader(this))
				{
					return (false, null);
				}
				await _tcs.Task;
			}
			return (true, await _tcs.Task);
		}
	}

	internal class WaitQueueWaiter : IQueueWaiter
	{
		private bool _itemAvailable;

		private ManualResetEvent _waitEvent;

		public WaitQueueWaiter()
		{
			_waitEvent = new ManualResetEvent(initialState: false);
		}

		public void Set(bool itemAvailable)
		{
			lock (this)
			{
				_itemAvailable = itemAvailable;
				_waitEvent.Set();
			}
		}

		public bool Wait(TimeSpan timeout)
		{
			if (!TimeoutHelper.WaitOne(_waitEvent, timeout))
			{
				return false;
			}
			return _itemAvailable;
		}
	}

	internal class TaskQueueWaiter : IQueueWaiter
	{
		private TaskCompletionSource<bool> _tcs;

		public TaskQueueWaiter()
		{
			_tcs = new TaskCompletionSource<bool>();
		}

		public void Set(bool itemAvailable)
		{
			lock (this)
			{
				_tcs.TrySetResult(itemAvailable);
			}
		}

		public async Task<bool> WaitAsync(TimeSpan timeout)
		{
			if (!(await _tcs.Task.AwaitWithTimeout(timeout)))
			{
				return false;
			}
			return await _tcs.Task;
		}
	}

	private static Action<object> s_completeOutstandingReadersCallback;

	private static Action<object> s_completeWaitersFalseCallback;

	private static Action<object> s_completeWaitersTrueCallback;

	private static Action<object> s_onDispatchCallback;

	private static Action<object> s_onInvokeDequeuedCallback;

	private QueueState _queueState;

	private ItemQueue _itemQueue;

	private Queue<IQueueReader> _readerQueue;

	private List<IQueueWaiter> _waiterList;

	public int PendingCount
	{
		get
		{
			lock (ThisLock)
			{
				return _itemQueue.ItemCount;
			}
		}
	}

	public Action<T> DisposeItemCallback { get; set; }

	private Func<Action<AsyncCallback, IAsyncResult>> AsyncCallbackGenerator { get; set; }

	private object ThisLock => _itemQueue;

	public InputQueue()
	{
		_itemQueue = new ItemQueue();
		_readerQueue = new Queue<IQueueReader>();
		_waiterList = new List<IQueueWaiter>();
		_queueState = QueueState.Open;
	}

	public InputQueue(Func<Action<AsyncCallback, IAsyncResult>> asyncCallbackGenerator)
		: this()
	{
		AsyncCallbackGenerator = asyncCallbackGenerator;
	}

	public IAsyncResult BeginDequeue(TimeSpan timeout, AsyncCallback callback, object state)
	{
		Item item = default(Item);
		lock (ThisLock)
		{
			if (_queueState == QueueState.Open)
			{
				if (!_itemQueue.HasAvailableItem)
				{
					AsyncQueueReader asyncQueueReader = new AsyncQueueReader(this, timeout, callback, state);
					_readerQueue.Enqueue(asyncQueueReader);
					return asyncQueueReader;
				}
				item = _itemQueue.DequeueAvailableItem();
			}
			else if (_queueState == QueueState.Shutdown)
			{
				if (_itemQueue.HasAvailableItem)
				{
					item = _itemQueue.DequeueAvailableItem();
				}
				else if (_itemQueue.HasAnyItem)
				{
					AsyncQueueReader asyncQueueReader2 = new AsyncQueueReader(this, timeout, callback, state);
					_readerQueue.Enqueue(asyncQueueReader2);
					return asyncQueueReader2;
				}
			}
		}
		InvokeDequeuedCallback(item.DequeuedCallback);
		return new CompletedAsyncResult<T>(item.GetValue(), callback, state);
	}

	public IAsyncResult BeginWaitForItem(TimeSpan timeout, AsyncCallback callback, object state)
	{
		lock (ThisLock)
		{
			if (_queueState == QueueState.Open)
			{
				if (!_itemQueue.HasAvailableItem)
				{
					AsyncQueueWaiter asyncQueueWaiter = new AsyncQueueWaiter(timeout, callback, state);
					_waiterList.Add(asyncQueueWaiter);
					return asyncQueueWaiter;
				}
			}
			else if (_queueState == QueueState.Shutdown && !_itemQueue.HasAvailableItem && _itemQueue.HasAnyItem)
			{
				AsyncQueueWaiter asyncQueueWaiter2 = new AsyncQueueWaiter(timeout, callback, state);
				_waiterList.Add(asyncQueueWaiter2);
				return asyncQueueWaiter2;
			}
		}
		return new CompletedAsyncResult<bool>(data: true, callback, state);
	}

	public void Close()
	{
		Dispose();
	}

	public T Dequeue(TimeSpan timeout)
	{
		if (!Dequeue(timeout, out var value))
		{
			throw Fx.Exception.AsError(new TimeoutException(InternalSR.TimeoutInputQueueDequeue(timeout)));
		}
		return value;
	}

	public async Task<T> DequeueAsync(TimeSpan timeout)
	{
		var (flag, result) = await TryDequeueAsync(timeout);
		if (!flag)
		{
			throw Fx.Exception.AsError(new TimeoutException(InternalSR.TimeoutInputQueueDequeue(timeout)));
		}
		return result;
	}

	public async Task<(bool, T)> TryDequeueAsync(TimeSpan timeout)
	{
		TaskQueueReader taskQueueReader = null;
		Item item = default(Item);
		lock (ThisLock)
		{
			if (_queueState == QueueState.Open)
			{
				if (_itemQueue.HasAvailableItem)
				{
					item = _itemQueue.DequeueAvailableItem();
				}
				else
				{
					taskQueueReader = new TaskQueueReader(this);
					_readerQueue.Enqueue(taskQueueReader);
				}
			}
			else
			{
				if (_queueState != QueueState.Shutdown)
				{
					return (true, null);
				}
				if (_itemQueue.HasAvailableItem)
				{
					item = _itemQueue.DequeueAvailableItem();
				}
				else
				{
					if (!_itemQueue.HasAnyItem)
					{
						return (true, null);
					}
					taskQueueReader = new TaskQueueReader(this);
					_readerQueue.Enqueue(taskQueueReader);
				}
			}
		}
		if (taskQueueReader != null)
		{
			return await taskQueueReader.WaitAsync(timeout);
		}
		InvokeDequeuedCallback(item.DequeuedCallback);
		return (true, item.GetValue());
	}

	public bool Dequeue(TimeSpan timeout, out T value)
	{
		WaitQueueReader waitQueueReader = null;
		Item item = default(Item);
		lock (ThisLock)
		{
			if (_queueState == QueueState.Open)
			{
				if (_itemQueue.HasAvailableItem)
				{
					item = _itemQueue.DequeueAvailableItem();
				}
				else
				{
					waitQueueReader = new WaitQueueReader(this);
					_readerQueue.Enqueue(waitQueueReader);
				}
			}
			else
			{
				if (_queueState != QueueState.Shutdown)
				{
					value = null;
					return true;
				}
				if (_itemQueue.HasAvailableItem)
				{
					item = _itemQueue.DequeueAvailableItem();
				}
				else
				{
					if (!_itemQueue.HasAnyItem)
					{
						value = null;
						return true;
					}
					waitQueueReader = new WaitQueueReader(this);
					_readerQueue.Enqueue(waitQueueReader);
				}
			}
		}
		if (waitQueueReader != null)
		{
			return waitQueueReader.Wait(timeout, out value);
		}
		InvokeDequeuedCallback(item.DequeuedCallback);
		value = item.GetValue();
		return true;
	}

	public void Dispatch()
	{
		IQueueReader queueReader = null;
		Item item = default(Item);
		IQueueReader[] array = null;
		IQueueWaiter[] waiters = null;
		bool itemAvailable = true;
		lock (ThisLock)
		{
			itemAvailable = _queueState != QueueState.Closed && _queueState != QueueState.Shutdown;
			GetWaiters(out waiters);
			if (_queueState != QueueState.Closed)
			{
				_itemQueue.MakePendingItemAvailable();
				if (_readerQueue.Count > 0)
				{
					item = _itemQueue.DequeueAvailableItem();
					queueReader = _readerQueue.Dequeue();
					if (_queueState == QueueState.Shutdown && _readerQueue.Count > 0 && _itemQueue.ItemCount == 0)
					{
						array = new IQueueReader[_readerQueue.Count];
						_readerQueue.CopyTo(array, 0);
						_readerQueue.Clear();
						itemAvailable = false;
					}
				}
			}
		}
		if (array != null)
		{
			if (s_completeOutstandingReadersCallback == null)
			{
				s_completeOutstandingReadersCallback = CompleteOutstandingReadersCallback;
			}
			ActionItem.Schedule(s_completeOutstandingReadersCallback, array);
		}
		if (waiters != null)
		{
			CompleteWaitersLater(itemAvailable, waiters);
		}
		if (queueReader != null)
		{
			InvokeDequeuedCallback(item.DequeuedCallback);
			queueReader.Set(item);
		}
	}

	public bool EndDequeue(IAsyncResult result, out T value)
	{
		if (result is CompletedAsyncResult<T>)
		{
			value = CompletedAsyncResult<T>.End(result);
			return true;
		}
		return AsyncQueueReader.End(result, out value);
	}

	public T EndDequeue(IAsyncResult result)
	{
		if (!EndDequeue(result, out var value))
		{
			throw Fx.Exception.AsError(new TimeoutException());
		}
		return value;
	}

	public bool EndWaitForItem(IAsyncResult result)
	{
		if (result is CompletedAsyncResult<bool>)
		{
			return CompletedAsyncResult<bool>.End(result);
		}
		return AsyncQueueWaiter.End(result);
	}

	public void EnqueueAndDispatch(T item)
	{
		EnqueueAndDispatch(item, null);
	}

	public void EnqueueAndDispatch(T item, Action dequeuedCallback)
	{
		EnqueueAndDispatch(item, dequeuedCallback, canDispatchOnThisThread: true);
	}

	public void EnqueueAndDispatch(Exception exception, Action dequeuedCallback, bool canDispatchOnThisThread)
	{
		EnqueueAndDispatch(new Item(exception, dequeuedCallback), canDispatchOnThisThread);
	}

	public void EnqueueAndDispatch(T item, Action dequeuedCallback, bool canDispatchOnThisThread)
	{
		EnqueueAndDispatch(new Item(item, dequeuedCallback), canDispatchOnThisThread);
	}

	public bool EnqueueWithoutDispatch(T item, Action dequeuedCallback)
	{
		return EnqueueWithoutDispatch(new Item(item, dequeuedCallback));
	}

	public bool EnqueueWithoutDispatch(Exception exception, Action dequeuedCallback)
	{
		return EnqueueWithoutDispatch(new Item(exception, dequeuedCallback));
	}

	public void Shutdown()
	{
		Shutdown(null);
	}

	public void Shutdown(Func<Exception> pendingExceptionGenerator)
	{
		IQueueReader[] array = null;
		lock (ThisLock)
		{
			if (_queueState == QueueState.Shutdown || _queueState == QueueState.Closed)
			{
				return;
			}
			_queueState = QueueState.Shutdown;
			if (_readerQueue.Count > 0 && _itemQueue.ItemCount == 0)
			{
				array = new IQueueReader[_readerQueue.Count];
				_readerQueue.CopyTo(array, 0);
				_readerQueue.Clear();
			}
		}
		if (array != null)
		{
			for (int i = 0; i < array.Length; i++)
			{
				Exception exception = pendingExceptionGenerator?.Invoke();
				array[i].Set(new Item(exception, null));
			}
		}
	}

	public bool WaitForItem(TimeSpan timeout)
	{
		WaitQueueWaiter waitQueueWaiter = null;
		bool flag = false;
		lock (ThisLock)
		{
			if (_queueState == QueueState.Open)
			{
				if (_itemQueue.HasAvailableItem)
				{
					flag = true;
				}
				else
				{
					waitQueueWaiter = new WaitQueueWaiter();
					_waiterList.Add(waitQueueWaiter);
				}
			}
			else
			{
				if (_queueState != QueueState.Shutdown)
				{
					return true;
				}
				if (_itemQueue.HasAvailableItem)
				{
					flag = true;
				}
				else
				{
					if (!_itemQueue.HasAnyItem)
					{
						return true;
					}
					waitQueueWaiter = new WaitQueueWaiter();
					_waiterList.Add(waitQueueWaiter);
				}
			}
		}
		return waitQueueWaiter?.Wait(timeout) ?? flag;
	}

	public Task<bool> WaitForItemAsync(TimeSpan timeout)
	{
		TaskQueueWaiter taskQueueWaiter = null;
		bool result = false;
		lock (ThisLock)
		{
			if (_queueState == QueueState.Open)
			{
				if (_itemQueue.HasAvailableItem)
				{
					result = true;
				}
				else
				{
					taskQueueWaiter = new TaskQueueWaiter();
					_waiterList.Add(taskQueueWaiter);
				}
			}
			else
			{
				if (_queueState != QueueState.Shutdown)
				{
					return Task.FromResult(result: true);
				}
				if (_itemQueue.HasAvailableItem)
				{
					result = true;
				}
				else
				{
					if (!_itemQueue.HasAnyItem)
					{
						return Task.FromResult(result: true);
					}
					taskQueueWaiter = new TaskQueueWaiter();
					_waiterList.Add(taskQueueWaiter);
				}
			}
		}
		if (taskQueueWaiter != null)
		{
			return taskQueueWaiter.WaitAsync(timeout);
		}
		return Task.FromResult(result);
	}

	public void Dispose()
	{
		bool flag = false;
		lock (ThisLock)
		{
			if (_queueState != QueueState.Closed)
			{
				_queueState = QueueState.Closed;
				flag = true;
			}
		}
		if (flag)
		{
			while (_readerQueue.Count > 0)
			{
				IQueueReader queueReader = _readerQueue.Dequeue();
				queueReader.Set(default(Item));
			}
			while (_itemQueue.HasAnyItem)
			{
				Item item = _itemQueue.DequeueAnyItem();
				DisposeItem(item);
				InvokeDequeuedCallback(item.DequeuedCallback);
			}
		}
	}

	private void DisposeItem(Item item)
	{
		T value = item.Value;
		if (value != null)
		{
			if (value is IDisposable)
			{
				((IDisposable)value).Dispose();
			}
			else
			{
				DisposeItemCallback?.Invoke(value);
			}
		}
	}

	private static void CompleteOutstandingReadersCallback(object state)
	{
		IQueueReader[] array = (IQueueReader[])state;
		for (int i = 0; i < array.Length; i++)
		{
			array[i].Set(default(Item));
		}
	}

	private static void CompleteWaiters(bool itemAvailable, IQueueWaiter[] waiters)
	{
		for (int i = 0; i < waiters.Length; i++)
		{
			waiters[i].Set(itemAvailable);
		}
	}

	private static void CompleteWaitersFalseCallback(object state)
	{
		CompleteWaiters(itemAvailable: false, (IQueueWaiter[])state);
	}

	private static void CompleteWaitersLater(bool itemAvailable, IQueueWaiter[] waiters)
	{
		if (itemAvailable)
		{
			if (s_completeWaitersTrueCallback == null)
			{
				s_completeWaitersTrueCallback = CompleteWaitersTrueCallback;
			}
			ActionItem.Schedule(s_completeWaitersTrueCallback, waiters);
		}
		else
		{
			if (s_completeWaitersFalseCallback == null)
			{
				s_completeWaitersFalseCallback = CompleteWaitersFalseCallback;
			}
			ActionItem.Schedule(s_completeWaitersFalseCallback, waiters);
		}
	}

	private static void CompleteWaitersTrueCallback(object state)
	{
		CompleteWaiters(itemAvailable: true, (IQueueWaiter[])state);
	}

	private static void InvokeDequeuedCallback(Action dequeuedCallback)
	{
		dequeuedCallback?.Invoke();
	}

	private static void InvokeDequeuedCallbackLater(Action dequeuedCallback)
	{
		if (dequeuedCallback != null)
		{
			if (s_onInvokeDequeuedCallback == null)
			{
				s_onInvokeDequeuedCallback = OnInvokeDequeuedCallback;
			}
			ActionItem.Schedule(s_onInvokeDequeuedCallback, dequeuedCallback);
		}
	}

	private static void OnDispatchCallback(object state)
	{
		((InputQueue<T>)state).Dispatch();
	}

	private static void OnInvokeDequeuedCallback(object state)
	{
		Action action = (Action)state;
		action();
	}

	private void EnqueueAndDispatch(Item item, bool canDispatchOnThisThread)
	{
		bool flag = false;
		IQueueReader queueReader = null;
		bool flag2 = false;
		IQueueWaiter[] waiters = null;
		bool itemAvailable = true;
		lock (ThisLock)
		{
			itemAvailable = _queueState != QueueState.Closed && _queueState != QueueState.Shutdown;
			GetWaiters(out waiters);
			if (_queueState == QueueState.Open)
			{
				if (canDispatchOnThisThread)
				{
					if (_readerQueue.Count == 0)
					{
						_itemQueue.EnqueueAvailableItem(item);
					}
					else
					{
						queueReader = _readerQueue.Dequeue();
					}
				}
				else if (_readerQueue.Count == 0)
				{
					_itemQueue.EnqueueAvailableItem(item);
				}
				else
				{
					_itemQueue.EnqueuePendingItem(item);
					flag2 = true;
				}
			}
			else
			{
				flag = true;
			}
		}
		if (waiters != null)
		{
			if (canDispatchOnThisThread)
			{
				CompleteWaiters(itemAvailable, waiters);
			}
			else
			{
				CompleteWaitersLater(itemAvailable, waiters);
			}
		}
		if (queueReader != null)
		{
			InvokeDequeuedCallback(item.DequeuedCallback);
			queueReader.Set(item);
		}
		if (flag2)
		{
			if (s_onDispatchCallback == null)
			{
				s_onDispatchCallback = OnDispatchCallback;
			}
			ActionItem.Schedule(s_onDispatchCallback, this);
		}
		else if (flag)
		{
			InvokeDequeuedCallback(item.DequeuedCallback);
			DisposeItem(item);
		}
	}

	private bool EnqueueWithoutDispatch(Item item)
	{
		lock (ThisLock)
		{
			if (_queueState != QueueState.Closed && _queueState != QueueState.Shutdown)
			{
				if (_readerQueue.Count == 0 && _waiterList.Count == 0)
				{
					_itemQueue.EnqueueAvailableItem(item);
					return false;
				}
				_itemQueue.EnqueuePendingItem(item);
				return true;
			}
		}
		DisposeItem(item);
		InvokeDequeuedCallbackLater(item.DequeuedCallback);
		return false;
	}

	private void GetWaiters(out IQueueWaiter[] waiters)
	{
		if (_waiterList.Count > 0)
		{
			waiters = _waiterList.ToArray();
			_waiterList.Clear();
		}
		else
		{
			waiters = null;
		}
	}

	private bool RemoveReader(IQueueReader reader)
	{
		lock (ThisLock)
		{
			if (_queueState == QueueState.Open || _queueState == QueueState.Shutdown)
			{
				bool result = false;
				for (int num = _readerQueue.Count; num > 0; num--)
				{
					IQueueReader queueReader = _readerQueue.Dequeue();
					if (queueReader == reader)
					{
						result = true;
					}
					else
					{
						_readerQueue.Enqueue(queueReader);
					}
				}
				return result;
			}
		}
		return false;
	}
}
