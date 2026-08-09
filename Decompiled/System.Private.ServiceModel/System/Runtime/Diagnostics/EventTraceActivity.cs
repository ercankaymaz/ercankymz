using System.Diagnostics;
using System.Diagnostics.Tracing;

namespace System.Runtime.Diagnostics;

public class EventTraceActivity
{
	public Guid ActivityId;

	private static EventTraceActivity s_empty;

	public static EventTraceActivity Empty
	{
		get
		{
			if (s_empty == null)
			{
				s_empty = new EventTraceActivity(Guid.Empty);
			}
			return s_empty;
		}
	}

	public static string Name => "E2EActivity";

	public EventTraceActivity(bool setOnThread = false)
		: this(Guid.NewGuid(), setOnThread)
	{
	}

	public EventTraceActivity(Guid guid, bool setOnThread = false)
	{
		ActivityId = guid;
		if (setOnThread)
		{
			SetActivityIdOnThread();
		}
	}

	public static EventTraceActivity GetFromThreadOrCreate(bool clearIdOnThread = false)
	{
		Guid guid = Trace.CorrelationManager.ActivityId;
		if (guid == Guid.Empty)
		{
			guid = Guid.NewGuid();
		}
		else if (clearIdOnThread)
		{
			Trace.CorrelationManager.ActivityId = Guid.Empty;
		}
		return new EventTraceActivity(guid);
	}

	public static Guid GetActivityIdFromThread()
	{
		return EventSource.CurrentThreadActivityId;
	}

	private void SetActivityIdOnThread()
	{
		EventSource.SetCurrentThreadActivityId(ActivityId);
	}
}
