using System.Runtime.InteropServices;

namespace System.Diagnostics;

[Flags]
[ComVisible(true)]
public enum ActivityTraceFlags
{
	None = 0,
	Recorded = 1
}
