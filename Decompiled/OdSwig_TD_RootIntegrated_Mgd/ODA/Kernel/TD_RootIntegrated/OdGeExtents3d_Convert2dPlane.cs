using System;

namespace ODA.Kernel.TD_RootIntegrated;

[Flags]
public enum OdGeExtents3d_Convert2dPlane
{
	kConvert2dPlaneXY = 4,
	kConvert2dPlaneXZ = 8,
	kConvert2dPlaneYX = 1,
	kConvert2dPlaneYZ = 9,
	kConvert2dPlaneZX = 2,
	kConvert2dPlaneZY = 6
}
