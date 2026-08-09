using System;

namespace ODA.Kernel.TD_RootIntegrated;

[Flags]
public enum OdGiPointCloud_ComponentMask
{
	kNoComponents = 0,
	kColors = 1,
	kTransparencies = 2,
	kNormals = 4
}
