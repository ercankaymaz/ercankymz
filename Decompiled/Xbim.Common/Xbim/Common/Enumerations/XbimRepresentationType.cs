using System;

namespace Xbim.Common.Enumerations;

[Flags]
public enum XbimRepresentationType : short
{
	Curve2D = 1,
	GeometricSet = 2,
	GeometricCurveSet = 4,
	SurfaceModel = 8,
	SolidModel = 0x10,
	SweptSolid = 0x20,
	Brep = 0x40,
	CSG = 0x80,
	Clipping = 0x100,
	AdvancedSweptSolid = 0x200,
	BoundingBox = 0x400,
	SectionedSpine = 0x800,
	MappedRepresentation = 0x1000
}
