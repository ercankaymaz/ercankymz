using System;

namespace ODA.Kernel.TD_RootIntegrated;

[Flags]
public enum OdGiConveyorGeometry_EConveyorBoundaryInfoFlags
{
	kBoundaryProcXform = 1,
	kBoundaryProcXformNonUni = 2,
	kBoundaryProcProjection = 4,
	kBoundaryProcClip = 8,
	kBoundaryProcClipFull = 0x10
}
