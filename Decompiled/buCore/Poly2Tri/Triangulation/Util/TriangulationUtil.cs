using System;
using Poly2Tri.Utility;
using ns54;

namespace Poly2Tri.Triangulation.Util;

public class TriangulationUtil
{
	public static bool SmartIncircle(Point2D pa, Point2D pb, Point2D pc, Point2D pd)
	{
		double x = pd.X;
		double y = pd.Y;
		double num = pa.X - x;
		double num2 = pa.Y - y;
		double num3 = pb.X - x;
		double num4 = pb.Y - y;
		double num5 = num * num4;
		double num6 = num3 * num2;
		double num7 = num5 - num6;
		if (!(num7 <= 0.0))
		{
			double num8 = pc.X - x;
			double num9 = pc.Y - y;
			double num10 = num8 * num2;
			double num11 = num * num9;
			double num12 = num10 - num11;
			if (!(num12 <= 0.0))
			{
				double num13 = num3 * num9;
				double num14 = num8 * num4;
				double num15 = num * num + num2 * num2;
				double num16 = num3 * num3 + num4 * num4;
				double num17 = num8 * num8 + num9 * num9;
				double num18 = num15 * (num13 - num14) + num16 * num12 + num17 * num7;
				return num18 > 0.0;
			}
			return false;
		}
		return false;
	}

	public static bool InScanArea(Point2D pa, Point2D pb, Point2D pc, Point2D pd)
	{
		double x = pd.X;
		double y = pd.Y;
		double num = pa.X - x;
		double num2 = pa.Y - y;
		double num3 = pb.X - x;
		double num4 = pb.Y - y;
		double num5 = num * num4;
		double num6 = num3 * num2;
		double num7 = num5 - num6;
		if (!(num7 <= 0.0))
		{
			double num8 = pc.X - x;
			double num9 = pc.Y - y;
			double num10 = num8 * num2;
			double num11 = num * num9;
			double num12 = num10 - num11;
			if (!(num12 <= 0.0))
			{
				return true;
			}
			return false;
		}
		return false;
	}

	public static Orientation Orient2d(Point2D pa, Point2D pb, Point2D pc)
	{
		double num = (pa.X - pc.X) * (pb.Y - pc.Y);
		double num2 = (pa.Y - pc.Y) * (pb.X - pc.X);
		double num3 = num - num2;
		if (num3 <= -1E-12 || !(num3 < 1E-12))
		{
			if (!(num3 > 0.0))
			{
				return Orientation.Clockwise;
			}
			return Orientation.AntiClockwise;
		}
		return Orientation.Collinear;
	}

	public static bool PointInBoundingBox(double xmin, double xmax, double ymin, double ymax, Point2D p)
	{
		return !(p.X <= xmin) && p.X < xmax && p.Y > ymin && p.Y < ymax;
	}

	public static bool PointOnLineSegment2D(Point2D lineStart, Point2D lineEnd, Point2D p, double epsilon)
	{
		double x = lineStart.X;
		double y = lineStart.Y;
		double x2 = lineEnd.X;
		double y2 = lineEnd.Y;
		double x3 = p.X;
		double y3 = p.Y;
		return Class156.smethod_282(x2, x, y3, epsilon, y2, x3, y);
	}

	public static bool RectsIntersect(Rect2D r1, Rect2D r2)
	{
		return !(r1.Right <= r2.Left) && r1.Left < r2.Right && r1.Bottom > r2.Top && r1.Top < r2.Bottom;
	}

	public static bool LinesIntersect2D(Point2D ptStart0, Point2D ptEnd0, Point2D ptStart1, Point2D ptEnd1, bool firstIsSegment, bool secondIsSegment, bool coincidentEndPointCollisions, ref Point2D pIntersectionPt, double epsilon)
	{
		double num = (ptEnd0.X - ptStart0.X) * (ptStart1.Y - ptEnd1.Y) - (ptStart1.X - ptEnd1.X) * (ptEnd0.Y - ptStart0.Y);
		if (!(Math.Abs(num) < epsilon))
		{
			double num2 = (ptStart1.X - ptStart0.X) * (ptStart1.Y - ptEnd1.Y) - (ptStart1.X - ptEnd1.X) * (ptStart1.Y - ptStart0.Y);
			double num3 = (ptEnd0.X - ptStart0.X) * (ptStart1.Y - ptStart0.Y) - (ptStart1.X - ptStart0.X) * (ptEnd0.Y - ptStart0.Y);
			double num4 = 1.0 / num;
			double num5 = num2 * num4;
			double num6 = num3 * num4;
			if ((firstIsSegment && (num5 < 0.0 || !(num5 <= 1.0))) || (secondIsSegment && (!(num6 >= 0.0) || !(num6 <= 1.0))) || (!coincidentEndPointCollisions && (MathUtil.AreValuesEqual(0.0, num5, epsilon) || MathUtil.AreValuesEqual(0.0, num6, epsilon))))
			{
				return false;
			}
			if (pIntersectionPt != null)
			{
				pIntersectionPt.X = ptStart0.X + num5 * (ptEnd0.X - ptStart0.X);
				pIntersectionPt.Y = ptStart0.Y + num5 * (ptEnd0.Y - ptStart0.Y);
			}
			return true;
		}
		return false;
	}

	public static bool LinesIntersect2D(Point2D ptStart0, Point2D ptEnd0, Point2D ptStart1, Point2D ptEnd1, ref Point2D pIntersectionPt, double epsilon)
	{
		return LinesIntersect2D(ptStart0, ptEnd0, ptStart1, ptEnd1, firstIsSegment: true, secondIsSegment: true, coincidentEndPointCollisions: false, ref pIntersectionPt, epsilon);
	}

	public static bool RaysIntersect2D(Point2D ptRayOrigin0, Point2D ptRayVector0, Point2D ptRayOrigin1, Point2D ptRayVector1, ref Point2D ptIntersection)
	{
		if (ptIntersection == null)
		{
			double value = ptRayVector1.X - ptRayVector0.X;
			if (Math.Abs(value) > 0.01)
			{
				value = ptRayVector1.Y - ptRayVector0.Y;
				if (Math.Abs(value) > 0.01)
				{
					return true;
				}
			}
			return false;
		}
		Point2D point2D_ = new Point2D(ptRayOrigin1.X - ptRayOrigin0.X, ptRayOrigin1.Y - ptRayOrigin0.Y);
		Point2D point2D_2 = new Point2D(0.0 - ptRayVector1.Y, ptRayVector1.X);
		double num = Class156.smethod_240(ptRayVector0, point2D_2);
		if (!(Math.Abs(num) < 0.01))
		{
			double num2 = Class156.smethod_240(point2D_, point2D_2);
			double num3 = num2 / num;
			ptIntersection.X = ptRayOrigin0.X + ptRayVector0.X * num3;
			ptIntersection.Y = ptRayOrigin0.Y + ptRayVector0.Y * num3;
			return true;
		}
		return false;
	}
}
