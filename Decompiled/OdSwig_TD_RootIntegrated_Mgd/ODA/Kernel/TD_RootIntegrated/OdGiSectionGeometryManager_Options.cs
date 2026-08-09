using System;

namespace ODA.Kernel.TD_RootIntegrated;

[Flags]
public enum OdGiSectionGeometryManager_Options
{
	kForceLiveSectionSettings = 1,
	kIntersectionAsRegion = 2,
	kKeepResultsTransformed = 4
}
