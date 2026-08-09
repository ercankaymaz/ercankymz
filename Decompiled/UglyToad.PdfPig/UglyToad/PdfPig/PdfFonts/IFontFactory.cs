using UglyToad.PdfPig.Tokens;

namespace UglyToad.PdfPig.PdfFonts;

internal interface IFontFactory
{
	IFont Get(DictionaryToken dictionary);
}
