namespace System.ServiceModel.Channels;

internal abstract class ClientFramingDecoder : FramingDecoder
{
	public ClientFramingDecoderState CurrentState { get; protected set; }

	protected override string CurrentStateAsString => CurrentState.ToString();

	public abstract string Fault { get; }

	protected ClientFramingDecoder(long streamPosition)
		: base(streamPosition)
	{
		CurrentState = ClientFramingDecoderState.ReadingUpgradeRecord;
	}

	public abstract int Decode(byte[] bytes, int offset, int size);
}
