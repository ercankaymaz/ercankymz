using System.Runtime.CompilerServices;

namespace Poly2Tri.Triangulation.Polygon;

public class PolygonPoint : TriangulationPoint
{
	[CompilerGenerated]
	private PolygonPoint polygonPoint_0;

	[CompilerGenerated]
	private PolygonPoint polygonPoint_1;

	public PolygonPoint Next
	{
		[CompilerGenerated]
		get
		{
			return polygonPoint_0;
		}
		[CompilerGenerated]
		set
		{
			polygonPoint_0 = value;
		}
	}

	public PolygonPoint Previous
	{
		[CompilerGenerated]
		get
		{
			return polygonPoint_1;
		}
		[CompilerGenerated]
		set
		{
			polygonPoint_1 = value;
		}
	}

	public PolygonPoint(double x, double y)
		: base(x, y)
	{
	}
}
