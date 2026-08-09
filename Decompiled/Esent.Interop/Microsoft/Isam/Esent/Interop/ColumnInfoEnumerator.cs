using System.Text;

namespace Microsoft.Isam.Esent.Interop;

internal abstract class ColumnInfoEnumerator : TableEnumerator<ColumnInfo>
{
	protected JET_COLUMNLIST Columnlist { get; set; }

	protected ColumnInfoEnumerator(JET_SESID sesid)
		: base(sesid)
	{
	}

	protected override ColumnInfo GetCurrent()
	{
		return GetColumnInfoFromColumnlist(base.Sesid, Columnlist);
	}

	private static ColumnInfo GetColumnInfoFromColumnlist(JET_SESID sesid, JET_COLUMNLIST columnlist)
	{
		Encoding encoding = (EsentVersion.SupportsWindows8Features ? Encoding.Unicode : LibraryHelpers.EncodingASCII);
		string name = StringCache.TryToIntern(Api.RetrieveColumnAsString(sesid, columnlist.tableid, columnlist.columnidcolumnname, encoding, RetrieveColumnGrbit.None));
		uint value = Api.RetrieveColumnAsUInt32(sesid, columnlist.tableid, columnlist.columnidcolumnid).Value;
		uint value2 = Api.RetrieveColumnAsUInt32(sesid, columnlist.tableid, columnlist.columnidcoltyp).Value;
		uint value3 = Api.RetrieveColumnAsUInt16(sesid, columnlist.tableid, columnlist.columnidCp).Value;
		return new ColumnInfo(maxLength: (int)Api.RetrieveColumnAsUInt32(sesid, columnlist.tableid, columnlist.columnidcbMax).Value, defaultValue: Api.RetrieveColumn(sesid, columnlist.tableid, columnlist.columnidDefault), grbit: (ColumndefGrbit)checked((int)Api.RetrieveColumnAsUInt32(sesid, columnlist.tableid, columnlist.columnidgrbit).Value), name: name, columnid: new JET_COLUMNID
		{
			Value = value
		}, coltyp: (JET_coltyp)checked((int)value2), cp: (JET_CP)checked((int)value3));
	}
}
