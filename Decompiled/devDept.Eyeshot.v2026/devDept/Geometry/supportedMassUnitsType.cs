using System;

namespace devDept.Geometry;

[Flags]
public enum supportedMassUnitsType
{
	Unitless = 1,
	Micrograms = 2,
	Milligrams = 4,
	Grams = 8,
	Kilograms = 0x10,
	Ton = 0x20,
	Ounce = 0x40,
	Pound = 0x80,
	Stone = 0x100,
	ShortTon = 0x200,
	LongTon = 0x400,
	All = 0x7FF
}
