using System;

namespace ODA.Drawings.TD_DbCoreIntegrated;

[Flags]
public enum OdDb_Poly3dType
{
	k3dSimplePoly = 0,
	k3dQuadSplinePoly = 1,
	k3dCubicSplinePoly = 2
}
