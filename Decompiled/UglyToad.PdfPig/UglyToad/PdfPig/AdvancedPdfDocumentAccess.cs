using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UglyToad.PdfPig.Content;
using UglyToad.PdfPig.Core;
using UglyToad.PdfPig.Filters;
using UglyToad.PdfPig.Parser.Parts;
using UglyToad.PdfPig.Tokenization.Scanner;
using UglyToad.PdfPig.Tokens;

namespace UglyToad.PdfPig;

public class AdvancedPdfDocumentAccess : IDisposable
{
	private readonly IPdfTokenScanner pdfScanner;

	private readonly ILookupFilterProvider filterProvider;

	private readonly Catalog catalog;

	private bool isDisposed;

	internal AdvancedPdfDocumentAccess(IPdfTokenScanner pdfScanner, ILookupFilterProvider filterProvider, Catalog catalog)
	{
		this.pdfScanner = pdfScanner ?? throw new ArgumentNullException("pdfScanner");
		this.filterProvider = filterProvider ?? throw new ArgumentNullException("filterProvider");
		this.catalog = catalog ?? throw new ArgumentNullException("catalog");
	}

	public bool TryGetEmbeddedFiles([NotNullWhen(true)] out IReadOnlyList<EmbeddedFile>? embeddedFiles)
	{
		GuardDisposed();
		embeddedFiles = null;
		if (!catalog.CatalogDictionary.TryGet<DictionaryToken>(NameToken.Names, pdfScanner, out DictionaryToken token) || !token.TryGet<DictionaryToken>(NameToken.EmbeddedFiles, pdfScanner, out DictionaryToken token2))
		{
			return false;
		}
		IReadOnlyDictionary<string, IToken> readOnlyDictionary = NameTreeParser.FlattenNameTreeToDictionary(token2, pdfScanner, (IToken x) => x);
		if (readOnlyDictionary.Count == 0)
		{
			return false;
		}
		List<EmbeddedFile> list = new List<EmbeddedFile>();
		foreach (KeyValuePair<string, IToken> item in readOnlyDictionary)
		{
			if (DirectObjectFinder.TryGet<DictionaryToken>(item.Value, pdfScanner, out DictionaryToken tokenResult) && tokenResult.TryGet<DictionaryToken>(NameToken.Ef, pdfScanner, out DictionaryToken token3) && token3.TryGet<StreamToken>(NameToken.F, pdfScanner, out StreamToken token4))
			{
				string fileSpecification = string.Empty;
				if (tokenResult.TryGet<IDataToken<string>>(NameToken.F, pdfScanner, out IDataToken<string> token5))
				{
					fileSpecification = token5.Data;
				}
				Memory<byte> memory = token4.Decode(filterProvider, pdfScanner);
				list.Add(new EmbeddedFile(item.Key, fileSpecification, memory, token4));
			}
		}
		embeddedFiles = list;
		return embeddedFiles.Count > 0;
	}

	public void ReplaceIndirectObject(IndirectReference reference, Func<IToken, IToken> replacer)
	{
		ObjectToken objectToken = pdfScanner.Get(reference);
		IToken token = replacer(objectToken.Data);
		pdfScanner.ReplaceToken(reference, token);
	}

	public void ReplaceIndirectObject(IndirectReference reference, IToken replacement)
	{
		pdfScanner.ReplaceToken(reference, replacement);
	}

	private void GuardDisposed()
	{
		if (isDisposed)
		{
			throw new ObjectDisposedException("AdvancedPdfDocumentAccess");
		}
	}

	public void Dispose()
	{
		pdfScanner?.Dispose();
		isDisposed = true;
	}
}
