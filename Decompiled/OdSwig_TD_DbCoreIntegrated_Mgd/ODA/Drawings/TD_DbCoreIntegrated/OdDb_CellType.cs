using System;

namespace ODA.Drawings.TD_DbCoreIntegrated;

[Flags]
public enum OdDb_CellType
{
	kUnknownCell = 0,
	kTextCell = 1,
	kBlockCell = 2,
	kMultipleContentCell = 3
}
