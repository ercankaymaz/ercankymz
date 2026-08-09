using System.Collections.Generic;

namespace UglyToad.PdfPig.Filters.Dct.JpegLibrary.Jpeg;

internal sealed class JpegHuffmanCanonicalCodeCompareByCodeLen : Comparer<JpegHuffmanCanonicalCode>
{
	public static JpegHuffmanCanonicalCodeCompareByCodeLen Instance { get; } = new JpegHuffmanCanonicalCodeCompareByCodeLen();

	public override int Compare(JpegHuffmanCanonicalCode x, JpegHuffmanCanonicalCode y)
	{
		if (x.CodeLength > y.CodeLength)
		{
			return 1;
		}
		if (x.CodeLength < y.CodeLength)
		{
			return -1;
		}
		if (x.Symbol > y.Symbol)
		{
			return 1;
		}
		return -1;
	}
}
