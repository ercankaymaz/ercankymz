using System;
using System.Runtime.InteropServices;

namespace Opc.Ua.Bindings;

[ComVisible(true)]
public class TcpConnectionWaitingEventArgs : ConnectionWaitingEventArgs
{
	public override object Handle => Socket;

	internal IMessageSocket Socket { get; }

	internal TcpConnectionWaitingEventArgs(string serverUrl, Uri endpointUrl, IMessageSocket socket)
		: base(serverUrl, endpointUrl)
	{
		Socket = socket;
	}
}
