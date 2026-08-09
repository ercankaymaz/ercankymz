using System;

namespace ODA.Drawings.TD_DbCoreIntegrated;

[Flags]
public enum OdDbPlotSettings_PlotType
{
	kDisplay = 0,
	kExtents = 1,
	kLimits = 2,
	kView = 3,
	kWindow = 4,
	kLayout = 5
}
