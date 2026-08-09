using System;
using System.Collections.Generic;
using UglyToad.PdfPig.PdfFonts.Cmap;
using UglyToad.PdfPig.Tokenization.Scanner;
using UglyToad.PdfPig.Tokens;

namespace UglyToad.PdfPig.PdfFonts.Parser.Parts;

internal class CidCharacterParser : ICidFontPartParser<NumericToken>
{
	public void Parse(NumericToken numeric, ITokenScanner scanner, CharacterMapBuilder builder)
	{
		List<CidCharacterMapping> list = new List<CidCharacterMapping>();
		for (int i = 0; i < numeric.Int; i++)
		{
			if (!scanner.TryReadToken<HexToken>(out var token))
			{
				throw new InvalidOperationException("The first token in a line for Cid Characters should be a hex, instead it was: " + scanner.CurrentToken);
			}
			if (!scanner.TryReadToken<NumericToken>(out var token2))
			{
				throw new InvalidOperationException("The destination token in a line for Cid Character should be an integer, instead it was: " + scanner.CurrentToken);
			}
			int sourceCharacterCode = token.Bytes.ToInt();
			CidCharacterMapping item = new CidCharacterMapping(sourceCharacterCode, token2.Int);
			list.Add(item);
		}
		builder.CidCharacterMappings = list;
	}
}
