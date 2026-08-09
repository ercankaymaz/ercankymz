using System;

namespace ODA.Kernel.TD_RootIntegrated;

[Flags]
public enum OdDbGripOperations_DrawType
{
	kWarmGrip = 0,
	kHoverGrip = 1,
	kHotGrip = 2,
	kDragImageGrip = 3
}
