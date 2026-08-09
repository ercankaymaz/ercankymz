using System.ComponentModel;

namespace Basler.Pylon;

public static class PLGigEChunkData
{
	[EditorBrowsable(EditorBrowsableState.Never)]
	public class ChunkPixelFormatEnum : ParameterListEnum
	{
		public override string Name => "@ChunkData/ChunkPixelFormat";

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

	public static IntegerName ChunkLineTriggerCounter => (IntegerName)"@ChunkData/ChunkLineTriggerCounter";

	public static IntegerName ChunkGainAll => (IntegerName)"@ChunkData/ChunkGainAll";

	public static IntegerName ChunkPayloadCRC16 => (IntegerName)"@ChunkData/ChunkPayloadCRC16";

	public static FloatName ChunkExposureTime => (FloatName)"@ChunkData/ChunkExposureTime";

	public static IntegerName ChunkShaftEncoderCounter => (IntegerName)"@ChunkData/ChunkShaftEncoderCounter";

	public static IntegerName ChunkInputStatusAtLineTriggerValue => (IntegerName)"@ChunkData/ChunkInputStatusAtLineTriggerValue";

	public static IntegerName ChunkInputStatusAtLineTriggerIndex => (IntegerName)"@ChunkData/ChunkInputStatusAtLineTriggerIndex";

	public static IntegerName ChunkInputStatusAtLineTriggerBitsPerLine => (IntegerName)"@ChunkData/ChunkInputStatusAtLineTriggerBitsPerLine";

	public static IntegerName ChunkLineTriggerEndToEndCounter => (IntegerName)"@ChunkData/ChunkLineTriggerEndToEndCounter";

	public static IntegerName ChunkFramesPerTriggerCounter => (IntegerName)"@ChunkData/ChunkFramesPerTriggerCounter";

	public static IntegerName ChunkFrameTriggerCounter => (IntegerName)"@ChunkData/ChunkFrameTriggerCounter";

	public static IntegerName ChunkFrameTriggerIgnoredCounter => (IntegerName)"@ChunkData/ChunkFrameTriggerIgnoredCounter";

	public static IntegerName ChunkLineTriggerIgnoredCounter => (IntegerName)"@ChunkData/ChunkLineTriggerIgnoredCounter";

	public static IntegerName ChunkTriggerinputcounter => (IntegerName)"@ChunkData/ChunkTriggerinputcounter";

	public static IntegerName ChunkVirtLineStatusAll => (IntegerName)"@ChunkData/ChunkVirtLineStatusAll";

	public static IntegerName ChunkLineStatusAll => (IntegerName)"@ChunkData/ChunkLineStatusAll";

	public static IntegerName ChunkFramecounter => (IntegerName)"@ChunkData/ChunkFramecounter";

	public static IntegerName ChunkTimestamp => (IntegerName)"@ChunkData/ChunkTimestamp";

	public static ChunkPixelFormatEnum ChunkPixelFormat => new ChunkPixelFormatEnum();

	public static IntegerName ChunkDynamicRangeMax => (IntegerName)"@ChunkData/ChunkDynamicRangeMax";

	public static IntegerName ChunkDynamicRangeMin => (IntegerName)"@ChunkData/ChunkDynamicRangeMin";

	public static IntegerName ChunkHeight => (IntegerName)"@ChunkData/ChunkHeight";

	public static IntegerName ChunkWidth => (IntegerName)"@ChunkData/ChunkWidth";

	public static IntegerName ChunkOffsetY => (IntegerName)"@ChunkData/ChunkOffsetY";

	public static IntegerName ChunkOffsetX => (IntegerName)"@ChunkData/ChunkOffsetX";

	public static IntegerName ChunkSequenceSetIndex => (IntegerName)"@ChunkData/ChunkSequenceSetIndex";

	public static IntegerName ChunkStride => (IntegerName)"@ChunkData/ChunkStride";
}
