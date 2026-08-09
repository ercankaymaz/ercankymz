using System;
using System.Diagnostics.Tracing;
using Microsoft.Extensions.Logging;

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

	private readonly EventId SubscriptionStateMessageEventId = new EventId(32, "SubscriptionState");

	private readonly EventId NotificationEventId = new EventId(32, "Notification");

	private readonly EventId NotificationReceivedEventId = new EventId(32, "NotificationReceived");

	private readonly EventId PublishStartEventId = new EventId(16, "PublishStart");

	private readonly EventId PublishStopEventId = new EventId(16, "PublishStop");

	[Event(1, Message = "Subscription {0}, Id={1}, LastNotificationTime={2:HH:mm:ss}, GoodPublishRequestCount={3}, PublishingInterval={4}, KeepAliveCount={5}, PublishingEnabled={6}, MonitoredItemCount={7}", Level = EventLevel.Verbose)]
	public void SubscriptionState(string context, uint id, DateTime lastNotificationTime, int goodPublishRequestCount, double currentPublishingInterval, uint currentKeepAliveCount, bool currentPublishingEnabled, uint monitoredItemCount)
	{
		if (IsEnabled())
		{
			WriteEvent(1, context, id, lastNotificationTime, goodPublishRequestCount, currentPublishingInterval, currentKeepAliveCount, currentPublishingEnabled, monitoredItemCount);
		}
		else if (Utils.Logger.IsEnabled(LogLevel.Information))
		{
			Utils.LogInfo(SubscriptionStateMessageEventId, "Subscription {0}, Id={1}, LastNotificationTime={2:HH:mm:ss}, GoodPublishRequestCount={3}, PublishingInterval={4}, KeepAliveCount={5}, PublishingEnabled={6}, MonitoredItemCount={7}", context, id, lastNotificationTime, goodPublishRequestCount, currentPublishingInterval, currentKeepAliveCount, currentPublishingEnabled, monitoredItemCount);
		}
	}

	[Event(2, Message = "Notification: ClientHandle={0}, Value={1}", Level = EventLevel.Verbose)]
	public void Notification(int clientHandle, string value)
	{
		WriteEvent(2, value, clientHandle);
	}

	[Event(3, Message = "NOTIFICATION RECEIVED: SubId={0}, SeqNo={1}", Level = EventLevel.Verbose)]
	public void NotificationReceived(int subscriptionId, int sequenceNumber)
	{
		if (IsEnabled())
		{
			WriteEvent(3, subscriptionId, sequenceNumber);
		}
		else if (Utils.Logger.IsEnabled(LogLevel.Trace))
		{
			Utils.LogTrace(NotificationReceivedEventId, "NOTIFICATION RECEIVED: SubId={0}, SeqNo={1}", subscriptionId, sequenceNumber);
		}
	}

	[Event(3, Message = "PUBLISH #{0} SENT", Level = EventLevel.Verbose)]
	public void PublishStart(int requestHandle)
	{
		if (IsEnabled())
		{
			WriteEvent(3, requestHandle);
		}
		else if (Utils.Logger.IsEnabled(LogLevel.Trace))
		{
			Utils.LogTrace(PublishStartEventId, "PUBLISH #{0} SENT", requestHandle);
		}
	}

	[Event(4, Message = "PUBLISH #{0} RECEIVED", Level = EventLevel.Verbose)]
	public void PublishStop(int requestHandle)
	{
		if (IsEnabled())
		{
			WriteEvent(4, requestHandle);
		}
		else if (Utils.Logger.IsEnabled(LogLevel.Trace))
		{
			Utils.LogTrace(PublishStopEventId, "PUBLISH #{0} RECEIVED", requestHandle);
		}
	}

	[NonEvent]
	public void NotificationValue(uint clientHandle, Variant wrappedValue)
	{
		if ((Utils.TraceMask & 0x40) != 0)
		{
			if (IsEnabled())
			{
				Notification((int)clientHandle, wrappedValue.ToString());
			}
			else if (Utils.Logger.IsEnabled(LogLevel.Trace))
			{
				Utils.LogTrace(NotificationEventId, "Notification: ClientHandle={0}, Value={1}", clientHandle, wrappedValue);
			}
		}
	}
}
