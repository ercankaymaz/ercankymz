using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Poly2Tri.Triangulation.Delaunay.Sweep;
using Poly2Tri.Utility;

namespace Poly2Tri.Triangulation;

public class TriangulationPoint : Point2D, IEquatable<TriangulationPoint>
{
	[CompilerGenerated]
	private sealed class Class127
	{
		public TriangulationPoint triangulationPoint_0;

		public TriangulationPoint triangulationPoint_1;

		public Func<DTSweepConstraint, bool> func_0;

		internal bool method_0(DTSweepConstraint dtsweepConstraint_0)
		{
			return (dtsweepConstraint_0.P.Equals(triangulationPoint_0) && dtsweepConstraint_0.Q.Equals(triangulationPoint_1)) || (dtsweepConstraint_0.P.Equals(triangulationPoint_1) && dtsweepConstraint_0.Q.Equals(triangulationPoint_0));
		}
	}

	public const double VERTEX_CODE_DEFAULT_PRECISION = 3.0;

	[CompilerGenerated]
	private uint uint_0;

	[CompilerGenerated]
	private List<DTSweepConstraint> list_0;

	public override double X
	{
		get
		{
			return base.X;
		}
		set
		{
			if (value != base.X)
			{
				base.X = value;
				VertexCode = CreateVertexCode(base.X, base.Y, 3.0);
			}
		}
	}

	public override double Y
	{
		get
		{
			return base.Y;
		}
		set
		{
			if (value != base.Y)
			{
				base.Y = value;
				VertexCode = CreateVertexCode(base.X, base.Y, 3.0);
			}
		}
	}

	public uint VertexCode
	{
		[CompilerGenerated]
		get
		{
			return uint_0;
		}
		[CompilerGenerated]
		private set
		{
			uint_0 = value;
		}
	}

	public List<DTSweepConstraint> Edges
	{
		[CompilerGenerated]
		get
		{
			return list_0;
		}
		[CompilerGenerated]
		private set
		{
			list_0 = value;
		}
	}

	public bool HasEdges => Edges != null;

	public TriangulationPoint(double x, double y, double precision = 3.0)
		: base(x, y)
	{
		VertexCode = CreateVertexCode(x, y, precision);
	}

	public override string ToString()
	{
		return base.ToString() + ":{" + VertexCode + "}";
	}

	public override int GetHashCode()
	{
		return (int)VertexCode;
	}

	public override bool Equals(object obj)
	{
		return Equals(obj as TriangulationPoint);
	}

	public bool Equals(TriangulationPoint other)
	{
		if (other != null)
		{
			return VertexCode == other.VertexCode && Equals(other, 0.0);
		}
		return false;
	}

	public override void Set(double x, double y)
	{
		X = x;
		Y = y;
	}

	public static uint CreateVertexCode(double x, double y, double precision)
	{
		float value = (float)MathUtil.RoundWithPrecision(x, precision);
		float value2 = (float)MathUtil.RoundWithPrecision(y, precision);
		uint nInitialValue = MathUtil.Jenkins32Hash(BitConverter.GetBytes(value), 0u);
		return MathUtil.Jenkins32Hash(BitConverter.GetBytes(value2), nInitialValue);
	}

	public void AddEdge(DTSweepConstraint e)
	{
		if (Edges == null)
		{
			Edges = new List<DTSweepConstraint>();
		}
		Edges.Add(e);
	}

	public bool HasEdge(TriangulationPoint p)
	{
		DTSweepConstraint edge;
		return GetEdge(p, out edge);
	}

	public bool GetEdge(TriangulationPoint p, out DTSweepConstraint edge)
	{
		edge = null;
		if (Edges != null && Edges.Count >= 1 && p != null && !p.Equals(this))
		{
			using (IEnumerator<DTSweepConstraint> enumerator = Edges.Where((DTSweepConstraint dtsweepConstraint_0) => (dtsweepConstraint_0.P.Equals(this) && dtsweepConstraint_0.Q.Equals(p)) || (dtsweepConstraint_0.P.Equals(p) && dtsweepConstraint_0.Q.Equals(this))).GetEnumerator())
			{
				if (enumerator.MoveNext())
				{
					DTSweepConstraint current = enumerator.Current;
					edge = current;
					return true;
				}
			}
			return false;
		}
		return false;
	}
}
