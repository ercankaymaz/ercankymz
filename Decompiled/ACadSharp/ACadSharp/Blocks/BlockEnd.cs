using ACadSharp.Attributes;
using ACadSharp.Entities;
using ACadSharp.Tables;
using CSMath;

namespace ACadSharp.Blocks;

[DxfName("ENDBLK")]
[DxfSubClass("AcDbBlockEnd")]
public class BlockEnd : Entity
{
	public override string ObjectName => "ENDBLK";

	public override ObjectType ObjectType => ObjectType.ENDBLK;

	public override string SubclassMarker => "AcDbBlockEnd";

	public BlockEnd(BlockRecord record)
	{
		base.Owner = record;
	}

	public override CadObject Clone()
	{
		BlockEnd obj = (BlockEnd)base.Clone();
		obj.Owner = new BlockRecord((base.Owner as BlockRecord).Name);
		return obj;
	}

	public override BoundingBox GetBoundingBox()
	{
		return BoundingBox.Null;
	}

	public override void ApplyTransform(Transform transform)
	{
	}
}
