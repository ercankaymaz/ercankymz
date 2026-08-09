using System;

namespace ODA.Drawings.TD_DbCoreIntegrated;

[Flags]
public enum OdDb_TableHitItem
{
	kTableHitNone = 0,
	kTableHitCell = 1,
	kTableHitRowIndicator = 2,
	kTableHitColumnIndicator = 4,
	kTableHitGridLine = 8
}
