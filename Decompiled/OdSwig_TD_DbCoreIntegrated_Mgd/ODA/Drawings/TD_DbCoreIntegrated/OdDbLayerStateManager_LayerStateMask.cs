using System;

namespace ODA.Drawings.TD_DbCoreIntegrated;

[Flags]
public enum OdDbLayerStateManager_LayerStateMask
{
	kNone = 0,
	kOn = 1,
	kFrozen = 2,
	kLocked = 4,
	kPlot = 8,
	kNewViewport = 0x10,
	kColor = 0x20,
	kLineType = 0x40,
	kLineWeight = 0x80,
	kPlotStyle = 0x100,
	kCurrentViewport = 0x200,
	kTransparency = 0x400,
	kAll = 0x7FF,
	kStateIsHidden = 0x8000,
	kLastRestored = 0x10000,
	kDecomposition = 0x207FF
}
