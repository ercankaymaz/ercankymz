using System;

namespace ODA.Drawings.TD_DbCoreIntegrated;

[Flags]
public enum OdDb_TableStyleFlags
{
	kHorzInsideLineFirst = 1,
	kHorzInsideLineSecond = 2,
	kHorzInsideLineThird = 4,
	kTableStyleModified = 8
}
