using System;
using System.Collections.Generic;
using System.Linq;
using UglyToad.PdfPig.Content;
using UglyToad.PdfPig.Core;
using UglyToad.PdfPig.Geometry;

namespace UglyToad.PdfPig.DocumentLayoutAnalysis.PageSegmenter;

public class RecursiveXYCut : IPageSegmenter
{
	private struct Projection
	{
		public double UpperBound { get; set; }

		public double LowerBound { get; set; }

		public Projection(double lowerBound, double upperBound)
		{
			UpperBound = upperBound;
			LowerBound = lowerBound;
		}

		public bool Contains(double value)
		{
			if (value >= LowerBound)
			{
				return value <= UpperBound;
			}
			return false;
		}
	}

	public class RecursiveXYCutOptions : IPageSegmenterOptions, IDlaOptions
	{
		public int MaxDegreeOfParallelism { get; set; } = -1;

		public string WordSeparator { get; set; } = " ";

		public string LineSeparator { get; set; } = "\n";

		public double MinimumWidth { get; set; } = 1.0;

		public Func<IEnumerable<Letter>, double> DominantFontWidthFunc { get; set; } = delegate(IEnumerable<Letter> letters)
		{
			IEnumerable<double> enumerable = letters.Select((Letter x) => Math.Max(Math.Round(x.Width, 3), Math.Round(x.GlyphRectangle.Width, 3)));
			double num = enumerable.Mode();
			if (double.IsNaN(num) || num == 0.0)
			{
				num = enumerable.Average();
			}
			return num;
		};

		public Func<IEnumerable<Letter>, double> DominantFontHeightFunc { get; set; } = delegate(IEnumerable<Letter> letters)
		{
			IEnumerable<double> enumerable = letters.Select((Letter x) => Math.Round(x.GlyphRectangle.Height, 3));
			double num = enumerable.Mode();
			if (double.IsNaN(num) || num == 0.0)
			{
				num = enumerable.Average();
			}
			return num * 1.5;
		};
	}

	private readonly RecursiveXYCutOptions options;

	public static RecursiveXYCut Instance { get; } = new RecursiveXYCut();

	public RecursiveXYCut()
		: this(new RecursiveXYCutOptions())
	{
	}

	public RecursiveXYCut(RecursiveXYCutOptions options)
	{
		this.options = options ?? throw new ArgumentNullException("options");
	}

	public IReadOnlyList<TextBlock> GetBlocks(IEnumerable<Word> words)
	{
		if (words == null || !words.Any())
		{
			return Array.Empty<TextBlock>();
		}
		return GetBlocks(words, options.MinimumWidth, options.DominantFontWidthFunc, options.DominantFontHeightFunc, options.WordSeparator, options.LineSeparator);
	}

	private IReadOnlyList<TextBlock> GetBlocks(IEnumerable<Word> words, double minimumWidth, Func<IEnumerable<Letter>, double> dominantFontWidthFunc, Func<IEnumerable<Letter>, double> dominantFontHeightFunc, string wordSeparator, string lineSeparator)
	{
		words = words.Where((Word w) => !string.IsNullOrWhiteSpace(w.Text));
		if (!words.Any())
		{
			return Array.Empty<TextBlock>();
		}
		XYLeaf leaf = new XYLeaf(words);
		XYNode xYNode = VerticalCut(leaf, minimumWidth, dominantFontWidthFunc, dominantFontHeightFunc);
		if (xYNode.IsLeaf)
		{
			return new List<TextBlock>
			{
				new TextBlock((xYNode as XYLeaf).GetLines(wordSeparator), lineSeparator)
			};
		}
		List<XYLeaf> leaves = xYNode.GetLeaves();
		if (leaves.Count > 0)
		{
			return leaves.ConvertAll((XYLeaf l) => new TextBlock(l.GetLines(wordSeparator), lineSeparator));
		}
		return new List<TextBlock>();
	}

	private XYNode VerticalCut(XYLeaf leaf, double minimumWidth, Func<IEnumerable<Letter>, double> dominantFontWidthFunc, Func<IEnumerable<Letter>, double> dominantFontHeightFunc, int level = 0)
	{
		Word[] array = leaf.Words.OrderBy((Word w) => w.BoundingBox.Normalise().Left).ToArray();
		if (array.Length == 0)
		{
			return new XYNode((XYNode[])null);
		}
		leaf = new XYLeaf(array);
		if (leaf.CountWords() <= 1 || leaf.BoundingBox.Width <= minimumWidth)
		{
			return leaf;
		}
		double num = dominantFontWidthFunc(array.SelectMany((Word x) => x.Letters));
		List<Projection> list = new List<Projection>();
		PdfRectangle pdfRectangle = array[0].BoundingBox.Normalise();
		Projection item = new Projection(pdfRectangle.Left, pdfRectangle.Right);
		int num2 = array.Length;
		for (int num3 = 1; num3 < num2; num3++)
		{
			PdfRectangle pdfRectangle2 = array[num3].BoundingBox.Normalise();
			if (item.Contains(pdfRectangle2.Left) || item.Contains(pdfRectangle2.Right))
			{
				if (pdfRectangle2.Left >= item.LowerBound && pdfRectangle2.Left <= item.UpperBound && pdfRectangle2.Right > item.UpperBound)
				{
					item.UpperBound = pdfRectangle2.Right;
				}
			}
			else if (pdfRectangle2.Left - item.UpperBound <= num)
			{
				item.UpperBound = pdfRectangle2.Right;
			}
			else if (item.UpperBound - item.LowerBound < minimumWidth)
			{
				item.UpperBound = pdfRectangle2.Right;
			}
			else if (num3 != num2 - 1)
			{
				list.Add(item);
				item = new Projection(pdfRectangle2.Left, pdfRectangle2.Right);
			}
			if (num3 == num2 - 1)
			{
				list.Add(item);
			}
		}
		IEnumerable<IEnumerable<Word>> source = list.Select((Projection p) => leaf.Words.Where(delegate(Word w)
		{
			PdfRectangle pdfRectangle3 = w.BoundingBox.Normalise();
			return pdfRectangle3.Left >= p.LowerBound && pdfRectangle3.Right <= p.UpperBound;
		}));
		List<XYNode> list2 = (from e in source
			where e.Any()
			select new XYLeaf(e) into l
			select HorizontalCut(l, minimumWidth, dominantFontWidthFunc, dominantFontHeightFunc, level)).ToList();
		List<Word> list3 = (from x in leaf.Words.Except(source.SelectMany((IEnumerable<Word> x) => x))
			where !string.IsNullOrWhiteSpace(x.Text)
			select x).ToList();
		if (list3.Count > 0)
		{
			list2.AddRange(list3.Select((Word w) => new XYLeaf(w)));
		}
		return new XYNode(list2);
	}

	private XYNode HorizontalCut(XYLeaf leaf, double minimumWidth, Func<IEnumerable<Letter>, double> dominantFontWidthFunc, Func<IEnumerable<Letter>, double> dominantFontHeightFunc, int level = 0)
	{
		Word[] array = leaf.Words.OrderBy((Word w) => w.BoundingBox.Normalise().Bottom).ToArray();
		if (array.Length == 0)
		{
			return new XYNode((XYNode[])null);
		}
		leaf = new XYLeaf(array);
		if (leaf.CountWords() <= 1)
		{
			return leaf;
		}
		double num = dominantFontHeightFunc(array.SelectMany((Word x) => x.Letters));
		List<Projection> list = new List<Projection>();
		PdfRectangle pdfRectangle = array[0].BoundingBox.Normalise();
		Projection item = new Projection(pdfRectangle.Bottom, pdfRectangle.Top);
		int num2 = array.Length;
		for (int num3 = 1; num3 < num2; num3++)
		{
			PdfRectangle pdfRectangle2 = array[num3].BoundingBox.Normalise();
			if (item.Contains(pdfRectangle2.Bottom) || item.Contains(pdfRectangle2.Top))
			{
				if (pdfRectangle2.Bottom >= item.LowerBound && pdfRectangle2.Bottom <= item.UpperBound && pdfRectangle2.Top > item.UpperBound)
				{
					item.UpperBound = pdfRectangle2.Top;
				}
			}
			else if (pdfRectangle2.Bottom - item.UpperBound <= num)
			{
				item.UpperBound = pdfRectangle2.Top;
			}
			else if (num3 != num2 - 1)
			{
				list.Add(item);
				item = new Projection(pdfRectangle2.Bottom, pdfRectangle2.Top);
			}
			if (num3 == num2 - 1)
			{
				list.Add(item);
			}
		}
		if (list.Count == 1)
		{
			if (level >= 1)
			{
				return leaf;
			}
			level++;
		}
		IEnumerable<IEnumerable<Word>> source = list.Select((Projection p) => leaf.Words.Where(delegate(Word w)
		{
			PdfRectangle pdfRectangle3 = w.BoundingBox.Normalise();
			return pdfRectangle3.Bottom >= p.LowerBound && pdfRectangle3.Top <= p.UpperBound;
		}));
		List<XYNode> list2 = (from e in source
			where e.Any()
			select new XYLeaf(e) into l
			select VerticalCut(l, minimumWidth, dominantFontWidthFunc, dominantFontHeightFunc, level)).ToList();
		List<Word> list3 = (from x in leaf.Words.Except(source.SelectMany((IEnumerable<Word> x) => x))
			where !string.IsNullOrWhiteSpace(x.Text)
			select x).ToList();
		if (list3.Count > 0)
		{
			list2.AddRange(list3.Select((Word w) => new XYLeaf(w)));
		}
		return new XYNode(list2);
	}
}
