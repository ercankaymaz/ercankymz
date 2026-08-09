using ACadSharp.Attributes;
using ACadSharp.Entities;
using ACadSharp.Tables;
using CSMath;

namespace ACadSharp.Blocks;

[DxfName("BLOCK")]
[DxfSubClass("AcDbBlockBegin")]
public class Block : Entity
{
	[DxfCodeValue(new int[] { 10, 20, 30 })]
	public XYZ BasePoint { get; set; } = XYZ.Zero;

	public BlockRecord BlockOwner => base.Owner as BlockRecord;

	[DxfCodeValue(new int[] { 4 })]
	public string Comments { get; set; }

	[DxfCodeValue(new int[] { 70 })]
	public BlockTypeFlags Flags { get; set; }

	[DxfCodeValue(new int[] { 71 })]
	public bool IsUnloaded { get; set; }

	[DxfCodeValue(new int[] { 2, 3 })]
	public string Name
	{
		get
		{
			return BlockOwner.Name;
		}
		set
		{
			BlockOwner.Name = value;
		}
	}

	public override string ObjectName => "BLOCK";

	public override ObjectType ObjectType => ObjectType.BLOCK;

	public override string SubclassMarker => "AcDbBlockBegin";

	[DxfCodeValue(new int[] { 1 })]
	public string XRefPath { get; set; }

	public Block(BlockRecord record)
	{
		base.Owner = record;
	}

	internal Block()
	{
	}

	public override void ApplyTransform(Transform transform)
	{
	}

	public override CadObject Clone()
	{
		Block obj = (Block)base.Clone();
		obj.Owner = new BlockRecord(Name);
		return obj;
	}

	public override BoundingBox GetBoundingBox()
	{
		BoundingBox result = BoundingBox.Null;
		foreach (Entity entity in BlockOwner.Entities)
		{
			result = result.Merge(entity.GetBoundingBox());
		}
		return result;
	}
}
