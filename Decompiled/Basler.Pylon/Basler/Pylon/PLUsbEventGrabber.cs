namespace Basler.Pylon;

public static class PLUsbEventGrabber
{
	public static IntegerName Statistic_Last_Failed_Event_Buffer_Status => (IntegerName)"@EventGrabber/Statistic_Last_Failed_Event_Buffer_Status";

	public static IntegerName Statistic_Failed_Event_Count => (IntegerName)"@EventGrabber/Statistic_Failed_Event_Count";

	public static IntegerName Statistic_Total_Event_Count => (IntegerName)"@EventGrabber/Statistic_Total_Event_Count";

	public static IntegerName TransferLoopThreadPriority => (IntegerName)"@EventGrabber/TransferLoopThreadPriority";

	public static IntegerName NumMaxQueuedUrbs => (IntegerName)"@EventGrabber/NumMaxQueuedUrbs";

	public static IntegerName NumBuffer => (IntegerName)"@EventGrabber/NumBuffer";
}
