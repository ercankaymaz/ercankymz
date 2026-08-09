using System;
using System.Runtime.CompilerServices;
using Poly2Tri.Utility;

namespace Poly2Tri.Triangulation;

public class TriangulationConstraint : Edge
{
	[CompilerGenerated]
	private uint uint_0;

	public TriangulationPoint P
	{
		get
		{
			return base.EdgeStart as TriangulationPoint;
		}
		set
		{
			if (value != null && !value.Equals(base.EdgeStart))
			{
				base.EdgeStart = value;
				CalculateContraintCode();
			}
		}
	}

	public TriangulationPoint Q
	{
		get
		{
			return base.EdgeEnd as TriangulationPoint;
		}
		set
		{
			if (value != null && !value.Equals(base.EdgeEnd))
			{
				base.EdgeEnd = value;
				CalculateContraintCode();
			}
		}
	}

	public uint ConstraintCode
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

	public TriangulationConstraint(Point2D p1, Point2D p2)
	{
		ConstraintCode = 0u;
		base.EdgeStart = p1;
		base.EdgeEnd = p2;
		if (!(p1.Y > p2.Y))
		{
			if (p1.Y == p2.Y)
			{
				if (!(p1.X > p2.X))
				{
					if (p1.X != p2.X)
					{
					}
				}
				else
				{
					base.EdgeEnd = p1;
					base.EdgeStart = p2;
				}
			}
		}
		else
		{
			base.EdgeEnd = p1;
			base.EdgeStart = p2;
		}
		CalculateContraintCode();
	}

	public override string ToString()
	{
		return $"[P={P}, Q={Q} : {{{ConstraintCode}}}]";
	}

	public void CalculateContraintCode()
	{
		ConstraintCode = CalculateContraintCode(P, Q);
	}

	public static uint CalculateContraintCode(TriangulationPoint p, TriangulationPoint q)
	{
		if (p == null || p == null)
		{
			throw new ArgumentNullException();
		}
		uint nInitialValue = MathUtil.Jenkins32Hash(BitConverter.GetBytes(p.VertexCode), 0u);
		return MathUtil.Jenkins32Hash(BitConverter.GetBytes(q.VertexCode), nInitialValue);
	}
}
