using System;

namespace ODA.Drawings.TD_DbCoreIntegrated;

[Flags]
public enum OdDbRasterVariables_FrameSettings
{
	kImageFrameInvalid = -1,
	kImageFrameOff = 0,
	kImageFrameAbove = 1,
	kImageFrameBelow = 2,
	kImageFrameOnNoPlot = 3
}
