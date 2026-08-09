using System.Runtime.InteropServices;

namespace Opc.Ua.Bindings;

[ComVisible(true)]
public class TcpTransportChannel : UaSCUaBinaryTransportChannel
{
	public TcpTransportChannel()
		: base(new TcpMessageSocketFactory())
	{
	}
}
