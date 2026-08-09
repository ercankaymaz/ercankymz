using System;

namespace ODA.Drawings.TD_DbCoreIntegrated;

[Flags]
public enum OdDbLoftedSurface_LoftSurfaceType
{
	kLoftSurf = 0,
	kLoftBlendSurf = 1,
	kLoftNetworkSurf = 2
}
