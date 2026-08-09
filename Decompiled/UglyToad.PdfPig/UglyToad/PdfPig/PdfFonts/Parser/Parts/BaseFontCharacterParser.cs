using System;
using UglyToad.PdfPig.PdfFonts.Cmap;
using UglyToad.PdfPig.Tokenization.Scanner;
using UglyToad.PdfPig.Tokens;

namespace UglyToad.PdfPig.PdfFonts.Parser.Parts;

internal class BaseFontCharacterParser : ICidFontPartParser<NumericToken>
{
	public void Parse(NumericToken numeric, ITokenScanner tokenScanner, CharacterMapBuilder builder)
	{
		for (int i = 0; i < numeric.Int; i++)
		{
			if (!tokenScanner.MoveNext() || !(tokenScanner.CurrentToken is HexToken hexToken))
			{
				if (tokenScanner.CurrentToken is OperatorToken operatorToken && (string.Equals(operatorToken.Data, "endbfchar", StringComparison.OrdinalIgnoreCase) || string.Equals(operatorToken.Data, "endcmap", StringComparison.OrdinalIgnoreCase)))
				{
					break;
				}
				throw new InvalidOperationException($"Base font characters definition contains invalid item at index {i}: {tokenScanner.CurrentToken}");
			}
			if (!tokenScanner.MoveNext())
			{
				throw new InvalidOperationException($"Base font characters definition contains invalid item at index {i}: {tokenScanner.CurrentToken}");
			}
			if (tokenScanner.CurrentToken is NameToken nameToken)
			{
				builder.AddBaseFontCharacter(hexToken.Bytes, nameToken.Data);
				continue;
			}
			if (tokenScanner.CurrentToken is HexToken hexToken2)
			{
				builder.AddBaseFontCharacter(hexToken.Bytes, hexToken2.Bytes);
				continue;
			}
			throw new InvalidOperationException($"Base font characters definition contains invalid item at index {i}: {tokenScanner.CurrentToken}");
		}
	}
}
