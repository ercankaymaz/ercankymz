using System;

namespace buClass;

[Serializable]
public enum SortingNextGroupFindRulesType
{
	ClosestLength,
	AskMe,
	NoNextGroup,
	MinYMinX,
	MinYMaxX,
	MinXMinY,
	MinXMaxY,
	MaxYMinX,
	MaxYMaxX,
	MaxXMinY,
	MaxXMaxY,
	DrawingSequence,
	ClosestContantPoint,
	FarContantPoint,
	ClosestLengthWithSingleTouch
}
