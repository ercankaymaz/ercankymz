using System.Net.WebSockets;

namespace System.ServiceModel.Channels;

internal static class WebSocketDefaults
{
	public const WebSocketTransportUsage TransportUsage = WebSocketTransportUsage.Never;

	public const bool CreateNotificationOnConnection = false;

	public const string DefaultKeepAliveIntervalString = "00:00:00";

	public static readonly TimeSpan DefaultKeepAliveInterval = TimeSpanHelper.FromSeconds(0, "00:00:00");

	public const int BufferSize = 16384;

	public const int MinReceiveBufferSize = 256;

	public const int MinSendBufferSize = 16;

	internal const WebSocketMessageType DefaultWebSocketMessageType = WebSocketMessageType.Binary;

	public const string SubProtocol = null;

	public const string WebSocketConnectionHeaderValue = "Upgrade";

	public const string WebSocketUpgradeHeaderValue = "websocket";
}
