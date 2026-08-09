using System;

namespace ODA.Drawings.TD_DbCoreIntegrated;

[Flags]
public enum OdDb_Poly2dType
{
	k2dSimplePoly = 0,
	k2dFitCurvePoly = 1,
	k2dQuadSplinePoly = 2,
	k2dCubicSplinePoly = 3
}
