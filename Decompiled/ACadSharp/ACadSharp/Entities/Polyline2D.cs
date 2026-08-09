using System.Collections.Generic;
using ACadSharp.Attributes;

namespace ACadSharp.Entities;

[DxfName("POLYLINE")]
[DxfSubClass("AcDb2dPolyline")]
public class Polyline2D : Polyline<Vertex2D>
{
	public override ObjectType ObjectType => ObjectType.POLYLINE_2D;

	public override string SubclassMarker => "AcDb2dPolyline";

	public Polyline2D()
	{
	}

	public Polyline2D(IEnumerable<Vertex2D> vertices, bool isClosed)
		: base(vertices, isClosed)
	{
	}
}
