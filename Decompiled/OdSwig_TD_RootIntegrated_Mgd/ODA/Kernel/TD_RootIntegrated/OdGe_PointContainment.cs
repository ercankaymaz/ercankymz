using System;

namespace ODA.Kernel.TD_RootIntegrated;

[Flags]
public enum OdGe_PointContainment
{
	kInside = 0,
	kOutside = 1,
	kOnBoundary = 2
}
