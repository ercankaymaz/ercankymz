using System;

namespace ModuleWorks;

[Serializable]
public enum NCMoveType
{
	Linear,
	ArcClockwise,
	ArcCounterClockwise,
	ArcSweepClockwise,
	ArcSweepCounterClockwise,
	Wire,
	Thread,
	Combine,
	Subtract
}
