using System;

namespace ModuleWorks.ToolpathParameters;

[Serializable]
public enum ImpellerCutParamsBladeFinishingMode
{
	BfmFull,
	BfmFullTrimTrailEdge,
	BfmFullTrimTrailLeadEdge,
	BfmLeftSide,
	BfmRightSide,
	BfmPocket
}
