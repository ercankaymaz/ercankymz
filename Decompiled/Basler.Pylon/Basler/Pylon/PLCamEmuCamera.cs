using System.ComponentModel;

namespace Basler.Pylon;

public static class PLCamEmuCamera
{
	[EditorBrowsable(EditorBrowsableState.Never)]
	public class AcquisitionModeEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/AcquisitionMode";

		public string SingleFrame => "SingleFrame";

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

		public string FrameTriggerWait => "FrameTriggerWait";

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

		public string Sensor => "Sensor";

		public string Coreboard => "Coreboard";

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

		public string Line3 => "Line3";

		public string Line2 => "Line2";

		public string Line1 => "Line1";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class LineSourceEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/LineSource";

		public string UserOutput3 => "UserOutput3";

		public string UserOutput2 => "UserOutput2";

		public string UserOutput1 => "UserOutput1";

		public string Timer2Active => "Timer2Active";

		public string Timer1Active => "Timer1Active";

		public string Off => "Off";

		public string FrameTriggerWait => "FrameTriggerWait";

		public string FrameBurstTriggerWait => "FrameBurstTriggerWait";

		public string FrameBurstActive => "FrameBurstActive";

		public string ExposureTriggerWait => "ExposureTriggerWait";

		public string ExposureActive => "ExposureActive";

		public string Counter2Active => "Counter2Active";

		public string Counter1Active => "Counter1Active";

		public string AcquisitionActive => "AcquisitionActive";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class PixelFormatEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/PixelFormat";

		public string RGB8Packed => "RGB8Packed";

		public string RGB16Packed => "RGB16Packed";

		public string Mono8 => "Mono8";

		public string Mono16 => "Mono16";

		public string Mono12 => "Mono12";

		public string Mono10 => "Mono10";

		public string BayerRG8 => "BayerRG8";

		public string BayerRG16 => "BayerRG16";

		public string BayerRG12 => "BayerRG12";

		public string BayerRG10 => "BayerRG10";

		public string BayerGR8 => "BayerGR8";

		public string BayerGR16 => "BayerGR16";

		public string BayerGR12 => "BayerGR12";

		public string BayerGR10 => "BayerGR10";

		public string BayerGB8 => "BayerGB8";

		public string BayerGB16 => "BayerGB16";

		public string BayerGB12 => "BayerGB12";

		public string BayerGB10 => "BayerGB10";

		public string BayerBG8 => "BayerBG8";

		public string BayerBG16 => "BayerBG16";

		public string BayerBG12 => "BayerBG12";

		public string BayerBG10 => "BayerBG10";

		public string BGRA8Packed => "BGRA8Packed";

		public string BGR8Packed => "BGR8Packed";

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

		public string Bpp48 => "Bpp48";

		public string Bpp32 => "Bpp32";

		public string Bpp24 => "Bpp24";

		public string Bpp16 => "Bpp16";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class TestImageSelectorEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/TestImageSelector";

		public string Testimage2 => "Testimage2";

		public string Testimage1 => "Testimage1";

		public string Off => "Off";

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

		public string FrameStart => "FrameStart";

		public string FrameEnd => "FrameEnd";

		public string FrameBurstStart => "FrameBurstStart";

		public string FrameBurstEnd => "FrameBurstEnd";

		public string FrameBurstActive => "FrameBurstActive";

		public string FrameActive => "FrameActive";

		public string ExposureStart => "ExposureStart";

		public string ExposureEnd => "ExposureEnd";

		public string ExposureActive => "ExposureActive";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class TriggerSourceEnum : ParameterListEnum
	{
		public override string Name => "@CameraDevice/TriggerSource";

		public string Timer2End => "Timer2End";

		public string Timer2Active => "Timer2Active";

		public string Timer1End => "Timer1End";

		public string Timer1Active => "Timer1Active";

		public string SoftwareSignal3 => "SoftwareSignal3";

		public string SoftwareSignal2 => "SoftwareSignal2";

		public string SoftwareSignal1 => "SoftwareSignal1";

		public string Software => "Software";

		public string PeriodicSignal1 => "PeriodicSignal1";

		public string Line3 => "Line3";

		public string Line2 => "Line2";

		public string Line1 => "Line1";

		public string Counter2Start => "Counter2Start";

		public string Counter2End => "Counter2End";

		public string Counter2Active => "Counter2Active";

		public string Counter1Start => "Counter1Start";

		public string Counter1End => "Counter1End";

		public string Counter1Active => "Counter1Active";

		public string Action1 => "Action1";

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

		public override string ToString()
		{
			return Name;
		}
	}

	private static AcquisitionModeEnum m_AcquisitionModeCached = null;

	private static AcquisitionStatusSelectorEnum m_AcquisitionStatusSelectorCached = null;

	private static BinningHorizontalModeEnum m_BinningHorizontalModeCached = null;

	private static BinningVerticalModeEnum m_BinningVerticalModeCached = null;

	private static DeviceLinkThroughputLimitModeEnum m_DeviceLinkThroughputLimitModeCached = null;

	private static DeviceTemperatureSelectorEnum m_DeviceTemperatureSelectorCached = null;

	private static ExposureAutoEnum m_ExposureAutoCached = null;

	private static ExposureModeEnum m_ExposureModeCached = null;

	private static GainAutoEnum m_GainAutoCached = null;

	private static ImageFileModeEnum m_ImageFileModeCached = null;

	private static LineModeEnum m_LineModeCached = null;

	private static LineSelectorEnum m_LineSelectorCached = null;

	private static LineSourceEnum m_LineSourceCached = null;

	private static PixelFormatEnum m_PixelFormatCached = null;

	private static PixelSizeEnum m_PixelSizeCached = null;

	private static TestImageSelectorEnum m_TestImageSelectorCached = null;

	private static TriggerActivationEnum m_TriggerActivationCached = null;

	private static TriggerModeEnum m_TriggerModeCached = null;

	private static TriggerSelectorEnum m_TriggerSelectorCached = null;

	private static TriggerSourceEnum m_TriggerSourceCached = null;

	private static UserOutputSelectorEnum m_UserOutputSelectorCached = null;

	public static IntegerName WidthMax => new IntegerName("@CameraDevice/WidthMax");

	public static IntegerName Width => new IntegerName("@CameraDevice/Width");

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

	public static FloatName TriggerDelay => new FloatName("@CameraDevice/TriggerDelay");

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

	public static IntegerName SensorWidth => new IntegerName("@CameraDevice/SensorWidth");

	public static IntegerName SensorHeight => new IntegerName("@CameraDevice/SensorHeight");

	public static BooleanName ReverseY => new BooleanName("@CameraDevice/ReverseY");

	public static BooleanName ReverseX => new BooleanName("@CameraDevice/ReverseX");

	public static FloatName ResultingFrameRateAbs => new FloatName("@CameraDevice/ResultingFrameRateAbs");

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

	public static IntegerName PayloadSize => new IntegerName("@CameraDevice/PayloadSize");

	public static IntegerName OffsetY => new IntegerName("@CameraDevice/OffsetY");

	public static IntegerName OffsetX => new IntegerName("@CameraDevice/OffsetX");

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

	public static BooleanName LineInverter => new BooleanName("@CameraDevice/LineInverter");

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

	public static IntegerName HeightMax => new IntegerName("@CameraDevice/HeightMax");

	public static IntegerName Height => new IntegerName("@CameraDevice/Height");

	public static FloatName Gamma => new FloatName("@CameraDevice/Gamma");

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

	public static FloatName Gain => new FloatName("@CameraDevice/Gain");

	public static IntegerName ForceFailedBufferCount => new IntegerName("@CameraDevice/ForceFailedBufferCount");

	public static CommandName ForceFailedBuffer => new CommandName("@CameraDevice/ForceFailedBuffer");

	public static IntegerName ExposureTimeRaw => new IntegerName("@CameraDevice/ExposureTimeRaw");

	public static FloatName ExposureTimeBaseAbs => new FloatName("@CameraDevice/ExposureTimeBaseAbs");

	public static FloatName ExposureTimeAbs => new FloatName("@CameraDevice/ExposureTimeAbs");

	public static FloatName ExposureTime => new FloatName("@CameraDevice/ExposureTime");

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

	public static IntegerName DigitalShift => new IntegerName("@CameraDevice/DigitalShift");

	public static StringName DeviceVersion => new StringName("@CameraDevice/DeviceVersion");

	public static StringName DeviceVendorName => new StringName("@CameraDevice/DeviceVendorName");

	public static StringName DeviceUserID => new StringName("@CameraDevice/DeviceUserID");

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

	public static StringName DeviceModelName => new StringName("@CameraDevice/DeviceModelName");

	public static StringName DeviceManufacturerInfo => new StringName("@CameraDevice/DeviceManufacturerInfo");

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

	public static StringName DeviceFirmwareVersion => new StringName("@CameraDevice/DeviceFirmwareVersion");

	public static CommandName BslCenterY => new CommandName("@CameraDevice/BslCenterY");

	public static CommandName BslCenterX => new CommandName("@CameraDevice/BslCenterX");

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

	public static BooleanName AcquisitionFrameRateEnable => new BooleanName("@CameraDevice/AcquisitionFrameRateEnable");

	public static FloatName AcquisitionFrameRate => new FloatName("@CameraDevice/AcquisitionFrameRate");
}
