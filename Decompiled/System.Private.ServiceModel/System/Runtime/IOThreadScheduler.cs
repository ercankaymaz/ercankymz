using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;

namespace System.Runtime;

internal class IOThreadScheduler
{
	private static class Bits
	{
		public const int HiShift = 16;

		public const int HiOne = 65536;

		public const int LoHiBit = 32768;

		public const int HiHiBit = int.MinValue;

		public const int LoCountMask = 32767;

		public const int HiCountMask = 2147418112;

		public const int LoMask = 65535;

		public const int HiMask = -65536;

		public const int HiBits = -2147450880;

		public static int Count(int slot)
		{
			return (((slot >> 16) - slot + 2) & 0xFFFF) - 1;
		}

		public static int CountNoIdle(int slot)
		{
			return ((slot >> 16) - slot + 1) & 0xFFFF;
		}

		public static int IncrementLo(int slot)
		{
			return ((slot + 1) & 0xFFFF) | (slot & -65536);
		}

		public static bool IsComplete(int gate)
		{
			return (gate & -65536) == gate << 16;
		}
	}

	[StructLayout(LayoutKind.Sequential, Size = 64)]
	private struct Slot
	{
		private int _gate;

		private Action<object> _callback;

		private object _state;

		public bool TryEnqueueWorkItem(Action<object> callback, object state, out bool wrapped)
		{
			int num = Interlocked.Increment(ref _gate);
			wrapped = (num & 0x7FFF) != 1;
			if (wrapped)
			{
				if ((num & 0x8000) != 0 && Bits.IsComplete(num))
				{
					Interlocked.CompareExchange(ref _gate, 0, num);
				}
				return false;
			}
			_state = state;
			_callback = callback;
			num = Interlocked.Add(ref _gate, 32768);
			if ((num & 0x7FFF0000) == 0)
			{
				return true;
			}
			_state = null;
			_callback = null;
			if (num >> 16 != (num & 0x7FFF) || Interlocked.CompareExchange(ref _gate, 0, num) != num)
			{
				num = Interlocked.Add(ref _gate, int.MinValue);
				if (Bits.IsComplete(num))
				{
					Interlocked.CompareExchange(ref _gate, 0, num);
				}
			}
			return false;
		}

		public void DequeueWorkItem(out Action<object> callback, out object state)
		{
			int num = Interlocked.Add(ref _gate, 65536);
			if ((num & 0x8000) == 0)
			{
				callback = null;
				state = null;
			}
			else if ((num & 0x7FFF0000) == 65536)
			{
				callback = _callback;
				state = _state;
				_state = null;
				_callback = null;
				if ((num & 0x7FFF) != 1 || Interlocked.CompareExchange(ref _gate, 0, num) != num)
				{
					num = Interlocked.Add(ref _gate, int.MinValue);
					if (Bits.IsComplete(num))
					{
						Interlocked.CompareExchange(ref _gate, 0, num);
					}
				}
			}
			else
			{
				callback = null;
				state = null;
				if (Bits.IsComplete(num))
				{
					Interlocked.CompareExchange(ref _gate, 0, num);
				}
			}
		}
	}

	private class ScheduledOverlapped
	{
		private static bool s_isWindows = RuntimeInformation.IsOSPlatform(OSPlatform.Windows);

		private unsafe readonly NativeOverlapped* _nativeOverlapped;

		private IOThreadScheduler _scheduler;

		private Action _postDelegate;

		public unsafe ScheduledOverlapped()
		{
			if (s_isWindows)
			{
				_nativeOverlapped = new Overlapped().UnsafePack(Fx.ThunkCallback(IOCallback), null);
				_postDelegate = PostIOCP;
			}
			else
			{
				_postDelegate = PostNewThread;
			}
		}

		private unsafe void IOCallback(uint errorCode, uint numBytes, NativeOverlapped* nativeOverlapped)
		{
			Callback();
		}

		private void Callback()
		{
			try
			{
				CallbackCore();
			}
			finally
			{
			}
		}

		[Conditional("DEBUG")]
		private static void InitThreadDebugData()
		{
			s_isIoThread.Value = true;
			Thread.CurrentThread.Name = "IOThreadScheduler.IOCallback";
		}

		[Conditional("DEBUG")]
		private static void ClearThreadDebugData()
		{
			s_isIoThread.Value = false;
		}

		private void CallbackCore()
		{
			IOThreadScheduler scheduler = _scheduler;
			_scheduler = null;
			Action<object> callback;
			object state;
			try
			{
			}
			finally
			{
				scheduler.CompletionCallback(out callback, out state);
			}
			bool flag = true;
			while (flag)
			{
				callback?.Invoke(state);
				try
				{
				}
				finally
				{
					flag = scheduler.TryCoalesce(out callback, out state);
				}
			}
		}

		public void Post(IOThreadScheduler iots)
		{
			_scheduler = iots;
			_postDelegate();
		}

		private unsafe void PostIOCP()
		{
			ThreadPool.UnsafeQueueNativeOverlapped(_nativeOverlapped);
		}

		private void PostNewThread()
		{
			Thread thread = new Thread(Callback);
			thread.Start();
		}

		public unsafe void Cleanup()
		{
			if (_scheduler != null)
			{
				throw Fx.AssertAndThrowFatal("Cleanup called on an overlapped that is in-flight.");
			}
			if (s_isWindows)
			{
				Overlapped.Free(_nativeOverlapped);
			}
		}
	}

	private class IOThreadSchedulerSynchronizationContext : SynchronizationContext
	{
		public override void Post(SendOrPostCallback d, object state)
		{
			ScheduleCallbackNoFlow(delegate(object s)
			{
				d(s);
			}, state);
		}
	}

	private const int MaximumCapacity = 32768;

	private static IOThreadScheduler s_current = new IOThreadScheduler(32);

	private static SynchronizationContext s_syncContext = new IOThreadSchedulerSynchronizationContext();

	private static TaskScheduler s_IOTaskScheduler;

	private readonly ScheduledOverlapped _overlapped;

	private readonly Slot[] _slots;

	private static ThreadLocal<bool> s_isIoThread = new ThreadLocal<bool>();

	private int _headTail = -131072;

	public static TaskScheduler IOTaskScheduler
	{
		get
		{
			if (s_IOTaskScheduler == null)
			{
				SynchronizationContext current = SynchronizationContext.Current;
				SynchronizationContext.SetSynchronizationContext(s_syncContext);
				s_IOTaskScheduler = TaskScheduler.FromCurrentSynchronizationContext();
				SynchronizationContext.SetSynchronizationContext(current);
			}
			return s_IOTaskScheduler;
		}
	}

	private int SlotMask => _slots.Length - 1;

	public static bool IsRunningOnIOThread
	{
		get
		{
			if (s_isIoThread.IsValueCreated)
			{
				return s_isIoThread.Value;
			}
			return false;
		}
	}

	private IOThreadScheduler(int capacity)
	{
		_slots = new Slot[capacity];
		_overlapped = new ScheduledOverlapped();
	}

	public static void ScheduleCallbackNoFlow(Action<object> callback, object state)
	{
		if (callback == null)
		{
			throw Fx.Exception.ArgumentNull("callback");
		}
		bool flag = false;
		while (!flag)
		{
			try
			{
			}
			finally
			{
				flag = s_current.ScheduleCallbackHelper(callback, state);
			}
		}
	}

	public static void ScheduleCallbackLowPriNoFlow(Action<object> callback, object state)
	{
		if (callback == null)
		{
			throw Fx.Exception.ArgumentNull("callback");
		}
		Task.Factory.StartNew(callback, state, CancellationToken.None, TaskCreationOptions.DenyChildAttach, TaskScheduler.Default);
	}

	private bool ScheduleCallbackHelper(Action<object> callback, object state)
	{
		int num = Interlocked.Add(ref _headTail, 65536);
		bool flag = Bits.Count(num) == 0;
		if (flag)
		{
			num = Interlocked.Add(ref _headTail, 65536);
		}
		if (Bits.Count(num) == -1)
		{
			throw Fx.AssertAndThrowFatal("Head/Tail overflow!");
		}
		bool wrapped;
		bool result = _slots[(num >> 16) & SlotMask].TryEnqueueWorkItem(callback, state, out wrapped);
		if (wrapped)
		{
			IOThreadScheduler value = new IOThreadScheduler(Math.Min(_slots.Length * 2, 32768));
			Interlocked.CompareExchange(ref s_current, value, this);
		}
		if (flag)
		{
			_overlapped.Post(this);
		}
		return result;
	}

	private void CompletionCallback(out Action<object> callback, out object state)
	{
		int num = _headTail;
		bool flag;
		do
		{
			flag = Bits.Count(num) == 0;
		}
		while (num != (num = Interlocked.CompareExchange(ref _headTail, Bits.IncrementLo(num), num)));
		if (!flag)
		{
			_overlapped.Post(this);
			_slots[num & SlotMask].DequeueWorkItem(out callback, out state);
		}
		else
		{
			callback = null;
			state = null;
		}
	}

	private bool TryCoalesce(out Action<object> callback, out object state)
	{
		int num = _headTail;
		while (Bits.Count(num) > 0)
		{
			if (num == (num = Interlocked.CompareExchange(ref _headTail, Bits.IncrementLo(num), num)))
			{
				_slots[num & SlotMask].DequeueWorkItem(out callback, out state);
				return true;
			}
		}
		callback = null;
		state = null;
		return false;
	}

	~IOThreadScheduler()
	{
		if (!Environment.HasShutdownStarted)
		{
			Cleanup();
		}
	}

	private void Cleanup()
	{
		if (_overlapped != null)
		{
			_overlapped.Cleanup();
		}
	}
}
