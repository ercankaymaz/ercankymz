using System;
using PdfSharp.Internal;

namespace PdfSharp.Drawing;

public sealed class XGraphicsPath
{
	private XFillMode _fillMode;

	internal CoreGraphicsPath _corePath;

	public XFillMode FillMode
	{
		get
		{
			return _fillMode;
		}
		set
		{
			_fillMode = value;
		}
	}

	public XGraphicsPathInternals Internals => new XGraphicsPathInternals(this);

	public XGraphicsPath()
	{
		_corePath = new CoreGraphicsPath();
	}

	public XGraphicsPath Clone()
	{
		XGraphicsPath result = (XGraphicsPath)MemberwiseClone();
		_corePath = new CoreGraphicsPath(_corePath);
		return result;
	}

	public void AddLine(XPoint pt1, XPoint pt2)
	{
		AddLine(pt1.X, pt1.Y, pt2.X, pt2.Y);
	}

	public void AddLine(double x1, double y1, double x2, double y2)
	{
		_corePath.MoveOrLineTo(x1, y1);
		_corePath.LineTo(x2, y2, closeSubpath: false);
	}

	public void AddLines(XPoint[] points)
	{
		if (points == null)
		{
			throw new ArgumentNullException("points");
		}
		int num = points.Length;
		if (num != 0)
		{
			_corePath.MoveOrLineTo(points[0].X, points[0].Y);
			for (int i = 1; i < num; i++)
			{
				_corePath.LineTo(points[i].X, points[i].Y, closeSubpath: false);
			}
		}
	}

	public void AddBezier(XPoint pt1, XPoint pt2, XPoint pt3, XPoint pt4)
	{
		AddBezier(pt1.X, pt1.Y, pt2.X, pt2.Y, pt3.X, pt3.Y, pt4.X, pt4.Y);
	}

	public void AddBezier(double x1, double y1, double x2, double y2, double x3, double y3, double x4, double y4)
	{
		_corePath.MoveOrLineTo(x1, y1);
		_corePath.BezierTo(x2, y2, x3, y3, x4, y4, closeSubpath: false);
	}

	public void AddBeziers(XPoint[] points)
	{
		if (points == null)
		{
			throw new ArgumentNullException("points");
		}
		int num = points.Length;
		if (num < 4)
		{
			throw new ArgumentException("At least four points required for bezier curve.", "points");
		}
		if ((num - 1) % 3 != 0)
		{
			throw new ArgumentException("Invalid number of points for bezier curve. Number must fulfil 4+3n.", "points");
		}
		_corePath.MoveOrLineTo(points[0].X, points[0].Y);
		for (int i = 1; i < num; i += 3)
		{
			_corePath.BezierTo(points[i].X, points[i].Y, points[i + 1].X, points[i + 1].Y, points[i + 2].X, points[i + 2].Y, closeSubpath: false);
		}
	}

	public void AddCurve(XPoint[] points)
	{
		AddCurve(points, 0.5);
	}

	public void AddCurve(XPoint[] points, double tension)
	{
		int num = points.Length;
		if (num < 2)
		{
			throw new ArgumentException("AddCurve requires two or more points.", "points");
		}
		_corePath.AddCurve(points, tension);
	}

	public void AddCurve(XPoint[] points, int offset, int numberOfSegments, double tension)
	{
		throw new NotImplementedException("AddCurve not yet implemented.");
	}

	public void AddArc(XRect rect, double startAngle, double sweepAngle)
	{
		AddArc(rect.X, rect.Y, rect.Width, rect.Height, startAngle, sweepAngle);
	}

	public void AddArc(double x, double y, double width, double height, double startAngle, double sweepAngle)
	{
		_corePath.AddArc(x, y, width, height, startAngle, sweepAngle);
	}

	public void AddArc(XPoint point1, XPoint point2, XSize size, double rotationAngle, bool isLargeArg, XSweepDirection sweepDirection)
	{
		_corePath.AddArc(point1, point2, size, rotationAngle, isLargeArg, sweepDirection);
	}

	public void AddRectangle(XRect rect)
	{
		_corePath.MoveTo(rect.X, rect.Y);
		_corePath.LineTo(rect.X + rect.Width, rect.Y, closeSubpath: false);
		_corePath.LineTo(rect.X + rect.Width, rect.Y + rect.Height, closeSubpath: false);
		_corePath.LineTo(rect.X, rect.Y + rect.Height, closeSubpath: true);
		_corePath.CloseSubpath();
	}

	public void AddRectangle(double x, double y, double width, double height)
	{
		AddRectangle(new XRect(x, y, width, height));
	}

	public void AddRectangles(XRect[] rects)
	{
		int num = rects.Length;
		for (int i = 0; i < num; i++)
		{
			AddRectangle(rects[i]);
		}
	}

	public void AddRoundedRectangle(double x, double y, double width, double height, double ellipseWidth, double ellipseHeight)
	{
		double num = ellipseWidth / 2.0;
		double num2 = ellipseHeight / 2.0;
		_corePath.MoveTo(x + width - num, y);
		_corePath.QuadrantArcTo(x + width - num, y + num2, num, num2, 1, clockwise: true);
		_corePath.LineTo(x + width, y + height - num2, closeSubpath: false);
		_corePath.QuadrantArcTo(x + width - num, y + height - num2, num, num2, 4, clockwise: true);
		_corePath.LineTo(x + num, y + height, closeSubpath: false);
		_corePath.QuadrantArcTo(x + num, y + height - num2, num, num2, 3, clockwise: true);
		_corePath.LineTo(x, y + num2, closeSubpath: false);
		_corePath.QuadrantArcTo(x + num, y + num2, num, num2, 2, clockwise: true);
		_corePath.CloseSubpath();
	}

	public void AddEllipse(XRect rect)
	{
		AddEllipse(rect.X, rect.Y, rect.Width, rect.Height);
	}

	public void AddEllipse(double x, double y, double width, double height)
	{
		double num = width / 2.0;
		double num2 = height / 2.0;
		double x2 = x + num;
		double y2 = y + num2;
		_corePath.MoveTo(x + num, y);
		_corePath.QuadrantArcTo(x2, y2, num, num2, 1, clockwise: true);
		_corePath.QuadrantArcTo(x2, y2, num, num2, 4, clockwise: true);
		_corePath.QuadrantArcTo(x2, y2, num, num2, 3, clockwise: true);
		_corePath.QuadrantArcTo(x2, y2, num, num2, 2, clockwise: true);
		_corePath.CloseSubpath();
	}

	public void AddPolygon(XPoint[] points)
	{
		int num = points.Length;
		if (num != 0)
		{
			_corePath.MoveTo(points[0].X, points[0].Y);
			for (int i = 0; i < num - 1; i++)
			{
				_corePath.LineTo(points[i].X, points[i].Y, closeSubpath: false);
			}
			_corePath.LineTo(points[num - 1].X, points[num - 1].Y, closeSubpath: true);
			_corePath.CloseSubpath();
		}
	}

	public void AddPie(XRect rect, double startAngle, double sweepAngle)
	{
		AddPie(rect.X, rect.Y, rect.Width, rect.Height, startAngle, sweepAngle);
	}

	public void AddPie(double x, double y, double width, double height, double startAngle, double sweepAngle)
	{
		DiagnosticsHelper.HandleNotImplemented("XGraphicsPath.AddPie");
	}

	public void AddClosedCurve(XPoint[] points)
	{
		AddClosedCurve(points, 0.5);
	}

	public void AddClosedCurve(XPoint[] points, double tension)
	{
		if (points == null)
		{
			throw new ArgumentNullException("points");
		}
		int num = points.Length;
		if (num != 0)
		{
			if (num < 2)
			{
				throw new ArgumentException("Not enough points.", "points");
			}
			DiagnosticsHelper.HandleNotImplemented("XGraphicsPath.AddClosedCurve");
		}
	}

	public void AddPath(XGraphicsPath path, bool connect)
	{
		DiagnosticsHelper.HandleNotImplemented("XGraphicsPath.AddPath");
	}

	public void AddString(string s, XFontFamily family, XFontStyle style, double emSize, XPoint origin, XStringFormat format)
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

	public void AddString(string s, XFontFamily family, XFontStyle style, double emSize, XRect layoutRect, XStringFormat format)
	{
		if (s == null)
		{
			throw new ArgumentNullException("s");
		}
		if (family == null)
		{
			throw new ArgumentNullException("family");
		}
		if (format == null)
		{
			format = XStringFormats.Default;
		}
		if (format.LineAlignment == XLineAlignment.BaseLine && layoutRect.Height != 0.0)
		{
			throw new InvalidOperationException("DrawString: With XLineAlignment.BaseLine the height of the layout rectangle must be 0.");
		}
		if (s.Length != 0)
		{
			XFont xFont = new XFont(family.Name, emSize, style);
			DiagnosticsHelper.HandleNotImplemented("XGraphicsPath.AddString");
		}
	}

	public void CloseFigure()
	{
		_corePath.CloseSubpath();
	}

	public void StartFigure()
	{
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
}
