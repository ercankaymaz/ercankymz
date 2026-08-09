using System.Runtime.InteropServices;

namespace System.Buffers;

[ComVisible(true)]
public interface IMemoryOwner<T> : IDisposable
{
	Memory<T> Memory { get; }
}
