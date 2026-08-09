using System;
using System.Diagnostics.CodeAnalysis;
using UglyToad.PdfPig.Content;
using UglyToad.PdfPig.Graphics.Colors;

namespace UglyToad.PdfPig.Images.Png;

internal static class PngFromPdfImageFactory
{
	private static bool TryGenerateSoftMask(IPdfImage image, [NotNullWhen(true)] out ReadOnlySpan<byte> maskBytes)
	{
		maskBytes = ReadOnlySpan<byte>.Empty;
		IPdfImage maskImage = image.MaskImage;
		if (maskImage == null)
		{
			return false;
		}
		if (image.HeightInSamples != maskImage.HeightInSamples || image.WidthInSamples != maskImage.WidthInSamples)
		{
			return false;
		}
		if (!maskImage.TryGetBytesAsMemory(out var memory))
		{
			return false;
		}
		try
		{
			maskBytes = ColorSpaceDetailsByteConverter.Convert(maskImage.ColorSpaceDetails, memory.Span, maskImage.BitsPerComponent, maskImage.WidthInSamples, maskImage.HeightInSamples);
			return IsCorrectlySized(maskImage, maskBytes);
		}
		catch (Exception)
		{
		}
		return false;
	}

	private static bool IsCorrectlySized(IPdfImage image, ReadOnlySpan<byte> bytesPure)
	{
		int baseNumberOfColorComponents = image.ColorSpaceDetails.BaseNumberOfColorComponents;
		int num = image.WidthInSamples * image.HeightInSamples * baseNumberOfColorComponents;
		int length = bytesPure.Length;
		if (bytesPure.Length != num && (length != num + 1 || bytesPure[length - 1] != 10) && (length != num + 1 || bytesPure[length - 1] != 13))
		{
			if (length == num + 2 && bytesPure[length - 2] == 13)
			{
				return bytesPure[length - 1] == 10;
			}
			return false;
		}
		return true;
	}

	public static bool TryGenerate(IPdfImage image, [NotNullWhen(true)] out byte[]? bytes)
	{
		bytes = null;
		if (image.ColorSpaceDetails == null || image.ColorSpaceDetails is UnsupportedColorSpaceDetails || image.ColorSpaceDetails.BaseType == ColorSpace.Pattern || !image.TryGetBytesAsMemory(out var memory))
		{
			return false;
		}
		Span<byte> span = memory.Span;
		try
		{
			span = ColorSpaceDetailsByteConverter.Convert(image.ColorSpaceDetails, span, image.BitsPerComponent, image.WidthInSamples, image.HeightInSamples);
			int baseNumberOfColorComponents = image.ColorSpaceDetails.BaseNumberOfColorComponents;
			ReadOnlySpan<byte> maskBytes = null;
			bool flag = TryGenerateSoftMask(image, out maskBytes);
			Func<int, byte> func = (int _) => byte.MaxValue;
			if (flag)
			{
				byte[] softMaskBytes = maskBytes.ToArray();
				func = ((!image.MaskImage.NeedsReverseDecode()) ? ((Func<int, byte>)((int i) => softMaskBytes[i])) : ((Func<int, byte>)((int i) => Convert.ToByte(255 - softMaskBytes[i]))));
			}
			PngBuilder pngBuilder = PngBuilder.Create(image.WidthInSamples, image.HeightInSamples, flag);
			if (!IsCorrectlySized(image, span))
			{
				return false;
			}
			if (image.ColorSpaceDetails.BaseType == ColorSpace.DeviceCMYK || baseNumberOfColorComponents == 4)
			{
				int num = 0;
				int num2 = 0;
				for (int num3 = 0; num3 < image.HeightInSamples; num3++)
				{
					for (int num4 = 0; num4 < image.WidthInSamples; num4++)
					{
						byte a = func(num2++);
						double num5 = (double)(int)span[num++] / 255.0;
						double num6 = (double)(int)span[num++] / 255.0;
						double num7 = (double)(int)span[num++] / 255.0;
						double num8 = (double)(int)span[num++] / 255.0;
						byte r = (byte)(255.0 * (1.0 - num5) * (1.0 - num8));
						byte g = (byte)(255.0 * (1.0 - num6) * (1.0 - num8));
						byte b = (byte)(255.0 * (1.0 - num7) * (1.0 - num8));
						pngBuilder.SetPixel(new Pixel(r, g, b, a, isGrayscale: false), num4, num3);
					}
				}
			}
			else if (baseNumberOfColorComponents == 3)
			{
				int num9 = 0;
				int num10 = 0;
				for (int num11 = 0; num11 < image.HeightInSamples; num11++)
				{
					for (int num12 = 0; num12 < image.WidthInSamples; num12++)
					{
						byte a2 = func(num10++);
						pngBuilder.SetPixel(new Pixel(span[num9++], span[num9++], span[num9++], a2, isGrayscale: false), num12, num11);
					}
				}
			}
			else
			{
				int arg = 0;
				if (!image.NeedsReverseDecode())
				{
					for (int num13 = 0; num13 < image.HeightInSamples; num13++)
					{
						for (int num14 = 0; num14 < image.WidthInSamples; num14++)
						{
							byte a3 = func(arg);
							byte b2 = span[arg++];
							pngBuilder.SetPixel(new Pixel(b2, b2, b2, a3, isGrayscale: false), num14, num13);
						}
					}
				}
				else
				{
					for (int num15 = 0; num15 < image.HeightInSamples; num15++)
					{
						for (int num16 = 0; num16 < image.WidthInSamples; num16++)
						{
							byte a4 = func(arg);
							byte b3 = (byte)(255 - span[arg++]);
							pngBuilder.SetPixel(new Pixel(b3, b3, b3, a4, isGrayscale: false), num16, num15);
						}
					}
				}
			}
			bytes = pngBuilder.Save();
			return true;
		}
		catch
		{
		}
		return false;
	}
}
