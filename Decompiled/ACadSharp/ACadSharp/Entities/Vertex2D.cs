using ACadSharp.Attributes;
using CSMath;

namespace ACadSharp.Entities;

[DxfName("VERTEX")]
[DxfSubClass("AcDb2dVertex")]
public class Vertex2D : Vertex
{
	public override ObjectType ObjectType => ObjectType.VERTEX_2D;

	public override string SubclassMarker => "AcDb2dVertex";

	public Vertex2D()
	{
	}

	public Vertex2D(IVector location)
	{
		base.Location = location.Convert<XYZ>();
	}
}
