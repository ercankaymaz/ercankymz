using System;

namespace ODA.Drawings.TD_DbCoreIntegrated;

[Flags]
public enum OdDbViewport_ShadePlotType
{
	kAsDisplayed = 0,
	kWireframe = 1,
	kHidden = 2,
	kRendered = 3,
	kVisualStyle = 4,
	kRenderPreset = 5
}
