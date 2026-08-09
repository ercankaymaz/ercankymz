using System;

namespace ODA.Drawings.TD_DbCoreIntegrated;

[Flags]
public enum OdDbDetailViewStyle_IdentifierPlacement
{
	kOutsideBoundary = 0,
	kOutsideBoundaryWithLeader = 1,
	kOnBoundary = 2,
	kOnBoundaryWithLeader = 3
}
