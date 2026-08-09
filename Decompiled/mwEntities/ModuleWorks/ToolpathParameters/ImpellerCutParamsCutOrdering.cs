using System;

namespace ModuleWorks.ToolpathParameters;

[Serializable]
public enum ImpellerCutParamsCutOrdering
{
	CoLeftToRight,
	CoRightToLeft,
	CoFromCenterAway,
	CoFromCenterAwayClimb,
	CoFromCenterAwayConventional,
	CoTopDown,
	CoBottomUp,
	CoInsideToOutside,
	CoOutsideToInside
}
