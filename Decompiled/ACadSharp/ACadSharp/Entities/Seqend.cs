using ACadSharp.Attributes;
using CSMath;

namespace ACadSharp.Entities;

[DxfName("SEQEND")]
public class Seqend : Entity
{
	public override ObjectType ObjectType => ObjectType.SEQEND;

	public override string ObjectName => "SEQEND";

	public Seqend()
	{
	}

	internal Seqend(CadObject owner)
	{
		base.Owner = owner;
	}

	public override BoundingBox GetBoundingBox()
	{
		return BoundingBox.Null;
	}

	public override void ApplyTransform(Transform transform)
	{
	}
}
