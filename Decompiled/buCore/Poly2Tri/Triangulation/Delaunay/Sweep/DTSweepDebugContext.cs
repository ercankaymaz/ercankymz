using System.Runtime.CompilerServices;

namespace Poly2Tri.Triangulation.Delaunay.Sweep;

public class DTSweepDebugContext : TriangulationDebugContext
{
	[CompilerGenerated]
	private DelaunayTriangle delaunayTriangle_0;

	[CompilerGenerated]
	private DelaunayTriangle delaunayTriangle_1;

	[CompilerGenerated]
	private TriangulationPoint triangulationPoint_0;

	[CompilerGenerated]
	private AdvancingFrontNode advancingFrontNode_0;

	[CompilerGenerated]
	private DTSweepConstraint dtsweepConstraint_0;

	public DelaunayTriangle PrimaryTriangle
	{
		[CompilerGenerated]
		get
		{
			return delaunayTriangle_0;
		}
		[CompilerGenerated]
		set
		{
			delaunayTriangle_0 = value;
		}
	}

	public DelaunayTriangle SecondaryTriangle
	{
		[CompilerGenerated]
		get
		{
			return delaunayTriangle_1;
		}
		[CompilerGenerated]
		set
		{
			delaunayTriangle_1 = value;
		}
	}

	public TriangulationPoint ActivePoint
	{
		[CompilerGenerated]
		get
		{
			return triangulationPoint_0;
		}
		[CompilerGenerated]
		set
		{
			triangulationPoint_0 = value;
		}
	}

	public AdvancingFrontNode ActiveNode
	{
		[CompilerGenerated]
		get
		{
			return advancingFrontNode_0;
		}
		[CompilerGenerated]
		set
		{
			advancingFrontNode_0 = value;
		}
	}

	public DTSweepConstraint ActiveConstraint
	{
		[CompilerGenerated]
		get
		{
			return dtsweepConstraint_0;
		}
		[CompilerGenerated]
		set
		{
			dtsweepConstraint_0 = value;
		}
	}

	public bool IsDebugContext => true;

	public override void Clear()
	{
		PrimaryTriangle = null;
		SecondaryTriangle = null;
		ActivePoint = null;
		ActiveNode = null;
		ActiveConstraint = null;
	}
}
