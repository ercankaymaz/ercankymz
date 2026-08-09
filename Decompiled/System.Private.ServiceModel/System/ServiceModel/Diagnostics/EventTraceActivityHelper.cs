using System.Runtime.Diagnostics;
using System.Security;
using System.ServiceModel.Channels;
using System.Xml;

namespace System.ServiceModel.Diagnostics;

internal static class EventTraceActivityHelper
{
	public static bool TryAttachActivity(Message message, EventTraceActivity activity)
	{
		if (FxTrace.Trace.IsEnd2EndActivityTracingEnabled && message != null && activity != null && !message.Properties.ContainsKey(EventTraceActivity.Name))
		{
			message.Properties.Add(EventTraceActivity.Name, activity);
			return true;
		}
		return false;
	}

	public static EventTraceActivity TryExtractActivity(Message message)
	{
		return TryExtractActivity(message, createIfNotExist: false);
	}

	public static EventTraceActivity TryExtractActivity(Message message, bool createIfNotExist)
	{
		EventTraceActivity eventTraceActivity = null;
		if (message != null && message.State != MessageState.Closed)
		{
			if (message.Properties.TryGetValue(EventTraceActivity.Name, out var value))
			{
				eventTraceActivity = value as EventTraceActivity;
			}
			if (eventTraceActivity == null)
			{
				if (GetMessageId(message, out var guid))
				{
					eventTraceActivity = new EventTraceActivity(guid);
				}
				else
				{
					UniqueId relatesTo = message.Headers.RelatesTo;
					if (relatesTo != null && relatesTo.TryGetGuid(out guid))
					{
						eventTraceActivity = new EventTraceActivity(guid);
					}
				}
				if (eventTraceActivity == null && createIfNotExist)
				{
					eventTraceActivity = new EventTraceActivity();
				}
				if (eventTraceActivity != null)
				{
					message.Properties[EventTraceActivity.Name] = eventTraceActivity;
				}
			}
		}
		return eventTraceActivity;
	}

	[SecurityCritical]
	internal static void SetOnThread(EventTraceActivity eventTraceActivity)
	{
	}

	private static bool GetMessageId(Message message, out Guid guid)
	{
		UniqueId messageId = message.Headers.MessageId;
		if (messageId == null)
		{
			guid = Guid.Empty;
			return false;
		}
		return messageId.TryGetGuid(out guid);
	}
}
