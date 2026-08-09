using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace System.Diagnostics;

[System_002EDiagnostics_002EDiagnosticSource_002ENullableContext(1)]
[System_002EDiagnostics_002EDiagnosticSource_002ENullable(0)]
[System_002EDiagnostics_002EDiagnosticSource_002EIsReadOnly]
[ComVisible(true)]
public struct ActivityEvent
{
	private static readonly ActivityTagsCollection s_emptyTags = new ActivityTagsCollection();

	public string Name { get; }

	public DateTimeOffset Timestamp { get; }

	[System_002EDiagnostics_002EDiagnosticSource_002ENullable(new byte[] { 1, 0, 1, 2 })]
	public IEnumerable<KeyValuePair<string, object>> Tags
	{
		[return: System_002EDiagnostics_002EDiagnosticSource_002ENullable(new byte[] { 1, 0, 1, 2 })]
		get;
	}

	public ActivityEvent(string name)
		: this(name, DateTimeOffset.UtcNow, s_emptyTags)
	{
	}

	public ActivityEvent(string name, DateTimeOffset timestamp = default(DateTimeOffset), [System_002EDiagnostics_002EDiagnosticSource_002ENullable(2)] ActivityTagsCollection tags = null)
	{
		Name = name ?? string.Empty;
		Tags = tags ?? s_emptyTags;
		Timestamp = ((timestamp != default(DateTimeOffset)) ? timestamp : DateTimeOffset.UtcNow);
	}
}
