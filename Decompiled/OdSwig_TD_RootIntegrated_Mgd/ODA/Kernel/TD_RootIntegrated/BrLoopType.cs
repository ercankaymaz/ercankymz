using System;

namespace ODA.Kernel.TD_RootIntegrated;

[Flags]
public enum BrLoopType
{
	odbrLoopUnclassified = 0,
	odbrLoopExterior = 1,
	odbrLoopInterior = 2,
	odbrLoopWinding = 3
}
