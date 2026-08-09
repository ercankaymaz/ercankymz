using System;
using UglyToad.PdfPig.Content;
using UglyToad.PdfPig.Core;
using UglyToad.PdfPig.Tokenization.Scanner;
using UglyToad.PdfPig.Tokens;

namespace UglyToad.PdfPig;

public class Structure
{
	public Catalog Catalog { get; }

	internal IPdfTokenScanner TokenScanner { get; }

	internal Structure(Catalog catalog, IPdfTokenScanner scanner)
	{
		Catalog = catalog ?? throw new ArgumentNullException("catalog");
		TokenScanner = scanner ?? throw new ArgumentNullException("scanner");
	}

	public ObjectToken GetObject(IndirectReference reference)
	{
		return TokenScanner.Get(reference) ?? throw new InvalidOperationException($"Could not find the object with reference: {reference}.");
	}
}
