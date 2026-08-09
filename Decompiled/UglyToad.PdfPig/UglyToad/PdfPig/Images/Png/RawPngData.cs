using System;

namespace UglyToad.PdfPig.Images.Png;

internal sealed class RawPngData
{
	private readonly byte[] data;

	private readonly int bytesPerPixel;

	private readonly int width;

	private readonly Palette? palette;

	private readonly ColorType colorType;

	private readonly int rowOffset;

	private readonly int bitDepth;

	public RawPngData(byte[] data, int bytesPerPixel, Palette? palette, ImageHeader imageHeader)
	{
		if (width < 0)
		{
			throw new ArgumentOutOfRangeException($"Width must be greater than or equal to 0, got {width}.");
		}
		this.data = data ?? throw new ArgumentNullException("data");
		this.bytesPerPixel = bytesPerPixel;
		this.palette = palette;
		width = imageHeader.Width;
		colorType = imageHeader.ColorType;
		rowOffset = ((imageHeader.InterlaceMethod != InterlaceMethod.Adam7) ? 1 : 0);
		bitDepth = imageHeader.BitDepth;
	}

	public Pixel GetPixel(int x, int y)
	{
		if (palette != null)
		{
			int num = 8 / bitDepth;
			int num2 = 1 + width / num;
			int num3 = x / num;
			int num4 = 1 + y * num2 + num3;
			byte b = data[num4];
			if (bitDepth == 8)
			{
				return palette.GetPixel(b);
			}
			int num5 = x % num;
			int num6 = 8 - (num5 + 1) * bitDepth;
			int index = (b >> num6) & ((1 << bitDepth) - 1);
			return palette.GetPixel(index);
		}
		int num7 = rowOffset + rowOffset * y + bytesPerPixel * width * y + bytesPerPixel * x;
		byte b2 = data[num7];
		switch (bytesPerPixel)
		{
		case 1:
			return new Pixel(b2, b2, b2, byte.MaxValue, isGrayscale: true);
		case 2:
			if (colorType == ColorType.None)
			{
				byte second3 = data[num7 + 1];
				byte num10 = ToSingleByte(b2, second3);
				return new Pixel(num10, num10, num10, byte.MaxValue, isGrayscale: true);
			}
			return new Pixel(b2, b2, b2, data[num7 + 1], isGrayscale: true);
		case 3:
			return new Pixel(b2, data[num7 + 1], data[num7 + 2], byte.MaxValue, isGrayscale: false);
		case 4:
			if (colorType == ColorType.AlphaChannelUsed)
			{
				byte second = data[num7 + 1];
				byte first = data[num7 + 2];
				byte second2 = data[num7 + 3];
				byte num9 = ToSingleByte(b2, second);
				byte a2 = ToSingleByte(first, second2);
				return new Pixel(num9, num9, num9, a2, isGrayscale: true);
			}
			return new Pixel(b2, data[num7 + 1], data[num7 + 2], data[num7 + 3], isGrayscale: false);
		case 6:
			return new Pixel(b2, data[num7 + 2], data[num7 + 4], byte.MaxValue, isGrayscale: false);
		case 8:
		{
			int num8 = num7;
			byte r = ToSingleByte(data[num8++], data[num8++]);
			byte g = ToSingleByte(data[num8++], data[num8++]);
			byte b3 = ToSingleByte(data[num8++], data[num8++]);
			byte a = ToSingleByte(data[num8++], data[num8++]);
			return new Pixel(r, g, b3, a, isGrayscale: false);
		}
		default:
			throw new InvalidOperationException($"Unrecognized number of bytes per pixel: {bytesPerPixel}.");
		}
	}

	private static byte ToSingleByte(byte first, byte second)
	{
		int num = (first << 8) + second;
		return (byte)Math.Round((double)(255 * num) / 65535.0);
	}
}
