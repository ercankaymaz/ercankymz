using System;

namespace ODA.Kernel.TD_RootIntegrated;

[Flags]
public enum OdGiDrawable_DrawableType
{
	kGeometry = 0,
	kDistantLight = 1,
	kPointLight = 2,
	kSpotLight = 3,
	kAmbientLight = 4,
	kSolidBackground = 5,
	kGradientBackground = 6,
	kImageBackground = 7,
	kGroundPlaneBackground = 8,
	kViewport = 9,
	kWebLight = 0xA,
	kSkyBackground = 0xB,
	kImageBasedLightingBackground = 0xC,
	kEnvironmentBackground = 0x10,
	kCustomBackground = 0x11
}
