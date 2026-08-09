namespace System.ServiceModel.Channels;

internal class ClientSimplexEncoder : SessionEncoder
{
	public static byte[] ModeBytes = new byte[5] { 0, 1, 0, 1, 3 };

	private ClientSimplexEncoder()
	{
	}
}
