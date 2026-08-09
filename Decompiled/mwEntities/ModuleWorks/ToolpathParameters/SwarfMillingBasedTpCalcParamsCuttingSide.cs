using System;

namespace ModuleWorks.ToolpathParameters;

[Serializable]
public enum SwarfMillingBasedTpCalcParamsCuttingSide
{
	CutSideLeft,
	CutSideRight,
	CutSideInside,
	CutSideOutside,
	SideByCoverPlane,
	CutSideAutodetect,
	CutSideSurfaceNormal,
	CutSideReverseSurfaceNormal
}
