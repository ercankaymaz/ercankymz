using System.IO;
using PdfSharp.Pdf.Content.Objects;

namespace PdfSharp.Pdf.Content;

public static class ContentReader
{
	public static CSequence ReadContent(PdfPage page)
	{
		CParser cParser = new CParser(page);
		return cParser.ReadContent();
	}

	public static CSequence ReadContent(byte[] content)
	{
		CParser cParser = new CParser(content);
		return cParser.ReadContent();
	}

	public static CSequence ReadContent(MemoryStream content)
	{
		CParser cParser = new CParser(content);
		return cParser.ReadContent();
	}
}
