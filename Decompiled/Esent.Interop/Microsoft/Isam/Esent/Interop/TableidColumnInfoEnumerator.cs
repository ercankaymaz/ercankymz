namespace Microsoft.Isam.Esent.Interop;

internal sealed class TableidColumnInfoEnumerator : ColumnInfoEnumerator
{
	private readonly JET_TABLEID tableid;

	public TableidColumnInfoEnumerator(JET_SESID sesid, JET_TABLEID tableid)
		: base(sesid)
	{
		this.tableid = tableid;
	}

	protected override void OpenTable()
	{
		Api.JetGetTableColumnInfo(base.Sesid, tableid, string.Empty, out JET_COLUMNLIST columnlist);
		base.Columnlist = columnlist;
		base.TableidToEnumerate = base.Columnlist.tableid;
	}
}
