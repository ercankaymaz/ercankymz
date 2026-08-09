using System;

namespace ODA.Kernel.TD_RootIntegrated;

[Flags]
public enum OdGsClientViewInfo_ViewportFlags
{
	kDependentViewport = 1,
	kDependentGeometry = 2,
	kHelperView = 4,
	kSetViewportId = 8
}
