using System;
using System.Collections.Generic;
using SixLabors.ImageSharp.Memory;
using SixLabors.ImageSharp.PixelFormats;

namespace SixLabors.ImageSharp.Processing.Processors.Quantization;

public class DefaultPixelSamplingStrategy : IPixelSamplingStrategy
{
	private const int DefaultMaximumPixels = 16777216;

	public long MaximumPixels { get; }

	public double MinimumScanRatio { get; }

	public DefaultPixelSamplingStrategy()
		: this(16777216, 0.1)
	{
	}

	public DefaultPixelSamplingStrategy(int maximumPixels, double minimumScanRatio)
	{
		Guard.MustBeGreaterThan(maximumPixels, 0, "maximumPixels");
		MaximumPixels = maximumPixels;
		MinimumScanRatio = minimumScanRatio;
	}

	public IEnumerable<Buffer2DRegion<TPixel>> EnumeratePixelRegions<TPixel>(Image<TPixel> image) where TPixel : unmanaged, IPixel<TPixel>
	{
		long num = Math.Min(MaximumPixels, (long)image.Width * (long)image.Height * image.Frames.Count) / image.Width;
		long totalNumberOfRows = (long)image.Height * (long)image.Frames.Count;
		if (totalNumberOfRows <= num)
		{
			foreach (ImageFrame<TPixel> frame in image.Frames)
			{
				yield return frame.PixelBuffer.GetRegion();
			}
			yield break;
		}
		double value = (double)num / (double)totalNumberOfRows;
		value = Math.Max(val2: (num <= 200) ? Math.Round(value, 1) : Math.Round(value, 2), val1: MinimumScanRatio);
		Rational rational = new Rational(value);
		int denom = (int)rational.Denominator;
		int num2 = (int)rational.Numerator;
		for (int pos = 0; pos < totalNumberOfRows; pos++)
		{
			if ((int)((uint)pos % (uint)denom) < num2)
			{
				yield return GetRow(pos);
			}
		}
		Buffer2DRegion<TPixel> GetRow(int num3)
		{
			int index = num3 / image.Height;
			int y = num3 % image.Height;
			return image.Frames[index].PixelBuffer.GetRegion(0, y, image.Width, 1);
		}
	}

	public IEnumerable<Buffer2DRegion<TPixel>> EnumeratePixelRegions<TPixel>(ImageFrame<TPixel> frame) where TPixel : unmanaged, IPixel<TPixel>
	{
		long num = Math.Min(MaximumPixels, (long)frame.Width * (long)frame.Height) / frame.Width;
		long totalNumberOfRows = frame.Height;
		if (totalNumberOfRows <= num)
		{
			yield return frame.PixelBuffer.GetRegion();
			yield break;
		}
		double value = (double)num / (double)totalNumberOfRows;
		value = Math.Max(val2: (num <= 200) ? Math.Round(value, 1) : Math.Round(value, 2), val1: MinimumScanRatio);
		Rational rational = new Rational(value);
		int denom = (int)rational.Denominator;
		int num2 = (int)rational.Numerator;
		for (int pos = 0; pos < totalNumberOfRows; pos++)
		{
			if ((int)((uint)pos % (uint)denom) < num2)
			{
				yield return GetRow(pos);
			}
		}
		Buffer2DRegion<TPixel> GetRow(int num3)
		{
			int y = num3 % frame.Height;
			return frame.PixelBuffer.GetRegion(0, y, frame.Width, 1);
		}
	}
}
