using System;

namespace ODA.Drawings.TD_DbCoreIntegrated;

[Flags]
public enum OdDb_CellEdgeMask
{
	kTopMask = 1,
	kRightMask = 2,
	kBottomMask = 4,
	kLeftMask = 8
}
