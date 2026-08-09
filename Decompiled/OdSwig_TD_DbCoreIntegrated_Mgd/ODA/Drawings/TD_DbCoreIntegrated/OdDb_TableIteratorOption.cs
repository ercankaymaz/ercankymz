using System;

namespace ODA.Drawings.TD_DbCoreIntegrated;

[Flags]
public enum OdDb_TableIteratorOption
{
	kTableIteratorNone = 0,
	kTableIteratorIterateSelection = 1,
	kTableIteratorIterateRows = 2,
	kTableIteratorIterateColumns = 4,
	kTableIteratorIterateDataLinks = 0x80,
	kTableIteratorReverseOrder = 8,
	kTableIteratorSkipReadOnlyContent = 0x10,
	kTableIteratorSkipReadOnlyFormat = 0x20,
	kTableIteratorSkipMerged = 0x40
}
