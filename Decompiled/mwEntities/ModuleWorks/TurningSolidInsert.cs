using System;

namespace ModuleWorks;

[Serializable]
public enum TurningSolidInsert
{
	Triangle = 0,
	Diamond = 1,
	Parallelogram = 2,
	Square = 3,
	Octagonal = 4,
	[Obsolete("Deprecated since Release 2017.04. Please use TurningSolidInsert.Octagonal instead.")]
	Octogonal = 4,
	Pentagonal = 5,
	Round = 6,
	Hexagonal = 7,
	Groove = 8,
	[Obsolete("Deprecated since Release 2021.12. Please do not use.")]
	NotSet = 9,
	ThreadTriangle = 9
}
