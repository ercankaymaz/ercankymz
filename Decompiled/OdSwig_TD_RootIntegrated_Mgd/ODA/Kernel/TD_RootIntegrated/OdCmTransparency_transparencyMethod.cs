using System;

namespace ODA.Kernel.TD_RootIntegrated;

[Flags]
public enum OdCmTransparency_transparencyMethod
{
	kByLayer = 0,
	kByBlock = 1,
	kByAlpha = 2,
	kErrorValue = 3
}
