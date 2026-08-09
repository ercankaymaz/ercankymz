using System.ComponentModel;

namespace Basler.Pylon;

public static class PLInterface
{
	[EditorBrowsable(EditorBrowsableState.Never)]
	public class CxpLinkConfigurationEnum : ParameterListEnum
	{
		public override string Name => "@Interface/CxpLinkConfiguration";

		public string CXP6_X1 => "CXP6_X1";

		public string CXP5_X1 => "CXP5_X1";

		public string CXP3_X1 => "CXP3_X1";

		public string CXP2_X1 => "CXP2_X1";

		public string CXP1_X1 => "CXP1_X1";

		public string CXP12_X1 => "CXP12_X1";

		public string CXP10_X1 => "CXP10_X1";

		public string Auto => "Auto";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class CxpPoCxpStatusEnum : ParameterListEnum
	{
		public override string Name => "@Interface/CxpPoCxpStatus";

		public string Tripped => "Tripped";

		public string Off => "Off";

		public string Auto => "Auto";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class CxpPort0PowerStateEnum : ParameterListEnum
	{
		public override string Name => "@Interface/CxpPort0PowerState";

		public string On => "On";

		public string LowVoltage => "LowVoltage";

		public string InvalidValue => "InvalidValue";

		public string Initializing => "Initializing";

		public string HighVoltage => "HighVoltage";

		public string HighCurrent => "HighCurrent";

		public string Disabled => "Disabled";

		public string AdcFault => "AdcFault";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class CxpPort1PowerStateEnum : ParameterListEnum
	{
		public override string Name => "@Interface/CxpPort1PowerState";

		public string On => "On";

		public string LowVoltage => "LowVoltage";

		public string InvalidValue => "InvalidValue";

		public string Initializing => "Initializing";

		public string HighVoltage => "HighVoltage";

		public string HighCurrent => "HighCurrent";

		public string Disabled => "Disabled";

		public string AdcFault => "AdcFault";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class CxpPort2PowerStateEnum : ParameterListEnum
	{
		public override string Name => "@Interface/CxpPort2PowerState";

		public string On => "On";

		public string LowVoltage => "LowVoltage";

		public string InvalidValue => "InvalidValue";

		public string Initializing => "Initializing";

		public string HighVoltage => "HighVoltage";

		public string HighCurrent => "HighCurrent";

		public string Disabled => "Disabled";

		public string AdcFault => "AdcFault";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class CxpPort3PowerStateEnum : ParameterListEnum
	{
		public override string Name => "@Interface/CxpPort3PowerState";

		public string On => "On";

		public string LowVoltage => "LowVoltage";

		public string InvalidValue => "InvalidValue";

		public string Initializing => "Initializing";

		public string HighVoltage => "HighVoltage";

		public string HighCurrent => "HighCurrent";

		public string Disabled => "Disabled";

		public string AdcFault => "AdcFault";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class DeviceAccessStatusEnum : ParameterListEnum
	{
		public override string Name => "@Interface/DeviceAccessStatus";

		public string Unknown => "Unknown";

		public string ReadWrite => "ReadWrite";

		public string ReadOnly => "ReadOnly";

		public string OpenReadWrite => "OpenReadWrite";

		public string OpenReadOnly => "OpenReadOnly";

		public string NoAccess => "NoAccess";

		public string Busy => "Busy";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class DiscoveryMethodEnum : ParameterListEnum
	{
		public override string Name => "@Interface/DiscoveryMethod";

		public string MixedDiscovery => "MixedDiscovery";

		public string EmulationDiscovery => "EmulationDiscovery";

		public string CameraDiscovery => "CameraDiscovery";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class EventNotificationEnum : ParameterListEnum
	{
		public override string Name => "@Interface/EventNotification";

		public string Once => "Once";

		public string On => "On";

		public string Off => "Off";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class EventSelectorEnum : ParameterListEnum
	{
		public override string Name => "@Interface/EventSelector";

		public string LineFront3RisingEdge => "LineFront3RisingEdge";

		public string LineFront3FallingEdge => "LineFront3FallingEdge";

		public string LineFront2RisingEdge => "LineFront2RisingEdge";

		public string LineFront2FallingEdge => "LineFront2FallingEdge";

		public string LineFront1RisingEdge => "LineFront1RisingEdge";

		public string LineFront1FallingEdge => "LineFront1FallingEdge";

		public string LineFront0RisingEdge => "LineFront0RisingEdge";

		public string LineFront0FallingEdge => "LineFront0FallingEdge";

		public string Line7RisingEdge => "Line7RisingEdge";

		public string Line7FallingEdge => "Line7FallingEdge";

		public string Line6RisingEdge => "Line6RisingEdge";

		public string Line6FallingEdge => "Line6FallingEdge";

		public string Line5RisingEdge => "Line5RisingEdge";

		public string Line5FallingEdge => "Line5FallingEdge";

		public string Line4RisingEdge => "Line4RisingEdge";

		public string Line4FallingEdge => "Line4FallingEdge";

		public string Line3RisingEdge => "Line3RisingEdge";

		public string Line3FallingEdge => "Line3FallingEdge";

		public string Line2RisingEdge => "Line2RisingEdge";

		public string Line2FallingEdge => "Line2FallingEdge";

		public string Line1RisingEdge => "Line1RisingEdge";

		public string Line1FallingEdge => "Line1FallingEdge";

		public string Line0RisingEdge => "Line0RisingEdge";

		public string Line0FallingEdge => "Line0FallingEdge";

		public string InterfaceLost => "InterfaceLost";

		public string DeviceListChanged => "DeviceListChanged";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class InterfaceAppletEnum : ParameterListEnum
	{
		public override string Name => "@Interface/InterfaceApplet";

		public string FrameGrabberTest => "FrameGrabberTest";

		public string Acq_TripleCXP12Line => "Acq_TripleCXP12Line";

		public string Acq_TripleCXP12Area => "Acq_TripleCXP12Area";

		public string Acq_SingleCXP12x1Area_02 => "Acq_SingleCXP12x1Area_02";

		public string Acq_SingleCXP12x1Area_01 => "Acq_SingleCXP12x1Area_01";

		public string Acq_SingleCXP12x1Area => "Acq_SingleCXP12x1Area";

		public string Acq_SingleCXP12Line => "Acq_SingleCXP12Line";

		public string Acq_SingleCXP12Area => "Acq_SingleCXP12Area";

		public string Acq_QuadCXP12Line => "Acq_QuadCXP12Line";

		public string Acq_QuadCXP12Area => "Acq_QuadCXP12Area";

		public string Acq_DualCXP12Line => "Acq_DualCXP12Line";

		public string Acq_DualCXP12Area => "Acq_DualCXP12Area";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class InterfaceAppletStatusEnum : ParameterListEnum
	{
		public override string Name => "@Interface/InterfaceAppletStatus";

		public string NotLoaded => "NotLoaded";

		public string Loading => "Loading";

		public string FrameGrabberTest => "FrameGrabberTest";

		public string Acq_TripleCXP12Line => "Acq_TripleCXP12Line";

		public string Acq_TripleCXP12Area => "Acq_TripleCXP12Area";

		public string Acq_SingleCXP12Line => "Acq_SingleCXP12Line";

		public string Acq_SingleCXP12Area => "Acq_SingleCXP12Area";

		public string Acq_QuadCXP12Line => "Acq_QuadCXP12Line";

		public string Acq_QuadCXP12Area => "Acq_QuadCXP12Area";

		public string Acq_DualCXP12Line => "Acq_DualCXP12Line";

		public string Acq_DualCXP12Area => "Acq_DualCXP12Area";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class InterfaceTypeEnum : ParameterListEnum
	{
		public override string Name => "@Interface/InterfaceType";

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

	private static CxpLinkConfigurationEnum m_CxpLinkConfigurationCached = null;

	private static CxpPoCxpStatusEnum m_CxpPoCxpStatusCached = null;

	private static CxpPort0PowerStateEnum m_CxpPort0PowerStateCached = null;

	private static CxpPort1PowerStateEnum m_CxpPort1PowerStateCached = null;

	private static CxpPort2PowerStateEnum m_CxpPort2PowerStateCached = null;

	private static CxpPort3PowerStateEnum m_CxpPort3PowerStateCached = null;

	private static DeviceAccessStatusEnum m_DeviceAccessStatusCached = null;

	private static DiscoveryMethodEnum m_DiscoveryMethodCached = null;

	private static EventNotificationEnum m_EventNotificationCached = null;

	private static EventSelectorEnum m_EventSelectorCached = null;

	private static InterfaceAppletEnum m_InterfaceAppletCached = null;

	private static InterfaceAppletStatusEnum m_InterfaceAppletStatusCached = null;

	private static InterfaceTypeEnum m_InterfaceTypeCached = null;

	public static CommandName UserSetSave => new CommandName("@Interface/UserSetSave");

	public static CommandName UserSetLoad => new CommandName("@Interface/UserSetLoad");

	public static StringName UserSetFile => new StringName("@Interface/UserSetFile");

	public static FloatName PowerSupplyTemperature => new FloatName("@Interface/PowerSupplyTemperature");

	public static InterfaceTypeEnum InterfaceType
	{
		get
		{
			if (m_InterfaceTypeCached == null)
			{
				m_InterfaceTypeCached = new InterfaceTypeEnum();
			}
			return m_InterfaceTypeCached;
		}
	}

	public static IntegerName InterfaceTLVersionMinor => new IntegerName("@Interface/InterfaceTLVersionMinor");

	public static IntegerName InterfaceTLVersionMajor => new IntegerName("@Interface/InterfaceTLVersionMajor");

	public static StringName InterfaceID => new StringName("@Interface/InterfaceID");

	public static StringName InterfaceFirmwareVersion => new StringName("@Interface/InterfaceFirmwareVersion");

	public static StringName InterfaceDisplayName => new StringName("@Interface/InterfaceDisplayName");

	public static StringName InterfaceAppletVersion => new StringName("@Interface/InterfaceAppletVersion");

	public static InterfaceAppletStatusEnum InterfaceAppletStatus
	{
		get
		{
			if (m_InterfaceAppletStatusCached == null)
			{
				m_InterfaceAppletStatusCached = new InterfaceAppletStatusEnum();
			}
			return m_InterfaceAppletStatusCached;
		}
	}

	public static StringName InterfaceAppletPath => new StringName("@Interface/InterfaceAppletPath");

	public static IntegerName InterfaceAppletNumOfDMAs => new IntegerName("@Interface/InterfaceAppletNumOfDMAs");

	public static IntegerName InterfaceAppletNumOfCameras => new IntegerName("@Interface/InterfaceAppletNumOfCameras");

	public static StringName InterfaceAppletDescription => new StringName("@Interface/InterfaceAppletDescription");

	public static StringName InterfaceAppletCategory => new StringName("@Interface/InterfaceAppletCategory");

	public static StringName InterfaceAppletBitStreamUID => new StringName("@Interface/InterfaceAppletBitStreamUID");

	public static InterfaceAppletEnum InterfaceApplet
	{
		get
		{
			if (m_InterfaceAppletCached == null)
			{
				m_InterfaceAppletCached = new InterfaceAppletEnum();
			}
			return m_InterfaceAppletCached;
		}
	}

	public static IntegerName GevDeviceSubnetMask => new IntegerName("@Interface/GevDeviceSubnetMask");

	public static IntegerName GevDeviceMACAddress => new IntegerName("@Interface/GevDeviceMACAddress");

	public static IntegerName GevDeviceIPAddress => new IntegerName("@Interface/GevDeviceIPAddress");

	public static FloatName FpgaCoreVoltage => new FloatName("@Interface/FpgaCoreVoltage");

	public static FloatName FpgaCoreTemperature => new FloatName("@Interface/FpgaCoreTemperature");

	public static FloatName FpgaBRamVoltage => new FloatName("@Interface/FpgaBRamVoltage");

	public static FloatName FpgaAuxVoltage => new FloatName("@Interface/FpgaAuxVoltage");

	public static BooleanName ExternalPowerPresent => new BooleanName("@Interface/ExternalPowerPresent");

	public static EventSelectorEnum EventSelector
	{
		get
		{
			if (m_EventSelectorCached == null)
			{
				m_EventSelectorCached = new EventSelectorEnum();
			}
			return m_EventSelectorCached;
		}
	}

	public static EventNotificationEnum EventNotification
	{
		get
		{
			if (m_EventNotificationCached == null)
			{
				m_EventNotificationCached = new EventNotificationEnum();
			}
			return m_EventNotificationCached;
		}
	}

	public static IntegerName EventLineFront3RisingEdgeTimestamp => new IntegerName("@Interface/EventLineFront3RisingEdgeTimestamp");

	public static IntegerName EventLineFront3RisingEdgeSoftCounter => new IntegerName("@Interface/EventLineFront3RisingEdgeSoftCounter");

	public static IntegerName EventLineFront3RisingEdge => new IntegerName("@Interface/EventLineFront3RisingEdge");

	public static IntegerName EventLineFront3FallingEdgeTimestamp => new IntegerName("@Interface/EventLineFront3FallingEdgeTimestamp");

	public static IntegerName EventLineFront3FallingEdgeSoftCounter => new IntegerName("@Interface/EventLineFront3FallingEdgeSoftCounter");

	public static IntegerName EventLineFront3FallingEdge => new IntegerName("@Interface/EventLineFront3FallingEdge");

	public static IntegerName EventLineFront2RisingEdgeTimestamp => new IntegerName("@Interface/EventLineFront2RisingEdgeTimestamp");

	public static IntegerName EventLineFront2RisingEdgeSoftCounter => new IntegerName("@Interface/EventLineFront2RisingEdgeSoftCounter");

	public static IntegerName EventLineFront2RisingEdge => new IntegerName("@Interface/EventLineFront2RisingEdge");

	public static IntegerName EventLineFront2FallingEdgeTimestamp => new IntegerName("@Interface/EventLineFront2FallingEdgeTimestamp");

	public static IntegerName EventLineFront2FallingEdgeSoftCounter => new IntegerName("@Interface/EventLineFront2FallingEdgeSoftCounter");

	public static IntegerName EventLineFront2FallingEdge => new IntegerName("@Interface/EventLineFront2FallingEdge");

	public static IntegerName EventLineFront1RisingEdgeTimestamp => new IntegerName("@Interface/EventLineFront1RisingEdgeTimestamp");

	public static IntegerName EventLineFront1RisingEdgeSoftCounter => new IntegerName("@Interface/EventLineFront1RisingEdgeSoftCounter");

	public static IntegerName EventLineFront1RisingEdge => new IntegerName("@Interface/EventLineFront1RisingEdge");

	public static IntegerName EventLineFront1FallingEdgeTimestamp => new IntegerName("@Interface/EventLineFront1FallingEdgeTimestamp");

	public static IntegerName EventLineFront1FallingEdgeSoftCounter => new IntegerName("@Interface/EventLineFront1FallingEdgeSoftCounter");

	public static IntegerName EventLineFront1FallingEdge => new IntegerName("@Interface/EventLineFront1FallingEdge");

	public static IntegerName EventLineFront0RisingEdgeTimestamp => new IntegerName("@Interface/EventLineFront0RisingEdgeTimestamp");

	public static IntegerName EventLineFront0RisingEdgeSoftCounter => new IntegerName("@Interface/EventLineFront0RisingEdgeSoftCounter");

	public static IntegerName EventLineFront0RisingEdge => new IntegerName("@Interface/EventLineFront0RisingEdge");

	public static IntegerName EventLineFront0FallingEdgeTimestamp => new IntegerName("@Interface/EventLineFront0FallingEdgeTimestamp");

	public static IntegerName EventLineFront0FallingEdgeSoftCounter => new IntegerName("@Interface/EventLineFront0FallingEdgeSoftCounter");

	public static IntegerName EventLineFront0FallingEdge => new IntegerName("@Interface/EventLineFront0FallingEdge");

	public static IntegerName EventLine7RisingEdgeTimestamp => new IntegerName("@Interface/EventLine7RisingEdgeTimestamp");

	public static IntegerName EventLine7RisingEdgeSoftCounter => new IntegerName("@Interface/EventLine7RisingEdgeSoftCounter");

	public static IntegerName EventLine7RisingEdge => new IntegerName("@Interface/EventLine7RisingEdge");

	public static IntegerName EventLine7FallingEdgeTimestamp => new IntegerName("@Interface/EventLine7FallingEdgeTimestamp");

	public static IntegerName EventLine7FallingEdgeSoftCounter => new IntegerName("@Interface/EventLine7FallingEdgeSoftCounter");

	public static IntegerName EventLine7FallingEdge => new IntegerName("@Interface/EventLine7FallingEdge");

	public static IntegerName EventLine6RisingEdgeTimestamp => new IntegerName("@Interface/EventLine6RisingEdgeTimestamp");

	public static IntegerName EventLine6RisingEdgeSoftCounter => new IntegerName("@Interface/EventLine6RisingEdgeSoftCounter");

	public static IntegerName EventLine6RisingEdge => new IntegerName("@Interface/EventLine6RisingEdge");

	public static IntegerName EventLine6FallingEdgeTimestamp => new IntegerName("@Interface/EventLine6FallingEdgeTimestamp");

	public static IntegerName EventLine6FallingEdgeSoftCounter => new IntegerName("@Interface/EventLine6FallingEdgeSoftCounter");

	public static IntegerName EventLine6FallingEdge => new IntegerName("@Interface/EventLine6FallingEdge");

	public static IntegerName EventLine5RisingEdgeTimestamp => new IntegerName("@Interface/EventLine5RisingEdgeTimestamp");

	public static IntegerName EventLine5RisingEdgeSoftCounter => new IntegerName("@Interface/EventLine5RisingEdgeSoftCounter");

	public static IntegerName EventLine5RisingEdge => new IntegerName("@Interface/EventLine5RisingEdge");

	public static IntegerName EventLine5FallingEdgeTimestamp => new IntegerName("@Interface/EventLine5FallingEdgeTimestamp");

	public static IntegerName EventLine5FallingEdgeSoftCounter => new IntegerName("@Interface/EventLine5FallingEdgeSoftCounter");

	public static IntegerName EventLine5FallingEdge => new IntegerName("@Interface/EventLine5FallingEdge");

	public static IntegerName EventLine4RisingEdgeTimestamp => new IntegerName("@Interface/EventLine4RisingEdgeTimestamp");

	public static IntegerName EventLine4RisingEdgeSoftCounter => new IntegerName("@Interface/EventLine4RisingEdgeSoftCounter");

	public static IntegerName EventLine4RisingEdge => new IntegerName("@Interface/EventLine4RisingEdge");

	public static IntegerName EventLine4FallingEdgeTimestamp => new IntegerName("@Interface/EventLine4FallingEdgeTimestamp");

	public static IntegerName EventLine4FallingEdgeSoftCounter => new IntegerName("@Interface/EventLine4FallingEdgeSoftCounter");

	public static IntegerName EventLine4FallingEdge => new IntegerName("@Interface/EventLine4FallingEdge");

	public static IntegerName EventLine3RisingEdgeTimestamp => new IntegerName("@Interface/EventLine3RisingEdgeTimestamp");

	public static IntegerName EventLine3RisingEdgeSoftCounter => new IntegerName("@Interface/EventLine3RisingEdgeSoftCounter");

	public static IntegerName EventLine3RisingEdge => new IntegerName("@Interface/EventLine3RisingEdge");

	public static IntegerName EventLine3FallingEdgeTimestamp => new IntegerName("@Interface/EventLine3FallingEdgeTimestamp");

	public static IntegerName EventLine3FallingEdgeSoftCounter => new IntegerName("@Interface/EventLine3FallingEdgeSoftCounter");

	public static IntegerName EventLine3FallingEdge => new IntegerName("@Interface/EventLine3FallingEdge");

	public static IntegerName EventLine2RisingEdgeTimestamp => new IntegerName("@Interface/EventLine2RisingEdgeTimestamp");

	public static IntegerName EventLine2RisingEdgeSoftCounter => new IntegerName("@Interface/EventLine2RisingEdgeSoftCounter");

	public static IntegerName EventLine2RisingEdge => new IntegerName("@Interface/EventLine2RisingEdge");

	public static IntegerName EventLine2FallingEdgeTimestamp => new IntegerName("@Interface/EventLine2FallingEdgeTimestamp");

	public static IntegerName EventLine2FallingEdgeSoftCounter => new IntegerName("@Interface/EventLine2FallingEdgeSoftCounter");

	public static IntegerName EventLine2FallingEdge => new IntegerName("@Interface/EventLine2FallingEdge");

	public static IntegerName EventLine1RisingEdgeTimestamp => new IntegerName("@Interface/EventLine1RisingEdgeTimestamp");

	public static IntegerName EventLine1RisingEdgeSoftCounter => new IntegerName("@Interface/EventLine1RisingEdgeSoftCounter");

	public static IntegerName EventLine1RisingEdge => new IntegerName("@Interface/EventLine1RisingEdge");

	public static IntegerName EventLine1FallingEdgeTimestamp => new IntegerName("@Interface/EventLine1FallingEdgeTimestamp");

	public static IntegerName EventLine1FallingEdgeSoftCounter => new IntegerName("@Interface/EventLine1FallingEdgeSoftCounter");

	public static IntegerName EventLine1FallingEdge => new IntegerName("@Interface/EventLine1FallingEdge");

	public static IntegerName EventLine0RisingEdgeTimestamp => new IntegerName("@Interface/EventLine0RisingEdgeTimestamp");

	public static IntegerName EventLine0RisingEdgeSoftCounter => new IntegerName("@Interface/EventLine0RisingEdgeSoftCounter");

	public static IntegerName EventLine0RisingEdge => new IntegerName("@Interface/EventLine0RisingEdge");

	public static IntegerName EventLine0FallingEdgeTimestamp => new IntegerName("@Interface/EventLine0FallingEdgeTimestamp");

	public static IntegerName EventLine0FallingEdgeSoftCounter => new IntegerName("@Interface/EventLine0FallingEdgeSoftCounter");

	public static IntegerName EventLine0FallingEdge => new IntegerName("@Interface/EventLine0FallingEdge");

	public static IntegerName EventInterfaceLostSoftCounter => new IntegerName("@Interface/EventInterfaceLostSoftCounter");

	public static IntegerName EventInterfaceLost => new IntegerName("@Interface/EventInterfaceLost");

	public static IntegerName EventDeviceListChangedSoftCounter => new IntegerName("@Interface/EventDeviceListChangedSoftCounter");

	public static IntegerName EventDeviceListChanged => new IntegerName("@Interface/EventDeviceListChanged");

	public static DiscoveryMethodEnum DiscoveryMethod
	{
		get
		{
			if (m_DiscoveryMethodCached == null)
			{
				m_DiscoveryMethodCached = new DiscoveryMethodEnum();
			}
			return m_DiscoveryMethodCached;
		}
	}

	public static StringName DeviceVendorName => new StringName("@Interface/DeviceVendorName");

	public static StringName DeviceUserID => new StringName("@Interface/DeviceUserID");

	public static IntegerName DeviceUpdateTimeout => new IntegerName("@Interface/DeviceUpdateTimeout");

	public static CommandName DeviceUpdateList => new CommandName("@Interface/DeviceUpdateList");

	public static IntegerName DeviceTLVersionMinor => new IntegerName("@Interface/DeviceTLVersionMinor");

	public static IntegerName DeviceTLVersionMajor => new IntegerName("@Interface/DeviceTLVersionMajor");

	public static StringName DeviceSerialNumber => new StringName("@Interface/DeviceSerialNumber");

	public static IntegerName DeviceSelector => new IntegerName("@Interface/DeviceSelector");

	public static StringName DeviceModelName => new StringName("@Interface/DeviceModelName");

	public static StringName DeviceID => new StringName("@Interface/DeviceID");

	public static DeviceAccessStatusEnum DeviceAccessStatus
	{
		get
		{
			if (m_DeviceAccessStatusCached == null)
			{
				m_DeviceAccessStatusCached = new DeviceAccessStatusEnum();
			}
			return m_DeviceAccessStatusCached;
		}
	}

	public static FloatName CxpPort3Voltage => new FloatName("@Interface/CxpPort3Voltage");

	public static CxpPort3PowerStateEnum CxpPort3PowerState
	{
		get
		{
			if (m_CxpPort3PowerStateCached == null)
			{
				m_CxpPort3PowerStateCached = new CxpPort3PowerStateEnum();
			}
			return m_CxpPort3PowerStateCached;
		}
	}

	public static FloatName CxpPort3Power => new FloatName("@Interface/CxpPort3Power");

	public static IntegerName CxpPort3NotInTableErrorCount => new IntegerName("@Interface/CxpPort3NotInTableErrorCount");

	public static FloatName CxpPort3LinkSpeed => new FloatName("@Interface/CxpPort3LinkSpeed");

	public static IntegerName CxpPort3DisparityErrorCount => new IntegerName("@Interface/CxpPort3DisparityErrorCount");

	public static FloatName CxpPort3Current => new FloatName("@Interface/CxpPort3Current");

	public static FloatName CxpPort2Voltage => new FloatName("@Interface/CxpPort2Voltage");

	public static CxpPort2PowerStateEnum CxpPort2PowerState
	{
		get
		{
			if (m_CxpPort2PowerStateCached == null)
			{
				m_CxpPort2PowerStateCached = new CxpPort2PowerStateEnum();
			}
			return m_CxpPort2PowerStateCached;
		}
	}

	public static FloatName CxpPort2Power => new FloatName("@Interface/CxpPort2Power");

	public static IntegerName CxpPort2NotInTableErrorCount => new IntegerName("@Interface/CxpPort2NotInTableErrorCount");

	public static FloatName CxpPort2LinkSpeed => new FloatName("@Interface/CxpPort2LinkSpeed");

	public static IntegerName CxpPort2DisparityErrorCount => new IntegerName("@Interface/CxpPort2DisparityErrorCount");

	public static FloatName CxpPort2Current => new FloatName("@Interface/CxpPort2Current");

	public static FloatName CxpPort1Voltage => new FloatName("@Interface/CxpPort1Voltage");

	public static CxpPort1PowerStateEnum CxpPort1PowerState
	{
		get
		{
			if (m_CxpPort1PowerStateCached == null)
			{
				m_CxpPort1PowerStateCached = new CxpPort1PowerStateEnum();
			}
			return m_CxpPort1PowerStateCached;
		}
	}

	public static FloatName CxpPort1Power => new FloatName("@Interface/CxpPort1Power");

	public static IntegerName CxpPort1NotInTableErrorCount => new IntegerName("@Interface/CxpPort1NotInTableErrorCount");

	public static FloatName CxpPort1LinkSpeed => new FloatName("@Interface/CxpPort1LinkSpeed");

	public static IntegerName CxpPort1DisparityErrorCount => new IntegerName("@Interface/CxpPort1DisparityErrorCount");

	public static FloatName CxpPort1Current => new FloatName("@Interface/CxpPort1Current");

	public static FloatName CxpPort0Voltage => new FloatName("@Interface/CxpPort0Voltage");

	public static CxpPort0PowerStateEnum CxpPort0PowerState
	{
		get
		{
			if (m_CxpPort0PowerStateCached == null)
			{
				m_CxpPort0PowerStateCached = new CxpPort0PowerStateEnum();
			}
			return m_CxpPort0PowerStateCached;
		}
	}

	public static FloatName CxpPort0Power => new FloatName("@Interface/CxpPort0Power");

	public static IntegerName CxpPort0NotInTableErrorCount => new IntegerName("@Interface/CxpPort0NotInTableErrorCount");

	public static FloatName CxpPort0LinkSpeed => new FloatName("@Interface/CxpPort0LinkSpeed");

	public static IntegerName CxpPort0DisparityErrorCount => new IntegerName("@Interface/CxpPort0DisparityErrorCount");

	public static FloatName CxpPort0Current => new FloatName("@Interface/CxpPort0Current");

	public static CommandName CxpPoCxpTurnOff => new CommandName("@Interface/CxpPoCxpTurnOff");

	public static CommandName CxpPoCxpTripReset => new CommandName("@Interface/CxpPoCxpTripReset");

	public static CxpPoCxpStatusEnum CxpPoCxpStatus
	{
		get
		{
			if (m_CxpPoCxpStatusCached == null)
			{
				m_CxpPoCxpStatusCached = new CxpPoCxpStatusEnum();
			}
			return m_CxpPoCxpStatusCached;
		}
	}

	public static CommandName CxpPoCxpAuto => new CommandName("@Interface/CxpPoCxpAuto");

	public static CxpLinkConfigurationEnum CxpLinkConfiguration
	{
		get
		{
			if (m_CxpLinkConfigurationCached == null)
			{
				m_CxpLinkConfigurationCached = new CxpLinkConfigurationEnum();
			}
			return m_CxpLinkConfigurationCached;
		}
	}

	public static IntegerName CxpConnectionSelector => new IntegerName("@Interface/CxpConnectionSelector");

	public static FloatName AmbientTemperature => new FloatName("@Interface/AmbientTemperature");
}
