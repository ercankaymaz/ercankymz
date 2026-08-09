using System.Collections.Generic;
using System.Linq;
using UglyToad.PdfPig.Content;

namespace UglyToad.PdfPig.DocumentLayoutAnalysis.ReadingOrderDetector;

public class RenderingReadingOrderDetector : IReadingOrderDetector
{
	public static RenderingReadingOrderDetector Instance { get; } = new RenderingReadingOrderDetector();

	public IEnumerable<TextBlock> Get(IReadOnlyList<TextBlock> textBlocks)
	{
		int readingOrder = 0;
		foreach (TextBlock item in textBlocks.OrderBy((TextBlock b) => AvgTextSequence(b)))
		{
			item.SetReadingOrder(readingOrder++);
			yield return item;
		}
	}

	private double AvgTextSequence(TextBlock textBlock)
	{
		return (from l in textBlock.TextLines.SelectMany((TextLine tl) => tl.Words).SelectMany((Word w) => w.Letters)
			select l.TextSequence).Average();
	}
}
