using System;

namespace ODA.Drawings.TD_DbCoreIntegrated;

[Flags]
public enum OdDb_CellState
{
	kCellStateNone = 0,
	kCellStateContentLocked = 1,
	kCellStateContentReadOnly = 2,
	kCellStateLinked = 4,
	kCellStateContentModifiedAfterUpdate = 8,
	kCellStateFormatLocked = 0x10,
	kCellStateFormatReadOnly = 0x20,
	kCellStateFormatModifiedAfterUpdate = 0x40,
	kAllCellStates = 0x7F
}
