namespace MS.Internal;

internal interface IPerformanceTracker
{
	bool StartTiming(ulong codeMarker, string description);

	bool StopTiming(ulong codeMarker, string description);

	bool MarkTime(ulong codeMarker, string description);
}
