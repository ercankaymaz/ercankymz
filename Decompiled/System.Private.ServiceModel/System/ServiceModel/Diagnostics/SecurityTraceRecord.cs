using System.Runtime.Diagnostics;

namespace System.ServiceModel.Diagnostics;

internal class SecurityTraceRecord : TraceRecord
{
	private string _traceName;

	internal override string EventId => BuildEventId(_traceName);

	internal SecurityTraceRecord(string traceName)
	{
		if (string.IsNullOrEmpty(traceName))
		{
			_traceName = "Empty";
		}
		else
		{
			_traceName = traceName;
		}
	}
}
