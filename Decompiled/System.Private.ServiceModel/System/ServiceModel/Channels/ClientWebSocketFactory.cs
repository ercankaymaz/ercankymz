using System.Net;
using System.Net.WebSockets;
using System.Runtime;
using System.Threading.Tasks;

namespace System.ServiceModel.Channels;

public abstract class ClientWebSocketFactory
{
	public abstract Task<WebSocket> CreateWebSocketAsync(Uri address, WebHeaderCollection headers, ICredentials credentials, WebSocketTransportSettings settings, TimeoutHelper timeoutHelper);

	public static ClientWebSocketFactory GetFactory()
	{
		return new CoreClrClientWebSocketFactory();
	}
}
