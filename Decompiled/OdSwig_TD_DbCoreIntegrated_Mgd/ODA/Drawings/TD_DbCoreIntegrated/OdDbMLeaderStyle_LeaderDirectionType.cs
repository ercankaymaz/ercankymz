using System;

namespace ODA.Drawings.TD_DbCoreIntegrated;

[Flags]
public enum OdDbMLeaderStyle_LeaderDirectionType
{
	kUnknownLeader = 0,
	kLeftLeader = 1,
	kRightLeader = 2,
	kTopLeader = 3,
	kBottomLeader = 4
}
