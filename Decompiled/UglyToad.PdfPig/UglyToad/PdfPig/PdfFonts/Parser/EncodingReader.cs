using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UglyToad.PdfPig.Fonts;
using UglyToad.PdfPig.Fonts.Encodings;
using UglyToad.PdfPig.Parser.Parts;
using UglyToad.PdfPig.Tokenization.Scanner;
using UglyToad.PdfPig.Tokens;

namespace UglyToad.PdfPig.PdfFonts.Parser;

internal class EncodingReader : IEncodingReader
{
	private readonly IPdfTokenScanner pdfScanner;

	public EncodingReader(IPdfTokenScanner pdfScanner)
	{
		this.pdfScanner = pdfScanner;
	}

	public Encoding? Read(DictionaryToken fontDictionary, FontDescriptor? descriptor = null, Encoding? fontEncoding = null)
	{
		if (!fontDictionary.TryGet(NameToken.Encoding, out var token))
		{
			return null;
		}
		if (DirectObjectFinder.TryGet<NameToken>(token, pdfScanner, out NameToken tokenResult))
		{
			if (TryGetNamedEncoding(descriptor, tokenResult, out Encoding encoding))
			{
				return encoding;
			}
			if (fontDictionary.TryGet<NameToken>(NameToken.BaseFont, pdfScanner, out NameToken token2))
			{
				if (string.Equals(token2.Data, "ZapfDingbats", StringComparison.OrdinalIgnoreCase))
				{
					return ZapfDingbatsEncoding.Instance;
				}
				if (string.Equals(token2.Data, "Symbol", StringComparison.OrdinalIgnoreCase))
				{
					return SymbolEncoding.Instance;
				}
				return WinAnsiEncoding.Instance;
			}
		}
		DictionaryToken encodingDictionary = DirectObjectFinder.Get<DictionaryToken>(token, pdfScanner);
		return ReadEncodingDictionary(encodingDictionary, fontEncoding);
	}

	private Encoding? ReadEncodingDictionary(DictionaryToken encodingDictionary, Encoding? fontEncoding)
	{
		if (encodingDictionary == null)
		{
			return null;
		}
		Encoding encoding;
		if (encodingDictionary.TryGet(NameToken.BaseEncoding, out var token) && token is NameToken nameToken)
		{
			if (!Encoding.TryGetNamedEncoding(nameToken, out encoding))
			{
				throw new InvalidFontFormatException($"No encoding found with name {nameToken} to use as base encoding.");
			}
		}
		else
		{
			encoding = fontEncoding ?? StandardEncoding.Instance;
		}
		if (!encodingDictionary.TryGet(NameToken.Differences, out var token2))
		{
			return encoding;
		}
		IReadOnlyList<(int, string)> differences = ProcessDifferences(DirectObjectFinder.Get<ArrayToken>(token2, pdfScanner));
		return new DifferenceBasedEncoding(encoding, differences);
	}

	private static IReadOnlyList<(int, string)> ProcessDifferences(ArrayToken differenceArray)
	{
		List<(int, string)> list = new List<(int, string)>();
		if (differenceArray.Length == 0)
		{
			return list;
		}
		int num = -1;
		foreach (IToken datum in differenceArray.Data)
		{
			if (datum is NumericToken numericToken)
			{
				num = numericToken.Int;
				continue;
			}
			if (datum is NameToken nameToken)
			{
				list.Add((num, nameToken.Data));
				num++;
				continue;
			}
			throw new InvalidFontFormatException($"Unexpected entry in the differences array: {differenceArray}.");
		}
		return list;
	}

	private static bool TryGetNamedEncoding(FontDescriptor? descriptor, NameToken encodingName, [NotNullWhen(true)] out Encoding? encoding)
	{
		encoding = null;
		if (descriptor != null && descriptor.Flags.HasFlag(FontDescriptorFlags.Symbolic))
		{
			encoding = StandardEncoding.Instance;
		}
		if (!Encoding.TryGetNamedEncoding(encodingName, out encoding))
		{
			return false;
		}
		return true;
	}
}
