using System;

namespace ACadSharp.IO.DWG;

internal class DwgCheckSumCalculator
{
	public static readonly byte[] MagicSequence;

	static DwgCheckSumCalculator()
	{
		MagicSequence = new byte[256];
		int num = 1;
		for (int i = 0; i < 256; i++)
		{
			num *= 214013;
			num += 2531011;
			MagicSequence[i] = (byte)(num >> 16);
		}
	}

	public static int CompressionCalculator(int length)
	{
		return 31 - (length + 32 - 1) % 32;
	}

	public static uint Calculate(uint seed, byte[] buffer, int offset, int size)
	{
		uint num = seed & 0xFFFF;
		uint num2 = seed >> 16;
		int num3 = offset;
		while (size != 0)
		{
			int num4 = Math.Min(5552, size);
			size -= num4;
			for (int i = 0; i < num4; i++)
			{
				num += buffer[num3];
				num2 += num;
				num3++;
			}
			num %= 65521;
			num2 %= 65521;
		}
		return (num2 << 16) | (num & 0xFFFF);
	}
}
