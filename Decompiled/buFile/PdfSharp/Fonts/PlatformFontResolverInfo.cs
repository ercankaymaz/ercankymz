using System.Drawing;

namespace PdfSharp.Fonts;

internal class PlatformFontResolverInfo : FontResolverInfo
{
	private readonly Font _gdiFont;

	public Font GdiFont => _gdiFont;

	public PlatformFontResolverInfo(string faceName, bool mustSimulateBold, bool mustSimulateItalic, Font gdiFont)
		: base(faceName, mustSimulateBold, mustSimulateItalic)
	{
		_gdiFont = gdiFont;
	}
}
