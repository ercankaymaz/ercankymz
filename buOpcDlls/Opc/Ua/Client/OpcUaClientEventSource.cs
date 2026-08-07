// Decompiled with JetBrains decompiler
// Type: Opc.Ua.Client.OpcUaClientEventSource
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics.Tracing;

#nullable disable
namespace Opc.Ua.Client;

[EventSource(Name = "OPC-UA-Client", Guid = "8CFA469E-18C6-480F-9B74-B005DACDE3D3")]
internal class OpcUaClientEventSource : EventSource
{
  private const int SubscriptionStateId = 1;
  private const int NotificationId = 2;
  private const int NotificationReceivedId = 3;
  private const int PublishStartId = 3;
  private const int PublishStopId = 4;
  private const string SubscriptionStateMessage = "Subscription {0}, Id={1}, LastNotificationTime={2:HH:mm:ss}, GoodPublishRequestCount={3}, PublishingInterval={4}, KeepAliveCount={5}, PublishingEnabled={6}, MonitoredItemCount={7}";
  private const string NotificationMessage = "Notification: ClientHandle={0}, Value={1}";
  private const string NotificationReceivedMessage = "NOTIFICATION RECEIVED: SubId={0}, SeqNo={1}";
  private const string PublishStartMessage = "PUBLISH #{0} SENT";
  private const string PublishStopMessage = "PUBLISH #{0} RECEIVED";
  private readonly EventId SubscriptionStateMessageEventId = new EventId(32 /*0x20*/, "SubscriptionState");
  private readonly EventId NotificationEventId = new EventId(32 /*0x20*/, "Notification");
  private readonly EventId NotificationReceivedEventId = new EventId(32 /*0x20*/, "NotificationReceived");
  private readonly EventId PublishStartEventId = new EventId(16 /*0x10*/, "PublishStart");
  private readonly EventId PublishStopEventId = new EventId(16 /*0x10*/, "PublishStop");

  [Event(1, Message = "Subscription {0}, Id={1}, LastNotificationTime={2:HH:mm:ss}, GoodPublishRequestCount={3}, PublishingInterval={4}, KeepAliveCount={5}, PublishingEnabled={6}, MonitoredItemCount={7}", Level = EventLevel.Verbose)]
  public void SubscriptionState(
    string context,
    uint id,
    DateTime lastNotificationTime,
    int goodPublishRequestCount,
    double currentPublishingInterval,
    uint currentKeepAliveCount,
    bool currentPublishingEnabled,
    uint monitoredItemCount)
  {
    if (this.IsEnabled())
    {
      this.WriteEvent(1, (object) context, (object) id, (object) lastNotificationTime, (object) goodPublishRequestCount, (object) currentPublishingInterval, (object) currentKeepAliveCount, (object) currentPublishingEnabled, (object) monitoredItemCount);
    }
    else
    {
      if (!Utils.Logger.IsEnabled(Microsoft.Extensions.Logging.LogLevel.Information))
        return;
      Utils.LogInfo(this.SubscriptionStateMessageEventId, "Subscription {0}, Id={1}, LastNotificationTime={2:HH:mm:ss}, GoodPublishRequestCount={3}, PublishingInterval={4}, KeepAliveCount={5}, PublishingEnabled={6}, MonitoredItemCount={7}", (object) context, (object) id, (object) lastNotificationTime, (object) goodPublishRequestCount, (object) currentPublishingInterval, (object) currentKeepAliveCount, (object) currentPublishingEnabled, (object) monitoredItemCount);
    }
  }

  [Event(2, Message = "Notification: ClientHandle={0}, Value={1}", Level = EventLevel.Verbose)]
  public void Notification(int clientHandle, string value)
  {
    this.WriteEvent(2, value, clientHandle);
  }

  [Event(3, Message = "NOTIFICATION RECEIVED: SubId={0}, SeqNo={1}", Level = EventLevel.Verbose)]
  public void NotificationReceived(int subscriptionId, int sequenceNumber)
  {
    if (this.IsEnabled())
    {
      this.WriteEvent(3, subscriptionId, sequenceNumber);
    }
    else
    {
      if (!Utils.Logger.IsEnabled(Microsoft.Extensions.Logging.LogLevel.Trace))
        return;
      Utils.LogTrace(this.NotificationReceivedEventId, "NOTIFICATION RECEIVED: SubId={0}, SeqNo={1}", (object) subscriptionId, (object) sequenceNumber);
    }
  }

  [Event(3, Message = "PUBLISH #{0} SENT", Level = EventLevel.Verbose)]
  public void PublishStart(int requestHandle)
  {
    if (this.IsEnabled())
    {
      this.WriteEvent(3, requestHandle);
    }
    else
    {
      if (!Utils.Logger.IsEnabled(Microsoft.Extensions.Logging.LogLevel.Trace))
        return;
      Utils.LogTrace(this.PublishStartEventId, "PUBLISH #{0} SENT", (object) requestHandle);
    }
  }

  [Event(4, Message = "PUBLISH #{0} RECEIVED", Level = EventLevel.Verbose)]
  public void PublishStop(int requestHandle)
  {
    if (this.IsEnabled())
    {
      this.WriteEvent(4, requestHandle);
    }
    else
    {
      if (!Utils.Logger.IsEnabled(Microsoft.Extensions.Logging.LogLevel.Trace))
        return;
      Utils.LogTrace(this.PublishStopEventId, "PUBLISH #{0} RECEIVED", (object) requestHandle);
    }
  }

  [NonEvent]
  public void NotificationValue(uint clientHandle, Opc.Ua.Variant wrappedValue)
  {
    if ((Utils.TraceMask & 64 /*0x40*/) == 0)
      return;
    if (this.IsEnabled())
    {
      this.Notification((int) clientHandle, wrappedValue.ToString());
    }
    else
    {
      if (!Utils.Logger.IsEnabled(Microsoft.Extensions.Logging.LogLevel.Trace))
        return;
      Utils.LogTrace(this.NotificationEventId, "Notification: ClientHandle={0}, Value={1}", (object) clientHandle, (object) wrappedValue);
    }
  }
}
