using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace UglyToad.PdfPig.Filters.Dct.JpegLibrary.Jpeg;

internal sealed class JpegStandardHuffmanEncodingTable
{
	private static JpegHuffmanEncodingTable? s_luminanceDCTable;

	private static JpegHuffmanEncodingTable? s_luminanceACTable;

	private static JpegHuffmanEncodingTable? s_chrominanceDCTable;

	private static JpegHuffmanEncodingTable? s_chrominanceACTable;

	private static ReadOnlySpan<byte> LuminanceDCCodeLengths => new byte[16]
	{
		0, 1, 5, 1, 1, 1, 1, 1, 1, 0,
		0, 0, 0, 0, 0, 0
	};

	private static ReadOnlySpan<byte> LuminanceDCCodeValues => new byte[12]
	{
		0, 1, 2, 3, 4, 5, 6, 7, 8, 9,
		10, 11
	};

	private static ReadOnlySpan<byte> LuminanceACCodeLengths => new byte[16]
	{
		0, 2, 1, 3, 3, 2, 4, 3, 5, 5,
		4, 4, 0, 0, 1, 125
	};

	private static ReadOnlySpan<byte> LuminanceACCodeValues => new byte[162]
	{
		1, 2, 3, 0, 4, 17, 5, 18, 33, 49,
		65, 6, 19, 81, 97, 7, 34, 113, 20, 50,
		129, 145, 161, 8, 35, 66, 177, 193, 21, 82,
		209, 240, 36, 51, 98, 114, 130, 9, 10, 22,
		23, 24, 25, 26, 37, 38, 39, 40, 41, 42,
		52, 53, 54, 55, 56, 57, 58, 67, 68, 69,
		70, 71, 72, 73, 74, 83, 84, 85, 86, 87,
		88, 89, 90, 99, 100, 101, 102, 103, 104, 105,
		106, 115, 116, 117, 118, 119, 120, 121, 122, 131,
		132, 133, 134, 135, 136, 137, 138, 146, 147, 148,
		149, 150, 151, 152, 153, 154, 162, 163, 164, 165,
		166, 167, 168, 169, 170, 178, 179, 180, 181, 182,
		183, 184, 185, 186, 194, 195, 196, 197, 198, 199,
		200, 201, 202, 210, 211, 212, 213, 214, 215, 216,
		217, 218, 225, 226, 227, 228, 229, 230, 231, 232,
		233, 234, 241, 242, 243, 244, 245, 246, 247, 248,
		249, 250
	};

	private static ReadOnlySpan<byte> ChrominanceDCCodeLengths => new byte[16]
	{
		0, 3, 1, 1, 1, 1, 1, 1, 1, 1,
		1, 0, 0, 0, 0, 0
	};

	private static ReadOnlySpan<byte> ChrominanceDCCodeValues => new byte[12]
	{
		0, 1, 2, 3, 4, 5, 6, 7, 8, 9,
		10, 11
	};

	private static ReadOnlySpan<byte> ChrominanceACCodeLengths => new byte[16]
	{
		0, 2, 1, 2, 4, 4, 3, 4, 7, 5,
		4, 4, 0, 1, 2, 119
	};

	private static ReadOnlySpan<byte> ChrominanceACCodeValues => new byte[162]
	{
		0, 1, 2, 3, 17, 4, 5, 33, 49, 6,
		18, 65, 81, 7, 97, 113, 19, 34, 50, 129,
		8, 20, 66, 145, 161, 177, 193, 9, 35, 51,
		82, 240, 21, 98, 114, 209, 10, 22, 36, 52,
		225, 37, 241, 23, 24, 25, 26, 38, 39, 40,
		41, 42, 53, 54, 55, 56, 57, 58, 67, 68,
		69, 70, 71, 72, 73, 74, 83, 84, 85, 86,
		87, 88, 89, 90, 99, 100, 101, 102, 103, 104,
		105, 106, 115, 116, 117, 118, 119, 120, 121, 122,
		130, 131, 132, 133, 134, 135, 136, 137, 138, 146,
		147, 148, 149, 150, 151, 152, 153, 154, 162, 163,
		164, 165, 166, 167, 168, 169, 170, 178, 179, 180,
		181, 182, 183, 184, 185, 186, 194, 195, 196, 197,
		198, 199, 200, 201, 202, 210, 211, 212, 213, 214,
		215, 216, 217, 218, 226, 227, 228, 229, 230, 231,
		232, 233, 234, 242, 243, 244, 245, 246, 247, 248,
		249, 250
	};

	private static JpegHuffmanCanonicalCode[] BuildCanonicalCode(ReadOnlySpan<byte> codeLengths, ReadOnlySpan<byte> codeValues)
	{
		JpegHuffmanCanonicalCode[] array = new JpegHuffmanCanonicalCode[codeValues.Length];
		Span<byte> span = stackalloc byte[16];
		codeLengths.CopyTo(span);
		int num = 1;
		ref byte reference = ref MemoryMarshal.GetReference(span);
		for (int i = 0; i < array.Length; i++)
		{
			while (reference == 0)
			{
				reference = ref Unsafe.Add(ref reference, 1);
				num++;
			}
			reference--;
			array[i].Symbol = codeValues[i];
			array[i].CodeLength = (byte)num;
		}
		ushort num2 = (array[0].Code = 0);
		ushort num4 = num2;
		int codeLength = array[0].CodeLength;
		for (int j = 1; j < array.Length; j++)
		{
			ref JpegHuffmanCanonicalCode reference2 = ref array[j];
			if (reference2.CodeLength > codeLength)
			{
				num4++;
				num4 = (reference2.Code = (ushort)(num4 << reference2.CodeLength - codeLength));
				codeLength = reference2.CodeLength;
			}
			else
			{
				num4 = (reference2.Code = (ushort)(num4 + 1));
			}
		}
		return array;
	}

	public static JpegHuffmanEncodingTable GetLuminanceDCTable()
	{
		JpegHuffmanEncodingTable jpegHuffmanEncodingTable = s_luminanceDCTable;
		if (jpegHuffmanEncodingTable == null)
		{
			jpegHuffmanEncodingTable = (s_luminanceDCTable = new JpegHuffmanEncodingTable(BuildCanonicalCode(LuminanceDCCodeLengths, LuminanceDCCodeValues)));
		}
		return jpegHuffmanEncodingTable;
	}

	public static JpegHuffmanEncodingTable GetLuminanceACTable()
	{
		JpegHuffmanEncodingTable jpegHuffmanEncodingTable = s_luminanceACTable;
		if (jpegHuffmanEncodingTable == null)
		{
			jpegHuffmanEncodingTable = (s_luminanceACTable = new JpegHuffmanEncodingTable(BuildCanonicalCode(LuminanceACCodeLengths, LuminanceACCodeValues)));
		}
		return jpegHuffmanEncodingTable;
	}

	public static JpegHuffmanEncodingTable GetChrominanceDCTable()
	{
		JpegHuffmanEncodingTable jpegHuffmanEncodingTable = s_chrominanceDCTable;
		if (jpegHuffmanEncodingTable == null)
		{
			jpegHuffmanEncodingTable = (s_chrominanceDCTable = new JpegHuffmanEncodingTable(BuildCanonicalCode(ChrominanceDCCodeLengths, ChrominanceDCCodeValues)));
		}
		return jpegHuffmanEncodingTable;
	}

	public static JpegHuffmanEncodingTable GetChrominanceACTable()
	{
		JpegHuffmanEncodingTable jpegHuffmanEncodingTable = s_chrominanceACTable;
		if (jpegHuffmanEncodingTable == null)
		{
			jpegHuffmanEncodingTable = (s_chrominanceACTable = new JpegHuffmanEncodingTable(BuildCanonicalCode(ChrominanceACCodeLengths, ChrominanceACCodeValues)));
		}
		return jpegHuffmanEncodingTable;
	}
}
