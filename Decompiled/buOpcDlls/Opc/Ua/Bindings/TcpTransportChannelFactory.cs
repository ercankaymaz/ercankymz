using System.Runtime.InteropServices;

namespace Opc.Ua.Bindings;

[ComVisible(true)]
public class TcpTransportChannelFactory : ITransportChannelFactory, ITransportBindingFactory<ITransportChannel>, ITransportBindingScheme
{
	public string UriScheme => "opc.tcp";

	public ITransportChannel Create()
	{
		return new TcpTransportChannel();
	}
}
