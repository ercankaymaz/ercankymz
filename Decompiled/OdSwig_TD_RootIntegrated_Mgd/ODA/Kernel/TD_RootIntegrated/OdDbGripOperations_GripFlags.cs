using System;

namespace ODA.Kernel.TD_RootIntegrated;

[Flags]
public enum OdDbGripOperations_GripFlags
{
	kSkipWhenShared = 1,
	kDisableRubberBandLine = 2,
	kDisableModeKeywords = 4,
	kDrawAtDragImageGripPoint = 8,
	kTriggerGrip = 0x10,
	kTurnOnForcedPick = 0x20,
	kMapGripHotToRtClk = 0x40,
	kGizmosEnabled = 0x80,
	kGripIsPerViewport = 0x100
}
