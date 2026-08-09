using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Microsoft.Extensions.Logging;

[Microsoft_002EExtensions_002ELogging_002EAbstractions_002ENullableContext(1)]
[Microsoft_002EExtensions_002ELogging_002EAbstractions_002ENullable(0)]
[AttributeUsage(AttributeTargets.Method)]
[ComVisible(true)]
public sealed class LoggerMessageAttribute : Attribute
{
	public int EventId { get; set; } = -1;

	[Microsoft_002EExtensions_002ELogging_002EAbstractions_002ENullable(2)]
	public string EventName
	{
		[Microsoft_002EExtensions_002ELogging_002EAbstractions_002ENullableContext(2)]
		get;
		[Microsoft_002EExtensions_002ELogging_002EAbstractions_002ENullableContext(2)]
		set;
	}

	public LogLevel Level { get; set; } = LogLevel.None;

	public string Message { get; set; } = "";

	public bool SkipEnabledCheck { get; set; }

	public LoggerMessageAttribute()
	{
	}

	public LoggerMessageAttribute(int eventId, LogLevel level, string message)
	{
		EventId = eventId;
		Level = level;
		Message = message;
	}
}
