using System;

namespace ACadSharp.Tables.Collections;

public class BlockRecordsTable : Table<BlockRecord>
{
	public override ObjectType ObjectType => ObjectType.BLOCK_CONTROL_OBJ;

	public override string ObjectName => "BLOCK_RECORD";

	protected override string[] defaultEntries => new string[2] { "*Model_Space", "*Paper_Space" };

	internal BlockRecordsTable()
	{
	}

	internal BlockRecordsTable(CadDocument document)
		: base(document)
	{
	}

	public override void Add(BlockRecord item)
	{
		if (item.IsAnonymous && Contains(item.Name))
		{
			if (base[item.Name].Equals(item))
			{
				throw new ArgumentException("The BlockRecord with name " + item.Name + " has already been added.");
			}
			item.Name = createName("*A");
		}
		base.Add(item);
	}
}
