using System.IO;

namespace CSUtilities.Extensions;

internal static class StreamExtensions
{
	public static void Write(this Stream stream, byte[] buffer)
	{
		stream.Write(buffer, 0, buffer.Length);
	}
}
