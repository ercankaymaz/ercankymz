using System;

namespace ODA.Kernel.TD_RootIntegrated;

[Flags]
public enum OdGiMrFilter_
{
	krBox = 0,
	krTriangle = 1,
	krGauss = 2,
	krMitchell = 3,
	krLanczos = 4
}
