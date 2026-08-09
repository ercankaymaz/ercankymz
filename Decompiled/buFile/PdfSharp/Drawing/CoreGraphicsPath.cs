#define DEBUG
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace PdfSharp.Drawing;

internal class CoreGraphicsPath
{
	private const byte PathPointTypeStart = 0;

	private const byte PathPointTypeLine = 1;

	private const byte PathPointTypeBezier = 3;

	private const byte PathPointTypePathTypeMask = 7;

	private const byte PathPointTypeCloseSubpath = 128;

	private XFillMode _fillMode;

	private readonly List<XPoint> _points = new List<XPoint>();

	private readonly List<byte> _types = new List<byte>();

	private XFillMode FillMode
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

	public XPoint[] PathPoints => _points.ToArray();

	public byte[] PathTypes => _types.ToArray();

	public CoreGraphicsPath()
	{
	}

	public CoreGraphicsPath(CoreGraphicsPath path)
	{
		_points = new List<XPoint>(path._points);
		_types = new List<byte>(path._types);
	}

	public void MoveOrLineTo(double x, double y)
	{
		if (_types.Count == 0 || (_types[_types.Count - 1] & 0x80) == 128)
		{
			MoveTo(x, y);
		}
		else
		{
			LineTo(x, y, closeSubpath: false);
		}
	}

	public void MoveTo(double x, double y)
	{
		_points.Add(new XPoint(x, y));
		_types.Add(0);
	}

	public void LineTo(double x, double y, bool closeSubpath)
	{
		if (_points.Count <= 0 || !_points[_points.Count - 1].Equals(new XPoint(x, y)))
		{
			_points.Add(new XPoint(x, y));
			_types.Add((byte)(1 | (closeSubpath ? 128 : 0)));
		}
	}

	public void BezierTo(double x1, double y1, double x2, double y2, double x3, double y3, bool closeSubpath)
	{
		_points.Add(new XPoint(x1, y1));
		_types.Add(3);
		_points.Add(new XPoint(x2, y2));
		_types.Add(3);
		_points.Add(new XPoint(x3, y3));
		_types.Add((byte)(3 | (closeSubpath ? 128 : 0)));
	}

	public void QuadrantArcTo(double x, double y, double width, double height, int quadrant, bool clockwise)
	{
		if (width < 0.0)
		{
			throw new ArgumentOutOfRangeException("width");
		}
		if (height < 0.0)
		{
			throw new ArgumentOutOfRangeException("height");
		}
		double num = 0.5522847498307935 * width;
		double num2 = 0.5522847498307935 * height;
		double x2;
		double y2;
		double x3;
		double y3;
		double x4;
		double y4;
		switch (quadrant)
		{
		case 1:
			if (clockwise)
			{
				x2 = x + num;
				y2 = y - height;
				x3 = x + width;
				y3 = y - num2;
				x4 = x + width;
				y4 = y;
			}
			else
			{
				x2 = x + width;
				y2 = y - num2;
				x3 = x + num;
				y3 = y - height;
				x4 = x;
				y4 = y - height;
			}
			break;
		case 2:
			if (clockwise)
			{
				x2 = x - width;
				y2 = y - num2;
				x3 = x - num;
				y3 = y - height;
				x4 = x;
				y4 = y - height;
			}
			else
			{
				x2 = x - num;
				y2 = y - height;
				x3 = x - width;
				y3 = y - num2;
				x4 = x - width;
				y4 = y;
			}
			break;
		case 3:
			if (clockwise)
			{
				x2 = x - num;
				y2 = y + height;
				x3 = x - width;
				y3 = y + num2;
				x4 = x - width;
				y4 = y;
			}
			else
			{
				x2 = x - width;
				y2 = y + num2;
				x3 = x - num;
				y3 = y + height;
				x4 = x;
				y4 = y + height;
			}
			break;
		case 4:
			if (clockwise)
			{
				x2 = x + width;
				y2 = y + num2;
				x3 = x + num;
				y3 = y + height;
				x4 = x;
				y4 = y + height;
			}
			else
			{
				x2 = x + num;
				y2 = y + height;
				x3 = x + width;
				y3 = y + num2;
				x4 = x + width;
				y4 = y;
			}
			break;
		default:
			throw new ArgumentOutOfRangeException("quadrant");
		}
		BezierTo(x2, y2, x3, y3, x4, y4, closeSubpath: false);
	}

	public void CloseSubpath()
	{
		int count = _types.Count;
		if (count > 0)
		{
			_types[count - 1] |= 128;
		}
	}

	public void AddArc(double x, double y, double width, double height, double startAngle, double sweepAngle)
	{
		XMatrix matrix = XMatrix.Identity;
		List<XPoint> list = GeometryHelper.BezierCurveFromArc(x, y, width, height, startAngle, sweepAngle, PathStart.MoveTo1st, ref matrix);
		int count = list.Count;
		Debug.Assert((count + 2) % 3 == 0);
		MoveOrLineTo(list[0].X, list[0].Y);
		for (int i = 1; i < count; i += 3)
		{
			BezierTo(list[i].X, list[i].Y, list[i + 1].X, list[i + 1].Y, list[i + 2].X, list[i + 2].Y, closeSubpath: false);
		}
	}

	public void AddArc(XPoint point1, XPoint point2, XSize size, double rotationAngle, bool isLargeArg, XSweepDirection sweepDirection)
	{
		List<XPoint> list = GeometryHelper.BezierCurveFromArc(point1, point2, size, rotationAngle, isLargeArg, sweepDirection == XSweepDirection.Clockwise, PathStart.MoveTo1st);
		int count = list.Count;
		Debug.Assert((count + 2) % 3 == 0);
		MoveOrLineTo(list[0].X, list[0].Y);
		for (int i = 1; i < count; i += 3)
		{
			BezierTo(list[i].X, list[i].Y, list[i + 1].X, list[i + 1].Y, list[i + 2].X, list[i + 2].Y, closeSubpath: false);
		}
	}

	public void AddCurve(XPoint[] points, double tension)
	{
		int num = points.Length;
		if (num < 2)
		{
			throw new ArgumentException("AddCurve requires two or more points.", "points");
		}
		tension /= 3.0;
		MoveOrLineTo(points[0].X, points[0].Y);
		if (num == 2)
		{
			ToCurveSegment(points[0], points[0], points[1], points[1], tension);
			return;
		}
		ToCurveSegment(points[0], points[0], points[1], points[2], tension);
		for (int i = 1; i < num - 2; i++)
		{
			ToCurveSegment(points[i - 1], points[i], points[i + 1], points[i + 2], tension);
		}
		ToCurveSegment(points[num - 3], points[num - 2], points[num - 1], points[num - 1], tension);
	}

	private void ToCurveSegment(XPoint pt0, XPoint pt1, XPoint pt2, XPoint pt3, double tension3)
	{
		BezierTo(pt1.X + tension3 * (pt2.X - pt0.X), pt1.Y + tension3 * (pt2.Y - pt0.Y), pt2.X - tension3 * (pt3.X - pt1.X), pt2.Y - tension3 * (pt3.Y - pt1.Y), pt2.X, pt2.Y, closeSubpath: false);
	}
}
