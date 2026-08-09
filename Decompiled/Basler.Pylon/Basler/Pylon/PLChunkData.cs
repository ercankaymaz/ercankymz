using System.ComponentModel;

namespace Basler.Pylon;

public static class PLChunkData
{
	[EditorBrowsable(EditorBrowsableState.Never)]
	public class BslChunkAutoBrightnessStatusEnum : ParameterListEnum
	{
		public override string Name => "@ChunkData/BslChunkAutoBrightnessStatus";

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
		public override string Name => "@ChunkData/BslChunkTimestampSelector";

		public string FrameStart => "FrameStart";

		public string ExposureStart => "ExposureStart";

		public string ExposureEnd => "ExposureEnd";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class ChunkCounterSelectorEnum : ParameterListEnum
	{
		public override string Name => "@ChunkData/ChunkCounterSelector";

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
		public override string Name => "@ChunkData/ChunkGainSelector";

		public string All => "All";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class ChunkPixelFormatEnum : ParameterListEnum
	{
		public override string Name => "@ChunkData/ChunkPixelFormat";

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

	private static BslChunkAutoBrightnessStatusEnum m_BslChunkAutoBrightnessStatusCached = null;

	private static BslChunkTimestampSelectorEnum m_BslChunkTimestampSelectorCached = null;

	private static ChunkCounterSelectorEnum m_ChunkCounterSelectorCached = null;

	private static ChunkGainSelectorEnum m_ChunkGainSelectorCached = null;

	private static ChunkPixelFormatEnum m_ChunkPixelFormatCached = null;

	public static IntegerName ChunkWidth => new IntegerName("@ChunkData/ChunkWidth");

	public static IntegerName ChunkVirtLineStatusAll => new IntegerName("@ChunkData/ChunkVirtLineStatusAll");

	public static IntegerName ChunkTriggerinputcounter => new IntegerName("@ChunkData/ChunkTriggerinputcounter");

	public static IntegerName ChunkTimestamp => new IntegerName("@ChunkData/ChunkTimestamp");

	public static IntegerName ChunkStride => new IntegerName("@ChunkData/ChunkStride");

	public static IntegerName ChunkShaftEncoderCounter => new IntegerName("@ChunkData/ChunkShaftEncoderCounter");

	public static IntegerName ChunkSequencerSetActive => new IntegerName("@ChunkData/ChunkSequencerSetActive");

	public static IntegerName ChunkSequenceSetIndex => new IntegerName("@ChunkData/ChunkSequenceSetIndex");

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

	public static IntegerName ChunkPixelDynamicRangeMin => new IntegerName("@ChunkData/ChunkPixelDynamicRangeMin");

	public static IntegerName ChunkPixelDynamicRangeMax => new IntegerName("@ChunkData/ChunkPixelDynamicRangeMax");

	public static IntegerName ChunkPayloadCRC16 => new IntegerName("@ChunkData/ChunkPayloadCRC16");

	public static IntegerName ChunkOffsetY => new IntegerName("@ChunkData/ChunkOffsetY");

	public static IntegerName ChunkOffsetX => new IntegerName("@ChunkData/ChunkOffsetX");

	public static IntegerName ChunkLineTriggerIgnoredCounter => new IntegerName("@ChunkData/ChunkLineTriggerIgnoredCounter");

	public static IntegerName ChunkLineTriggerEndToEndCounter => new IntegerName("@ChunkData/ChunkLineTriggerEndToEndCounter");

	public static IntegerName ChunkLineTriggerCounter => new IntegerName("@ChunkData/ChunkLineTriggerCounter");

	public static IntegerName ChunkLineStatusAll => new IntegerName("@ChunkData/ChunkLineStatusAll");

	public static IntegerName ChunkInputStatusAtLineTriggerValue => new IntegerName("@ChunkData/ChunkInputStatusAtLineTriggerValue");

	public static IntegerName ChunkInputStatusAtLineTriggerIndex => new IntegerName("@ChunkData/ChunkInputStatusAtLineTriggerIndex");

	public static IntegerName ChunkInputStatusAtLineTriggerBitsPerLine => new IntegerName("@ChunkData/ChunkInputStatusAtLineTriggerBitsPerLine");

	public static IntegerName ChunkHeight => new IntegerName("@ChunkData/ChunkHeight");

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

	public static IntegerName ChunkGainAll => new IntegerName("@ChunkData/ChunkGainAll");

	public static FloatName ChunkGain => new FloatName("@ChunkData/ChunkGain");

	public static IntegerName ChunkFramesPerTriggerCounter => new IntegerName("@ChunkData/ChunkFramesPerTriggerCounter");

	public static IntegerName ChunkFramecounter => new IntegerName("@ChunkData/ChunkFramecounter");

	public static IntegerName ChunkFrameTriggerIgnoredCounter => new IntegerName("@ChunkData/ChunkFrameTriggerIgnoredCounter");

	public static IntegerName ChunkFrameTriggerCounter => new IntegerName("@ChunkData/ChunkFrameTriggerCounter");

	public static IntegerName ChunkFrameID => new IntegerName("@ChunkData/ChunkFrameID");

	public static FloatName ChunkExposureTime => new FloatName("@ChunkData/ChunkExposureTime");

	public static IntegerName ChunkDynamicRangeMin => new IntegerName("@ChunkData/ChunkDynamicRangeMin");

	public static IntegerName ChunkDynamicRangeMax => new IntegerName("@ChunkData/ChunkDynamicRangeMax");

	public static IntegerName ChunkCounterValue => new IntegerName("@ChunkData/ChunkCounterValue");

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

	public static IntegerName BslChunkTimestampValue => new IntegerName("@ChunkData/BslChunkTimestampValue");

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
}
