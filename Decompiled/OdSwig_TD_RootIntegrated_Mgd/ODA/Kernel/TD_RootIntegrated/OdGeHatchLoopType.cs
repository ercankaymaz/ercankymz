using System;

namespace ODA.Kernel.TD_RootIntegrated;

[Flags]
public enum OdGeHatchLoopType
{
	OdGeHatchLoopType_Default = 0,
	OdGeHatchLoopType_External = 1,
	OdGeHatchLoopType_Polyline = 2,
	OdGeHatchLoopType_Derived = 4,
	OdGeHatchLoopType_Textbox = 8,
	OdGeHatchLoopType_Outermost = 0x10,
	OdGeHatchLoopType_NotClosed = 0x20,
	OdGeHatchLoopType_SelfIntersecting = 0x40,
	OdGeHatchLoopType_TextIsland = 0x80
}
