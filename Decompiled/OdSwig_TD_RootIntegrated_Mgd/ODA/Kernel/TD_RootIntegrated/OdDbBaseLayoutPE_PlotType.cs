using System;

namespace ODA.Kernel.TD_RootIntegrated;

[Flags]
public enum OdDbBaseLayoutPE_PlotType
{
	kDisplay = 0,
	kExtents = 1,
	kLimits = 2,
	kView = 3,
	kWindow = 4,
	kLayout = 5
}
