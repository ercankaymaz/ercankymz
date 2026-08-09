using System;

namespace ODA.Kernel.TD_RootIntegrated;

[Flags]
public enum OdGiVisualStyleProperties_DisplayStyles
{
	kNoDisplayStyle = 0,
	kBackgroundsFlag = 1,
	kLightingFlag = 2,
	kMaterialsFlag = 4,
	kTexturesFlag = 8
}
