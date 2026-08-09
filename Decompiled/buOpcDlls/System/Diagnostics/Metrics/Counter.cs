using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;

namespace System.Diagnostics.Metrics;

[SecuritySafeCritical]
[ComVisible(true)]
public sealed class Counter<T> : Instrument<T> where T : struct
{
	internal Counter(Meter meter, string name, string unit, string description)
		: base(meter, name, unit, description)
	{
		Publish();
	}

	public void Add(T delta)
	{
		RecordMeasurement(delta);
	}

	public void Add(T delta, [System_002EDiagnostics_002EDiagnosticSource_002ENullable(new byte[] { 0, 1, 2 })] KeyValuePair<string, object> tag)
	{
		RecordMeasurement(delta, tag);
	}

	public void Add(T delta, [System_002EDiagnostics_002EDiagnosticSource_002ENullable(new byte[] { 0, 1, 2 })] KeyValuePair<string, object> tag1, [System_002EDiagnostics_002EDiagnosticSource_002ENullable(new byte[] { 0, 1, 2 })] KeyValuePair<string, object> tag2)
	{
		RecordMeasurement(delta, tag1, tag2);
	}

	public void Add(T delta, [System_002EDiagnostics_002EDiagnosticSource_002ENullable(new byte[] { 0, 1, 2 })] KeyValuePair<string, object> tag1, [System_002EDiagnostics_002EDiagnosticSource_002ENullable(new byte[] { 0, 1, 2 })] KeyValuePair<string, object> tag2, [System_002EDiagnostics_002EDiagnosticSource_002ENullable(new byte[] { 0, 1, 2 })] KeyValuePair<string, object> tag3)
	{
		RecordMeasurement(delta, tag1, tag2, tag3);
	}

	public void Add(T delta, [System_002EDiagnostics_002EDiagnosticSource_002ENullable(new byte[] { 0, 0, 1, 2 })] ReadOnlySpan<KeyValuePair<string, object>> tags)
	{
		RecordMeasurement(delta, tags);
	}

	public void Add(T delta, [System_002EDiagnostics_002EDiagnosticSource_002ENullable(new byte[] { 1, 0, 1, 2 })] params KeyValuePair<string, object>[] tags)
	{
		RecordMeasurement(delta, tags.AsSpan());
	}

	public void Add(T delta, [In][System_002EDiagnostics_002EDiagnosticSource_002EIsReadOnly] ref TagList tagList)
	{
		RecordMeasurement(delta, ref tagList);
	}
}
