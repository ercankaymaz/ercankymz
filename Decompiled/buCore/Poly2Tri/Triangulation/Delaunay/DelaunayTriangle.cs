using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Poly2Tri.Triangulation.Delaunay.Sweep;
using Poly2Tri.Utility;
using ns54;

namespace Poly2Tri.Triangulation.Delaunay;

public class DelaunayTriangle : IEquatable<DelaunayTriangle>
{
	public FixedArray3<TriangulationPoint> Points;

	public FixedArray3<DelaunayTriangle> Neighbors;

	internal FixedArray3<bool> fixedArray3_0;

	public FixedArray3<bool> EdgeIsDelaunay;

	[CompilerGenerated]
	private bool bool_0;

	public FixedArray3<bool> EdgeIsConstrained => fixedArray3_0;

	public bool IsInterior
	{
		[CompilerGenerated]
		get
		{
			return bool_0;
		}
		[CompilerGenerated]
		set
		{
			bool_0 = value;
		}
	}

	public DelaunayTriangle(TriangulationPoint p1, TriangulationPoint p2, TriangulationPoint p3)
	{
		Points[0] = p1;
		Points[1] = p2;
		Points[2] = p3;
	}

	public int IndexOf(TriangulationPoint p)
	{
		int num = Points.IndexOf(p);
		if (num == -1)
		{
			throw new Exception("Calling index with a point that doesn't exist in triangle");
		}
		return num;
	}

	public int IndexCWFrom(TriangulationPoint p)
	{
		return (IndexOf(p) + 2) % 3;
	}

	public bool Contains(TriangulationPoint p)
	{
		return Points.Contains(p);
	}

	public void MarkNeighbor(DelaunayTriangle t)
	{
		bool flag = t.Contains(Points[0]);
		bool flag2 = t.Contains(Points[1]);
		bool flag3 = t.Contains(Points[2]);
		if (!(flag2 && flag3))
		{
			if (!(flag && flag3))
			{
				if (!(flag && flag2))
				{
					throw new Exception("Failed to mark neighbor, doesn't share an edge!");
				}
				Neighbors[2] = t;
				TriangulationPoint triangulationPoint_ = Points[0];
				TriangulationPoint triangulationPoint_2 = Points[1];
				Class156.smethod_263(triangulationPoint_, triangulationPoint_2, this, t);
			}
			else
			{
				Neighbors[1] = t;
				TriangulationPoint triangulationPoint_ = Points[0];
				TriangulationPoint triangulationPoint_2 = Points[2];
				Class156.smethod_263(triangulationPoint_, triangulationPoint_2, this, t);
			}
		}
		else
		{
			Neighbors[0] = t;
			TriangulationPoint triangulationPoint_ = Points[1];
			TriangulationPoint triangulationPoint_2 = Points[2];
			Class156.smethod_263(triangulationPoint_, triangulationPoint_2, this, t);
		}
	}

	public void Clear()
	{
		for (int i = 0; i < 3; i++)
		{
			DelaunayTriangle delaunayTriangle = Neighbors[i];
			if (delaunayTriangle != null)
			{
				Class156.smethod_114(this, delaunayTriangle);
			}
		}
		Class156.smethod_36(this);
		ref FixedArray3<TriangulationPoint> points = ref Points;
		ref FixedArray3<TriangulationPoint> points2 = ref Points;
		TriangulationPoint triangulationPoint = (Points[2] = null);
		TriangulationPoint value = (points2[1] = triangulationPoint);
		points[0] = value;
	}

	public TriangulationPoint OppositePoint(DelaunayTriangle t, TriangulationPoint p)
	{
		return PointCWFrom(t.PointCWFrom(p));
	}

	public DelaunayTriangle NeighborCWFrom(TriangulationPoint point)
	{
		return Neighbors[(Points.IndexOf(point) + 1) % 3];
	}

	public DelaunayTriangle NeighborCCWFrom(TriangulationPoint point)
	{
		return Neighbors[(Points.IndexOf(point) + 2) % 3];
	}

	public DelaunayTriangle NeighborAcrossFrom(TriangulationPoint point)
	{
		return Neighbors[Points.IndexOf(point)];
	}

	public TriangulationPoint PointCCWFrom(TriangulationPoint point)
	{
		return Points[(IndexOf(point) + 1) % 3];
	}

	public TriangulationPoint PointCWFrom(TriangulationPoint point)
	{
		return Points[(IndexOf(point) + 2) % 3];
	}

	public void Legalize(TriangulationPoint oPoint, TriangulationPoint nPoint)
	{
		Class156.smethod_162(this);
		Points[Class156.smethod_233(oPoint, this)] = nPoint;
	}

	public override string ToString()
	{
		return Points[0]?.ToString() + "," + Points[1]?.ToString() + "," + Points[2];
	}

	public void MarkNeighborEdges()
	{
		for (int i = 0; i < 3; i++)
		{
			if (EdgeIsConstrained[i] && Neighbors[i] != null)
			{
				Neighbors[i].MarkConstrainedEdge(Points[(i + 1) % 3], Points[(i + 2) % 3]);
			}
		}
	}

	public void MarkEdge(DelaunayTriangle triangle)
	{
		for (int i = 0; i < 3; i++)
		{
			if (EdgeIsConstrained[i])
			{
				triangle.MarkConstrainedEdge(Points[(i + 1) % 3], Points[(i + 2) % 3]);
			}
		}
	}

	public void MarkEdge(IEnumerable<DelaunayTriangle> tList)
	{
		foreach (DelaunayTriangle t in tList)
		{
			for (int i = 0; i < 3; i++)
			{
				if (t.EdgeIsConstrained[i])
				{
					MarkConstrainedEdge(t.Points[(i + 1) % 3], t.Points[(i + 2) % 3]);
				}
			}
		}
	}

	public void MarkConstrainedEdge(int index)
	{
		fixedArray3_0[index] = true;
	}

	public void MarkConstrainedEdge(DTSweepConstraint edge)
	{
		MarkConstrainedEdge(edge.P, edge.Q);
	}

	public void MarkConstrainedEdge(TriangulationPoint p, TriangulationPoint q)
	{
		int num = EdgeIndex(p, q);
		if (num != -1)
		{
			fixedArray3_0[num] = true;
		}
	}

	public double Area()
	{
		double num = Points[0].X - Points[1].X;
		double num2 = Points[2].Y - Points[1].Y;
		return Math.Abs(num * num2 * 0.5);
	}

	public TriangulationPoint Centroid()
	{
		double x = (Points[0].X + Points[1].X + Points[2].X) / 3.0;
		double y = (Points[0].Y + Points[1].Y + Points[2].Y) / 3.0;
		return new TriangulationPoint(x, y);
	}

	public int EdgeIndex(TriangulationPoint p1, TriangulationPoint p2)
	{
		int num = Points.IndexOf(p1);
		int num2 = Points.IndexOf(p2);
		bool flag = num == 0 || num2 == 0;
		bool flag2 = num == 1 || num2 == 1;
		bool flag3 = num == 2 || num2 == 2;
		if (!(flag2 && flag3))
		{
			if (!(flag && flag3))
			{
				if (!(flag && flag2))
				{
					return -1;
				}
				return 2;
			}
			return 1;
		}
		return 0;
	}

	public bool GetConstrainedEdgeCCW(TriangulationPoint p)
	{
		return EdgeIsConstrained[(IndexOf(p) + 2) % 3];
	}

	public bool GetConstrainedEdgeCW(TriangulationPoint p)
	{
		return EdgeIsConstrained[(IndexOf(p) + 1) % 3];
	}

	public bool GetConstrainedEdgeAcross(TriangulationPoint p)
	{
		return EdgeIsConstrained[IndexOf(p)];
	}

	public void SetConstrainedEdgeCCW(TriangulationPoint p, bool ce)
	{
		int int_ = (IndexOf(p) + 2) % 3;
		Class156.smethod_253(int_, this, ce);
	}

	public void SetConstrainedEdgeCW(TriangulationPoint p, bool ce)
	{
		int int_ = (IndexOf(p) + 1) % 3;
		Class156.smethod_253(int_, this, ce);
	}

	public void SetConstrainedEdgeAcross(TriangulationPoint p, bool ce)
	{
		int int_ = IndexOf(p);
		Class156.smethod_253(int_, this, ce);
	}

	public bool GetDelaunayEdgeCCW(TriangulationPoint p)
	{
		return EdgeIsDelaunay[(IndexOf(p) + 2) % 3];
	}

	public bool GetDelaunayEdgeCW(TriangulationPoint p)
	{
		return EdgeIsDelaunay[(IndexOf(p) + 1) % 3];
	}

	public bool GetDelaunayEdgeAcross(TriangulationPoint p)
	{
		return EdgeIsDelaunay[IndexOf(p)];
	}

	public void SetDelaunayEdgeCCW(TriangulationPoint p, bool ce)
	{
		EdgeIsDelaunay[(IndexOf(p) + 2) % 3] = ce;
	}

	public void SetDelaunayEdgeCW(TriangulationPoint p, bool ce)
	{
		EdgeIsDelaunay[(IndexOf(p) + 1) % 3] = ce;
	}

	public void SetDelaunayEdgeAcross(TriangulationPoint p, bool ce)
	{
		EdgeIsDelaunay[IndexOf(p)] = ce;
	}

	public bool GetEdgeCCW(TriangulationPoint p, out DTSweepConstraint edge)
	{
		int num = IndexOf(p);
		int int_ = (num + 2) % 3;
		return Class156.smethod_280(ref edge, this, int_);
	}

	public bool GetEdgeCW(TriangulationPoint p, out DTSweepConstraint edge)
	{
		int num = IndexOf(p);
		int int_ = (num + 1) % 3;
		return Class156.smethod_280(ref edge, this, int_);
	}

	public bool GetEdgeAcross(TriangulationPoint p, out DTSweepConstraint edge)
	{
		int num = IndexOf(p);
		int int_ = num;
		return Class156.smethod_280(ref edge, this, int_);
	}

	public bool Equals(DelaunayTriangle other)
	{
		return this == other;
	}
}
