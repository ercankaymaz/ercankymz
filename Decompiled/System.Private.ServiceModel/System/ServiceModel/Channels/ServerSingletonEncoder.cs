namespace System.ServiceModel.Channels;

internal class ServerSingletonEncoder : SingletonEncoder
{
	public static byte[] AckResponseBytes = new byte[1] { 11 };

	public static byte[] UpgradeResponseBytes = new byte[1] { 10 };

	private ServerSingletonEncoder()
	{
	}
}
