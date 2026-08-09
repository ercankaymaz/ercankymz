using System.Buffers;

namespace System.IO;

internal static class StreamExtensions
{
	public static void Write(this Stream stream, ReadOnlySpan<byte> buffer)
	{
		byte[] array = ArrayPool<byte>.Shared.Rent(buffer.Length);
		buffer.CopyTo(array);
		try
		{
			stream.Write(array, 0, buffer.Length);
		}
		finally
		{
			ArrayPool<byte>.Shared.Return(array);
		}
	}

	public static int Read(this Stream stream, Span<byte> buffer)
	{
		byte[] array = ArrayPool<byte>.Shared.Rent(buffer.Length);
		try
		{
			int num = stream.Read(array, 0, buffer.Length);
			array.AsSpan(0, num).CopyTo(buffer);
			return num;
		}
		finally
		{
			ArrayPool<byte>.Shared.Return(array);
		}
	}
}
