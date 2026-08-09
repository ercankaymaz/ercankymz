using System.Globalization;

namespace Microsoft.Isam.Esent.Interop;

public class JET_COLUMNLIST
{
	public JET_TABLEID tableid { get; internal set; }

	public int cRecord { get; internal set; }

	public JET_COLUMNID columnidcolumnname { get; internal set; }

	public JET_COLUMNID columnidcolumnid { get; internal set; }

	public JET_COLUMNID columnidcoltyp { get; internal set; }

	public JET_COLUMNID columnidCp { get; internal set; }

	public JET_COLUMNID columnidcbMax { get; internal set; }

	public JET_COLUMNID columnidgrbit { get; internal set; }

	public JET_COLUMNID columnidDefault { get; internal set; }

	public JET_COLUMNID columnidBaseTableName { get; internal set; }

	public override string ToString()
	{
		return string.Format(CultureInfo.InvariantCulture, "JET_COLUMNLIST(0x{0:x},{1} records)", tableid, cRecord);
	}

	internal void SetFromNativeColumnlist(NATIVE_COLUMNLIST value)
	{
		tableid = new JET_TABLEID
		{
			Value = value.tableid
		};
		cRecord = checked((int)value.cRecord);
		columnidcolumnname = new JET_COLUMNID
		{
			Value = value.columnidcolumnname
		};
		columnidcolumnid = new JET_COLUMNID
		{
			Value = value.columnidcolumnid
		};
		columnidcoltyp = new JET_COLUMNID
		{
			Value = value.columnidcoltyp
		};
		columnidCp = new JET_COLUMNID
		{
			Value = value.columnidCp
		};
		columnidcbMax = new JET_COLUMNID
		{
			Value = value.columnidcbMax
		};
		columnidgrbit = new JET_COLUMNID
		{
			Value = value.columnidgrbit
		};
		columnidDefault = new JET_COLUMNID
		{
			Value = value.columnidDefault
		};
		columnidBaseTableName = new JET_COLUMNID
		{
			Value = value.columnidBaseTableName
		};
	}
}
