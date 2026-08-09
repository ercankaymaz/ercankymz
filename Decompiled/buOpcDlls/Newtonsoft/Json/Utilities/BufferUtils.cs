using System.Runtime.CompilerServices;

namespace Newtonsoft.Json.Utilities;

[Newtonsoft_002EJson_002ENullableContext(2)]
[Newtonsoft_002EJson_002ENullable(0)]
internal static class BufferUtils
{
	[Newtonsoft_002EJson_002ENullableContext(1)]
	public static char[] RentBuffer([Newtonsoft_002EJson_002ENullable(2)] IArrayPool<char> bufferPool, int minSize)
	{
		if (bufferPool == null)
		{
			return new char[minSize];
		}
		return bufferPool.Rent(minSize);
	}

	public static void ReturnBuffer(IArrayPool<char> bufferPool, char[] buffer)
	{
		bufferPool?.Return(buffer);
	}

	[return: Newtonsoft_002EJson_002ENullable(1)]
	public static char[] EnsureBufferSize(IArrayPool<char> bufferPool, int size, char[] buffer)
	{
		if (bufferPool == null)
		{
			return new char[size];
		}
		if (buffer != null)
		{
			bufferPool.Return(buffer);
		}
		return bufferPool.Rent(size);
	}
}
