using System;
using System.Globalization;

namespace UglyToad.PdfPig.Core;

public readonly struct PdfRectangle : IEquatable<PdfRectangle>
{
	public PdfPoint TopLeft { get; }

	public PdfPoint TopRight { get; }

	public PdfPoint BottomRight { get; }

	public PdfPoint BottomLeft { get; }

	public PdfPoint Centroid
	{
		get
		{
			double x = (BottomRight.X + TopRight.X + TopLeft.X + BottomLeft.X) / 4.0;
			double y = (BottomRight.Y + TopRight.Y + TopLeft.Y + BottomLeft.Y) / 4.0;
			return new PdfPoint(x, y);
		}
	}

	public double Width { get; }

	public double Height { get; }

	public double Rotation => GetT() * 180.0 / Math.PI;

	public double Area => Math.Abs(Width * Height);

	public double Left
	{
		get
		{
			if (!(TopLeft.X < TopRight.X))
			{
				return TopRight.X;
			}
			return TopLeft.X;
		}
	}

	public double Top
	{
		get
		{
			if (!(TopLeft.Y > BottomLeft.Y))
			{
				return BottomLeft.Y;
			}
			return TopLeft.Y;
		}
	}

	public double Right
	{
		get
		{
			if (!(BottomRight.X > BottomLeft.X))
			{
				return BottomLeft.X;
			}
			return BottomRight.X;
		}
	}

	public double Bottom
	{
		get
		{
			if (!(BottomRight.Y < TopRight.Y))
			{
				return TopRight.Y;
			}
			return BottomRight.Y;
		}
	}

	public PdfRectangle(PdfPoint bottomLeft, PdfPoint topRight)
		: this(bottomLeft.X, bottomLeft.Y, topRight.X, topRight.Y)
	{
	}

	public PdfRectangle(short x1, short y1, short x2, short y2)
		: this((double)x1, (double)y1, (double)x2, (double)y2)
	{
	}

	public PdfRectangle(double x1, double y1, double x2, double y2)
		: this(new PdfPoint(x1, y2), new PdfPoint(x2, y2), new PdfPoint(x1, y1), new PdfPoint(x2, y1))
	{
	}

	public PdfRectangle(PdfPoint topLeft, PdfPoint topRight, PdfPoint bottomLeft, PdfPoint bottomRight)
	{
		TopLeft = topLeft;
		TopRight = topRight;
		BottomLeft = bottomLeft;
		BottomRight = bottomRight;
		Width = Math.Sqrt((BottomLeft.X - BottomRight.X) * (BottomLeft.X - BottomRight.X) + (BottomLeft.Y - BottomRight.Y) * (BottomLeft.Y - BottomRight.Y));
		Height = Math.Sqrt((BottomLeft.X - TopLeft.X) * (BottomLeft.X - TopLeft.X) + (BottomLeft.Y - TopLeft.Y) * (BottomLeft.Y - TopLeft.Y));
	}

	public PdfRectangle Translate(double dx, double dy)
	{
		return new PdfRectangle(TopLeft.Translate(dx, dy), TopRight.Translate(dx, dy), BottomLeft.Translate(dx, dy), BottomRight.Translate(dx, dy));
	}

	private double GetT()
	{
		if (!BottomRight.Equals(BottomLeft))
		{
			return Math.Atan2(BottomRight.Y - BottomLeft.Y, BottomRight.X - BottomLeft.X);
		}
		return Math.Atan2(TopLeft.Y - BottomLeft.Y, TopLeft.X - BottomLeft.X) - Math.PI / 2.0;
	}

	public override string ToString()
	{
		return $"[{TopLeft}, {Width.ToString(CultureInfo.InvariantCulture)}, {Height.ToString(CultureInfo.InvariantCulture)}]";
	}

	public bool Equals(PdfRectangle other)
	{
		if (TopLeft.Equals(other.TopLeft) && TopRight.Equals(other.TopRight) && BottomRight.Equals(other.BottomRight))
		{
			return BottomLeft.Equals(other.BottomLeft);
		}
		return false;
	}

	public override bool Equals(object? obj)
	{
		if (obj is PdfRectangle other)
		{
			return Equals(other);
		}
		return false;
	}

	public override int GetHashCode()
	{
		return HashCode.Combine(TopLeft, TopRight, BottomRight, BottomLeft);
	}

	public static bool operator ==(PdfRectangle left, PdfRectangle right)
	{
		return left.Equals(right);
	}

	public static bool operator !=(PdfRectangle left, PdfRectangle right)
	{
		return !(left == right);
	}
}
