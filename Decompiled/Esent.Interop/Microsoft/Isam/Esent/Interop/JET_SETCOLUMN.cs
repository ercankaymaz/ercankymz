using System;
using System.Globalization;

namespace Microsoft.Isam.Esent.Interop;

public class JET_SETCOLUMN : IContentEquatable<JET_SETCOLUMN>, IDeepCloneable<JET_SETCOLUMN>
{
	public JET_COLUMNID columnid { get; set; }

	public byte[] pvData { get; set; }

	public int ibData { get; set; }

	public int cbData { get; set; }

	public SetColumnGrbit grbit { get; set; }

	public int ibLongValue { get; set; }

	public int itagSequence { get; set; }

	public JET_wrn err { get; internal set; }

	public override string ToString()
	{
		return string.Format(CultureInfo.InvariantCulture, "JET_SETCOLUMN(0x{0:x},{1},ibLongValue={2},itagSequence={3})", columnid.Value, Util.DumpBytes(pvData, ibData, cbData), ibLongValue, itagSequence);
	}

	public bool ContentEquals(JET_SETCOLUMN other)
	{
		if (other == null)
		{
			return false;
		}
		CheckDataSize();
		other.CheckDataSize();
		if (columnid == other.columnid && ibData == other.ibData && cbData == other.cbData && grbit == other.grbit && ibLongValue == other.ibLongValue && itagSequence == other.itagSequence && err == other.err)
		{
			return Util.ArrayEqual(pvData, other.pvData, ibData, cbData);
		}
		return false;
	}

	public JET_SETCOLUMN DeepClone()
	{
		JET_SETCOLUMN jET_SETCOLUMN = (JET_SETCOLUMN)MemberwiseClone();
		if (pvData != null)
		{
			jET_SETCOLUMN.pvData = new byte[pvData.Length];
			Array.Copy(pvData, jET_SETCOLUMN.pvData, cbData);
		}
		return jET_SETCOLUMN;
	}

	internal void CheckDataSize()
	{
		if (cbData < 0)
		{
			throw new ArgumentOutOfRangeException("cbData", "data length cannot be negative");
		}
		if (ibData < 0)
		{
			throw new ArgumentOutOfRangeException("ibData", "data offset cannot be negative");
		}
		if (ibData != 0 && (pvData == null || ibData >= pvData.Length))
		{
			throw new ArgumentOutOfRangeException("ibData", ibData, "cannot be greater than the length of the pvData");
		}
		if ((pvData == null && cbData != 0 && SetColumnGrbit.SizeLV != (grbit & SetColumnGrbit.SizeLV)) || (pvData != null && cbData > checked(pvData.Length - ibData)))
		{
			throw new ArgumentOutOfRangeException("cbData", cbData, "cannot be greater than the length of the pvData (unless the SizeLV option is used)");
		}
		if (itagSequence < 0)
		{
			throw new ArgumentOutOfRangeException("itagSequence", itagSequence, "cannot be negative");
		}
		if (ibLongValue < 0)
		{
			throw new ArgumentOutOfRangeException("ibLongValue", ibLongValue, "cannot be negative");
		}
	}

	internal NATIVE_SETCOLUMN GetNativeSetcolumn()
	{
		return checked(new NATIVE_SETCOLUMN
		{
			columnid = columnid.Value,
			cbData = (uint)cbData,
			grbit = (uint)grbit,
			ibLongValue = (uint)ibLongValue,
			itagSequence = (uint)itagSequence
		});
	}
}
