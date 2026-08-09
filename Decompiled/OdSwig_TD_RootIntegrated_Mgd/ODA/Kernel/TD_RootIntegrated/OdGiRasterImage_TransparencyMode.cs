using System;

namespace ODA.Kernel.TD_RootIntegrated;

[Flags]
public enum OdGiRasterImage_TransparencyMode
{
	kTransparencyDef = -1,
	kTransparencyOff = 0,
	kTransparency1Bit = 1,
	kTransparency8Bit = 2
}
