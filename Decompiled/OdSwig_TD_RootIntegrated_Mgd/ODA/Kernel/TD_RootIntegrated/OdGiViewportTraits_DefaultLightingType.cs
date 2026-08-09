using System;

namespace ODA.Kernel.TD_RootIntegrated;

[Flags]
public enum OdGiViewportTraits_DefaultLightingType
{
	kOneDistantLight = 0,
	kTwoDistantLights = 1,
	kBackLighting = 2,
	kUserDefinedLight = 3
}
