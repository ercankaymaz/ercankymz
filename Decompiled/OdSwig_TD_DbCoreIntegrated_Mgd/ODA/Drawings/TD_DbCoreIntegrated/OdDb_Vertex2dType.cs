using System;

namespace ODA.Drawings.TD_DbCoreIntegrated;

[Flags]
public enum OdDb_Vertex2dType
{
	k2dVertex = 0,
	k2dSplineCtlVertex = 1,
	k2dSplineFitVertex = 2,
	k2dCurveFitVertex = 3
}
