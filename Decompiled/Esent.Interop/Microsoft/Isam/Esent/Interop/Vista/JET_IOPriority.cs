using System;

namespace Microsoft.Isam.Esent.Interop.Vista;

[Flags]
public enum JET_IOPriority
{
	Normal = 0,
	Low = 1,
	LowForCheckpoint = 2,
	LowForScavenge = 4
}
