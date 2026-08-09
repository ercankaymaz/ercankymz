using ACadSharp.Attributes;

namespace ACadSharp.Entities;

[DxfName("VERTEX")]
[DxfSubClass("AcDbFaceRecord")]
public class VertexFaceRecord : Vertex
{
	public override ObjectType ObjectType => ObjectType.VERTEX_PFACE_FACE;

	public override string SubclassMarker => "AcDbFaceRecord";

	[DxfCodeValue(new int[] { 71 })]
	public short Index1 { get; set; }

	[DxfCodeValue(new int[] { 72 })]
	public short Index2 { get; set; }

	[DxfCodeValue(new int[] { 73 })]
	public short Index3 { get; set; }

	[DxfCodeValue(new int[] { 74 })]
	public short Index4 { get; set; }
}
