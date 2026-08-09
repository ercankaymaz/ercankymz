namespace ACadSharp.Tables.Collections;

public class TextStylesTable : Table<TextStyle>
{
	public override ObjectType ObjectType => ObjectType.STYLE_CONTROL_OBJ;

	public override string ObjectName => "STYLE";

	protected override string[] defaultEntries => new string[1] { "Standard" };

	internal TextStylesTable()
	{
	}

	internal TextStylesTable(CadDocument document)
		: base(document)
	{
	}
}
