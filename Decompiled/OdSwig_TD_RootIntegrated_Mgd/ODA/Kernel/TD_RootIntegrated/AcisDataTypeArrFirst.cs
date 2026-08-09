using System;

namespace ODA.Kernel.TD_RootIntegrated;

[Flags]
public enum AcisDataTypeArrFirst
{
	kUndefinedDataTypeArrFirst = 0,
	kArrFirstSurfaceExtrude_CMark = 5,
	kArrFirstSolidExtrude_CMark = 6,
	kArrPlaneSurface_CLine56 = 0xC,
	kArrSolidExtrude_CLCM = 0xB,
	kArrSolidBox_CLine = 0xE,
	kArrExtendCL = 0xF,
	kArrExtrudeSurface_CLine = 0xD
}
