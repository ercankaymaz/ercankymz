using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace System.Diagnostics;

[System_002EDiagnostics_002EDiagnosticSource_002ENullableContext(2)]
[System_002EDiagnostics_002EDiagnosticSource_002ENullable(0)]
[System_002EDiagnostics_002EDiagnosticSource_002EIsReadOnly]
[ComVisible(true)]
public struct ActivityContext(ActivityTraceId traceId, ActivitySpanId spanId, ActivityTraceFlags traceFlags, string traceState = null, bool isRemote = false) : IEquatable<ActivityContext>
{
	public ActivityTraceId TraceId { get; } = traceId;

	public ActivitySpanId SpanId { get; } = spanId;

	public ActivityTraceFlags TraceFlags { get; } = traceFlags;

	public string TraceState { get; } = traceState;

	public bool IsRemote { get; } = isRemote;

	public static bool TryParse(string traceParent, string traceState, out ActivityContext context)
	{
		if (traceParent == null)
		{
			context = default(ActivityContext);
			return false;
		}
		return Activity.TryConvertIdToContext(traceParent, traceState, out context);
	}

	[System_002EDiagnostics_002EDiagnosticSource_002ENullableContext(1)]
	public static ActivityContext Parse(string traceParent, [System_002EDiagnostics_002EDiagnosticSource_002ENullable(2)] string traceState)
	{
		if (traceParent == null)
		{
			throw new ArgumentNullException("traceParent");
		}
		if (!Activity.TryConvertIdToContext(traceParent, traceState, out var context))
		{
			throw new ArgumentException(System_002EDiagnostics_002EDiagnosticSource3462135_002ESR.InvalidTraceParent);
		}
		return context;
	}

	public bool Equals(ActivityContext value)
	{
		if (SpanId.Equals(value.SpanId) && TraceId.Equals(value.TraceId) && TraceFlags == value.TraceFlags && TraceState == value.TraceState)
		{
			return IsRemote == value.IsRemote;
		}
		return false;
	}

	public override bool Equals([System_002EDiagnostics_002EDiagnosticSource3462135_002ENotNullWhen(true)] object obj)
	{
		if (!(obj is ActivityContext value))
		{
			return false;
		}
		return Equals(value);
	}

	public static bool operator ==(ActivityContext left, ActivityContext right)
	{
		return left.Equals(right);
	}

	public static bool operator !=(ActivityContext left, ActivityContext right)
	{
		return !(left == right);
	}

	public override int GetHashCode()
	{
		if (this == default(ActivityContext))
		{
			return 0;
		}
		int num = 5381;
		num = (num << 5) + num + TraceId.GetHashCode();
		num = (num << 5) + num + SpanId.GetHashCode();
		num = (int)((num << 5) + num + TraceFlags);
		return (num << 5) + num + ((TraceState != null) ? TraceState.GetHashCode() : 0);
	}
}
