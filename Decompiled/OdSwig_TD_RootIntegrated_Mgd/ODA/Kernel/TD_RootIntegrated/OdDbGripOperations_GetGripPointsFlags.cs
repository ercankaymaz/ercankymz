using System;

namespace ODA.Kernel.TD_RootIntegrated;

[Flags]
public enum OdDbGripOperations_GetGripPointsFlags
{
	kGripPointsOnly = 1,
	kCyclableGripsOnly = 2,
	kDynamicDimMode = 4
}
