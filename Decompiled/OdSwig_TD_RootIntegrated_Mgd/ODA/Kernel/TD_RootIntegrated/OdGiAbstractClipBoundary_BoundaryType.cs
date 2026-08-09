using System;

namespace ODA.Kernel.TD_RootIntegrated;

[Flags]
public enum OdGiAbstractClipBoundary_BoundaryType
{
	kNormal = 0,
	kInverted = 1,
	kExtended = 2,
	kComplex = 3,
	kPlanar = 4,
	kMulti = 5
}
