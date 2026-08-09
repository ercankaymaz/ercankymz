using System;
using System.Buffers.Binary;
using System.IO;

namespace UglyToad.PdfPig.Images.Png;

internal static class StreamHelper
{
	public static void WriteBigEndianInt32(Stream stream, int value)
	{
		Span<byte> span = stackalloc byte[4];
		BinaryPrimitives.WriteInt32BigEndian(span, value);
		stream.Write(span);
	}

	public static bool TryReadHeaderBytes(Stream stream, out byte[] bytes)
	{
		bytes = new byte[8];
		return stream.Read(bytes, 0, 8) == 8;
	}
}
