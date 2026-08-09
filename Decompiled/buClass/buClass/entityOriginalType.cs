using System;

namespace buClass;

[Serializable]
public enum entityOriginalType
{
	None,
	Arc,
	Line,
	LinearPath,
	Ellipse,
	EllipseArc,
	Spline,
	Curve,
	CompositeCurve,
	Surface,
	Brep,
	Point,
	Circle,
	Text,
	Mesh,
	Region,
	Dimenstion
}
