using System;

namespace ODA.Kernel.TD_RootIntegrated;

[Flags]
public enum OdGiOrthoClipperEx_ClipStageFlags
{
	kCSNoFlags = 0,
	kCSDisabled = 1,
	kCSInverted = 2,
	kCSEnableSections = 4,
	kCSEnableCutting = 8,
	kCSPassNonSections = 0x10
}
