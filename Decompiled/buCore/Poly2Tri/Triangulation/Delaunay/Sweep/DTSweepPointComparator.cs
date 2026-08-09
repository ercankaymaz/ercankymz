using System.Collections.Generic;

namespace Poly2Tri.Triangulation.Delaunay.Sweep;

public class DTSweepPointComparator : IComparer<TriangulationPoint>
{
	public int Compare(TriangulationPoint p1, TriangulationPoint p2)
	{
		if (!(p1.Y < p2.Y))
		{
			if (!(p1.Y > p2.Y))
			{
				if (!(p1.X < p2.X))
				{
					if (!(p1.X > p2.X))
					{
						return 0;
					}
					return 1;
				}
				return -1;
			}
			return 1;
		}
		return -1;
	}
}
