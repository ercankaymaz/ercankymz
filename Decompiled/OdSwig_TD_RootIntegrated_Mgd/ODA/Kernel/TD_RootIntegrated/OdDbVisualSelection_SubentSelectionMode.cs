using System;

namespace ODA.Kernel.TD_RootIntegrated;

[Flags]
public enum OdDbVisualSelection_SubentSelectionMode
{
	kDisableSubents = 0,
	kEnableSubents = 1,
	kIncludeViewport = 2,
	kNestedEntities = 4
}
