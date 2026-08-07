// Decompiled with JetBrains decompiler
// Type: PdfSharp.Drawing.XGraphicsPath
// Assembly: buFile, Version=1.50.4740.0, Culture=neutral, PublicKeyToken=f94615aa0424f9eb
// MVID: 1F93257A-1245-4898-8C4E-DC1AB39EF50B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buFile.dll

using PdfSharp.Internal;
using System;

#nullable disable
namespace PdfSharp.Drawing;

public sealed class XGraphicsPath
{
  private XFillMode _fillMode;
  internal CoreGraphicsPath _corePath;

  public XGraphicsPath() => this._corePath = new CoreGraphicsPath();

  public XGraphicsPath Clone()
  {
    XGraphicsPath xgraphicsPath = (XGraphicsPath) this.MemberwiseClone();
    this._corePath = new CoreGraphicsPath(this._corePath);
    return xgraphicsPath;
  }

  public void AddLine(XPoint pt1, XPoint pt2) => this.AddLine(pt1.X, pt1.Y, pt2.X, pt2.Y);

  public void AddLine(double x1, double y1, double x2, double y2)
  {
    this._corePath.MoveOrLineTo(x1, y1);
    this._corePath.LineTo(x2, y2, false);
  }

  public void AddLines(XPoint[] points)
  {
    int num = points != null ? points.Length : throw new ArgumentNullException(nameof (points));
    if (num == 0)
      return;
    this._corePath.MoveOrLineTo(points[0].X, points[0].Y);
    for (int index = 1; index < num; ++index)
      this._corePath.LineTo(points[index].X, points[index].Y, false);
  }

  public void AddBezier(XPoint pt1, XPoint pt2, XPoint pt3, XPoint pt4)
  {
    this.AddBezier(pt1.X, pt1.Y, pt2.X, pt2.Y, pt3.X, pt3.Y, pt4.X, pt4.Y);
  }

  public void AddBezier(
    double x1,
    double y1,
    double x2,
    double y2,
    double x3,
    double y3,
    double x4,
    double y4)
  {
    this._corePath.MoveOrLineTo(x1, y1);
    this._corePath.BezierTo(x2, y2, x3, y3, x4, y4, false);
  }

  public void AddBeziers(XPoint[] points)
  {
    int num = points != null ? points.Length : throw new ArgumentNullException(nameof (points));
    if (num < 4)
      throw new ArgumentException("At least four points required for bezier curve.", nameof (points));
    if ((num - 1) % 3 != 0)
      throw new ArgumentException("Invalid number of points for bezier curve. Number must fulfil 4+3n.", nameof (points));
    this._corePath.MoveOrLineTo(points[0].X, points[0].Y);
    for (int index = 1; index < num; index += 3)
      this._corePath.BezierTo(points[index].X, points[index].Y, points[index + 1].X, points[index + 1].Y, points[index + 2].X, points[index + 2].Y, false);
  }

  public void AddCurve(XPoint[] points) => this.AddCurve(points, 0.5);

  public void AddCurve(XPoint[] points, double tension)
  {
    if (points.Length < 2)
      throw new ArgumentException("AddCurve requires two or more points.", nameof (points));
    this._corePath.AddCurve(points, tension);
  }

  public void AddCurve(XPoint[] points, int offset, int numberOfSegments, double tension)
  {
    throw new NotImplementedException("AddCurve not yet implemented.");
  }

  public void AddArc(XRect rect, double startAngle, double sweepAngle)
  {
    this.AddArc(rect.X, rect.Y, rect.Width, rect.Height, startAngle, sweepAngle);
  }

  public void AddArc(
    double x,
    double y,
    double width,
    double height,
    double startAngle,
    double sweepAngle)
  {
    this._corePath.AddArc(x, y, width, height, startAngle, sweepAngle);
  }

  public void AddArc(
    XPoint point1,
    XPoint point2,
    XSize size,
    double rotationAngle,
    bool isLargeArg,
    XSweepDirection sweepDirection)
  {
    this._corePath.AddArc(point1, point2, size, rotationAngle, isLargeArg, sweepDirection);
  }

  public void AddRectangle(XRect rect)
  {
    this._corePath.MoveTo(rect.X, rect.Y);
    this._corePath.LineTo(rect.X + rect.Width, rect.Y, false);
    this._corePath.LineTo(rect.X + rect.Width, rect.Y + rect.Height, false);
    this._corePath.LineTo(rect.X, rect.Y + rect.Height, true);
    this._corePath.CloseSubpath();
  }

  public void AddRectangle(double x, double y, double width, double height)
  {
    this.AddRectangle(new XRect(x, y, width, height));
  }

  public void AddRectangles(XRect[] rects)
  {
    int length = rects.Length;
    for (int index = 0; index < length; ++index)
      this.AddRectangle(rects[index]);
  }

  public void AddRoundedRectangle(
    double x,
    double y,
    double width,
    double height,
    double ellipseWidth,
    double ellipseHeight)
  {
    double width1 = ellipseWidth / 2.0;
    double height1 = ellipseHeight / 2.0;
    this._corePath.MoveTo(x + width - width1, y);
    this._corePath.QuadrantArcTo(x + width - width1, y + height1, width1, height1, 1, true);
    this._corePath.LineTo(x + width, y + height - height1, false);
    this._corePath.QuadrantArcTo(x + width - width1, y + height - height1, width1, height1, 4, true);
    this._corePath.LineTo(x + width1, y + height, false);
    this._corePath.QuadrantArcTo(x + width1, y + height - height1, width1, height1, 3, true);
    this._corePath.LineTo(x, y + height1, false);
    this._corePath.QuadrantArcTo(x + width1, y + height1, width1, height1, 2, true);
    this._corePath.CloseSubpath();
  }

  public void AddEllipse(XRect rect) => this.AddEllipse(rect.X, rect.Y, rect.Width, rect.Height);

  public void AddEllipse(double x, double y, double width, double height)
  {
    double width1 = width / 2.0;
    double height1 = height / 2.0;
    double x1 = x + width1;
    double y1 = y + height1;
    this._corePath.MoveTo(x + width1, y);
    this._corePath.QuadrantArcTo(x1, y1, width1, height1, 1, true);
    this._corePath.QuadrantArcTo(x1, y1, width1, height1, 4, true);
    this._corePath.QuadrantArcTo(x1, y1, width1, height1, 3, true);
    this._corePath.QuadrantArcTo(x1, y1, width1, height1, 2, true);
    this._corePath.CloseSubpath();
  }

  public void AddPolygon(XPoint[] points)
  {
    int length = points.Length;
    if (length == 0)
      return;
    this._corePath.MoveTo(points[0].X, points[0].Y);
    for (int index = 0; index < length - 1; ++index)
      this._corePath.LineTo(points[index].X, points[index].Y, false);
    this._corePath.LineTo(points[length - 1].X, points[length - 1].Y, true);
    this._corePath.CloseSubpath();
  }

  public void AddPie(XRect rect, double startAngle, double sweepAngle)
  {
    this.AddPie(rect.X, rect.Y, rect.Width, rect.Height, startAngle, sweepAngle);
  }

  public void AddPie(
    double x,
    double y,
    double width,
    double height,
    double startAngle,
    double sweepAngle)
  {
    DiagnosticsHelper.HandleNotImplemented("XGraphicsPath.AddPie");
  }

  public void AddClosedCurve(XPoint[] points) => this.AddClosedCurve(points, 0.5);

  public void AddClosedCurve(XPoint[] points, double tension)
  {
    int num = points != null ? points.Length : throw new ArgumentNullException(nameof (points));
    if (num == 0)
      return;
    if (num < 2)
      throw new ArgumentException("Not enough points.", nameof (points));
    DiagnosticsHelper.HandleNotImplemented("XGraphicsPath.AddClosedCurve");
  }

  public void AddPath(XGraphicsPath path, bool connect)
  {
    DiagnosticsHelper.HandleNotImplemented("XGraphicsPath.AddPath");
  }

  public void AddString(
    string s,
    XFontFamily family,
    XFontStyle style,
    double emSize,
    XPoint origin,
    XStringFormat format)
  {
    try
    {
      DiagnosticsHelper.HandleNotImplemented("XGraphicsPath.AddString");
    }
    catch
    {
      throw;
    }
  }

  public void AddString(
    string s,
    XFontFamily family,
    XFontStyle style,
    double emSize,
    XRect layoutRect,
    XStringFormat format)
  {
    if (s == null)
      throw new ArgumentNullException(nameof (s));
    if (family == null)
      throw new ArgumentNullException(nameof (family));
    if (format == null)
      format = XStringFormats.Default;
    if ((format.LineAlignment != XLineAlignment.BaseLine ? 0 : (layoutRect.Height != 0.0 ? 1 : 0)) != 0)
      throw new InvalidOperationException("DrawString: With XLineAlignment.BaseLine the height of the layout rectangle must be 0.");
    if (s.Length == 0)
      return;
    XFont xfont = new XFont(family.Name, emSize, style);
    DiagnosticsHelper.HandleNotImplemented("XGraphicsPath.AddString");
  }

  public void CloseFigure() => this._corePath.CloseSubpath();

  public void StartFigure()
  {
  }

  public XFillMode FillMode
  {
    get => this._fillMode;
    set => this._fillMode = value;
  }

  public void Flatten()
  {
  }

  public void Flatten(XMatrix matrix)
  {
  }

  public void Flatten(XMatrix matrix, double flatness)
  {
  }

  public void Widen(XPen pen)
  {
  }

  public void Widen(XPen pen, XMatrix matrix)
  {
    throw new NotImplementedException("XGraphicsPath.Widen");
  }

  public void Widen(XPen pen, XMatrix matrix, double flatness)
  {
  }

  public XGraphicsPathInternals Internals => new XGraphicsPathInternals(this);
}
