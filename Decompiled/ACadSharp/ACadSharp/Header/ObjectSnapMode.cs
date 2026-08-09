using System;

namespace ACadSharp.Header;

[Flags]
public enum ObjectSnapMode : ushort
{
	None = 0,
	EndPoint = 1,
	MidPoint = 2,
	Center = 4,
	Node = 8,
	Quadrant = 0x10,
	Intersection = 0x20,
	Insertion = 0x40,
	Perpendicular = 0x80,
	Tangent = 0x100,
	Nearest = 0x200,
	ClearsAllObjectSnaps = 0x400,
	ApparentIntersection = 0x800,
	Extension = 0x1000,
	Parallel = 0x2000,
	AllModes = 0x3FFF,
	SwitchedOff = 0x4000
}
