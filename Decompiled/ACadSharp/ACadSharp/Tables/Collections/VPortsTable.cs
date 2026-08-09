namespace ACadSharp.Tables.Collections;

public class VPortsTable : Table<VPort>
{
	public override ObjectType ObjectType => ObjectType.VPORT_CONTROL_OBJ;

	public override string ObjectName => "VPORT";

	protected override string[] defaultEntries => new string[1] { "*Active" };

	internal VPortsTable()
	{
	}

	internal VPortsTable(CadDocument document)
		: base(document)
	{
	}

	public override void Add(VPort item)
	{
		if (Contains(item.Name))
		{
			addHandlePrefix(item);
		}
		else
		{
			add(item.Name, item);
		}
	}
}
