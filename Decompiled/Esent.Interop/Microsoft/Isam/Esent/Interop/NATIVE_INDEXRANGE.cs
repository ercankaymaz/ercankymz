using System;
using System.Runtime.InteropServices;

namespace Microsoft.Isam.Esent.Interop;

internal struct NATIVE_INDEXRANGE
{
	public uint cbStruct;

	public IntPtr tableid;

	public uint grbit;

	public static NATIVE_INDEXRANGE MakeIndexRangeFromTableid(JET_TABLEID tableid)
	{
		NATIVE_INDEXRANGE result = new NATIVE_INDEXRANGE
		{
			tableid = tableid.Value,
			grbit = 1u
		};
		result.cbStruct = checked((uint)Marshal.SizeOf(typeof(NATIVE_INDEXRANGE)));
		return result;
	}
}
