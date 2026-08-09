using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace ODA.Kernel.TD_RootIntegrated;

public class MemoryManager
{
	public delegate MemoryTransaction GetCurrentTransactionCallback();

	private static MemoryManager mMngr = null;

	private static object memLocker = new object();

	private static ConcurrentDictionary<int, List<MemoryTransaction>> TransDict = new ConcurrentDictionary<int, List<MemoryTransaction>>();

	public static GetCurrentTransactionCallback CurrentTransactionCallback { get; set; }

	public static MemoryManager GetMemoryManager()
	{
		if (mMngr == null)
		{
			lock (memLocker)
			{
				if (mMngr == null)
				{
					mMngr = new MemoryManager();
				}
			}
		}
		return mMngr;
	}

	private MemoryManager()
	{
	}

	public MemoryTransaction GetCurrentTransaction()
	{
		if (CurrentTransactionCallback != null)
		{
			return CurrentTransactionCallback();
		}
		return GetTransaction(Thread.CurrentThread.ManagedThreadId);
	}

	public MemoryTransaction GetTransaction(int managedThreadId)
	{
		if (!TransDict.TryGetValue(managedThreadId, out var value))
		{
			return null;
		}
		return value.Last();
	}

	public MemoryTransaction StartTransaction()
	{
		int managedThreadId = Thread.CurrentThread.ManagedThreadId;
		return StartTransaction(managedThreadId);
	}

	public MemoryTransaction StartTransaction(int ManagedThreadId)
	{
		List<MemoryTransaction> orAdd = TransDict.GetOrAdd(ManagedThreadId, (int t) => new List<MemoryTransaction>());
		MemoryTransaction memoryTransaction = new MemoryTransaction();
		orAdd.Add(memoryTransaction);
		return memoryTransaction;
	}

	public void StopTransaction(MemoryTransaction value)
	{
		int managedThreadId = Thread.CurrentThread.ManagedThreadId;
		StopTransaction(value, managedThreadId);
	}

	public void StopTransaction(MemoryTransaction value, int ManagedThreadId)
	{
		if (TransDict.TryGetValue(ManagedThreadId, out var value2))
		{
			int num = value2.IndexOf(value);
			int count = value2.Count;
			if (num < 0 || num >= count)
			{
				throw new Exception("Stop transaction exception");
			}
			for (int num2 = count - 1; num2 >= num; num2--)
			{
				MemoryTransaction memoryTransaction = value2[num2];
				value2.Remove(memoryTransaction);
				memoryTransaction.DeleteObjects();
			}
			if (value2.Count == 0)
			{
				TransDict.TryRemove(ManagedThreadId, out var _);
			}
		}
	}

	public void StopAll()
	{
		int managedThreadId = Thread.CurrentThread.ManagedThreadId;
		StopAll(managedThreadId);
	}

	public void StopAll(int ManagedThreadId)
	{
		if (TransDict.TryGetValue(ManagedThreadId, out var value))
		{
			for (int num = value.Count - 1; num >= 0; num--)
			{
				MemoryTransaction memoryTransaction = value[num];
				value.Remove(memoryTransaction);
				memoryTransaction.DeleteObjects();
			}
			if (value.Count == 0)
			{
				TransDict.TryRemove(ManagedThreadId, out var _);
			}
		}
	}
}
