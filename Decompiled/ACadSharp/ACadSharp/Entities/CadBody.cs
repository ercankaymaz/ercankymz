using ACadSharp.Attributes;

namespace ACadSharp.Entities;

[DxfName("BODY")]
public class CadBody : ModelerGeometry
{
	public override ObjectType ObjectType => ObjectType.BODY;

	public override string ObjectName => "BODY";
}
