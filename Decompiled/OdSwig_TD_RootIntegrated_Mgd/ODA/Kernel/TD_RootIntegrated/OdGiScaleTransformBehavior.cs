using System;

namespace ODA.Kernel.TD_RootIntegrated;

[Flags]
public enum OdGiScaleTransformBehavior
{
	kOdGiWorldScale = 0,
	kOdGiViewportScale = 1,
	kOdGiScreenScale = 2,
	kOdGiViewportLocalOriginScale = 3,
	kOdGiScreenLocalOriginScale = 4
}
