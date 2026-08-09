using System;

namespace ODA.Kernel.TD_RootIntegrated;

[Flags]
public enum OdGiProgressiveMeshGenerator_Status
{
	kStatus_Ok = 0,
	kStatus_DegenerateFacesIgnored = 1,
	kStatus_NonManifoldFacesIgnored = 2,
	kStatus_InvalidFacesIgnored = 4,
	kStatus_ZeroNormalFacesIgnored = 8,
	kStatus_NonTriangleFaceTriangulated = 0x10
}
