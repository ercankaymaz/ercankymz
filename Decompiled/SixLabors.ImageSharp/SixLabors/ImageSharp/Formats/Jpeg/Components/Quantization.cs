using System;
using System.Runtime.CompilerServices;

namespace SixLabors.ImageSharp.Formats.Jpeg.Components;

internal static class Quantization
{
	public const int MaxQualityFactor = 100;

	public const int MinQualityFactor = 1;

	public const int DefaultQualityFactor = 75;

	public const int QualityEstimationConfidenceLowerThreshold = 25;

	public const int QualityEstimationConfidenceUpperThreshold = 98;

	public static ReadOnlySpan<byte> LuminanceTable => new byte[64]
	{
		16, 11, 10, 16, 24, 40, 51, 61, 12, 12,
		14, 19, 26, 58, 60, 55, 14, 13, 16, 24,
		40, 57, 69, 56, 14, 17, 22, 29, 51, 87,
		80, 62, 18, 22, 37, 56, 68, 109, 103, 77,
		24, 35, 55, 64, 81, 104, 113, 92, 49, 64,
		78, 87, 103, 121, 120, 101, 72, 92, 95, 98,
		112, 100, 103, 99
	};

	public static ReadOnlySpan<byte> ChrominanceTable => new byte[64]
	{
		17, 18, 24, 47, 99, 99, 99, 99, 18, 21,
		26, 66, 99, 99, 99, 99, 24, 26, 56, 99,
		99, 99, 99, 99, 47, 66, 99, 99, 99, 99,
		99, 99, 99, 99, 99, 99, 99, 99, 99, 99,
		99, 99, 99, 99, 99, 99, 99, 99, 99, 99,
		99, 99, 99, 99, 99, 99, 99, 99, 99, 99,
		99, 99, 99, 99
	};

	public static int EstimateQuality(ref Block8x8F table, ReadOnlySpan<byte> target)
	{
		double num = 0.0;
		if (table.EqualsToScalar(1))
		{
			return 100;
		}
		for (int i = 0; i < 64; i++)
		{
			double num2 = (((int)table[i] == 0) ? 999.99 : (100.0 * (double)(table[i] / (float)(int)target[i])));
			num += num2;
		}
		num /= 64.0;
		int value = ((!(num <= 100.0)) ? ((int)Math.Round(5000.0 / num)) : ((int)Math.Round((200.0 - num) / 2.0)));
		return Numerics.Clamp(value, 1, 100);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static int EstimateLuminanceQuality(ref Block8x8F luminanceTable)
	{
		return EstimateQuality(ref luminanceTable, LuminanceTable);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static int EstimateChrominanceQuality(ref Block8x8F chrominanceTable)
	{
		return EstimateQuality(ref chrominanceTable, ChrominanceTable);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private static int QualityToScale(int quality)
	{
		if (quality >= 50)
		{
			return 200 - quality * 2;
		}
		return 5000 / quality;
	}

	public static Block8x8F ScaleQuantizationTable(int scale, ReadOnlySpan<byte> unscaledTable)
	{
		Block8x8F result = default(Block8x8F);
		for (int i = 0; i < 64; i++)
		{
			int value = (unscaledTable[i] * scale + 50) / 100;
			result[i] = Numerics.Clamp(value, 1, 255);
		}
		return result;
	}

	public static Block8x8 ScaleQuantizationTable(int quality, Block8x8 unscaledTable)
	{
		int num = QualityToScale(quality);
		Block8x8 result = default(Block8x8);
		for (int i = 0; i < 64; i++)
		{
			int value = (unscaledTable[i] * num + 50) / 100;
			result[i] = (short)Numerics.Clamp(value, 1, 255);
		}
		return result;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Block8x8F ScaleLuminanceTable(int quality)
	{
		return ScaleQuantizationTable(QualityToScale(quality), LuminanceTable);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Block8x8F ScaleChrominanceTable(int quality)
	{
		return ScaleQuantizationTable(QualityToScale(quality), ChrominanceTable);
	}
}
