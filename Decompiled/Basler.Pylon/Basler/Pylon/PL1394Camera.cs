using System.ComponentModel;

namespace Basler.Pylon;

public static class PL1394Camera
{
	[EditorBrowsable(EditorBrowsableState.Never)]
	public class GainAutoEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/GainAuto";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class GainSelectorEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/GainSelector";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class BlackLevelSelectorEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/BlackLevelSelector";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class GammaSelectorEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/GammaSelector";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class PixelFormatEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/PixelFormat";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class PixelSizeEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/PixelSize";

		public string Bpp16 => "Bpp16";

		public string Bpp12 => "Bpp12";

		public string Bpp10 => "Bpp10";

		public string Bpp8 => "Bpp8";

		public string Bpp4 => "Bpp4";

		public string Bpp2 => "Bpp2";

		public string Bpp1 => "Bpp1";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class PixelColorFilterEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/PixelColorFilter";

		public string None => "None";

		public string Bayer_BG => "Bayer_BG";

		public string Bayer_GR => "Bayer_GR";

		public string Bayer_GB => "Bayer_GB";

		public string Bayer_RG => "Bayer_RG";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class TestImageSelectorEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/TestImageSelector";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class LightSourceSelectorEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/LightSourceSelector";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class BalanceWhiteAutoEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/BalanceWhiteAuto";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class BalanceRatioSelectorEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/BalanceRatioSelector";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class ColorTransformationSelectorEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/ColorTransformationSelector";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class ColorTransformationValueSelectorEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/ColorTransformationValueSelector";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class ColorAdjustmentSelectorEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/ColorAdjustmentSelector";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class LegacyBinningVerticalEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/LegacyBinningVertical";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class AcquisitionModeEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/AcquisitionMode";

		public string Continuous => "Continuous";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class TriggerControlImplementationEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/TriggerControlImplementation";

		public string Standard => "Standard";

		public string Legacy => "Legacy";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class TriggerSelectorEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/TriggerSelector";

		public string AcquisitionStart => "AcquisitionStart";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class TriggerModeEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/TriggerMode";

		public string On => "On";

		public string Off => "Off";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class TriggerSourceEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/TriggerSource";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class TriggerActivationEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/TriggerActivation";

		public string FallingEdge => "FallingEdge";

		public string RisingEdge => "RisingEdge";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class ExposureModeEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/ExposureMode";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class ExposureAutoEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/ExposureAuto";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class AcquisitionStatusSelectorEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/AcquisitionStatusSelector";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class LineSelectorEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/LineSelector";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class LineModeEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/LineMode";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class LineLogicEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/LineLogic";

		public string Negative => "Negative";

		public string Positive => "Positive";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class LineFormatEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/LineFormat";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class LineSourceEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/LineSource";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class UserOutputSelectorEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/UserOutputSelector";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class TimerSelectorEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/TimerSelector";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class TimerTriggerSourceEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/TimerTriggerSource";

		public string ExposureStart => "ExposureStart";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class TimerTriggerActivationEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/TimerTriggerActivation";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class CounterSelectorEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/CounterSelector";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class CounterEventSourceEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/CounterEventSource";

		public string FrameTrigger => "FrameTrigger";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class CounterResetSourceEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/CounterResetSource";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class TimerSequenceEntrySelectorEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/TimerSequenceEntrySelector";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class TimerSequenceTimerSelectorEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/TimerSequenceTimerSelector";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class LUTSelectorEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/LUTSelector";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class UserSetSelectorEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/UserSetSelector";

		public string Default => "Default";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class UserSetDefaultSelectorEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/UserSetDefaultSelector";

		public string Default => "Default";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class DefaultSetSelectorEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/DefaultSetSelector";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class AutoFunctionProfileEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/AutoFunctionProfile";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class AutoFunctionAOISelectorEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/AutoFunctionAOISelector";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class UserDefinedValueSelectorEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/UserDefinedValueSelector";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class DeviceScanTypeEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/DeviceScanType";

		public string Linescan => "Linescan";

		public string Areascan => "Areascan";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class TemperatureSelectorEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/TemperatureSelector";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class ParameterSelectorEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/ParameterSelector";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class ExpertFeatureAccessSelectorEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/ExpertFeatureAccessSelector";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class ChunkSelectorEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/ChunkSelector";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class ChunkPixelFormatEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/ChunkPixelFormat";

		public string RGB12V1Packed => "RGB12V1Packed";

		public string BayerBG12Packed => "BayerBG12Packed";

		public string BayerRG12Packed => "BayerRG12Packed";

		public string BayerGR12Packed => "BayerGR12Packed";

		public string BayerGB12Packed => "BayerGB12Packed";

		public string YUV422_YUYV_Packed => "YUV422_YUYV_Packed";

		public string RGB16Planar => "RGB16Planar";

		public string RGB12Planar => "RGB12Planar";

		public string RGB10Planar => "RGB10Planar";

		public string RGB8Planar => "RGB8Planar";

		public string YUV444Packed => "YUV444Packed";

		public string YUV422Packed => "YUV422Packed";

		public string YUV411Packed => "YUV411Packed";

		public string RGB10V2Packed => "RGB10V2Packed";

		public string RGB10V1Packed => "RGB10V1Packed";

		public string BGR12Packed => "BGR12Packed";

		public string RGB12Packed => "RGB12Packed";

		public string BGR10Packed => "BGR10Packed";

		public string RGB10Packed => "RGB10Packed";

		public string BGRA8Packed => "BGRA8Packed";

		public string RGBA8Packed => "RGBA8Packed";

		public string BGR8Packed => "BGR8Packed";

		public string RGB8Packed => "RGB8Packed";

		public string BayerBG16 => "BayerBG16";

		public string BayerGB16 => "BayerGB16";

		public string BayerRG16 => "BayerRG16";

		public string BayerGR16 => "BayerGR16";

		public string BayerBG12 => "BayerBG12";

		public string BayerGB12 => "BayerGB12";

		public string BayerRG12 => "BayerRG12";

		public string BayerGR12 => "BayerGR12";

		public string BayerBG10 => "BayerBG10";

		public string BayerGB10 => "BayerGB10";

		public string BayerRG10 => "BayerRG10";

		public string BayerGR10 => "BayerGR10";

		public string BayerBG8 => "BayerBG8";

		public string BayerGB8 => "BayerGB8";

		public string BayerRG8 => "BayerRG8";

		public string BayerGR8 => "BayerGR8";

		public string Mono16 => "Mono16";

		public string Mono12Packed => "Mono12Packed";

		public string Mono12 => "Mono12";

		public string Mono10Packed => "Mono10Packed";

		public string Mono10 => "Mono10";

		public string Mono8Signed => "Mono8Signed";

		public string Mono8 => "Mono8";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class EventSelectorEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/EventSelector";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class EventNotificationEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/EventNotification";

		public string On => "On";

		public string GenICamEvent => "GenICamEvent";

		public string Off => "Off";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class FileSelectorEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/FileSelector";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class FileOperationSelectorEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/FileOperationSelector";

		public string Open => "Open";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class FileOpenModeEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/FileOpenMode";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class FileOperationStatusEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/FileOperationStatus";

		public string Failure => "Failure";

		public string Success => "Success";

		public override string ToString()
		{
			return Name;
		}
	}

	public static CommandName FileOperationExecute => (CommandName)"@CameraDevice/FileOperationExecute";

	public static IntegerName FileSize => (IntegerName)"@CameraDevice/FileSize";

	public static IntegerName FileOperationResult => (IntegerName)"@CameraDevice/FileOperationResult";

	public static FileOperationStatusEnum FileOperationStatus => new FileOperationStatusEnum();

	public static IntegerName FileAccessLength => (IntegerName)"@CameraDevice/FileAccessLength";

	public static IntegerName FileAccessOffset => (IntegerName)"@CameraDevice/FileAccessOffset";

	public static FileOpenModeEnum FileOpenMode => new FileOpenModeEnum();

	public static FileOperationSelectorEnum FileOperationSelector => new FileOperationSelectorEnum();

	public static FileSelectorEnum FileSelector => new FileSelectorEnum();

	public static IntegerName EventOverrunEventTimestamp => (IntegerName)"@CameraDevice/EventOverrunEventTimestamp";

	public static IntegerName EventOverrunEventFrameID => (IntegerName)"@CameraDevice/EventOverrunEventFrameID";

	public static IntegerName EventOverrunEventStreamChannelIndex => (IntegerName)"@CameraDevice/EventOverrunEventStreamChannelIndex";

	public static IntegerName FrameTimeoutEventTimestamp => (IntegerName)"@CameraDevice/FrameTimeoutEventTimestamp";

	public static IntegerName FrameTimeoutEventStreamChannelIndex => (IntegerName)"@CameraDevice/FrameTimeoutEventStreamChannelIndex";

	public static IntegerName AcquisitionStartOvertriggerEventTimestamp => (IntegerName)"@CameraDevice/AcquisitionStartOvertriggerEventTimestamp";

	public static IntegerName AcquisitionStartOvertriggerEventStreamChannelIndex => (IntegerName)"@CameraDevice/AcquisitionStartOvertriggerEventStreamChannelIndex";

	public static IntegerName FrameStartOvertriggerEventTimestamp => (IntegerName)"@CameraDevice/FrameStartOvertriggerEventTimestamp";

	public static IntegerName FrameStartOvertriggerEventStreamChannelIndex => (IntegerName)"@CameraDevice/FrameStartOvertriggerEventStreamChannelIndex";

	public static IntegerName LineStartOvertriggerEventTimestamp => (IntegerName)"@CameraDevice/LineStartOvertriggerEventTimestamp";

	public static IntegerName LineStartOvertriggerEventStreamChannelIndex => (IntegerName)"@CameraDevice/LineStartOvertriggerEventStreamChannelIndex";

	public static IntegerName ExposureEndEventTimestamp => (IntegerName)"@CameraDevice/ExposureEndEventTimestamp";

	public static IntegerName ExposureEndEventFrameID => (IntegerName)"@CameraDevice/ExposureEndEventFrameID";

	public static IntegerName ExposureEndEventStreamChannelIndex => (IntegerName)"@CameraDevice/ExposureEndEventStreamChannelIndex";

	public static EventNotificationEnum EventNotification => new EventNotificationEnum();

	public static EventSelectorEnum EventSelector => new EventSelectorEnum();

	public static FloatName ChunkExposureTime => (FloatName)"@CameraDevice/ChunkExposureTime";

	public static IntegerName ChunkTriggerinputcounter => (IntegerName)"@CameraDevice/ChunkTriggerinputcounter";

	public static IntegerName ChunkLineStatusAll => (IntegerName)"@CameraDevice/ChunkLineStatusAll";

	public static IntegerName ChunkFramecounter => (IntegerName)"@CameraDevice/ChunkFramecounter";

	public static IntegerName ChunkTimestamp => (IntegerName)"@CameraDevice/ChunkTimestamp";

	public static ChunkPixelFormatEnum ChunkPixelFormat => new ChunkPixelFormatEnum();

	public static IntegerName ChunkDynamicRangeMax => (IntegerName)"@CameraDevice/ChunkDynamicRangeMax";

	public static IntegerName ChunkDynamicRangeMin => (IntegerName)"@CameraDevice/ChunkDynamicRangeMin";

	public static IntegerName ChunkHeight => (IntegerName)"@CameraDevice/ChunkHeight";

	public static IntegerName ChunkWidth => (IntegerName)"@CameraDevice/ChunkWidth";

	public static IntegerName ChunkOffsetY => (IntegerName)"@CameraDevice/ChunkOffsetY";

	public static IntegerName ChunkOffsetX => (IntegerName)"@CameraDevice/ChunkOffsetX";

	public static IntegerName ChunkStride => (IntegerName)"@CameraDevice/ChunkStride";

	public static BooleanName ChunkEnable => (BooleanName)"@CameraDevice/ChunkEnable";

	public static ChunkSelectorEnum ChunkSelector => new ChunkSelectorEnum();

	public static BooleanName ChunkModeActive => (BooleanName)"@CameraDevice/ChunkModeActive";

	public static BooleanName ExpertFeatureEnable => (BooleanName)"@CameraDevice/ExpertFeatureEnable";

	public static IntegerName ExpertFeatureAccessKey => (IntegerName)"@CameraDevice/ExpertFeatureAccessKey";

	public static ExpertFeatureAccessSelectorEnum ExpertFeatureAccessSelector => new ExpertFeatureAccessSelectorEnum();

	public static BooleanName RemoveLimits => (BooleanName)"@CameraDevice/RemoveLimits";

	public static ParameterSelectorEnum ParameterSelector => new ParameterSelectorEnum();

	public static FloatName TemperatureAbs => (FloatName)"@CameraDevice/TemperatureAbs";

	public static TemperatureSelectorEnum TemperatureSelector => new TemperatureSelectorEnum();

	public static CommandName DeviceReset => (CommandName)"@CameraDevice/DeviceReset";

	public static DeviceScanTypeEnum DeviceScanType => new DeviceScanTypeEnum();

	public static StringName DeviceUserID => (StringName)"@CameraDevice/DeviceUserID";

	public static StringName DeviceFirmwareVersion => (StringName)"@CameraDevice/DeviceFirmwareVersion";

	public static IntegerName DeviceSerialNumber => (IntegerName)"@CameraDevice/DeviceSerialNumber";

	public static StringName DeviceModelName => (StringName)"@CameraDevice/DeviceModelName";

	public static StringName DeviceVendorName => (StringName)"@CameraDevice/DeviceVendorName";

	public static IntegerName UserDefinedValue => (IntegerName)"@CameraDevice/UserDefinedValue";

	public static UserDefinedValueSelectorEnum UserDefinedValueSelector => new UserDefinedValueSelectorEnum();

	public static BooleanName AutoFunctionAOIUsageRedLightCorrection => (BooleanName)"@CameraDevice/AutoFunctionAOIUsageRedLightCorrection";

	public static BooleanName AutoFunctionAOIUsageWhiteBalance => (BooleanName)"@CameraDevice/AutoFunctionAOIUsageWhiteBalance";

	public static BooleanName AutoFunctionAOIUsageIntensity => (BooleanName)"@CameraDevice/AutoFunctionAOIUsageIntensity";

	public static IntegerName AutoFunctionAOIOffsetY => (IntegerName)"@CameraDevice/AutoFunctionAOIOffsetY";

	public static IntegerName AutoFunctionAOIOffsetX => (IntegerName)"@CameraDevice/AutoFunctionAOIOffsetX";

	public static IntegerName AutoFunctionAOIHeight => (IntegerName)"@CameraDevice/AutoFunctionAOIHeight";

	public static IntegerName AutoFunctionAOIWidth => (IntegerName)"@CameraDevice/AutoFunctionAOIWidth";

	public static AutoFunctionAOISelectorEnum AutoFunctionAOISelector => new AutoFunctionAOISelectorEnum();

	public static AutoFunctionProfileEnum AutoFunctionProfile => new AutoFunctionProfileEnum();

	public static FloatName AutoExposureTimeAbsUpperLimit => (FloatName)"@CameraDevice/AutoExposureTimeAbsUpperLimit";

	public static FloatName AutoExposureTimeAbsLowerLimit => (FloatName)"@CameraDevice/AutoExposureTimeAbsLowerLimit";

	public static IntegerName AutoGainRawUpperLimit => (IntegerName)"@CameraDevice/AutoGainRawUpperLimit";

	public static IntegerName AutoGainRawLowerLimit => (IntegerName)"@CameraDevice/AutoGainRawLowerLimit";

	public static IntegerName GrayValueAdjustmentDampingRaw => (IntegerName)"@CameraDevice/GrayValueAdjustmentDampingRaw";

	public static FloatName GrayValueAdjustmentDampingAbs => (FloatName)"@CameraDevice/GrayValueAdjustmentDampingAbs";

	public static IntegerName AutoTargetValue => (IntegerName)"@CameraDevice/AutoTargetValue";

	public static DefaultSetSelectorEnum DefaultSetSelector => new DefaultSetSelectorEnum();

	public static UserSetDefaultSelectorEnum UserSetDefaultSelector => new UserSetDefaultSelectorEnum();

	public static CommandName UserSetSave => (CommandName)"@CameraDevice/UserSetSave";

	public static CommandName UserSetLoad => (CommandName)"@CameraDevice/UserSetLoad";

	public static UserSetSelectorEnum UserSetSelector => new UserSetSelectorEnum();

	public static IntegerName RecommendedPacketSize => (IntegerName)"@CameraDevice/RecommendedPacketSize";

	public static IntegerName PacketSize => (IntegerName)"@CameraDevice/PacketSize";

	public static IntegerName PayloadSize => (IntegerName)"@CameraDevice/PayloadSize";

	public static IntegerName LUTValue => (IntegerName)"@CameraDevice/LUTValue";

	public static IntegerName LUTIndex => (IntegerName)"@CameraDevice/LUTIndex";

	public static BooleanName LUTEnable => (BooleanName)"@CameraDevice/LUTEnable";

	public static LUTSelectorEnum LUTSelector => new LUTSelectorEnum();

	public static IntegerName TimerSequenceTimerDurationRaw => (IntegerName)"@CameraDevice/TimerSequenceTimerDurationRaw";

	public static IntegerName TimerSequenceTimerDelayRaw => (IntegerName)"@CameraDevice/TimerSequenceTimerDelayRaw";

	public static BooleanName TimerSequenceTimerInverter => (BooleanName)"@CameraDevice/TimerSequenceTimerInverter";

	public static BooleanName TimerSequenceTimerEnable => (BooleanName)"@CameraDevice/TimerSequenceTimerEnable";

	public static TimerSequenceTimerSelectorEnum TimerSequenceTimerSelector => new TimerSequenceTimerSelectorEnum();

	public static TimerSequenceEntrySelectorEnum TimerSequenceEntrySelector => new TimerSequenceEntrySelectorEnum();

	public static IntegerName TimerSequenceCurrentEntryIndex => (IntegerName)"@CameraDevice/TimerSequenceCurrentEntryIndex";

	public static IntegerName TimerSequenceLastEntryIndex => (IntegerName)"@CameraDevice/TimerSequenceLastEntryIndex";

	public static BooleanName TimerSequenceEnable => (BooleanName)"@CameraDevice/TimerSequenceEnable";

	public static CommandName CounterReset => (CommandName)"@CameraDevice/CounterReset";

	public static CounterResetSourceEnum CounterResetSource => new CounterResetSourceEnum();

	public static CounterEventSourceEnum CounterEventSource => new CounterEventSourceEnum();

	public static CounterSelectorEnum CounterSelector => new CounterSelectorEnum();

	public static TimerTriggerActivationEnum TimerTriggerActivation => new TimerTriggerActivationEnum();

	public static TimerTriggerSourceEnum TimerTriggerSource => new TimerTriggerSourceEnum();

	public static IntegerName TimerDurationRaw => (IntegerName)"@CameraDevice/TimerDurationRaw";

	public static FloatName TimerDurationAbs => (FloatName)"@CameraDevice/TimerDurationAbs";

	public static IntegerName TimerDelayRaw => (IntegerName)"@CameraDevice/TimerDelayRaw";

	public static FloatName TimerDelayAbs => (FloatName)"@CameraDevice/TimerDelayAbs";

	public static TimerSelectorEnum TimerSelector => new TimerSelectorEnum();

	public static FloatName TimerDurationTimebaseAbs => (FloatName)"@CameraDevice/TimerDurationTimebaseAbs";

	public static FloatName TimerDelayTimebaseAbs => (FloatName)"@CameraDevice/TimerDelayTimebaseAbs";

	public static IntegerName UserOutputValueAll => (IntegerName)"@CameraDevice/UserOutputValueAll";

	public static BooleanName UserOutputValue => (BooleanName)"@CameraDevice/UserOutputValue";

	public static UserOutputSelectorEnum UserOutputSelector => new UserOutputSelectorEnum();

	public static IntegerName LineStatusAll => (IntegerName)"@CameraDevice/LineStatusAll";

	public static BooleanName LineStatus => (BooleanName)"@CameraDevice/LineStatus";

	public static IntegerName LineDebouncerTimeRaw => (IntegerName)"@CameraDevice/LineDebouncerTimeRaw";

	public static FloatName LineDebouncerTimeAbs => (FloatName)"@CameraDevice/LineDebouncerTimeAbs";

	public static BooleanName LineTermination => (BooleanName)"@CameraDevice/LineTermination";

	public static BooleanName LineInverter => (BooleanName)"@CameraDevice/LineInverter";

	public static LineSourceEnum LineSource => new LineSourceEnum();

	public static LineFormatEnum LineFormat => new LineFormatEnum();

	public static LineLogicEnum LineLogic => new LineLogicEnum();

	public static LineModeEnum LineMode => new LineModeEnum();

	public static LineSelectorEnum LineSelector => new LineSelectorEnum();

	public static BooleanName AcquisitionStatus => (BooleanName)"@CameraDevice/AcquisitionStatus";

	public static AcquisitionStatusSelectorEnum AcquisitionStatusSelector => new AcquisitionStatusSelectorEnum();

	public static FloatName ResultingFrameRateAbs => (FloatName)"@CameraDevice/ResultingFrameRateAbs";

	public static FloatName AcquisitionFrameRateAbs => (FloatName)"@CameraDevice/AcquisitionFrameRateAbs";

	public static BooleanName AcquisitionFrameRateEnable => (BooleanName)"@CameraDevice/AcquisitionFrameRateEnable";

	public static FloatName ReadoutTimeAbs => (FloatName)"@CameraDevice/ReadoutTimeAbs";

	public static IntegerName ExposureTimeRaw => (IntegerName)"@CameraDevice/ExposureTimeRaw";

	public static BooleanName ExposureTimeBaseAbsEnable => (BooleanName)"@CameraDevice/ExposureTimeBaseAbsEnable";

	public static FloatName ExposureTimeBaseAbs => (FloatName)"@CameraDevice/ExposureTimeBaseAbs";

	public static FloatName ExposureTimeAbs => (FloatName)"@CameraDevice/ExposureTimeAbs";

	public static ExposureAutoEnum ExposureAuto => new ExposureAutoEnum();

	public static ExposureModeEnum ExposureMode => new ExposureModeEnum();

	public static FloatName TriggerDelayAbs => (FloatName)"@CameraDevice/TriggerDelayAbs";

	public static TriggerActivationEnum TriggerActivation => new TriggerActivationEnum();

	public static TriggerSourceEnum TriggerSource => new TriggerSourceEnum();

	public static CommandName TriggerSoftware => (CommandName)"@CameraDevice/TriggerSoftware";

	public static TriggerModeEnum TriggerMode => new TriggerModeEnum();

	public static TriggerSelectorEnum TriggerSelector => new TriggerSelectorEnum();

	public static TriggerControlImplementationEnum TriggerControlImplementation => new TriggerControlImplementationEnum();

	public static IntegerName AcquisitionFrameCount => (IntegerName)"@CameraDevice/AcquisitionFrameCount";

	public static CommandName AcquisitionStop => (CommandName)"@CameraDevice/AcquisitionStop";

	public static CommandName AcquisitionStart => (CommandName)"@CameraDevice/AcquisitionStart";

	public static AcquisitionModeEnum AcquisitionMode => new AcquisitionModeEnum();

	public static BooleanName EnableBurstAcquisition => (BooleanName)"@CameraDevice/EnableBurstAcquisition";

	public static IntegerName BinningVertical => (IntegerName)"@CameraDevice/BinningVertical";

	public static IntegerName BinningHorizontal => (IntegerName)"@CameraDevice/BinningHorizontal";

	public static LegacyBinningVerticalEnum LegacyBinningVertical => new LegacyBinningVerticalEnum();

	public static IntegerName OffsetY => (IntegerName)"@CameraDevice/OffsetY";

	public static IntegerName OffsetX => (IntegerName)"@CameraDevice/OffsetX";

	public static IntegerName Height => (IntegerName)"@CameraDevice/Height";

	public static IntegerName Width => (IntegerName)"@CameraDevice/Width";

	public static IntegerName ColorAdjustmentSaturationRaw => (IntegerName)"@CameraDevice/ColorAdjustmentSaturationRaw";

	public static FloatName ColorAdjustmentSaturation => (FloatName)"@CameraDevice/ColorAdjustmentSaturation";

	public static IntegerName ColorAdjustmentHueRaw => (IntegerName)"@CameraDevice/ColorAdjustmentHueRaw";

	public static FloatName ColorAdjustmentHue => (FloatName)"@CameraDevice/ColorAdjustmentHue";

	public static ColorAdjustmentSelectorEnum ColorAdjustmentSelector => new ColorAdjustmentSelectorEnum();

	public static CommandName ColorAdjustmentReset => (CommandName)"@CameraDevice/ColorAdjustmentReset";

	public static BooleanName ColorAdjustmentEnable => (BooleanName)"@CameraDevice/ColorAdjustmentEnable";

	public static IntegerName ColorTransformationMatrixFactorRaw => (IntegerName)"@CameraDevice/ColorTransformationMatrixFactorRaw";

	public static FloatName ColorTransformationMatrixFactor => (FloatName)"@CameraDevice/ColorTransformationMatrixFactor";

	public static IntegerName ColorTransformationValueRaw => (IntegerName)"@CameraDevice/ColorTransformationValueRaw";

	public static FloatName ColorTransformationValue => (FloatName)"@CameraDevice/ColorTransformationValue";

	public static ColorTransformationValueSelectorEnum ColorTransformationValueSelector => new ColorTransformationValueSelectorEnum();

	public static ColorTransformationSelectorEnum ColorTransformationSelector => new ColorTransformationSelectorEnum();

	public static IntegerName BalanceRatioRaw => (IntegerName)"@CameraDevice/BalanceRatioRaw";

	public static FloatName BalanceRatioAbs => (FloatName)"@CameraDevice/BalanceRatioAbs";

	public static BalanceRatioSelectorEnum BalanceRatioSelector => new BalanceRatioSelectorEnum();

	public static BalanceWhiteAutoEnum BalanceWhiteAuto => new BalanceWhiteAutoEnum();

	public static CommandName BalanceWhiteReset => (CommandName)"@CameraDevice/BalanceWhiteReset";

	public static LightSourceSelectorEnum LightSourceSelector => new LightSourceSelectorEnum();

	public static IntegerName HeightMax => (IntegerName)"@CameraDevice/HeightMax";

	public static IntegerName WidthMax => (IntegerName)"@CameraDevice/WidthMax";

	public static IntegerName SensorHeight => (IntegerName)"@CameraDevice/SensorHeight";

	public static IntegerName SensorWidth => (IntegerName)"@CameraDevice/SensorWidth";

	public static IntegerName TLParamsLocked => (IntegerName)"@CameraDevice/TLParamsLocked";

	public static TestImageSelectorEnum TestImageSelector => new TestImageSelectorEnum();

	public static BooleanName ReverseY => (BooleanName)"@CameraDevice/ReverseY";

	public static BooleanName ReverseX => (BooleanName)"@CameraDevice/ReverseX";

	public static IntegerName PixelDynamicRangeMax => (IntegerName)"@CameraDevice/PixelDynamicRangeMax";

	public static IntegerName PixelDynamicRangeMin => (IntegerName)"@CameraDevice/PixelDynamicRangeMin";

	public static BooleanName ProcessedRawEnable => (BooleanName)"@CameraDevice/ProcessedRawEnable";

	public static PixelColorFilterEnum PixelColorFilter => new PixelColorFilterEnum();

	public static PixelSizeEnum PixelSize => new PixelSizeEnum();

	public static PixelFormatEnum PixelFormat => new PixelFormatEnum();

	public static IntegerName SubstrateVoltage => (IntegerName)"@CameraDevice/SubstrateVoltage";

	public static IntegerName DigitalShift => (IntegerName)"@CameraDevice/DigitalShift";

	public static FloatName Gamma => (FloatName)"@CameraDevice/Gamma";

	public static GammaSelectorEnum GammaSelector => new GammaSelectorEnum();

	public static BooleanName GammaEnable => (BooleanName)"@CameraDevice/GammaEnable";

	public static IntegerName BlackLevelRaw => (IntegerName)"@CameraDevice/BlackLevelRaw";

	public static BlackLevelSelectorEnum BlackLevelSelector => new BlackLevelSelectorEnum();

	public static IntegerName GainRaw => (IntegerName)"@CameraDevice/GainRaw";

	public static GainSelectorEnum GainSelector => new GainSelectorEnum();

	public static GainAutoEnum GainAuto => new GainAutoEnum();
}
