using System.ComponentModel;

namespace Basler.Pylon;

public static class PLEventGrabber
{
	[EditorBrowsable(EditorBrowsableState.Never)]
	public class StatusEnum : ParameterListEnum
	{
		public override string Name => "@EventGrabber/Status";

		public string Open => "Open";

		public string Closed => "Closed";

		public override string ToString()
		{
			return Name;
		}
	}

	private static StatusEnum m_StatusCached = null;

	public static IntegerName TransferLoopThreadPriority => new IntegerName("@EventGrabber/TransferLoopThreadPriority");

	public static IntegerName Timeout => new IntegerName("@EventGrabber/Timeout");

	public static StatusEnum Status
	{
		get
		{
			if (m_StatusCached == null)
			{
				m_StatusCached = new StatusEnum();
			}
			return m_StatusCached;
		}
	}

	public static IntegerName Statistic_Total_Event_Count => new IntegerName("@EventGrabber/Statistic_Total_Event_Count");

	public static IntegerName Statistic_Last_Failed_Event_Buffer_Status => new IntegerName("@EventGrabber/Statistic_Last_Failed_Event_Buffer_Status");

	public static IntegerName Statistic_Failed_Event_Count => new IntegerName("@EventGrabber/Statistic_Failed_Event_Count");

	public static IntegerName RetryCount => new IntegerName("@EventGrabber/RetryCount");

	public static IntegerName NumMaxQueuedUrbs => new IntegerName("@EventGrabber/NumMaxQueuedUrbs");

	public static IntegerName NumBuffer => new IntegerName("@EventGrabber/NumBuffer");

	public static IntegerName FirewallTraversalInterval => new IntegerName("@EventGrabber/FirewallTraversalInterval");
}
