using System;

namespace ODA.Drawings.TD_DbCoreIntegrated;

[Flags]
public enum DwgDataType
{
	kDwgNull = 0,
	kDwgReal = 1,
	kDwgInt32 = 2,
	kDwgInt16 = 3,
	kDwgInt8 = 4,
	kDwgText = 5,
	kDwgBChunk = 6,
	kDwgHandle = 7,
	kDwgHardOwnershipId = 8,
	kDwgSoftOwnershipId = 9,
	kDwgHardPointerId = 0xA,
	kDwgSoftPointerId = 0xB,
	kDwg3Real = 0xC,
	kDwgInt64 = 0xD,
	kDwg2Real = 0xE,
	kDwgNotRecognized = 0x13
}
