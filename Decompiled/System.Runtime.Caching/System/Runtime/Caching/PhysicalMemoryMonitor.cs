namespace System.Runtime.Caching;

internal sealed class PhysicalMemoryMonitor : MemoryMonitor
{
	private const int MinTotalMemoryTrimPercent = 10;

	private const long TargetTotalMemoryTrimIntervalTicks = 3000000000L;

	private int lastGCCount;

	internal long MemoryLimit => _pressureHigh;

	private PhysicalMemoryMonitor()
	{
	}

	internal PhysicalMemoryMonitor(int physicalMemoryLimitPercentage)
	{
		long totalPhysical = MemoryMonitor.TotalPhysical;
		if (totalPhysical >= 4294967296L)
		{
			_pressureHigh = 99;
		}
		else if (totalPhysical >= 2147483648u)
		{
			_pressureHigh = 98;
		}
		else if (totalPhysical >= 1073741824)
		{
			_pressureHigh = 97;
		}
		else if (totalPhysical >= 805306368)
		{
			_pressureHigh = 96;
		}
		else
		{
			_pressureHigh = 95;
		}
		_pressureLow = _pressureHigh - 9;
		SetLimit(physicalMemoryLimitPercentage);
		InitHistory();
	}

	internal override int GetPercentToTrim(DateTime lastTrimTime, int lastTrimPercent)
	{
		int result = 0;
		if (IsAboveHighPressure())
		{
			long ticks = DateTime.UtcNow.Subtract(lastTrimTime).Ticks;
			if (ticks > 0)
			{
				result = Math.Min(50, (int)(lastTrimPercent * 3000000000u / ticks));
				result = Math.Max(10, result);
			}
		}
		return result;
	}

	internal void SetLimit(int physicalMemoryLimitPercentage)
	{
		if (physicalMemoryLimitPercentage != 0)
		{
			_pressureHigh = Math.Max(3, physicalMemoryLimitPercentage);
			_pressureLow = Math.Max(1, _pressureHigh - 9);
		}
	}

	protected override int GetCurrentPressure()
	{
		int num = GC.CollectionCount(0);
		if (num == lastGCCount)
		{
			GC.Collect(0, GCCollectionMode.Optimized);
			num = GC.CollectionCount(0);
		}
		lastGCCount = num;
		GCMemoryInfo gCMemoryInfo = GC.GetGCMemoryInfo();
		if (gCMemoryInfo.TotalAvailableMemoryBytes >= gCMemoryInfo.MemoryLoadBytes)
		{
			int val = (int)((double)(float)gCMemoryInfo.MemoryLoadBytes * 100.0 / (double)(float)gCMemoryInfo.TotalAvailableMemoryBytes);
			return Math.Max(1, val);
		}
		if (gCMemoryInfo.MemoryLoadBytes <= 0)
		{
			return 0;
		}
		return 100;
	}
}
