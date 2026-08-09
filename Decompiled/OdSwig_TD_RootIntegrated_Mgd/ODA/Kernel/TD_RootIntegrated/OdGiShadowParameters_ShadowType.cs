using System;

namespace ODA.Kernel.TD_RootIntegrated;

[Flags]
public enum OdGiShadowParameters_ShadowType
{
	kShadowsRayTraced = 0,
	kShadowMaps = 1,
	kAreaSampled = 2
}
