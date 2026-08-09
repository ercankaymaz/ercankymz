using System.ComponentModel;

namespace Basler.Pylon;

public static class PLStream
{
	[EditorBrowsable(EditorBrowsableState.Never)]
	public class AccessModeEnum : ParameterListEnum
	{
		public override string Name => "@StreamGrabber0/AccessMode";

		public string NotInitialized => "NotInitialized";

		public string Monitor => "Monitor";

		public string Exclusive => "Exclusive";

		public string Control => "Control";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class StatusEnum : ParameterListEnum
	{
		public override string Name => "@StreamGrabber0/Status";

		public string Open => "Open";

		public string NotInitialized => "NotInitialized";

		public string Locked => "Locked";

		public string Closed => "Closed";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class StreamBufferHandlingModeEnum : ParameterListEnum
	{
		public override string Name => "@StreamGrabber0/StreamBufferHandlingMode";

		public string OldestFirstOverwrite => "OldestFirstOverwrite";

		public string OldestFirst => "OldestFirst";

		public string NewestOnly => "NewestOnly";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class StreamTypeEnum : ParameterListEnum
	{
		public override string Name => "@StreamGrabber0/StreamType";

		public string USB3Vision => "USB3Vision";

		public string U3V => "U3V";

		public string Mixed => "Mixed";

		public string GigEVision => "GigEVision";

		public string GEV => "GEV";

		public string Custom => "Custom";

		public string CoaXPress => "CoaXPress";

		public string CameraLinkHS => "CameraLinkHS";

		public string CameraLink => "CameraLink";

		public string CXP => "CXP";

		public string CLHS => "CLHS";

		public string CL => "CL";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class TransmissionTypeEnum : ParameterListEnum
	{
		public override string Name => "@StreamGrabber0/TransmissionType";

		public string UseCameraConfig => "UseCameraConfig";

		public string Unicast => "Unicast";

		public string SubnetDirectedBroadcast => "SubnetDirectedBroadcast";

		public string Multicast => "Multicast";

		public string LimitedBroadcast => "LimitedBroadcast";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class TypeEnum : ParameterListEnum
	{
		public override string Name => "@StreamGrabber0/Type";

		public string WindowsIntelPerformanceDriver => "WindowsIntelPerformanceDriver";

		public string WindowsFilterDriver => "WindowsFilterDriver";

		public string SocketDriver => "SocketDriver";

		public string NoDriverAvailable => "NoDriverAvailable";

		public override string ToString()
		{
			return Name;
		}
	}

	private static AccessModeEnum m_AccessModeCached = null;

	private static StatusEnum m_StatusCached = null;

	private static StreamBufferHandlingModeEnum m_StreamBufferHandlingModeCached = null;

	private static StreamTypeEnum m_StreamTypeCached = null;

	private static TransmissionTypeEnum m_TransmissionTypeCached = null;

	private static TypeEnum m_TypeCached = null;

	public static BooleanName UseExtendedIdIfAvailable => new BooleanName("@StreamGrabber0/UseExtendedIdIfAvailable");

	public static IntegerName TypeIsWindowsIntelPerformanceDriverAvailable => new IntegerName("@StreamGrabber0/TypeIsWindowsIntelPerformanceDriverAvailable");

	public static IntegerName TypeIsWindowsFilterDriverAvailable => new IntegerName("@StreamGrabber0/TypeIsWindowsFilterDriverAvailable");

	public static IntegerName TypeIsSocketDriverAvailable => new IntegerName("@StreamGrabber0/TypeIsSocketDriverAvailable");

	public static TypeEnum Type
	{
		get
		{
			if (m_TypeCached == null)
			{
				m_TypeCached = new TypeEnum();
			}
			return m_TypeCached;
		}
	}

	public static TransmissionTypeEnum TransmissionType
	{
		get
		{
			if (m_TransmissionTypeCached == null)
			{
				m_TransmissionTypeCached = new TransmissionTypeEnum();
			}
			return m_TransmissionTypeCached;
		}
	}

	public static IntegerName TransferLoopThreadPriority => new IntegerName("@StreamGrabber0/TransferLoopThreadPriority");

	public static StreamTypeEnum StreamType
	{
		get
		{
			if (m_StreamTypeCached == null)
			{
				m_StreamTypeCached = new StreamTypeEnum();
			}
			return m_StreamTypeCached;
		}
	}

	public static IntegerName StreamStartedFrameCount => new IntegerName("@StreamGrabber0/StreamStartedFrameCount");

	public static IntegerName StreamOutputBufferCount => new IntegerName("@StreamGrabber0/StreamOutputBufferCount");

	public static IntegerName StreamLostFrameCount => new IntegerName("@StreamGrabber0/StreamLostFrameCount");

	public static BooleanName StreamIsGrabbing => new BooleanName("@StreamGrabber0/StreamIsGrabbing");

	public static IntegerName StreamInputBufferCount => new IntegerName("@StreamGrabber0/StreamInputBufferCount");

	public static StringName StreamID => new StringName("@StreamGrabber0/StreamID");

	public static IntegerName StreamDeliveredFrameCount => new IntegerName("@StreamGrabber0/StreamDeliveredFrameCount");

	public static IntegerName StreamChunkCountMaximum => new IntegerName("@StreamGrabber0/StreamChunkCountMaximum");

	public static StreamBufferHandlingModeEnum StreamBufferHandlingMode
	{
		get
		{
			if (m_StreamBufferHandlingModeCached == null)
			{
				m_StreamBufferHandlingModeCached = new StreamBufferHandlingModeEnum();
			}
			return m_StreamBufferHandlingModeCached;
		}
	}

	public static IntegerName StreamBufferAlignment => new IntegerName("@StreamGrabber0/StreamBufferAlignment");

	public static IntegerName StreamAnnouncedBufferCount => new IntegerName("@StreamGrabber0/StreamAnnouncedBufferCount");

	public static IntegerName StreamAnnounceBufferMinimum => new IntegerName("@StreamGrabber0/StreamAnnounceBufferMinimum");

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

	public static IntegerName Statistic_Total_Packet_Count => new IntegerName("@StreamGrabber0/Statistic_Total_Packet_Count");

	public static IntegerName Statistic_Total_Buffer_Count => new IntegerName("@StreamGrabber0/Statistic_Total_Buffer_Count");

	public static IntegerName Statistic_Resynchronization_Count => new IntegerName("@StreamGrabber0/Statistic_Resynchronization_Count");

	public static IntegerName Statistic_Resend_Request_Count => new IntegerName("@StreamGrabber0/Statistic_Resend_Request_Count");

	public static IntegerName Statistic_Resend_Packet_Count => new IntegerName("@StreamGrabber0/Statistic_Resend_Packet_Count");

	public static IntegerName Statistic_Out_Of_Memory_Error_Count => new IntegerName("@StreamGrabber0/Statistic_Out_Of_Memory_Error_Count");

	public static IntegerName Statistic_Missed_Frame_Count => new IntegerName("@StreamGrabber0/Statistic_Missed_Frame_Count");

	public static StringName Statistic_Last_Failed_Buffer_Status_Text => new StringName("@StreamGrabber0/Statistic_Last_Failed_Buffer_Status_Text");

	public static IntegerName Statistic_Last_Failed_Buffer_Status => new IntegerName("@StreamGrabber0/Statistic_Last_Failed_Buffer_Status");

	public static IntegerName Statistic_Last_Block_Id => new IntegerName("@StreamGrabber0/Statistic_Last_Block_Id");

	public static IntegerName Statistic_Failed_Packet_Count => new IntegerName("@StreamGrabber0/Statistic_Failed_Packet_Count");

	public static IntegerName Statistic_Failed_Buffer_Count => new IntegerName("@StreamGrabber0/Statistic_Failed_Buffer_Count");

	public static IntegerName Statistic_Buffer_Underrun_Count => new IntegerName("@StreamGrabber0/Statistic_Buffer_Underrun_Count");

	public static IntegerName SocketBufferSize => new IntegerName("@StreamGrabber0/SocketBufferSize");

	public static IntegerName ResendTimeout => new IntegerName("@StreamGrabber0/ResendTimeout");

	public static IntegerName ResendRequestThreshold => new IntegerName("@StreamGrabber0/ResendRequestThreshold");

	public static IntegerName ResendRequestResponseTimeout => new IntegerName("@StreamGrabber0/ResendRequestResponseTimeout");

	public static IntegerName ResendRequestBatching => new IntegerName("@StreamGrabber0/ResendRequestBatching");

	public static IntegerName ReceiveWindowSize => new IntegerName("@StreamGrabber0/ReceiveWindowSize");

	public static BooleanName ReceiveThreadPriorityOverride => new BooleanName("@StreamGrabber0/ReceiveThreadPriorityOverride");

	public static IntegerName ReceiveThreadPriority => new IntegerName("@StreamGrabber0/ReceiveThreadPriority");

	public static CommandName ProbePacketSize => new CommandName("@StreamGrabber0/ProbePacketSize");

	public static IntegerName PayloadSize => new IntegerName("@StreamGrabber0/PayloadSize");

	public static IntegerName PacketTimeout => new IntegerName("@StreamGrabber0/PacketTimeout");

	public static IntegerName NumMaxQueuedUrbs => new IntegerName("@StreamGrabber0/NumMaxQueuedUrbs");

	public static IntegerName MaximumNumberResendRequests => new IntegerName("@StreamGrabber0/MaximumNumberResendRequests");

	public static IntegerName MaxTransferSize => new IntegerName("@StreamGrabber0/MaxTransferSize");

	public static IntegerName MaxNumBuffer => new IntegerName("@StreamGrabber0/MaxNumBuffer");

	public static IntegerName MaxBufferSize => new IntegerName("@StreamGrabber0/MaxBufferSize");

	public static IntegerName FrameRetention => new IntegerName("@StreamGrabber0/FrameRetention");

	public static IntegerName FirewallTraversalInterval => new IntegerName("@StreamGrabber0/FirewallTraversalInterval");

	public static BooleanName EnableResend => new BooleanName("@StreamGrabber0/EnableResend");

	public static IntegerName DestinationPort => new IntegerName("@StreamGrabber0/DestinationPort");

	public static StringName DestinationAddr => new StringName("@StreamGrabber0/DestinationAddr");

	public static BooleanName AutoPacketSize => new BooleanName("@StreamGrabber0/AutoPacketSize");

	public static AccessModeEnum AccessMode
	{
		get
		{
			if (m_AccessModeCached == null)
			{
				m_AccessModeCached = new AccessModeEnum();
			}
			return m_AccessModeCached;
		}
	}
}
