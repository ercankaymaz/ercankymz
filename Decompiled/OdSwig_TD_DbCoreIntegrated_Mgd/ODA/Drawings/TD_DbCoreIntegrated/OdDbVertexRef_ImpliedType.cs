using System;

namespace ODA.Drawings.TD_DbCoreIntegrated;

[Flags]
public enum OdDbVertexRef_ImpliedType
{
	kExplicitVertex = 0,
	kUnknownType = 1,
	kEdgeStart = 2,
	kEdgeEnd = 3,
	kEdgeMid = 4,
	kEdgeCenter = 5,
	kEdgeSplineControlPoint = 6,
	kEdgeSplineFitPoint = 7
}
