using System.ComponentModel;

namespace Basler.Pylon;

public static class PLCamera
{
	[EditorBrowsable(EditorBrowsableState.Never)]
	public class AcquisitionFrameRateEnumEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/AcquisitionFrameRateEnum";

		public string FrameRate60 => "FrameRate60";

		public string FrameRate50 => "FrameRate50";

		public string FrameRate30 => "FrameRate30";

		public string FrameRate25 => "FrameRate25";

		public string FrameRate24 => "FrameRate24";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class AcquisitionModeEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/AcquisitionMode";

		public string SingleFrame => "SingleFrame";

		public string MultiFrame => "MultiFrame";

		public string Continuous => "Continuous";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class AcquisitionStatusSelectorEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/AcquisitionStatusSelector";

		public string LineTriggerWait => "LineTriggerWait";

		public string FrameTriggerWait => "FrameTriggerWait";

		public string FrameTransfer => "FrameTransfer";

		public string FrameBurstTriggerWait => "FrameBurstTriggerWait";

		public string FrameBurstTriggerTransfer => "FrameBurstTriggerTransfer";

		public string FrameBurstTriggerActive => "FrameBurstTriggerActive";

		public string FrameBurstActive => "FrameBurstActive";

		public string FrameActive => "FrameActive";

		public string ExposureTriggerWait => "ExposureTriggerWait";

		public string ExposureActive => "ExposureActive";

		public string AcquisitionTriggerWait => "AcquisitionTriggerWait";

		public string AcquisitionTransfer => "AcquisitionTransfer";

		public string AcquisitionIdle => "AcquisitionIdle";

		public string AcquisitionActive => "AcquisitionActive";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class AutoFunctionAOISelectorEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/AutoFunctionAOISelector";

		public string AOI8 => "AOI8";

		public string AOI7 => "AOI7";

		public string AOI6 => "AOI6";

		public string AOI5 => "AOI5";

		public string AOI4 => "AOI4";

		public string AOI3 => "AOI3";

		public string AOI2 => "AOI2";

		public string AOI1 => "AOI1";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class AutoFunctionProfileEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/AutoFunctionProfile";

		public string Smart => "Smart";

		public string MinimizeGainQuick => "MinimizeGainQuick";

		public string MinimizeGain => "MinimizeGain";

		public string MinimizeExposureTimeQuick => "MinimizeExposureTimeQuick";

		public string MinimizeExposureTime => "MinimizeExposureTime";

		public string GainMinimumQuick => "GainMinimumQuick";

		public string GainMinimum => "GainMinimum";

		public string ExposureMinimumQuick => "ExposureMinimumQuick";

		public string ExposureMinimum => "ExposureMinimum";

		public string AntiFlicker60Hz => "AntiFlicker60Hz";

		public string AntiFlicker50Hz => "AntiFlicker50Hz";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class AutoFunctionROISelectorEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/AutoFunctionROISelector";

		public string ROI2 => "ROI2";

		public string ROI1 => "ROI1";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class AutoTonalRangeAdjustmentSelectorEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/AutoTonalRangeAdjustmentSelector";

		public string DarkAndBright => "DarkAndBright";

		public string Dark => "Dark";

		public string Bright => "Bright";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class AutoTonalRangeModeSelectorEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/AutoTonalRangeModeSelector";

		public string Contrast => "Contrast";

		public string ColorAndContrast => "ColorAndContrast";

		public string Color => "Color";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class BLCSerialPortBaudRateEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/BLCSerialPortBaudRate";

		public string Baud115200 => "Baud115200";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class BLCSerialPortParityEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/BLCSerialPortParity";

		public string Off => "Off";

		public string Odd => "Odd";

		public string Even => "Even";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class BLCSerialPortSourceEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/BLCSerialPortSource";

		public string Off => "Off";

		public string Line4 => "Line4";

		public string Line3 => "Line3";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class BLCSerialPortStopBitsEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/BLCSerialPortStopBits";

		public string StopBits1 => "StopBits1";

		public string StopBits0 => "StopBits0";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class BLCSerialReceiveQueueStatusEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/BLCSerialReceiveQueueStatus";

		public string Full => "Full";

		public string Filled => "Filled";

		public string Empty => "Empty";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class BLCSerialTransmitQueueStatusEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/BLCSerialTransmitQueueStatus";

		public string Full => "Full";

		public string Filled => "Filled";

		public string Empty => "Empty";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class BalanceRatioSelectorEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/BalanceRatioSelector";

		public string Red => "Red";

		public string Green => "Green";

		public string Blue => "Blue";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class BalanceWhiteAutoEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/BalanceWhiteAuto";

		public string Once => "Once";

		public string Off => "Off";

		public string Continuous => "Continuous";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class BandwidthReserveModeEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/BandwidthReserveMode";

		public string Standard => "Standard";

		public string Performance => "Performance";

		public string Manual => "Manual";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class BinningHorizontalModeEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/BinningHorizontalMode";

		public string Sum => "Sum";

		public string Average => "Average";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class BinningModeHorizontalEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/BinningModeHorizontal";

		public string Summing => "Summing";

		public string Averaging => "Averaging";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class BinningModeVerticalEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/BinningModeVertical";

		public string Summing => "Summing";

		public string Averaging => "Averaging";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class BinningSelectorEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/BinningSelector";

		public string Sensor => "Sensor";

		public string Region1 => "Region1";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class BinningVerticalModeEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/BinningVerticalMode";

		public string Sum => "Sum";

		public string Average => "Average";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class BlackLevelSelectorEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/BlackLevelSelector";

		public string Tap4 => "Tap4";

		public string Tap3 => "Tap3";

		public string Tap2 => "Tap2";

		public string Tap1 => "Tap1";

		public string Red => "Red";

		public string Green => "Green";

		public string DigitalAll => "DigitalAll";

		public string Blue => "Blue";

		public string AnalogAll => "AnalogAll";

		public string All => "All";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class BslAcquisitionBurstModeEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/BslAcquisitionBurstMode";

		public string Standard => "Standard";

		public string HighSpeed => "HighSpeed";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class BslAcquisitionStopModeEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/BslAcquisitionStopMode";

		public string CompleteExposure => "CompleteExposure";

		public string AbortExposure => "AbortExposure";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class BslBlackLevelCompensationModeEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/BslBlackLevelCompensationMode";

		public string Sensor => "Sensor";

		public string Off => "Off";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class BslChunkAutoBrightnessStatusEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/BslChunkAutoBrightnessStatus";

		public string TargetReached => "TargetReached";

		public string TargetNotReached => "TargetNotReached";

		public string Disabled => "Disabled";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class BslChunkTimestampSelectorEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/BslChunkTimestampSelector";

		public string FrameStart => "FrameStart";

		public string ExposureStart => "ExposureStart";

		public string ExposureEnd => "ExposureEnd";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class BslColorAdjustmentSelectorEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/BslColorAdjustmentSelector";

		public string Yellow => "Yellow";

		public string Red => "Red";

		public string Magenta => "Magenta";

		public string Green => "Green";

		public string Cyan => "Cyan";

		public string Blue => "Blue";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class BslColorSpaceEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/BslColorSpace";

		public string sRgb => "sRgb";

		public string Off => "Off";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class BslColorSpaceModeEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/BslColorSpaceMode";

		public string sRGB => "sRGB";

		public string RGB => "RGB";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class BslContrastModeEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/BslContrastMode";

		public string SCurve => "SCurve";

		public string Linear => "Linear";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class BslDefectPixelCorrectionModeEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/BslDefectPixelCorrectionMode";

		public string StaticOnly => "StaticOnly";

		public string On => "On";

		public string Off => "Off";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class BslExposureTimeModeEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/BslExposureTimeMode";

		public string UltraShort => "UltraShort";

		public string Standard => "Standard";

		public string Short => "Short";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class BslImmediateTriggerModeEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/BslImmediateTriggerMode";

		public string On => "On";

		public string Off => "Off";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class BslLightControlErrorStatusEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/BslLightControlErrorStatus";

		public string NoError => "NoError";

		public string MultipleDevices => "MultipleDevices";

		public string Device4 => "Device4";

		public string Device3 => "Device3";

		public string Device2 => "Device2";

		public string Device1 => "Device1";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class BslLightControlModeEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/BslLightControlMode";

		public string On => "On";

		public string Off => "Off";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class BslLightControlSourceEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/BslLightControlSource";

		public string Off => "Off";

		public string Line4 => "Line4";

		public string Line3 => "Line3";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class BslLightControlStatusEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/BslLightControlStatus";

		public string Updating => "Updating";

		public string Searching => "Searching";

		public string Ready => "Ready";

		public string Off => "Off";

		public string Idle => "Idle";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class BslLightDeviceChangeIDEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/BslLightDeviceChangeID";

		public string Device4 => "Device4";

		public string Device3 => "Device3";

		public string Device2 => "Device2";

		public string Device1 => "Device1";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class BslLightDeviceLastErrorEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/BslLightDeviceLastError";

		public string ShortCircuit => "ShortCircuit";

		public string NoError => "NoError";

		public string InsufficientCurrent => "InsufficientCurrent";

		public string Hardware => "Hardware";

		public string Connection => "Connection";

		public string Communication => "Communication";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class BslLightDeviceOperationModeEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/BslLightDeviceOperationMode";

		public string Strobe => "Strobe";

		public string On => "On";

		public string Off => "Off";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class BslLightDeviceSelectorEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/BslLightDeviceSelector";

		public string Device4 => "Device4";

		public string Device3 => "Device3";

		public string Device2 => "Device2";

		public string Device1 => "Device1";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class BslLightDeviceStrobeModeEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/BslLightDeviceStrobeMode";

		public string Manual => "Manual";

		public string Automatic => "Automatic";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class BslLightSourcePresetEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/BslLightSourcePreset";

		public string Tungsten => "Tungsten";

		public string Off => "Off";

		public string FactoryLED6000K => "FactoryLED6000K";

		public string Daylight6500K => "Daylight6500K";

		public string Daylight5000K => "Daylight5000K";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class BslLightSourcePresetFeatureSelectorEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/BslLightSourcePresetFeatureSelector";

		public string WhiteBalance => "WhiteBalance";

		public string ColorTransformation => "ColorTransformation";

		public string ColorAdjustment => "ColorAdjustment";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class BslLineConnectionEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/BslLineConnection";

		public string TwiSda => "TwiSda";

		public string TwiScl => "TwiScl";

		public string ConnectionOff => "ConnectionOff";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class BslMultipleROIColumnSelectorEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/BslMultipleROIColumnSelector";

		public string Column8 => "Column8";

		public string Column7 => "Column7";

		public string Column6 => "Column6";

		public string Column5 => "Column5";

		public string Column4 => "Column4";

		public string Column3 => "Column3";

		public string Column2 => "Column2";

		public string Column1 => "Column1";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class BslMultipleROIRowSelectorEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/BslMultipleROIRowSelector";

		public string Row9 => "Row9";

		public string Row8 => "Row8";

		public string Row7 => "Row7";

		public string Row6 => "Row6";

		public string Row5 => "Row5";

		public string Row4 => "Row4";

		public string Row3 => "Row3";

		public string Row2 => "Row2";

		public string Row16 => "Row16";

		public string Row15 => "Row15";

		public string Row14 => "Row14";

		public string Row13 => "Row13";

		public string Row12 => "Row12";

		public string Row11 => "Row11";

		public string Row10 => "Row10";

		public string Row1 => "Row1";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class BslPeriodicSignalSelectorEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/BslPeriodicSignalSelector";

		public string PeriodicSignal1 => "PeriodicSignal1";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class BslPeriodicSignalSourceEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/BslPeriodicSignalSource";

		public string PtpClock => "PtpClock";

		public string DeviceClock => "DeviceClock";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class BslPtpDelayMechanismEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/BslPtpDelayMechanism";

		public string P2P => "P2P";

		public string E2E => "E2E";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class BslPtpNetworkModeEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/BslPtpNetworkMode";

		public string Unicast => "Unicast";

		public string Multicast => "Multicast";

		public string Hybrid => "Hybrid";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class BslPtpProfileEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/BslPtpProfile";

		public string PeerToPeerDefaultProfile => "PeerToPeerDefaultProfile";

		public string DelayRequestResponseDefaultProfile => "DelayRequestResponseDefaultProfile";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class BslSensorBitDepthEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/BslSensorBitDepth";

		public string Bpp8 => "Bpp8";

		public string Bpp12 => "Bpp12";

		public string Bpp10 => "Bpp10";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class BslSensorBitDepthModeEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/BslSensorBitDepthMode";

		public string Manual => "Manual";

		public string Auto => "Auto";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class BslSensorStateEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/BslSensorState";

		public string Standby => "Standby";

		public string On => "On";

		public string Off => "Off";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class BslSerialBaudRateEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/BslSerialBaudRate";

		public string Baud9600 => "Baud9600";

		public string Baud57600 => "Baud57600";

		public string Baud4800 => "Baud4800";

		public string Baud38400 => "Baud38400";

		public string Baud2400 => "Baud2400";

		public string Baud19200 => "Baud19200";

		public string Baud1200 => "Baud1200";

		public string Baud115200 => "Baud115200";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class BslSerialNumberOfDataBitsEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/BslSerialNumberOfDataBits";

		public string Bits8 => "Bits8";

		public string Bits7 => "Bits7";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class BslSerialNumberOfStopBitsEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/BslSerialNumberOfStopBits";

		public string Bits2 => "Bits2";

		public string Bits1 => "Bits1";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class BslSerialParityEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/BslSerialParity";

		public string Odd => "Odd";

		public string None => "None";

		public string Even => "Even";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class BslSerialRxSourceEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/BslSerialRxSource";

		public string SerialTx => "SerialTx";

		public string Off => "Off";

		public string Line3 => "Line3";

		public string Line2 => "Line2";

		public string Line1 => "Line1";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class BslTemperatureStatusEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/BslTemperatureStatus";

		public string Ok => "Ok";

		public string Error => "Error";

		public string Critical => "Critical";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class BslTransferBitDepthEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/BslTransferBitDepth";

		public string Bpp8 => "Bpp8";

		public string Bpp12 => "Bpp12";

		public string Bpp10 => "Bpp10";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class BslTransferBitDepthModeEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/BslTransferBitDepthMode";

		public string Manual => "Manual";

		public string Auto => "Auto";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class BslTwiBitrateEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/BslTwiBitrate";

		public string Bitrate50kbps => "Bitrate50kbps";

		public string Bitrate400kbps => "Bitrate400kbps";

		public string Bitrate20kbps => "Bitrate20kbps";

		public string Bitrate200kbps => "Bitrate200kbps";

		public string Bitrate10kbps => "Bitrate10kbps";

		public string Bitrate100kbps => "Bitrate100kbps";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class BslTwiTransferStatusEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/BslTwiTransferStatus";

		public string Success => "Success";

		public string Pending => "Pending";

		public string NakData => "NakData";

		public string NakAddress => "NakAddress";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class BslUSBPowerSourceEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/BslUSBPowerSource";

		public string Bus => "Bus";

		public string Aux => "Aux";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class BslUSBSpeedModeEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/BslUSBSpeedMode";

		public string SuperSpeed => "SuperSpeed";

		public string LowSpeed => "LowSpeed";

		public string HighSpeed => "HighSpeed";

		public string FullSpeed => "FullSpeed";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class BslVignettingCorrectionModeEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/BslVignettingCorrectionMode";

		public string On => "On";

		public string Off => "Off";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class CameraOperationModeEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/CameraOperationMode";

		public string Standard => "Standard";

		public string LongExposure => "LongExposure";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class ChunkCounterSelectorEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/ChunkCounterSelector";

		public string Counter2 => "Counter2";

		public string Counter1 => "Counter1";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class ChunkGainSelectorEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/ChunkGainSelector";

		public string All => "All";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class ChunkPixelFormatEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/ChunkPixelFormat";

		public string YUV444Packed => "YUV444Packed";

		public string YUV422_YUYV_Packed => "YUV422_YUYV_Packed";

		public string YUV422_8 => "YUV422_8";

		public string YUV422Packed => "YUV422Packed";

		public string YUV411Packed => "YUV411Packed";

		public string YCbCr422_8 => "YCbCr422_8";

		public string RGBA8Packed => "RGBA8Packed";

		public string RGB8Planar => "RGB8Planar";

		public string RGB8Packed => "RGB8Packed";

		public string RGB8 => "RGB8";

		public string RGB16Planar => "RGB16Planar";

		public string RGB12V1Packed => "RGB12V1Packed";

		public string RGB12Planar => "RGB12Planar";

		public string RGB12Packed => "RGB12Packed";

		public string RGB10V2Packed => "RGB10V2Packed";

		public string RGB10V1Packed => "RGB10V1Packed";

		public string RGB10Planar => "RGB10Planar";

		public string RGB10Packed => "RGB10Packed";

		public string Mono8Signed => "Mono8Signed";

		public string Mono8 => "Mono8";

		public string Mono16 => "Mono16";

		public string Mono12p => "Mono12p";

		public string Mono12Packed => "Mono12Packed";

		public string Mono12 => "Mono12";

		public string Mono10p => "Mono10p";

		public string Mono10Packed => "Mono10Packed";

		public string Mono10 => "Mono10";

		public string BayerRG8 => "BayerRG8";

		public string BayerRG16 => "BayerRG16";

		public string BayerRG12p => "BayerRG12p";

		public string BayerRG12Packed => "BayerRG12Packed";

		public string BayerRG12 => "BayerRG12";

		public string BayerRG10p => "BayerRG10p";

		public string BayerRG10 => "BayerRG10";

		public string BayerGR8 => "BayerGR8";

		public string BayerGR16 => "BayerGR16";

		public string BayerGR12p => "BayerGR12p";

		public string BayerGR12Packed => "BayerGR12Packed";

		public string BayerGR12 => "BayerGR12";

		public string BayerGR10p => "BayerGR10p";

		public string BayerGR10 => "BayerGR10";

		public string BayerGB8 => "BayerGB8";

		public string BayerGB16 => "BayerGB16";

		public string BayerGB12p => "BayerGB12p";

		public string BayerGB12Packed => "BayerGB12Packed";

		public string BayerGB12 => "BayerGB12";

		public string BayerGB10p => "BayerGB10p";

		public string BayerGB10 => "BayerGB10";

		public string BayerBG8 => "BayerBG8";

		public string BayerBG16 => "BayerBG16";

		public string BayerBG12p => "BayerBG12p";

		public string BayerBG12Packed => "BayerBG12Packed";

		public string BayerBG12 => "BayerBG12";

		public string BayerBG10p => "BayerBG10p";

		public string BayerBG10 => "BayerBG10";

		public string BGRA8Packed => "BGRA8Packed";

		public string BGR8Packed => "BGR8Packed";

		public string BGR8 => "BGR8";

		public string BGR12Packed => "BGR12Packed";

		public string BGR10Packed => "BGR10Packed";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class ChunkSelectorEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/ChunkSelector";

		public string Width => "Width";

		public string VirtLineStatusAll => "VirtLineStatusAll";

		public string Triggerinputcounter => "Triggerinputcounter";

		public string Timestamp => "Timestamp";

		public string Stride => "Stride";

		public string ShaftEncoderCounter => "ShaftEncoderCounter";

		public string SequencerSetActive => "SequencerSetActive";

		public string SequenceSetIndex => "SequenceSetIndex";

		public string PixelFormat => "PixelFormat";

		public string PayloadCRC16 => "PayloadCRC16";

		public string OffsetY => "OffsetY";

		public string OffsetX => "OffsetX";

		public string LineTriggerIgnoredCounter => "LineTriggerIgnoredCounter";

		public string LineTriggerEndToEndCounter => "LineTriggerEndToEndCounter";

		public string LineTriggerCounter => "LineTriggerCounter";

		public string LineStatusAll => "LineStatusAll";

		public string InputStatusAtLineTrigger => "InputStatusAtLineTrigger";

		public string Image => "Image";

		public string Height => "Height";

		public string GainAll => "GainAll";

		public string Gain => "Gain";

		public string FramesPerTriggerCounter => "FramesPerTriggerCounter";

		public string Framecounter => "Framecounter";

		public string FrameTriggerIgnoredCounter => "FrameTriggerIgnoredCounter";

		public string FrameTriggerCounter => "FrameTriggerCounter";

		public string FrameID => "FrameID";

		public string ExposureTime => "ExposureTime";

		public string DynamicRangeMin => "DynamicRangeMin";

		public string DynamicRangeMax => "DynamicRangeMax";

		public string CounterValue => "CounterValue";

		public string BrightPixel => "BrightPixel";

		public string AutoBrightnessStatus => "AutoBrightnessStatus";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class ClConfigurationEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/ClConfiguration";

		public string Medium => "Medium";

		public string Full => "Full";

		public string DualBase => "DualBase";

		public string Deca => "Deca";

		public string Base => "Base";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class ClPixelClockEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/ClPixelClock";

		public string PixelClock83_5 => "PixelClock83_5";

		public string PixelClock83 => "PixelClock83";

		public string PixelClock82_5 => "PixelClock82_5";

		public string PixelClock82 => "PixelClock82";

		public string PixelClock65 => "PixelClock65";

		public string PixelClock48 => "PixelClock48";

		public string PixelClock40 => "PixelClock40";

		public string PixelClock32_5 => "PixelClock32_5";

		public string PixelClock20 => "PixelClock20";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class ClSerialPortBaudRateEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/ClSerialPortBaudRate";

		public string Baud9600 => "Baud9600";

		public string Baud921600 => "Baud921600";

		public string Baud57600 => "Baud57600";

		public string Baud460800 => "Baud460800";

		public string Baud38400 => "Baud38400";

		public string Baud230400 => "Baud230400";

		public string Baud19200 => "Baud19200";

		public string Baud115200 => "Baud115200";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class ClTapGeometryEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/ClTapGeometry";

		public string Geometry1X_2YE => "Geometry1X_2YE";

		public string Geometry1X_1Y => "Geometry1X_1Y";

		public string Geometry1X8_1Y => "Geometry1X8_1Y";

		public string Geometry1X8 => "Geometry1X8";

		public string Geometry1X6_1Y => "Geometry1X6_1Y";

		public string Geometry1X6 => "Geometry1X6";

		public string Geometry1X4_1Y => "Geometry1X4_1Y";

		public string Geometry1X4 => "Geometry1X4";

		public string Geometry1X3_1Y => "Geometry1X3_1Y";

		public string Geometry1X3 => "Geometry1X3";

		public string Geometry1X2_1Y => "Geometry1X2_1Y";

		public string Geometry1X2 => "Geometry1X2";

		public string Geometry1X10_1Y => "Geometry1X10_1Y";

		public string Geometry1X10 => "Geometry1X10";

		public string Geometry1X => "Geometry1X";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class ClTimeSlotsEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/ClTimeSlots";

		public string TimeSlots1 => "TimeSlots1";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class ColorAdjustmentSelectorEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/ColorAdjustmentSelector";

		public string Yellow => "Yellow";

		public string Red => "Red";

		public string Magenta => "Magenta";

		public string Green => "Green";

		public string Cyan => "Cyan";

		public string Blue => "Blue";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class ColorOverexposureCompensationAOISelectorEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/ColorOverexposureCompensationAOISelector";

		public string AOI1 => "AOI1";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class ColorSpaceEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/ColorSpace";

		public string sRGB => "sRGB";

		public string RGB => "RGB";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class ColorTransformationSelectorEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/ColorTransformationSelector";

		public string YUVtoRGB => "YUVtoRGB";

		public string RGBtoYUV => "RGBtoYUV";

		public string RGBtoRGB => "RGBtoRGB";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class ColorTransformationValueSelectorEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/ColorTransformationValueSelector";

		public string Offset2 => "Offset2";

		public string Offset1 => "Offset1";

		public string Offset0 => "Offset0";

		public string Gain22 => "Gain22";

		public string Gain21 => "Gain21";

		public string Gain20 => "Gain20";

		public string Gain12 => "Gain12";

		public string Gain11 => "Gain11";

		public string Gain10 => "Gain10";

		public string Gain02 => "Gain02";

		public string Gain01 => "Gain01";

		public string Gain00 => "Gain00";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class ComponentSelectorEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/ComponentSelector";

		public string Range => "Range";

		public string Intensity => "Intensity";

		public string Confidence => "Confidence";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class CounterEventActivationEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/CounterEventActivation";

		public string RisingEdge => "RisingEdge";

		public string LevelLow => "LevelLow";

		public string LevelHigh => "LevelHigh";

		public string FallingEdge => "FallingEdge";

		public string AnyEdge => "AnyEdge";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class CounterEventSourceEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/CounterEventSource";

		public string Timer2End => "Timer2End";

		public string Timer2Active => "Timer2Active";

		public string Timer1End => "Timer1End";

		public string Timer1Active => "Timer1Active";

		public string SoftwareSignal3 => "SoftwareSignal3";

		public string SoftwareSignal2 => "SoftwareSignal2";

		public string SoftwareSignal1 => "SoftwareSignal1";

		public string PeriodicSignal1 => "PeriodicSignal1";

		public string Off => "Off";

		public string LineTrigger => "LineTrigger";

		public string LineStart => "LineStart";

		public string LineEnd => "LineEnd";

		public string Line4 => "Line4";

		public string Line3 => "Line3";

		public string Line2 => "Line2";

		public string Line1 => "Line1";

		public string FrameTriggerWait => "FrameTriggerWait";

		public string FrameTrigger => "FrameTrigger";

		public string FrameStart => "FrameStart";

		public string FrameEnd => "FrameEnd";

		public string FrameBurstTriggerWait => "FrameBurstTriggerWait";

		public string FrameBurstActive => "FrameBurstActive";

		public string ExposureTriggerWait => "ExposureTriggerWait";

		public string ExposureStart => "ExposureStart";

		public string ExposureEnd => "ExposureEnd";

		public string ExposureActive => "ExposureActive";

		public string CxpTrigger1 => "CxpTrigger1";

		public string CxpTrigger0 => "CxpTrigger0";

		public string Counter3End => "Counter3End";

		public string Counter2Start => "Counter2Start";

		public string Counter2End => "Counter2End";

		public string Counter2Active => "Counter2Active";

		public string Counter1Start => "Counter1Start";

		public string Counter1End => "Counter1End";

		public string Counter1Active => "Counter1Active";

		public string Action2 => "Action2";

		public string Action1 => "Action1";

		public string AcquisitionTrigger => "AcquisitionTrigger";

		public string AcquisitionStart => "AcquisitionStart";

		public string AcquisitionEnd => "AcquisitionEnd";

		public string AcquisitionActive => "AcquisitionActive";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class CounterResetActivationEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/CounterResetActivation";

		public string RisingEdge => "RisingEdge";

		public string LevelLow => "LevelLow";

		public string LevelHigh => "LevelHigh";

		public string FallingEdge => "FallingEdge";

		public string AnyEdge => "AnyEdge";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class CounterResetSourceEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/CounterResetSource";

		public string VInputDecActive => "VInputDecActive";

		public string VInput4 => "VInput4";

		public string VInput3 => "VInput3";

		public string VInput2 => "VInput2";

		public string VInput1 => "VInput1";

		public string Timer2End => "Timer2End";

		public string Timer2Active => "Timer2Active";

		public string Timer1End => "Timer1End";

		public string Timer1Active => "Timer1Active";

		public string SoftwareSignal3 => "SoftwareSignal3";

		public string SoftwareSignal2 => "SoftwareSignal2";

		public string SoftwareSignal1 => "SoftwareSignal1";

		public string Software => "Software";

		public string PeriodicSignal1 => "PeriodicSignal1";

		public string Off => "Off";

		public string Line8 => "Line8";

		public string Line7 => "Line7";

		public string Line6 => "Line6";

		public string Line5 => "Line5";

		public string Line4 => "Line4";

		public string Line3 => "Line3";

		public string Line2 => "Line2";

		public string Line1 => "Line1";

		public string FrameTriggerWait => "FrameTriggerWait";

		public string FrameBurstTriggerWait => "FrameBurstTriggerWait";

		public string FrameBurstActive => "FrameBurstActive";

		public string ExposureTriggerWait => "ExposureTriggerWait";

		public string ExposureStart => "ExposureStart";

		public string ExposureActive => "ExposureActive";

		public string CxpTrigger1 => "CxpTrigger1";

		public string CxpTrigger0 => "CxpTrigger0";

		public string Counter4End => "Counter4End";

		public string Counter3End => "Counter3End";

		public string Counter2Start => "Counter2Start";

		public string Counter2End => "Counter2End";

		public string Counter2Active => "Counter2Active";

		public string Counter1Start => "Counter1Start";

		public string Counter1End => "Counter1End";

		public string Counter1Active => "Counter1Active";

		public string CC4 => "CC4";

		public string CC3 => "CC3";

		public string CC2 => "CC2";

		public string CC1 => "CC1";

		public string Action2 => "Action2";

		public string Action1 => "Action1";

		public string AcquisitionActive => "AcquisitionActive";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class CounterSelectorEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/CounterSelector";

		public string Counter4 => "Counter4";

		public string Counter3 => "Counter3";

		public string Counter2 => "Counter2";

		public string Counter1 => "Counter1";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class CounterStatusEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/CounterStatus";

		public string CounterTriggerWait => "CounterTriggerWait";

		public string CounterCompleted => "CounterCompleted";

		public string CounterActive => "CounterActive";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class CounterTriggerActivationEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/CounterTriggerActivation";

		public string RisingEdge => "RisingEdge";

		public string LevelLow => "LevelLow";

		public string LevelHigh => "LevelHigh";

		public string FallingEdge => "FallingEdge";

		public string AnyEdge => "AnyEdge";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class CounterTriggerSourceEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/CounterTriggerSource";

		public string Timer2End => "Timer2End";

		public string Timer2Active => "Timer2Active";

		public string Timer1End => "Timer1End";

		public string Timer1Active => "Timer1Active";

		public string SoftwareSignal3 => "SoftwareSignal3";

		public string SoftwareSignal2 => "SoftwareSignal2";

		public string SoftwareSignal1 => "SoftwareSignal1";

		public string PeriodicSignal1 => "PeriodicSignal1";

		public string Off => "Off";

		public string Line4 => "Line4";

		public string Line3 => "Line3";

		public string Line2 => "Line2";

		public string Line1 => "Line1";

		public string FrameTriggerWait => "FrameTriggerWait";

		public string FrameBurstTriggerWait => "FrameBurstTriggerWait";

		public string FrameBurstActive => "FrameBurstActive";

		public string ExposureTriggerWait => "ExposureTriggerWait";

		public string ExposureStart => "ExposureStart";

		public string ExposureActive => "ExposureActive";

		public string CxpTrigger1 => "CxpTrigger1";

		public string CxpTrigger0 => "CxpTrigger0";

		public string Counter2Start => "Counter2Start";

		public string Counter2End => "Counter2End";

		public string Counter2Active => "Counter2Active";

		public string Counter1Start => "Counter1Start";

		public string Counter1End => "Counter1End";

		public string Counter1Active => "Counter1Active";

		public string Action2 => "Action2";

		public string Action1 => "Action1";

		public string AcquisitionActive => "AcquisitionActive";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class CxpConnectionTestModeEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/CxpConnectionTestMode";

		public string Off => "Off";

		public string Mode1 => "Mode1";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class CxpErrorCounterSelectorEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/CxpErrorCounterSelector";

		public string DuplicatedCharactersUncorrected => "DuplicatedCharactersUncorrected";

		public string ControlPacketCrc => "ControlPacketCrc";

		public string ConnectionLockLoss => "ConnectionLockLoss";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class CxpErrorCounterStatusEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/CxpErrorCounterStatus";

		public string CounterActive => "CounterActive";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class CxpLinkConfigurationEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/CxpLinkConfiguration";

		public string CXP6_X2 => "CXP6_X2";

		public string CXP6_X1 => "CXP6_X1";

		public string CXP5_X2 => "CXP5_X2";

		public string CXP5_X1 => "CXP5_X1";

		public string CXP3_X2 => "CXP3_X2";

		public string CXP3_X1 => "CXP3_X1";

		public string CXP2_X2 => "CXP2_X2";

		public string CXP2_X1 => "CXP2_X1";

		public string CXP12_X2 => "CXP12_X2";

		public string CXP12_X1 => "CXP12_X1";

		public string CXP10_X2 => "CXP10_X2";

		public string CXP10_X1 => "CXP10_X1";

		public string Auto => "Auto";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class CxpLinkConfigurationPreferredEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/CxpLinkConfigurationPreferred";

		public string CXP6_X2 => "CXP6_X2";

		public string CXP6_X1 => "CXP6_X1";

		public string CXP5_X2 => "CXP5_X2";

		public string CXP5_X1 => "CXP5_X1";

		public string CXP3_X2 => "CXP3_X2";

		public string CXP3_X1 => "CXP3_X1";

		public string CXP2_X2 => "CXP2_X2";

		public string CXP2_X1 => "CXP2_X1";

		public string CXP12_X2 => "CXP12_X2";

		public string CXP12_X1 => "CXP12_X1";

		public string CXP10_X2 => "CXP10_X2";

		public string CXP10_X1 => "CXP10_X1";

		public string Auto => "Auto";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class CxpLinkConfigurationStatusEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/CxpLinkConfigurationStatus";

		public string CXP6_X2 => "CXP6_X2";

		public string CXP6_X1 => "CXP6_X1";

		public string CXP5_X2 => "CXP5_X2";

		public string CXP5_X1 => "CXP5_X1";

		public string CXP3_X2 => "CXP3_X2";

		public string CXP3_X1 => "CXP3_X1";

		public string CXP2_X2 => "CXP2_X2";

		public string CXP2_X1 => "CXP2_X1";

		public string CXP12_X2 => "CXP12_X2";

		public string CXP12_X1 => "CXP12_X1";

		public string CXP10_X2 => "CXP10_X2";

		public string CXP10_X1 => "CXP10_X1";

		public string Auto => "Auto";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class CxpSendReceiveSelectorEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/CxpSendReceiveSelector";

		public string Send => "Send";

		public string Receive => "Receive";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class DefectPixelCorrectionModeEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/DefectPixelCorrectionMode";

		public string StaticOnly => "StaticOnly";

		public string On => "On";

		public string Off => "Off";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class DemosaicingModeEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/DemosaicingMode";

		public string Simple => "Simple";

		public string BaslerPGI => "BaslerPGI";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class DeviceCharacterSetEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/DeviceCharacterSet";

		public string UTF8 => "UTF8";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class DeviceIndicatorModeEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/DeviceIndicatorMode";

		public string Inactive => "Inactive";

		public string ErrorStatus => "ErrorStatus";

		public string Active => "Active";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class DeviceLinkThroughputLimitModeEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/DeviceLinkThroughputLimitMode";

		public string On => "On";

		public string Off => "Off";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class DeviceRegistersEndiannessEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/DeviceRegistersEndianness";

		public string Little => "Little";

		public string Big => "Big";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class DeviceScanTypeEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/DeviceScanType";

		public string Linescan3D => "Linescan3D";

		public string Linescan => "Linescan";

		public string Areascan3D => "Areascan3D";

		public string Areascan => "Areascan";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class DeviceTLTypeEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/DeviceTLType";

		public string USB3Vision => "USB3Vision";

		public string GigEVision => "GigEVision";

		public string CoaXPress => "CoaXPress";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class DeviceTapGeometryEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/DeviceTapGeometry";

		public string Geometry_1X_1Y => "Geometry_1X_1Y";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class DeviceTemperatureSelectorEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/DeviceTemperatureSelector";

		public string Sensorboard => "Sensorboard";

		public string Sensor => "Sensor";

		public string Illumination => "Illumination";

		public string Framegrabberboard => "Framegrabberboard";

		public string FpgaCore => "FpgaCore";

		public string Coreboard => "Coreboard";

		public string Camera => "Camera";

		public string CPU => "CPU";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class DeviceTypeEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/DeviceType";

		public string Transmitter => "Transmitter";

		public string Transceiver => "Transceiver";

		public string Receiver => "Receiver";

		public string Peripheral => "Peripheral";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class EventNotificationEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/EventNotification";

		public string Once => "Once";

		public string On => "On";

		public string Off => "Off";

		public string GenICamEvent => "GenICamEvent";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class EventSelectorEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/EventSelector";

		public string VirtualLine4RisingEdge => "VirtualLine4RisingEdge";

		public string VirtualLine3RisingEdge => "VirtualLine3RisingEdge";

		public string VirtualLine2RisingEdge => "VirtualLine2RisingEdge";

		public string VirtualLine1RisingEdge => "VirtualLine1RisingEdge";

		public string Test => "Test";

		public string TemperatureStatusChanged => "TemperatureStatusChanged";

		public string Overrun => "Overrun";

		public string OverTemperature => "OverTemperature";

		public string LineStartOvertrigger => "LineStartOvertrigger";

		public string Line4RisingEdge => "Line4RisingEdge";

		public string Line3RisingEdge => "Line3RisingEdge";

		public string Line2RisingEdge => "Line2RisingEdge";

		public string Line1RisingEdge => "Line1RisingEdge";

		public string FrameWait => "FrameWait";

		public string FrameTriggerMissed => "FrameTriggerMissed";

		public string FrameTimeout => "FrameTimeout";

		public string FrameStartWait => "FrameStartWait";

		public string FrameStartOvertrigger => "FrameStartOvertrigger";

		public string FrameStart => "FrameStart";

		public string FrameBurstStartWait => "FrameBurstStartWait";

		public string FrameBurstStartOvertrigger => "FrameBurstStartOvertrigger";

		public string FrameBurstStart => "FrameBurstStart";

		public string FrameBufferOverrun => "FrameBufferOverrun";

		public string ExposureEnd => "ExposureEnd";

		public string EventOverrun => "EventOverrun";

		public string CriticalTemperature => "CriticalTemperature";

		public string ActionLate => "ActionLate";

		public string AcquisitionWait => "AcquisitionWait";

		public string AcquisitionStartWait => "AcquisitionStartWait";

		public string AcquisitionStartOvertrigger => "AcquisitionStartOvertrigger";

		public string AcquisitionStart => "AcquisitionStart";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class EventTemperatureStatusChangedStatusEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/EventTemperatureStatusChangedStatus";

		public string Ok => "Ok";

		public string Error => "Error";

		public string Critical => "Critical";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class ExpertFeatureAccessSelectorEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/ExpertFeatureAccessSelector";

		public string ExpertFeature9 => "ExpertFeature9";

		public string ExpertFeature8 => "ExpertFeature8";

		public string ExpertFeature7 => "ExpertFeature7";

		public string ExpertFeature6 => "ExpertFeature6";

		public string ExpertFeature5 => "ExpertFeature5";

		public string ExpertFeature4 => "ExpertFeature4";

		public string ExpertFeature3 => "ExpertFeature3";

		public string ExpertFeature2 => "ExpertFeature2";

		public string ExpertFeature1_Legacy => "ExpertFeature1_Legacy";

		public string ExpertFeature11 => "ExpertFeature11";

		public string ExpertFeature10 => "ExpertFeature10";

		public string ExpertFeature1 => "ExpertFeature1";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class ExposureAutoEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/ExposureAuto";

		public string Once => "Once";

		public string Off => "Off";

		public string Continuous => "Continuous";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class ExposureModeEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/ExposureMode";

		public string TriggerWidth => "TriggerWidth";

		public string TriggerControlled => "TriggerControlled";

		public string Timed => "Timed";

		public string Off => "Off";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class ExposureOverlapTimeModeEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/ExposureOverlapTimeMode";

		public string Manual => "Manual";

		public string Automatic => "Automatic";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class ExposureTimeModeEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/ExposureTimeMode";

		public string UltraShort => "UltraShort";

		public string Standard => "Standard";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class FeatureSetEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/FeatureSet";

		public string Full => "Full";

		public string Basic => "Basic";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class FieldOutputModeEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/FieldOutputMode";

		public string Field1 => "Field1";

		public string Field0First => "Field0First";

		public string Field0 => "Field0";

		public string DeinterlacedNewFields => "DeinterlacedNewFields";

		public string ConcatenatedNewFields => "ConcatenatedNewFields";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class FileOpenModeEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/FileOpenMode";

		public string Write => "Write";

		public string Read => "Read";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class FileOperationSelectorEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/FileOperationSelector";

		public string Write => "Write";

		public string Read => "Read";

		public string Open => "Open";

		public string Close => "Close";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class FileOperationStatusEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/FileOperationStatus";

		public string Success => "Success";

		public string Failure => "Failure";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class FileSelectorEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/FileSelector";

		public string VignettingCorrection => "VignettingCorrection";

		public string UserSet3 => "UserSet3";

		public string UserSet2 => "UserSet2";

		public string UserSet1 => "UserSet1";

		public string UserOffsetShading2 => "UserOffsetShading2";

		public string UserOffsetShading1 => "UserOffsetShading1";

		public string UserGainShading2 => "UserGainShading2";

		public string UserGainShading1 => "UserGainShading1";

		public string UserData => "UserData";

		public string None => "None";

		public string FirmwareUpdatePackage => "FirmwareUpdatePackage";

		public string FirmwareUpdate => "FirmwareUpdate";

		public string ExpertFeature7File => "ExpertFeature7File";

		public string BootUpdatePackage => "BootUpdatePackage";

		public string BootUpdate => "BootUpdate";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class FrequencyConverterInputSourceEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/FrequencyConverterInputSource";

		public string ShaftEncoderModuleOut => "ShaftEncoderModuleOut";

		public string Line8 => "Line8";

		public string Line7 => "Line7";

		public string Line6 => "Line6";

		public string Line5 => "Line5";

		public string Line4 => "Line4";

		public string Line3 => "Line3";

		public string Line2 => "Line2";

		public string Line1 => "Line1";

		public string CC4 => "CC4";

		public string CC3 => "CC3";

		public string CC2 => "CC2";

		public string CC1 => "CC1";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class FrequencyConverterSignalAlignmentEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/FrequencyConverterSignalAlignment";

		public string RisingEdge => "RisingEdge";

		public string FallingEdge => "FallingEdge";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class GainAutoEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/GainAuto";

		public string Once => "Once";

		public string Off => "Off";

		public string Continuous => "Continuous";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class GainSelectorEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/GainSelector";

		public string Tap4 => "Tap4";

		public string Tap3 => "Tap3";

		public string Tap2 => "Tap2";

		public string Tap1 => "Tap1";

		public string Red => "Red";

		public string Green => "Green";

		public string DigitalAll => "DigitalAll";

		public string Blue => "Blue";

		public string AnalogAll => "AnalogAll";

		public string All => "All";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class GammaSelectorEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/GammaSelector";

		public string sRGB => "sRGB";

		public string User => "User";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class GenDCStreamingModeEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/GenDCStreamingMode";

		public string On => "On";

		public string Off => "Off";

		public string Automatic => "Automatic";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class GenDCStreamingStatusEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/GenDCStreamingStatus";

		public string On => "On";

		public string Off => "Off";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class GevCCPEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/GevCCP";

		public string ExclusiveControl => "ExclusiveControl";

		public string Exclusive => "Exclusive";

		public string Control => "Control";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class GevGVSPExtendedIDModeEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/GevGVSPExtendedIDMode";

		public string On => "On";

		public string Off => "Off";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class GevIEEE1588StatusEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/GevIEEE1588Status";

		public string Undefined => "Undefined";

		public string Uncalibrated => "Uncalibrated";

		public string Slave => "Slave";

		public string PreMaster => "PreMaster";

		public string Passive => "Passive";

		public string Master => "Master";

		public string Listening => "Listening";

		public string Initializing => "Initializing";

		public string Faulty => "Faulty";

		public string Disabled => "Disabled";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class GevIEEE1588StatusLatchedEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/GevIEEE1588StatusLatched";

		public string Undefined => "Undefined";

		public string Uncalibrated => "Uncalibrated";

		public string Slave => "Slave";

		public string PreMaster => "PreMaster";

		public string Passive => "Passive";

		public string Master => "Master";

		public string Listening => "Listening";

		public string Initializing => "Initializing";

		public string Faulty => "Faulty";

		public string Disabled => "Disabled";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class GevInterfaceSelectorEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/GevInterfaceSelector";

		public string NetworkInterface0 => "NetworkInterface0";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class GevStreamChannelSelectorEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/GevStreamChannelSelector";

		public string StreamChannel0 => "StreamChannel0";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class ImageCompressionModeEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/ImageCompressionMode";

		public string Off => "Off";

		public string BaslerCompressionBeyond => "BaslerCompressionBeyond";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class ImageCompressionRateOptionEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/ImageCompressionRateOption";

		public string Lossless => "Lossless";

		public string FixRatio => "FixRatio";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class ImageFileModeEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/ImageFileMode";

		public string On => "On";

		public string Off => "Off";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class IntensityCalculationEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/IntensityCalculation";

		public string Method2 => "Method2";

		public string Method1 => "Method1";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class InterlacedIntegrationModeEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/InterlacedIntegrationMode";

		public string FrameIntegration => "FrameIntegration";

		public string FieldIntegration => "FieldIntegration";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class LUTSelectorEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/LUTSelector";

		public string Luminance => "Luminance";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class LastErrorEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/LastError";

		public string Userset => "Userset";

		public string UserDefPixFailure => "UserDefPixFailure";

		public string PowerFailure => "PowerFailure";

		public string Overtrigger => "Overtrigger";

		public string OverTemperature => "OverTemperature";

		public string NoError => "NoError";

		public string InvalidParameter => "InvalidParameter";

		public string InsufficientTriggerWidth => "InsufficientTriggerWidth";

		public string Illumination => "Illumination";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class LegacyBinningVerticalEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/LegacyBinningVertical";

		public string Two_Rows => "Two_Rows";

		public string Off => "Off";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class LightSourcePresetEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/LightSourcePreset";

		public string Tungsten2800K => "Tungsten2800K";

		public string Off => "Off";

		public string MicroscopeLED6000K => "MicroscopeLED6000K";

		public string MicroscopeLED5500K => "MicroscopeLED5500K";

		public string MicroscopeLED4500K => "MicroscopeLED4500K";

		public string Daylight6500K => "Daylight6500K";

		public string Daylight5000K => "Daylight5000K";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class LightSourceSelectorEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/LightSourceSelector";

		public string Tungsten => "Tungsten";

		public string Off => "Off";

		public string MicroscopeLED6000K => "MicroscopeLED6000K";

		public string MicroscopeLED5500K => "MicroscopeLED5500K";

		public string MicroscopeLED4500K => "MicroscopeLED4500K";

		public string LightSource1 => "LightSource1";

		public string LightSource0 => "LightSource0";

		public string Daylight6500K => "Daylight6500K";

		public string Daylight => "Daylight";

		public string Custom => "Custom";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class LineFormatEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/LineFormat";

		public string TriState => "TriState";

		public string TTL => "TTL";

		public string RS422 => "RS422";

		public string OptoCoupled => "OptoCoupled";

		public string OpenDrain => "OpenDrain";

		public string NoConnect => "NoConnect";

		public string LVTTL => "LVTTL";

		public string LVDS => "LVDS";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class LineLogicEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/LineLogic";

		public string Positive => "Positive";

		public string Negative => "Negative";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class LineModeEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/LineMode";

		public string Output => "Output";

		public string Input => "Input";

		public string InOut => "InOut";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class LineSelectorEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/LineSelector";

		public string Out4 => "Out4";

		public string Out3 => "Out3";

		public string Out2 => "Out2";

		public string Out1 => "Out1";

		public string Line8 => "Line8";

		public string Line7 => "Line7";

		public string Line6 => "Line6";

		public string Line5 => "Line5";

		public string Line4 => "Line4";

		public string Line3 => "Line3";

		public string Line2 => "Line2";

		public string Line1 => "Line1";

		public string In4 => "In4";

		public string In3 => "In3";

		public string In2 => "In2";

		public string In1 => "In1";

		public string ClSpare => "ClSpare";

		public string CC4 => "CC4";

		public string CC3 => "CC3";

		public string CC2 => "CC2";

		public string CC1 => "CC1";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class LineSourceEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/LineSource";

		public string UserOutput4 => "UserOutput4";

		public string UserOutput3 => "UserOutput3";

		public string UserOutput2 => "UserOutput2";

		public string UserOutput1 => "UserOutput1";

		public string UserOutput0 => "UserOutput0";

		public string UserOutput => "UserOutput";

		public string TriggerReady => "TriggerReady";

		public string TimerActive => "TimerActive";

		public string Timer4Active => "Timer4Active";

		public string Timer3Active => "Timer3Active";

		public string Timer2Active => "Timer2Active";

		public string Timer1Active => "Timer1Active";

		public string SyncUserOutput3 => "SyncUserOutput3";

		public string SyncUserOutput2 => "SyncUserOutput2";

		public string SyncUserOutput1 => "SyncUserOutput1";

		public string SyncUserOutput0 => "SyncUserOutput0";

		public string SyncUserOutput => "SyncUserOutput";

		public string ShaftEncoderModuleOut => "ShaftEncoderModuleOut";

		public string SerialTx => "SerialTx";

		public string PatternGenerator4 => "PatternGenerator4";

		public string PatternGenerator3 => "PatternGenerator3";

		public string PatternGenerator2 => "PatternGenerator2";

		public string PatternGenerator1 => "PatternGenerator1";

		public string Off => "Off";

		public string LineTriggerWait => "LineTriggerWait";

		public string FrequencyConverter => "FrequencyConverter";

		public string FrameTriggerWait => "FrameTriggerWait";

		public string FrameCycle => "FrameCycle";

		public string FrameBurstTriggerWait => "FrameBurstTriggerWait";

		public string FrameBurstActive => "FrameBurstActive";

		public string FlashWindow => "FlashWindow";

		public string ExposureTriggerWait => "ExposureTriggerWait";

		public string ExposureActive => "ExposureActive";

		public string Counter2Active => "Counter2Active";

		public string Counter1Active => "Counter1Active";

		public string BslLightControl => "BslLightControl";

		public string AcquisitionTriggerWait => "AcquisitionTriggerWait";

		public string AcquisitionTriggerReady => "AcquisitionTriggerReady";

		public string AcquisitionActive => "AcquisitionActive";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class OperatingModeEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/OperatingMode";

		public string ShortRange => "ShortRange";

		public string LongRange => "LongRange";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class OverlapModeEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/OverlapMode";

		public string On => "On";

		public string Off => "Off";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class ParameterSelectorEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/ParameterSelector";

		public string Gain => "Gain";

		public string Framerate => "Framerate";

		public string ExposureTime => "ExposureTime";

		public string ExposureOverlapMax => "ExposureOverlapMax";

		public string ExposureOverhead => "ExposureOverhead";

		public string Brightness => "Brightness";

		public string BlackLevel => "BlackLevel";

		public string AutoTargetValue => "AutoTargetValue";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class PgiModeEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/PgiMode";

		public string On => "On";

		public string Off => "Off";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class PixelCodingEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/PixelCoding";

		public string YUV444 => "YUV444";

		public string YUV422 => "YUV422";

		public string YUV411 => "YUV411";

		public string Raw8 => "Raw8";

		public string Raw16 => "Raw16";

		public string RGBA8 => "RGBA8";

		public string RGB8Planar => "RGB8Planar";

		public string RGB8 => "RGB8";

		public string RGB16Planar => "RGB16Planar";

		public string RGB16 => "RGB16";

		public string RGB10V2Packed => "RGB10V2Packed";

		public string RGB10V1Packed => "RGB10V1Packed";

		public string Mono8Signed => "Mono8Signed";

		public string Mono8 => "Mono8";

		public string Mono16 => "Mono16";

		public string Mono12Packed => "Mono12Packed";

		public string Mono10Packed => "Mono10Packed";

		public string BayerRG10p => "BayerRG10p";

		public string BayerGR10p => "BayerGR10p";

		public string BayerGB10p => "BayerGB10p";

		public string BayerBG10p => "BayerBG10p";

		public string BGRA8 => "BGRA8";

		public string BGR8 => "BGR8";

		public string BGR16 => "BGR16";

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

		public string Bayer_RG => "Bayer_RG";

		public string Bayer_GR => "Bayer_GR";

		public string Bayer_GB => "Bayer_GB";

		public string Bayer_BG => "Bayer_BG";

		public string BayerRG => "BayerRG";

		public string BayerGR => "BayerGR";

		public string BayerGB => "BayerGB";

		public string BayerBG => "BayerBG";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class PixelFormatEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/PixelFormat";

		public string YUV444Packed => "YUV444Packed";

		public string YUV422_YUYV_Packed => "YUV422_YUYV_Packed";

		public string YUV422_8 => "YUV422_8";

		public string YUV422Packed => "YUV422Packed";

		public string YUV411Packed => "YUV411Packed";

		public string YCbCr422_8 => "YCbCr422_8";

		public string RGBA8Packed => "RGBA8Packed";

		public string RGB8Planar => "RGB8Planar";

		public string RGB8Packed => "RGB8Packed";

		public string RGB8 => "RGB8";

		public string RGB16Planar => "RGB16Planar";

		public string RGB16Packed => "RGB16Packed";

		public string RGB12V1Packed => "RGB12V1Packed";

		public string RGB12Planar => "RGB12Planar";

		public string RGB12Packed => "RGB12Packed";

		public string RGB10V2Packed => "RGB10V2Packed";

		public string RGB10V1Packed => "RGB10V1Packed";

		public string RGB10Planar => "RGB10Planar";

		public string RGB10Packed => "RGB10Packed";

		public string Mono8Signed => "Mono8Signed";

		public string Mono8 => "Mono8";

		public string Mono16 => "Mono16";

		public string Mono12p => "Mono12p";

		public string Mono12Packed => "Mono12Packed";

		public string Mono12 => "Mono12";

		public string Mono10p => "Mono10p";

		public string Mono10Packed => "Mono10Packed";

		public string Mono10 => "Mono10";

		public string Coord3D_C16 => "Coord3D_C16";

		public string Coord3D_ABC32f => "Coord3D_ABC32f";

		public string Confidence8 => "Confidence8";

		public string Confidence16 => "Confidence16";

		public string BayerRG8 => "BayerRG8";

		public string BayerRG16 => "BayerRG16";

		public string BayerRG12p => "BayerRG12p";

		public string BayerRG12Packed => "BayerRG12Packed";

		public string BayerRG12 => "BayerRG12";

		public string BayerRG10p => "BayerRG10p";

		public string BayerRG10 => "BayerRG10";

		public string BayerGR8 => "BayerGR8";

		public string BayerGR16 => "BayerGR16";

		public string BayerGR12p => "BayerGR12p";

		public string BayerGR12Packed => "BayerGR12Packed";

		public string BayerGR12 => "BayerGR12";

		public string BayerGR10p => "BayerGR10p";

		public string BayerGR10 => "BayerGR10";

		public string BayerGB8 => "BayerGB8";

		public string BayerGB16 => "BayerGB16";

		public string BayerGB12p => "BayerGB12p";

		public string BayerGB12Packed => "BayerGB12Packed";

		public string BayerGB12 => "BayerGB12";

		public string BayerGB10p => "BayerGB10p";

		public string BayerGB10 => "BayerGB10";

		public string BayerBG8 => "BayerBG8";

		public string BayerBG16 => "BayerBG16";

		public string BayerBG12p => "BayerBG12p";

		public string BayerBG12Packed => "BayerBG12Packed";

		public string BayerBG12 => "BayerBG12";

		public string BayerBG10p => "BayerBG10p";

		public string BayerBG10 => "BayerBG10";

		public string BGRA8Packed => "BGRA8Packed";

		public string BGR8Packed => "BGR8Packed";

		public string BGR8 => "BGR8";

		public string BGR12Packed => "BGR12Packed";

		public string BGR10Packed => "BGR10Packed";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class PixelSizeEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/PixelSize";

		public string Bpp8 => "Bpp8";

		public string Bpp64 => "Bpp64";

		public string Bpp48 => "Bpp48";

		public string Bpp4 => "Bpp4";

		public string Bpp36 => "Bpp36";

		public string Bpp32 => "Bpp32";

		public string Bpp24 => "Bpp24";

		public string Bpp2 => "Bpp2";

		public string Bpp16 => "Bpp16";

		public string Bpp14 => "Bpp14";

		public string Bpp12 => "Bpp12";

		public string Bpp10 => "Bpp10";

		public string Bpp1 => "Bpp1";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class PtpClockAccuracyEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/PtpClockAccuracy";

		public string Within2p5us => "Within2p5us";

		public string Within2p5ms => "Within2p5ms";

		public string Within25us => "Within25us";

		public string Within25ns => "Within25ns";

		public string Within25ms => "Within25ms";

		public string Within250us => "Within250us";

		public string Within250ns => "Within250ns";

		public string Within250ms => "Within250ms";

		public string Within1us => "Within1us";

		public string Within1s => "Within1s";

		public string Within1ms => "Within1ms";

		public string Within10us => "Within10us";

		public string Within10s => "Within10s";

		public string Within10ms => "Within10ms";

		public string Within100us => "Within100us";

		public string Within100ns => "Within100ns";

		public string Within100ms => "Within100ms";

		public string Unknown => "Unknown";

		public string GreaterThan10s => "GreaterThan10s";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class PtpServoStatusEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/PtpServoStatus";

		public string Unknown => "Unknown";

		public string Locked => "Locked";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class PtpStatusEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/PtpStatus";

		public string Uncalibrated => "Uncalibrated";

		public string Slave => "Slave";

		public string PreMaster => "PreMaster";

		public string Passive => "Passive";

		public string Master => "Master";

		public string Listening => "Listening";

		public string Initializing => "Initializing";

		public string Faulty => "Faulty";

		public string Disabled => "Disabled";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class ROIZoneModeEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/ROIZoneMode";

		public string On => "On";

		public string Off => "Off";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class ROIZoneSelectorEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/ROIZoneSelector";

		public string Zone7 => "Zone7";

		public string Zone6 => "Zone6";

		public string Zone5 => "Zone5";

		public string Zone4 => "Zone4";

		public string Zone3 => "Zone3";

		public string Zone2 => "Zone2";

		public string Zone1 => "Zone1";

		public string Zone0 => "Zone0";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class RemoveParameterLimitSelectorEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/RemoveParameterLimitSelector";

		public string Gain => "Gain";

		public string ExposureTime => "ExposureTime";

		public string ExposureOverhead => "ExposureOverhead";

		public string BlackLevel => "BlackLevel";

		public string AutoTargetValue => "AutoTargetValue";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class Scan3dCoordinateSelectorEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/Scan3dCoordinateSelector";

		public string CoordinateC => "CoordinateC";

		public string CoordinateB => "CoordinateB";

		public string CoordinateA => "CoordinateA";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class Scan3dCoordinateSystemEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/Scan3dCoordinateSystem";

		public string Cartesian => "Cartesian";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class Scan3dCoordinateSystemReferenceEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/Scan3dCoordinateSystemReference";

		public string Anchor => "Anchor";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class Scan3dDistanceUnitEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/Scan3dDistanceUnit";

		public string Millimeter => "Millimeter";

		public string DeviceSpecific => "DeviceSpecific";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class Scan3dOutputModeEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/Scan3dOutputMode";

		public string UncalibratedC => "UncalibratedC";

		public string CalibratedC => "CalibratedC";

		public string CalibratedABC_Grid => "CalibratedABC_Grid";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class SensorBitDepthEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/SensorBitDepth";

		public string BitDepth8 => "BitDepth8";

		public string BitDepth16 => "BitDepth16";

		public string BitDepth14 => "BitDepth14";

		public string BitDepth12 => "BitDepth12";

		public string BitDepth10 => "BitDepth10";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class SensorDigitizationTapsEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/SensorDigitizationTaps";

		public string Two => "Two";

		public string Three => "Three";

		public string One => "One";

		public string Four => "Four";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class SensorReadoutModeEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/SensorReadoutMode";

		public string Normal => "Normal";

		public string Fast => "Fast";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class SensorShutterModeEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/SensorShutterMode";

		public string Rolling => "Rolling";

		public string GlobalReset => "GlobalReset";

		public string Global => "Global";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class SequenceAddressBitSelectorEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/SequenceAddressBitSelector";

		public string Bit3 => "Bit3";

		public string Bit2 => "Bit2";

		public string Bit1 => "Bit1";

		public string Bit0 => "Bit0";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class SequenceAddressBitSourceEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/SequenceAddressBitSource";

		public string VInputDecActive => "VInputDecActive";

		public string VInput4 => "VInput4";

		public string VInput3 => "VInput3";

		public string VInput2 => "VInput2";

		public string VInput1 => "VInput1";

		public string Line8 => "Line8";

		public string Line7 => "Line7";

		public string Line6 => "Line6";

		public string Line5 => "Line5";

		public string Line4 => "Line4";

		public string Line3 => "Line3";

		public string Line2 => "Line2";

		public string Line1 => "Line1";

		public string CC4 => "CC4";

		public string CC3 => "CC3";

		public string CC2 => "CC2";

		public string CC1 => "CC1";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class SequenceAdvanceModeEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/SequenceAdvanceMode";

		public string FreeSelection => "FreeSelection";

		public string Controlled => "Controlled";

		public string Auto => "Auto";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class SequenceConfigurationModeEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/SequenceConfigurationMode";

		public string On => "On";

		public string Off => "Off";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class SequenceControlSelectorEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/SequenceControlSelector";

		public string Restart => "Restart";

		public string Advance => "Advance";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class SequenceControlSourceEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/SequenceControlSource";

		public string VInputDecActive => "VInputDecActive";

		public string VInput4 => "VInput4";

		public string VInput3 => "VInput3";

		public string VInput2 => "VInput2";

		public string VInput1 => "VInput1";

		public string Line8 => "Line8";

		public string Line7 => "Line7";

		public string Line6 => "Line6";

		public string Line5 => "Line5";

		public string Line4 => "Line4";

		public string Line3 => "Line3";

		public string Line2 => "Line2";

		public string Line1 => "Line1";

		public string Disabled => "Disabled";

		public string CC4 => "CC4";

		public string CC3 => "CC3";

		public string CC2 => "CC2";

		public string CC1 => "CC1";

		public string AlwaysActive => "AlwaysActive";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class SequencerConfigurationModeEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/SequencerConfigurationMode";

		public string On => "On";

		public string Off => "Off";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class SequencerModeEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/SequencerMode";

		public string On => "On";

		public string Off => "Off";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class SequencerTriggerActivationEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/SequencerTriggerActivation";

		public string RisingEdge => "RisingEdge";

		public string LevelLow => "LevelLow";

		public string LevelHigh => "LevelHigh";

		public string FallingEdge => "FallingEdge";

		public string AnyEdge => "AnyEdge";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class SequencerTriggerSourceEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/SequencerTriggerSource";

		public string SoftwareSignal3 => "SoftwareSignal3";

		public string SoftwareSignal2 => "SoftwareSignal2";

		public string SoftwareSignal1 => "SoftwareSignal1";

		public string Line4 => "Line4";

		public string Line3 => "Line3";

		public string Line2 => "Line2";

		public string Line1 => "Line1";

		public string FrameStart => "FrameStart";

		public string FrameEnd => "FrameEnd";

		public string Counter3End => "Counter3End";

		public string Counter2End => "Counter2End";

		public string Counter1End => "Counter1End";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class ShadingSelectorEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/ShadingSelector";

		public string OffsetShading => "OffsetShading";

		public string GainShading => "GainShading";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class ShadingSetCreateEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/ShadingSetCreate";

		public string Once => "Once";

		public string Off => "Off";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class ShadingSetDefaultSelectorEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/ShadingSetDefaultSelector";

		public string UserShadingSet2 => "UserShadingSet2";

		public string UserShadingSet1 => "UserShadingSet1";

		public string DefaultShadingSet => "DefaultShadingSet";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class ShadingSetSelectorEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/ShadingSetSelector";

		public string UserShadingSet2 => "UserShadingSet2";

		public string UserShadingSet1 => "UserShadingSet1";

		public string DefaultShadingSet => "DefaultShadingSet";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class ShadingStatusEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/ShadingStatus";

		public string StartupSetError => "StartupSetError";

		public string NoError => "NoError";

		public string CreateError => "CreateError";

		public string ActivateError => "ActivateError";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class ShaftEncoderModuleCounterModeEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/ShaftEncoderModuleCounterMode";

		public string IgnoreDirection => "IgnoreDirection";

		public string FollowDirection => "FollowDirection";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class ShaftEncoderModuleLineSelectorEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/ShaftEncoderModuleLineSelector";

		public string PhaseB => "PhaseB";

		public string PhaseA => "PhaseA";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class ShaftEncoderModuleLineSourceEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/ShaftEncoderModuleLineSource";

		public string Line8 => "Line8";

		public string Line7 => "Line7";

		public string Line6 => "Line6";

		public string Line5 => "Line5";

		public string Line4 => "Line4";

		public string Line3 => "Line3";

		public string Line2 => "Line2";

		public string Line1 => "Line1";

		public string CC4 => "CC4";

		public string CC3 => "CC3";

		public string CC2 => "CC2";

		public string CC1 => "CC1";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class ShaftEncoderModuleModeEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/ShaftEncoderModuleMode";

		public string ForwardOnly => "ForwardOnly";

		public string AnyDirection => "AnyDirection";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class ShutterModeEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/ShutterMode";

		public string Rolling => "Rolling";

		public string GlobalResetRelease => "GlobalResetRelease";

		public string Global => "Global";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class SoftwareSignalSelectorEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/SoftwareSignalSelector";

		public string SoftwareSignal4 => "SoftwareSignal4";

		public string SoftwareSignal3 => "SoftwareSignal3";

		public string SoftwareSignal2 => "SoftwareSignal2";

		public string SoftwareSignal1 => "SoftwareSignal1";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class SyncUserOutputSelectorEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/SyncUserOutputSelector";

		public string SyncUserOutputLine4 => "SyncUserOutputLine4";

		public string SyncUserOutputLine3 => "SyncUserOutputLine3";

		public string SyncUserOutputLine2 => "SyncUserOutputLine2";

		public string SyncUserOutputLine1 => "SyncUserOutputLine1";

		public string SyncUserOutputClSpare => "SyncUserOutputClSpare";

		public string SyncUserOutputCC4 => "SyncUserOutputCC4";

		public string SyncUserOutputCC3 => "SyncUserOutputCC3";

		public string SyncUserOutputCC2 => "SyncUserOutputCC2";

		public string SyncUserOutputCC1 => "SyncUserOutputCC1";

		public string SyncUserOutput8 => "SyncUserOutput8";

		public string SyncUserOutput7 => "SyncUserOutput7";

		public string SyncUserOutput6 => "SyncUserOutput6";

		public string SyncUserOutput5 => "SyncUserOutput5";

		public string SyncUserOutput4 => "SyncUserOutput4";

		public string SyncUserOutput3 => "SyncUserOutput3";

		public string SyncUserOutput2 => "SyncUserOutput2";

		public string SyncUserOutput1 => "SyncUserOutput1";

		public string SyncUserOutput0 => "SyncUserOutput0";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class TemperatureSelectorEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/TemperatureSelector";

		public string Sensorboard => "Sensorboard";

		public string Framegrabberboard => "Framegrabberboard";

		public string Coreboard => "Coreboard";

		public string Case => "Case";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class TemperatureStateEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/TemperatureState";

		public string Ok => "Ok";

		public string Error => "Error";

		public string Critical => "Critical";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class TestImageSelectorEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/TestImageSelector";

		public string White => "White";

		public string VerticalLineMoving => "VerticalLineMoving";

		public string Testimage7 => "Testimage7";

		public string Testimage6 => "Testimage6";

		public string Testimage5 => "Testimage5";

		public string Testimage4 => "Testimage4";

		public string Testimage3 => "Testimage3";

		public string Testimage2 => "Testimage2";

		public string Testimage1 => "Testimage1";

		public string Off => "Off";

		public string MovingDiagonalGrayGradient_8Bit => "MovingDiagonalGrayGradient_8Bit";

		public string MovingDiagonalGrayGradient_12Bit => "MovingDiagonalGrayGradient_12Bit";

		public string MovingDiagonalGrayGradientFeatureTest_8Bit => "MovingDiagonalGrayGradientFeatureTest_8Bit";

		public string MovingDiagonalGrayGradientFeatureTest_12Bit => "MovingDiagonalGrayGradientFeatureTest_12Bit";

		public string MovingDiagonalColorGradient => "MovingDiagonalColorGradient";

		public string HorzontalLineMoving => "HorzontalLineMoving";

		public string GreyVerticalRampMoving => "GreyVerticalRampMoving";

		public string GreyVerticalRamp => "GreyVerticalRamp";

		public string GreyHorizontalRampMoving => "GreyHorizontalRampMoving";

		public string GreyHorizontalRamp => "GreyHorizontalRamp";

		public string FrameCounter => "FrameCounter";

		public string FixedDiagonalGrayGradient_8Bit => "FixedDiagonalGrayGradient_8Bit";

		public string DeviceSpecific => "DeviceSpecific";

		public string ColorBar => "ColorBar";

		public string Black => "Black";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class TestPatternEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/TestPattern";

		public string White => "White";

		public string Testimage6 => "Testimage6";

		public string Testimage3 => "Testimage3";

		public string Testimage2 => "Testimage2";

		public string Testimage1 => "Testimage1";

		public string Off => "Off";

		public string GreyDiagonalSawtooth8 => "GreyDiagonalSawtooth8";

		public string ColorDiagonalSawtooth8 => "ColorDiagonalSawtooth8";

		public string Black => "Black";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class TimerSelectorEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/TimerSelector";

		public string Timer4 => "Timer4";

		public string Timer3 => "Timer3";

		public string Timer2 => "Timer2";

		public string Timer1 => "Timer1";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class TimerSequenceEntrySelectorEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/TimerSequenceEntrySelector";

		public string Entry9 => "Entry9";

		public string Entry8 => "Entry8";

		public string Entry7 => "Entry7";

		public string Entry6 => "Entry6";

		public string Entry5 => "Entry5";

		public string Entry4 => "Entry4";

		public string Entry3 => "Entry3";

		public string Entry2 => "Entry2";

		public string Entry16 => "Entry16";

		public string Entry15 => "Entry15";

		public string Entry14 => "Entry14";

		public string Entry13 => "Entry13";

		public string Entry12 => "Entry12";

		public string Entry11 => "Entry11";

		public string Entry10 => "Entry10";

		public string Entry1 => "Entry1";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class TimerSequenceTimerSelectorEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/TimerSequenceTimerSelector";

		public string Timer4 => "Timer4";

		public string Timer3 => "Timer3";

		public string Timer2 => "Timer2";

		public string Timer1 => "Timer1";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class TimerStatusEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/TimerStatus";

		public string TimerTriggerWait => "TimerTriggerWait";

		public string TimerIdle => "TimerIdle";

		public string TimerActive => "TimerActive";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class TimerTriggerActivationEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/TimerTriggerActivation";

		public string RisingEdge => "RisingEdge";

		public string LevelLow => "LevelLow";

		public string LevelHigh => "LevelHigh";

		public string FallingEdge => "FallingEdge";

		public string AnyEdge => "AnyEdge";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class TimerTriggerSourceEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/TimerTriggerSource";

		public string Timer2End => "Timer2End";

		public string Timer2Active => "Timer2Active";

		public string Timer1End => "Timer1End";

		public string Timer1Active => "Timer1Active";

		public string SoftwareSignal3 => "SoftwareSignal3";

		public string SoftwareSignal2 => "SoftwareSignal2";

		public string SoftwareSignal1 => "SoftwareSignal1";

		public string PeriodicSignal1 => "PeriodicSignal1";

		public string Off => "Off";

		public string Line4 => "Line4";

		public string Line3 => "Line3";

		public string Line2 => "Line2";

		public string Line1 => "Line1";

		public string FrameTriggerWait => "FrameTriggerWait";

		public string FrameBurstTriggerWait => "FrameBurstTriggerWait";

		public string FrameBurstActive => "FrameBurstActive";

		public string FlashWindowStart => "FlashWindowStart";

		public string ExposureTriggerWait => "ExposureTriggerWait";

		public string ExposureStart => "ExposureStart";

		public string ExposureActive => "ExposureActive";

		public string CxpTrigger1 => "CxpTrigger1";

		public string CxpTrigger0 => "CxpTrigger0";

		public string Counter2Start => "Counter2Start";

		public string Counter2End => "Counter2End";

		public string Counter2Active => "Counter2Active";

		public string Counter1Start => "Counter1Start";

		public string Counter1End => "Counter1End";

		public string Counter1Active => "Counter1Active";

		public string Action2 => "Action2";

		public string Action1 => "Action1";

		public string AcquisitionActive => "AcquisitionActive";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class TonalRangeAutoEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/TonalRangeAuto";

		public string Once => "Once";

		public string Off => "Off";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class TonalRangeEnableEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/TonalRangeEnable";

		public string On => "On";

		public string Off => "Off";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class TonalRangeSelectorEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/TonalRangeSelector";

		public string Sum => "Sum";

		public string Red => "Red";

		public string Green => "Green";

		public string Blue => "Blue";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class TriggerActivationEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/TriggerActivation";

		public string RisingEdge => "RisingEdge";

		public string LevelLow => "LevelLow";

		public string LevelHigh => "LevelHigh";

		public string FallingEdge => "FallingEdge";

		public string AnyEdge => "AnyEdge";

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
	public class TriggerDelaySourceEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/TriggerDelaySource";

		public string Time_us => "Time_us";

		public string LineTrigger => "LineTrigger";

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
	public class TriggerSelectorEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/TriggerSelector";

		public string LineStart => "LineStart";

		public string FrameStart => "FrameStart";

		public string FrameEnd => "FrameEnd";

		public string FrameBurstStart => "FrameBurstStart";

		public string FrameBurstEnd => "FrameBurstEnd";

		public string FrameBurstActive => "FrameBurstActive";

		public string FrameActive => "FrameActive";

		public string ExposureStart => "ExposureStart";

		public string ExposureEnd => "ExposureEnd";

		public string ExposureActive => "ExposureActive";

		public string AcquisitionStart => "AcquisitionStart";

		public string AcquisitionEnd => "AcquisitionEnd";

		public string AcquisitionActive => "AcquisitionActive";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class TriggerSourceEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/TriggerSource";

		public string VInputDecActive => "VInputDecActive";

		public string VInput4 => "VInput4";

		public string VInput3 => "VInput3";

		public string VInput2 => "VInput2";

		public string VInput1 => "VInput1";

		public string UserOutput2 => "UserOutput2";

		public string UserOutput1 => "UserOutput1";

		public string Timer2End => "Timer2End";

		public string Timer2Active => "Timer2Active";

		public string Timer1Start => "Timer1Start";

		public string Timer1End => "Timer1End";

		public string Timer1Active => "Timer1Active";

		public string SoftwareSignal3 => "SoftwareSignal3";

		public string SoftwareSignal2 => "SoftwareSignal2";

		public string SoftwareSignal1 => "SoftwareSignal1";

		public string Software => "Software";

		public string ShaftEncoderModuleOut => "ShaftEncoderModuleOut";

		public string PeriodicSignal1 => "PeriodicSignal1";

		public string Line8 => "Line8";

		public string Line7 => "Line7";

		public string Line6 => "Line6";

		public string Line5 => "Line5";

		public string Line4 => "Line4";

		public string Line3 => "Line3";

		public string Line2 => "Line2";

		public string Line1 => "Line1";

		public string FrequencyConverter => "FrequencyConverter";

		public string CxpTrigger1 => "CxpTrigger1";

		public string CxpTrigger0 => "CxpTrigger0";

		public string Counter2Start => "Counter2Start";

		public string Counter2End => "Counter2End";

		public string Counter2Active => "Counter2Active";

		public string Counter1Start => "Counter1Start";

		public string Counter1End => "Counter1End";

		public string Counter1Active => "Counter1Active";

		public string CC4 => "CC4";

		public string CC3 => "CC3";

		public string CC2 => "CC2";

		public string CC1 => "CC1";

		public string Action4 => "Action4";

		public string Action3 => "Action3";

		public string Action2 => "Action2";

		public string Action1 => "Action1";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class UserDefinedValueSelectorEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/UserDefinedValueSelector";

		public string Value5 => "Value5";

		public string Value4 => "Value4";

		public string Value3 => "Value3";

		public string Value2 => "Value2";

		public string Value1 => "Value1";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class UserOutputSelectorEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/UserOutputSelector";

		public string UserOutputLine4 => "UserOutputLine4";

		public string UserOutputLine3 => "UserOutputLine3";

		public string UserOutputLine2 => "UserOutputLine2";

		public string UserOutputLine1 => "UserOutputLine1";

		public string UserOutputClSpare => "UserOutputClSpare";

		public string UserOutputCC4 => "UserOutputCC4";

		public string UserOutputCC3 => "UserOutputCC3";

		public string UserOutputCC2 => "UserOutputCC2";

		public string UserOutputCC1 => "UserOutputCC1";

		public string UserOutput8 => "UserOutput8";

		public string UserOutput7 => "UserOutput7";

		public string UserOutput6 => "UserOutput6";

		public string UserOutput5 => "UserOutput5";

		public string UserOutput4 => "UserOutput4";

		public string UserOutput3 => "UserOutput3";

		public string UserOutput2 => "UserOutput2";

		public string UserOutput1 => "UserOutput1";

		public string UserOutput0 => "UserOutput0";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class UserSetDefaultEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/UserSetDefault";

		public string UserSet3 => "UserSet3";

		public string UserSet2 => "UserSet2";

		public string UserSet1 => "UserSet1";

		public string LightMicroscopy => "LightMicroscopy";

		public string HighGain => "HighGain";

		public string Default => "Default";

		public string ColorRaw => "ColorRaw";

		public string Color => "Color";

		public string AutoFunctions => "AutoFunctions";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class UserSetDefaultSelectorEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/UserSetDefaultSelector";

		public string UserSet3 => "UserSet3";

		public string UserSet2 => "UserSet2";

		public string UserSet1 => "UserSet1";

		public string LightMicroscopy => "LightMicroscopy";

		public string HighGain => "HighGain";

		public string Default => "Default";

		public string Custom1 => "Custom1";

		public string Custom0 => "Custom0";

		public string ColorRaw => "ColorRaw";

		public string Color => "Color";

		public string AutoFunctions => "AutoFunctions";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class UserSetSelectorEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/UserSetSelector";

		public string UserSet3 => "UserSet3";

		public string UserSet2 => "UserSet2";

		public string UserSet1 => "UserSet1";

		public string LightMicroscopy => "LightMicroscopy";

		public string HighGain => "HighGain";

		public string Default => "Default";

		public string Custom1 => "Custom1";

		public string Custom0 => "Custom0";

		public string ColorRaw => "ColorRaw";

		public string Color => "Color";

		public string AutoFunctions => "AutoFunctions";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class VInpSignalReadoutActivationEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/VInpSignalReadoutActivation";

		public string RisingEdge => "RisingEdge";

		public string FallingEdge => "FallingEdge";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class VInpSignalSourceEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/VInpSignalSource";

		public string Line8 => "Line8";

		public string Line7 => "Line7";

		public string Line6 => "Line6";

		public string Line5 => "Line5";

		public string Line4 => "Line4";

		public string Line3 => "Line3";

		public string Line2 => "Line2";

		public string Line1 => "Line1";

		public string CC4 => "CC4";

		public string CC3 => "CC3";

		public string CC2 => "CC2";

		public string CC1 => "CC1";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class VignettingCorrectionModeEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/VignettingCorrectionMode";

		public string On => "On";

		public string Off => "Off";

		public override string ToString()
		{
			return Name;
		}
	}

	private static AcquisitionFrameRateEnumEnum m_AcquisitionFrameRateEnumCached = null;

	private static AcquisitionModeEnum m_AcquisitionModeCached = null;

	private static AcquisitionStatusSelectorEnum m_AcquisitionStatusSelectorCached = null;

	private static AutoFunctionAOISelectorEnum m_AutoFunctionAOISelectorCached = null;

	private static AutoFunctionProfileEnum m_AutoFunctionProfileCached = null;

	private static AutoFunctionROISelectorEnum m_AutoFunctionROISelectorCached = null;

	private static AutoTonalRangeAdjustmentSelectorEnum m_AutoTonalRangeAdjustmentSelectorCached = null;

	private static AutoTonalRangeModeSelectorEnum m_AutoTonalRangeModeSelectorCached = null;

	private static BLCSerialPortBaudRateEnum m_BLCSerialPortBaudRateCached = null;

	private static BLCSerialPortParityEnum m_BLCSerialPortParityCached = null;

	private static BLCSerialPortSourceEnum m_BLCSerialPortSourceCached = null;

	private static BLCSerialPortStopBitsEnum m_BLCSerialPortStopBitsCached = null;

	private static BLCSerialReceiveQueueStatusEnum m_BLCSerialReceiveQueueStatusCached = null;

	private static BLCSerialTransmitQueueStatusEnum m_BLCSerialTransmitQueueStatusCached = null;

	private static BalanceRatioSelectorEnum m_BalanceRatioSelectorCached = null;

	private static BalanceWhiteAutoEnum m_BalanceWhiteAutoCached = null;

	private static BandwidthReserveModeEnum m_BandwidthReserveModeCached = null;

	private static BinningHorizontalModeEnum m_BinningHorizontalModeCached = null;

	private static BinningModeHorizontalEnum m_BinningModeHorizontalCached = null;

	private static BinningModeVerticalEnum m_BinningModeVerticalCached = null;

	private static BinningSelectorEnum m_BinningSelectorCached = null;

	private static BinningVerticalModeEnum m_BinningVerticalModeCached = null;

	private static BlackLevelSelectorEnum m_BlackLevelSelectorCached = null;

	private static BslAcquisitionBurstModeEnum m_BslAcquisitionBurstModeCached = null;

	private static BslAcquisitionStopModeEnum m_BslAcquisitionStopModeCached = null;

	private static BslBlackLevelCompensationModeEnum m_BslBlackLevelCompensationModeCached = null;

	private static BslChunkAutoBrightnessStatusEnum m_BslChunkAutoBrightnessStatusCached = null;

	private static BslChunkTimestampSelectorEnum m_BslChunkTimestampSelectorCached = null;

	private static BslColorAdjustmentSelectorEnum m_BslColorAdjustmentSelectorCached = null;

	private static BslColorSpaceEnum m_BslColorSpaceCached = null;

	private static BslColorSpaceModeEnum m_BslColorSpaceModeCached = null;

	private static BslContrastModeEnum m_BslContrastModeCached = null;

	private static BslDefectPixelCorrectionModeEnum m_BslDefectPixelCorrectionModeCached = null;

	private static BslExposureTimeModeEnum m_BslExposureTimeModeCached = null;

	private static BslImmediateTriggerModeEnum m_BslImmediateTriggerModeCached = null;

	private static BslLightControlErrorStatusEnum m_BslLightControlErrorStatusCached = null;

	private static BslLightControlModeEnum m_BslLightControlModeCached = null;

	private static BslLightControlSourceEnum m_BslLightControlSourceCached = null;

	private static BslLightControlStatusEnum m_BslLightControlStatusCached = null;

	private static BslLightDeviceChangeIDEnum m_BslLightDeviceChangeIDCached = null;

	private static BslLightDeviceLastErrorEnum m_BslLightDeviceLastErrorCached = null;

	private static BslLightDeviceOperationModeEnum m_BslLightDeviceOperationModeCached = null;

	private static BslLightDeviceSelectorEnum m_BslLightDeviceSelectorCached = null;

	private static BslLightDeviceStrobeModeEnum m_BslLightDeviceStrobeModeCached = null;

	private static BslLightSourcePresetEnum m_BslLightSourcePresetCached = null;

	private static BslLightSourcePresetFeatureSelectorEnum m_BslLightSourcePresetFeatureSelectorCached = null;

	private static BslLineConnectionEnum m_BslLineConnectionCached = null;

	private static BslMultipleROIColumnSelectorEnum m_BslMultipleROIColumnSelectorCached = null;

	private static BslMultipleROIRowSelectorEnum m_BslMultipleROIRowSelectorCached = null;

	private static BslPeriodicSignalSelectorEnum m_BslPeriodicSignalSelectorCached = null;

	private static BslPeriodicSignalSourceEnum m_BslPeriodicSignalSourceCached = null;

	private static BslPtpDelayMechanismEnum m_BslPtpDelayMechanismCached = null;

	private static BslPtpNetworkModeEnum m_BslPtpNetworkModeCached = null;

	private static BslPtpProfileEnum m_BslPtpProfileCached = null;

	private static BslSensorBitDepthEnum m_BslSensorBitDepthCached = null;

	private static BslSensorBitDepthModeEnum m_BslSensorBitDepthModeCached = null;

	private static BslSensorStateEnum m_BslSensorStateCached = null;

	private static BslSerialBaudRateEnum m_BslSerialBaudRateCached = null;

	private static BslSerialNumberOfDataBitsEnum m_BslSerialNumberOfDataBitsCached = null;

	private static BslSerialNumberOfStopBitsEnum m_BslSerialNumberOfStopBitsCached = null;

	private static BslSerialParityEnum m_BslSerialParityCached = null;

	private static BslSerialRxSourceEnum m_BslSerialRxSourceCached = null;

	private static BslTemperatureStatusEnum m_BslTemperatureStatusCached = null;

	private static BslTransferBitDepthEnum m_BslTransferBitDepthCached = null;

	private static BslTransferBitDepthModeEnum m_BslTransferBitDepthModeCached = null;

	private static BslTwiBitrateEnum m_BslTwiBitrateCached = null;

	private static BslTwiTransferStatusEnum m_BslTwiTransferStatusCached = null;

	private static BslUSBPowerSourceEnum m_BslUSBPowerSourceCached = null;

	private static BslUSBSpeedModeEnum m_BslUSBSpeedModeCached = null;

	private static BslVignettingCorrectionModeEnum m_BslVignettingCorrectionModeCached = null;

	private static CameraOperationModeEnum m_CameraOperationModeCached = null;

	private static ChunkCounterSelectorEnum m_ChunkCounterSelectorCached = null;

	private static ChunkGainSelectorEnum m_ChunkGainSelectorCached = null;

	private static ChunkPixelFormatEnum m_ChunkPixelFormatCached = null;

	private static ChunkSelectorEnum m_ChunkSelectorCached = null;

	private static ClConfigurationEnum m_ClConfigurationCached = null;

	private static ClPixelClockEnum m_ClPixelClockCached = null;

	private static ClSerialPortBaudRateEnum m_ClSerialPortBaudRateCached = null;

	private static ClTapGeometryEnum m_ClTapGeometryCached = null;

	private static ClTimeSlotsEnum m_ClTimeSlotsCached = null;

	private static ColorAdjustmentSelectorEnum m_ColorAdjustmentSelectorCached = null;

	private static ColorOverexposureCompensationAOISelectorEnum m_ColorOverexposureCompensationAOISelectorCached = null;

	private static ColorSpaceEnum m_ColorSpaceCached = null;

	private static ColorTransformationSelectorEnum m_ColorTransformationSelectorCached = null;

	private static ColorTransformationValueSelectorEnum m_ColorTransformationValueSelectorCached = null;

	private static ComponentSelectorEnum m_ComponentSelectorCached = null;

	private static CounterEventActivationEnum m_CounterEventActivationCached = null;

	private static CounterEventSourceEnum m_CounterEventSourceCached = null;

	private static CounterResetActivationEnum m_CounterResetActivationCached = null;

	private static CounterResetSourceEnum m_CounterResetSourceCached = null;

	private static CounterSelectorEnum m_CounterSelectorCached = null;

	private static CounterStatusEnum m_CounterStatusCached = null;

	private static CounterTriggerActivationEnum m_CounterTriggerActivationCached = null;

	private static CounterTriggerSourceEnum m_CounterTriggerSourceCached = null;

	private static CxpConnectionTestModeEnum m_CxpConnectionTestModeCached = null;

	private static CxpErrorCounterSelectorEnum m_CxpErrorCounterSelectorCached = null;

	private static CxpErrorCounterStatusEnum m_CxpErrorCounterStatusCached = null;

	private static CxpLinkConfigurationEnum m_CxpLinkConfigurationCached = null;

	private static CxpLinkConfigurationPreferredEnum m_CxpLinkConfigurationPreferredCached = null;

	private static CxpLinkConfigurationStatusEnum m_CxpLinkConfigurationStatusCached = null;

	private static CxpSendReceiveSelectorEnum m_CxpSendReceiveSelectorCached = null;

	private static DefectPixelCorrectionModeEnum m_DefectPixelCorrectionModeCached = null;

	private static DemosaicingModeEnum m_DemosaicingModeCached = null;

	private static DeviceCharacterSetEnum m_DeviceCharacterSetCached = null;

	private static DeviceIndicatorModeEnum m_DeviceIndicatorModeCached = null;

	private static DeviceLinkThroughputLimitModeEnum m_DeviceLinkThroughputLimitModeCached = null;

	private static DeviceRegistersEndiannessEnum m_DeviceRegistersEndiannessCached = null;

	private static DeviceScanTypeEnum m_DeviceScanTypeCached = null;

	private static DeviceTLTypeEnum m_DeviceTLTypeCached = null;

	private static DeviceTapGeometryEnum m_DeviceTapGeometryCached = null;

	private static DeviceTemperatureSelectorEnum m_DeviceTemperatureSelectorCached = null;

	private static DeviceTypeEnum m_DeviceTypeCached = null;

	private static EventNotificationEnum m_EventNotificationCached = null;

	private static EventSelectorEnum m_EventSelectorCached = null;

	private static EventTemperatureStatusChangedStatusEnum m_EventTemperatureStatusChangedStatusCached = null;

	private static ExpertFeatureAccessSelectorEnum m_ExpertFeatureAccessSelectorCached = null;

	private static ExposureAutoEnum m_ExposureAutoCached = null;

	private static ExposureModeEnum m_ExposureModeCached = null;

	private static ExposureOverlapTimeModeEnum m_ExposureOverlapTimeModeCached = null;

	private static ExposureTimeModeEnum m_ExposureTimeModeCached = null;

	private static FeatureSetEnum m_FeatureSetCached = null;

	private static FieldOutputModeEnum m_FieldOutputModeCached = null;

	private static FileOpenModeEnum m_FileOpenModeCached = null;

	private static FileOperationSelectorEnum m_FileOperationSelectorCached = null;

	private static FileOperationStatusEnum m_FileOperationStatusCached = null;

	private static FileSelectorEnum m_FileSelectorCached = null;

	private static FrequencyConverterInputSourceEnum m_FrequencyConverterInputSourceCached = null;

	private static FrequencyConverterSignalAlignmentEnum m_FrequencyConverterSignalAlignmentCached = null;

	private static GainAutoEnum m_GainAutoCached = null;

	private static GainSelectorEnum m_GainSelectorCached = null;

	private static GammaSelectorEnum m_GammaSelectorCached = null;

	private static GenDCStreamingModeEnum m_GenDCStreamingModeCached = null;

	private static GenDCStreamingStatusEnum m_GenDCStreamingStatusCached = null;

	private static GevCCPEnum m_GevCCPCached = null;

	private static GevGVSPExtendedIDModeEnum m_GevGVSPExtendedIDModeCached = null;

	private static GevIEEE1588StatusEnum m_GevIEEE1588StatusCached = null;

	private static GevIEEE1588StatusLatchedEnum m_GevIEEE1588StatusLatchedCached = null;

	private static GevInterfaceSelectorEnum m_GevInterfaceSelectorCached = null;

	private static GevStreamChannelSelectorEnum m_GevStreamChannelSelectorCached = null;

	private static ImageCompressionModeEnum m_ImageCompressionModeCached = null;

	private static ImageCompressionRateOptionEnum m_ImageCompressionRateOptionCached = null;

	private static ImageFileModeEnum m_ImageFileModeCached = null;

	private static IntensityCalculationEnum m_IntensityCalculationCached = null;

	private static InterlacedIntegrationModeEnum m_InterlacedIntegrationModeCached = null;

	private static LUTSelectorEnum m_LUTSelectorCached = null;

	private static LastErrorEnum m_LastErrorCached = null;

	private static LegacyBinningVerticalEnum m_LegacyBinningVerticalCached = null;

	private static LightSourcePresetEnum m_LightSourcePresetCached = null;

	private static LightSourceSelectorEnum m_LightSourceSelectorCached = null;

	private static LineFormatEnum m_LineFormatCached = null;

	private static LineLogicEnum m_LineLogicCached = null;

	private static LineModeEnum m_LineModeCached = null;

	private static LineSelectorEnum m_LineSelectorCached = null;

	private static LineSourceEnum m_LineSourceCached = null;

	private static OperatingModeEnum m_OperatingModeCached = null;

	private static OverlapModeEnum m_OverlapModeCached = null;

	private static ParameterSelectorEnum m_ParameterSelectorCached = null;

	private static PgiModeEnum m_PgiModeCached = null;

	private static PixelCodingEnum m_PixelCodingCached = null;

	private static PixelColorFilterEnum m_PixelColorFilterCached = null;

	private static PixelFormatEnum m_PixelFormatCached = null;

	private static PixelSizeEnum m_PixelSizeCached = null;

	private static PtpClockAccuracyEnum m_PtpClockAccuracyCached = null;

	private static PtpServoStatusEnum m_PtpServoStatusCached = null;

	private static PtpStatusEnum m_PtpStatusCached = null;

	private static ROIZoneModeEnum m_ROIZoneModeCached = null;

	private static ROIZoneSelectorEnum m_ROIZoneSelectorCached = null;

	private static RemoveParameterLimitSelectorEnum m_RemoveParameterLimitSelectorCached = null;

	private static Scan3dCoordinateSelectorEnum m_Scan3dCoordinateSelectorCached = null;

	private static Scan3dCoordinateSystemEnum m_Scan3dCoordinateSystemCached = null;

	private static Scan3dCoordinateSystemReferenceEnum m_Scan3dCoordinateSystemReferenceCached = null;

	private static Scan3dDistanceUnitEnum m_Scan3dDistanceUnitCached = null;

	private static Scan3dOutputModeEnum m_Scan3dOutputModeCached = null;

	private static SensorBitDepthEnum m_SensorBitDepthCached = null;

	private static SensorDigitizationTapsEnum m_SensorDigitizationTapsCached = null;

	private static SensorReadoutModeEnum m_SensorReadoutModeCached = null;

	private static SensorShutterModeEnum m_SensorShutterModeCached = null;

	private static SequenceAddressBitSelectorEnum m_SequenceAddressBitSelectorCached = null;

	private static SequenceAddressBitSourceEnum m_SequenceAddressBitSourceCached = null;

	private static SequenceAdvanceModeEnum m_SequenceAdvanceModeCached = null;

	private static SequenceConfigurationModeEnum m_SequenceConfigurationModeCached = null;

	private static SequenceControlSelectorEnum m_SequenceControlSelectorCached = null;

	private static SequenceControlSourceEnum m_SequenceControlSourceCached = null;

	private static SequencerConfigurationModeEnum m_SequencerConfigurationModeCached = null;

	private static SequencerModeEnum m_SequencerModeCached = null;

	private static SequencerTriggerActivationEnum m_SequencerTriggerActivationCached = null;

	private static SequencerTriggerSourceEnum m_SequencerTriggerSourceCached = null;

	private static ShadingSelectorEnum m_ShadingSelectorCached = null;

	private static ShadingSetCreateEnum m_ShadingSetCreateCached = null;

	private static ShadingSetDefaultSelectorEnum m_ShadingSetDefaultSelectorCached = null;

	private static ShadingSetSelectorEnum m_ShadingSetSelectorCached = null;

	private static ShadingStatusEnum m_ShadingStatusCached = null;

	private static ShaftEncoderModuleCounterModeEnum m_ShaftEncoderModuleCounterModeCached = null;

	private static ShaftEncoderModuleLineSelectorEnum m_ShaftEncoderModuleLineSelectorCached = null;

	private static ShaftEncoderModuleLineSourceEnum m_ShaftEncoderModuleLineSourceCached = null;

	private static ShaftEncoderModuleModeEnum m_ShaftEncoderModuleModeCached = null;

	private static ShutterModeEnum m_ShutterModeCached = null;

	private static SoftwareSignalSelectorEnum m_SoftwareSignalSelectorCached = null;

	private static SyncUserOutputSelectorEnum m_SyncUserOutputSelectorCached = null;

	private static TemperatureSelectorEnum m_TemperatureSelectorCached = null;

	private static TemperatureStateEnum m_TemperatureStateCached = null;

	private static TestImageSelectorEnum m_TestImageSelectorCached = null;

	private static TestPatternEnum m_TestPatternCached = null;

	private static TimerSelectorEnum m_TimerSelectorCached = null;

	private static TimerSequenceEntrySelectorEnum m_TimerSequenceEntrySelectorCached = null;

	private static TimerSequenceTimerSelectorEnum m_TimerSequenceTimerSelectorCached = null;

	private static TimerStatusEnum m_TimerStatusCached = null;

	private static TimerTriggerActivationEnum m_TimerTriggerActivationCached = null;

	private static TimerTriggerSourceEnum m_TimerTriggerSourceCached = null;

	private static TonalRangeAutoEnum m_TonalRangeAutoCached = null;

	private static TonalRangeEnableEnum m_TonalRangeEnableCached = null;

	private static TonalRangeSelectorEnum m_TonalRangeSelectorCached = null;

	private static TriggerActivationEnum m_TriggerActivationCached = null;

	private static TriggerControlImplementationEnum m_TriggerControlImplementationCached = null;

	private static TriggerDelaySourceEnum m_TriggerDelaySourceCached = null;

	private static TriggerModeEnum m_TriggerModeCached = null;

	private static TriggerSelectorEnum m_TriggerSelectorCached = null;

	private static TriggerSourceEnum m_TriggerSourceCached = null;

	private static UserDefinedValueSelectorEnum m_UserDefinedValueSelectorCached = null;

	private static UserOutputSelectorEnum m_UserOutputSelectorCached = null;

	private static UserSetDefaultEnum m_UserSetDefaultCached = null;

	private static UserSetDefaultSelectorEnum m_UserSetDefaultSelectorCached = null;

	private static UserSetSelectorEnum m_UserSetSelectorCached = null;

	private static VInpSignalReadoutActivationEnum m_VInpSignalReadoutActivationCached = null;

	private static VInpSignalSourceEnum m_VInpSignalSourceCached = null;

	private static VignettingCorrectionModeEnum m_VignettingCorrectionModeCached = null;

	public static FloatName ZOffsetOriginToCameraFront => new FloatName("@CameraDevice/ZOffsetOriginToCameraFront");

	public static IntegerName WorkingRangeMin => new IntegerName("@CameraDevice/WorkingRangeMin");

	public static IntegerName WorkingRangeMax => new IntegerName("@CameraDevice/WorkingRangeMax");

	public static IntegerName WidthMax => new IntegerName("@CameraDevice/WidthMax");

	public static IntegerName Width => new IntegerName("@CameraDevice/Width");

	public static IntegerName VolatileRowOffsetValue => new IntegerName("@CameraDevice/VolatileRowOffsetValue");

	public static IntegerName VolatileRowOffsetIndex => new IntegerName("@CameraDevice/VolatileRowOffsetIndex");

	public static BooleanName VolatileRowOffsetEnable => new BooleanName("@CameraDevice/VolatileRowOffsetEnable");

	public static IntegerName VolatileColumnOffsetValue => new IntegerName("@CameraDevice/VolatileColumnOffsetValue");

	public static IntegerName VolatileColumnOffsetIndex => new IntegerName("@CameraDevice/VolatileColumnOffsetIndex");

	public static BooleanName VolatileColumnOffsetEnable => new BooleanName("@CameraDevice/VolatileColumnOffsetEnable");

	public static IntegerName VirtualLine4RisingEdgeEventTimestamp => new IntegerName("@CameraDevice/VirtualLine4RisingEdgeEventTimestamp");

	public static IntegerName VirtualLine4RisingEdgeEventStreamChannelIndex => new IntegerName("@CameraDevice/VirtualLine4RisingEdgeEventStreamChannelIndex");

	public static IntegerName VirtualLine3RisingEdgeEventTimestamp => new IntegerName("@CameraDevice/VirtualLine3RisingEdgeEventTimestamp");

	public static IntegerName VirtualLine3RisingEdgeEventStreamChannelIndex => new IntegerName("@CameraDevice/VirtualLine3RisingEdgeEventStreamChannelIndex");

	public static IntegerName VirtualLine2RisingEdgeEventTimestamp => new IntegerName("@CameraDevice/VirtualLine2RisingEdgeEventTimestamp");

	public static IntegerName VirtualLine2RisingEdgeEventStreamChannelIndex => new IntegerName("@CameraDevice/VirtualLine2RisingEdgeEventStreamChannelIndex");

	public static IntegerName VirtualLine1RisingEdgeEventTimestamp => new IntegerName("@CameraDevice/VirtualLine1RisingEdgeEventTimestamp");

	public static IntegerName VirtualLine1RisingEdgeEventStreamChannelIndex => new IntegerName("@CameraDevice/VirtualLine1RisingEdgeEventStreamChannelIndex");

	public static VignettingCorrectionModeEnum VignettingCorrectionMode
	{
		get
		{
			if (m_VignettingCorrectionModeCached == null)
			{
				m_VignettingCorrectionModeCached = new VignettingCorrectionModeEnum();
			}
			return m_VignettingCorrectionModeCached;
		}
	}

	public static CommandName VignettingCorrectionLoad => new CommandName("@CameraDevice/VignettingCorrectionLoad");

	public static VInpSignalSourceEnum VInpSignalSource
	{
		get
		{
			if (m_VInpSignalSourceCached == null)
			{
				m_VInpSignalSourceCached = new VInpSignalSourceEnum();
			}
			return m_VInpSignalSourceCached;
		}
	}

	public static VInpSignalReadoutActivationEnum VInpSignalReadoutActivation
	{
		get
		{
			if (m_VInpSignalReadoutActivationCached == null)
			{
				m_VInpSignalReadoutActivationCached = new VInpSignalReadoutActivationEnum();
			}
			return m_VInpSignalReadoutActivationCached;
		}
	}

	public static IntegerName VInpSamplingPoint => new IntegerName("@CameraDevice/VInpSamplingPoint");

	public static IntegerName VInpBitLength => new IntegerName("@CameraDevice/VInpBitLength");

	public static UserSetSelectorEnum UserSetSelector
	{
		get
		{
			if (m_UserSetSelectorCached == null)
			{
				m_UserSetSelectorCached = new UserSetSelectorEnum();
			}
			return m_UserSetSelectorCached;
		}
	}

	public static CommandName UserSetSave => new CommandName("@CameraDevice/UserSetSave");

	public static CommandName UserSetLoad => new CommandName("@CameraDevice/UserSetLoad");

	public static UserSetDefaultSelectorEnum UserSetDefaultSelector
	{
		get
		{
			if (m_UserSetDefaultSelectorCached == null)
			{
				m_UserSetDefaultSelectorCached = new UserSetDefaultSelectorEnum();
			}
			return m_UserSetDefaultSelectorCached;
		}
	}

	public static UserSetDefaultEnum UserSetDefault
	{
		get
		{
			if (m_UserSetDefaultCached == null)
			{
				m_UserSetDefaultCached = new UserSetDefaultEnum();
			}
			return m_UserSetDefaultCached;
		}
	}

	public static IntegerName UserOutputValueAllMask => new IntegerName("@CameraDevice/UserOutputValueAllMask");

	public static IntegerName UserOutputValueAll => new IntegerName("@CameraDevice/UserOutputValueAll");

	public static BooleanName UserOutputValue => new BooleanName("@CameraDevice/UserOutputValue");

	public static UserOutputSelectorEnum UserOutputSelector
	{
		get
		{
			if (m_UserOutputSelectorCached == null)
			{
				m_UserOutputSelectorCached = new UserOutputSelectorEnum();
			}
			return m_UserOutputSelectorCached;
		}
	}

	public static UserDefinedValueSelectorEnum UserDefinedValueSelector
	{
		get
		{
			if (m_UserDefinedValueSelectorCached == null)
			{
				m_UserDefinedValueSelectorCached = new UserDefinedValueSelectorEnum();
			}
			return m_UserDefinedValueSelectorCached;
		}
	}

	public static IntegerName UserDefinedValue => new IntegerName("@CameraDevice/UserDefinedValue");

	public static TriggerSourceEnum TriggerSource
	{
		get
		{
			if (m_TriggerSourceCached == null)
			{
				m_TriggerSourceCached = new TriggerSourceEnum();
			}
			return m_TriggerSourceCached;
		}
	}

	public static CommandName TriggerSoftware => new CommandName("@CameraDevice/TriggerSoftware");

	public static TriggerSelectorEnum TriggerSelector
	{
		get
		{
			if (m_TriggerSelectorCached == null)
			{
				m_TriggerSelectorCached = new TriggerSelectorEnum();
			}
			return m_TriggerSelectorCached;
		}
	}

	public static BooleanName TriggerPartialClosingFrame => new BooleanName("@CameraDevice/TriggerPartialClosingFrame");

	public static TriggerModeEnum TriggerMode
	{
		get
		{
			if (m_TriggerModeCached == null)
			{
				m_TriggerModeCached = new TriggerModeEnum();
			}
			return m_TriggerModeCached;
		}
	}

	public static TriggerDelaySourceEnum TriggerDelaySource
	{
		get
		{
			if (m_TriggerDelaySourceCached == null)
			{
				m_TriggerDelaySourceCached = new TriggerDelaySourceEnum();
			}
			return m_TriggerDelaySourceCached;
		}
	}

	public static IntegerName TriggerDelayLineTriggerCount => new IntegerName("@CameraDevice/TriggerDelayLineTriggerCount");

	public static FloatName TriggerDelayAbs => new FloatName("@CameraDevice/TriggerDelayAbs");

	public static FloatName TriggerDelay => new FloatName("@CameraDevice/TriggerDelay");

	public static TriggerControlImplementationEnum TriggerControlImplementation
	{
		get
		{
			if (m_TriggerControlImplementationCached == null)
			{
				m_TriggerControlImplementationCached = new TriggerControlImplementationEnum();
			}
			return m_TriggerControlImplementationCached;
		}
	}

	public static TriggerActivationEnum TriggerActivation
	{
		get
		{
			if (m_TriggerActivationCached == null)
			{
				m_TriggerActivationCached = new TriggerActivationEnum();
			}
			return m_TriggerActivationCached;
		}
	}

	public static IntegerName TonalRangeTargetDark => new IntegerName("@CameraDevice/TonalRangeTargetDark");

	public static IntegerName TonalRangeTargetBright => new IntegerName("@CameraDevice/TonalRangeTargetBright");

	public static IntegerName TonalRangeSourceDark => new IntegerName("@CameraDevice/TonalRangeSourceDark");

	public static IntegerName TonalRangeSourceBright => new IntegerName("@CameraDevice/TonalRangeSourceBright");

	public static TonalRangeSelectorEnum TonalRangeSelector
	{
		get
		{
			if (m_TonalRangeSelectorCached == null)
			{
				m_TonalRangeSelectorCached = new TonalRangeSelectorEnum();
			}
			return m_TonalRangeSelectorCached;
		}
	}

	public static TonalRangeEnableEnum TonalRangeEnable
	{
		get
		{
			if (m_TonalRangeEnableCached == null)
			{
				m_TonalRangeEnableCached = new TonalRangeEnableEnum();
			}
			return m_TonalRangeEnableCached;
		}
	}

	public static TonalRangeAutoEnum TonalRangeAuto
	{
		get
		{
			if (m_TonalRangeAutoCached == null)
			{
				m_TonalRangeAutoCached = new TonalRangeAutoEnum();
			}
			return m_TonalRangeAutoCached;
		}
	}

	public static CommandName TimestampReset => new CommandName("@CameraDevice/TimestampReset");

	public static IntegerName TimestampLatchValue => new IntegerName("@CameraDevice/TimestampLatchValue");

	public static CommandName TimestampLatch => new CommandName("@CameraDevice/TimestampLatch");

	public static TimerTriggerSourceEnum TimerTriggerSource
	{
		get
		{
			if (m_TimerTriggerSourceCached == null)
			{
				m_TimerTriggerSourceCached = new TimerTriggerSourceEnum();
			}
			return m_TimerTriggerSourceCached;
		}
	}

	public static FloatName TimerTriggerArmDelay => new FloatName("@CameraDevice/TimerTriggerArmDelay");

	public static TimerTriggerActivationEnum TimerTriggerActivation
	{
		get
		{
			if (m_TimerTriggerActivationCached == null)
			{
				m_TimerTriggerActivationCached = new TimerTriggerActivationEnum();
			}
			return m_TimerTriggerActivationCached;
		}
	}

	public static TimerStatusEnum TimerStatus
	{
		get
		{
			if (m_TimerStatusCached == null)
			{
				m_TimerStatusCached = new TimerStatusEnum();
			}
			return m_TimerStatusCached;
		}
	}

	public static TimerSequenceTimerSelectorEnum TimerSequenceTimerSelector
	{
		get
		{
			if (m_TimerSequenceTimerSelectorCached == null)
			{
				m_TimerSequenceTimerSelectorCached = new TimerSequenceTimerSelectorEnum();
			}
			return m_TimerSequenceTimerSelectorCached;
		}
	}

	public static BooleanName TimerSequenceTimerInverter => new BooleanName("@CameraDevice/TimerSequenceTimerInverter");

	public static BooleanName TimerSequenceTimerEnable => new BooleanName("@CameraDevice/TimerSequenceTimerEnable");

	public static IntegerName TimerSequenceTimerDurationRaw => new IntegerName("@CameraDevice/TimerSequenceTimerDurationRaw");

	public static IntegerName TimerSequenceTimerDelayRaw => new IntegerName("@CameraDevice/TimerSequenceTimerDelayRaw");

	public static IntegerName TimerSequenceLastEntryIndex => new IntegerName("@CameraDevice/TimerSequenceLastEntryIndex");

	public static TimerSequenceEntrySelectorEnum TimerSequenceEntrySelector
	{
		get
		{
			if (m_TimerSequenceEntrySelectorCached == null)
			{
				m_TimerSequenceEntrySelectorCached = new TimerSequenceEntrySelectorEnum();
			}
			return m_TimerSequenceEntrySelectorCached;
		}
	}

	public static BooleanName TimerSequenceEnable => new BooleanName("@CameraDevice/TimerSequenceEnable");

	public static IntegerName TimerSequenceCurrentEntryIndex => new IntegerName("@CameraDevice/TimerSequenceCurrentEntryIndex");

	public static TimerSelectorEnum TimerSelector
	{
		get
		{
			if (m_TimerSelectorCached == null)
			{
				m_TimerSelectorCached = new TimerSelectorEnum();
			}
			return m_TimerSelectorCached;
		}
	}

	public static CommandName TimerReset => new CommandName("@CameraDevice/TimerReset");

	public static FloatName TimerDurationTimebaseAbs => new FloatName("@CameraDevice/TimerDurationTimebaseAbs");

	public static IntegerName TimerDurationRaw => new IntegerName("@CameraDevice/TimerDurationRaw");

	public static FloatName TimerDurationAbs => new FloatName("@CameraDevice/TimerDurationAbs");

	public static FloatName TimerDuration => new FloatName("@CameraDevice/TimerDuration");

	public static FloatName TimerDelayTimebaseAbs => new FloatName("@CameraDevice/TimerDelayTimebaseAbs");

	public static IntegerName TimerDelayRaw => new IntegerName("@CameraDevice/TimerDelayRaw");

	public static FloatName TimerDelayAbs => new FloatName("@CameraDevice/TimerDelayAbs");

	public static FloatName TimerDelay => new FloatName("@CameraDevice/TimerDelay");

	public static BooleanName ThermalDriftCorrection => new BooleanName("@CameraDevice/ThermalDriftCorrection");

	public static IntegerName TestPendingAck => new IntegerName("@CameraDevice/TestPendingAck");

	public static TestPatternEnum TestPattern
	{
		get
		{
			if (m_TestPatternCached == null)
			{
				m_TestPatternCached = new TestPatternEnum();
			}
			return m_TestPatternCached;
		}
	}

	public static TestImageSelectorEnum TestImageSelector
	{
		get
		{
			if (m_TestImageSelectorCached == null)
			{
				m_TestImageSelectorCached = new TestImageSelectorEnum();
			}
			return m_TestImageSelectorCached;
		}
	}

	public static BooleanName TestImageResetAndHold => new BooleanName("@CameraDevice/TestImageResetAndHold");

	public static CommandName TestEventGenerate => new CommandName("@CameraDevice/TestEventGenerate");

	public static TemperatureStateEnum TemperatureState
	{
		get
		{
			if (m_TemperatureStateCached == null)
			{
				m_TemperatureStateCached = new TemperatureStateEnum();
			}
			return m_TemperatureStateCached;
		}
	}

	public static TemperatureSelectorEnum TemperatureSelector
	{
		get
		{
			if (m_TemperatureSelectorCached == null)
			{
				m_TemperatureSelectorCached = new TemperatureSelectorEnum();
			}
			return m_TemperatureSelectorCached;
		}
	}

	public static FloatName TemperatureAbs => new FloatName("@CameraDevice/TemperatureAbs");

	public static IntegerName SyncUserOutputValueAll => new IntegerName("@CameraDevice/SyncUserOutputValueAll");

	public static BooleanName SyncUserOutputValue => new BooleanName("@CameraDevice/SyncUserOutputValue");

	public static SyncUserOutputSelectorEnum SyncUserOutputSelector
	{
		get
		{
			if (m_SyncUserOutputSelectorCached == null)
			{
				m_SyncUserOutputSelectorCached = new SyncUserOutputSelectorEnum();
			}
			return m_SyncUserOutputSelectorCached;
		}
	}

	public static CommandName SyncFreeRunTimerUpdate => new CommandName("@CameraDevice/SyncFreeRunTimerUpdate");

	public static FloatName SyncFreeRunTimerTriggerRateAbs => new FloatName("@CameraDevice/SyncFreeRunTimerTriggerRateAbs");

	public static IntegerName SyncFreeRunTimerStartTimeLow => new IntegerName("@CameraDevice/SyncFreeRunTimerStartTimeLow");

	public static IntegerName SyncFreeRunTimerStartTimeHigh => new IntegerName("@CameraDevice/SyncFreeRunTimerStartTimeHigh");

	public static BooleanName SyncFreeRunTimerEnable => new BooleanName("@CameraDevice/SyncFreeRunTimerEnable");

	public static IntegerName SubstrateVoltage => new IntegerName("@CameraDevice/SubstrateVoltage");

	public static IntegerName StartupTime => new IntegerName("@CameraDevice/StartupTime");

	public static IntegerName StackedZoneImagingZoneOffsetY => new IntegerName("@CameraDevice/StackedZoneImagingZoneOffsetY");

	public static IntegerName StackedZoneImagingZoneHeight => new IntegerName("@CameraDevice/StackedZoneImagingZoneHeight");

	public static BooleanName StackedZoneImagingZoneEnable => new BooleanName("@CameraDevice/StackedZoneImagingZoneEnable");

	public static IntegerName StackedZoneImagingIndex => new IntegerName("@CameraDevice/StackedZoneImagingIndex");

	public static BooleanName StackedZoneImagingEnable => new BooleanName("@CameraDevice/StackedZoneImagingEnable");

	public static IntegerName SpatialCorrection => new IntegerName("@CameraDevice/SpatialCorrection");

	public static SoftwareSignalSelectorEnum SoftwareSignalSelector
	{
		get
		{
			if (m_SoftwareSignalSelectorCached == null)
			{
				m_SoftwareSignalSelectorCached = new SoftwareSignalSelectorEnum();
			}
			return m_SoftwareSignalSelectorCached;
		}
	}

	public static CommandName SoftwareSignalPulse => new CommandName("@CameraDevice/SoftwareSignalPulse");

	public static ShutterModeEnum ShutterMode
	{
		get
		{
			if (m_ShutterModeCached == null)
			{
				m_ShutterModeCached = new ShutterModeEnum();
			}
			return m_ShutterModeCached;
		}
	}

	public static IntegerName SharpnessEnhancementRaw => new IntegerName("@CameraDevice/SharpnessEnhancementRaw");

	public static FloatName SharpnessEnhancementAbs => new FloatName("@CameraDevice/SharpnessEnhancementAbs");

	public static FloatName SharpnessEnhancement => new FloatName("@CameraDevice/SharpnessEnhancement");

	public static CommandName ShaftEncoderModuleReverseCounterReset => new CommandName("@CameraDevice/ShaftEncoderModuleReverseCounterReset");

	public static IntegerName ShaftEncoderModuleReverseCounterMax => new IntegerName("@CameraDevice/ShaftEncoderModuleReverseCounterMax");

	public static ShaftEncoderModuleModeEnum ShaftEncoderModuleMode
	{
		get
		{
			if (m_ShaftEncoderModuleModeCached == null)
			{
				m_ShaftEncoderModuleModeCached = new ShaftEncoderModuleModeEnum();
			}
			return m_ShaftEncoderModuleModeCached;
		}
	}

	public static ShaftEncoderModuleLineSourceEnum ShaftEncoderModuleLineSource
	{
		get
		{
			if (m_ShaftEncoderModuleLineSourceCached == null)
			{
				m_ShaftEncoderModuleLineSourceCached = new ShaftEncoderModuleLineSourceEnum();
			}
			return m_ShaftEncoderModuleLineSourceCached;
		}
	}

	public static ShaftEncoderModuleLineSelectorEnum ShaftEncoderModuleLineSelector
	{
		get
		{
			if (m_ShaftEncoderModuleLineSelectorCached == null)
			{
				m_ShaftEncoderModuleLineSelectorCached = new ShaftEncoderModuleLineSelectorEnum();
			}
			return m_ShaftEncoderModuleLineSelectorCached;
		}
	}

	public static CommandName ShaftEncoderModuleCounterReset => new CommandName("@CameraDevice/ShaftEncoderModuleCounterReset");

	public static ShaftEncoderModuleCounterModeEnum ShaftEncoderModuleCounterMode
	{
		get
		{
			if (m_ShaftEncoderModuleCounterModeCached == null)
			{
				m_ShaftEncoderModuleCounterModeCached = new ShaftEncoderModuleCounterModeEnum();
			}
			return m_ShaftEncoderModuleCounterModeCached;
		}
	}

	public static IntegerName ShaftEncoderModuleCounterMax => new IntegerName("@CameraDevice/ShaftEncoderModuleCounterMax");

	public static IntegerName ShaftEncoderModuleCounter => new IntegerName("@CameraDevice/ShaftEncoderModuleCounter");

	public static ShadingStatusEnum ShadingStatus
	{
		get
		{
			if (m_ShadingStatusCached == null)
			{
				m_ShadingStatusCached = new ShadingStatusEnum();
			}
			return m_ShadingStatusCached;
		}
	}

	public static ShadingSetSelectorEnum ShadingSetSelector
	{
		get
		{
			if (m_ShadingSetSelectorCached == null)
			{
				m_ShadingSetSelectorCached = new ShadingSetSelectorEnum();
			}
			return m_ShadingSetSelectorCached;
		}
	}

	public static ShadingSetDefaultSelectorEnum ShadingSetDefaultSelector
	{
		get
		{
			if (m_ShadingSetDefaultSelectorCached == null)
			{
				m_ShadingSetDefaultSelectorCached = new ShadingSetDefaultSelectorEnum();
			}
			return m_ShadingSetDefaultSelectorCached;
		}
	}

	public static ShadingSetCreateEnum ShadingSetCreate
	{
		get
		{
			if (m_ShadingSetCreateCached == null)
			{
				m_ShadingSetCreateCached = new ShadingSetCreateEnum();
			}
			return m_ShadingSetCreateCached;
		}
	}

	public static CommandName ShadingSetActivate => new CommandName("@CameraDevice/ShadingSetActivate");

	public static ShadingSelectorEnum ShadingSelector
	{
		get
		{
			if (m_ShadingSelectorCached == null)
			{
				m_ShadingSelectorCached = new ShadingSelectorEnum();
			}
			return m_ShadingSelectorCached;
		}
	}

	public static BooleanName ShadingEnable => new BooleanName("@CameraDevice/ShadingEnable");

	public static SequencerTriggerSourceEnum SequencerTriggerSource
	{
		get
		{
			if (m_SequencerTriggerSourceCached == null)
			{
				m_SequencerTriggerSourceCached = new SequencerTriggerSourceEnum();
			}
			return m_SequencerTriggerSourceCached;
		}
	}

	public static SequencerTriggerActivationEnum SequencerTriggerActivation
	{
		get
		{
			if (m_SequencerTriggerActivationCached == null)
			{
				m_SequencerTriggerActivationCached = new SequencerTriggerActivationEnum();
			}
			return m_SequencerTriggerActivationCached;
		}
	}

	public static IntegerName SequencerSetStart => new IntegerName("@CameraDevice/SequencerSetStart");

	public static IntegerName SequencerSetSelector => new IntegerName("@CameraDevice/SequencerSetSelector");

	public static CommandName SequencerSetSave => new CommandName("@CameraDevice/SequencerSetSave");

	public static IntegerName SequencerSetNext => new IntegerName("@CameraDevice/SequencerSetNext");

	public static CommandName SequencerSetLoad => new CommandName("@CameraDevice/SequencerSetLoad");

	public static IntegerName SequencerSetActive => new IntegerName("@CameraDevice/SequencerSetActive");

	public static IntegerName SequencerPathSelector => new IntegerName("@CameraDevice/SequencerPathSelector");

	public static SequencerModeEnum SequencerMode
	{
		get
		{
			if (m_SequencerModeCached == null)
			{
				m_SequencerModeCached = new SequencerModeEnum();
			}
			return m_SequencerModeCached;
		}
	}

	public static SequencerConfigurationModeEnum SequencerConfigurationMode
	{
		get
		{
			if (m_SequencerConfigurationModeCached == null)
			{
				m_SequencerConfigurationModeCached = new SequencerConfigurationModeEnum();
			}
			return m_SequencerConfigurationModeCached;
		}
	}

	public static IntegerName SequenceSetTotalNumber => new IntegerName("@CameraDevice/SequenceSetTotalNumber");

	public static CommandName SequenceSetStore => new CommandName("@CameraDevice/SequenceSetStore");

	public static CommandName SequenceSetLoad => new CommandName("@CameraDevice/SequenceSetLoad");

	public static IntegerName SequenceSetIndex => new IntegerName("@CameraDevice/SequenceSetIndex");

	public static IntegerName SequenceSetExecutions => new IntegerName("@CameraDevice/SequenceSetExecutions");

	public static BooleanName SequenceEnable => new BooleanName("@CameraDevice/SequenceEnable");

	public static IntegerName SequenceCurrentSet => new IntegerName("@CameraDevice/SequenceCurrentSet");

	public static SequenceControlSourceEnum SequenceControlSource
	{
		get
		{
			if (m_SequenceControlSourceCached == null)
			{
				m_SequenceControlSourceCached = new SequenceControlSourceEnum();
			}
			return m_SequenceControlSourceCached;
		}
	}

	public static SequenceControlSelectorEnum SequenceControlSelector
	{
		get
		{
			if (m_SequenceControlSelectorCached == null)
			{
				m_SequenceControlSelectorCached = new SequenceControlSelectorEnum();
			}
			return m_SequenceControlSelectorCached;
		}
	}

	public static SequenceConfigurationModeEnum SequenceConfigurationMode
	{
		get
		{
			if (m_SequenceConfigurationModeCached == null)
			{
				m_SequenceConfigurationModeCached = new SequenceConfigurationModeEnum();
			}
			return m_SequenceConfigurationModeCached;
		}
	}

	public static CommandName SequenceAsyncRestart => new CommandName("@CameraDevice/SequenceAsyncRestart");

	public static CommandName SequenceAsyncAdvance => new CommandName("@CameraDevice/SequenceAsyncAdvance");

	public static SequenceAdvanceModeEnum SequenceAdvanceMode
	{
		get
		{
			if (m_SequenceAdvanceModeCached == null)
			{
				m_SequenceAdvanceModeCached = new SequenceAdvanceModeEnum();
			}
			return m_SequenceAdvanceModeCached;
		}
	}

	public static SequenceAddressBitSourceEnum SequenceAddressBitSource
	{
		get
		{
			if (m_SequenceAddressBitSourceCached == null)
			{
				m_SequenceAddressBitSourceCached = new SequenceAddressBitSourceEnum();
			}
			return m_SequenceAddressBitSourceCached;
		}
	}

	public static SequenceAddressBitSelectorEnum SequenceAddressBitSelector
	{
		get
		{
			if (m_SequenceAddressBitSelectorCached == null)
			{
				m_SequenceAddressBitSelectorCached = new SequenceAddressBitSelectorEnum();
			}
			return m_SequenceAddressBitSelectorCached;
		}
	}

	public static IntegerName SensorWidth => new IntegerName("@CameraDevice/SensorWidth");

	public static SensorShutterModeEnum SensorShutterMode
	{
		get
		{
			if (m_SensorShutterModeCached == null)
			{
				m_SensorShutterModeCached = new SensorShutterModeEnum();
			}
			return m_SensorShutterModeCached;
		}
	}

	public static FloatName SensorReadoutTime => new FloatName("@CameraDevice/SensorReadoutTime");

	public static SensorReadoutModeEnum SensorReadoutMode
	{
		get
		{
			if (m_SensorReadoutModeCached == null)
			{
				m_SensorReadoutModeCached = new SensorReadoutModeEnum();
			}
			return m_SensorReadoutModeCached;
		}
	}

	public static FloatName SensorPosition => new FloatName("@CameraDevice/SensorPosition");

	public static FloatName SensorPixelWidth => new FloatName("@CameraDevice/SensorPixelWidth");

	public static FloatName SensorPixelHeight => new FloatName("@CameraDevice/SensorPixelHeight");

	public static IntegerName SensorHeight => new IntegerName("@CameraDevice/SensorHeight");

	public static SensorDigitizationTapsEnum SensorDigitizationTaps
	{
		get
		{
			if (m_SensorDigitizationTapsCached == null)
			{
				m_SensorDigitizationTapsCached = new SensorDigitizationTapsEnum();
			}
			return m_SensorDigitizationTapsCached;
		}
	}

	public static SensorBitDepthEnum SensorBitDepth
	{
		get
		{
			if (m_SensorBitDepthCached == null)
			{
				m_SensorBitDepthCached = new SensorBitDepthEnum();
			}
			return m_SensorBitDepthCached;
		}
	}

	public static FloatName Scan3dPrincipalPointV => new FloatName("@CameraDevice/Scan3dPrincipalPointV");

	public static FloatName Scan3dPrincipalPointU => new FloatName("@CameraDevice/Scan3dPrincipalPointU");

	public static Scan3dOutputModeEnum Scan3dOutputMode
	{
		get
		{
			if (m_Scan3dOutputModeCached == null)
			{
				m_Scan3dOutputModeCached = new Scan3dOutputModeEnum();
			}
			return m_Scan3dOutputModeCached;
		}
	}

	public static FloatName Scan3dInvalidDataValue => new FloatName("@CameraDevice/Scan3dInvalidDataValue");

	public static BooleanName Scan3dInvalidDataFlag => new BooleanName("@CameraDevice/Scan3dInvalidDataFlag");

	public static FloatName Scan3dFocalLength => new FloatName("@CameraDevice/Scan3dFocalLength");

	public static Scan3dDistanceUnitEnum Scan3dDistanceUnit
	{
		get
		{
			if (m_Scan3dDistanceUnitCached == null)
			{
				m_Scan3dDistanceUnitCached = new Scan3dDistanceUnitEnum();
			}
			return m_Scan3dDistanceUnitCached;
		}
	}

	public static Scan3dCoordinateSystemReferenceEnum Scan3dCoordinateSystemReference
	{
		get
		{
			if (m_Scan3dCoordinateSystemReferenceCached == null)
			{
				m_Scan3dCoordinateSystemReferenceCached = new Scan3dCoordinateSystemReferenceEnum();
			}
			return m_Scan3dCoordinateSystemReferenceCached;
		}
	}

	public static Scan3dCoordinateSystemEnum Scan3dCoordinateSystem
	{
		get
		{
			if (m_Scan3dCoordinateSystemCached == null)
			{
				m_Scan3dCoordinateSystemCached = new Scan3dCoordinateSystemEnum();
			}
			return m_Scan3dCoordinateSystemCached;
		}
	}

	public static Scan3dCoordinateSelectorEnum Scan3dCoordinateSelector
	{
		get
		{
			if (m_Scan3dCoordinateSelectorCached == null)
			{
				m_Scan3dCoordinateSelectorCached = new Scan3dCoordinateSelectorEnum();
			}
			return m_Scan3dCoordinateSelectorCached;
		}
	}

	public static FloatName Scan3dCoordinateScale => new FloatName("@CameraDevice/Scan3dCoordinateScale");

	public static FloatName Scan3dCoordinateOffset => new FloatName("@CameraDevice/Scan3dCoordinateOffset");

	public static FloatName Scan3dCalibrationOffset => new FloatName("@CameraDevice/Scan3dCalibrationOffset");

	public static FloatName Scan3dAxisMin => new FloatName("@CameraDevice/Scan3dAxisMin");

	public static FloatName Scan3dAxisMax => new FloatName("@CameraDevice/Scan3dAxisMax");

	public static FloatName ScalingVerticalAbs => new FloatName("@CameraDevice/ScalingVerticalAbs");

	public static FloatName ScalingVertical => new FloatName("@CameraDevice/ScalingVertical");

	public static FloatName ScalingHorizontalAbs => new FloatName("@CameraDevice/ScalingHorizontalAbs");

	public static FloatName ScalingHorizontal => new FloatName("@CameraDevice/ScalingHorizontal");

	public static IntegerName SIPayloadTransferSize => new IntegerName("@CameraDevice/SIPayloadTransferSize");

	public static IntegerName SIPayloadTransferCount => new IntegerName("@CameraDevice/SIPayloadTransferCount");

	public static IntegerName SIPayloadFinalTransfer2Size => new IntegerName("@CameraDevice/SIPayloadFinalTransfer2Size");

	public static IntegerName SIPayloadFinalTransfer1Size => new IntegerName("@CameraDevice/SIPayloadFinalTransfer1Size");

	public static BooleanName ReverseY => new BooleanName("@CameraDevice/ReverseY");

	public static BooleanName ReverseX => new BooleanName("@CameraDevice/ReverseX");

	public static FloatName ResultingLineRateAbs => new FloatName("@CameraDevice/ResultingLineRateAbs");

	public static FloatName ResultingLinePeriodAbs => new FloatName("@CameraDevice/ResultingLinePeriodAbs");

	public static FloatName ResultingFrameRateAbs => new FloatName("@CameraDevice/ResultingFrameRateAbs");

	public static FloatName ResultingFrameRate => new FloatName("@CameraDevice/ResultingFrameRate");

	public static FloatName ResultingFramePeriodAbs => new FloatName("@CameraDevice/ResultingFramePeriodAbs");

	public static IntegerName ResetTime => new IntegerName("@CameraDevice/ResetTime");

	public static RemoveParameterLimitSelectorEnum RemoveParameterLimitSelector
	{
		get
		{
			if (m_RemoveParameterLimitSelectorCached == null)
			{
				m_RemoveParameterLimitSelectorCached = new RemoveParameterLimitSelectorEnum();
			}
			return m_RemoveParameterLimitSelectorCached;
		}
	}

	public static BooleanName RemoveParameterLimit => new BooleanName("@CameraDevice/RemoveParameterLimit");

	public static BooleanName RemoveLimits => new BooleanName("@CameraDevice/RemoveLimits");

	public static FloatName ReadoutTimeAbs => new FloatName("@CameraDevice/ReadoutTimeAbs");

	public static IntegerName ReadoutTime => new IntegerName("@CameraDevice/ReadoutTime");

	public static IntegerName ROIZoneSize => new IntegerName("@CameraDevice/ROIZoneSize");

	public static ROIZoneSelectorEnum ROIZoneSelector
	{
		get
		{
			if (m_ROIZoneSelectorCached == null)
			{
				m_ROIZoneSelectorCached = new ROIZoneSelectorEnum();
			}
			return m_ROIZoneSelectorCached;
		}
	}

	public static IntegerName ROIZoneOffset => new IntegerName("@CameraDevice/ROIZoneOffset");

	public static ROIZoneModeEnum ROIZoneMode
	{
		get
		{
			if (m_ROIZoneModeCached == null)
			{
				m_ROIZoneModeCached = new ROIZoneModeEnum();
			}
			return m_ROIZoneModeCached;
		}
	}

	public static PtpStatusEnum PtpStatus
	{
		get
		{
			if (m_PtpStatusCached == null)
			{
				m_PtpStatusCached = new PtpStatusEnum();
			}
			return m_PtpStatusCached;
		}
	}

	public static PtpServoStatusEnum PtpServoStatus
	{
		get
		{
			if (m_PtpServoStatusCached == null)
			{
				m_PtpServoStatusCached = new PtpServoStatusEnum();
			}
			return m_PtpServoStatusCached;
		}
	}

	public static IntegerName PtpParentClockID => new IntegerName("@CameraDevice/PtpParentClockID");

	public static IntegerName PtpOffsetFromMaster => new IntegerName("@CameraDevice/PtpOffsetFromMaster");

	public static IntegerName PtpGrandmasterClockID => new IntegerName("@CameraDevice/PtpGrandmasterClockID");

	public static BooleanName PtpEnable => new BooleanName("@CameraDevice/PtpEnable");

	public static CommandName PtpDataSetLatch => new CommandName("@CameraDevice/PtpDataSetLatch");

	public static IntegerName PtpClockID => new IntegerName("@CameraDevice/PtpClockID");

	public static PtpClockAccuracyEnum PtpClockAccuracy
	{
		get
		{
			if (m_PtpClockAccuracyCached == null)
			{
				m_PtpClockAccuracyCached = new PtpClockAccuracyEnum();
			}
			return m_PtpClockAccuracyCached;
		}
	}

	public static BooleanName ProcessedRawEnable => new BooleanName("@CameraDevice/ProcessedRawEnable");

	public static IntegerName Prelines => new IntegerName("@CameraDevice/Prelines");

	public static PixelSizeEnum PixelSize
	{
		get
		{
			if (m_PixelSizeCached == null)
			{
				m_PixelSizeCached = new PixelSizeEnum();
			}
			return m_PixelSizeCached;
		}
	}

	public static BooleanName PixelFormatLegacy => new BooleanName("@CameraDevice/PixelFormatLegacy");

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

	public static IntegerName PixelDynamicRangeMin => new IntegerName("@CameraDevice/PixelDynamicRangeMin");

	public static IntegerName PixelDynamicRangeMax => new IntegerName("@CameraDevice/PixelDynamicRangeMax");

	public static PixelColorFilterEnum PixelColorFilter
	{
		get
		{
			if (m_PixelColorFilterCached == null)
			{
				m_PixelColorFilterCached = new PixelColorFilterEnum();
			}
			return m_PixelColorFilterCached;
		}
	}

	public static PixelCodingEnum PixelCoding
	{
		get
		{
			if (m_PixelCodingCached == null)
			{
				m_PixelCodingCached = new PixelCodingEnum();
			}
			return m_PixelCodingCached;
		}
	}

	public static PgiModeEnum PgiMode
	{
		get
		{
			if (m_PgiModeCached == null)
			{
				m_PgiModeCached = new PgiModeEnum();
			}
			return m_PgiModeCached;
		}
	}

	public static IntegerName PayloadTransferSize => new IntegerName("@CameraDevice/PayloadTransferSize");

	public static IntegerName PayloadTransferCount => new IntegerName("@CameraDevice/PayloadTransferCount");

	public static IntegerName PayloadTransferBlockDelay => new IntegerName("@CameraDevice/PayloadTransferBlockDelay");

	public static IntegerName PayloadSize => new IntegerName("@CameraDevice/PayloadSize");

	public static IntegerName PayloadFinalTransfer2Size => new IntegerName("@CameraDevice/PayloadFinalTransfer2Size");

	public static IntegerName PayloadFinalTransfer1Size => new IntegerName("@CameraDevice/PayloadFinalTransfer1Size");

	public static ParameterSelectorEnum ParameterSelector
	{
		get
		{
			if (m_ParameterSelectorCached == null)
			{
				m_ParameterSelectorCached = new ParameterSelectorEnum();
			}
			return m_ParameterSelectorCached;
		}
	}

	public static OverlapModeEnum OverlapMode
	{
		get
		{
			if (m_OverlapModeCached == null)
			{
				m_OverlapModeCached = new OverlapModeEnum();
			}
			return m_OverlapModeCached;
		}
	}

	public static IntegerName OverTemperatureEventTimestamp => new IntegerName("@CameraDevice/OverTemperatureEventTimestamp");

	public static IntegerName OverTemperatureEventStreamChannelIndex => new IntegerName("@CameraDevice/OverTemperatureEventStreamChannelIndex");

	public static BooleanName OverTemperature => new BooleanName("@CameraDevice/OverTemperature");

	public static BooleanName OutlierRemoval => new BooleanName("@CameraDevice/OutlierRemoval");

	public static OperatingModeEnum OperatingMode
	{
		get
		{
			if (m_OperatingModeCached == null)
			{
				m_OperatingModeCached = new OperatingModeEnum();
			}
			return m_OperatingModeCached;
		}
	}

	public static IntegerName OffsetY => new IntegerName("@CameraDevice/OffsetY");

	public static IntegerName OffsetX => new IntegerName("@CameraDevice/OffsetX");

	public static IntegerName NumberOfActionSignals => new IntegerName("@CameraDevice/NumberOfActionSignals");

	public static IntegerName NoiseReductionRaw => new IntegerName("@CameraDevice/NoiseReductionRaw");

	public static FloatName NoiseReductionAbs => new FloatName("@CameraDevice/NoiseReductionAbs");

	public static FloatName NoiseReduction => new FloatName("@CameraDevice/NoiseReduction");

	public static IntegerName MultiCameraChannel => new IntegerName("@CameraDevice/MultiCameraChannel");

	public static FloatName MinOutPulseWidthAbs => new FloatName("@CameraDevice/MinOutPulseWidthAbs");

	public static BooleanName LineTermination => new BooleanName("@CameraDevice/LineTermination");

	public static IntegerName LineStatusAll => new IntegerName("@CameraDevice/LineStatusAll");

	public static BooleanName LineStatus => new BooleanName("@CameraDevice/LineStatus");

	public static IntegerName LineStartOvertriggerEventTimestamp => new IntegerName("@CameraDevice/LineStartOvertriggerEventTimestamp");

	public static IntegerName LineStartOvertriggerEventStreamChannelIndex => new IntegerName("@CameraDevice/LineStartOvertriggerEventStreamChannelIndex");

	public static LineSourceEnum LineSource
	{
		get
		{
			if (m_LineSourceCached == null)
			{
				m_LineSourceCached = new LineSourceEnum();
			}
			return m_LineSourceCached;
		}
	}

	public static LineSelectorEnum LineSelector
	{
		get
		{
			if (m_LineSelectorCached == null)
			{
				m_LineSelectorCached = new LineSelectorEnum();
			}
			return m_LineSelectorCached;
		}
	}

	public static BooleanName LinePitchEnable => new BooleanName("@CameraDevice/LinePitchEnable");

	public static IntegerName LinePitch => new IntegerName("@CameraDevice/LinePitch");

	public static BooleanName LineOverloadStatus => new BooleanName("@CameraDevice/LineOverloadStatus");

	public static CommandName LineOverloadReset => new CommandName("@CameraDevice/LineOverloadReset");

	public static LineModeEnum LineMode
	{
		get
		{
			if (m_LineModeCached == null)
			{
				m_LineModeCached = new LineModeEnum();
			}
			return m_LineModeCached;
		}
	}

	public static FloatName LineMinimumOutputPulseWidth => new FloatName("@CameraDevice/LineMinimumOutputPulseWidth");

	public static LineLogicEnum LineLogic
	{
		get
		{
			if (m_LineLogicCached == null)
			{
				m_LineLogicCached = new LineLogicEnum();
			}
			return m_LineLogicCached;
		}
	}

	public static BooleanName LineInverter => new BooleanName("@CameraDevice/LineInverter");

	public static LineFormatEnum LineFormat
	{
		get
		{
			if (m_LineFormatCached == null)
			{
				m_LineFormatCached = new LineFormatEnum();
			}
			return m_LineFormatCached;
		}
	}

	public static FloatName LineDebouncerTimeAbs => new FloatName("@CameraDevice/LineDebouncerTimeAbs");

	public static FloatName LineDebouncerTime => new FloatName("@CameraDevice/LineDebouncerTime");

	public static IntegerName Line4RisingEdgeEventTimestamp => new IntegerName("@CameraDevice/Line4RisingEdgeEventTimestamp");

	public static IntegerName Line4RisingEdgeEventStreamChannelIndex => new IntegerName("@CameraDevice/Line4RisingEdgeEventStreamChannelIndex");

	public static IntegerName Line3RisingEdgeEventTimestamp => new IntegerName("@CameraDevice/Line3RisingEdgeEventTimestamp");

	public static IntegerName Line3RisingEdgeEventStreamChannelIndex => new IntegerName("@CameraDevice/Line3RisingEdgeEventStreamChannelIndex");

	public static IntegerName Line2RisingEdgeEventTimestamp => new IntegerName("@CameraDevice/Line2RisingEdgeEventTimestamp");

	public static IntegerName Line2RisingEdgeEventStreamChannelIndex => new IntegerName("@CameraDevice/Line2RisingEdgeEventStreamChannelIndex");

	public static IntegerName Line1RisingEdgeEventTimestamp => new IntegerName("@CameraDevice/Line1RisingEdgeEventTimestamp");

	public static IntegerName Line1RisingEdgeEventStreamChannelIndex => new IntegerName("@CameraDevice/Line1RisingEdgeEventStreamChannelIndex");

	public static LightSourceSelectorEnum LightSourceSelector
	{
		get
		{
			if (m_LightSourceSelectorCached == null)
			{
				m_LightSourceSelectorCached = new LightSourceSelectorEnum();
			}
			return m_LightSourceSelectorCached;
		}
	}

	public static LightSourcePresetEnum LightSourcePreset
	{
		get
		{
			if (m_LightSourcePresetCached == null)
			{
				m_LightSourcePresetCached = new LightSourcePresetEnum();
			}
			return m_LightSourcePresetCached;
		}
	}

	public static LegacyBinningVerticalEnum LegacyBinningVertical
	{
		get
		{
			if (m_LegacyBinningVerticalCached == null)
			{
				m_LegacyBinningVerticalCached = new LegacyBinningVerticalEnum();
			}
			return m_LegacyBinningVerticalCached;
		}
	}

	public static IntegerName LateActionEventTimestamp => new IntegerName("@CameraDevice/LateActionEventTimestamp");

	public static IntegerName LateActionEventStreamChannelIndex => new IntegerName("@CameraDevice/LateActionEventStreamChannelIndex");

	public static LastErrorEnum LastError
	{
		get
		{
			if (m_LastErrorCached == null)
			{
				m_LastErrorCached = new LastErrorEnum();
			}
			return m_LastErrorCached;
		}
	}

	public static ArrayName LUTValueAll => new ArrayName("@CameraDevice/LUTValueAll");

	public static IntegerName LUTValue => new IntegerName("@CameraDevice/LUTValue");

	public static LUTSelectorEnum LUTSelector
	{
		get
		{
			if (m_LUTSelectorCached == null)
			{
				m_LUTSelectorCached = new LUTSelectorEnum();
			}
			return m_LUTSelectorCached;
		}
	}

	public static IntegerName LUTIndex => new IntegerName("@CameraDevice/LUTIndex");

	public static BooleanName LUTEnable => new BooleanName("@CameraDevice/LUTEnable");

	public static InterlacedIntegrationModeEnum InterlacedIntegrationMode
	{
		get
		{
			if (m_InterlacedIntegrationModeCached == null)
			{
				m_InterlacedIntegrationModeCached = new InterlacedIntegrationModeEnum();
			}
			return m_InterlacedIntegrationModeCached;
		}
	}

	public static IntensityCalculationEnum IntensityCalculation
	{
		get
		{
			if (m_IntensityCalculationCached == null)
			{
				m_IntensityCalculationCached = new IntensityCalculationEnum();
			}
			return m_IntensityCalculationCached;
		}
	}

	public static StringName ImageFilename => new StringName("@CameraDevice/ImageFilename");

	public static ImageFileModeEnum ImageFileMode
	{
		get
		{
			if (m_ImageFileModeCached == null)
			{
				m_ImageFileModeCached = new ImageFileModeEnum();
			}
			return m_ImageFileModeCached;
		}
	}

	public static ImageCompressionRateOptionEnum ImageCompressionRateOption
	{
		get
		{
			if (m_ImageCompressionRateOptionCached == null)
			{
				m_ImageCompressionRateOptionCached = new ImageCompressionRateOptionEnum();
			}
			return m_ImageCompressionRateOptionCached;
		}
	}

	public static ImageCompressionModeEnum ImageCompressionMode
	{
		get
		{
			if (m_ImageCompressionModeCached == null)
			{
				m_ImageCompressionModeCached = new ImageCompressionModeEnum();
			}
			return m_ImageCompressionModeCached;
		}
	}

	public static IntegerName Image1StreamID => new IntegerName("@CameraDevice/Image1StreamID");

	public static IntegerName HeightMax => new IntegerName("@CameraDevice/HeightMax");

	public static IntegerName Height => new IntegerName("@CameraDevice/Height");

	public static IntegerName GrayValueAdjustmentDampingRaw => new IntegerName("@CameraDevice/GrayValueAdjustmentDampingRaw");

	public static FloatName GrayValueAdjustmentDampingAbs => new FloatName("@CameraDevice/GrayValueAdjustmentDampingAbs");

	public static IntegerName GevVersionMinor => new IntegerName("@CameraDevice/GevVersionMinor");

	public static IntegerName GevVersionMajor => new IntegerName("@CameraDevice/GevVersionMajor");

	public static IntegerName GevTimestampValue => new IntegerName("@CameraDevice/GevTimestampValue");

	public static IntegerName GevTimestampTickFrequency => new IntegerName("@CameraDevice/GevTimestampTickFrequency");

	public static CommandName GevTimestampControlReset => new CommandName("@CameraDevice/GevTimestampControlReset");

	public static CommandName GevTimestampControlLatchReset => new CommandName("@CameraDevice/GevTimestampControlLatchReset");

	public static CommandName GevTimestampControlLatch => new CommandName("@CameraDevice/GevTimestampControlLatch");

	public static BooleanName GevSupportedOptionalLegacy16BitBlockID => new BooleanName("@CameraDevice/GevSupportedOptionalLegacy16BitBlockID");

	public static BooleanName GevSupportedOptionalCommandsWRITEMEM => new BooleanName("@CameraDevice/GevSupportedOptionalCommandsWRITEMEM");

	public static BooleanName GevSupportedOptionalCommandsPACKETRESEND => new BooleanName("@CameraDevice/GevSupportedOptionalCommandsPACKETRESEND");

	public static BooleanName GevSupportedOptionalCommandsEVENTDATA => new BooleanName("@CameraDevice/GevSupportedOptionalCommandsEVENTDATA");

	public static BooleanName GevSupportedOptionalCommandsEVENT => new BooleanName("@CameraDevice/GevSupportedOptionalCommandsEVENT");

	public static BooleanName GevSupportedOptionalCommandsConcatenation => new BooleanName("@CameraDevice/GevSupportedOptionalCommandsConcatenation");

	public static BooleanName GevSupportedIPConfigurationPersistentIP => new BooleanName("@CameraDevice/GevSupportedIPConfigurationPersistentIP");

	public static BooleanName GevSupportedIPConfigurationLLA => new BooleanName("@CameraDevice/GevSupportedIPConfigurationLLA");

	public static BooleanName GevSupportedIPConfigurationDHCP => new BooleanName("@CameraDevice/GevSupportedIPConfigurationDHCP");

	public static BooleanName GevSupportedIEEE1588 => new BooleanName("@CameraDevice/GevSupportedIEEE1588");

	public static GevStreamChannelSelectorEnum GevStreamChannelSelector
	{
		get
		{
			if (m_GevStreamChannelSelectorCached == null)
			{
				m_GevStreamChannelSelectorCached = new GevStreamChannelSelectorEnum();
			}
			return m_GevStreamChannelSelectorCached;
		}
	}

	public static IntegerName GevStreamChannelCount => new IntegerName("@CameraDevice/GevStreamChannelCount");

	public static StringName GevSecondURL => new StringName("@CameraDevice/GevSecondURL");

	public static IntegerName GevSCPSPacketSize => new IntegerName("@CameraDevice/GevSCPSPacketSize");

	public static CommandName GevSCPSFireTestPacket => new CommandName("@CameraDevice/GevSCPSFireTestPacket");

	public static BooleanName GevSCPSDoNotFragment => new BooleanName("@CameraDevice/GevSCPSDoNotFragment");

	public static BooleanName GevSCPSBigEndian => new BooleanName("@CameraDevice/GevSCPSBigEndian");

	public static IntegerName GevSCPInterfaceIndex => new IntegerName("@CameraDevice/GevSCPInterfaceIndex");

	public static IntegerName GevSCPHostPort => new IntegerName("@CameraDevice/GevSCPHostPort");

	public static IntegerName GevSCPD => new IntegerName("@CameraDevice/GevSCPD");

	public static IntegerName GevSCFTD => new IntegerName("@CameraDevice/GevSCFTD");

	public static IntegerName GevSCFJM => new IntegerName("@CameraDevice/GevSCFJM");

	public static IntegerName GevSCDMT => new IntegerName("@CameraDevice/GevSCDMT");

	public static IntegerName GevSCDCT => new IntegerName("@CameraDevice/GevSCDCT");

	public static IntegerName GevSCDA => new IntegerName("@CameraDevice/GevSCDA");

	public static IntegerName GevSCBWRA => new IntegerName("@CameraDevice/GevSCBWRA");

	public static IntegerName GevSCBWR => new IntegerName("@CameraDevice/GevSCBWR");

	public static IntegerName GevSCBWA => new IntegerName("@CameraDevice/GevSCBWA");

	public static IntegerName GevPersistentSubnetMask => new IntegerName("@CameraDevice/GevPersistentSubnetMask");

	public static IntegerName GevPersistentIPAddress => new IntegerName("@CameraDevice/GevPersistentIPAddress");

	public static IntegerName GevPersistentDefaultGateway => new IntegerName("@CameraDevice/GevPersistentDefaultGateway");

	public static IntegerName GevPTPDiagnosticsQueueSendNumFailure => new IntegerName("@CameraDevice/GevPTPDiagnosticsQueueSendNumFailure");

	public static IntegerName GevPTPDiagnosticsQueueRxGnrlPushNumFailure => new IntegerName("@CameraDevice/GevPTPDiagnosticsQueueRxGnrlPushNumFailure");

	public static IntegerName GevPTPDiagnosticsQueueRxGnrlMaxNumElements => new IntegerName("@CameraDevice/GevPTPDiagnosticsQueueRxGnrlMaxNumElements");

	public static IntegerName GevPTPDiagnosticsQueueRxEvntPushNumFailure => new IntegerName("@CameraDevice/GevPTPDiagnosticsQueueRxEvntPushNumFailure");

	public static IntegerName GevPTPDiagnosticsQueueRxEvntMaxNumElements => new IntegerName("@CameraDevice/GevPTPDiagnosticsQueueRxEvntMaxNumElements");

	public static IntegerName GevNumberOfInterfaces => new IntegerName("@CameraDevice/GevNumberOfInterfaces");

	public static IntegerName GevMessageChannelCount => new IntegerName("@CameraDevice/GevMessageChannelCount");

	public static IntegerName GevMACAddress => new IntegerName("@CameraDevice/GevMACAddress");

	public static IntegerName GevLinkSpeed => new IntegerName("@CameraDevice/GevLinkSpeed");

	public static BooleanName GevLinkMaster => new BooleanName("@CameraDevice/GevLinkMaster");

	public static BooleanName GevLinkFullDuplex => new BooleanName("@CameraDevice/GevLinkFullDuplex");

	public static BooleanName GevLinkCrossover => new BooleanName("@CameraDevice/GevLinkCrossover");

	public static GevInterfaceSelectorEnum GevInterfaceSelector
	{
		get
		{
			if (m_GevInterfaceSelectorCached == null)
			{
				m_GevInterfaceSelectorCached = new GevInterfaceSelectorEnum();
			}
			return m_GevInterfaceSelectorCached;
		}
	}

	public static GevIEEE1588StatusLatchedEnum GevIEEE1588StatusLatched
	{
		get
		{
			if (m_GevIEEE1588StatusLatchedCached == null)
			{
				m_GevIEEE1588StatusLatchedCached = new GevIEEE1588StatusLatchedEnum();
			}
			return m_GevIEEE1588StatusLatchedCached;
		}
	}

	public static GevIEEE1588StatusEnum GevIEEE1588Status
	{
		get
		{
			if (m_GevIEEE1588StatusCached == null)
			{
				m_GevIEEE1588StatusCached = new GevIEEE1588StatusEnum();
			}
			return m_GevIEEE1588StatusCached;
		}
	}

	public static IntegerName GevIEEE1588ParentClockId => new IntegerName("@CameraDevice/GevIEEE1588ParentClockId");

	public static IntegerName GevIEEE1588OffsetFromMaster => new IntegerName("@CameraDevice/GevIEEE1588OffsetFromMaster");

	public static CommandName GevIEEE1588DataSetLatch => new CommandName("@CameraDevice/GevIEEE1588DataSetLatch");

	public static IntegerName GevIEEE1588ClockId => new IntegerName("@CameraDevice/GevIEEE1588ClockId");

	public static BooleanName GevIEEE1588 => new BooleanName("@CameraDevice/GevIEEE1588");

	public static IntegerName GevHeartbeatTimeout => new IntegerName("@CameraDevice/GevHeartbeatTimeout");

	public static GevGVSPExtendedIDModeEnum GevGVSPExtendedIDMode
	{
		get
		{
			if (m_GevGVSPExtendedIDModeCached == null)
			{
				m_GevGVSPExtendedIDModeCached = new GevGVSPExtendedIDModeEnum();
			}
			return m_GevGVSPExtendedIDModeCached;
		}
	}

	public static StringName GevFirstURL => new StringName("@CameraDevice/GevFirstURL");

	public static BooleanName GevDeviceModeIsBigEndian => new BooleanName("@CameraDevice/GevDeviceModeIsBigEndian");

	public static IntegerName GevDeviceModeCharacterSet => new IntegerName("@CameraDevice/GevDeviceModeCharacterSet");

	public static IntegerName GevCurrentSubnetMask => new IntegerName("@CameraDevice/GevCurrentSubnetMask");

	public static BooleanName GevCurrentIPConfigurationPersistentIP => new BooleanName("@CameraDevice/GevCurrentIPConfigurationPersistentIP");

	public static BooleanName GevCurrentIPConfigurationLLA => new BooleanName("@CameraDevice/GevCurrentIPConfigurationLLA");

	public static BooleanName GevCurrentIPConfigurationDHCP => new BooleanName("@CameraDevice/GevCurrentIPConfigurationDHCP");

	public static IntegerName GevCurrentIPConfiguration => new IntegerName("@CameraDevice/GevCurrentIPConfiguration");

	public static IntegerName GevCurrentIPAddress => new IntegerName("@CameraDevice/GevCurrentIPAddress");

	public static IntegerName GevCurrentDefaultGateway => new IntegerName("@CameraDevice/GevCurrentDefaultGateway");

	public static GevCCPEnum GevCCP
	{
		get
		{
			if (m_GevCCPCached == null)
			{
				m_GevCCPCached = new GevCCPEnum();
			}
			return m_GevCCPCached;
		}
	}

	public static GenDCStreamingStatusEnum GenDCStreamingStatus
	{
		get
		{
			if (m_GenDCStreamingStatusCached == null)
			{
				m_GenDCStreamingStatusCached = new GenDCStreamingStatusEnum();
			}
			return m_GenDCStreamingStatusCached;
		}
	}

	public static GenDCStreamingModeEnum GenDCStreamingMode
	{
		get
		{
			if (m_GenDCStreamingModeCached == null)
			{
				m_GenDCStreamingModeCached = new GenDCStreamingModeEnum();
			}
			return m_GenDCStreamingModeCached;
		}
	}

	public static GammaSelectorEnum GammaSelector
	{
		get
		{
			if (m_GammaSelectorCached == null)
			{
				m_GammaSelectorCached = new GammaSelectorEnum();
			}
			return m_GammaSelectorCached;
		}
	}

	public static BooleanName GammaEnable => new BooleanName("@CameraDevice/GammaEnable");

	public static BooleanName GammaCorrection => new BooleanName("@CameraDevice/GammaCorrection");

	public static FloatName Gamma => new FloatName("@CameraDevice/Gamma");

	public static GainSelectorEnum GainSelector
	{
		get
		{
			if (m_GainSelectorCached == null)
			{
				m_GainSelectorCached = new GainSelectorEnum();
			}
			return m_GainSelectorCached;
		}
	}

	public static IntegerName GainRaw => new IntegerName("@CameraDevice/GainRaw");

	public static GainAutoEnum GainAuto
	{
		get
		{
			if (m_GainAutoCached == null)
			{
				m_GainAutoCached = new GainAutoEnum();
			}
			return m_GainAutoCached;
		}
	}

	public static FloatName GainAbs => new FloatName("@CameraDevice/GainAbs");

	public static FloatName Gain => new FloatName("@CameraDevice/Gain");

	public static FrequencyConverterSignalAlignmentEnum FrequencyConverterSignalAlignment
	{
		get
		{
			if (m_FrequencyConverterSignalAlignmentCached == null)
			{
				m_FrequencyConverterSignalAlignmentCached = new FrequencyConverterSignalAlignmentEnum();
			}
			return m_FrequencyConverterSignalAlignmentCached;
		}
	}

	public static BooleanName FrequencyConverterPreventOvertrigger => new BooleanName("@CameraDevice/FrequencyConverterPreventOvertrigger");

	public static IntegerName FrequencyConverterPreDivider => new IntegerName("@CameraDevice/FrequencyConverterPreDivider");

	public static IntegerName FrequencyConverterPostDivider => new IntegerName("@CameraDevice/FrequencyConverterPostDivider");

	public static IntegerName FrequencyConverterMultiplier => new IntegerName("@CameraDevice/FrequencyConverterMultiplier");

	public static FrequencyConverterInputSourceEnum FrequencyConverterInputSource
	{
		get
		{
			if (m_FrequencyConverterInputSourceCached == null)
			{
				m_FrequencyConverterInputSourceCached = new FrequencyConverterInputSourceEnum();
			}
			return m_FrequencyConverterInputSourceCached;
		}
	}

	public static IntegerName FrameWaitEventTimestamp => new IntegerName("@CameraDevice/FrameWaitEventTimestamp");

	public static IntegerName FrameWaitEventStreamChannelIndex => new IntegerName("@CameraDevice/FrameWaitEventStreamChannelIndex");

	public static IntegerName FrameTimeoutEventTimestamp => new IntegerName("@CameraDevice/FrameTimeoutEventTimestamp");

	public static IntegerName FrameTimeoutEventStreamChannelIndex => new IntegerName("@CameraDevice/FrameTimeoutEventStreamChannelIndex");

	public static BooleanName FrameTimeoutEnable => new BooleanName("@CameraDevice/FrameTimeoutEnable");

	public static FloatName FrameTimeoutAbs => new FloatName("@CameraDevice/FrameTimeoutAbs");

	public static IntegerName FrameStartWaitEventTimestamp => new IntegerName("@CameraDevice/FrameStartWaitEventTimestamp");

	public static IntegerName FrameStartWaitEventStreamChannelIndex => new IntegerName("@CameraDevice/FrameStartWaitEventStreamChannelIndex");

	public static IntegerName FrameStartOvertriggerEventTimestamp => new IntegerName("@CameraDevice/FrameStartOvertriggerEventTimestamp");

	public static IntegerName FrameStartOvertriggerEventStreamChannelIndex => new IntegerName("@CameraDevice/FrameStartOvertriggerEventStreamChannelIndex");

	public static IntegerName FrameStartEventTimestamp => new IntegerName("@CameraDevice/FrameStartEventTimestamp");

	public static IntegerName FrameStartEventStreamChannelIndex => new IntegerName("@CameraDevice/FrameStartEventStreamChannelIndex");

	public static IntegerName FrameDuration => new IntegerName("@CameraDevice/FrameDuration");

	public static IntegerName ForceFailedBufferCount => new IntegerName("@CameraDevice/ForceFailedBufferCount");

	public static CommandName ForceFailedBuffer => new CommandName("@CameraDevice/ForceFailedBuffer");

	public static BooleanName FilterTemporal => new BooleanName("@CameraDevice/FilterTemporal");

	public static IntegerName FilterStrength => new IntegerName("@CameraDevice/FilterStrength");

	public static BooleanName FilterSpatial => new BooleanName("@CameraDevice/FilterSpatial");

	public static IntegerName FileSize => new IntegerName("@CameraDevice/FileSize");

	public static FileSelectorEnum FileSelector
	{
		get
		{
			if (m_FileSelectorCached == null)
			{
				m_FileSelectorCached = new FileSelectorEnum();
			}
			return m_FileSelectorCached;
		}
	}

	public static FileOperationStatusEnum FileOperationStatus
	{
		get
		{
			if (m_FileOperationStatusCached == null)
			{
				m_FileOperationStatusCached = new FileOperationStatusEnum();
			}
			return m_FileOperationStatusCached;
		}
	}

	public static FileOperationSelectorEnum FileOperationSelector
	{
		get
		{
			if (m_FileOperationSelectorCached == null)
			{
				m_FileOperationSelectorCached = new FileOperationSelectorEnum();
			}
			return m_FileOperationSelectorCached;
		}
	}

	public static IntegerName FileOperationResult => new IntegerName("@CameraDevice/FileOperationResult");

	public static CommandName FileOperationExecute => new CommandName("@CameraDevice/FileOperationExecute");

	public static FileOpenModeEnum FileOpenMode
	{
		get
		{
			if (m_FileOpenModeCached == null)
			{
				m_FileOpenModeCached = new FileOpenModeEnum();
			}
			return m_FileOpenModeCached;
		}
	}

	public static IntegerName FileAccessOffset => new IntegerName("@CameraDevice/FileAccessOffset");

	public static IntegerName FileAccessLength => new IntegerName("@CameraDevice/FileAccessLength");

	public static ArrayName FileAccessBuffer => new ArrayName("@CameraDevice/FileAccessBuffer");

	public static FieldOutputModeEnum FieldOutputMode
	{
		get
		{
			if (m_FieldOutputModeCached == null)
			{
				m_FieldOutputModeCached = new FieldOutputModeEnum();
			}
			return m_FieldOutputModeCached;
		}
	}

	public static FeatureSetEnum FeatureSet
	{
		get
		{
			if (m_FeatureSetCached == null)
			{
				m_FeatureSetCached = new FeatureSetEnum();
			}
			return m_FeatureSetCached;
		}
	}

	public static BooleanName FastMode => new BooleanName("@CameraDevice/FastMode");

	public static IntegerName ExposureTimeRaw => new IntegerName("@CameraDevice/ExposureTimeRaw");

	public static ExposureTimeModeEnum ExposureTimeMode
	{
		get
		{
			if (m_ExposureTimeModeCached == null)
			{
				m_ExposureTimeModeCached = new ExposureTimeModeEnum();
			}
			return m_ExposureTimeModeCached;
		}
	}

	public static BooleanName ExposureTimeBaseAbsEnable => new BooleanName("@CameraDevice/ExposureTimeBaseAbsEnable");

	public static FloatName ExposureTimeBaseAbs => new FloatName("@CameraDevice/ExposureTimeBaseAbs");

	public static FloatName ExposureTimeAbs => new FloatName("@CameraDevice/ExposureTimeAbs");

	public static FloatName ExposureTime => new FloatName("@CameraDevice/ExposureTime");

	public static IntegerName ExposureStartDelayRaw => new IntegerName("@CameraDevice/ExposureStartDelayRaw");

	public static FloatName ExposureStartDelayAbs => new FloatName("@CameraDevice/ExposureStartDelayAbs");

	public static ExposureOverlapTimeModeEnum ExposureOverlapTimeMode
	{
		get
		{
			if (m_ExposureOverlapTimeModeCached == null)
			{
				m_ExposureOverlapTimeModeCached = new ExposureOverlapTimeModeEnum();
			}
			return m_ExposureOverlapTimeModeCached;
		}
	}

	public static IntegerName ExposureOverlapTimeMaxRaw => new IntegerName("@CameraDevice/ExposureOverlapTimeMaxRaw");

	public static FloatName ExposureOverlapTimeMaxAbs => new FloatName("@CameraDevice/ExposureOverlapTimeMaxAbs");

	public static FloatName ExposureOverlapTimeMax => new FloatName("@CameraDevice/ExposureOverlapTimeMax");

	public static ExposureModeEnum ExposureMode
	{
		get
		{
			if (m_ExposureModeCached == null)
			{
				m_ExposureModeCached = new ExposureModeEnum();
			}
			return m_ExposureModeCached;
		}
	}

	public static IntegerName ExposureEndEventTimestamp => new IntegerName("@CameraDevice/ExposureEndEventTimestamp");

	public static IntegerName ExposureEndEventStreamChannelIndex => new IntegerName("@CameraDevice/ExposureEndEventStreamChannelIndex");

	public static IntegerName ExposureEndEventFrameID => new IntegerName("@CameraDevice/ExposureEndEventFrameID");

	public static ExposureAutoEnum ExposureAuto
	{
		get
		{
			if (m_ExposureAutoCached == null)
			{
				m_ExposureAutoCached = new ExposureAutoEnum();
			}
			return m_ExposureAutoCached;
		}
	}

	public static BooleanName ExpertFeatureEnable => new BooleanName("@CameraDevice/ExpertFeatureEnable");

	public static ExpertFeatureAccessSelectorEnum ExpertFeatureAccessSelector
	{
		get
		{
			if (m_ExpertFeatureAccessSelectorCached == null)
			{
				m_ExpertFeatureAccessSelectorCached = new ExpertFeatureAccessSelectorEnum();
			}
			return m_ExpertFeatureAccessSelectorCached;
		}
	}

	public static IntegerName ExpertFeatureAccessKey => new IntegerName("@CameraDevice/ExpertFeatureAccessKey");

	public static IntegerName EventTestTimestamp => new IntegerName("@CameraDevice/EventTestTimestamp");

	public static IntegerName EventTest => new IntegerName("@CameraDevice/EventTest");

	public static IntegerName EventTemperatureStatusChangedTimestamp => new IntegerName("@CameraDevice/EventTemperatureStatusChangedTimestamp");

	public static EventTemperatureStatusChangedStatusEnum EventTemperatureStatusChangedStatus
	{
		get
		{
			if (m_EventTemperatureStatusChangedStatusCached == null)
			{
				m_EventTemperatureStatusChangedStatusCached = new EventTemperatureStatusChangedStatusEnum();
			}
			return m_EventTemperatureStatusChangedStatusCached;
		}
	}

	public static IntegerName EventTemperatureStatusChanged => new IntegerName("@CameraDevice/EventTemperatureStatusChanged");

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

	public static IntegerName EventOverrunTimestamp => new IntegerName("@CameraDevice/EventOverrunTimestamp");

	public static IntegerName EventOverrunEventTimestamp => new IntegerName("@CameraDevice/EventOverrunEventTimestamp");

	public static IntegerName EventOverrunEventStreamChannelIndex => new IntegerName("@CameraDevice/EventOverrunEventStreamChannelIndex");

	public static IntegerName EventOverrunEventFrameID => new IntegerName("@CameraDevice/EventOverrunEventFrameID");

	public static IntegerName EventOverrun => new IntegerName("@CameraDevice/EventOverrun");

	public static IntegerName EventOverTemperatureTimestamp => new IntegerName("@CameraDevice/EventOverTemperatureTimestamp");

	public static IntegerName EventOverTemperature => new IntegerName("@CameraDevice/EventOverTemperature");

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

	public static IntegerName EventFrameTriggerMissedTimestamp => new IntegerName("@CameraDevice/EventFrameTriggerMissedTimestamp");

	public static IntegerName EventFrameTriggerMissed => new IntegerName("@CameraDevice/EventFrameTriggerMissed");

	public static IntegerName EventFrameStartWaitTimestamp => new IntegerName("@CameraDevice/EventFrameStartWaitTimestamp");

	public static IntegerName EventFrameStartWait => new IntegerName("@CameraDevice/EventFrameStartWait");

	public static IntegerName EventFrameStartTimestamp => new IntegerName("@CameraDevice/EventFrameStartTimestamp");

	public static IntegerName EventFrameStartOvertriggerTimestamp => new IntegerName("@CameraDevice/EventFrameStartOvertriggerTimestamp");

	public static IntegerName EventFrameStartOvertriggerFrameID => new IntegerName("@CameraDevice/EventFrameStartOvertriggerFrameID");

	public static IntegerName EventFrameStartOvertrigger => new IntegerName("@CameraDevice/EventFrameStartOvertrigger");

	public static IntegerName EventFrameStartFrameID => new IntegerName("@CameraDevice/EventFrameStartFrameID");

	public static IntegerName EventFrameStart => new IntegerName("@CameraDevice/EventFrameStart");

	public static IntegerName EventFrameBurstStartWaitTimestamp => new IntegerName("@CameraDevice/EventFrameBurstStartWaitTimestamp");

	public static IntegerName EventFrameBurstStartWait => new IntegerName("@CameraDevice/EventFrameBurstStartWait");

	public static IntegerName EventFrameBurstStartTimestamp => new IntegerName("@CameraDevice/EventFrameBurstStartTimestamp");

	public static IntegerName EventFrameBurstStartOvertriggerTimestamp => new IntegerName("@CameraDevice/EventFrameBurstStartOvertriggerTimestamp");

	public static IntegerName EventFrameBurstStartOvertriggerFrameID => new IntegerName("@CameraDevice/EventFrameBurstStartOvertriggerFrameID");

	public static IntegerName EventFrameBurstStartOvertrigger => new IntegerName("@CameraDevice/EventFrameBurstStartOvertrigger");

	public static IntegerName EventFrameBurstStartFrameID => new IntegerName("@CameraDevice/EventFrameBurstStartFrameID");

	public static IntegerName EventFrameBurstStart => new IntegerName("@CameraDevice/EventFrameBurstStart");

	public static IntegerName EventFrameBufferOverrunTimestamp => new IntegerName("@CameraDevice/EventFrameBufferOverrunTimestamp");

	public static IntegerName EventFrameBufferOverrun => new IntegerName("@CameraDevice/EventFrameBufferOverrun");

	public static IntegerName EventExposureEndTimestamp => new IntegerName("@CameraDevice/EventExposureEndTimestamp");

	public static IntegerName EventExposureEndFrameID => new IntegerName("@CameraDevice/EventExposureEndFrameID");

	public static IntegerName EventExposureEnd => new IntegerName("@CameraDevice/EventExposureEnd");

	public static IntegerName EventCriticalTemperatureTimestamp => new IntegerName("@CameraDevice/EventCriticalTemperatureTimestamp");

	public static IntegerName EventCriticalTemperature => new IntegerName("@CameraDevice/EventCriticalTemperature");

	public static IntegerName EventActionLateTimestamp => new IntegerName("@CameraDevice/EventActionLateTimestamp");

	public static IntegerName EventActionLate => new IntegerName("@CameraDevice/EventActionLate");

	public static BooleanName EnableBurstAcquisition => new BooleanName("@CameraDevice/EnableBurstAcquisition");

	public static IntegerName DigitalShift => new IntegerName("@CameraDevice/DigitalShift");

	public static StringName DeviceVersion => new StringName("@CameraDevice/DeviceVersion");

	public static StringName DeviceVendorName => new StringName("@CameraDevice/DeviceVendorName");

	public static StringName DeviceUserID => new StringName("@CameraDevice/DeviceUserID");

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

	public static DeviceTemperatureSelectorEnum DeviceTemperatureSelector
	{
		get
		{
			if (m_DeviceTemperatureSelectorCached == null)
			{
				m_DeviceTemperatureSelectorCached = new DeviceTemperatureSelectorEnum();
			}
			return m_DeviceTemperatureSelectorCached;
		}
	}

	public static FloatName DeviceTemperature => new FloatName("@CameraDevice/DeviceTemperature");

	public static DeviceTapGeometryEnum DeviceTapGeometry
	{
		get
		{
			if (m_DeviceTapGeometryCached == null)
			{
				m_DeviceTapGeometryCached = new DeviceTapGeometryEnum();
			}
			return m_DeviceTapGeometryCached;
		}
	}

	public static IntegerName DeviceTLVersionSubMinor => new IntegerName("@CameraDevice/DeviceTLVersionSubMinor");

	public static IntegerName DeviceTLVersionMinor => new IntegerName("@CameraDevice/DeviceTLVersionMinor");

	public static IntegerName DeviceTLVersionMajor => new IntegerName("@CameraDevice/DeviceTLVersionMajor");

	public static DeviceTLTypeEnum DeviceTLType
	{
		get
		{
			if (m_DeviceTLTypeCached == null)
			{
				m_DeviceTLTypeCached = new DeviceTLTypeEnum();
			}
			return m_DeviceTLTypeCached;
		}
	}

	public static IntegerName DeviceStreamChannelCount => new IntegerName("@CameraDevice/DeviceStreamChannelCount");

	public static StringName DeviceSerialNumber => new StringName("@CameraDevice/DeviceSerialNumber");

	public static DeviceScanTypeEnum DeviceScanType
	{
		get
		{
			if (m_DeviceScanTypeCached == null)
			{
				m_DeviceScanTypeCached = new DeviceScanTypeEnum();
			}
			return m_DeviceScanTypeCached;
		}
	}

	public static IntegerName DeviceSFNCVersionSubMinor => new IntegerName("@CameraDevice/DeviceSFNCVersionSubMinor");

	public static IntegerName DeviceSFNCVersionMinor => new IntegerName("@CameraDevice/DeviceSFNCVersionMinor");

	public static IntegerName DeviceSFNCVersionMajor => new IntegerName("@CameraDevice/DeviceSFNCVersionMajor");

	public static CommandName DeviceReset => new CommandName("@CameraDevice/DeviceReset");

	public static CommandName DeviceRegistersStreamingStart => new CommandName("@CameraDevice/DeviceRegistersStreamingStart");

	public static CommandName DeviceRegistersStreamingEnd => new CommandName("@CameraDevice/DeviceRegistersStreamingEnd");

	public static DeviceRegistersEndiannessEnum DeviceRegistersEndianness
	{
		get
		{
			if (m_DeviceRegistersEndiannessCached == null)
			{
				m_DeviceRegistersEndiannessCached = new DeviceRegistersEndiannessEnum();
			}
			return m_DeviceRegistersEndiannessCached;
		}
	}

	public static StringName DeviceModelName => new StringName("@CameraDevice/DeviceModelName");

	public static StringName DeviceManufacturerInfo => new StringName("@CameraDevice/DeviceManufacturerInfo");

	public static IntegerName DeviceManifestXMLSubMinorVersion => new IntegerName("@CameraDevice/DeviceManifestXMLSubMinorVersion");

	public static IntegerName DeviceManifestXMLMinorVersion => new IntegerName("@CameraDevice/DeviceManifestXMLMinorVersion");

	public static IntegerName DeviceManifestXMLMajorVersion => new IntegerName("@CameraDevice/DeviceManifestXMLMajorVersion");

	public static IntegerName DeviceManifestSchemaMinorVersion => new IntegerName("@CameraDevice/DeviceManifestSchemaMinorVersion");

	public static IntegerName DeviceManifestSchemaMajorVersion => new IntegerName("@CameraDevice/DeviceManifestSchemaMajorVersion");

	public static StringName DeviceManifestPrimaryURL => new StringName("@CameraDevice/DeviceManifestPrimaryURL");

	public static DeviceLinkThroughputLimitModeEnum DeviceLinkThroughputLimitMode
	{
		get
		{
			if (m_DeviceLinkThroughputLimitModeCached == null)
			{
				m_DeviceLinkThroughputLimitModeCached = new DeviceLinkThroughputLimitModeEnum();
			}
			return m_DeviceLinkThroughputLimitModeCached;
		}
	}

	public static IntegerName DeviceLinkThroughputLimit => new IntegerName("@CameraDevice/DeviceLinkThroughputLimit");

	public static IntegerName DeviceLinkSpeed => new IntegerName("@CameraDevice/DeviceLinkSpeed");

	public static IntegerName DeviceLinkSelector => new IntegerName("@CameraDevice/DeviceLinkSelector");

	public static IntegerName DeviceLinkCurrentThroughput => new IntegerName("@CameraDevice/DeviceLinkCurrentThroughput");

	public static IntegerName DeviceLinkConnectionCount => new IntegerName("@CameraDevice/DeviceLinkConnectionCount");

	public static DeviceIndicatorModeEnum DeviceIndicatorMode
	{
		get
		{
			if (m_DeviceIndicatorModeCached == null)
			{
				m_DeviceIndicatorModeCached = new DeviceIndicatorModeEnum();
			}
			return m_DeviceIndicatorModeCached;
		}
	}

	public static StringName DeviceID => new StringName("@CameraDevice/DeviceID");

	public static IntegerName DeviceGenCPVersionMinor => new IntegerName("@CameraDevice/DeviceGenCPVersionMinor");

	public static IntegerName DeviceGenCPVersionMajor => new IntegerName("@CameraDevice/DeviceGenCPVersionMajor");

	public static StringName DeviceFirmwareVersion => new StringName("@CameraDevice/DeviceFirmwareVersion");

	public static CommandName DeviceFeaturePersistenceStart => new CommandName("@CameraDevice/DeviceFeaturePersistenceStart");

	public static CommandName DeviceFeaturePersistenceEnd => new CommandName("@CameraDevice/DeviceFeaturePersistenceEnd");

	public static StringName DeviceFamilyName => new StringName("@CameraDevice/DeviceFamilyName");

	public static IntegerName DeviceEventChannelCount => new IntegerName("@CameraDevice/DeviceEventChannelCount");

	public static IntegerName DeviceColorPipelineVersion => new IntegerName("@CameraDevice/DeviceColorPipelineVersion");

	public static DeviceCharacterSetEnum DeviceCharacterSet
	{
		get
		{
			if (m_DeviceCharacterSetCached == null)
			{
				m_DeviceCharacterSetCached = new DeviceCharacterSetEnum();
			}
			return m_DeviceCharacterSetCached;
		}
	}

	public static IntegerName DepthMin => new IntegerName("@CameraDevice/DepthMin");

	public static IntegerName DepthMax => new IntegerName("@CameraDevice/DepthMax");

	public static DemosaicingModeEnum DemosaicingMode
	{
		get
		{
			if (m_DemosaicingModeCached == null)
			{
				m_DemosaicingModeCached = new DemosaicingModeEnum();
			}
			return m_DemosaicingModeCached;
		}
	}

	public static DefectPixelCorrectionModeEnum DefectPixelCorrectionMode
	{
		get
		{
			if (m_DefectPixelCorrectionModeCached == null)
			{
				m_DefectPixelCorrectionModeCached = new DefectPixelCorrectionModeEnum();
			}
			return m_DefectPixelCorrectionModeCached;
		}
	}

	public static IntegerName DecimationVertical => new IntegerName("@CameraDevice/DecimationVertical");

	public static IntegerName DecimationHorizontal => new IntegerName("@CameraDevice/DecimationHorizontal");

	public static CxpSendReceiveSelectorEnum CxpSendReceiveSelector
	{
		get
		{
			if (m_CxpSendReceiveSelectorCached == null)
			{
				m_CxpSendReceiveSelectorCached = new CxpSendReceiveSelectorEnum();
			}
			return m_CxpSendReceiveSelectorCached;
		}
	}

	public static CxpLinkConfigurationStatusEnum CxpLinkConfigurationStatus
	{
		get
		{
			if (m_CxpLinkConfigurationStatusCached == null)
			{
				m_CxpLinkConfigurationStatusCached = new CxpLinkConfigurationStatusEnum();
			}
			return m_CxpLinkConfigurationStatusCached;
		}
	}

	public static CxpLinkConfigurationPreferredEnum CxpLinkConfigurationPreferred
	{
		get
		{
			if (m_CxpLinkConfigurationPreferredCached == null)
			{
				m_CxpLinkConfigurationPreferredCached = new CxpLinkConfigurationPreferredEnum();
			}
			return m_CxpLinkConfigurationPreferredCached;
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

	public static IntegerName CxpErrorCounterValue => new IntegerName("@CameraDevice/CxpErrorCounterValue");

	public static CxpErrorCounterStatusEnum CxpErrorCounterStatus
	{
		get
		{
			if (m_CxpErrorCounterStatusCached == null)
			{
				m_CxpErrorCounterStatusCached = new CxpErrorCounterStatusEnum();
			}
			return m_CxpErrorCounterStatusCached;
		}
	}

	public static CxpErrorCounterSelectorEnum CxpErrorCounterSelector
	{
		get
		{
			if (m_CxpErrorCounterSelectorCached == null)
			{
				m_CxpErrorCounterSelectorCached = new CxpErrorCounterSelectorEnum();
			}
			return m_CxpErrorCounterSelectorCached;
		}
	}

	public static CommandName CxpErrorCounterReset => new CommandName("@CameraDevice/CxpErrorCounterReset");

	public static IntegerName CxpConnectionTestPacketCount => new IntegerName("@CameraDevice/CxpConnectionTestPacketCount");

	public static CxpConnectionTestModeEnum CxpConnectionTestMode
	{
		get
		{
			if (m_CxpConnectionTestModeCached == null)
			{
				m_CxpConnectionTestModeCached = new CxpConnectionTestModeEnum();
			}
			return m_CxpConnectionTestModeCached;
		}
	}

	public static IntegerName CxpConnectionTestErrorCount => new IntegerName("@CameraDevice/CxpConnectionTestErrorCount");

	public static IntegerName CxpConnectionSelector => new IntegerName("@CameraDevice/CxpConnectionSelector");

	public static IntegerName CriticalTemperatureEventTimestamp => new IntegerName("@CameraDevice/CriticalTemperatureEventTimestamp");

	public static IntegerName CriticalTemperatureEventStreamChannelIndex => new IntegerName("@CameraDevice/CriticalTemperatureEventStreamChannelIndex");

	public static BooleanName CriticalTemperature => new BooleanName("@CameraDevice/CriticalTemperature");

	public static IntegerName CounterValue => new IntegerName("@CameraDevice/CounterValue");

	public static CounterTriggerSourceEnum CounterTriggerSource
	{
		get
		{
			if (m_CounterTriggerSourceCached == null)
			{
				m_CounterTriggerSourceCached = new CounterTriggerSourceEnum();
			}
			return m_CounterTriggerSourceCached;
		}
	}

	public static CounterTriggerActivationEnum CounterTriggerActivation
	{
		get
		{
			if (m_CounterTriggerActivationCached == null)
			{
				m_CounterTriggerActivationCached = new CounterTriggerActivationEnum();
			}
			return m_CounterTriggerActivationCached;
		}
	}

	public static CounterStatusEnum CounterStatus
	{
		get
		{
			if (m_CounterStatusCached == null)
			{
				m_CounterStatusCached = new CounterStatusEnum();
			}
			return m_CounterStatusCached;
		}
	}

	public static CounterSelectorEnum CounterSelector
	{
		get
		{
			if (m_CounterSelectorCached == null)
			{
				m_CounterSelectorCached = new CounterSelectorEnum();
			}
			return m_CounterSelectorCached;
		}
	}

	public static CounterResetSourceEnum CounterResetSource
	{
		get
		{
			if (m_CounterResetSourceCached == null)
			{
				m_CounterResetSourceCached = new CounterResetSourceEnum();
			}
			return m_CounterResetSourceCached;
		}
	}

	public static CounterResetActivationEnum CounterResetActivation
	{
		get
		{
			if (m_CounterResetActivationCached == null)
			{
				m_CounterResetActivationCached = new CounterResetActivationEnum();
			}
			return m_CounterResetActivationCached;
		}
	}

	public static CommandName CounterReset => new CommandName("@CameraDevice/CounterReset");

	public static CounterEventSourceEnum CounterEventSource
	{
		get
		{
			if (m_CounterEventSourceCached == null)
			{
				m_CounterEventSourceCached = new CounterEventSourceEnum();
			}
			return m_CounterEventSourceCached;
		}
	}

	public static CounterEventActivationEnum CounterEventActivation
	{
		get
		{
			if (m_CounterEventActivationCached == null)
			{
				m_CounterEventActivationCached = new CounterEventActivationEnum();
			}
			return m_CounterEventActivationCached;
		}
	}

	public static IntegerName CounterDuration => new IntegerName("@CameraDevice/CounterDuration");

	public static IntegerName ConfidenceThreshold => new IntegerName("@CameraDevice/ConfidenceThreshold");

	public static ComponentSelectorEnum ComponentSelector
	{
		get
		{
			if (m_ComponentSelectorCached == null)
			{
				m_ComponentSelectorCached = new ComponentSelectorEnum();
			}
			return m_ComponentSelectorCached;
		}
	}

	public static BooleanName ComponentEnable => new BooleanName("@CameraDevice/ComponentEnable");

	public static ColorTransformationValueSelectorEnum ColorTransformationValueSelector
	{
		get
		{
			if (m_ColorTransformationValueSelectorCached == null)
			{
				m_ColorTransformationValueSelectorCached = new ColorTransformationValueSelectorEnum();
			}
			return m_ColorTransformationValueSelectorCached;
		}
	}

	public static IntegerName ColorTransformationValueRaw => new IntegerName("@CameraDevice/ColorTransformationValueRaw");

	public static FloatName ColorTransformationValue => new FloatName("@CameraDevice/ColorTransformationValue");

	public static ColorTransformationSelectorEnum ColorTransformationSelector
	{
		get
		{
			if (m_ColorTransformationSelectorCached == null)
			{
				m_ColorTransformationSelectorCached = new ColorTransformationSelectorEnum();
			}
			return m_ColorTransformationSelectorCached;
		}
	}

	public static IntegerName ColorTransformationMatrixFactorRaw => new IntegerName("@CameraDevice/ColorTransformationMatrixFactorRaw");

	public static FloatName ColorTransformationMatrixFactor => new FloatName("@CameraDevice/ColorTransformationMatrixFactor");

	public static BooleanName ColorTransformationEnable => new BooleanName("@CameraDevice/ColorTransformationEnable");

	public static ColorSpaceEnum ColorSpace
	{
		get
		{
			if (m_ColorSpaceCached == null)
			{
				m_ColorSpaceCached = new ColorSpaceEnum();
			}
			return m_ColorSpaceCached;
		}
	}

	public static IntegerName ColorOverexposureCompensationAOIWidth => new IntegerName("@CameraDevice/ColorOverexposureCompensationAOIWidth");

	public static ColorOverexposureCompensationAOISelectorEnum ColorOverexposureCompensationAOISelector
	{
		get
		{
			if (m_ColorOverexposureCompensationAOISelectorCached == null)
			{
				m_ColorOverexposureCompensationAOISelectorCached = new ColorOverexposureCompensationAOISelectorEnum();
			}
			return m_ColorOverexposureCompensationAOISelectorCached;
		}
	}

	public static IntegerName ColorOverexposureCompensationAOIOffsetY => new IntegerName("@CameraDevice/ColorOverexposureCompensationAOIOffsetY");

	public static IntegerName ColorOverexposureCompensationAOIOffsetX => new IntegerName("@CameraDevice/ColorOverexposureCompensationAOIOffsetX");

	public static IntegerName ColorOverexposureCompensationAOIHeight => new IntegerName("@CameraDevice/ColorOverexposureCompensationAOIHeight");

	public static IntegerName ColorOverexposureCompensationAOIFactorRaw => new IntegerName("@CameraDevice/ColorOverexposureCompensationAOIFactorRaw");

	public static FloatName ColorOverexposureCompensationAOIFactor => new FloatName("@CameraDevice/ColorOverexposureCompensationAOIFactor");

	public static BooleanName ColorOverexposureCompensationAOIEnable => new BooleanName("@CameraDevice/ColorOverexposureCompensationAOIEnable");

	public static ColorAdjustmentSelectorEnum ColorAdjustmentSelector
	{
		get
		{
			if (m_ColorAdjustmentSelectorCached == null)
			{
				m_ColorAdjustmentSelectorCached = new ColorAdjustmentSelectorEnum();
			}
			return m_ColorAdjustmentSelectorCached;
		}
	}

	public static IntegerName ColorAdjustmentSaturationRaw => new IntegerName("@CameraDevice/ColorAdjustmentSaturationRaw");

	public static FloatName ColorAdjustmentSaturation => new FloatName("@CameraDevice/ColorAdjustmentSaturation");

	public static CommandName ColorAdjustmentReset => new CommandName("@CameraDevice/ColorAdjustmentReset");

	public static IntegerName ColorAdjustmentHueRaw => new IntegerName("@CameraDevice/ColorAdjustmentHueRaw");

	public static FloatName ColorAdjustmentHue => new FloatName("@CameraDevice/ColorAdjustmentHue");

	public static BooleanName ColorAdjustmentEnable => new BooleanName("@CameraDevice/ColorAdjustmentEnable");

	public static CommandName ClearLastError => new CommandName("@CameraDevice/ClearLastError");

	public static ClTimeSlotsEnum ClTimeSlots
	{
		get
		{
			if (m_ClTimeSlotsCached == null)
			{
				m_ClTimeSlotsCached = new ClTimeSlotsEnum();
			}
			return m_ClTimeSlotsCached;
		}
	}

	public static ClTapGeometryEnum ClTapGeometry
	{
		get
		{
			if (m_ClTapGeometryCached == null)
			{
				m_ClTapGeometryCached = new ClTapGeometryEnum();
			}
			return m_ClTapGeometryCached;
		}
	}

	public static ClSerialPortBaudRateEnum ClSerialPortBaudRate
	{
		get
		{
			if (m_ClSerialPortBaudRateCached == null)
			{
				m_ClSerialPortBaudRateCached = new ClSerialPortBaudRateEnum();
			}
			return m_ClSerialPortBaudRateCached;
		}
	}

	public static FloatName ClPixelClockAbs => new FloatName("@CameraDevice/ClPixelClockAbs");

	public static ClPixelClockEnum ClPixelClock
	{
		get
		{
			if (m_ClPixelClockCached == null)
			{
				m_ClPixelClockCached = new ClPixelClockEnum();
			}
			return m_ClPixelClockCached;
		}
	}

	public static IntegerName ClInterLineDelayRaw => new IntegerName("@CameraDevice/ClInterLineDelayRaw");

	public static FloatName ClInterLineDelayAbs => new FloatName("@CameraDevice/ClInterLineDelayAbs");

	public static ClConfigurationEnum ClConfiguration
	{
		get
		{
			if (m_ClConfigurationCached == null)
			{
				m_ClConfigurationCached = new ClConfigurationEnum();
			}
			return m_ClConfigurationCached;
		}
	}

	public static IntegerName ChunkWidth => new IntegerName("@CameraDevice/ChunkWidth");

	public static IntegerName ChunkVirtLineStatusAll => new IntegerName("@CameraDevice/ChunkVirtLineStatusAll");

	public static IntegerName ChunkTriggerinputcounter => new IntegerName("@CameraDevice/ChunkTriggerinputcounter");

	public static IntegerName ChunkTimestamp => new IntegerName("@CameraDevice/ChunkTimestamp");

	public static IntegerName ChunkStride => new IntegerName("@CameraDevice/ChunkStride");

	public static IntegerName ChunkShaftEncoderCounter => new IntegerName("@CameraDevice/ChunkShaftEncoderCounter");

	public static IntegerName ChunkSequencerSetActive => new IntegerName("@CameraDevice/ChunkSequencerSetActive");

	public static IntegerName ChunkSequenceSetIndex => new IntegerName("@CameraDevice/ChunkSequenceSetIndex");

	public static ChunkSelectorEnum ChunkSelector
	{
		get
		{
			if (m_ChunkSelectorCached == null)
			{
				m_ChunkSelectorCached = new ChunkSelectorEnum();
			}
			return m_ChunkSelectorCached;
		}
	}

	public static ChunkPixelFormatEnum ChunkPixelFormat
	{
		get
		{
			if (m_ChunkPixelFormatCached == null)
			{
				m_ChunkPixelFormatCached = new ChunkPixelFormatEnum();
			}
			return m_ChunkPixelFormatCached;
		}
	}

	public static IntegerName ChunkPixelDynamicRangeMin => new IntegerName("@CameraDevice/ChunkPixelDynamicRangeMin");

	public static IntegerName ChunkPixelDynamicRangeMax => new IntegerName("@CameraDevice/ChunkPixelDynamicRangeMax");

	public static IntegerName ChunkPayloadCRC16 => new IntegerName("@CameraDevice/ChunkPayloadCRC16");

	public static IntegerName ChunkOffsetY => new IntegerName("@CameraDevice/ChunkOffsetY");

	public static IntegerName ChunkOffsetX => new IntegerName("@CameraDevice/ChunkOffsetX");

	public static BooleanName ChunkModeActive => new BooleanName("@CameraDevice/ChunkModeActive");

	public static IntegerName ChunkLineTriggerIgnoredCounter => new IntegerName("@CameraDevice/ChunkLineTriggerIgnoredCounter");

	public static IntegerName ChunkLineTriggerEndToEndCounter => new IntegerName("@CameraDevice/ChunkLineTriggerEndToEndCounter");

	public static IntegerName ChunkLineTriggerCounter => new IntegerName("@CameraDevice/ChunkLineTriggerCounter");

	public static IntegerName ChunkLineStatusAll => new IntegerName("@CameraDevice/ChunkLineStatusAll");

	public static IntegerName ChunkInputStatusAtLineTriggerValue => new IntegerName("@CameraDevice/ChunkInputStatusAtLineTriggerValue");

	public static IntegerName ChunkInputStatusAtLineTriggerIndex => new IntegerName("@CameraDevice/ChunkInputStatusAtLineTriggerIndex");

	public static IntegerName ChunkInputStatusAtLineTriggerBitsPerLine => new IntegerName("@CameraDevice/ChunkInputStatusAtLineTriggerBitsPerLine");

	public static IntegerName ChunkHeight => new IntegerName("@CameraDevice/ChunkHeight");

	public static ChunkGainSelectorEnum ChunkGainSelector
	{
		get
		{
			if (m_ChunkGainSelectorCached == null)
			{
				m_ChunkGainSelectorCached = new ChunkGainSelectorEnum();
			}
			return m_ChunkGainSelectorCached;
		}
	}

	public static IntegerName ChunkGainAll => new IntegerName("@CameraDevice/ChunkGainAll");

	public static FloatName ChunkGain => new FloatName("@CameraDevice/ChunkGain");

	public static IntegerName ChunkFramesPerTriggerCounter => new IntegerName("@CameraDevice/ChunkFramesPerTriggerCounter");

	public static IntegerName ChunkFramecounter => new IntegerName("@CameraDevice/ChunkFramecounter");

	public static IntegerName ChunkFrameTriggerIgnoredCounter => new IntegerName("@CameraDevice/ChunkFrameTriggerIgnoredCounter");

	public static IntegerName ChunkFrameTriggerCounter => new IntegerName("@CameraDevice/ChunkFrameTriggerCounter");

	public static IntegerName ChunkFrameID => new IntegerName("@CameraDevice/ChunkFrameID");

	public static FloatName ChunkExposureTime => new FloatName("@CameraDevice/ChunkExposureTime");

	public static BooleanName ChunkEnable => new BooleanName("@CameraDevice/ChunkEnable");

	public static IntegerName ChunkDynamicRangeMin => new IntegerName("@CameraDevice/ChunkDynamicRangeMin");

	public static IntegerName ChunkDynamicRangeMax => new IntegerName("@CameraDevice/ChunkDynamicRangeMax");

	public static IntegerName ChunkCounterValue => new IntegerName("@CameraDevice/ChunkCounterValue");

	public static ChunkCounterSelectorEnum ChunkCounterSelector
	{
		get
		{
			if (m_ChunkCounterSelectorCached == null)
			{
				m_ChunkCounterSelectorCached = new ChunkCounterSelectorEnum();
			}
			return m_ChunkCounterSelectorCached;
		}
	}

	public static BooleanName CenterY => new BooleanName("@CameraDevice/CenterY");

	public static BooleanName CenterX => new BooleanName("@CameraDevice/CenterX");

	public static CameraOperationModeEnum CameraOperationMode
	{
		get
		{
			if (m_CameraOperationModeCached == null)
			{
				m_CameraOperationModeCached = new CameraOperationModeEnum();
			}
			return m_CameraOperationModeCached;
		}
	}

	public static BslVignettingCorrectionModeEnum BslVignettingCorrectionMode
	{
		get
		{
			if (m_BslVignettingCorrectionModeCached == null)
			{
				m_BslVignettingCorrectionModeCached = new BslVignettingCorrectionModeEnum();
			}
			return m_BslVignettingCorrectionModeCached;
		}
	}

	public static CommandName BslVignettingCorrectionLoad => new CommandName("@CameraDevice/BslVignettingCorrectionLoad");

	public static BslUSBSpeedModeEnum BslUSBSpeedMode
	{
		get
		{
			if (m_BslUSBSpeedModeCached == null)
			{
				m_BslUSBSpeedModeCached = new BslUSBSpeedModeEnum();
			}
			return m_BslUSBSpeedModeCached;
		}
	}

	public static BslUSBPowerSourceEnum BslUSBPowerSource
	{
		get
		{
			if (m_BslUSBPowerSourceCached == null)
			{
				m_BslUSBPowerSourceCached = new BslUSBPowerSourceEnum();
			}
			return m_BslUSBPowerSourceCached;
		}
	}

	public static CommandName BslTwiWrite => new CommandName("@CameraDevice/BslTwiWrite");

	public static CommandName BslTwiUpdateTransferStatus => new CommandName("@CameraDevice/BslTwiUpdateTransferStatus");

	public static BslTwiTransferStatusEnum BslTwiTransferStatus
	{
		get
		{
			if (m_BslTwiTransferStatusCached == null)
			{
				m_BslTwiTransferStatusCached = new BslTwiTransferStatusEnum();
			}
			return m_BslTwiTransferStatusCached;
		}
	}

	public static IntegerName BslTwiTransferLength => new IntegerName("@CameraDevice/BslTwiTransferLength");

	public static ArrayName BslTwiTransferBuffer => new ArrayName("@CameraDevice/BslTwiTransferBuffer");

	public static IntegerName BslTwiTargetAddress => new IntegerName("@CameraDevice/BslTwiTargetAddress");

	public static CommandName BslTwiRead => new CommandName("@CameraDevice/BslTwiRead");

	public static BooleanName BslTwiPullSdaLow => new BooleanName("@CameraDevice/BslTwiPullSdaLow");

	public static BooleanName BslTwiPullSclLow => new BooleanName("@CameraDevice/BslTwiPullSclLow");

	public static BslTwiBitrateEnum BslTwiBitrate
	{
		get
		{
			if (m_BslTwiBitrateCached == null)
			{
				m_BslTwiBitrateCached = new BslTwiBitrateEnum();
			}
			return m_BslTwiBitrateCached;
		}
	}

	public static BslTransferBitDepthModeEnum BslTransferBitDepthMode
	{
		get
		{
			if (m_BslTransferBitDepthModeCached == null)
			{
				m_BslTransferBitDepthModeCached = new BslTransferBitDepthModeEnum();
			}
			return m_BslTransferBitDepthModeCached;
		}
	}

	public static BslTransferBitDepthEnum BslTransferBitDepth
	{
		get
		{
			if (m_BslTransferBitDepthCached == null)
			{
				m_BslTransferBitDepthCached = new BslTransferBitDepthEnum();
			}
			return m_BslTransferBitDepthCached;
		}
	}

	public static IntegerName BslTemperatureStatusErrorCount => new IntegerName("@CameraDevice/BslTemperatureStatusErrorCount");

	public static BslTemperatureStatusEnum BslTemperatureStatus
	{
		get
		{
			if (m_BslTemperatureStatusCached == null)
			{
				m_BslTemperatureStatusCached = new BslTemperatureStatusEnum();
			}
			return m_BslTemperatureStatusCached;
		}
	}

	public static FloatName BslTemperatureMax => new FloatName("@CameraDevice/BslTemperatureMax");

	public static FloatName BslSharpnessEnhancement => new FloatName("@CameraDevice/BslSharpnessEnhancement");

	public static BooleanName BslSerialTxFifoOverflow => new BooleanName("@CameraDevice/BslSerialTxFifoOverflow");

	public static BooleanName BslSerialTxFifoEmpty => new BooleanName("@CameraDevice/BslSerialTxFifoEmpty");

	public static BooleanName BslSerialTxBreak => new BooleanName("@CameraDevice/BslSerialTxBreak");

	public static CommandName BslSerialTransmit => new CommandName("@CameraDevice/BslSerialTransmit");

	public static IntegerName BslSerialTransferLength => new IntegerName("@CameraDevice/BslSerialTransferLength");

	public static ArrayName BslSerialTransferBuffer => new ArrayName("@CameraDevice/BslSerialTransferBuffer");

	public static BooleanName BslSerialRxStopBitError => new BooleanName("@CameraDevice/BslSerialRxStopBitError");

	public static BslSerialRxSourceEnum BslSerialRxSource
	{
		get
		{
			if (m_BslSerialRxSourceCached == null)
			{
				m_BslSerialRxSourceCached = new BslSerialRxSourceEnum();
			}
			return m_BslSerialRxSourceCached;
		}
	}

	public static BooleanName BslSerialRxParityError => new BooleanName("@CameraDevice/BslSerialRxParityError");

	public static BooleanName BslSerialRxFifoOverflow => new BooleanName("@CameraDevice/BslSerialRxFifoOverflow");

	public static CommandName BslSerialRxBreakReset => new CommandName("@CameraDevice/BslSerialRxBreakReset");

	public static BooleanName BslSerialRxBreak => new BooleanName("@CameraDevice/BslSerialRxBreak");

	public static CommandName BslSerialReceive => new CommandName("@CameraDevice/BslSerialReceive");

	public static BslSerialParityEnum BslSerialParity
	{
		get
		{
			if (m_BslSerialParityCached == null)
			{
				m_BslSerialParityCached = new BslSerialParityEnum();
			}
			return m_BslSerialParityCached;
		}
	}

	public static BslSerialNumberOfStopBitsEnum BslSerialNumberOfStopBits
	{
		get
		{
			if (m_BslSerialNumberOfStopBitsCached == null)
			{
				m_BslSerialNumberOfStopBitsCached = new BslSerialNumberOfStopBitsEnum();
			}
			return m_BslSerialNumberOfStopBitsCached;
		}
	}

	public static BslSerialNumberOfDataBitsEnum BslSerialNumberOfDataBits
	{
		get
		{
			if (m_BslSerialNumberOfDataBitsCached == null)
			{
				m_BslSerialNumberOfDataBitsCached = new BslSerialNumberOfDataBitsEnum();
			}
			return m_BslSerialNumberOfDataBitsCached;
		}
	}

	public static BslSerialBaudRateEnum BslSerialBaudRate
	{
		get
		{
			if (m_BslSerialBaudRateCached == null)
			{
				m_BslSerialBaudRateCached = new BslSerialBaudRateEnum();
			}
			return m_BslSerialBaudRateCached;
		}
	}

	public static BslSensorStateEnum BslSensorState
	{
		get
		{
			if (m_BslSensorStateCached == null)
			{
				m_BslSensorStateCached = new BslSensorStateEnum();
			}
			return m_BslSensorStateCached;
		}
	}

	public static CommandName BslSensorStandby => new CommandName("@CameraDevice/BslSensorStandby");

	public static CommandName BslSensorOn => new CommandName("@CameraDevice/BslSensorOn");

	public static CommandName BslSensorOff => new CommandName("@CameraDevice/BslSensorOff");

	public static BslSensorBitDepthModeEnum BslSensorBitDepthMode
	{
		get
		{
			if (m_BslSensorBitDepthModeCached == null)
			{
				m_BslSensorBitDepthModeCached = new BslSensorBitDepthModeEnum();
			}
			return m_BslSensorBitDepthModeCached;
		}
	}

	public static BslSensorBitDepthEnum BslSensorBitDepth
	{
		get
		{
			if (m_BslSensorBitDepthCached == null)
			{
				m_BslSensorBitDepthCached = new BslSensorBitDepthEnum();
			}
			return m_BslSensorBitDepthCached;
		}
	}

	public static FloatName BslScalingFactor => new FloatName("@CameraDevice/BslScalingFactor");

	public static FloatName BslSaturationValue => new FloatName("@CameraDevice/BslSaturationValue");

	public static IntegerName BslSaturationRaw => new IntegerName("@CameraDevice/BslSaturationRaw");

	public static FloatName BslSaturation => new FloatName("@CameraDevice/BslSaturation");

	public static FloatName BslResultingTransferFrameRate => new FloatName("@CameraDevice/BslResultingTransferFrameRate");

	public static FloatName BslResultingFrameBurstRate => new FloatName("@CameraDevice/BslResultingFrameBurstRate");

	public static FloatName BslResultingAcquisitionFrameRate => new FloatName("@CameraDevice/BslResultingAcquisitionFrameRate");

	public static IntegerName BslPtpUcPortAddrIndex => new IntegerName("@CameraDevice/BslPtpUcPortAddrIndex");

	public static IntegerName BslPtpUcPortAddr => new IntegerName("@CameraDevice/BslPtpUcPortAddr");

	public static BooleanName BslPtpTwoStep => new BooleanName("@CameraDevice/BslPtpTwoStep");

	public static BslPtpProfileEnum BslPtpProfile
	{
		get
		{
			if (m_BslPtpProfileCached == null)
			{
				m_BslPtpProfileCached = new BslPtpProfileEnum();
			}
			return m_BslPtpProfileCached;
		}
	}

	public static IntegerName BslPtpPriority1 => new IntegerName("@CameraDevice/BslPtpPriority1");

	public static BslPtpNetworkModeEnum BslPtpNetworkMode
	{
		get
		{
			if (m_BslPtpNetworkModeCached == null)
			{
				m_BslPtpNetworkModeCached = new BslPtpNetworkModeEnum();
			}
			return m_BslPtpNetworkModeCached;
		}
	}

	public static BooleanName BslPtpManagementEnable => new BooleanName("@CameraDevice/BslPtpManagementEnable");

	public static BslPtpDelayMechanismEnum BslPtpDelayMechanism
	{
		get
		{
			if (m_BslPtpDelayMechanismCached == null)
			{
				m_BslPtpDelayMechanismCached = new BslPtpDelayMechanismEnum();
			}
			return m_BslPtpDelayMechanismCached;
		}
	}

	public static BslPeriodicSignalSourceEnum BslPeriodicSignalSource
	{
		get
		{
			if (m_BslPeriodicSignalSourceCached == null)
			{
				m_BslPeriodicSignalSourceCached = new BslPeriodicSignalSourceEnum();
			}
			return m_BslPeriodicSignalSourceCached;
		}
	}

	public static BslPeriodicSignalSelectorEnum BslPeriodicSignalSelector
	{
		get
		{
			if (m_BslPeriodicSignalSelectorCached == null)
			{
				m_BslPeriodicSignalSelectorCached = new BslPeriodicSignalSelectorEnum();
			}
			return m_BslPeriodicSignalSelectorCached;
		}
	}

	public static FloatName BslPeriodicSignalPeriod => new FloatName("@CameraDevice/BslPeriodicSignalPeriod");

	public static FloatName BslPeriodicSignalDelay => new FloatName("@CameraDevice/BslPeriodicSignalDelay");

	public static FloatName BslNoiseReduction => new FloatName("@CameraDevice/BslNoiseReduction");

	public static BooleanName BslMultipleROIRowsEnable => new BooleanName("@CameraDevice/BslMultipleROIRowsEnable");

	public static IntegerName BslMultipleROIRowSize => new IntegerName("@CameraDevice/BslMultipleROIRowSize");

	public static BslMultipleROIRowSelectorEnum BslMultipleROIRowSelector
	{
		get
		{
			if (m_BslMultipleROIRowSelectorCached == null)
			{
				m_BslMultipleROIRowSelectorCached = new BslMultipleROIRowSelectorEnum();
			}
			return m_BslMultipleROIRowSelectorCached;
		}
	}

	public static IntegerName BslMultipleROIRowOffset => new IntegerName("@CameraDevice/BslMultipleROIRowOffset");

	public static BooleanName BslMultipleROIColumnsEnable => new BooleanName("@CameraDevice/BslMultipleROIColumnsEnable");

	public static IntegerName BslMultipleROIColumnSize => new IntegerName("@CameraDevice/BslMultipleROIColumnSize");

	public static BslMultipleROIColumnSelectorEnum BslMultipleROIColumnSelector
	{
		get
		{
			if (m_BslMultipleROIColumnSelectorCached == null)
			{
				m_BslMultipleROIColumnSelectorCached = new BslMultipleROIColumnSelectorEnum();
			}
			return m_BslMultipleROIColumnSelectorCached;
		}
	}

	public static IntegerName BslMultipleROIColumnOffset => new IntegerName("@CameraDevice/BslMultipleROIColumnOffset");

	public static BooleanName BslLineOverloadStatus => new BooleanName("@CameraDevice/BslLineOverloadStatus");

	public static BslLineConnectionEnum BslLineConnection
	{
		get
		{
			if (m_BslLineConnectionCached == null)
			{
				m_BslLineConnectionCached = new BslLineConnectionEnum();
			}
			return m_BslLineConnectionCached;
		}
	}

	public static BslLightSourcePresetFeatureSelectorEnum BslLightSourcePresetFeatureSelector
	{
		get
		{
			if (m_BslLightSourcePresetFeatureSelectorCached == null)
			{
				m_BslLightSourcePresetFeatureSelectorCached = new BslLightSourcePresetFeatureSelectorEnum();
			}
			return m_BslLightSourcePresetFeatureSelectorCached;
		}
	}

	public static BooleanName BslLightSourcePresetFeatureEnable => new BooleanName("@CameraDevice/BslLightSourcePresetFeatureEnable");

	public static BslLightSourcePresetEnum BslLightSourcePreset
	{
		get
		{
			if (m_BslLightSourcePresetCached == null)
			{
				m_BslLightSourcePresetCached = new BslLightSourcePresetEnum();
			}
			return m_BslLightSourcePresetCached;
		}
	}

	public static BslLightDeviceStrobeModeEnum BslLightDeviceStrobeMode
	{
		get
		{
			if (m_BslLightDeviceStrobeModeCached == null)
			{
				m_BslLightDeviceStrobeModeCached = new BslLightDeviceStrobeModeEnum();
			}
			return m_BslLightDeviceStrobeModeCached;
		}
	}

	public static IntegerName BslLightDeviceStrobeDurationRaw => new IntegerName("@CameraDevice/BslLightDeviceStrobeDurationRaw");

	public static FloatName BslLightDeviceStrobeDuration => new FloatName("@CameraDevice/BslLightDeviceStrobeDuration");

	public static BslLightDeviceSelectorEnum BslLightDeviceSelector
	{
		get
		{
			if (m_BslLightDeviceSelectorCached == null)
			{
				m_BslLightDeviceSelectorCached = new BslLightDeviceSelectorEnum();
			}
			return m_BslLightDeviceSelectorCached;
		}
	}

	public static BslLightDeviceOperationModeEnum BslLightDeviceOperationMode
	{
		get
		{
			if (m_BslLightDeviceOperationModeCached == null)
			{
				m_BslLightDeviceOperationModeCached = new BslLightDeviceOperationModeEnum();
			}
			return m_BslLightDeviceOperationModeCached;
		}
	}

	public static IntegerName BslLightDeviceMaxCurrentRaw => new IntegerName("@CameraDevice/BslLightDeviceMaxCurrentRaw");

	public static FloatName BslLightDeviceMaxCurrent => new FloatName("@CameraDevice/BslLightDeviceMaxCurrent");

	public static BslLightDeviceLastErrorEnum BslLightDeviceLastError
	{
		get
		{
			if (m_BslLightDeviceLastErrorCached == null)
			{
				m_BslLightDeviceLastErrorCached = new BslLightDeviceLastErrorEnum();
			}
			return m_BslLightDeviceLastErrorCached;
		}
	}

	public static StringName BslLightDeviceFirmwareVersion => new StringName("@CameraDevice/BslLightDeviceFirmwareVersion");

	public static CommandName BslLightDeviceClearLastError => new CommandName("@CameraDevice/BslLightDeviceClearLastError");

	public static BslLightDeviceChangeIDEnum BslLightDeviceChangeID
	{
		get
		{
			if (m_BslLightDeviceChangeIDCached == null)
			{
				m_BslLightDeviceChangeIDCached = new BslLightDeviceChangeIDEnum();
			}
			return m_BslLightDeviceChangeIDCached;
		}
	}

	public static IntegerName BslLightDeviceBrightnessRaw => new IntegerName("@CameraDevice/BslLightDeviceBrightnessRaw");

	public static FloatName BslLightDeviceBrightness => new FloatName("@CameraDevice/BslLightDeviceBrightness");

	public static BslLightControlStatusEnum BslLightControlStatus
	{
		get
		{
			if (m_BslLightControlStatusCached == null)
			{
				m_BslLightControlStatusCached = new BslLightControlStatusEnum();
			}
			return m_BslLightControlStatusCached;
		}
	}

	public static BslLightControlSourceEnum BslLightControlSource
	{
		get
		{
			if (m_BslLightControlSourceCached == null)
			{
				m_BslLightControlSourceCached = new BslLightControlSourceEnum();
			}
			return m_BslLightControlSourceCached;
		}
	}

	public static BslLightControlModeEnum BslLightControlMode
	{
		get
		{
			if (m_BslLightControlModeCached == null)
			{
				m_BslLightControlModeCached = new BslLightControlModeEnum();
			}
			return m_BslLightControlModeCached;
		}
	}

	public static BslLightControlErrorStatusEnum BslLightControlErrorStatus
	{
		get
		{
			if (m_BslLightControlErrorStatusCached == null)
			{
				m_BslLightControlErrorStatusCached = new BslLightControlErrorStatusEnum();
			}
			return m_BslLightControlErrorStatusCached;
		}
	}

	public static CommandName BslLightControlEnumerateDevices => new CommandName("@CameraDevice/BslLightControlEnumerateDevices");

	public static FloatName BslInputHoldOffTime => new FloatName("@CameraDevice/BslInputHoldOffTime");

	public static FloatName BslInputFilterTime => new FloatName("@CameraDevice/BslInputFilterTime");

	public static BslImmediateTriggerModeEnum BslImmediateTriggerMode
	{
		get
		{
			if (m_BslImmediateTriggerModeCached == null)
			{
				m_BslImmediateTriggerModeCached = new BslImmediateTriggerModeEnum();
			}
			return m_BslImmediateTriggerModeCached;
		}
	}

	public static FloatName BslImageCompressionRatio => new FloatName("@CameraDevice/BslImageCompressionRatio");

	public static IntegerName BslImageCompressionLastSize => new IntegerName("@CameraDevice/BslImageCompressionLastSize");

	public static FloatName BslImageCompressionLastRatio => new FloatName("@CameraDevice/BslImageCompressionLastRatio");

	public static IntegerName BslHueValue => new IntegerName("@CameraDevice/BslHueValue");

	public static IntegerName BslHueRaw => new IntegerName("@CameraDevice/BslHueRaw");

	public static FloatName BslHue => new FloatName("@CameraDevice/BslHue");

	public static BslExposureTimeModeEnum BslExposureTimeMode
	{
		get
		{
			if (m_BslExposureTimeModeCached == null)
			{
				m_BslExposureTimeModeCached = new BslExposureTimeModeEnum();
			}
			return m_BslExposureTimeModeCached;
		}
	}

	public static FloatName BslExposureStartDelay => new FloatName("@CameraDevice/BslExposureStartDelay");

	public static IntegerName BslErrorReportValue => new IntegerName("@CameraDevice/BslErrorReportValue");

	public static CommandName BslErrorReportNext => new CommandName("@CameraDevice/BslErrorReportNext");

	public static BooleanName BslErrorPresent => new BooleanName("@CameraDevice/BslErrorPresent");

	public static FloatName BslEffectiveExposureTime => new FloatName("@CameraDevice/BslEffectiveExposureTime");

	public static IntegerName BslDeviceLinkCurrentThroughput => new IntegerName("@CameraDevice/BslDeviceLinkCurrentThroughput");

	public static BslDefectPixelCorrectionModeEnum BslDefectPixelCorrectionMode
	{
		get
		{
			if (m_BslDefectPixelCorrectionModeCached == null)
			{
				m_BslDefectPixelCorrectionModeCached = new BslDefectPixelCorrectionModeEnum();
			}
			return m_BslDefectPixelCorrectionModeCached;
		}
	}

	public static IntegerName BslContrastRaw => new IntegerName("@CameraDevice/BslContrastRaw");

	public static BslContrastModeEnum BslContrastMode
	{
		get
		{
			if (m_BslContrastModeCached == null)
			{
				m_BslContrastModeCached = new BslContrastModeEnum();
			}
			return m_BslContrastModeCached;
		}
	}

	public static FloatName BslContrast => new FloatName("@CameraDevice/BslContrast");

	public static BslColorSpaceModeEnum BslColorSpaceMode
	{
		get
		{
			if (m_BslColorSpaceModeCached == null)
			{
				m_BslColorSpaceModeCached = new BslColorSpaceModeEnum();
			}
			return m_BslColorSpaceModeCached;
		}
	}

	public static BslColorSpaceEnum BslColorSpace
	{
		get
		{
			if (m_BslColorSpaceCached == null)
			{
				m_BslColorSpaceCached = new BslColorSpaceEnum();
			}
			return m_BslColorSpaceCached;
		}
	}

	public static BslColorAdjustmentSelectorEnum BslColorAdjustmentSelector
	{
		get
		{
			if (m_BslColorAdjustmentSelectorCached == null)
			{
				m_BslColorAdjustmentSelectorCached = new BslColorAdjustmentSelectorEnum();
			}
			return m_BslColorAdjustmentSelectorCached;
		}
	}

	public static FloatName BslColorAdjustmentSaturation => new FloatName("@CameraDevice/BslColorAdjustmentSaturation");

	public static FloatName BslColorAdjustmentHue => new FloatName("@CameraDevice/BslColorAdjustmentHue");

	public static BooleanName BslColorAdjustmentEnable => new BooleanName("@CameraDevice/BslColorAdjustmentEnable");

	public static IntegerName BslChunkTimestampValue => new IntegerName("@CameraDevice/BslChunkTimestampValue");

	public static BslChunkTimestampSelectorEnum BslChunkTimestampSelector
	{
		get
		{
			if (m_BslChunkTimestampSelectorCached == null)
			{
				m_BslChunkTimestampSelectorCached = new BslChunkTimestampSelectorEnum();
			}
			return m_BslChunkTimestampSelectorCached;
		}
	}

	public static BslChunkAutoBrightnessStatusEnum BslChunkAutoBrightnessStatus
	{
		get
		{
			if (m_BslChunkAutoBrightnessStatusCached == null)
			{
				m_BslChunkAutoBrightnessStatusCached = new BslChunkAutoBrightnessStatusEnum();
			}
			return m_BslChunkAutoBrightnessStatusCached;
		}
	}

	public static CommandName BslCenterY => new CommandName("@CameraDevice/BslCenterY");

	public static CommandName BslCenterX => new CommandName("@CameraDevice/BslCenterX");

	public static IntegerName BslBrightnessRaw => new IntegerName("@CameraDevice/BslBrightnessRaw");

	public static FloatName BslBrightness => new FloatName("@CameraDevice/BslBrightness");

	public static BslBlackLevelCompensationModeEnum BslBlackLevelCompensationMode
	{
		get
		{
			if (m_BslBlackLevelCompensationModeCached == null)
			{
				m_BslBlackLevelCompensationModeCached = new BslBlackLevelCompensationModeEnum();
			}
			return m_BslBlackLevelCompensationModeCached;
		}
	}

	public static BslAcquisitionStopModeEnum BslAcquisitionStopMode
	{
		get
		{
			if (m_BslAcquisitionStopModeCached == null)
			{
				m_BslAcquisitionStopModeCached = new BslAcquisitionStopModeEnum();
			}
			return m_BslAcquisitionStopModeCached;
		}
	}

	public static BslAcquisitionBurstModeEnum BslAcquisitionBurstMode
	{
		get
		{
			if (m_BslAcquisitionBurstModeCached == null)
			{
				m_BslAcquisitionBurstModeCached = new BslAcquisitionBurstModeEnum();
			}
			return m_BslAcquisitionBurstModeCached;
		}
	}

	public static BlackLevelSelectorEnum BlackLevelSelector
	{
		get
		{
			if (m_BlackLevelSelectorCached == null)
			{
				m_BlackLevelSelectorCached = new BlackLevelSelectorEnum();
			}
			return m_BlackLevelSelectorCached;
		}
	}

	public static IntegerName BlackLevelRaw => new IntegerName("@CameraDevice/BlackLevelRaw");

	public static FloatName BlackLevelAbs => new FloatName("@CameraDevice/BlackLevelAbs");

	public static FloatName BlackLevel => new FloatName("@CameraDevice/BlackLevel");

	public static BinningVerticalModeEnum BinningVerticalMode
	{
		get
		{
			if (m_BinningVerticalModeCached == null)
			{
				m_BinningVerticalModeCached = new BinningVerticalModeEnum();
			}
			return m_BinningVerticalModeCached;
		}
	}

	public static IntegerName BinningVertical => new IntegerName("@CameraDevice/BinningVertical");

	public static BinningSelectorEnum BinningSelector
	{
		get
		{
			if (m_BinningSelectorCached == null)
			{
				m_BinningSelectorCached = new BinningSelectorEnum();
			}
			return m_BinningSelectorCached;
		}
	}

	public static BinningModeVerticalEnum BinningModeVertical
	{
		get
		{
			if (m_BinningModeVerticalCached == null)
			{
				m_BinningModeVerticalCached = new BinningModeVerticalEnum();
			}
			return m_BinningModeVerticalCached;
		}
	}

	public static BinningModeHorizontalEnum BinningModeHorizontal
	{
		get
		{
			if (m_BinningModeHorizontalCached == null)
			{
				m_BinningModeHorizontalCached = new BinningModeHorizontalEnum();
			}
			return m_BinningModeHorizontalCached;
		}
	}

	public static BinningHorizontalModeEnum BinningHorizontalMode
	{
		get
		{
			if (m_BinningHorizontalModeCached == null)
			{
				m_BinningHorizontalModeCached = new BinningHorizontalModeEnum();
			}
			return m_BinningHorizontalModeCached;
		}
	}

	public static IntegerName BinningHorizontal => new IntegerName("@CameraDevice/BinningHorizontal");

	public static BandwidthReserveModeEnum BandwidthReserveMode
	{
		get
		{
			if (m_BandwidthReserveModeCached == null)
			{
				m_BandwidthReserveModeCached = new BandwidthReserveModeEnum();
			}
			return m_BandwidthReserveModeCached;
		}
	}

	public static CommandName BalanceWhiteReset => new CommandName("@CameraDevice/BalanceWhiteReset");

	public static BalanceWhiteAutoEnum BalanceWhiteAuto
	{
		get
		{
			if (m_BalanceWhiteAutoCached == null)
			{
				m_BalanceWhiteAutoCached = new BalanceWhiteAutoEnum();
			}
			return m_BalanceWhiteAutoCached;
		}
	}

	public static IntegerName BalanceWhiteAdjustmentDampingRaw => new IntegerName("@CameraDevice/BalanceWhiteAdjustmentDampingRaw");

	public static FloatName BalanceWhiteAdjustmentDampingAbs => new FloatName("@CameraDevice/BalanceWhiteAdjustmentDampingAbs");

	public static BalanceRatioSelectorEnum BalanceRatioSelector
	{
		get
		{
			if (m_BalanceRatioSelectorCached == null)
			{
				m_BalanceRatioSelectorCached = new BalanceRatioSelectorEnum();
			}
			return m_BalanceRatioSelectorCached;
		}
	}

	public static IntegerName BalanceRatioRaw => new IntegerName("@CameraDevice/BalanceRatioRaw");

	public static FloatName BalanceRatioAbs => new FloatName("@CameraDevice/BalanceRatioAbs");

	public static FloatName BalanceRatio => new FloatName("@CameraDevice/BalanceRatio");

	public static BLCSerialTransmitQueueStatusEnum BLCSerialTransmitQueueStatus
	{
		get
		{
			if (m_BLCSerialTransmitQueueStatusCached == null)
			{
				m_BLCSerialTransmitQueueStatusCached = new BLCSerialTransmitQueueStatusEnum();
			}
			return m_BLCSerialTransmitQueueStatusCached;
		}
	}

	public static BLCSerialReceiveQueueStatusEnum BLCSerialReceiveQueueStatus
	{
		get
		{
			if (m_BLCSerialReceiveQueueStatusCached == null)
			{
				m_BLCSerialReceiveQueueStatusCached = new BLCSerialReceiveQueueStatusEnum();
			}
			return m_BLCSerialReceiveQueueStatusCached;
		}
	}

	public static IntegerName BLCSerialPortTransmitValue => new IntegerName("@CameraDevice/BLCSerialPortTransmitValue");

	public static CommandName BLCSerialPortTransmitCmd => new CommandName("@CameraDevice/BLCSerialPortTransmitCmd");

	public static BLCSerialPortStopBitsEnum BLCSerialPortStopBits
	{
		get
		{
			if (m_BLCSerialPortStopBitsCached == null)
			{
				m_BLCSerialPortStopBitsCached = new BLCSerialPortStopBitsEnum();
			}
			return m_BLCSerialPortStopBitsCached;
		}
	}

	public static BLCSerialPortSourceEnum BLCSerialPortSource
	{
		get
		{
			if (m_BLCSerialPortSourceCached == null)
			{
				m_BLCSerialPortSourceCached = new BLCSerialPortSourceEnum();
			}
			return m_BLCSerialPortSourceCached;
		}
	}

	public static IntegerName BLCSerialPortReceiveValue => new IntegerName("@CameraDevice/BLCSerialPortReceiveValue");

	public static CommandName BLCSerialPortReceiveCmd => new CommandName("@CameraDevice/BLCSerialPortReceiveCmd");

	public static BLCSerialPortParityEnum BLCSerialPortParity
	{
		get
		{
			if (m_BLCSerialPortParityCached == null)
			{
				m_BLCSerialPortParityCached = new BLCSerialPortParityEnum();
			}
			return m_BLCSerialPortParityCached;
		}
	}

	public static CommandName BLCSerialPortClearErrors => new CommandName("@CameraDevice/BLCSerialPortClearErrors");

	public static BLCSerialPortBaudRateEnum BLCSerialPortBaudRate
	{
		get
		{
			if (m_BLCSerialPortBaudRateCached == null)
			{
				m_BLCSerialPortBaudRateCached = new BLCSerialPortBaudRateEnum();
			}
			return m_BLCSerialPortBaudRateCached;
		}
	}

	public static BooleanName BLCSerialParityError => new BooleanName("@CameraDevice/BLCSerialParityError");

	public static BooleanName BLCSerialFramingError => new BooleanName("@CameraDevice/BLCSerialFramingError");

	public static IntegerName AutoTonalRangeThresholdDarkRaw => new IntegerName("@CameraDevice/AutoTonalRangeThresholdDarkRaw");

	public static FloatName AutoTonalRangeThresholdDark => new FloatName("@CameraDevice/AutoTonalRangeThresholdDark");

	public static IntegerName AutoTonalRangeThresholdBrightRaw => new IntegerName("@CameraDevice/AutoTonalRangeThresholdBrightRaw");

	public static FloatName AutoTonalRangeThresholdBright => new FloatName("@CameraDevice/AutoTonalRangeThresholdBright");

	public static IntegerName AutoTonalRangeTargetDark => new IntegerName("@CameraDevice/AutoTonalRangeTargetDark");

	public static IntegerName AutoTonalRangeTargetBright => new IntegerName("@CameraDevice/AutoTonalRangeTargetBright");

	public static AutoTonalRangeModeSelectorEnum AutoTonalRangeModeSelector
	{
		get
		{
			if (m_AutoTonalRangeModeSelectorCached == null)
			{
				m_AutoTonalRangeModeSelectorCached = new AutoTonalRangeModeSelectorEnum();
			}
			return m_AutoTonalRangeModeSelectorCached;
		}
	}

	public static AutoTonalRangeAdjustmentSelectorEnum AutoTonalRangeAdjustmentSelector
	{
		get
		{
			if (m_AutoTonalRangeAdjustmentSelectorCached == null)
			{
				m_AutoTonalRangeAdjustmentSelectorCached = new AutoTonalRangeAdjustmentSelectorEnum();
			}
			return m_AutoTonalRangeAdjustmentSelectorCached;
		}
	}

	public static IntegerName AutoTargetValue => new IntegerName("@CameraDevice/AutoTargetValue");

	public static FloatName AutoTargetBrightnessDamping => new FloatName("@CameraDevice/AutoTargetBrightnessDamping");

	public static FloatName AutoTargetBrightness => new FloatName("@CameraDevice/AutoTargetBrightness");

	public static FloatName AutoGainUpperLimit => new FloatName("@CameraDevice/AutoGainUpperLimit");

	public static IntegerName AutoGainRawUpperLimit => new IntegerName("@CameraDevice/AutoGainRawUpperLimit");

	public static IntegerName AutoGainRawLowerLimit => new IntegerName("@CameraDevice/AutoGainRawLowerLimit");

	public static FloatName AutoGainLowerLimit => new FloatName("@CameraDevice/AutoGainLowerLimit");

	public static IntegerName AutoFunctionROIWidth => new IntegerName("@CameraDevice/AutoFunctionROIWidth");

	public static BooleanName AutoFunctionROIUseWhiteBalance => new BooleanName("@CameraDevice/AutoFunctionROIUseWhiteBalance");

	public static BooleanName AutoFunctionROIUseTonalRange => new BooleanName("@CameraDevice/AutoFunctionROIUseTonalRange");

	public static BooleanName AutoFunctionROIUseBrightness => new BooleanName("@CameraDevice/AutoFunctionROIUseBrightness");

	public static AutoFunctionROISelectorEnum AutoFunctionROISelector
	{
		get
		{
			if (m_AutoFunctionROISelectorCached == null)
			{
				m_AutoFunctionROISelectorCached = new AutoFunctionROISelectorEnum();
			}
			return m_AutoFunctionROISelectorCached;
		}
	}

	public static IntegerName AutoFunctionROIOffsetY => new IntegerName("@CameraDevice/AutoFunctionROIOffsetY");

	public static IntegerName AutoFunctionROIOffsetX => new IntegerName("@CameraDevice/AutoFunctionROIOffsetX");

	public static BooleanName AutoFunctionROIHighlight => new BooleanName("@CameraDevice/AutoFunctionROIHighlight");

	public static IntegerName AutoFunctionROIHeight => new IntegerName("@CameraDevice/AutoFunctionROIHeight");

	public static AutoFunctionProfileEnum AutoFunctionProfile
	{
		get
		{
			if (m_AutoFunctionProfileCached == null)
			{
				m_AutoFunctionProfileCached = new AutoFunctionProfileEnum();
			}
			return m_AutoFunctionProfileCached;
		}
	}

	public static IntegerName AutoFunctionAOIWidth => new IntegerName("@CameraDevice/AutoFunctionAOIWidth");

	public static BooleanName AutoFunctionAOIUseWhiteBalance => new BooleanName("@CameraDevice/AutoFunctionAOIUseWhiteBalance");

	public static BooleanName AutoFunctionAOIUseBrightness => new BooleanName("@CameraDevice/AutoFunctionAOIUseBrightness");

	public static BooleanName AutoFunctionAOIUsageWhiteBalance => new BooleanName("@CameraDevice/AutoFunctionAOIUsageWhiteBalance");

	public static BooleanName AutoFunctionAOIUsageTonalRange => new BooleanName("@CameraDevice/AutoFunctionAOIUsageTonalRange");

	public static BooleanName AutoFunctionAOIUsageRedLightCorrection => new BooleanName("@CameraDevice/AutoFunctionAOIUsageRedLightCorrection");

	public static BooleanName AutoFunctionAOIUsageIntensity => new BooleanName("@CameraDevice/AutoFunctionAOIUsageIntensity");

	public static AutoFunctionAOISelectorEnum AutoFunctionAOISelector
	{
		get
		{
			if (m_AutoFunctionAOISelectorCached == null)
			{
				m_AutoFunctionAOISelectorCached = new AutoFunctionAOISelectorEnum();
			}
			return m_AutoFunctionAOISelectorCached;
		}
	}

	public static IntegerName AutoFunctionAOIOffsetY => new IntegerName("@CameraDevice/AutoFunctionAOIOffsetY");

	public static IntegerName AutoFunctionAOIOffsetX => new IntegerName("@CameraDevice/AutoFunctionAOIOffsetX");

	public static IntegerName AutoFunctionAOIHeight => new IntegerName("@CameraDevice/AutoFunctionAOIHeight");

	public static IntegerName AutoExposureTimeUpperLimitRaw => new IntegerName("@CameraDevice/AutoExposureTimeUpperLimitRaw");

	public static FloatName AutoExposureTimeUpperLimit => new FloatName("@CameraDevice/AutoExposureTimeUpperLimit");

	public static IntegerName AutoExposureTimeLowerLimitRaw => new IntegerName("@CameraDevice/AutoExposureTimeLowerLimitRaw");

	public static FloatName AutoExposureTimeLowerLimit => new FloatName("@CameraDevice/AutoExposureTimeLowerLimit");

	public static FloatName AutoExposureTimeAbsUpperLimit => new FloatName("@CameraDevice/AutoExposureTimeAbsUpperLimit");

	public static FloatName AutoExposureTimeAbsLowerLimit => new FloatName("@CameraDevice/AutoExposureTimeAbsLowerLimit");

	public static FloatName AutoBacklightCompensation => new FloatName("@CameraDevice/AutoBacklightCompensation");

	public static IntegerName ActionSelector => new IntegerName("@CameraDevice/ActionSelector");

	public static IntegerName ActionQueueSize => new IntegerName("@CameraDevice/ActionQueueSize");

	public static IntegerName ActionLateEventTimestamp => new IntegerName("@CameraDevice/ActionLateEventTimestamp");

	public static IntegerName ActionLateEventStreamChannelIndex => new IntegerName("@CameraDevice/ActionLateEventStreamChannelIndex");

	public static IntegerName ActionGroupMask => new IntegerName("@CameraDevice/ActionGroupMask");

	public static IntegerName ActionGroupKey => new IntegerName("@CameraDevice/ActionGroupKey");

	public static IntegerName ActionDeviceKey => new IntegerName("@CameraDevice/ActionDeviceKey");

	public static IntegerName ActionCommandCount => new IntegerName("@CameraDevice/ActionCommandCount");

	public static IntegerName AcquisitionWaitEventTimestamp => new IntegerName("@CameraDevice/AcquisitionWaitEventTimestamp");

	public static IntegerName AcquisitionWaitEventStreamChannelIndex => new IntegerName("@CameraDevice/AcquisitionWaitEventStreamChannelIndex");

	public static CommandName AcquisitionStop => new CommandName("@CameraDevice/AcquisitionStop");

	public static AcquisitionStatusSelectorEnum AcquisitionStatusSelector
	{
		get
		{
			if (m_AcquisitionStatusSelectorCached == null)
			{
				m_AcquisitionStatusSelectorCached = new AcquisitionStatusSelectorEnum();
			}
			return m_AcquisitionStatusSelectorCached;
		}
	}

	public static BooleanName AcquisitionStatus => new BooleanName("@CameraDevice/AcquisitionStatus");

	public static IntegerName AcquisitionStartWaitEventTimestamp => new IntegerName("@CameraDevice/AcquisitionStartWaitEventTimestamp");

	public static IntegerName AcquisitionStartWaitEventStreamChannelIndex => new IntegerName("@CameraDevice/AcquisitionStartWaitEventStreamChannelIndex");

	public static IntegerName AcquisitionStartOvertriggerEventTimestamp => new IntegerName("@CameraDevice/AcquisitionStartOvertriggerEventTimestamp");

	public static IntegerName AcquisitionStartOvertriggerEventStreamChannelIndex => new IntegerName("@CameraDevice/AcquisitionStartOvertriggerEventStreamChannelIndex");

	public static IntegerName AcquisitionStartEventTimestamp => new IntegerName("@CameraDevice/AcquisitionStartEventTimestamp");

	public static IntegerName AcquisitionStartEventStreamChannelIndex => new IntegerName("@CameraDevice/AcquisitionStartEventStreamChannelIndex");

	public static CommandName AcquisitionStart => new CommandName("@CameraDevice/AcquisitionStart");

	public static AcquisitionModeEnum AcquisitionMode
	{
		get
		{
			if (m_AcquisitionModeCached == null)
			{
				m_AcquisitionModeCached = new AcquisitionModeEnum();
			}
			return m_AcquisitionModeCached;
		}
	}

	public static FloatName AcquisitionLineRateAbs => new FloatName("@CameraDevice/AcquisitionLineRateAbs");

	public static BooleanName AcquisitionIdle => new BooleanName("@CameraDevice/AcquisitionIdle");

	public static AcquisitionFrameRateEnumEnum AcquisitionFrameRateEnum
	{
		get
		{
			if (m_AcquisitionFrameRateEnumCached == null)
			{
				m_AcquisitionFrameRateEnumCached = new AcquisitionFrameRateEnumEnum();
			}
			return m_AcquisitionFrameRateEnumCached;
		}
	}

	public static BooleanName AcquisitionFrameRateEnable => new BooleanName("@CameraDevice/AcquisitionFrameRateEnable");

	public static FloatName AcquisitionFrameRateAbs => new FloatName("@CameraDevice/AcquisitionFrameRateAbs");

	public static FloatName AcquisitionFrameRate => new FloatName("@CameraDevice/AcquisitionFrameRate");

	public static IntegerName AcquisitionFrameCount => new IntegerName("@CameraDevice/AcquisitionFrameCount");

	public static IntegerName AcquisitionBurstFrameCount => new IntegerName("@CameraDevice/AcquisitionBurstFrameCount");

	public static CommandName AcquisitionAbort => new CommandName("@CameraDevice/AcquisitionAbort");
}
