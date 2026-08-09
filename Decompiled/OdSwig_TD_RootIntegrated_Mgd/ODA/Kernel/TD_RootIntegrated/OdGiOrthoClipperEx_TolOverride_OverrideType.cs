using System;

namespace ODA.Kernel.TD_RootIntegrated;

[Flags]
public enum OdGiOrthoClipperEx_TolOverride_OverrideType
{
	kNoOverride = 0,
	kAbsolute = 1,
	kMultiplier = 2,
	kAddition = 3
}
