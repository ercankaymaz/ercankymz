using System;

namespace ODA.Kernel.TD_RootIntegrated;

[Flags]
public enum AcisDataType
{
	kUndefinedDataType = 0,
	kSurfaceExtrude_CMark = 0x18,
	kSphere_CMark = 0x19,
	kRevolvedSurface_CMark = 0x1A,
	kSolidExtrude_CMark = 0x1B,
	kSphereSlice_CMark = 0x2B,
	kRevolvedSurface_CMark_Any = 0x35,
	kPlaneSurface_CLine = 0x36,
	kSolidExtrude_CLCM = 0x37,
	kPlaneSurface_CLine56 = 0x38,
	kLoftedSurface_CLine58 = 0x3A,
	kLoftedSurface_CLine60 = 0x3C,
	kSolidBox_CLine = 0x3D,
	kExtendCL = 0x3E,
	kExtrudeSurface_TopOrBottom_CLine = 0x40,
	kExtrudeSurface_Side_CLine = 0x41
}
