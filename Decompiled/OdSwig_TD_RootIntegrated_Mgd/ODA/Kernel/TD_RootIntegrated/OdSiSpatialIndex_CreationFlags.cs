using System;

namespace ODA.Kernel.TD_RootIntegrated;

[Flags]
public enum OdSiSpatialIndex_CreationFlags
{
	kSiNoFlags = 0,
	kSiPlanar = 1,
	kSiModifyMtAware = 2,
	kSiAccessMtAware = 4,
	kSiFullMtAware = 6
}
