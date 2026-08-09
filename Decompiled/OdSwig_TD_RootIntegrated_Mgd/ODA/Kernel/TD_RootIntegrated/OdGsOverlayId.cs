using System;

namespace ODA.Kernel.TD_RootIntegrated;

[Flags]
public enum OdGsOverlayId
{
	kGsMainOverlay = 0,
	kGsDirectOverlay = 1,
	kGsUserFg3Overlay = 2,
	kGsUserBg1Overlay = 3,
	kGsUserBg3Overlay = 4,
	kGsUserFg1Overlay = 5,
	kGsHighlightOverlay = 6,
	kGsHighlightSelectionOverlay = 7,
	kGsDirectTopmostOverlay = 8,
	kGsSpriteOverlay = 9,
	kGsContrastOverlay = 0xA,
	kGsUserFg2Overlay = 0xB,
	kGsUserBg2Overlay = 0xC,
	kNumGsOverlays = 0xD,
	kGsAllOverlays = 0x1FFF,
	kGsNoOverlays = 0,
	kGsUndefinedOverlay = -1
}
