using System;

namespace ModuleWorks.ToolpathParameters;

[Serializable]
public enum LeadParamsType
{
	TangentialArc = 1,
	ReverseTangArc,
	VerticalTangArc,
	HorizontalTangArc,
	OrthogonalArc,
	TangentialLine,
	OrthogonalLine,
	ReverseTangLine,
	ReverseVertTangArc,
	ReverseVertProfileRamp,
	PositionLine,
	VertProfileRamp,
	Line,
	AutomaticArc,
	ReverseOrthogonalLine,
	G1Spline,
	G2Spline,
	G1Spiral,
	G2Spiral,
	SlantLine,
	G0Ramp,
	HelicalArc,
	AlongToolAxis,
	LastType
}
