using System;

namespace ODA.Kernel.TD_RootIntegrated;

[Flags]
public enum OdGe_csiConfig
{
	kXUnknown = 0,
	kXOut = 1,
	kXIn = 2,
	kXTanOut = 3,
	kXTanIn = 4,
	kXCoincident = 5,
	kXCoincidentUnbounded = 6
}
