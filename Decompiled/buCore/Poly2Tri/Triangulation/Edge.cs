using System.Runtime.CompilerServices;
using Poly2Tri.Utility;

namespace Poly2Tri.Triangulation;

public class Edge
{
	[CompilerGenerated]
	private Point2D point2D_0;

	[CompilerGenerated]
	private Point2D point2D_1;

	public Point2D EdgeStart
	{
		[CompilerGenerated]
		get
		{
			return point2D_0;
		}
		[CompilerGenerated]
		set
		{
			point2D_0 = value;
		}
	}

	public Point2D EdgeEnd
	{
		[CompilerGenerated]
		get
		{
			return point2D_1;
		}
		[CompilerGenerated]
		set
		{
			point2D_1 = value;
		}
	}

	public Edge()
	{
		EdgeStart = null;
		EdgeEnd = null;
	}

	public Edge(Point2D edgeStart, Point2D edgeEnd)
	{
		EdgeStart = edgeStart;
		EdgeEnd = edgeEnd;
	}
}
