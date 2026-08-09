using System;
using System.Buffers.Binary;
using System.IO;
using System.IO.Compression;
using UglyToad.PdfPig.Filters;

namespace UglyToad.PdfPig.Images.Png;

internal class PngBuilder
{
	private const byte Deflate32KbWindow = 120;

	private const byte ChecksumBits = 1;

	private readonly byte[] rawData;

	private readonly bool hasAlphaChannel;

	private readonly int width;

	private readonly int height;

	private readonly int bytesPerPixel;

	public static PngBuilder Create(int width, int height, bool hasAlphaChannel)
	{
		int num = (hasAlphaChannel ? 4 : 3);
		return new PngBuilder(new byte[height * width * num + height], hasAlphaChannel, width, height, num);
	}

	private PngBuilder(byte[] rawData, bool hasAlphaChannel, int width, int height, int bytesPerPixel)
	{
		this.rawData = rawData;
		this.hasAlphaChannel = hasAlphaChannel;
		this.width = width;
		this.height = height;
		this.bytesPerPixel = bytesPerPixel;
	}

	public PngBuilder SetPixel(byte r, byte g, byte b, int x, int y)
	{
		return SetPixel(new Pixel(r, g, b), x, y);
	}

	public PngBuilder SetPixel(Pixel pixel, int x, int y)
	{
		int num = y * (width * bytesPerPixel + 1) + 1 + x * bytesPerPixel;
		rawData[num++] = pixel.R;
		rawData[num++] = pixel.G;
		rawData[num++] = pixel.B;
		if (hasAlphaChannel)
		{
			rawData[num] = pixel.A;
		}
		return this;
	}

	public byte[] Save()
	{
		using MemoryStream memoryStream = new MemoryStream();
		Save(memoryStream);
		return memoryStream.ToArray();
	}

	public void Save(Stream outputStream)
	{
		outputStream.Write(HeaderValidationResult.ExpectedHeader);
		PngStreamWriteHelper pngStreamWriteHelper = new PngStreamWriteHelper(outputStream);
		pngStreamWriteHelper.WriteChunkLength(13);
		pngStreamWriteHelper.WriteChunkHeader(ImageHeader.HeaderBytes);
		StreamHelper.WriteBigEndianInt32(pngStreamWriteHelper, width);
		StreamHelper.WriteBigEndianInt32(pngStreamWriteHelper, height);
		pngStreamWriteHelper.WriteByte(8);
		ColorType colorType = ColorType.ColorUsed;
		if (hasAlphaChannel)
		{
			colorType |= ColorType.AlphaChannelUsed;
		}
		pngStreamWriteHelper.WriteByte((byte)colorType);
		pngStreamWriteHelper.WriteByte(0);
		pngStreamWriteHelper.WriteByte(0);
		pngStreamWriteHelper.WriteByte(0);
		pngStreamWriteHelper.WriteCrc();
		byte[] array = Compress(rawData);
		pngStreamWriteHelper.WriteChunkLength(array.Length);
		pngStreamWriteHelper.WriteChunkHeader("IDAT"u8);
		pngStreamWriteHelper.Write(array);
		pngStreamWriteHelper.WriteCrc();
		pngStreamWriteHelper.WriteChunkLength(0);
		pngStreamWriteHelper.WriteChunkHeader("IEND"u8);
		pngStreamWriteHelper.WriteCrc();
	}

	private static byte[] Compress(byte[] data)
	{
		using MemoryStream memoryStream = new MemoryStream();
		using DeflateStream writeStream = new DeflateStream(memoryStream, CompressionLevel.Fastest, leaveOpen: true);
		using Adler32ChecksumStream adler32ChecksumStream = new Adler32ChecksumStream(writeStream);
		adler32ChecksumStream.Write(data, 0, data.Length);
		adler32ChecksumStream.Close();
		memoryStream.Seek(0L, SeekOrigin.Begin);
		byte[] array = new byte[2 + memoryStream.Length + 4];
		array[0] = 120;
		array[1] = 1;
		int num = 0;
		int num2;
		while ((num2 = memoryStream.ReadByte()) != -1)
		{
			array[2 + num] = (byte)num2;
			num++;
		}
		uint checksum = adler32ChecksumStream.Checksum;
		long num3 = 2 + memoryStream.Length;
		BinaryPrimitives.WriteUInt32BigEndian(array.AsSpan((int)num3, 4), checksum);
		return array;
	}
}
