using System;

namespace ACadSharp.Entities;

[Flags]
public enum SplineFlags : ushort
{
	None = 0,
	Closed = 1,
	Periodic = 2,
	Rational = 4,
	Planar = 8,
	Linear = 0x10
}
