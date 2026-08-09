using System;
using System.Collections.Generic;
using Poly2Tri.Utility;
using ns54;

namespace Poly2Tri.Triangulation.Polygon;

public class PolygonOperationContext
{
	public PolygonUtil.PolyOperation Operations;

	public Point2DList OriginalPolygon2;

	public Point2DList Poly1;

	public Point2DList Poly2;

	public List<EdgeIntersectInfo> Intersections;

	public int StartingIndex;

	public PolygonUtil.PolyUnionError Error;

	public List<int> Poly1VectorAngles;

	public List<int> Poly2VectorAngles;

	public Dictionary<uint, Point2DList> Output = new Dictionary<uint, Point2DList>();

	public Point2DList Union
	{
		get
		{
			if (!Output.TryGetValue(1u, out var value))
			{
				value = new Point2DList();
				Output.Add(1u, value);
			}
			return value;
		}
	}

	public Point2DList Intersect
	{
		get
		{
			if (!Output.TryGetValue(2u, out var value))
			{
				value = new Point2DList();
				Output.Add(2u, value);
			}
			return value;
		}
	}

	public Point2DList Subtract
	{
		get
		{
			if (!Output.TryGetValue(4u, out var value))
			{
				value = new Point2DList();
				Output.Add(4u, value);
			}
			return value;
		}
	}

	public void Clear()
	{
		Operations = PolygonUtil.PolyOperation.None;
		OriginalPolygon2 = null;
		Poly1 = null;
		Poly2 = null;
		Intersections = null;
		StartingIndex = -1;
		Error = PolygonUtil.PolyUnionError.None;
		Poly1VectorAngles = null;
		Poly2VectorAngles = null;
		Output = new Dictionary<uint, Point2DList>();
	}

	public bool Init(PolygonUtil.PolyOperation operations, Point2DList polygon1, Point2DList polygon2)
	{
		Clear();
		Operations = operations;
		OriginalPolygon2 = polygon2;
		Poly1 = new Point2DList(polygon1)
		{
			WindingOrder = Point2DList.WindingOrderType.AntiClockwise
		};
		Poly2 = new Point2DList(polygon2)
		{
			WindingOrder = Point2DList.WindingOrderType.AntiClockwise
		};
		Point2DList poly = Poly1;
		Point2DList poly2 = Poly2;
		if (Class156.smethod_238(poly2, poly, out Intersections))
		{
			int count = Intersections.Count;
			for (int i = 0; i < count; i++)
			{
				for (int j = i + 1; j < count; j++)
				{
					if (Intersections[i].EdgeOne.EdgeStart.Equals(Intersections[j].EdgeOne.EdgeStart) && Intersections[i].EdgeOne.EdgeEnd.Equals(Intersections[j].EdgeOne.EdgeEnd))
					{
						Intersections[j].EdgeOne.EdgeStart = Intersections[i].IntersectionPoint;
					}
					if (Intersections[i].EdgeTwo.EdgeStart.Equals(Intersections[j].EdgeTwo.EdgeStart) && Intersections[i].EdgeTwo.EdgeEnd.Equals(Intersections[j].EdgeTwo.EdgeEnd))
					{
						Intersections[j].EdgeTwo.EdgeStart = Intersections[i].IntersectionPoint;
					}
				}
			}
			foreach (EdgeIntersectInfo intersection in Intersections)
			{
				if (!Poly1.Contains(intersection.IntersectionPoint))
				{
					Poly1.Insert(Poly1.IndexOf(intersection.EdgeOne.EdgeStart) + 1, intersection.IntersectionPoint);
				}
				if (!Poly2.Contains(intersection.IntersectionPoint))
				{
					Poly2.Insert(Poly2.IndexOf(intersection.EdgeTwo.EdgeStart) + 1, intersection.IntersectionPoint);
				}
			}
			Poly1VectorAngles = new List<int>();
			for (int k = 0; k < Poly2.Count; k++)
			{
				Poly1VectorAngles.Add(-1);
			}
			Poly2VectorAngles = new List<int>();
			for (int l = 0; l < Poly1.Count; l++)
			{
				Poly2VectorAngles.Add(-1);
			}
			int num = 0;
			do
			{
				bool flag = PointInPolygonAngle(Poly1[num], Poly2);
				Poly2VectorAngles[num] = (flag ? 1 : 0);
				if (!flag)
				{
					num = Poly1.NextIndex(num);
					continue;
				}
				StartingIndex = num;
				break;
			}
			while (num != 0);
			if (StartingIndex != -1)
			{
				return true;
			}
			Error = PolygonUtil.PolyUnionError.Poly1InsidePoly2;
			return false;
		}
		Error = PolygonUtil.PolyUnionError.NoIntersections;
		return false;
	}

	public static bool PointInPolygonAngle(Point2D point, Point2DList polygon)
	{
		double num = 0.0;
		for (int i = 0; i < polygon.Count; i++)
		{
			Point2D p = polygon[i] - point;
			Point2D p2 = polygon[polygon.NextIndex(i)] - point;
			num += VectorAngle(p, p2);
		}
		if (!(Math.Abs(num) < Math.PI))
		{
			return true;
		}
		return false;
	}

	public static double VectorAngle(Point2D p1, Point2D p2)
	{
		double num = Math.Atan2(p1.Y, p1.X);
		double num2 = Math.Atan2(p2.Y, p2.X);
		double num3;
		for (num3 = num2 - num; num3 > Math.PI; num3 -= Math.PI * 2.0)
		{
		}
		for (; num3 < -Math.PI; num3 += Math.PI * 2.0)
		{
		}
		return num3;
	}
}
