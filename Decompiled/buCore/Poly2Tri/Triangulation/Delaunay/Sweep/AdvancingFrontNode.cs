namespace Poly2Tri.Triangulation.Delaunay.Sweep;

public class AdvancingFrontNode
{
	public AdvancingFrontNode Next;

	public AdvancingFrontNode Prev;

	public readonly double Value;

	public readonly TriangulationPoint Point;

	public DelaunayTriangle Triangle;

	public bool HasNext => Next != null;

	public bool HasPrev => Prev != null;

	public AdvancingFrontNode(TriangulationPoint point)
	{
		Point = point;
		Value = point.X;
	}
}
