using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using UglyToad.PdfPig.Content;
using UglyToad.PdfPig.Core;
using UglyToad.PdfPig.DocumentLayoutAnalysis.PageSegmenter;
using UglyToad.PdfPig.Geometry;
using UglyToad.PdfPig.Util;

namespace UglyToad.PdfPig.DocumentLayoutAnalysis;

public static class DecorationTextBlockClassifier
{
	private static readonly Regex NumbersPattern = new Regex("(\\d+)|(\\b([MDCLXVI]+)\\b)", RegexOptions.IgnoreCase);

	private const string replacementChar = "@";

	public static IReadOnlyList<IReadOnlyList<TextBlock>> Get(IReadOnlyList<Page> pages, IWordExtractor wordExtractor, IPageSegmenter pageSegmenter, double similarityThreshold = 0.25, int n = 5, int maxDegreeOfParallelism = -1)
	{
		return Get(pages, wordExtractor, pageSegmenter, Distances.MinimumEditDistanceNormalised, similarityThreshold, n, maxDegreeOfParallelism);
	}

	public static IReadOnlyList<IReadOnlyList<TextBlock>> Get(IReadOnlyList<Page> pages, IWordExtractor wordExtractor, IPageSegmenter pageSegmenter, Func<string, string, double> minimumEditDistanceNormalised, double similarityThreshold = 0.25, int n = 5, int maxDegreeOfParallelism = -1)
	{
		if (pages.Count < 2)
		{
			throw new ArgumentException("The algorithm cannot be used with a document of less than 2 pages.", "pages");
		}
		ConcurrentDictionary<int, IReadOnlyList<TextBlock>> pagesBlocks = new ConcurrentDictionary<int, IReadOnlyList<TextBlock>>();
		ParallelOptions parallelOptions = new ParallelOptions
		{
			MaxDegreeOfParallelism = maxDegreeOfParallelism
		};
		Parallel.For(0, pages.Count, parallelOptions, delegate(int p)
		{
			IEnumerable<Word> words = pages[p].GetWords(wordExtractor);
			IReadOnlyList<TextBlock> blocks = pageSegmenter.GetBlocks(words);
			if (!pagesBlocks.TryAdd(p, blocks))
			{
				throw new ArgumentException("Cannot add element with index " + p + " in ConcurrentDictionary.");
			}
		});
		return Get((from x in pagesBlocks
			orderby x.Key
			select x.Value).ToList(), minimumEditDistanceNormalised, similarityThreshold, n, maxDegreeOfParallelism);
	}

	public static IReadOnlyList<IReadOnlyList<TextBlock>> Get(IReadOnlyList<IReadOnlyList<TextBlock>> pagesTextBlocks, double similarityThreshold = 0.25, int n = 5, int maxDegreeOfParallelism = -1)
	{
		return Get(pagesTextBlocks, Distances.MinimumEditDistanceNormalised, similarityThreshold, n, maxDegreeOfParallelism);
	}

	public static IReadOnlyList<IReadOnlyList<TextBlock>> Get(IReadOnlyList<IReadOnlyList<TextBlock>> pagesTextBlocks, Func<string, string, double> minimumEditDistanceNormalised, double similarityThreshold = 0.25, int n = 5, int maxDegreeOfParallelism = -1)
	{
		if (pagesTextBlocks.Count < 2)
		{
			throw new ArgumentException("The algorithm cannot be used with a document of less than 2 pages.", "pagesTextBlocks");
		}
		ConcurrentDictionary<int, OrderedSet<TextBlock>> pageDecorations = new ConcurrentDictionary<int, OrderedSet<TextBlock>>();
		ParallelOptions parallelOptions = new ParallelOptions
		{
			MaxDegreeOfParallelism = maxDegreeOfParallelism
		};
		Parallel.For(0, pagesTextBlocks.Count, parallelOptions, delegate(int p)
		{
			if (!pageDecorations.TryAdd(p, new OrderedSet<TextBlock>()))
			{
				throw new ArgumentException("Cannot add element with index " + p + " in ConcurrentDictionary.");
			}
			int previousPageNumber = GetPreviousPageNumber(p, pagesTextBlocks.Count);
			int nextPageNumber = GetNextPageNumber(p, pagesTextBlocks.Count);
			IReadOnlyList<TextBlock> source = pagesTextBlocks[previousPageNumber];
			IReadOnlyList<TextBlock> readOnlyList = pagesTextBlocks[p];
			IReadOnlyList<TextBlock> source2 = pagesTextBlocks[nextPageNumber];
			int num = Math.Min(n, readOnlyList.Count);
			source = (from b in source
				orderby b.BoundingBox.Bottom descending, b.BoundingBox.Left
				select b).ToList();
			readOnlyList = (from b in readOnlyList
				orderby b.BoundingBox.Bottom descending, b.BoundingBox.Left
				select b).ToList();
			source2 = (from b in source2
				orderby b.BoundingBox.Bottom descending, b.BoundingBox.Left
				select b).ToList();
			for (int num2 = 0; num2 < num; num2++)
			{
				TextBlock textBlock = readOnlyList[num2];
				if (Score(textBlock, source, source2, minimumEditDistanceNormalised, similarityThreshold, n) >= similarityThreshold)
				{
					pageDecorations[p].TryAdd(textBlock);
				}
			}
			source = (from b in source
				orderby b.BoundingBox.Top, b.BoundingBox.Left
				select b).ToList();
			readOnlyList = (from b in readOnlyList
				orderby b.BoundingBox.Top, b.BoundingBox.Left
				select b).ToList();
			source2 = (from b in source2
				orderby b.BoundingBox.Top, b.BoundingBox.Left
				select b).ToList();
			for (int num3 = 0; num3 < num; num3++)
			{
				TextBlock textBlock2 = readOnlyList[num3];
				if (Score(textBlock2, source, source2, minimumEditDistanceNormalised, similarityThreshold, n) >= similarityThreshold)
				{
					pageDecorations[p].TryAdd(textBlock2);
				}
			}
			source = (from b in source
				orderby b.BoundingBox.Left, b.BoundingBox.Top
				select b).ToList();
			readOnlyList = (from b in readOnlyList
				orderby b.BoundingBox.Left, b.BoundingBox.Top
				select b).ToList();
			source2 = (from b in source2
				orderby b.BoundingBox.Left, b.BoundingBox.Top
				select b).ToList();
			for (int num4 = 0; num4 < num; num4++)
			{
				TextBlock textBlock3 = readOnlyList[num4];
				if (Score(textBlock3, source, source2, minimumEditDistanceNormalised, similarityThreshold, n) >= similarityThreshold)
				{
					pageDecorations[p].TryAdd(textBlock3);
				}
			}
			source = (from b in source
				orderby b.BoundingBox.Right descending, b.BoundingBox.Top
				select b).ToList();
			readOnlyList = (from b in readOnlyList
				orderby b.BoundingBox.Right descending, b.BoundingBox.Top
				select b).ToList();
			source2 = (from b in source2
				orderby b.BoundingBox.Right descending, b.BoundingBox.Top
				select b).ToList();
			for (int num5 = 0; num5 < num; num5++)
			{
				TextBlock textBlock4 = readOnlyList[num5];
				if (Score(textBlock4, source, source2, minimumEditDistanceNormalised, similarityThreshold, n) >= similarityThreshold)
				{
					pageDecorations[p].TryAdd(textBlock4);
				}
			}
		});
		return (from x in pageDecorations
			orderby x.Key
			select x.Value.GetList()).ToList();
	}

	private static double ContentSimilarity(TextBlock b1, TextBlock b2, Func<string, string, double> minimumEditDistanceNormalised)
	{
		return 1.0 - minimumEditDistanceNormalised(NumbersPattern.Replace(b1.Text, "@"), NumbersPattern.Replace(b2.Text, "@"));
	}

	private static double GeomSimilarity(TextBlock b1, TextBlock b2)
	{
		double result = 0.0;
		PdfRectangle? pdfRectangle = b1.BoundingBox.Intersect(b2.BoundingBox);
		if (pdfRectangle.HasValue)
		{
			result = pdfRectangle.Value.Area / Math.Max(b1.BoundingBox.Area, b2.BoundingBox.Area);
		}
		return result;
	}

	private static double Similarity(TextBlock b1, TextBlock b2, Func<string, string, double> minimumEditDistanceNormalised)
	{
		return ContentSimilarity(b1, b2, minimumEditDistanceNormalised) * GeomSimilarity(b1, b2);
	}

	private static double ScoreI(TextBlock current, TextBlock previous, TextBlock next, Func<string, string, double> minimumEditDistanceNormalised)
	{
		return 0.5 * (Similarity(current, next, minimumEditDistanceNormalised) + Similarity(current, previous, minimumEditDistanceNormalised));
	}

	private static double Score(TextBlock current, IReadOnlyList<TextBlock> previous, IReadOnlyList<TextBlock> next, Func<string, string, double> minimumEditDistanceNormalised, double threshold, int n)
	{
		n = Math.Min(n, Math.Min(previous.Count, next.Count));
		double num = 0.0;
		for (int i = 0; i < n; i++)
		{
			double num2 = ScoreI(current, previous[i], next[i], minimumEditDistanceNormalised);
			if (num2 > num)
			{
				num = num2;
			}
			if (num >= threshold)
			{
				return num;
			}
		}
		return num;
	}

	private static int GetPreviousPageNumber(int currentPage, int pagesCount)
	{
		int num = ((currentPage - 1 >= 0) ? (currentPage - 1) : (pagesCount - 1));
		if (pagesCount > 3)
		{
			num = ((num - 1 >= 0) ? (num - 1) : (pagesCount - 1));
		}
		return num;
	}

	private static int GetNextPageNumber(int currentPage, int pagesCount)
	{
		int num = ((currentPage + 1 < pagesCount) ? (currentPage + 1) : 0);
		if (pagesCount > 3)
		{
			num = ((num + 1 < pagesCount) ? (num + 1) : 0);
		}
		return num;
	}
}
