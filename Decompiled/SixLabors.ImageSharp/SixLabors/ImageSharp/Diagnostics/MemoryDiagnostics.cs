using System;
using System.Threading;

namespace SixLabors.ImageSharp.Diagnostics;

public static class MemoryDiagnostics
{
	private static int totalUndisposedAllocationCount;

	private static UndisposedAllocationDelegate? undisposedAllocation;

	private static int undisposedAllocationSubscriptionCounter;

	private static readonly object SyncRoot = new object();

	public static int TotalUndisposedAllocationCount => totalUndisposedAllocationCount;

	internal static bool UndisposedAllocationSubscribed => Volatile.Read(in undisposedAllocationSubscriptionCounter) > 0;

	public static event UndisposedAllocationDelegate UndisposedAllocation
	{
		add
		{
			lock (SyncRoot)
			{
				undisposedAllocationSubscriptionCounter++;
				undisposedAllocation = (UndisposedAllocationDelegate)Delegate.Combine(undisposedAllocation, value);
			}
		}
		remove
		{
			lock (SyncRoot)
			{
				undisposedAllocation = (UndisposedAllocationDelegate)Delegate.Remove(undisposedAllocation, value);
				undisposedAllocationSubscriptionCounter--;
			}
		}
	}

	internal static event Action? MemoryAllocated;

	internal static event Action? MemoryReleased;

	internal static void IncrementTotalUndisposedAllocationCount()
	{
		Interlocked.Increment(ref totalUndisposedAllocationCount);
		MemoryDiagnostics.MemoryAllocated?.Invoke();
	}

	internal static void DecrementTotalUndisposedAllocationCount()
	{
		Interlocked.Decrement(ref totalUndisposedAllocationCount);
		MemoryDiagnostics.MemoryReleased?.Invoke();
	}

	internal static void RaiseUndisposedMemoryResource(string allocationStackTrace)
	{
		if (undisposedAllocation != null)
		{
			ThreadPool.QueueUserWorkItem(delegate(string stackTrace)
			{
				undisposedAllocation?.Invoke(stackTrace);
			}, allocationStackTrace, preferLocal: false);
		}
	}
}
