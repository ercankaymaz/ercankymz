using System.Collections.Generic;

namespace UglyToad.PdfPig.DocumentLayoutAnalysis.ReadingOrderDetector;

public class DefaultReadingOrderDetector : IReadingOrderDetector
{
	public static DefaultReadingOrderDetector Instance { get; } = new DefaultReadingOrderDetector();

	public IEnumerable<TextBlock> Get(IReadOnlyList<TextBlock> textBlocks)
	{
		return textBlocks;
	}
}
