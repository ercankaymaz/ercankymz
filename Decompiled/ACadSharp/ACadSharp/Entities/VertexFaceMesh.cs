using ACadSharp.Attributes;

namespace ACadSharp.Entities;

[DxfName("VERTEX")]
[DxfSubClass("AcDbPolyFaceMeshVertex")]
public class VertexFaceMesh : Vertex
{
	public override ObjectType ObjectType => ObjectType.VERTEX_PFACE;

	public override string SubclassMarker => "AcDbPolyFaceMeshVertex";
}
