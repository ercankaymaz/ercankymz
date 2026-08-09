using System;
using UglyToad.PdfPig.Graphics.Colors;

namespace UglyToad.PdfPig.Images;

public static class ColorSpaceDetailsByteConverter
{
	public static Span<byte> Convert(ColorSpaceDetails details, Span<byte> decoded, int bitsPerComponent, int imageWidth, int imageHeight)
	{
		if (decoded.IsEmpty)
		{
			return default(Span<byte>);
		}
		if (details == null)
		{
			return decoded;
		}
		if (bitsPerComponent != 8)
		{
			decoded = UnpackComponents(decoded, bitsPerComponent, details.Type);
		}
		int numberOfColorComponents = details.NumberOfColorComponents;
		int num = decoded.Length / imageHeight / numberOfColorComponents;
		if (num != imageWidth)
		{
			decoded = ((numberOfColorComponents <= 1 || imageWidth * imageHeight * numberOfColorComponents >= decoded.Length) ? RemoveStridePadding(decoded, num, imageWidth, imageHeight, numberOfColorComponents) : decoded.Slice(0, imageWidth * imageHeight * numberOfColorComponents));
		}
		return details.Transform(decoded);
	}

	private static Span<byte> UnpackComponents(Span<byte> input, int bitsPerComponent, ColorSpace colorSpace)
	{
		if (bitsPerComponent == 16)
		{
			int num = input.Length / 2;
			Span<byte> result = input.Slice(0, num);
			for (int i = 0; i < num; i++)
			{
				int num2 = 2 * i;
				result[i] = (byte)((ushort)(input[num2 + 1] | (input[num2] << 8)) / 256);
			}
			return result;
		}
		int num3 = 8 - bitsPerComponent;
		Span<byte> result2 = new byte[input.Length * (int)Math.Ceiling((double)(num3 + 1) / (double)bitsPerComponent)];
		int num4 = (int)Math.Pow(2.0, bitsPerComponent) - 1;
		int num5 = 0;
		if (bitsPerComponent == 1 && colorSpace != ColorSpace.Indexed)
		{
			Span<byte> span = input;
			for (int j = 0; j < span.Length; j++)
			{
				byte b = span[j];
				for (int num6 = num3; num6 >= 0; num6--)
				{
					result2[num5++] = (byte)(((byte)((b >> num6) & num4) == 1) ? byte.MaxValue : 0);
				}
			}
			return result2;
		}
		Span<byte> span2 = input;
		for (int j = 0; j < span2.Length; j++)
		{
			byte b2 = span2[j];
			for (int num7 = num3; num7 >= 0; num7 -= bitsPerComponent)
			{
				result2[num5++] = (byte)((b2 >> num7) & num4);
			}
		}
		return result2;
	}

	private static Span<byte> RemoveStridePadding(Span<byte> input, int strideWidth, int imageWidth, int imageHeight, int multiplier)
	{
		int num = imageWidth * imageHeight * multiplier;
		Span<byte> result = ((num < input.Length) ? input.Slice(0, num) : ((Span<byte>)new byte[num]));
		for (int i = 0; i < imageHeight; i++)
		{
			int start = i * strideWidth;
			int start2 = i * imageWidth;
			input.Slice(start, imageWidth).CopyTo(result.Slice(start2, imageWidth));
		}
		return result;
	}
}
