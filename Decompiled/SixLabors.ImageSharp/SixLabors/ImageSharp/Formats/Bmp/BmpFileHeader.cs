using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace SixLabors.ImageSharp.Formats.Bmp;

[StructLayout(LayoutKind.Sequential, Pack = 1)]
internal readonly struct BmpFileHeader(short type, int fileSize, int reserved, int offset)
{
	public const int Size = 14;

	public short Type { get; } = type;

	public int FileSize { get; } = fileSize;

	public int Reserved { get; } = reserved;

	public int Offset { get; } = offset;

	public static BmpFileHeader Parse(Span<byte> data)
	{
		return MemoryMarshal.Cast<byte, BmpFileHeader>(data)[0];
	}

	public void WriteTo(Span<byte> buffer)
	{
		Unsafe.As<byte, BmpFileHeader>(ref MemoryMarshal.GetReference<byte>(buffer)) = this;
	}
}
