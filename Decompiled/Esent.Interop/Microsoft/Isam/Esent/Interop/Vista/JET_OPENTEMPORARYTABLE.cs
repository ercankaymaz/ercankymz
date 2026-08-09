using System;
using System.Globalization;
using System.Runtime.InteropServices;

namespace Microsoft.Isam.Esent.Interop.Vista;

public class JET_OPENTEMPORARYTABLE
{
	public JET_COLUMNDEF[] prgcolumndef { get; set; }

	public int ccolumn { get; set; }

	public JET_UNICODEINDEX pidxunicode { get; set; }

	public TempTableGrbit grbit { get; set; }

	public JET_COLUMNID[] prgcolumnid { get; set; }

	public int cbKeyMost { get; set; }

	public int cbVarSegMac { get; set; }

	public JET_TABLEID tableid { get; internal set; }

	public override string ToString()
	{
		return string.Format(CultureInfo.InvariantCulture, "JET_OPENTEMPORARYTABLE({0}, {1} columns)", grbit, ccolumn);
	}

	internal NATIVE_OPENTEMPORARYTABLE GetNativeOpenTemporaryTable()
	{
		CheckDataSize();
		return checked(new NATIVE_OPENTEMPORARYTABLE
		{
			cbStruct = (uint)Marshal.SizeOf(typeof(NATIVE_OPENTEMPORARYTABLE)),
			ccolumn = (uint)ccolumn,
			grbit = (uint)grbit,
			cbKeyMost = (uint)cbKeyMost,
			cbVarSegMac = (uint)cbVarSegMac
		});
	}

	private void CheckDataSize()
	{
		if (prgcolumndef == null)
		{
			throw new ArgumentNullException("prgcolumndef");
		}
		if (prgcolumnid == null)
		{
			throw new ArgumentNullException("prgcolumnid");
		}
		if (ccolumn < 0)
		{
			throw new ArgumentOutOfRangeException("ccolumn", ccolumn, "cannot be negative");
		}
		if (ccolumn > prgcolumndef.Length)
		{
			throw new ArgumentOutOfRangeException("ccolumn", ccolumn, "cannot be greater than prgcolumndef.Length");
		}
		if (ccolumn > prgcolumnid.Length)
		{
			throw new ArgumentOutOfRangeException("ccolumn", ccolumn, "cannot be greater than prgcolumnid.Length");
		}
	}

	internal NATIVE_OPENTEMPORARYTABLE2 GetNativeOpenTemporaryTable2()
	{
		CheckDataSize();
		return checked(new NATIVE_OPENTEMPORARYTABLE2
		{
			cbStruct = (uint)Marshal.SizeOf(typeof(NATIVE_OPENTEMPORARYTABLE2)),
			ccolumn = (uint)ccolumn,
			grbit = (uint)grbit,
			cbKeyMost = (uint)cbKeyMost,
			cbVarSegMac = (uint)cbVarSegMac
		});
	}
}
