using System;

namespace UglyToad.PdfPig.Filters.Lzw;

internal ref struct BitStream(ReadOnlySpan<byte> data)
{
	private readonly ReadOnlySpan<byte> data = data;

	private int currentWithinByteBitOffset = 0;

	private int currentByteIndex = 0;

	public int Get(int numberOfBits)
	{
		int num = (numberOfBits + currentWithinByteBitOffset) % 8;
		int num2 = (numberOfBits + currentWithinByteBitOffset) / 8;
		if (num != 0)
		{
			num2++;
		}
		int num3 = 0;
		for (int i = 0; i < num2; i++)
		{
			if (i > 0)
			{
				currentByteIndex++;
			}
			if (currentByteIndex >= data.Length)
			{
				throw new InvalidOperationException($"Reached the end of the bit stream while trying to read {i} bits.");
			}
			num3 <<= 8;
			num3 |= data[currentByteIndex];
		}
		if (num > 0)
		{
			num3 >>= 8 - num;
		}
		else
		{
			currentByteIndex++;
		}
		int num4 = 32 - numberOfBits;
		num3 &= -1 >>> num4;
		currentWithinByteBitOffset = num;
		return num3;
	}
}
