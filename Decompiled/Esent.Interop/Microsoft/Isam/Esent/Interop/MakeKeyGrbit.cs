using System;

namespace Microsoft.Isam.Esent.Interop;

[Flags]
public enum MakeKeyGrbit
{
	None = 0,
	NewKey = 1,
	NormalizedKey = 8,
	KeyDataZeroLength = 0x10,
	StrLimit = 2,
	SubStrLimit = 4,
	FullColumnStartLimit = 0x100,
	FullColumnEndLimit = 0x200,
	PartialColumnStartLimit = 0x400,
	PartialColumnEndLimit = 0x800
}
