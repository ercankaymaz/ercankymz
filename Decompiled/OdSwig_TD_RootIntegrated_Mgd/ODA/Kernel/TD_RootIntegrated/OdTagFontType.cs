using System;

namespace ODA.Kernel.TD_RootIntegrated;

[Flags]
public enum OdTagFontType
{
	kFontTypeUnknown = 0,
	kFontTypeShx = 1,
	kFontTypeTrueType = 2,
	kFontTypeShape = 3,
	kFontTypeBig = 4,
	kFontTypeRsc = 5
}
