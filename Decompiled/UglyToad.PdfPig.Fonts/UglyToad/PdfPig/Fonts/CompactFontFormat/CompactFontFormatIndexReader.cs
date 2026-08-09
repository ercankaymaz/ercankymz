using System;

namespace UglyToad.PdfPig.Fonts.CompactFontFormat;

internal static class CompactFontFormatIndexReader
{
	public static CompactFontFormatIndex ReadDictionaryData(CompactFontFormatData data)
	{
		int[] array = ReadIndex(data);
		if (array.Length == 0)
		{
			return new CompactFontFormatIndex(null);
		}
		int num = array.Length - 1;
		byte[][] array2 = new byte[num][];
		for (int i = 0; i < num; i++)
		{
			int num2 = array[i + 1] - array[i];
			if (num2 < 0)
			{
				throw new InvalidOperationException($"Negative object length {num2} at {i}. Current position: {data.Position}.");
			}
			if (num2 > data.Length)
			{
				throw new InvalidOperationException($"Attempted to read data of length {num2} in data array of length {data.Length}.");
			}
			array2[i] = data.ReadBytes(num2);
		}
		return new CompactFontFormatIndex(array2);
	}

	public static int[] ReadIndex(CompactFontFormatData data)
	{
		ushort num = data.ReadCard16();
		if (num == 0)
		{
			return Array.Empty<int>();
		}
		byte offsetSize = data.ReadOffsize();
		int[] array = new int[num + 1];
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = data.ReadOffset(offsetSize);
		}
		return array;
	}
}
