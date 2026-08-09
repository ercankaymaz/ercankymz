using System;

namespace buClass;

[Serializable]
public enum CamCutOrder
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
