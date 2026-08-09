using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace System.Diagnostics;

[System_002EDiagnostics_002EDiagnosticSource_002ENullableContext(1)]
[System_002EDiagnostics_002EDiagnosticSource_002ENullable(0)]
[ComVisible(true)]
public abstract class DiagnosticSource
{
	internal const string WriteRequiresUnreferencedCode = "The type of object being written to DiagnosticSource cannot be discovered statically.";

	[RequiresUnreferencedCode("The type of object being written to DiagnosticSource cannot be discovered statically.")]
	public abstract void Write(string name, [System_002EDiagnostics_002EDiagnosticSource_002ENullable(2)] object value);

	public abstract bool IsEnabled(string name);

	[System_002EDiagnostics_002EDiagnosticSource_002ENullableContext(2)]
	public virtual bool IsEnabled([System_002EDiagnostics_002EDiagnosticSource_002ENullable(1)] string name, object arg1, object arg2 = null)
	{
		return IsEnabled(name);
	}

	[RequiresUnreferencedCode("The type of object being written to DiagnosticSource cannot be discovered statically.")]
	public Activity StartActivity(Activity activity, [System_002EDiagnostics_002EDiagnosticSource_002ENullable(2)] object args)
	{
		activity.Start();
		Write(activity.OperationName + ".Start", args);
		return activity;
	}

	[RequiresUnreferencedCode("The type of object being written to DiagnosticSource cannot be discovered statically.")]
	public void StopActivity(Activity activity, [System_002EDiagnostics_002EDiagnosticSource_002ENullable(2)] object args)
	{
		if (activity.Duration == TimeSpan.Zero)
		{
			activity.SetEndTime(Activity.GetUtcNow());
		}
		Write(activity.OperationName + ".Stop", args);
		activity.Stop();
	}

	public virtual void OnActivityImport(Activity activity, [System_002EDiagnostics_002EDiagnosticSource_002ENullable(2)] object payload)
	{
	}

	public virtual void OnActivityExport(Activity activity, [System_002EDiagnostics_002EDiagnosticSource_002ENullable(2)] object payload)
	{
	}
}
