using System.Collections.Generic;

namespace UglyToad.PdfPig.DocumentLayoutAnalysis.ReadingOrderDetector;

public interface IReadingOrderDetector
{
	IEnumerable<TextBlock> Get(IReadOnlyList<TextBlock> textBlocks);
}
