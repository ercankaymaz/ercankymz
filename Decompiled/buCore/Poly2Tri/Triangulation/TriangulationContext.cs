using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Poly2Tri.Triangulation.Delaunay;
using Poly2Tri.Triangulation.Delaunay.Sweep;

namespace Poly2Tri.Triangulation;

public abstract class TriangulationContext
{
	[CompilerGenerated]
	private TriangulationDebugContext triangulationDebugContext_0;

	[CompilerGenerated]
	private bool bool_0;

	public readonly List<DelaunayTriangle> Triangles = new List<DelaunayTriangle>();

	public readonly List<TriangulationPoint> Points = new List<TriangulationPoint>(200);

	[CompilerGenerated]
	private TriangulationMode triangulationMode_0;

	[CompilerGenerated]
	private ITriangulatable itriangulatable_0;

	protected TriangulationDebugContext DebugContext
	{
		[CompilerGenerated]
		get
		{
			return triangulationDebugContext_0;
		}
		[CompilerGenerated]
		private set
		{
			triangulationDebugContext_0 = value;
		}
	}

	public bool IsDebugEnabled
	{
		[CompilerGenerated]
		get
		{
			return bool_0;
		}
		[CompilerGenerated]
		protected set
		{
			bool_0 = value;
		}
	}

	public TriangulationMode TriangulationMode
	{
		[CompilerGenerated]
		get
		{
			return triangulationMode_0;
		}
		[CompilerGenerated]
		private set
		{
			triangulationMode_0 = value;
		}
	}

	public ITriangulatable Triangulatable
	{
		[CompilerGenerated]
		get
		{
			return itriangulatable_0;
		}
		[CompilerGenerated]
		private set
		{
			itriangulatable_0 = value;
		}
	}

	public abstract TriangulationAlgorithm Algorithm { get; }

	protected TriangulationContext(TriangulationDebugContext debug)
	{
		DebugContext = debug;
	}

	public virtual void PrepareTriangulation(ITriangulatable t)
	{
		Triangulatable = t;
		TriangulationMode = t.TriangulationMode;
		t.Prepare(this);
	}

	public abstract DTSweepConstraint NewConstraint(TriangulationPoint a, TriangulationPoint b);
}
