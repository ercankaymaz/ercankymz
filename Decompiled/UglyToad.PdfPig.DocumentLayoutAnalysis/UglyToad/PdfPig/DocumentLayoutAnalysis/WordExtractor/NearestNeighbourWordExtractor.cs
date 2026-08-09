using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UglyToad.PdfPig.Content;
using UglyToad.PdfPig.Core;
using UglyToad.PdfPig.Util;

namespace UglyToad.PdfPig.DocumentLayoutAnalysis.WordExtractor;

public class NearestNeighbourWordExtractor : IWordExtractor
{
	public class NearestNeighbourWordExtractorOptions : IWordExtractorOptions, IDlaOptions
	{
		public int MaxDegreeOfParallelism { get; set; } = -1;

		public Func<Letter, Letter, double> MaximumDistance { get; set; } = delegate(Letter l1, Letter l2)
		{
			double num = Math.Max(Math.Max(Math.Max(Math.Max(Math.Max(Math.Abs(l1.GlyphRectangle.Width), Math.Abs(l2.GlyphRectangle.Width)), Math.Abs(l1.Width)), Math.Abs(l2.Width)), l1.PointSize), l2.PointSize) * 0.2;
			return (l1.TextOrientation == TextOrientation.Other || l2.TextOrientation == TextOrientation.Other) ? (2.0 * num) : num;
		};

		public Func<PdfPoint, PdfPoint, double> DistanceMeasure { get; set; } = Distances.Euclidean;

		public Func<PdfPoint, PdfPoint, double> DistanceMeasureAA { get; set; } = Distances.Manhattan;

		public Func<Letter, Letter, bool> Filter { get; set; } = (Letter _, Letter l2) => !string.IsNullOrWhiteSpace(l2.Value);

		public Func<Letter, bool> FilterPivot { get; set; } = (Letter l) => !string.IsNullOrWhiteSpace(l.Value);

		public bool GroupByOrientation { get; set; } = true;
	}

	private readonly NearestNeighbourWordExtractorOptions options;

	public static NearestNeighbourWordExtractor Instance { get; } = new NearestNeighbourWordExtractor();

	public NearestNeighbourWordExtractor()
		: this(new NearestNeighbourWordExtractorOptions())
	{
	}

	public NearestNeighbourWordExtractor(NearestNeighbourWordExtractorOptions options)
	{
		this.options = options ?? throw new ArgumentNullException("options");
	}

	public IEnumerable<Word> GetWords(IReadOnlyList<Letter> letters)
	{
		if (letters == null || letters.Count == 0)
		{
			return Array.Empty<Word>();
		}
		if (options.GroupByOrientation)
		{
			List<Letter>[] buckets = new List<Letter>[5];
			for (int i = 0; i < buckets.Length; i++)
			{
				buckets[i] = new List<Letter>();
			}
			foreach (Letter letter in letters)
			{
				switch (letter.TextOrientation)
				{
				case TextOrientation.Horizontal:
					buckets[0].Add(letter);
					break;
				case TextOrientation.Rotate270:
					buckets[1].Add(letter);
					break;
				case TextOrientation.Rotate180:
					buckets[2].Add(letter);
					break;
				case TextOrientation.Rotate90:
					buckets[3].Add(letter);
					break;
				default:
					buckets[4].Add(letter);
					break;
				}
			}
			List<Word> results = new List<Word>(letters.Count);
			ParallelOptions parallelOptions = new ParallelOptions
			{
				MaxDegreeOfParallelism = ((options.MaxDegreeOfParallelism > 0) ? options.MaxDegreeOfParallelism : Environment.ProcessorCount)
			};
			Parallel.ForEach(Partitioner.Create(0, buckets.Length), parallelOptions, delegate(Tuple<int, int> range)
			{
				for (int j = range.Item1; j < range.Item2; j++)
				{
					if (buckets[j].Count != 0)
					{
						Func<PdfPoint, PdfPoint, double> distMeasure = ((j == 4) ? options.DistanceMeasure : options.DistanceMeasureAA);
						List<Word> words = GetWords(buckets[j], options.MaximumDistance, distMeasure, options.FilterPivot, options.Filter, options.MaxDegreeOfParallelism);
						lock (results)
						{
							results.AddRange(words);
						}
					}
				}
			});
			results.TrimExcess();
			return results;
		}
		return GetWords(letters, options.MaximumDistance, options.DistanceMeasure, options.FilterPivot, options.Filter, options.MaxDegreeOfParallelism);
	}

	private List<Word> GetWords(IReadOnlyList<Letter> letters, Func<Letter, Letter, double> maxDistanceFunction, Func<PdfPoint, PdfPoint, double> distMeasure, Func<Letter, bool> filterPivotFunction, Func<Letter, Letter, bool> filterFunction, int maxDegreeOfParallelism)
	{
		if (letters == null || letters.Count == 0)
		{
			return new List<Word>();
		}
		List<IReadOnlyList<Letter>> list = Clustering.NearestNeighbours(letters, distMeasure, maxDistanceFunction, (Letter l) => l.EndBaseLine, (Letter l) => l.StartBaseLine, filterPivotFunction, filterFunction, maxDegreeOfParallelism).ToList();
		List<Word> list2 = new List<Word>();
		foreach (IReadOnlyList<Letter> item in list)
		{
			list2.Add(new Word(item));
		}
		return list2;
	}
}
