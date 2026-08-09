using System;
using UglyToad.PdfPig.Core;
using UglyToad.PdfPig.Tokenization.Scanner;
using UglyToad.PdfPig.Tokens;
using UglyToad.PdfPig.Util;

namespace UglyToad.PdfPig.PdfFonts.Parser.Parts;

internal static class FontDescriptorFactory
{
	public static FontDescriptor Generate(DictionaryToken dictionary, IPdfTokenScanner pdfScanner)
	{
		if (dictionary == null)
		{
			throw new ArgumentNullException("dictionary");
		}
		NameToken fontName = GetFontName(dictionary, pdfScanner);
		string fontFamily = GetFontFamily(dictionary);
		FontStretch fontStretch = GetFontStretch(dictionary);
		FontDescriptorFlags flags = GetFlags(dictionary);
		PdfRectangle boundingBox = GetBoundingBox(dictionary, pdfScanner);
		string charSet = GetCharSet(dictionary);
		DescriptorFontFile fontFile = GetFontFile(dictionary);
		return new FontDescriptor.Builder(fontName, flags)
		{
			FontFamily = fontFamily,
			Stretch = fontStretch,
			FontWeight = GetDoubleOrDefault(dictionary, NameToken.FontWeight),
			BoundingBox = boundingBox,
			ItalicAngle = GetDoubleOrDefault(dictionary, NameToken.ItalicAngle),
			Ascent = GetDoubleOrDefault(dictionary, NameToken.Ascent),
			Descent = GetDoubleOrDefault(dictionary, NameToken.Descent),
			Leading = GetDoubleOrDefault(dictionary, NameToken.Leading),
			CapHeight = Math.Abs(GetDoubleOrDefault(dictionary, NameToken.CapHeight)),
			XHeight = Math.Abs(GetDoubleOrDefault(dictionary, NameToken.Xheight)),
			StemVertical = GetDoubleOrDefault(dictionary, NameToken.StemV),
			StemHorizontal = GetDoubleOrDefault(dictionary, NameToken.StemH),
			AverageWidth = GetDoubleOrDefault(dictionary, NameToken.AvgWidth),
			MaxWidth = GetDoubleOrDefault(dictionary, NameToken.MaxWidth),
			MissingWidth = GetDoubleOrDefault(dictionary, NameToken.MissingWidth),
			FontFile = fontFile,
			CharSet = charSet
		}.Build();
	}

	private static double GetDoubleOrDefault(DictionaryToken dictionary, NameToken name)
	{
		if (!dictionary.TryGet(name, out var token) || !(token is NumericToken numericToken))
		{
			return 0.0;
		}
		return numericToken.Data;
	}

	private static NameToken GetFontName(DictionaryToken dictionary, IPdfTokenScanner scanner)
	{
		if (!dictionary.TryGet<NameToken>(NameToken.FontName, scanner, out NameToken token))
		{
			return NameToken.Create(string.Empty);
		}
		return token;
	}

	private static string GetFontFamily(DictionaryToken dictionary)
	{
		if (dictionary.TryGet(NameToken.FontFamily, out var token) && token is StringToken stringToken)
		{
			return stringToken.Data;
		}
		return string.Empty;
	}

	private static FontStretch GetFontStretch(DictionaryToken dictionary)
	{
		if (!dictionary.TryGet(NameToken.FontStretch, out var token) || !(token is NameToken name))
		{
			return FontStretch.Normal;
		}
		return name.ConvertToFontStretch();
	}

	private static FontDescriptorFlags GetFlags(DictionaryToken dictionary)
	{
		int num = dictionary.GetIntOrDefault(NameToken.Flags, -1);
		if (num == -1)
		{
			num = 0;
		}
		return (FontDescriptorFlags)num;
	}

	private static PdfRectangle GetBoundingBox(DictionaryToken dictionary, IPdfTokenScanner pdfScanner)
	{
		if (!dictionary.TryGet(NameToken.FontBbox, out var token) || !(token is ArrayToken arrayToken))
		{
			return new PdfRectangle(0, 0, 0, 0);
		}
		if (arrayToken.Data.Count != 4)
		{
			return new PdfRectangle(0, 0, 0, 0);
		}
		return arrayToken.ToRectangle(pdfScanner);
	}

	private static string? GetCharSet(DictionaryToken dictionary)
	{
		if (!dictionary.TryGet(NameToken.CharSet, out var token) || !(token is NameToken nameToken))
		{
			return null;
		}
		return nameToken.Data;
	}

	private static DescriptorFontFile? GetFontFile(DictionaryToken dictionary)
	{
		if (dictionary.TryGet(NameToken.FontFile, out var token))
		{
			return new DescriptorFontFile((token as IndirectReferenceToken) ?? throw new NotSupportedException("We currently expect the FontFile to be an object reference."), DescriptorFontFile.FontFileType.Type1);
		}
		if (dictionary.TryGet(NameToken.FontFile2, out token))
		{
			return new DescriptorFontFile((token as IndirectReferenceToken) ?? throw new NotSupportedException("We currently expect the FontFile2 to be an object reference."), DescriptorFontFile.FontFileType.TrueType);
		}
		if (dictionary.TryGet(NameToken.FontFile3, out token))
		{
			return new DescriptorFontFile((token as IndirectReferenceToken) ?? throw new NotSupportedException("We currently expect the FontFile3 to be an object reference."), DescriptorFontFile.FontFileType.FromSubtype);
		}
		return null;
	}
}
