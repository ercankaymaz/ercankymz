using System;

namespace ODA.Drawings.TD_DbCoreIntegrated;

[Flags]
public enum OdDbHatch_HatchEdgeType
{
	kNone = 0,
	kLine = 1,
	kCirArc = 2,
	kEllArc = 3,
	kSpline = 4
}
