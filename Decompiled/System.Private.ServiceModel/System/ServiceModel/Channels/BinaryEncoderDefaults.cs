namespace System.ServiceModel.Channels;

internal static class BinaryEncoderDefaults
{
	public const int MaxSessionSize = 2048;

	public static EnvelopeVersion EnvelopeVersion => EnvelopeVersion.Soap12;

	public static BinaryVersion BinaryVersion => BinaryVersion.Version1;
}
