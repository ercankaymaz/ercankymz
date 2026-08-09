using System;
using System.Runtime.InteropServices;

namespace SixLabors.ImageSharp.Formats.Bmp;

[StructLayout(LayoutKind.Sequential, Pack = 1)]
internal readonly struct BmpArrayFileHeader(short type, int size, int offsetToNext, short width, short height)
{
	public short Type { get; } = type;

	public int Size { get; } = size;

	public int OffsetToNext { get; } = offsetToNext;

	public short ScreenWidth { get; } = width;

	public short ScreenHeight { get; } = height;

	public static BmpArrayFileHeader Parse(Span<byte> data)
	{
		return MemoryMarshal.Cast<byte, BmpArrayFileHeader>(data)[0];
	}
}
