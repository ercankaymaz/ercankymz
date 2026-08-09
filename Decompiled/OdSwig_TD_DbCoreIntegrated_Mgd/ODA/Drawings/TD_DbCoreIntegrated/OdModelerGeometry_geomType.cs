using System;

namespace ODA.Drawings.TD_DbCoreIntegrated;

[Flags]
public enum OdModelerGeometry_geomType
{
	kUndefined = 0,
	kBody = 1,
	kSolid = 2,
	kRegion = 3,
	kSurface = 4
}
