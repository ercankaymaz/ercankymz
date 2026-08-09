using System;

namespace ODA.Kernel.TD_RootIntegrated;

[Flags]
public enum OdGsPropertiesDirectRenderOutput_DirectRenderFlags
{
	DirectRender_Point = 1,
	DirectRender_LineFlat = 2,
	DirectRender_LineGouraud = 4,
	DirectRender_TriangleFlat = 8,
	DirectRender_TriangleGouraud = 0x10,
	DirectRender_PolygoneFlat = 0x20,
	DirectRender_PolygoneGouraud = 0x40,
	DirectRender_Image = 0x80
}
