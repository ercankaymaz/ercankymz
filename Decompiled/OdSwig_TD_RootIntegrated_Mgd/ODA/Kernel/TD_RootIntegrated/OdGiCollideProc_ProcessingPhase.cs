using System;

namespace ODA.Kernel.TD_RootIntegrated;

[Flags]
public enum OdGiCollideProc_ProcessingPhase
{
	kPhaseGatherInputData = 0,
	kPhaseDetectIntersections = 1
}
