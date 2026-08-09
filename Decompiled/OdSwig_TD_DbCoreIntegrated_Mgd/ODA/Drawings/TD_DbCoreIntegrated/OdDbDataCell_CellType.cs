using System;

namespace ODA.Drawings.TD_DbCoreIntegrated;

[Flags]
public enum OdDbDataCell_CellType
{
	kUnknown = 0,
	kInteger = 1,
	kDouble = 2,
	kCharPtr = 3,
	kPoint = 4,
	kObjectId = 5,
	kHardOwnerId = 6,
	kSoftOwnerId = 7,
	kHardPtrId = 8,
	kSoftPtrId = 9,
	kBool = 0xA,
	kVector = 0xB
}
