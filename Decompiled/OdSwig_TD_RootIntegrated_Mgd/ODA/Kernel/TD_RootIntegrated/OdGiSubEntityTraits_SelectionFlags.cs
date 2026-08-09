using System;

namespace ODA.Kernel.TD_RootIntegrated;

[Flags]
public enum OdGiSubEntityTraits_SelectionFlags
{
	kNoSelectionFlags = 0,
	kSelectionIgnore = 1,
	kHighlightingGeometry = 2,
	kHiddenInHighlight = 4
}
