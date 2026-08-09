using System;

namespace ODA.Drawings.TD_DbCoreIntegrated;

[Flags]
public enum OdXRefLayerPropertyOverride_XRefLayerPropertyOverrideType
{
	On = 0,
	Freeze = 1,
	Lock = 2,
	Plot = 3,
	Color = 4,
	Linetype = 5,
	Lineweight = 6,
	Transparency = 7,
	PlotStyle = 8,
	NewVPFreeze = 9,
	Description = 0xA
}
