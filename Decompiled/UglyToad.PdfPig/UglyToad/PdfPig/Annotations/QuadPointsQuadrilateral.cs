using System;
using UglyToad.PdfPig.Core;

namespace UglyToad.PdfPig.Annotations;

public readonly struct QuadPointsQuadrilateral
{
	private readonly PdfPoint[] points;

	public ReadOnlySpan<PdfPoint> Points => points;

	public QuadPointsQuadrilateral(PdfPoint[] points)
	{
		if (points == null)
		{
			throw new ArgumentNullException("points");
		}
		if (points.Length != 4)
		{
			throw new ArgumentException($"Quadpoints quadrilateral should only contain 4 points, instead got {points.Length} points.");
		}
		this.points = points;
	}

	public override string ToString()
	{
		return $"[ {Points[0]}, {Points[1]}, {Points[2]}, {Points[3]} ]";
	}
}
