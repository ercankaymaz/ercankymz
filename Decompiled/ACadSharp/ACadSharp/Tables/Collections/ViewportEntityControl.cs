namespace ACadSharp.Tables.Collections;

internal class ViewportEntityControl : Table<ViewportEntityHeader>
{
	public override ObjectType ObjectType => ObjectType.VP_ENT_HDR_CTRL_OBJ;

	protected override string[] defaultEntries { get; }

	public ViewportEntityControl(CadDocument document)
		: base(document)
	{
	}
}
