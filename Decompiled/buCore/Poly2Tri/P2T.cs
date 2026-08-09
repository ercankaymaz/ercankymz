using System.Collections.Generic;
using Poly2Tri.Triangulation;
using Poly2Tri.Triangulation.Polygon;
using ns54;

namespace Poly2Tri;

public static class P2T
{
	public static void Triangulate(IEnumerable<Polygon> polygons)
	{
		foreach (Polygon polygon in polygons)
		{
			Triangulate(polygon);
		}
	}

	public static void Triangulate(ITriangulatable t, TriangulationAlgorithm algorithm = TriangulationAlgorithm.DTSweep)
	{
		TriangulationContext triangulationContext = Class156.smethod_75(algorithm);
		triangulationContext.PrepareTriangulation(t);
		Class156.smethod_285(triangulationContext);
	}
}
