using System;

namespace ODA.Kernel.TD_RootIntegrated;

[Flags]
public enum OdGiDisplayStyle_DisplaySettings
{
	kNone = 0,
	kBackgrounds = 1,
	kLights = 2,
	kMaterials = 4,
	kTextures = 8
}
