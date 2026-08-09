using System;

namespace ModuleWorks.ToolpathParameters;

[Serializable]
public enum TurningTpCalcParamsCuttingDirection
{
	CdNegative,
	CdPositive,
	CdBiDirection,
	CdAlternateCenterAway,
	CdAlternatePositiveFirst,
	CdAlternateNegativeFirst
}
