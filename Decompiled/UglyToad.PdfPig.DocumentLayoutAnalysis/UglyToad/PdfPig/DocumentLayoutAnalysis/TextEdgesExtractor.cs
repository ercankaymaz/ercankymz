using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UglyToad.PdfPig.Content;
using UglyToad.PdfPig.Core;

namespace UglyToad.PdfPig.DocumentLayoutAnalysis;

public static class TextEdgesExtractor
{
	private static readonly Tuple<EdgeType, Func<PdfRectangle, double>>[] edgesFuncs = new Tuple<EdgeType, Func<PdfRectangle, double>>[3]
	{
		Tuple.Create<EdgeType, Func<PdfRectangle, double>>(EdgeType.Left, (PdfRectangle x) => Math.Round(x.Left, 0)),
		Tuple.Create<EdgeType, Func<PdfRectangle, double>>(EdgeType.Mid, (PdfRectangle x) => Math.Round(x.Left + x.Width / 2.0, 0)),
		Tuple.Create<EdgeType, Func<PdfRectangle, double>>(EdgeType.Right, (PdfRectangle x) => Math.Round(x.Right, 0))
	};

	public static IReadOnlyDictionary<EdgeType, List<PdfLine>> GetEdges(IEnumerable<Word> pageWords, int minimumElements = 4, int maxDegreeOfParallelism = -1)
	{
		if (minimumElements < 0)
		{
			throw new ArgumentException("TextEdgesExtractor.GetEdges(): The minimum number of elements should be positive.", "minimumElements");
		}
		IEnumerable<Word> cleanWords = pageWords.Where((Word x) => !string.IsNullOrWhiteSpace(x.Text.Trim()));
		ConcurrentDictionary<EdgeType, List<PdfLine>> dictionary = new ConcurrentDictionary<EdgeType, List<PdfLine>>();
		ParallelOptions parallelOptions = new ParallelOptions
		{
			MaxDegreeOfParallelism = maxDegreeOfParallelism
		};
		Parallel.ForEach(edgesFuncs, parallelOptions, delegate(Tuple<EdgeType, Func<PdfRectangle, double>> f)
		{
			dictionary.TryAdd(f.Item1, GetVerticalEdges(cleanWords, f.Item2, minimumElements));
		});
		return dictionary.ToDictionary((KeyValuePair<EdgeType, List<PdfLine>> x) => x.Key, (KeyValuePair<EdgeType, List<PdfLine>> x) => x.Value);
	}

	private static List<PdfLine> GetVerticalEdges(IEnumerable<Word> pageWords, Func<PdfRectangle, double> func, int minimumElements)
	{
		Dictionary<double, List<Word>> dictionary = (from x in pageWords
			group x by func(x.BoundingBox) into x
			where x.Count() >= minimumElements
			select x).ToDictionary((IGrouping<double, Word> gdc) => gdc.Key, (IGrouping<double, Word> gdc) => gdc.ToList());
		Dictionary<double, List<List<Word>>> dictionary2 = new Dictionary<double, List<List<Word>>>();
		foreach (KeyValuePair<double, List<Word>> edge in dictionary)
		{
			List<Word> list = edge.Value.OrderBy((Word x) => x.BoundingBox.Bottom).ToList();
			dictionary2.Add(edge.Key, new List<List<Word>>());
			List<Word> list2 = (from x in pageWords.Except(edge.Value)
				where x.BoundingBox.Left < edge.Key && x.BoundingBox.Right > edge.Key
				where x.BoundingBox.Bottom > edge.Value.Min((Word z) => z.BoundingBox.Bottom) && x.BoundingBox.Top < edge.Value.Max((Word z) => z.BoundingBox.Top)
				orderby x.BoundingBox.Bottom
				select x).ToList();
			if (list2.Count > 0)
			{
				foreach (Word cut in list2)
				{
					List<Word> list3 = list.Where((Word x) => x.BoundingBox.Top < cut.BoundingBox.Bottom).ToList();
					if (list3.Count >= minimumElements)
					{
						dictionary2[edge.Key].Add(list3);
					}
					list = list.Except(list3).ToList();
				}
				if (list.Count >= minimumElements)
				{
					dictionary2[edge.Key].Add(list);
				}
			}
			else
			{
				dictionary2[edge.Key].Add(list);
			}
		}
		return dictionary2.SelectMany((KeyValuePair<double, List<List<Word>>> x) => x.Value.Select((List<Word> y) => new PdfLine(x.Key, y.Min((Word w) => w.BoundingBox.Bottom), x.Key, y.Max((Word w) => w.BoundingBox.Top)))).ToList();
	}
}
