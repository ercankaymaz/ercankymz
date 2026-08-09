using System;

namespace SourceGrid.Utils;

public class PerformanceCounter : IDisposable, IPerformanceCounter
{
	private DateTime dateTime_0 = DateTime.MinValue;

	public PerformanceCounter()
	{
		dateTime_0 = DateTime.Now;
	}

	public double GetSeconds()
	{
		return (DateTime.Now - dateTime_0).TotalSeconds;
	}

	public double GetMilisec()
	{
		return (DateTime.Now - dateTime_0).TotalMilliseconds;
	}

	public void Dispose()
	{
	}
}
