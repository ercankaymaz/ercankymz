using System;

namespace ODA.Kernel.TD_RootIntegrated;

[Flags]
public enum OdDb_RenderMode
{
	k2DOptimized = 0,
	kWireframe = 1,
	kHiddenLine = 2,
	kFlatShaded = 3,
	kGouraudShaded = 4,
	kFlatShadedWithWireframe = 5,
	kGouraudShadedWithWireframe = 6,
	kMaxRenderMode = 7
}
