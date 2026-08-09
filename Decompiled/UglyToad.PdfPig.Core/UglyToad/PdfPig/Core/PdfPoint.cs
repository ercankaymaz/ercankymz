using System;
using System.Diagnostics;
using System.Globalization;

namespace UglyToad.PdfPig.Core;

public readonly struct PdfPoint : IEquatable<PdfPoint>
{
	public static PdfPoint Origin { get; } = new PdfPoint(0.0, 0.0);

	public double X { get; }

	public double Y { get; }

	[DebuggerStepThrough]
	public PdfPoint(int x, int y)
	{
		X = x;
		Y = y;
	}

	[DebuggerStepThrough]
	public PdfPoint(double x, double y)
	{
		X = x;
		Y = y;
	}

	public PdfPoint MoveX(double dx)
	{
		return new PdfPoint(X + dx, Y);
	}

	public PdfPoint MoveY(double dy)
	{
		return new PdfPoint(X, Y + dy);
	}

	public PdfPoint Translate(double dx, double dy)
	{
		return new PdfPoint(X + dx, Y + dy);
	}

	public override bool Equals(object? obj)
	{
		if (obj is PdfPoint other)
		{
			return Equals(other);
		}
		return false;
	}

	public bool Equals(PdfPoint other)
	{
		if (X.Equals(other.X))
		{
			return Y.Equals(other.Y);
		}
		return false;
	}

	public override int GetHashCode()
	{
		return HashCode.Combine(X, Y);
	}

	public override string ToString()
	{
		return "(x:" + X.ToString(CultureInfo.InvariantCulture) + ", y:" + Y.ToString(CultureInfo.InvariantCulture) + ")";
	}

	public static bool operator ==(PdfPoint left, PdfPoint right)
	{
		return left.Equals(right);
	}

	public static bool operator !=(PdfPoint left, PdfPoint right)
	{
		return !(left == right);
	}
}
