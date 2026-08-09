namespace ACadSharp.Tables.Collections;

public class LayersTable : Table<Layer>
{
	public override ObjectType ObjectType => ObjectType.LAYER_CONTROL_OBJ;

	public override string ObjectName => "LAYER";

	protected override string[] defaultEntries => new string[1] { "0" };

	internal LayersTable()
	{
	}

	internal LayersTable(CadDocument document)
		: base(document)
	{
	}
}
