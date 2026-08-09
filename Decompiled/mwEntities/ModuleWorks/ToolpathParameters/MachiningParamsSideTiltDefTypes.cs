using System;

namespace ModuleWorks.ToolpathParameters;

[Serializable]
public enum MachiningParamsSideTiltDefTypes
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
