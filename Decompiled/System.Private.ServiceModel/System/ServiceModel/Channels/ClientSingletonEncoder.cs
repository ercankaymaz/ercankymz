namespace System.ServiceModel.Channels;

internal class ClientSingletonEncoder : SingletonEncoder
{
	public static byte[] PreambleEndBytes = new byte[1] { 12 };

	public static byte[] ModeBytes = new byte[5] { 0, 1, 0, 1, 1 };

	private ClientSingletonEncoder()
	{
	}

	public static int CalcStartSize(EncodedVia via, EncodedContentType contentType)
	{
		return via.EncodedBytes.Length + contentType.EncodedBytes.Length;
	}

	public static void EncodeStart(byte[] buffer, int offset, EncodedVia via, EncodedContentType contentType)
	{
		Buffer.BlockCopy(via.EncodedBytes, 0, buffer, offset, via.EncodedBytes.Length);
		Buffer.BlockCopy(contentType.EncodedBytes, 0, buffer, offset + via.EncodedBytes.Length, contentType.EncodedBytes.Length);
	}
}
