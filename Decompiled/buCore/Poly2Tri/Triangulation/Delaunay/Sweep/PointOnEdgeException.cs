using System;
using System.Runtime.CompilerServices;

namespace Poly2Tri.Triangulation.Delaunay.Sweep;

public class PointOnEdgeException : NotImplementedException
{
	[CompilerGenerated]
	private TriangulationPoint triangulationPoint_0;

	[CompilerGenerated]
	private TriangulationPoint triangulationPoint_1;

	[CompilerGenerated]
	private TriangulationPoint triangulationPoint_2;

	public TriangulationPoint A
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

	public TriangulationPoint B
	{
		[CompilerGenerated]
		get
		{
			return triangulationPoint_1;
		}
		[CompilerGenerated]
		set
		{
			triangulationPoint_1 = value;
		}
	}

	public TriangulationPoint C
	{
		[CompilerGenerated]
		get
		{
			return triangulationPoint_2;
		}
		[CompilerGenerated]
		set
		{
			triangulationPoint_2 = value;
		}
	}

	public PointOnEdgeException(string message, TriangulationPoint a, TriangulationPoint b, TriangulationPoint c)
		: base(message)
	{
		A = a;
		B = b;
		C = c;
	}
}
