using System;

namespace ODA.Drawings.TD_DbCoreIntegrated;

[Flags]
public enum OdDb_TableBreakFlowDirection
{
	kTableBreakFlowRight = 1,
	kTableBreakFlowDownOrUp = 2,
	kTableBreakFlowLeft = 4
}
