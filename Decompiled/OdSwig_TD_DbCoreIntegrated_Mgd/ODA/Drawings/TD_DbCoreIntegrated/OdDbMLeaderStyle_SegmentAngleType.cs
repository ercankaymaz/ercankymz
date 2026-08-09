using System;

namespace ODA.Drawings.TD_DbCoreIntegrated;

[Flags]
public enum OdDbMLeaderStyle_SegmentAngleType
{
	kAny = 0,
	k15 = 1,
	k30 = 2,
	k45 = 3,
	k60 = 4,
	k90 = 6,
	kHorz = 0xC
}
