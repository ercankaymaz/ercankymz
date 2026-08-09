using System;
using System.Xml.Linq;
using UglyToad.PdfPig.Core;
using UglyToad.PdfPig.Filters;
using UglyToad.PdfPig.Tokenization.Scanner;
using UglyToad.PdfPig.Tokens;

namespace UglyToad.PdfPig.Content;

public class XmpMetadata
{
	private readonly ILookupFilterProvider filterProvider;

	private readonly IPdfTokenScanner pdfTokenScanner;

	public StreamToken MetadataStreamToken { get; }

	internal XmpMetadata(StreamToken stream, ILookupFilterProvider filterProvider, IPdfTokenScanner pdfTokenScanner)
	{
		this.filterProvider = filterProvider ?? throw new ArgumentNullException("filterProvider");
		this.pdfTokenScanner = pdfTokenScanner;
		MetadataStreamToken = stream ?? throw new ArgumentNullException("stream");
	}

	public ReadOnlySpan<byte> GetXmlBytes()
	{
		return MetadataStreamToken.Decode(filterProvider, pdfTokenScanner).Span;
	}

	public XDocument GetXDocument()
	{
		return XDocument.Parse(OtherEncodings.BytesAsLatin1String(GetXmlBytes()));
	}
}
