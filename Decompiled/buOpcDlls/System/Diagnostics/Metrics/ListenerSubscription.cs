using System.Runtime.CompilerServices;

namespace System.Diagnostics.Metrics;

[System_002EDiagnostics_002EDiagnosticSource_002EIsReadOnly]
internal struct ListenerSubscription
{
	internal MeterListener Listener { get; }

	internal object State { get; }

	internal ListenerSubscription(MeterListener listener, object state = null)
	{
		Listener = listener;
		State = state;
	}
}
