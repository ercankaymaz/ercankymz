using System.ComponentModel;

namespace Basler.Pylon;

public static class PLUsbChunkData
{
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

	public static IntegerName ChunkPayloadCRC16 => (IntegerName)"@ChunkData/ChunkPayloadCRC16";

	public static IntegerName ChunkSequencerSetActive => (IntegerName)"@ChunkData/ChunkSequencerSetActive";

	public static IntegerName ChunkCounterValue => (IntegerName)"@ChunkData/ChunkCounterValue";

	public static ChunkCounterSelectorEnum ChunkCounterSelector => new ChunkCounterSelectorEnum();

	public static IntegerName ChunkLineStatusAll => (IntegerName)"@ChunkData/ChunkLineStatusAll";

	public static IntegerName ChunkTimestamp => (IntegerName)"@ChunkData/ChunkTimestamp";

	public static FloatName ChunkExposureTime => (FloatName)"@ChunkData/ChunkExposureTime";

	public static FloatName ChunkGain => (FloatName)"@ChunkData/ChunkGain";

	public static ChunkGainSelectorEnum ChunkGainSelector => new ChunkGainSelectorEnum();
}
