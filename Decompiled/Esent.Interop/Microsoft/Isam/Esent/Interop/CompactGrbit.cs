using System;

namespace Microsoft.Isam.Esent.Interop;

[Flags]
public enum CompactGrbit
{
	None = 0,
	Stats = 0x20,
	[Obsolete("Use esentutl repair functionality instead.")]
	Repair = 0x40
}
