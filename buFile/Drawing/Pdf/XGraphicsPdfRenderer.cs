// Decompiled with JetBrains decompiler
// Type: PdfSharp.Drawing.Pdf.XGraphicsPdfRenderer
// Assembly: buFile, Version=1.50.4740.0, Culture=neutral, PublicKeyToken=f94615aa0424f9eb
// MVID: 1F93257A-1245-4898-8C4E-DC1AB39EF50B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buFile.dll

using PdfSharp.Fonts.OpenType;
using PdfSharp.Pdf;
using PdfSharp.Pdf.Advanced;
using PdfSharp.Pdf.Internal;
using PdfSharp.Pdf.Security;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Text;

#nullable disable
namespace PdfSharp.Drawing.Pdf;

internal class XGraphicsPdfRenderer : IXGraphicsRenderer
{
  private int _clipLevel;
  private StreamMode _streamMode;
  internal PdfPage _page;
  internal XForm _form;
  internal PdfColorMode _colorMode;
  private XGraphicsPdfPageOptions _options;
  private XGraphics _gfx;
  private readonly StringBuilder _content;
  private const int GraphicsStackLevelInitial = 0;
  private const int GraphicsStackLevelPageSpace = 1;
  private const int GraphicsStackLevelWorldSpace = 2;
  private PdfGraphicsState _gfxState;
  private readonly Stack<PdfGraphicsState> _gfxStateStack = new Stack<PdfGraphicsState>();
  public double PageHeightPt;
  public XMatrix DefaultViewMatrix;

  public XGraphicsPdfRenderer(PdfPage page, XGraphics gfx, XGraphicsPdfPageOptions options)
  {
    this._page = page;
    this._colorMode = page._document.Options.ColorMode;
    this._options = options;
    this._gfx = gfx;
    this._content = new StringBuilder();
    page.RenderContent._pdfRenderer = this;
    this._gfxState = new PdfGraphicsState(this);
  }

  public XGraphicsPdfRenderer(XForm form, XGraphics gfx)
  {
    this._form = form;
    this._colorMode = form.Owner.Options.ColorMode;
    this._gfx = gfx;
    this._content = new StringBuilder();
    form.PdfRenderer = this;
    this._gfxState = new PdfGraphicsState(this);
  }

  private string GetContent()
  {
    this.EndPage();
    return this._content.ToString();
  }

  public XGraphicsPdfPageOptions PageOptions => this._options;

  public void Close()
  {
    if (this._page != null)
    {
      this._page.RenderContent.CreateStream(PdfEncoders.RawEncoding.GetBytes(this.GetContent()));
      this._gfx = (XGraphics) null;
      this._page.RenderContent._pdfRenderer = (XGraphicsPdfRenderer) null;
      this._page.RenderContent = (PdfContent) null;
      this._page = (PdfPage) null;
    }
    else
    {
      if (this._form == null)
        return;
      this._form._pdfForm.CreateStream(PdfEncoders.RawEncoding.GetBytes(this.GetContent()));
      this._gfx = (XGraphics) null;
      this._form.PdfRenderer = (XGraphicsPdfRenderer) null;
      this._form = (XForm) null;
    }
  }

  public void DrawLine(XPen pen, double x1, double y1, double x2, double y2)
  {
    this.DrawLines(pen, new XPoint[2]
    {
      new XPoint(x1, y1),
      new XPoint(x2, y2)
    });
  }

  public void DrawLines(XPen pen, XPoint[] points)
  {
    if (pen == null)
      throw new ArgumentNullException(nameof (pen));
    int num = points != null ? points.Length : throw new ArgumentNullException(nameof (points));
    if (num == 0)
      return;
    this.Realize(pen);
    this.AppendFormatPoint("{0:0.####} {1:0.####} m\n", points[0].X, points[0].Y);
    for (int index = 1; index < num; ++index)
      this.AppendFormatPoint("{0:0.####} {1:0.####} l\n", points[index].X, points[index].Y);
    this._content.Append("S\n");
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
    this.DrawBeziers(pen, new XPoint[4]
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
    int num = points != null ? points.Length : throw new ArgumentNullException(nameof (points));
    if (num == 0)
      return;
    if ((num - 1) % 3 != 0)
      throw new ArgumentException("Invalid number of points for bezier curves. Number must fulfil 4+3n.", nameof (points));
    this.Realize(pen);
    this.AppendFormatPoint("{0:0.####} {1:0.####} m\n", points[0].X, points[0].Y);
    for (int index = 1; index < num; index += 3)
      this.AppendFormat3Points("{0:0.####} {1:0.####} {2:0.####} {3:0.####} {4:0.####} {5:0.####} c\n", points[index].X, points[index].Y, points[index + 1].X, points[index + 1].Y, points[index + 2].X, points[index + 2].Y);
    this.AppendStrokeFill(pen, (XBrush) null, XFillMode.Alternate, false);
  }

  public void DrawCurve(XPen pen, XPoint[] points, double tension)
  {
    if (pen == null)
      throw new ArgumentNullException(nameof (pen));
    int num = points != null ? points.Length : throw new ArgumentNullException(nameof (points));
    if (num == 0)
      return;
    if (num < 2)
      throw new ArgumentException("Not enough points", nameof (points));
    tension /= 3.0;
    this.Realize(pen);
    this.AppendFormatPoint("{0:0.####} {1:0.####} m\n", points[0].X, points[0].Y);
    if (num == 2)
    {
      this.AppendCurveSegment(points[0], points[0], points[1], points[1], tension);
    }
    else
    {
      this.AppendCurveSegment(points[0], points[0], points[1], points[2], tension);
      for (int index = 1; index < num - 2; ++index)
        this.AppendCurveSegment(points[index - 1], points[index], points[index + 1], points[index + 2], tension);
      this.AppendCurveSegment(points[num - 3], points[num - 2], points[num - 1], points[num - 1], tension);
    }
    this.AppendStrokeFill(pen, (XBrush) null, XFillMode.Alternate, false);
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
    this.Realize(pen);
    this.AppendPartialArc(x, y, width, height, startAngle, sweepAngle, PathStart.MoveTo1st, new XMatrix());
    this.AppendStrokeFill(pen, (XBrush) null, XFillMode.Alternate, false);
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
      throw new ArgumentNullException("pen and brush");
    this.Realize(pen, brush);
    this.AppendFormatRect("{0:0.###} {1:0.###} {2:0.###} {3:0.###} re\n", x, y + height, width, height);
    if ((pen == null ? 0 : (brush != null ? 1 : 0)) != 0)
      this._content.Append("B\n");
    else if (pen != null)
      this._content.Append("S\n");
    else
      this._content.Append("f\n");
  }

  public void DrawRectangles(XPen pen, XBrush brush, XRect[] rects)
  {
    int length = rects.Length;
    for (int index = 0; index < length; ++index)
    {
      XRect rect = rects[index];
      this.DrawRectangle(pen, brush, rect.X, rect.Y, rect.Width, rect.Height);
    }
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
    XGraphicsPath path = new XGraphicsPath();
    path.AddRoundedRectangle(x, y, width, height, ellipseWidth, ellipseHeight);
    this.DrawPath(pen, brush, path);
  }

  public void DrawEllipse(
    XPen pen,
    XBrush brush,
    double x,
    double y,
    double width,
    double height)
  {
    this.Realize(pen, brush);
    XRect xrect = new XRect(x, y, width, height);
    double num1 = xrect.Width / 2.0;
    double num2 = xrect.Height / 2.0;
    double num3 = num1 * 0.55228474983079345;
    double num4 = num2 * 0.55228474983079345;
    double x3 = xrect.X + num1;
    double num5 = xrect.Y + num2;
    this.AppendFormatPoint("{0:0.####} {1:0.####} m\n", x3 + num1, num5);
    this.AppendFormat3Points("{0:0.####} {1:0.####} {2:0.####} {3:0.####} {4:0.####} {5:0.####} c\n", x3 + num1, num5 + num4, x3 + num3, num5 + num2, x3, num5 + num2);
    this.AppendFormat3Points("{0:0.####} {1:0.####} {2:0.####} {3:0.####} {4:0.####} {5:0.####} c\n", x3 - num3, num5 + num2, x3 - num1, num5 + num4, x3 - num1, num5);
    this.AppendFormat3Points("{0:0.####} {1:0.####} {2:0.####} {3:0.####} {4:0.####} {5:0.####} c\n", x3 - num1, num5 - num4, x3 - num3, num5 - num2, x3, num5 - num2);
    this.AppendFormat3Points("{0:0.####} {1:0.####} {2:0.####} {3:0.####} {4:0.####} {5:0.####} c\n", x3 + num3, num5 - num2, x3 + num1, num5 - num4, x3 + num1, num5);
    this.AppendStrokeFill(pen, brush, XFillMode.Winding, true);
  }

  public void DrawPolygon(XPen pen, XBrush brush, XPoint[] points, XFillMode fillmode)
  {
    this.Realize(pen, brush);
    int length = points.Length;
    if (points.Length < 2)
      throw new ArgumentException(PSSR.PointArrayAtLeast(2), nameof (points));
    this.AppendFormatPoint("{0:0.####} {1:0.####} m\n", points[0].X, points[0].Y);
    for (int index = 1; index < length; ++index)
      this.AppendFormatPoint("{0:0.####} {1:0.####} l\n", points[index].X, points[index].Y);
    this.AppendStrokeFill(pen, brush, fillmode, true);
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
    this.Realize(pen, brush);
    this.AppendFormatPoint("{0:0.####} {1:0.####} m\n", x + width / 2.0, y + height / 2.0);
    this.AppendPartialArc(x, y, width, height, startAngle, sweepAngle, PathStart.LineTo1st, new XMatrix());
    this.AppendStrokeFill(pen, brush, XFillMode.Alternate, true);
  }

  public void DrawClosedCurve(
    XPen pen,
    XBrush brush,
    XPoint[] points,
    double tension,
    XFillMode fillmode)
  {
    int length = points.Length;
    if (length == 0)
      return;
    if (length < 2)
      throw new ArgumentException("Not enough points.", nameof (points));
    tension /= 3.0;
    this.Realize(pen, brush);
    this.AppendFormatPoint("{0:0.####} {1:0.####} m\n", points[0].X, points[0].Y);
    if (length == 2)
    {
      this.AppendCurveSegment(points[0], points[0], points[1], points[1], tension);
    }
    else
    {
      this.AppendCurveSegment(points[length - 1], points[0], points[1], points[2], tension);
      for (int index = 1; index < length - 2; ++index)
        this.AppendCurveSegment(points[index - 1], points[index], points[index + 1], points[index + 2], tension);
      this.AppendCurveSegment(points[length - 3], points[length - 2], points[length - 1], points[0], tension);
      this.AppendCurveSegment(points[length - 2], points[length - 1], points[0], points[1], tension);
    }
    this.AppendStrokeFill(pen, brush, fillmode, true);
  }

  public void DrawPath(XPen pen, XBrush brush, XGraphicsPath path)
  {
    if ((pen != null ? 0 : (brush == null ? 1 : 0)) != 0)
      throw new ArgumentNullException(nameof (pen));
    this.Realize(pen, brush);
    this.AppendPath(path._corePath);
    this.AppendStrokeFill(pen, brush, path.FillMode, false);
  }

  public void DrawString(string s, XFont font, XBrush brush, XRect rect, XStringFormat format)
  {
    double x = rect.X;
    double y1 = rect.Y;
    double height1 = font.GetHeight();
    double num1 = height1 * (double) font.CellAscent / (double) font.CellSpace;
    double num2 = height1 * (double) font.CellDescent / (double) font.CellSpace;
    double width = this._gfx.MeasureString(s, font).Width;
    bool flag1 = (font.GlyphTypeface.StyleSimulations & XStyleSimulations.ItalicSimulation) != 0;
    bool flag2 = (font.GlyphTypeface.StyleSimulations & XStyleSimulations.BoldSimulation) != 0;
    bool flag3 = (font.Style & XFontStyle.Strikeout) != 0;
    bool flag4 = (font.Style & XFontStyle.Underline) != 0;
    this.Realize(font, brush, flag2 ? 2 : 0);
    switch (format.Alignment)
    {
      case XStringAlignment.Center:
        x += (rect.Width - width) / 2.0;
        break;
      case XStringAlignment.Far:
        x += rect.Width - width;
        break;
    }
    if (this.Gfx.PageDirection == XPageDirection.Downwards)
    {
      switch (format.LineAlignment)
      {
        case XLineAlignment.Near:
          y1 += num1;
          break;
        case XLineAlignment.Center:
          y1 += num1 * 3.0 / 4.0 / 2.0 + rect.Height / 2.0;
          break;
        case XLineAlignment.Far:
          y1 += -num2 + rect.Height;
          break;
      }
    }
    else
    {
      switch (format.LineAlignment)
      {
        case XLineAlignment.Near:
          y1 += num2;
          break;
        case XLineAlignment.Center:
          y1 += -(num1 * 3.0 / 4.0) / 2.0 + rect.Height / 2.0;
          break;
        case XLineAlignment.Far:
          y1 += -num1 + rect.Height;
          break;
      }
    }
    PdfFont realizedFont = this._gfxState._realizedFont;
    Debug.Assert(realizedFont != null);
    realizedFont.AddChars(s);
    OpenTypeDescriptor descriptor = realizedFont.FontDescriptor._descriptor;
    string stringLiteral;
    if (font.Unicode)
    {
      StringBuilder stringBuilder = new StringBuilder();
      bool symbol = descriptor.FontFace.cmap.symbol;
      for (int index = 0; index < s.Length; ++index)
      {
        char ch = s[index];
        if (symbol)
          ch |= (char) ((uint) descriptor.FontFace.os2.usFirstCharIndex & 65280U);
        int glyphIndex = descriptor.CharCodeToGlyphIndex(ch);
        stringBuilder.Append((char) glyphIndex);
      }
      s = stringBuilder.ToString();
      byte[] bytes = PdfEncoders.FormatStringLiteral(PdfEncoders.RawUnicodeEncoding.GetBytes(s), true, false, true, (PdfStandardSecurityHandler) null);
      stringLiteral = PdfEncoders.RawEncoding.GetString(bytes, 0, bytes.Length);
    }
    else
      stringLiteral = PdfEncoders.ToStringLiteral(PdfEncoders.WinAnsiEncoding.GetBytes(s), false, (PdfStandardSecurityHandler) null);
    XPoint view = this.WorldToView(new XPoint(x, y1));
    double dy = 0.0;
    if (flag2)
      ;
    if (flag1)
    {
      if (this._gfxState.ItalicSimulationOn)
      {
        this.AdjustTdOffset(ref view, dy, true);
        this.AppendFormatArgs("{0:0.####} {1:0.####} Td\n{2} Tj\n", (object) view.X, (object) view.Y, (object) stringLiteral);
      }
      else
      {
        XMatrix xmatrix = new XMatrix(1.0, 0.0, 0.34202014332566871, 1.0, view.X, view.Y);
        this.AppendFormatArgs("{0:0.####} {1:0.####} {2:0.####} {3:0.####} {4:0.####} {5:0.####} Tm\n{6} Tj\n", (object) xmatrix.M11, (object) xmatrix.M12, (object) xmatrix.M21, (object) xmatrix.M22, (object) xmatrix.OffsetX, (object) xmatrix.OffsetY, (object) stringLiteral);
        this._gfxState.ItalicSimulationOn = true;
        this.AdjustTdOffset(ref view, dy, false);
      }
    }
    else if (this._gfxState.ItalicSimulationOn)
    {
      XMatrix xmatrix = new XMatrix(1.0, 0.0, 0.0, 1.0, view.X, view.Y);
      this.AppendFormatArgs("{0:0.####} {1:0.####} {2:0.####} {3:0.####} {4:0.####} {5:0.####} Tm\n{6} Tj\n", (object) xmatrix.M11, (object) xmatrix.M12, (object) xmatrix.M21, (object) xmatrix.M22, (object) xmatrix.OffsetX, (object) xmatrix.OffsetY, (object) stringLiteral);
      this._gfxState.ItalicSimulationOn = false;
      this.AdjustTdOffset(ref view, dy, false);
    }
    else
    {
      this.AdjustTdOffset(ref view, dy, false);
      this.AppendFormatArgs("{0:0.####} {1:0.####} Td {2} Tj\n", (object) view.X, (object) view.Y, (object) stringLiteral);
    }
    if (flag4)
    {
      double num3 = height1 * (double) realizedFont.FontDescriptor._descriptor.UnderlinePosition / (double) font.CellSpace;
      double height2 = height1 * (double) realizedFont.FontDescriptor._descriptor.UnderlineThickness / (double) font.CellSpace;
      double y2 = this.Gfx.PageDirection == XPageDirection.Downwards ? y1 - num3 : y1 + num3 - height2;
      this.DrawRectangle((XPen) null, brush, x, y2, width, height2);
    }
    if (!flag3)
      return;
    double num4 = height1 * (double) realizedFont.FontDescriptor._descriptor.StrikeoutPosition / (double) font.CellSpace;
    double height3 = height1 * (double) realizedFont.FontDescriptor._descriptor.StrikeoutSize / (double) font.CellSpace;
    double y3 = this.Gfx.PageDirection == XPageDirection.Downwards ? y1 - num4 : y1 + num4 - height3;
    this.DrawRectangle((XPen) null, brush, x, y3, width, height3);
  }

  public void DrawImage(XImage image, double x, double y, double width, double height)
  {
    string name = this.Realize(image);
    if (!(image is XForm))
    {
      if (this._gfx.PageDirection == XPageDirection.Downwards)
        this.AppendFormatImage("q {2:0.####} 0 0 {3:0.####} {0:0.####} {1:0.####} cm {4} Do Q\n", x, y + height, width, height, name);
      else
        this.AppendFormatImage("q {2:0.####} 0 0 {3:0.####} {0:0.####} {1:0.####} cm {4} Do Q\n", x, y, width, height, name);
    }
    else
    {
      this.BeginPage();
      XForm form = (XForm) image;
      form.Finish();
      this.Owner.FormTable.GetForm(form);
      double width1 = width / image.PointWidth;
      double height1 = height / image.PointHeight;
      if ((width1 == 0.0 ? 0 : (height1 != 0.0 ? 1 : 0)) == 0)
        return;
      XPdfForm xpdfForm = image as XPdfForm;
      if (this._gfx.PageDirection == XPageDirection.Downwards)
      {
        double x1 = x;
        double num = y;
        if (xpdfForm != null)
        {
          x1 -= xpdfForm.Page.MediaBox.X1;
          num += xpdfForm.Page.MediaBox.Y1;
        }
        this.AppendFormatImage("q {2:0.####} 0 0 {3:0.####} {0:0.####} {1:0.####} cm 100 Tz {4} Do Q\n", x1, num + height, width1, height1, name);
      }
      else
        this.AppendFormatImage("q {2:0.####} 0 0 {3:0.####} {0:0.####} {1:0.####} cm {4} Do Q\n", x, y, width1, height1, name);
    }
  }

  public void DrawImage(XImage image, XRect destRect, XRect srcRect, XGraphicsUnit srcUnit)
  {
    double x1 = destRect.X;
    double y = destRect.Y;
    double width1 = destRect.Width;
    double height1 = destRect.Height;
    string name = this.Realize(image);
    if (!(image is XForm))
    {
      if (this._gfx.PageDirection == XPageDirection.Downwards)
        this.AppendFormatImage("q {2:0.####} 0 0 {3:0.####} {0:0.####} {1:0.####} cm {4} Do\nQ\n", x1, y + height1, width1, height1, name);
      else
        this.AppendFormatImage("q {2:0.####} 0 0 {3:0.####} {0:0.####} {1:0.####} cm {4} Do Q\n", x1, y, width1, height1, name);
    }
    else
    {
      this.BeginPage();
      XForm form = (XForm) image;
      form.Finish();
      this.Owner.FormTable.GetForm(form);
      double width2 = width1 / image.PointWidth;
      double height2 = height1 / image.PointHeight;
      if ((width2 == 0.0 ? 0 : (height2 != 0.0 ? 1 : 0)) == 0)
        return;
      XPdfForm xpdfForm = image as XPdfForm;
      if (this._gfx.PageDirection == XPageDirection.Downwards)
      {
        double x2 = x1;
        double num = y;
        if (xpdfForm != null)
        {
          x2 -= xpdfForm.Page.MediaBox.X1;
          num += xpdfForm.Page.MediaBox.Y1;
        }
        this.AppendFormatImage("q {2:0.####} 0 0 {3:0.####} {0:0.####} {1:0.####} cm {4} Do Q\n", x2, num + height1, width2, height2, name);
      }
      else
        this.AppendFormatImage("q {2:0.####} 0 0 {3:0.####} {0:0.####} {1:0.####} cm {4} Do Q\n", x1, y, width2, height2, name);
    }
  }

  public void Save(XGraphicsState state)
  {
    this.BeginGraphicMode();
    this.RealizeTransform();
    this._gfxState.InternalState = state.InternalState;
    this.SaveState();
  }

  public void Restore(XGraphicsState state)
  {
    this.BeginGraphicMode();
    this.RestoreState(state.InternalState);
  }

  public void BeginContainer(
    XGraphicsContainer container,
    XRect dstrect,
    XRect srcrect,
    XGraphicsUnit unit)
  {
    this.BeginGraphicMode();
    this.RealizeTransform();
    this._gfxState.InternalState = container.InternalState;
    this.SaveState();
  }

  public void EndContainer(XGraphicsContainer container)
  {
    this.BeginGraphicMode();
    this.RestoreState(container.InternalState);
  }

  public XMatrix Transform
  {
    get
    {
      return !this._gfxState.UnrealizedCtm.IsIdentity ? this._gfxState.UnrealizedCtm * this._gfxState.RealizedCtm : this._gfxState.EffectiveCtm;
    }
  }

  public void AddTransform(XMatrix value, XMatrixOrder matrixOrder)
  {
    this._gfxState.AddTransform(value, matrixOrder);
  }

  public void SetClip(XGraphicsPath path, XCombineMode combineMode)
  {
    if (path == null)
      throw new NotImplementedException("SetClip with no path.");
    if (this._gfxState.Level < 2)
      this.RealizeTransform();
    switch (combineMode)
    {
      case XCombineMode.Replace:
        if (this._clipLevel != 0)
        {
          if (this._clipLevel != this._gfxState.Level)
            throw new NotImplementedException("Cannot set new clip region in an inner graphic state level.");
          this.ResetClip();
        }
        this._clipLevel = this._gfxState.Level;
        break;
      case XCombineMode.Intersect:
        if (this._clipLevel == 0)
        {
          this._clipLevel = this._gfxState.Level;
          break;
        }
        break;
      default:
        Debug.Assert(false, "Invalid XCombineMode in internal function.");
        break;
    }
    this._gfxState.SetAndRealizeClipPath(path);
  }

  public void ResetClip()
  {
    if (this._clipLevel == 0)
      return;
    if (this._clipLevel != this._gfxState.Level)
      throw new NotImplementedException("Cannot reset clip region in an inner graphic state level.");
    this.BeginGraphicMode();
    InternalGraphicsState internalState = this._gfxState.InternalState;
    this.RestoreState();
    this.SaveState();
    this._gfxState.InternalState = internalState;
  }

  public void WriteComment(string comment)
  {
    comment = comment.Replace("\n", "\n% ");
    this.Append($"% {comment}\n");
  }

  private void AppendPartialArc(
    double x,
    double y,
    double width,
    double height,
    double startAngle,
    double sweepAngle,
    PathStart pathStart,
    XMatrix matrix)
  {
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
    int num4 = this.Quadrant(num1, true, clockwise);
    int num5 = this.Quadrant(num3, false, clockwise);
    if (num4 == num5 & flag1)
    {
      this.AppendPartialArcQuadrant(x, y, width, height, num1, num3, pathStart, matrix);
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
            this.AppendPartialArcQuadrant(x, y, width, height, α, num3, PathStart.Ignore1st, matrix);
          }
          else
          {
            double α = (double) (num6 * 90 + (clockwise ? 0 : 90));
            double β = (double) (num6 * 90 + (clockwise ? 90 : 0));
            this.AppendPartialArcQuadrant(x, y, width, height, α, β, PathStart.Ignore1st, matrix);
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
        this.AppendPartialArcQuadrant(x, y, width, height, num1, β1, pathStart, matrix);
        goto label_20;
      }
    }
  }

  private int Quadrant(double φ, bool start, bool clockwise)
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

  private void AppendPartialArcQuadrant(
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
      XPoint xpoint1;
      switch (pathStart)
      {
        case PathStart.MoveTo1st:
          xpoint1 = matrix.Transform(new XPoint(num3 + num1 * num9, num4 + num2 * num8));
          this.AppendFormatPoint("{0:0.###} {1:0.###} m\n", xpoint1.X, xpoint1.Y);
          break;
        case PathStart.LineTo1st:
          xpoint1 = matrix.Transform(new XPoint(num3 + num1 * num9, num4 + num2 * num8));
          this.AppendFormatPoint("{0:0.###} {1:0.###} l\n", xpoint1.X, xpoint1.Y);
          break;
      }
      xpoint1 = matrix.Transform(new XPoint(num3 + num1 * (num9 - num7 * num8), num4 + num2 * (num8 + num7 * num9)));
      XPoint xpoint2 = matrix.Transform(new XPoint(num3 + num1 * (num11 + num7 * num10), num4 + num2 * (num10 - num7 * num11)));
      XPoint xpoint3 = matrix.Transform(new XPoint(num3 + num1 * num11, num4 + num2 * num10));
      this.AppendFormat3Points("{0:0.###} {1:0.###} {2:0.###} {3:0.###} {4:0.###} {5:0.###} c\n", xpoint1.X, xpoint1.Y, xpoint2.X, xpoint2.Y, xpoint3.X, xpoint3.Y);
    }
    else
    {
      XPoint xpoint4;
      switch (pathStart)
      {
        case PathStart.MoveTo1st:
          xpoint4 = matrix.Transform(new XPoint(num3 - num1 * num9, num4 - num2 * num8));
          this.AppendFormatPoint("{0:0.###} {1:0.###} m\n", xpoint4.X, xpoint4.Y);
          break;
        case PathStart.LineTo1st:
          xpoint4 = matrix.Transform(new XPoint(num3 - num1 * num9, num4 - num2 * num8));
          this.AppendFormatPoint("{0:0.###} {1:0.###} l\n", xpoint4.X, xpoint4.Y);
          break;
      }
      xpoint4 = matrix.Transform(new XPoint(num3 - num1 * (num9 - num7 * num8), num4 - num2 * (num8 + num7 * num9)));
      XPoint xpoint5 = matrix.Transform(new XPoint(num3 - num1 * (num11 + num7 * num10), num4 - num2 * (num10 - num7 * num11)));
      XPoint xpoint6 = matrix.Transform(new XPoint(num3 - num1 * num11, num4 - num2 * num10));
      this.AppendFormat3Points("{0:0.###} {1:0.###} {2:0.###} {3:0.###} {4:0.###} {5:0.###} c\n", xpoint4.X, xpoint4.Y, xpoint5.X, xpoint5.Y, xpoint6.X, xpoint6.Y);
    }
  }

  private void AppendCurveSegment(
    XPoint pt0,
    XPoint pt1,
    XPoint pt2,
    XPoint pt3,
    double tension3)
  {
    this.AppendFormat3Points("{0:0.####} {1:0.####} {2:0.####} {3:0.####} {4:0.####} {5:0.####} c\n", pt1.X + tension3 * (pt2.X - pt0.X), pt1.Y + tension3 * (pt2.Y - pt0.Y), pt2.X - tension3 * (pt3.X - pt1.X), pt2.Y - tension3 * (pt3.Y - pt1.Y), pt2.X, pt2.Y);
  }

  internal void AppendPath(CoreGraphicsPath path)
  {
    this.AppendPath(path.PathPoints, path.PathTypes);
  }

  private void AppendPath(XPoint[] points, byte[] types)
  {
    int length = points.Length;
    if (length == 0)
      return;
    for (int index1 = 0; index1 < length; ++index1)
    {
      byte type = types[index1];
      switch ((int) type & 7)
      {
        case 0:
          this.AppendFormatPoint("{0:0.####} {1:0.####} m\n", points[index1].X, points[index1].Y);
          break;
        case 1:
          this.AppendFormatPoint("{0:0.####} {1:0.####} l\n", points[index1].X, points[index1].Y);
          if (((uint) type & 128U /*0x80*/) > 0U)
          {
            this.Append("h\n");
            break;
          }
          break;
        case 3:
          Debug.Assert(index1 + 2 < length);
          int index2;
          this.AppendFormat3Points("{0:0.####} {1:0.####} {2:0.####} {3:0.####} {4:0.####} {5:0.####} c\n", points[index1].X, points[index1].Y, points[index2 = index1 + 1].X, points[index2].Y, points[index1 = index2 + 1].X, points[index1].Y);
          if (((uint) types[index1] & 128U /*0x80*/) > 0U)
          {
            this.Append("h\n");
            break;
          }
          break;
      }
    }
  }

  internal void Append(string value) => this._content.Append(value);

  internal void AppendFormatArgs(string format, params object[] args)
  {
    this._content.AppendFormat((IFormatProvider) CultureInfo.InvariantCulture, format, args);
    string str = this._content.ToString();
    str.Substring(Math.Max(0, str.Length - 100)).GetType();
  }

  internal void AppendFormatString(string format, string s)
  {
    this._content.AppendFormat((IFormatProvider) CultureInfo.InvariantCulture, format, (object) s);
  }

  internal void AppendFormatFont(string format, string s, double d)
  {
    this._content.AppendFormat((IFormatProvider) CultureInfo.InvariantCulture, format, (object) s, (object) d);
  }

  internal void AppendFormatInt(string format, int n)
  {
    this._content.AppendFormat((IFormatProvider) CultureInfo.InvariantCulture, format, (object) n);
  }

  internal void AppendFormatDouble(string format, double d)
  {
    this._content.AppendFormat((IFormatProvider) CultureInfo.InvariantCulture, format, (object) d);
  }

  internal void AppendFormatPoint(string format, double x, double y)
  {
    XPoint view = this.WorldToView(new XPoint(x, y));
    this._content.AppendFormat((IFormatProvider) CultureInfo.InvariantCulture, format, (object) view.X, (object) view.Y);
  }

  internal void AppendFormatRect(string format, double x, double y, double width, double height)
  {
    XPoint view = this.WorldToView(new XPoint(x, y));
    this._content.AppendFormat((IFormatProvider) CultureInfo.InvariantCulture, format, (object) view.X, (object) view.Y, (object) width, (object) height);
  }

  internal void AppendFormat3Points(
    string format,
    double x1,
    double y1,
    double x2,
    double y2,
    double x3,
    double y3)
  {
    XPoint view1 = this.WorldToView(new XPoint(x1, y1));
    XPoint view2 = this.WorldToView(new XPoint(x2, y2));
    XPoint view3 = this.WorldToView(new XPoint(x3, y3));
    this._content.AppendFormat((IFormatProvider) CultureInfo.InvariantCulture, format, (object) view1.X, (object) view1.Y, (object) view2.X, (object) view2.Y, (object) view3.X, (object) view3.Y);
  }

  internal void AppendFormat(string format, XPoint point)
  {
    XPoint view = this.WorldToView(point);
    this._content.AppendFormat((IFormatProvider) CultureInfo.InvariantCulture, format, (object) view.X, (object) view.Y);
  }

  internal void AppendFormat(string format, double x, double y, string s)
  {
    XPoint view = this.WorldToView(new XPoint(x, y));
    this._content.AppendFormat((IFormatProvider) CultureInfo.InvariantCulture, format, (object) view.X, (object) view.Y, (object) s);
  }

  internal void AppendFormatImage(
    string format,
    double x,
    double y,
    double width,
    double height,
    string name)
  {
    XPoint view = this.WorldToView(new XPoint(x, y));
    this._content.AppendFormat((IFormatProvider) CultureInfo.InvariantCulture, format, (object) view.X, (object) view.Y, (object) width, (object) height, (object) name);
  }

  private void AppendStrokeFill(XPen pen, XBrush brush, XFillMode fillMode, bool closePath)
  {
    if (closePath)
      this._content.Append("h ");
    if (fillMode == XFillMode.Winding)
    {
      if ((pen == null ? 0 : (brush != null ? 1 : 0)) != 0)
        this._content.Append("B\n");
      else if (pen != null)
        this._content.Append("S\n");
      else
        this._content.Append("f\n");
    }
    else if ((pen == null ? 0 : (brush != null ? 1 : 0)) != 0)
      this._content.Append("B*\n");
    else if (pen != null)
      this._content.Append("S\n");
    else
      this._content.Append("f*\n");
  }

  private void BeginPage()
  {
    if (this._gfxState.Level != 0)
      return;
    this.DefaultViewMatrix = new XMatrix();
    if (this._gfx.PageDirection == XPageDirection.Downwards)
    {
      this.PageHeightPt = this.Size.Height;
      XPoint xpoint = new XPoint();
      if ((this._page == null ? 0 : (this._page.TrimMargins.AreSet ? 1 : 0)) != 0)
      {
        double pageHeightPt = this.PageHeightPt;
        XUnit xunit = this._page.TrimMargins.Top;
        double point1 = xunit.Point;
        xunit = this._page.TrimMargins.Bottom;
        double point2 = xunit.Point;
        double num = point1 + point2;
        this.PageHeightPt = pageHeightPt + num;
        ref XPoint local = ref xpoint;
        xunit = this._page.TrimMargins.Left;
        double point3 = xunit.Point;
        xunit = this._page.TrimMargins.Top;
        double point4 = xunit.Point;
        local = new XPoint(point3, point4);
      }
      switch (this._gfx.PageUnit)
      {
        case XGraphicsUnit.Inch:
          this.DefaultViewMatrix.ScalePrepend(72.0);
          break;
        case XGraphicsUnit.Millimeter:
          this.DefaultViewMatrix.ScalePrepend(360.0 / (double) sbyte.MaxValue);
          break;
        case XGraphicsUnit.Centimeter:
          this.DefaultViewMatrix.ScalePrepend(3600.0 / (double) sbyte.MaxValue);
          break;
        case XGraphicsUnit.Presentation:
          this.DefaultViewMatrix.ScalePrepend(0.75);
          break;
      }
      if (xpoint != new XPoint())
      {
        Debug.Assert(this._gfx.PageUnit == XGraphicsUnit.Point, "With TrimMargins set the page units must be Point. Ohter cases nyi.");
        this.DefaultViewMatrix.TranslatePrepend(xpoint.X, -xpoint.Y);
      }
      this.SaveState();
      if (this.DefaultViewMatrix.IsIdentity)
        return;
      Debug.Assert(this._gfxState.RealizedCtm.IsIdentity);
      double[] elements = this.DefaultViewMatrix.GetElements();
      this.AppendFormatArgs("{0:0.#######} {1:0.#######} {2:0.#######} {3:0.#######} {4:0.#######} {5:0.#######} cm ", (object) elements[0], (object) elements[1], (object) elements[2], (object) elements[3], (object) elements[4], (object) elements[5]);
    }
    else
    {
      switch (this._gfx.PageUnit)
      {
        case XGraphicsUnit.Inch:
          this.DefaultViewMatrix.ScalePrepend(72.0);
          break;
        case XGraphicsUnit.Millimeter:
          this.DefaultViewMatrix.ScalePrepend(360.0 / (double) sbyte.MaxValue);
          break;
        case XGraphicsUnit.Centimeter:
          this.DefaultViewMatrix.ScalePrepend(3600.0 / (double) sbyte.MaxValue);
          break;
        case XGraphicsUnit.Presentation:
          this.DefaultViewMatrix.ScalePrepend(0.75);
          break;
      }
      this.SaveState();
      double[] elements = this.DefaultViewMatrix.GetElements();
      this.AppendFormat3Points("{0:0.#######} {1:0.#######} {2:0.#######} {3:0.#######} {4:0.#######} {5:0.#######} cm ", elements[0], elements[1], elements[2], elements[3], elements[4], elements[5]);
    }
  }

  private void EndPage()
  {
    if (this._streamMode == StreamMode.Text)
    {
      this._content.Append("ET\n");
      this._streamMode = StreamMode.Graphic;
    }
    while (this._gfxStateStack.Count != 0)
      this.RestoreState();
  }

  internal void BeginGraphicMode()
  {
    if (this._streamMode == 0)
      return;
    if (this._streamMode == StreamMode.Text)
      this._content.Append("ET\n");
    this._streamMode = StreamMode.Graphic;
  }

  internal void BeginTextMode()
  {
    if (this._streamMode == StreamMode.Text)
      return;
    this._streamMode = StreamMode.Text;
    this._content.Append("BT\n");
    this._gfxState.RealizedTextPosition = new XPoint();
    this._gfxState.ItalicSimulationOn = false;
  }

  private void Realize(XPen pen, XBrush brush)
  {
    this.BeginPage();
    this.BeginGraphicMode();
    this.RealizeTransform();
    if (pen != null)
      this._gfxState.RealizePen(pen, this._colorMode);
    if (brush == null)
      return;
    this._gfxState.RealizeBrush(brush, this._colorMode, 0, 0.0);
  }

  private void Realize(XPen pen) => this.Realize(pen, (XBrush) null);

  private void Realize(XBrush brush) => this.Realize((XPen) null, brush);

  private void Realize(XFont font, XBrush brush, int renderingMode)
  {
    this.BeginPage();
    this.RealizeTransform();
    this.BeginTextMode();
    this._gfxState.RealizeFont(font, brush, renderingMode);
  }

  private void AdjustTdOffset(ref XPoint pos, double dy, bool adjustSkew)
  {
    pos.Y += dy;
    XPoint xpoint = pos;
    pos -= new XVector(this._gfxState.RealizedTextPosition.X, this._gfxState.RealizedTextPosition.Y);
    if (adjustSkew)
      pos.X -= 0.34202014332566871 * pos.Y;
    this._gfxState.RealizedTextPosition = xpoint;
  }

  private string Realize(XImage image)
  {
    this.BeginPage();
    this.BeginGraphicMode();
    this.RealizeTransform();
    this._gfxState.RealizeNonStrokeTransparency(1.0, this._colorMode);
    return image is XForm form ? this.GetFormName(form) : this.GetImageName(image);
  }

  private void RealizeTransform()
  {
    this.BeginPage();
    if (this._gfxState.Level == 1)
    {
      this.BeginGraphicMode();
      this.SaveState();
    }
    if (this._gfxState.UnrealizedCtm.IsIdentity)
      return;
    this.BeginGraphicMode();
    this._gfxState.RealizeCtm();
  }

  internal XPoint WorldToView(XPoint point)
  {
    Debug.Assert(this._gfxState.UnrealizedCtm.IsIdentity, "Somewhere a RealizeTransform is missing.");
    XPoint xpoint = this._gfxState.WorldTransform.Transform(point);
    return this._gfxState.InverseEffectiveCtm.Transform(new XPoint(xpoint.X, this.PageHeightPt / this.DefaultViewMatrix.M22 - xpoint.Y));
  }

  [Conditional("DEBUG")]
  private void DumpPathData(XPoint[] points, byte[] types)
  {
    int length = points.Length;
    for (int index = 0; index < length; ++index)
      Debug.WriteLine(PdfEncoders.Format("{0:X}   {1:####0.000} {2:####0.000}", (object) types[index], (object) points[index].X, (object) points[index].Y), "PathData");
  }

  internal PdfDocument Owner => this._page == null ? this._form.Owner : this._page.Owner;

  internal XGraphics Gfx => this._gfx;

  internal PdfResources Resources
  {
    get => this._page == null ? this._form.Resources : this._page.Resources;
  }

  internal XSize Size
  {
    get
    {
      return this._page == null ? this._form.Size : new XSize((double) this._page.Width, (double) this._page.Height);
    }
  }

  internal string GetFontName(XFont font, out PdfFont pdfFont)
  {
    return this._page == null ? this._form.GetFontName(font, out pdfFont) : this._page.GetFontName(font, out pdfFont);
  }

  internal string GetImageName(XImage image)
  {
    return this._page == null ? this._form.GetImageName(image) : this._page.GetImageName(image);
  }

  internal string GetFormName(XForm form)
  {
    return this._page == null ? this._form.GetFormName(form) : this._page.GetFormName(form);
  }

  private void SaveState()
  {
    Debug.Assert(this._streamMode == StreamMode.Graphic, "Cannot save state in text mode.");
    this._gfxStateStack.Push(this._gfxState);
    this._gfxState = this._gfxState.Clone();
    this._gfxState.Level = this._gfxStateStack.Count;
    this.Append("q\n");
  }

  private void RestoreState()
  {
    Debug.Assert(this._streamMode == StreamMode.Graphic, "Cannot restore state in text mode.");
    this._gfxState = this._gfxStateStack.Pop();
    this.Append("Q\n");
  }

  private PdfGraphicsState RestoreState(InternalGraphicsState state)
  {
    int num = 1;
    PdfGraphicsState pdfGraphicsState;
    for (pdfGraphicsState = this._gfxStateStack.Pop(); pdfGraphicsState.InternalState != state; pdfGraphicsState = this._gfxStateStack.Pop())
    {
      this.Append("Q\n");
      ++num;
    }
    this.Append("Q\n");
    this._gfxState = pdfGraphicsState;
    return pdfGraphicsState;
  }
}
