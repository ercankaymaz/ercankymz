using System.Runtime.InteropServices;

namespace Opc.Ua.Bindings;

[ComVisible(true)]
public enum TcpChannelState
{
	Closed,
	Closing,
	Connecting,
	Opening,
	Open,
	Faulted
}
