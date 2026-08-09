using UglyToad.PdfPig.Fonts.TrueType;

namespace UglyToad.PdfPig.Fonts.SystemFonts;

public interface ISystemFontFinder
{
	TrueTypeFont GetTrueTypeFont(string name);
}
