using System;

namespace ODA.Kernel.TD_RootIntegrated;

[Flags]
public enum OdGiConveyorContext_ConveyorContextFlags
{
	kSpatialFilterSimplPline = 1,
	kSpatialFilterSimplNurbs = 2,
	kSpatialFilterSimplText = 4,
	kSpatialFilterSimplShape = 8,
	kSpatialFilterSimplAll = 0xF,
	kEmbranchmentSimplText = 0x10,
	kEmbranchmentSimplNurbs = 0x20,
	kEmbranchmentSimplAll = 0x30,
	kConveyorSimplAll = 0x3F,
	kPlineMarkers = 0x40,
	kForceMarkersOnModified = 0x80,
	kPolylineMarkers = 0x100,
	kPlineAllowArcProc = 0x200,
	kTestMode = 0x400,
	kLineTyperAfterMetafile = 0x800
}
