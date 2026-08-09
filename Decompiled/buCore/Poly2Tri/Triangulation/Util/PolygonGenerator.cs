using System;
using Poly2Tri.Triangulation.Polygon;

namespace Poly2Tri.Triangulation.Util;

public class PolygonGenerator
{
	private static readonly Random random_0 = new Random();

	public static Poly2Tri.Triangulation.Polygon.Polygon RandomCircleSweep(double scale, int vertexCount)
	{
		double num = scale / 4.0;
		PolygonPoint[] array = new PolygonPoint[vertexCount];
		for (int i = 0; i < vertexCount; i++)
		{
			do
			{
				num = ((i % 250 == 0) ? (num + scale / 2.0 * (0.5 - random_0.NextDouble())) : ((i % 50 == 0) ? (num + scale / 5.0 * (0.5 - random_0.NextDouble())) : (num + 25.0 * scale / (double)vertexCount * (0.5 - random_0.NextDouble()))));
				num = ((!(num > scale / 2.0)) ? num : (scale / 2.0));
				num = ((num >= scale / 10.0) ? num : (scale / 10.0));
			}
			while (!(num >= scale / 10.0) || num > scale / 2.0);
			PolygonPoint polygonPoint = new PolygonPoint(num * Math.Cos(Math.PI * 2.0 * (double)i / (double)vertexCount), num * Math.Sin(Math.PI * 2.0 * (double)i / (double)vertexCount));
			array[i] = polygonPoint;
		}
		return new Poly2Tri.Triangulation.Polygon.Polygon(array);
	}

	public static Poly2Tri.Triangulation.Polygon.Polygon RandomCircleSweep2(double scale, int vertexCount)
	{
		double num = scale / 4.0;
		PolygonPoint[] array = new PolygonPoint[vertexCount];
		for (int i = 0; i < vertexCount; i++)
		{
			do
			{
				num += scale / 5.0 * (0.5 - random_0.NextDouble());
				num = ((!(num > scale / 2.0)) ? num : (scale / 2.0));
				num = ((num >= scale / 10.0) ? num : (scale / 10.0));
			}
			while (!(num >= scale / 10.0) || num > scale / 2.0);
			PolygonPoint polygonPoint = new PolygonPoint(num * Math.Cos(Math.PI * 2.0 * (double)i / (double)vertexCount), num * Math.Sin(Math.PI * 2.0 * (double)i / (double)vertexCount));
			array[i] = polygonPoint;
		}
		return new Poly2Tri.Triangulation.Polygon.Polygon(array);
	}
}
