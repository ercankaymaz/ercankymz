using System;

namespace ODA.Kernel.TD_RootIntegrated;

[Flags]
public enum OdGiOrientationTransformBehavior
{
	kOdGiWorldOrientation = 0,
	kOdGiScreenOrientation = 1,
	kOdGiZAxisOrientation = 2
}
