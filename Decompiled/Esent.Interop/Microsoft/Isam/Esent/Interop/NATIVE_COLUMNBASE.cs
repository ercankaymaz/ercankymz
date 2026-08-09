using System;
using System.Runtime.InteropServices;

namespace Microsoft.Isam.Esent.Interop;

internal struct NATIVE_COLUMNBASE
{
	public uint cbStruct;

	public uint columnid;

	public uint coltyp;

	[Obsolete("Reserved")]
	public ushort wCountry;

	[Obsolete("Use cp")]
	public ushort langid;

	public ushort cp;

	[Obsolete("Reserved")]
	public ushort wFiller;

	public uint cbMax;

	public uint grbit;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
	public string szBaseTableName;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
	public string szBaseColumnName;

	private const int NameSize = 256;
}
