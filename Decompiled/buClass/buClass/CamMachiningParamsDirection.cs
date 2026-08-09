using System;

namespace buClass;

[Serializable]
public enum CamMachiningParamsDirection
{
	DirClockwise,
	DirCounterClockwise,
	DirClimb,
	DirConventional,
	DirFollowCurveChaining,
	DirFollowCurveChainingReverse
}
