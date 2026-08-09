using System;
using System.Collections.Generic;

namespace UglyToad.PdfPig.Geometry.ClipperLibrary;

internal class ClipperOffset
{
	private const double DefArcTolerance = 0.25;

	private ClipperIntPoint lowest;

	private readonly ClipperPolyNode polyNodes = new ClipperPolyNode();

	public double ArcTolerance { get; set; }

	public double MiterLimit { get; set; }

	public ClipperOffset(double miterLimit = 2.0, double arcTolerance = 0.25)
	{
		MiterLimit = miterLimit;
		ArcTolerance = arcTolerance;
		lowest.X = -1L;
	}

	public void Clear()
	{
		polyNodes.Children.Clear();
		lowest.X = -1L;
	}

	public void AddPath(List<ClipperIntPoint> path, ClipperJoinType joinType, ClipperEndType endType)
	{
		int num = path.Count - 1;
		if (num < 0)
		{
			return;
		}
		ClipperPolyNode clipperPolyNode = new ClipperPolyNode
		{
			JoinType = joinType,
			EndType = endType
		};
		if (endType == ClipperEndType.ClosedLine || endType == ClipperEndType.ClosedPolygon)
		{
			while (num > 0 && path[0] == path[num])
			{
				num--;
			}
		}
		clipperPolyNode.Polygon.Capacity = num + 1;
		clipperPolyNode.Polygon.Add(path[0]);
		int num2 = 0;
		int num3 = 0;
		for (int i = 1; i <= num; i++)
		{
			if (clipperPolyNode.Polygon[num2] != path[i])
			{
				num2++;
				clipperPolyNode.Polygon.Add(path[i]);
				if (path[i].Y > clipperPolyNode.Polygon[num3].Y || (path[i].Y == clipperPolyNode.Polygon[num3].Y && path[i].X < clipperPolyNode.Polygon[num3].X))
				{
					num3 = num2;
				}
			}
		}
		if (endType == ClipperEndType.ClosedPolygon && num2 < 2)
		{
			return;
		}
		polyNodes.AddChild(clipperPolyNode);
		if (endType != ClipperEndType.ClosedPolygon)
		{
			return;
		}
		if (lowest.X < 0)
		{
			lowest = new ClipperIntPoint(polyNodes.ChildCount - 1, num3);
			return;
		}
		ClipperIntPoint clipperIntPoint = polyNodes.Children[(int)lowest.X].Polygon[(int)lowest.Y];
		if (clipperPolyNode.Polygon[num3].Y > clipperIntPoint.Y || (clipperPolyNode.Polygon[num3].Y == clipperIntPoint.Y && clipperPolyNode.Polygon[num3].X < clipperIntPoint.X))
		{
			lowest = new ClipperIntPoint(polyNodes.ChildCount - 1, num3);
		}
	}

	public void AddPaths(List<List<ClipperIntPoint>> paths, ClipperJoinType joinType, ClipperEndType endType)
	{
		foreach (List<ClipperIntPoint> path in paths)
		{
			AddPath(path, joinType, endType);
		}
	}

	public static long Round(double value)
	{
		if (!(value < 0.0))
		{
			return (long)(value + 0.5);
		}
		return (long)(value - 0.5);
	}

	public static ClipperDoublePoint GetUnitNormal(ClipperIntPoint pt1, ClipperIntPoint pt2)
	{
		double num = pt2.X - pt1.X;
		double num2 = pt2.Y - pt1.Y;
		if (num == 0.0 && num2 == 0.0)
		{
			return default(ClipperDoublePoint);
		}
		double num3 = 1.0 / Math.Sqrt(num * num + num2 * num2);
		num *= num3;
		num2 *= num3;
		return new ClipperDoublePoint(num2, 0.0 - num);
	}
}
