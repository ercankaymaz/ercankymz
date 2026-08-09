namespace UglyToad.PdfPig.DocumentLayoutAnalysis.PageSegmenter;

public interface IPageSegmenterOptions : IDlaOptions
{
	string WordSeparator { get; set; }

	string LineSeparator { get; set; }
}
