using System;
using System.Collections.Generic;
using System.Linq;
using UglyToad.PdfPig.Content;
using UglyToad.PdfPig.Core;
using UglyToad.PdfPig.DocumentLayoutAnalysis.ReadingOrderDetector;
using UglyToad.PdfPig.Geometry;

namespace UglyToad.PdfPig.DocumentLayoutAnalysis.PageSegmenter;

internal class XYLeaf : XYNode
{
	public override bool IsLeaf => true;

	public IReadOnlyList<Word> Words { get; }

	public override int CountWords()
	{
		return Words?.Count ?? 0;
	}

	public override List<XYLeaf> GetLeaves()
	{
		return null;
	}

	public IReadOnlyList<TextLine> GetLines(string wordSeparator)
	{
		return (from x in Words
			group x by x.BoundingBox.Bottom into x
			select new TextLine(x.OrderByReadingOrder(), wordSeparator)).OrderByReadingOrder();
	}

	public XYLeaf(params Word[] words)
		: this(words?.ToList())
	{
	}

	public XYLeaf(IEnumerable<Word> words)
		: base((XYNode[])null)
	{
		if (words == null)
		{
			throw new ArgumentException("XYLeaf(): The words contained in the leaf cannot be null.", "words");
		}
		List<PdfRectangle> source = words.Select((Word b) => b.BoundingBox.Normalise()).ToList();
		base.BoundingBox = new PdfRectangle(source.Min((PdfRectangle b) => b.Left), source.Min((PdfRectangle b) => b.Bottom), source.Max((PdfRectangle b) => b.Right), source.Max((PdfRectangle b) => b.Top));
		Words = words.ToArray();
	}
}
