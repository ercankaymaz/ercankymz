using System;

namespace ModuleWorks.ToolpathParameters;

[Serializable]
public enum MultiAxisMoldAndDieAction
{
	ActionGapDirect,
	ActionGapFollowSurfaces,
	ActionGapBlendSpline,
	ActionGapFeedDistance,
	ActionGapRapidDistance,
	ActionGapClearanceArea,
	ActionGapIncrementalClearancePlane,
	ActionGapClearanceBlendSpline
}
