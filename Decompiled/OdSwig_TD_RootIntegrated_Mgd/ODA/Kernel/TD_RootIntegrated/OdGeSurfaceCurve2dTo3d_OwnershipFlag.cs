using System;

namespace ODA.Kernel.TD_RootIntegrated;

[Flags]
public enum OdGeSurfaceCurve2dTo3d_OwnershipFlag
{
	kCurveCopy = 1,
	kCurveOwn = 2,
	kCurveReference = 3,
	kSurfaceCopy = 4,
	kSurfaceOwn = 8,
	kSurfaceReference = 0xC,
	kCopy = 5,
	kOwn = 0xA,
	kReference = 0xF,
	kCurveMask = 3,
	kSurfaceMask = 0xC
}
