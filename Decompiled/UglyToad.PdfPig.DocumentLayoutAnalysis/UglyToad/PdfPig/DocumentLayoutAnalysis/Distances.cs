using System;
using System.Collections.Generic;
using System.Linq;
using UglyToad.PdfPig.Core;

namespace UglyToad.PdfPig.DocumentLayoutAnalysis;

public static class Distances
{
	public static double Euclidean(PdfPoint point1, PdfPoint point2)
	{
		double num = point1.X - point2.X;
		double num2 = point1.Y - point2.Y;
		return Math.Sqrt(num * num + num2 * num2);
	}

	public static double WeightedEuclidean(PdfPoint point1, PdfPoint point2, double wX = 1.0, double wY = 1.0)
	{
		double num = point1.X - point2.X;
		double num2 = point1.Y - point2.Y;
		return Math.Sqrt(wX * num * num + wY * num2 * num2);
	}

	public static double Manhattan(PdfPoint point1, PdfPoint point2)
	{
		return Math.Abs(point1.X - point2.X) + Math.Abs(point1.Y - point2.Y);
	}

	public static double Angle(PdfPoint startPoint, PdfPoint endPoint)
	{
		return Math.Atan2(endPoint.Y - startPoint.Y, endPoint.X - startPoint.X) * 180.0 / Math.PI;
	}

	public static double Vertical(PdfPoint point1, PdfPoint point2)
	{
		return Math.Abs(point2.Y - point1.Y);
	}

	public static double Horizontal(PdfPoint point1, PdfPoint point2)
	{
		return Math.Abs(point2.X - point1.X);
	}

	public static double BoundAngle180(double angle)
	{
		angle = (angle + 180.0) % 360.0;
		if (angle < 0.0)
		{
			angle += 360.0;
		}
		return angle - 180.0;
	}

	public static double BoundAngle0to360(double angle)
	{
		angle %= 360.0;
		if (angle < 0.0)
		{
			angle += 360.0;
		}
		return angle;
	}

	public static int MinimumEditDistance(string string1, string string2)
	{
		ushort[,] array = new ushort[string1.Length + 1, string2.Length + 1];
		for (int i = 1; i <= string1.Length; i++)
		{
			array[i, 0] = (ushort)i;
		}
		for (int j = 1; j <= string2.Length; j++)
		{
			array[0, j] = (ushort)j;
		}
		for (int k = 1; k <= string2.Length; k++)
		{
			for (int l = 1; l <= string1.Length; l++)
			{
				array[l, k] = Math.Min(Math.Min((ushort)(array[l - 1, k] + 1), (ushort)(array[l, k - 1] + 1)), (ushort)((uint)array[l - 1, k - 1] + ((string1[l - 1] != string2[k - 1]) ? 1u : 0u)));
			}
		}
		return array[string1.Length, string2.Length];
	}

	public static double MinimumEditDistanceNormalised(string string1, string string2)
	{
		return (double)MinimumEditDistance(string1, string2) / (double)Math.Max(string1.Length, string2.Length);
	}

	public static int FindIndexNearest<T>(T element, IReadOnlyList<T> candidates, Func<T, PdfPoint> pivotPoint, Func<T, PdfPoint> candidatePoint, Func<PdfPoint, PdfPoint, double> distanceMeasure, out double distance)
	{
		if (candidates == null || candidates.Count == 0)
		{
			throw new ArgumentException("Distances.FindIndexNearest(): The list of neighbours candidates is either null or empty.", "candidates");
		}
		if (distanceMeasure == null)
		{
			throw new ArgumentException("Distances.FindIndexNearest(): The distance measure must not be null.", "distanceMeasure");
		}
		distance = double.MaxValue;
		int result = -1;
		List<PdfPoint> list = candidates.Select(candidatePoint).ToList();
		PdfPoint arg = pivotPoint(element);
		for (int i = 0; i < candidates.Count; i++)
		{
			double num = distanceMeasure(arg, list[i]);
			if (num < distance && !candidates[i].Equals(element))
			{
				distance = num;
				result = i;
			}
		}
		return result;
	}

	public static int FindIndexNearest<T>(T element, IReadOnlyList<T> candidates, Func<T, PdfLine> pivotLine, Func<T, PdfLine> candidateLine, Func<PdfLine, PdfLine, double> distanceMeasure, out double distance)
	{
		if (candidates == null || candidates.Count == 0)
		{
			throw new ArgumentException("Distances.FindIndexNearest(): The list of neighbours candidates is either null or empty.", "candidates");
		}
		if (distanceMeasure == null)
		{
			throw new ArgumentException("Distances.FindIndexNearest(): The distance measure must not be null.", "distanceMeasure");
		}
		distance = double.MaxValue;
		int result = -1;
		List<PdfLine> list = candidates.Select(candidateLine).ToList();
		PdfLine arg = pivotLine(element);
		for (int i = 0; i < candidates.Count; i++)
		{
			double num = distanceMeasure(arg, list[i]);
			if (num < distance && !candidates[i].Equals(element))
			{
				distance = num;
				result = i;
			}
		}
		return result;
	}
}
