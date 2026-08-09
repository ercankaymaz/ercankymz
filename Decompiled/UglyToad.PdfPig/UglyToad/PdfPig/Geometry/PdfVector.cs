using System;
using UglyToad.PdfPig.Core;

namespace UglyToad.PdfPig.Geometry;

internal readonly struct PdfVector
{
	public double X { get; }

	public double Y { get; }

	public PdfVector(double x, double y)
	{
		X = x;
		Y = y;
	}

	public PdfVector Scale(double scale)
	{
		return new PdfVector(X * scale, Y * scale);
	}

	public double GetMagnitude()
	{
		double x = X;
		double y = Y;
		return Math.Sqrt(x * x + y * y);
	}

	public PdfVector Subtract(PdfVector vector)
	{
		return new PdfVector(X - vector.X, Y - vector.Y);
	}

	public PdfPoint ToPoint()
	{
		return new PdfPoint(X, Y);
	}

	public override string ToString()
	{
		return $"({X}, {Y})";
	}
}
