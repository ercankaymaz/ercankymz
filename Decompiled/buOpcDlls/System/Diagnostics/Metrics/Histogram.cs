using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;

namespace System.Diagnostics.Metrics;

[SecuritySafeCritical]
[ComVisible(true)]
public sealed class Histogram<T> : Instrument<T> where T : struct
{
	internal Histogram(Meter meter, string name, string unit, string description)
		: base(meter, name, unit, description)
	{
		Publish();
	}

	public void Record(T value)
	{
		RecordMeasurement(value);
	}

	public void Record(T value, [System_002EDiagnostics_002EDiagnosticSource_002ENullable(new byte[] { 0, 1, 2 })] KeyValuePair<string, object> tag)
	{
		RecordMeasurement(value, tag);
	}

	public void Record(T value, [System_002EDiagnostics_002EDiagnosticSource_002ENullable(new byte[] { 0, 1, 2 })] KeyValuePair<string, object> tag1, [System_002EDiagnostics_002EDiagnosticSource_002ENullable(new byte[] { 0, 1, 2 })] KeyValuePair<string, object> tag2)
	{
		RecordMeasurement(value, tag1, tag2);
	}

	public void Record(T value, [System_002EDiagnostics_002EDiagnosticSource_002ENullable(new byte[] { 0, 1, 2 })] KeyValuePair<string, object> tag1, [System_002EDiagnostics_002EDiagnosticSource_002ENullable(new byte[] { 0, 1, 2 })] KeyValuePair<string, object> tag2, [System_002EDiagnostics_002EDiagnosticSource_002ENullable(new byte[] { 0, 1, 2 })] KeyValuePair<string, object> tag3)
	{
		RecordMeasurement(value, tag1, tag2, tag3);
	}

	public void Record(T value, [System_002EDiagnostics_002EDiagnosticSource_002ENullable(new byte[] { 0, 0, 1, 2 })] ReadOnlySpan<KeyValuePair<string, object>> tags)
	{
		RecordMeasurement(value, tags);
	}

	public void Record(T value, [System_002EDiagnostics_002EDiagnosticSource_002ENullable(new byte[] { 1, 0, 1, 2 })] params KeyValuePair<string, object>[] tags)
	{
		RecordMeasurement(value, tags.AsSpan());
	}

	public void Record(T value, [In][System_002EDiagnostics_002EDiagnosticSource_002EIsReadOnly] ref TagList tagList)
	{
		RecordMeasurement(value, ref tagList);
	}
}
