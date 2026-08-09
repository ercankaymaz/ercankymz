using System;

namespace ODA.Kernel.TD_RootIntegrated;

[Flags]
public enum OdGe_ssiConfig
{
	kSSIUnknown = 0,
	kSSIOut = 1,
	kSSIIn = 2,
	kSSICoincident = 3
}
