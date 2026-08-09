using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UglyToad.PdfPig.Content;
using UglyToad.PdfPig.Core;
using UglyToad.PdfPig.DocumentLayoutAnalysis.ReadingOrderDetector;

namespace UglyToad.PdfPig.DocumentLayoutAnalysis.PageSegmenter;

public class DocstrumBoundingBoxes : IPageSegmenter
{
	private sealed class PdfPointXYComparer : IComparer<PdfPoint>
	{
		public static readonly PdfPointXYComparer Instance = new PdfPointXYComparer();

		public int Compare(PdfPoint p1, PdfPoint p2)
		{
			int num = p1.X.CompareTo(p2.X);
			if (num != 0)
			{
				return num;
			}
			return p1.Y.CompareTo(p2.Y);
		}
	}

	private sealed class PdfPointYComparer : IComparer<PdfPoint>
	{
		public static readonly PdfPointYComparer Instance = new PdfPointYComparer();

		public int Compare(PdfPoint p1, PdfPoint p2)
		{
			return p1.Y.CompareTo(p2.Y);
		}
	}

	public readonly struct AngleBounds
	{
		public double Lower { get; }

		public double Upper { get; }

		public AngleBounds(double lowerBound, double upperBound)
		{
			if (lowerBound >= upperBound)
			{
				throw new ArgumentException("The lower bound should be smaller than the upper bound.");
			}
			Lower = lowerBound;
			Upper = upperBound;
		}

		public bool Contains(double angle)
		{
			if (angle >= Lower)
			{
				return angle <= Upper;
			}
			return false;
		}
	}

	public class DocstrumBoundingBoxesOptions : IPageSegmenterOptions, IDlaOptions
	{
		public int MaxDegreeOfParallelism { get; set; } = -1;

		public string WordSeparator { get; set; } = " ";

		public string LineSeparator { get; set; } = "\n";

		public double Epsilon { get; set; } = 0.001;

		public AngleBounds WithinLineBounds { get; set; } = new AngleBounds(-30.0, 30.0);

		public double WithinLineMultiplier { get; set; } = 3.0;

		public int WithinLineBinSize { get; set; } = 10;

		public AngleBounds BetweenLineBounds { get; set; } = new AngleBounds(45.0, 135.0);

		public double BetweenLineMultiplier { get; set; } = 1.3;

		public int BetweenLineBinSize { get; set; } = 10;

		public AngleBounds AngularDifferenceBounds { get; set; } = new AngleBounds(-30.0, 30.0);
	}

	private readonly DocstrumBoundingBoxesOptions options;

	public static DocstrumBoundingBoxes Instance { get; } = new DocstrumBoundingBoxes();

	public DocstrumBoundingBoxes()
		: this(new DocstrumBoundingBoxesOptions())
	{
	}

	public DocstrumBoundingBoxes(DocstrumBoundingBoxesOptions options)
	{
		this.options = options ?? throw new ArgumentNullException("options");
	}

	public IReadOnlyList<TextBlock> GetBlocks(IEnumerable<Word> words)
	{
		if (words == null)
		{
			return Array.Empty<TextBlock>();
		}
		IReadOnlyList<Word> readOnlyList = (words as IReadOnlyList<Word>) ?? words.ToArray();
		if (readOnlyList.Count == 0)
		{
			return Array.Empty<TextBlock>();
		}
		return GetBlocks(readOnlyList, options.WithinLineBounds, options.WithinLineMultiplier, options.WithinLineBinSize, options.BetweenLineBounds, options.BetweenLineMultiplier, options.BetweenLineBinSize, options.AngularDifferenceBounds, options.Epsilon, options.WordSeparator, options.LineSeparator, options.MaxDegreeOfParallelism);
	}

	private IReadOnlyList<TextBlock> GetBlocks(IReadOnlyList<Word> words, AngleBounds wlBounds, double wlMultiplier, int wlBinSize, AngleBounds blBounds, double blMultiplier, int blBinSize, AngleBounds angularDifferenceBounds, double epsilon, string wordSeparator, string lineSeparator, int maxDegreeOfParallelism)
	{
		words = words.Where((Word w) => !string.IsNullOrWhiteSpace(w.Text)).ToList();
		if (words.Count == 0)
		{
			return Array.Empty<TextBlock>();
		}
		if (!GetSpacingEstimation(words, wlBounds, wlBinSize, blBounds, blBinSize, maxDegreeOfParallelism, out var withinLineDistance, out var betweenLineDistance))
		{
			if (double.IsNaN(withinLineDistance))
			{
				withinLineDistance = 0.0;
			}
			if (double.IsNaN(betweenLineDistance))
			{
				betweenLineDistance = 0.0;
			}
		}
		double maxWLDistance = wlMultiplier * withinLineDistance;
		TextLine[] lines = GetLines(words, maxWLDistance, wlBounds, wordSeparator, maxDegreeOfParallelism).ToArray();
		double maxBLDistance = blMultiplier * betweenLineDistance;
		return GetStructuralBlocks(lines, maxBLDistance, angularDifferenceBounds, epsilon, lineSeparator, maxDegreeOfParallelism).ToList();
	}

	public static bool GetSpacingEstimation(IReadOnlyList<Word> words, AngleBounds wlBounds, int wlBinSize, AngleBounds blBounds, int blBinSize, int maxDegreeOfParallelism, out double withinLineDistance, out double betweenLineDistance)
	{
		ParallelOptions parallelOptions = new ParallelOptions
		{
			MaxDegreeOfParallelism = maxDegreeOfParallelism
		};
		ConcurrentBag<double> withinLineDistList = new ConcurrentBag<double>();
		ConcurrentBag<double> betweenLineDistList = new ConcurrentBag<double>();
		KdTree<Word> kdTreeBottomLeft = new KdTree<Word>(words, (Word w) => w.BoundingBox.BottomLeft);
		Parallel.For(0, words.Count, parallelOptions, delegate(int i)
		{
			Word word = words[i];
			foreach (var item in kdTreeBottomLeft.FindNearestNeighbours(word, 2, (Word w) => w.BoundingBox.BottomRight, Distances.Euclidean))
			{
				if (wlBounds.Contains(AngleWL(word, item.Item1)))
				{
					withinLineDistList.Add(Distances.Euclidean(word.BoundingBox.BottomRight, item.Item1.BoundingBox.BottomLeft));
				}
			}
			foreach (var item2 in kdTreeBottomLeft.FindNearestNeighbours(word, 2, (Word w) => w.BoundingBox.TopLeft, Distances.Euclidean))
			{
				double num = AngleBL(word, item2.Item1);
				if (blBounds.Contains(num))
				{
					double num2 = Distances.Euclidean(word.BoundingBox.Centroid, item2.Item1.BoundingBox.Centroid);
					if (num > 90.0)
					{
						num -= 180.0;
					}
					double num3 = Math.Abs(num2 * Math.Cos((90.0 - num) * Math.PI / 180.0)) - word.BoundingBox.Height / 2.0 - item2.Item1.BoundingBox.Height / 2.0;
					if (num3 >= 0.0)
					{
						betweenLineDistList.Add(num3);
					}
				}
			}
		});
		double? peakAverageDistance = GetPeakAverageDistance(withinLineDistList, wlBinSize);
		double? peakAverageDistance2 = GetPeakAverageDistance(betweenLineDistList, blBinSize);
		withinLineDistance = peakAverageDistance ?? double.NaN;
		betweenLineDistance = peakAverageDistance2 ?? double.NaN;
		if (peakAverageDistance.HasValue)
		{
			return peakAverageDistance2.HasValue;
		}
		return false;
	}

	private static double? GetPeakAverageDistance(IEnumerable<double> distances, int binLength = 1)
	{
		if (!distances.Any())
		{
			return null;
		}
		if (binLength <= 0)
		{
			throw new ArgumentException("DocstrumBoundingBoxes: the bin length must be positive when commputing peak average distance.", "binLength");
		}
		double num = Math.Ceiling(distances.Max());
		if (num > 2147483647.0)
		{
			throw new OverflowException($"Error while casting maximum distance of {num} to integer.");
		}
		int num2 = (int)num;
		if (num2 == 0)
		{
			num2 = binLength;
		}
		else
		{
			binLength = ((binLength > num2) ? num2 : binLength);
		}
		Dictionary<int, List<double>> dictionary = (from x in Enumerable.Range(0, (int)Math.Ceiling((double)num2 / (double)binLength) + 1)
			select x * binLength).ToDictionary((int x) => x, (int _) => new List<double>());
		foreach (double distance in distances)
		{
			int num3 = (int)Math.Floor(distance / (double)binLength);
			if (num3 < 0)
			{
				throw new ArgumentOutOfRangeException("bin", "DocstrumBoundingBoxes: Negative distance found while commputing peak average distance.");
			}
			dictionary[dictionary.Keys.ElementAt(num3)].Add(distance);
		}
		List<double> list = null;
		foreach (KeyValuePair<int, List<double>> item in dictionary)
		{
			if (list == null || item.Value.Count > list.Count)
			{
				list = item.Value;
			}
		}
		return list?.Average();
	}

	public static IEnumerable<TextLine> GetLines(IReadOnlyList<Word> words, double maxWLDistance, AngleBounds wlBounds, string wordSeparator, int maxDegreeOfParallelism)
	{
		List<IReadOnlyList<Word>> list = Clustering.NearestNeighbours(words, 2, Distances.Euclidean, (Word _, Word __) => maxWLDistance, (Word pivot) => pivot.BoundingBox.BottomRight, (Word candidate) => candidate.BoundingBox.BottomLeft, (Word _) => true, (Word pivot, Word candidate) => wlBounds.Contains(AngleWL(pivot, candidate)), maxDegreeOfParallelism).ToList();
		foreach (IReadOnlyList<Word> item in list)
		{
			yield return new TextLine(item.OrderByReadingOrder(), wordSeparator);
		}
	}

	private static double AngleWL(Word pivot, Word candidate)
	{
		double num = Distances.BoundAngle180(Distances.Angle(pivot.BoundingBox.BottomRight, candidate.BoundingBox.BottomLeft) - pivot.BoundingBox.Rotation);
		if (num > 90.0)
		{
			num -= 180.0;
		}
		else if (num < -90.0)
		{
			num += 180.0;
		}
		return num;
	}

	public static IEnumerable<TextBlock> GetStructuralBlocks(IReadOnlyList<TextLine> lines, double maxBLDistance, AngleBounds angularDifferenceBounds, double epsilon, string lineSeparator, int maxDegreeOfParallelism)
	{
		List<IReadOnlyList<TextLine>> list = Clustering.NearestNeighbours(lines, (PdfLine l1, PdfLine l2) => PerpendicularOverlappingDistance(l1, l2, angularDifferenceBounds, epsilon), (TextLine _, TextLine __) => maxBLDistance, (TextLine pivot) => new PdfLine(pivot.BoundingBox.BottomLeft, pivot.BoundingBox.BottomRight), (TextLine candidate) => new PdfLine(candidate.BoundingBox.TopLeft, candidate.BoundingBox.TopRight), (TextLine _) => true, (TextLine _, TextLine __) => true, maxDegreeOfParallelism).ToList();
		foreach (IReadOnlyList<TextLine> item in list)
		{
			yield return new TextBlock(item.OrderByReadingOrder(), lineSeparator);
		}
	}

	private static double PerpendicularOverlappingDistance(PdfLine line1, PdfLine line2, AngleBounds angularDifferenceBounds, double epsilon)
	{
		if (GetStructuralBlockingParameters(line1, line2, epsilon, out var angularDifference, out var _, out var perpendicularDistance))
		{
			if (angularDifference > 90.0)
			{
				angularDifference -= 180.0;
			}
			else if (angularDifference < -90.0)
			{
				angularDifference += 180.0;
			}
			if (!angularDifferenceBounds.Contains(angularDifference))
			{
				return double.PositiveInfinity;
			}
			return Math.Abs(perpendicularDistance);
		}
		return double.PositiveInfinity;
	}

	public static bool GetStructuralBlockingParameters(PdfLine i, PdfLine j, double epsilon, out double angularDifference, out double normalisedOverlap, out double perpendicularDistance)
	{
		if (AlmostEquals(i, j, epsilon))
		{
			angularDifference = 0.0;
			normalisedOverlap = 1.0;
			perpendicularDistance = 0.0;
			return true;
		}
		double num = i.Point2.X - i.Point1.X;
		double num2 = i.Point2.Y - i.Point1.Y;
		double num3 = j.Point2.X - j.Point1.X;
		double num4 = j.Point2.Y - j.Point1.Y;
		angularDifference = Distances.BoundAngle180((Math.Atan2(num4, num3) - Math.Atan2(num2, num)) * 180.0 / Math.PI);
		PdfPoint? translatedPoint = GetTranslatedPoint(i.Point1.X, i.Point1.Y, j.Point1.X, j.Point1.Y, num, num2, num3, num4, epsilon);
		PdfPoint? translatedPoint2 = GetTranslatedPoint(i.Point2.X, i.Point2.Y, j.Point2.X, j.Point2.Y, num, num2, num3, num4, epsilon);
		if (!translatedPoint.HasValue || !translatedPoint2.HasValue)
		{
			normalisedOverlap = double.NaN;
			perpendicularDistance = double.NaN;
			return false;
		}
		PdfPoint[] array = new PdfPoint[4] { j.Point1, j.Point2, translatedPoint.Value, translatedPoint2.Value };
		if (num3 != 0.0)
		{
			Array.Sort(array, PdfPointXYComparer.Instance);
		}
		else if (num4 != 0.0)
		{
			Array.Sort(array, PdfPointYComparer.Instance);
		}
		PdfPoint pdfPoint = array[1];
		PdfPoint pdfPoint2 = array[2];
		bool flag = PointInLine(j.Point1, j.Point2, pdfPoint) && PointInLine(j.Point1, j.Point2, pdfPoint2) && PointInLine(translatedPoint.Value, translatedPoint2.Value, pdfPoint) && PointInLine(translatedPoint.Value, translatedPoint2.Value, pdfPoint2);
		double num5 = Distances.Euclidean(pdfPoint, pdfPoint2);
		normalisedOverlap = (flag ? num5 : (0.0 - num5)) / j.Length;
		double num6 = (pdfPoint.X + pdfPoint2.X) / 2.0;
		double num7 = (pdfPoint.Y + pdfPoint2.Y) / 2.0;
		if (!num.AlmostEqualsToZero(epsilon) && !num2.AlmostEqualsToZero(epsilon))
		{
			perpendicularDistance = (num6 - i.Point1.X - (num7 - i.Point1.Y) * num / num2) / Math.Sqrt(num * num / (num2 * num2) + 1.0);
		}
		else if (num.AlmostEqualsToZero(epsilon))
		{
			perpendicularDistance = num6 - i.Point1.X;
		}
		else
		{
			perpendicularDistance = num7 - i.Point1.Y;
		}
		return flag;
	}

	private static PdfPoint? GetTranslatedPoint(double xPi, double yPi, double xPj, double yPj, double dXi, double dYi, double dXj, double dYj, double epsilon)
	{
		double num = dYi * dYj;
		double num2 = dXi * dXj;
		double num3 = num + num2;
		if (num3.AlmostEqualsToZero(epsilon))
		{
			return null;
		}
		double num4;
		double y;
		if (!dXj.AlmostEqualsToZero(epsilon))
		{
			num4 = (xPi * num2 + xPj * num + dXj * dYi * (yPi - yPj)) / num3;
			y = dYj / dXj * (num4 - xPj) + yPj;
		}
		else
		{
			y = (yPi * num + yPj * num2 + dYj * dXi * (xPi - xPj)) / num3;
			num4 = xPj;
		}
		return new PdfPoint(num4, y);
	}

	private static bool PointInLine(PdfPoint pl1, PdfPoint pl2, PdfPoint point)
	{
		double num = point.X - pl1.X;
		double num2 = point.Y - pl1.Y;
		double num3 = pl2.X - pl1.X;
		double num4 = pl2.Y - pl1.Y;
		double num5 = num * num3 + num2 * num4;
		if (num5 >= 0.0)
		{
			return num5 <= num3 * num3 + num4 * num4;
		}
		return false;
	}

	private static bool AlmostEquals(PdfLine line1, PdfLine line2, double epsilon)
	{
		if ((line1.Point1.X - line2.Point1.X).AlmostEqualsToZero(epsilon) && (line1.Point1.Y - line2.Point1.Y).AlmostEqualsToZero(epsilon) && (line1.Point2.X - line2.Point2.X).AlmostEqualsToZero(epsilon))
		{
			return (line1.Point2.Y - line2.Point2.Y).AlmostEqualsToZero(epsilon);
		}
		return false;
	}

	private static double AngleBL(Word pivot, Word candidate)
	{
		double num = Distances.BoundAngle180(Distances.Angle(pivot.BoundingBox.Centroid, candidate.BoundingBox.Centroid) - pivot.BoundingBox.Rotation);
		if (num < 0.0)
		{
			num += 180.0;
		}
		return num;
	}
}
