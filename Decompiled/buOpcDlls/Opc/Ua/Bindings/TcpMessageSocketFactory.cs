using System.Runtime.InteropServices;

namespace Opc.Ua.Bindings;

[ComVisible(true)]
public class TcpMessageSocketFactory : IMessageSocketFactory
{
	public string Implementation => "UA-TCP";

	public IMessageSocket Create(IMessageSink sink, BufferManager bufferManager, int receiveBufferSize)
	{
		return new TcpMessageSocket(sink, bufferManager, receiveBufferSize);
	}
}
