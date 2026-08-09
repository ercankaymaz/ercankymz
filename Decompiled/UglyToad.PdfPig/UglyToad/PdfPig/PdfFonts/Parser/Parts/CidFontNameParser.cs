using System.Globalization;
using UglyToad.PdfPig.PdfFonts.Cmap;
using UglyToad.PdfPig.Tokenization.Scanner;
using UglyToad.PdfPig.Tokens;

namespace UglyToad.PdfPig.PdfFonts.Parser.Parts;

internal class CidFontNameParser : ICidFontPartParser<NameToken>
{
	public void Parse(NameToken nameToken, ITokenScanner scanner, CharacterMapBuilder builder)
	{
		string data = nameToken.Data;
		if (data == null)
		{
			return;
		}
		switch (data.Length)
		{
		case 8:
			switch (data[4])
			{
			case 'N':
			{
				if (data == "CMapName" && scanner.TryReadToken<NameToken>(out var token4))
				{
					builder.Name = token4.Data;
				}
				break;
			}
			case 'T':
			{
				if (data == "CMapType" && scanner.TryReadToken<NumericToken>(out var token3))
				{
					builder.Type = token3.Int;
				}
				break;
			}
			case 's':
			{
				if (data == "Registry" && scanner.TryReadToken<StringToken>(out var token5))
				{
					builder.SystemInfoBuilder.Registry = token5.Data;
				}
				break;
			}
			case 'r':
			{
				if (data == "Ordering" && scanner.TryReadToken<StringToken>(out var token2))
				{
					builder.SystemInfoBuilder.Ordering = token2.Data;
				}
				break;
			}
			}
			break;
		case 5:
		{
			if (data == "WMode" && scanner.TryReadToken<NumericToken>(out var token7))
			{
				builder.WMode = token7.Int;
			}
			break;
		}
		case 11:
			if (data == "CMapVersion" && scanner.MoveNext())
			{
				IToken currentToken = scanner.CurrentToken;
				if (currentToken is NumericToken numericToken)
				{
					builder.Version = numericToken.Data.ToString(NumberFormatInfo.InvariantInfo);
				}
				else if (currentToken is StringToken stringToken)
				{
					builder.Version = stringToken.Data;
				}
			}
			break;
		case 10:
		{
			if (data == "Supplement" && scanner.TryReadToken<NumericToken>(out var token6))
			{
				builder.SystemInfoBuilder.Supplement = token6.Int;
			}
			break;
		}
		case 13:
		{
			if (data == "CIDSystemInfo" && scanner.TryReadToken<DictionaryToken>(out var token))
			{
				builder.CharacterIdentifierSystemInfo = GetCharacterIdentifier(token);
			}
			break;
		}
		case 6:
		case 7:
		case 9:
		case 12:
			break;
		}
	}

	private static CharacterIdentifierSystemInfo GetCharacterIdentifier(DictionaryToken dictionary)
	{
		StringToken stringToken;
		if (dictionary.TryGet(NameToken.Registry, out var token))
		{
			stringToken = token as StringToken;
			if (stringToken != null)
			{
				goto IL_0025;
			}
		}
		stringToken = new StringToken("Adobe");
		goto IL_0025;
		IL_004a:
		NumericToken numericToken;
		if (dictionary.TryGet(NameToken.Supplement, out var token2))
		{
			numericToken = token2 as NumericToken;
			if (numericToken != null)
			{
				goto IL_006e;
			}
		}
		numericToken = new NumericToken(0);
		goto IL_006e;
		IL_006e:
		StringToken stringToken2;
		return new CharacterIdentifierSystemInfo(stringToken.Data, stringToken2.Data, numericToken.Int);
		IL_0025:
		if (dictionary.TryGet(NameToken.Ordering, out var token3))
		{
			stringToken2 = token3 as StringToken;
			if (stringToken2 != null)
			{
				goto IL_004a;
			}
		}
		stringToken2 = new StringToken(string.Empty);
		goto IL_004a;
	}
}
