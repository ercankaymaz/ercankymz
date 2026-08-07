// Decompiled with JetBrains decompiler
// Type: Poly2Tri.Triangulation.Util.TriangulationUtil
// Assembly: buCore, Version=5.1.1.3, Culture=neutral, PublicKeyToken=null
// MVID: 75A66F79-5BE1-42D4-8188-CDC69C2B6DAA
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buCore.dll

using ns7;
using Poly2Tri.Utility;
using System;

#nullable disable
namespace Poly2Tri.Triangulation.Util;

public class TriangulationUtil
{
  public static bool SmartIncircle(Point2D pa, Point2D pb, Point2D pc, Point2D pd)
  {
    double x = pd.X;
    double y = pd.Y;
    double num1 = pa.X - x;
    double num2 = pa.Y - y;
    double num3 = pb.X - x;
    double num4 = pb.Y - y;
    double num5 = num1 * num4 - num3 * num2;
    bool flag;
    if (num5 <= 0.0)
    {
      flag = false;
    }
    else
    {
      double num6 = pc.X - x;
      double num7 = pc.Y - y;
      double num8 = num6 * num2 - num1 * num7;
      if (num8 <= 0.0)
      {
        flag = false;
      }
      else
      {
        double num9 = num3 * num7;
        double num10 = num6 * num4;
        double num11 = num1 * num1 + num2 * num2;
        double num12 = num3 * num3 + num4 * num4;
        double num13 = num6 * num6 + num7 * num7;
        flag = num11 * (num9 - num10) + num12 * num8 + num13 * num5 > 0.0;
      }
    }
    return flag;
  }

  public static bool InScanArea(Point2D pa, Point2D pb, Point2D pc, Point2D pd)
  {
    double x = pd.X;
    double y = pd.Y;
    double num1 = pa.X - x;
    double num2 = pa.Y - y;
    double num3 = pb.X - x;
    double num4 = pb.Y - y;
    bool flag;
    if (num1 * num4 - num3 * num2 <= 0.0)
    {
      flag = false;
    }
    else
    {
      double num5 = pc.X - x;
      double num6 = pc.Y - y;
      flag = num5 * num2 - num1 * num6 > 0.0;
    }
    return flag;
  }

  public static Orientation Orient2d(Point2D pa, Point2D pb, Point2D pc)
  {
    double num = (pa.X - pc.X) * (pb.Y - pc.Y) - (pa.Y - pc.Y) * (pb.X - pc.X);
    return (num <= -1E-12 ? 0 : (num < 1E-12 ? 1 : 0)) == 0 ? (num <= 0.0 ? Orientation.Clockwise : Orientation.AntiClockwise) : Orientation.Collinear;
  }

  public static bool PointInBoundingBox(
    double xmin,
    double xmax,
    double ymin,
    double ymax,
    Point2D p)
  {
    return p.X > xmin && p.X < xmax && p.Y > ymin && p.Y < ymax;
  }

  public static bool PointOnLineSegment2D(
    Point2D lineStart,
    Point2D lineEnd,
    Point2D p,
    double epsilon)
  {
    double x1 = lineStart.X;
    double y1 = lineStart.Y;
    double x2 = lineEnd.X;
    double y2 = lineEnd.Y;
    double x3 = p.X;
    double y3 = p.Y;
    return Class30.smethod_282(x2, x1, y3, epsilon, y2, x3, y1);
  }

  public static bool RectsIntersect(Rect2D r1, Rect2D r2)
  {
    return r1.Right > r2.Left && r1.Left < r2.Right && r1.Bottom > r2.Top && r1.Top < r2.Bottom;
  }

  public static bool LinesIntersect2D(
    Point2D ptStart0,
    Point2D ptEnd0,
    Point2D ptStart1,
    Point2D ptEnd1,
    bool firstIsSegment,
    bool secondIsSegment,
    bool coincidentEndPointCollisions,
    ref Point2D pIntersectionPt,
    double epsilon)
  {
    double num1 = (ptEnd0.X - ptStart0.X) * (ptStart1.Y - ptEnd1.Y) - (ptStart1.X - ptEnd1.X) * (ptEnd0.Y - ptStart0.Y);
    bool flag;
    if (Math.Abs(num1) < epsilon)
    {
      flag = false;
    }
    else
    {
      double num2 = (ptStart1.X - ptStart0.X) * (ptStart1.Y - ptEnd1.Y) - (ptStart1.X - ptEnd1.X) * (ptStart1.Y - ptStart0.Y);
      double num3 = (ptEnd0.X - ptStart0.X) * (ptStart1.Y - ptStart0.Y) - (ptStart1.X - ptStart0.X) * (ptEnd0.Y - ptStart0.Y);
      double num4 = 1.0 / num1;
      double val2_1 = num2 * num4;
      double val2_2 = num3 * num4;
      if ((firstIsSegment && (val2_1 < 0.0 || val2_1 > 1.0) || secondIsSegment && (val2_2 < 0.0 || val2_2 > 1.0) ? 0 : (coincidentEndPointCollisions ? 1 : (MathUtil.AreValuesEqual(0.0, val2_1, epsilon) ? 0 : (!MathUtil.AreValuesEqual(0.0, val2_2, epsilon) ? 1 : 0)))) != 0)
      {
        if (pIntersectionPt != null)
        {
          pIntersectionPt.X = ptStart0.X + val2_1 * (ptEnd0.X - ptStart0.X);
          pIntersectionPt.Y = ptStart0.Y + val2_1 * (ptEnd0.Y - ptStart0.Y);
        }
        flag = true;
      }
      else
        flag = false;
    }
    return flag;
  }

  public static bool LinesIntersect2D(
    Point2D ptStart0,
    Point2D ptEnd0,
    Point2D ptStart1,
    Point2D ptEnd1,
    ref Point2D pIntersectionPt,
    double epsilon)
  {
    return TriangulationUtil.LinesIntersect2D(ptStart0, ptEnd0, ptStart1, ptEnd1, true, true, false, ref pIntersectionPt, epsilon);
  }

  public static bool RaysIntersect2D(
    Point2D ptRayOrigin0,
    Point2D ptRayVector0,
    Point2D ptRayOrigin1,
    Point2D ptRayVector1,
    ref Point2D ptIntersection)
  {
    bool flag;
    if (ptIntersection != null)
    {
      Point2D point2D_0 = new Point2D(ptRayOrigin1.X - ptRayOrigin0.X, ptRayOrigin1.Y - ptRayOrigin0.Y);
      Point2D point2D_1 = new Point2D(-ptRayVector1.Y, ptRayVector1.X);
      double num1 = Class30.smethod_240(ptRayVector0, point2D_1);
      if (Math.Abs(num1) < 0.01)
      {
        flag = false;
      }
      else
      {
        double num2 = Class30.smethod_240(point2D_0, point2D_1) / num1;
        ptIntersection.X = ptRayOrigin0.X + ptRayVector0.X * num2;
        ptIntersection.Y = ptRayOrigin0.Y + ptRayVector0.Y * num2;
        flag = true;
      }
    }
    else
      flag = Math.Abs(ptRayVector1.X - ptRayVector0.X) > 0.01 && Math.Abs(ptRayVector1.Y - ptRayVector0.Y) > 0.01;
    return flag;
  }
}
