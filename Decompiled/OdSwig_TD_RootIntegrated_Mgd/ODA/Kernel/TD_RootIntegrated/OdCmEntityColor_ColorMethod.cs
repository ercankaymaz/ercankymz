using System;

namespace ODA.Kernel.TD_RootIntegrated;

[Flags]
public enum OdCmEntityColor_ColorMethod
{
	kByLayer = 0xC0,
	kByBlock = 0xC1,
	kByColor = 0xC2,
	kByACI = 0xC3,
	kByPen = 0xC4,
	kForeground = 0xC5,
	kByDgnIndex = 0xC7,
	kNone = 0xC8
}
