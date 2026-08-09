using System;

namespace ODA.Kernel.TD_RootIntegrated;

[Flags]
public enum OdGiEdgeStyle_EdgeStyle
{
	kNoEdgeStyle = 0,
	kVisible = 1,
	kSilhouette = 2,
	kObscured = 4,
	kIntersection = 8
}
