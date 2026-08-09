using System;
using System.Buffers.Binary;
using System.IO;

namespace UglyToad.PdfPig.Core;

public static class WritingExtensions
{
	public static void WriteUInt(this Stream stream, long value)
	{
		stream.WriteUInt((uint)value);
	}

	public static void WriteUInt(this Stream stream, uint value)
	{
		Span<byte> span = stackalloc byte[4];
		BinaryPrimitives.WriteUInt32BigEndian(span, value);
		stream.Write(span);
	}

	public static void WriteUShort(this Stream stream, int value)
	{
		stream.WriteUShort((ushort)value);
	}

	public static void WriteUShort(this Stream stream, ushort value)
	{
		ReadOnlySpan<byte> buffer = new ReadOnlySpan<byte>(new byte[2]
		{
			(byte)(value >> 8),
			(byte)value
		});
		stream.Write(buffer);
	}

	public static void WriteShort(this Stream stream, ushort value)
	{
		stream.WriteShort((short)value);
	}

	public static void WriteShort(this Stream stream, short value)
	{
		ReadOnlySpan<byte> buffer = new ReadOnlySpan<byte>(new byte[2]
		{
			(byte)(value >> 8),
			(byte)value
		});
		stream.Write(buffer);
	}
}
