using System;

namespace ODA.Kernel.TD_RootIntegrated;

[Flags]
public enum OdGiContextualColorsImpl_VisualType
{
	kVisualTypeNotSet = -1,
	k2dModel = 0,
	kLayout = 1,
	k3dParallel = 2,
	k3dPerspective = 3,
	kBlock = 4,
	kNumVisualTypes = 5
}
