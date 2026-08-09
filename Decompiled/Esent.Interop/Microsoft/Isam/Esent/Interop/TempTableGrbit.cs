using System;

namespace Microsoft.Isam.Esent.Interop;

[Flags]
public enum TempTableGrbit
{
	None = 0,
	Indexed = 1,
	Unique = 2,
	Updatable = 4,
	Scrollable = 8,
	SortNullsHigh = 0x10,
	ForceMaterialization = 0x20,
	ErrorOnDuplicateInsertion = 0x20
}
