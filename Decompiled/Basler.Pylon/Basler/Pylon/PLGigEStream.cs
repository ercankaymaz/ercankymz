using System.ComponentModel;

namespace Basler.Pylon;

public static class PLGigEStream
{
	[EditorBrowsable(EditorBrowsableState.Never)]
	public class TypeEnum : ParameterListEnum
	{
		public override string Name => "@StreamGrabber0/Type";

		public string NoDriverAvailable => "NoDriverAvailable";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class StatusEnum : ParameterListEnum
	{
		public override string Name => "@StreamGrabber0/Status";

		public string Locked => "Locked";

		public string Open => "Open";

		public string Closed => "Closed";

		public string NotInitialized => "NotInitialized";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class AccessModeEnum : ParameterListEnum
	{
		public override string Name => "@StreamGrabber0/AccessMode";

		public string Exclusive => "Exclusive";

		public string Control => "Control";

		public string Monitor => "Monitor";

		public string NotInitialized => "NotInitialized";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class TransmissionTypeEnum : ParameterListEnum
	{
		public override string Name => "@StreamGrabber0/TransmissionType";

		public string SubnetDirectedBroadcast => "SubnetDirectedBroadcast";

		public string LimitedBroadcast => "LimitedBroadcast";

		public string Multicast => "Multicast";

		public string Unicast => "Unicast";

		public string UseCameraConfig => "UseCameraConfig";

		public override string ToString()
		{
			return Name;
		}
	}

	public static IntegerName DestinationPort => (IntegerName)"@StreamGrabber0/DestinationPort";

	public static StringName DestinationAddr => (StringName)"@StreamGrabber0/DestinationAddr";

	public static TransmissionTypeEnum TransmissionType => new TransmissionTypeEnum();

	public static IntegerName Statistic_Resend_Packet_Count => (IntegerName)"@StreamGrabber0/Statistic_Resend_Packet_Count";

	public static IntegerName Statistic_Resend_Request_Count => (IntegerName)"@StreamGrabber0/Statistic_Resend_Request_Count";

	public static IntegerName Statistic_Failed_Packet_Count => (IntegerName)"@StreamGrabber0/Statistic_Failed_Packet_Count";

	public static IntegerName Statistic_Total_Packet_Count => (IntegerName)"@StreamGrabber0/Statistic_Total_Packet_Count";

	public static IntegerName Statistic_Buffer_Underrun_Count => (IntegerName)"@StreamGrabber0/Statistic_Buffer_Underrun_Count";

	public static IntegerName Statistic_Failed_Buffer_Count => (IntegerName)"@StreamGrabber0/Statistic_Failed_Buffer_Count";

	public static IntegerName Statistic_Total_Buffer_Count => (IntegerName)"@StreamGrabber0/Statistic_Total_Buffer_Count";

	public static IntegerName TypeIsSocketDriverAvailable => (IntegerName)"@StreamGrabber0/TypeIsSocketDriverAvailable";

	public static IntegerName TypeIsWindowsFilterDriverAvailable => (IntegerName)"@StreamGrabber0/TypeIsWindowsFilterDriverAvailable";

	public static IntegerName TypeIsWindowsIntelPerformanceDriverAvailable => (IntegerName)"@StreamGrabber0/TypeIsWindowsIntelPerformanceDriverAvailable";

	public static AccessModeEnum AccessMode => new AccessModeEnum();

	public static StatusEnum Status => new StatusEnum();

	public static IntegerName SocketBufferSize => (IntegerName)"@StreamGrabber0/SocketBufferSize";

	public static IntegerName ReceiveThreadPriority => (IntegerName)"@StreamGrabber0/ReceiveThreadPriority";

	public static BooleanName ReceiveThreadPriorityOverride => (BooleanName)"@StreamGrabber0/ReceiveThreadPriorityOverride";

	public static IntegerName FrameRetention => (IntegerName)"@StreamGrabber0/FrameRetention";

	public static BooleanName UseExtendedIdIfAvailable => (BooleanName)"@StreamGrabber0/UseExtendedIdIfAvailable";

	public static IntegerName MaximumNumberResendRequests => (IntegerName)"@StreamGrabber0/MaximumNumberResendRequests";

	public static IntegerName ResendRequestResponseTimeout => (IntegerName)"@StreamGrabber0/ResendRequestResponseTimeout";

	public static IntegerName ResendTimeout => (IntegerName)"@StreamGrabber0/ResendTimeout";

	public static IntegerName ResendRequestBatching => (IntegerName)"@StreamGrabber0/ResendRequestBatching";

	public static IntegerName ResendRequestThreshold => (IntegerName)"@StreamGrabber0/ResendRequestThreshold";

	public static IntegerName ReceiveWindowSize => (IntegerName)"@StreamGrabber0/ReceiveWindowSize";

	public static BooleanName AutoPacketSize => (BooleanName)"@StreamGrabber0/AutoPacketSize";

	public static IntegerName PacketTimeout => (IntegerName)"@StreamGrabber0/PacketTimeout";

	public static BooleanName EnableResend => (BooleanName)"@StreamGrabber0/EnableResend";

	public static IntegerName MaxBufferSize => (IntegerName)"@StreamGrabber0/MaxBufferSize";

	public static IntegerName MaxNumBuffer => (IntegerName)"@StreamGrabber0/MaxNumBuffer";

	public static TypeEnum Type => new TypeEnum();
}
