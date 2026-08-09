using System;

namespace ODA.Kernel.TD_RootIntegrated;

[Flags]
public enum GradientType
{
	GR_INVALID = 0,
	GR_SPHERE = 1,
	GR_HEMISPHERE = 2,
	GR_CURVED = 3,
	GR_LINEAR = 4,
	GR_CYLINDER = 5
}
