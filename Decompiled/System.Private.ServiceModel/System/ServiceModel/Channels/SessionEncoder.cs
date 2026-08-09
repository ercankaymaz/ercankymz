namespace System.ServiceModel.Channels;

internal abstract class SessionEncoder
{
	public const int MaxMessageFrameSize = 6;

	public static byte[] PreambleEndBytes = new byte[1] { 12 };

	public static byte[] EndBytes = new byte[1] { 7 };

	public static int CalcStartSize(EncodedVia via, EncodedContentType contentType)
	{
		return via.EncodedBytes.Length + contentType.EncodedBytes.Length;
	}

	public static void EncodeStart(byte[] buffer, int offset, EncodedVia via, EncodedContentType contentType)
	{
		Buffer.BlockCopy(via.EncodedBytes, 0, buffer, offset, via.EncodedBytes.Length);
		Buffer.BlockCopy(contentType.EncodedBytes, 0, buffer, offset + via.EncodedBytes.Length, contentType.EncodedBytes.Length);
	}

	public static ArraySegment<byte> EncodeMessageFrame(ArraySegment<byte> messageFrame)
	{
		int num = 1 + IntEncoder.GetEncodedSize(messageFrame.Count);
		int num2 = messageFrame.Offset - num;
		if (num2 < 0)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentOutOfRangeException("messageFrame.Offset", messageFrame.Offset, System.SR.Format(System.SR.SpaceNeededExceedsMessageFrameOffset, num)));
		}
		byte[] array = messageFrame.Array;
		array[num2++] = 6;
		IntEncoder.Encode(messageFrame.Count, array, num2);
		return new ArraySegment<byte>(array, messageFrame.Offset - num, messageFrame.Count + num);
	}
}
