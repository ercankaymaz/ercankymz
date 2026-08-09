using System.Runtime.CompilerServices;
using ns54;

namespace Poly2Tri.Triangulation.Delaunay.Sweep;

public class DTSweepContext : TriangulationContext
{
	public AdvancingFront Front;

	[CompilerGenerated]
	private TriangulationPoint triangulationPoint_0;

	[CompilerGenerated]
	private TriangulationPoint triangulationPoint_1;

	public readonly DTSweepBasin Basin = new DTSweepBasin();

	public readonly DTSweepEdgeEvent EdgeEvent = new DTSweepEdgeEvent();

	private readonly DTSweepPointComparator dtsweepPointComparator_0 = new DTSweepPointComparator();

	public override TriangulationAlgorithm Algorithm => TriangulationAlgorithm.DTSweep;

	public new DTSweepDebugContext DebugContext => (DTSweepDebugContext)base.DebugContext;

	[SpecialName]
	[CompilerGenerated]
	private TriangulationPoint method_0()
	{
		return triangulationPoint_0;
	}

	[SpecialName]
	[CompilerGenerated]
	private void method_1(TriangulationPoint triangulationPoint_2)
	{
		triangulationPoint_0 = triangulationPoint_2;
	}

	[SpecialName]
	[CompilerGenerated]
	private TriangulationPoint method_2()
	{
		return triangulationPoint_1;
	}

	[SpecialName]
	[CompilerGenerated]
	private void method_3(TriangulationPoint triangulationPoint_2)
	{
		triangulationPoint_1 = triangulationPoint_2;
	}

	public DTSweepContext()
		: base(new DTSweepDebugContext())
	{
	}

	public void RemoveFromList(DelaunayTriangle triangle)
	{
		Triangles.Remove(triangle);
	}

	public void MeshClean(DelaunayTriangle triangle)
	{
		Class156.smethod_215(triangle, this);
	}

	public AdvancingFrontNode LocateNode(TriangulationPoint point)
	{
		return Front.LocateNode(point);
	}

	public void CreateAdvancingFront()
	{
		DelaunayTriangle delaunayTriangle = new DelaunayTriangle(Points[0], method_2(), method_0());
		Triangles.Add(delaunayTriangle);
		AdvancingFrontNode head = new AdvancingFrontNode(delaunayTriangle.Points[1])
		{
			Triangle = delaunayTriangle
		};
		AdvancingFrontNode advancingFrontNode = new AdvancingFrontNode(delaunayTriangle.Points[0])
		{
			Triangle = delaunayTriangle
		};
		AdvancingFrontNode tail = new AdvancingFrontNode(delaunayTriangle.Points[2]);
		Front = new AdvancingFront(head, tail)
		{
			Head = 
			{
				Next = advancingFrontNode
			}
		};
		advancingFrontNode.Next = Front.Tail;
		advancingFrontNode.Prev = Front.Head;
		Front.Tail.Prev = advancingFrontNode;
	}

	public void MapTriangleToNodes(DelaunayTriangle t)
	{
		for (int i = 0; i < 3; i++)
		{
			if (t.Neighbors[i] == null)
			{
				AdvancingFrontNode advancingFrontNode = Front.LocatePoint(t.PointCWFrom(t.Points[i]));
				if (advancingFrontNode != null)
				{
					advancingFrontNode.Triangle = t;
				}
			}
		}
	}

	public override void PrepareTriangulation(ITriangulatable t)
	{
		base.PrepareTriangulation(t);
		double x;
		double num = (x = Points[0].X);
		double y;
		double num2 = (y = Points[0].Y);
		foreach (TriangulationPoint point in Points)
		{
			if (point.X > num)
			{
				num = point.X;
			}
			if (point.X < x)
			{
				x = point.X;
			}
			if (point.Y > num2)
			{
				num2 = point.Y;
			}
			if (point.Y < y)
			{
				y = point.Y;
			}
		}
		double num3 = 0.30000001192092896 * (num - x);
		double num4 = 0.30000001192092896 * (num2 - y);
		TriangulationPoint triangulationPoint_ = new TriangulationPoint(num + num3, y - num4);
		TriangulationPoint triangulationPoint_2 = new TriangulationPoint(x - num3, y - num4);
		method_1(triangulationPoint_);
		method_3(triangulationPoint_2);
		Points.Sort(dtsweepPointComparator_0);
	}

	public void FinalizeTriangulation()
	{
		base.Triangulatable.AddTriangles(Triangles);
		Triangles.Clear();
	}

	public override DTSweepConstraint NewConstraint(TriangulationPoint a, TriangulationPoint b)
	{
		return new DTSweepConstraint(a, b);
	}
}
