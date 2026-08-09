using System;

namespace ODA.Kernel.TD_RootIntegrated;

[Flags]
public enum OdGe_ExternalEntityKind
{
	kAcisEntity = 0,
	kGe3dCurveEntity = 1,
	kGeSurfaceEntity = 2,
	kExternalEntityUndefined = 3,
	kBimEntity = 4,
	kIfcEntity = 5
}
