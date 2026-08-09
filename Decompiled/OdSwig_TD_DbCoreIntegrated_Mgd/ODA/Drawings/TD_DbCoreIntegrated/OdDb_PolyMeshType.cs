using System;

namespace ODA.Drawings.TD_DbCoreIntegrated;

[Flags]
public enum OdDb_PolyMeshType
{
	kSimpleMesh = 0,
	kQuadSurfaceMesh = 5,
	kCubicSurfaceMesh = 6,
	kBezierSurfaceMesh = 8
}
