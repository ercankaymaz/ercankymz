namespace ACadSharp.Tables.Collections;

public class DimensionStylesTable : Table<DimensionStyle>
{
	public override ObjectType ObjectType => ObjectType.DIMSTYLE_CONTROL_OBJ;

	public override string ObjectName => "DIMSTYLE";

	protected override string[] defaultEntries => new string[1] { "Standard" };

	internal DimensionStylesTable()
	{
	}

	internal DimensionStylesTable(CadDocument document)
		: base(document)
	{
	}
}
