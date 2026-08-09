using System;

namespace ModuleWorks.ToolpathParameters;

[Serializable]
public enum MachiningParamsCutOrder
{
	OrderStandard,
	OrderFromCenter,
	OrderFromOuter,
	OrderTriMeshCcFromTopToBottom,
	OrderTriMeshCcFromBottomToTop,
	OrderFromTopToBottom,
	OrderFromBottomToTop,
	OrderFromLeftToRight,
	OrderFromRightToLeft,
	OrderWipeFromOneSide,
	OrderWipeFromLessCuts,
	OrderTowardsDriveCurve,
	OrderFromDriveCurve,
	OrderSelectionSequence
}
