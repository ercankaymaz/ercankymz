using PdfSharp.Drawing;
using PdfSharp.Fonts;

namespace PdfSharp.Internal;

public static class FontsDevHelper
{
	public static XFont CreateSpecialFont(string familyName, double emSize, XFontStyle style, XPdfFontOptions pdfOptions, XStyleSimulations styleSimulations)
	{
		return new XFont(familyName, emSize, style, pdfOptions, styleSimulations);
	}

	public static string GetFontCachesState()
	{
		return FontFactory.GetFontCachesState();
	}
}
