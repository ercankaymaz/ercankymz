using System;

namespace ODA.Kernel.TD_RootIntegrated;

[Flags]
public enum OdGiFilterType_
{
	krEBox = 0,
	krETriangle = 1,
	krEGaussian = 2,
	krELanczos = 3,
	krEMitchell = 4
}
