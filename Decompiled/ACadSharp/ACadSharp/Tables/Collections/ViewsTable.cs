namespace ACadSharp.Tables.Collections;

public class ViewsTable : Table<View>
{
	public override ObjectType ObjectType => ObjectType.VIEW_CONTROL_OBJ;

	public override string ObjectName => "VIEW";

	protected override string[] defaultEntries => new string[0];

	internal ViewsTable()
	{
	}

	internal ViewsTable(CadDocument document)
		: base(document)
	{
	}
}
