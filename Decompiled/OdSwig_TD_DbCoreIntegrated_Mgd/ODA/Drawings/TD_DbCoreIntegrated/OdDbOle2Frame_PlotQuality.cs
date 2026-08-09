using System;

namespace ODA.Drawings.TD_DbCoreIntegrated;

[Flags]
public enum OdDbOle2Frame_PlotQuality
{
	kMonochrome = 0,
	kLowGraphics = 1,
	kHighGraphics = 2,
	kAutomatic = 3
}
