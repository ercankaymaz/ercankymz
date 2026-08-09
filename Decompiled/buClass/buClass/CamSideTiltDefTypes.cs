using System;

namespace buClass;

[Serializable]
public enum CamSideTiltDefTypes
{
	FollowSurfIsoDir,
	OrthoToLowerEdgeCurve,
	OrthoToCutDirAtEachPos,
	OrthoToCutDirAtEachContour,
	UseSpindleMainDir,
	UseUserDefinedDir,
	UseTiltLineDef,
	TiltLineAutomatic
}
