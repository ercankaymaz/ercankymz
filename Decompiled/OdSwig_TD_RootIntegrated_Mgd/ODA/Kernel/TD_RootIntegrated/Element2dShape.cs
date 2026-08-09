using System;

namespace ODA.Kernel.TD_RootIntegrated;

[Flags]
public enum Element2dShape
{
	kDefault = 0,
	kAllPolygons = 1,
	kAllQuadrilaterals = 2,
	kAllTriangles = 3
}
