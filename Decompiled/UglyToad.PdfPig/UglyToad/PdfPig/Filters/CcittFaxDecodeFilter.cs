using System;
using UglyToad.PdfPig.Core;
using UglyToad.PdfPig.Filters.CcittFax;
using UglyToad.PdfPig.Tokens;
using UglyToad.PdfPig.Util;

namespace UglyToad.PdfPig.Filters;

public sealed class CcittFaxDecodeFilter : IFilter
{
	public bool IsSupported { get; } = true;

	public Memory<byte> Decode(Memory<byte> input, DictionaryToken streamDictionary, IFilterProvider filterProvider, int filterIndex)
	{
		DictionaryToken filterParameters = DecodeParameterResolver.GetFilterParameters(streamDictionary, filterIndex);
		int intOrDefault = filterParameters.GetIntOrDefault(NameToken.Columns, 1728);
		int intOrDefault2 = filterParameters.GetIntOrDefault(NameToken.Rows);
		int intOrDefault3 = streamDictionary.GetIntOrDefault(NameToken.Height, NameToken.H);
		intOrDefault2 = ((intOrDefault2 <= 0 || intOrDefault3 <= 0) ? Math.Max(intOrDefault2, intOrDefault3) : intOrDefault3);
		int intOrDefault4 = filterParameters.GetIntOrDefault(NameToken.K);
		bool booleanOrDefault = filterParameters.GetBooleanOrDefault(NameToken.EncodedByteAlign, defaultValue: false);
		CcittFaxCompressionType type = DetermineCompressionType(input.Span, intOrDefault4);
		using CcittFaxDecoderStream decoderStream = new CcittFaxDecoderStream(MemoryHelper.AsReadOnlyMemoryStream(input), intOrDefault, type, booleanOrDefault);
		byte[] array = new byte[(intOrDefault + 7) / 8 * intOrDefault2];
		ReadFromDecoderStream(decoderStream, array);
		if (!filterParameters.GetBooleanOrDefault(NameToken.BlackIs1, defaultValue: false))
		{
			InvertBitmap(array);
		}
		return array;
	}

	private static CcittFaxCompressionType DetermineCompressionType(ReadOnlySpan<byte> input, int k)
	{
		if (k == 0)
		{
			CcittFaxCompressionType result = CcittFaxCompressionType.Group3_1D;
			if (input[0] != 0 || (input[1] >> 4 != 1 && input[1] != 1))
			{
				result = CcittFaxCompressionType.ModifiedHuffman;
				short num = (short)((input[0] << 8) + (input[1] & 0xFF) >> 4);
				for (int i = 12; i < 160; i++)
				{
					num = (short)((num << 1) + ((input[i / 8] >> 7 - i % 8) & 1));
					if ((num & 0xFFF) == 1)
					{
						return CcittFaxCompressionType.Group3_1D;
					}
				}
			}
			return result;
		}
		if (k > 0)
		{
			return CcittFaxCompressionType.Group3_2D;
		}
		return CcittFaxCompressionType.Group4_2D;
	}

	private static void ReadFromDecoderStream(CcittFaxDecoderStream decoderStream, byte[] result)
	{
		int num = 0;
		int num2;
		while ((num2 = decoderStream.Read(result, num, result.Length - num)) > -1)
		{
			num += num2;
			if (num >= result.Length)
			{
				break;
			}
		}
		decoderStream.Close();
	}

	private static void InvertBitmap(Span<byte> bufferData)
	{
		for (int i = 0; i < bufferData.Length; i++)
		{
			ref byte reference = ref bufferData[i];
			reference = (byte)(~reference & 0xFF);
		}
	}
}
