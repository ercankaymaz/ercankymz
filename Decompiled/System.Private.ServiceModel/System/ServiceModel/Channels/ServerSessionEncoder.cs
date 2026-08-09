namespace System.ServiceModel.Channels;

internal abstract class ServerSessionEncoder : SessionEncoder
{
	public static byte[] AckResponseBytes = new byte[1] { 11 };

	public static byte[] UpgradeResponseBytes = new byte[1] { 10 };
}
