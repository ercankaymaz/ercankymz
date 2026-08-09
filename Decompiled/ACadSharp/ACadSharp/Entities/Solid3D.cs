using ACadSharp.Attributes;

namespace ACadSharp.Entities;

[DxfName("3DSOLID")]
[DxfSubClass("AcDb3dSolid")]
public class Solid3D : ModelerGeometry
{
	public override ObjectType ObjectType => ObjectType.SOLID3D;

	public override string ObjectName => "3DSOLID";

	public override string SubclassMarker => "AcDb3dSolid";
}
