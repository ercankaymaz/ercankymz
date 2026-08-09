using System;
using System.Runtime.InteropServices;

namespace Opc.Ua.Bindings;

[ComVisible(true)]
public interface IMessageSink
{
	bool ChannelFull { get; }

	void OnMessageReceived(IMessageSocket source, ArraySegment<byte> message);

	void OnReceiveError(IMessageSocket source, ServiceResult result);
}
