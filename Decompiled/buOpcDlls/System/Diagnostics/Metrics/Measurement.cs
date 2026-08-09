using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;

namespace System.Diagnostics.Metrics;

[System_002EDiagnostics_002EDiagnosticSource_002EIsReadOnly]
[SecuritySafeCritical]
[ComVisible(true)]
public struct Measurement<T> where T : struct
{
	private readonly KeyValuePair<string, object>[] _tags;

	[System_002EDiagnostics_002EDiagnosticSource_002ENullable(new byte[] { 0, 0, 1, 2 })]
	public ReadOnlySpan<KeyValuePair<string, object>> Tags
	{
		[return: System_002EDiagnostics_002EDiagnosticSource_002ENullable(new byte[] { 0, 0, 1, 2 })]
		get
		{
			return _tags.AsSpan();
		}
	}

	public T Value { get; }

	public Measurement(T value)
	{
		_tags = Instrument.EmptyTags;
		Value = value;
	}

	public Measurement(T value, [System_002EDiagnostics_002EDiagnosticSource_002ENullable(new byte[] { 2, 0, 1, 2 })] IEnumerable<KeyValuePair<string, object>> tags)
	{
		_tags = ToArray(tags);
		Value = value;
	}

	public Measurement(T value, [System_002EDiagnostics_002EDiagnosticSource_002ENullable(new byte[] { 2, 0, 1, 2 })] params KeyValuePair<string, object>[] tags)
	{
		if (tags != null)
		{
			_tags = new KeyValuePair<string, object>[tags.Length];
			tags.CopyTo(_tags, 0);
		}
		else
		{
			_tags = Instrument.EmptyTags;
		}
		Value = value;
	}

	public Measurement(T value, [System_002EDiagnostics_002EDiagnosticSource_002ENullable(new byte[] { 0, 0, 1, 2 })] ReadOnlySpan<KeyValuePair<string, object>> tags)
	{
		_tags = tags.ToArray();
		Value = value;
	}

	private static KeyValuePair<string, object>[] ToArray(IEnumerable<KeyValuePair<string, object>> tags)
	{
		if (tags != null)
		{
			return new List<KeyValuePair<string, object>>(tags).ToArray();
		}
		return Instrument.EmptyTags;
	}
}
