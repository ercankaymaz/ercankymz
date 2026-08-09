using System;

namespace ODA.Kernel.TD_RootIntegrated;

[Flags]
public enum OdGiVisualStyleProperties_FaceLightingQuality
{
	kNoLighting = 0,
	kPerFaceLighting = 1,
	kPerVertexLighting = 2,
	kPerPixelLighting = 3
}
