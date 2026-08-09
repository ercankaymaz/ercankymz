using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Newtonsoft.Json.Serialization;

public class DiagnosticsTraceWriter : ITraceWriter
{
	public TraceLevel LevelFilter { get; set; }

	private TraceEventType GetTraceEventType(TraceLevel level)
	{
		return level switch
		{
			TraceLevel.Error => TraceEventType.Error, 
			TraceLevel.Warning => TraceEventType.Warning, 
			TraceLevel.Info => TraceEventType.Information, 
			TraceLevel.Verbose => TraceEventType.Verbose, 
			_ => throw new ArgumentOutOfRangeException("level"), 
		};
	}

	[Newtonsoft_002EJson_002ENullableContext(1)]
	public void Trace(TraceLevel level, string message, [Newtonsoft_002EJson_002ENullable(2)] Exception ex)
	{
		if (level == TraceLevel.Off)
		{
			return;
		}
		TraceEventCache eventCache = new TraceEventCache();
		TraceEventType traceEventType = GetTraceEventType(level);
		foreach (TraceListener listener in System.Diagnostics.Trace.Listeners)
		{
			if (!listener.IsThreadSafe)
			{
				lock (listener)
				{
					listener.TraceEvent(eventCache, "Newtonsoft.Json", traceEventType, 0, message);
				}
			}
			else
			{
				listener.TraceEvent(eventCache, "Newtonsoft.Json", traceEventType, 0, message);
			}
			if (System.Diagnostics.Trace.AutoFlush)
			{
				listener.Flush();
			}
		}
	}
}
