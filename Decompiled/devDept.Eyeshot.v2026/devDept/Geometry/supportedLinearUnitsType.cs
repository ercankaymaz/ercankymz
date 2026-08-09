using System;

namespace devDept.Geometry;

[Flags]
public enum supportedLinearUnitsType
{
	Unitless = 1,
	Inches = 2,
	Feet = 4,
	Miles = 8,
	Millimeters = 0x10,
	Centimeters = 0x20,
	Meters = 0x40,
	Kilometers = 0x80,
	Microinches = 0x100,
	Mils = 0x200,
	Yards = 0x400,
	Angstroms = 0x800,
	Nanometers = 0x1000,
	Microns = 0x2000,
	Decimeters = 0x4000,
	Decameters = 0x8000,
	Hectometers = 0x10000,
	Gigameters = 0x20000,
	Astronomical = 0x40000,
	LightYears = 0x80000,
	Parsecs = 0x100000,
	All = 0x1FFFFF
}
