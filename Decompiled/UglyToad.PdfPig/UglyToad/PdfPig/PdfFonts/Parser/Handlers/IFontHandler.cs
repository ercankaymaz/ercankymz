using UglyToad.PdfPig.Tokens;

namespace UglyToad.PdfPig.PdfFonts.Parser.Handlers;

internal interface IFontHandler
{
	IFont Generate(DictionaryToken dictionary);
}
