using System;

namespace ODA.Drawings.TD_DbCoreIntegrated;

[Flags]
public enum OdModelerGeometry_MaterialState
{
	kNoMaterials = 0,
	kHasMaterials = 1,
	kUnknown = 2
}
