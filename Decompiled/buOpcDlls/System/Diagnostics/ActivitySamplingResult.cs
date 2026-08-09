using System.Runtime.InteropServices;

namespace System.Diagnostics;

[ComVisible(true)]
public enum ActivitySamplingResult
{
	None,
	PropagationData,
	AllData,
	AllDataAndRecorded
}
