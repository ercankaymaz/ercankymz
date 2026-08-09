using System;
using System.Buffers.Binary;
using System.IO;
using System.Text;
using SixLabors.ImageSharp.Formats.Webp.Chunks;

namespace SixLabors.ImageSharp.Common.Helpers;

internal static class RiffHelper
{
	private const uint RiffFourCc = 1380533830u;

	public static void WriteRiffFile(Stream stream, string formType, Action<Stream> func)
	{
		WriteChunk(stream, 1380533830u, delegate(Stream s)
		{
			s.Write(Encoding.ASCII.GetBytes(formType));
			func(s);
		});
	}

	public static void WriteChunk(Stream stream, uint fourCc, Action<Stream> func)
	{
		Span<byte> span = stackalloc byte[4];
		BinaryPrimitives.WriteUInt32BigEndian(span, fourCc);
		stream.Write(span);
		long position = stream.Position;
		stream.Position += 4L;
		func(stream);
		long num = stream.Position;
		uint num2 = (uint)(num - position - 4);
		if (num2 % 2 == 1)
		{
			stream.WriteByte(0);
			num++;
		}
		BinaryPrimitives.WriteUInt32LittleEndian(span, num2);
		stream.Position = position;
		stream.Write(span);
		stream.Position = num;
	}

	public static void WriteChunk(Stream stream, uint fourCc, ReadOnlySpan<byte> data)
	{
		Span<byte> span = stackalloc byte[4];
		BinaryPrimitives.WriteUInt32BigEndian(span, fourCc);
		stream.Write(span);
		uint length = (uint)data.Length;
		BinaryPrimitives.WriteUInt32LittleEndian(span, length);
		stream.Write(span);
		stream.Write(data);
		if (length % 2 == 1)
		{
			stream.WriteByte(0);
		}
	}

	public unsafe static void WriteChunk<TStruct>(Stream stream, uint fourCc, in TStruct chunk) where TStruct : unmanaged
	{
		fixed (TStruct* pointer = &chunk)
		{
			WriteChunk(stream, fourCc, new Span<byte>(pointer, sizeof(TStruct)));
		}
	}

	public static long BeginWriteChunk(Stream stream, uint fourCc)
	{
		Span<byte> span = stackalloc byte[4];
		BinaryPrimitives.WriteUInt32BigEndian(span, fourCc);
		stream.Write(span);
		long position = stream.Position;
		stream.Position += 4L;
		return position;
	}

	public static void EndWriteChunk(Stream stream, long sizePosition)
	{
		Span<byte> span = stackalloc byte[4];
		long num = stream.Position;
		uint num2 = (uint)(num - sizePosition - 4);
		if (num2 % 2 == 1)
		{
			stream.WriteByte(0);
			num++;
		}
		BinaryPrimitives.WriteUInt32LittleEndian(span, num2);
		stream.Position = sizePosition;
		stream.Write(span);
		stream.Position = num;
	}

	public static long BeginWriteRiffFile(Stream stream, string formType)
	{
		long result = BeginWriteChunk(stream, 1380533830u);
		stream.Write(Encoding.ASCII.GetBytes(formType));
		return result;
	}

	public static void EndWriteRiffFile(Stream stream, in WebpVp8X vp8x, bool updateVp8x, long sizePosition)
	{
		EndWriteChunk(stream, sizePosition + 4);
		if (updateVp8x)
		{
			long position = stream.Position;
			stream.Position = sizePosition + 12;
			vp8x.WriteTo(stream);
			stream.Position = position;
		}
	}
}
