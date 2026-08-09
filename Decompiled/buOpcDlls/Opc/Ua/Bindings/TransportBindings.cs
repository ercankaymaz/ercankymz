using System;
using System.Runtime.InteropServices;

namespace Opc.Ua.Bindings;

[ComVisible(true)]
public static class TransportBindings
{
	public static TransportChannelBindings Channels { get; private set; }

	public static TransportListenerBindings Listeners { get; private set; }

	static TransportBindings()
	{
		Channels = new TransportChannelBindings(new Type[1] { typeof(TcpTransportChannelFactory) });
		Listeners = new TransportListenerBindings(new Type[1] { typeof(TcpTransportListenerFactory) });
	}
}
