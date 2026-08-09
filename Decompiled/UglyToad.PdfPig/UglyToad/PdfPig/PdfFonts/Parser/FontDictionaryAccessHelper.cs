using UglyToad.PdfPig.Fonts;
using UglyToad.PdfPig.Parser.Parts;
using UglyToad.PdfPig.PdfFonts.Parser.Parts;
using UglyToad.PdfPig.Tokenization.Scanner;
using UglyToad.PdfPig.Tokens;

namespace UglyToad.PdfPig.PdfFonts.Parser;

internal static class FontDictionaryAccessHelper
{
	public static int GetFirstCharacter(DictionaryToken dictionary)
	{
		if (!dictionary.TryGet(NameToken.FirstChar, out var token) || !(token is NumericToken numericToken))
		{
			throw new InvalidFontFormatException($"No first character entry was found in the font dictionary for this TrueType font: {dictionary}.");
		}
		return numericToken.Int;
	}

	public static int GetLastCharacter(DictionaryToken dictionary)
	{
		if (!dictionary.TryGet(NameToken.LastChar, out var token) || !(token is NumericToken numericToken))
		{
			throw new InvalidFontFormatException($"No first character entry was found in the font dictionary for this TrueType font: {dictionary}.");
		}
		return numericToken.Int;
	}

	public static double[] GetWidths(IPdfTokenScanner pdfScanner, DictionaryToken dictionary)
	{
		if (!dictionary.TryGet(NameToken.Widths, out var token))
		{
			throw new InvalidFontFormatException($"No widths array found for the font: {dictionary}.");
		}
		ArrayToken arrayToken = DirectObjectFinder.Get<ArrayToken>(token, pdfScanner);
		double[] array = new double[arrayToken.Data.Count];
		for (int i = 0; i < arrayToken.Data.Count; i++)
		{
			IToken token2 = arrayToken.Data[i];
			if (!(token2 is NumericToken numericToken))
			{
				throw new InvalidFontFormatException($"Token which was not a number found in the widths array: {token2}.");
			}
			array[i] = numericToken.Double;
		}
		return array;
	}

	public static FontDescriptor GetFontDescriptor(IPdfTokenScanner pdfScanner, DictionaryToken dictionary)
	{
		if (!dictionary.TryGet<DictionaryToken>(NameToken.FontDescriptor, pdfScanner, out DictionaryToken token))
		{
			throw new InvalidFontFormatException($"No font descriptor indirect reference found in the TrueType font: {dictionary}.");
		}
		return FontDescriptorFactory.Generate(token, pdfScanner);
	}

	public static NameToken GetName(IPdfTokenScanner pdfScanner, DictionaryToken dictionary, FontDescriptor descriptor)
	{
		if (dictionary.TryGet(NameToken.BaseFont, out var token))
		{
			return DirectObjectFinder.Get<NameToken>(token, pdfScanner);
		}
		if (descriptor.FontName != null)
		{
			return descriptor.FontName;
		}
		throw new InvalidFontFormatException($"Could not find a name for this font {dictionary}.");
	}
}
