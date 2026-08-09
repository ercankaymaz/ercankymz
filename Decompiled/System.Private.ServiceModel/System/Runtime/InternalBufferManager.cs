using System.Collections.Generic;
using System.Threading;

namespace System.Runtime;

internal abstract class InternalBufferManager
{
	internal class PooledBufferManager : InternalBufferManager
	{
		internal abstract class BufferPool
		{
			internal class SynchronizedBufferPool : BufferPool
			{
				private SynchronizedPool<byte[]> _innerPool;

				internal SynchronizedBufferPool(int bufferSize, int limit)
					: base(bufferSize, limit)
				{
					_innerPool = new SynchronizedPool<byte[]>(limit);
				}

				internal override void OnClear()
				{
					_innerPool.Clear();
				}

				internal override byte[] Take()
				{
					return _innerPool.Take();
				}

				internal override bool Return(byte[] buffer)
				{
					return _innerPool.Return(buffer);
				}
			}

			internal class LargeBufferPool : BufferPool
			{
				private Stack<byte[]> _items;

				private object ThisLock => _items;

				internal LargeBufferPool(int bufferSize, int limit)
					: base(bufferSize, limit)
				{
					_items = new Stack<byte[]>(limit);
				}

				internal override void OnClear()
				{
					lock (ThisLock)
					{
						_items.Clear();
					}
				}

				internal override byte[] Take()
				{
					lock (ThisLock)
					{
						if (_items.Count > 0)
						{
							return _items.Pop();
						}
					}
					return null;
				}

				internal override bool Return(byte[] buffer)
				{
					lock (ThisLock)
					{
						if (_items.Count < base.Limit)
						{
							_items.Push(buffer);
							return true;
						}
					}
					return false;
				}
			}

			private int _count;

			private int _peak;

			public int BufferSize { get; }

			public int Limit { get; }

			public int Misses { get; set; }

			public int Peak => _peak;

			public BufferPool(int bufferSize, int limit)
			{
				BufferSize = bufferSize;
				Limit = limit;
			}

			public void Clear()
			{
				OnClear();
				_count = 0;
			}

			public void DecrementCount()
			{
				int num = _count - 1;
				if (num >= 0)
				{
					_count = num;
				}
			}

			public void IncrementCount()
			{
				int num = _count + 1;
				if (num <= Limit)
				{
					_count = num;
					if (num > _peak)
					{
						_peak = num;
					}
				}
			}

			internal abstract byte[] Take();

			internal abstract bool Return(byte[] buffer);

			internal abstract void OnClear();

			internal static BufferPool CreatePool(int bufferSize, int limit)
			{
				if (bufferSize < 85000)
				{
					return new SynchronizedBufferPool(bufferSize, limit);
				}
				return new LargeBufferPool(bufferSize, limit);
			}
		}

		private const int minBufferSize = 128;

		private const int maxMissesBeforeTuning = 8;

		private const int initialBufferCount = 1;

		private readonly object _tuningLock;

		private int[] _bufferSizes;

		private BufferPool[] _bufferPools;

		private long _memoryLimit;

		private long _remainingMemory;

		private bool _areQuotasBeingTuned;

		private int _totalMisses;

		public PooledBufferManager(long maxMemoryToPool, int maxBufferSize)
		{
			_tuningLock = new object();
			_memoryLimit = maxMemoryToPool;
			_remainingMemory = maxMemoryToPool;
			List<BufferPool> list = new List<BufferPool>();
			int num = 128;
			while (true)
			{
				long num2 = _remainingMemory / num;
				int num3 = (int)((num2 > int.MaxValue) ? int.MaxValue : num2);
				if (num3 > 1)
				{
					num3 = 1;
				}
				list.Add(BufferPool.CreatePool(num, num3));
				_remainingMemory -= (long)num3 * (long)num;
				if (num >= maxBufferSize)
				{
					break;
				}
				long num4 = (long)num * 2L;
				num = (int)((num4 <= maxBufferSize) ? num4 : maxBufferSize);
			}
			_bufferPools = list.ToArray();
			_bufferSizes = new int[_bufferPools.Length];
			for (int i = 0; i < _bufferPools.Length; i++)
			{
				_bufferSizes[i] = _bufferPools[i].BufferSize;
			}
		}

		public override void Clear()
		{
			for (int i = 0; i < _bufferPools.Length; i++)
			{
				BufferPool bufferPool = _bufferPools[i];
				bufferPool.Clear();
			}
		}

		private void ChangeQuota(ref BufferPool bufferPool, int delta)
		{
			if (TraceCore.BufferPoolChangeQuotaIsEnabled(Fx.Trace))
			{
				TraceCore.BufferPoolChangeQuota(Fx.Trace, bufferPool.BufferSize, delta);
			}
			BufferPool bufferPool2 = bufferPool;
			int num = bufferPool2.Limit + delta;
			BufferPool bufferPool3 = BufferPool.CreatePool(bufferPool2.BufferSize, num);
			for (int i = 0; i < num; i++)
			{
				byte[] array = bufferPool2.Take();
				if (array == null)
				{
					break;
				}
				bufferPool3.Return(array);
				bufferPool3.IncrementCount();
			}
			_remainingMemory -= bufferPool2.BufferSize * delta;
			bufferPool = bufferPool3;
		}

		private void DecreaseQuota(ref BufferPool bufferPool)
		{
			ChangeQuota(ref bufferPool, -1);
		}

		private int FindMostExcessivePool()
		{
			long num = 0L;
			int result = -1;
			for (int i = 0; i < _bufferPools.Length; i++)
			{
				BufferPool bufferPool = _bufferPools[i];
				if (bufferPool.Peak < bufferPool.Limit)
				{
					long num2 = (long)(bufferPool.Limit - bufferPool.Peak) * (long)bufferPool.BufferSize;
					if (num2 > num)
					{
						result = i;
						num = num2;
					}
				}
			}
			return result;
		}

		private int FindMostStarvedPool()
		{
			long num = 0L;
			int result = -1;
			for (int i = 0; i < _bufferPools.Length; i++)
			{
				BufferPool bufferPool = _bufferPools[i];
				if (bufferPool.Peak == bufferPool.Limit)
				{
					long num2 = (long)bufferPool.Misses * (long)bufferPool.BufferSize;
					if (num2 > num)
					{
						result = i;
						num = num2;
					}
				}
			}
			return result;
		}

		private BufferPool FindPool(int desiredBufferSize)
		{
			for (int i = 0; i < _bufferSizes.Length; i++)
			{
				if (desiredBufferSize <= _bufferSizes[i])
				{
					return _bufferPools[i];
				}
			}
			return null;
		}

		private void IncreaseQuota(ref BufferPool bufferPool)
		{
			ChangeQuota(ref bufferPool, 1);
		}

		public override void ReturnBuffer(byte[] buffer)
		{
			BufferPool bufferPool = FindPool(buffer.Length);
			if (bufferPool != null)
			{
				if (buffer.Length != bufferPool.BufferSize)
				{
					throw Fx.Exception.Argument("buffer", InternalSR.BufferIsNotRightSizeForBufferManager);
				}
				if (bufferPool.Return(buffer))
				{
					bufferPool.IncrementCount();
				}
			}
		}

		public override byte[] TakeBuffer(int bufferSize)
		{
			BufferPool bufferPool = FindPool(bufferSize);
			if (bufferPool != null)
			{
				byte[] array = bufferPool.Take();
				if (array != null)
				{
					bufferPool.DecrementCount();
					return array;
				}
				if (bufferPool.Peak == bufferPool.Limit)
				{
					bufferPool.Misses++;
					if (++_totalMisses >= 8)
					{
						TuneQuotas();
					}
				}
				if (TraceCore.BufferPoolAllocationIsEnabled(Fx.Trace))
				{
					TraceCore.BufferPoolAllocation(Fx.Trace, bufferPool.BufferSize);
				}
				return Fx.AllocateByteArray(bufferPool.BufferSize);
			}
			if (TraceCore.BufferPoolAllocationIsEnabled(Fx.Trace))
			{
				TraceCore.BufferPoolAllocation(Fx.Trace, bufferSize);
			}
			return Fx.AllocateByteArray(bufferSize);
		}

		private void TuneQuotas()
		{
			if (_areQuotasBeingTuned)
			{
				return;
			}
			bool lockTaken = false;
			try
			{
				Monitor.TryEnter(_tuningLock, ref lockTaken);
				if (!lockTaken || _areQuotasBeingTuned)
				{
					return;
				}
				_areQuotasBeingTuned = true;
			}
			finally
			{
				if (lockTaken)
				{
					Monitor.Exit(_tuningLock);
				}
			}
			int num = FindMostStarvedPool();
			if (num >= 0)
			{
				BufferPool bufferPool = _bufferPools[num];
				if (_remainingMemory < bufferPool.BufferSize)
				{
					int num2 = FindMostExcessivePool();
					if (num2 >= 0)
					{
						DecreaseQuota(ref _bufferPools[num2]);
					}
				}
				if (_remainingMemory >= bufferPool.BufferSize)
				{
					IncreaseQuota(ref _bufferPools[num]);
				}
			}
			for (int i = 0; i < _bufferPools.Length; i++)
			{
				BufferPool bufferPool2 = _bufferPools[i];
				bufferPool2.Misses = 0;
			}
			_totalMisses = 0;
			_areQuotasBeingTuned = false;
		}
	}

	internal class GCBufferManager : InternalBufferManager
	{
		public static GCBufferManager Value { get; } = new GCBufferManager();

		private GCBufferManager()
		{
		}

		public override void Clear()
		{
		}

		public override byte[] TakeBuffer(int bufferSize)
		{
			return Fx.AllocateByteArray(bufferSize);
		}

		public override void ReturnBuffer(byte[] buffer)
		{
		}
	}

	public abstract byte[] TakeBuffer(int bufferSize);

	public abstract void ReturnBuffer(byte[] buffer);

	public abstract void Clear();

	public static InternalBufferManager Create(long maxBufferPoolSize, int maxBufferSize)
	{
		if (maxBufferPoolSize == 0L)
		{
			return GCBufferManager.Value;
		}
		return new PooledBufferManager(maxBufferPoolSize, maxBufferSize);
	}
}
