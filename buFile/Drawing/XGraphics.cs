// Decompiled with JetBrains decompiler
// Type: PdfSharp.Drawing.XGraphics
// Assembly: buFile, Version=1.50.4740.0, Culture=neutral, PublicKeyToken=f94615aa0424f9eb
// MVID: 1F93257A-1245-4898-8C4E-DC1AB39EF50B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buFile.dll

using PdfSharp.Drawing.BarCodes;
using PdfSharp.Drawing.Pdf;
using PdfSharp.Pdf;
using PdfSharp.Pdf.Advanced;
using System;
using System.Diagnostics;

#nullable disable
namespace PdfSharp.Drawing;

public sealed class XGraphics : IDisposable
{
  private bool _disposed;
  private PdfFontEncoding _muh;
  internal XGraphicTargetContext TargetContext;
  private readonly XGraphicsUnit _pageUnit;
  private readonly XPageDirection _pageDirection;
  private XPoint _pageOrigin;
  private XSize _pageSize;
  private XSize _pageSizePoints;
  private XSmoothingMode _smoothingMode;
  private XGraphics.XGraphicsInternals _internals;
  private XGraphics.SpaceTransformer _transformer;
  private InternalGraphicsMode _internalGraphicsMode;
  private XImage _associatedImage;
  internal XMatrix DefaultViewMatrix;
  private bool _drawGraphics;
  private readonly XForm _form;
  private IXGraphicsRenderer _renderer;
  private XMatrix _transform;
  private readonly GraphicsStateStack _gsStack;

  private XGraphics(
    PdfPage page,
    XGraphicsPdfPageOptions options,
    XGraphicsUnit pageUnit,
    XPageDirection pageDirection)
  {
    if (page == null)
      throw new ArgumentNullException(nameof (page));
    if (page.Owner == null)
      throw new ArgumentException("You cannot draw on a page that is not owned by a PdfDocument object.", nameof (page));
    if (page.RenderContent != null)
      throw new InvalidOperationException("An XGraphics object already exists for this page and must be disposed before a new one can be created.");
    if (page.Owner.IsReadOnly)
      throw new InvalidOperationException("Cannot create XGraphics for a page of a document that cannot be modified. Use PdfDocumentOpenMode.Modify.");
    this._gsStack = new GraphicsStateStack(this);
    PdfContent pdfContent = (PdfContent) null;
    switch (options)
    {
      case XGraphicsPdfPageOptions.Append:
        pdfContent = page.Contents.AppendContent();
        break;
      case XGraphicsPdfPageOptions.Prepend:
        pdfContent = page.Contents.PrependContent();
        break;
      case XGraphicsPdfPageOptions.Replace:
        page.Contents.Elements.Clear();
        goto case XGraphicsPdfPageOptions.Append;
    }
    page.RenderContent = pdfContent;
    this.TargetContext = XGraphicTargetContext.CORE;
    this._renderer = (IXGraphicsRenderer) new XGraphicsPdfRenderer(page, this, options);
    this._pageSizePoints = new XSize((double) page.Width, (double) page.Height);
    switch (pageUnit)
    {
      case XGraphicsUnit.Point:
        this._pageSize = new XSize((double) page.Width, (double) page.Height);
        break;
      case XGraphicsUnit.Inch:
        this._pageSize = new XSize(XUnit.FromPoint((double) page.Width).Inch, XUnit.FromPoint((double) page.Height).Inch);
        break;
      case XGraphicsUnit.Millimeter:
        this._pageSize = new XSize(XUnit.FromPoint((double) page.Width).Millimeter, XUnit.FromPoint((double) page.Height).Millimeter);
        break;
      case XGraphicsUnit.Centimeter:
        this._pageSize = new XSize(XUnit.FromPoint((double) page.Width).Centimeter, XUnit.FromPoint((double) page.Height).Centimeter);
        break;
      case XGraphicsUnit.Presentation:
        this._pageSize = new XSize(XUnit.FromPoint((double) page.Width).Presentation, XUnit.FromPoint((double) page.Height).Presentation);
        break;
      default:
        throw new NotImplementedException("unit");
    }
    this._pageUnit = pageUnit;
    this._pageDirection = pageDirection;
    this.Initialize();
  }

  private XGraphics(XForm form)
  {
    this._form = form != null ? form : throw new ArgumentNullException(nameof (form));
    form.AssociateGraphics(this);
    this._gsStack = new GraphicsStateStack(this);
    this.TargetContext = XGraphicTargetContext.CORE;
    this._drawGraphics = false;
    if (form.Owner != null)
      this._renderer = (IXGraphicsRenderer) new XGraphicsPdfRenderer(form, this);
    this._pageSize = form.Size;
    this.Initialize();
  }

  public static XGraphics CreateMeasureContext(
    XSize size,
    XGraphicsUnit pageUnit,
    XPageDirection pageDirection)
  {
    return XGraphics.FromPdfPage(new PdfDocument().AddPage(), XGraphicsPdfPageOptions.Append, pageUnit, pageDirection);
  }

  public static XGraphics FromPdfPage(PdfPage page)
  {
    return new XGraphics(page, XGraphicsPdfPageOptions.Append, XGraphicsUnit.Point, XPageDirection.Downwards);
  }

  public static XGraphics FromPdfPage(PdfPage page, XGraphicsUnit unit)
  {
    return new XGraphics(page, XGraphicsPdfPageOptions.Append, unit, XPageDirection.Downwards);
  }

  public static XGraphics FromPdfPage(PdfPage page, XPageDirection pageDirection)
  {
    return new XGraphics(page, XGraphicsPdfPageOptions.Append, XGraphicsUnit.Point, pageDirection);
  }

  public static XGraphics FromPdfPage(PdfPage page, XGraphicsPdfPageOptions options)
  {
    return new XGraphics(page, options, XGraphicsUnit.Point, XPageDirection.Downwards);
  }

  public static XGraphics FromPdfPage(
    PdfPage page,
    XGraphicsPdfPageOptions options,
    XPageDirection pageDirection)
  {
    return new XGraphics(page, options, XGraphicsUnit.Point, pageDirection);
  }

  public static XGraphics FromPdfPage(
    PdfPage page,
    XGraphicsPdfPageOptions options,
    XGraphicsUnit unit)
  {
    return new XGraphics(page, options, unit, XPageDirection.Downwards);
  }

  public static XGraphics FromPdfPage(
    PdfPage page,
    XGraphicsPdfPageOptions options,
    XGraphicsUnit unit,
    XPageDirection pageDirection)
  {
    return new XGraphics(page, options, unit, pageDirection);
  }

  public static XGraphics FromPdfForm(XPdfForm form)
  {
    return form.Gfx == null ? new XGraphics((XForm) form) : form.Gfx;
  }

  public static XGraphics FromForm(XForm form) => form.Gfx == null ? new XGraphics(form) : form.Gfx;

  public static XGraphics FromImage(XImage image)
  {
    return XGraphics.FromImage(image, XGraphicsUnit.Point);
  }

  public static XGraphics FromImage(XImage image, XGraphicsUnit unit)
  {
    if (image == null)
      throw new ArgumentNullException(nameof (image));
    return !(image is XBitmapImage) ? (XGraphics) null : (XGraphics) null;
  }

  private void Initialize()
  {
    this._pageOrigin = new XPoint();
    double offsetY = this._pageSize.Height;
    PdfPage pdfPage = this.PdfPage;
    XPoint xpoint = new XPoint();
    if ((pdfPage == null ? 0 : (pdfPage.TrimMargins.AreSet ? 1 : 0)) != 0)
    {
      double num1 = offsetY;
      double point1 = pdfPage.TrimMargins.Top.Point;
      XUnit xunit = pdfPage.TrimMargins.Bottom;
      double point2 = xunit.Point;
      double num2 = point1 + point2;
      offsetY = num1 + num2;
      ref XPoint local = ref xpoint;
      xunit = pdfPage.TrimMargins.Left;
      double point3 = xunit.Point;
      xunit = pdfPage.TrimMargins.Top;
      double point4 = xunit.Point;
      local = new XPoint(point3, point4);
    }
    XMatrix xmatrix = new XMatrix();
    Debug.Assert(this.TargetContext == XGraphicTargetContext.CORE);
    if (this._pageDirection != 0)
      xmatrix.Prepend(new XMatrix(1.0, 0.0, 0.0, -1.0, 0.0, offsetY));
    if (xpoint != new XPoint())
      xmatrix.TranslatePrepend(xpoint.X, -xpoint.Y);
    this.DefaultViewMatrix = xmatrix;
    this._transform = new XMatrix();
  }

  public void Dispose() => this.Dispose(true);

  private void Dispose(bool disposing)
  {
    if (this._disposed)
      return;
    this._disposed = true;
    if (disposing && this._associatedImage != null)
    {
      this._associatedImage.DisassociateWithGraphics(this);
      this._associatedImage = (XImage) null;
    }
    if (this._form != null)
      this._form.Finish();
    this._drawGraphics = false;
    if (this._renderer == null)
      return;
    this._renderer.Close();
    this._renderer = (IXGraphicsRenderer) null;
  }

  public PdfFontEncoding MUH
  {
    get => this._muh;
    set => this._muh = value;
  }

  public XGraphicsUnit PageUnit => this._pageUnit;

  public XPageDirection PageDirection
  {
    get => this._pageDirection;
    set
    {
      if (value != 0)
        throw new NotImplementedException("PageDirection must be XPageDirection.Downwards in current implementation.");
    }
  }

  public XPoint PageOrigin
  {
    get => this._pageOrigin;
    set
    {
      if (value != new XPoint())
        throw new NotImplementedException("PageOrigin cannot be modified in current implementation.");
    }
  }

  public XSize PageSize => this._pageSize;

  public void DrawLine(XPen pen, XPoint pt1, XPoint pt2)
  {
    this.DrawLine(pen, pt1.X, pt1.Y, pt2.X, pt2.Y);
  }

  public void DrawLine(XPen pen, double x1, double y1, double x2, double y2)
  {
    if (pen == null)
      throw new ArgumentNullException(nameof (pen));
    if (this._drawGraphics)
      ;
    if (this._renderer == null)
      return;
    this._renderer.DrawLines(pen, new XPoint[2]
    {
      new XPoint(x1, y1),
      new XPoint(x2, y2)
    });
  }

  public void DrawLines(XPen pen, XPoint[] points)
  {
    if (pen == null)
      throw new ArgumentNullException(nameof (pen));
    if (points == null)
      throw new ArgumentNullException(nameof (points));
    if (points.Length < 2)
      throw new ArgumentException(PSSR.PointArrayAtLeast(2), nameof (points));
    if (this._drawGraphics)
      ;
    if (this._renderer == null)
      return;
    this._renderer.DrawLines(pen, points);
  }

  public void DrawLines(XPen pen, double x, double y, params double[] value)
  {
    if (pen == null)
      throw new ArgumentNullException(nameof (pen));
    int num = value != null ? value.Length : throw new ArgumentNullException(nameof (value));
    XPoint[] points = new XPoint[num / 2 + 1];
    points[0].X = x;
    points[0].Y = y;
    for (int index = 0; index < num / 2; ++index)
    {
      points[index + 1].X = value[2 * index];
      points[index + 1].Y = value[2 * index + 1];
    }
    this.DrawLines(pen, points);
  }

  public void DrawBezier(XPen pen, XPoint pt1, XPoint pt2, XPoint pt3, XPoint pt4)
  {
    this.DrawBezier(pen, pt1.X, pt1.Y, pt2.X, pt2.Y, pt3.X, pt3.Y, pt4.X, pt4.Y);
  }

  public void DrawBezier(
    XPen pen,
    double x1,
    double y1,
    double x2,
    double y2,
    double x3,
    double y3,
    double x4,
    double y4)
  {
    if (pen == null)
      throw new ArgumentNullException(nameof (pen));
    if (this._drawGraphics)
      ;
    if (this._renderer == null)
      return;
    this._renderer.DrawBeziers(pen, new XPoint[4]
    {
      new XPoint(x1, y1),
      new XPoint(x2, y2),
      new XPoint(x3, y3),
      new XPoint(x4, y4)
    });
  }

  public void DrawBeziers(XPen pen, XPoint[] points)
  {
    if (pen == null)
      throw new ArgumentNullException(nameof (pen));
    int length = points.Length;
    if (length == 0)
      return;
    if ((length - 1) % 3 != 0)
      throw new ArgumentException("Invalid number of points for bezier curves. Number must fulfill 4+3n.", nameof (points));
    if (this._drawGraphics)
      ;
    if (this._renderer == null)
      return;
    this._renderer.DrawBeziers(pen, points);
  }

  public void DrawCurve(XPen pen, XPoint[] points) => this.DrawCurve(pen, points, 0.5);

  public void DrawCurve(
    XPen pen,
    XPoint[] points,
    int offset,
    int numberOfSegments,
    double tension)
  {
    XPoint[] xpointArray = new XPoint[numberOfSegments];
    Array.Copy((Array) points, offset, (Array) xpointArray, 0, numberOfSegments);
    this.DrawCurve(pen, xpointArray, tension);
  }

  public void DrawCurve(XPen pen, XPoint[] points, double tension)
  {
    if (pen == null)
      throw new ArgumentNullException(nameof (pen));
    if (points == null)
      throw new ArgumentNullException(nameof (points));
    if (points.Length < 2)
      throw new ArgumentException("DrawCurve requires two or more points.", nameof (points));
    if (this._drawGraphics)
      ;
    if (this._renderer == null)
      return;
    this._renderer.DrawCurve(pen, points, tension);
  }

  public void DrawArc(XPen pen, XRect rect, double startAngle, double sweepAngle)
  {
    this.DrawArc(pen, rect.X, rect.Y, rect.Width, rect.Height, startAngle, sweepAngle);
  }

  public void DrawArc(
    XPen pen,
    double x,
    double y,
    double width,
    double height,
    double startAngle,
    double sweepAngle)
  {
    if (pen == null)
      throw new ArgumentNullException(nameof (pen));
    if (Math.Abs(sweepAngle) >= 360.0)
    {
      this.DrawEllipse(pen, x, y, width, height);
    }
    else
    {
      if (this._drawGraphics)
        ;
      if (this._renderer == null)
        return;
      this._renderer.DrawArc(pen, x, y, width, height, startAngle, sweepAngle);
    }
  }

  public void DrawRectangle(XPen pen, XRect rect)
  {
    this.DrawRectangle(pen, rect.X, rect.Y, rect.Width, rect.Height);
  }

  public void DrawRectangle(XPen pen, double x, double y, double width, double height)
  {
    if (pen == null)
      throw new ArgumentNullException(nameof (pen));
    if (this._drawGraphics)
      ;
    if (this._renderer == null)
      return;
    this._renderer.DrawRectangle(pen, (XBrush) null, x, y, width, height);
  }

  public void DrawRectangle(XBrush brush, XRect rect)
  {
    this.DrawRectangle(brush, rect.X, rect.Y, rect.Width, rect.Height);
  }

  public void DrawRectangle(XBrush brush, double x, double y, double width, double height)
  {
    if (brush == null)
      throw new ArgumentNullException(nameof (brush));
    if (this._drawGraphics)
      ;
    if (this._renderer == null)
      return;
    this._renderer.DrawRectangle((XPen) null, brush, x, y, width, height);
  }

  public void DrawRectangle(XPen pen, XBrush brush, XRect rect)
  {
    this.DrawRectangle(pen, brush, rect.X, rect.Y, rect.Width, rect.Height);
  }

  public void DrawRectangle(
    XPen pen,
    XBrush brush,
    double x,
    double y,
    double width,
    double height)
  {
    if ((pen != null ? 0 : (brush == null ? 1 : 0)) != 0)
      throw new ArgumentNullException("pen and brush", PSSR.NeedPenOrBrush);
    if (this._drawGraphics)
      ;
    if (this._renderer == null)
      return;
    this._renderer.DrawRectangle(pen, brush, x, y, width, height);
  }

  public void DrawRectangles(XPen pen, XRect[] rectangles)
  {
    if (pen == null)
      throw new ArgumentNullException(nameof (pen));
    if (rectangles == null)
      throw new ArgumentNullException(nameof (rectangles));
    this.DrawRectangles(pen, (XBrush) null, rectangles);
  }

  public void DrawRectangles(XBrush brush, XRect[] rectangles)
  {
    if (brush == null)
      throw new ArgumentNullException(nameof (brush));
    if (rectangles == null)
      throw new ArgumentNullException(nameof (rectangles));
    this.DrawRectangles((XPen) null, brush, rectangles);
  }

  public void DrawRectangles(XPen pen, XBrush brush, XRect[] rectangles)
  {
    if ((pen != null ? 0 : (brush == null ? 1 : 0)) != 0)
      throw new ArgumentNullException("pen and brush", PSSR.NeedPenOrBrush);
    int num = rectangles != null ? rectangles.Length : throw new ArgumentNullException(nameof (rectangles));
    if (this._drawGraphics)
      ;
    if (this._renderer == null)
      return;
    for (int index = 0; index < num; ++index)
    {
      XRect rectangle = rectangles[index];
      this._renderer.DrawRectangle(pen, brush, rectangle.X, rectangle.Y, rectangle.Width, rectangle.Height);
    }
  }

  public void DrawRoundedRectangle(XPen pen, XRect rect, XSize ellipseSize)
  {
    this.DrawRoundedRectangle(pen, rect.X, rect.Y, rect.Width, rect.Height, ellipseSize.Width, ellipseSize.Height);
  }

  public void DrawRoundedRectangle(
    XPen pen,
    double x,
    double y,
    double width,
    double height,
    double ellipseWidth,
    double ellipseHeight)
  {
    if (pen == null)
      throw new ArgumentNullException(nameof (pen));
    this.DrawRoundedRectangle(pen, (XBrush) null, x, y, width, height, ellipseWidth, ellipseHeight);
  }

  public void DrawRoundedRectangle(XBrush brush, XRect rect, XSize ellipseSize)
  {
    this.DrawRoundedRectangle(brush, rect.X, rect.Y, rect.Width, rect.Height, ellipseSize.Width, ellipseSize.Height);
  }

  public void DrawRoundedRectangle(
    XBrush brush,
    double x,
    double y,
    double width,
    double height,
    double ellipseWidth,
    double ellipseHeight)
  {
    if (brush == null)
      throw new ArgumentNullException(nameof (brush));
    this.DrawRoundedRectangle((XPen) null, brush, x, y, width, height, ellipseWidth, ellipseHeight);
  }

  public void DrawRoundedRectangle(XPen pen, XBrush brush, XRect rect, XSize ellipseSize)
  {
    this.DrawRoundedRectangle(pen, brush, rect.X, rect.Y, rect.Width, rect.Height, ellipseSize.Width, ellipseSize.Height);
  }

  public void DrawRoundedRectangle(
    XPen pen,
    XBrush brush,
    double x,
    double y,
    double width,
    double height,
    double ellipseWidth,
    double ellipseHeight)
  {
    if ((pen != null ? 0 : (brush == null ? 1 : 0)) != 0)
      throw new ArgumentNullException("pen and brush", PSSR.NeedPenOrBrush);
    if (this._drawGraphics)
      ;
    if (this._renderer == null)
      return;
    this._renderer.DrawRoundedRectangle(pen, brush, x, y, width, height, ellipseWidth, ellipseHeight);
  }

  public void DrawEllipse(XPen pen, XRect rect)
  {
    this.DrawEllipse(pen, rect.X, rect.Y, rect.Width, rect.Height);
  }

  public void DrawEllipse(XPen pen, double x, double y, double width, double height)
  {
    if (pen == null)
      throw new ArgumentNullException(nameof (pen));
    if (this._drawGraphics)
      ;
    if (this._renderer == null)
      return;
    this._renderer.DrawEllipse(pen, (XBrush) null, x, y, width, height);
  }

  public void DrawEllipse(XBrush brush, XRect rect)
  {
    this.DrawEllipse(brush, rect.X, rect.Y, rect.Width, rect.Height);
  }

  public void DrawEllipse(XBrush brush, double x, double y, double width, double height)
  {
    if (brush == null)
      throw new ArgumentNullException(nameof (brush));
    if (this._drawGraphics)
      ;
    if (this._renderer == null)
      return;
    this._renderer.DrawEllipse((XPen) null, brush, x, y, width, height);
  }

  public void DrawEllipse(XPen pen, XBrush brush, XRect rect)
  {
    this.DrawEllipse(pen, brush, rect.X, rect.Y, rect.Width, rect.Height);
  }

  public void DrawEllipse(
    XPen pen,
    XBrush brush,
    double x,
    double y,
    double width,
    double height)
  {
    if ((pen != null ? 0 : (brush == null ? 1 : 0)) != 0)
      throw new ArgumentNullException("pen and brush", PSSR.NeedPenOrBrush);
    if (this._drawGraphics)
      ;
    if (this._renderer == null)
      return;
    this._renderer.DrawEllipse(pen, brush, x, y, width, height);
  }

  public void DrawPolygon(XPen pen, XPoint[] points)
  {
    if (pen == null)
      throw new ArgumentNullException(nameof (pen));
    if (points == null)
      throw new ArgumentNullException(nameof (points));
    if (points.Length < 2)
      throw new ArgumentException(PSSR.PointArrayAtLeast(2), nameof (points));
    if (this._drawGraphics)
      ;
    if (this._renderer == null)
      return;
    this._renderer.DrawPolygon(pen, (XBrush) null, points, XFillMode.Alternate);
  }

  public void DrawPolygon(XBrush brush, XPoint[] points, XFillMode fillmode)
  {
    if (brush == null)
      throw new ArgumentNullException(nameof (brush));
    if (points == null)
      throw new ArgumentNullException(nameof (points));
    if (points.Length < 2)
      throw new ArgumentException(PSSR.PointArrayAtLeast(2), nameof (points));
    if (this._drawGraphics)
      ;
    if (this._renderer == null)
      return;
    this._renderer.DrawPolygon((XPen) null, brush, points, fillmode);
  }

  public void DrawPolygon(XPen pen, XBrush brush, XPoint[] points, XFillMode fillmode)
  {
    if ((pen != null ? 0 : (brush == null ? 1 : 0)) != 0)
      throw new ArgumentNullException("pen and brush", PSSR.NeedPenOrBrush);
    if (points == null)
      throw new ArgumentNullException(nameof (points));
    if (points.Length < 2)
      throw new ArgumentException(PSSR.PointArrayAtLeast(2), nameof (points));
    if (this._drawGraphics)
      ;
    if (this._renderer == null)
      return;
    this._renderer.DrawPolygon(pen, brush, points, fillmode);
  }

  public void DrawPie(XPen pen, XRect rect, double startAngle, double sweepAngle)
  {
    this.DrawPie(pen, rect.X, rect.Y, rect.Width, rect.Height, startAngle, sweepAngle);
  }

  public void DrawPie(
    XPen pen,
    double x,
    double y,
    double width,
    double height,
    double startAngle,
    double sweepAngle)
  {
    if (pen == null)
      throw new ArgumentNullException(nameof (pen), PSSR.NeedPenOrBrush);
    if (this._drawGraphics)
      ;
    if (this._renderer == null)
      return;
    this._renderer.DrawPie(pen, (XBrush) null, x, y, width, height, startAngle, sweepAngle);
  }

  public void DrawPie(XBrush brush, XRect rect, double startAngle, double sweepAngle)
  {
    this.DrawPie(brush, rect.X, rect.Y, rect.Width, rect.Height, startAngle, sweepAngle);
  }

  public void DrawPie(
    XBrush brush,
    double x,
    double y,
    double width,
    double height,
    double startAngle,
    double sweepAngle)
  {
    if (brush == null)
      throw new ArgumentNullException(nameof (brush), PSSR.NeedPenOrBrush);
    if (this._drawGraphics)
      ;
    if (this._renderer == null)
      return;
    this._renderer.DrawPie((XPen) null, brush, x, y, width, height, startAngle, sweepAngle);
  }

  public void DrawPie(XPen pen, XBrush brush, XRect rect, double startAngle, double sweepAngle)
  {
    this.DrawPie(pen, brush, rect.X, rect.Y, rect.Width, rect.Height, startAngle, sweepAngle);
  }

  public void DrawPie(
    XPen pen,
    XBrush brush,
    double x,
    double y,
    double width,
    double height,
    double startAngle,
    double sweepAngle)
  {
    if ((pen != null ? 0 : (brush == null ? 1 : 0)) != 0)
      throw new ArgumentNullException(nameof (pen), PSSR.NeedPenOrBrush);
    if (this._drawGraphics)
      ;
    if (this._renderer == null)
      return;
    this._renderer.DrawPie(pen, brush, x, y, width, height, startAngle, sweepAngle);
  }

  public void DrawClosedCurve(XPen pen, XPoint[] points)
  {
    this.DrawClosedCurve(pen, (XBrush) null, points, XFillMode.Alternate, 0.5);
  }

  public void DrawClosedCurve(XPen pen, XPoint[] points, double tension)
  {
    this.DrawClosedCurve(pen, (XBrush) null, points, XFillMode.Alternate, tension);
  }

  public void DrawClosedCurve(XBrush brush, XPoint[] points)
  {
    this.DrawClosedCurve((XPen) null, brush, points, XFillMode.Alternate, 0.5);
  }

  public void DrawClosedCurve(XBrush brush, XPoint[] points, XFillMode fillmode)
  {
    this.DrawClosedCurve((XPen) null, brush, points, fillmode, 0.5);
  }

  public void DrawClosedCurve(XBrush brush, XPoint[] points, XFillMode fillmode, double tension)
  {
    this.DrawClosedCurve((XPen) null, brush, points, fillmode, tension);
  }

  public void DrawClosedCurve(XPen pen, XBrush brush, XPoint[] points)
  {
    this.DrawClosedCurve(pen, brush, points, XFillMode.Alternate, 0.5);
  }

  public void DrawClosedCurve(XPen pen, XBrush brush, XPoint[] points, XFillMode fillmode)
  {
    this.DrawClosedCurve(pen, brush, points, fillmode, 0.5);
  }

  public void DrawClosedCurve(
    XPen pen,
    XBrush brush,
    XPoint[] points,
    XFillMode fillmode,
    double tension)
  {
    if ((pen != null ? 0 : (brush == null ? 1 : 0)) != 0)
      throw new ArgumentNullException("pen and brush", PSSR.NeedPenOrBrush);
    int length = points.Length;
    if (length == 0)
      return;
    if (length < 2)
      throw new ArgumentException("Not enough points.", nameof (points));
    if (this._drawGraphics)
      ;
    if (this._renderer == null)
      return;
    this._renderer.DrawClosedCurve(pen, brush, points, tension, fillmode);
  }

  public void DrawPath(XPen pen, XGraphicsPath path)
  {
    if (pen == null)
      throw new ArgumentNullException(nameof (pen));
    if (path == null)
      throw new ArgumentNullException(nameof (path));
    if (this._drawGraphics)
      ;
    if (this._renderer == null)
      return;
    this._renderer.DrawPath(pen, (XBrush) null, path);
  }

  public void DrawPath(XBrush brush, XGraphicsPath path)
  {
    if (brush == null)
      throw new ArgumentNullException(nameof (brush));
    if (path == null)
      throw new ArgumentNullException(nameof (path));
    if (this._drawGraphics)
      ;
    if (this._renderer == null)
      return;
    this._renderer.DrawPath((XPen) null, brush, path);
  }

  public void DrawPath(XPen pen, XBrush brush, XGraphicsPath path)
  {
    if ((pen != null ? 0 : (brush == null ? 1 : 0)) != 0)
      throw new ArgumentNullException("pen and brush", PSSR.NeedPenOrBrush);
    if (path == null)
      throw new ArgumentNullException(nameof (path));
    if (this._drawGraphics)
      ;
    if (this._renderer == null)
      return;
    this._renderer.DrawPath(pen, brush, path);
  }

  public void DrawString(string s, XFont font, XBrush brush, XPoint point)
  {
    this.DrawString(s, font, brush, new XRect(point.X, point.Y, 0.0, 0.0), XStringFormats.Default);
  }

  public void DrawString(string s, XFont font, XBrush brush, XPoint point, XStringFormat format)
  {
    this.DrawString(s, font, brush, new XRect(point.X, point.Y, 0.0, 0.0), format);
  }

  public void DrawString(string s, XFont font, XBrush brush, double x, double y)
  {
    this.DrawString(s, font, brush, new XRect(x, y, 0.0, 0.0), XStringFormats.Default);
  }

  public void DrawString(
    string s,
    XFont font,
    XBrush brush,
    double x,
    double y,
    XStringFormat format)
  {
    this.DrawString(s, font, brush, new XRect(x, y, 0.0, 0.0), format);
  }

  public void DrawString(string s, XFont font, XBrush brush, XRect layoutRectangle)
  {
    this.DrawString(s, font, brush, layoutRectangle, XStringFormats.Default);
  }

  public void DrawString(
    string text,
    XFont font,
    XBrush brush,
    XRect layoutRectangle,
    XStringFormat format)
  {
    if (text == null)
      throw new ArgumentNullException(nameof (text));
    if (font == null)
      throw new ArgumentNullException(nameof (font));
    if (brush == null)
      throw new ArgumentNullException(nameof (brush));
    if ((format == null || format.LineAlignment != XLineAlignment.BaseLine ? 0 : (layoutRectangle.Height != 0.0 ? 1 : 0)) != 0)
      throw new InvalidOperationException("DrawString: With XLineAlignment.BaseLine the height of the layout rectangle must be 0.");
    if (text.Length == 0)
      return;
    if (format == null)
      format = XStringFormats.Default;
    if (this._drawGraphics)
      ;
    if (this._renderer == null)
      return;
    this._renderer.DrawString(text, font, brush, layoutRectangle, format);
  }

  public XSize MeasureString(string text, XFont font, XStringFormat stringFormat)
  {
    if (text == null)
      throw new ArgumentNullException(nameof (text));
    if (font == null)
      throw new ArgumentNullException(nameof (font));
    if (stringFormat == null)
      throw new ArgumentNullException(nameof (stringFormat));
    return FontHelper.MeasureString(text, font, stringFormat);
  }

  public XSize MeasureString(string text, XFont font)
  {
    return this.MeasureString(text, font, XStringFormats.Default);
  }

  public void DrawImage(XImage image, XPoint point) => this.DrawImage(image, point.X, point.Y);

  public void DrawImage(XImage image, double x, double y)
  {
    if (image == null)
      throw new ArgumentNullException(nameof (image));
    this.CheckXPdfFormConsistence(image);
    double pointWidth = image.PointWidth;
    double pointHeight = image.PointHeight;
    if (this._drawGraphics)
      ;
    if (this._renderer == null)
      return;
    this._renderer.DrawImage(image, x, y, image.PointWidth, image.PointHeight);
  }

  public void DrawImage(XImage image, XRect rect)
  {
    this.DrawImage(image, rect.X, rect.Y, rect.Width, rect.Height);
  }

  public void DrawImage(XImage image, double x, double y, double width, double height)
  {
    if (image == null)
      throw new ArgumentNullException(nameof (image));
    this.CheckXPdfFormConsistence(image);
    if (this._drawGraphics)
      ;
    if (this._renderer == null)
      return;
    this._renderer.DrawImage(image, x, y, width, height);
  }

  public void DrawImage(XImage image, XRect destRect, XRect srcRect, XGraphicsUnit srcUnit)
  {
    if (image == null)
      throw new ArgumentNullException(nameof (image));
    this.CheckXPdfFormConsistence(image);
    if (this._drawGraphics)
      ;
    if (this._renderer == null)
      return;
    this._renderer.DrawImage(image, destRect, srcRect, srcUnit);
  }

  private void DrawMissingImageRect(XRect rect)
  {
  }

  private void CheckXPdfFormConsistence(XImage image)
  {
    if (!(image is XForm xform))
      return;
    xform.Finish();
    if ((this._renderer == null ? 0 : (this._renderer is XGraphicsPdfRenderer ? 1 : 0)) == 0)
      return;
    if ((xform.Owner == null ? 0 : (xform.Owner != ((XGraphicsPdfRenderer) this._renderer).Owner ? 1 : 0)) != 0)
      throw new InvalidOperationException("A XPdfForm object is always bound to the document it was created for and cannot be drawn in the context of another document.");
    if (xform == ((XGraphicsPdfRenderer) this._renderer)._form)
      throw new InvalidOperationException("A XPdfForm cannot be drawn on itself.");
  }

  public void DrawBarCode(BarCode barcode, XPoint position)
  {
    barcode.Render(this, (XBrush) XBrushes.Black, (XFont) null, position);
  }

  public void DrawBarCode(BarCode barcode, XBrush brush, XPoint position)
  {
    barcode.Render(this, brush, (XFont) null, position);
  }

  public void DrawBarCode(BarCode barcode, XBrush brush, XFont font, XPoint position)
  {
    barcode.Render(this, brush, font, position);
  }

  public void DrawMatrixCode(MatrixCode matrixcode, XPoint position)
  {
    matrixcode.Render(this, (XBrush) XBrushes.Black, position);
  }

  public void DrawMatrixCode(MatrixCode matrixcode, XBrush brush, XPoint position)
  {
    matrixcode.Render(this, brush, position);
  }

  public XGraphicsState Save()
  {
    XGraphicsState state = (XGraphicsState) null;
    if ((this.TargetContext == XGraphicTargetContext.CORE ? 1 : (this.TargetContext == XGraphicTargetContext.NONE ? 1 : 0)) != 0)
    {
      state = new XGraphicsState();
      this._gsStack.Push(new InternalGraphicsState(this, state)
      {
        Transform = this._transform
      });
    }
    else
      Debug.Assert(false, "XGraphicTargetContext must be XGraphicTargetContext.CORE.");
    if (this._renderer != null)
      this._renderer.Save(state);
    return state;
  }

  public void Restore(XGraphicsState state)
  {
    if (state == null)
      throw new ArgumentNullException(nameof (state));
    if (this.TargetContext == XGraphicTargetContext.CORE)
    {
      this._gsStack.Restore(state.InternalState);
      this._transform = state.InternalState.Transform;
    }
    if (this._renderer == null)
      return;
    this._renderer.Restore(state);
  }

  public void Restore()
  {
    if (this._gsStack.Count == 0)
      throw new InvalidOperationException("Cannot restore without preceding save operation.");
    this.Restore(this._gsStack.Current.State);
  }

  public XGraphicsContainer BeginContainer()
  {
    return this.BeginContainer(new XRect(0.0, 0.0, 1.0, 1.0), new XRect(0.0, 0.0, 1.0, 1.0), XGraphicsUnit.Point);
  }

  public XGraphicsContainer BeginContainer(XRect dstrect, XRect srcrect, XGraphicsUnit unit)
  {
    if (unit != 0)
      throw new ArgumentException("The current implementation supports XGraphicsUnit.Point only.", nameof (unit));
    XGraphicsContainer container = (XGraphicsContainer) null;
    if (this.TargetContext == XGraphicTargetContext.CORE)
      container = new XGraphicsContainer();
    this._gsStack.Push(new InternalGraphicsState(this, container)
    {
      Transform = this._transform
    });
    if (this._renderer != null)
      this._renderer.BeginContainer(container, dstrect, srcrect, unit);
    XMatrix transform = new XMatrix();
    double scaleX = dstrect.Width / srcrect.Width;
    double scaleY = dstrect.Height / srcrect.Height;
    transform.TranslatePrepend(-srcrect.X, -srcrect.Y);
    transform.ScalePrepend(scaleX, scaleY);
    transform.TranslatePrepend(dstrect.X / scaleX, dstrect.Y / scaleY);
    this.AddTransform(transform, XMatrixOrder.Prepend);
    return container;
  }

  public void EndContainer(XGraphicsContainer container)
  {
    if (container == null)
      throw new ArgumentNullException(nameof (container));
    this._gsStack.Restore(container.InternalState);
    this._transform = container.InternalState.Transform;
    if (this._renderer == null)
      return;
    this._renderer.EndContainer(container);
  }

  public int GraphicsStateLevel => this._gsStack.Count;

  public XSmoothingMode SmoothingMode
  {
    get => this._smoothingMode;
    set => this._smoothingMode = value;
  }

  public void TranslateTransform(double dx, double dy)
  {
    this.AddTransform(XMatrix.CreateTranslation(dx, dy), XMatrixOrder.Prepend);
  }

  public void TranslateTransform(double dx, double dy, XMatrixOrder order)
  {
    XMatrix transform = new XMatrix();
    transform.TranslatePrepend(dx, dy);
    this.AddTransform(transform, order);
  }

  public void ScaleTransform(double scaleX, double scaleY)
  {
    this.AddTransform(XMatrix.CreateScaling(scaleX, scaleY), XMatrixOrder.Prepend);
  }

  public void ScaleTransform(double scaleX, double scaleY, XMatrixOrder order)
  {
    XMatrix transform = new XMatrix();
    transform.ScalePrepend(scaleX, scaleY);
    this.AddTransform(transform, order);
  }

  public void ScaleTransform(double scaleXY) => this.ScaleTransform(scaleXY, scaleXY);

  public void ScaleTransform(double scaleXY, XMatrixOrder order)
  {
    this.ScaleTransform(scaleXY, scaleXY, order);
  }

  public void ScaleAtTransform(double scaleX, double scaleY, double centerX, double centerY)
  {
    this.AddTransform(XMatrix.CreateScaling(scaleX, scaleY, centerX, centerY), XMatrixOrder.Prepend);
  }

  public void ScaleAtTransform(double scaleX, double scaleY, XPoint center)
  {
    this.AddTransform(XMatrix.CreateScaling(scaleX, scaleY, center.X, center.Y), XMatrixOrder.Prepend);
  }

  public void RotateTransform(double angle)
  {
    this.AddTransform(XMatrix.CreateRotationRadians(angle * (Math.PI / 180.0)), XMatrixOrder.Prepend);
  }

  public void RotateTransform(double angle, XMatrixOrder order)
  {
    XMatrix transform = new XMatrix();
    transform.RotatePrepend(angle);
    this.AddTransform(transform, order);
  }

  public void RotateAtTransform(double angle, XPoint point)
  {
    this.AddTransform(XMatrix.CreateRotationRadians(angle * (Math.PI / 180.0), point.X, point.Y), XMatrixOrder.Prepend);
  }

  public void RotateAtTransform(double angle, XPoint point, XMatrixOrder order)
  {
    this.AddTransform(XMatrix.CreateRotationRadians(angle * (Math.PI / 180.0), point.X, point.Y), order);
  }

  public void ShearTransform(double shearX, double shearY)
  {
    this.AddTransform(XMatrix.CreateSkewRadians(shearX * (Math.PI / 180.0), shearY * (Math.PI / 180.0)), XMatrixOrder.Prepend);
  }

  public void ShearTransform(double shearX, double shearY, XMatrixOrder order)
  {
    this.AddTransform(XMatrix.CreateSkewRadians(shearX * (Math.PI / 180.0), shearY * (Math.PI / 180.0)), order);
  }

  public void SkewAtTransform(double shearX, double shearY, double centerX, double centerY)
  {
    this.AddTransform(XMatrix.CreateSkewRadians(shearX * (Math.PI / 180.0), shearY * (Math.PI / 180.0), centerX, centerY), XMatrixOrder.Prepend);
  }

  public void SkewAtTransform(double shearX, double shearY, XPoint center)
  {
    this.AddTransform(XMatrix.CreateSkewRadians(shearX * (Math.PI / 180.0), shearY * (Math.PI / 180.0), center.X, center.Y), XMatrixOrder.Prepend);
  }

  public void MultiplyTransform(XMatrix matrix) => this.AddTransform(matrix, XMatrixOrder.Prepend);

  public void MultiplyTransform(XMatrix matrix, XMatrixOrder order)
  {
    this.AddTransform(matrix, order);
  }

  public XMatrix Transform => this._transform;

  private void AddTransform(XMatrix transform, XMatrixOrder order)
  {
    XMatrix transform1 = this._transform;
    transform1.Multiply(transform, order);
    this._transform = transform1;
    this.DefaultViewMatrix.Multiply(this._transform, XMatrixOrder.Prepend);
    if (this.TargetContext == XGraphicTargetContext.CORE)
      this.GetType();
    if (this._renderer == null)
      return;
    this._renderer.AddTransform(transform, XMatrixOrder.Prepend);
  }

  public void IntersectClip(XRect rect)
  {
    XGraphicsPath path = new XGraphicsPath();
    path.AddRectangle(rect);
    this.IntersectClip(path);
  }

  public void IntersectClip(XGraphicsPath path)
  {
    if (path == null)
      throw new ArgumentNullException(nameof (path));
    if (this._drawGraphics)
      ;
    if (this._renderer == null)
      return;
    this._renderer.SetClip(path, XCombineMode.Intersect);
  }

  public void WriteComment(string comment)
  {
    if (comment == null)
      throw new ArgumentNullException(nameof (comment));
    if (this._drawGraphics)
      ;
    if (this._renderer == null)
      return;
    this._renderer.WriteComment(comment);
  }

  public XGraphics.XGraphicsInternals Internals
  {
    get => this._internals ?? (this._internals = new XGraphics.XGraphicsInternals(this));
  }

  public XGraphics.SpaceTransformer Transformer
  {
    get => this._transformer ?? (this._transformer = new XGraphics.SpaceTransformer(this));
  }

  internal void DisassociateImage()
  {
    if (this._associatedImage == null)
      throw new InvalidOperationException("No image associated.");
    this.Dispose();
  }

  internal InternalGraphicsMode InternalGraphicsMode
  {
    get => this._internalGraphicsMode;
    set => this._internalGraphicsMode = value;
  }

  internal XImage AssociatedImage
  {
    get => this._associatedImage;
    set => this._associatedImage = value;
  }

  public PdfPage PdfPage
  {
    get => this._renderer is XGraphicsPdfRenderer renderer ? renderer._page : (PdfPage) null;
  }

  public class XGraphicsInternals
  {
    private readonly XGraphics _gfx;

    internal XGraphicsInternals(XGraphics gfx) => this._gfx = gfx;
  }

  public class SpaceTransformer
  {
    private readonly XGraphics _gfx;

    internal SpaceTransformer(XGraphics gfx) => this._gfx = gfx;

    public XRect WorldToDefaultPage(XRect rect)
    {
      XPoint[] points = new XPoint[4]
      {
        new XPoint(rect.X, rect.Y),
        new XPoint(rect.X + rect.Width, rect.Y),
        new XPoint(rect.X, rect.Y + rect.Height),
        new XPoint(rect.X + rect.Width, rect.Y + rect.Height)
      };
      this._gfx.Transform.TransformPoints(points);
      double height = this._gfx.PageSize.Height;
      points[0].Y = height - points[0].Y;
      points[1].Y = height - points[1].Y;
      points[2].Y = height - points[2].Y;
      points[3].Y = height - points[3].Y;
      double x = Math.Min(Math.Min(points[0].X, points[1].X), Math.Min(points[2].X, points[3].X));
      double num1 = Math.Max(Math.Max(points[0].X, points[1].X), Math.Max(points[2].X, points[3].X));
      double y = Math.Min(Math.Min(points[0].Y, points[1].Y), Math.Min(points[2].Y, points[3].Y));
      double num2 = Math.Max(Math.Max(points[0].Y, points[1].Y), Math.Max(points[2].Y, points[3].Y));
      return new XRect(x, y, num1 - x, num2 - y);
    }
  }
}
