using System;
using Microsoft.Internal.Performance;

namespace MS.Internal;

internal static class Performance
{
	private const string PerformanceTrackerInstanceKey = "Cider_PerformanceTrackerInstanceKey";

	private const string StartTimingFunctionKey = "Cider_StartTimingFunctionKey";

	private const string StopTimingFunctionKey = "Cider_StopTimingFunctionKey";

	private const string MarkTimeFunctionKey = "Cider_MarkTimeFunctionKey";

	private static bool _initialized;

	private static Func<ulong, string, bool> _startFunc;

	private static Func<ulong, string, bool> _endFunc;

	private static Func<ulong, string, bool> _markFunc;

	private static void Initialize()
	{
		if (!_initialized)
		{
			AppDomain currentDomain = AppDomain.CurrentDomain;
			if (_startFunc == null)
			{
				_startFunc = (Func<ulong, string, bool>)currentDomain.GetData("Cider_StartTimingFunctionKey");
			}
			if (_endFunc == null)
			{
				_endFunc = (Func<ulong, string, bool>)currentDomain.GetData("Cider_StopTimingFunctionKey");
			}
			if (_markFunc == null)
			{
				_markFunc = (Func<ulong, string, bool>)currentDomain.GetData("Cider_MarkTimeFunctionKey");
			}
			_initialized = true;
		}
	}

	public static void Initialize(IPerformanceTracker tracker)
	{
		AppDomain.CurrentDomain.SetData("Cider_PerformanceTrackerInstanceKey", tracker);
		_startFunc = tracker.StartTiming;
		AppDomain.CurrentDomain.SetData("Cider_StartTimingFunctionKey", _startFunc);
		_endFunc = tracker.StopTiming;
		AppDomain.CurrentDomain.SetData("Cider_StopTimingFunctionKey", _endFunc);
		_markFunc = tracker.MarkTime;
		AppDomain.CurrentDomain.SetData("Cider_MarkTimeFunctionKey", _markFunc);
		_initialized = true;
	}

	public static void StartTiming(PerformanceMark mark)
	{
		Initialize();
		CodeMarkers.Instance.CodeMarker(mark.BeginEvent);
		if (_startFunc != null)
		{
			_startFunc((ulong)mark.BeginEvent, mark.Description);
		}
	}

	public static void StopTiming(PerformanceMark mark)
	{
		if (_endFunc != null)
		{
			_endFunc((ulong)mark.EndEvent, mark.Description);
		}
		CodeMarkers.Instance.CodeMarker(mark.EndEvent);
	}

	public static void MarkTime(PerformanceMark mark)
	{
		if (_markFunc != null)
		{
			_markFunc((ulong)mark.BeginEvent, mark.Description);
		}
		CodeMarkers.Instance.CodeMarker(mark.BeginEvent);
	}
}
