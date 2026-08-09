using System;

namespace ODA.Kernel.TD_RootIntegrated;

[Flags]
public enum OdGiPositionTransformBehavior
{
	kOdGiWorldPosition = 0,
	kOdGiViewportPosition = 1,
	kOdGiScreenPosition = 2,
	kOdGiScreenLocalOriginPosition = 3,
	kOdGiWorldWithScreenOffsetPosition = 4
}
