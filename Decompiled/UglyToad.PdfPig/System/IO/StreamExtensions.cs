using System.Buffers;

namespace System.IO;

internal static class StreamExtensions
{
	public static void Write(this Stream stream, ReadOnlySpan<byte> data)
	{
		byte[] array = ArrayPool<byte>.Shared.Rent(data.Length);
		data.CopyTo(array);
		try
		{
			stream.Write(array, 0, data.Length);
		}
		finally
		{
			ArrayPool<byte>.Shared.Return(array);
		}
	}
}
