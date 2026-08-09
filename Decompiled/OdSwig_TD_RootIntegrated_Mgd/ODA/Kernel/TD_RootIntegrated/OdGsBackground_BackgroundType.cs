using System;

namespace ODA.Kernel.TD_RootIntegrated;

[Flags]
public enum OdGsBackground_BackgroundType
{
	kSolidBackground = 0,
	kGradientBackground = 1,
	kImageBackground = 2,
	kGroundPlaneBackground = 3,
	kSkyBackground = 4,
	kIBLBackground = 5,
	kEnvironmentBackground = 6,
	kCustomBackground = 7
}
