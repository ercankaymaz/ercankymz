namespace Microsoft.Isam.Esent.Interop;

internal sealed class TableColumnInfoEnumerator : ColumnInfoEnumerator
{
	private readonly JET_DBID dbid;

	private readonly string tablename;

	public TableColumnInfoEnumerator(JET_SESID sesid, JET_DBID dbid, string tablename)
		: base(sesid)
	{
		this.dbid = dbid;
		this.tablename = tablename;
	}

	protected override void OpenTable()
	{
		Api.JetGetColumnInfo(base.Sesid, dbid, tablename, string.Empty, out JET_COLUMNLIST columnlist);
		base.Columnlist = columnlist;
		base.TableidToEnumerate = base.Columnlist.tableid;
	}
}
