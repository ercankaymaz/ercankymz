using System.Text;

namespace Microsoft.Isam.Esent.Interop;

internal sealed class TableNameEnumerator : TableEnumerator<string>
{
	private readonly JET_DBID dbid;

	private JET_OBJECTLIST objectlist;

	public TableNameEnumerator(JET_SESID sesid, JET_DBID dbid)
		: base(sesid)
	{
		this.dbid = dbid;
	}

	protected override void OpenTable()
	{
		Api.JetGetObjectInfo(base.Sesid, dbid, out objectlist);
		base.TableidToEnumerate = objectlist.tableid;
	}

	protected override bool SkipCurrent()
	{
		int value = Api.RetrieveColumnAsInt32(base.Sesid, base.TableidToEnumerate, objectlist.columnidflags).Value;
		return int.MinValue == (value & int.MinValue);
	}

	protected override string GetCurrent()
	{
		Encoding encoding = (EsentVersion.SupportsVistaFeatures ? Encoding.Unicode : LibraryHelpers.EncodingASCII);
		return StringCache.TryToIntern(Api.RetrieveColumnAsString(base.Sesid, base.TableidToEnumerate, objectlist.columnidobjectname, encoding, RetrieveColumnGrbit.None));
	}
}
