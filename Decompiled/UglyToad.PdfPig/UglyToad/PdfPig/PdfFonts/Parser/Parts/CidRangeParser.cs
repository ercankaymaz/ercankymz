using UglyToad.PdfPig.Fonts;
using UglyToad.PdfPig.PdfFonts.Cmap;
using UglyToad.PdfPig.Tokenization.Scanner;
using UglyToad.PdfPig.Tokens;

namespace UglyToad.PdfPig.PdfFonts.Parser.Parts;

internal class CidRangeParser : ICidFontPartParser<NumericToken>
{
	public void Parse(NumericToken numeric, ITokenScanner scanner, CharacterMapBuilder builder)
	{
		for (int i = 0; i < numeric.Int; i++)
		{
			if (!scanner.TryReadToken<HexToken>(out var token))
			{
				throw new InvalidFontFormatException("Could not find the starting hex token for the CIDRange in this font.");
			}
			if (!scanner.TryReadToken<HexToken>(out var token2))
			{
				throw new InvalidFontFormatException("Could not find the end hex token for the CIDRange in this font.");
			}
			if (!scanner.TryReadToken<NumericToken>(out var token3))
			{
				throw new InvalidFontFormatException("Could not find the starting CID numeric token for the CIDRange in this font.");
			}
			int firstCharacterCode = HexToken.ConvertHexBytesToInt(token);
			int lastCharacterCode = HexToken.ConvertHexBytesToInt(token2);
			CidRange range = new CidRange(firstCharacterCode, lastCharacterCode, token3.Int);
			builder.AddCidRange(range);
		}
	}
}
