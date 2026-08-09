using UglyToad.PdfPig.PdfFonts.Cmap;
using UglyToad.PdfPig.Tokenization.Scanner;

namespace UglyToad.PdfPig.PdfFonts.Parser.Parts;

internal interface ICidFontPartParser<in TToken>
{
	void Parse(TToken previous, ITokenScanner tokenScanner, CharacterMapBuilder builder);
}
