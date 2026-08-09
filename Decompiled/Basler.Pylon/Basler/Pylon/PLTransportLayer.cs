using System.ComponentModel;

namespace Basler.Pylon;

public static class PLTransportLayer
{
	[EditorBrowsable(EditorBrowsableState.Never)]
	public class AreaTriggerModeEnum : ParameterListEnum
	{
		public override string Name => "@DeviceTransportLayer/AreaTriggerMode";

		public string Synchronized => "Synchronized";

		public string Software => "Software";

		public string Generator => "Generator";

		public string External => "External";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class BitAlignmentEnum : ParameterListEnum
	{
		public override string Name => "@DeviceTransportLayer/BitAlignment";

		public string RightAligned => "RightAligned";

		public string LeftAligned => "LeftAligned";

		public string CustomBitShift => "CustomBitShift";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class CxpLinkConfigurationEnum : ParameterListEnum
	{
		public override string Name => "@DeviceTransportLayer/CxpLinkConfiguration";

		public string CXP6_X4 => "CXP6_X4";

		public string CXP6_X3 => "CXP6_X3";

		public string CXP6_X2 => "CXP6_X2";

		public string CXP6_X1 => "CXP6_X1";

		public string CXP5_X4 => "CXP5_X4";

		public string CXP5_X3 => "CXP5_X3";

		public string CXP5_X2 => "CXP5_X2";

		public string CXP5_X1 => "CXP5_X1";

		public string CXP3_X4 => "CXP3_X4";

		public string CXP3_X3 => "CXP3_X3";

		public string CXP3_X2 => "CXP3_X2";

		public string CXP3_X1 => "CXP3_X1";

		public string CXP2_X4 => "CXP2_X4";

		public string CXP2_X3 => "CXP2_X3";

		public string CXP2_X2 => "CXP2_X2";

		public string CXP2_X1 => "CXP2_X1";

		public string CXP1_X4 => "CXP1_X4";

		public string CXP1_X3 => "CXP1_X3";

		public string CXP1_X2 => "CXP1_X2";

		public string CXP1_X1 => "CXP1_X1";

		public string CXP12_X4 => "CXP12_X4";

		public string CXP12_X3 => "CXP12_X3";

		public string CXP12_X2 => "CXP12_X2";

		public string CXP12_X1 => "CXP12_X1";

		public string CXP10_X4 => "CXP10_X4";

		public string CXP10_X3 => "CXP10_X3";

		public string CXP10_X2 => "CXP10_X2";

		public string CXP10_X1 => "CXP10_X1";

		public string Auto => "Auto";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class CxpTriggerPacketModeEnum : ParameterListEnum
	{
		public override string Name => "@DeviceTransportLayer/CxpTriggerPacketMode";

		public string CXPTriggerStandard => "CXPTriggerStandard";

		public string CXPTriggerRising => "CXPTriggerRising";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class DeviceAccessStatusEnum : ParameterListEnum
	{
		public override string Name => "@DeviceTransportLayer/DeviceAccessStatus";

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
	public class DeviceEndianessMechanismEnum : ParameterListEnum
	{
		public override string Name => "@DeviceTransportLayer/DeviceEndianessMechanism";

		public string Standard => "Standard";

		public string Legacy => "Legacy";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class DeviceTypeEnum : ParameterListEnum
	{
		public override string Name => "@DeviceTransportLayer/DeviceType";

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
	public class EventNotificationEnum : ParameterListEnum
	{
		public override string Name => "@DeviceTransportLayer/EventNotification";

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
		public override string Name => "@DeviceTransportLayer/EventSelector";

		public string TriggerQueueFilllevelThresholdOn => "TriggerQueueFilllevelThresholdOn";

		public string TriggerQueueFilllevelThresholdOff => "TriggerQueueFilllevelThresholdOff";

		public string TriggerExceededPeriodLimits => "TriggerExceededPeriodLimits";

		public string Overflow => "Overflow";

		public string FrameTriggerMissed => "FrameTriggerMissed";

		public string FrameTransferStart => "FrameTransferStart";

		public string FrameTransferEnd => "FrameTransferEnd";

		public string DeviceLost => "DeviceLost";

		public string AcquisitionTrigger => "AcquisitionTrigger";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class FormatEnum : ParameterListEnum
	{
		public override string Name => "@DeviceTransportLayer/Format";

		public string YCbCr422_8 => "YCbCr422_8";

		public string RGBa8 => "RGBa8";

		public string RGB8 => "RGB8";

		public string RGB16 => "RGB16";

		public string RGB14p => "RGB14p";

		public string RGB12p => "RGB12p";

		public string RGB10p => "RGB10p";

		public string Mono8 => "Mono8";

		public string Mono16 => "Mono16";

		public string Mono14p => "Mono14p";

		public string Mono12p => "Mono12p";

		public string Mono10p => "Mono10p";

		public string BayerRG8 => "BayerRG8";

		public string BayerRG16 => "BayerRG16";

		public string BayerRG14p => "BayerRG14p";

		public string BayerRG12p => "BayerRG12p";

		public string BayerRG10p => "BayerRG10p";

		public string BayerGR8 => "BayerGR8";

		public string BayerGR16 => "BayerGR16";

		public string BayerGR14p => "BayerGR14p";

		public string BayerGR12p => "BayerGR12p";

		public string BayerGR10p => "BayerGR10p";

		public string BayerGB8 => "BayerGB8";

		public string BayerGB16 => "BayerGB16";

		public string BayerGB14p => "BayerGB14p";

		public string BayerGB12p => "BayerGB12p";

		public string BayerGB10p => "BayerGB10p";

		public string BayerBG8 => "BayerBG8";

		public string BayerBG16 => "BayerBG16";

		public string BayerBG14p => "BayerBG14p";

		public string BayerBG12p => "BayerBG12p";

		public string BayerBG10p => "BayerBG10p";

		public string BGRa8 => "BGRa8";

		public string BGR8 => "BGR8";

		public string BGR16 => "BGR16";

		public string BGR14p => "BGR14p";

		public string BGR12p => "BGR12p";

		public string BGR10p => "BGR10p";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class LutEnableEnum : ParameterListEnum
	{
		public override string Name => "@DeviceTransportLayer/LutEnable";

		public string On => "On";

		public string Off => "Off";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class LutImplementationTypeEnum : ParameterListEnum
	{
		public override string Name => "@DeviceTransportLayer/LutImplementationType";

		public string KneeLUT => "KneeLUT";

		public string FullLUT => "FullLUT";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class LutTypeEnum : ParameterListEnum
	{
		public override string Name => "@DeviceTransportLayer/LutType";

		public string UserFile => "UserFile";

		public string Processor => "Processor";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class MissingCameraFrameResponseEnum : ParameterListEnum
	{
		public override string Name => "@DeviceTransportLayer/MissingCameraFrameResponse";

		public string Yes => "Yes";

		public string No => "No";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class OverflowEventSelectEnum : ParameterListEnum
	{
		public override string Name => "@DeviceTransportLayer/OverflowEventSelect";

		public string OK => "OK";

		public string LostOK => "LostOK";

		public string Lost => "Lost";

		public string IncompleteOK => "IncompleteOK";

		public string IncompleteLost => "IncompleteLost";

		public string Incomplete => "Incomplete";

		public string All => "All";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class PixelFormatEnum : ParameterListEnum
	{
		public override string Name => "@DeviceTransportLayer/PixelFormat";

		public string YCbCr422_8 => "YCbCr422_8";

		public string RGB8 => "RGB8";

		public string RGB16 => "RGB16";

		public string RGB14p => "RGB14p";

		public string RGB12p => "RGB12p";

		public string RGB10p => "RGB10p";

		public string Mono8 => "Mono8";

		public string Mono16 => "Mono16";

		public string Mono14p => "Mono14p";

		public string Mono12p => "Mono12p";

		public string Mono12 => "Mono12";

		public string Mono10p => "Mono10p";

		public string Mono10 => "Mono10";

		public string BayerRG8 => "BayerRG8";

		public string BayerRG14p => "BayerRG14p";

		public string BayerRG12p => "BayerRG12p";

		public string BayerRG10p => "BayerRG10p";

		public string BayerGR8 => "BayerGR8";

		public string BayerGR14p => "BayerGR14p";

		public string BayerGR12p => "BayerGR12p";

		public string BayerGR10p => "BayerGR10p";

		public string BayerGB8 => "BayerGB8";

		public string BayerGB14p => "BayerGB14p";

		public string BayerGB12p => "BayerGB12p";

		public string BayerGB10p => "BayerGB10p";

		public string BayerBG8 => "BayerBG8";

		public string BayerBG14p => "BayerBG14p";

		public string BayerBG12p => "BayerBG12p";

		public string BayerBG10p => "BayerBG10p";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class ProcessingInvertEnum : ParameterListEnum
	{
		public override string Name => "@DeviceTransportLayer/ProcessingInvert";

		public string On => "On";

		public string Off => "Off";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class SoftwareTriggerIsBusyEnum : ParameterListEnum
	{
		public override string Name => "@DeviceTransportLayer/SoftwareTriggerIsBusy";

		public string NotBusy => "NotBusy";

		public string Busy => "Busy";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class SystemmonitorByteAlignment8b10bLockedEnum : ParameterListEnum
	{
		public override string Name => "@DeviceTransportLayer/SystemmonitorByteAlignment8b10bLocked";

		public string Yes => "Yes";

		public string No => "No";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class SystemmonitorExternalPowerEnum : ParameterListEnum
	{
		public override string Name => "@DeviceTransportLayer/SystemmonitorExternalPower";

		public string PowerGood => "PowerGood";

		public string NoPower => "NoPower";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class SystemmonitorPowerOverCxpStateEnum : ParameterListEnum
	{
		public override string Name => "@DeviceTransportLayer/SystemmonitorPowerOverCxpState";

		public string PoCXPOverVolt => "PoCXPOverVolt";

		public string PoCXPOK => "PoCXPOK";

		public string PoCXPNotConnected => "PoCXPNotConnected";

		public string PoCXPMinCurrent => "PoCXPMinCurrent";

		public string PoCXPMaxCurrent => "PoCXPMaxCurrent";

		public string PoCXPLowVolt => "PoCXPLowVolt";

		public string PoCXPDisabled => "PoCXPDisabled";

		public string PoCXPBooting => "PoCXPBooting";

		public string PoCXPADCChipError => "PoCXPADCChipError";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class TriggerCameraOutSelectEnum : ParameterListEnum
	{
		public override string Name => "@DeviceTransportLayer/TriggerCameraOutSelect";

		public string VCC => "VCC";

		public string PulseGenerator3 => "PulseGenerator3";

		public string PulseGenerator2 => "PulseGenerator2";

		public string PulseGenerator1 => "PulseGenerator1";

		public string PulseGenerator0 => "PulseGenerator0";

		public string NotPulseGenerator3 => "NotPulseGenerator3";

		public string NotPulseGenerator2 => "NotPulseGenerator2";

		public string NotPulseGenerator1 => "NotPulseGenerator1";

		public string NotPulseGenerator0 => "NotPulseGenerator0";

		public string NotCamDPulseGenerator3 => "NotCamDPulseGenerator3";

		public string NotCamDPulseGenerator2 => "NotCamDPulseGenerator2";

		public string NotCamDPulseGenerator1 => "NotCamDPulseGenerator1";

		public string NotCamDPulseGenerator0 => "NotCamDPulseGenerator0";

		public string NotCamCPulseGenerator3 => "NotCamCPulseGenerator3";

		public string NotCamCPulseGenerator2 => "NotCamCPulseGenerator2";

		public string NotCamCPulseGenerator1 => "NotCamCPulseGenerator1";

		public string NotCamCPulseGenerator0 => "NotCamCPulseGenerator0";

		public string NotCamBPulseGenerator3 => "NotCamBPulseGenerator3";

		public string NotCamBPulseGenerator2 => "NotCamBPulseGenerator2";

		public string NotCamBPulseGenerator1 => "NotCamBPulseGenerator1";

		public string NotCamBPulseGenerator0 => "NotCamBPulseGenerator0";

		public string NotCamAPulseGenerator3 => "NotCamAPulseGenerator3";

		public string NotCamAPulseGenerator2 => "NotCamAPulseGenerator2";

		public string NotCamAPulseGenerator1 => "NotCamAPulseGenerator1";

		public string NotCamAPulseGenerator0 => "NotCamAPulseGenerator0";

		public string NotBypassGPI7 => "NotBypassGPI7";

		public string NotBypassGPI6 => "NotBypassGPI6";

		public string NotBypassGPI5 => "NotBypassGPI5";

		public string NotBypassGPI4 => "NotBypassGPI4";

		public string NotBypassGPI3 => "NotBypassGPI3";

		public string NotBypassGPI2 => "NotBypassGPI2";

		public string NotBypassGPI1 => "NotBypassGPI1";

		public string NotBypassGPI0 => "NotBypassGPI0";

		public string NotBypassFrontGPI3 => "NotBypassFrontGPI3";

		public string NotBypassFrontGPI2 => "NotBypassFrontGPI2";

		public string NotBypassFrontGPI1 => "NotBypassFrontGPI1";

		public string NotBypassFrontGPI0 => "NotBypassFrontGPI0";

		public string NotBypassFronGPI3 => "NotBypassFronGPI3";

		public string NotBypassFronGPI2 => "NotBypassFronGPI2";

		public string NotBypassFronGPI1 => "NotBypassFronGPI1";

		public string NotBypassFronGPI0 => "NotBypassFronGPI0";

		public string GND => "GND";

		public string CamDPulseGenerator3 => "CamDPulseGenerator3";

		public string CamDPulseGenerator2 => "CamDPulseGenerator2";

		public string CamDPulseGenerator1 => "CamDPulseGenerator1";

		public string CamDPulseGenerator0 => "CamDPulseGenerator0";

		public string CamCPulseGenerator3 => "CamCPulseGenerator3";

		public string CamCPulseGenerator2 => "CamCPulseGenerator2";

		public string CamCPulseGenerator1 => "CamCPulseGenerator1";

		public string CamCPulseGenerator0 => "CamCPulseGenerator0";

		public string CamBPulseGenerator3 => "CamBPulseGenerator3";

		public string CamBPulseGenerator2 => "CamBPulseGenerator2";

		public string CamBPulseGenerator1 => "CamBPulseGenerator1";

		public string CamBPulseGenerator0 => "CamBPulseGenerator0";

		public string CamAPulseGenerator3 => "CamAPulseGenerator3";

		public string CamAPulseGenerator2 => "CamAPulseGenerator2";

		public string CamAPulseGenerator1 => "CamAPulseGenerator1";

		public string CamAPulseGenerator0 => "CamAPulseGenerator0";

		public string BypassGPI7 => "BypassGPI7";

		public string BypassGPI6 => "BypassGPI6";

		public string BypassGPI5 => "BypassGPI5";

		public string BypassGPI4 => "BypassGPI4";

		public string BypassGPI3 => "BypassGPI3";

		public string BypassGPI2 => "BypassGPI2";

		public string BypassGPI1 => "BypassGPI1";

		public string BypassGPI0 => "BypassGPI0";

		public string BypassFrontGPI3 => "BypassFrontGPI3";

		public string BypassFrontGPI2 => "BypassFrontGPI2";

		public string BypassFrontGPI1 => "BypassFrontGPI1";

		public string BypassFrontGPI0 => "BypassFrontGPI0";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class TriggerExceededPeriodLimitsEnum : ParameterListEnum
	{
		public override string Name => "@DeviceTransportLayer/TriggerExceededPeriodLimits";

		public string Yes => "Yes";

		public string No => "No";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class TriggerInPolarityEnum : ParameterListEnum
	{
		public override string Name => "@DeviceTransportLayer/TriggerInPolarity";

		public string LowActive => "LowActive";

		public string HighActive => "HighActive";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class TriggerInSourceEnum : ParameterListEnum
	{
		public override string Name => "@DeviceTransportLayer/TriggerInSource";

		public string TriggerInSourceFrontGPI3 => "TriggerInSourceFrontGPI3";

		public string TriggerInSourceFrontGPI2 => "TriggerInSourceFrontGPI2";

		public string TriggerInSourceFrontGPI1 => "TriggerInSourceFrontGPI1";

		public string TriggerInSourceFrontGPI0 => "TriggerInSourceFrontGPI0";

		public string GPITriggerSource7 => "GPITriggerSource7";

		public string GPITriggerSource6 => "GPITriggerSource6";

		public string GPITriggerSource5 => "GPITriggerSource5";

		public string GPITriggerSource4 => "GPITriggerSource4";

		public string GPITriggerSource3 => "GPITriggerSource3";

		public string GPITriggerSource2 => "GPITriggerSource2";

		public string GPITriggerSource1 => "GPITriggerSource1";

		public string GPITriggerSource0 => "GPITriggerSource0";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class TriggerInStatisticsPolarityEnum : ParameterListEnum
	{
		public override string Name => "@DeviceTransportLayer/TriggerInStatisticsPolarity";

		public string LowActive => "LowActive";

		public string HighActive => "HighActive";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class TriggerInStatisticsSourceEnum : ParameterListEnum
	{
		public override string Name => "@DeviceTransportLayer/TriggerInStatisticsSource";

		public string TriggerInSourceFrontGPI3 => "TriggerInSourceFrontGPI3";

		public string TriggerInSourceFrontGPI2 => "TriggerInSourceFrontGPI2";

		public string TriggerInSourceFrontGPI1 => "TriggerInSourceFrontGPI1";

		public string TriggerInSourceFrontGPI0 => "TriggerInSourceFrontGPI0";

		public string GPITriggerSource7 => "GPITriggerSource7";

		public string GPITriggerSource6 => "GPITriggerSource6";

		public string GPITriggerSource5 => "GPITriggerSource5";

		public string GPITriggerSource4 => "GPITriggerSource4";

		public string GPITriggerSource3 => "GPITriggerSource3";

		public string GPITriggerSource2 => "GPITriggerSource2";

		public string GPITriggerSource1 => "GPITriggerSource1";

		public string GPITriggerSource0 => "GPITriggerSource0";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class TriggerOutSelectFrontGPO0Enum : ParameterListEnum
	{
		public override string Name => "@DeviceTransportLayer/TriggerOutSelectFrontGPO0";

		public string VCC => "VCC";

		public string PulseGenerator3 => "PulseGenerator3";

		public string PulseGenerator2 => "PulseGenerator2";

		public string PulseGenerator1 => "PulseGenerator1";

		public string PulseGenerator0 => "PulseGenerator0";

		public string NotPulseGenerator3 => "NotPulseGenerator3";

		public string NotPulseGenerator2 => "NotPulseGenerator2";

		public string NotPulseGenerator1 => "NotPulseGenerator1";

		public string NotPulseGenerator0 => "NotPulseGenerator0";

		public string NotCamDPulseGenerator3 => "NotCamDPulseGenerator3";

		public string NotCamDPulseGenerator2 => "NotCamDPulseGenerator2";

		public string NotCamDPulseGenerator1 => "NotCamDPulseGenerator1";

		public string NotCamDPulseGenerator0 => "NotCamDPulseGenerator0";

		public string NotCamCPulseGenerator3 => "NotCamCPulseGenerator3";

		public string NotCamCPulseGenerator2 => "NotCamCPulseGenerator2";

		public string NotCamCPulseGenerator1 => "NotCamCPulseGenerator1";

		public string NotCamCPulseGenerator0 => "NotCamCPulseGenerator0";

		public string NotCamBPulseGenerator3 => "NotCamBPulseGenerator3";

		public string NotCamBPulseGenerator2 => "NotCamBPulseGenerator2";

		public string NotCamBPulseGenerator1 => "NotCamBPulseGenerator1";

		public string NotCamBPulseGenerator0 => "NotCamBPulseGenerator0";

		public string NotCamAPulseGenerator3 => "NotCamAPulseGenerator3";

		public string NotCamAPulseGenerator2 => "NotCamAPulseGenerator2";

		public string NotCamAPulseGenerator1 => "NotCamAPulseGenerator1";

		public string NotCamAPulseGenerator0 => "NotCamAPulseGenerator0";

		public string NotBypassGPI7 => "NotBypassGPI7";

		public string NotBypassGPI6 => "NotBypassGPI6";

		public string NotBypassGPI5 => "NotBypassGPI5";

		public string NotBypassGPI4 => "NotBypassGPI4";

		public string NotBypassGPI3 => "NotBypassGPI3";

		public string NotBypassGPI2 => "NotBypassGPI2";

		public string NotBypassGPI1 => "NotBypassGPI1";

		public string NotBypassGPI0 => "NotBypassGPI0";

		public string NotBypassFrontGPI3 => "NotBypassFrontGPI3";

		public string NotBypassFrontGPI2 => "NotBypassFrontGPI2";

		public string NotBypassFrontGPI1 => "NotBypassFrontGPI1";

		public string NotBypassFrontGPI0 => "NotBypassFrontGPI0";

		public string NotBypassFronGPI3 => "NotBypassFronGPI3";

		public string NotBypassFronGPI2 => "NotBypassFronGPI2";

		public string NotBypassFronGPI1 => "NotBypassFronGPI1";

		public string NotBypassFronGPI0 => "NotBypassFronGPI0";

		public string GND => "GND";

		public string CamDPulseGenerator3 => "CamDPulseGenerator3";

		public string CamDPulseGenerator2 => "CamDPulseGenerator2";

		public string CamDPulseGenerator1 => "CamDPulseGenerator1";

		public string CamDPulseGenerator0 => "CamDPulseGenerator0";

		public string CamCPulseGenerator3 => "CamCPulseGenerator3";

		public string CamCPulseGenerator2 => "CamCPulseGenerator2";

		public string CamCPulseGenerator1 => "CamCPulseGenerator1";

		public string CamCPulseGenerator0 => "CamCPulseGenerator0";

		public string CamBPulseGenerator3 => "CamBPulseGenerator3";

		public string CamBPulseGenerator2 => "CamBPulseGenerator2";

		public string CamBPulseGenerator1 => "CamBPulseGenerator1";

		public string CamBPulseGenerator0 => "CamBPulseGenerator0";

		public string CamAPulseGenerator3 => "CamAPulseGenerator3";

		public string CamAPulseGenerator2 => "CamAPulseGenerator2";

		public string CamAPulseGenerator1 => "CamAPulseGenerator1";

		public string CamAPulseGenerator0 => "CamAPulseGenerator0";

		public string BypassGPI7 => "BypassGPI7";

		public string BypassGPI6 => "BypassGPI6";

		public string BypassGPI5 => "BypassGPI5";

		public string BypassGPI4 => "BypassGPI4";

		public string BypassGPI3 => "BypassGPI3";

		public string BypassGPI2 => "BypassGPI2";

		public string BypassGPI1 => "BypassGPI1";

		public string BypassGPI0 => "BypassGPI0";

		public string BypassFrontGPI3 => "BypassFrontGPI3";

		public string BypassFrontGPI2 => "BypassFrontGPI2";

		public string BypassFrontGPI1 => "BypassFrontGPI1";

		public string BypassFrontGPI0 => "BypassFrontGPI0";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class TriggerOutSelectFrontGPO1Enum : ParameterListEnum
	{
		public override string Name => "@DeviceTransportLayer/TriggerOutSelectFrontGPO1";

		public string VCC => "VCC";

		public string PulseGenerator3 => "PulseGenerator3";

		public string PulseGenerator2 => "PulseGenerator2";

		public string PulseGenerator1 => "PulseGenerator1";

		public string PulseGenerator0 => "PulseGenerator0";

		public string NotPulseGenerator3 => "NotPulseGenerator3";

		public string NotPulseGenerator2 => "NotPulseGenerator2";

		public string NotPulseGenerator1 => "NotPulseGenerator1";

		public string NotPulseGenerator0 => "NotPulseGenerator0";

		public string NotCamDPulseGenerator3 => "NotCamDPulseGenerator3";

		public string NotCamDPulseGenerator2 => "NotCamDPulseGenerator2";

		public string NotCamDPulseGenerator1 => "NotCamDPulseGenerator1";

		public string NotCamDPulseGenerator0 => "NotCamDPulseGenerator0";

		public string NotCamCPulseGenerator3 => "NotCamCPulseGenerator3";

		public string NotCamCPulseGenerator2 => "NotCamCPulseGenerator2";

		public string NotCamCPulseGenerator1 => "NotCamCPulseGenerator1";

		public string NotCamCPulseGenerator0 => "NotCamCPulseGenerator0";

		public string NotCamBPulseGenerator3 => "NotCamBPulseGenerator3";

		public string NotCamBPulseGenerator2 => "NotCamBPulseGenerator2";

		public string NotCamBPulseGenerator1 => "NotCamBPulseGenerator1";

		public string NotCamBPulseGenerator0 => "NotCamBPulseGenerator0";

		public string NotCamAPulseGenerator3 => "NotCamAPulseGenerator3";

		public string NotCamAPulseGenerator2 => "NotCamAPulseGenerator2";

		public string NotCamAPulseGenerator1 => "NotCamAPulseGenerator1";

		public string NotCamAPulseGenerator0 => "NotCamAPulseGenerator0";

		public string NotBypassGPI7 => "NotBypassGPI7";

		public string NotBypassGPI6 => "NotBypassGPI6";

		public string NotBypassGPI5 => "NotBypassGPI5";

		public string NotBypassGPI4 => "NotBypassGPI4";

		public string NotBypassGPI3 => "NotBypassGPI3";

		public string NotBypassGPI2 => "NotBypassGPI2";

		public string NotBypassGPI1 => "NotBypassGPI1";

		public string NotBypassGPI0 => "NotBypassGPI0";

		public string NotBypassFrontGPI3 => "NotBypassFrontGPI3";

		public string NotBypassFrontGPI2 => "NotBypassFrontGPI2";

		public string NotBypassFrontGPI1 => "NotBypassFrontGPI1";

		public string NotBypassFrontGPI0 => "NotBypassFrontGPI0";

		public string NotBypassFronGPI3 => "NotBypassFronGPI3";

		public string NotBypassFronGPI2 => "NotBypassFronGPI2";

		public string NotBypassFronGPI1 => "NotBypassFronGPI1";

		public string NotBypassFronGPI0 => "NotBypassFronGPI0";

		public string GND => "GND";

		public string CamDPulseGenerator3 => "CamDPulseGenerator3";

		public string CamDPulseGenerator2 => "CamDPulseGenerator2";

		public string CamDPulseGenerator1 => "CamDPulseGenerator1";

		public string CamDPulseGenerator0 => "CamDPulseGenerator0";

		public string CamCPulseGenerator3 => "CamCPulseGenerator3";

		public string CamCPulseGenerator2 => "CamCPulseGenerator2";

		public string CamCPulseGenerator1 => "CamCPulseGenerator1";

		public string CamCPulseGenerator0 => "CamCPulseGenerator0";

		public string CamBPulseGenerator3 => "CamBPulseGenerator3";

		public string CamBPulseGenerator2 => "CamBPulseGenerator2";

		public string CamBPulseGenerator1 => "CamBPulseGenerator1";

		public string CamBPulseGenerator0 => "CamBPulseGenerator0";

		public string CamAPulseGenerator3 => "CamAPulseGenerator3";

		public string CamAPulseGenerator2 => "CamAPulseGenerator2";

		public string CamAPulseGenerator1 => "CamAPulseGenerator1";

		public string CamAPulseGenerator0 => "CamAPulseGenerator0";

		public string BypassGPI7 => "BypassGPI7";

		public string BypassGPI6 => "BypassGPI6";

		public string BypassGPI5 => "BypassGPI5";

		public string BypassGPI4 => "BypassGPI4";

		public string BypassGPI3 => "BypassGPI3";

		public string BypassGPI2 => "BypassGPI2";

		public string BypassGPI1 => "BypassGPI1";

		public string BypassGPI0 => "BypassGPI0";

		public string BypassFrontGPI3 => "BypassFrontGPI3";

		public string BypassFrontGPI2 => "BypassFrontGPI2";

		public string BypassFrontGPI1 => "BypassFrontGPI1";

		public string BypassFrontGPI0 => "BypassFrontGPI0";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class TriggerOutSelectGPO0Enum : ParameterListEnum
	{
		public override string Name => "@DeviceTransportLayer/TriggerOutSelectGPO0";

		public string VCC => "VCC";

		public string PulseGenerator3 => "PulseGenerator3";

		public string PulseGenerator2 => "PulseGenerator2";

		public string PulseGenerator1 => "PulseGenerator1";

		public string PulseGenerator0 => "PulseGenerator0";

		public string NotPulseGenerator3 => "NotPulseGenerator3";

		public string NotPulseGenerator2 => "NotPulseGenerator2";

		public string NotPulseGenerator1 => "NotPulseGenerator1";

		public string NotPulseGenerator0 => "NotPulseGenerator0";

		public string NotCamDPulseGenerator3 => "NotCamDPulseGenerator3";

		public string NotCamDPulseGenerator2 => "NotCamDPulseGenerator2";

		public string NotCamDPulseGenerator1 => "NotCamDPulseGenerator1";

		public string NotCamDPulseGenerator0 => "NotCamDPulseGenerator0";

		public string NotCamCPulseGenerator3 => "NotCamCPulseGenerator3";

		public string NotCamCPulseGenerator2 => "NotCamCPulseGenerator2";

		public string NotCamCPulseGenerator1 => "NotCamCPulseGenerator1";

		public string NotCamCPulseGenerator0 => "NotCamCPulseGenerator0";

		public string NotCamBPulseGenerator3 => "NotCamBPulseGenerator3";

		public string NotCamBPulseGenerator2 => "NotCamBPulseGenerator2";

		public string NotCamBPulseGenerator1 => "NotCamBPulseGenerator1";

		public string NotCamBPulseGenerator0 => "NotCamBPulseGenerator0";

		public string NotCamAPulseGenerator3 => "NotCamAPulseGenerator3";

		public string NotCamAPulseGenerator2 => "NotCamAPulseGenerator2";

		public string NotCamAPulseGenerator1 => "NotCamAPulseGenerator1";

		public string NotCamAPulseGenerator0 => "NotCamAPulseGenerator0";

		public string NotBypassGPI7 => "NotBypassGPI7";

		public string NotBypassGPI6 => "NotBypassGPI6";

		public string NotBypassGPI5 => "NotBypassGPI5";

		public string NotBypassGPI4 => "NotBypassGPI4";

		public string NotBypassGPI3 => "NotBypassGPI3";

		public string NotBypassGPI2 => "NotBypassGPI2";

		public string NotBypassGPI1 => "NotBypassGPI1";

		public string NotBypassGPI0 => "NotBypassGPI0";

		public string NotBypassFrontGPI3 => "NotBypassFrontGPI3";

		public string NotBypassFrontGPI2 => "NotBypassFrontGPI2";

		public string NotBypassFrontGPI1 => "NotBypassFrontGPI1";

		public string NotBypassFrontGPI0 => "NotBypassFrontGPI0";

		public string GND => "GND";

		public string CamDPulseGenerator3 => "CamDPulseGenerator3";

		public string CamDPulseGenerator2 => "CamDPulseGenerator2";

		public string CamDPulseGenerator1 => "CamDPulseGenerator1";

		public string CamDPulseGenerator0 => "CamDPulseGenerator0";

		public string CamCPulseGenerator3 => "CamCPulseGenerator3";

		public string CamCPulseGenerator2 => "CamCPulseGenerator2";

		public string CamCPulseGenerator1 => "CamCPulseGenerator1";

		public string CamCPulseGenerator0 => "CamCPulseGenerator0";

		public string CamBPulseGenerator3 => "CamBPulseGenerator3";

		public string CamBPulseGenerator2 => "CamBPulseGenerator2";

		public string CamBPulseGenerator1 => "CamBPulseGenerator1";

		public string CamBPulseGenerator0 => "CamBPulseGenerator0";

		public string CamAPulseGenerator3 => "CamAPulseGenerator3";

		public string CamAPulseGenerator2 => "CamAPulseGenerator2";

		public string CamAPulseGenerator1 => "CamAPulseGenerator1";

		public string CamAPulseGenerator0 => "CamAPulseGenerator0";

		public string BypassGPI7 => "BypassGPI7";

		public string BypassGPI6 => "BypassGPI6";

		public string BypassGPI5 => "BypassGPI5";

		public string BypassGPI4 => "BypassGPI4";

		public string BypassGPI3 => "BypassGPI3";

		public string BypassGPI2 => "BypassGPI2";

		public string BypassGPI1 => "BypassGPI1";

		public string BypassGPI0 => "BypassGPI0";

		public string BypassFrontGPI3 => "BypassFrontGPI3";

		public string BypassFrontGPI2 => "BypassFrontGPI2";

		public string BypassFrontGPI1 => "BypassFrontGPI1";

		public string BypassFrontGPI0 => "BypassFrontGPI0";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class TriggerOutSelectGPO1Enum : ParameterListEnum
	{
		public override string Name => "@DeviceTransportLayer/TriggerOutSelectGPO1";

		public string VCC => "VCC";

		public string PulseGenerator3 => "PulseGenerator3";

		public string PulseGenerator2 => "PulseGenerator2";

		public string PulseGenerator1 => "PulseGenerator1";

		public string PulseGenerator0 => "PulseGenerator0";

		public string NotPulseGenerator3 => "NotPulseGenerator3";

		public string NotPulseGenerator2 => "NotPulseGenerator2";

		public string NotPulseGenerator1 => "NotPulseGenerator1";

		public string NotPulseGenerator0 => "NotPulseGenerator0";

		public string NotCamDPulseGenerator3 => "NotCamDPulseGenerator3";

		public string NotCamDPulseGenerator2 => "NotCamDPulseGenerator2";

		public string NotCamDPulseGenerator1 => "NotCamDPulseGenerator1";

		public string NotCamDPulseGenerator0 => "NotCamDPulseGenerator0";

		public string NotCamCPulseGenerator3 => "NotCamCPulseGenerator3";

		public string NotCamCPulseGenerator2 => "NotCamCPulseGenerator2";

		public string NotCamCPulseGenerator1 => "NotCamCPulseGenerator1";

		public string NotCamCPulseGenerator0 => "NotCamCPulseGenerator0";

		public string NotCamBPulseGenerator3 => "NotCamBPulseGenerator3";

		public string NotCamBPulseGenerator2 => "NotCamBPulseGenerator2";

		public string NotCamBPulseGenerator1 => "NotCamBPulseGenerator1";

		public string NotCamBPulseGenerator0 => "NotCamBPulseGenerator0";

		public string NotCamAPulseGenerator3 => "NotCamAPulseGenerator3";

		public string NotCamAPulseGenerator2 => "NotCamAPulseGenerator2";

		public string NotCamAPulseGenerator1 => "NotCamAPulseGenerator1";

		public string NotCamAPulseGenerator0 => "NotCamAPulseGenerator0";

		public string NotBypassGPI7 => "NotBypassGPI7";

		public string NotBypassGPI6 => "NotBypassGPI6";

		public string NotBypassGPI5 => "NotBypassGPI5";

		public string NotBypassGPI4 => "NotBypassGPI4";

		public string NotBypassGPI3 => "NotBypassGPI3";

		public string NotBypassGPI2 => "NotBypassGPI2";

		public string NotBypassGPI1 => "NotBypassGPI1";

		public string NotBypassGPI0 => "NotBypassGPI0";

		public string NotBypassFrontGPI3 => "NotBypassFrontGPI3";

		public string NotBypassFrontGPI2 => "NotBypassFrontGPI2";

		public string NotBypassFrontGPI1 => "NotBypassFrontGPI1";

		public string NotBypassFrontGPI0 => "NotBypassFrontGPI0";

		public string GND => "GND";

		public string CamDPulseGenerator3 => "CamDPulseGenerator3";

		public string CamDPulseGenerator2 => "CamDPulseGenerator2";

		public string CamDPulseGenerator1 => "CamDPulseGenerator1";

		public string CamDPulseGenerator0 => "CamDPulseGenerator0";

		public string CamCPulseGenerator3 => "CamCPulseGenerator3";

		public string CamCPulseGenerator2 => "CamCPulseGenerator2";

		public string CamCPulseGenerator1 => "CamCPulseGenerator1";

		public string CamCPulseGenerator0 => "CamCPulseGenerator0";

		public string CamBPulseGenerator3 => "CamBPulseGenerator3";

		public string CamBPulseGenerator2 => "CamBPulseGenerator2";

		public string CamBPulseGenerator1 => "CamBPulseGenerator1";

		public string CamBPulseGenerator0 => "CamBPulseGenerator0";

		public string CamAPulseGenerator3 => "CamAPulseGenerator3";

		public string CamAPulseGenerator2 => "CamAPulseGenerator2";

		public string CamAPulseGenerator1 => "CamAPulseGenerator1";

		public string CamAPulseGenerator0 => "CamAPulseGenerator0";

		public string BypassGPI7 => "BypassGPI7";

		public string BypassGPI6 => "BypassGPI6";

		public string BypassGPI5 => "BypassGPI5";

		public string BypassGPI4 => "BypassGPI4";

		public string BypassGPI3 => "BypassGPI3";

		public string BypassGPI2 => "BypassGPI2";

		public string BypassGPI1 => "BypassGPI1";

		public string BypassGPI0 => "BypassGPI0";

		public string BypassFrontGPI3 => "BypassFrontGPI3";

		public string BypassFrontGPI2 => "BypassFrontGPI2";

		public string BypassFrontGPI1 => "BypassFrontGPI1";

		public string BypassFrontGPI0 => "BypassFrontGPI0";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class TriggerOutSelectGPO2Enum : ParameterListEnum
	{
		public override string Name => "@DeviceTransportLayer/TriggerOutSelectGPO2";

		public string VCC => "VCC";

		public string PulseGenerator3 => "PulseGenerator3";

		public string PulseGenerator2 => "PulseGenerator2";

		public string PulseGenerator1 => "PulseGenerator1";

		public string PulseGenerator0 => "PulseGenerator0";

		public string NotPulseGenerator3 => "NotPulseGenerator3";

		public string NotPulseGenerator2 => "NotPulseGenerator2";

		public string NotPulseGenerator1 => "NotPulseGenerator1";

		public string NotPulseGenerator0 => "NotPulseGenerator0";

		public string NotCamDPulseGenerator3 => "NotCamDPulseGenerator3";

		public string NotCamDPulseGenerator2 => "NotCamDPulseGenerator2";

		public string NotCamDPulseGenerator1 => "NotCamDPulseGenerator1";

		public string NotCamDPulseGenerator0 => "NotCamDPulseGenerator0";

		public string NotCamCPulseGenerator3 => "NotCamCPulseGenerator3";

		public string NotCamCPulseGenerator2 => "NotCamCPulseGenerator2";

		public string NotCamCPulseGenerator1 => "NotCamCPulseGenerator1";

		public string NotCamCPulseGenerator0 => "NotCamCPulseGenerator0";

		public string NotCamBPulseGenerator3 => "NotCamBPulseGenerator3";

		public string NotCamBPulseGenerator2 => "NotCamBPulseGenerator2";

		public string NotCamBPulseGenerator1 => "NotCamBPulseGenerator1";

		public string NotCamBPulseGenerator0 => "NotCamBPulseGenerator0";

		public string NotCamAPulseGenerator3 => "NotCamAPulseGenerator3";

		public string NotCamAPulseGenerator2 => "NotCamAPulseGenerator2";

		public string NotCamAPulseGenerator1 => "NotCamAPulseGenerator1";

		public string NotCamAPulseGenerator0 => "NotCamAPulseGenerator0";

		public string NotBypassGPI7 => "NotBypassGPI7";

		public string NotBypassGPI6 => "NotBypassGPI6";

		public string NotBypassGPI5 => "NotBypassGPI5";

		public string NotBypassGPI4 => "NotBypassGPI4";

		public string NotBypassGPI3 => "NotBypassGPI3";

		public string NotBypassGPI2 => "NotBypassGPI2";

		public string NotBypassGPI1 => "NotBypassGPI1";

		public string NotBypassGPI0 => "NotBypassGPI0";

		public string NotBypassFrontGPI3 => "NotBypassFrontGPI3";

		public string NotBypassFrontGPI2 => "NotBypassFrontGPI2";

		public string NotBypassFrontGPI1 => "NotBypassFrontGPI1";

		public string NotBypassFrontGPI0 => "NotBypassFrontGPI0";

		public string GND => "GND";

		public string CamDPulseGenerator3 => "CamDPulseGenerator3";

		public string CamDPulseGenerator2 => "CamDPulseGenerator2";

		public string CamDPulseGenerator1 => "CamDPulseGenerator1";

		public string CamDPulseGenerator0 => "CamDPulseGenerator0";

		public string CamCPulseGenerator3 => "CamCPulseGenerator3";

		public string CamCPulseGenerator2 => "CamCPulseGenerator2";

		public string CamCPulseGenerator1 => "CamCPulseGenerator1";

		public string CamCPulseGenerator0 => "CamCPulseGenerator0";

		public string CamBPulseGenerator3 => "CamBPulseGenerator3";

		public string CamBPulseGenerator2 => "CamBPulseGenerator2";

		public string CamBPulseGenerator1 => "CamBPulseGenerator1";

		public string CamBPulseGenerator0 => "CamBPulseGenerator0";

		public string CamAPulseGenerator3 => "CamAPulseGenerator3";

		public string CamAPulseGenerator2 => "CamAPulseGenerator2";

		public string CamAPulseGenerator1 => "CamAPulseGenerator1";

		public string CamAPulseGenerator0 => "CamAPulseGenerator0";

		public string BypassGPI7 => "BypassGPI7";

		public string BypassGPI6 => "BypassGPI6";

		public string BypassGPI5 => "BypassGPI5";

		public string BypassGPI4 => "BypassGPI4";

		public string BypassGPI3 => "BypassGPI3";

		public string BypassGPI2 => "BypassGPI2";

		public string BypassGPI1 => "BypassGPI1";

		public string BypassGPI0 => "BypassGPI0";

		public string BypassFrontGPI3 => "BypassFrontGPI3";

		public string BypassFrontGPI2 => "BypassFrontGPI2";

		public string BypassFrontGPI1 => "BypassFrontGPI1";

		public string BypassFrontGPI0 => "BypassFrontGPI0";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class TriggerOutSelectGPO3Enum : ParameterListEnum
	{
		public override string Name => "@DeviceTransportLayer/TriggerOutSelectGPO3";

		public string VCC => "VCC";

		public string PulseGenerator3 => "PulseGenerator3";

		public string PulseGenerator2 => "PulseGenerator2";

		public string PulseGenerator1 => "PulseGenerator1";

		public string PulseGenerator0 => "PulseGenerator0";

		public string NotPulseGenerator3 => "NotPulseGenerator3";

		public string NotPulseGenerator2 => "NotPulseGenerator2";

		public string NotPulseGenerator1 => "NotPulseGenerator1";

		public string NotPulseGenerator0 => "NotPulseGenerator0";

		public string NotCamDPulseGenerator3 => "NotCamDPulseGenerator3";

		public string NotCamDPulseGenerator2 => "NotCamDPulseGenerator2";

		public string NotCamDPulseGenerator1 => "NotCamDPulseGenerator1";

		public string NotCamDPulseGenerator0 => "NotCamDPulseGenerator0";

		public string NotCamCPulseGenerator3 => "NotCamCPulseGenerator3";

		public string NotCamCPulseGenerator2 => "NotCamCPulseGenerator2";

		public string NotCamCPulseGenerator1 => "NotCamCPulseGenerator1";

		public string NotCamCPulseGenerator0 => "NotCamCPulseGenerator0";

		public string NotCamBPulseGenerator3 => "NotCamBPulseGenerator3";

		public string NotCamBPulseGenerator2 => "NotCamBPulseGenerator2";

		public string NotCamBPulseGenerator1 => "NotCamBPulseGenerator1";

		public string NotCamBPulseGenerator0 => "NotCamBPulseGenerator0";

		public string NotCamAPulseGenerator3 => "NotCamAPulseGenerator3";

		public string NotCamAPulseGenerator2 => "NotCamAPulseGenerator2";

		public string NotCamAPulseGenerator1 => "NotCamAPulseGenerator1";

		public string NotCamAPulseGenerator0 => "NotCamAPulseGenerator0";

		public string NotBypassGPI7 => "NotBypassGPI7";

		public string NotBypassGPI6 => "NotBypassGPI6";

		public string NotBypassGPI5 => "NotBypassGPI5";

		public string NotBypassGPI4 => "NotBypassGPI4";

		public string NotBypassGPI3 => "NotBypassGPI3";

		public string NotBypassGPI2 => "NotBypassGPI2";

		public string NotBypassGPI1 => "NotBypassGPI1";

		public string NotBypassGPI0 => "NotBypassGPI0";

		public string NotBypassFrontGPI3 => "NotBypassFrontGPI3";

		public string NotBypassFrontGPI2 => "NotBypassFrontGPI2";

		public string NotBypassFrontGPI1 => "NotBypassFrontGPI1";

		public string NotBypassFrontGPI0 => "NotBypassFrontGPI0";

		public string GND => "GND";

		public string CamDPulseGenerator3 => "CamDPulseGenerator3";

		public string CamDPulseGenerator2 => "CamDPulseGenerator2";

		public string CamDPulseGenerator1 => "CamDPulseGenerator1";

		public string CamDPulseGenerator0 => "CamDPulseGenerator0";

		public string CamCPulseGenerator3 => "CamCPulseGenerator3";

		public string CamCPulseGenerator2 => "CamCPulseGenerator2";

		public string CamCPulseGenerator1 => "CamCPulseGenerator1";

		public string CamCPulseGenerator0 => "CamCPulseGenerator0";

		public string CamBPulseGenerator3 => "CamBPulseGenerator3";

		public string CamBPulseGenerator2 => "CamBPulseGenerator2";

		public string CamBPulseGenerator1 => "CamBPulseGenerator1";

		public string CamBPulseGenerator0 => "CamBPulseGenerator0";

		public string CamAPulseGenerator3 => "CamAPulseGenerator3";

		public string CamAPulseGenerator2 => "CamAPulseGenerator2";

		public string CamAPulseGenerator1 => "CamAPulseGenerator1";

		public string CamAPulseGenerator0 => "CamAPulseGenerator0";

		public string BypassGPI7 => "BypassGPI7";

		public string BypassGPI6 => "BypassGPI6";

		public string BypassGPI5 => "BypassGPI5";

		public string BypassGPI4 => "BypassGPI4";

		public string BypassGPI3 => "BypassGPI3";

		public string BypassGPI2 => "BypassGPI2";

		public string BypassGPI1 => "BypassGPI1";

		public string BypassGPI0 => "BypassGPI0";

		public string BypassFrontGPI3 => "BypassFrontGPI3";

		public string BypassFrontGPI2 => "BypassFrontGPI2";

		public string BypassFrontGPI1 => "BypassFrontGPI1";

		public string BypassFrontGPI0 => "BypassFrontGPI0";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class TriggerOutSelectGPO4Enum : ParameterListEnum
	{
		public override string Name => "@DeviceTransportLayer/TriggerOutSelectGPO4";

		public string VCC => "VCC";

		public string PulseGenerator3 => "PulseGenerator3";

		public string PulseGenerator2 => "PulseGenerator2";

		public string PulseGenerator1 => "PulseGenerator1";

		public string PulseGenerator0 => "PulseGenerator0";

		public string NotPulseGenerator3 => "NotPulseGenerator3";

		public string NotPulseGenerator2 => "NotPulseGenerator2";

		public string NotPulseGenerator1 => "NotPulseGenerator1";

		public string NotPulseGenerator0 => "NotPulseGenerator0";

		public string NotCamDPulseGenerator3 => "NotCamDPulseGenerator3";

		public string NotCamDPulseGenerator2 => "NotCamDPulseGenerator2";

		public string NotCamDPulseGenerator1 => "NotCamDPulseGenerator1";

		public string NotCamDPulseGenerator0 => "NotCamDPulseGenerator0";

		public string NotCamCPulseGenerator3 => "NotCamCPulseGenerator3";

		public string NotCamCPulseGenerator2 => "NotCamCPulseGenerator2";

		public string NotCamCPulseGenerator1 => "NotCamCPulseGenerator1";

		public string NotCamCPulseGenerator0 => "NotCamCPulseGenerator0";

		public string NotCamBPulseGenerator3 => "NotCamBPulseGenerator3";

		public string NotCamBPulseGenerator2 => "NotCamBPulseGenerator2";

		public string NotCamBPulseGenerator1 => "NotCamBPulseGenerator1";

		public string NotCamBPulseGenerator0 => "NotCamBPulseGenerator0";

		public string NotCamAPulseGenerator3 => "NotCamAPulseGenerator3";

		public string NotCamAPulseGenerator2 => "NotCamAPulseGenerator2";

		public string NotCamAPulseGenerator1 => "NotCamAPulseGenerator1";

		public string NotCamAPulseGenerator0 => "NotCamAPulseGenerator0";

		public string NotBypassGPI7 => "NotBypassGPI7";

		public string NotBypassGPI6 => "NotBypassGPI6";

		public string NotBypassGPI5 => "NotBypassGPI5";

		public string NotBypassGPI4 => "NotBypassGPI4";

		public string NotBypassGPI3 => "NotBypassGPI3";

		public string NotBypassGPI2 => "NotBypassGPI2";

		public string NotBypassGPI1 => "NotBypassGPI1";

		public string NotBypassGPI0 => "NotBypassGPI0";

		public string NotBypassFrontGPI3 => "NotBypassFrontGPI3";

		public string NotBypassFrontGPI2 => "NotBypassFrontGPI2";

		public string NotBypassFrontGPI1 => "NotBypassFrontGPI1";

		public string NotBypassFrontGPI0 => "NotBypassFrontGPI0";

		public string GND => "GND";

		public string CamDPulseGenerator3 => "CamDPulseGenerator3";

		public string CamDPulseGenerator2 => "CamDPulseGenerator2";

		public string CamDPulseGenerator1 => "CamDPulseGenerator1";

		public string CamDPulseGenerator0 => "CamDPulseGenerator0";

		public string CamCPulseGenerator3 => "CamCPulseGenerator3";

		public string CamCPulseGenerator2 => "CamCPulseGenerator2";

		public string CamCPulseGenerator1 => "CamCPulseGenerator1";

		public string CamCPulseGenerator0 => "CamCPulseGenerator0";

		public string CamBPulseGenerator3 => "CamBPulseGenerator3";

		public string CamBPulseGenerator2 => "CamBPulseGenerator2";

		public string CamBPulseGenerator1 => "CamBPulseGenerator1";

		public string CamBPulseGenerator0 => "CamBPulseGenerator0";

		public string CamAPulseGenerator3 => "CamAPulseGenerator3";

		public string CamAPulseGenerator2 => "CamAPulseGenerator2";

		public string CamAPulseGenerator1 => "CamAPulseGenerator1";

		public string CamAPulseGenerator0 => "CamAPulseGenerator0";

		public string BypassGPI7 => "BypassGPI7";

		public string BypassGPI6 => "BypassGPI6";

		public string BypassGPI5 => "BypassGPI5";

		public string BypassGPI4 => "BypassGPI4";

		public string BypassGPI3 => "BypassGPI3";

		public string BypassGPI2 => "BypassGPI2";

		public string BypassGPI1 => "BypassGPI1";

		public string BypassGPI0 => "BypassGPI0";

		public string BypassFrontGPI3 => "BypassFrontGPI3";

		public string BypassFrontGPI2 => "BypassFrontGPI2";

		public string BypassFrontGPI1 => "BypassFrontGPI1";

		public string BypassFrontGPI0 => "BypassFrontGPI0";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class TriggerOutSelectGPO5Enum : ParameterListEnum
	{
		public override string Name => "@DeviceTransportLayer/TriggerOutSelectGPO5";

		public string VCC => "VCC";

		public string PulseGenerator3 => "PulseGenerator3";

		public string PulseGenerator2 => "PulseGenerator2";

		public string PulseGenerator1 => "PulseGenerator1";

		public string PulseGenerator0 => "PulseGenerator0";

		public string NotPulseGenerator3 => "NotPulseGenerator3";

		public string NotPulseGenerator2 => "NotPulseGenerator2";

		public string NotPulseGenerator1 => "NotPulseGenerator1";

		public string NotPulseGenerator0 => "NotPulseGenerator0";

		public string NotCamDPulseGenerator3 => "NotCamDPulseGenerator3";

		public string NotCamDPulseGenerator2 => "NotCamDPulseGenerator2";

		public string NotCamDPulseGenerator1 => "NotCamDPulseGenerator1";

		public string NotCamDPulseGenerator0 => "NotCamDPulseGenerator0";

		public string NotCamCPulseGenerator3 => "NotCamCPulseGenerator3";

		public string NotCamCPulseGenerator2 => "NotCamCPulseGenerator2";

		public string NotCamCPulseGenerator1 => "NotCamCPulseGenerator1";

		public string NotCamCPulseGenerator0 => "NotCamCPulseGenerator0";

		public string NotCamBPulseGenerator3 => "NotCamBPulseGenerator3";

		public string NotCamBPulseGenerator2 => "NotCamBPulseGenerator2";

		public string NotCamBPulseGenerator1 => "NotCamBPulseGenerator1";

		public string NotCamBPulseGenerator0 => "NotCamBPulseGenerator0";

		public string NotCamAPulseGenerator3 => "NotCamAPulseGenerator3";

		public string NotCamAPulseGenerator2 => "NotCamAPulseGenerator2";

		public string NotCamAPulseGenerator1 => "NotCamAPulseGenerator1";

		public string NotCamAPulseGenerator0 => "NotCamAPulseGenerator0";

		public string NotBypassGPI7 => "NotBypassGPI7";

		public string NotBypassGPI6 => "NotBypassGPI6";

		public string NotBypassGPI5 => "NotBypassGPI5";

		public string NotBypassGPI4 => "NotBypassGPI4";

		public string NotBypassGPI3 => "NotBypassGPI3";

		public string NotBypassGPI2 => "NotBypassGPI2";

		public string NotBypassGPI1 => "NotBypassGPI1";

		public string NotBypassGPI0 => "NotBypassGPI0";

		public string NotBypassFrontGPI3 => "NotBypassFrontGPI3";

		public string NotBypassFrontGPI2 => "NotBypassFrontGPI2";

		public string NotBypassFrontGPI1 => "NotBypassFrontGPI1";

		public string NotBypassFrontGPI0 => "NotBypassFrontGPI0";

		public string GND => "GND";

		public string CamDPulseGenerator3 => "CamDPulseGenerator3";

		public string CamDPulseGenerator2 => "CamDPulseGenerator2";

		public string CamDPulseGenerator1 => "CamDPulseGenerator1";

		public string CamDPulseGenerator0 => "CamDPulseGenerator0";

		public string CamCPulseGenerator3 => "CamCPulseGenerator3";

		public string CamCPulseGenerator2 => "CamCPulseGenerator2";

		public string CamCPulseGenerator1 => "CamCPulseGenerator1";

		public string CamCPulseGenerator0 => "CamCPulseGenerator0";

		public string CamBPulseGenerator3 => "CamBPulseGenerator3";

		public string CamBPulseGenerator2 => "CamBPulseGenerator2";

		public string CamBPulseGenerator1 => "CamBPulseGenerator1";

		public string CamBPulseGenerator0 => "CamBPulseGenerator0";

		public string CamAPulseGenerator3 => "CamAPulseGenerator3";

		public string CamAPulseGenerator2 => "CamAPulseGenerator2";

		public string CamAPulseGenerator1 => "CamAPulseGenerator1";

		public string CamAPulseGenerator0 => "CamAPulseGenerator0";

		public string BypassGPI7 => "BypassGPI7";

		public string BypassGPI6 => "BypassGPI6";

		public string BypassGPI5 => "BypassGPI5";

		public string BypassGPI4 => "BypassGPI4";

		public string BypassGPI3 => "BypassGPI3";

		public string BypassGPI2 => "BypassGPI2";

		public string BypassGPI1 => "BypassGPI1";

		public string BypassGPI0 => "BypassGPI0";

		public string BypassFrontGPI3 => "BypassFrontGPI3";

		public string BypassFrontGPI2 => "BypassFrontGPI2";

		public string BypassFrontGPI1 => "BypassFrontGPI1";

		public string BypassFrontGPI0 => "BypassFrontGPI0";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class TriggerOutSelectGPO6Enum : ParameterListEnum
	{
		public override string Name => "@DeviceTransportLayer/TriggerOutSelectGPO6";

		public string VCC => "VCC";

		public string PulseGenerator3 => "PulseGenerator3";

		public string PulseGenerator2 => "PulseGenerator2";

		public string PulseGenerator1 => "PulseGenerator1";

		public string PulseGenerator0 => "PulseGenerator0";

		public string NotPulseGenerator3 => "NotPulseGenerator3";

		public string NotPulseGenerator2 => "NotPulseGenerator2";

		public string NotPulseGenerator1 => "NotPulseGenerator1";

		public string NotPulseGenerator0 => "NotPulseGenerator0";

		public string NotCamDPulseGenerator3 => "NotCamDPulseGenerator3";

		public string NotCamDPulseGenerator2 => "NotCamDPulseGenerator2";

		public string NotCamDPulseGenerator1 => "NotCamDPulseGenerator1";

		public string NotCamDPulseGenerator0 => "NotCamDPulseGenerator0";

		public string NotCamCPulseGenerator3 => "NotCamCPulseGenerator3";

		public string NotCamCPulseGenerator2 => "NotCamCPulseGenerator2";

		public string NotCamCPulseGenerator1 => "NotCamCPulseGenerator1";

		public string NotCamCPulseGenerator0 => "NotCamCPulseGenerator0";

		public string NotCamBPulseGenerator3 => "NotCamBPulseGenerator3";

		public string NotCamBPulseGenerator2 => "NotCamBPulseGenerator2";

		public string NotCamBPulseGenerator1 => "NotCamBPulseGenerator1";

		public string NotCamBPulseGenerator0 => "NotCamBPulseGenerator0";

		public string NotCamAPulseGenerator3 => "NotCamAPulseGenerator3";

		public string NotCamAPulseGenerator2 => "NotCamAPulseGenerator2";

		public string NotCamAPulseGenerator1 => "NotCamAPulseGenerator1";

		public string NotCamAPulseGenerator0 => "NotCamAPulseGenerator0";

		public string NotBypassGPI7 => "NotBypassGPI7";

		public string NotBypassGPI6 => "NotBypassGPI6";

		public string NotBypassGPI5 => "NotBypassGPI5";

		public string NotBypassGPI4 => "NotBypassGPI4";

		public string NotBypassGPI3 => "NotBypassGPI3";

		public string NotBypassGPI2 => "NotBypassGPI2";

		public string NotBypassGPI1 => "NotBypassGPI1";

		public string NotBypassGPI0 => "NotBypassGPI0";

		public string NotBypassFrontGPI3 => "NotBypassFrontGPI3";

		public string NotBypassFrontGPI2 => "NotBypassFrontGPI2";

		public string NotBypassFrontGPI1 => "NotBypassFrontGPI1";

		public string NotBypassFrontGPI0 => "NotBypassFrontGPI0";

		public string GND => "GND";

		public string CamDPulseGenerator3 => "CamDPulseGenerator3";

		public string CamDPulseGenerator2 => "CamDPulseGenerator2";

		public string CamDPulseGenerator1 => "CamDPulseGenerator1";

		public string CamDPulseGenerator0 => "CamDPulseGenerator0";

		public string CamCPulseGenerator3 => "CamCPulseGenerator3";

		public string CamCPulseGenerator2 => "CamCPulseGenerator2";

		public string CamCPulseGenerator1 => "CamCPulseGenerator1";

		public string CamCPulseGenerator0 => "CamCPulseGenerator0";

		public string CamBPulseGenerator3 => "CamBPulseGenerator3";

		public string CamBPulseGenerator2 => "CamBPulseGenerator2";

		public string CamBPulseGenerator1 => "CamBPulseGenerator1";

		public string CamBPulseGenerator0 => "CamBPulseGenerator0";

		public string CamAPulseGenerator3 => "CamAPulseGenerator3";

		public string CamAPulseGenerator2 => "CamAPulseGenerator2";

		public string CamAPulseGenerator1 => "CamAPulseGenerator1";

		public string CamAPulseGenerator0 => "CamAPulseGenerator0";

		public string BypassGPI7 => "BypassGPI7";

		public string BypassGPI6 => "BypassGPI6";

		public string BypassGPI5 => "BypassGPI5";

		public string BypassGPI4 => "BypassGPI4";

		public string BypassGPI3 => "BypassGPI3";

		public string BypassGPI2 => "BypassGPI2";

		public string BypassGPI1 => "BypassGPI1";

		public string BypassGPI0 => "BypassGPI0";

		public string BypassFrontGPI3 => "BypassFrontGPI3";

		public string BypassFrontGPI2 => "BypassFrontGPI2";

		public string BypassFrontGPI1 => "BypassFrontGPI1";

		public string BypassFrontGPI0 => "BypassFrontGPI0";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class TriggerOutSelectGPO7Enum : ParameterListEnum
	{
		public override string Name => "@DeviceTransportLayer/TriggerOutSelectGPO7";

		public string VCC => "VCC";

		public string PulseGenerator3 => "PulseGenerator3";

		public string PulseGenerator2 => "PulseGenerator2";

		public string PulseGenerator1 => "PulseGenerator1";

		public string PulseGenerator0 => "PulseGenerator0";

		public string NotPulseGenerator3 => "NotPulseGenerator3";

		public string NotPulseGenerator2 => "NotPulseGenerator2";

		public string NotPulseGenerator1 => "NotPulseGenerator1";

		public string NotPulseGenerator0 => "NotPulseGenerator0";

		public string NotCamDPulseGenerator3 => "NotCamDPulseGenerator3";

		public string NotCamDPulseGenerator2 => "NotCamDPulseGenerator2";

		public string NotCamDPulseGenerator1 => "NotCamDPulseGenerator1";

		public string NotCamDPulseGenerator0 => "NotCamDPulseGenerator0";

		public string NotCamCPulseGenerator3 => "NotCamCPulseGenerator3";

		public string NotCamCPulseGenerator2 => "NotCamCPulseGenerator2";

		public string NotCamCPulseGenerator1 => "NotCamCPulseGenerator1";

		public string NotCamCPulseGenerator0 => "NotCamCPulseGenerator0";

		public string NotCamBPulseGenerator3 => "NotCamBPulseGenerator3";

		public string NotCamBPulseGenerator2 => "NotCamBPulseGenerator2";

		public string NotCamBPulseGenerator1 => "NotCamBPulseGenerator1";

		public string NotCamBPulseGenerator0 => "NotCamBPulseGenerator0";

		public string NotCamAPulseGenerator3 => "NotCamAPulseGenerator3";

		public string NotCamAPulseGenerator2 => "NotCamAPulseGenerator2";

		public string NotCamAPulseGenerator1 => "NotCamAPulseGenerator1";

		public string NotCamAPulseGenerator0 => "NotCamAPulseGenerator0";

		public string NotBypassGPI7 => "NotBypassGPI7";

		public string NotBypassGPI6 => "NotBypassGPI6";

		public string NotBypassGPI5 => "NotBypassGPI5";

		public string NotBypassGPI4 => "NotBypassGPI4";

		public string NotBypassGPI3 => "NotBypassGPI3";

		public string NotBypassGPI2 => "NotBypassGPI2";

		public string NotBypassGPI1 => "NotBypassGPI1";

		public string NotBypassGPI0 => "NotBypassGPI0";

		public string NotBypassFrontGPI3 => "NotBypassFrontGPI3";

		public string NotBypassFrontGPI2 => "NotBypassFrontGPI2";

		public string NotBypassFrontGPI1 => "NotBypassFrontGPI1";

		public string NotBypassFrontGPI0 => "NotBypassFrontGPI0";

		public string GND => "GND";

		public string CamDPulseGenerator3 => "CamDPulseGenerator3";

		public string CamDPulseGenerator2 => "CamDPulseGenerator2";

		public string CamDPulseGenerator1 => "CamDPulseGenerator1";

		public string CamDPulseGenerator0 => "CamDPulseGenerator0";

		public string CamCPulseGenerator3 => "CamCPulseGenerator3";

		public string CamCPulseGenerator2 => "CamCPulseGenerator2";

		public string CamCPulseGenerator1 => "CamCPulseGenerator1";

		public string CamCPulseGenerator0 => "CamCPulseGenerator0";

		public string CamBPulseGenerator3 => "CamBPulseGenerator3";

		public string CamBPulseGenerator2 => "CamBPulseGenerator2";

		public string CamBPulseGenerator1 => "CamBPulseGenerator1";

		public string CamBPulseGenerator0 => "CamBPulseGenerator0";

		public string CamAPulseGenerator3 => "CamAPulseGenerator3";

		public string CamAPulseGenerator2 => "CamAPulseGenerator2";

		public string CamAPulseGenerator1 => "CamAPulseGenerator1";

		public string CamAPulseGenerator0 => "CamAPulseGenerator0";

		public string BypassGPI7 => "BypassGPI7";

		public string BypassGPI6 => "BypassGPI6";

		public string BypassGPI5 => "BypassGPI5";

		public string BypassGPI4 => "BypassGPI4";

		public string BypassGPI3 => "BypassGPI3";

		public string BypassGPI2 => "BypassGPI2";

		public string BypassGPI1 => "BypassGPI1";

		public string BypassGPI0 => "BypassGPI0";

		public string BypassFrontGPI3 => "BypassFrontGPI3";

		public string BypassFrontGPI2 => "BypassFrontGPI2";

		public string BypassFrontGPI1 => "BypassFrontGPI1";

		public string BypassFrontGPI0 => "BypassFrontGPI0";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class TriggerOutStatisticsSourceEnum : ParameterListEnum
	{
		public override string Name => "@DeviceTransportLayer/TriggerOutStatisticsSource";

		public string PulseGenerator3 => "PulseGenerator3";

		public string PulseGenerator2 => "PulseGenerator2";

		public string PulseGenerator1 => "PulseGenerator1";

		public string PulseGenerator0 => "PulseGenerator0";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class TriggerOutputEventSelectEnum : ParameterListEnum
	{
		public override string Name => "@DeviceTransportLayer/TriggerOutputEventSelect";

		public string PulseGenerator3 => "PulseGenerator3";

		public string PulseGenerator2 => "PulseGenerator2";

		public string PulseGenerator1 => "PulseGenerator1";

		public string PulseGenerator0 => "PulseGenerator0";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class TriggerQueueModeEnum : ParameterListEnum
	{
		public override string Name => "@DeviceTransportLayer/TriggerQueueMode";

		public string On => "On";

		public string Off => "Off";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class TriggerStateEnum : ParameterListEnum
	{
		public override string Name => "@DeviceTransportLayer/TriggerState";

		public string SyncStop => "SyncStop";

		public string AsyncStop => "AsyncStop";

		public string Active => "Active";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class VantagePointEnum : ParameterListEnum
	{
		public override string Name => "@DeviceTransportLayer/VantagePoint";

		public string TopRight => "TopRight";

		public string TopLeft => "TopLeft";

		public string BottomRight => "BottomRight";

		public string BottomLeft => "BottomLeft";

		public override string ToString()
		{
			return Name;
		}
	}

	private static AreaTriggerModeEnum m_AreaTriggerModeCached = null;

	private static BitAlignmentEnum m_BitAlignmentCached = null;

	private static CxpLinkConfigurationEnum m_CxpLinkConfigurationCached = null;

	private static CxpTriggerPacketModeEnum m_CxpTriggerPacketModeCached = null;

	private static DeviceAccessStatusEnum m_DeviceAccessStatusCached = null;

	private static DeviceEndianessMechanismEnum m_DeviceEndianessMechanismCached = null;

	private static DeviceTypeEnum m_DeviceTypeCached = null;

	private static EventNotificationEnum m_EventNotificationCached = null;

	private static EventSelectorEnum m_EventSelectorCached = null;

	private static FormatEnum m_FormatCached = null;

	private static LutEnableEnum m_LutEnableCached = null;

	private static LutImplementationTypeEnum m_LutImplementationTypeCached = null;

	private static LutTypeEnum m_LutTypeCached = null;

	private static MissingCameraFrameResponseEnum m_MissingCameraFrameResponseCached = null;

	private static OverflowEventSelectEnum m_OverflowEventSelectCached = null;

	private static PixelFormatEnum m_PixelFormatCached = null;

	private static ProcessingInvertEnum m_ProcessingInvertCached = null;

	private static SoftwareTriggerIsBusyEnum m_SoftwareTriggerIsBusyCached = null;

	private static SystemmonitorByteAlignment8b10bLockedEnum m_SystemmonitorByteAlignment8b10bLockedCached = null;

	private static SystemmonitorExternalPowerEnum m_SystemmonitorExternalPowerCached = null;

	private static SystemmonitorPowerOverCxpStateEnum m_SystemmonitorPowerOverCxpStateCached = null;

	private static TriggerCameraOutSelectEnum m_TriggerCameraOutSelectCached = null;

	private static TriggerExceededPeriodLimitsEnum m_TriggerExceededPeriodLimitsCached = null;

	private static TriggerInPolarityEnum m_TriggerInPolarityCached = null;

	private static TriggerInSourceEnum m_TriggerInSourceCached = null;

	private static TriggerInStatisticsPolarityEnum m_TriggerInStatisticsPolarityCached = null;

	private static TriggerInStatisticsSourceEnum m_TriggerInStatisticsSourceCached = null;

	private static TriggerOutSelectFrontGPO0Enum m_TriggerOutSelectFrontGPO0Cached = null;

	private static TriggerOutSelectFrontGPO1Enum m_TriggerOutSelectFrontGPO1Cached = null;

	private static TriggerOutSelectGPO0Enum m_TriggerOutSelectGPO0Cached = null;

	private static TriggerOutSelectGPO1Enum m_TriggerOutSelectGPO1Cached = null;

	private static TriggerOutSelectGPO2Enum m_TriggerOutSelectGPO2Cached = null;

	private static TriggerOutSelectGPO3Enum m_TriggerOutSelectGPO3Cached = null;

	private static TriggerOutSelectGPO4Enum m_TriggerOutSelectGPO4Cached = null;

	private static TriggerOutSelectGPO5Enum m_TriggerOutSelectGPO5Cached = null;

	private static TriggerOutSelectGPO6Enum m_TriggerOutSelectGPO6Cached = null;

	private static TriggerOutSelectGPO7Enum m_TriggerOutSelectGPO7Cached = null;

	private static TriggerOutStatisticsSourceEnum m_TriggerOutStatisticsSourceCached = null;

	private static TriggerOutputEventSelectEnum m_TriggerOutputEventSelectCached = null;

	private static TriggerQueueModeEnum m_TriggerQueueModeCached = null;

	private static TriggerStateEnum m_TriggerStateCached = null;

	private static VantagePointEnum m_VantagePointCached = null;

	public static IntegerName WriteTimeout => new IntegerName("@DeviceTransportLayer/WriteTimeout");

	public static IntegerName Width => new IntegerName("@DeviceTransportLayer/Width");

	public static VantagePointEnum VantagePoint
	{
		get
		{
			if (m_VantagePointCached == null)
			{
				m_VantagePointCached = new VantagePointEnum();
			}
			return m_VantagePointCached;
		}
	}

	public static IntegerName UncorrectedErrorCount => new IntegerName("@DeviceTransportLayer/UncorrectedErrorCount");

	public static IntegerName TriggerWaveViolation => new IntegerName("@DeviceTransportLayer/TriggerWaveViolation");

	public static TriggerStateEnum TriggerState
	{
		get
		{
			if (m_TriggerStateCached == null)
			{
				m_TriggerStateCached = new TriggerStateEnum();
			}
			return m_TriggerStateCached;
		}
	}

	public static TriggerQueueModeEnum TriggerQueueMode
	{
		get
		{
			if (m_TriggerQueueModeCached == null)
			{
				m_TriggerQueueModeCached = new TriggerQueueModeEnum();
			}
			return m_TriggerQueueModeCached;
		}
	}

	public static IntegerName TriggerQueueFillLevelEventOnThreshold => new IntegerName("@DeviceTransportLayer/TriggerQueueFillLevelEventOnThreshold");

	public static IntegerName TriggerQueueFillLevelEventOffThreshold => new IntegerName("@DeviceTransportLayer/TriggerQueueFillLevelEventOffThreshold");

	public static IntegerName TriggerQueueFillLevel => new IntegerName("@DeviceTransportLayer/TriggerQueueFillLevel");

	public static FloatName TriggerPulseFormGenerator3Width => new FloatName("@DeviceTransportLayer/TriggerPulseFormGenerator3Width");

	public static IntegerName TriggerPulseFormGenerator3DownscalePhase => new IntegerName("@DeviceTransportLayer/TriggerPulseFormGenerator3DownscalePhase");

	public static IntegerName TriggerPulseFormGenerator3Downscale => new IntegerName("@DeviceTransportLayer/TriggerPulseFormGenerator3Downscale");

	public static FloatName TriggerPulseFormGenerator3Delay => new FloatName("@DeviceTransportLayer/TriggerPulseFormGenerator3Delay");

	public static FloatName TriggerPulseFormGenerator2Width => new FloatName("@DeviceTransportLayer/TriggerPulseFormGenerator2Width");

	public static IntegerName TriggerPulseFormGenerator2DownscalePhase => new IntegerName("@DeviceTransportLayer/TriggerPulseFormGenerator2DownscalePhase");

	public static IntegerName TriggerPulseFormGenerator2Downscale => new IntegerName("@DeviceTransportLayer/TriggerPulseFormGenerator2Downscale");

	public static FloatName TriggerPulseFormGenerator2Delay => new FloatName("@DeviceTransportLayer/TriggerPulseFormGenerator2Delay");

	public static FloatName TriggerPulseFormGenerator1Width => new FloatName("@DeviceTransportLayer/TriggerPulseFormGenerator1Width");

	public static IntegerName TriggerPulseFormGenerator1DownscalePhase => new IntegerName("@DeviceTransportLayer/TriggerPulseFormGenerator1DownscalePhase");

	public static IntegerName TriggerPulseFormGenerator1Downscale => new IntegerName("@DeviceTransportLayer/TriggerPulseFormGenerator1Downscale");

	public static FloatName TriggerPulseFormGenerator1Delay => new FloatName("@DeviceTransportLayer/TriggerPulseFormGenerator1Delay");

	public static FloatName TriggerPulseFormGenerator0Width => new FloatName("@DeviceTransportLayer/TriggerPulseFormGenerator0Width");

	public static IntegerName TriggerPulseFormGenerator0DownscalePhase => new IntegerName("@DeviceTransportLayer/TriggerPulseFormGenerator0DownscalePhase");

	public static IntegerName TriggerPulseFormGenerator0Downscale => new IntegerName("@DeviceTransportLayer/TriggerPulseFormGenerator0Downscale");

	public static FloatName TriggerPulseFormGenerator0Delay => new FloatName("@DeviceTransportLayer/TriggerPulseFormGenerator0Delay");

	public static FloatName TriggerOutputFrequency => new FloatName("@DeviceTransportLayer/TriggerOutputFrequency");

	public static TriggerOutputEventSelectEnum TriggerOutputEventSelect
	{
		get
		{
			if (m_TriggerOutputEventSelectCached == null)
			{
				m_TriggerOutputEventSelectCached = new TriggerOutputEventSelectEnum();
			}
			return m_TriggerOutputEventSelectCached;
		}
	}

	public static TriggerOutStatisticsSourceEnum TriggerOutStatisticsSource
	{
		get
		{
			if (m_TriggerOutStatisticsSourceCached == null)
			{
				m_TriggerOutStatisticsSourceCached = new TriggerOutStatisticsSourceEnum();
			}
			return m_TriggerOutStatisticsSourceCached;
		}
	}

	public static CommandName TriggerOutStatisticsPulseCountClear => new CommandName("@DeviceTransportLayer/TriggerOutStatisticsPulseCountClear");

	public static IntegerName TriggerOutStatisticsPulseCount => new IntegerName("@DeviceTransportLayer/TriggerOutStatisticsPulseCount");

	public static TriggerOutSelectGPO7Enum TriggerOutSelectGPO7
	{
		get
		{
			if (m_TriggerOutSelectGPO7Cached == null)
			{
				m_TriggerOutSelectGPO7Cached = new TriggerOutSelectGPO7Enum();
			}
			return m_TriggerOutSelectGPO7Cached;
		}
	}

	public static TriggerOutSelectGPO6Enum TriggerOutSelectGPO6
	{
		get
		{
			if (m_TriggerOutSelectGPO6Cached == null)
			{
				m_TriggerOutSelectGPO6Cached = new TriggerOutSelectGPO6Enum();
			}
			return m_TriggerOutSelectGPO6Cached;
		}
	}

	public static TriggerOutSelectGPO5Enum TriggerOutSelectGPO5
	{
		get
		{
			if (m_TriggerOutSelectGPO5Cached == null)
			{
				m_TriggerOutSelectGPO5Cached = new TriggerOutSelectGPO5Enum();
			}
			return m_TriggerOutSelectGPO5Cached;
		}
	}

	public static TriggerOutSelectGPO4Enum TriggerOutSelectGPO4
	{
		get
		{
			if (m_TriggerOutSelectGPO4Cached == null)
			{
				m_TriggerOutSelectGPO4Cached = new TriggerOutSelectGPO4Enum();
			}
			return m_TriggerOutSelectGPO4Cached;
		}
	}

	public static TriggerOutSelectGPO3Enum TriggerOutSelectGPO3
	{
		get
		{
			if (m_TriggerOutSelectGPO3Cached == null)
			{
				m_TriggerOutSelectGPO3Cached = new TriggerOutSelectGPO3Enum();
			}
			return m_TriggerOutSelectGPO3Cached;
		}
	}

	public static TriggerOutSelectGPO2Enum TriggerOutSelectGPO2
	{
		get
		{
			if (m_TriggerOutSelectGPO2Cached == null)
			{
				m_TriggerOutSelectGPO2Cached = new TriggerOutSelectGPO2Enum();
			}
			return m_TriggerOutSelectGPO2Cached;
		}
	}

	public static TriggerOutSelectGPO1Enum TriggerOutSelectGPO1
	{
		get
		{
			if (m_TriggerOutSelectGPO1Cached == null)
			{
				m_TriggerOutSelectGPO1Cached = new TriggerOutSelectGPO1Enum();
			}
			return m_TriggerOutSelectGPO1Cached;
		}
	}

	public static TriggerOutSelectGPO0Enum TriggerOutSelectGPO0
	{
		get
		{
			if (m_TriggerOutSelectGPO0Cached == null)
			{
				m_TriggerOutSelectGPO0Cached = new TriggerOutSelectGPO0Enum();
			}
			return m_TriggerOutSelectGPO0Cached;
		}
	}

	public static TriggerOutSelectFrontGPO1Enum TriggerOutSelectFrontGPO1
	{
		get
		{
			if (m_TriggerOutSelectFrontGPO1Cached == null)
			{
				m_TriggerOutSelectFrontGPO1Cached = new TriggerOutSelectFrontGPO1Enum();
			}
			return m_TriggerOutSelectFrontGPO1Cached;
		}
	}

	public static TriggerOutSelectFrontGPO0Enum TriggerOutSelectFrontGPO0
	{
		get
		{
			if (m_TriggerOutSelectFrontGPO0Cached == null)
			{
				m_TriggerOutSelectFrontGPO0Cached = new TriggerOutSelectFrontGPO0Enum();
			}
			return m_TriggerOutSelectFrontGPO0Cached;
		}
	}

	public static IntegerName TriggerMultiplyPulses => new IntegerName("@DeviceTransportLayer/TriggerMultiplyPulses");

	public static TriggerInStatisticsSourceEnum TriggerInStatisticsSource
	{
		get
		{
			if (m_TriggerInStatisticsSourceCached == null)
			{
				m_TriggerInStatisticsSourceCached = new TriggerInStatisticsSourceEnum();
			}
			return m_TriggerInStatisticsSourceCached;
		}
	}

	public static CommandName TriggerInStatisticsPulseCountClear => new CommandName("@DeviceTransportLayer/TriggerInStatisticsPulseCountClear");

	public static IntegerName TriggerInStatisticsPulseCount => new IntegerName("@DeviceTransportLayer/TriggerInStatisticsPulseCount");

	public static TriggerInStatisticsPolarityEnum TriggerInStatisticsPolarity
	{
		get
		{
			if (m_TriggerInStatisticsPolarityCached == null)
			{
				m_TriggerInStatisticsPolarityCached = new TriggerInStatisticsPolarityEnum();
			}
			return m_TriggerInStatisticsPolarityCached;
		}
	}

	public static FloatName TriggerInStatisticsMinimumFrequency => new FloatName("@DeviceTransportLayer/TriggerInStatisticsMinimumFrequency");

	public static CommandName TriggerInStatisticsMinMaxFrequencyClear => new CommandName("@DeviceTransportLayer/TriggerInStatisticsMinMaxFrequencyClear");

	public static FloatName TriggerInStatisticsMaximumFrequency => new FloatName("@DeviceTransportLayer/TriggerInStatisticsMaximumFrequency");

	public static FloatName TriggerInStatisticsFrequency => new FloatName("@DeviceTransportLayer/TriggerInStatisticsFrequency");

	public static TriggerInSourceEnum TriggerInSource
	{
		get
		{
			if (m_TriggerInSourceCached == null)
			{
				m_TriggerInSourceCached = new TriggerInSourceEnum();
			}
			return m_TriggerInSourceCached;
		}
	}

	public static TriggerInPolarityEnum TriggerInPolarity
	{
		get
		{
			if (m_TriggerInPolarityCached == null)
			{
				m_TriggerInPolarityCached = new TriggerInPolarityEnum();
			}
			return m_TriggerInPolarityCached;
		}
	}

	public static IntegerName TriggerInDownscalePhase => new IntegerName("@DeviceTransportLayer/TriggerInDownscalePhase");

	public static IntegerName TriggerInDownscale => new IntegerName("@DeviceTransportLayer/TriggerInDownscale");

	public static FloatName TriggerInDebounce => new FloatName("@DeviceTransportLayer/TriggerInDebounce");

	public static CommandName TriggerExceededPeriodLimitsClear => new CommandName("@DeviceTransportLayer/TriggerExceededPeriodLimitsClear");

	public static TriggerExceededPeriodLimitsEnum TriggerExceededPeriodLimits
	{
		get
		{
			if (m_TriggerExceededPeriodLimitsCached == null)
			{
				m_TriggerExceededPeriodLimitsCached = new TriggerExceededPeriodLimitsEnum();
			}
			return m_TriggerExceededPeriodLimitsCached;
		}
	}

	public static IntegerName TriggerEventCount => new IntegerName("@DeviceTransportLayer/TriggerEventCount");

	public static TriggerCameraOutSelectEnum TriggerCameraOutSelect
	{
		get
		{
			if (m_TriggerCameraOutSelectCached == null)
			{
				m_TriggerCameraOutSelectCached = new TriggerCameraOutSelectEnum();
			}
			return m_TriggerCameraOutSelectCached;
		}
	}

	public static IntegerName TriggerAcknowledgementCount => new IntegerName("@DeviceTransportLayer/TriggerAcknowledgementCount");

	public static IntegerName SystemmonitorUsedCxpConnections => new IntegerName("@DeviceTransportLayer/SystemmonitorUsedCxpConnections");

	public static SystemmonitorPowerOverCxpStateEnum SystemmonitorPowerOverCxpState
	{
		get
		{
			if (m_SystemmonitorPowerOverCxpStateCached == null)
			{
				m_SystemmonitorPowerOverCxpStateCached = new SystemmonitorPowerOverCxpStateEnum();
			}
			return m_SystemmonitorPowerOverCxpStateCached;
		}
	}

	public static FloatName SystemmonitorPortBitRate => new FloatName("@DeviceTransportLayer/SystemmonitorPortBitRate");

	public static IntegerName SystemmonitorPcieTrainedRequestSize => new IntegerName("@DeviceTransportLayer/SystemmonitorPcieTrainedRequestSize");

	public static IntegerName SystemmonitorPcieTrainedPayloadSize => new IntegerName("@DeviceTransportLayer/SystemmonitorPcieTrainedPayloadSize");

	public static IntegerName SystemmonitorPacketbufferOverflowSource => new IntegerName("@DeviceTransportLayer/SystemmonitorPacketbufferOverflowSource");

	public static IntegerName SystemmonitorPacketbufferOverflowCount => new IntegerName("@DeviceTransportLayer/SystemmonitorPacketbufferOverflowCount");

	public static IntegerName SystemmonitorNotInTable8b10bError => new IntegerName("@DeviceTransportLayer/SystemmonitorNotInTable8b10bError");

	public static FloatName SystemmonitorFpgaVccInt => new FloatName("@DeviceTransportLayer/SystemmonitorFpgaVccInt");

	public static FloatName SystemmonitorFpgaVccBram => new FloatName("@DeviceTransportLayer/SystemmonitorFpgaVccBram");

	public static FloatName SystemmonitorFpgaVccAux => new FloatName("@DeviceTransportLayer/SystemmonitorFpgaVccAux");

	public static FloatName SystemmonitorFpgaTemperature => new FloatName("@DeviceTransportLayer/SystemmonitorFpgaTemperature");

	public static SystemmonitorExternalPowerEnum SystemmonitorExternalPower
	{
		get
		{
			if (m_SystemmonitorExternalPowerCached == null)
			{
				m_SystemmonitorExternalPowerCached = new SystemmonitorExternalPowerEnum();
			}
			return m_SystemmonitorExternalPowerCached;
		}
	}

	public static IntegerName SystemmonitorDisparity8b10bError => new IntegerName("@DeviceTransportLayer/SystemmonitorDisparity8b10bError");

	public static IntegerName SystemmonitorCxpImageLineMode => new IntegerName("@DeviceTransportLayer/SystemmonitorCxpImageLineMode");

	public static FloatName SystemmonitorCurrentLinkSpeed => new FloatName("@DeviceTransportLayer/SystemmonitorCurrentLinkSpeed");

	public static IntegerName SystemmonitorChannelVoltageSelector => new IntegerName("@DeviceTransportLayer/SystemmonitorChannelVoltageSelector");

	public static FloatName SystemmonitorChannelVoltage => new FloatName("@DeviceTransportLayer/SystemmonitorChannelVoltage");

	public static IntegerName SystemmonitorChannelCurrentSelector => new IntegerName("@DeviceTransportLayer/SystemmonitorChannelCurrentSelector");

	public static FloatName SystemmonitorChannelCurrent => new FloatName("@DeviceTransportLayer/SystemmonitorChannelCurrent");

	public static SystemmonitorByteAlignment8b10bLockedEnum SystemmonitorByteAlignment8b10bLocked
	{
		get
		{
			if (m_SystemmonitorByteAlignment8b10bLockedCached == null)
			{
				m_SystemmonitorByteAlignment8b10bLockedCached = new SystemmonitorByteAlignment8b10bLockedEnum();
			}
			return m_SystemmonitorByteAlignment8b10bLockedCached;
		}
	}

	public static IntegerName StreamSelector => new IntegerName("@DeviceTransportLayer/StreamSelector");

	public static StringName StreamID => new StringName("@DeviceTransportLayer/StreamID");

	public static StringName StreamDisplayName => new StringName("@DeviceTransportLayer/StreamDisplayName");

	public static IntegerName Statistic_Write_Pipe_Reset_Count => new IntegerName("@DeviceTransportLayer/Statistic_Write_Pipe_Reset_Count");

	public static IntegerName Statistic_Write_Operations_Failed_Count => new IntegerName("@DeviceTransportLayer/Statistic_Write_Operations_Failed_Count");

	public static IntegerName Statistic_Read_Pipe_Reset_Count => new IntegerName("@DeviceTransportLayer/Statistic_Read_Pipe_Reset_Count");

	public static IntegerName Statistic_Read_Operations_Failed_Count => new IntegerName("@DeviceTransportLayer/Statistic_Read_Operations_Failed_Count");

	public static StringName Statistic_Last_Error_Status_Text => new StringName("@DeviceTransportLayer/Statistic_Last_Error_Status_Text");

	public static IntegerName Statistic_Last_Error_Status => new IntegerName("@DeviceTransportLayer/Statistic_Last_Error_Status");

	public static IntegerName StatisticReadWriteTimeoutCount => new IntegerName("@DeviceTransportLayer/StatisticReadWriteTimeoutCount");

	public static IntegerName SoftwareTriggerQueueFillLevel => new IntegerName("@DeviceTransportLayer/SoftwareTriggerQueueFillLevel");

	public static SoftwareTriggerIsBusyEnum SoftwareTriggerIsBusy
	{
		get
		{
			if (m_SoftwareTriggerIsBusyCached == null)
			{
				m_SoftwareTriggerIsBusyCached = new SoftwareTriggerIsBusyEnum();
			}
			return m_SoftwareTriggerIsBusyCached;
		}
	}

	public static IntegerName SensorWidth => new IntegerName("@DeviceTransportLayer/SensorWidth");

	public static IntegerName SensorHeight => new IntegerName("@DeviceTransportLayer/SensorHeight");

	public static CommandName SendSoftwareTrigger => new CommandName("@DeviceTransportLayer/SendSoftwareTrigger");

	public static FloatName ScalingFactorRed => new FloatName("@DeviceTransportLayer/ScalingFactorRed");

	public static FloatName ScalingFactorGreen => new FloatName("@DeviceTransportLayer/ScalingFactorGreen");

	public static FloatName ScalingFactorBlue => new FloatName("@DeviceTransportLayer/ScalingFactorBlue");

	public static IntegerName ReadTimeout => new IntegerName("@DeviceTransportLayer/ReadTimeout");

	public static FloatName ProcessingOffset => new FloatName("@DeviceTransportLayer/ProcessingOffset");

	public static ProcessingInvertEnum ProcessingInvert
	{
		get
		{
			if (m_ProcessingInvertCached == null)
			{
				m_ProcessingInvertCached = new ProcessingInvertEnum();
			}
			return m_ProcessingInvertCached;
		}
	}

	public static FloatName ProcessingGamma => new FloatName("@DeviceTransportLayer/ProcessingGamma");

	public static FloatName ProcessingGain => new FloatName("@DeviceTransportLayer/ProcessingGain");

	public static PixelFormatEnum PixelFormat
	{
		get
		{
			if (m_PixelFormatCached == null)
			{
				m_PixelFormatCached = new PixelFormatEnum();
			}
			return m_PixelFormatCached;
		}
	}

	public static IntegerName PixelDepth => new IntegerName("@DeviceTransportLayer/PixelDepth");

	public static IntegerName PacketTagErrorCount => new IntegerName("@DeviceTransportLayer/PacketTagErrorCount");

	public static FloatName OverflowSyncOnThreshold => new FloatName("@DeviceTransportLayer/OverflowSyncOnThreshold");

	public static FloatName OverflowOnThreshold => new FloatName("@DeviceTransportLayer/OverflowOnThreshold");

	public static FloatName OverflowOffThreshold => new FloatName("@DeviceTransportLayer/OverflowOffThreshold");

	public static OverflowEventSelectEnum OverflowEventSelect
	{
		get
		{
			if (m_OverflowEventSelectCached == null)
			{
				m_OverflowEventSelectCached = new OverflowEventSelectEnum();
			}
			return m_OverflowEventSelectCached;
		}
	}

	public static IntegerName Overflow => new IntegerName("@DeviceTransportLayer/Overflow");

	public static BooleanName OutputPackedFormats => new BooleanName("@DeviceTransportLayer/OutputPackedFormats");

	public static IntegerName OffsetY => new IntegerName("@DeviceTransportLayer/OffsetY");

	public static IntegerName OffsetX => new IntegerName("@DeviceTransportLayer/OffsetX");

	public static CommandName MissingCameraFrameResponseClear => new CommandName("@DeviceTransportLayer/MissingCameraFrameResponseClear");

	public static MissingCameraFrameResponseEnum MissingCameraFrameResponse
	{
		get
		{
			if (m_MissingCameraFrameResponseCached == null)
			{
				m_MissingCameraFrameResponseCached = new MissingCameraFrameResponseEnum();
			}
			return m_MissingCameraFrameResponseCached;
		}
	}

	public static BooleanName MigrationModeEnable => new BooleanName("@DeviceTransportLayer/MigrationModeEnable");

	public static IntegerName MaxRetryCountWrite => new IntegerName("@DeviceTransportLayer/MaxRetryCountWrite");

	public static IntegerName MaxRetryCountRead => new IntegerName("@DeviceTransportLayer/MaxRetryCountRead");

	public static IntegerName LutValueSelector => new IntegerName("@DeviceTransportLayer/LutValueSelector");

	public static IntegerName LutValueRedSelector => new IntegerName("@DeviceTransportLayer/LutValueRedSelector");

	public static IntegerName LutValueRed => new IntegerName("@DeviceTransportLayer/LutValueRed");

	public static IntegerName LutValueGreenSelector => new IntegerName("@DeviceTransportLayer/LutValueGreenSelector");

	public static IntegerName LutValueGreen => new IntegerName("@DeviceTransportLayer/LutValueGreen");

	public static IntegerName LutValueBlueSelector => new IntegerName("@DeviceTransportLayer/LutValueBlueSelector");

	public static IntegerName LutValueBlue => new IntegerName("@DeviceTransportLayer/LutValueBlue");

	public static IntegerName LutValue => new IntegerName("@DeviceTransportLayer/LutValue");

	public static LutTypeEnum LutType
	{
		get
		{
			if (m_LutTypeCached == null)
			{
				m_LutTypeCached = new LutTypeEnum();
			}
			return m_LutTypeCached;
		}
	}

	public static StringName LutSaveFile => new StringName("@DeviceTransportLayer/LutSaveFile");

	public static IntegerName LutOutputPixelBitDepth => new IntegerName("@DeviceTransportLayer/LutOutputPixelBitDepth");

	public static IntegerName LutInputPixelBitDepth => new IntegerName("@DeviceTransportLayer/LutInputPixelBitDepth");

	public static LutImplementationTypeEnum LutImplementationType
	{
		get
		{
			if (m_LutImplementationTypeCached == null)
			{
				m_LutImplementationTypeCached = new LutImplementationTypeEnum();
			}
			return m_LutImplementationTypeCached;
		}
	}

	public static LutEnableEnum LutEnable
	{
		get
		{
			if (m_LutEnableCached == null)
			{
				m_LutEnableCached = new LutEnableEnum();
			}
			return m_LutEnableCached;
		}
	}

	public static StringName LutCustomFile => new StringName("@DeviceTransportLayer/LutCustomFile");

	public static FloatName LinkCommandTimeout => new FloatName("@DeviceTransportLayer/LinkCommandTimeout");

	public static IntegerName LinkCommandRetryCount => new IntegerName("@DeviceTransportLayer/LinkCommandRetryCount");

	public static IntegerName ImageSelectPeriod => new IntegerName("@DeviceTransportLayer/ImageSelectPeriod");

	public static IntegerName ImageSelect => new IntegerName("@DeviceTransportLayer/ImageSelect");

	public static IntegerName Height => new IntegerName("@DeviceTransportLayer/Height");

	public static IntegerName HeartbeatTimeout => new IntegerName("@DeviceTransportLayer/HeartbeatTimeout");

	public static IntegerName GevDeviceSubnetMask => new IntegerName("@DeviceTransportLayer/GevDeviceSubnetMask");

	public static IntegerName GevDeviceMACAddress => new IntegerName("@DeviceTransportLayer/GevDeviceMACAddress");

	public static IntegerName GevDeviceIPAddress => new IntegerName("@DeviceTransportLayer/GevDeviceIPAddress");

	public static IntegerName GevDeviceGateway => new IntegerName("@DeviceTransportLayer/GevDeviceGateway");

	public static StringName GentlInfoVersion => new StringName("@DeviceTransportLayer/GentlInfoVersion");

	public static StringName GentlInfoIgnorefgformat => new StringName("@DeviceTransportLayer/GentlInfoIgnorefgformat");

	public static IntegerName GPI => new IntegerName("@DeviceTransportLayer/GPI");

	public static IntegerName FrontGPI => new IntegerName("@DeviceTransportLayer/FrontGPI");

	public static FormatEnum Format
	{
		get
		{
			if (m_FormatCached == null)
			{
				m_FormatCached = new FormatEnum();
			}
			return m_FormatCached;
		}
	}

	public static IntegerName FillLevel => new IntegerName("@DeviceTransportLayer/FillLevel");

	public static IntegerName EventTriggerQueueFilllevelThresholdOnTimestamp => new IntegerName("@DeviceTransportLayer/EventTriggerQueueFilllevelThresholdOnTimestamp");

	public static IntegerName EventTriggerQueueFilllevelThresholdOnSoftCounter => new IntegerName("@DeviceTransportLayer/EventTriggerQueueFilllevelThresholdOnSoftCounter");

	public static IntegerName EventTriggerQueueFilllevelThresholdOn => new IntegerName("@DeviceTransportLayer/EventTriggerQueueFilllevelThresholdOn");

	public static IntegerName EventTriggerQueueFilllevelThresholdOffTimestamp => new IntegerName("@DeviceTransportLayer/EventTriggerQueueFilllevelThresholdOffTimestamp");

	public static IntegerName EventTriggerQueueFilllevelThresholdOffSoftCounter => new IntegerName("@DeviceTransportLayer/EventTriggerQueueFilllevelThresholdOffSoftCounter");

	public static IntegerName EventTriggerQueueFilllevelThresholdOff => new IntegerName("@DeviceTransportLayer/EventTriggerQueueFilllevelThresholdOff");

	public static IntegerName EventTriggerExceededPeriodLimitsTimestamp => new IntegerName("@DeviceTransportLayer/EventTriggerExceededPeriodLimitsTimestamp");

	public static IntegerName EventTriggerExceededPeriodLimitsSoftCounter => new IntegerName("@DeviceTransportLayer/EventTriggerExceededPeriodLimitsSoftCounter");

	public static IntegerName EventTriggerExceededPeriodLimits => new IntegerName("@DeviceTransportLayer/EventTriggerExceededPeriodLimits");

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

	public static IntegerName EventOverflowTimestamp => new IntegerName("@DeviceTransportLayer/EventOverflowTimestamp");

	public static IntegerName EventOverflowSoftCounter => new IntegerName("@DeviceTransportLayer/EventOverflowSoftCounter");

	public static BooleanName EventOverflowIsTruncated => new BooleanName("@DeviceTransportLayer/EventOverflowIsTruncated");

	public static BooleanName EventOverflowIsLost => new BooleanName("@DeviceTransportLayer/EventOverflowIsLost");

	public static BooleanName EventOverflowIsComplete => new BooleanName("@DeviceTransportLayer/EventOverflowIsComplete");

	public static IntegerName EventOverflowFrameId => new IntegerName("@DeviceTransportLayer/EventOverflowFrameId");

	public static IntegerName EventOverflow => new IntegerName("@DeviceTransportLayer/EventOverflow");

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

	public static IntegerName EventFrameTriggerMissedTimestamp => new IntegerName("@DeviceTransportLayer/EventFrameTriggerMissedTimestamp");

	public static IntegerName EventFrameTriggerMissedSoftCounter => new IntegerName("@DeviceTransportLayer/EventFrameTriggerMissedSoftCounter");

	public static IntegerName EventFrameTriggerMissed => new IntegerName("@DeviceTransportLayer/EventFrameTriggerMissed");

	public static IntegerName EventFrameTransferStartTimestamp => new IntegerName("@DeviceTransportLayer/EventFrameTransferStartTimestamp");

	public static IntegerName EventFrameTransferStartSoftCounter => new IntegerName("@DeviceTransportLayer/EventFrameTransferStartSoftCounter");

	public static IntegerName EventFrameTransferStart => new IntegerName("@DeviceTransportLayer/EventFrameTransferStart");

	public static IntegerName EventFrameTransferEndTimestamp => new IntegerName("@DeviceTransportLayer/EventFrameTransferEndTimestamp");

	public static IntegerName EventFrameTransferEndSoftCounter => new IntegerName("@DeviceTransportLayer/EventFrameTransferEndSoftCounter");

	public static IntegerName EventFrameTransferEnd => new IntegerName("@DeviceTransportLayer/EventFrameTransferEnd");

	public static IntegerName EventDeviceLostSoftCounter => new IntegerName("@DeviceTransportLayer/EventDeviceLostSoftCounter");

	public static IntegerName EventDeviceLost => new IntegerName("@DeviceTransportLayer/EventDeviceLost");

	public static IntegerName EventAcquisitionTriggerTimestamp => new IntegerName("@DeviceTransportLayer/EventAcquisitionTriggerTimestamp");

	public static IntegerName EventAcquisitionTriggerSoftCounter => new IntegerName("@DeviceTransportLayer/EventAcquisitionTriggerSoftCounter");

	public static IntegerName EventAcquisitionTrigger => new IntegerName("@DeviceTransportLayer/EventAcquisitionTrigger");

	public static StringName DeviceVendorName => new StringName("@DeviceTransportLayer/DeviceVendorName");

	public static DeviceTypeEnum DeviceType
	{
		get
		{
			if (m_DeviceTypeCached == null)
			{
				m_DeviceTypeCached = new DeviceTypeEnum();
			}
			return m_DeviceTypeCached;
		}
	}

	public static StringName DeviceSerialNumber => new StringName("@DeviceTransportLayer/DeviceSerialNumber");

	public static StringName DeviceModelName => new StringName("@DeviceTransportLayer/DeviceModelName");

	public static StringName DeviceManufacturerInfo => new StringName("@DeviceTransportLayer/DeviceManufacturerInfo");

	public static StringName DeviceID => new StringName("@DeviceTransportLayer/DeviceID");

	public static DeviceEndianessMechanismEnum DeviceEndianessMechanism
	{
		get
		{
			if (m_DeviceEndianessMechanismCached == null)
			{
				m_DeviceEndianessMechanismCached = new DeviceEndianessMechanismEnum();
			}
			return m_DeviceEndianessMechanismCached;
		}
	}

	public static StringName DeviceDisplayName => new StringName("@DeviceTransportLayer/DeviceDisplayName");

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

	public static CxpTriggerPacketModeEnum CxpTriggerPacketMode
	{
		get
		{
			if (m_CxpTriggerPacketModeCached == null)
			{
				m_CxpTriggerPacketModeCached = new CxpTriggerPacketModeEnum();
			}
			return m_CxpTriggerPacketModeCached;
		}
	}

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

	public static IntegerName CustomBitShiftRight => new IntegerName("@DeviceTransportLayer/CustomBitShiftRight");

	public static IntegerName CorrectedErrorCount => new IntegerName("@DeviceTransportLayer/CorrectedErrorCount");

	public static BooleanName ConnectionGuardEnable => new BooleanName("@DeviceTransportLayer/ConnectionGuardEnable");

	public static BooleanName CommandDuplicationEnable => new BooleanName("@DeviceTransportLayer/CommandDuplicationEnable");

	public static BitAlignmentEnum BitAlignment
	{
		get
		{
			if (m_BitAlignmentCached == null)
			{
				m_BitAlignmentCached = new BitAlignmentEnum();
			}
			return m_BitAlignmentCached;
		}
	}

	public static BooleanName AutomaticROIControl => new BooleanName("@DeviceTransportLayer/AutomaticROIControl");

	public static BooleanName AutomaticFormatControl => new BooleanName("@DeviceTransportLayer/AutomaticFormatControl");

	public static AreaTriggerModeEnum AreaTriggerMode
	{
		get
		{
			if (m_AreaTriggerModeCached == null)
			{
				m_AreaTriggerModeCached = new AreaTriggerModeEnum();
			}
			return m_AreaTriggerModeCached;
		}
	}
}
