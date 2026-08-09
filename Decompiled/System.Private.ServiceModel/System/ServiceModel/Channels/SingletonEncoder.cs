namespace System.ServiceModel.Channels;

internal abstract class SingletonEncoder
{
	public static byte[] EnvelopeStartBytes = new byte[1] { 5 };

	public static byte[] EnvelopeEndBytes = new byte[1];

	public static byte[] EnvelopeEndFramingEndBytes = new byte[2] { 0, 7 };

	public static byte[] EndBytes = new byte[1] { 7 };

	public static ArraySegment<byte> EncodeMessageFrame(ArraySegment<byte> messageFrame)
	{
		int encodedSize = IntEncoder.GetEncodedSize(messageFrame.Count);
		int num = messageFrame.Offset - encodedSize;
		if (num < 0)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentOutOfRangeException("messageFrame.Offset", messageFrame.Offset, System.SR.Format(System.SR.SpaceNeededExceedsMessageFrameOffset, encodedSize)));
		}
		byte[] array = messageFrame.Array;
		IntEncoder.Encode(messageFrame.Count, array, num);
		return new ArraySegment<byte>(array, num, messageFrame.Count + encodedSize);
	}
}
