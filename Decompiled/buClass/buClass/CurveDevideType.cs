using System;

namespace buClass;

[Serializable]
public enum CurveDevideType
{
	DontDevide,
	CurveToArc,
	CurveToPolyLine,
	CurveToLine,
	CurveControlPointsToLine,
	CurveControlPointsToPolyLine
}
