using System;

namespace Microsoft.Isam.Esent.Interop;

[Flags]
public enum SpaceHintsGrbit
{
	None = 0,
	SpaceHintUtilizeParentSpace = 1,
	CreateHintAppendSequential = 2,
	CreateHintHotpointSequential = 4,
	RetrieveHintReserve1 = 8,
	RetrieveHintTableScanForward = 0x10,
	RetrieveHintTableScanBackward = 0x20,
	RetrieveHintReserve2 = 0x40,
	RetrieveHintReserve3 = 0x80,
	DeleteHintTableSequential = 0x100
}
