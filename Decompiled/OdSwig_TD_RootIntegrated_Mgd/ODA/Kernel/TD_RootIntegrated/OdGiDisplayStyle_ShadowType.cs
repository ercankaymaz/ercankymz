using System;

namespace ODA.Kernel.TD_RootIntegrated;

[Flags]
public enum OdGiDisplayStyle_ShadowType
{
	kShadowsNone = 0,
	kShadowsGroundPlane = 1,
	kShadowsFull = 2,
	kShadowsFullAndGround = 3
}
