using System;

namespace buClass;

[Serializable]
public enum SortingResultType
{
	Error = -1,
	None = 0,
	Done = 1,
	MultipleEntities = 5,
	SelectNextGroup = 6,
	UpperFound = 7,
	Stoped = 8
}
