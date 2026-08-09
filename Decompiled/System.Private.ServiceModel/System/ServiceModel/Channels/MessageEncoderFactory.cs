namespace System.ServiceModel.Channels;

public abstract class MessageEncoderFactory
{
	public abstract MessageEncoder Encoder { get; }

	public abstract MessageVersion MessageVersion { get; }

	public virtual MessageEncoder CreateSessionEncoder()
	{
		return Encoder;
	}
}
