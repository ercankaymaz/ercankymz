using System;

namespace ODA.Kernel.TD_RootIntegrated;

[Flags]
public enum OdGiLightTraitsData_LightType
{
	kInvalidLight = -1,
	kPointLight = 2,
	kSpotLight = 3,
	kDistantLight = 1,
	kWebLight = 0xA
}
