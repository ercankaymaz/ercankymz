namespace ACadSharp.Tables.Collections;

public class AppIdsTable : Table<AppId>
{
	public override ObjectType ObjectType => ObjectType.APPID_CONTROL_OBJ;

	public override string ObjectName => "APPID";

	protected override string[] defaultEntries => new string[1] { "ACAD" };

	internal AppIdsTable()
	{
	}

	internal AppIdsTable(CadDocument document)
		: base(document)
	{
	}
}
