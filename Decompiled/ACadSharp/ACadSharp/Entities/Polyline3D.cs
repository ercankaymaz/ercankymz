using System.Collections.Generic;
using System.Linq;
using ACadSharp.Attributes;
using CSMath;

namespace ACadSharp.Entities;

[DxfName("POLYLINE")]
[DxfSubClass("AcDb3dPolyline")]
public class Polyline3D : Polyline<Vertex3D>
{
	public override ObjectType ObjectType => ObjectType.POLYLINE_3D;

	public override string SubclassMarker => "AcDb3dPolyline";

	public Polyline3D()
	{
	}

	public Polyline3D(IEnumerable<XYZ> vertices, bool isClosed = false)
		: base(vertices.Select((XYZ v) => new Vertex3D(v)), isClosed)
	{
	}

	public Polyline3D(IEnumerable<Vertex3D> vertices, bool isClosed = false)
		: base(vertices, isClosed)
	{
	}

	public Polyline3D(params IEnumerable<XYZ> vertices)
		: base(vertices.Select((XYZ v) => new Vertex3D(v)), false)
	{
	}
}
