using System;

namespace buEyeBaseVer5.Apps.Marble;

[Serializable]
public enum MarbleMachineToolType
{
	OnlySaw,
	OnlySpindle,
	OnlyWaterJet,
	SawSpindle,
	SawSpindleHeadSpindle,
	SawHeadSpindle,
	SawSpindleHeadSpindleWaterJet,
	SpindleAndMagazine
}
