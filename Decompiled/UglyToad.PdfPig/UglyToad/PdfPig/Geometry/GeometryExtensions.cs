using System;
using System.Buffers;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UglyToad.PdfPig.Core;
using UglyToad.PdfPig.Geometry.ClipperLibrary;
using UglyToad.PdfPig.Graphics;

namespace UglyToad.PdfPig.Geometry;

public static class GeometryExtensions
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

	private const double epsilon = 1E-05;

	private const double OneThird = 1.0 / 3.0;

	private const double SqrtOfThree = 1.73205080756888;

	private static bool ccw(PdfPoint point1, PdfPoint point2, PdfPoint point3)
	{
		return (point2.X - point1.X) * (point3.Y - point1.Y) > (point2.Y - point1.Y) * (point3.X - point1.X);
	}

	public static double DotProduct(this PdfPoint point1, PdfPoint point2)
	{
		return point1.X * point2.X + point1.Y * point2.Y;
	}

	public static PdfPoint Add(this PdfPoint point1, PdfPoint point2)
	{
		return new PdfPoint(point1.X + point2.X, point1.Y + point2.Y);
	}

	public static PdfPoint Subtract(this PdfPoint point1, PdfPoint point2)
	{
		return new PdfPoint(point1.X - point2.X, point1.Y - point2.Y);
	}

	private static PdfRectangle ParametricPerpendicularProjection(ReadOnlySpan<PdfPoint> polygon)
	{
		if (polygon.Length == 0)
		{
			throw new ArgumentException("ParametricPerpendicularProjection(): polygon cannot be null and must contain at least one point.", "polygon");
		}
		if (polygon.Length == 1)
		{
			return new PdfRectangle(polygon[0], polygon[0]);
		}
		if (polygon.Length == 2)
		{
			return new PdfRectangle(polygon[0], polygon[1]);
		}
		Span<double> span = stackalloc double[8];
		double num = double.PositiveInfinity;
		int num2 = 1;
		int num3 = 0;
		double num4 = double.NaN;
		double num5 = double.NaN;
		double num6 = double.NaN;
		double num7 = double.NaN;
		double num8 = double.NaN;
		double num9 = double.NaN;
		do
		{
			PdfPoint pdfPoint = polygon[num3];
			PdfPoint pdfPoint2 = polygon[num2];
			double num10 = pdfPoint2.X - pdfPoint.X;
			double num11 = pdfPoint2.Y - pdfPoint.Y;
			double num12 = 1.0 / (num10 * num10 + num11 * num11);
			double num13 = 1.0;
			double num14 = 0.0;
			double num15 = 0.0;
			int num16 = -1;
			for (num2 = 0; num2 < polygon.Length; num2++)
			{
				pdfPoint2 = polygon[num2];
				double num17 = pdfPoint2.X - pdfPoint.X;
				double num18 = pdfPoint2.Y - pdfPoint.Y;
				double num19 = (num17 * num10 + num18 * num11) * num12;
				double num20 = num19 * num10 + pdfPoint.X;
				double num21 = num19 * num11 + pdfPoint.Y;
				num17 = num20 - pdfPoint2.X;
				num18 = num21 - pdfPoint2.Y;
				double num22 = num17 * num17 + num18 * num18;
				if (num19 < num13)
				{
					num13 = num19;
					num6 = num20;
					num7 = num21;
				}
				if (num19 > num14)
				{
					num14 = num19;
					num8 = num20;
					num9 = num21;
				}
				if (num22 > num15)
				{
					num15 = num22;
					num4 = num20;
					num5 = num21;
					num16 = num2;
				}
			}
			if (num16 != -1)
			{
				PdfPoint pdfPoint3 = polygon[num16];
				double num23 = pdfPoint3.X - num4;
				double num24 = pdfPoint3.Y - num5;
				double num25 = num8 + num23;
				double num26 = num9 + num24;
				double num27 = num6 + num23;
				double num28 = num7 + num24;
				double num17 = num8 - num6;
				double num18 = num9 - num7;
				double num29 = (num17 * num17 + num18 * num18) * num15;
				if (num29 < num)
				{
					num = num29;
					span[0] = num6;
					span[1] = num7;
					span[2] = num8;
					span[3] = num9;
					span[4] = num25;
					span[5] = num26;
					span[6] = num27;
					span[7] = num28;
				}
			}
			num3++;
			num2 = num3 + 1;
			if (num2 == polygon.Length)
			{
				num2 = 0;
			}
		}
		while (num3 != polygon.Length);
		return new PdfRectangle(new PdfPoint(span[4], span[5]), new PdfPoint(span[6], span[7]), new PdfPoint(span[2], span[3]), new PdfPoint(span[0], span[1]));
	}

	public static PdfRectangle MinimumAreaRectangle(IEnumerable<PdfPoint> points)
	{
		if (points == null)
		{
			throw new ArgumentException("MinimumAreaRectangle(): points cannot be null.", "points");
		}
		return MinimumAreaRectangle(points.ToArray());
	}

	public static PdfRectangle MinimumAreaRectangle(PdfPoint[] points)
	{
		if (points == null || !points.Any())
		{
			throw new ArgumentException("MinimumAreaRectangle(): points cannot be null and must contain at least one point.", "points");
		}
		return ParametricPerpendicularProjection(GrahamScan(points.Distinct()).ToArray());
	}

	public static PdfRectangle OrientedBoundingBox(IReadOnlyList<PdfPoint> points)
	{
		if (points == null || points.Count < 2)
		{
			throw new ArgumentException("OrientedBoundingBox(): points cannot be null and must contain at least two points.", "points");
		}
		double num = points.Average((PdfPoint p) => p.X);
		double num2 = points.Average((PdfPoint p) => p.Y);
		double num3 = 0.0;
		double num4 = 0.0;
		for (int num5 = 0; num5 < points.Count; num5++)
		{
			PdfPoint pdfPoint = points[num5];
			double num6 = pdfPoint.X - num;
			double num7 = pdfPoint.Y - num2;
			num3 += num6 * num7;
			num4 += num6 * num6;
		}
		double num8 = Math.Atan(num3 / num4);
		double num9 = Math.Cos(num8);
		double num10 = Math.Sin(num8);
		TransformationMatrix inverseRotation = new TransformationMatrix(num9, 0.0 - num10, 0.0, num10, num9, 0.0, 0.0, 0.0, 1.0);
		PdfPoint[] source = points.Select((PdfPoint p) => inverseRotation.Transform(p)).ToArray();
		PdfRectangle original = new PdfRectangle(source.Min((PdfPoint p) => p.X), source.Min((PdfPoint p) => p.Y), source.Max((PdfPoint p) => p.X), source.Max((PdfPoint p) => p.Y));
		return new TransformationMatrix(num9, num10, 0.0, 0.0 - num10, num9, 0.0, 0.0, 0.0, 1.0).Transform(original);
	}

	public static IReadOnlyCollection<PdfPoint> GrahamScan(IEnumerable<PdfPoint> points)
	{
		return GrahamScan(points.ToArray());
	}

	public static IReadOnlyCollection<PdfPoint> GrahamScan(PdfPoint[] points)
	{
		if (points == null || points.Length == 0)
		{
			throw new ArgumentException("GrahamScan(): points cannot be null and must contain at least one point.", "points");
		}
		if (points.Length < 3)
		{
			return points;
		}
		Array.Sort(points, PdfPointXYComparer.Instance);
		PdfPoint P0 = points[0];
		IGrouping<double, PdfPoint>[] array = (from p in points.Skip(1)
			group p by polarAngle(in P0, in p) into g
			orderby g.Key
			select g).ToArray();
		PdfPoint[] array2 = ArrayPool<PdfPoint>.Shared.Rent(array.Length);
		try
		{
			for (int num = 0; num < array.Length; num++)
			{
				IGrouping<double, PdfPoint> source = array[num];
				if (source.Count() == 1)
				{
					array2[num] = source.First();
					continue;
				}
				array2[num] = source.OrderByDescending(delegate(PdfPoint p)
				{
					double num3 = p.X - P0.X;
					double num4 = p.Y - P0.Y;
					return num3 * num3 + num4 * num4;
				}).First();
			}
			if (array.Length < 2)
			{
				return new global::_003C_003Ez__ReadOnlyArray<PdfPoint>(new PdfPoint[2]
				{
					P0,
					array2[0]
				});
			}
			Stack<PdfPoint> stack = new Stack<PdfPoint>();
			stack.Push(P0);
			stack.Push(array2[0]);
			stack.Push(array2[1]);
			for (int num2 = 2; num2 < array.Length; num2++)
			{
				PdfPoint pdfPoint = array2[num2];
				while (stack.Count > 1 && !ccw(stack.ElementAt(1), stack.Peek(), pdfPoint))
				{
					stack.Pop();
				}
				stack.Push(pdfPoint);
			}
			return stack;
		}
		finally
		{
			ArrayPool<PdfPoint>.Shared.Return(array2);
		}
		static double polarAngle(in PdfPoint point1, in PdfPoint point2)
		{
			return Math.Atan2(point2.Y - point1.Y, point2.X - point1.X) % Math.PI;
		}
	}

	public static PdfPath ToPdfPath(this PdfRectangle rectangle)
	{
		PdfSubpath pdfSubpath = new PdfSubpath();
		pdfSubpath.Rectangle(rectangle.BottomLeft.X, rectangle.BottomLeft.Y, rectangle.Width, rectangle.Height);
		return new PdfPath { pdfSubpath };
	}

	public static bool Contains(this PdfRectangle rectangle, PdfPoint point, bool includeBorder = false)
	{
		if (Math.Abs(rectangle.Area) < 1E-05)
		{
			return false;
		}
		if (Math.Abs(rectangle.Rotation) < 1E-05)
		{
			if (includeBorder)
			{
				if (point.X >= rectangle.Left && point.X <= rectangle.Right && point.Y >= rectangle.Bottom)
				{
					return point.Y <= rectangle.Top;
				}
				return false;
			}
			if (point.X > rectangle.Left && point.X < rectangle.Right && point.Y > rectangle.Bottom)
			{
				return point.Y < rectangle.Top;
			}
			return false;
		}
		double num = area(rectangle.BottomLeft, point, rectangle.TopLeft);
		double num2 = area(rectangle.TopLeft, point, rectangle.TopRight);
		double num3 = area(rectangle.TopRight, point, rectangle.BottomRight);
		double num4 = area(rectangle.BottomRight, point, rectangle.BottomLeft);
		if (num + num2 + num3 + num4 - rectangle.Area > 1E-05)
		{
			return false;
		}
		if (num < 1E-05 || num2 < 1E-05 || num3 < 1E-05 || num4 < 1E-05)
		{
			return includeBorder;
		}
		return true;
		static double area(in PdfPoint p1, PdfPoint p2, PdfPoint p3)
		{
			return Math.Abs(p2.X * p1.Y - p1.X * p2.Y + (p3.X * p2.Y - p2.X * p3.Y) + (p1.X * p3.Y - p3.X * p1.Y)) / 2.0;
		}
	}

	public static bool Contains(this PdfRectangle rectangle, PdfRectangle other, bool includeBorder = false)
	{
		if (!rectangle.Contains(other.BottomLeft, includeBorder))
		{
			return false;
		}
		if (!rectangle.Contains(other.TopRight, includeBorder))
		{
			return false;
		}
		if (!rectangle.Contains(other.BottomRight, includeBorder))
		{
			return false;
		}
		if (!rectangle.Contains(other.TopLeft, includeBorder))
		{
			return false;
		}
		return true;
	}

	public static bool IntersectsWith(this PdfRectangle rectangle, PdfRectangle other)
	{
		if (Math.Abs(rectangle.Rotation) < 1E-05 && Math.Abs(other.Rotation) < 1E-05)
		{
			if (rectangle.Left > other.Right || other.Left > rectangle.Right)
			{
				return false;
			}
			if (rectangle.Top < other.Bottom || other.Top < rectangle.Bottom)
			{
				return false;
			}
			return true;
		}
		PdfRectangle rectangle2 = rectangle.Normalise();
		PdfRectangle other2 = other.Normalise();
		if (Math.Abs(rectangle2.Rotation) < 1E-05 && Math.Abs(other2.Rotation) < 1E-05 && !rectangle2.IntersectsWith(other2))
		{
			return false;
		}
		if (rectangle.Contains(other.BottomLeft))
		{
			return true;
		}
		if (rectangle.Contains(other.TopRight))
		{
			return true;
		}
		if (rectangle.Contains(other.TopLeft))
		{
			return true;
		}
		if (rectangle.Contains(other.BottomRight))
		{
			return true;
		}
		if (other.Contains(rectangle.BottomLeft))
		{
			return true;
		}
		if (other.Contains(rectangle.TopRight))
		{
			return true;
		}
		if (other.Contains(rectangle.TopLeft))
		{
			return true;
		}
		if (other.Contains(rectangle.BottomRight))
		{
			return true;
		}
		if (IntersectsWith(rectangle.BottomLeft, rectangle.BottomRight, other.BottomLeft, other.BottomRight))
		{
			return true;
		}
		if (IntersectsWith(rectangle.BottomLeft, rectangle.BottomRight, other.BottomRight, other.TopRight))
		{
			return true;
		}
		if (IntersectsWith(rectangle.BottomLeft, rectangle.BottomRight, other.TopRight, other.TopLeft))
		{
			return true;
		}
		if (IntersectsWith(rectangle.BottomLeft, rectangle.BottomRight, other.TopLeft, other.BottomLeft))
		{
			return true;
		}
		if (IntersectsWith(rectangle.BottomRight, rectangle.TopRight, other.BottomLeft, other.BottomRight))
		{
			return true;
		}
		if (IntersectsWith(rectangle.BottomRight, rectangle.TopRight, other.BottomRight, other.TopRight))
		{
			return true;
		}
		if (IntersectsWith(rectangle.BottomRight, rectangle.TopRight, other.TopRight, other.TopLeft))
		{
			return true;
		}
		if (IntersectsWith(rectangle.BottomRight, rectangle.TopRight, other.TopLeft, other.BottomLeft))
		{
			return true;
		}
		if (IntersectsWith(rectangle.TopRight, rectangle.TopLeft, other.BottomLeft, other.BottomRight))
		{
			return true;
		}
		if (IntersectsWith(rectangle.TopRight, rectangle.TopLeft, other.BottomRight, other.TopRight))
		{
			return true;
		}
		if (IntersectsWith(rectangle.TopRight, rectangle.TopLeft, other.TopRight, other.TopLeft))
		{
			return true;
		}
		if (IntersectsWith(rectangle.TopRight, rectangle.TopLeft, other.TopLeft, other.BottomLeft))
		{
			return true;
		}
		if (IntersectsWith(rectangle.TopLeft, rectangle.BottomLeft, other.BottomLeft, other.BottomRight))
		{
			return true;
		}
		if (IntersectsWith(rectangle.TopLeft, rectangle.BottomLeft, other.BottomRight, other.TopRight))
		{
			return true;
		}
		if (IntersectsWith(rectangle.TopLeft, rectangle.BottomLeft, other.TopRight, other.TopLeft))
		{
			return true;
		}
		if (IntersectsWith(rectangle.TopLeft, rectangle.BottomLeft, other.TopLeft, other.BottomLeft))
		{
			return true;
		}
		return false;
	}

	public static bool IntersectsWith(this PdfPath path, PdfRectangle rectangle, bool includeBorder = false)
	{
		List<List<ClipperIntPoint>> paths = path.Select((PdfSubpath sp) => sp.ToClipperPolygon().ToList()).ToList();
		ClipperPolyFillType fillRule = ((path.FillingRule == FillingRule.NonZeroWinding) ? ClipperPolyFillType.NonZero : ClipperPolyFillType.EvenOdd);
		foreach (ClipperIntPoint item in rectangle.ToClipperPolygon())
		{
			if (PointInPaths(item, paths, fillRule, includeBorder))
			{
				return true;
			}
		}
		return false;
	}

	public static PdfRectangle? Intersect(this PdfRectangle rectangle, PdfRectangle other)
	{
		if (!rectangle.IntersectsWith(other))
		{
			return null;
		}
		return new PdfRectangle(Math.Max(rectangle.BottomLeft.X, other.BottomLeft.X), Math.Max(rectangle.BottomLeft.Y, other.BottomLeft.Y), Math.Min(rectangle.TopRight.X, other.TopRight.X), Math.Min(rectangle.TopRight.Y, other.TopRight.Y));
	}

	public static PdfRectangle Normalise(this PdfRectangle rectangle)
	{
		PdfPoint bottomLeft = rectangle.BottomLeft;
		PdfPoint bottomRight = rectangle.BottomRight;
		PdfPoint topLeft = rectangle.TopLeft;
		PdfPoint topRight = rectangle.TopRight;
		double x = Math.Min(Math.Min(bottomLeft.X, bottomRight.X), Math.Min(topLeft.X, topRight.X));
		double y = Math.Min(Math.Min(bottomLeft.Y, bottomRight.Y), Math.Min(topLeft.Y, topRight.Y));
		double x2 = Math.Max(Math.Max(bottomLeft.X, bottomRight.X), Math.Max(topLeft.X, topRight.X));
		double y2 = Math.Max(Math.Max(bottomLeft.Y, bottomRight.Y), Math.Max(topLeft.Y, topRight.Y));
		return new PdfRectangle(x, y, x2, y2);
	}

	public static bool IntersectsWith(this PdfRectangle rectangle, PdfLine line)
	{
		return IntersectsWith(rectangle, line.Point1, line.Point2);
	}

	public static PdfLine? Intersect(this PdfRectangle rectangle, PdfLine line)
	{
		PdfPoint[] array = Intersect(rectangle, line.Point1, line.Point2);
		if (array != null)
		{
			return new PdfLine(array[0], array[1]);
		}
		return null;
	}

	public static List<PdfLine> Intersect(this PdfRectangle rectangle, List<PdfLine> lines)
	{
		Clipper clipper = new Clipper();
		clipper.AddPath(rectangle.ToClipperPolygon().ToList(), ClipperPolyType.Clip, Closed: true);
		foreach (PdfLine line in lines)
		{
			clipper.AddPath(line.ToClipperIntPoint(), ClipperPolyType.Subject, Closed: false);
		}
		ClipperPolyTree clipperPolyTree = new ClipperPolyTree();
		if (clipper.Execute(ClipperClipType.Intersection, clipperPolyTree))
		{
			List<PdfLine> list = new List<PdfLine>();
			{
				foreach (ClipperPolyNode child in clipperPolyTree.Children)
				{
					list.Add(new PdfLine(new PdfPoint((double)child.Contour[0].X / 10000.0, (double)child.Contour[0].Y / 10000.0), new PdfPoint((double)child.Contour[1].X / 10000.0, (double)child.Contour[1].Y / 10000.0)));
				}
				return list;
			}
		}
		return new List<PdfLine>();
	}

	public static bool Contains(this PdfLine line, PdfPoint point)
	{
		return Contains(line.Point1, line.Point2, point);
	}

	public static bool IntersectsWith(this PdfLine line, PdfLine other)
	{
		return IntersectsWith(line.Point1, line.Point2, other.Point1, other.Point2);
	}

	public static bool IntersectsWith(this PdfLine line, PdfSubpath.Line other)
	{
		return IntersectsWith(line.Point1, line.Point2, other.From, other.To);
	}

	public static PdfPoint? Intersect(this PdfLine line, PdfLine other)
	{
		return Intersect(line.Point1, line.Point2, other.Point1, other.Point2);
	}

	public static PdfPoint? Intersect(this PdfLine line, PdfSubpath.Line other)
	{
		return Intersect(line.Point1, line.Point2, other.From, other.To);
	}

	public static bool ParallelTo(this PdfLine line, PdfLine other)
	{
		return ParallelTo(line.Point1, line.Point2, other.Point1, other.Point2);
	}

	public static bool ParallelTo(this PdfLine line, PdfSubpath.Line other)
	{
		return ParallelTo(line.Point1, line.Point2, other.From, other.To);
	}

	public static PdfLine? Intersect(this PdfLine line, PdfRectangle rectangle)
	{
		return rectangle.Intersect(line);
	}

	public static bool IntersectsWith(this PdfLine line, PdfRectangle rectangle)
	{
		return rectangle.IntersectsWith(line);
	}

	public static bool Contains(this PdfSubpath.Line line, PdfPoint point)
	{
		return Contains(line.From, line.To, point);
	}

	public static bool IntersectsWith(this PdfSubpath.Line line, PdfSubpath.Line other)
	{
		return IntersectsWith(line.From, line.To, other.From, other.To);
	}

	public static bool IntersectsWith(this PdfSubpath.Line line, PdfLine other)
	{
		return IntersectsWith(line.From, line.To, other.Point1, other.Point2);
	}

	public static PdfPoint? Intersect(this PdfSubpath.Line line, PdfSubpath.Line other)
	{
		return Intersect(line.From, line.To, other.From, other.To);
	}

	public static PdfPoint? Intersect(this PdfSubpath.Line line, PdfLine other)
	{
		return Intersect(line.From, line.To, other.Point1, other.Point2);
	}

	public static bool ParallelTo(this PdfSubpath.Line line, PdfSubpath.Line other)
	{
		return ParallelTo(line.From, line.To, other.From, other.To);
	}

	public static bool ParallelTo(this PdfSubpath.Line line, PdfLine other)
	{
		return ParallelTo(line.From, line.To, other.Point1, other.Point2);
	}

	private static bool Contains(PdfPoint pl1, PdfPoint pl2, PdfPoint point)
	{
		if (Math.Abs(pl2.X - pl1.X) < 1E-05)
		{
			if (Math.Abs(point.X - pl2.X) < 1E-05)
			{
				return (double)Math.Abs(Math.Sign(point.Y - pl2.Y) - Math.Sign(point.Y - pl1.Y)) > 1E-05;
			}
			return false;
		}
		if (Math.Abs(pl2.Y - pl1.Y) < 1E-05)
		{
			if (Math.Abs(point.Y - pl2.Y) < 1E-05)
			{
				return (double)Math.Abs(Math.Sign(point.X - pl2.X) - Math.Sign(point.X - pl1.X)) > 1E-05;
			}
			return false;
		}
		double num = (point.X - pl1.X) / (pl2.X - pl1.X);
		double num2 = (point.Y - pl1.Y) / (pl2.Y - pl1.Y);
		if (Math.Abs(num - num2) > 1E-05)
		{
			return false;
		}
		if (num >= 0.0)
		{
			return num - 1.0 <= 1E-05;
		}
		return false;
	}

	public static bool IntersectsWith(PdfPoint p11, PdfPoint p12, PdfPoint p21, PdfPoint p22)
	{
		if (ccw(p11, p12, p21) != ccw(p11, p12, p22))
		{
			return ccw(p21, p22, p11) != ccw(p21, p22, p12);
		}
		return false;
	}

	private static PdfPoint? Intersect(PdfPoint p11, PdfPoint p12, PdfPoint p21, PdfPoint p22)
	{
		if (!IntersectsWith(p11, p12, p21, p22))
		{
			return null;
		}
		var (num, num2) = GetSlopeIntercept(p11, p12);
		var (num3, num4) = GetSlopeIntercept(p21, p22);
		if (double.IsNaN(num))
		{
			double num5 = num2;
			double y = num3 * num5 + num4;
			return new PdfPoint(num5, y);
		}
		if (double.IsNaN(num3))
		{
			double num6 = num4;
			double y2 = num * num6 + num2;
			return new PdfPoint(num6, y2);
		}
		double num7 = (num4 - num2) / (num - num3);
		double y3 = num * num7 + num2;
		return new PdfPoint(num7, y3);
	}

	private static PdfPoint[]? Intersect(PdfRectangle rectangle, PdfPoint pl1, PdfPoint pl2)
	{
		Clipper clipper = new Clipper();
		clipper.AddPath(rectangle.ToClipperPolygon().ToList(), ClipperPolyType.Clip, Closed: true);
		clipper.AddPath(new List<ClipperIntPoint>(2)
		{
			pl1.ToClipperIntPoint(),
			pl2.ToClipperIntPoint()
		}, ClipperPolyType.Subject, Closed: false);
		ClipperPolyTree clipperPolyTree = new ClipperPolyTree();
		if (clipper.Execute(ClipperClipType.Intersection, clipperPolyTree))
		{
			if (clipperPolyTree.Children.Count == 0)
			{
				return null;
			}
			if (clipperPolyTree.Children.Count == 1)
			{
				ClipperPolyNode clipperPolyNode = clipperPolyTree.Children[0];
				return new PdfPoint[2]
				{
					new PdfPoint((double)clipperPolyNode.Contour[0].X / 10000.0, (double)clipperPolyNode.Contour[0].Y / 10000.0),
					new PdfPoint((double)clipperPolyNode.Contour[1].X / 10000.0, (double)clipperPolyNode.Contour[1].Y / 10000.0)
				};
			}
			throw new ArgumentException("GeometryExtensions.Intersect(PdfRectangle, PdfPoint, PdfPoint): more than one solution found.");
		}
		return null;
	}

	public static bool IntersectsWith(PdfRectangle rectangle, PdfPoint pl1, PdfPoint pl2)
	{
		Clipper clipper = new Clipper();
		clipper.AddPath(rectangle.ToClipperPolygon().ToList(), ClipperPolyType.Clip, Closed: true);
		clipper.AddPath(new List<ClipperIntPoint>
		{
			pl1.ToClipperIntPoint(),
			pl2.ToClipperIntPoint()
		}, ClipperPolyType.Subject, Closed: false);
		ClipperPolyTree clipperPolyTree = new ClipperPolyTree();
		if (clipper.Execute(ClipperClipType.Intersection, clipperPolyTree))
		{
			return clipperPolyTree.Children.Count > 0;
		}
		return false;
	}

	private static bool ParallelTo(PdfPoint p11, PdfPoint p12, PdfPoint p21, PdfPoint p22)
	{
		return Math.Abs((p12.Y - p11.Y) * (p22.X - p21.X) - (p22.Y - p21.Y) * (p12.X - p11.X)) < 1E-05;
	}

	public static (PdfSubpath.CubicBezierCurve, PdfSubpath.CubicBezierCurve) Split(this PdfSubpath.CubicBezierCurve bezierCurve, double tau)
	{
		PdfPoint[][] array = new PdfPoint[4][]
		{
			new PdfPoint[4] { bezierCurve.StartPoint, bezierCurve.FirstControlPoint, bezierCurve.SecondControlPoint, bezierCurve.EndPoint },
			new PdfPoint[3],
			new PdfPoint[2],
			new PdfPoint[1]
		};
		for (int i = 1; i <= 3; i++)
		{
			for (int j = 0; j <= 3 - i; j++)
			{
				double x = (1.0 - tau) * array[i - 1][j].X + tau * array[i - 1][j + 1].X;
				double y = (1.0 - tau) * array[i - 1][j].Y + tau * array[i - 1][j + 1].Y;
				array[i][j] = new PdfPoint(x, y);
			}
		}
		return (new PdfSubpath.CubicBezierCurve(array[0][0], array[1][0], array[2][0], array[3][0]), new PdfSubpath.CubicBezierCurve(array[3][0], array[2][1], array[1][2], array[0][3]));
	}

	public static bool IntersectsWith(this PdfSubpath.CubicBezierCurve bezierCurve, PdfLine line)
	{
		return IntersectsWith(bezierCurve, line.Point1, line.Point2);
	}

	public static bool IntersectsWith(this PdfSubpath.CubicBezierCurve bezierCurve, PdfSubpath.Line line)
	{
		return IntersectsWith(bezierCurve, line.From, line.To);
	}

	private static bool IntersectsWith(PdfSubpath.CubicBezierCurve bezierCurve, PdfPoint p1, PdfPoint p2)
	{
		return Intersect(bezierCurve, p1, p2).Length != 0;
	}

	public static PdfPoint[] Intersect(this PdfSubpath.CubicBezierCurve bezierCurve, PdfLine line)
	{
		return Intersect(bezierCurve, line.Point1, line.Point2);
	}

	public static PdfPoint[] Intersect(this PdfSubpath.CubicBezierCurve bezierCurve, PdfSubpath.Line line)
	{
		return Intersect(bezierCurve, line.From, line.To);
	}

	private static PdfPoint[] Intersect(PdfSubpath.CubicBezierCurve bezierCurve, PdfPoint p1, PdfPoint p2)
	{
		double[] array = IntersectT(bezierCurve, p1, p2);
		if (array == null || array.Length == 0)
		{
			return Array.Empty<PdfPoint>();
		}
		List<PdfPoint> list = new List<PdfPoint>();
		double[] array2 = array;
		foreach (double t in array2)
		{
			PdfPoint pdfPoint = new PdfPoint(PdfSubpath.BezierCurve.ValueWithT(bezierCurve.StartPoint.X, bezierCurve.FirstControlPoint.X, bezierCurve.SecondControlPoint.X, bezierCurve.EndPoint.X, t), PdfSubpath.BezierCurve.ValueWithT(bezierCurve.StartPoint.Y, bezierCurve.FirstControlPoint.Y, bezierCurve.SecondControlPoint.Y, bezierCurve.EndPoint.Y, t));
			if (Contains(p1, p2, pdfPoint))
			{
				list.Add(pdfPoint);
			}
		}
		return list.ToArray();
	}

	public static double[]? IntersectT(this PdfSubpath.CubicBezierCurve bezierCurve, PdfLine line)
	{
		return IntersectT(bezierCurve, line.Point1, line.Point2);
	}

	public static double[]? IntersectT(this PdfSubpath.CubicBezierCurve bezierCurve, PdfSubpath.Line line)
	{
		return IntersectT(bezierCurve, line.From, line.To);
	}

	private static double[]? IntersectT(PdfSubpath.CubicBezierCurve bezierCurve, PdfPoint p1, PdfPoint p2)
	{
		PdfRectangle? boundingRectangle = bezierCurve.GetBoundingRectangle();
		if (!boundingRectangle.HasValue)
		{
			return null;
		}
		if (boundingRectangle.Value.Left > Math.Max(p1.X, p2.X) || Math.Min(p1.X, p2.X) > boundingRectangle.Value.Right)
		{
			return null;
		}
		if (boundingRectangle.Value.Top < Math.Min(p1.Y, p2.Y) || Math.Max(p1.Y, p2.Y) < boundingRectangle.Value.Bottom)
		{
			return null;
		}
		double num = p2.Y - p1.Y;
		double num2 = p1.X - p2.X;
		double num3 = p1.X * (p1.Y - p2.Y) + p1.Y * (p2.X - p1.X);
		double num4 = bezierCurve.StartPoint.X * num + bezierCurve.StartPoint.Y * num2;
		double num5 = 3.0 * (bezierCurve.FirstControlPoint.X * num + bezierCurve.FirstControlPoint.Y * num2);
		double num6 = 3.0 * (bezierCurve.SecondControlPoint.X * num + bezierCurve.SecondControlPoint.Y * num2);
		double num7 = bezierCurve.EndPoint.X * num + bezierCurve.EndPoint.Y * num2;
		double a = 0.0 - num4 + num5 - num6 + num7;
		double b = 3.0 * num4 - 2.0 * num5 + num6;
		double c = -3.0 * num4 + num5;
		double d = num4 + num3;
		return (from s in SolveCubicEquation(a, b, c, d)
			where !double.IsNaN(s) && s >= -1E-05 && s - 1.0 <= 1E-05
			orderby s
			select s).ToArray();
	}

	private static double CrossProduct(ClipperIntPoint pt1, ClipperIntPoint pt2, ClipperIntPoint pt3)
	{
		return (pt2.X - pt1.X) * (pt3.Y - pt2.Y) - (pt2.Y - pt1.Y) * (pt3.X - pt2.X);
	}

	private static int PointInPathsWindingCount(ClipperIntPoint pt, List<List<ClipperIntPoint>> paths)
	{
		int num = 0;
		for (int i = 0; i < paths.Count; i++)
		{
			int j = 0;
			List<ClipperIntPoint> list = paths[i];
			int count = list.Count;
			if (count < 3)
			{
				continue;
			}
			ClipperIntPoint pt2;
			for (pt2 = list[count - 1]; j < count && list[j].Y == pt2.Y; j++)
			{
			}
			if (j == count)
			{
				continue;
			}
			bool flag = pt2.Y < pt.Y;
			while (j < count)
			{
				if (flag)
				{
					for (; j < count && list[j].Y < pt.Y; j++)
					{
					}
					if (j == count)
					{
						break;
					}
					if (j > 0)
					{
						pt2 = list[j - 1];
					}
					double num2 = CrossProduct(pt2, list[j], pt);
					if (num2 == 0.0)
					{
						return int.MaxValue;
					}
					if (num2 < 0.0)
					{
						num--;
					}
				}
				else
				{
					for (; j < count && list[j].Y > pt.Y; j++)
					{
					}
					if (j == count)
					{
						break;
					}
					if (j > 0)
					{
						pt2 = list[j - 1];
					}
					double num3 = CrossProduct(pt2, list[j], pt);
					if (num3 == 0.0)
					{
						return int.MaxValue;
					}
					if (num3 > 0.0)
					{
						num++;
					}
				}
				j++;
				flag = !flag;
			}
		}
		return num;
	}

	private static bool PointInPaths(ClipperIntPoint pt, List<List<ClipperIntPoint>> paths, ClipperPolyFillType fillRule, bool includeBorder)
	{
		int num = PointInPathsWindingCount(pt, paths);
		if (num == int.MaxValue)
		{
			return includeBorder;
		}
		if (fillRule == ClipperPolyFillType.EvenOdd || fillRule != ClipperPolyFillType.NonZero)
		{
			return num % 2 != 0;
		}
		return num != 0;
	}

	public static bool Contains(this PdfSubpath subpath, PdfPoint point, bool includeBorder = false)
	{
		return PointInPaths(point.ToClipperIntPoint(), new List<List<ClipperIntPoint>> { subpath.ToClipperPolygon().ToList() }, ClipperPolyFillType.EvenOdd, includeBorder);
	}

	public static bool Contains(this PdfSubpath subpath, PdfRectangle rectangle, bool includeBorder = false)
	{
		List<List<ClipperIntPoint>> paths = new List<List<ClipperIntPoint>> { subpath.ToClipperPolygon().ToList() };
		foreach (ClipperIntPoint item in rectangle.ToClipperPolygon())
		{
			if (!PointInPaths(item, paths, ClipperPolyFillType.EvenOdd, includeBorder))
			{
				return false;
			}
		}
		return true;
	}

	public static bool Contains(this PdfSubpath subpath, PdfSubpath other, bool includeBorder = false)
	{
		List<List<ClipperIntPoint>> paths = new List<List<ClipperIntPoint>> { subpath.ToClipperPolygon().ToList() };
		foreach (ClipperIntPoint item in other.ToClipperPolygon())
		{
			if (!PointInPaths(item, paths, ClipperPolyFillType.EvenOdd, includeBorder))
			{
				return false;
			}
		}
		return true;
	}

	public static double GetArea(this PdfPath path)
	{
		List<List<ClipperIntPoint>> list = Clipper.SimplifyPolygons(path.Select((PdfSubpath sp) => sp.ToClipperPolygon().ToList()).ToList(), (path.FillingRule == FillingRule.NonZeroWinding) ? ClipperPolyFillType.NonZero : ClipperPolyFillType.EvenOdd);
		double num = 0.0;
		foreach (List<ClipperIntPoint> item in list)
		{
			num += Clipper.Area(item);
		}
		return num;
	}

	public static bool Contains(this PdfPath path, PdfPoint point, bool includeBorder = false)
	{
		List<List<ClipperIntPoint>> paths = path.Select((PdfSubpath sp) => sp.ToClipperPolygon().ToList()).ToList();
		return PointInPaths(point.ToClipperIntPoint(), paths, (path.FillingRule == FillingRule.NonZeroWinding) ? ClipperPolyFillType.NonZero : ClipperPolyFillType.EvenOdd, includeBorder);
	}

	public static bool Contains(this PdfPath path, PdfRectangle rectangle, bool includeBorder = false)
	{
		List<List<ClipperIntPoint>> paths = path.Select((PdfSubpath sp) => sp.ToClipperPolygon().ToList()).ToList();
		ClipperPolyFillType fillRule = ((path.FillingRule == FillingRule.NonZeroWinding) ? ClipperPolyFillType.NonZero : ClipperPolyFillType.EvenOdd);
		foreach (ClipperIntPoint item in rectangle.ToClipperPolygon())
		{
			if (!PointInPaths(item, paths, fillRule, includeBorder))
			{
				return false;
			}
		}
		return true;
	}

	public static bool Contains(this PdfPath path, PdfSubpath subpath, bool includeBorder = false)
	{
		List<List<ClipperIntPoint>> paths = path.Select((PdfSubpath sp) => sp.ToClipperPolygon().ToList()).ToList();
		ClipperPolyFillType fillRule = ((path.FillingRule == FillingRule.NonZeroWinding) ? ClipperPolyFillType.NonZero : ClipperPolyFillType.EvenOdd);
		foreach (ClipperIntPoint item in subpath.ToClipperPolygon())
		{
			if (!PointInPaths(item, paths, fillRule, includeBorder))
			{
				return false;
			}
		}
		return true;
	}

	public static bool Contains(this PdfPath path, PdfPath other, bool includeBorder = false)
	{
		List<List<ClipperIntPoint>> paths = path.Select((PdfSubpath sp) => sp.ToClipperPolygon().ToList()).ToList();
		ClipperPolyFillType fillRule = ((path.FillingRule == FillingRule.NonZeroWinding) ? ClipperPolyFillType.NonZero : ClipperPolyFillType.EvenOdd);
		foreach (PdfSubpath item in other)
		{
			foreach (ClipperIntPoint item2 in item.ToClipperPolygon())
			{
				if (!PointInPaths(item2, paths, fillRule, includeBorder))
				{
					return false;
				}
			}
		}
		return true;
	}

	private static (double Slope, double Intercept) GetSlopeIntercept(PdfPoint point1, PdfPoint point2)
	{
		if (Math.Abs(point1.X - point2.X) > 1E-05)
		{
			double num = (point2.Y - point1.Y) / (point2.X - point1.X);
			double item = point2.Y - num * point2.X;
			return (Slope: num, Intercept: item);
		}
		return (Slope: double.NaN, Intercept: point1.X);
	}

	private static double CubicRoot(double d)
	{
		if (d < 0.0)
		{
			return 0.0 - Math.Pow(0.0 - d, 1.0 / 3.0);
		}
		return Math.Pow(d, 1.0 / 3.0);
	}

	private static double[] SolveCubicEquation(double a, double b, double c, double d)
	{
		if (Math.Abs(a) <= 1E-05)
		{
			double num = c * c - 4.0 * b * d;
			if (num >= 0.0)
			{
				double num2 = Math.Sqrt(num);
				double num3 = 1.0 / (2.0 * b);
				double num4 = (0.0 - c + num2) * num3;
				double num5 = (0.0 - c - num2) * num3;
				return new double[2] { num4, num5 };
			}
			return Array.Empty<double>();
		}
		double num6 = a * a;
		double num7 = num6 * a;
		double num8 = b * b * b;
		double num9 = a * b * c;
		double num10 = b / (3.0 * a);
		double num11 = (3.0 * a * c - b * b) / (9.0 * num6);
		double num12 = (9.0 * num9 - 27.0 * num6 * d - 2.0 * num8) / (54.0 * num7);
		double num13 = num11 * num11 * num11 + num12 * num12;
		double num14 = double.NaN;
		double num15 = double.NaN;
		double num16 = double.NaN;
		if (num13 >= 0.0)
		{
			double num17 = Math.Sqrt(num13);
			double num18 = CubicRoot(num12 + num17);
			double num19 = CubicRoot(num12 - num17);
			double num20 = num18 + num19;
			num14 = num20 - num10;
			if (Math.Abs(0.86602540378444 * (num18 - num19)) <= 1E-05)
			{
				num15 = (0.0 - num20) / 2.0 - num10;
			}
		}
		else
		{
			double p_ = num11 * 3.0;
			double q_ = (0.0 - num12) * 2.0;
			num14 = vietTrigonometricSolution(p_, q_, 0.0) - num10;
			num15 = vietTrigonometricSolution(p_, q_, 1.0) - num10;
			num16 = vietTrigonometricSolution(p_, q_, 2.0) - num10;
		}
		return new double[3] { num14, num15, num16 };
		static double vietTrigonometricSolution(double num21, double num22, double k)
		{
			return 2.0 * Math.Sqrt((0.0 - num21) / 3.0) * Math.Cos(1.0 / 3.0 * Math.Acos(3.0 * num22 / (2.0 * num21) * Math.Sqrt(-3.0 / num21)) - Math.PI * 2.0 * k / 3.0);
		}
	}

	internal static string ToSvg(this PdfSubpath p, double height)
	{
		StringBuilder stringBuilder = new StringBuilder();
		foreach (PdfSubpath.IPathCommand command in p.Commands)
		{
			command.WriteSvg(stringBuilder, height);
		}
		if (stringBuilder.Length == 0)
		{
			return string.Empty;
		}
		if (stringBuilder[stringBuilder.Length - 1] == ' ')
		{
			stringBuilder.Remove(stringBuilder.Length - 1, 1);
		}
		return stringBuilder.ToString();
	}

	internal static string ToFullSvg(this PdfSubpath p, double height)
	{
		string text = p.ToSvg(height);
		PdfRectangle? boundingRectangle = p.GetBoundingRectangle();
		List<PdfRectangle> list = new List<PdfRectangle>();
		foreach (PdfSubpath.IPathCommand command in p.Commands)
		{
			PdfRectangle? boundingRectangle2 = command.GetBoundingRectangle();
			if (boundingRectangle2.HasValue)
			{
				list.Add(boundingRectangle2.Value);
			}
		}
		string text2 = "<path d='" + text + "' stroke='cyan' stroke-width='3'></path>";
		string text3 = (boundingRectangle.HasValue ? BboxToRect(boundingRectangle.Value, "yellow") : string.Empty);
		string text4 = string.Join(" ", list.Select((PdfRectangle x) => BboxToRect(x, "gray")));
		return "<svg width='500' height='500'><g transform=\"scale(0.2, -0.2) translate(100, -700)\">" + text2 + " " + text3 + " " + text4 + "</g></svg>";
		static string BboxToRect(PdfRectangle box, string stroke)
		{
			return $"<rect x='{box.Left}' y='{box.Bottom}' width='{box.Width}' height='{box.Height}' stroke-width='2' fill='none' stroke='{stroke}'></rect>";
		}
	}
}
