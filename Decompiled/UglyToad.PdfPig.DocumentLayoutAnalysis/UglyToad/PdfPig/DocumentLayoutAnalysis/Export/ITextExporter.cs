using UglyToad.PdfPig.Content;

namespace UglyToad.PdfPig.DocumentLayoutAnalysis.Export;

public interface ITextExporter
{
	string Get(Page page);
}
