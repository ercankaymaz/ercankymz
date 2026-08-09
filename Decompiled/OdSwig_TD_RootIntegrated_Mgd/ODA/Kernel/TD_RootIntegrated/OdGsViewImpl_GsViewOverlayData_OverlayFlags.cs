using System;

namespace ODA.Kernel.TD_RootIntegrated;

[Flags]
public enum OdGsViewImpl_GsViewOverlayData_OverlayFlags
{
	kWorldToDeviceValid = 1,
	kSceneDeptInvalid = 2,
	kViewToScreenValid = 4
}
