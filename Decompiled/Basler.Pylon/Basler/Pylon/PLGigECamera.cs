using System.ComponentModel;

namespace Basler.Pylon;

public static class PLGigECamera
{
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
	public class SequenceControlSelectorEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/SequenceControlSelector";

		public string Advance => "Advance";

		public string Restart => "Restart";

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

		public string CC4 => "CC4";

		public string CC3 => "CC3";

		public string CC2 => "CC2";

		public string CC1 => "CC1";

		public string Line8 => "Line8";

		public string Line7 => "Line7";

		public string Line6 => "Line6";

		public string Line5 => "Line5";

		public string Line4 => "Line4";

		public string Line3 => "Line3";

		public string Line2 => "Line2";

		public string Line1 => "Line1";

		public string AlwaysActive => "AlwaysActive";

		public string Disabled => "Disabled";

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

		public string CC4 => "CC4";

		public string CC3 => "CC3";

		public string CC2 => "CC2";

		public string CC1 => "CC1";

		public string Line8 => "Line8";

		public string Line7 => "Line7";

		public string Line6 => "Line6";

		public string Line5 => "Line5";

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

		public string Blue => "Blue";

		public string Green => "Green";

		public string Red => "Red";

		public string Tap4 => "Tap4";

		public string Tap3 => "Tap3";

		public string Tap2 => "Tap2";

		public string Tap1 => "Tap1";

		public string DigitalAll => "DigitalAll";

		public string AnalogAll => "AnalogAll";

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

		public string Blue => "Blue";

		public string Green => "Green";

		public string Red => "Red";

		public string Tap4 => "Tap4";

		public string Tap3 => "Tap3";

		public string Tap2 => "Tap2";

		public string Tap1 => "Tap1";

		public string DigitalAll => "DigitalAll";

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
	public class SensorBitDepthEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/SensorBitDepth";

		public string BitDepth16 => "BitDepth16";

		public string BitDepth14 => "BitDepth14";

		public string BitDepth12 => "BitDepth12";

		public string BitDepth10 => "BitDepth10";

		public string BitDepth8 => "BitDepth8";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class SensorDigitizationTapsEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/SensorDigitizationTaps";

		public string Four => "Four";

		public string Three => "Three";

		public string Two => "Two";

		public string One => "One";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class PixelFormatEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/PixelFormat";

		public string BayerBG10p => "BayerBG10p";

		public string BayerGB10p => "BayerGB10p";

		public string BayerRG10p => "BayerRG10p";

		public string BayerGR10p => "BayerGR10p";

		public string Mono8Signed => "Mono8Signed";

		public string RGB12V1Packed => "RGB12V1Packed";

		public string BayerBG16 => "BayerBG16";

		public string BayerGB16 => "BayerGB16";

		public string BayerRG16 => "BayerRG16";

		public string BayerGR16 => "BayerGR16";

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

		public string Mono10p => "Mono10p";

		public string Mono10Packed => "Mono10Packed";

		public string Mono10 => "Mono10";

		public string Mono8 => "Mono8";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class PixelCodingEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/PixelCoding";

		public string BayerBG10p => "BayerBG10p";

		public string BayerGB10p => "BayerGB10p";

		public string BayerRG10p => "BayerRG10p";

		public string BayerGR10p => "BayerGR10p";

		public string RGB16Planar => "RGB16Planar";

		public string RGB8Planar => "RGB8Planar";

		public string YUV444 => "YUV444";

		public string YUV422 => "YUV422";

		public string YUV411 => "YUV411";

		public string RGB10V2Packed => "RGB10V2Packed";

		public string RGB10V1Packed => "RGB10V1Packed";

		public string BGR16 => "BGR16";

		public string RGB16 => "RGB16";

		public string BGRA8 => "BGRA8";

		public string RGBA8 => "RGBA8";

		public string BGR8 => "BGR8";

		public string RGB8 => "RGB8";

		public string Raw16 => "Raw16";

		public string Raw8 => "Raw8";

		public string Mono12Packed => "Mono12Packed";

		public string Mono10Packed => "Mono10Packed";

		public string Mono16 => "Mono16";

		public string Mono8Signed => "Mono8Signed";

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

		public string Bpp64 => "Bpp64";

		public string Bpp48 => "Bpp48";

		public string Bpp36 => "Bpp36";

		public string Bpp32 => "Bpp32";

		public string Bpp24 => "Bpp24";

		public string Bpp16 => "Bpp16";

		public string Bpp14 => "Bpp14";

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
	public class SpatialCorrectionStartingLineEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/SpatialCorrectionStartingLine";

		public string LineBlue => "LineBlue";

		public string LineGreen => "LineGreen";

		public string LineRed => "LineRed";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class FieldOutputModeEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/FieldOutputMode";

		public string DeinterlacedNewFields => "DeinterlacedNewFields";

		public string ConcatenatedNewFields => "ConcatenatedNewFields";

		public string Field0First => "Field0First";

		public string Field1 => "Field1";

		public string Field0 => "Field0";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class TestImageSelectorEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/TestImageSelector";

		public string Testimage7 => "Testimage7";

		public string Testimage6 => "Testimage6";

		public string Testimage5 => "Testimage5";

		public string Testimage4 => "Testimage4";

		public string Testimage3 => "Testimage3";

		public string Testimage2 => "Testimage2";

		public string Testimage1 => "Testimage1";

		public string MovingDiagonalColorGradient => "MovingDiagonalColorGradient";

		public string MovingDiagonalGrayGradientFeatureTest_12Bit => "MovingDiagonalGrayGradientFeatureTest_12Bit";

		public string MovingDiagonalGrayGradientFeatureTest_8Bit => "MovingDiagonalGrayGradientFeatureTest_8Bit";

		public string MovingDiagonalGrayGradient_12Bit => "MovingDiagonalGrayGradient_12Bit";

		public string MovingDiagonalGrayGradient_8Bit => "MovingDiagonalGrayGradient_8Bit";

		public string FixedDiagonalGrayGradient_8Bit => "FixedDiagonalGrayGradient_8Bit";

		public string DeviceSpecific => "DeviceSpecific";

		public string FrameCounter => "FrameCounter";

		public string ColorBar => "ColorBar";

		public string VerticalLineMoving => "VerticalLineMoving";

		public string HorzontalLineMoving => "HorzontalLineMoving";

		public string GreyVerticalRampMoving => "GreyVerticalRampMoving";

		public string GreyHorizontalRampMoving => "GreyHorizontalRampMoving";

		public string GreyVerticalRamp => "GreyVerticalRamp";

		public string GreyHorizontalRamp => "GreyHorizontalRamp";

		public string White => "White";

		public string Black => "Black";

		public string Off => "Off";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class LightSourceSelectorEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/LightSourceSelector";

		public string LightSource1 => "LightSource1";

		public string LightSource0 => "LightSource0";

		public string Daylight6500K => "Daylight6500K";

		public string MicroscopeLED6000K => "MicroscopeLED6000K";

		public string MicroscopeLED5500K => "MicroscopeLED5500K";

		public string MicroscopeLED4500K => "MicroscopeLED4500K";

		public string Tungsten => "Tungsten";

		public string Daylight => "Daylight";

		public string Custom => "Custom";

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
	public class BinningModeHorizontalEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/BinningModeHorizontal";

		public string Averaging => "Averaging";

		public string Summing => "Summing";

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
	public class BinningModeVerticalEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/BinningModeVertical";

		public string Averaging => "Averaging";

		public string Summing => "Summing";

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
	public class AcquisitionModeEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/AcquisitionMode";

		public string Continuous => "Continuous";

		public string MultiFrame => "MultiFrame";

		public string SingleFrame => "SingleFrame";

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

		public string ExposureActive => "ExposureActive";

		public string ExposureEnd => "ExposureEnd";

		public string ExposureStart => "ExposureStart";

		public string LineStart => "LineStart";

		public string FrameActive => "FrameActive";

		public string FrameEnd => "FrameEnd";

		public string FrameStart => "FrameStart";

		public string AcquisitionActive => "AcquisitionActive";

		public string AcquisitionEnd => "AcquisitionEnd";

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

		public string VInputDecActive => "VInputDecActive";

		public string VInput4 => "VInput4";

		public string VInput3 => "VInput3";

		public string VInput2 => "VInput2";

		public string VInput1 => "VInput1";

		public string Action4 => "Action4";

		public string Action3 => "Action3";

		public string Action2 => "Action2";

		public string Action1 => "Action1";

		public string UserOutput2 => "UserOutput2";

		public string UserOutput1 => "UserOutput1";

		public string Counter1End => "Counter1End";

		public string Counter1Start => "Counter1Start";

		public string Timer1End => "Timer1End";

		public string Timer1Start => "Timer1Start";

		public string FrequencyConverter => "FrequencyConverter";

		public string ShaftEncoderModuleOut => "ShaftEncoderModuleOut";

		public string CC4 => "CC4";

		public string CC3 => "CC3";

		public string CC2 => "CC2";

		public string CC1 => "CC1";

		public string Line8 => "Line8";

		public string Line7 => "Line7";

		public string Line6 => "Line6";

		public string Line5 => "Line5";

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
	public class TriggerDelaySourceEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/TriggerDelaySource";

		public string LineTrigger => "LineTrigger";

		public string Time_us => "Time_us";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class ExposureModeEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/ExposureMode";

		public string TriggerControlled => "TriggerControlled";

		public string TriggerWidth => "TriggerWidth";

		public string Timed => "Timed";

		public string Off => "Off";

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
	public class AcquisitionStatusSelectorEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/AcquisitionStatusSelector";

		public string AcquisitionIdle => "AcquisitionIdle";

		public string LineTriggerWait => "LineTriggerWait";

		public string ExposureActive => "ExposureActive";

		public string FrameTransfer => "FrameTransfer";

		public string FrameActive => "FrameActive";

		public string FrameTriggerWait => "FrameTriggerWait";

		public string AcquisitionTransfer => "AcquisitionTransfer";

		public string AcquisitionActive => "AcquisitionActive";

		public string AcquisitionTriggerWait => "AcquisitionTriggerWait";

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
	public class LineSourceEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/LineSource";

		public string SyncUserOutput3 => "SyncUserOutput3";

		public string SyncUserOutput2 => "SyncUserOutput2";

		public string SyncUserOutput1 => "SyncUserOutput1";

		public string SyncUserOutput0 => "SyncUserOutput0";

		public string UserOutput0 => "UserOutput0";

		public string SyncUserOutput => "SyncUserOutput";

		public string FrameCycle => "FrameCycle";

		public string FlashWindow => "FlashWindow";

		public string AcquisitionTriggerReady => "AcquisitionTriggerReady";

		public string PatternGenerator4 => "PatternGenerator4";

		public string PatternGenerator3 => "PatternGenerator3";

		public string PatternGenerator2 => "PatternGenerator2";

		public string PatternGenerator1 => "PatternGenerator1";

		public string FrequencyConverter => "FrequencyConverter";

		public string ShaftEncoderModuleOut => "ShaftEncoderModuleOut";

		public string AcquisitionTriggerWait => "AcquisitionTriggerWait";

		public string SerialTx => "SerialTx";

		public string TriggerReady => "TriggerReady";

		public string UserOutput => "UserOutput";

		public string UserOutput4 => "UserOutput4";

		public string UserOutput3 => "UserOutput3";

		public string UserOutput2 => "UserOutput2";

		public string UserOutput1 => "UserOutput1";

		public string TimerActive => "TimerActive";

		public string Timer4Active => "Timer4Active";

		public string Timer3Active => "Timer3Active";

		public string Timer2Active => "Timer2Active";

		public string Timer1Active => "Timer1Active";

		public string LineTriggerWait => "LineTriggerWait";

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

		public string UserOutput8 => "UserOutput8";

		public string UserOutput7 => "UserOutput7";

		public string UserOutput6 => "UserOutput6";

		public string UserOutput5 => "UserOutput5";

		public string UserOutput4 => "UserOutput4";

		public string UserOutput3 => "UserOutput3";

		public string UserOutput2 => "UserOutput2";

		public string UserOutput1 => "UserOutput1";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class SyncUserOutputSelectorEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/SyncUserOutputSelector";

		public string SyncUserOutput8 => "SyncUserOutput8";

		public string SyncUserOutput7 => "SyncUserOutput7";

		public string SyncUserOutput6 => "SyncUserOutput6";

		public string SyncUserOutput5 => "SyncUserOutput5";

		public string SyncUserOutput4 => "SyncUserOutput4";

		public string SyncUserOutput3 => "SyncUserOutput3";

		public string SyncUserOutput2 => "SyncUserOutput2";

		public string SyncUserOutput1 => "SyncUserOutput1";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class VInpSignalSourceEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/VInpSignalSource";

		public string CC4 => "CC4";

		public string CC3 => "CC3";

		public string CC2 => "CC2";

		public string CC1 => "CC1";

		public string Line8 => "Line8";

		public string Line7 => "Line7";

		public string Line6 => "Line6";

		public string Line5 => "Line5";

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
	public class VInpSignalReadoutActivationEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/VInpSignalReadoutActivation";

		public string FallingEdge => "FallingEdge";

		public string RisingEdge => "RisingEdge";

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

		public string CC4 => "CC4";

		public string CC3 => "CC3";

		public string CC2 => "CC2";

		public string CC1 => "CC1";

		public string Line8 => "Line8";

		public string Line7 => "Line7";

		public string Line6 => "Line6";

		public string Line5 => "Line5";

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
	public class FrequencyConverterInputSourceEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/FrequencyConverterInputSource";

		public string ShaftEncoderModuleOut => "ShaftEncoderModuleOut";

		public string CC4 => "CC4";

		public string CC3 => "CC3";

		public string CC2 => "CC2";

		public string CC1 => "CC1";

		public string Line8 => "Line8";

		public string Line7 => "Line7";

		public string Line6 => "Line6";

		public string Line5 => "Line5";

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
	public class FrequencyConverterSignalAlignmentEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/FrequencyConverterSignalAlignment";

		public string FallingEdge => "FallingEdge";

		public string RisingEdge => "RisingEdge";

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
	public class TimerTriggerSourceEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/TimerTriggerSource";

		public string FlashWindowStart => "FlashWindowStart";

		public string ExposureStart => "ExposureStart";

		public string Off => "Off";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class TimerTriggerActivationEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/TimerTriggerActivation";

		public string LevelLow => "LevelLow";

		public string LevelHigh => "LevelHigh";

		public string FallingEdge => "FallingEdge";

		public string RisingEdge => "RisingEdge";

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
	public class CounterEventSourceEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/CounterEventSource";

		public string ExposureEnd => "ExposureEnd";

		public string ExposureStart => "ExposureStart";

		public string LineEnd => "LineEnd";

		public string LineStart => "LineStart";

		public string LineTrigger => "LineTrigger";

		public string FrameEnd => "FrameEnd";

		public string FrameStart => "FrameStart";

		public string FrameTrigger => "FrameTrigger";

		public string AcquisitionEnd => "AcquisitionEnd";

		public string AcquisitionStart => "AcquisitionStart";

		public string AcquisitionTrigger => "AcquisitionTrigger";

		public string Off => "Off";

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

		public string CC4 => "CC4";

		public string CC3 => "CC3";

		public string CC2 => "CC2";

		public string CC1 => "CC1";

		public string Line8 => "Line8";

		public string Line7 => "Line7";

		public string Line6 => "Line6";

		public string Line5 => "Line5";

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
	public class TimerSequenceEntrySelectorEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/TimerSequenceEntrySelector";

		public string Entry16 => "Entry16";

		public string Entry15 => "Entry15";

		public string Entry14 => "Entry14";

		public string Entry13 => "Entry13";

		public string Entry12 => "Entry12";

		public string Entry11 => "Entry11";

		public string Entry10 => "Entry10";

		public string Entry9 => "Entry9";

		public string Entry8 => "Entry8";

		public string Entry7 => "Entry7";

		public string Entry6 => "Entry6";

		public string Entry5 => "Entry5";

		public string Entry4 => "Entry4";

		public string Entry3 => "Entry3";

		public string Entry2 => "Entry2";

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
	public class GevInterfaceSelectorEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/GevInterfaceSelector";

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
	public class GevCCPEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/GevCCP";

		public string ExclusiveControl => "ExclusiveControl";

		public string Control => "Control";

		public string Exclusive => "Exclusive";

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
	public class GevIEEE1588StatusEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/GevIEEE1588Status";

		public string Slave => "Slave";

		public string Uncalibrated => "Uncalibrated";

		public string Passive => "Passive";

		public string Master => "Master";

		public string PreMaster => "PreMaster";

		public string Listening => "Listening";

		public string Disabled => "Disabled";

		public string Faulty => "Faulty";

		public string Initializing => "Initializing";

		public string Undefined => "Undefined";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class GevIEEE1588StatusLatchedEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/GevIEEE1588StatusLatched";

		public string Slave => "Slave";

		public string Uncalibrated => "Uncalibrated";

		public string Passive => "Passive";

		public string Master => "Master";

		public string PreMaster => "PreMaster";

		public string Listening => "Listening";

		public string Disabled => "Disabled";

		public string Faulty => "Faulty";

		public string Initializing => "Initializing";

		public string Undefined => "Undefined";

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

		public string Custom1 => "Custom1";

		public string Custom0 => "Custom0";

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
	public class UserSetDefaultSelectorEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/UserSetDefaultSelector";

		public string LightMicroscopy => "LightMicroscopy";

		public string UserSet3 => "UserSet3";

		public string UserSet2 => "UserSet2";

		public string UserSet1 => "UserSet1";

		public string Custom1 => "Custom1";

		public string Custom0 => "Custom0";

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
	public class DefaultSetSelectorEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/DefaultSetSelector";

		public string LightMicroscopy => "LightMicroscopy";

		public string Custom1 => "Custom1";

		public string Custom0 => "Custom0";

		public string ColorRaw => "ColorRaw";

		public string Color => "Color";

		public string AutoFunctions => "AutoFunctions";

		public string HighGain => "HighGain";

		public string Standard => "Standard";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class AutoFunctionProfileEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/AutoFunctionProfile";

		public string ExposureMinimumQuick => "ExposureMinimumQuick";

		public string GainMinimumQuick => "GainMinimumQuick";

		public string ExposureMinimum => "ExposureMinimum";

		public string GainMinimum => "GainMinimum";

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
	public class ShadingSelectorEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/ShadingSelector";

		public string GainShading => "GainShading";

		public string OffsetShading => "OffsetShading";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class ShadingStatusEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/ShadingStatus";

		public string CreateError => "CreateError";

		public string ActivateError => "ActivateError";

		public string StartupSetError => "StartupSetError";

		public string NoError => "NoError";

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
	public class FeatureSetEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/FeatureSet";

		public string Basic => "Basic";

		public string Full => "Full";

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

		public string Case => "Case";

		public string Framegrabberboard => "Framegrabberboard";

		public string Coreboard => "Coreboard";

		public string Sensorboard => "Sensorboard";

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
	public class LastErrorEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/LastError";

		public string UserDefPixFailure => "UserDefPixFailure";

		public string InsufficientTriggerWidth => "InsufficientTriggerWidth";

		public string PowerFailure => "PowerFailure";

		public string OverTemperature => "OverTemperature";

		public string InvalidParameter => "InvalidParameter";

		public string Userset => "Userset";

		public string Overtrigger => "Overtrigger";

		public string NoError => "NoError";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class ParameterSelectorEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/ParameterSelector";

		public string ExposureOverlapMax => "ExposureOverlapMax";

		public string ExposureOverhead => "ExposureOverhead";

		public string AutoTargetValue => "AutoTargetValue";

		public string Framerate => "Framerate";

		public string ExposureTime => "ExposureTime";

		public string BlackLevel => "BlackLevel";

		public string Brightness => "Brightness";

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

		public string ExpertFeature1_Legacy => "ExpertFeature1_Legacy";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class ChunkSelectorEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/ChunkSelector";

		public string LineTriggerCounter => "LineTriggerCounter";

		public string VirtLineStatusAll => "VirtLineStatusAll";

		public string BrightPixel => "BrightPixel";

		public string GainAll => "GainAll";

		public string ExposureTime => "ExposureTime";

		public string SequenceSetIndex => "SequenceSetIndex";

		public string Stride => "Stride";

		public string PayloadCRC16 => "PayloadCRC16";

		public string ShaftEncoderCounter => "ShaftEncoderCounter";

		public string InputStatusAtLineTrigger => "InputStatusAtLineTrigger";

		public string FramesPerTriggerCounter => "FramesPerTriggerCounter";

		public string FrameTriggerCounter => "FrameTriggerCounter";

		public string LineTriggerEndToEndCounter => "LineTriggerEndToEndCounter";

		public string FrameTriggerIgnoredCounter => "FrameTriggerIgnoredCounter";

		public string LineTriggerIgnoredCounter => "LineTriggerIgnoredCounter";

		public string Triggerinputcounter => "Triggerinputcounter";

		public string Framecounter => "Framecounter";

		public string LineStatusAll => "LineStatusAll";

		public string Timestamp => "Timestamp";

		public string DynamicRangeMin => "DynamicRangeMin";

		public string DynamicRangeMax => "DynamicRangeMax";

		public string PixelFormat => "PixelFormat";

		public string Height => "Height";

		public string Width => "Width";

		public string OffsetY => "OffsetY";

		public string OffsetX => "OffsetX";

		public string Image => "Image";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class ChunkPixelFormatEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/ChunkPixelFormat";

		public string BayerBG10p => "BayerBG10p";

		public string BayerRG10p => "BayerRG10p";

		public string BayerGR10p => "BayerGR10p";

		public string BayerGB10p => "BayerGB10p";

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

		public string Mono10p => "Mono10p";

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

		public string EventOverrun => "EventOverrun";

		public string AcquisitionStartWait => "AcquisitionStartWait";

		public string FrameStartWait => "FrameStartWait";

		public string AcquisitionWait => "AcquisitionWait";

		public string FrameWait => "FrameWait";

		public string VirtualLine4RisingEdge => "VirtualLine4RisingEdge";

		public string VirtualLine3RisingEdge => "VirtualLine3RisingEdge";

		public string VirtualLine2RisingEdge => "VirtualLine2RisingEdge";

		public string VirtualLine1RisingEdge => "VirtualLine1RisingEdge";

		public string Line4RisingEdge => "Line4RisingEdge";

		public string Line3RisingEdge => "Line3RisingEdge";

		public string Line2RisingEdge => "Line2RisingEdge";

		public string Line1RisingEdge => "Line1RisingEdge";

		public string ActionLate => "ActionLate";

		public string OverTemperature => "OverTemperature";

		public string CriticalTemperature => "CriticalTemperature";

		public string AcquisitionStart => "AcquisitionStart";

		public string FrameStart => "FrameStart";

		public string FrameTimeout => "FrameTimeout";

		public string AcquisitionStartOvertrigger => "AcquisitionStartOvertrigger";

		public string FrameStartOvertrigger => "FrameStartOvertrigger";

		public string LineStartOvertrigger => "LineStartOvertrigger";

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

	public static CommandName FileOperationExecute => (CommandName)"@CameraDevice/FileOperationExecute";

	public static IntegerName FileSize => (IntegerName)"@CameraDevice/FileSize";

	public static IntegerName FileOperationResult => (IntegerName)"@CameraDevice/FileOperationResult";

	public static FileOperationStatusEnum FileOperationStatus => new FileOperationStatusEnum();

	public static IntegerName FileAccessLength => (IntegerName)"@CameraDevice/FileAccessLength";

	public static IntegerName FileAccessOffset => (IntegerName)"@CameraDevice/FileAccessOffset";

	public static FileOpenModeEnum FileOpenMode => new FileOpenModeEnum();

	public static FileOperationSelectorEnum FileOperationSelector => new FileOperationSelectorEnum();

	public static FileSelectorEnum FileSelector => new FileSelectorEnum();

	public static IntegerName AcquisitionStartWaitEventTimestamp => (IntegerName)"@CameraDevice/AcquisitionStartWaitEventTimestamp";

	public static IntegerName AcquisitionStartWaitEventStreamChannelIndex => (IntegerName)"@CameraDevice/AcquisitionStartWaitEventStreamChannelIndex";

	public static IntegerName FrameStartWaitEventTimestamp => (IntegerName)"@CameraDevice/FrameStartWaitEventTimestamp";

	public static IntegerName FrameStartWaitEventStreamChannelIndex => (IntegerName)"@CameraDevice/FrameStartWaitEventStreamChannelIndex";

	public static IntegerName AcquisitionWaitEventTimestamp => (IntegerName)"@CameraDevice/AcquisitionWaitEventTimestamp";

	public static IntegerName AcquisitionWaitEventStreamChannelIndex => (IntegerName)"@CameraDevice/AcquisitionWaitEventStreamChannelIndex";

	public static IntegerName FrameWaitEventTimestamp => (IntegerName)"@CameraDevice/FrameWaitEventTimestamp";

	public static IntegerName FrameWaitEventStreamChannelIndex => (IntegerName)"@CameraDevice/FrameWaitEventStreamChannelIndex";

	public static IntegerName VirtualLine4RisingEdgeEventTimestamp => (IntegerName)"@CameraDevice/VirtualLine4RisingEdgeEventTimestamp";

	public static IntegerName VirtualLine4RisingEdgeEventStreamChannelIndex => (IntegerName)"@CameraDevice/VirtualLine4RisingEdgeEventStreamChannelIndex";

	public static IntegerName VirtualLine3RisingEdgeEventTimestamp => (IntegerName)"@CameraDevice/VirtualLine3RisingEdgeEventTimestamp";

	public static IntegerName VirtualLine3RisingEdgeEventStreamChannelIndex => (IntegerName)"@CameraDevice/VirtualLine3RisingEdgeEventStreamChannelIndex";

	public static IntegerName VirtualLine2RisingEdgeEventTimestamp => (IntegerName)"@CameraDevice/VirtualLine2RisingEdgeEventTimestamp";

	public static IntegerName VirtualLine2RisingEdgeEventStreamChannelIndex => (IntegerName)"@CameraDevice/VirtualLine2RisingEdgeEventStreamChannelIndex";

	public static IntegerName VirtualLine1RisingEdgeEventTimestamp => (IntegerName)"@CameraDevice/VirtualLine1RisingEdgeEventTimestamp";

	public static IntegerName VirtualLine1RisingEdgeEventStreamChannelIndex => (IntegerName)"@CameraDevice/VirtualLine1RisingEdgeEventStreamChannelIndex";

	public static IntegerName Line4RisingEdgeEventTimestamp => (IntegerName)"@CameraDevice/Line4RisingEdgeEventTimestamp";

	public static IntegerName Line4RisingEdgeEventStreamChannelIndex => (IntegerName)"@CameraDevice/Line4RisingEdgeEventStreamChannelIndex";

	public static IntegerName Line3RisingEdgeEventTimestamp => (IntegerName)"@CameraDevice/Line3RisingEdgeEventTimestamp";

	public static IntegerName Line3RisingEdgeEventStreamChannelIndex => (IntegerName)"@CameraDevice/Line3RisingEdgeEventStreamChannelIndex";

	public static IntegerName Line2RisingEdgeEventTimestamp => (IntegerName)"@CameraDevice/Line2RisingEdgeEventTimestamp";

	public static IntegerName Line2RisingEdgeEventStreamChannelIndex => (IntegerName)"@CameraDevice/Line2RisingEdgeEventStreamChannelIndex";

	public static IntegerName Line1RisingEdgeEventTimestamp => (IntegerName)"@CameraDevice/Line1RisingEdgeEventTimestamp";

	public static IntegerName Line1RisingEdgeEventStreamChannelIndex => (IntegerName)"@CameraDevice/Line1RisingEdgeEventStreamChannelIndex";

	public static IntegerName LateActionEventTimestamp => (IntegerName)"@CameraDevice/LateActionEventTimestamp";

	public static IntegerName LateActionEventStreamChannelIndex => (IntegerName)"@CameraDevice/LateActionEventStreamChannelIndex";

	public static IntegerName ActionLateEventTimestamp => (IntegerName)"@CameraDevice/ActionLateEventTimestamp";

	public static IntegerName ActionLateEventStreamChannelIndex => (IntegerName)"@CameraDevice/ActionLateEventStreamChannelIndex";

	public static IntegerName OverTemperatureEventTimestamp => (IntegerName)"@CameraDevice/OverTemperatureEventTimestamp";

	public static IntegerName OverTemperatureEventStreamChannelIndex => (IntegerName)"@CameraDevice/OverTemperatureEventStreamChannelIndex";

	public static IntegerName CriticalTemperatureEventTimestamp => (IntegerName)"@CameraDevice/CriticalTemperatureEventTimestamp";

	public static IntegerName CriticalTemperatureEventStreamChannelIndex => (IntegerName)"@CameraDevice/CriticalTemperatureEventStreamChannelIndex";

	public static IntegerName EventOverrunEventTimestamp => (IntegerName)"@CameraDevice/EventOverrunEventTimestamp";

	public static IntegerName EventOverrunEventFrameID => (IntegerName)"@CameraDevice/EventOverrunEventFrameID";

	public static IntegerName EventOverrunEventStreamChannelIndex => (IntegerName)"@CameraDevice/EventOverrunEventStreamChannelIndex";

	public static IntegerName FrameTimeoutEventTimestamp => (IntegerName)"@CameraDevice/FrameTimeoutEventTimestamp";

	public static IntegerName FrameTimeoutEventStreamChannelIndex => (IntegerName)"@CameraDevice/FrameTimeoutEventStreamChannelIndex";

	public static IntegerName AcquisitionStartOvertriggerEventTimestamp => (IntegerName)"@CameraDevice/AcquisitionStartOvertriggerEventTimestamp";

	public static IntegerName AcquisitionStartOvertriggerEventStreamChannelIndex => (IntegerName)"@CameraDevice/AcquisitionStartOvertriggerEventStreamChannelIndex";

	public static IntegerName AcquisitionStartEventTimestamp => (IntegerName)"@CameraDevice/AcquisitionStartEventTimestamp";

	public static IntegerName AcquisitionStartEventStreamChannelIndex => (IntegerName)"@CameraDevice/AcquisitionStartEventStreamChannelIndex";

	public static IntegerName FrameStartEventTimestamp => (IntegerName)"@CameraDevice/FrameStartEventTimestamp";

	public static IntegerName FrameStartEventStreamChannelIndex => (IntegerName)"@CameraDevice/FrameStartEventStreamChannelIndex";

	public static IntegerName FrameStartOvertriggerEventTimestamp => (IntegerName)"@CameraDevice/FrameStartOvertriggerEventTimestamp";

	public static IntegerName FrameStartOvertriggerEventStreamChannelIndex => (IntegerName)"@CameraDevice/FrameStartOvertriggerEventStreamChannelIndex";

	public static IntegerName LineStartOvertriggerEventTimestamp => (IntegerName)"@CameraDevice/LineStartOvertriggerEventTimestamp";

	public static IntegerName LineStartOvertriggerEventStreamChannelIndex => (IntegerName)"@CameraDevice/LineStartOvertriggerEventStreamChannelIndex";

	public static IntegerName ExposureEndEventTimestamp => (IntegerName)"@CameraDevice/ExposureEndEventTimestamp";

	public static IntegerName ExposureEndEventFrameID => (IntegerName)"@CameraDevice/ExposureEndEventFrameID";

	public static IntegerName ExposureEndEventStreamChannelIndex => (IntegerName)"@CameraDevice/ExposureEndEventStreamChannelIndex";

	public static EventNotificationEnum EventNotification => new EventNotificationEnum();

	public static EventSelectorEnum EventSelector => new EventSelectorEnum();

	public static IntegerName ChunkLineTriggerCounter => (IntegerName)"@CameraDevice/ChunkLineTriggerCounter";

	public static IntegerName ChunkGainAll => (IntegerName)"@CameraDevice/ChunkGainAll";

	public static IntegerName ChunkPayloadCRC16 => (IntegerName)"@CameraDevice/ChunkPayloadCRC16";

	public static FloatName ChunkExposureTime => (FloatName)"@CameraDevice/ChunkExposureTime";

	public static IntegerName ChunkShaftEncoderCounter => (IntegerName)"@CameraDevice/ChunkShaftEncoderCounter";

	public static IntegerName ChunkInputStatusAtLineTriggerValue => (IntegerName)"@CameraDevice/ChunkInputStatusAtLineTriggerValue";

	public static IntegerName ChunkInputStatusAtLineTriggerIndex => (IntegerName)"@CameraDevice/ChunkInputStatusAtLineTriggerIndex";

	public static IntegerName ChunkInputStatusAtLineTriggerBitsPerLine => (IntegerName)"@CameraDevice/ChunkInputStatusAtLineTriggerBitsPerLine";

	public static IntegerName ChunkLineTriggerEndToEndCounter => (IntegerName)"@CameraDevice/ChunkLineTriggerEndToEndCounter";

	public static IntegerName ChunkFramesPerTriggerCounter => (IntegerName)"@CameraDevice/ChunkFramesPerTriggerCounter";

	public static IntegerName ChunkFrameTriggerCounter => (IntegerName)"@CameraDevice/ChunkFrameTriggerCounter";

	public static IntegerName ChunkFrameTriggerIgnoredCounter => (IntegerName)"@CameraDevice/ChunkFrameTriggerIgnoredCounter";

	public static IntegerName ChunkLineTriggerIgnoredCounter => (IntegerName)"@CameraDevice/ChunkLineTriggerIgnoredCounter";

	public static IntegerName ChunkTriggerinputcounter => (IntegerName)"@CameraDevice/ChunkTriggerinputcounter";

	public static IntegerName ChunkVirtLineStatusAll => (IntegerName)"@CameraDevice/ChunkVirtLineStatusAll";

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

	public static IntegerName ChunkSequenceSetIndex => (IntegerName)"@CameraDevice/ChunkSequenceSetIndex";

	public static IntegerName ChunkStride => (IntegerName)"@CameraDevice/ChunkStride";

	public static BooleanName ChunkEnable => (BooleanName)"@CameraDevice/ChunkEnable";

	public static ChunkSelectorEnum ChunkSelector => new ChunkSelectorEnum();

	public static BooleanName ChunkModeActive => (BooleanName)"@CameraDevice/ChunkModeActive";

	public static BooleanName ExpertFeatureEnable => (BooleanName)"@CameraDevice/ExpertFeatureEnable";

	public static IntegerName ExpertFeatureAccessKey => (IntegerName)"@CameraDevice/ExpertFeatureAccessKey";

	public static ExpertFeatureAccessSelectorEnum ExpertFeatureAccessSelector => new ExpertFeatureAccessSelectorEnum();

	public static IntegerName Prelines => (IntegerName)"@CameraDevice/Prelines";

	public static BooleanName RemoveLimits => (BooleanName)"@CameraDevice/RemoveLimits";

	public static ParameterSelectorEnum ParameterSelector => new ParameterSelectorEnum();

	public static IntegerName DeviceColorPipelineVersion => (IntegerName)"@CameraDevice/DeviceColorPipelineVersion";

	public static CommandName ClearLastError => (CommandName)"@CameraDevice/ClearLastError";

	public static LastErrorEnum LastError => new LastErrorEnum();

	public static BooleanName OverTemperature => (BooleanName)"@CameraDevice/OverTemperature";

	public static BooleanName CriticalTemperature => (BooleanName)"@CameraDevice/CriticalTemperature";

	public static TemperatureStateEnum TemperatureState => new TemperatureStateEnum();

	public static FloatName TemperatureAbs => (FloatName)"@CameraDevice/TemperatureAbs";

	public static TemperatureSelectorEnum TemperatureSelector => new TemperatureSelectorEnum();

	public static CommandName DeviceReset => (CommandName)"@CameraDevice/DeviceReset";

	public static DeviceScanTypeEnum DeviceScanType => new DeviceScanTypeEnum();

	public static StringName DeviceUserID => (StringName)"@CameraDevice/DeviceUserID";

	public static StringName DeviceID => (StringName)"@CameraDevice/DeviceID";

	public static StringName DeviceFirmwareVersion => (StringName)"@CameraDevice/DeviceFirmwareVersion";

	public static StringName DeviceVersion => (StringName)"@CameraDevice/DeviceVersion";

	public static StringName DeviceManufacturerInfo => (StringName)"@CameraDevice/DeviceManufacturerInfo";

	public static StringName DeviceModelName => (StringName)"@CameraDevice/DeviceModelName";

	public static StringName DeviceVendorName => (StringName)"@CameraDevice/DeviceVendorName";

	public static FeatureSetEnum FeatureSet => new FeatureSetEnum();

	public static IntegerName GenicamXmlFileDefault => (IntegerName)"@CameraDevice/GenicamXmlFileDefault";

	public static IntegerName UserDefinedValue => (IntegerName)"@CameraDevice/UserDefinedValue";

	public static UserDefinedValueSelectorEnum UserDefinedValueSelector => new UserDefinedValueSelectorEnum();

	public static ShadingSetCreateEnum ShadingSetCreate => new ShadingSetCreateEnum();

	public static CommandName ShadingSetActivate => (CommandName)"@CameraDevice/ShadingSetActivate";

	public static ShadingSetSelectorEnum ShadingSetSelector => new ShadingSetSelectorEnum();

	public static ShadingSetDefaultSelectorEnum ShadingSetDefaultSelector => new ShadingSetDefaultSelectorEnum();

	public static ShadingStatusEnum ShadingStatus => new ShadingStatusEnum();

	public static BooleanName ShadingEnable => (BooleanName)"@CameraDevice/ShadingEnable";

	public static ShadingSelectorEnum ShadingSelector => new ShadingSelectorEnum();

	public static IntegerName ColorOverexposureCompensationAOIOffsetY => (IntegerName)"@CameraDevice/ColorOverexposureCompensationAOIOffsetY";

	public static IntegerName ColorOverexposureCompensationAOIOffsetX => (IntegerName)"@CameraDevice/ColorOverexposureCompensationAOIOffsetX";

	public static IntegerName ColorOverexposureCompensationAOIHeight => (IntegerName)"@CameraDevice/ColorOverexposureCompensationAOIHeight";

	public static IntegerName ColorOverexposureCompensationAOIWidth => (IntegerName)"@CameraDevice/ColorOverexposureCompensationAOIWidth";

	public static IntegerName ColorOverexposureCompensationAOIFactorRaw => (IntegerName)"@CameraDevice/ColorOverexposureCompensationAOIFactorRaw";

	public static FloatName ColorOverexposureCompensationAOIFactor => (FloatName)"@CameraDevice/ColorOverexposureCompensationAOIFactor";

	public static BooleanName ColorOverexposureCompensationAOIEnable => (BooleanName)"@CameraDevice/ColorOverexposureCompensationAOIEnable";

	public static ColorOverexposureCompensationAOISelectorEnum ColorOverexposureCompensationAOISelector => new ColorOverexposureCompensationAOISelectorEnum();

	public static IntegerName AutoTonalRangeTargetBright => (IntegerName)"@CameraDevice/AutoTonalRangeTargetBright";

	public static IntegerName AutoTonalRangeTargetDark => (IntegerName)"@CameraDevice/AutoTonalRangeTargetDark";

	public static IntegerName AutoTonalRangeThresholdBrightRaw => (IntegerName)"@CameraDevice/AutoTonalRangeThresholdBrightRaw";

	public static FloatName AutoTonalRangeThresholdBright => (FloatName)"@CameraDevice/AutoTonalRangeThresholdBright";

	public static IntegerName AutoTonalRangeThresholdDarkRaw => (IntegerName)"@CameraDevice/AutoTonalRangeThresholdDarkRaw";

	public static FloatName AutoTonalRangeThresholdDark => (FloatName)"@CameraDevice/AutoTonalRangeThresholdDark";

	public static AutoTonalRangeAdjustmentSelectorEnum AutoTonalRangeAdjustmentSelector => new AutoTonalRangeAdjustmentSelectorEnum();

	public static AutoTonalRangeModeSelectorEnum AutoTonalRangeModeSelector => new AutoTonalRangeModeSelectorEnum();

	public static BooleanName AutoFunctionAOIUsageTonalRange => (BooleanName)"@CameraDevice/AutoFunctionAOIUsageTonalRange";

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

	public static IntegerName BalanceWhiteAdjustmentDampingRaw => (IntegerName)"@CameraDevice/BalanceWhiteAdjustmentDampingRaw";

	public static FloatName BalanceWhiteAdjustmentDampingAbs => (FloatName)"@CameraDevice/BalanceWhiteAdjustmentDampingAbs";

	public static IntegerName GrayValueAdjustmentDampingRaw => (IntegerName)"@CameraDevice/GrayValueAdjustmentDampingRaw";

	public static FloatName GrayValueAdjustmentDampingAbs => (FloatName)"@CameraDevice/GrayValueAdjustmentDampingAbs";

	public static IntegerName AutoTargetValue => (IntegerName)"@CameraDevice/AutoTargetValue";

	public static DefaultSetSelectorEnum DefaultSetSelector => new DefaultSetSelectorEnum();

	public static UserSetDefaultSelectorEnum UserSetDefaultSelector => new UserSetDefaultSelectorEnum();

	public static CommandName UserSetSave => (CommandName)"@CameraDevice/UserSetSave";

	public static CommandName UserSetLoad => (CommandName)"@CameraDevice/UserSetLoad";

	public static UserSetSelectorEnum UserSetSelector => new UserSetSelectorEnum();

	public static CommandName DeviceRegistersStreamingEnd => (CommandName)"@CameraDevice/DeviceRegistersStreamingEnd";

	public static CommandName DeviceRegistersStreamingStart => (CommandName)"@CameraDevice/DeviceRegistersStreamingStart";

	public static IntegerName ActionGroupMask => (IntegerName)"@CameraDevice/ActionGroupMask";

	public static IntegerName ActionGroupKey => (IntegerName)"@CameraDevice/ActionGroupKey";

	public static IntegerName ActionSelector => (IntegerName)"@CameraDevice/ActionSelector";

	public static IntegerName ActionDeviceKey => (IntegerName)"@CameraDevice/ActionDeviceKey";

	public static IntegerName ActionCommandCount => (IntegerName)"@CameraDevice/ActionCommandCount";

	public static IntegerName NumberOfActionSignals => (IntegerName)"@CameraDevice/NumberOfActionSignals";

	public static IntegerName GevPTPDiagnosticsQueueSendNumFailure => (IntegerName)"@CameraDevice/GevPTPDiagnosticsQueueSendNumFailure";

	public static IntegerName GevPTPDiagnosticsQueueRxGnrlPushNumFailure => (IntegerName)"@CameraDevice/GevPTPDiagnosticsQueueRxGnrlPushNumFailure";

	public static IntegerName GevPTPDiagnosticsQueueRxEvntPushNumFailure => (IntegerName)"@CameraDevice/GevPTPDiagnosticsQueueRxEvntPushNumFailure";

	public static IntegerName GevPTPDiagnosticsQueueRxGnrlMaxNumElements => (IntegerName)"@CameraDevice/GevPTPDiagnosticsQueueRxGnrlMaxNumElements";

	public static IntegerName GevPTPDiagnosticsQueueRxEvntMaxNumElements => (IntegerName)"@CameraDevice/GevPTPDiagnosticsQueueRxEvntMaxNumElements";

	public static IntegerName GevIEEE1588ParentClockId => (IntegerName)"@CameraDevice/GevIEEE1588ParentClockId";

	public static IntegerName GevIEEE1588ParentClockIdHigh => (IntegerName)"@CameraDevice/GevIEEE1588ParentClockIdHigh";

	public static IntegerName GevIEEE1588ParentClockIdLow => (IntegerName)"@CameraDevice/GevIEEE1588ParentClockIdLow";

	public static IntegerName GevIEEE1588ClockId => (IntegerName)"@CameraDevice/GevIEEE1588ClockId";

	public static IntegerName GevIEEE1588ClockIdHigh => (IntegerName)"@CameraDevice/GevIEEE1588ClockIdHigh";

	public static IntegerName GevIEEE1588ClockIdLow => (IntegerName)"@CameraDevice/GevIEEE1588ClockIdLow";

	public static IntegerName GevIEEE1588OffsetFromMaster => (IntegerName)"@CameraDevice/GevIEEE1588OffsetFromMaster";

	public static GevIEEE1588StatusLatchedEnum GevIEEE1588StatusLatched => new GevIEEE1588StatusLatchedEnum();

	public static CommandName GevIEEE1588DataSetLatch => (CommandName)"@CameraDevice/GevIEEE1588DataSetLatch";

	public static GevIEEE1588StatusEnum GevIEEE1588Status => new GevIEEE1588StatusEnum();

	public static BooleanName GevIEEE1588 => (BooleanName)"@CameraDevice/GevIEEE1588";

	public static BooleanName PixelFormatLegacy => (BooleanName)"@CameraDevice/PixelFormatLegacy";

	public static IntegerName TLParamsLocked => (IntegerName)"@CameraDevice/TLParamsLocked";

	public static BooleanName GevSCPSBigEndian => (BooleanName)"@CameraDevice/GevSCPSBigEndian";

	public static BooleanName GevSCPSDoNotFragment => (BooleanName)"@CameraDevice/GevSCPSDoNotFragment";

	public static CommandName GevSCPSFireTestPacket => (CommandName)"@CameraDevice/GevSCPSFireTestPacket";

	public static IntegerName GevSCPHostPort => (IntegerName)"@CameraDevice/GevSCPHostPort";

	public static IntegerName GevSCDA => (IntegerName)"@CameraDevice/GevSCDA";

	public static IntegerName GevSCPInterfaceIndex => (IntegerName)"@CameraDevice/GevSCPInterfaceIndex";

	public static GevStreamChannelSelectorEnum GevStreamChannelSelector => new GevStreamChannelSelectorEnum();

	public static GevCCPEnum GevCCP => new GevCCPEnum();

	public static IntegerName GevTimestampValue => (IntegerName)"@CameraDevice/GevTimestampValue";

	public static CommandName GevTimestampControlLatchReset => (CommandName)"@CameraDevice/GevTimestampControlLatchReset";

	public static CommandName GevTimestampControlReset => (CommandName)"@CameraDevice/GevTimestampControlReset";

	public static CommandName GevTimestampControlLatch => (CommandName)"@CameraDevice/GevTimestampControlLatch";

	public static IntegerName GevTimestampTickFrequency => (IntegerName)"@CameraDevice/GevTimestampTickFrequency";

	public static IntegerName GevHeartbeatTimeout => (IntegerName)"@CameraDevice/GevHeartbeatTimeout";

	public static BooleanName GevSupportedOptionalCommandsConcatenation => (BooleanName)"@CameraDevice/GevSupportedOptionalCommandsConcatenation";

	public static BooleanName GevSupportedOptionalCommandsWRITEMEM => (BooleanName)"@CameraDevice/GevSupportedOptionalCommandsWRITEMEM";

	public static BooleanName GevSupportedOptionalCommandsPACKETRESEND => (BooleanName)"@CameraDevice/GevSupportedOptionalCommandsPACKETRESEND";

	public static BooleanName GevSupportedOptionalCommandsEVENT => (BooleanName)"@CameraDevice/GevSupportedOptionalCommandsEVENT";

	public static BooleanName GevSupportedOptionalCommandsEVENTDATA => (BooleanName)"@CameraDevice/GevSupportedOptionalCommandsEVENTDATA";

	public static BooleanName GevSupportedIEEE1588 => (BooleanName)"@CameraDevice/GevSupportedIEEE1588";

	public static BooleanName GevSupportedOptionalLegacy16BitBlockID => (BooleanName)"@CameraDevice/GevSupportedOptionalLegacy16BitBlockID";

	public static IntegerName GevStreamChannelCount => (IntegerName)"@CameraDevice/GevStreamChannelCount";

	public static IntegerName GevMessageChannelCount => (IntegerName)"@CameraDevice/GevMessageChannelCount";

	public static IntegerName GevNumberOfInterfaces => (IntegerName)"@CameraDevice/GevNumberOfInterfaces";

	public static StringName GevSecondURL => (StringName)"@CameraDevice/GevSecondURL";

	public static StringName GevFirstURL => (StringName)"@CameraDevice/GevFirstURL";

	public static BooleanName GevLinkCrossover => (BooleanName)"@CameraDevice/GevLinkCrossover";

	public static BooleanName GevLinkFullDuplex => (BooleanName)"@CameraDevice/GevLinkFullDuplex";

	public static BooleanName GevLinkMaster => (BooleanName)"@CameraDevice/GevLinkMaster";

	public static IntegerName GevLinkSpeed => (IntegerName)"@CameraDevice/GevLinkSpeed";

	public static IntegerName GevPersistentDefaultGateway => (IntegerName)"@CameraDevice/GevPersistentDefaultGateway";

	public static IntegerName GevPersistentSubnetMask => (IntegerName)"@CameraDevice/GevPersistentSubnetMask";

	public static IntegerName GevPersistentIPAddress => (IntegerName)"@CameraDevice/GevPersistentIPAddress";

	public static IntegerName GevCurrentDefaultGateway => (IntegerName)"@CameraDevice/GevCurrentDefaultGateway";

	public static IntegerName GevCurrentSubnetMask => (IntegerName)"@CameraDevice/GevCurrentSubnetMask";

	public static IntegerName GevCurrentIPAddress => (IntegerName)"@CameraDevice/GevCurrentIPAddress";

	public static IntegerName GevCurrentIPConfiguration => (IntegerName)"@CameraDevice/GevCurrentIPConfiguration";

	public static BooleanName GevSupportedIPConfigurationPersistentIP => (BooleanName)"@CameraDevice/GevSupportedIPConfigurationPersistentIP";

	public static BooleanName GevSupportedIPConfigurationDHCP => (BooleanName)"@CameraDevice/GevSupportedIPConfigurationDHCP";

	public static BooleanName GevSupportedIPConfigurationLLA => (BooleanName)"@CameraDevice/GevSupportedIPConfigurationLLA";

	public static GevGVSPExtendedIDModeEnum GevGVSPExtendedIDMode => new GevGVSPExtendedIDModeEnum();

	public static IntegerName GevMACAddress => (IntegerName)"@CameraDevice/GevMACAddress";

	public static GevInterfaceSelectorEnum GevInterfaceSelector => new GevInterfaceSelectorEnum();

	public static IntegerName GevDeviceModeCharacterSet => (IntegerName)"@CameraDevice/GevDeviceModeCharacterSet";

	public static BooleanName GevDeviceModeIsBigEndian => (BooleanName)"@CameraDevice/GevDeviceModeIsBigEndian";

	public static IntegerName GevVersionMinor => (IntegerName)"@CameraDevice/GevVersionMinor";

	public static IntegerName GevVersionMajor => (IntegerName)"@CameraDevice/GevVersionMajor";

	public static IntegerName GevSCFJM => (IntegerName)"@CameraDevice/GevSCFJM";

	public static IntegerName GevSCDCT => (IntegerName)"@CameraDevice/GevSCDCT";

	public static IntegerName GevSCDMT => (IntegerName)"@CameraDevice/GevSCDMT";

	public static IntegerName GevSCBWA => (IntegerName)"@CameraDevice/GevSCBWA";

	public static IntegerName GevSCBWRA => (IntegerName)"@CameraDevice/GevSCBWRA";

	public static IntegerName GevSCBWR => (IntegerName)"@CameraDevice/GevSCBWR";

	public static IntegerName GevSCFTD => (IntegerName)"@CameraDevice/GevSCFTD";

	public static IntegerName GevSCPD => (IntegerName)"@CameraDevice/GevSCPD";

	public static IntegerName GevSCPSPacketSize => (IntegerName)"@CameraDevice/GevSCPSPacketSize";

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

	public static BooleanName FrequencyConverterPreventOvertrigger => (BooleanName)"@CameraDevice/FrequencyConverterPreventOvertrigger";

	public static IntegerName FrequencyConverterPostDivider => (IntegerName)"@CameraDevice/FrequencyConverterPostDivider";

	public static IntegerName FrequencyConverterMultiplier => (IntegerName)"@CameraDevice/FrequencyConverterMultiplier";

	public static IntegerName FrequencyConverterPreDivider => (IntegerName)"@CameraDevice/FrequencyConverterPreDivider";

	public static FrequencyConverterSignalAlignmentEnum FrequencyConverterSignalAlignment => new FrequencyConverterSignalAlignmentEnum();

	public static FrequencyConverterInputSourceEnum FrequencyConverterInputSource => new FrequencyConverterInputSourceEnum();

	public static CommandName ShaftEncoderModuleReverseCounterReset => (CommandName)"@CameraDevice/ShaftEncoderModuleReverseCounterReset";

	public static IntegerName ShaftEncoderModuleReverseCounterMax => (IntegerName)"@CameraDevice/ShaftEncoderModuleReverseCounterMax";

	public static CommandName ShaftEncoderModuleCounterReset => (CommandName)"@CameraDevice/ShaftEncoderModuleCounterReset";

	public static IntegerName ShaftEncoderModuleCounterMax => (IntegerName)"@CameraDevice/ShaftEncoderModuleCounterMax";

	public static IntegerName ShaftEncoderModuleCounter => (IntegerName)"@CameraDevice/ShaftEncoderModuleCounter";

	public static ShaftEncoderModuleCounterModeEnum ShaftEncoderModuleCounterMode => new ShaftEncoderModuleCounterModeEnum();

	public static ShaftEncoderModuleModeEnum ShaftEncoderModuleMode => new ShaftEncoderModuleModeEnum();

	public static ShaftEncoderModuleLineSourceEnum ShaftEncoderModuleLineSource => new ShaftEncoderModuleLineSourceEnum();

	public static ShaftEncoderModuleLineSelectorEnum ShaftEncoderModuleLineSelector => new ShaftEncoderModuleLineSelectorEnum();

	public static VInpSignalReadoutActivationEnum VInpSignalReadoutActivation => new VInpSignalReadoutActivationEnum();

	public static IntegerName VInpSamplingPoint => (IntegerName)"@CameraDevice/VInpSamplingPoint";

	public static IntegerName VInpBitLength => (IntegerName)"@CameraDevice/VInpBitLength";

	public static VInpSignalSourceEnum VInpSignalSource => new VInpSignalSourceEnum();

	public static IntegerName SyncUserOutputValueAll => (IntegerName)"@CameraDevice/SyncUserOutputValueAll";

	public static BooleanName SyncUserOutputValue => (BooleanName)"@CameraDevice/SyncUserOutputValue";

	public static SyncUserOutputSelectorEnum SyncUserOutputSelector => new SyncUserOutputSelectorEnum();

	public static IntegerName UserOutputValueAllMask => (IntegerName)"@CameraDevice/UserOutputValueAllMask";

	public static IntegerName UserOutputValueAll => (IntegerName)"@CameraDevice/UserOutputValueAll";

	public static BooleanName UserOutputValue => (BooleanName)"@CameraDevice/UserOutputValue";

	public static UserOutputSelectorEnum UserOutputSelector => new UserOutputSelectorEnum();

	public static IntegerName LineStatusAll => (IntegerName)"@CameraDevice/LineStatusAll";

	public static BooleanName LineStatus => (BooleanName)"@CameraDevice/LineStatus";

	public static FloatName MinOutPulseWidthAbs => (FloatName)"@CameraDevice/MinOutPulseWidthAbs";

	public static IntegerName MinOutPulseWidthRaw => (IntegerName)"@CameraDevice/MinOutPulseWidthRaw";

	public static IntegerName LineDebouncerTimeRaw => (IntegerName)"@CameraDevice/LineDebouncerTimeRaw";

	public static FloatName LineDebouncerTimeAbs => (FloatName)"@CameraDevice/LineDebouncerTimeAbs";

	public static BooleanName LineTermination => (BooleanName)"@CameraDevice/LineTermination";

	public static BooleanName LineInverter => (BooleanName)"@CameraDevice/LineInverter";

	public static LineSourceEnum LineSource => new LineSourceEnum();

	public static LineFormatEnum LineFormat => new LineFormatEnum();

	public static LineLogicEnum LineLogic => new LineLogicEnum();

	public static LineModeEnum LineMode => new LineModeEnum();

	public static LineSelectorEnum LineSelector => new LineSelectorEnum();

	public static CommandName SyncFreeRunTimerUpdate => (CommandName)"@CameraDevice/SyncFreeRunTimerUpdate";

	public static FloatName SyncFreeRunTimerTriggerRateAbs => (FloatName)"@CameraDevice/SyncFreeRunTimerTriggerRateAbs";

	public static IntegerName SyncFreeRunTimerStartTimeHigh => (IntegerName)"@CameraDevice/SyncFreeRunTimerStartTimeHigh";

	public static IntegerName SyncFreeRunTimerStartTimeLow => (IntegerName)"@CameraDevice/SyncFreeRunTimerStartTimeLow";

	public static BooleanName SyncFreeRunTimerEnable => (BooleanName)"@CameraDevice/SyncFreeRunTimerEnable";

	public static FloatName FrameTimeoutAbs => (FloatName)"@CameraDevice/FrameTimeoutAbs";

	public static BooleanName FrameTimeoutEnable => (BooleanName)"@CameraDevice/FrameTimeoutEnable";

	public static BooleanName AcquisitionStatus => (BooleanName)"@CameraDevice/AcquisitionStatus";

	public static AcquisitionStatusSelectorEnum AcquisitionStatusSelector => new AcquisitionStatusSelectorEnum();

	public static FloatName ResultingFrameRateAbs => (FloatName)"@CameraDevice/ResultingFrameRateAbs";

	public static FloatName ResultingFramePeriodAbs => (FloatName)"@CameraDevice/ResultingFramePeriodAbs";

	public static FloatName AcquisitionFrameRateAbs => (FloatName)"@CameraDevice/AcquisitionFrameRateAbs";

	public static BooleanName AcquisitionFrameRateEnable => (BooleanName)"@CameraDevice/AcquisitionFrameRateEnable";

	public static FloatName ResultingLineRateAbs => (FloatName)"@CameraDevice/ResultingLineRateAbs";

	public static FloatName ResultingLinePeriodAbs => (FloatName)"@CameraDevice/ResultingLinePeriodAbs";

	public static FloatName AcquisitionLineRateAbs => (FloatName)"@CameraDevice/AcquisitionLineRateAbs";

	public static SensorReadoutModeEnum SensorReadoutMode => new SensorReadoutModeEnum();

	public static ShutterModeEnum ShutterMode => new ShutterModeEnum();

	public static BooleanName GlobalResetReleaseModeEnable => (BooleanName)"@CameraDevice/GlobalResetReleaseModeEnable";

	public static IntegerName ExposureOverlapTimeMaxRaw => (IntegerName)"@CameraDevice/ExposureOverlapTimeMaxRaw";

	public static FloatName ExposureOverlapTimeMaxAbs => (FloatName)"@CameraDevice/ExposureOverlapTimeMaxAbs";

	public static ExposureOverlapTimeModeEnum ExposureOverlapTimeMode => new ExposureOverlapTimeModeEnum();

	public static FloatName ReadoutTimeAbs => (FloatName)"@CameraDevice/ReadoutTimeAbs";

	public static IntegerName ExposureTimeRaw => (IntegerName)"@CameraDevice/ExposureTimeRaw";

	public static BooleanName ExposureTimeBaseAbsEnable => (BooleanName)"@CameraDevice/ExposureTimeBaseAbsEnable";

	public static FloatName ExposureTimeBaseAbs => (FloatName)"@CameraDevice/ExposureTimeBaseAbs";

	public static FloatName ExposureTimeAbs => (FloatName)"@CameraDevice/ExposureTimeAbs";

	public static ExposureTimeModeEnum ExposureTimeMode => new ExposureTimeModeEnum();

	public static ExposureAutoEnum ExposureAuto => new ExposureAutoEnum();

	public static InterlacedIntegrationModeEnum InterlacedIntegrationMode => new InterlacedIntegrationModeEnum();

	public static ExposureModeEnum ExposureMode => new ExposureModeEnum();

	public static IntegerName ExposureStartDelayRaw => (IntegerName)"@CameraDevice/ExposureStartDelayRaw";

	public static FloatName ExposureStartDelayAbs => (FloatName)"@CameraDevice/ExposureStartDelayAbs";

	public static IntegerName TriggerDelayLineTriggerCount => (IntegerName)"@CameraDevice/TriggerDelayLineTriggerCount";

	public static FloatName TriggerDelayAbs => (FloatName)"@CameraDevice/TriggerDelayAbs";

	public static TriggerDelaySourceEnum TriggerDelaySource => new TriggerDelaySourceEnum();

	public static BooleanName TriggerPartialClosingFrame => (BooleanName)"@CameraDevice/TriggerPartialClosingFrame";

	public static TriggerActivationEnum TriggerActivation => new TriggerActivationEnum();

	public static TriggerSourceEnum TriggerSource => new TriggerSourceEnum();

	public static CommandName TriggerSoftware => (CommandName)"@CameraDevice/TriggerSoftware";

	public static TriggerModeEnum TriggerMode => new TriggerModeEnum();

	public static TriggerSelectorEnum TriggerSelector => new TriggerSelectorEnum();

	public static TriggerControlImplementationEnum TriggerControlImplementation => new TriggerControlImplementationEnum();

	public static IntegerName AcquisitionFrameCount => (IntegerName)"@CameraDevice/AcquisitionFrameCount";

	public static CommandName AcquisitionAbort => (CommandName)"@CameraDevice/AcquisitionAbort";

	public static CommandName AcquisitionStop => (CommandName)"@CameraDevice/AcquisitionStop";

	public static CommandName AcquisitionStart => (CommandName)"@CameraDevice/AcquisitionStart";

	public static AcquisitionModeEnum AcquisitionMode => new AcquisitionModeEnum();

	public static BooleanName EnableBurstAcquisition => (BooleanName)"@CameraDevice/EnableBurstAcquisition";

	public static IntegerName StackedZoneImagingZoneHeight => (IntegerName)"@CameraDevice/StackedZoneImagingZoneHeight";

	public static IntegerName StackedZoneImagingZoneOffsetY => (IntegerName)"@CameraDevice/StackedZoneImagingZoneOffsetY";

	public static BooleanName StackedZoneImagingZoneEnable => (BooleanName)"@CameraDevice/StackedZoneImagingZoneEnable";

	public static IntegerName StackedZoneImagingIndex => (IntegerName)"@CameraDevice/StackedZoneImagingIndex";

	public static BooleanName StackedZoneImagingEnable => (BooleanName)"@CameraDevice/StackedZoneImagingEnable";

	public static IntegerName ROIZoneOffset => (IntegerName)"@CameraDevice/ROIZoneOffset";

	public static IntegerName ROIZoneSize => (IntegerName)"@CameraDevice/ROIZoneSize";

	public static ROIZoneModeEnum ROIZoneMode => new ROIZoneModeEnum();

	public static ROIZoneSelectorEnum ROIZoneSelector => new ROIZoneSelectorEnum();

	public static FloatName ScalingVerticalAbs => (FloatName)"@CameraDevice/ScalingVerticalAbs";

	public static FloatName ScalingHorizontalAbs => (FloatName)"@CameraDevice/ScalingHorizontalAbs";

	public static IntegerName DecimationVertical => (IntegerName)"@CameraDevice/DecimationVertical";

	public static IntegerName DecimationHorizontal => (IntegerName)"@CameraDevice/DecimationHorizontal";

	public static IntegerName BinningVertical => (IntegerName)"@CameraDevice/BinningVertical";

	public static BinningModeVerticalEnum BinningModeVertical => new BinningModeVerticalEnum();

	public static BinningVerticalModeEnum BinningVerticalMode => new BinningVerticalModeEnum();

	public static IntegerName BinningHorizontal => (IntegerName)"@CameraDevice/BinningHorizontal";

	public static BinningModeHorizontalEnum BinningModeHorizontal => new BinningModeHorizontalEnum();

	public static BinningHorizontalModeEnum BinningHorizontalMode => new BinningHorizontalModeEnum();

	public static LegacyBinningVerticalEnum LegacyBinningVertical => new LegacyBinningVerticalEnum();

	public static BooleanName CenterY => (BooleanName)"@CameraDevice/CenterY";

	public static BooleanName CenterX => (BooleanName)"@CameraDevice/CenterX";

	public static IntegerName OffsetY => (IntegerName)"@CameraDevice/OffsetY";

	public static IntegerName OffsetX => (IntegerName)"@CameraDevice/OffsetX";

	public static IntegerName Height => (IntegerName)"@CameraDevice/Height";

	public static IntegerName Width => (IntegerName)"@CameraDevice/Width";

	public static IntegerName TonalRangeTargetDark => (IntegerName)"@CameraDevice/TonalRangeTargetDark";

	public static IntegerName TonalRangeTargetBright => (IntegerName)"@CameraDevice/TonalRangeTargetBright";

	public static IntegerName TonalRangeSourceDark => (IntegerName)"@CameraDevice/TonalRangeSourceDark";

	public static IntegerName TonalRangeSourceBright => (IntegerName)"@CameraDevice/TonalRangeSourceBright";

	public static TonalRangeSelectorEnum TonalRangeSelector => new TonalRangeSelectorEnum();

	public static TonalRangeAutoEnum TonalRangeAuto => new TonalRangeAutoEnum();

	public static TonalRangeEnableEnum TonalRangeEnable => new TonalRangeEnableEnum();

	public static IntegerName SharpnessEnhancementRaw => (IntegerName)"@CameraDevice/SharpnessEnhancementRaw";

	public static FloatName SharpnessEnhancementAbs => (FloatName)"@CameraDevice/SharpnessEnhancementAbs";

	public static IntegerName NoiseReductionRaw => (IntegerName)"@CameraDevice/NoiseReductionRaw";

	public static FloatName NoiseReductionAbs => (FloatName)"@CameraDevice/NoiseReductionAbs";

	public static PgiModeEnum PgiMode => new PgiModeEnum();

	public static DemosaicingModeEnum DemosaicingMode => new DemosaicingModeEnum();

	public static BslContrastModeEnum BslContrastMode => new BslContrastModeEnum();

	public static IntegerName BslContrastRaw => (IntegerName)"@CameraDevice/BslContrastRaw";

	public static FloatName BslContrast => (FloatName)"@CameraDevice/BslContrast";

	public static IntegerName BslBrightnessRaw => (IntegerName)"@CameraDevice/BslBrightnessRaw";

	public static FloatName BslBrightness => (FloatName)"@CameraDevice/BslBrightness";

	public static IntegerName BslSaturationRaw => (IntegerName)"@CameraDevice/BslSaturationRaw";

	public static FloatName BslSaturation => (FloatName)"@CameraDevice/BslSaturation";

	public static IntegerName BslHueRaw => (IntegerName)"@CameraDevice/BslHueRaw";

	public static FloatName BslHue => (FloatName)"@CameraDevice/BslHue";

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

	public static BooleanName TestImageResetAndHold => (BooleanName)"@CameraDevice/TestImageResetAndHold";

	public static TestImageSelectorEnum TestImageSelector => new TestImageSelectorEnum();

	public static FieldOutputModeEnum FieldOutputMode => new FieldOutputModeEnum();

	public static BooleanName ReverseY => (BooleanName)"@CameraDevice/ReverseY";

	public static BooleanName ReverseX => (BooleanName)"@CameraDevice/ReverseX";

	public static SpatialCorrectionStartingLineEnum SpatialCorrectionStartingLine => new SpatialCorrectionStartingLineEnum();

	public static IntegerName SpatialCorrectionAmount => (IntegerName)"@CameraDevice/SpatialCorrectionAmount";

	public static IntegerName SpatialCorrection => (IntegerName)"@CameraDevice/SpatialCorrection";

	public static IntegerName PixelDynamicRangeMax => (IntegerName)"@CameraDevice/PixelDynamicRangeMax";

	public static IntegerName PixelDynamicRangeMin => (IntegerName)"@CameraDevice/PixelDynamicRangeMin";

	public static BooleanName ProcessedRawEnable => (BooleanName)"@CameraDevice/ProcessedRawEnable";

	public static PixelColorFilterEnum PixelColorFilter => new PixelColorFilterEnum();

	public static PixelSizeEnum PixelSize => new PixelSizeEnum();

	public static PixelCodingEnum PixelCoding => new PixelCodingEnum();

	public static PixelFormatEnum PixelFormat => new PixelFormatEnum();

	public static SensorDigitizationTapsEnum SensorDigitizationTaps => new SensorDigitizationTapsEnum();

	public static SensorBitDepthEnum SensorBitDepth => new SensorBitDepthEnum();

	public static IntegerName SubstrateVoltage => (IntegerName)"@CameraDevice/SubstrateVoltage";

	public static IntegerName DigitalShift => (IntegerName)"@CameraDevice/DigitalShift";

	public static FloatName Gamma => (FloatName)"@CameraDevice/Gamma";

	public static GammaSelectorEnum GammaSelector => new GammaSelectorEnum();

	public static BooleanName GammaEnable => (BooleanName)"@CameraDevice/GammaEnable";

	public static FloatName BlackLevelAbs => (FloatName)"@CameraDevice/BlackLevelAbs";

	public static IntegerName BlackLevelRaw => (IntegerName)"@CameraDevice/BlackLevelRaw";

	public static BlackLevelSelectorEnum BlackLevelSelector => new BlackLevelSelectorEnum();

	public static FloatName GainAbs => (FloatName)"@CameraDevice/GainAbs";

	public static IntegerName GainRaw => (IntegerName)"@CameraDevice/GainRaw";

	public static GainSelectorEnum GainSelector => new GainSelectorEnum();

	public static GainAutoEnum GainAuto => new GainAutoEnum();

	public static SequenceAddressBitSourceEnum SequenceAddressBitSource => new SequenceAddressBitSourceEnum();

	public static SequenceAddressBitSelectorEnum SequenceAddressBitSelector => new SequenceAddressBitSelectorEnum();

	public static SequenceControlSourceEnum SequenceControlSource => new SequenceControlSourceEnum();

	public static SequenceControlSelectorEnum SequenceControlSelector => new SequenceControlSelectorEnum();

	public static SequenceAdvanceModeEnum SequenceAdvanceMode => new SequenceAdvanceModeEnum();

	public static IntegerName SequenceSetExecutions => (IntegerName)"@CameraDevice/SequenceSetExecutions";

	public static CommandName SequenceSetLoad => (CommandName)"@CameraDevice/SequenceSetLoad";

	public static CommandName SequenceSetStore => (CommandName)"@CameraDevice/SequenceSetStore";

	public static IntegerName SequenceSetIndex => (IntegerName)"@CameraDevice/SequenceSetIndex";

	public static IntegerName SequenceSetTotalNumber => (IntegerName)"@CameraDevice/SequenceSetTotalNumber";

	public static CommandName SequenceAsyncAdvance => (CommandName)"@CameraDevice/SequenceAsyncAdvance";

	public static CommandName SequenceAsyncRestart => (CommandName)"@CameraDevice/SequenceAsyncRestart";

	public static SequenceConfigurationModeEnum SequenceConfigurationMode => new SequenceConfigurationModeEnum();

	public static IntegerName SequenceCurrentSet => (IntegerName)"@CameraDevice/SequenceCurrentSet";

	public static BooleanName SequenceEnable => (BooleanName)"@CameraDevice/SequenceEnable";
}
