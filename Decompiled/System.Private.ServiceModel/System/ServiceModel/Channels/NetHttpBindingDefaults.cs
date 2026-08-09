namespace System.ServiceModel.Channels;

internal static class NetHttpBindingDefaults
{
	public const NetHttpMessageEncoding MessageEncoding = NetHttpMessageEncoding.Binary;

	public const WebSocketTransportUsage TransportUsage = WebSocketTransportUsage.WhenDuplex;
}
