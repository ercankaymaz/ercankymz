using System.Runtime.InteropServices;

namespace Opc.Ua.Bindings;

[ComVisible(true)]
public interface IMessageSocketChannel
{
	IMessageSocket Socket { get; }
}
