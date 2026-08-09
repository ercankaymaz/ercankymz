using System;

namespace Microsoft.Isam.Esent.Interop.Win32;

[Flags]
internal enum AllocationType : uint
{
	MEM_COMMIT = 0x1000u,
	MEM_RESERVE = 0x2000u
}
