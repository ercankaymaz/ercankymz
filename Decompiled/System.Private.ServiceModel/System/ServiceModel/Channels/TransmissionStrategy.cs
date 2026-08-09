using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime;
using System.ServiceModel.Diagnostics;
using System.Threading.Tasks;
using System.Xml;

namespace System.ServiceModel.Channels;

internal sealed class TransmissionStrategy
{
	internal class AsyncWaitQueueAdder : IQueueAdder
	{
		private readonly TaskCompletionSource<object> _tcs = new TaskCompletionSource<object>();

		private Exception _exception;

		private readonly bool _isLast;

		private MessageAttemptInfo _attemptInfo;

		private readonly TransmissionStrategy _strategy;

		public AsyncWaitQueueAdder(TransmissionStrategy strategy, Message message, bool isLast, object state)
		{
			_strategy = strategy;
			_isLast = isLast;
			_attemptInfo = new MessageAttemptInfo(message, 0L, 0, state);
		}

		public void Abort(CommunicationObject communicationObject)
		{
			_exception = communicationObject.CreateClosedException();
			_tcs.TrySetResult(null);
		}

		public void Complete0()
		{
			_attemptInfo = _strategy.AddToWindow(_attemptInfo.Message, _isLast, _attemptInfo.State);
			_tcs.TrySetResult(null);
		}

		public void Complete1()
		{
		}

		public void Fault(CommunicationObject communicationObject)
		{
			_exception = communicationObject.GetTerminalException();
			_tcs.TrySetResult(null);
		}

		public async Task<MessageAttemptInfo> WaitAsync(TimeSpan timeout)
		{
			if (!(await _tcs.Task.AwaitWithTimeout(timeout)) && _strategy.RemoveAdder(this) && _exception == null)
			{
				_exception = new TimeoutException(System.SR.Format(System.SR.TimeoutOnAddToWindow, timeout));
			}
			if (_exception != null)
			{
				_attemptInfo.Message.Close();
				_tcs.TrySetResult(null);
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(_exception);
			}
			_tcs.TrySetResult(null);
			return _attemptInfo;
		}
	}

	private static class Constants
	{
		public const int ChebychevFactor = 2;

		public const int Gain = 3;

		public const int TimeMultiplier = 7;

		public const long MaxMeanRtt = 3074457345618258602L;

		public const long MaxSerrRtt = 1537228672809129301L;
	}

	private interface IQueueAdder
	{
		void Abort(CommunicationObject communicationObject);

		void Fault(CommunicationObject communicationObject);

		void Complete0();

		void Complete1();
	}

	private class SlidingWindow
	{
		private struct TransmissionInfo(Message message, long lastAttemptTime, object state)
		{
			internal MessageBuffer Buffer = message.CreateBufferedCopy(int.MaxValue);

			internal long LastAttemptTime = lastAttemptTime;

			internal int RetryCount = 0;

			internal object State = state;

			internal bool Transferred = false;
		}

		private readonly TransmissionInfo[] _buffer;

		private int _head;

		private int _tail;

		private readonly int _maxSize;

		public int Count
		{
			get
			{
				if (_tail >= _head)
				{
					return _tail - _head;
				}
				return _tail - _head + _maxSize;
			}
		}

		public int TransferredCount
		{
			get
			{
				if (Count == 0)
				{
					return 0;
				}
				return GetTransferredInRangeCount(0, Count - 1);
			}
		}

		public SlidingWindow(int maxSize)
		{
			_maxSize = maxSize + 1;
			_buffer = new TransmissionInfo[_maxSize];
		}

		public void Add(Message message, long addTime, object state)
		{
			if (Count >= _maxSize - 1)
			{
				throw Fx.AssertAndThrow("The caller is not allowed to add messages beyond the sliding window's maximum size.");
			}
			_buffer[_tail] = new TransmissionInfo(message, addTime, state);
			_tail = (_tail + 1) % _maxSize;
		}

		private void AssertIndex(int index)
		{
			if (index >= Count)
			{
				throw Fx.AssertAndThrow("Argument index must be less than Count.");
			}
			if (index < 0)
			{
				throw Fx.AssertAndThrow("Argument index must be positive.");
			}
		}

		public void Close()
		{
			Remove(Count);
		}

		public long GetLastAttemptTime(int index)
		{
			AssertIndex(index);
			return _buffer[(_head + index) % _maxSize].LastAttemptTime;
		}

		public Message GetMessage(int index)
		{
			AssertIndex(index);
			if (!_buffer[(_head + index) % _maxSize].Transferred)
			{
				return _buffer[(_head + index) % _maxSize].Buffer.CreateMessage();
			}
			return null;
		}

		public int GetRetryCount(int index)
		{
			AssertIndex(index);
			return _buffer[(_head + index) % _maxSize].RetryCount;
		}

		public object GetState(int index)
		{
			AssertIndex(index);
			return _buffer[(_head + index) % _maxSize].State;
		}

		public bool GetTransferred(int index)
		{
			AssertIndex(index);
			return _buffer[(_head + index) % _maxSize].Transferred;
		}

		public int GetTransferredInRangeCount(int beginIndex, int endIndex)
		{
			if (beginIndex < 0)
			{
				throw Fx.AssertAndThrow("Argument beginIndex cannot be negative.");
			}
			if (endIndex >= Count)
			{
				throw Fx.AssertAndThrow("Argument endIndex cannot be greater than Count.");
			}
			if (endIndex < beginIndex)
			{
				throw Fx.AssertAndThrow("Argument endIndex cannot be less than argument beginIndex.");
			}
			int num = 0;
			for (int i = beginIndex; i <= endIndex; i++)
			{
				if (_buffer[(_head + i) % _maxSize].Transferred)
				{
					num++;
				}
			}
			return num;
		}

		public int RecordRetry(int index, long retryTime)
		{
			AssertIndex(index);
			_buffer[(_head + index) % _maxSize].LastAttemptTime = retryTime;
			return ++_buffer[(_head + index) % _maxSize].RetryCount;
		}

		public void Remove(int count)
		{
			if (count > Count)
			{
			}
			while (count-- > 0)
			{
				_buffer[_head].Buffer.Close();
				_buffer[_head].Buffer = null;
				_head = (_head + 1) % _maxSize;
			}
		}

		public void SetTransferred(int index)
		{
			AssertIndex(index);
			_buffer[(_head + index) % _maxSize].Transferred = true;
		}
	}

	private bool _aborted;

	private bool _closed;

	private int _congestionControlModeAcks;

	private readonly UniqueId _id;

	private int _lossWindowSize;

	private readonly int _maxWindowSize;

	private long _meanRtt;

	private ComponentExceptionHandler _onException;

	private readonly ReliableMessagingVersion _reliableMessagingVersion;

	private readonly List<long> _retransmissionWindow = new List<long>();

	private readonly IOThreadTimer _retryTimer;

	private RetryHandler _retryTimeoutElapsedHandler;

	private readonly bool _requestAcks;

	private long _serrRtt;

	private int _slowStartThreshold;

	private bool _startup = true;

	private long _timeout;

	private readonly Queue<IQueueAdder> _waitQueue = new Queue<IQueueAdder>();

	private readonly SlidingWindow _window;

	private int _windowSize = 1;

	private long _windowStart = 1L;

	public bool DoneTransmitting
	{
		get
		{
			if (Last != 0L)
			{
				return _windowStart == Last + 1;
			}
			return false;
		}
	}

	public bool HasPending
	{
		get
		{
			if (_window.Count <= 0)
			{
				return _waitQueue.Count > 0;
			}
			return true;
		}
	}

	public long Last { get; private set; }

	private static long Now => Ticks.Now / 10000 << 7;

	public ComponentExceptionHandler OnException
	{
		set
		{
			_onException = value;
		}
	}

	public RetryHandler RetryTimeoutElapsed
	{
		set
		{
			_retryTimeoutElapsedHandler = value;
		}
	}

	public int QuotaRemaining { get; private set; }

	private object ThisLock { get; } = new object();

	public int Timeout => (int)(_timeout >> 7);

	public TransmissionStrategy(ReliableMessagingVersion reliableMessagingVersion, TimeSpan initRtt, int maxWindowSize, bool requestAcks, UniqueId id)
	{
		if (initRtt < TimeSpan.Zero)
		{
			if (DiagnosticUtility.ShouldTrace(TraceEventType.Warning))
			{
				TraceUtility.TraceEvent(TraceEventType.Warning, 262254, System.SR.TraceCodeWsrmNegativeElapsedTimeDetected, this);
			}
			initRtt = ReliableMessagingConstants.UnknownInitiationTime;
		}
		if (maxWindowSize <= 0)
		{
			throw Fx.AssertAndThrow("Argument maxWindow size must be positive.");
		}
		_id = id;
		_maxWindowSize = (_lossWindowSize = maxWindowSize);
		_meanRtt = Math.Min((long)initRtt.TotalMilliseconds, 24019198012642645L) << 7;
		_serrRtt = _meanRtt >> 1;
		_window = new SlidingWindow(maxWindowSize);
		_slowStartThreshold = maxWindowSize;
		_timeout = Math.Max(51200 + _meanRtt, _meanRtt + (_serrRtt << 2));
		QuotaRemaining = int.MaxValue;
		_retryTimer = new IOThreadTimer((Func<object, Task>)OnRetryElapsed, (object)null, true);
		_requestAcks = requestAcks;
		_reliableMessagingVersion = reliableMessagingVersion;
	}

	public void Abort(ChannelBase channel)
	{
		lock (ThisLock)
		{
			_aborted = true;
			if (!_closed)
			{
				_closed = true;
				_retryTimer.Cancel();
				while (_waitQueue.Count > 0)
				{
					_waitQueue.Dequeue().Abort(channel);
				}
				_window.Close();
			}
		}
	}

	public Task<(MessageAttemptInfo attemptInfo, bool success)> AddAsync(Message message, TimeSpan timeout, object state)
	{
		return InternalAddAsync(message, isLast: false, timeout, state);
	}

	public async Task<MessageAttemptInfo> AddLastAsync(Message message, TimeSpan timeout, object state)
	{
		if (_reliableMessagingVersion != ReliableMessagingVersion.WSReliableMessagingFebruary2005)
		{
			throw Fx.AssertAndThrow("Last message supported only in February 2005.");
		}
		return (await InternalAddAsync(message, isLast: true, timeout, state)).Item1;
	}

	private MessageAttemptInfo AddToWindow(Message message, bool isLast, object state)
	{
		MessageAttemptInfo messageAttemptInfo = default(MessageAttemptInfo);
		long num = _windowStart + _window.Count;
		WsrmUtilities.AddSequenceHeader(_reliableMessagingVersion, message, _id, num, isLast);
		if (_requestAcks && (_window.Count == _windowSize - 1 || QuotaRemaining == 1))
		{
			message.Properties.AllowOutputBatching = false;
			WsrmUtilities.AddAckRequestedHeader(_reliableMessagingVersion, message, _id);
		}
		if (_window.Count == 0)
		{
			_retryTimer.Set(Timeout);
		}
		_window.Add(message, Now, state);
		QuotaRemaining--;
		if (isLast)
		{
			Last = num;
		}
		int index = (int)(num - _windowStart);
		return new MessageAttemptInfo(_window.GetMessage(index), num, 0, state);
	}

	private bool CanAdd()
	{
		if (_window.Count < _windowSize && QuotaRemaining > 0)
		{
			return _waitQueue.Count == 0;
		}
		return false;
	}

	public void Close()
	{
		lock (ThisLock)
		{
			if (!_closed)
			{
				_closed = true;
				_retryTimer.Cancel();
				if (_waitQueue.Count != 0)
				{
					throw Fx.AssertAndThrow("The reliable channel must throw prior to the call to Close() if there are outstanding send or request operations.");
				}
				_window.Close();
			}
		}
	}

	public void DequeuePending()
	{
		Queue<IQueueAdder> queue = null;
		lock (ThisLock)
		{
			if (_closed || _waitQueue.Count == 0)
			{
				return;
			}
			int num = Math.Min(_windowSize, QuotaRemaining) - _window.Count;
			if (num <= 0)
			{
				return;
			}
			num = Math.Min(num, _waitQueue.Count);
			queue = new Queue<IQueueAdder>(num);
			while (num-- > 0)
			{
				IQueueAdder queueAdder = _waitQueue.Dequeue();
				queueAdder.Complete0();
				queue.Enqueue(queueAdder);
			}
		}
		while (queue.Count > 0)
		{
			queue.Dequeue().Complete1();
		}
	}

	private bool IsAddValid()
	{
		if (!_aborted)
		{
			return !_closed;
		}
		return false;
	}

	public Task OnRetryElapsed(object state)
	{
		try
		{
			MessageAttemptInfo attemptInfo = default(MessageAttemptInfo);
			lock (ThisLock)
			{
				if (_closed || _window.Count == 0)
				{
					return Task.CompletedTask;
				}
				_window.RecordRetry(0, Now);
				_congestionControlModeAcks = 0;
				_slowStartThreshold = Math.Max(1, _windowSize >> 1);
				_lossWindowSize = _windowSize;
				_windowSize = 1;
				_timeout <<= 1;
				_startup = false;
				attemptInfo = new MessageAttemptInfo(_window.GetMessage(0), _windowStart, _window.GetRetryCount(0), _window.GetState(0));
			}
			_retryTimeoutElapsedHandler(attemptInfo);
			lock (ThisLock)
			{
				if (!_closed && _window.Count > 0)
				{
					_retryTimer.Set(Timeout);
				}
			}
		}
		catch (Exception exception)
		{
			if (Fx.IsFatal(exception))
			{
				throw;
			}
			_onException(exception);
		}
		return Task.CompletedTask;
	}

	public void Fault(ChannelBase channel)
	{
		lock (ThisLock)
		{
			if (!_closed)
			{
				_closed = true;
				_retryTimer.Cancel();
				while (_waitQueue.Count > 0)
				{
					_waitQueue.Dequeue().Fault(channel);
				}
				_window.Close();
			}
		}
	}

	public MessageAttemptInfo GetMessageInfoForRetry(bool remove)
	{
		lock (ThisLock)
		{
			if (_closed)
			{
				return default(MessageAttemptInfo);
			}
			if (remove)
			{
				if (_retransmissionWindow.Count == 0)
				{
					throw Fx.AssertAndThrow("The caller is not allowed to remove a message attempt when there are no message attempts.");
				}
				_retransmissionWindow.RemoveAt(0);
			}
			while (_retransmissionWindow.Count > 0)
			{
				long num = _retransmissionWindow[0];
				if (num < _windowStart)
				{
					_retransmissionWindow.RemoveAt(0);
					continue;
				}
				int index = (int)(num - _windowStart);
				if (_window.GetTransferred(index))
				{
					_retransmissionWindow.RemoveAt(0);
					continue;
				}
				return new MessageAttemptInfo(_window.GetMessage(index), num, _window.GetRetryCount(index), _window.GetState(index));
			}
			return default(MessageAttemptInfo);
		}
	}

	public bool SetLast()
	{
		if (_reliableMessagingVersion != ReliableMessagingVersion.WSReliableMessaging11)
		{
			throw Fx.AssertAndThrow("SetLast supported only in 1.1.");
		}
		lock (ThisLock)
		{
			if (Last != 0L)
			{
				throw Fx.AssertAndThrow("Cannot set last more than once.");
			}
			Last = _windowStart + _window.Count - 1;
			return Last == 0L || DoneTransmitting;
		}
	}

	private async Task<(MessageAttemptInfo attemptInfo, bool success)> InternalAddAsync(Message message, bool isLast, TimeSpan timeout, object state)
	{
		MessageAttemptInfo item = default(MessageAttemptInfo);
		AsyncWaitQueueAdder asyncWaitQueueAdder;
		lock (ThisLock)
		{
			if (isLast && Last != 0L)
			{
				throw Fx.AssertAndThrow("Can't add more than one last message.");
			}
			if (!IsAddValid())
			{
				return (attemptInfo: item, success: false);
			}
			ThrowIfRollover();
			if (CanAdd())
			{
				item = AddToWindow(message, isLast, state);
				return (attemptInfo: item, success: true);
			}
			asyncWaitQueueAdder = new AsyncWaitQueueAdder(this, message, isLast, state);
			_waitQueue.Enqueue(asyncWaitQueueAdder);
		}
		return (attemptInfo: await asyncWaitQueueAdder.WaitAsync(timeout), success: true);
	}

	public bool IsFinalAckConsistent(SequenceRangeCollection ranges)
	{
		lock (ThisLock)
		{
			if (_closed)
			{
				return true;
			}
			if (_windowStart == 1 && _window.Count == 0)
			{
				return ranges.Count == 0;
			}
			if (ranges.Count == 0 || ranges[0].Lower != 1)
			{
				return false;
			}
			return ranges[0].Upper >= _windowStart - 1;
		}
	}

	public void ProcessAcknowledgement(SequenceRangeCollection ranges, out bool invalidAck, out bool inconsistentAck)
	{
		invalidAck = false;
		inconsistentAck = false;
		bool flag = false;
		bool flag2 = false;
		lock (ThisLock)
		{
			if (_closed)
			{
				return;
			}
			long num = _windowStart + _window.Count - 1;
			long num2 = _windowStart - 1;
			int num3 = _window.TransferredCount;
			for (int i = 0; i < ranges.Count; i++)
			{
				SequenceRange sequenceRange = ranges[i];
				if (sequenceRange.Upper > num)
				{
					invalidAck = true;
					return;
				}
				if ((sequenceRange.Lower > 1 && sequenceRange.Lower <= num2) || sequenceRange.Upper < num2)
				{
					flag2 = true;
				}
				if (sequenceRange.Upper >= _windowStart)
				{
					if (sequenceRange.Lower <= _windowStart)
					{
						flag = true;
					}
					if (!flag)
					{
						int num4 = (int)(sequenceRange.Lower - _windowStart);
						int num5 = (int)((sequenceRange.Upper > num) ? (_window.Count - 1) : (sequenceRange.Upper - _windowStart));
						flag = _window.GetTransferredInRangeCount(num4, num5) < num5 - num4 + 1;
					}
					if (num3 > 0 && !flag2)
					{
						int beginIndex = (int)((sequenceRange.Lower < _windowStart) ? 0 : (sequenceRange.Lower - _windowStart));
						int endIndex = (int)((sequenceRange.Upper > num) ? (_window.Count - 1) : (sequenceRange.Upper - _windowStart));
						num3 -= _window.GetTransferredInRangeCount(beginIndex, endIndex);
					}
				}
			}
			if (num3 > 0)
			{
				flag2 = true;
			}
		}
		inconsistentAck = flag2 && flag;
	}

	public bool ProcessTransferred(long transferred, int quotaRemaining)
	{
		if (transferred <= 0)
		{
			throw Fx.AssertAndThrow("Argument transferred must be a valid sequence number.");
		}
		lock (ThisLock)
		{
			if (_closed)
			{
				return false;
			}
			return ProcessTransferred(new SequenceRange(transferred), quotaRemaining);
		}
	}

	public bool ProcessTransferred(SequenceRangeCollection ranges, int quotaRemaining)
	{
		if (ranges.Count == 0)
		{
			return false;
		}
		lock (ThisLock)
		{
			if (_closed)
			{
				return false;
			}
			bool result = false;
			for (int i = 0; i < ranges.Count; i++)
			{
				if (ProcessTransferred(ranges[i], quotaRemaining))
				{
					result = true;
				}
			}
			return result;
		}
	}

	private bool ProcessTransferred(SequenceRange range, int quotaRemaining)
	{
		if (range.Upper < _windowStart)
		{
			if (range.Upper == _windowStart - 1 && quotaRemaining != -1 && quotaRemaining > QuotaRemaining)
			{
				QuotaRemaining = quotaRemaining - Math.Min(_windowSize, _window.Count);
			}
			return false;
		}
		if (range.Lower <= _windowStart)
		{
			bool result = false;
			_retryTimer.Cancel();
			long num = range.Upper - _windowStart + 1;
			if (num == 1)
			{
				for (int i = 1; i < _window.Count && _window.GetTransferred(i); i++)
				{
					num++;
				}
			}
			long now = Now;
			long num2 = _windowStart + _windowSize;
			for (int j = 0; j < (int)num; j++)
			{
				UpdateStats(now, _window.GetLastAttemptTime(j));
			}
			if (quotaRemaining != -1)
			{
				int val = Math.Min(_windowSize, _window.Count) - (int)num;
				QuotaRemaining = quotaRemaining - Math.Max(0, val);
			}
			_window.Remove((int)num);
			_windowStart += num;
			int num3 = 0;
			if (_windowSize <= _slowStartThreshold)
			{
				_windowSize = Math.Min(_maxWindowSize, Math.Min(_slowStartThreshold + 1, _windowSize + (int)num));
				num3 = (_startup ? Math.Max(0, (int)num2 - (int)_windowStart) : 0);
			}
			else
			{
				_congestionControlModeAcks += (int)num;
				int num4 = Math.Max(1, (_lossWindowSize - _slowStartThreshold) / 8);
				int num5 = (_windowSize - _slowStartThreshold) * _windowSize / num4;
				if (_congestionControlModeAcks > num5)
				{
					_congestionControlModeAcks = 0;
					_windowSize = Math.Min(_maxWindowSize, _windowSize + 1);
				}
				num3 = Math.Max(0, (int)num2 - (int)_windowStart);
			}
			int num6 = Math.Min(_windowSize, _window.Count);
			if (num3 < num6)
			{
				result = _retransmissionWindow.Count == 0;
				for (int k = num3; k < _windowSize && k < _window.Count; k++)
				{
					long item = _windowStart + k;
					if (!_window.GetTransferred(k) && !_retransmissionWindow.Contains(item))
					{
						_window.RecordRetry(k, Now);
						_retransmissionWindow.Add(item);
					}
				}
			}
			if (_window.Count > 0)
			{
				_retryTimer.Set(Timeout);
			}
			return result;
		}
		for (long num7 = range.Lower; num7 <= range.Upper; num7++)
		{
			_window.SetTransferred((int)(num7 - _windowStart));
		}
		return false;
	}

	private bool RemoveAdder(IQueueAdder adder)
	{
		lock (ThisLock)
		{
			if (_closed)
			{
				return false;
			}
			bool result = false;
			for (int i = 0; i < _waitQueue.Count; i++)
			{
				IQueueAdder queueAdder = _waitQueue.Dequeue();
				if (adder == queueAdder)
				{
					result = true;
				}
				else
				{
					_waitQueue.Enqueue(queueAdder);
				}
			}
			return result;
		}
	}

	private void ThrowIfRollover()
	{
		if (_windowStart + _window.Count + _waitQueue.Count == long.MaxValue)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new MessageNumberRolloverFault(_id).CreateException());
		}
	}

	private void UpdateStats(long now, long lastAttemptTime)
	{
		now = Math.Max(now, lastAttemptTime);
		long num = now - lastAttemptTime;
		long num2 = num - _meanRtt;
		_serrRtt = Math.Min(_serrRtt + (Math.Abs(num2) - _serrRtt >> 3), 1537228672809129301L);
		_meanRtt = Math.Min(_meanRtt + (num2 >> 3), 3074457345618258602L);
		_timeout = Math.Max(51200 + _meanRtt, _meanRtt + (_serrRtt << 2));
	}
}
