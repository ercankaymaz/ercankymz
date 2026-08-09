namespace ACadSharp.Tables.Collections;

public class UCSTable : Table<UCS>
{
	public override ObjectType ObjectType => ObjectType.UCS_CONTROL_OBJ;

	public override string ObjectName => "UCS";

	protected override string[] defaultEntries => new string[0];

	internal UCSTable()
	{
	}

	internal UCSTable(CadDocument document)
		: base(document)
	{
	}
}
