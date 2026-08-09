using System;

namespace Microsoft.Isam.Esent.Interop;

internal struct NATIVE_ENUMCOLUMN
{
	public uint columnid;

	public int err;

	public uint cbData;

	public IntPtr pvData;

	public uint cEnumColumnValue
	{
		get
		{
			return cbData;
		}
		set
		{
			cbData = value;
		}
	}

	public unsafe NATIVE_ENUMCOLUMNVALUE* rgEnumColumnValue
	{
		get
		{
			return (NATIVE_ENUMCOLUMNVALUE*)(void*)pvData;
		}
		set
		{
			pvData = new IntPtr(value);
		}
	}
}
