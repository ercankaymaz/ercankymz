using System;

namespace ODA.Kernel.TD_RootIntegrated;

[Flags]
public enum OdGiTransientManager_OdGiTransientDrawingMode
{
	kOdGiMain = 0,
	kOdGiSprite = 1,
	kOdGiDirectShortTerm = 2,
	kOdGiHighlight = 3,
	kOdGiDirectTopmost = 4,
	kOdGiContrast = 5,
	kOdGiDrawingModeCount = 6
}
