using System;
using System.IO;

namespace UglyToad.PdfPig.Images.Png;

internal class Png
{
	private readonly RawPngData data;

	private readonly bool hasTransparencyChunk;

	public ImageHeader Header { get; }

	public int Width => Header.Width;

	public int Height => Header.Height;

	public bool HasAlphaChannel
	{
		get
		{
			if ((Header.ColorType & ColorType.AlphaChannelUsed) == 0)
			{
				return hasTransparencyChunk;
			}
			return true;
		}
	}

	internal Png(ImageHeader header, RawPngData data, bool hasTransparencyChunk)
	{
		Header = header;
		this.data = data ?? throw new ArgumentNullException("data");
		this.hasTransparencyChunk = hasTransparencyChunk;
	}

	public Pixel GetPixel(int x, int y)
	{
		return data.GetPixel(x, y);
	}

	public static Png Open(Stream stream, IChunkVisitor? chunkVisitor = null)
	{
		return PngOpener.Open(stream, chunkVisitor);
	}

	public static Png Open(byte[] bytes, IChunkVisitor? chunkVisitor = null)
	{
		using MemoryStream stream = new MemoryStream(bytes);
		return PngOpener.Open(stream, chunkVisitor);
	}

	public static Png Open(string filePath, IChunkVisitor? chunkVisitor = null)
	{
		using FileStream stream = File.OpenRead(filePath);
		return Open(stream, chunkVisitor);
	}
}
