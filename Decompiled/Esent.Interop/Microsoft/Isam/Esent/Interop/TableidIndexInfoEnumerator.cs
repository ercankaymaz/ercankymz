namespace Microsoft.Isam.Esent.Interop;

internal sealed class TableidIndexInfoEnumerator : IndexInfoEnumerator
{
	private readonly JET_TABLEID tableid;

	public TableidIndexInfoEnumerator(JET_SESID sesid, JET_TABLEID tableid)
		: base(sesid)
	{
		this.tableid = tableid;
	}

	protected override void OpenTable()
	{
		Api.JetGetTableIndexInfo(base.Sesid, tableid, string.Empty, out JET_INDEXLIST result, JET_IdxInfo.List);
		base.Indexlist = result;
		base.TableidToEnumerate = base.Indexlist.tableid;
	}

	protected override void GetIndexInfo(JET_SESID sesid, string indexname, out string result, JET_IdxInfo infoLevel)
	{
		Api.JetGetTableIndexInfo(sesid, tableid, indexname, out result, infoLevel);
	}
}
