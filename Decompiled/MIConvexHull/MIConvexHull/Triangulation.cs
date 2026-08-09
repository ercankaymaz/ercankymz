using System.Collections.Generic;
using System.Linq;

namespace MIConvexHull;

public static class Triangulation
{
	public static ITriangulation<TVertex, DefaultTriangulationCell<TVertex>> CreateDelaunay<TVertex>(IList<TVertex> data, double PlaneDistanceTolerance = 1E-10) where TVertex : IVertex
	{
		return DelaunayTriangulation<TVertex, DefaultTriangulationCell<TVertex>>.Create(data, PlaneDistanceTolerance);
	}

	public static ITriangulation<DefaultVertex, DefaultTriangulationCell<DefaultVertex>> CreateDelaunay(IList<double[]> data, double PlaneDistanceTolerance = 1E-10)
	{
		return DelaunayTriangulation<DefaultVertex, DefaultTriangulationCell<DefaultVertex>>.Create(data.Select((double[] p) => new DefaultVertex
		{
			Position = p
		}).ToList(), PlaneDistanceTolerance);
	}

	public static ITriangulation<TVertex, TFace> CreateDelaunay<TVertex, TFace>(IList<TVertex> data, double PlaneDistanceTolerance = 1E-10) where TVertex : IVertex where TFace : TriangulationCell<TVertex, TFace>, new()
	{
		return DelaunayTriangulation<TVertex, TFace>.Create(data, PlaneDistanceTolerance);
	}

	public static VoronoiMesh<TVertex, TCell, TEdge> CreateVoronoi<TVertex, TCell, TEdge>(IList<TVertex> data, double PlaneDistanceTolerance = 1E-10) where TVertex : IVertex where TCell : TriangulationCell<TVertex, TCell>, new() where TEdge : VoronoiEdge<TVertex, TCell>, new()
	{
		return VoronoiMesh<TVertex, TCell, TEdge>.Create(data, PlaneDistanceTolerance);
	}

	public static VoronoiMesh<TVertex, DefaultTriangulationCell<TVertex>, VoronoiEdge<TVertex, DefaultTriangulationCell<TVertex>>> CreateVoronoi<TVertex>(IList<TVertex> data, double PlaneDistanceTolerance = 1E-10) where TVertex : IVertex
	{
		return VoronoiMesh<TVertex, DefaultTriangulationCell<TVertex>, VoronoiEdge<TVertex, DefaultTriangulationCell<TVertex>>>.Create(data, PlaneDistanceTolerance);
	}

	public static VoronoiMesh<DefaultVertex, DefaultTriangulationCell<DefaultVertex>, VoronoiEdge<DefaultVertex, DefaultTriangulationCell<DefaultVertex>>> CreateVoronoi(IList<double[]> data, double PlaneDistanceTolerance = 1E-10)
	{
		return VoronoiMesh<DefaultVertex, DefaultTriangulationCell<DefaultVertex>, VoronoiEdge<DefaultVertex, DefaultTriangulationCell<DefaultVertex>>>.Create(data.Select((double[] p) => new DefaultVertex
		{
			Position = p.ToArray()
		}).ToList(), PlaneDistanceTolerance);
	}

	public static VoronoiMesh<TVertex, TCell, VoronoiEdge<TVertex, TCell>> CreateVoronoi<TVertex, TCell>(IList<TVertex> data, double PlaneDistanceTolerance = 1E-10) where TVertex : IVertex where TCell : TriangulationCell<TVertex, TCell>, new()
	{
		return VoronoiMesh<TVertex, TCell, VoronoiEdge<TVertex, TCell>>.Create(data, PlaneDistanceTolerance);
	}
}
