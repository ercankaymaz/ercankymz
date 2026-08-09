using System;

namespace ODA.Kernel.TD_RootIntegrated;

[Flags]
public enum OdGiVisualStyleProperties_EdgeStyles
{
	kNoEdgeStyle = 0,
	kVisibleFlag = 1,
	kSilhouetteFlag = 2,
	kObscuredFlag = 4,
	kIntersectionFlag = 8
}
