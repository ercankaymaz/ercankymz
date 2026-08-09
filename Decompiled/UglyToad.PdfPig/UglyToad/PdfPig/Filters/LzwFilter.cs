using System;
using System.Collections.Generic;
using System.IO;
using UglyToad.PdfPig.Core;
using UglyToad.PdfPig.Filters.Lzw;
using UglyToad.PdfPig.Tokens;
using UglyToad.PdfPig.Util;

namespace UglyToad.PdfPig.Filters;

public sealed class LzwFilter : IFilter
{
	private const int DefaultColors = 1;

	private const int DefaultBitsPerComponent = 8;

	private const int DefaultColumns = 1;

	private const int ClearTable = 256;

	private const int EodMarker = 257;

	private const int NineBitBoundary = 511;

	private const int TenBitBoundary = 1023;

	private const int ElevenBitBoundary = 2047;

	public bool IsSupported { get; } = true;

	public Memory<byte> Decode(Memory<byte> input, DictionaryToken streamDictionary, IFilterProvider filterProvider, int filterIndex)
	{
		DictionaryToken filterParameters = DecodeParameterResolver.GetFilterParameters(streamDictionary, filterIndex);
		int intOrDefault = filterParameters.GetIntOrDefault(NameToken.Predictor, -1);
		int intOrDefault2 = filterParameters.GetIntOrDefault(NameToken.EarlyChange, 1);
		int colors = Math.Min(filterParameters.GetIntOrDefault(NameToken.Colors, 1), 32);
		int intOrDefault3 = filterParameters.GetIntOrDefault(NameToken.BitsPerComponent, 8);
		int intOrDefault4 = filterParameters.GetIntOrDefault(NameToken.Columns, 1);
		return Decode(input.Span, intOrDefault2 == 1, intOrDefault, colors, intOrDefault3, intOrDefault4);
	}

	private static Memory<byte> Decode(ReadOnlySpan<byte> input, bool isEarlyChange, int predictor, int colors, int bitsPerComponent, int columns)
	{
		using MemoryStream memoryStream = new MemoryStream((int)((double)input.Length * 1.5));
		using Stream stream = PngPredictor.WrapPredictor(memoryStream, predictor, colors, bitsPerComponent, columns);
		Dictionary<int, byte[]> defaultTable = GetDefaultTable();
		int numberOfBits = 9;
		BitStream bitStream = new BitStream(input);
		int num = ((!isEarlyChange) ? 1 : 0);
		int num2 = -1;
		while (true)
		{
			int num3 = bitStream.Get(numberOfBits);
			switch (num3)
			{
			case 256:
				defaultTable = GetDefaultTable();
				num2 = -1;
				numberOfBits = 9;
				continue;
			case 257:
				stream.Flush();
				return memoryStream.AsMemory();
			}
			if (defaultTable.TryGetValue(num3, out var value))
			{
				stream.Write(value, 0, value.Length);
				if (num2 >= 0)
				{
					byte[] array = defaultTable[num2];
					byte[] array2 = new byte[array.Length + 1];
					Array.Copy(array, array2, array.Length);
					array2[array.Length] = value[0];
					defaultTable[defaultTable.Count] = array2;
				}
			}
			else
			{
				byte[] array3 = defaultTable[num2];
				byte[] array4 = new byte[array3.Length + 1];
				Array.Copy(array3, array4, array3.Length);
				array4[array3.Length] = array3[0];
				stream.Write(array4, 0, array4.Length);
				defaultTable[defaultTable.Count] = array4;
			}
			num2 = num3;
			numberOfBits = ((defaultTable.Count < 2047 + num) ? ((defaultTable.Count < 1023 + num) ? ((defaultTable.Count < 511 + num) ? 9 : 10) : 11) : 12);
		}
	}

	private static Dictionary<int, byte[]> GetDefaultTable()
	{
		Dictionary<int, byte[]> dictionary = new Dictionary<int, byte[]>();
		for (int i = 0; i < 256; i++)
		{
			dictionary[i] = new byte[1] { (byte)i };
		}
		dictionary[256] = null;
		dictionary[257] = null;
		return dictionary;
	}
}
