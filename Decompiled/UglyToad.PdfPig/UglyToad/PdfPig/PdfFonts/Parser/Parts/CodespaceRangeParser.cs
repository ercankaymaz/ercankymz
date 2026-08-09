using System;
using System.Collections.Generic;
using UglyToad.PdfPig.PdfFonts.Cmap;
using UglyToad.PdfPig.Tokenization.Scanner;
using UglyToad.PdfPig.Tokens;

namespace UglyToad.PdfPig.PdfFonts.Parser.Parts;

internal class CodespaceRangeParser : ICidFontPartParser<NumericToken>
{
	public void Parse(NumericToken numeric, ITokenScanner tokenScanner, CharacterMapBuilder builder)
	{
		List<CodespaceRange> list = new List<CodespaceRange>(numeric.Int);
		for (int i = 0; i < numeric.Int; i++)
		{
			if (!tokenScanner.MoveNext())
			{
				throw new InvalidOperationException("Codespace range have reach an unexpected end");
			}
			if (tokenScanner.CurrentToken is OperatorToken { Data: "endcodespacerange" })
			{
				break;
			}
			if (!(tokenScanner.CurrentToken is HexToken hexToken))
			{
				throw new InvalidOperationException("Codespace range contains an unexpected token: " + tokenScanner.CurrentToken);
			}
			if (!tokenScanner.MoveNext() || !(tokenScanner.CurrentToken is HexToken hexToken2))
			{
				throw new InvalidOperationException("Codespace range contains an unexpected token: " + tokenScanner.CurrentToken);
			}
			list.Add(new CodespaceRange(hexToken.Memory, hexToken2.Memory));
		}
		builder.CodespaceRanges = list;
	}
}
