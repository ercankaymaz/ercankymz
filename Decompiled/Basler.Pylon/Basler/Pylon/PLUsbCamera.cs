using System.ComponentModel;

namespace Basler.Pylon;

public static class PLUsbCamera
{
	[EditorBrowsable(EditorBrowsableState.Never)]
	public class CameraOperationModeEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/CameraOperationMode";

		public string LongExposure => "LongExposure";

		public string Standard => "Standard";

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
	public class SequencerTriggerSourceEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/SequencerTriggerSource";

		public string FrameEnd => "FrameEnd";

		public string FrameStart => "FrameStart";

		public string Counter3End => "Counter3End";

		public string Counter2End => "Counter2End";

		public string Counter1End => "Counter1End";

		public string SoftwareSignal3 => "SoftwareSignal3";

		public string SoftwareSignal2 => "SoftwareSignal2";

		public string SoftwareSignal1 => "SoftwareSignal1";

		public string Line4 => "Line4";

		public string Line3 => "Line3";

		public string Line2 => "Line2";

		public string Line1 => "Line1";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class SequencerTriggerActivationEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/SequencerTriggerActivation";

		public string LevelLow => "LevelLow";

		public string LevelHigh => "LevelHigh";

		public string AnyEdge => "AnyEdge";

		public string FallingEdge => "FallingEdge";

		public string RisingEdge => "RisingEdge";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class BinningHorizontalModeEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/BinningHorizontalMode";

		public string Average => "Average";

		public string Sum => "Sum";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class BinningVerticalModeEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/BinningVerticalMode";

		public string Average => "Average";

		public string Sum => "Sum";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class PixelFormatEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/PixelFormat";

		public string YCbCr422_8 => "YCbCr422_8";

		public string BGR8 => "BGR8";

		public string RGB8 => "RGB8";

		public string BayerBG12p => "BayerBG12p";

		public string BayerBG12 => "BayerBG12";

		public string BayerGB12p => "BayerGB12p";

		public string BayerGB12 => "BayerGB12";

		public string BayerRG12p => "BayerRG12p";

		public string BayerRG12 => "BayerRG12";

		public string BayerGR12p => "BayerGR12p";

		public string BayerGR12 => "BayerGR12";

		public string BayerBG10p => "BayerBG10p";

		public string BayerBG10 => "BayerBG10";

		public string BayerGB10p => "BayerGB10p";

		public string BayerGB10 => "BayerGB10";

		public string BayerRG10p => "BayerRG10p";

		public string BayerRG10 => "BayerRG10";

		public string BayerGR10p => "BayerGR10p";

		public string BayerGR10 => "BayerGR10";

		public string BayerBG8 => "BayerBG8";

		public string BayerGB8 => "BayerGB8";

		public string BayerRG8 => "BayerRG8";

		public string BayerGR8 => "BayerGR8";

		public string Mono12p => "Mono12p";

		public string Mono12 => "Mono12";

		public string Mono10p => "Mono10p";

		public string Mono10 => "Mono10";

		public string Mono8 => "Mono8";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class PixelSizeEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/PixelSize";

		public string Bpp24 => "Bpp24";

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

		public string BayerBG => "BayerBG";

		public string BayerGR => "BayerGR";

		public string BayerGB => "BayerGB";

		public string BayerRG => "BayerRG";

		public string None => "None";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class TestImageSelectorEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/TestImageSelector";

		public string Testimage6 => "Testimage6";

		public string Testimage5 => "Testimage5";

		public string Testimage4 => "Testimage4";

		public string Testimage3 => "Testimage3";

		public string Testimage2 => "Testimage2";

		public string Testimage1 => "Testimage1";

		public string Off => "Off";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class TestPatternEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/TestPattern";

		public string ColorDiagonalSawtooth8 => "ColorDiagonalSawtooth8";

		public string GreyDiagonalSawtooth8 => "GreyDiagonalSawtooth8";

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
	public class GainAutoEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/GainAuto";

		public string Continuous => "Continuous";

		public string Once => "Once";

		public string Off => "Off";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class GainSelectorEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/GainSelector";

		public string AnalogAll => "AnalogAll";

		public string DigitalAll => "DigitalAll";

		public string All => "All";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class BlackLevelSelectorEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/BlackLevelSelector";

		public string All => "All";

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
	public class LightSourcePresetEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/LightSourcePreset";

		public string MicroscopeLED6000K => "MicroscopeLED6000K";

		public string MicroscopeLED5500K => "MicroscopeLED5500K";

		public string MicroscopeLED4500K => "MicroscopeLED4500K";

		public string Tungsten2800K => "Tungsten2800K";

		public string Daylight6500K => "Daylight6500K";

		public string Daylight5000K => "Daylight5000K";

		public string Off => "Off";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class BalanceWhiteAutoEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/BalanceWhiteAuto";

		public string Continuous => "Continuous";

		public string Once => "Once";

		public string Off => "Off";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class BalanceRatioSelectorEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/BalanceRatioSelector";

		public string Blue => "Blue";

		public string Green => "Green";

		public string Red => "Red";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class ColorAdjustmentSelectorEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/ColorAdjustmentSelector";

		public string Magenta => "Magenta";

		public string Blue => "Blue";

		public string Cyan => "Cyan";

		public string Green => "Green";

		public string Yellow => "Yellow";

		public string Red => "Red";

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

		public string BaslerPGI => "BaslerPGI";

		public string Simple => "Simple";

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
	public class AcquisitionModeEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/AcquisitionMode";

		public string Continuous => "Continuous";

		public string SingleFrame => "SingleFrame";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class ShutterModeEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/ShutterMode";

		public string GlobalResetRelease => "GlobalResetRelease";

		public string Rolling => "Rolling";

		public string Global => "Global";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class ExposureAutoEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/ExposureAuto";

		public string Continuous => "Continuous";

		public string Once => "Once";

		public string Off => "Off";

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
	public class ExposureModeEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/ExposureMode";

		public string TriggerWidth => "TriggerWidth";

		public string Timed => "Timed";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class ExposureOverlapTimeModeEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/ExposureOverlapTimeMode";

		public string Automatic => "Automatic";

		public string Manual => "Manual";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class SensorReadoutModeEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/SensorReadoutMode";

		public string Fast => "Fast";

		public string Normal => "Normal";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class TriggerSelectorEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/TriggerSelector";

		public string FrameStart => "FrameStart";

		public string FrameBurstStart => "FrameBurstStart";

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

		public string SoftwareSignal3 => "SoftwareSignal3";

		public string SoftwareSignal2 => "SoftwareSignal2";

		public string SoftwareSignal1 => "SoftwareSignal1";

		public string Line4 => "Line4";

		public string Line3 => "Line3";

		public string Line2 => "Line2";

		public string Line1 => "Line1";

		public string Software => "Software";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class TriggerActivationEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/TriggerActivation";

		public string LevelLow => "LevelLow";

		public string LevelHigh => "LevelHigh";

		public string AnyEdge => "AnyEdge";

		public string FallingEdge => "FallingEdge";

		public string RisingEdge => "RisingEdge";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class AcquisitionStatusSelectorEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/AcquisitionStatusSelector";

		public string AcquisitionIdle => "AcquisitionIdle";

		public string ExposureActive => "ExposureActive";

		public string FrameTransfer => "FrameTransfer";

		public string FrameActive => "FrameActive";

		public string FrameTriggerWait => "FrameTriggerWait";

		public string FrameBurstTriggerTransfer => "FrameBurstTriggerTransfer";

		public string FrameBurstTriggerActive => "FrameBurstTriggerActive";

		public string FrameBurstTriggerWait => "FrameBurstTriggerWait";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class SensorShutterModeEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/SensorShutterMode";

		public string GlobalReset => "GlobalReset";

		public string Rolling => "Rolling";

		public string Global => "Global";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class OverlapModeEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/OverlapMode";

		public string Off => "Off";

		public string On => "On";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class BslImmediateTriggerModeEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/BslImmediateTriggerMode";

		public string Off => "Off";

		public string On => "On";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class AutoFunctionProfileEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/AutoFunctionProfile";

		public string MinimizeExposureTimeQuick => "MinimizeExposureTimeQuick";

		public string MinimizeGainQuick => "MinimizeGainQuick";

		public string AntiFlicker60Hz => "AntiFlicker60Hz";

		public string AntiFlicker50Hz => "AntiFlicker50Hz";

		public string Smart => "Smart";

		public string MinimizeExposureTime => "MinimizeExposureTime";

		public string MinimizeGain => "MinimizeGain";

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
	public class AutoFunctionAOISelectorEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/AutoFunctionAOISelector";

		public string AOI2 => "AOI2";

		public string AOI1 => "AOI1";

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

		public string Color => "Color";

		public string ColorAndContrast => "ColorAndContrast";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class AutoTonalRangeAdjustmentSelectorEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/AutoTonalRangeAdjustmentSelector";

		public string Dark => "Dark";

		public string Bright => "Bright";

		public string DarkAndBright => "DarkAndBright";

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
	public class LineSelectorEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/LineSelector";

		public string Line4 => "Line4";

		public string Line3 => "Line3";

		public string Line2 => "Line2";

		public string Line1 => "Line1";

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

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class LineFormatEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/LineFormat";

		public string LVTTL => "LVTTL";

		public string OptoCoupled => "OptoCoupled";

		public string RS422 => "RS422";

		public string LVDS => "LVDS";

		public string TTL => "TTL";

		public string TriState => "TriState";

		public string NoConnect => "NoConnect";

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
	public class LineSourceEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/LineSource";

		public string UserOutput4 => "UserOutput4";

		public string FlashWindow => "FlashWindow";

		public string UserOutput3 => "UserOutput3";

		public string UserOutput2 => "UserOutput2";

		public string UserOutput1 => "UserOutput1";

		public string UserOutput0 => "UserOutput0";

		public string Timer1Active => "Timer1Active";

		public string FrameBurstTriggerWait => "FrameBurstTriggerWait";

		public string FrameTriggerWait => "FrameTriggerWait";

		public string ExposureActive => "ExposureActive";

		public string Off => "Off";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class UserOutputSelectorEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/UserOutputSelector";

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
	public class TimerSelectorEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/TimerSelector";

		public string Timer1 => "Timer1";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class TimerTriggerSourceEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/TimerTriggerSource";

		public string FlashWindowStart => "FlashWindowStart";

		public string ExposureStart => "ExposureStart";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class CounterSelectorEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/CounterSelector";

		public string Counter2 => "Counter2";

		public string Counter1 => "Counter1";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class CounterEventSourceEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/CounterEventSource";

		public string Counter3End => "Counter3End";

		public string Counter2End => "Counter2End";

		public string Counter1End => "Counter1End";

		public string FrameStart => "FrameStart";

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

		public string Counter4End => "Counter4End";

		public string Counter3End => "Counter3End";

		public string Counter2End => "Counter2End";

		public string Counter1End => "Counter1End";

		public string Line4 => "Line4";

		public string Line3 => "Line3";

		public string Line2 => "Line2";

		public string Line1 => "Line1";

		public string Software => "Software";

		public string Off => "Off";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class CounterResetActivationEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/CounterResetActivation";

		public string LevelLow => "LevelLow";

		public string LevelHigh => "LevelHigh";

		public string AnyEdge => "AnyEdge";

		public string FallingEdge => "FallingEdge";

		public string RisingEdge => "RisingEdge";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class UserSetSelectorEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/UserSetSelector";

		public string LightMicroscopy => "LightMicroscopy";

		public string UserSet3 => "UserSet3";

		public string UserSet2 => "UserSet2";

		public string UserSet1 => "UserSet1";

		public string ColorRaw => "ColorRaw";

		public string Color => "Color";

		public string AutoFunctions => "AutoFunctions";

		public string HighGain => "HighGain";

		public string Default => "Default";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class UserSetDefaultEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/UserSetDefault";

		public string LightMicroscopy => "LightMicroscopy";

		public string UserSet3 => "UserSet3";

		public string UserSet2 => "UserSet2";

		public string UserSet1 => "UserSet1";

		public string ColorRaw => "ColorRaw";

		public string Color => "Color";

		public string AutoFunctions => "AutoFunctions";

		public string HighGain => "HighGain";

		public string Default => "Default";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class ChunkSelectorEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/ChunkSelector";

		public string PayloadCRC16 => "PayloadCRC16";

		public string SequencerSetActive => "SequencerSetActive";

		public string CounterValue => "CounterValue";

		public string LineStatusAll => "LineStatusAll";

		public string Timestamp => "Timestamp";

		public string ExposureTime => "ExposureTime";

		public string Gain => "Gain";

		public string Image => "Image";

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
	public class EventSelectorEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/EventSelector";

		public string FrameBurstStartWait => "FrameBurstStartWait";

		public string FrameStartWait => "FrameStartWait";

		public string OverTemperature => "OverTemperature";

		public string CriticalTemperature => "CriticalTemperature";

		public string FrameBurstStartOvertrigger => "FrameBurstStartOvertrigger";

		public string FrameStartOvertrigger => "FrameStartOvertrigger";

		public string FrameBurstStart => "FrameBurstStart";

		public string FrameStart => "FrameStart";

		public string ExposureEnd => "ExposureEnd";

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

		public string Off => "Off";

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

		public string HighSpeed => "HighSpeed";

		public string FullSpeed => "FullSpeed";

		public string LowSpeed => "LowSpeed";

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
	public class DeviceTemperatureSelectorEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/DeviceTemperatureSelector";

		public string Framegrabberboard => "Framegrabberboard";

		public string Sensorboard => "Sensorboard";

		public string Coreboard => "Coreboard";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class TemperatureStateEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/TemperatureState";

		public string Error => "Error";

		public string Critical => "Critical";

		public string Ok => "Ok";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class DeviceIndicatorModeEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/DeviceIndicatorMode";

		public string Active => "Active";

		public string Inactive => "Inactive";

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
	public class RemoveParameterLimitSelectorEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/RemoveParameterLimitSelector";

		public string ExposureOverhead => "ExposureOverhead";

		public string AutoTargetValue => "AutoTargetValue";

		public string ExposureTime => "ExposureTime";

		public string BlackLevel => "BlackLevel";

		public string Gain => "Gain";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class ExpertFeatureAccessSelectorEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/ExpertFeatureAccessSelector";

		public string ExpertFeature10 => "ExpertFeature10";

		public string ExpertFeature9 => "ExpertFeature9";

		public string ExpertFeature8 => "ExpertFeature8";

		public string ExpertFeature7 => "ExpertFeature7";

		public string ExpertFeature6 => "ExpertFeature6";

		public string ExpertFeature5 => "ExpertFeature5";

		public string ExpertFeature4 => "ExpertFeature4";

		public string ExpertFeature3 => "ExpertFeature3";

		public string ExpertFeature2 => "ExpertFeature2";

		public string ExpertFeature1 => "ExpertFeature1";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class FileSelectorEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/FileSelector";

		public string ExpertFeature7File => "ExpertFeature7File";

		public string UserOffsetShading2 => "UserOffsetShading2";

		public string UserOffsetShading1 => "UserOffsetShading1";

		public string UserGainShading2 => "UserGainShading2";

		public string UserGainShading1 => "UserGainShading1";

		public string UserSet3 => "UserSet3";

		public string UserSet2 => "UserSet2";

		public string UserSet1 => "UserSet1";

		public string UserData => "UserData";

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

		public string Close => "Close";

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

		public string Write => "Write";

		public string Read => "Read";

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
	public class TonalRangeSelectorEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/TonalRangeSelector";

		public string Blue => "Blue";

		public string Green => "Green";

		public string Red => "Red";

		public string Sum => "Sum";

		public override string ToString()
		{
			return Name;
		}
	}

	public static IntegerName TonalRangeTargetDark => (IntegerName)"@CameraDevice/TonalRangeTargetDark";

	public static IntegerName TonalRangeTargetBright => (IntegerName)"@CameraDevice/TonalRangeTargetBright";

	public static IntegerName TonalRangeSourceDark => (IntegerName)"@CameraDevice/TonalRangeSourceDark";

	public static IntegerName TonalRangeSourceBright => (IntegerName)"@CameraDevice/TonalRangeSourceBright";

	public static TonalRangeSelectorEnum TonalRangeSelector => new TonalRangeSelectorEnum();

	public static TonalRangeAutoEnum TonalRangeAuto => new TonalRangeAutoEnum();

	public static TonalRangeEnableEnum TonalRangeEnable => new TonalRangeEnableEnum();

	public static CommandName FileOperationExecute => (CommandName)"@CameraDevice/FileOperationExecute";

	public static IntegerName FileSize => (IntegerName)"@CameraDevice/FileSize";

	public static IntegerName FileOperationResult => (IntegerName)"@CameraDevice/FileOperationResult";

	public static FileOperationStatusEnum FileOperationStatus => new FileOperationStatusEnum();

	public static IntegerName FileAccessLength => (IntegerName)"@CameraDevice/FileAccessLength";

	public static IntegerName FileAccessOffset => (IntegerName)"@CameraDevice/FileAccessOffset";

	public static FileOpenModeEnum FileOpenMode => new FileOpenModeEnum();

	public static FileOperationSelectorEnum FileOperationSelector => new FileOperationSelectorEnum();

	public static FileSelectorEnum FileSelector => new FileSelectorEnum();

	public static BooleanName ExpertFeatureEnable => (BooleanName)"@CameraDevice/ExpertFeatureEnable";

	public static IntegerName ExpertFeatureAccessKey => (IntegerName)"@CameraDevice/ExpertFeatureAccessKey";

	public static ExpertFeatureAccessSelectorEnum ExpertFeatureAccessSelector => new ExpertFeatureAccessSelectorEnum();

	public static BooleanName RemoveParameterLimit => (BooleanName)"@CameraDevice/RemoveParameterLimit";

	public static RemoveParameterLimitSelectorEnum RemoveParameterLimitSelector => new RemoveParameterLimitSelectorEnum();

	public static IntegerName UserDefinedValue => (IntegerName)"@CameraDevice/UserDefinedValue";

	public static UserDefinedValueSelectorEnum UserDefinedValueSelector => new UserDefinedValueSelectorEnum();

	public static IntegerName DeviceColorPipelineVersion => (IntegerName)"@CameraDevice/DeviceColorPipelineVersion";

	public static CommandName DeviceRegistersStreamingEnd => (CommandName)"@CameraDevice/DeviceRegistersStreamingEnd";

	public static CommandName DeviceRegistersStreamingStart => (CommandName)"@CameraDevice/DeviceRegistersStreamingStart";

	public static DeviceIndicatorModeEnum DeviceIndicatorMode => new DeviceIndicatorModeEnum();

	public static IntegerName DeviceSFNCVersionSubMinor => (IntegerName)"@CameraDevice/DeviceSFNCVersionSubMinor";

	public static IntegerName DeviceSFNCVersionMinor => (IntegerName)"@CameraDevice/DeviceSFNCVersionMinor";

	public static IntegerName DeviceSFNCVersionMajor => (IntegerName)"@CameraDevice/DeviceSFNCVersionMajor";

	public static CommandName DeviceReset => (CommandName)"@CameraDevice/DeviceReset";

	public static TemperatureStateEnum TemperatureState => new TemperatureStateEnum();

	public static FloatName DeviceTemperature => (FloatName)"@CameraDevice/DeviceTemperature";

	public static DeviceTemperatureSelectorEnum DeviceTemperatureSelector => new DeviceTemperatureSelectorEnum();

	public static IntegerName DeviceLinkCurrentThroughput => (IntegerName)"@CameraDevice/DeviceLinkCurrentThroughput";

	public static IntegerName DeviceLinkThroughputLimit => (IntegerName)"@CameraDevice/DeviceLinkThroughputLimit";

	public static DeviceLinkThroughputLimitModeEnum DeviceLinkThroughputLimitMode => new DeviceLinkThroughputLimitModeEnum();

	public static IntegerName DeviceLinkSpeed => (IntegerName)"@CameraDevice/DeviceLinkSpeed";

	public static IntegerName DeviceLinkSelector => (IntegerName)"@CameraDevice/DeviceLinkSelector";

	public static IntegerName TimestampLatchValue => (IntegerName)"@CameraDevice/TimestampLatchValue";

	public static CommandName TimestampLatch => (CommandName)"@CameraDevice/TimestampLatch";

	public static DeviceScanTypeEnum DeviceScanType => new DeviceScanTypeEnum();

	public static StringName DeviceUserID => (StringName)"@CameraDevice/DeviceUserID";

	public static StringName DeviceSerialNumber => (StringName)"@CameraDevice/DeviceSerialNumber";

	public static StringName DeviceFirmwareVersion => (StringName)"@CameraDevice/DeviceFirmwareVersion";

	public static StringName DeviceVersion => (StringName)"@CameraDevice/DeviceVersion";

	public static StringName DeviceManufacturerInfo => (StringName)"@CameraDevice/DeviceManufacturerInfo";

	public static StringName DeviceModelName => (StringName)"@CameraDevice/DeviceModelName";

	public static StringName DeviceVendorName => (StringName)"@CameraDevice/DeviceVendorName";

	public static IntegerName PayloadFinalTransfer2Size => (IntegerName)"@CameraDevice/PayloadFinalTransfer2Size";

	public static IntegerName PayloadFinalTransfer1Size => (IntegerName)"@CameraDevice/PayloadFinalTransfer1Size";

	public static IntegerName PayloadTransferCount => (IntegerName)"@CameraDevice/PayloadTransferCount";

	public static IntegerName PayloadTransferSize => (IntegerName)"@CameraDevice/PayloadTransferSize";

	public static IntegerName PayloadTransferBlockDelay => (IntegerName)"@CameraDevice/PayloadTransferBlockDelay";

	public static IntegerName TestPendingAck => (IntegerName)"@CameraDevice/TestPendingAck";

	public static IntegerName SIPayloadFinalTransfer2Size => (IntegerName)"@CameraDevice/SIPayloadFinalTransfer2Size";

	public static IntegerName SIPayloadFinalTransfer1Size => (IntegerName)"@CameraDevice/SIPayloadFinalTransfer1Size";

	public static IntegerName SIPayloadTransferCount => (IntegerName)"@CameraDevice/SIPayloadTransferCount";

	public static IntegerName SIPayloadTransferSize => (IntegerName)"@CameraDevice/SIPayloadTransferSize";

	public static BslUSBSpeedModeEnum BslUSBSpeedMode => new BslUSBSpeedModeEnum();

	public static IntegerName PayloadSize => (IntegerName)"@CameraDevice/PayloadSize";

	public static IntegerName EventFrameBurstStartWaitTimestamp => (IntegerName)"@CameraDevice/EventFrameBurstStartWaitTimestamp";

	public static IntegerName EventFrameBurstStartWait => (IntegerName)"@CameraDevice/EventFrameBurstStartWait";

	public static IntegerName EventFrameStartWaitTimestamp => (IntegerName)"@CameraDevice/EventFrameStartWaitTimestamp";

	public static IntegerName EventFrameStartWait => (IntegerName)"@CameraDevice/EventFrameStartWait";

	public static IntegerName EventOverTemperatureTimestamp => (IntegerName)"@CameraDevice/EventOverTemperatureTimestamp";

	public static IntegerName EventOverTemperature => (IntegerName)"@CameraDevice/EventOverTemperature";

	public static IntegerName EventCriticalTemperatureTimestamp => (IntegerName)"@CameraDevice/EventCriticalTemperatureTimestamp";

	public static IntegerName EventCriticalTemperature => (IntegerName)"@CameraDevice/EventCriticalTemperature";

	public static IntegerName EventTestTimestamp => (IntegerName)"@CameraDevice/EventTestTimestamp";

	public static IntegerName EventTest => (IntegerName)"@CameraDevice/EventTest";

	public static IntegerName EventFrameBurstStartOvertriggerFrameID => (IntegerName)"@CameraDevice/EventFrameBurstStartOvertriggerFrameID";

	public static IntegerName EventFrameBurstStartOvertriggerTimestamp => (IntegerName)"@CameraDevice/EventFrameBurstStartOvertriggerTimestamp";

	public static IntegerName EventFrameBurstStartOvertrigger => (IntegerName)"@CameraDevice/EventFrameBurstStartOvertrigger";

	public static IntegerName EventFrameStartOvertriggerFrameID => (IntegerName)"@CameraDevice/EventFrameStartOvertriggerFrameID";

	public static IntegerName EventFrameStartOvertriggerTimestamp => (IntegerName)"@CameraDevice/EventFrameStartOvertriggerTimestamp";

	public static IntegerName EventFrameStartOvertrigger => (IntegerName)"@CameraDevice/EventFrameStartOvertrigger";

	public static IntegerName EventFrameBurstStartFrameID => (IntegerName)"@CameraDevice/EventFrameBurstStartFrameID";

	public static IntegerName EventFrameBurstStartTimestamp => (IntegerName)"@CameraDevice/EventFrameBurstStartTimestamp";

	public static IntegerName EventFrameBurstStart => (IntegerName)"@CameraDevice/EventFrameBurstStart";

	public static IntegerName EventFrameStartFrameID => (IntegerName)"@CameraDevice/EventFrameStartFrameID";

	public static IntegerName EventFrameStartTimestamp => (IntegerName)"@CameraDevice/EventFrameStartTimestamp";

	public static IntegerName EventFrameStart => (IntegerName)"@CameraDevice/EventFrameStart";

	public static IntegerName EventExposureEndFrameID => (IntegerName)"@CameraDevice/EventExposureEndFrameID";

	public static IntegerName EventExposureEndTimestamp => (IntegerName)"@CameraDevice/EventExposureEndTimestamp";

	public static IntegerName EventExposureEnd => (IntegerName)"@CameraDevice/EventExposureEnd";

	public static CommandName TriggerEventTest => (CommandName)"@CameraDevice/TriggerEventTest";

	public static EventNotificationEnum EventNotification => new EventNotificationEnum();

	public static EventSelectorEnum EventSelector => new EventSelectorEnum();

	public static IntegerName ChunkPayloadCRC16 => (IntegerName)"@CameraDevice/ChunkPayloadCRC16";

	public static IntegerName ChunkSequencerSetActive => (IntegerName)"@CameraDevice/ChunkSequencerSetActive";

	public static IntegerName ChunkCounterValue => (IntegerName)"@CameraDevice/ChunkCounterValue";

	public static ChunkCounterSelectorEnum ChunkCounterSelector => new ChunkCounterSelectorEnum();

	public static IntegerName ChunkLineStatusAll => (IntegerName)"@CameraDevice/ChunkLineStatusAll";

	public static IntegerName ChunkTimestamp => (IntegerName)"@CameraDevice/ChunkTimestamp";

	public static FloatName ChunkExposureTime => (FloatName)"@CameraDevice/ChunkExposureTime";

	public static FloatName ChunkGain => (FloatName)"@CameraDevice/ChunkGain";

	public static ChunkGainSelectorEnum ChunkGainSelector => new ChunkGainSelectorEnum();

	public static BooleanName ChunkEnable => (BooleanName)"@CameraDevice/ChunkEnable";

	public static ChunkSelectorEnum ChunkSelector => new ChunkSelectorEnum();

	public static BooleanName ChunkModeActive => (BooleanName)"@CameraDevice/ChunkModeActive";

	public static UserSetDefaultEnum UserSetDefault => new UserSetDefaultEnum();

	public static CommandName UserSetSave => (CommandName)"@CameraDevice/UserSetSave";

	public static CommandName UserSetLoad => (CommandName)"@CameraDevice/UserSetLoad";

	public static UserSetSelectorEnum UserSetSelector => new UserSetSelectorEnum();

	public static IntegerName CounterDuration => (IntegerName)"@CameraDevice/CounterDuration";

	public static CommandName CounterReset => (CommandName)"@CameraDevice/CounterReset";

	public static CounterResetActivationEnum CounterResetActivation => new CounterResetActivationEnum();

	public static CounterResetSourceEnum CounterResetSource => new CounterResetSourceEnum();

	public static CounterEventSourceEnum CounterEventSource => new CounterEventSourceEnum();

	public static CounterSelectorEnum CounterSelector => new CounterSelectorEnum();

	public static TimerTriggerSourceEnum TimerTriggerSource => new TimerTriggerSourceEnum();

	public static FloatName TimerDelay => (FloatName)"@CameraDevice/TimerDelay";

	public static FloatName TimerDuration => (FloatName)"@CameraDevice/TimerDuration";

	public static TimerSelectorEnum TimerSelector => new TimerSelectorEnum();

	public static CommandName SoftwareSignalPulse => (CommandName)"@CameraDevice/SoftwareSignalPulse";

	public static SoftwareSignalSelectorEnum SoftwareSignalSelector => new SoftwareSignalSelectorEnum();

	public static IntegerName UserOutputValueAll => (IntegerName)"@CameraDevice/UserOutputValueAll";

	public static BooleanName UserOutputValue => (BooleanName)"@CameraDevice/UserOutputValue";

	public static UserOutputSelectorEnum UserOutputSelector => new UserOutputSelectorEnum();

	public static IntegerName LineStatusAll => (IntegerName)"@CameraDevice/LineStatusAll";

	public static BooleanName LineStatus => (BooleanName)"@CameraDevice/LineStatus";

	public static CommandName LineOverloadReset => (CommandName)"@CameraDevice/LineOverloadReset";

	public static BooleanName LineOverloadStatus => (BooleanName)"@CameraDevice/LineOverloadStatus";

	public static FloatName LineMinimumOutputPulseWidth => (FloatName)"@CameraDevice/LineMinimumOutputPulseWidth";

	public static FloatName LineDebouncerTime => (FloatName)"@CameraDevice/LineDebouncerTime";

	public static BooleanName LineInverter => (BooleanName)"@CameraDevice/LineInverter";

	public static LineSourceEnum LineSource => new LineSourceEnum();

	public static LineLogicEnum LineLogic => new LineLogicEnum();

	public static LineFormatEnum LineFormat => new LineFormatEnum();

	public static LineModeEnum LineMode => new LineModeEnum();

	public static LineSelectorEnum LineSelector => new LineSelectorEnum();

	public static IntegerName LUTValue => (IntegerName)"@CameraDevice/LUTValue";

	public static IntegerName LUTIndex => (IntegerName)"@CameraDevice/LUTIndex";

	public static BooleanName LUTEnable => (BooleanName)"@CameraDevice/LUTEnable";

	public static LUTSelectorEnum LUTSelector => new LUTSelectorEnum();

	public static IntegerName AutoTonalRangeTargetDark => (IntegerName)"@CameraDevice/AutoTonalRangeTargetDark";

	public static IntegerName AutoTonalRangeTargetBright => (IntegerName)"@CameraDevice/AutoTonalRangeTargetBright";

	public static FloatName AutoTonalRangeThresholdDark => (FloatName)"@CameraDevice/AutoTonalRangeThresholdDark";

	public static FloatName AutoTonalRangeThresholdBright => (FloatName)"@CameraDevice/AutoTonalRangeThresholdBright";

	public static AutoTonalRangeAdjustmentSelectorEnum AutoTonalRangeAdjustmentSelector => new AutoTonalRangeAdjustmentSelectorEnum();

	public static AutoTonalRangeModeSelectorEnum AutoTonalRangeModeSelector => new AutoTonalRangeModeSelectorEnum();

	public static BooleanName AutoFunctionAOIUseWhiteBalance => (BooleanName)"@CameraDevice/AutoFunctionAOIUseWhiteBalance";

	public static BooleanName AutoFunctionAOIUseBrightness => (BooleanName)"@CameraDevice/AutoFunctionAOIUseBrightness";

	public static IntegerName AutoFunctionAOIOffsetY => (IntegerName)"@CameraDevice/AutoFunctionAOIOffsetY";

	public static IntegerName AutoFunctionAOIOffsetX => (IntegerName)"@CameraDevice/AutoFunctionAOIOffsetX";

	public static IntegerName AutoFunctionAOIHeight => (IntegerName)"@CameraDevice/AutoFunctionAOIHeight";

	public static IntegerName AutoFunctionAOIWidth => (IntegerName)"@CameraDevice/AutoFunctionAOIWidth";

	public static AutoFunctionAOISelectorEnum AutoFunctionAOISelector => new AutoFunctionAOISelectorEnum();

	public static BooleanName AutoFunctionROIUseTonalRange => (BooleanName)"@CameraDevice/AutoFunctionROIUseTonalRange";

	public static BooleanName AutoFunctionROIUseWhiteBalance => (BooleanName)"@CameraDevice/AutoFunctionROIUseWhiteBalance";

	public static BooleanName AutoFunctionROIUseBrightness => (BooleanName)"@CameraDevice/AutoFunctionROIUseBrightness";

	public static IntegerName AutoFunctionROIOffsetY => (IntegerName)"@CameraDevice/AutoFunctionROIOffsetY";

	public static IntegerName AutoFunctionROIOffsetX => (IntegerName)"@CameraDevice/AutoFunctionROIOffsetX";

	public static IntegerName AutoFunctionROIHeight => (IntegerName)"@CameraDevice/AutoFunctionROIHeight";

	public static IntegerName AutoFunctionROIWidth => (IntegerName)"@CameraDevice/AutoFunctionROIWidth";

	public static AutoFunctionROISelectorEnum AutoFunctionROISelector => new AutoFunctionROISelectorEnum();

	public static FloatName AutoBacklightCompensation => (FloatName)"@CameraDevice/AutoBacklightCompensation";

	public static FloatName AutoExposureTimeUpperLimit => (FloatName)"@CameraDevice/AutoExposureTimeUpperLimit";

	public static FloatName AutoExposureTimeLowerLimit => (FloatName)"@CameraDevice/AutoExposureTimeLowerLimit";

	public static FloatName AutoGainUpperLimit => (FloatName)"@CameraDevice/AutoGainUpperLimit";

	public static FloatName AutoGainLowerLimit => (FloatName)"@CameraDevice/AutoGainLowerLimit";

	public static AutoFunctionProfileEnum AutoFunctionProfile => new AutoFunctionProfileEnum();

	public static FloatName AutoTargetBrightness => (FloatName)"@CameraDevice/AutoTargetBrightness";

	public static BslImmediateTriggerModeEnum BslImmediateTriggerMode => new BslImmediateTriggerModeEnum();

	public static OverlapModeEnum OverlapMode => new OverlapModeEnum();

	public static SensorShutterModeEnum SensorShutterMode => new SensorShutterModeEnum();

	public static BooleanName AcquisitionStatus => (BooleanName)"@CameraDevice/AcquisitionStatus";

	public static AcquisitionStatusSelectorEnum AcquisitionStatusSelector => new AcquisitionStatusSelectorEnum();

	public static FloatName SensorReadoutTime => (FloatName)"@CameraDevice/SensorReadoutTime";

	public static FloatName ResultingFrameRate => (FloatName)"@CameraDevice/ResultingFrameRate";

	public static FloatName AcquisitionFrameRate => (FloatName)"@CameraDevice/AcquisitionFrameRate";

	public static BooleanName AcquisitionFrameRateEnable => (BooleanName)"@CameraDevice/AcquisitionFrameRateEnable";

	public static FloatName TriggerDelay => (FloatName)"@CameraDevice/TriggerDelay";

	public static TriggerActivationEnum TriggerActivation => new TriggerActivationEnum();

	public static TriggerSourceEnum TriggerSource => new TriggerSourceEnum();

	public static CommandName TriggerSoftware => (CommandName)"@CameraDevice/TriggerSoftware";

	public static TriggerModeEnum TriggerMode => new TriggerModeEnum();

	public static TriggerSelectorEnum TriggerSelector => new TriggerSelectorEnum();

	public static IntegerName AcquisitionBurstFrameCount => (IntegerName)"@CameraDevice/AcquisitionBurstFrameCount";

	public static SensorReadoutModeEnum SensorReadoutMode => new SensorReadoutModeEnum();

	public static FloatName ExposureOverlapTimeMax => (FloatName)"@CameraDevice/ExposureOverlapTimeMax";

	public static ExposureOverlapTimeModeEnum ExposureOverlapTimeMode => new ExposureOverlapTimeModeEnum();

	public static FloatName ExposureTime => (FloatName)"@CameraDevice/ExposureTime";

	public static ExposureModeEnum ExposureMode => new ExposureModeEnum();

	public static ExposureTimeModeEnum ExposureTimeMode => new ExposureTimeModeEnum();

	public static ExposureAutoEnum ExposureAuto => new ExposureAutoEnum();

	public static ShutterModeEnum ShutterMode => new ShutterModeEnum();

	public static CommandName AcquisitionStop => (CommandName)"@CameraDevice/AcquisitionStop";

	public static CommandName AcquisitionStart => (CommandName)"@CameraDevice/AcquisitionStart";

	public static AcquisitionModeEnum AcquisitionMode => new AcquisitionModeEnum();

	public static FloatName SharpnessEnhancement => (FloatName)"@CameraDevice/SharpnessEnhancement";

	public static FloatName NoiseReduction => (FloatName)"@CameraDevice/NoiseReduction";

	public static PgiModeEnum PgiMode => new PgiModeEnum();

	public static DemosaicingModeEnum DemosaicingMode => new DemosaicingModeEnum();

	public static FloatName BslSaturationValue => (FloatName)"@CameraDevice/BslSaturationValue";

	public static FloatName BslSaturation => (FloatName)"@CameraDevice/BslSaturation";

	public static IntegerName BslHueValue => (IntegerName)"@CameraDevice/BslHueValue";

	public static FloatName BslHue => (FloatName)"@CameraDevice/BslHue";

	public static DefectPixelCorrectionModeEnum DefectPixelCorrectionMode => new DefectPixelCorrectionModeEnum();

	public static FloatName BslContrast => (FloatName)"@CameraDevice/BslContrast";

	public static FloatName BslBrightness => (FloatName)"@CameraDevice/BslBrightness";

	public static BslContrastModeEnum BslContrastMode => new BslContrastModeEnum();

	public static FloatName ColorTransformationValue => (FloatName)"@CameraDevice/ColorTransformationValue";

	public static ColorTransformationValueSelectorEnum ColorTransformationValueSelector => new ColorTransformationValueSelectorEnum();

	public static ColorTransformationSelectorEnum ColorTransformationSelector => new ColorTransformationSelectorEnum();

	public static FloatName ColorAdjustmentSaturation => (FloatName)"@CameraDevice/ColorAdjustmentSaturation";

	public static FloatName ColorAdjustmentHue => (FloatName)"@CameraDevice/ColorAdjustmentHue";

	public static ColorAdjustmentSelectorEnum ColorAdjustmentSelector => new ColorAdjustmentSelectorEnum();

	public static FloatName BalanceRatio => (FloatName)"@CameraDevice/BalanceRatio";

	public static BalanceRatioSelectorEnum BalanceRatioSelector => new BalanceRatioSelectorEnum();

	public static BalanceWhiteAutoEnum BalanceWhiteAuto => new BalanceWhiteAutoEnum();

	public static LightSourcePresetEnum LightSourcePreset => new LightSourcePresetEnum();

	public static BslColorSpaceModeEnum BslColorSpaceMode => new BslColorSpaceModeEnum();

	public static IntegerName DigitalShift => (IntegerName)"@CameraDevice/DigitalShift";

	public static ColorSpaceEnum ColorSpace => new ColorSpaceEnum();

	public static FloatName Gamma => (FloatName)"@CameraDevice/Gamma";

	public static FloatName BlackLevel => (FloatName)"@CameraDevice/BlackLevel";

	public static BlackLevelSelectorEnum BlackLevelSelector => new BlackLevelSelectorEnum();

	public static FloatName Gain => (FloatName)"@CameraDevice/Gain";

	public static GainSelectorEnum GainSelector => new GainSelectorEnum();

	public static GainAutoEnum GainAuto => new GainAutoEnum();

	public static IntegerName ROIZoneOffset => (IntegerName)"@CameraDevice/ROIZoneOffset";

	public static IntegerName ROIZoneSize => (IntegerName)"@CameraDevice/ROIZoneSize";

	public static ROIZoneModeEnum ROIZoneMode => new ROIZoneModeEnum();

	public static ROIZoneSelectorEnum ROIZoneSelector => new ROIZoneSelectorEnum();

	public static TestPatternEnum TestPattern => new TestPatternEnum();

	public static BooleanName TestImageResetAndHold => (BooleanName)"@CameraDevice/TestImageResetAndHold";

	public static TestImageSelectorEnum TestImageSelector => new TestImageSelectorEnum();

	public static IntegerName PixelDynamicRangeMax => (IntegerName)"@CameraDevice/PixelDynamicRangeMax";

	public static IntegerName PixelDynamicRangeMin => (IntegerName)"@CameraDevice/PixelDynamicRangeMin";

	public static PixelColorFilterEnum PixelColorFilter => new PixelColorFilterEnum();

	public static PixelSizeEnum PixelSize => new PixelSizeEnum();

	public static PixelFormatEnum PixelFormat => new PixelFormatEnum();

	public static BooleanName ReverseY => (BooleanName)"@CameraDevice/ReverseY";

	public static BooleanName ReverseX => (BooleanName)"@CameraDevice/ReverseX";

	public static FloatName ScalingVertical => (FloatName)"@CameraDevice/ScalingVertical";

	public static FloatName ScalingHorizontal => (FloatName)"@CameraDevice/ScalingHorizontal";

	public static IntegerName DecimationVertical => (IntegerName)"@CameraDevice/DecimationVertical";

	public static IntegerName DecimationHorizontal => (IntegerName)"@CameraDevice/DecimationHorizontal";

	public static IntegerName BinningVertical => (IntegerName)"@CameraDevice/BinningVertical";

	public static BinningVerticalModeEnum BinningVerticalMode => new BinningVerticalModeEnum();

	public static IntegerName BinningHorizontal => (IntegerName)"@CameraDevice/BinningHorizontal";

	public static BinningHorizontalModeEnum BinningHorizontalMode => new BinningHorizontalModeEnum();

	public static BooleanName CenterY => (BooleanName)"@CameraDevice/CenterY";

	public static BooleanName CenterX => (BooleanName)"@CameraDevice/CenterX";

	public static IntegerName LinePitch => (IntegerName)"@CameraDevice/LinePitch";

	public static BooleanName LinePitchEnable => (BooleanName)"@CameraDevice/LinePitchEnable";

	public static IntegerName OffsetY => (IntegerName)"@CameraDevice/OffsetY";

	public static IntegerName OffsetX => (IntegerName)"@CameraDevice/OffsetX";

	public static IntegerName Height => (IntegerName)"@CameraDevice/Height";

	public static IntegerName Width => (IntegerName)"@CameraDevice/Width";

	public static IntegerName HeightMax => (IntegerName)"@CameraDevice/HeightMax";

	public static IntegerName WidthMax => (IntegerName)"@CameraDevice/WidthMax";

	public static IntegerName SensorHeight => (IntegerName)"@CameraDevice/SensorHeight";

	public static IntegerName SensorWidth => (IntegerName)"@CameraDevice/SensorWidth";

	public static SequencerTriggerActivationEnum SequencerTriggerActivation => new SequencerTriggerActivationEnum();

	public static SequencerTriggerSourceEnum SequencerTriggerSource => new SequencerTriggerSourceEnum();

	public static IntegerName SequencerSetNext => (IntegerName)"@CameraDevice/SequencerSetNext";

	public static IntegerName SequencerPathSelector => (IntegerName)"@CameraDevice/SequencerPathSelector";

	public static CommandName SequencerSetSave => (CommandName)"@CameraDevice/SequencerSetSave";

	public static CommandName SequencerSetLoad => (CommandName)"@CameraDevice/SequencerSetLoad";

	public static IntegerName SequencerSetSelector => (IntegerName)"@CameraDevice/SequencerSetSelector";

	public static IntegerName SequencerSetStart => (IntegerName)"@CameraDevice/SequencerSetStart";

	public static SequencerConfigurationModeEnum SequencerConfigurationMode => new SequencerConfigurationModeEnum();

	public static IntegerName SequencerSetActive => (IntegerName)"@CameraDevice/SequencerSetActive";

	public static SequencerModeEnum SequencerMode => new SequencerModeEnum();

	public static CameraOperationModeEnum CameraOperationMode => new CameraOperationModeEnum();
}
