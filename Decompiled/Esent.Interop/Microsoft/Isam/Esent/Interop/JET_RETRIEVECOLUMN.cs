using System;
using System.Globalization;

namespace Microsoft.Isam.Esent.Interop;

public class JET_RETRIEVECOLUMN
{
	public JET_COLUMNID columnid { get; set; }

	public byte[] pvData { get; set; }

	public int ibData { get; set; }

	public int cbData { get; set; }

	public int cbActual { get; private set; }

	public RetrieveColumnGrbit grbit { get; set; }

	public int ibLongValue { get; set; }

	public int itagSequence { get; set; }

	public JET_COLUMNID columnidNextTagged { get; private set; }

	public JET_wrn err { get; private set; }

	public override string ToString()
	{
		return string.Format(CultureInfo.InvariantCulture, "JET_RETRIEVECOLUMN(0x{0:x})", columnid);
	}

	internal void CheckDataSize()
	{
		if (cbData < 0)
		{
			throw new ArgumentOutOfRangeException("cbData", cbData, "data length cannot be negative");
		}
		if (ibData < 0)
		{
			throw new ArgumentOutOfRangeException("ibData", cbData, "data offset cannot be negative");
		}
		if (ibData != 0 && (pvData == null || ibData >= pvData.Length))
		{
			throw new ArgumentOutOfRangeException("ibData", ibData, "cannot be greater than the length of the pvData buffer");
		}
		if ((pvData == null && cbData != 0) || (pvData != null && cbData > checked(pvData.Length - ibData)))
		{
			throw new ArgumentOutOfRangeException("cbData", cbData, "cannot be greater than the length of the pvData buffer");
		}
	}

	internal void GetNativeRetrievecolumn(ref NATIVE_RETRIEVECOLUMN retrievecolumn)
	{
		retrievecolumn.columnid = columnid.Value;
		retrievecolumn.cbData = (uint)cbData;
		checked
		{
			retrievecolumn.grbit = (uint)grbit;
			retrievecolumn.ibLongValue = (uint)ibLongValue;
			retrievecolumn.itagSequence = (uint)itagSequence;
		}
	}

	internal void UpdateFromNativeRetrievecolumn(ref NATIVE_RETRIEVECOLUMN native)
	{
		checked
		{
			cbActual = (int)native.cbActual;
			columnidNextTagged = new JET_COLUMNID
			{
				Value = native.columnidNextTagged
			};
			itagSequence = (int)native.itagSequence;
		}
		err = (JET_wrn)native.err;
	}
}
