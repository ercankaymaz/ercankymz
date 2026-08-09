using System.Globalization;

namespace Microsoft.Isam.Esent.Interop;

public class JET_OBJECTLIST
{
	public JET_TABLEID tableid { get; internal set; }

	public int cRecord { get; internal set; }

	public JET_COLUMNID columnidobjectname { get; internal set; }

	public JET_COLUMNID columnidobjtyp { get; internal set; }

	public JET_COLUMNID columnidgrbit { get; internal set; }

	public JET_COLUMNID columnidflags { get; internal set; }

	public JET_COLUMNID columnidcRecord { get; internal set; }

	public JET_COLUMNID columnidcontainername { get; internal set; }

	public JET_COLUMNID columnidcPage { get; internal set; }

	public override string ToString()
	{
		return string.Format(CultureInfo.InvariantCulture, "JET_OBJECTLIST(0x{0:x},{1} records)", tableid, cRecord);
	}

	internal void SetFromNativeObjectlist(NATIVE_OBJECTLIST value)
	{
		tableid = new JET_TABLEID
		{
			Value = value.tableid
		};
		cRecord = checked((int)value.cRecord);
		columnidobjectname = new JET_COLUMNID
		{
			Value = value.columnidobjectname
		};
		columnidobjtyp = new JET_COLUMNID
		{
			Value = value.columnidobjtyp
		};
		columnidgrbit = new JET_COLUMNID
		{
			Value = value.columnidgrbit
		};
		columnidflags = new JET_COLUMNID
		{
			Value = value.columnidflags
		};
		columnidcRecord = new JET_COLUMNID
		{
			Value = value.columnidcRecord
		};
		columnidcPage = new JET_COLUMNID
		{
			Value = value.columnidcPage
		};
		columnidcontainername = new JET_COLUMNID
		{
			Value = value.columnidcontainername
		};
	}
}
