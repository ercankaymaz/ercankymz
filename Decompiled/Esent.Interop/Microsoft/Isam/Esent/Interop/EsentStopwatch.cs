using System;
using System.Diagnostics;
using Microsoft.Isam.Esent.Interop.Vista;

namespace Microsoft.Isam.Esent.Interop;

public class EsentStopwatch
{
	private Stopwatch stopwatch;

	private JET_THREADSTATS statsAtStart;

	public bool IsRunning { get; private set; }

	public JET_THREADSTATS ThreadStats { get; private set; }

	public TimeSpan Elapsed { get; private set; }

	public static EsentStopwatch StartNew()
	{
		EsentStopwatch esentStopwatch = new EsentStopwatch();
		esentStopwatch.Start();
		return esentStopwatch;
	}

	public override string ToString()
	{
		if (!IsRunning)
		{
			return Elapsed.ToString();
		}
		return "EsentStopwatch (running)";
	}

	public void Start()
	{
		Reset();
		stopwatch = Stopwatch.StartNew();
		IsRunning = true;
		if (EsentVersion.SupportsVistaFeatures)
		{
			VistaApi.JetGetThreadStats(out statsAtStart);
		}
	}

	public void Stop()
	{
		if (IsRunning)
		{
			IsRunning = false;
			stopwatch.Stop();
			Elapsed = stopwatch.Elapsed;
			if (EsentVersion.SupportsVistaFeatures)
			{
				VistaApi.JetGetThreadStats(out var threadstats);
				ThreadStats = threadstats - statsAtStart;
			}
		}
	}

	public void Reset()
	{
		stopwatch = null;
		ThreadStats = default(JET_THREADSTATS);
		Elapsed = TimeSpan.Zero;
		IsRunning = false;
	}
}
