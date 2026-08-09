using System;

namespace buClass;

[Serializable]
public enum SortingIntersectionRulesType
{
	LowerIndex,
	HigherIndex,
	LowerAngle,
	HighAngle,
	AskMe,
	PreviousAngleDirection,
	ClosestLength,
	FromDrawing,
	With2Point,
	First180DegreeTehnFromDrawing,
	Stop,
	CW,
	CCW
}
