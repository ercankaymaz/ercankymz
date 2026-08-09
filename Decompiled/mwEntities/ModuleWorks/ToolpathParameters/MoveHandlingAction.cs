using System;

namespace ModuleWorks.ToolpathParameters;

[Serializable]
public enum MoveHandlingAction
{
	ActionGapDirect,
	ActionGapBrokenFeed,
	ActionGapRapidPlane,
	ActionGapFollowSurfs,
	ActionGapBlendSpline,
	ActionGapBrokenFeedRap,
	ActionGapFollowStock,
	ActionGapStep,
	ActionGapDirectBlend,
	ActionGapShortestPath,
	ActionGapArcLineArc,
	ActionGapIncrementalRapidPlane,
	ActionGapClearanceBlendSpline,
	ActionGap3Plus2Connection,
	ActionGap3Plus2ConnectionPlane,
	ActionGapBrokenFeedRapBlendSpline,
	ActionGapBrokenFeedBlendSpline,
	LastType
}
