using System;

namespace ODA.Drawings.TD_DbCoreIntegrated;

[Flags]
public enum OdDbMLeader_LeaderLineOverrideType
{
	kOverrideLeaderType = 0,
	kOverrideLineColor = 1,
	kOverrideLineTypeId = 2,
	kOverrideLineWeight = 3,
	kOverrideArrowSize = 4,
	kOverrideArrowSymbolId = 5
}
