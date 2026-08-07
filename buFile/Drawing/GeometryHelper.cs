// Decompiled with JetBrains decompiler
// Type: PdfSharp.Drawing.GeometryHelper
// Assembly: buFile, Version=1.50.4740.0, Culture=neutral, PublicKeyToken=f94615aa0424f9eb
// MVID: 1F93257A-1245-4898-8C4E-DC1AB39EF50B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buFile.dll

using System;
using System.Collections.Generic;
using System.Diagnostics;

#nullable disable
namespace PdfSharp.Drawing;

internal static class GeometryHelper
{
  public static List<XPoint> BezierCurveFromArc(
    double x,
    double y,
    double width,
    double height,
    double startAngle,
    double sweepAngle,
    PathStart pathStart,
    ref XMatrix matrix)
  {
    List<XPoint> points = new List<XPoint>();
    double num1 = startAngle;
    if (num1 < 0.0)
      num1 += (1.0 + Math.Floor(Math.Abs(num1) / 360.0)) * 360.0;
    else if (num1 > 360.0)
      num1 -= Math.Floor(num1 / 360.0) * 360.0;
    Debug.Assert(num1 >= 0.0 && num1 <= 360.0);
    double num2 = sweepAngle;
    if (num2 < -360.0)
      num2 = -360.0;
    else if (num2 > 360.0)
      num2 = 360.0;
    if ((num1 != 0.0 ? 0 : (num2 < 0.0 ? 1 : 0)) != 0)
      num1 = 360.0;
    else if ((num1 != 360.0 ? 0 : (num2 > 0.0 ? 1 : 0)) != 0)
      num1 = 0.0;
    bool flag1 = Math.Abs(num2) <= 90.0;
    double num3 = num1 + num2;
    if (num3 < 0.0)
      num3 += (1.0 + Math.Floor(Math.Abs(num3) / 360.0)) * 360.0;
    bool clockwise = sweepAngle > 0.0;
    int num4 = GeometryHelper.Quadrant(num1, true, clockwise);
    int num5 = GeometryHelper.Quadrant(num3, false, clockwise);
    if (num4 == num5 & flag1)
    {
      GeometryHelper.AppendPartialArcQuadrant(points, x, y, width, height, num1, num3, pathStart, matrix);
    }
    else
    {
      int num6 = num4;
      bool flag2 = true;
      while (true)
      {
        if (!(num6 == num4 & flag2))
        {
          if (num6 == num5)
          {
            double α = (double) (num6 * 90 + (clockwise ? 0 : 90));
            GeometryHelper.AppendPartialArcQuadrant(points, x, y, width, height, α, num3, PathStart.Ignore1st, matrix);
          }
          else
          {
            double α = (double) (num6 * 90 + (clockwise ? 0 : 90));
            double β = (double) (num6 * 90 + (clockwise ? 90 : 0));
            GeometryHelper.AppendPartialArcQuadrant(points, x, y, width, height, α, β, PathStart.Ignore1st, matrix);
          }
        }
        else
          goto label_22;
label_20:
        if (!(num6 == num5 & flag1))
        {
          flag1 = true;
          num6 = !clockwise ? (num6 == 0 ? 3 : num6 - 1) : (num6 == 3 ? 0 : num6 + 1);
          flag2 = false;
          continue;
        }
        break;
label_22:
        double β1 = (double) (num6 * 90 + (clockwise ? 90 : 0));
        GeometryHelper.AppendPartialArcQuadrant(points, x, y, width, height, num1, β1, pathStart, matrix);
        goto label_20;
      }
    }
    return points;
  }

  private static int Quadrant(double φ, bool start, bool clockwise)
  {
    Debug.Assert(φ >= 0.0);
    if (φ > 360.0)
      φ -= Math.Floor(φ / 360.0) * 360.0;
    int num = (int) (φ / 90.0);
    if ((double) (num * 90) == φ)
    {
      if ((!start || clockwise ? (!start & clockwise ? 1 : 0) : 1) != 0)
        num = num == 0 ? 3 : num - 1;
    }
    else
      num = clockwise ? (int) Math.Floor(φ / 90.0) % 4 : (int) Math.Floor(φ / 90.0);
    return num;
  }

  private static void AppendPartialArcQuadrant(
    List<XPoint> points,
    double x,
    double y,
    double width,
    double height,
    double α,
    double β,
    PathStart pathStart,
    XMatrix matrix)
  {
    Debug.Assert(α >= 0.0 && α <= 360.0);
    Debug.Assert(β >= 0.0);
    if (β > 360.0)
      β -= Math.Floor(β / 360.0) * 360.0;
    Debug.Assert(Math.Abs(α - β) <= 90.0);
    double num1 = width / 2.0;
    double num2 = height / 2.0;
    double num3 = x + num1;
    double num4 = y + num2;
    bool flag = false;
    if ((α < 180.0 ? 0 : (β >= 180.0 ? 1 : 0)) != 0)
    {
      α -= 180.0;
      β -= 180.0;
      flag = true;
    }
    if (width == height)
    {
      α *= Math.PI / 180.0;
      β *= Math.PI / 180.0;
    }
    else
    {
      α *= Math.PI / 180.0;
      double num5 = Math.Sin(α);
      if (Math.Abs(num5) > 1E-10)
        α = Math.PI / 2.0 - Math.Atan(num2 * Math.Cos(α) / (num1 * num5));
      β *= Math.PI / 180.0;
      double num6 = Math.Sin(β);
      if (Math.Abs(num6) > 1E-10)
        β = Math.PI / 2.0 - Math.Atan(num2 * Math.Cos(β) / (num1 * num6));
    }
    double num7 = 4.0 * (1.0 - Math.Cos((α - β) / 2.0)) / (3.0 * Math.Sin((β - α) / 2.0));
    double num8 = Math.Sin(α);
    double num9 = Math.Cos(α);
    double num10 = Math.Sin(β);
    double num11 = Math.Cos(β);
    if (!flag)
    {
      switch (pathStart)
      {
        case PathStart.MoveTo1st:
          points.Add(matrix.Transform(new XPoint(num3 + num1 * num9, num4 + num2 * num8)));
          break;
        case PathStart.LineTo1st:
          points.Add(matrix.Transform(new XPoint(num3 + num1 * num9, num4 + num2 * num8)));
          break;
      }
      points.Add(matrix.Transform(new XPoint(num3 + num1 * (num9 - num7 * num8), num4 + num2 * (num8 + num7 * num9))));
      points.Add(matrix.Transform(new XPoint(num3 + num1 * (num11 + num7 * num10), num4 + num2 * (num10 - num7 * num11))));
      points.Add(matrix.Transform(new XPoint(num3 + num1 * num11, num4 + num2 * num10)));
    }
    else
    {
      switch (pathStart)
      {
        case PathStart.MoveTo1st:
          points.Add(matrix.Transform(new XPoint(num3 - num1 * num9, num4 - num2 * num8)));
          break;
        case PathStart.LineTo1st:
          points.Add(matrix.Transform(new XPoint(num3 - num1 * num9, num4 - num2 * num8)));
          break;
      }
      points.Add(matrix.Transform(new XPoint(num3 - num1 * (num9 - num7 * num8), num4 - num2 * (num8 + num7 * num9))));
      points.Add(matrix.Transform(new XPoint(num3 - num1 * (num11 + num7 * num10), num4 - num2 * (num10 - num7 * num11))));
      points.Add(matrix.Transform(new XPoint(num3 - num1 * num11, num4 - num2 * num10)));
    }
  }

  public static List<XPoint> BezierCurveFromArc(
    XPoint point1,
    XPoint point2,
    XSize size,
    double rotationAngle,
    bool isLargeArc,
    bool clockwise,
    PathStart pathStart)
  {
    double width = size.Width;
    double height = size.Height;
    Debug.Assert(width * height > 0.0);
    double num1 = height / width;
    bool flag = !clockwise;
    XMatrix matrix = new XMatrix();
    matrix.RotateAppend(-rotationAngle);
    matrix.ScaleAppend(height / width, 1.0);
    XPoint xpoint1 = matrix.Transform(point1);
    XPoint xpoint2 = matrix.Transform(point2);
    XPoint xpoint3 = new XPoint((xpoint1.X + xpoint2.X) / 2.0, (xpoint1.Y + xpoint2.Y) / 2.0);
    XVector xvector1 = xpoint2 - xpoint1;
    double num2 = xvector1.Length / 2.0;
    XVector xvector2 = isLargeArc != flag ? new XVector(xvector1.Y, -xvector1.X) : new XVector(-xvector1.Y, xvector1.X);
    xvector2.Normalize();
    double d = Math.Sqrt(height * height - num2 * num2);
    if (double.IsNaN(d))
      d = 0.0;
    XPoint xpoint4 = xpoint3 + d * xvector2;
    double num3 = Math.Atan2(xpoint1.Y - xpoint4.Y, xpoint1.X - xpoint4.X);
    double num4 = Math.Atan2(xpoint2.Y - xpoint4.Y, xpoint2.X - xpoint4.X);
    if (isLargeArc == Math.Abs(num4 - num3) < Math.PI)
    {
      if (num3 < num4)
        num3 += 2.0 * Math.PI;
      else
        num4 += 2.0 * Math.PI;
    }
    matrix.Invert();
    double num5 = num4 - num3;
    return GeometryHelper.BezierCurveFromArc(xpoint4.X - width * num1, xpoint4.Y - height, 2.0 * width * num1, 2.0 * height, num3 / (Math.PI / 180.0), num5 / (Math.PI / 180.0), pathStart, ref matrix);
  }
}
