using System;

namespace buClass;

[Serializable]
public enum AnalyseEntitiesResultErrorType
{
	None,
	SameAvailable,
	SmallGap,
	SmallLength,
	NotClosedEntities,
	Intersection
}
