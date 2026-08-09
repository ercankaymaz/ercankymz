using System;

namespace buEyeBaseVer5.Apps.Marble;

[Serializable]
public enum MarbleOperationSequence
{
	SawStraight,
	SawCircular,
	SawAngleCutStraight,
	CornerCleanByMilling,
	CornerCleanByDrill,
	MillingCuttings,
	Drills,
	waterJet,
	RestCutting
}
