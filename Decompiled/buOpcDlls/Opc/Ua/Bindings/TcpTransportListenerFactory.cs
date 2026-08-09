using System.Runtime.InteropServices;

namespace Opc.Ua.Bindings;

[ComVisible(true)]
public class TcpTransportListenerFactory : TcpServiceHost
{
	public override string UriScheme => "opc.tcp";

	public override ITransportListener Create()
	{
		return new TcpTransportListener();
	}
}
