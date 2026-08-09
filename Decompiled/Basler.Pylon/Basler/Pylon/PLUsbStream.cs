namespace Basler.Pylon;

public static class PLUsbStream
{
	public static IntegerName Statistic_Last_Block_Id => (IntegerName)"@StreamGrabber0/Statistic_Last_Block_Id";

	public static IntegerName Statistic_Resynchronization_Count => (IntegerName)"@StreamGrabber0/Statistic_Resynchronization_Count";

	public static IntegerName Statistic_Missed_Frame_Count => (IntegerName)"@StreamGrabber0/Statistic_Missed_Frame_Count";

	public static StringName Statistic_Last_Failed_Buffer_Status_Text => (StringName)"@StreamGrabber0/Statistic_Last_Failed_Buffer_Status_Text";

	public static IntegerName Statistic_Last_Failed_Buffer_Status => (IntegerName)"@StreamGrabber0/Statistic_Last_Failed_Buffer_Status";

	public static IntegerName Statistic_Failed_Buffer_Count => (IntegerName)"@StreamGrabber0/Statistic_Failed_Buffer_Count";

	public static IntegerName Statistic_Total_Buffer_Count => (IntegerName)"@StreamGrabber0/Statistic_Total_Buffer_Count";

	public static IntegerName TransferTimeout => (IntegerName)"@StreamGrabber0/TransferTimeout";

	public static IntegerName TransferLoopThreadPriority => (IntegerName)"@StreamGrabber0/TransferLoopThreadPriority";

	public static IntegerName NumMaxQueuedUrbs => (IntegerName)"@StreamGrabber0/NumMaxQueuedUrbs";

	public static IntegerName MaxTransferSize => (IntegerName)"@StreamGrabber0/MaxTransferSize";

	public static IntegerName MaxBufferSize => (IntegerName)"@StreamGrabber0/MaxBufferSize";

	public static IntegerName MaxNumBuffer => (IntegerName)"@StreamGrabber0/MaxNumBuffer";
}
