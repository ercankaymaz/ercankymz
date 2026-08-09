using System.Collections.Generic;
using ns54;

namespace Poly2Tri.Triangulation.Delaunay.Sweep;

public static class DTSweep
{
	public static void Triangulate(DTSweepContext tcx)
	{
		tcx.CreateAdvancingFront();
		smethod_0(tcx);
		smethod_1(tcx);
		if (tcx.TriangulationMode != TriangulationMode.Polygon)
		{
			Class156.smethod_245(tcx);
			if (tcx.TriangulationMode != TriangulationMode.Constrained)
			{
				tcx.FinalizeTriangulation();
			}
			else
			{
				tcx.FinalizeTriangulation();
			}
		}
		else
		{
			Class156.smethod_24(tcx);
		}
	}

	private static void smethod_0(DTSweepContext dtsweepContext_0)
	{
		List<TriangulationPoint> points = dtsweepContext_0.Points;
		for (int i = 1; i < points.Count; i++)
		{
			TriangulationPoint triangulationPoint = points[i];
			AdvancingFrontNode advancingFrontNode = Class156.smethod_201(dtsweepContext_0, triangulationPoint);
			if (i != 295)
			{
			}
			if (advancingFrontNode == null || !triangulationPoint.HasEdges)
			{
				continue;
			}
			foreach (DTSweepConstraint edge in triangulationPoint.Edges)
			{
				if (dtsweepContext_0.IsDebugEnabled)
				{
					dtsweepContext_0.DebugContext.ActiveConstraint = edge;
				}
				Class156.smethod_135(dtsweepContext_0, edge, advancingFrontNode);
			}
		}
	}

	private static void smethod_1(TriangulationContext triangulationContext_0)
	{
		foreach (DelaunayTriangle triangle in triangulationContext_0.Triangles)
		{
			for (int i = 0; i < 3; i++)
			{
				if (!triangle.GetConstrainedEdgeCCW(triangle.Points[i]) && triangle.GetEdgeCCW(triangle.Points[i], out var _))
				{
					triangle.MarkConstrainedEdge((i + 2) % 3);
				}
			}
		}
	}
}
