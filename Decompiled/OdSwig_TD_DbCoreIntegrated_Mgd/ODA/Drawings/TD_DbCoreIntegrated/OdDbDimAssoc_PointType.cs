using System;

namespace ODA.Drawings.TD_DbCoreIntegrated;

[Flags]
public enum OdDbDimAssoc_PointType
{
	kXline1Point = 0,
	kXline2Point = 1,
	kOriginPoint = 0,
	kDefiningPoint = 1,
	kXline1Start = 0,
	kXline1End = 1,
	kXline2Start = 2,
	kXline2End = 3,
	kVertexPoint = 2,
	kChordPoint = 0,
	kCenterPoint = 1,
	kFarChordPoint = 1,
	kOverrideCenterPoint = 2,
	kAngLineStart = 2,
	kJogPoint = 3,
	kAngLineEnd = 3,
	kLeaderPoint = 0
}
