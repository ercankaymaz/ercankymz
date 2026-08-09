using System;

namespace ACadSharp.Entities;

[Flags]
public enum BoundaryPathFlags
{
	Default = 0,
	External = 1,
	Polyline = 2,
	Derived = 4,
	Textbox = 8,
	Outermost = 0x10,
	NotClosed = 0x20,
	SelfIntersecting = 0x40,
	TextIsland = 0x80,
	Duplicate = 0x100,
	IsAnnotative = 0x200,
	DoesNotSupportScale = 0x400,
	ForceAnnoAllVisible = 0x800,
	OrientToPaper = 0x1000,
	IsAnnotativeBlock = 0x2000
}
