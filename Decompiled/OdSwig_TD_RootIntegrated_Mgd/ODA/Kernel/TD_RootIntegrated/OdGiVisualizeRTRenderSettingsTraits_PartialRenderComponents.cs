using System;

namespace ODA.Kernel.TD_RootIntegrated;

[Flags]
public enum OdGiVisualizeRTRenderSettingsTraits_PartialRenderComponents
{
	kReflectionPart = 1,
	kRefractionPart = 2,
	kDiffuseLightingPart = 4,
	kSpecularLightingPart = 8,
	kAllRenderComponents = 0xF
}
