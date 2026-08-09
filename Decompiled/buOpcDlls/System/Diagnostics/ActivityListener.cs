using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace System.Diagnostics;

[System_002EDiagnostics_002EDiagnosticSource_002ENullableContext(2)]
[System_002EDiagnostics_002EDiagnosticSource_002ENullable(0)]
[ComVisible(true)]
public sealed class ActivityListener : IDisposable
{
	[System_002EDiagnostics_002EDiagnosticSource_002ENullable(new byte[] { 2, 1 })]
	public Action<Activity> ActivityStarted
	{
		[return: System_002EDiagnostics_002EDiagnosticSource_002ENullable(new byte[] { 2, 1 })]
		get;
		[param: System_002EDiagnostics_002EDiagnosticSource_002ENullable(new byte[] { 2, 1 })]
		set;
	}

	[System_002EDiagnostics_002EDiagnosticSource_002ENullable(new byte[] { 2, 1 })]
	public Action<Activity> ActivityStopped
	{
		[return: System_002EDiagnostics_002EDiagnosticSource_002ENullable(new byte[] { 2, 1 })]
		get;
		[param: System_002EDiagnostics_002EDiagnosticSource_002ENullable(new byte[] { 2, 1 })]
		set;
	}

	[System_002EDiagnostics_002EDiagnosticSource_002ENullable(new byte[] { 2, 1 })]
	public Func<ActivitySource, bool> ShouldListenTo
	{
		[return: System_002EDiagnostics_002EDiagnosticSource_002ENullable(new byte[] { 2, 1 })]
		get;
		[param: System_002EDiagnostics_002EDiagnosticSource_002ENullable(new byte[] { 2, 1 })]
		set;
	}

	[System_002EDiagnostics_002EDiagnosticSource_002ENullable(new byte[] { 2, 1 })]
	public SampleActivity<string> SampleUsingParentId
	{
		[return: System_002EDiagnostics_002EDiagnosticSource_002ENullable(new byte[] { 2, 1 })]
		get;
		[param: System_002EDiagnostics_002EDiagnosticSource_002ENullable(new byte[] { 2, 1 })]
		set;
	}

	public SampleActivity<ActivityContext> Sample { get; set; }

	public void Dispose()
	{
		ActivitySource.DetachListener(this);
	}
}
