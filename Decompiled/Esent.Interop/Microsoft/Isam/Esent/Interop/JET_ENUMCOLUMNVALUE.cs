using System;
using System.Globalization;

namespace Microsoft.Isam.Esent.Interop;

public class JET_ENUMCOLUMNVALUE
{
	public int itagSequence { get; internal set; }

	public JET_wrn err { get; internal set; }

	public int cbData { get; internal set; }

	public IntPtr pvData { get; internal set; }

	public override string ToString()
	{
		return string.Format(CultureInfo.InvariantCulture, "JET_ENUMCOLUMNVALUE(itagSequence = {0}, cbData = {1})", itagSequence, cbData);
	}

	internal void SetFromNativeEnumColumnValue(NATIVE_ENUMCOLUMNVALUE value)
	{
		itagSequence = checked((int)value.itagSequence);
		err = (JET_wrn)value.err;
		cbData = checked((int)value.cbData);
		pvData = value.pvData;
	}
}
