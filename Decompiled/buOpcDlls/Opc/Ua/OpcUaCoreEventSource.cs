using System;
using System.Diagnostics.Tracing;
using Microsoft.Extensions.Logging;

namespace Opc.Ua;

[EventSource(Name = "OPC-UA-Core", Guid = "753029BC-A4AA-4440-8668-290D0692A72B")]
internal sealed class OpcUaCoreEventSource : EventSource, ILogger
{
	public static class Tasks
	{
		public const EventTask ServiceCallTask = (EventTask)1;
	}

	public static class Keywords
	{
		public const EventKeywords FormattedMessage = (EventKeywords)1L;

		public const EventKeywords Services = (EventKeywords)2L;
	}

	private const int TraceId = 1;

	private const int DebugId = 2;

	private const int InfoId = 3;

	private const int WarningId = 4;

	private const int ErrorId = 5;

	private const int CriticalId = 6;

	private const int ServiceCallStartId = 9;

	private const int ServiceCallStopId = 10;

	private const int ServiceCallBadStopId = 11;

	private const int SubscriptionStateId = 12;

	private const int SendResponseId = 13;

	private const int ServiceFaultId = 14;

	private const string ServiceCallStartMessage = "{0} Called. RequestHandle={1}, PendingRequestCount={2}";

	private const string ServiceCallStopMessage = "{0} Completed. RequestHandle={1}, PendingRequestCount={2}";

	private const string ServiceCallBadStopMessage = "{0} Completed. RequestHandle={1}, PendingRequestCount={2}, StatusCode={3}";

	private const string SendResponseMessage = "ChannelId {0}: SendResponse {1}";

	private const string ServiceFaultMessage = "Service Fault Occured. Reason={0}";

	private readonly EventId ServiceCallStartEventId = new EventId(8, "ServiceCallStart");

	private readonly EventId ServiceCallStopEventId = new EventId(8, "ServiceCallStop");

	private readonly EventId ServiceCallBadStopEventId = new EventId(8, "ServiceCallBadStop");

	private readonly EventId SendResponseEventId = new EventId(8, "SendResponse");

	private readonly EventId ServiceFaultEventId = new EventId(8, "ServiceFault");

	[Event(6, Keywords = (EventKeywords)1L, Level = EventLevel.Critical)]
	internal void Critical(int eventId, string eventName, string message)
	{
		WriteFormattedMessage(6, eventId, eventName, message);
	}

	[Event(5, Keywords = (EventKeywords)1L, Level = EventLevel.Error)]
	internal void Error(int eventId, string eventName, string message)
	{
		WriteFormattedMessage(5, eventId, eventName, message);
	}

	[Event(4, Keywords = (EventKeywords)1L, Level = EventLevel.Warning)]
	internal void Warning(int eventId, string eventName, string message)
	{
		WriteFormattedMessage(4, eventId, eventName, message);
	}

	[Event(1, Keywords = (EventKeywords)1L, Level = EventLevel.Verbose)]
	internal void Trace(int eventId, string eventName, string message)
	{
		WriteFormattedMessage(1, eventId, eventName, message);
	}

	[Event(3, Keywords = (EventKeywords)1L, Level = EventLevel.Informational)]
	internal void Info(int eventId, string eventName, string message)
	{
		WriteFormattedMessage(3, eventId, eventName, message);
	}

	[Event(2, Keywords = (EventKeywords)1L, Level = EventLevel.Verbose)]
	internal void Debug(int eventId, string eventName, string message)
	{
	}

	[NonEvent]
	public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
	{
		if (!IsEnabled())
		{
			return;
		}
		string text = null;
		if (IsEnabled(EventLevel.Informational, (EventKeywords)1L))
		{
			text = formatter(state, exception);
			switch (logLevel)
			{
			case LogLevel.Trace:
				Trace(eventId.Id, eventId.Name, text);
				break;
			case LogLevel.Debug:
				Debug(eventId.Id, eventId.Name, text);
				break;
			case LogLevel.Information:
				Info(eventId.Id, eventId.Name, text);
				break;
			case LogLevel.Warning:
				Warning(eventId.Id, eventId.Name, text);
				break;
			case LogLevel.Error:
				Error(eventId.Id, eventId.Name, text);
				break;
			case LogLevel.Critical:
				Critical(eventId.Id, eventId.Name, text);
				break;
			}
		}
	}

	[NonEvent]
	public bool IsEnabled(LogLevel logLevel)
	{
		if (logLevel != LogLevel.None)
		{
			return IsEnabled();
		}
		return false;
	}

	[NonEvent]
	public IDisposable BeginScope<TState>(TState state)
	{
		return null;
	}

	[NonEvent]
	internal void WriteFormattedMessage(int id, int eventId, string EventName, string FormattedMessage)
	{
		if (IsEnabled())
		{
			EventName = EventName ?? "";
			FormattedMessage = FormattedMessage ?? "";
			WriteEvent(id, eventId, EventName, FormattedMessage);
		}
	}

	[NonEvent]
	private LogLevel GetDefaultLevel()
	{
		EventKeywords keywords = (EventKeywords)1L;
		if (IsEnabled(EventLevel.Verbose, keywords))
		{
			return LogLevel.Trace;
		}
		if (IsEnabled(EventLevel.Informational, keywords))
		{
			return LogLevel.Information;
		}
		if (IsEnabled(EventLevel.Warning, keywords))
		{
			return LogLevel.Warning;
		}
		if (IsEnabled(EventLevel.Error, keywords))
		{
			return LogLevel.Error;
		}
		return LogLevel.Critical;
	}

	[Event(9, Keywords = (EventKeywords)2L, Message = "{0} Called. RequestHandle={1}, PendingRequestCount={2}", Level = EventLevel.Verbose, Task = (EventTask)1)]
	public void ServiceCallStart(string serviceName, int requestHandle, int pendingRequestCount)
	{
		if (IsEnabled())
		{
			WriteEvent(9, serviceName, requestHandle, pendingRequestCount);
		}
		else if (Utils.Logger.IsEnabled(LogLevel.Trace))
		{
			Utils.Log(LogLevel.Trace, ServiceCallStartEventId, "{0} Called. RequestHandle={1}, PendingRequestCount={2}", serviceName, requestHandle, pendingRequestCount);
		}
	}

	[Event(10, Keywords = (EventKeywords)2L, Message = "{0} Completed. RequestHandle={1}, PendingRequestCount={2}", Level = EventLevel.Verbose, Task = (EventTask)1)]
	public void ServiceCallStop(string serviceName, int requestHandle, int pendingRequestCount)
	{
		if (IsEnabled())
		{
			WriteEvent(10, serviceName, requestHandle, pendingRequestCount);
		}
		else if (Utils.Logger.IsEnabled(LogLevel.Trace))
		{
			Utils.Log(LogLevel.Trace, ServiceCallStopEventId, "{0} Completed. RequestHandle={1}, PendingRequestCount={2}", serviceName, requestHandle, pendingRequestCount);
		}
	}

	[Event(11, Keywords = (EventKeywords)2L, Message = "{0} Completed. RequestHandle={1}, PendingRequestCount={2}, StatusCode={3}", Level = EventLevel.Warning, Task = (EventTask)1)]
	public void ServiceCallBadStop(string serviceName, int requestHandle, int statusCode, int pendingRequestCount)
	{
		if (IsEnabled())
		{
			WriteEvent(11, serviceName, requestHandle, pendingRequestCount, statusCode);
		}
		else if (Utils.Logger.IsEnabled(LogLevel.Trace))
		{
			Utils.Log(LogLevel.Trace, ServiceCallBadStopEventId, "{0} Completed. RequestHandle={1}, PendingRequestCount={2}, StatusCode={3}", serviceName, requestHandle, pendingRequestCount, statusCode);
		}
	}

	[Event(14, Message = "Service Fault Occured. Reason={0}", Level = EventLevel.Error)]
	public void ServiceFault(int statusCode)
	{
		if (IsEnabled())
		{
			WriteEvent(14, statusCode);
			return;
		}
		Utils.LogWarning(ServiceFaultEventId, "Service Fault Occured. Reason={0}", statusCode);
	}

	[Event(13, Message = "ChannelId {0}: SendResponse {1}", Level = EventLevel.Verbose)]
	public void SendResponse(int channelId, int requestId)
	{
		if (IsEnabled())
		{
			WriteEvent(13, channelId, requestId);
		}
		else if (Utils.Logger.IsEnabled(LogLevel.Trace))
		{
			Utils.Log(LogLevel.Trace, SendResponseEventId, "ChannelId {0}: SendResponse {1}", channelId, requestId);
		}
	}
}
