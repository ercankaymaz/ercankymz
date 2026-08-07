// Decompiled with JetBrains decompiler
// Type: Opc.Ua.OpcUaCoreEventSource
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics.Tracing;

#nullable disable
namespace Opc.Ua;

[EventSource(Name = "OPC-UA-Core", Guid = "753029BC-A4AA-4440-8668-290D0692A72B")]
internal sealed class OpcUaCoreEventSource : EventSource, ILogger
{
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

  [Event(6, Keywords = (EventKeywords) 1, Level = EventLevel.Critical)]
  internal void Critical(int eventId, string eventName, string message)
  {
    this.WriteFormattedMessage(6, eventId, eventName, message);
  }

  [Event(5, Keywords = (EventKeywords) 1, Level = EventLevel.Error)]
  internal void Error(int eventId, string eventName, string message)
  {
    this.WriteFormattedMessage(5, eventId, eventName, message);
  }

  [Event(4, Keywords = (EventKeywords) 1, Level = EventLevel.Warning)]
  internal void Warning(int eventId, string eventName, string message)
  {
    this.WriteFormattedMessage(4, eventId, eventName, message);
  }

  [Event(1, Keywords = (EventKeywords) 1, Level = EventLevel.Verbose)]
  internal void Trace(int eventId, string eventName, string message)
  {
    this.WriteFormattedMessage(1, eventId, eventName, message);
  }

  [Event(3, Keywords = (EventKeywords) 1, Level = EventLevel.Informational)]
  internal void Info(int eventId, string eventName, string message)
  {
    this.WriteFormattedMessage(3, eventId, eventName, message);
  }

  [Event(2, Keywords = (EventKeywords) 1, Level = EventLevel.Verbose)]
  internal void Debug(int eventId, string eventName, string message)
  {
  }

  [NonEvent]
  public void Log<TState>(
    Microsoft.Extensions.Logging.LogLevel logLevel,
    EventId eventId,
    TState state,
    Exception exception,
    Func<TState, Exception, string> formatter)
  {
    if (!this.IsEnabled())
      return;
    if (!this.IsEnabled(EventLevel.Informational, (EventKeywords) 1))
      return;
    string message = formatter(state, exception);
    switch (logLevel)
    {
      case Microsoft.Extensions.Logging.LogLevel.Trace:
        this.Trace(eventId.Id, eventId.Name, message);
        break;
      case Microsoft.Extensions.Logging.LogLevel.Debug:
        this.Debug(eventId.Id, eventId.Name, message);
        break;
      case Microsoft.Extensions.Logging.LogLevel.Information:
        this.Info(eventId.Id, eventId.Name, message);
        break;
      case Microsoft.Extensions.Logging.LogLevel.Warning:
        this.Warning(eventId.Id, eventId.Name, message);
        break;
      case Microsoft.Extensions.Logging.LogLevel.Error:
        this.Error(eventId.Id, eventId.Name, message);
        break;
      case Microsoft.Extensions.Logging.LogLevel.Critical:
        this.Critical(eventId.Id, eventId.Name, message);
        break;
    }
  }

  [NonEvent]
  public bool IsEnabled(Microsoft.Extensions.Logging.LogLevel logLevel)
  {
    return logLevel != Microsoft.Extensions.Logging.LogLevel.None && this.IsEnabled();
  }

  [NonEvent]
  public IDisposable BeginScope<TState>(TState state) => (IDisposable) null;

  [NonEvent]
  internal void WriteFormattedMessage(
    int id,
    int eventId,
    string EventName,
    string FormattedMessage)
  {
    if (!this.IsEnabled())
      return;
    EventName = EventName ?? "";
    FormattedMessage = FormattedMessage ?? "";
    this.WriteEvent(id, (object) eventId, (object) EventName, (object) FormattedMessage);
  }

  [NonEvent]
  private Microsoft.Extensions.Logging.LogLevel GetDefaultLevel()
  {
    EventKeywords keywords = (EventKeywords) 1;
    if (this.IsEnabled(EventLevel.Verbose, (EventKeywords) 1))
      return Microsoft.Extensions.Logging.LogLevel.Trace;
    if (this.IsEnabled(EventLevel.Informational, keywords))
      return Microsoft.Extensions.Logging.LogLevel.Information;
    if (this.IsEnabled(EventLevel.Warning, keywords))
      return Microsoft.Extensions.Logging.LogLevel.Warning;
    return this.IsEnabled(EventLevel.Error, keywords) ? Microsoft.Extensions.Logging.LogLevel.Error : Microsoft.Extensions.Logging.LogLevel.Critical;
  }

  [Event(9, Keywords = (EventKeywords) 2, Message = "{0} Called. RequestHandle={1}, PendingRequestCount={2}", Level = EventLevel.Verbose, Task = (EventTask) 1)]
  public void ServiceCallStart(string serviceName, int requestHandle, int pendingRequestCount)
  {
    if (this.IsEnabled())
    {
      this.WriteEvent(9, serviceName, requestHandle, pendingRequestCount);
    }
    else
    {
      if (!Utils.Logger.IsEnabled(Microsoft.Extensions.Logging.LogLevel.Trace))
        return;
      Utils.Log(Microsoft.Extensions.Logging.LogLevel.Trace, this.ServiceCallStartEventId, "{0} Called. RequestHandle={1}, PendingRequestCount={2}", (object) serviceName, (object) requestHandle, (object) pendingRequestCount);
    }
  }

  [Event(10, Keywords = (EventKeywords) 2, Message = "{0} Completed. RequestHandle={1}, PendingRequestCount={2}", Level = EventLevel.Verbose, Task = (EventTask) 1)]
  public void ServiceCallStop(string serviceName, int requestHandle, int pendingRequestCount)
  {
    if (this.IsEnabled())
    {
      this.WriteEvent(10, serviceName, requestHandle, pendingRequestCount);
    }
    else
    {
      if (!Utils.Logger.IsEnabled(Microsoft.Extensions.Logging.LogLevel.Trace))
        return;
      Utils.Log(Microsoft.Extensions.Logging.LogLevel.Trace, this.ServiceCallStopEventId, "{0} Completed. RequestHandle={1}, PendingRequestCount={2}", (object) serviceName, (object) requestHandle, (object) pendingRequestCount);
    }
  }

  [Event(11, Keywords = (EventKeywords) 2, Message = "{0} Completed. RequestHandle={1}, PendingRequestCount={2}, StatusCode={3}", Level = EventLevel.Warning, Task = (EventTask) 1)]
  public void ServiceCallBadStop(
    string serviceName,
    int requestHandle,
    int statusCode,
    int pendingRequestCount)
  {
    if (this.IsEnabled())
    {
      this.WriteEvent(11, (object) serviceName, (object) requestHandle, (object) pendingRequestCount, (object) statusCode);
    }
    else
    {
      if (!Utils.Logger.IsEnabled(Microsoft.Extensions.Logging.LogLevel.Trace))
        return;
      Utils.Log(Microsoft.Extensions.Logging.LogLevel.Trace, this.ServiceCallBadStopEventId, "{0} Completed. RequestHandle={1}, PendingRequestCount={2}, StatusCode={3}", (object) serviceName, (object) requestHandle, (object) pendingRequestCount, (object) statusCode);
    }
  }

  [Event(14, Message = "Service Fault Occured. Reason={0}", Level = EventLevel.Error)]
  public void ServiceFault(int statusCode)
  {
    if (this.IsEnabled())
      this.WriteEvent(14, statusCode);
    else
      Utils.LogWarning(this.ServiceFaultEventId, "Service Fault Occured. Reason={0}", (object) statusCode);
  }

  [Event(13, Message = "ChannelId {0}: SendResponse {1}", Level = EventLevel.Verbose)]
  public void SendResponse(int channelId, int requestId)
  {
    if (this.IsEnabled())
    {
      this.WriteEvent(13, channelId, requestId);
    }
    else
    {
      if (!Utils.Logger.IsEnabled(Microsoft.Extensions.Logging.LogLevel.Trace))
        return;
      Utils.Log(Microsoft.Extensions.Logging.LogLevel.Trace, this.SendResponseEventId, "ChannelId {0}: SendResponse {1}", (object) channelId, (object) requestId);
    }
  }

  public static class Tasks
  {
    public const EventTask ServiceCallTask = (EventTask) 1;
  }

  public static class Keywords
  {
    public const EventKeywords FormattedMessage = (EventKeywords) 1;
    public const EventKeywords Services = (EventKeywords) 2;
  }
}
