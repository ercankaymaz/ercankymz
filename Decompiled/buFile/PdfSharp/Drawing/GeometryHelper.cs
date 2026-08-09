#define DEBUG
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace PdfSharp.Drawing;

internal static class GeometryHelper
{
	public static List<XPoint> BezierCurveFromArc(double x, double y, double width, double height, double startAngle, double sweepAngle, PathStart pathStart, ref XMatrix matrix)
	{
		List<XPoint> list = new List<XPoint>();
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
			AppendPartialArcQuadrant(list, x, y, width, height, num, num2, pathStart, matrix);
		}
		else
		{
			int num5 = num3;
			bool flag3 = true;
			while (true)
			{
				if (num5 == num3 && flag3)
				{
					double β = num5 * 90 + (flag2 ? 90 : 0);
					AppendPartialArcQuadrant(list, x, y, width, height, num, β, pathStart, matrix);
				}
				else if (num5 == num4)
				{
					double α = num5 * 90 + ((!flag2) ? 90 : 0);
					AppendPartialArcQuadrant(list, x, y, width, height, α, num2, PathStart.Ignore1st, matrix);
				}
				else
				{
					double α2 = num5 * 90 + ((!flag2) ? 90 : 0);
					double β2 = num5 * 90 + (flag2 ? 90 : 0);
					AppendPartialArcQuadrant(list, x, y, width, height, α2, β2, PathStart.Ignore1st, matrix);
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
		return list;
	}

	private static int Quadrant(double φ, bool start, bool clockwise)
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

	private static void AppendPartialArcQuadrant(List<XPoint> points, double x, double y, double width, double height, double α, double β, PathStart pathStart, XMatrix matrix)
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
			switch (pathStart)
			{
			case PathStart.MoveTo1st:
				points.Add(matrix.Transform(new XPoint(num3 + num * num8, num4 + num2 * num5)));
				break;
			case PathStart.LineTo1st:
				points.Add(matrix.Transform(new XPoint(num3 + num * num8, num4 + num2 * num5)));
				break;
			}
			points.Add(matrix.Transform(new XPoint(num3 + num * (num8 - num7 * num5), num4 + num2 * (num5 + num7 * num8))));
			points.Add(matrix.Transform(new XPoint(num3 + num * (num9 + num7 * num6), num4 + num2 * (num6 - num7 * num9))));
			points.Add(matrix.Transform(new XPoint(num3 + num * num9, num4 + num2 * num6)));
		}
		else
		{
			switch (pathStart)
			{
			case PathStart.MoveTo1st:
				points.Add(matrix.Transform(new XPoint(num3 - num * num8, num4 - num2 * num5)));
				break;
			case PathStart.LineTo1st:
				points.Add(matrix.Transform(new XPoint(num3 - num * num8, num4 - num2 * num5)));
				break;
			}
			points.Add(matrix.Transform(new XPoint(num3 - num * (num8 - num7 * num5), num4 - num2 * (num5 + num7 * num8))));
			points.Add(matrix.Transform(new XPoint(num3 - num * (num9 + num7 * num6), num4 - num2 * (num6 - num7 * num9))));
			points.Add(matrix.Transform(new XPoint(num3 - num * num9, num4 - num2 * num6)));
		}
	}

	public static List<XPoint> BezierCurveFromArc(XPoint point1, XPoint point2, XSize size, double rotationAngle, bool isLargeArc, bool clockwise, PathStart pathStart)
	{
		double width = size.Width;
		double height = size.Height;
		Debug.Assert(width * height > 0.0);
		double num = height / width;
		bool flag = !clockwise;
		XMatrix matrix = default(XMatrix);
		matrix.RotateAppend(0.0 - rotationAngle);
		matrix.ScaleAppend(height / width, 1.0);
		XPoint xPoint = matrix.Transform(point1);
		XPoint xPoint2 = matrix.Transform(point2);
		XPoint xPoint3 = new XPoint((xPoint.X + xPoint2.X) / 2.0, (xPoint.Y + xPoint2.Y) / 2.0);
		XVector xVector = xPoint2 - xPoint;
		double num2 = xVector.Length / 2.0;
		XVector xVector2 = ((isLargeArc != flag) ? new XVector(xVector.Y, 0.0 - xVector.X) : new XVector(0.0 - xVector.Y, xVector.X));
		xVector2.Normalize();
		double num3 = Math.Sqrt(height * height - num2 * num2);
		if (double.IsNaN(num3))
		{
			num3 = 0.0;
		}
		XPoint xPoint4 = xPoint3 + num3 * xVector2;
		double num4 = Math.Atan2(xPoint.Y - xPoint4.Y, xPoint.X - xPoint4.X);
		double num5 = Math.Atan2(xPoint2.Y - xPoint4.Y, xPoint2.X - xPoint4.X);
		if (isLargeArc == Math.Abs(num5 - num4) < Math.PI)
		{
			if (num4 < num5)
			{
				num4 += Math.PI * 2.0;
			}
			else
			{
				num5 += Math.PI * 2.0;
			}
		}
		matrix.Invert();
		double num6 = num5 - num4;
		return BezierCurveFromArc(xPoint4.X - width * num, xPoint4.Y - height, 2.0 * width * num, 2.0 * height, num4 / (Math.PI / 180.0), num6 / (Math.PI / 180.0), pathStart, ref matrix);
	}
}
