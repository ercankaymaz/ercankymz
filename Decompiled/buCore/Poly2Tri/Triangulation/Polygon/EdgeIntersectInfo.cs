using System.Runtime.CompilerServices;
using Poly2Tri.Utility;

namespace Poly2Tri.Triangulation.Polygon;

public class EdgeIntersectInfo
{
	[CompilerGenerated]
	private Edge edge_0;

	[CompilerGenerated]
	private Edge edge_1;

	[CompilerGenerated]
	private Point2D point2D_0;

	public Edge EdgeOne
	{
		[CompilerGenerated]
		get
		{
			return edge_0;
		}
		[CompilerGenerated]
		private set
		{
			edge_0 = value;
		}
	}

	public Edge EdgeTwo
	{
		[CompilerGenerated]
		get
		{
			return edge_1;
		}
		[CompilerGenerated]
		private set
		{
			edge_1 = value;
		}
	}

	public Point2D IntersectionPoint
	{
		[CompilerGenerated]
		get
		{
			return point2D_0;
		}
		[CompilerGenerated]
		private set
		{
			point2D_0 = value;
		}
	}

	public EdgeIntersectInfo(Edge edgeOne, Edge edgeTwo, Point2D intersectionPoint)
	{
		EdgeOne = edgeOne;
		EdgeTwo = edgeTwo;
		IntersectionPoint = intersectionPoint;
	}
}
