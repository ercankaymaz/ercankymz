#define DEBUG
using System;
using System.Diagnostics;
using System.Globalization;
using System.Text;
using PdfSharp.Internal;
using PdfSharp.Pdf;
using PdfSharp.Pdf.Advanced;
using PdfSharp.Pdf.Internal;

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

	private XDashStyle _realizedDashStyle = (XDashStyle)(-1);

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

	public PdfGraphicsState(XGraphicsPdfRenderer renderer)
	{
		_renderer = renderer;
	}

	public PdfGraphicsState Clone()
	{
		return (PdfGraphicsState)MemberwiseClone();
	}

	object ICloneable.Clone()
	{
		return Clone();
	}

	public void PushState()
	{
		_renderer.Append("q/n");
	}

	public void PopState()
	{
		_renderer.Append("Q/n");
	}

	public void RealizePen(XPen pen, PdfColorMode colorMode)
	{
		XColor color = pen.Color;
		bool overprint = pen.Overprint;
		color = ColorSpaceHelper.EnsureColorMode(colorMode, color);
		if (_realizedLineWith != pen._width)
		{
			_renderer.AppendFormatArgs("{0:0.###} w\n", pen._width);
			_realizedLineWith = pen._width;
		}
		if (_realizedLineCap != (int)pen._lineCap)
		{
			_renderer.AppendFormatArgs("{0} J\n", (int)pen._lineCap);
			_realizedLineCap = (int)pen._lineCap;
		}
		if (_realizedLineJoin != (int)pen._lineJoin)
		{
			_renderer.AppendFormatArgs("{0} j\n", (int)pen._lineJoin);
			_realizedLineJoin = (int)pen._lineJoin;
		}
		if (_realizedLineCap == 0 && _realizedMiterLimit != (double)(int)pen._miterLimit && (int)pen._miterLimit != 0)
		{
			_renderer.AppendFormatInt("{0} M\n", (int)pen._miterLimit);
			_realizedMiterLimit = (int)pen._miterLimit;
		}
		if (_realizedDashStyle != pen._dashStyle || pen._dashStyle == XDashStyle.Custom)
		{
			double width = pen.Width;
			double num = 3.0 * width;
			XDashStyle xDashStyle = pen.DashStyle;
			if (width == 0.0)
			{
				xDashStyle = XDashStyle.Solid;
			}
			switch (xDashStyle)
			{
			case XDashStyle.Solid:
				_renderer.Append("[]0 d\n");
				break;
			case XDashStyle.Dash:
				_renderer.AppendFormatArgs("[{0:0.##} {1:0.##}]0 d\n", num, width);
				break;
			case XDashStyle.Dot:
				_renderer.AppendFormatArgs("[{0:0.##}]0 d\n", width);
				break;
			case XDashStyle.DashDot:
				_renderer.AppendFormatArgs("[{0:0.##} {1:0.##} {1:0.##} {1:0.##}]0 d\n", num, width);
				break;
			case XDashStyle.DashDotDot:
				_renderer.AppendFormatArgs("[{0:0.##} {1:0.##} {1:0.##} {1:0.##} {1:0.##} {1:0.##}]0 d\n", num, width);
				break;
			case XDashStyle.Custom:
			{
				StringBuilder stringBuilder = new StringBuilder("[", 256);
				int num2 = ((pen._dashPattern != null) ? pen._dashPattern.Length : 0);
				for (int i = 0; i < num2; i++)
				{
					if (i > 0)
					{
						stringBuilder.Append(' ');
					}
					stringBuilder.Append(PdfEncoders.ToString(pen._dashPattern[i] * pen._width));
				}
				if (num2 > 0 && num2 % 2 == 1)
				{
					stringBuilder.Append(' ');
					stringBuilder.Append(PdfEncoders.ToString(0.2 * pen._width));
				}
				stringBuilder.AppendFormat(CultureInfo.InvariantCulture, "]{0:0.###} d\n", pen._dashOffset * pen._width);
				string value = (_realizedDashPattern = stringBuilder.ToString());
				_renderer.Append(value);
				break;
			}
			}
			_realizedDashStyle = xDashStyle;
		}
		if (colorMode != PdfColorMode.Cmyk)
		{
			if (_realizedStrokeColor.Rgb != color.Rgb)
			{
				_renderer.Append(PdfEncoders.ToString(color, PdfColorMode.Rgb));
				_renderer.Append(" RG\n");
			}
		}
		else if (!ColorSpaceHelper.IsEqualCmyk(_realizedStrokeColor, color))
		{
			_renderer.Append(PdfEncoders.ToString(color, PdfColorMode.Cmyk));
			_renderer.Append(" K\n");
		}
		if (_renderer.Owner.Version >= 14 && (_realizedStrokeColor.A != color.A || _realizedStrokeOverPrint != overprint))
		{
			PdfExtGState extGStateStroke = _renderer.Owner.ExtGStateTable.GetExtGStateStroke(color.A, overprint);
			string s = _renderer.Resources.AddExtGState(extGStateStroke);
			_renderer.AppendFormatString("{0} gs\n", s);
			if (_renderer._page != null && color.A < 1.0)
			{
				_renderer._page.TransparencyUsed = true;
			}
		}
		_realizedStrokeColor = color;
		_realizedStrokeOverPrint = overprint;
	}

	public void RealizeBrush(XBrush brush, PdfColorMode colorMode, int renderingMode, double fontEmSize)
	{
		if (brush is XSolidBrush { Color: var color, Overprint: var overprint })
		{
			switch (renderingMode)
			{
			case 0:
				RealizeFillColor(color, overprint, colorMode);
				break;
			case 2:
				RealizeFillColor(color, overPrint: false, colorMode);
				RealizePen(new XPen(color, fontEmSize * 0.02), colorMode);
				break;
			default:
				throw new InvalidOperationException("Only rendering modes 0 and 2 are currently supported.");
			}
			return;
		}
		if (renderingMode != 0)
		{
			throw new InvalidOperationException("Rendering modes other than 0 can only be used with solid color brushes.");
		}
		if (brush is XLinearGradientBrush brush2)
		{
			Debug.Assert(UnrealizedCtm.IsIdentity, "Must realize ctm first.");
			XMatrix defaultViewMatrix = _renderer.DefaultViewMatrix;
			defaultViewMatrix.Prepend(EffectiveCtm);
			PdfShadingPattern pdfShadingPattern = new PdfShadingPattern(_renderer.Owner);
			pdfShadingPattern.SetupFromBrush(brush2, defaultViewMatrix, _renderer);
			string s = _renderer.Resources.AddPattern(pdfShadingPattern);
			_renderer.AppendFormatString("/Pattern cs\n", s);
			_renderer.AppendFormatString("{0} scn\n", s);
			_realizedFillColor = XColor.Empty;
		}
	}

	private void RealizeFillColor(XColor color, bool overPrint, PdfColorMode colorMode)
	{
		color = ColorSpaceHelper.EnsureColorMode(colorMode, color);
		if (colorMode != PdfColorMode.Cmyk)
		{
			if (_realizedFillColor.IsEmpty || _realizedFillColor.Rgb != color.Rgb)
			{
				_renderer.Append(PdfEncoders.ToString(color, PdfColorMode.Rgb));
				_renderer.Append(" rg\n");
			}
		}
		else
		{
			Debug.Assert(colorMode == PdfColorMode.Cmyk);
			if (_realizedFillColor.IsEmpty || !ColorSpaceHelper.IsEqualCmyk(_realizedFillColor, color))
			{
				_renderer.Append(PdfEncoders.ToString(color, PdfColorMode.Cmyk));
				_renderer.Append(" k\n");
			}
		}
		if (_renderer.Owner.Version >= 14 && (_realizedFillColor.A != color.A || _realizedNonStrokeOverPrint != overPrint))
		{
			PdfExtGState extGStateNonStroke = _renderer.Owner.ExtGStateTable.GetExtGStateNonStroke(color.A, overPrint);
			string s = _renderer.Resources.AddExtGState(extGStateNonStroke);
			_renderer.AppendFormatString("{0} gs\n", s);
			if (_renderer._page != null && color.A < 1.0)
			{
				_renderer._page.TransparencyUsed = true;
			}
		}
		_realizedFillColor = color;
		_realizedNonStrokeOverPrint = overPrint;
	}

	internal void RealizeNonStrokeTransparency(double transparency, PdfColorMode colorMode)
	{
		XColor realizedFillColor = _realizedFillColor;
		realizedFillColor.A = transparency;
		RealizeFillColor(realizedFillColor, _realizedNonStrokeOverPrint, colorMode);
	}

	public void RealizeFont(XFont font, XBrush brush, int renderingMode)
	{
		RealizeBrush(brush, _renderer._colorMode, renderingMode, font.Size);
		if (_realizedRenderingMode != renderingMode)
		{
			_renderer.AppendFormatInt("{0} Tr\n", renderingMode);
			_realizedRenderingMode = renderingMode;
		}
		if (_realizedRenderingMode == 0)
		{
			if (_realizedCharSpace != 0.0)
			{
				_renderer.Append("0 Tc\n");
				_realizedCharSpace = 0.0;
			}
		}
		else
		{
			double num = font.Size * 0.02;
			if (_realizedCharSpace != num)
			{
				_renderer.AppendFormatDouble("{0:0.###} Tc\n", num);
				_realizedCharSpace = num;
			}
		}
		_realizedFont = null;
		string fontName = _renderer.GetFontName(font, out _realizedFont);
		if (fontName != _realizedFontName || _realizedFontSize != font.Size)
		{
			if (_renderer.Gfx.PageDirection == XPageDirection.Downwards)
			{
				_renderer.AppendFormatFont("{0} {1:0.###} Tf\n", fontName, font.Size);
			}
			else
			{
				_renderer.AppendFormatFont("{0} {1:0.###} Tf\n", fontName, font.Size);
			}
			_realizedFontName = fontName;
			_realizedFontSize = font.Size;
		}
	}

	public void AddTransform(XMatrix value, XMatrixOrder matrixOrder)
	{
		if (matrixOrder == XMatrixOrder.Append)
		{
			throw new NotImplementedException("XMatrixOrder.Append");
		}
		XMatrix matrix = value;
		if (_renderer.Gfx.PageDirection == XPageDirection.Downwards)
		{
			matrix.M12 = 0.0 - value.M12;
			matrix.M21 = 0.0 - value.M21;
		}
		UnrealizedCtm.Prepend(matrix);
		WorldTransform.Prepend(value);
	}

	public void RealizeCtm()
	{
		if (!UnrealizedCtm.IsIdentity)
		{
			Debug.Assert(!UnrealizedCtm.IsIdentity, "mrCtm is unnecessarily set.");
			double[] elements = UnrealizedCtm.GetElements();
			_renderer.AppendFormatArgs("{0:0.#######} {1:0.#######} {2:0.#######} {3:0.#######} {4:0.#######} {5:0.#######} cm\n", elements[0], elements[1], elements[2], elements[3], elements[4], elements[5]);
			RealizedCtm.Prepend(UnrealizedCtm);
			UnrealizedCtm = default(XMatrix);
			EffectiveCtm = RealizedCtm;
			InverseEffectiveCtm = EffectiveCtm;
			InverseEffectiveCtm.Invert();
		}
	}

	public void SetAndRealizeClipRect(XRect clipRect)
	{
		XGraphicsPath xGraphicsPath = new XGraphicsPath();
		xGraphicsPath.AddRectangle(clipRect);
		RealizeClipPath(xGraphicsPath);
	}

	public void SetAndRealizeClipPath(XGraphicsPath clipPath)
	{
		RealizeClipPath(clipPath);
	}

	private void RealizeClipPath(XGraphicsPath clipPath)
	{
		DiagnosticsHelper.HandleNotImplemented("RealizeClipPath");
		_renderer.BeginGraphicMode();
		RealizeCtm();
		_renderer.AppendPath(clipPath._corePath);
		_renderer.Append((clipPath.FillMode == XFillMode.Winding) ? "W n\n" : "W* n\n");
	}
}
