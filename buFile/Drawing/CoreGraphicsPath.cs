// Decompiled with JetBrains decompiler
// Type: PdfSharp.Drawing.CoreGraphicsPath
// Assembly: buFile, Version=1.50.4740.0, Culture=neutral, PublicKeyToken=f94615aa0424f9eb
// MVID: 1F93257A-1245-4898-8C4E-DC1AB39EF50B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buFile.dll

using System;
using System.Collections.Generic;
using System.Diagnostics;

#nullable disable
namespace PdfSharp.Drawing;

internal class CoreGraphicsPath
{
  private const byte PathPointTypeStart = 0;
  private const byte PathPointTypeLine = 1;
  private const byte PathPointTypeBezier = 3;
  private const byte PathPointTypePathTypeMask = 7;
  private const byte PathPointTypeCloseSubpath = 128 /*0x80*/;
  private XFillMode _fillMode;
  private readonly List<XPoint> _points = new List<XPoint>();
  private readonly List<byte> _types = new List<byte>();

  public CoreGraphicsPath()
  {
  }

  public CoreGraphicsPath(CoreGraphicsPath path)
  {
    this._points = new List<XPoint>((IEnumerable<XPoint>) path._points);
    this._types = new List<byte>((IEnumerable<byte>) path._types);
  }

  public void MoveOrLineTo(double x, double y)
  {
    if ((this._types.Count == 0 ? 1 : (((int) this._types[this._types.Count - 1] & 128 /*0x80*/) == 128 /*0x80*/ ? 1 : 0)) != 0)
      this.MoveTo(x, y);
    else
      this.LineTo(x, y, false);
  }

  public void MoveTo(double x, double y)
  {
    this._points.Add(new XPoint(x, y));
    this._types.Add((byte) 0);
  }

  public void LineTo(double x, double y, bool closeSubpath)
  {
    if ((this._points.Count <= 0 ? 0 : (this._points[this._points.Count - 1].Equals(new XPoint(x, y)) ? 1 : 0)) != 0)
      return;
    this._points.Add(new XPoint(x, y));
    this._types.Add((byte) (1 | (closeSubpath ? 128 /*0x80*/ : 0)));
  }

  public void BezierTo(
    double x1,
    double y1,
    double x2,
    double y2,
    double x3,
    double y3,
    bool closeSubpath)
  {
    this._points.Add(new XPoint(x1, y1));
    this._types.Add((byte) 3);
    this._points.Add(new XPoint(x2, y2));
    this._types.Add((byte) 3);
    this._points.Add(new XPoint(x3, y3));
    this._types.Add((byte) (3 | (closeSubpath ? 128 /*0x80*/ : 0)));
  }

  public void QuadrantArcTo(
    double x,
    double y,
    double width,
    double height,
    int quadrant,
    bool clockwise)
  {
    if (width < 0.0)
      throw new ArgumentOutOfRangeException(nameof (width));
    if (height < 0.0)
      throw new ArgumentOutOfRangeException(nameof (height));
    double num1 = 0.55228474983079345 * width;
    double num2 = 0.55228474983079345 * height;
    double x1;
    double y1;
    double x2;
    double y2;
    double x3;
    double y3;
    switch (quadrant)
    {
      case 1:
        if (clockwise)
        {
          x1 = x + num1;
          y1 = y - height;
          x2 = x + width;
          y2 = y - num2;
          x3 = x + width;
          y3 = y;
          break;
        }
        x1 = x + width;
        y1 = y - num2;
        x2 = x + num1;
        y2 = y - height;
        x3 = x;
        y3 = y - height;
        break;
      case 2:
        if (clockwise)
        {
          x1 = x - width;
          y1 = y - num2;
          x2 = x - num1;
          y2 = y - height;
          x3 = x;
          y3 = y - height;
          break;
        }
        x1 = x - num1;
        y1 = y - height;
        x2 = x - width;
        y2 = y - num2;
        x3 = x - width;
        y3 = y;
        break;
      case 3:
        if (clockwise)
        {
          x1 = x - num1;
          y1 = y + height;
          x2 = x - width;
          y2 = y + num2;
          x3 = x - width;
          y3 = y;
          break;
        }
        x1 = x - width;
        y1 = y + num2;
        x2 = x - num1;
        y2 = y + height;
        x3 = x;
        y3 = y + height;
        break;
      case 4:
        if (clockwise)
        {
          x1 = x + width;
          y1 = y + num2;
          x2 = x + num1;
          y2 = y + height;
          x3 = x;
          y3 = y + height;
          break;
        }
        x1 = x + num1;
        y1 = y + height;
        x2 = x + width;
        y2 = y + num2;
        x3 = x + width;
        y3 = y;
        break;
      default:
        throw new ArgumentOutOfRangeException(nameof (quadrant));
    }
    this.BezierTo(x1, y1, x2, y2, x3, y3, false);
  }

  public void CloseSubpath()
  {
    int count = this._types.Count;
    if (count <= 0)
      return;
    this._types[count - 1] |= (byte) 128 /*0x80*/;
  }

  private XFillMode FillMode
  {
    get => this._fillMode;
    set => this._fillMode = value;
  }

  public void AddArc(
    double x,
    double y,
    double width,
    double height,
    double startAngle,
    double sweepAngle)
  {
    XMatrix identity = XMatrix.Identity;
    List<XPoint> xpointList = GeometryHelper.BezierCurveFromArc(x, y, width, height, startAngle, sweepAngle, PathStart.MoveTo1st, ref identity);
    int count = xpointList.Count;
    Debug.Assert((count + 2) % 3 == 0);
    XPoint xpoint1 = xpointList[0];
    double x1 = xpoint1.X;
    xpoint1 = xpointList[0];
    double y1 = xpoint1.Y;
    this.MoveOrLineTo(x1, y1);
    for (int index = 1; index < count; index += 3)
    {
      XPoint xpoint2 = xpointList[index];
      double x2 = xpoint2.X;
      xpoint2 = xpointList[index];
      double y2 = xpoint2.Y;
      xpoint2 = xpointList[index + 1];
      double x3 = xpoint2.X;
      xpoint2 = xpointList[index + 1];
      double y3 = xpoint2.Y;
      xpoint2 = xpointList[index + 2];
      double x4 = xpoint2.X;
      xpoint2 = xpointList[index + 2];
      double y4 = xpoint2.Y;
      this.BezierTo(x2, y2, x3, y3, x4, y4, false);
    }
  }

  public void AddArc(
    XPoint point1,
    XPoint point2,
    XSize size,
    double rotationAngle,
    bool isLargeArg,
    XSweepDirection sweepDirection)
  {
    List<XPoint> xpointList = GeometryHelper.BezierCurveFromArc(point1, point2, size, rotationAngle, isLargeArg, sweepDirection == XSweepDirection.Clockwise, PathStart.MoveTo1st);
    int count = xpointList.Count;
    Debug.Assert((count + 2) % 3 == 0);
    XPoint xpoint1 = xpointList[0];
    double x1 = xpoint1.X;
    xpoint1 = xpointList[0];
    double y1 = xpoint1.Y;
    this.MoveOrLineTo(x1, y1);
    for (int index = 1; index < count; index += 3)
    {
      XPoint xpoint2 = xpointList[index];
      double x2 = xpoint2.X;
      xpoint2 = xpointList[index];
      double y2 = xpoint2.Y;
      xpoint2 = xpointList[index + 1];
      double x3 = xpoint2.X;
      xpoint2 = xpointList[index + 1];
      double y3 = xpoint2.Y;
      xpoint2 = xpointList[index + 2];
      double x4 = xpoint2.X;
      xpoint2 = xpointList[index + 2];
      double y4 = xpoint2.Y;
      this.BezierTo(x2, y2, x3, y3, x4, y4, false);
    }
  }

  public void AddCurve(XPoint[] points, double tension)
  {
    int length = points.Length;
    if (length < 2)
      throw new ArgumentException("AddCurve requires two or more points.", nameof (points));
    tension /= 3.0;
    this.MoveOrLineTo(points[0].X, points[0].Y);
    if (length == 2)
    {
      this.ToCurveSegment(points[0], points[0], points[1], points[1], tension);
    }
    else
    {
      this.ToCurveSegment(points[0], points[0], points[1], points[2], tension);
      for (int index = 1; index < length - 2; ++index)
        this.ToCurveSegment(points[index - 1], points[index], points[index + 1], points[index + 2], tension);
      this.ToCurveSegment(points[length - 3], points[length - 2], points[length - 1], points[length - 1], tension);
    }
  }

  private void ToCurveSegment(XPoint pt0, XPoint pt1, XPoint pt2, XPoint pt3, double tension3)
  {
    this.BezierTo(pt1.X + tension3 * (pt2.X - pt0.X), pt1.Y + tension3 * (pt2.Y - pt0.Y), pt2.X - tension3 * (pt3.X - pt1.X), pt2.Y - tension3 * (pt3.Y - pt1.Y), pt2.X, pt2.Y, false);
  }

  public XPoint[] PathPoints => this._points.ToArray();

  public byte[] PathTypes => this._types.ToArray();
}
