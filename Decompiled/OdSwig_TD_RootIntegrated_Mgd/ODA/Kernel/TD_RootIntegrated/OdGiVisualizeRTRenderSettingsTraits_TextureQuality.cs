using System;

namespace ODA.Kernel.TD_RootIntegrated;

[Flags]
public enum OdGiVisualizeRTRenderSettingsTraits_TextureQuality
{
	kTqNearest = 0,
	kTqSmooth = 1,
	kTqTrilinear = 2,
	kTqAnisotropic = 3
}
