using System;

namespace ODA.Kernel.TD_RootIntegrated;

[Flags]
public enum OdGiDgLinetypeItem_Flags
{
	kFlagAutoPhase = 1,
	kFlagUseIterationLimit = 2,
	kFlagSingleSegmentMode = 4,
	kFlagCenterStretchPhaseMode = 8,
	kFlagStandardLinetype = 0x10,
	kFlagComputeStandardScale = 0x20
}
