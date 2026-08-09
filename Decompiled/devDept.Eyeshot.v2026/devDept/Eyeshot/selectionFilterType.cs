using System;

namespace devDept.Eyeshot;

[Flags]
public enum selectionFilterType
{
	Entity = 1,
	Vertex = 2,
	Edge = 4,
	Face = 8,
	SubCurve = 0x10,
	Contour = 0x20,
	SketchPoint = 0x40,
	SketchCurve = 0x80
}
