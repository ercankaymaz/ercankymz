// Decompiled with JetBrains decompiler
// Type: PdfSharp.Drawing.Pdf.PdfGraphicsState
// Assembly: buFile, Version=1.50.4740.0, Culture=neutral, PublicKeyToken=f94615aa0424f9eb
// MVID: 1F93257A-1245-4898-8C4E-DC1AB39EF50B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buFile.dll

using PdfSharp.Internal;
using PdfSharp.Pdf;
using PdfSharp.Pdf.Advanced;
using PdfSharp.Pdf.Internal;
using System;
using System.Diagnostics;
using System.Globalization;
using System.Text;

#nullable disable
namespace PdfSharp.Drawing.Pdf;

internal sealed class PdfGraphicsState : ICloneable
{
  private readonly XGraphicsPdfRenderer _renderer;
  internal int Level;
  internal InternalGraphicsState InternalState;
  private double _realizedLineWith = -1.0;
  private int _realizedLineCap = -1;
  private int _realizedLineJoin = -1;
  private double _realizedMiterLimit = -1.0;
  private XDashStyle _realizedDashStyle = ~XDashStyle.Solid;
  private string _realizedDashPattern;
  private XColor _realizedStrokeColor = XColor.Empty;
  private bool _realizedStrokeOverPrint;
  private XColor _realizedFillColor = XColor.Empty;
  private bool _realizedNonStrokeOverPrint;
  internal PdfFont _realizedFont;
  private string _realizedFontName = string.Empty;
  private double _realizedFontSize;
  private int _realizedRenderingMode;
  private double _realizedCharSpace;
  public XPoint RealizedTextPosition;
  public bool ItalicSimulationOn;
  public XMatrix RealizedCtm;
  public XMatrix UnrealizedCtm;
  public XMatrix EffectiveCtm;
  public XMatrix InverseEffectiveCtm;
  public XMatrix WorldTransform;

  public PdfGraphicsState(XGraphicsPdfRenderer renderer) => this._renderer = renderer;

  public PdfGraphicsState Clone() => (PdfGraphicsState) this.MemberwiseClone();

  object ICloneable.Clone() => (object) this.Clone();

  public void PushState() => this._renderer.Append("q/n");

  public void PopState() => this._renderer.Append("Q/n");

  public void RealizePen(XPen pen, PdfColorMode colorMode)
  {
    XColor color = pen.Color;
    bool overprint = pen.Overprint;
    XColor xcolor = ColorSpaceHelper.EnsureColorMode(colorMode, color);
    if (this._realizedLineWith != pen._width)
    {
      this._renderer.AppendFormatArgs("{0:0.###} w\n", (object) pen._width);
      this._realizedLineWith = pen._width;
    }
    if ((XLineCap) this._realizedLineCap != pen._lineCap)
    {
      this._renderer.AppendFormatArgs("{0} J\n", (object) (int) pen._lineCap);
      this._realizedLineCap = (int) pen._lineCap;
    }
    if ((XLineJoin) this._realizedLineJoin != pen._lineJoin)
    {
      this._renderer.AppendFormatArgs("{0} j\n", (object) (int) pen._lineJoin);
      this._realizedLineJoin = (int) pen._lineJoin;
    }
    if (this._realizedLineCap == 0 && (this._realizedMiterLimit == (double) (int) pen._miterLimit ? 0 : ((int) pen._miterLimit != 0 ? 1 : 0)) != 0)
    {
      this._renderer.AppendFormatInt("{0} M\n", (int) pen._miterLimit);
      this._realizedMiterLimit = (double) (int) pen._miterLimit;
    }
    if ((this._realizedDashStyle != pen._dashStyle ? 1 : (pen._dashStyle == XDashStyle.Custom ? 1 : 0)) != 0)
    {
      double width = pen.Width;
      double num = 3.0 * width;
      XDashStyle xdashStyle = pen.DashStyle;
      if (width == 0.0)
      {
        xdashStyle = XDashStyle.Solid;
      }
      else
      {
        switch (xdashStyle)
        {
          case XDashStyle.Solid:
            break;
          case XDashStyle.Dash:
            this._renderer.AppendFormatArgs("[{0:0.##} {1:0.##}]0 d\n", (object) num, (object) width);
            goto label_25;
          case XDashStyle.Dot:
            this._renderer.AppendFormatArgs("[{0:0.##}]0 d\n", (object) width);
            goto label_25;
          case XDashStyle.DashDot:
            this._renderer.AppendFormatArgs("[{0:0.##} {1:0.##} {1:0.##} {1:0.##}]0 d\n", (object) num, (object) width);
            goto label_25;
          case XDashStyle.DashDotDot:
            this._renderer.AppendFormatArgs("[{0:0.##} {1:0.##} {1:0.##} {1:0.##} {1:0.##} {1:0.##}]0 d\n", (object) num, (object) width);
            goto label_25;
          case XDashStyle.Custom:
            StringBuilder stringBuilder = new StringBuilder("[", 256 /*0x0100*/);
            int length = pen._dashPattern == null ? 0 : pen._dashPattern.Length;
            for (int index = 0; index < length; ++index)
            {
              if (index > 0)
                stringBuilder.Append(' ');
              stringBuilder.Append(PdfEncoders.ToString(pen._dashPattern[index] * pen._width));
            }
            if ((length <= 0 ? 0 : (length % 2 == 1 ? 1 : 0)) != 0)
            {
              stringBuilder.Append(' ');
              stringBuilder.Append(PdfEncoders.ToString(0.2 * pen._width));
            }
            stringBuilder.AppendFormat((IFormatProvider) CultureInfo.InvariantCulture, "]{0:0.###} d\n", (object) (pen._dashOffset * pen._width));
            string str = stringBuilder.ToString();
            this._realizedDashPattern = str;
            this._renderer.Append(str);
            goto label_25;
          default:
            goto label_25;
        }
      }
      this._renderer.Append("[]0 d\n");
label_25:
      this._realizedDashStyle = xdashStyle;
    }
    if (colorMode != PdfColorMode.Cmyk)
    {
      if ((int) this._realizedStrokeColor.Rgb != (int) xcolor.Rgb)
      {
        this._renderer.Append(PdfEncoders.ToString(xcolor, PdfColorMode.Rgb));
        this._renderer.Append(" RG\n");
      }
    }
    else if (!ColorSpaceHelper.IsEqualCmyk(this._realizedStrokeColor, xcolor))
    {
      this._renderer.Append(PdfEncoders.ToString(xcolor, PdfColorMode.Cmyk));
      this._renderer.Append(" K\n");
    }
    if ((this._renderer.Owner.Version < 14 ? 0 : (this._realizedStrokeColor.A != xcolor.A ? 1 : (this._realizedStrokeOverPrint != overprint ? 1 : 0))) != 0)
    {
      this._renderer.AppendFormatString("{0} gs\n", this._renderer.Resources.AddExtGState(this._renderer.Owner.ExtGStateTable.GetExtGStateStroke(xcolor.A, overprint)));
      if ((this._renderer._page == null ? 0 : (xcolor.A < 1.0 ? 1 : 0)) != 0)
        this._renderer._page.TransparencyUsed = true;
    }
    this._realizedStrokeColor = xcolor;
    this._realizedStrokeOverPrint = overprint;
  }

  public void RealizeBrush(
    XBrush brush,
    PdfColorMode colorMode,
    int renderingMode,
    double fontEmSize)
  {
    if (brush is XSolidBrush xsolidBrush)
    {
      XColor color = xsolidBrush.Color;
      bool overprint = xsolidBrush.Overprint;
      if (renderingMode == 0)
      {
        this.RealizeFillColor(color, overprint, colorMode);
      }
      else
      {
        if (renderingMode != 2)
          throw new InvalidOperationException("Only rendering modes 0 and 2 are currently supported.");
        this.RealizeFillColor(color, false, colorMode);
        this.RealizePen(new XPen(color, fontEmSize * 0.02), colorMode);
      }
    }
    else
    {
      if (renderingMode != 0)
        throw new InvalidOperationException("Rendering modes other than 0 can only be used with solid color brushes.");
      if (!(brush is XLinearGradientBrush brush1))
        return;
      Debug.Assert(this.UnrealizedCtm.IsIdentity, "Must realize ctm first.");
      XMatrix defaultViewMatrix = this._renderer.DefaultViewMatrix;
      defaultViewMatrix.Prepend(this.EffectiveCtm);
      PdfShadingPattern pattern = new PdfShadingPattern(this._renderer.Owner);
      pattern.SetupFromBrush(brush1, defaultViewMatrix, this._renderer);
      string s = this._renderer.Resources.AddPattern(pattern);
      this._renderer.AppendFormatString("/Pattern cs\n", s);
      this._renderer.AppendFormatString("{0} scn\n", s);
      this._realizedFillColor = XColor.Empty;
    }
  }

  private void RealizeFillColor(XColor color, bool overPrint, PdfColorMode colorMode)
  {
    color = ColorSpaceHelper.EnsureColorMode(colorMode, color);
    if (colorMode != PdfColorMode.Cmyk)
    {
      if ((this._realizedFillColor.IsEmpty ? 1 : ((int) this._realizedFillColor.Rgb != (int) color.Rgb ? 1 : 0)) != 0)
      {
        this._renderer.Append(PdfEncoders.ToString(color, PdfColorMode.Rgb));
        this._renderer.Append(" rg\n");
      }
    }
    else
    {
      Debug.Assert(colorMode == PdfColorMode.Cmyk);
      if ((this._realizedFillColor.IsEmpty ? 1 : (!ColorSpaceHelper.IsEqualCmyk(this._realizedFillColor, color) ? 1 : 0)) != 0)
      {
        this._renderer.Append(PdfEncoders.ToString(color, PdfColorMode.Cmyk));
        this._renderer.Append(" k\n");
      }
    }
    if ((this._renderer.Owner.Version < 14 ? 0 : (this._realizedFillColor.A != color.A ? 1 : (this._realizedNonStrokeOverPrint != overPrint ? 1 : 0))) != 0)
    {
      this._renderer.AppendFormatString("{0} gs\n", this._renderer.Resources.AddExtGState(this._renderer.Owner.ExtGStateTable.GetExtGStateNonStroke(color.A, overPrint)));
      if ((this._renderer._page == null ? 0 : (color.A < 1.0 ? 1 : 0)) != 0)
        this._renderer._page.TransparencyUsed = true;
    }
    this._realizedFillColor = color;
    this._realizedNonStrokeOverPrint = overPrint;
  }

  internal void RealizeNonStrokeTransparency(double transparency, PdfColorMode colorMode)
  {
    this.RealizeFillColor(this._realizedFillColor with
    {
      A = transparency
    }, this._realizedNonStrokeOverPrint, colorMode);
  }

  public void RealizeFont(XFont font, XBrush brush, int renderingMode)
  {
    this.RealizeBrush(brush, this._renderer._colorMode, renderingMode, font.Size);
    if (this._realizedRenderingMode != renderingMode)
    {
      this._renderer.AppendFormatInt("{0} Tr\n", renderingMode);
      this._realizedRenderingMode = renderingMode;
    }
    if (this._realizedRenderingMode == 0)
    {
      if (this._realizedCharSpace != 0.0)
      {
        this._renderer.Append("0 Tc\n");
        this._realizedCharSpace = 0.0;
      }
    }
    else
    {
      double d = font.Size * 0.02;
      if (this._realizedCharSpace != d)
      {
        this._renderer.AppendFormatDouble("{0:0.###} Tc\n", d);
        this._realizedCharSpace = d;
      }
    }
    this._realizedFont = (PdfFont) null;
    string fontName = this._renderer.GetFontName(font, out this._realizedFont);
    if ((fontName != this._realizedFontName ? 1 : (this._realizedFontSize != font.Size ? 1 : 0)) == 0)
      return;
    if (this._renderer.Gfx.PageDirection == XPageDirection.Downwards)
      this._renderer.AppendFormatFont("{0} {1:0.###} Tf\n", fontName, font.Size);
    else
      this._renderer.AppendFormatFont("{0} {1:0.###} Tf\n", fontName, font.Size);
    this._realizedFontName = fontName;
    this._realizedFontSize = font.Size;
  }

  public void AddTransform(XMatrix value, XMatrixOrder matrixOrder)
  {
    if (matrixOrder == XMatrixOrder.Append)
      throw new NotImplementedException("XMatrixOrder.Append");
    XMatrix matrix = value;
    if (this._renderer.Gfx.PageDirection == XPageDirection.Downwards)
    {
      matrix.M12 = -value.M12;
      matrix.M21 = -value.M21;
    }
    this.UnrealizedCtm.Prepend(matrix);
    this.WorldTransform.Prepend(value);
  }

  public void RealizeCtm()
  {
    if (this.UnrealizedCtm.IsIdentity)
      return;
    Debug.Assert(!this.UnrealizedCtm.IsIdentity, "mrCtm is unnecessarily set.");
    double[] elements = this.UnrealizedCtm.GetElements();
    this._renderer.AppendFormatArgs("{0:0.#######} {1:0.#######} {2:0.#######} {3:0.#######} {4:0.#######} {5:0.#######} cm\n", (object) elements[0], (object) elements[1], (object) elements[2], (object) elements[3], (object) elements[4], (object) elements[5]);
    this.RealizedCtm.Prepend(this.UnrealizedCtm);
    this.UnrealizedCtm = new XMatrix();
    this.EffectiveCtm = this.RealizedCtm;
    this.InverseEffectiveCtm = this.EffectiveCtm;
    this.InverseEffectiveCtm.Invert();
  }

  public void SetAndRealizeClipRect(XRect clipRect)
  {
    XGraphicsPath clipPath = new XGraphicsPath();
    clipPath.AddRectangle(clipRect);
    this.RealizeClipPath(clipPath);
  }

  public void SetAndRealizeClipPath(XGraphicsPath clipPath) => this.RealizeClipPath(clipPath);

  private void RealizeClipPath(XGraphicsPath clipPath)
  {
    DiagnosticsHelper.HandleNotImplemented(nameof (RealizeClipPath));
    this._renderer.BeginGraphicMode();
    this.RealizeCtm();
    this._renderer.AppendPath(clipPath._corePath);
    this._renderer.Append(clipPath.FillMode == XFillMode.Winding ? "W n\n" : "W* n\n");
  }
}
