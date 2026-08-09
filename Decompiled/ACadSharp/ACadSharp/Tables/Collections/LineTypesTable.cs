namespace ACadSharp.Tables.Collections;

public class LineTypesTable : Table<LineType>
{
	public override ObjectType ObjectType => ObjectType.LTYPE_CONTROL_OBJ;

	public override string ObjectName => "LTYPE";

	public LineType ByLayer => base["ByLayer"];

	public LineType ByBlock => base["ByBlock"];

	public LineType Continuous => base["Continuous"];

	protected override string[] defaultEntries => new string[3] { "ByLayer", "ByBlock", "Continuous" };

	internal LineTypesTable()
	{
	}

	internal LineTypesTable(CadDocument document)
		: base(document)
	{
	}
}
