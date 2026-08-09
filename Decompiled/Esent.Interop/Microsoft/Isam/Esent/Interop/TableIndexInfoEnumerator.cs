namespace Microsoft.Isam.Esent.Interop;

internal sealed class TableIndexInfoEnumerator : IndexInfoEnumerator
{
	private readonly JET_DBID dbid;

	private readonly string tablename;

	public TableIndexInfoEnumerator(JET_SESID sesid, JET_DBID dbid, string tablename)
		: base(sesid)
	{
		this.dbid = dbid;
		this.tablename = tablename;
	}

	protected override void OpenTable()
	{
		Api.JetGetIndexInfo(base.Sesid, dbid, tablename, string.Empty, out JET_INDEXLIST result, JET_IdxInfo.List);
		base.Indexlist = result;
		base.TableidToEnumerate = base.Indexlist.tableid;
	}

	protected override void GetIndexInfo(JET_SESID sesid, string indexname, out string result, JET_IdxInfo infoLevel)
	{
		Api.JetGetIndexInfo(sesid, dbid, tablename, indexname, out result, infoLevel);
	}
}
