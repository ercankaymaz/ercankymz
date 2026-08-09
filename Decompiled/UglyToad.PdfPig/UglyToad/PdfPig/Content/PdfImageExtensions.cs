using System.Collections.Generic;

namespace UglyToad.PdfPig.Content;

public static class PdfImageExtensions
{
	public static bool NeedsReverseDecode(this IPdfImage pdfImage)
	{
		IReadOnlyList<double> decode = pdfImage.Decode;
		if (decode != null && decode.Count >= 2 && pdfImage.Decode[0] == 1.0)
		{
			return pdfImage.Decode[1] == 0.0;
		}
		return false;
	}
}
