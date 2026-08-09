#define TRACE
using System;
using System.Diagnostics;

namespace buPop3.Common.Logging;

public class DiagnosticsLogger : ILog
{
	public void LogError(string message)
	{
		if (message == null)
		{
			throw new ArgumentNullException("message");
		}
		Trace.WriteLine("buPop3: " + message);
	}

	public void LogDebug(string message)
	{
		if (message == null)
		{
			throw new ArgumentNullException("message");
		}
		Trace.WriteLine("buPop3: (DEBUG) " + message);
	}
}
