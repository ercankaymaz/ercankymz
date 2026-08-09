using System.Runtime.InteropServices;

namespace System.Buffers;

[ComVisible(true)]
public interface IPinnable
{
	MemoryHandle Pin(int elementIndex);

	void Unpin();
}
