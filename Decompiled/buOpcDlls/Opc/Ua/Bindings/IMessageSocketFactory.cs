using System.Runtime.InteropServices;

namespace Opc.Ua.Bindings;

[ComVisible(true)]
public interface IMessageSocketFactory
{
	string Implementation { get; }

	IMessageSocket Create(IMessageSink sink, BufferManager bufferManager, int receiveBufferSize);
}
