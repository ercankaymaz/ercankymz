using System;

namespace ModuleWorks.ToolpathParameters;

[Serializable]
public enum MachiningParamsDirection
{
	DirClockwise,
	DirCounterClockwise,
	DirClimb,
	DirConventional,
	DirFollowCurveChaining,
	DirFollowCurveChainingReverse
}
