using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace SixLabors.ImageSharp.Formats.Tga;

[StructLayout(LayoutKind.Sequential, Pack = 1)]
internal readonly struct TgaFileHeader(byte idLength, byte colorMapType, TgaImageType imageType, short cMapStart, short cMapLength, byte cMapDepth, short xOffset, short yOffset, short width, short height, byte pixelDepth, byte imageDescriptor)
{
	public const int Size = 18;

	public byte IdLength { get; } = idLength;

	public byte ColorMapType { get; } = colorMapType;

	public TgaImageType ImageType { get; } = imageType;

	public short CMapStart { get; } = cMapStart;

	public short CMapLength { get; } = cMapLength;

	public byte CMapDepth { get; } = cMapDepth;

	public short XOffset { get; } = xOffset;

	public short YOffset { get; } = yOffset;

	public short Width { get; } = width;

	public short Height { get; } = height;

	public byte PixelDepth { get; } = pixelDepth;

	public byte ImageDescriptor { get; } = imageDescriptor;

	public static TgaFileHeader Parse(Span<byte> data)
	{
		return MemoryMarshal.Cast<byte, TgaFileHeader>(data)[0];
	}

	public void WriteTo(Span<byte> buffer)
	{
		Unsafe.As<byte, TgaFileHeader>(ref MemoryMarshal.GetReference<byte>(buffer)) = this;
	}
}
