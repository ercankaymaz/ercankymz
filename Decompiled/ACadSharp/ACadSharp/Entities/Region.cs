using ACadSharp.Attributes;

namespace ACadSharp.Entities;

[DxfName("REGION")]
public class Region : ModelerGeometry
{
	public override ObjectType ObjectType => ObjectType.REGION;

	public override string ObjectName => "REGION";
}
