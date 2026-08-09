using System;

namespace ODA.Drawings.TD_DbCoreIntegrated;

[Flags]
public enum OdDb_CellContentLayout
{
	kCellContentLayoutFlow = 1,
	kCellContentLayoutStackedHorizontal = 2,
	kCellContentLayoutStackedVertical = 4
}
