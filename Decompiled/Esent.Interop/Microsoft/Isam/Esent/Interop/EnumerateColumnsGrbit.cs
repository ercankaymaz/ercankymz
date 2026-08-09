using System;

namespace Microsoft.Isam.Esent.Interop;

[Flags]
public enum EnumerateColumnsGrbit
{
	None = 0,
	EnumerateCompressOutput = 0x80000,
	EnumerateCopy = 1,
	EnumerateIgnoreDefault = 0x20,
	EnumeratePresenceOnly = 0x20000,
	EnumerateTaggedOnly = 0x40000
}
