namespace ACadSharp.Tables;

internal class ViewportEntityHeader : TableEntry
{
	public override ObjectType ObjectType => ObjectType.VP_ENT_HDR;

	public override string Name
	{
		get
		{
			return name;
		}
		set
		{
			name = value;
		}
	}
}
