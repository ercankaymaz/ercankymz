using System;

namespace Microsoft.Isam.Esent.Interop;

[Flags]
public enum CreateDatabaseGrbit
{
	None = 0,
	OverwriteExisting = 0x200,
	RecoveryOff = 8
}
