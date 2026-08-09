using System;
using System.Collections.Generic;
using devDept.Serialization;

namespace devDept.Geometry;

[Serializable]
public class Polygon2D : ICloneable
{
	public Point2D Min;

	public Point2D Max;

	public Point2D[] Points;

	private double diagonal;

	public Point2D this[int index]
	{
		get
		{
			return Points[index];
		}
		set
		{
			Points[index] = value;
		}
	}

	public int VertexCount => Points.Length;

	public Size2D Size
	{
		get
		{
			if (!(Max != null) || !(Min != null))
			{
				return null;
			}
			return new Size2D(Max.X - Min.X, Max.Y - Min.Y);
		}
	}

	public bool IsClosed
	{
		get
		{
			if (Points.Length < 3)
			{
				return false;
			}
			if (Min == null)
			{
				return Points[0].Equals(Points[Points.Length - 1]);
			}
			return Point2D.AreEqual(Points[0], Points[Points.Length - 1], Size.Diagonal);
		}
	}

	public Polygon2D(int numPoints)
	{
		Points = new Point2D[numPoints];
	}

	public Polygon2D(IList<Point2D> points)
	{
		Points = new Point2D[points.Count];
		points.CopyTo(Points, 0);
	}

	public Polygon2D(Point2D[] points, Point2D min, Point2D max)
	{
		Points = points;
		Min = min;
		Max = max;
		_0023_003DzKMCOeVQ4rvzKk9kEQk6apKg_003D();
	}

	protected Polygon2D(Polygon2D another)
	{
		Points = new Point2D[another.Points.Length];
		for (int i = 0; i < Points.Length; i++)
		{
			Points[i] = (Point2D)another.Points[i].Clone();
		}
		if (another.Min != null)
		{
			Min = (Point2D)another.Min.Clone();
			Max = (Point2D)another.Max.Clone();
			_0023_003DzKMCOeVQ4rvzKk9kEQk6apKg_003D();
		}
	}

	public void UpdateBoundingRect()
	{
		Utility.BoundingRect(Points, out Min, out Max);
		_0023_003DzKMCOeVQ4rvzKk9kEQk6apKg_003D();
	}

	public bool IsValid()
	{
		if (Min == null)
		{
			return false;
		}
		if (Max == null)
		{
			return false;
		}
		return Point2D.AreEqual(Points[0], Points[Points.Length - 1], new Size2D(Min, Max).Diagonal);
	}

	public bool PointInsideBoundingRect(Point2D testPoint)
	{
		if (testPoint.X > Min.X && testPoint.X < Max.X && testPoint.Y > Min.Y && testPoint.Y < Max.Y)
		{
			return true;
		}
		return false;
	}

	public bool PointInsideOrOntoBoundingRect(Point2D testPoint)
	{
		return _0023_003DzpafCN4d7z2wvmPWzeBWCzRw_003D(testPoint, diagonal);
	}

	private bool _0023_003DzpafCN4d7z2wvmPWzeBWCzRw_003D(Point2D _0023_003DzZTe_0024jFG9ebLg, double _0023_003DzxH4ozIo_003D)
	{
		if ((Utility.AreEqual(_0023_003DzZTe_0024jFG9ebLg.X, Min.X, _0023_003DzxH4ozIo_003D) || _0023_003DzZTe_0024jFG9ebLg.X > Min.X) && (Utility.AreEqual(_0023_003DzZTe_0024jFG9ebLg.X, Max.X, _0023_003DzxH4ozIo_003D) || _0023_003DzZTe_0024jFG9ebLg.X < Max.X) && (Utility.AreEqual(_0023_003DzZTe_0024jFG9ebLg.Y, Min.Y, _0023_003DzxH4ozIo_003D) || _0023_003DzZTe_0024jFG9ebLg.Y > Min.Y) && (Utility.AreEqual(_0023_003DzZTe_0024jFG9ebLg.Y, Max.Y, _0023_003DzxH4ozIo_003D) || _0023_003DzZTe_0024jFG9ebLg.Y < Max.Y))
		{
			return true;
		}
		return false;
	}

	public bool IsOrientedClockwise()
	{
		return Utility.PolygonArea(Points) < 0.0;
	}

	public bool IsConvex()
	{
		return Utility.IsPolygonConvex(Points);
	}

	public bool IsSelfIntersecting()
	{
		return Utility.IsPolygonSelfIntersecting(Points);
	}

	public bool IsDegenerated()
	{
		return Utility.IsPolygonDegenerated(Points);
	}

	public bool IsCollapsed()
	{
		return Utility.IsPolygonCollapsed(Points);
	}

	public void Reverse()
	{
		Array.Reverse(Points);
	}

	public bool IsPointInside(Point2D testPoint)
	{
		if (!PointInsideBoundingRect(testPoint))
		{
			return false;
		}
		int num = Points.Length;
		int num2 = 0;
		int num3 = 0;
		int num4 = num - 1;
		while (num3 < num)
		{
			if (((Points[num3].Y <= testPoint.Y && testPoint.Y < Points[num4].Y) || (Points[num4].Y <= testPoint.Y && testPoint.Y < Points[num3].Y)) && testPoint.X < (Points[num4].X - Points[num3].X) * (testPoint.Y - Points[num3].Y) / (Points[num4].Y - Points[num3].Y) + Points[num3].X)
			{
				num2++;
			}
			num4 = num3++;
		}
		return (num2 & 1) == 1;
	}

	public pointStatusType IsPointInside(Point2D testPoint, double domainSize)
	{
		if (!_0023_003DzpafCN4d7z2wvmPWzeBWCzRw_003D(testPoint, domainSize))
		{
			return pointStatusType.Outside;
		}
		int num = Points.Length;
		for (int i = 0; i < num - 1; i++)
		{
			if (Utility.IsPointOnSegment(testPoint, Points[i], Points[i + 1], domainSize))
			{
				return pointStatusType.Onto;
			}
		}
		int num2 = 0;
		int num3 = 0;
		int num4 = num - 1;
		while (num3 < num)
		{
			if (((Points[num3].Y <= testPoint.Y && testPoint.Y < Points[num4].Y) || (Points[num4].Y <= testPoint.Y && testPoint.Y < Points[num3].Y)) && testPoint.X < (Points[num4].X - Points[num3].X) * (testPoint.Y - Points[num3].Y) / (Points[num4].Y - Points[num3].Y) + Points[num3].X)
			{
				num2++;
			}
			num4 = num3++;
		}
		if ((num2 & 1) != 0)
		{
			return pointStatusType.Inside;
		}
		return pointStatusType.Outside;
	}

	public polygonStatusType IsPolygonInside(Polygon2D subject, double domainSize)
	{
		if (!Utility.DoOverlapOrTouch(Min, Max, subject.Min, subject.Max, domainSize))
		{
			return polygonStatusType.Out;
		}
		int num = Points.Length;
		int num2 = subject.Points.Length;
		for (int i = 0; i < num2 - 1; i++)
		{
			Segment2D s = new Segment2D(subject.Points[i], subject.Points[i + 1]);
			for (int j = 0; j < num - 1; j++)
			{
				if (Segment2D.Intersection(new Segment2D(Points[j], Points[j + 1]), s, out var _, out var _, domainSize) == segmentIntersectionType.Cross)
				{
					return polygonStatusType.On;
				}
			}
		}
		int num3 = 0;
		int num4 = 0;
		int num5 = 0;
		int num6 = 0;
		int num7 = 0;
		for (int k = 0; k < num2 - 1; k++)
		{
			switch (IsPointInside(subject[k], domainSize * 1000.0))
			{
			case pointStatusType.Inside:
				num3++;
				break;
			case pointStatusType.Outside:
				num4++;
				break;
			case pointStatusType.Onto:
				num5++;
				break;
			}
			switch (IsPointInside(Point2D.MidPoint(subject.Points[k], subject.Points[k + 1]), domainSize * 1000.0))
			{
			case pointStatusType.Inside:
				num6++;
				break;
			case pointStatusType.Outside:
				num7++;
				break;
			}
		}
		if (num3 > 0 && num4 > 0)
		{
			return polygonStatusType.On;
		}
		if (num4 == 0 && num7 == 0)
		{
			return polygonStatusType.In;
		}
		bool flag = false;
		for (int l = 0; l < num - 1; l++)
		{
			if (subject.IsPointInside(Points[l], domainSize * 1000.0) == pointStatusType.Inside)
			{
				flag = true;
				break;
			}
			if (subject.IsPointInside(Point2D.MidPoint(Points[l], Points[l + 1]), domainSize * 1000.0) == pointStatusType.Inside)
			{
				flag = true;
				break;
			}
		}
		if (num4 + num5 == num2 - 1 && flag && num6 == 0)
		{
			return polygonStatusType.Over;
		}
		if (num4 > 0 && num6 > 0)
		{
			return polygonStatusType.On;
		}
		if (num7 < num2 - 1 && num6 > 0)
		{
			return polygonStatusType.On;
		}
		if (num4 > 0)
		{
			return polygonStatusType.Out;
		}
		return polygonStatusType.In;
	}

	public bool IsPolygonInside(Polygon2D subject)
	{
		if (!Utility.DoOverlap(Min, Max, subject.Min, subject.Max))
		{
			return false;
		}
		int num = subject.Points.Length;
		int num2 = 0;
		for (int i = 0; i < num - 1; i++)
		{
			if (IsPointInside(subject[i]))
			{
				num2++;
			}
		}
		if (num2 == num - 1)
		{
			return true;
		}
		return false;
	}

	private void _0023_003DzKMCOeVQ4rvzKk9kEQk6apKg_003D()
	{
		double num = Max.X - Min.X;
		double num2 = Max.Y - Min.Y;
		diagonal = Math.Sqrt(num * num + num2 * num2);
	}

	public virtual object Clone()
	{
		return new Polygon2D(this);
	}

	public void TransformBy(Transformation t)
	{
		int num = Points.Length;
		for (int i = 0; i < num; i++)
		{
			Point2D point2D = Points[i];
			double[] array = t.ActOnLeft(point2D.X, point2D.Y, 0.0, 1.0);
			double num2 = ((array[3] != 0.0) ? (1.0 / array[3]) : 1.0);
			point2D.X = num2 * array[0];
			point2D.Y = num2 * array[1];
		}
		UpdateBoundingRect();
	}

	public bool Intersect(Segment2D rectSeg)
	{
		for (int i = 0; i < Points.Length - 1; i++)
		{
			if (Segment2D.Intersection(new Segment2D(Points[i], Points[i + 1]), rectSeg, out var _))
			{
				return true;
			}
		}
		return false;
	}

	public Point2D[] IntersecWithCrossAndT(Segment2D segment)
	{
		List<Point2D> list = new List<Point2D>();
		Point2D b = null;
		for (int i = 0; i < Points.Length - 1; i++)
		{
			if (Segment2D.IntersectionAndT(new Segment2D(Points[i], Points[i + 1]), segment, out var i2) && i2 != null && (list.Count == 0 || i2.DistanceTo(b) > 1E-12))
			{
				list.Add(i2);
				b = i2;
			}
		}
		if (list.Count > 1 && list[0].DistanceTo(b) < 1E-12)
		{
			list.RemoveAt(list.Count - 1);
		}
		return list.ToArray();
	}

	public Point2D[] IntersecWithCrossAndTAndL(Segment2D segment)
	{
		List<Point2D> list = new List<Point2D>();
		Point2D b = null;
		for (int i = 0; i < Points.Length - 1; i++)
		{
			Segment2D segment2D = new Segment2D(Points[i], Points[i + 1]);
			if (Segment2D.IntersectionAndT(segment2D, segment, out var i2))
			{
				if (i2 != null && (list.Count == 0 || i2.DistanceTo(b) > 1E-12))
				{
					list.Add(i2);
					b = i2;
				}
			}
			else if (Point2D.Distance(segment2D.P0, segment.P1) < 1E-12 || Point2D.Distance(segment2D.P0, segment.P0) < 1E-12)
			{
				if (list.Count == 0 || segment2D.P0.DistanceTo(b) > 1E-12)
				{
					list.Add(segment2D.P0);
					b = segment2D.P0;
				}
			}
			else if ((Point2D.Distance(segment2D.P1, segment.P1) < 1E-12 || Point2D.Distance(segment2D.P1, segment.P0) < 1E-12) && (list.Count == 0 || segment2D.P1.DistanceTo(b) > 1E-12))
			{
				list.Add(segment2D.P1);
				b = segment2D.P1;
			}
		}
		if (list.Count > 1 && list[0].DistanceTo(b) < 1E-12)
		{
			list.RemoveAt(list.Count - 1);
		}
		return list.ToArray();
	}

	public bool IntersectWith(Segment2D segment)
	{
		for (int i = 0; i < Points.Length - 1; i++)
		{
			if (Segment2D.Intersection(new Segment2D(Points[i], Points[i + 1]), segment, out var _))
			{
				return true;
			}
		}
		return false;
	}

	public polygonStatusType IsBoxInside(Point2D min, Point2D max)
	{
		if (!Utility._0023_003DzGBcHaJW_L4SQ(Min, Max, min, max, out var _0023_003Dzsc0Foo8_003D, out var _))
		{
			return polygonStatusType.Out;
		}
		if (_0023_003Dzsc0Foo8_003D)
		{
			return polygonStatusType.Over;
		}
		for (int i = 0; i < Points.Length - 1; i++)
		{
			if (new Segment2D(Points[i], Points[i + 1]).DoesIntersectBox(min, max))
			{
				return polygonStatusType.On;
			}
		}
		if (!IsPointInside(min))
		{
			return polygonStatusType.Out;
		}
		return polygonStatusType.In;
	}

	public virtual Polygon2DSurrogate ConvertToSurrogate()
	{
		return new Polygon2DSurrogate(this);
	}
}
