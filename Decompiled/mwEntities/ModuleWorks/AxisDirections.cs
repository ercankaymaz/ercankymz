using System;

namespace ModuleWorks;

[Serializable]
public enum AxisDirections
{
	DirectionNone = 0,
	DirectionXPlus = 1,
	DirectionYPlus = 2,
	DirectionZPlus = 3,
	DirectionXMinus = -1,
	DirectionYMinus = -2,
	DirectionZMinus = -3
}
