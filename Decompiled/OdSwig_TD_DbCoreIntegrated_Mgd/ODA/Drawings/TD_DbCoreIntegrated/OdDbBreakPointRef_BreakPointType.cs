using System;

namespace ODA.Drawings.TD_DbCoreIntegrated;

[Flags]
public enum OdDbBreakPointRef_BreakPointType
{
	kDynamic = 0,
	kStatic = 1,
	kStatic2Point = 2
}
