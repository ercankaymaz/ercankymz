using System;
using System.Collections.Generic;
using System.Linq;
using UglyToad.PdfPig.Content;
using UglyToad.PdfPig.Core;
using UglyToad.PdfPig.Geometry;

namespace UglyToad.PdfPig.DocumentLayoutAnalysis;

public static class WhitespaceCoverExtractor
{
	private class QueueEntries : SortedSet<QueueEntry>
	{
		private readonly int bound;

		public QueueEntries(int maximumBound)
		{
			bound = maximumBound;
		}

		public QueueEntry Dequeue()
		{
			QueueEntry max = base.Max;
			Remove(max);
			return max;
		}

		public void Enqueue(QueueEntry queueEntry)
		{
			if (bound > 0 && base.Count > bound)
			{
				Remove(base.Min);
			}
			Add(queueEntry);
		}
	}

	private class QueueEntry : IComparable<QueueEntry>
	{
		private readonly double quality;

		private readonly double whitespaceFuzziness;

		public PdfRectangle Bound { get; }

		public HashSet<PdfRectangle> Obstacles { get; }

		public QueueEntry(PdfRectangle bound, HashSet<PdfRectangle> obstacles, double whitespaceFuzziness)
		{
			Bound = bound;
			quality = ScoringFunction(Bound);
			Obstacles = obstacles;
			this.whitespaceFuzziness = whitespaceFuzziness;
		}

		public PdfRectangle GetPivot()
		{
			double distance;
			int num = Distances.FindIndexNearest(Bound.Centroid, Obstacles.Select((PdfRectangle o) => o.Centroid).ToList(), (PdfPoint p) => p, (PdfPoint p) => p, Distances.Euclidean, out distance);
			if (num != -1)
			{
				return Obstacles.ElementAt(num);
			}
			return Obstacles.First();
		}

		public bool IsEmptyEnough()
		{
			return Obstacles.Count == 0;
		}

		public bool IsEmptyEnough(IEnumerable<PdfRectangle> pageObstacles)
		{
			if (IsEmptyEnough())
			{
				return true;
			}
			double num = 0.0;
			foreach (PdfRectangle pageObstacle in pageObstacles)
			{
				PdfRectangle? pdfRectangle = Bound.Intersect(pageObstacle);
				if (!pdfRectangle.HasValue)
				{
					return false;
				}
				double num2 = MinimumOverlappingArea(pageObstacle, Bound, whitespaceFuzziness);
				if (pdfRectangle.Value.Area > num2)
				{
					return false;
				}
				num += pdfRectangle.Value.Area;
			}
			return num < Bound.Area * whitespaceFuzziness;
		}

		public override string ToString()
		{
			return "Q=" + quality.ToString("#0.0") + ", O=" + Obstacles.Count + ", " + Bound;
		}

		public void AddWhitespace(PdfRectangle rectangle)
		{
			Obstacles.Add(rectangle);
		}

		public int CompareTo(QueueEntry entry)
		{
			return quality.CompareTo(entry.quality);
		}

		public override bool Equals(object obj)
		{
			if (obj is QueueEntry queueEntry)
			{
				if (Bound.Left == queueEntry.Bound.Left && Bound.Right == queueEntry.Bound.Right && Bound.Top == queueEntry.Bound.Top && Bound.Bottom == queueEntry.Bound.Bottom)
				{
					return Obstacles == queueEntry.Obstacles;
				}
				return false;
			}
			return false;
		}

		public override int GetHashCode()
		{
			return (Bound.Left, Bound.Right, Bound.Top, Bound.Bottom, Obstacles).GetHashCode();
		}

		private static double MinimumOverlappingArea(PdfRectangle r1, PdfRectangle r2, double whitespaceFuzziness)
		{
			return Math.Min(r1.Area, r2.Area) * whitespaceFuzziness;
		}

		private static double ScoringFunction(PdfRectangle rectangle)
		{
			return rectangle.Area * (rectangle.Height / 4.0);
		}
	}

	public static IReadOnlyList<PdfRectangle> GetWhitespaces(IEnumerable<Word> words, IEnumerable<IPdfImage> images = null, int maxRectangleCount = 40, int maxBoundQueueSize = 0)
	{
		return GetWhitespaces(words, images, (from x in words.SelectMany((Word w) => w.Letters)
			select x.GlyphRectangle.Width).Mode() * 1.25, (from x in words.SelectMany((Word w) => w.Letters)
			select x.GlyphRectangle.Height).Mode() * 1.25, maxRectangleCount, 0.15, maxBoundQueueSize);
	}

	public static IReadOnlyList<PdfRectangle> GetWhitespaces(IEnumerable<Word> words, IEnumerable<IPdfImage> images, double minWidth, double minHeight, int maxRectangleCount = 40, double whitespaceFuzziness = 0.15, int maxBoundQueueSize = 0)
	{
		List<PdfRectangle> list = (from o in words
			where o.BoundingBox.Width > 0.0 && o.BoundingBox.Height > 0.0
			select o.BoundingBox).ToList();
		if (images != null && images.Any())
		{
			list.AddRange(from o in images
				where o.Bounds.Width > 0.0 && o.Bounds.Height > 0.0
				select o.Bounds);
		}
		return GetWhitespaces(list, minWidth, minHeight, maxRectangleCount, whitespaceFuzziness, maxBoundQueueSize);
	}

	public static IReadOnlyList<PdfRectangle> GetWhitespaces(IEnumerable<PdfRectangle> boundingboxes, double minWidth, double minHeight, int maxRectangleCount = 40, double whitespaceFuzziness = 0.15, int maxBoundQueueSize = 0)
	{
		if (!boundingboxes.Any())
		{
			return Array.Empty<PdfRectangle>();
		}
		HashSet<PdfRectangle> obstacles = new HashSet<PdfRectangle>(boundingboxes);
		return GetMaximalRectangles(GetBound(obstacles), obstacles, minWidth, minHeight, maxRectangleCount, whitespaceFuzziness, maxBoundQueueSize);
	}

	private static IReadOnlyList<PdfRectangle> GetMaximalRectangles(PdfRectangle bound, HashSet<PdfRectangle> obstacles, double minWidth, double minHeight, int maxRectangleCount, double whitespaceFuzziness, int maxBoundQueueSize)
	{
		QueueEntries queueEntries = new QueueEntries(maxBoundQueueSize);
		queueEntries.Enqueue(new QueueEntry(bound, obstacles, whitespaceFuzziness));
		HashSet<PdfRectangle> hashSet = new HashSet<PdfRectangle>();
		HashSet<QueueEntry> hashSet2 = new HashSet<QueueEntry>();
		while (queueEntries.Any())
		{
			QueueEntry current = queueEntries.Dequeue();
			if (current.IsEmptyEnough(obstacles))
			{
				if (hashSet.Any((PdfRectangle c) => Inside(c, current.Bound)))
				{
					continue;
				}
				if (!IsAdjacentToPageBounds(bound, current.Bound) && !hashSet.Any((PdfRectangle q) => IsAdjacentTo(q, current.Bound)))
				{
					hashSet2.Add(current);
					continue;
				}
				hashSet.Add(current.Bound);
				if (hashSet.Count >= maxRectangleCount)
				{
					return hashSet.ToList();
				}
				obstacles.Add(current.Bound);
				foreach (QueueEntry item in hashSet2)
				{
					queueEntries.Enqueue(item);
				}
				foreach (QueueEntry item2 in queueEntries)
				{
					if (OverlapsHard(current.Bound, item2.Bound))
					{
						item2.AddWhitespace(current.Bound);
					}
				}
				continue;
			}
			PdfRectangle pivot = current.GetPivot();
			PdfRectangle bound2 = current.Bound;
			new List<PdfRectangle>();
			PdfRectangle rRight = new PdfRectangle(pivot.Right, bound2.Bottom, bound2.Right, bound2.Top);
			if (bound2.Right > pivot.Right && rRight.Height > minHeight && rRight.Width > minWidth)
			{
				queueEntries.Enqueue(new QueueEntry(rRight, new HashSet<PdfRectangle>(current.Obstacles.Where((PdfRectangle o) => OverlapsHard(rRight, o))), whitespaceFuzziness));
			}
			PdfRectangle rLeft = new PdfRectangle(bound2.Left, bound2.Bottom, pivot.Left, bound2.Top);
			if (bound2.Left < pivot.Left && rLeft.Height > minHeight && rLeft.Width > minWidth)
			{
				queueEntries.Enqueue(new QueueEntry(rLeft, new HashSet<PdfRectangle>(current.Obstacles.Where((PdfRectangle o) => OverlapsHard(rLeft, o))), whitespaceFuzziness));
			}
			PdfRectangle rAbove = new PdfRectangle(bound2.Left, bound2.Bottom, bound2.Right, pivot.Bottom);
			if (bound2.Bottom < pivot.Bottom && rAbove.Height > minHeight && rAbove.Width > minWidth)
			{
				queueEntries.Enqueue(new QueueEntry(rAbove, new HashSet<PdfRectangle>(current.Obstacles.Where((PdfRectangle o) => OverlapsHard(rAbove, o))), whitespaceFuzziness));
			}
			PdfRectangle rBelow = new PdfRectangle(bound2.Left, pivot.Top, bound2.Right, bound2.Top);
			if (bound2.Top > pivot.Top && rBelow.Height > minHeight && rBelow.Width > minWidth)
			{
				queueEntries.Enqueue(new QueueEntry(rBelow, new HashSet<PdfRectangle>(current.Obstacles.Where((PdfRectangle o) => OverlapsHard(rBelow, o))), whitespaceFuzziness));
			}
		}
		return hashSet.ToList();
	}

	private static bool IsAdjacentTo(PdfRectangle rectangle1, PdfRectangle rectangle2)
	{
		if (rectangle1.Left > rectangle2.Right || rectangle2.Left > rectangle1.Right || rectangle1.Top < rectangle2.Bottom || rectangle2.Top < rectangle1.Bottom)
		{
			return false;
		}
		if (rectangle1.Left != rectangle2.Right && rectangle1.Right != rectangle2.Left && rectangle1.Bottom != rectangle2.Top)
		{
			return rectangle1.Top == rectangle2.Bottom;
		}
		return true;
	}

	private static bool IsAdjacentToPageBounds(PdfRectangle pageBound, PdfRectangle rectangle)
	{
		if (rectangle.Bottom != pageBound.Bottom && rectangle.Top != pageBound.Top && rectangle.Left != pageBound.Left)
		{
			return rectangle.Right == pageBound.Right;
		}
		return true;
	}

	private static bool OverlapsHard(PdfRectangle rectangle1, PdfRectangle rectangle2)
	{
		if (rectangle1.Left < rectangle2.Right && rectangle2.Left < rectangle1.Right && rectangle1.Top > rectangle2.Bottom)
		{
			return rectangle2.Top > rectangle1.Bottom;
		}
		return false;
	}

	private static bool Inside(PdfRectangle rectangle1, PdfRectangle rectangle2)
	{
		if (rectangle2.Right <= rectangle1.Right && rectangle2.Left >= rectangle1.Left && rectangle2.Top <= rectangle1.Top)
		{
			return rectangle2.Bottom >= rectangle1.Bottom;
		}
		return false;
	}

	private static PdfRectangle GetBound(IEnumerable<PdfRectangle> obstacles)
	{
		return new PdfRectangle(obstacles.Min((PdfRectangle b) => b.Left), obstacles.Min((PdfRectangle b) => b.Bottom), obstacles.Max((PdfRectangle b) => b.Right), obstacles.Max((PdfRectangle b) => b.Top));
	}
}
