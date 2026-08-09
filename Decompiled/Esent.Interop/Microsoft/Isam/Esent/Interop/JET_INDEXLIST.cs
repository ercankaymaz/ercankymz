using System.Globalization;

namespace Microsoft.Isam.Esent.Interop;

public sealed class JET_INDEXLIST
{
	public JET_TABLEID tableid { get; internal set; }

	public int cRecord { get; internal set; }

	public JET_COLUMNID columnidindexname { get; internal set; }

	public JET_COLUMNID columnidgrbitIndex { get; internal set; }

	public JET_COLUMNID columnidcKey { get; internal set; }

	public JET_COLUMNID columnidcEntry { get; internal set; }

	public JET_COLUMNID columnidcPage { get; internal set; }

	public JET_COLUMNID columnidcColumn { get; internal set; }

	public JET_COLUMNID columnidiColumn { get; internal set; }

	public JET_COLUMNID columnidcolumnid { get; internal set; }

	public JET_COLUMNID columnidcoltyp { get; internal set; }

	public JET_COLUMNID columnidLangid { get; internal set; }

	public JET_COLUMNID columnidCp { get; internal set; }

	public JET_COLUMNID columnidgrbitColumn { get; internal set; }

	public JET_COLUMNID columnidcolumnname { get; internal set; }

	public JET_COLUMNID columnidLCMapFlags { get; internal set; }

	public override string ToString()
	{
		return string.Format(CultureInfo.InvariantCulture, "JET_INDEXLIST(0x{0:x},{1} records)", tableid, cRecord);
	}

	internal void SetFromNativeIndexlist(NATIVE_INDEXLIST value)
	{
		tableid = new JET_TABLEID
		{
			Value = value.tableid
		};
		cRecord = checked((int)value.cRecord);
		columnidindexname = new JET_COLUMNID
		{
			Value = value.columnidindexname
		};
		columnidgrbitIndex = new JET_COLUMNID
		{
			Value = value.columnidgrbitIndex
		};
		columnidcKey = new JET_COLUMNID
		{
			Value = value.columnidcKey
		};
		columnidcEntry = new JET_COLUMNID
		{
			Value = value.columnidcEntry
		};
		columnidcPage = new JET_COLUMNID
		{
			Value = value.columnidcPage
		};
		columnidcColumn = new JET_COLUMNID
		{
			Value = value.columnidcColumn
		};
		columnidiColumn = new JET_COLUMNID
		{
			Value = value.columnidiColumn
		};
		columnidcolumnid = new JET_COLUMNID
		{
			Value = value.columnidcolumnid
		};
		columnidcoltyp = new JET_COLUMNID
		{
			Value = value.columnidcoltyp
		};
		columnidLangid = new JET_COLUMNID
		{
			Value = value.columnidLangid
		};
		columnidCp = new JET_COLUMNID
		{
			Value = value.columnidCp
		};
		columnidgrbitColumn = new JET_COLUMNID
		{
			Value = value.columnidgrbitColumn
		};
		columnidcolumnname = new JET_COLUMNID
		{
			Value = value.columnidcolumnname
		};
		columnidLCMapFlags = new JET_COLUMNID
		{
			Value = value.columnidLCMapFlags
		};
	}
}
