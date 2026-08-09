namespace System.ServiceModel.Channels;

internal class ClientDuplexEncoder : SessionEncoder
{
	public static byte[] ModeBytes = new byte[5] { 0, 1, 0, 1, 2 };

	private ClientDuplexEncoder()
	{
	}
}
