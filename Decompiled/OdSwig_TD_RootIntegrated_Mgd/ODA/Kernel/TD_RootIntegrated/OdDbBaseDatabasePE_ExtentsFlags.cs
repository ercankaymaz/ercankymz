using System;

namespace ODA.Kernel.TD_RootIntegrated;

[Flags]
public enum OdDbBaseDatabasePE_ExtentsFlags
{
	kZeroFlags = 0,
	kExactExtents = 1,
	kUseViewExtents = 2,
	kUseGivenExtents = 4,
	kUseGivenView = 8,
	kIncludeOffLayers = 0x10
}
