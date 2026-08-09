using System;

namespace ModuleWorks.ToolpathParameters;

[Serializable]
public enum CCWith2DegOptionsListCCWith2DegOptions
{
	StayCloseToInitialToolOrientation = 1,
	RespectToolAxisAngleLimitsInCutDirection,
	KeepToolAxisAsVerticalAsPossible,
	MinimizeRotaryAxisMoves,
	MinimizeTiltAxisMoves
}
