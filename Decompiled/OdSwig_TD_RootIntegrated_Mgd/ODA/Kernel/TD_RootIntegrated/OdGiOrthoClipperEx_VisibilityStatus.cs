using System;

namespace ODA.Kernel.TD_RootIntegrated;

[Flags]
public enum OdGiOrthoClipperEx_VisibilityStatus
{
	kStatusInvisible = -1,
	kStatusClipped = 0,
	kStatusVisible = 1
}
