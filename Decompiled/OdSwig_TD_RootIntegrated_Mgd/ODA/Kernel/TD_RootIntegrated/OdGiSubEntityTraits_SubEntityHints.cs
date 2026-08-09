using System;

namespace ODA.Kernel.TD_RootIntegrated;

[Flags]
public enum OdGiSubEntityTraits_SubEntityHints
{
	kHint2DAttributes = 1,
	kHint3DAttributes = 2,
	kHintAllAttributes = 3,
	kHintSnapModeOn = 4,
	kHintDefaultState = 3
}
