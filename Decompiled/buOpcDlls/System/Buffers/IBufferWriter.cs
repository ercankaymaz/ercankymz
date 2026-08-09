using System.Runtime.InteropServices;

namespace System.Buffers;

[ComVisible(true)]
public interface IBufferWriter<T>
{
	void Advance(int count);

	Memory<T> GetMemory(int sizeHint = 0);

	Span<T> GetSpan(int sizeHint = 0);
}
