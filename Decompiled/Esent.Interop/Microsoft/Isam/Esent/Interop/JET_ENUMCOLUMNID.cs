using System;
using System.Globalization;

namespace Microsoft.Isam.Esent.Interop;

public class JET_ENUMCOLUMNID
{
	public JET_COLUMNID columnid { get; set; }

	public int ctagSequence { get; set; }

	public int[] rgtagSequence { get; set; }

	public override string ToString()
	{
		return string.Format(CultureInfo.InvariantCulture, "JET_ENUMCOLUMNID(0x{0:x})", columnid);
	}

	internal void CheckDataSize()
	{
		if (ctagSequence < 0)
		{
			throw new ArgumentOutOfRangeException("ctagSequence", "ctagSequence cannot be negative");
		}
		if ((rgtagSequence == null && ctagSequence != 0) || (rgtagSequence != null && ctagSequence > rgtagSequence.Length))
		{
			throw new ArgumentOutOfRangeException("ctagSequence", ctagSequence, "cannot be greater than the length of the pvData");
		}
	}

	internal NATIVE_ENUMCOLUMNID GetNativeEnumColumnid()
	{
		CheckDataSize();
		return new NATIVE_ENUMCOLUMNID
		{
			columnid = columnid.Value,
			ctagSequence = checked((uint)ctagSequence)
		};
	}
}
