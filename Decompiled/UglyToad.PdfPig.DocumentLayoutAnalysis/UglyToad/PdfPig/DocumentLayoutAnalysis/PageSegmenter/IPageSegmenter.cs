using System.Collections.Generic;
using UglyToad.PdfPig.Content;

namespace UglyToad.PdfPig.DocumentLayoutAnalysis.PageSegmenter;

public interface IPageSegmenter
{
	IReadOnlyList<TextBlock> GetBlocks(IEnumerable<Word> words);
}
