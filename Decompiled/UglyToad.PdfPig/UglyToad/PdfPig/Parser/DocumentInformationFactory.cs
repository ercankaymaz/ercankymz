using UglyToad.PdfPig.Content;
using UglyToad.PdfPig.Core;
using UglyToad.PdfPig.CrossReference;
using UglyToad.PdfPig.Parser.Parts;
using UglyToad.PdfPig.Tokenization.Scanner;
using UglyToad.PdfPig.Tokens;

namespace UglyToad.PdfPig.Parser;

internal static class DocumentInformationFactory
{
	public static DocumentInformation Create(IPdfTokenScanner pdfTokenScanner, TrailerDictionary trailer, bool isLenientParsing)
	{
		IToken token = trailer.Info;
		if (token is IndirectReferenceToken indirectReferenceToken)
		{
			token = DirectObjectFinder.Get<IToken>(indirectReferenceToken.Data, pdfTokenScanner);
		}
		if (token == null)
		{
			return DocumentInformation.Default;
		}
		if (token is DictionaryToken dictionaryToken)
		{
			string entryOrDefault = GetEntryOrDefault(dictionaryToken, NameToken.Title, pdfTokenScanner);
			string entryOrDefault2 = GetEntryOrDefault(dictionaryToken, NameToken.Author, pdfTokenScanner);
			string entryOrDefault3 = GetEntryOrDefault(dictionaryToken, NameToken.Subject, pdfTokenScanner);
			string entryOrDefault4 = GetEntryOrDefault(dictionaryToken, NameToken.Keywords, pdfTokenScanner);
			string entryOrDefault5 = GetEntryOrDefault(dictionaryToken, NameToken.Creator, pdfTokenScanner);
			string entryOrDefault6 = GetEntryOrDefault(dictionaryToken, NameToken.Producer, pdfTokenScanner);
			string entryOrDefault7 = GetEntryOrDefault(dictionaryToken, NameToken.CreationDate, pdfTokenScanner);
			string entryOrDefault8 = GetEntryOrDefault(dictionaryToken, NameToken.ModDate, pdfTokenScanner);
			return new DocumentInformation(dictionaryToken, entryOrDefault, entryOrDefault2, entryOrDefault3, entryOrDefault4, entryOrDefault5, entryOrDefault6, entryOrDefault7, entryOrDefault8);
		}
		if (token is StreamToken streamToken)
		{
			DictionaryToken streamDictionary = streamToken.StreamDictionary;
			if (!streamDictionary.TryGet(NameToken.Type, out NameToken token2) || token2 != "Metadata")
			{
				throw new PdfDocumentFormatException("Unknown document metadata type was found");
			}
			if (!streamDictionary.TryGet(NameToken.Subtype, out NameToken token3) || token3 != "XML")
			{
				throw new PdfDocumentFormatException("Unknown document metadata subtype was found");
			}
			return DocumentInformation.Default;
		}
		if (isLenientParsing)
		{
			return DocumentInformation.Default;
		}
		throw new PdfDocumentFormatException("Unknown document information token was found " + token?.GetType().Name);
	}

	private static string? GetEntryOrDefault(DictionaryToken infoDictionary, NameToken key, IPdfTokenScanner pdfTokenScanner)
	{
		if (infoDictionary == null)
		{
			return null;
		}
		if (!infoDictionary.TryGet(key, out var token))
		{
			return null;
		}
		if (token is IndirectReferenceToken token2)
		{
			if (DirectObjectFinder.TryGet<StringToken>(token2, pdfTokenScanner, out StringToken tokenResult))
			{
				return tokenResult.Data;
			}
			if (DirectObjectFinder.TryGet<HexToken>(token2, pdfTokenScanner, out HexToken tokenResult2))
			{
				return tokenResult2.Data;
			}
			return null;
		}
		if (token is StringToken stringToken)
		{
			return stringToken.Data;
		}
		if (token is HexToken hexToken)
		{
			return hexToken.Data;
		}
		return null;
	}
}
