using System;

namespace buClass;

[Serializable]
public enum SortingFirstCatchRulesType
{
	LowerIndex,
	HigherIndex,
	CW,
	CCW,
	FirstDirectionThenAuto,
	Jump,
	None,
	Manuel
}
