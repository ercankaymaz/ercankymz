using ACadSharp.Attributes;
using CSMath;

namespace ACadSharp.Entities;

[DxfName("VERTEX")]
[DxfSubClass("AcDb3dPolylineVertex")]
public class Vertex3D : Vertex
{
	public override ObjectType ObjectType => ObjectType.VERTEX_3D;

	public override string SubclassMarker => "AcDb3dPolylineVertex";

	public Vertex3D()
	{
	}

	public Vertex3D(XYZ location)
		: base(location)
	{
	}
}
