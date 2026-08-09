#define DEBUG
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Text;
using PdfSharp.Fonts.OpenType;
using PdfSharp.Pdf;
using PdfSharp.Pdf.Advanced;
using PdfSharp.Pdf.Internal;

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

	public XGraphicsPdfPageOptions PageOptions => _options;

	public XMatrix Transform
	{
		get
		{
			if (_gfxState.UnrealizedCtm.IsIdentity)
			{
				return _gfxState.EffectiveCtm;
			}
			return _gfxState.UnrealizedCtm * _gfxState.RealizedCtm;
		}
	}

	internal PdfDocument Owner
	{
		get
		{
			if (_page != null)
			{
				return _page.Owner;
			}
			return _form.Owner;
		}
	}

	internal XGraphics Gfx => _gfx;

	internal PdfResources Resources
	{
		get
		{
			if (_page != null)
			{
				return _page.Resources;
			}
			return _form.Resources;
		}
	}

	internal XSize Size
	{
		get
		{
			if (_page != null)
			{
				return new XSize(_page.Width, _page.Height);
			}
			return _form.Size;
		}
	}

	public XGraphicsPdfRenderer(PdfPage page, XGraphics gfx, XGraphicsPdfPageOptions options)
	{
		_page = page;
		_colorMode = page._document.Options.ColorMode;
		_options = options;
		_gfx = gfx;
		_content = new StringBuilder();
		page.RenderContent._pdfRenderer = this;
		_gfxState = new PdfGraphicsState(this);
	}

	public XGraphicsPdfRenderer(XForm form, XGraphics gfx)
	{
		_form = form;
		_colorMode = form.Owner.Options.ColorMode;
		_gfx = gfx;
		_content = new StringBuilder();
		form.PdfRenderer = this;
		_gfxState = new PdfGraphicsState(this);
	}

	private string GetContent()
	{
		EndPage();
		return _content.ToString();
	}

	public void Close()
	{
		if (_page != null)
		{
			PdfContent renderContent = _page.RenderContent;
			renderContent.CreateStream(PdfEncoders.RawEncoding.GetBytes(GetContent()));
			_gfx = null;
			_page.RenderContent._pdfRenderer = null;
			_page.RenderContent = null;
			_page = null;
		}
		else if (_form != null)
		{
			_form._pdfForm.CreateStream(PdfEncoders.RawEncoding.GetBytes(GetContent()));
			_gfx = null;
			_form.PdfRenderer = null;
			_form = null;
		}
	}

	public void DrawLine(XPen pen, double x1, double y1, double x2, double y2)
	{
		DrawLines(pen, new XPoint[2]
		{
			new XPoint(x1, y1),
			new XPoint(x2, y2)
		});
	}

	public void DrawLines(XPen pen, XPoint[] points)
	{
		if (pen == null)
		{
			throw new ArgumentNullException("pen");
		}
		if (points == null)
		{
			throw new ArgumentNullException("points");
		}
		int num = points.Length;
		if (num != 0)
		{
			Realize(pen);
			AppendFormatPoint("{0:0.####} {1:0.####} m\n", points[0].X, points[0].Y);
			for (int i = 1; i < num; i++)
			{
				AppendFormatPoint("{0:0.####} {1:0.####} l\n", points[i].X, points[i].Y);
			}
			_content.Append("S\n");
		}
	}

	public void DrawBezier(XPen pen, double x1, double y1, double x2, double y2, double x3, double y3, double x4, double y4)
	{
		DrawBeziers(pen, new XPoint[4]
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
		{
			throw new ArgumentNullException("pen");
		}
		if (points == null)
		{
			throw new ArgumentNullException("points");
		}
		int num = points.Length;
		if (num != 0)
		{
			if ((num - 1) % 3 != 0)
			{
				throw new ArgumentException("Invalid number of points for bezier curves. Number must fulfil 4+3n.", "points");
			}
			Realize(pen);
			AppendFormatPoint("{0:0.####} {1:0.####} m\n", points[0].X, points[0].Y);
			for (int i = 1; i < num; i += 3)
			{
				AppendFormat3Points("{0:0.####} {1:0.####} {2:0.####} {3:0.####} {4:0.####} {5:0.####} c\n", points[i].X, points[i].Y, points[i + 1].X, points[i + 1].Y, points[i + 2].X, points[i + 2].Y);
			}
			AppendStrokeFill(pen, null, XFillMode.Alternate, closePath: false);
		}
	}

	public void DrawCurve(XPen pen, XPoint[] points, double tension)
	{
		if (pen == null)
		{
			throw new ArgumentNullException("pen");
		}
		if (points == null)
		{
			throw new ArgumentNullException("points");
		}
		int num = points.Length;
		if (num == 0)
		{
			return;
		}
		if (num < 2)
		{
			throw new ArgumentException("Not enough points", "points");
		}
		tension /= 3.0;
		Realize(pen);
		AppendFormatPoint("{0:0.####} {1:0.####} m\n", points[0].X, points[0].Y);
		if (num == 2)
		{
			AppendCurveSegment(points[0], points[0], points[1], points[1], tension);
		}
		else
		{
			AppendCurveSegment(points[0], points[0], points[1], points[2], tension);
			for (int i = 1; i < num - 2; i++)
			{
				AppendCurveSegment(points[i - 1], points[i], points[i + 1], points[i + 2], tension);
			}
			AppendCurveSegment(points[num - 3], points[num - 2], points[num - 1], points[num - 1], tension);
		}
		AppendStrokeFill(pen, null, XFillMode.Alternate, closePath: false);
	}

	public void DrawArc(XPen pen, double x, double y, double width, double height, double startAngle, double sweepAngle)
	{
		if (pen == null)
		{
			throw new ArgumentNullException("pen");
		}
		Realize(pen);
		AppendPartialArc(x, y, width, height, startAngle, sweepAngle, PathStart.MoveTo1st, default(XMatrix));
		AppendStrokeFill(pen, null, XFillMode.Alternate, closePath: false);
	}

	public void DrawRectangle(XPen pen, XBrush brush, double x, double y, double width, double height)
	{
		if (pen == null && brush == null)
		{
			throw new ArgumentNullException("pen and brush");
		}
		Realize(pen, brush);
		AppendFormatRect("{0:0.###} {1:0.###} {2:0.###} {3:0.###} re\n", x, y + height, width, height);
		if (pen != null && brush != null)
		{
			_content.Append("B\n");
		}
		else if (pen != null)
		{
			_content.Append("S\n");
		}
		else
		{
			_content.Append("f\n");
		}
	}

	public void DrawRectangles(XPen pen, XBrush brush, XRect[] rects)
	{
		int num = rects.Length;
		for (int i = 0; i < num; i++)
		{
			XRect xRect = rects[i];
			DrawRectangle(pen, brush, xRect.X, xRect.Y, xRect.Width, xRect.Height);
		}
	}

	public void DrawRoundedRectangle(XPen pen, XBrush brush, double x, double y, double width, double height, double ellipseWidth, double ellipseHeight)
	{
		XGraphicsPath xGraphicsPath = new XGraphicsPath();
		xGraphicsPath.AddRoundedRectangle(x, y, width, height, ellipseWidth, ellipseHeight);
		DrawPath(pen, brush, xGraphicsPath);
	}

	public void DrawEllipse(XPen pen, XBrush brush, double x, double y, double width, double height)
	{
		Realize(pen, brush);
		XRect xRect = new XRect(x, y, width, height);
		double num = xRect.Width / 2.0;
		double num2 = xRect.Height / 2.0;
		double num3 = num * 0.5522847498307935;
		double num4 = num2 * 0.5522847498307935;
		double num5 = xRect.X + num;
		double num6 = xRect.Y + num2;
		AppendFormatPoint("{0:0.####} {1:0.####} m\n", num5 + num, num6);
		AppendFormat3Points("{0:0.####} {1:0.####} {2:0.####} {3:0.####} {4:0.####} {5:0.####} c\n", num5 + num, num6 + num4, num5 + num3, num6 + num2, num5, num6 + num2);
		AppendFormat3Points("{0:0.####} {1:0.####} {2:0.####} {3:0.####} {4:0.####} {5:0.####} c\n", num5 - num3, num6 + num2, num5 - num, num6 + num4, num5 - num, num6);
		AppendFormat3Points("{0:0.####} {1:0.####} {2:0.####} {3:0.####} {4:0.####} {5:0.####} c\n", num5 - num, num6 - num4, num5 - num3, num6 - num2, num5, num6 - num2);
		AppendFormat3Points("{0:0.####} {1:0.####} {2:0.####} {3:0.####} {4:0.####} {5:0.####} c\n", num5 + num3, num6 - num2, num5 + num, num6 - num4, num5 + num, num6);
		AppendStrokeFill(pen, brush, XFillMode.Winding, closePath: true);
	}

	public void DrawPolygon(XPen pen, XBrush brush, XPoint[] points, XFillMode fillmode)
	{
		Realize(pen, brush);
		int num = points.Length;
		if (points.Length < 2)
		{
			throw new ArgumentException(PSSR.PointArrayAtLeast(2), "points");
		}
		AppendFormatPoint("{0:0.####} {1:0.####} m\n", points[0].X, points[0].Y);
		for (int i = 1; i < num; i++)
		{
			AppendFormatPoint("{0:0.####} {1:0.####} l\n", points[i].X, points[i].Y);
		}
		AppendStrokeFill(pen, brush, fillmode, closePath: true);
	}

	public void DrawPie(XPen pen, XBrush brush, double x, double y, double width, double height, double startAngle, double sweepAngle)
	{
		Realize(pen, brush);
		AppendFormatPoint("{0:0.####} {1:0.####} m\n", x + width / 2.0, y + height / 2.0);
		AppendPartialArc(x, y, width, height, startAngle, sweepAngle, PathStart.LineTo1st, default(XMatrix));
		AppendStrokeFill(pen, brush, XFillMode.Alternate, closePath: true);
	}

	public void DrawClosedCurve(XPen pen, XBrush brush, XPoint[] points, double tension, XFillMode fillmode)
	{
		int num = points.Length;
		if (num == 0)
		{
			return;
		}
		if (num < 2)
		{
			throw new ArgumentException("Not enough points.", "points");
		}
		tension /= 3.0;
		Realize(pen, brush);
		AppendFormatPoint("{0:0.####} {1:0.####} m\n", points[0].X, points[0].Y);
		if (num == 2)
		{
			AppendCurveSegment(points[0], points[0], points[1], points[1], tension);
		}
		else
		{
			AppendCurveSegment(points[num - 1], points[0], points[1], points[2], tension);
			for (int i = 1; i < num - 2; i++)
			{
				AppendCurveSegment(points[i - 1], points[i], points[i + 1], points[i + 2], tension);
			}
			AppendCurveSegment(points[num - 3], points[num - 2], points[num - 1], points[0], tension);
			AppendCurveSegment(points[num - 2], points[num - 1], points[0], points[1], tension);
		}
		AppendStrokeFill(pen, brush, fillmode, closePath: true);
	}

	public void DrawPath(XPen pen, XBrush brush, XGraphicsPath path)
	{
		if (pen == null && brush == null)
		{
			throw new ArgumentNullException("pen");
		}
		Realize(pen, brush);
		AppendPath(path._corePath);
		AppendStrokeFill(pen, brush, path.FillMode, closePath: false);
	}

	public void DrawString(string s, XFont font, XBrush brush, XRect rect, XStringFormat format)
	{
		double num = rect.X;
		double num2 = rect.Y;
		double height = font.GetHeight();
		double num3 = height * (double)font.CellAscent / (double)font.CellSpace;
		double num4 = height * (double)font.CellDescent / (double)font.CellSpace;
		double width = _gfx.MeasureString(s, font).Width;
		bool flag = (font.GlyphTypeface.StyleSimulations & XStyleSimulations.ItalicSimulation) != 0;
		bool flag2 = (font.GlyphTypeface.StyleSimulations & XStyleSimulations.BoldSimulation) != 0;
		bool flag3 = (font.Style & XFontStyle.Strikeout) != 0;
		bool flag4 = (font.Style & XFontStyle.Underline) != 0;
		Realize(font, brush, flag2 ? 2 : 0);
		switch (format.Alignment)
		{
		case XStringAlignment.Center:
			num += (rect.Width - width) / 2.0;
			break;
		case XStringAlignment.Far:
			num += rect.Width - width;
			break;
		}
		if (Gfx.PageDirection == XPageDirection.Downwards)
		{
			switch (format.LineAlignment)
			{
			case XLineAlignment.Near:
				num2 += num3;
				break;
			case XLineAlignment.Center:
				num2 += num3 * 3.0 / 4.0 / 2.0 + rect.Height / 2.0;
				break;
			case XLineAlignment.Far:
				num2 += 0.0 - num4 + rect.Height;
				break;
			}
		}
		else
		{
			switch (format.LineAlignment)
			{
			case XLineAlignment.Near:
				num2 += num4;
				break;
			case XLineAlignment.Center:
				num2 += (0.0 - num3 * 3.0 / 4.0) / 2.0 + rect.Height / 2.0;
				break;
			case XLineAlignment.Far:
				num2 += 0.0 - num3 + rect.Height;
				break;
			}
		}
		PdfFont realizedFont = _gfxState._realizedFont;
		Debug.Assert(realizedFont != null);
		realizedFont.AddChars(s);
		OpenTypeDescriptor descriptor = realizedFont.FontDescriptor._descriptor;
		string text = null;
		if (font.Unicode)
		{
			StringBuilder stringBuilder = new StringBuilder();
			bool symbol = descriptor.FontFace.cmap.symbol;
			for (int i = 0; i < s.Length; i++)
			{
				char c = s[i];
				if (symbol)
				{
					c = (char)(c | (descriptor.FontFace.os2.usFirstCharIndex & 0xFF00));
				}
				int num5 = descriptor.CharCodeToGlyphIndex(c);
				stringBuilder.Append((char)num5);
			}
			s = stringBuilder.ToString();
			byte[] bytes = PdfEncoders.RawUnicodeEncoding.GetBytes(s);
			bytes = PdfEncoders.FormatStringLiteral(bytes, unicode: true, prefix: false, hex: true, null);
			text = PdfEncoders.RawEncoding.GetString(bytes, 0, bytes.Length);
		}
		else
		{
			byte[] bytes2 = PdfEncoders.WinAnsiEncoding.GetBytes(s);
			text = PdfEncoders.ToStringLiteral(bytes2, unicode: false, null);
		}
		XPoint point = new XPoint(num, num2);
		point = WorldToView(point);
		double dy = 0.0;
		if (flag2)
		{
		}
		if (flag)
		{
			if (_gfxState.ItalicSimulationOn)
			{
				AdjustTdOffset(ref point, dy, adjustSkew: true);
				AppendFormatArgs("{0:0.####} {1:0.####} Td\n{2} Tj\n", point.X, point.Y, text);
			}
			else
			{
				XMatrix xMatrix = new XMatrix(1.0, 0.0, 0.3420201433256687, 1.0, point.X, point.Y);
				AppendFormatArgs("{0:0.####} {1:0.####} {2:0.####} {3:0.####} {4:0.####} {5:0.####} Tm\n{6} Tj\n", xMatrix.M11, xMatrix.M12, xMatrix.M21, xMatrix.M22, xMatrix.OffsetX, xMatrix.OffsetY, text);
				_gfxState.ItalicSimulationOn = true;
				AdjustTdOffset(ref point, dy, adjustSkew: false);
			}
		}
		else if (_gfxState.ItalicSimulationOn)
		{
			XMatrix xMatrix2 = new XMatrix(1.0, 0.0, 0.0, 1.0, point.X, point.Y);
			AppendFormatArgs("{0:0.####} {1:0.####} {2:0.####} {3:0.####} {4:0.####} {5:0.####} Tm\n{6} Tj\n", xMatrix2.M11, xMatrix2.M12, xMatrix2.M21, xMatrix2.M22, xMatrix2.OffsetX, xMatrix2.OffsetY, text);
			_gfxState.ItalicSimulationOn = false;
			AdjustTdOffset(ref point, dy, adjustSkew: false);
		}
		else
		{
			AdjustTdOffset(ref point, dy, adjustSkew: false);
			AppendFormatArgs("{0:0.####} {1:0.####} Td {2} Tj\n", point.X, point.Y, text);
		}
		if (flag4)
		{
			double num6 = height * (double)realizedFont.FontDescriptor._descriptor.UnderlinePosition / (double)font.CellSpace;
			double num7 = height * (double)realizedFont.FontDescriptor._descriptor.UnderlineThickness / (double)font.CellSpace;
			double y = ((Gfx.PageDirection == XPageDirection.Downwards) ? (num2 - num6) : (num2 + num6 - num7));
			DrawRectangle(null, brush, num, y, width, num7);
		}
		if (flag3)
		{
			double num8 = height * (double)realizedFont.FontDescriptor._descriptor.StrikeoutPosition / (double)font.CellSpace;
			double num9 = height * (double)realizedFont.FontDescriptor._descriptor.StrikeoutSize / (double)font.CellSpace;
			double y2 = ((Gfx.PageDirection == XPageDirection.Downwards) ? (num2 - num8) : (num2 + num8 - num9));
			DrawRectangle(null, brush, num, y2, width, num9);
		}
	}

	public void DrawImage(XImage image, double x, double y, double width, double height)
	{
		string name = Realize(image);
		if (!(image is XForm))
		{
			if (_gfx.PageDirection == XPageDirection.Downwards)
			{
				AppendFormatImage("q {2:0.####} 0 0 {3:0.####} {0:0.####} {1:0.####} cm {4} Do Q\n", x, y + height, width, height, name);
			}
			else
			{
				AppendFormatImage("q {2:0.####} 0 0 {3:0.####} {0:0.####} {1:0.####} cm {4} Do Q\n", x, y, width, height, name);
			}
			return;
		}
		BeginPage();
		XForm xForm = (XForm)image;
		xForm.Finish();
		PdfFormXObject form = Owner.FormTable.GetForm(xForm);
		double num = width / image.PointWidth;
		double num2 = height / image.PointHeight;
		if (num == 0.0 || num2 == 0.0)
		{
			return;
		}
		XPdfForm xPdfForm = image as XPdfForm;
		if (_gfx.PageDirection == XPageDirection.Downwards)
		{
			double num3 = x;
			double num4 = y;
			if (xPdfForm != null)
			{
				num3 -= xPdfForm.Page.MediaBox.X1;
				num4 += xPdfForm.Page.MediaBox.Y1;
			}
			AppendFormatImage("q {2:0.####} 0 0 {3:0.####} {0:0.####} {1:0.####} cm 100 Tz {4} Do Q\n", num3, num4 + height, num, num2, name);
		}
		else
		{
			AppendFormatImage("q {2:0.####} 0 0 {3:0.####} {0:0.####} {1:0.####} cm {4} Do Q\n", x, y, num, num2, name);
		}
	}

	public void DrawImage(XImage image, XRect destRect, XRect srcRect, XGraphicsUnit srcUnit)
	{
		double x = destRect.X;
		double y = destRect.Y;
		double width = destRect.Width;
		double height = destRect.Height;
		string name = Realize(image);
		if (!(image is XForm))
		{
			if (_gfx.PageDirection == XPageDirection.Downwards)
			{
				AppendFormatImage("q {2:0.####} 0 0 {3:0.####} {0:0.####} {1:0.####} cm {4} Do\nQ\n", x, y + height, width, height, name);
			}
			else
			{
				AppendFormatImage("q {2:0.####} 0 0 {3:0.####} {0:0.####} {1:0.####} cm {4} Do Q\n", x, y, width, height, name);
			}
			return;
		}
		BeginPage();
		XForm xForm = (XForm)image;
		xForm.Finish();
		PdfFormXObject form = Owner.FormTable.GetForm(xForm);
		double num = width / image.PointWidth;
		double num2 = height / image.PointHeight;
		if (num == 0.0 || num2 == 0.0)
		{
			return;
		}
		XPdfForm xPdfForm = image as XPdfForm;
		if (_gfx.PageDirection == XPageDirection.Downwards)
		{
			double num3 = x;
			double num4 = y;
			if (xPdfForm != null)
			{
				num3 -= xPdfForm.Page.MediaBox.X1;
				num4 += xPdfForm.Page.MediaBox.Y1;
			}
			AppendFormatImage("q {2:0.####} 0 0 {3:0.####} {0:0.####} {1:0.####} cm {4} Do Q\n", num3, num4 + height, num, num2, name);
		}
		else
		{
			AppendFormatImage("q {2:0.####} 0 0 {3:0.####} {0:0.####} {1:0.####} cm {4} Do Q\n", x, y, num, num2, name);
		}
	}

	public void Save(XGraphicsState state)
	{
		BeginGraphicMode();
		RealizeTransform();
		_gfxState.InternalState = state.InternalState;
		SaveState();
	}

	public void Restore(XGraphicsState state)
	{
		BeginGraphicMode();
		RestoreState(state.InternalState);
	}

	public void BeginContainer(XGraphicsContainer container, XRect dstrect, XRect srcrect, XGraphicsUnit unit)
	{
		BeginGraphicMode();
		RealizeTransform();
		_gfxState.InternalState = container.InternalState;
		SaveState();
	}

	public void EndContainer(XGraphicsContainer container)
	{
		BeginGraphicMode();
		RestoreState(container.InternalState);
	}

	public void AddTransform(XMatrix value, XMatrixOrder matrixOrder)
	{
		_gfxState.AddTransform(value, matrixOrder);
	}

	public void SetClip(XGraphicsPath path, XCombineMode combineMode)
	{
		if (path == null)
		{
			throw new NotImplementedException("SetClip with no path.");
		}
		if (_gfxState.Level < 2)
		{
			RealizeTransform();
		}
		switch (combineMode)
		{
		case XCombineMode.Replace:
			if (_clipLevel != 0)
			{
				if (_clipLevel != _gfxState.Level)
				{
					throw new NotImplementedException("Cannot set new clip region in an inner graphic state level.");
				}
				ResetClip();
			}
			_clipLevel = _gfxState.Level;
			break;
		case XCombineMode.Intersect:
			if (_clipLevel == 0)
			{
				_clipLevel = _gfxState.Level;
			}
			break;
		default:
			Debug.Assert(condition: false, "Invalid XCombineMode in internal function.");
			break;
		}
		_gfxState.SetAndRealizeClipPath(path);
	}

	public void ResetClip()
	{
		if (_clipLevel != 0)
		{
			if (_clipLevel != _gfxState.Level)
			{
				throw new NotImplementedException("Cannot reset clip region in an inner graphic state level.");
			}
			BeginGraphicMode();
			InternalGraphicsState internalState = _gfxState.InternalState;
			XMatrix effectiveCtm = _gfxState.EffectiveCtm;
			RestoreState();
			SaveState();
			_gfxState.InternalState = internalState;
		}
	}

	public void WriteComment(string comment)
	{
		comment = comment.Replace("\n", "\n% ");
		Append("% " + comment + "\n");
	}

	private void AppendPartialArc(double x, double y, double width, double height, double startAngle, double sweepAngle, PathStart pathStart, XMatrix matrix)
	{
		double num = startAngle;
		if (num < 0.0)
		{
			num += (1.0 + Math.Floor(Math.Abs(num) / 360.0)) * 360.0;
		}
		else if (num > 360.0)
		{
			num -= Math.Floor(num / 360.0) * 360.0;
		}
		Debug.Assert(num >= 0.0 && num <= 360.0);
		double num2 = sweepAngle;
		if (num2 < -360.0)
		{
			num2 = -360.0;
		}
		else if (num2 > 360.0)
		{
			num2 = 360.0;
		}
		if (num == 0.0 && num2 < 0.0)
		{
			num = 360.0;
		}
		else if (num == 360.0 && num2 > 0.0)
		{
			num = 0.0;
		}
		bool flag = Math.Abs(num2) <= 90.0;
		num2 = num + num2;
		if (num2 < 0.0)
		{
			num2 += (1.0 + Math.Floor(Math.Abs(num2) / 360.0)) * 360.0;
		}
		bool flag2 = sweepAngle > 0.0;
		int num3 = Quadrant(num, start: true, flag2);
		int num4 = Quadrant(num2, start: false, flag2);
		if (num3 == num4 && flag)
		{
			AppendPartialArcQuadrant(x, y, width, height, num, num2, pathStart, matrix);
			return;
		}
		int num5 = num3;
		bool flag3 = true;
		while (true)
		{
			if (num5 == num3 && flag3)
			{
				double β = num5 * 90 + (flag2 ? 90 : 0);
				AppendPartialArcQuadrant(x, y, width, height, num, β, pathStart, matrix);
			}
			else if (num5 == num4)
			{
				double α = num5 * 90 + ((!flag2) ? 90 : 0);
				AppendPartialArcQuadrant(x, y, width, height, α, num2, PathStart.Ignore1st, matrix);
			}
			else
			{
				double α2 = num5 * 90 + ((!flag2) ? 90 : 0);
				double β2 = num5 * 90 + (flag2 ? 90 : 0);
				AppendPartialArcQuadrant(x, y, width, height, α2, β2, PathStart.Ignore1st, matrix);
			}
			if (num5 == num4 && flag)
			{
				break;
			}
			flag = true;
			num5 = ((!flag2) ? ((num5 == 0) ? 3 : (num5 - 1)) : ((num5 != 3) ? (num5 + 1) : 0));
			flag3 = false;
			bool flag4 = true;
		}
	}

	private int Quadrant(double φ, bool start, bool clockwise)
	{
		Debug.Assert(φ >= 0.0);
		if (φ > 360.0)
		{
			φ -= Math.Floor(φ / 360.0) * 360.0;
		}
		int num = (int)(φ / 90.0);
		if ((double)(num * 90) == φ)
		{
			if ((start && !clockwise) || (!start && clockwise))
			{
				num = ((num == 0) ? 3 : (num - 1));
			}
		}
		else
		{
			num = (clockwise ? ((int)Math.Floor(φ / 90.0) % 4) : ((int)Math.Floor(φ / 90.0)));
		}
		return num;
	}

	private void AppendPartialArcQuadrant(double x, double y, double width, double height, double α, double β, PathStart pathStart, XMatrix matrix)
	{
		Debug.Assert(α >= 0.0 && α <= 360.0);
		Debug.Assert(β >= 0.0);
		if (β > 360.0)
		{
			β -= Math.Floor(β / 360.0) * 360.0;
		}
		Debug.Assert(Math.Abs(α - β) <= 90.0);
		double num = width / 2.0;
		double num2 = height / 2.0;
		double num3 = x + num;
		double num4 = y + num2;
		bool flag = false;
		if (α >= 180.0 && β >= 180.0)
		{
			α -= 180.0;
			β -= 180.0;
			flag = true;
		}
		double num5;
		double num6;
		if (width == height)
		{
			α *= Math.PI / 180.0;
			β *= Math.PI / 180.0;
		}
		else
		{
			α *= Math.PI / 180.0;
			num5 = Math.Sin(α);
			if (Math.Abs(num5) > 1E-10)
			{
				α = Math.PI / 2.0 - Math.Atan(num2 * Math.Cos(α) / (num * num5));
			}
			β *= Math.PI / 180.0;
			num6 = Math.Sin(β);
			if (Math.Abs(num6) > 1E-10)
			{
				β = Math.PI / 2.0 - Math.Atan(num2 * Math.Cos(β) / (num * num6));
			}
		}
		double num7 = 4.0 * (1.0 - Math.Cos((α - β) / 2.0)) / (3.0 * Math.Sin((β - α) / 2.0));
		num5 = Math.Sin(α);
		double num8 = Math.Cos(α);
		num6 = Math.Sin(β);
		double num9 = Math.Cos(β);
		if (!flag)
		{
			XPoint xPoint;
			switch (pathStart)
			{
			case PathStart.MoveTo1st:
				xPoint = matrix.Transform(new XPoint(num3 + num * num8, num4 + num2 * num5));
				AppendFormatPoint("{0:0.###} {1:0.###} m\n", xPoint.X, xPoint.Y);
				break;
			case PathStart.LineTo1st:
				xPoint = matrix.Transform(new XPoint(num3 + num * num8, num4 + num2 * num5));
				AppendFormatPoint("{0:0.###} {1:0.###} l\n", xPoint.X, xPoint.Y);
				break;
			}
			xPoint = matrix.Transform(new XPoint(num3 + num * (num8 - num7 * num5), num4 + num2 * (num5 + num7 * num8)));
			XPoint xPoint2 = matrix.Transform(new XPoint(num3 + num * (num9 + num7 * num6), num4 + num2 * (num6 - num7 * num9)));
			XPoint xPoint3 = matrix.Transform(new XPoint(num3 + num * num9, num4 + num2 * num6));
			AppendFormat3Points("{0:0.###} {1:0.###} {2:0.###} {3:0.###} {4:0.###} {5:0.###} c\n", xPoint.X, xPoint.Y, xPoint2.X, xPoint2.Y, xPoint3.X, xPoint3.Y);
		}
		else
		{
			XPoint xPoint;
			switch (pathStart)
			{
			case PathStart.MoveTo1st:
				xPoint = matrix.Transform(new XPoint(num3 - num * num8, num4 - num2 * num5));
				AppendFormatPoint("{0:0.###} {1:0.###} m\n", xPoint.X, xPoint.Y);
				break;
			case PathStart.LineTo1st:
				xPoint = matrix.Transform(new XPoint(num3 - num * num8, num4 - num2 * num5));
				AppendFormatPoint("{0:0.###} {1:0.###} l\n", xPoint.X, xPoint.Y);
				break;
			}
			xPoint = matrix.Transform(new XPoint(num3 - num * (num8 - num7 * num5), num4 - num2 * (num5 + num7 * num8)));
			XPoint xPoint2 = matrix.Transform(new XPoint(num3 - num * (num9 + num7 * num6), num4 - num2 * (num6 - num7 * num9)));
			XPoint xPoint3 = matrix.Transform(new XPoint(num3 - num * num9, num4 - num2 * num6));
			AppendFormat3Points("{0:0.###} {1:0.###} {2:0.###} {3:0.###} {4:0.###} {5:0.###} c\n", xPoint.X, xPoint.Y, xPoint2.X, xPoint2.Y, xPoint3.X, xPoint3.Y);
		}
	}

	private void AppendCurveSegment(XPoint pt0, XPoint pt1, XPoint pt2, XPoint pt3, double tension3)
	{
		AppendFormat3Points("{0:0.####} {1:0.####} {2:0.####} {3:0.####} {4:0.####} {5:0.####} c\n", pt1.X + tension3 * (pt2.X - pt0.X), pt1.Y + tension3 * (pt2.Y - pt0.Y), pt2.X - tension3 * (pt3.X - pt1.X), pt2.Y - tension3 * (pt3.Y - pt1.Y), pt2.X, pt2.Y);
	}

	internal void AppendPath(CoreGraphicsPath path)
	{
		AppendPath(path.PathPoints, path.PathTypes);
	}

	private void AppendPath(XPoint[] points, byte[] types)
	{
		int num = points.Length;
		if (num == 0)
		{
			return;
		}
		for (int i = 0; i < num; i++)
		{
			byte b = types[i];
			switch (b & 7)
			{
			case 0:
				AppendFormatPoint("{0:0.####} {1:0.####} m\n", points[i].X, points[i].Y);
				break;
			case 1:
				AppendFormatPoint("{0:0.####} {1:0.####} l\n", points[i].X, points[i].Y);
				if ((b & 0x80) != 0)
				{
					Append("h\n");
				}
				break;
			case 3:
				Debug.Assert(i + 2 < num);
				AppendFormat3Points("{0:0.####} {1:0.####} {2:0.####} {3:0.####} {4:0.####} {5:0.####} c\n", points[i].X, points[i].Y, points[++i].X, points[i].Y, points[++i].X, points[i].Y);
				if ((types[i] & 0x80) != 0)
				{
					Append("h\n");
				}
				break;
			}
		}
	}

	internal void Append(string value)
	{
		_content.Append(value);
	}

	internal void AppendFormatArgs(string format, params object[] args)
	{
		_content.AppendFormat(CultureInfo.InvariantCulture, format, args);
		string text = _content.ToString();
		text = text.Substring(Math.Max(0, text.Length - 100));
		text.GetType();
	}

	internal void AppendFormatString(string format, string s)
	{
		_content.AppendFormat(CultureInfo.InvariantCulture, format, s);
	}

	internal void AppendFormatFont(string format, string s, double d)
	{
		_content.AppendFormat(CultureInfo.InvariantCulture, format, s, d);
	}

	internal void AppendFormatInt(string format, int n)
	{
		_content.AppendFormat(CultureInfo.InvariantCulture, format, n);
	}

	internal void AppendFormatDouble(string format, double d)
	{
		_content.AppendFormat(CultureInfo.InvariantCulture, format, d);
	}

	internal void AppendFormatPoint(string format, double x, double y)
	{
		XPoint xPoint = WorldToView(new XPoint(x, y));
		_content.AppendFormat(CultureInfo.InvariantCulture, format, xPoint.X, xPoint.Y);
	}

	internal void AppendFormatRect(string format, double x, double y, double width, double height)
	{
		XPoint xPoint = WorldToView(new XPoint(x, y));
		_content.AppendFormat(CultureInfo.InvariantCulture, format, xPoint.X, xPoint.Y, width, height);
	}

	internal void AppendFormat3Points(string format, double x1, double y1, double x2, double y2, double x3, double y3)
	{
		XPoint xPoint = WorldToView(new XPoint(x1, y1));
		XPoint xPoint2 = WorldToView(new XPoint(x2, y2));
		XPoint xPoint3 = WorldToView(new XPoint(x3, y3));
		_content.AppendFormat(CultureInfo.InvariantCulture, format, xPoint.X, xPoint.Y, xPoint2.X, xPoint2.Y, xPoint3.X, xPoint3.Y);
	}

	internal void AppendFormat(string format, XPoint point)
	{
		XPoint xPoint = WorldToView(point);
		_content.AppendFormat(CultureInfo.InvariantCulture, format, xPoint.X, xPoint.Y);
	}

	internal void AppendFormat(string format, double x, double y, string s)
	{
		XPoint xPoint = WorldToView(new XPoint(x, y));
		_content.AppendFormat(CultureInfo.InvariantCulture, format, xPoint.X, xPoint.Y, s);
	}

	internal void AppendFormatImage(string format, double x, double y, double width, double height, string name)
	{
		XPoint xPoint = WorldToView(new XPoint(x, y));
		_content.AppendFormat(CultureInfo.InvariantCulture, format, xPoint.X, xPoint.Y, width, height, name);
	}

	private void AppendStrokeFill(XPen pen, XBrush brush, XFillMode fillMode, bool closePath)
	{
		if (closePath)
		{
			_content.Append("h ");
		}
		if (fillMode == XFillMode.Winding)
		{
			if (pen != null && brush != null)
			{
				_content.Append("B\n");
			}
			else if (pen != null)
			{
				_content.Append("S\n");
			}
			else
			{
				_content.Append("f\n");
			}
		}
		else if (pen != null && brush != null)
		{
			_content.Append("B*\n");
		}
		else if (pen != null)
		{
			_content.Append("S\n");
		}
		else
		{
			_content.Append("f*\n");
		}
	}

	private void BeginPage()
	{
		if (_gfxState.Level != 0)
		{
			return;
		}
		DefaultViewMatrix = default(XMatrix);
		if (_gfx.PageDirection == XPageDirection.Downwards)
		{
			PageHeightPt = Size.Height;
			XPoint xPoint = default(XPoint);
			if (_page != null && _page.TrimMargins.AreSet)
			{
				PageHeightPt += _page.TrimMargins.Top.Point + _page.TrimMargins.Bottom.Point;
				xPoint = new XPoint(_page.TrimMargins.Left.Point, _page.TrimMargins.Top.Point);
			}
			switch (_gfx.PageUnit)
			{
			case XGraphicsUnit.Presentation:
				DefaultViewMatrix.ScalePrepend(0.75);
				break;
			case XGraphicsUnit.Inch:
				DefaultViewMatrix.ScalePrepend(72.0);
				break;
			case XGraphicsUnit.Millimeter:
				DefaultViewMatrix.ScalePrepend(2.834645669291339);
				break;
			case XGraphicsUnit.Centimeter:
				DefaultViewMatrix.ScalePrepend(28.346456692913385);
				break;
			}
			if (xPoint != default(XPoint))
			{
				Debug.Assert(_gfx.PageUnit == XGraphicsUnit.Point, "With TrimMargins set the page units must be Point. Ohter cases nyi.");
				DefaultViewMatrix.TranslatePrepend(xPoint.X, 0.0 - xPoint.Y);
			}
			SaveState();
			if (!DefaultViewMatrix.IsIdentity)
			{
				Debug.Assert(_gfxState.RealizedCtm.IsIdentity);
				double[] elements = DefaultViewMatrix.GetElements();
				AppendFormatArgs("{0:0.#######} {1:0.#######} {2:0.#######} {3:0.#######} {4:0.#######} {5:0.#######} cm ", elements[0], elements[1], elements[2], elements[3], elements[4], elements[5]);
			}
		}
		else
		{
			switch (_gfx.PageUnit)
			{
			case XGraphicsUnit.Presentation:
				DefaultViewMatrix.ScalePrepend(0.75);
				break;
			case XGraphicsUnit.Inch:
				DefaultViewMatrix.ScalePrepend(72.0);
				break;
			case XGraphicsUnit.Millimeter:
				DefaultViewMatrix.ScalePrepend(2.834645669291339);
				break;
			case XGraphicsUnit.Centimeter:
				DefaultViewMatrix.ScalePrepend(28.346456692913385);
				break;
			}
			SaveState();
			double[] elements2 = DefaultViewMatrix.GetElements();
			AppendFormat3Points("{0:0.#######} {1:0.#######} {2:0.#######} {3:0.#######} {4:0.#######} {5:0.#######} cm ", elements2[0], elements2[1], elements2[2], elements2[3], elements2[4], elements2[5]);
		}
	}

	private void EndPage()
	{
		if (_streamMode == StreamMode.Text)
		{
			_content.Append("ET\n");
			_streamMode = StreamMode.Graphic;
		}
		while (_gfxStateStack.Count != 0)
		{
			RestoreState();
		}
	}

	internal void BeginGraphicMode()
	{
		if (_streamMode != StreamMode.Graphic)
		{
			if (_streamMode == StreamMode.Text)
			{
				_content.Append("ET\n");
			}
			_streamMode = StreamMode.Graphic;
		}
	}

	internal void BeginTextMode()
	{
		if (_streamMode != StreamMode.Text)
		{
			_streamMode = StreamMode.Text;
			_content.Append("BT\n");
			_gfxState.RealizedTextPosition = default(XPoint);
			_gfxState.ItalicSimulationOn = false;
		}
	}

	private void Realize(XPen pen, XBrush brush)
	{
		BeginPage();
		BeginGraphicMode();
		RealizeTransform();
		if (pen != null)
		{
			_gfxState.RealizePen(pen, _colorMode);
		}
		if (brush != null)
		{
			_gfxState.RealizeBrush(brush, _colorMode, 0, 0.0);
		}
	}

	private void Realize(XPen pen)
	{
		Realize(pen, null);
	}

	private void Realize(XBrush brush)
	{
		Realize(null, brush);
	}

	private void Realize(XFont font, XBrush brush, int renderingMode)
	{
		BeginPage();
		RealizeTransform();
		BeginTextMode();
		_gfxState.RealizeFont(font, brush, renderingMode);
	}

	private void AdjustTdOffset(ref XPoint pos, double dy, bool adjustSkew)
	{
		pos.Y += dy;
		XPoint realizedTextPosition = pos;
		pos -= new XVector(_gfxState.RealizedTextPosition.X, _gfxState.RealizedTextPosition.Y);
		if (adjustSkew)
		{
			pos.X -= 0.3420201433256687 * pos.Y;
		}
		_gfxState.RealizedTextPosition = realizedTextPosition;
	}

	private string Realize(XImage image)
	{
		BeginPage();
		BeginGraphicMode();
		RealizeTransform();
		_gfxState.RealizeNonStrokeTransparency(1.0, _colorMode);
		return (image is XForm form) ? GetFormName(form) : GetImageName(image);
	}

	private void RealizeTransform()
	{
		BeginPage();
		if (_gfxState.Level == 1)
		{
			BeginGraphicMode();
			SaveState();
		}
		if (!_gfxState.UnrealizedCtm.IsIdentity)
		{
			BeginGraphicMode();
			_gfxState.RealizeCtm();
		}
	}

	internal XPoint WorldToView(XPoint point)
	{
		Debug.Assert(_gfxState.UnrealizedCtm.IsIdentity, "Somewhere a RealizeTransform is missing.");
		XPoint xPoint = _gfxState.WorldTransform.Transform(point);
		return _gfxState.InverseEffectiveCtm.Transform(new XPoint(xPoint.X, PageHeightPt / DefaultViewMatrix.M22 - xPoint.Y));
	}

	[Conditional("DEBUG")]
	private void DumpPathData(XPoint[] points, byte[] types)
	{
		int num = points.Length;
		for (int i = 0; i < num; i++)
		{
			string message = PdfEncoders.Format("{0:X}   {1:####0.000} {2:####0.000}", types[i], points[i].X, points[i].Y);
			Debug.WriteLine(message, "PathData");
		}
	}

	internal string GetFontName(XFont font, out PdfFont pdfFont)
	{
		if (_page != null)
		{
			return _page.GetFontName(font, out pdfFont);
		}
		return _form.GetFontName(font, out pdfFont);
	}

	internal string GetImageName(XImage image)
	{
		if (_page != null)
		{
			return _page.GetImageName(image);
		}
		return _form.GetImageName(image);
	}

	internal string GetFormName(XForm form)
	{
		if (_page != null)
		{
			return _page.GetFormName(form);
		}
		return _form.GetFormName(form);
	}

	private void SaveState()
	{
		Debug.Assert(_streamMode == StreamMode.Graphic, "Cannot save state in text mode.");
		_gfxStateStack.Push(_gfxState);
		_gfxState = _gfxState.Clone();
		_gfxState.Level = _gfxStateStack.Count;
		Append("q\n");
	}

	private void RestoreState()
	{
		Debug.Assert(_streamMode == StreamMode.Graphic, "Cannot restore state in text mode.");
		_gfxState = _gfxStateStack.Pop();
		Append("Q\n");
	}

	private PdfGraphicsState RestoreState(InternalGraphicsState state)
	{
		int num = 1;
		PdfGraphicsState pdfGraphicsState = _gfxStateStack.Pop();
		while (pdfGraphicsState.InternalState != state)
		{
			Append("Q\n");
			num++;
			pdfGraphicsState = _gfxStateStack.Pop();
		}
		Append("Q\n");
		_gfxState = pdfGraphicsState;
		return pdfGraphicsState;
	}
}
