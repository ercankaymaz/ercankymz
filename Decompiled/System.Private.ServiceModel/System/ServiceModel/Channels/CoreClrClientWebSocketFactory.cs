using System.Net;
using System.Net.WebSockets;
using System.Runtime;
using System.Threading.Tasks;

namespace System.ServiceModel.Channels;

internal class CoreClrClientWebSocketFactory : ClientWebSocketFactory
{
	public override async Task<WebSocket> CreateWebSocketAsync(Uri address, WebHeaderCollection headers, ICredentials credentials, WebSocketTransportSettings settings, TimeoutHelper timeoutHelper)
	{
		ClientWebSocket webSocket = new ClientWebSocket();
		webSocket.Options.Credentials = credentials;
		if (!string.IsNullOrEmpty(settings.SubProtocol))
		{
			webSocket.Options.AddSubProtocol(settings.SubProtocol);
		}
		webSocket.Options.KeepAliveInterval = settings.KeepAliveInterval;
		foreach (object header in headers)
		{
			string text = header as string;
			webSocket.Options.SetRequestHeader(text, headers[text]);
		}
		await webSocket.ConnectAsync(address, await timeoutHelper.GetCancellationTokenAsync());
		return webSocket;
	}
}
