using System;

namespace ACadSharp.Entities;

[Flags]
public enum DimensionType
{
	Linear = 0,
	Aligned = 1,
	Angular = 2,
	Diameter = 3,
	Radius = 4,
	Angular3Point = 5,
	Ordinate = 6,
	BlockReference = 0x20,
	OrdinateTypeX = 0x40,
	TextUserDefinedLocation = 0x80
}
