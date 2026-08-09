using System;

namespace ODA.Kernel.TD_RootIntegrated;

[Flags]
public enum OdGiDrawableDesc_DrawableDescFlags
{
	kFirstFlag = 1,
	kMarkedToSkip = 1,
	kMarkedBySelection = 2,
	kMarkedBySubSelection = 4,
	kMarkedByGeometry = 8,
	kMarkedBySubGeometry = 0x10,
	kMarkedToBreak = 0x20,
	kMarkedForForcedSelection = 0x40,
	kLastFlag = 0x40
}
