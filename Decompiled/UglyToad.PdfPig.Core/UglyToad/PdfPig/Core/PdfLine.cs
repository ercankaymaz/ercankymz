using System;

namespace UglyToad.PdfPig.Core;

public readonly struct PdfLine : IEquatable<PdfLine>
{
	public double Length
	{
		get
		{
			double num = Point1.X - Point2.X;
			double num2 = Point1.Y - Point2.Y;
			return Math.Sqrt(num * num + num2 * num2);
		}
	}

	public PdfPoint Point1 { get; }

	public PdfPoint Point2 { get; }

	public PdfLine(double x1, double y1, double x2, double y2)
		: this(new PdfPoint(x1, y1), new PdfPoint(x2, y2))
	{
	}

	public PdfLine(PdfPoint point1, PdfPoint point2)
	{
		Point1 = point1;
		Point2 = point2;
	}

	public PdfRectangle GetBoundingRectangle()
	{
		return new PdfRectangle(Math.Min(Point1.X, Point2.X), Math.Min(Point1.Y, Point2.Y), Math.Max(Point1.X, Point2.X), Math.Max(Point1.Y, Point2.Y));
	}

	public override bool Equals(object? obj)
	{
		if (obj is PdfLine other)
		{
			return Equals(other);
		}
		return false;
	}

	public bool Equals(PdfLine other)
	{
		if (Point1.Equals(other.Point1))
		{
			return Point2.Equals(other.Point2);
		}
		return false;
	}

	public override int GetHashCode()
	{
		return HashCode.Combine(Point1, Point2);
	}

	public static bool operator ==(PdfLine left, PdfLine right)
	{
		return left.Equals(right);
	}

	public static bool operator !=(PdfLine left, PdfLine right)
	{
		return !(left == right);
	}
}
